using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class BinaryDataEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public BinaryDataFormat Format
        {
            get { return this.format; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="size"></param>
        /// <param name="dataFormat"></param>
        /// <param name="binaryData"></param>
        /// <param name="scannerData"></param>
        /// <returns></returns>
        public static BinaryDataEventArgs Parse(
            Int16 eventType, 
            Int32 size, 
            Int16 dataFormat, 
            Object binaryData, 
            String scannerData)
        {
            BinaryDataEventArgs eventArgs = new BinaryDataEventArgs();
            eventArgs.format = (BinaryDataFormat)dataFormat;
            return eventArgs;
        }

        private BinaryDataFormat format;
    }
}
