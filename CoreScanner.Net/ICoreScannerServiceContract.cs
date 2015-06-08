using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace CoreScanner.Net
{
    [ContractClassFor(typeof(ICoreScannerService))]
    internal abstract class ICoreScannerServiceContract : ICoreScannerService
    {
        public Boolean IsOpen
        {
            get { return default(Boolean); }
        }

        public void Open(params ScannerType[] scannerTypes)
        {
            Contract.Requires(scannerTypes != null);
        }

        public void Close()
        {
            
        }

        public IEnumerable<ScannerInfo> GetScanners()
        {
            Contract.Ensures(Contract.Result<IEnumerable<ScannerInfo>>() != null);
            return default(IEnumerable<ScannerInfo>);
        }

        public String ExecuteCommand(OperationCode operation, String inXml)
        {
            Contract.Requires(inXml != null);
            return default(String);
        }

        public void ExecuteCommandAsync(OperationCode operation, String inXml)
        {
            Contract.Requires(inXml != null);
        }

        public IObservable<BarcodeEventArgs> WhenBarcodeScanned()
        {
            Contract.Ensures(Contract.Result<IObservable<BarcodeEventArgs>>() != null);
            return default(IObservable<BarcodeEventArgs>);
        }

        public IObservable<CommandReponseEventArgs> WhenCommandResponded()
        {
            Contract.Ensures(Contract.Result<IObservable<CommandReponseEventArgs>>() != null);
            return default(IObservable<CommandReponseEventArgs>);
        }

        public IObservable<PnpEventArgs> WhenPnp()
        {
            Contract.Ensures(Contract.Result<IObservable<PnpEventArgs>>() != null);
            return default(IObservable<PnpEventArgs>);
        }
    }
}
