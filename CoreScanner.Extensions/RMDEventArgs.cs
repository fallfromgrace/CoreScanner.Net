using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class RmdEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public RmdEventType EventType
        {
            get { return this.eventType; }
        }

        /// <summary>
        /// 
        /// </summary>
        private RmdEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="outXml"></param>
        /// <returns></returns>
        public static RmdEventArgs Parse(Int16 eventType, String outXml)
        {
            RmdEventArgs eventArgs = new RmdEventArgs();
            eventArgs.eventType = (RmdEventType)eventType;
            return eventArgs;
        }

        private RmdEventType eventType;
    }

    internal class SessionStart
    {

    }

    internal class DownloadStart
    {

    }

    internal class DownloadProgress
    {

    }

    internal class DownloadEnd
    {

    }

    internal class SessionEnd
    {

    }

    internal class SessionStatus
    {

    }
}
