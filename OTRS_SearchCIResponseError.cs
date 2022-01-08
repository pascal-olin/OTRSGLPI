    /// <remarks/>
    /// <summary>In case an error is returned when searching a CI, this object will be able to deserialize the XML and display the error with standard methods, 
    /// we therefore don't have to write a special process for the returned errors</summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "xxxx")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "xxxx", IsNullable = false)]
    public partial class SearchCIResponseError
    {

        private SearchCIResponseError errorField;

        /// <remarks/>
        public SearchCIResponseError Error
        {
            get
            {
                return this.errorField;
            }
            set
            {
                this.errorField = value;
            }
        }
    }

    /// <remarks/>
  
    public partial class SearchCIResponseError
    {

        private string errorCodeField;

        private string errorMessageField;

        /// <remarks/>
        public string ErrorCode
        {
            get
            {
                return this.errorCodeField;
            }
            set
            {
                this.errorCodeField = value;
            }
        }

        /// <remarks/>
        public string ErrorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }
    }


