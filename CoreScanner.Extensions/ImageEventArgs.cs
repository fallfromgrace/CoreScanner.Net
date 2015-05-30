using System;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public ImageEventType EventType
        {
            get { return this.eventType; }
        }

        /// <summary>
        /// 
        /// </summary>
        private ImageEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="size"></param>
        /// <param name="imageFormat"></param>
        /// <param name="imageData"></param>
        /// <param name="scannerData"></param>
        /// <returns></returns>
        public static ImageEventArgs Parse(
            Int16 eventType,
            Int32 size,
            Int16 imageFormat,
            Object imageData,
            String scannerData)
        {
            ImageEventArgs eventArgs = new ImageEventArgs();
            eventArgs.eventType = (ImageEventType)eventType;
            return eventArgs;
        }

        private ImageEventType eventType;
    }
}
