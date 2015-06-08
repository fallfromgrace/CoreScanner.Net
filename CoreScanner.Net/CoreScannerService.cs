using More.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CoreScanner.Net
{
    /// <summary>
    /// Wrapper around the CoreScanner library.
    /// </summary>
    internal sealed class CoreScannerService : ICoreScannerService
    {
        /// <summary>
        /// 
        /// </summary>
        public CoreScannerService(CCoreScanner coreScanner)
        {
            this.coreScanner = coreScanner;
            this.deviceIdsBuffer = new Int32[MaximumNumberOfScanners];
            this.isOpen = false;
            this.whenBarcodeCaptured = CreateWhenBarcodeScanned();
            this.whenCommandResponded = CreateWhenCommandResponded();
            this.whenPnp = CreateWhenPnp();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(Boolean disposing)
        {
            if (this.coreScanner != null)
            {
                if (disposing == true)
                    Marshal.ReleaseComObject(this.coreScanner);

                this.coreScanner = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        ~CoreScannerService()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// 
        /// </summary>
        public Boolean IsOpen
        {
            get { return this.isOpen; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scannerTypes"></param>
        public void Open(params ScannerType[] scannerTypes)
        {
            Int32 status;
            if (scannerTypes.Length == 0)
                scannerTypes = new ScannerType[] { ScannerType.All };

            this.coreScanner
                .Open(0, scannerTypes, (Int16)scannerTypes.Length, out status);
            ((Status)status).ThrowIfError();
            this.isOpen = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            Int32 status;
            this.coreScanner
                .Close(0, out status);
            ((Status)status).ThrowIfError();
            this.isOpen = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScannerInfo> GetScanners()
        {
            Contract.Ensures(Contract.Result<IEnumerable<ScannerInfo>>() != null);

            Int16 numDevices;
            String outXml;
            Int32 status;
            this.coreScanner
                .GetScanners(out numDevices, this.deviceIdsBuffer, out outXml, out status);
            ((Status)status).ThrowIfError();

            return outXml
                .ParseXmlDocument()
                .Elements("scanners")
                .Elements("scanner")
                .Select(scanner => ScannerInfo.Parse(scanner.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public String ExecuteCommand(OperationCode operation, String inXml)
        {
            Contract.Ensures(Contract.Result<String>() != null);

            Int32 status;
            String outXml;
            this.coreScanner
                .ExecCommand((Int32)operation, ref inXml, out outXml, out status);
            ((Status)status).ThrowIfError();
            return outXml ?? String.Empty;
        }

        /// <summary>
        /// Executes the specified command asynchronously.  Results are returned via the
        /// WhenCommandResponded observable.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="inXml"></param>
        /// <returns></returns>
        public void ExecuteCommandAsync(OperationCode operation, String inXml)
        {
            Int32 status;
            this.coreScanner
                .ExecCommandAsync((Int32)operation, ref inXml, out status);
            ((Status)status).ThrowIfError();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<BarcodeEventArgs> WhenBarcodeScanned()
        {
            Contract.Ensures(Contract.Result<IObservable<BarcodeEventArgs>>() != null);

            return this.whenBarcodeCaptured;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<CommandReponseEventArgs> WhenCommandResponded()
        {
            Contract.Ensures(Contract.Result<IObservable<CommandReponseEventArgs>>() != null);

            return this.whenCommandResponded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IObservable<PnpEventArgs> WhenPnp()
        {
            Contract.Ensures(Contract.Result<IObservable<PnpEventArgs>>() != null);

            return this.whenPnp;
        }

        #region Private Methods

        private IObservable<BarcodeEventArgs> CreateWhenBarcodeScanned()
        {
            return Observable.FromEvent(
                (Action<BarcodeEventArgs> handler) =>
                    new _ICoreScannerEvents_BarcodeEventEventHandler(
                        delegate(Int16 eventType, ref String outXml)
                        {
                            handler(BarcodeEventArgs.Parse(eventType, outXml));
                        }),
                handler => this.coreScanner.BarcodeEvent += handler,
                handler => this.coreScanner.BarcodeEvent -= handler);
        }

        private IObservable<CommandReponseEventArgs> CreateWhenCommandResponded()
        {
            return Observable.FromEvent(
                (Action<CommandReponseEventArgs> handler) =>
                    new _ICoreScannerEvents_CommandResponseEventEventHandler(
                        delegate(Int16 status, ref String outXml)
                        {
                            handler(CommandReponseEventArgs.Parse(status, outXml));
                        }),
                handler => this.coreScanner.CommandResponseEvent += handler,
                handler => this.coreScanner.CommandResponseEvent -= handler);
        }

        private IObservable<PnpEventArgs> CreateWhenPnp()
        {
            return Observable.FromEvent(
                (Action<PnpEventArgs> handler) =>
                    new _ICoreScannerEvents_PNPEventEventHandler(
                        delegate(Int16 eventType, ref String data)
                        {
                            handler(PnpEventArgs.Parse(eventType, data));
                        }),
                handler => this.coreScanner.PNPEvent += handler,
                handler => this.coreScanner.PNPEvent -= handler);
        }

        #endregion

        #region Private Fields

        private Boolean isOpen;
        private CCoreScanner coreScanner;
        private readonly IObservable<BarcodeEventArgs> whenBarcodeCaptured;
        private readonly IObservable<CommandReponseEventArgs> whenCommandResponded;
        private readonly IObservable<PnpEventArgs> whenPnp;
        private readonly Int32[] deviceIdsBuffer;

        private const Int32 MaximumNumberOfScanners = 255;

        #endregion
    }
}
