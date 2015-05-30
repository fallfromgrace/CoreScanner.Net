using Light;
using System;
using System.Linq;
using System.Xml.Linq;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class PnpEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public PnpEventType EventType
        {
            get { return this.eventType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ScannerInfo ScannerInfo
        {
            get { return this.scannerInfo; }
        }

        /// <summary>
        /// 
        /// </summary>
        private PnpEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="outXml"></param>
        /// <returns></returns>
        public static PnpEventArgs Parse(Int16 eventType, String outXml)
        {
            PnpEventArgs eventArgs = new PnpEventArgs();
            XElement argXml = XDocument
                    .Parse(outXml)
                    .Elements("outArgs")
                    .SelectMany(outArgs => outArgs
                        .Elements("arg-xml"))
                    .FirstOrDefault();
            Int32 statusValue = argXml
                .Elements("status")
                .Select(status => status.Value.ToInt32())
                .FirstOrDefault();
            XElement scannerInfo = argXml
                .Elements("scanners")
                .SelectMany(scanners => scanners
                    .Elements("scanner"))
                .FirstOrDefault();
            eventArgs.eventType = (PnpEventType)eventType;
            eventArgs.scannerInfo = ScannerInfo.Parse(scannerInfo.ToString());
            return eventArgs;
        }

        private ScannerInfo scannerInfo;
        private PnpEventType eventType;
    }
}
