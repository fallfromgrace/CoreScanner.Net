using System;

namespace CoreScanner.Net
{
    /// <summary>
    /// Return code from a CoreScanner function.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Command suceeded.
        /// </summary>
        Success = 0,
        DeviceLocked = 10,
        InvalidApplicationHandle = 100,
        CommLibUnavailable = 101,
        NullBufferPointer = 102,
        InvalidBufferPointer = 103,
        IncorrectBufferSize = 104,
        DuplicatedType = 105,
        IncorrectTypeCount = 106,
        InvalidArgument = 107,
        InvalidScannerId = 108,
        IncorrectEventCount = 109,
        DuplicateEventIds = 110,
        InvalidEventId = 111,
        DeviceUnavailable = 112,
        InvalidOpcode = 113,
        InvalidValue = 114,
        AsyncNotSupported = 115,
        OpcodeNotSupported = 116,
        OperationFailed = 117,
        CoreScannerFailure = 118,
        OperationNotSupported = 119,
        DeviceBusy = 120,

        CoreScannerAlreadyOpened = 200,
        CoreScannerAlreadyClosed = 201,
        CoreScannerClosed = 202,

        XmlMalformed = 300,
        XmlReaderCreationFailure = 301,
        XmlReaderInputFailure = 302,
        XmlReaderPropertyFailure = 303,
        XmlWriterCreationFailure = 304,
        XmlWriterOutputFailure = 305,
        XmlWriterPropertyFailure = 306,
        XmlReadError = 307,
        InvalidInXmlArguments = 308,
        XmlWriteFailed = 309,
        InXmlTooLong = 310,
        BufferLengthExceeded = 311,

        NullPointer = 400,
        DuplicateClient = 401,

        InvalidFirmwareFile = 500,
        FWUpdateFailed = 501,
        DATFileReadFailed = 502,
        FirmwareUpdateAlreadyInProgress = 503,
        FirmwareUpdateAlreadyAborted = 504,
        FWUpdateAborted = 505,
        ScannerDisconnected = 506,

        ComponentAlreadyAResident = 600,
    }

    /// <summary>
    /// 
    /// </summary>
    internal static class StatusExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        public static void ThrowIfError(this Status status)
        {
            switch (status)
            {
                case Status.Success: 
                    return;
                case Status.DeviceLocked: 
                    throw new InvalidOperationException("Device is locked by another application.");
                case Status.InvalidApplicationHandle: 
                    throw new ArgumentException("Invalid application handle. Reserved parameter. Value should be zero.");
                case Status.CommLibUnavailable: 
                    throw new InvalidOperationException("Required Comm Lib is unavailable to support the requested type");
                case Status.NullBufferPointer: 
                    throw new ArgumentNullException("buffer", "Null buffer pointer.");
                case Status.InvalidBufferPointer: 
                    throw new ArgumentException("Invalid buffer pointer.");
                case Status.IncorrectBufferSize: 
                    throw new ArgumentException("Incorrect buffer size.");
                case Status.DuplicatedType: 
                    throw new ArgumentException("Requested Type IDs are duplicated.");
                case Status.IncorrectTypeCount: 
                    throw new ArgumentException("Incorrect value for number of Types.");
                case Status.InvalidArgument: 
                    throw new ArgumentException("Invalid argument.");
                case Status.InvalidScannerId: 
                    throw new ArgumentException("Invalid scanner ID.");
                case Status.IncorrectEventCount: 
                    throw new ArgumentException("Incorrect value for number of Event IDs.");
                case Status.DuplicateEventIds: 
                    throw new ArgumentException("Event IDs are duplicated.");
                case Status.InvalidEventId: 
                    throw new ArgumentException("Invalid value for Event ID.");
                case Status.DeviceUnavailable: 
                    throw new InvalidOperationException("Required device is unavailable.");
                case Status.InvalidOpcode: 
                    throw new ArgumentException("Opcode is invalid.");
                case Status.InvalidValue: 
                    throw new ArgumentException("Invalid value for type.");
                case Status.AsyncNotSupported: 
                    throw new NotSupportedException("Opcode does not support asynchronous method.");
                case Status.OpcodeNotSupported: 
                    throw new NotSupportedException("Device does not support the Opcode.");
                case Status.OperationFailed: 
                    throw new InvalidOperationException("Operation failed in device.");
                case Status.CoreScannerFailure: 
                    throw new InvalidOperationException("Request failed in CoreScanner.");
                case Status.OperationNotSupported: 
                    throw new NotSupportedException("Operation not supported for auxiliary scanners.");
                case Status.DeviceBusy: 
                    throw new InvalidOperationException("Device busy. Applications should retry command.");

                case Status.CoreScannerAlreadyOpened: 
                    throw new InvalidOperationException("CoreScanner is already opened.");
                case Status.CoreScannerAlreadyClosed: 
                    throw new InvalidOperationException("CoreScanner is already closed.");
                case Status.CoreScannerClosed: 
                    throw new InvalidOperationException("CoreScanner is closed.");

                case Status.XmlMalformed: 
                    throw new ArgumentException("Malformed inXML.");
                case Status.XmlReaderCreationFailure: 
                    throw new InvalidOperationException("XML Reader could not be instantiated.");
                case Status.XmlReaderInputFailure: 
                    throw new InvalidOperationException("Input for XML Reader could not be set.");
                case Status.XmlReaderPropertyFailure: 
                    throw new InvalidOperationException("XML Reader property could not be set.");
                case Status.XmlWriterCreationFailure: 
                    throw new InvalidOperationException("XML Writer could not be instantiated.");
                case Status.XmlWriterOutputFailure: 
                    throw new InvalidOperationException("Output for XML Writer could not be set.");
                case Status.XmlWriterPropertyFailure: 
                    throw new InvalidOperationException("XML Writer property could not be set.");
                case Status.XmlReadError: 
                    throw new ArgumentException("Cannot read element from XML input.");
                case Status.InvalidInXmlArguments: 
                    throw new ArgumentException("Arguments in inXML are not valid.");
                case Status.XmlWriteFailed: 
                    throw new InvalidOperationException("Write to XML output string failed.");
                case Status.InXmlTooLong: 
                    throw new ArgumentException("InXML exceed length.");
                case Status.BufferLengthExceeded: 
                    throw new InvalidOperationException("buffer length for type exceeded.");

                case Status.NullPointer: 
                    throw new ArgumentNullException(String.Empty, "Null pointer.");
                case Status.DuplicateClient: 
                    throw new InvalidOperationException("Cannot add a duplicate client.");

                case Status.InvalidFirmwareFile: 
                    throw new ArgumentException("Invalid firmware file.");
                case Status.FWUpdateFailed: 
                    throw new InvalidOperationException("FW Update failed in scanner.");
                case Status.DATFileReadFailed: 
                    throw new InvalidOperationException("Failed to read DAT file.");
                case Status.FirmwareUpdateAlreadyInProgress: 
                    throw new InvalidOperationException("Firmware Update is in progress (cannot proceed another FW Update or another command).");
                case Status.FirmwareUpdateAlreadyAborted: 
                    throw new InvalidOperationException("Firmware update is already aborted.");
                case Status.FWUpdateAborted: 
                    throw new InvalidOperationException("FW Update aborted.");
                case Status.ScannerDisconnected: 
                    throw new InvalidOperationException("Scanner is disconnected while updating firmware.");

                case Status.ComponentAlreadyAResident: 
                    throw new InvalidOperationException("The software component is already resident in the scanner.");
                default: throw new InvalidOperationException(String.Format("Unknown status code {0}", status));
            }
        }
    }
}
