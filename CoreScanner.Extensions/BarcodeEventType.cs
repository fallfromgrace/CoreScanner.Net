using System;

namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public enum BarcodeEventType
    {
        /// <summary>
        /// 
        /// </summary>
        Good = 1,
    }

    internal static class BarcodeDataTypeExtensions
    {
        public static Int32 GetCode(
            this BarcodeDataType dataType,
            ScannerType scannerType)
        {
            switch (scannerType)
            {
                case ScannerType.SNAPI:
                    switch (dataType)
                    {
                        case BarcodeDataType.Code39: return 1;
                        case BarcodeDataType.Codabar: return 2;
                        case BarcodeDataType.Code128: return 3;
                        case BarcodeDataType.Discrete2of5: return 4;
                        default: throw new ArgumentOutOfRangeException("dataType");
                    }
                default: throw new ArgumentOutOfRangeException("mode");
            }
        }
    }
}
