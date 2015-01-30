using System;
using System.Collections.Generic;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// Specifies the basic abilities of the motorola scanner service.
    /// </summary>
    /// <remarks>
    /// This interface is used to define an implementation that wraps around the CoreScanner API.
    /// </remarks>
    public interface ICoreScannerService// : IDisposable
    {
        /// <summary>
        /// Gets if the scanner service is open for use.
        /// </summary>
        Boolean IsOpen { get; }

        /// <summary>
        /// Opens the service for use, monitoring the specified scanner types.
        /// </summary>
        /// <param name="scannerTypes"></param>
        void Open(params ScannerType[] scannerTypes);

        /// <summary>
        /// Closes the service.
        /// </summary>
        void Close();

        /// <summary>
        /// Gets the scanners currently connected.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Does not return the device topology, therefore it is recommended to call 
        /// GetDeviceTopology instead, as the topology is necessary to subscribe to the correct 
        /// scanner events.
        /// </remarks>
        IEnumerable<ScannerInfo> GetScanners();

        /// <summary>
        /// Executes the specified command with the specifed serialized arguments.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="inXml"></param>
        /// <returns></returns>
        String ExecuteCommand(OperationCode operation, String inXml);

        /// <summary>
        /// Asynchronously execute the specified command with the specifed serialized arguments.  
        /// Results are returned via WhenCommandResponded.  
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="inXml"></param>
        /// <remarks>
        /// The function does not return an IObservable because it would require parsing the 
        /// returned xml for a matching opcode and/or scannerId, as multiple asynchronous commands 
        /// can be simultaneously posting and returned out of order.  It is therefore recommended 
        /// to use the provided extensions methods which perform the correct filtering.
        /// </remarks>
        void ExecuteCommandAsync(OperationCode operation, String inXml);

        /// <summary>
        /// Gets an observable that signals when a barcode is scanned by any connected scanner.
        /// </summary>
        /// <returns></returns>
        IObservable<BarcodeEventArgs> WhenBarcodeScanned();

        /// <summary>
        /// Gets an observable that signals when an asynchronous command is completed.
        /// </summary>
        /// <returns></returns>
        IObservable<CommandReponseEventArgs> WhenCommandResponded();

        /// <summary>
        /// Gets an observable that signals when a scanner is connected or disconnected.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Does not trigger for bluetooth pairing or when the scanner is removed/attached from/to 
        /// a cradle, unfortunately.
        /// </remarks>
        IObservable<PnpEventArgs> WhenPnp();
    }
}
