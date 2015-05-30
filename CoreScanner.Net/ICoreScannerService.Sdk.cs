using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics.Contracts;
using Light;
using Light.Linq;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ICoreScannerServiceExtensions
    {
        /// <summary>
        /// Gets the version of CoreScanner Driver.
        /// </summary>
        /// <param name="coreScannerService"></param>
        /// <returns></returns>
        /// <remarks>
        /// Major.Minor.Revision
        /// </remarks>
        public static String GetVersion(
            this ICoreScannerService coreScannerService)
        {
            Contract.Requires(coreScannerService != null);

            XDocument inXml = new XDocument(
                new XElement("inArgs", String.Empty));
            return coreScannerService
                .ExecuteCommand(OperationCode.GetVersion, inXml.ToString())
                .ParseXmlDocument()
                .Elements("outArgs")
                .SelectMany(outArgs => outArgs
                    .Elements("arg-xml"))
                .SelectMany(argXml => argXml
                    .Elements("arg-string"))
                .Select(e => e.Value)
                .FirstOrDefault();
        }

        /// <summary>
        /// Registers the specified CoreScanner events.
        /// </summary>
        /// <param name="coreScannerService"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public static void RegisterForEvents(
            this ICoreScannerService coreScannerService, 
            EventType events)
        {
            Contract.Requires(coreScannerService != null);

            List<EventType> eventCodes = events
                .GetFlags<EventType>()
                .ToList();
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("cmdArgs",
                        new XElement("arg-int", eventCodes.Count),
                        new XElement("arg-int", eventCodes.Cast<Int32>().StringJoin(",")))));
            coreScannerService
                .ExecuteCommand(OperationCode.RegisterForEvents, inXml.ToString());
        }

        /// <summary>
        /// Unregisters the specified CoreScanner events.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public static void UnregisterForEvents(
            this ICoreScannerService scannerService,
            EventType events)
        {
            Contract.Requires(scannerService != null);

            List<EventType> eventCodes = events
                .GetFlags<EventType>()
                .ToList();
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("cmdArgs",
                        new XElement("arg-int", eventCodes.Count),
                        new XElement("arg-int", eventCodes.Cast<Int32>().StringJoin(",")))));
            scannerService
                .ExecuteCommand(OperationCode.UnregisterForEvents, inXml.ToString());
        }
    }
}
