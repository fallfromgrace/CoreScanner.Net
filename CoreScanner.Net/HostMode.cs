using System;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public enum HostMode
    {
        /// <summary>
        /// 
        /// </summary>
        USB_IBMHID,

        /// <summary>
        /// 
        /// </summary>
        USB_IBMTT,

        /// <summary>
        /// 
        /// </summary>
        USB_HIDKB,

        /// <summary>
        /// 
        /// </summary>
        USB_OPOS,

        /// <summary>
        /// 
        /// </summary>
        USB_SNAPI,

        /// <summary>
        /// 
        /// </summary>
        USB_SNAPI_NoImaging,

        /// <summary>
        /// 
        /// </summary>
        USB_CDC
    }

    /// <summary>
    /// 
    /// </summary>
    internal static class HostModeExtensions
    {
        public static String GetStringCode(
            this HostMode hostMode)
        {
            switch (hostMode)
            {
                case HostMode.USB_IBMHID: return "XUA-45001-1";
                case HostMode.USB_IBMTT: return "XUA-45001-2";
                case HostMode.USB_HIDKB: return "XUA-45001-3";
                case HostMode.USB_OPOS: return "XUA-45001-8";
                case HostMode.USB_SNAPI: return "XUA-45001-9";
                case HostMode.USB_SNAPI_NoImaging: return "XUA-45001-10";
                case HostMode.USB_CDC: return "XUA-45001-11";
                default: throw new ArgumentOutOfRangeException("hostMode");
            }
        }
    }
}
