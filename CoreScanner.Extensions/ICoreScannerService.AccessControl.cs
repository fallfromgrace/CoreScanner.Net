using System;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ICoreScannerServiceExtensions
    {
        /// <summary>
        /// Claims the specified device.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="scannerId"></param>
        public static void ClaimDevice(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            scannerService
                .ExecuteCommand(OperationCode.ClaimDevice, inXml.ToString());
        }

        /// <summary>
        /// Releases the specified device.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="scannerId"></param>
        public static void ReleaseDevice(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            scannerService
                .ExecuteCommand(OperationCode.ReleaseDevice, inXml.ToString());
        }
    }
}
