namespace CoreScanner.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public enum OperationCode
    {
        GetVersion = 1000,
        RegisterForEvents = 1001,
        UnregisterForEvents = 1002,

        ClaimDevice = 1500,
        ReleaseDevice = 1501,

        AbortMacroPdf = 2000,
        AbortUpdateFirmware = 2001,
        AimOff = 2002,
        AimOn = 2003,
        FlushMacroPdf = 2005,
        DevicePullTrigger = 2011,
        DeviceReleaseTrigger = 2012,
        ScanDisable = 2013,
        ScanEnable = 2014,
        SetParameterDefaults = 2015,
        DeviceSetParameters = 2016,
        SetParameterPersistence = 2017,
        RebootScanner = 2019,

        DeviceCaptureImage = 3000,
        DeviceCaptureBarcode = 3500,
        DeviceCaptureVideo = 4000,

        GetAllAttributes = 5000,
        GetAttribute = 5001,
        GetNextAttribute = 5002,
        SetAttribute = 5004,
        StoreAttribute = 5005,
        GetDeviceTopology = 5006,
        StartNewFirmware = 5014,
        UpdateFirmware = 5016,
        UpdateFirmwareFromPlugin = 5017,

        SetAction = 6000,
        DeviceSetSerialPortSettings = 6101,
        DeviceSwitchHostMode = 6200,
        KeyboardEmulatorEnable = 6300,
        KeyboardEmulatorSetLocale = 6301,
        KeyboardEmulatorGetConfiguration = 6302,

        ScaleReadWeight = 7000,
        ScaleZeroScale = 7002,
        ScaleSystemReset = 7015
    }
}
