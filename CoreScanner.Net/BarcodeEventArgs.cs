using Light;
using Light.Linq;
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class BarcodeEventArgs : EventArgs
    {
        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public BarcodeEventType EventType
        {
            get { return this.eventType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 ScannerId
        {
            get { return this.scannerId; }
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
        public BarcodeDataType DataType
        {
            get { return this.dataType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String DataLabel
        {
            get { return this.dataLabel; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Byte[] RawData
        {
            get { return this.rawData; }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private BarcodeEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="outXml"></param>
        /// <returns></returns>
        public static BarcodeEventArgs Parse(Int16 eventType, String outXml)
        {
            Contract.Requires(outXml != null);
            Contract.Ensures(Contract.Result<BarcodeEventArgs>() != null);

            BarcodeEventArgs eventArgs = new BarcodeEventArgs();
            XElement outArgs = XDocument
                .Parse(outXml)
                .Elements("outArgs")
                .FirstOrDefault();
            XElement scanData = outArgs
                .Elements("arg-xml")
                .Elements("scandata")
                .FirstOrDefault();
            eventArgs.eventType = (BarcodeEventType)eventType;
            eventArgs.scannerId = outArgs
                .Elements("scannerID")
                .Select(scannerId => scannerId.Value.ToInt32())
                .FirstOrDefault();
            eventArgs.modelNumber = scanData
                .Elements("modelnumber")
                .Select(modelnumber => modelnumber.Value.Trim())
                .FirstOrDefault();
            eventArgs.serialNumber = scanData
                .Elements("serialnumber")
                .Select(serialnumber => serialnumber.Value.Trim())
                .FirstOrDefault();
            eventArgs.guid = scanData
                .Elements("GUID")
                .Select(guid => guid.Value.ToGuid())
                .FirstOrDefault();
            eventArgs.dataType = scanData
                .Elements("datatype")
                .Select(dataType => (BarcodeDataType)dataType.Value.ToInt32())
                .FirstOrDefault();
            eventArgs.dataLabel = scanData
                .Elements("datalabel")
                .Select(dataLabel => dataLabel.Value
                    .Replace("0x", String.Empty)
                    .Split(' ')
                    .Select(v => Convert.ToByte(v, 16))
                    .DecodeToString(Encoding.UTF8))
                .FirstOrDefault();
            eventArgs.rawData = scanData
                .Elements("rawdata")
                .Select(dataLabel => dataLabel.Value
                    .Replace("0x", String.Empty)
                    .Split(' ')
                    .Select(v => Convert.ToByte(v, 16))
                    .ToArray())
                .FirstOrDefault();
            return eventArgs;
        }

        #region Private Fields

        private BarcodeEventType eventType;
        private Int32 scannerId;
        private String modelNumber;
        private String serialNumber;
        private Guid guid;
        private BarcodeDataType dataType;
        private String dataLabel;
        private Byte[] rawData;

        #endregion
    }
}
