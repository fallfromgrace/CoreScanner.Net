using System;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public NotificationEventType EventType
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
        private NotificationEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="outXml"></param>
        /// <returns></returns>
        public static NotificationEventArgs Parse(Int16 eventType, String outXml)
        {
            NotificationEventArgs eventArgs = new NotificationEventArgs();
            eventArgs.eventType = (NotificationEventType)eventType;
            eventArgs.scannerInfo = ScannerInfo.Parse(outXml);
            return eventArgs;
        }

        private NotificationEventType eventType;
        private ScannerInfo scannerInfo;
    }
}
