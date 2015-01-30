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
        /// 
        /// </summary>
        /// <param name="coreScannerService"></param>
        /// <param name="mode"></param>
        /// <param name="scannerId"></param>
        /// <param name="isSilent"></param>
        /// <param name="isPermanent"></param>
        public static void SetHostMode(
            this ICoreScannerService scannerService,
            HostMode mode,
            Int32 scannerId,
            Boolean isSilent,
            Boolean isPermanent)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId),
                    new XElement("cmdArgs",
                        new XElement("arg-string", mode.GetStringCode()),
                        new XElement("arg-bool", isSilent),
                        new XElement("arg-bool", isPermanent))));
            scannerService
                .ExecuteCommand(OperationCode.DeviceSwitchHostMode, inXml.ToString());
        }
    }
}
