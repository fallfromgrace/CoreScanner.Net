using Light;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Xml.Linq;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ICoreScannerServiceExtensions
    {
        /// <summary>
        /// Gets the attributes of the specified scanner.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        /// <returns></returns>
        public static IObservable<IReadOnlyCollection<AttributeId>> GetAvailableAttributesAsync(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId)));
            IObservable<IReadOnlyCollection<AttributeId>> resultAsync = scannerService
                .WhenCommandResponded()
                .Do(e => e.Status.ThrowIfError())
                .SelectMany(e => e.OutXml
                    .ParseXmlDocument()
                    .Elements("outArgs"))
                .Where(outArgs => outArgs
                    .Elements("scannerID")
                    .All(e => e.Value.ToInt32().Equals(scannerId)))
                .SelectMany(outArgs => outArgs
                    .Elements("arg-xml")
                    .Elements("response"))
                .Where(response => response
                    .Elements("opcode")
                    .Select(opCode => (OperationCode)opCode.Value.ToInt32())
                    .All(opCode => opCode.Equals(OperationCode.GetAllAttributes)))
                .FirstAsync()
                .RunAsync(CancellationToken.None)
                .Select(response => response
                    .Elements("attrib_list")
                    .Elements("attribute")
                    .Select(e => (AttributeId)e.Value.ToInt32())
                    .ToList()
                    .AsReadOnly());
            scannerService
                .ExecuteCommandAsync(OperationCode.GetAllAttributes, inXml.ToString());
            return resultAsync;
        }

        /// <summary>
        /// Gets the specified attribute values for the specified scanner.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static IObservable<IReadOnlyCollection<AttributeInfo>> GetAttributeValuesAsync(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            params AttributeId[] attributes)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);
            Contract.Requires(attributes.Length > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId),
                    new XElement("cmdArgs",
                        new XElement("arg-xml",
                            new XElement("attrib_list", attributes.Cast<Int32>().ToArray())))));
            IObservable<IReadOnlyCollection<AttributeInfo>> resultAsync = scannerService
                .WhenCommandResponded()
                .Do(e => e.Status.ThrowIfError())
                .SelectMany(e => e.OutXml
                    .ParseXmlDocument()
                    .Elements("outArgs"))
                .Where(outXml => outXml
                    .Elements("scannerID")
                    .All(e => e.Value.ToInt32().Equals(scannerId)))
                .SelectMany(outXml => outXml
                    .Elements("arg-xml")
                    .Elements("response"))
                .Where(response => response
                    .Elements("opcode")
                    .Select(e => (OperationCode)e.Value.ToInt32())
                    .All(opCode => opCode.Equals(OperationCode.GetAttribute)))
                .FirstAsync()
                .RunAsync(CancellationToken.None)
                .Select(outXml => outXml
                    .Elements("attrib_list")
                    .Elements("attribute")
                    .Select(e => AttributeInfo.Parse(e.ToString()))
                    .ToList()
                    .AsReadOnly()); 
            scannerService
                 .ExecuteCommandAsync(OperationCode.GetAttribute, inXml.ToString());
            return resultAsync;
        }

        /// <summary>
        /// Gets the next attribute value of the specified attribute for the specified scanner.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        /// <remarks>
        /// Can be used to create an asynchronous scanner attribute iterator.
        /// </remarks>
        public static IObservable<AttributeInfo> GetNextAttributeValueAsync(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            AttributeId attributeId)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId),
                    new XElement("cmdArgs",
                        new XElement("arg-xml",
                            new XElement("attrib_list", (Int32)attributeId)))));
            IObservable<AttributeInfo> resultAsync = scannerService
                .WhenCommandResponded()
                .Do(e => e.Status.ThrowIfError())
                .SelectMany(e => e.OutXml
                    .ParseXmlDocument()
                    .Elements("outArgs"))
                .Where(outArgs => outArgs
                    .Elements("scannerID")
                    .All(e => e.Value.ToInt32().Equals(scannerId)))
                .SelectMany(outArgs => outArgs
                    .Elements("arg-xml")
                    .Elements("response"))
                .Where(response => response
                    .Elements("opcode")
                    .Select(opCode => (OperationCode)opCode.Value.ToInt32())
                    .All(opCode => opCode.Equals(OperationCode.GetNextAttribute)))
                .FirstAsync()
                .RunAsync(CancellationToken.None)
                .SelectMany(response => response
                    .Elements("attrib_list")
                    .Elements("attribute")
                    .Select(attribute => AttributeInfo.Parse(attribute.ToString())));
            scannerService
                .ExecuteCommandAsync(OperationCode.GetNextAttribute, inXml.ToString());
            return resultAsync;
        }

        /// <summary>
        /// Sets the values of attributes for the specified scanner.  Attributes set using this 
        /// command are lost after the next power down.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        public static void SetAttributeValue(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            AttributeInfo attribute)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId),
                    new XElement("cmdArgs",
                        new XElement("arg-xml",
                            new XElement("attrib_list",
                                new XElement("attribute",
                                    new XElement("id", (Int32)attribute.Id),
                                    new XElement("datatype", attribute.Type.ToStringCode()),
                                    new XElement("value", attribute.Value)))))));
            scannerService
                .ExecuteCommand(OperationCode.SetAttribute, inXml.ToString());
        }

        /// <summary>
        /// Stores the values of attributes for the specified scanner.  Attributes set using this 
        /// command are persistent over power down and power up cycles.
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        public static void StoreAttributeValue(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            AttributeInfo attribute)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId),
                    new XElement("cmdArgs",
                        new XElement("arg-xml",
                            new XElement("attrib_list",
                                new XElement("attribute",
                                    new XElement("id", (Int32)attribute.Id),
                                    new XElement("datatype", attribute.Type.ToStringCode()),
                                    new XElement("value", attribute.Value)))))));
            scannerService
                .ExecuteCommand(OperationCode.StoreAttribute, inXml.ToString());
        }

        /// <summary>
        /// Get the topology of devices that are connected to the calling system.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <returns></returns>
        public static IEnumerable<ScannerInfo> GetDeviceTopology(
            this ICoreScannerService scannerService)
        {
            Contract.Requires(scannerService != null);

            XDocument inXml = new XDocument(
                new XElement("inArgs", String.Empty));
            return scannerService
                .ExecuteCommand(OperationCode.GetDeviceTopology, inXml.ToString())
                .ParseXmlDocument()
                .Elements("outArgs")
                .Elements("arg-xml")
                .Elements("scanners")
                .Elements("scanner")
                .Select(scanner => ScannerInfo.Parse(scanner.ToString()));
        }
    }
}
