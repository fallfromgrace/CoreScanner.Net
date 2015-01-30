using System;
using System.Reactive.Linq;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class ICoreScannerServiceExtensions
    {
        ///// <summary>
        ///// Gets each attribute value asynchronously.
        ///// </summary>
        ///// <param name="scannerService"></param>
        ///// <param name="scannerId"></param>
        ///// <returns></returns>
        //public static IObservable<AttributeInfo> GetAllAttributeValuesAsync(
        //    this ICoreScannerService scannerService,
        //    Int32 scannerId)
        //{
        //    return Observable.Create<AttributeInfo>(async observer =>
        //    {
        //        AttributeId name = (AttributeId)0;
        //        while (name >= 0)
        //        {
        //            AttributeInfo attribute = await scannerService
        //                .GetNextAttributeValueAsync(scannerId, name);
        //            name = attribute.Id;
        //            observer.OnNext(attribute);
        //        }

        //        observer.OnCompleted();
        //    });
        //}

        /// <summary>
        /// Ensures the scanner service is open and events are properly registered before use.
        /// </summary>
        /// <typeparam name="TCoreScannerService"></typeparam>
        /// <param name="scannerService"></param>
        /// <returns></returns>
        public static ICoreScannerService EnsureOpen<TCoreScannerService>(
            this TCoreScannerService scannerService)
            where TCoreScannerService : ICoreScannerService
        {
            if (scannerService.IsOpen == false)
            {
                scannerService.Open(ScannerType.All);
                scannerService.RegisterForEvents(
                    EventType.Barcode | EventType.Image | EventType.Video | 
                    EventType.Other | EventType.PNP | EventType.RMD);
            }

            return scannerService;
        }

        ///// <summary>
        ///// Ensures the scanner service is closed.
        ///// </summary>
        ///// <typeparam name="TCoreScannerService"></typeparam>
        ///// <param name="scannerService"></param>
        ///// <returns></returns>
        //public static ICoreScannerService EnsureClosed<TCoreScannerService>(
        //    this TCoreScannerService scannerService)
        //    where TCoreScannerService : ICoreScannerService
        //{
        //    if (scannerService.IsOpen == true)
        //    {
        //        scannerService.UnregisterForEvents(
        //            EventType.Barcode | EventType.Image | EventType.Video |
        //            EventType.Other | EventType.PNP | EventType.RMD);
        //        scannerService.Close();
        //    }

        //    return scannerService;
        //}
    }
}
