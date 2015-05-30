namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// NOTE!!! These values are ONLY for SNAPI mode barcode canners.  Values when in other modes 
    /// are potentially different.  
    /// </remarks>
    public enum BarcodeDataType
    {
        /// <summary>
        /// 
        /// </summary>
        Code39 = 1,

        /// <summary>
        /// 
        /// </summary>
        Codabar = 2,

        /// <summary>
        /// 
        /// </summary>
        Code128 = 3,

        /// <summary>
        /// 
        /// </summary>
        Discrete2of5 = 4,
    }
}
