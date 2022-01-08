/// <summary>defines the object required to contain configuration Item </summary>
/// <remarks>will be used in a list only, namespace is mandatory </remarks>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "skounamespace")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "skounamespace", IsNullable = false)]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//[System.Xml.Serialization.XmlRootAttribute(IsNullable = false)]


public partial class ConfigItem
{
    /// <summary>
    /// the ciXMLDataField holds the detailed object information (conforming with XML structure returned by GLPI)
    /// </summary>
    public ConfigItemCIXMLData cIXMLDataField;

    private string classField;

    private ushort configItemIDField;

    private byte createByField;

    private string createTimeField;

    private string curDeplStateField;

    private string curDeplStateTypeField;

    private string curInciStateField;

    private string curInciStateTypeField;

    private byte definitionIDField;

    private string deplStateField;

    private string deplStateTypeField;

    private string inciStateField;

    private string inciStateTypeField;

    private int lastVersionIDField;

    private string nameField;

    // private uint numberField;
    private ulong numberField;

    private int versionIDField;

    /// <remarks/>
    public ConfigItemCIXMLData CIXMLData
    {
        get
        {
            return this.cIXMLDataField;
        }
        set
        {
            this.cIXMLDataField = value;
        }
    }

    /// <remarks/>
    public string Class
    {
        get
        {
            return this.classField;
        }
        set
        {
            this.classField = value;
        }
    }

    /// <remarks/>
    public ushort ConfigItemID
    {
        get
        {
            return this.configItemIDField;
        }
        set
        {
            this.configItemIDField = value;
        }
    }

    /// <remarks/>
    public byte CreateBy
    {
        get
        {
            return this.createByField;
        }
        set
        {
            this.createByField = value;
        }
    }

    /// <remarks/>
    public string CreateTime
    {
        get
        {
            return this.createTimeField;
        }
        set
        {
            this.createTimeField = value;
        }
    }

    /// <remarks/>
    public string CurDeplState
    {
        get
        {
            return this.curDeplStateField;
        }
        set
        {
            this.curDeplStateField = value;
        }
    }

    /// <remarks/>
    public string CurDeplStateType
    {
        get
        {
            return this.curDeplStateTypeField;
        }
        set
        {
            this.curDeplStateTypeField = value;
        }
    }

    /// <remarks/>
    public string CurInciState
    {
        get
        {
            return this.curInciStateField;
        }
        set
        {
            this.curInciStateField = value;
        }
    }

    /// <remarks/>
    public string CurInciStateType
    {
        get
        {
            return this.curInciStateTypeField;
        }
        set
        {
            this.curInciStateTypeField = value;
        }
    }

    /// <remarks/>
    public byte DefinitionID
    {
        get
        {
            return this.definitionIDField;
        }
        set
        {
            this.definitionIDField = value;
        }
    }

    /// <remarks/>
    public string DeplState
    {
        get
        {
            return this.deplStateField;
        }
        set
        {
            this.deplStateField = value;
        }
    }

    /// <remarks/>
    public string DeplStateType
    {
        get
        {
            return this.deplStateTypeField;
        }
        set
        {
            this.deplStateTypeField = value;
        }
    }

    /// <remarks/>
    public string InciState
    {
        get
        {
            return this.inciStateField;
        }
        set
        {
            this.inciStateField = value;
        }
    }

    /// <remarks/>
    public string InciStateType
    {
        get
        {
            return this.inciStateTypeField;
        }
        set
        {
            this.inciStateTypeField = value;
        }
    }

    /// <remarks/>
    public int LastVersionID
    {
        get
        {
            return this.lastVersionIDField;
        }
        set
        {
            this.lastVersionIDField = value;
        }
    }

    /// <remarks/>
    public string Name
    {
        get
        {
            return this.nameField;
        }
        set
        {
            this.nameField = value;
        }
    }

    /// <remarks/>
    public ulong Number
    {
        get
        {
            return this.numberField;
        }
        set
        {
            this.numberField = value;
        }
    }

    /// <remarks/>
    public int VersionID
    {
        get
        {
            return this.versionIDField;
        }
        set
        {
            this.versionIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "skounamespace")]
public partial class ConfigItemCIXMLData
{

    private object[] hardDiskField;

    private string installDateField;

    private string modelField;

    private ConfigItemCIXMLDataNIC[] nICField;

    private string operatingSystemField;

    private string otherEquipmentField;

    private string ownerField;

    private string serialNumberField;
    private string TypeField;

    private string vendorField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("HardDisk")]
    public object[] HardDisk
    {
        get
        {
            return this.hardDiskField;
        }
        set
        {
            this.hardDiskField = value;
        }
    }

    /// <remarks/>
    public string InstallDate
    {
        get
        {
            return this.installDateField;
        }
        set
        {
            this.installDateField = value;
        }
    }

    /// <remarks/>
    public string Model
    {
        get
        {
            return this.modelField;
        }
        set
        {
            this.modelField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("NIC")]
    public ConfigItemCIXMLDataNIC[] NIC
    {
        get
        {
            return this.nICField;
        }
        set
        {
            this.nICField = value;
        }
    }

    /// <remarks/>
    public string OperatingSystem
    {
        get
        {
            return this.operatingSystemField;
        }
        set
        {
            this.operatingSystemField = value;
        }
        
    }

    /// <remarks/>
    public string OtherEquipment
    {
        get
        {
            return this.otherEquipmentField;
        }
        set
        {
            this.otherEquipmentField = value;
        }
    }

    /// <remarks/>
    public string Owner
    {
        get
        {
            return this.ownerField;
        }
        set
        {
            this.ownerField = value;
        }
    }

    /// <remarks/>
    public string SerialNumber
    {
        get
        {
            return this.serialNumberField;
        }
        set
        {
            this.serialNumberField = value;
        }
    }
    /// <remarks/>
    public string Type
    {
        get
        {
            return this.TypeField;
        }
        set
        {
            this.TypeField = value;
        }
    }

    /// <remarks/>
    public string Vendor
    {
        get
        {
            return this.vendorField;
        }
        set
        {
            this.vendorField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "skounamespace")]
public partial class ConfigItemCIXMLDataNIC
{

    private string iPAddressField;

    private object nICField;

    /// <remarks/>
    public string IPAddress
    {
        get
        {
            return this.iPAddressField;
        }
        set
        {
            this.iPAddressField = value;
        }
    }

    /// <remarks/>
    public object NIC
    {
        get
        {
            return this.nICField;
        }
        set
        {
            this.nICField = value;
        }
    }
}

