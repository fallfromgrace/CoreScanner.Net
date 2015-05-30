using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CoreScanner.Net
{
    //internal class RefCounter
    //{
    //    public RefCounter()
    //    {
    //        this.cnt = 0;
    //    }

    //    public Int32 AddRef()
    //    {
    //        return System.Threading.Interlocked.Increment(ref this.cnt);
    //    }

    //    public Int32 Release()
    //    {
    //        return System.Threading.Interlocked.Decrement(ref this.cnt);
    //    }

    //    private Int32 cnt;
    //}

    //internal class MotorolaLifetimeManager
    //{
    //    public RefCounter RefCount;
    //    public Int32 IsInitialized;
    //}

    /// <summary>
    /// Injects lifetime into the scanner service, using a shared refcounter instance.
    /// </summary>
    //internal sealed class MotorolaScannerServiceLifetimeDecorator : ICoreScannerService
    //{
    //    public MotorolaScannerServiceLifetimeDecorator(
    //        CoreScannerService scannerService,
    //        Object sync)
    //    {
    //        Contract.Requires(scannerService != null);
    //        Contract.Requires(sync != null);

    //        this.scannerService = scannerService;
    //        lock (sync)
    //        {

    //            this.scannerService.Open(ScannerType.All);
    //            this.scannerService.RegisterForEvents(
    //                EventType.Barcode | EventType.Image | EventType.Video |
    //                EventType.RMD | EventType.PNP | EventType.Other);
    //        }
    //    }

    //    ~MotorolaScannerServiceLifetimeDecorator()
    //    {
    //        Dispose(false);
    //    }

    //    private void Dispose(Boolean disposing)
    //    {
    //        if (scannerService != null &&
    //            counter.Release() == 0)
    //        {
    //            scannerService.UnregisterForEvents(
    //                EventType.Barcode | EventType.Image | EventType.Video |
    //                EventType.RMD | EventType.PNP | EventType.Other);
    //            scannerService.Close();

    //            if (disposing == true)
    //                scannerService.Dispose();
    //        }

    //        scannerService = null;
    //    }

    //    public void Dispose()
    //    {
    //        Dispose(true);
    //    }

    //    public Boolean IsOpen
    //    {
    //        get { return this.scannerService.IsOpen; }
    //    }

    //    public void Open(params ScannerType[] scannerTypes)
    //    {
    //        this.scannerService.Open(scannerTypes);
    //    }

    //    public void Close()
    //    {
    //        this.scannerService.Close();
    //    }

    //    public IEnumerable<MotorolaScannerInfo> GetScanners()
    //    {
    //        return this.scannerService.GetScanners();
    //    }

    //    public String ExecuteCommand(OperationCode operation, String inXml)
    //    {
    //        return this.scannerService.ExecuteCommand(operation, inXml);
    //    }

    //    public void ExecuteCommandAsync(OperationCode operation, String inXml)
    //    {
    //        this.scannerService.ExecuteCommandAsync(operation, inXml);
    //    }

    //    public IObservable<BarcodeEventArgs> WhenBarcodeScanned()
    //    {
    //        return this.scannerService.WhenBarcodeScanned();
    //    }

    //    public IObservable<CommandReponseEventArgs> WhenCommandResponded()
    //    {
    //        return this.scannerService.WhenCommandResponded();
    //    }

    //    public IObservable<PnpEventArgs> WhenPnp()
    //    {
    //        return this.scannerService.WhenPnp();
    //    }


    //    private readonly Object sync;
    //    private IMotorolaScannerService scannerService;
    //}
}
