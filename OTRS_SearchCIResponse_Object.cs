
/// <remarks/>
/// <summary>this object holds partial inventory information as returned by a search,
/// another call to GLPI requesting a particular CI number  will be required to all retrieval of all information about this CI</summary>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "xxxx")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "xxxx", IsNullable = false)]
//[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "xxxx")]
//[System.Xml.Serialization.XmlRootAttribute(Namespace = "xxxx", IsNullable = false)]
public partial class SearchCIResponse
{

    private ushort[] configItemIDsField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ConfigItemIDs")]
    public ushort[] ConfigItemIDs
    {
        get
        {
            return this.configItemIDsField;
        }
        set
        {
            this.configItemIDsField = value;
        }
    }
}





