using System;
using System.Linq;
using System.Xml.Linq;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ICoreScannerServiceExtensions
    {
        /// <summary>
        /// Aborts MacroPDF on the specified scanner.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        public static void AbortMacroPdf(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            scannerService
                .ExecuteCommand(OperationCode.AbortMacroPdf, inXml.ToString());
        }

        /// <summary>
        /// Aborts a firmware update process on the specified scanner.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        public static void AbortFirmwareUpdate(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            scannerService
                .ExecuteCommand(OperationCode.FlushMacroPdf, inXml.ToString());
        }

        /// <summary>
        /// Turns the aim on or off on the specified scanner.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="scannerId"></param>
        /// <param name="on"></param>
        public static void ToggleAim(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            Boolean on)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            if (on == true)
                scannerService.ExecuteCommand(OperationCode.AimOn, inXml.ToString());
            else
                scannerService.ExecuteCommand(OperationCode.AimOff, inXml.ToString());
        }

        /// <summary>
        /// Flush MacroPDF on the specified scanner.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        public static void FlushMacroPdf(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            scannerService
                .ExecuteCommand(OperationCode.FlushMacroPdf, inXml.ToString());
        }

        /// <summary>
        /// Pulls or releases the trigger on the specified scanner.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="scannerId"></param>
        /// <param name="pull"></param>
        public static void ToggleTrigger(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            Boolean pull)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            if (pull == true)
                scannerService.ExecuteCommand(OperationCode.DevicePullTrigger, inXml.ToString());
            else
                scannerService.ExecuteCommand(OperationCode.DeviceReleaseTrigger, inXml.ToString());
        }

        /// <summary>
        /// Enables or disables scanning on the specified scanner.
        /// </summary>
        /// <param name="service"></param>
        /// <param name="scannerId"></param>
        /// <param name="pull"></param>
        public static void ToggleScan(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            Boolean enable)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            if (enable == true)
                scannerService.ExecuteCommand(OperationCode.ScanEnable, inXml.ToString());
            else
                scannerService.ExecuteCommand(OperationCode.ScanDisable, inXml.ToString());
        }

        /// <summary>
        /// Sets all parameters to default values on the specified scanner.
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        public static void SetParametersToDefault(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerId", scannerId)));
            scannerService
                .ExecuteCommand(OperationCode.SetParameterDefaults, inXml.ToString());
        }

        /// <summary>
        /// Sets the specified parameters on the specified scanner temporarily.  
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        /// <param name="attributes"></param>
        /// <remarks>
        /// Parameters sets using this command are lost over the next power cycle.
        /// </remarks>
        public static void SetParameters(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            params AttributeInfo[] attributes)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId),
                    new XElement("cmdArgs",
                        new XElement("arg-xml",
                            new XElement("attrib_list", attributes
                                .Select(attribute => 
                                    new XElement("attribute",
                                        new XElement("id", (Int32)attribute.Id),
                                        new XElement("datatype", attribute.Type.ToStringCode()),
                                        new XElement("value", attribute.Value)))
                                .ToArray())))));
            scannerService
                .ExecuteCommand(OperationCode.DeviceSetParameters, inXml.ToString());
        }

        /// <summary>
        /// Sets the specified parameters on the specified scanner persistently.  
        /// </summary>
        /// <param name="scannerService"></param>
        /// <param name="scannerId"></param>
        /// <param name="attributes"></param>
        /// <remarks>
        /// Parameters sets using this command are persistent over power cycles.
        /// </remarks>
        public static void StoreParameters(
            this ICoreScannerService scannerService,
            Int32 scannerId,
            params AttributeInfo[] attributes)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId),
                    new XElement("cmdArgs",
                        new XElement("arg-xml",
                            new XElement("attrib_list", attributes
                                .Select(attribute =>
                                    new XElement("attribute",
                                        new XElement("id", (Int32)attribute.Id),
                                        new XElement("datatype", attribute.Type.ToStringCode()),
                                        new XElement("value", attribute.Value)))
                                .ToArray())))));
            scannerService
                .ExecuteCommand(OperationCode.SetParameterPersistence, inXml.ToString());
        }

        /// <summary>
        /// Reboots the specified scanner.  
        /// </summary>
        /// <param name="coreScannerService"></param>
        /// <param name="scannerId"></param>
        /// <remarks>
        /// Direct execution of this command on a Bluetooth scanner does not result in a reboot.  
        /// This command needs to be sent to the scanner's associated cradle to reboot the 
        /// Bluetooth scanner.
        /// </remarks>
        public static void RebootScanner(
            this ICoreScannerService scannerService,
            Int32 scannerId)
        {
            XDocument inXml = new XDocument(
                new XElement("inArgs",
                    new XElement("scannerID", scannerId)));
            scannerService
                .ExecuteCommand(OperationCode.RebootScanner, inXml.ToString());
        }
    }
}
