using System;

namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public enum AttributeType
    {
        UInt8,
        Int8,
        UInt16,
        Int16,
        UInt32,
        Int32,
        Boolean,
        Array,
        String,
        Action,
    }

    /// <summary>
    /// 
    /// </summary>
    internal static class AttributeTypeExtensions
    {
        public static String ToStringCode(
            this AttributeType attributeType)
        {
            switch (attributeType)
            {
                case AttributeType.Boolean: return "F";
                case AttributeType.UInt8: return "B";
                case AttributeType.Int8: return "C";
                case AttributeType.UInt16: return "W";
                case AttributeType.Int16: return "I";
                case AttributeType.UInt32: return "D";
                case AttributeType.Int32: return "L";
                case AttributeType.Array: return "A";
                case AttributeType.String: return "S";
                case AttributeType.Action: return "X";
                default: throw new ArgumentOutOfRangeException("attributeType");
            }
        }
    }
}
