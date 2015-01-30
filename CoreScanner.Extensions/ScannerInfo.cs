using Light;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// Device information concerning a Motorola scanner.
    /// </summary>
    /// <remarks>
    /// Not all fields may be populated due to scanner type, mode, or function call.
    /// </remarks>
    public sealed class ScannerInfo
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public ScannerType Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String ModelNumber
        {
            get { return this.modelNumber; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String SerialNumber
        {
            get { return this.serialNumber; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid Guid
        {
            get { return this.guid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Vid
        {
            get { return this.vid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Pid
        {
            get { return this.pid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ManufactureDate
        {
            get { return this.manufactureDate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String FirmwareVersion
        {
            get { return this.firmwareVersion; }
        }

        /// <summary>
        /// 
        /// </summary>
        public IReadOnlyCollection<ScannerInfo> CascadedScanners
        {
            get { return this.cascadedScanners; }
        }

        #endregion

        #region Static Factory

        private ScannerInfo()
        {

        }

        /// <summary>
        /// Parses scanner info from the specified xml string.
        /// </summary>
        /// <param name="scannerInfoXml"></param>
        /// <returns></returns>
        internal static ScannerInfo Parse(String scannerInfoXml)
        {
            Contract.Requires(scannerInfoXml != null);
            Contract.Ensures(Contract.Result<ScannerInfo>() != null);

            ScannerInfo scannerInfo = new ScannerInfo();
            XElement scanner = scannerInfoXml
                .ParseXmlDocument()
                .Elements("scanner")
                .FirstOrDefault();
            scannerInfo.type = scanner
                .Attributes("type")
                .Select(type => type.Value.ToScannerType())
                .FirstOrDefault();
            scannerInfo.id = scanner
                .Elements("scannerID")
                .Select(scannerId => scannerId.Value.ToInt32())
                .FirstOrDefault();
            scannerInfo.modelNumber = scanner
                .Elements("modelnumber")
                .Where(modelNumber => modelNumber.Value.IsNullOrWhiteSpace() == false)
                .Select(modelnumber => modelnumber.Value.Trim())
                .FirstOrDefault();
            scannerInfo.serialNumber = scanner
                .Elements("serialnumber")
                .Where(serialNumber => serialNumber.Value.IsNullOrWhiteSpace() == false)
                .Select(serialnumber => serialnumber.Value.Trim())
                .FirstOrDefault();
            scannerInfo.guid = scanner
                .Elements("GUID")
                .Where(guid => guid.Value.IsNullOrWhiteSpace() == false)
                .Select(guid => guid.Value.ToGuid())
                .FirstOrDefault();
            scannerInfo.vid = scanner
                .Elements("VID")
                .Where(vid => vid.Value.IsNullOrWhiteSpace() == false)
                .Select(vid => vid.Value.ToInt32())
                .FirstOrDefault();
            scannerInfo.pid = scanner
                .Elements("PID")
                .Where(pid => pid.Value.IsNullOrWhiteSpace() == false)
                .Select(pid => pid.Value.ToInt32())
                .FirstOrDefault();
            scannerInfo.manufactureDate = scanner
                .Elements("DoM")
                .Where(manufactureDate => manufactureDate.Value.IsNullOrWhiteSpace() == false)
                .Select(manufactureDate => manufactureDate.Value.ToDateTime())
                .FirstOrDefault();
            scannerInfo.firmwareVersion = scanner
                .Elements("firmware")
                .Where(firmwareVersion => firmwareVersion.Value.IsNullOrWhiteSpace() == false)
                .Select(firmwareVersion => firmwareVersion.Value.Trim())
                .FirstOrDefault();
            scannerInfo.cascadedScanners = scanner
                .Elements("scanner")
                .Where(element => element.Value.IsNullOrWhiteSpace() == false)
                .Select(element => ScannerInfo.Parse(element.ToString()))
                .ToList()
                .AsReadOnly();
            return scannerInfo;
        }

        #endregion

        #region Private Fields

        private ScannerType type;
        private Int32 id;
        private String modelNumber;
        private String serialNumber;
        private Guid guid;
        private Int32 vid;
        private Int32 pid;
        private DateTime manufactureDate;
        private String firmwareVersion;
        private IReadOnlyCollection<ScannerInfo> cascadedScanners;

        #endregion
    }
}
