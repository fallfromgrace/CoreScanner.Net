using System;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class IOEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        private IOEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static IOEventArgs Parse(Int16 eventType, Byte data)
        {
            IOEventArgs eventArgs = new IOEventArgs();
            return eventArgs;
        }
    }
}
