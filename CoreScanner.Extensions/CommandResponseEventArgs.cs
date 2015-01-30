using System;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandReponseEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public Status Status
        {
            get { return this.status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public String OutXml
        {
            get { return this.outXml; }
        }

        /// <summary>
        /// 
        /// </summary>
        private CommandReponseEventArgs()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="outXml"></param>
        /// <returns></returns>
        public static CommandReponseEventArgs Parse(Int16 status, String outXml)
        {
            CommandReponseEventArgs eventArgs = new CommandReponseEventArgs();
            eventArgs.status = (Status)status;
            eventArgs.outXml = outXml;
            return eventArgs;
        }
        
        private Status status;
        private String outXml;
    }
}
