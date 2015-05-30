namespace CoreScanner.Net
{
    /// <summary>
    /// 
    /// </summary>
    public enum AttributeId
    {
        //Discovery
        ModelNumber = 533,
        SerialNumber = 534,
        DeviceClass = 20007,
        ManufactureDate = 535,
        LastServiceDate = 536,
        ScannerFirmwareVersion = 20004,
        ScankitVersion = 20008,
        ImagekitVersion = 20013,
        CombinedFirmwareVersion = 20009,
        RSMVersion = 20011,
        FirstProgrammingDate = 614,
        ConfigurationFilename = 616,

        //System Events
        DecodeEvent = 256,
        BootupEvent = 258,
        ParamEvent = 259,

        //Operational Status
        InCradleDetect = 25000,
        OerationalMode = 25001,
        Charging = 25002,

        //Beeper
        BeeperVolume = 140,
        BeeperFrequency = 145,

        //DL Parsing
        DLParseMode = 645,
        DLParseBuffer = 646,

        //ADF
        ADFRules = 392,
        KeyDelay = 110,
        PauseDuration = 111,
        KeyCategory1 = 98,
        KeyCategory2 = 99,
        KeyCategory3 = 100,
        KeyCategory4 = 101,
        KeyCategory5 = 102,
        KeyCategory6 = 103,
        KeyValue1 = 104,
        KeyValue2 = 105,
        KeyValue3 = 106,
        KeyValue4 = 107,
        KeyValue5 = 108,
        KeyValue6 = 109,
        SimpleDataFormat = 235,

        //Synapse
        Synapse = 135,

        //Symbologies
        //UPC/EAN
        UPC_A = 1,
        UPC_E = 2,
        UPC_E1 = 12,
        EAN8 = 4,
        EAN13 = 3,
        BooklandEAN = 83,

        //Imaging
        CropTop = 315,

        //RFID
        RFIDLastTagID = 35001,
        RFIDTagID = 35002,
        RFIDBank = 35003,
        RFIDData = 35004,
        RFIDOffset = 35005,
        RFIDLength = 35006,
        RFIDPassword = 35007,
        RFIDCommand = 35008,
        RFIDCmdStatus = 35009,

        //Action
        BeeperAndLedControl = 6000,
        ParameterDefaults = 60001,
        ParamterBuffer = 60002,
        BeepOnNextBootup = 60003,
        Reboot = 60004,
        HostTriggerSession = 60005,

        //Bluetooth
        BluetoothAddress = 541,
        BluetoothAuthentication = 549,
        BluetoothEncryption = 550,
        BluetoothPincode = 552,
        BluetoothReconnectAttempts = 558,
        BluetoothBeepOnReconnectAttempt = 559,
        BluetoothHIDAutoReconnect = 604,
        BluetoothFriendlyName = 607,
        BluetoothPincodeType = 608,
        BluetoothInquiryMode = 610,

        //USB
        //IBM Handheld and Tabletop
        IBMHHIgnoreConfigDirs = 5001,

        //RS485
        //IBM
        IBMIgnoreConfigDirectives = 5000,
    }
}
