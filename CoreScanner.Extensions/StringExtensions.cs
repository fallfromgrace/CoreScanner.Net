using Light;
using System;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static ScannerType ToScannerType(this String typeName)
        {
            switch (typeName)
            {
                case "SNAPI": return ScannerType.SNAPI;
                case "USBIBMHID": return ScannerType.IBMHID;
                case "USBHIDKB": return ScannerType.HIDKB;
                default: throw new ArgumentException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static AttributeType ToAttributeType(this String attributeType)
        {
            switch (attributeType)
            {
                case "F": return AttributeType.Boolean;
                case "B": return AttributeType.UInt8;
                case "C": return AttributeType.Int8;
                case "W": return AttributeType.UInt16;
                case "I": return AttributeType.Int16;
                case "D": return AttributeType.UInt32;
                case "L": return AttributeType.Int32;
                case "A": return AttributeType.Array;
                case "S": return AttributeType.String;
                case "X": return AttributeType.Action;
                default: throw new ArgumentOutOfRangeException("attributeType");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attributePermission"></param>
        /// <returns></returns>
        public static AttributePermission ToAttributePermission(this String attributePermission)
        {
            switch (attributePermission)
            {
                case "R": return AttributePermission.Read;
                case "RWP": return AttributePermission.Read | AttributePermission.Write;
                case "": return AttributePermission.None;
                case "W": return AttributePermission.Write;
                default: throw new ArgumentOutOfRangeException("attributePermission");
            }
        }

        /// <summary>
        /// TODO implement this to get the correct scanner type.
        /// </summary>
        /// <param name="barcodeDataType"></param>
        /// <param name="scannerType"></param>
        /// <returns></returns>
        public static BarcodeDataType ConvertToBarcodeDataType(this String barcodeDataType, ScannerType scannerType)
        {
            Int32 barcodeDataTypeValue = barcodeDataType.ToInt32();
            switch (scannerType)
            {
                case ScannerType.SNAPI: return (BarcodeDataType)barcodeDataTypeValue;
                case ScannerType.NIXMODB: throw new NotImplementedException();
                case ScannerType.IBMHID: throw new NotImplementedException();
                case ScannerType.SSI: throw new NotSupportedException();
                case ScannerType.RSM: throw new NotSupportedException();
                case ScannerType.Imaging: throw new NotSupportedException();
                case ScannerType.HIDKB: throw new NotSupportedException();
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
