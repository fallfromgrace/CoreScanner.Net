using System;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    [Flags]
    public enum EventType
    {
        /// <summary>
        /// Triggered when a scanner captures bar codes in barcode mode.
        /// </summary>
        /// <remarks>
        /// To recieve barcode events, the application needs to call RegisterForEvents with this 
        /// value as an argument.
        /// </remarks>
        Barcode = 1 << 0,

        /// <summary>
        /// Triggered when an imaging scanner captures images in image mode.
        /// </summary>
        /// <remarks>
        /// To recieve image events, the application needs to call RegisterForEvents with this 
        /// value as an argument.
        /// </remarks>
        Image = 1 << 1,

        /// <summary>
        /// Triggered when an imaging scanner captures video in video mode.
        /// </summary>
        /// <remarks>
        /// To recieve video events, the application needs to call RegisterForEvents with this 
        /// value as an argument.
        /// </remarks>
        Video = 1 << 2,

        /// <summary>
        /// Receives RMD Events when updating firmware of the scanner. 
        /// </summary>
        /// To recieve RMD events, the application needs to call RegisterForEvents with this 
        /// value as an argument.
        /// </remarks>
        RMD = 1 << 3,

        /// <summary>
        /// Triggered when a scanner of a requested type attaches to the system or detaches from 
        /// the system. 
        /// </summary>
        /// <remarks>
        /// The pairing of a Bluetooth scanner to a cradle does not trigger a PnP event. To receive 
        /// information about a newly paired device, the GetScanners command must be called again.
        /// </remarks>
        PNP = 1 << 4,

        /// <summary>
        /// 
        /// </summary>
        Other = 1 << 5,
    }
}
