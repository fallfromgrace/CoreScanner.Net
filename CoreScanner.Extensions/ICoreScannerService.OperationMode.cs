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
        /// <param name="scannerId"></param>
        /// <param name="mode"></param>
        public static void SetCaptureMode(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            CaptureMode mode)
        {
            Contract.Requires(scannerService != null);
            Contract.Requires(scannerId > 0);

            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            switch (mode)
            {
                case CaptureMode.Barcode:
                    scannerService
                        .ExecuteCommand(OperationCode.DeviceCaptureBarcode, inXml.ToString());
                    break;
                case CaptureMode.Image:
                    scannerService
                        .ExecuteCommand(OperationCode.DeviceCaptureImage, inXml.ToString());
                    break;
                case CaptureMode.Video:
                    scannerService
                        .ExecuteCommand(OperationCode.DeviceCaptureVideo, inXml.ToString());
                    break;
                default: throw new ArgumentOutOfRangeException("mode");
            }
        }
    }
}
