using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public class CoreScannerServiceManager
    {
        /// <summary>
        /// 
        /// </summary>
        static CoreScannerServiceManager()
        {
            sync = new Object();
        }

        /// <summary>
        /// Gets an instance of the MotorolaScannerService.  Should be disposed after use.
        /// </summary>
        /// <returns></returns>
        public static ICoreScannerService GetInstance()
        {
            lock (sync)
            {
                //if (refCounter == null)
                //    refCounter = new RefCounter();
                if (scannerService == null)
                    scannerService = new CoreScannerService(new CCoreScanner());
                return scannerService;
                //return new MotorolaScannerServiceLifetimeDecorator(serviceProvider, refCounter);
            }
        }

        //private static RefCounter refCounter;
        private static ICoreScannerService scannerService;
        private static readonly Object sync;
    }
}
