using System;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public VideoEventType EventType
        {
            get { return this.eventType; }
        }

        /// <summary>
        /// 
        /// </summary>
        private VideoEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="size"></param>
        /// <param name="videoData"></param>
        /// <param name="scannerData"></param>
        /// <returns></returns>
        public static VideoEventArgs Parse(Int16 eventType, Int32 size, Object videoData, String scannerData)
        {
            VideoEventArgs eventArgs = new VideoEventArgs();
            eventArgs.eventType = (VideoEventType)eventType;
            return eventArgs;
        }

        private VideoEventType eventType;
    }
}
