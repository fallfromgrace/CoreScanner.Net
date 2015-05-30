using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using CoreScanner;

namespace CoreScanner.Net
{
    internal static class CoreScannerEventExtensions
    {
        //public static IObservable<BarcodeEventArgs> CreateWhenBarcodeScannedObservable(
        //    this CCoreScanner coreScanner)
        //{
        //    return Observable.FromEvent(
        //        (Action<BarcodeEventArgs> handler) =>
        //            new _ICoreScannerEvents_BarcodeEventEventHandler(
        //                delegate(Int16 eventType, ref String outXml)
        //                {
        //                    handler(BarcodeEventArgs.Parse(eventType, outXml));
        //                }),
        //        handler => coreScanner.BarcodeEvent += handler,
        //        handler => coreScanner.BarcodeEvent -= handler);
        //}
        //public static IObservable<CommandReponseEventArgs> WhenBarcodeScannedObservable(
        //    this CCoreScanner coreScanner)
        //{
        //    return Observable.FromEvent(
        //        (Action<CommandReponseEventArgs> handler) =>
        //            new _ICoreScannerEvents_CommandResponseEventEventHandler(
        //                delegate(Int16 eventType, ref String outXml)
        //                {
        //                    handler(CommandReponseEventArgs.Parse(eventType, outXml));
        //                }),
        //        handler => coreScanner.CommandResponseEvent += handler,
        //        handler => coreScanner.CommandResponseEvent -= handler);
        //}
        //public static IObservable<PnpEventArgs> WhenBarcodeScannedObservable(
        //    this CCoreScanner coreScanner)
        //{
        //    return Observable.FromEvent(
        //        (Action<PnpEventArgs> handler) =>
        //            new _ICoreScannerEvents_PNPEventEventHandler(
        //                delegate(Int16 eventType, ref String outXml)
        //                {
        //                    handler(PnpEventArgs.Parse(eventType, outXml));
        //                }),
        //        handler => coreScanner.PNPEvent += handler,
        //        handler => coreScanner.PNPEvent -= handler);
        //}
    }
}
