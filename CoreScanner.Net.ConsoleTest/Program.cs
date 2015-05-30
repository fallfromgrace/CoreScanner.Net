using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using Light.Linq;

namespace CoreScanner.Net.Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreScannerServiceManager
                .GetInstance()
                .WhenPnp()
                .Subscribe(e => 
                    Console.WriteLine(e.ScannerInfo.Id));

            CoreScannerServiceManager.GetInstance().RebootScanner(1);

            System.Threading.Thread.Sleep(1000000);

            CoreScannerServiceManager
                .GetInstance()
                .GetDeviceTopology()
                .ForEach(info => 
                    Console.WriteLine());
            CoreScannerServiceManager.GetInstance()
                .WhenBarcodeScanned()
                .Subscribe(e =>
                    Console.WriteLine(e.DataLabel));

            CoreScannerServiceManager
                .GetInstance()
                .GetScanners()
                .ForEach(s =>
                {

                    if (s.Type != ScannerType.SNAPI)
                        CoreScannerServiceManager
                            .GetInstance()
                            .SetHostMode(HostMode.USB_SNAPI, s.Id, false, true);
                });

            while(true)
            {
                Console.ReadLine();

            }
        }
    }
}
