namespace xxxx
{   
    /// <summary>
    /// Model class for all GLPI dropdown, extensively used for XML-RPC parsing as a T object.
    /// </summary>
    public class GLPI_DropDown
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Comment
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// Generic GLPI Dropdown class, used in code to construct list T of dropdowns objects
        /// </summary>
        /// <param name="ID1">ID</param>
        /// <param name="name1">Name</param>
        /// <param name="comment1">Comment</param>
        public GLPI_DropDown(string ID1, string name1, string comment1)
        {
            this.name = name1;
            this.id = ID1;
            this.comment = comment1;

        }
    }
    /// <summary>
    /// Manufacturer in GLPI
    /// </summary>
    public class GLPI_Manufacturer
    {
        /// <summary>
        /// ID
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Comment
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// Manufacturers in GLPI
        /// </summary>
        /// <param name="ID1">ID</param>
        /// <param name="name1">Name</param>
        /// <param name="comment1">Comment</param>
        public GLPI_Manufacturer(string ID1, string name1, string comment1)
        {
            this.name = name1;
            this.id = ID1;
            this.comment = comment1;

        }
        /// <summary>
        /// Manufacturer in GLPI: parameterless for deserialisation
        /// </summary>
        public GLPI_Manufacturer()
        { }
    }
    /// <summary>
    /// Type of computer
    /// </summary>
    public class GLPI_Computer_Type
    {   
        /// <summary>id of the object in the list </summary>
        public string id { get; set; }
        /// <summary>
        /// name of the object in the list 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// comments if any 
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// Type of Computers
        /// </summary>
        /// <param name="ID1">ID</param>
        /// <param name="name1">Name</param>
        /// <param name="comment1">Comment</param>
        public GLPI_Computer_Type(string ID1, string name1, string comment1)
        {
            this.name = name1;
            this.id = ID1;
            this.comment = comment1;

        }
        /// <summary>
        /// Parameterless definition for deserialisation
        /// </summary>
        public GLPI_Computer_Type()
        { }
    }
    /// <summary>
    /// Location in GLPI
    /// 
    /// </summary>
    public class GLPI_Location
    {
        /// <summary>id of the object in the list </summary>
        public string id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Comment
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// GLPI locations
        /// </summary>
        /// <param name="ID1">ID</param>
        /// <param name="name1">Name</param>
        /// <param name="comment1">Comment</param>
        public GLPI_Location(string ID1, string name1, string comment1)
        {
            this.name = name1;
            this.id = ID1;
            this.comment = comment1;

        }
        /// <summary>
        /// Parameterless Definition for deserialisation
        /// </summary>
        public GLPI_Location()
        { }
    }
    /// <summary>
    /// State in GLPI
    /// </summary>
    public class GLPI_States
    {
        /// <summary>id of the object in the list </summary>
        public string id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Comment
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// GLPI States
        /// </summary>
        /// <param name="ID1">ID</param>
        /// <param name="name1">Name</param>
        /// <param name="comment1">Comment</param>
        public GLPI_States(string ID1, string name1, string comment1)
        {
            this.name = name1;
            this.id = ID1;
            this.comment = comment1;

        }
        /// <summary>
        /// parameterless definition for deserialisation
        /// </summary>
        public GLPI_States()
        { }
    }
    /// <summary>
    /// model in GLPI
    /// </summary>
    public class GLPI_Model
    {
        /// <summary>id of the object in the list </summary>

        public string id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Comment
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// GLPI Model object
        /// </summary>
        /// <param name="ID1">ID</param>
        /// <param name="name1">Name</param>
        /// <param name="comment1">Comment</param>
        public GLPI_Model(string ID1, string name1,string comment1)
        {
            this.name = name1;
            this.id = ID1;
            this.comment = comment1;
    
        }
        /// <summary>
        /// Paramterless definition for deserialisation
        /// </summary>
        public GLPI_Model()
        { }
    }
    /// <summary>
    /// Operating system in GLPI
    /// </summary>
    public class GLPI_Operating_System
    {
        /// <summary>id of the object in the list </summary>
        public string id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// comment
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// Operating system object
        /// </summary>
        /// <param name="ID1">Unique ID</param>
        /// <param name="name1">Name</param>
        /// <param name="comment1">Comment</param>
        public GLPI_Operating_System(string ID1, string name1, string comment1)
        {
            this.name = name1;
            this.id = ID1;
            this.comment = comment1;
        }
        /// <summary>
        /// Parameterless constructor 
        /// </summary>
        public GLPI_Operating_System() //parameterless constructor
        { }

    }
    /// <summary>
    /// IEnumerable class to list partial CI objects in GLPI
    /// </summary>
    public class GLPI_Partial_CI // : IEnumerable
                                //public class GLPI_Partial_CI 
    {
        /// <summary>
        /// Unique Index
        /// </summary>
        public int Iindex { get; set; }
        /// <summary>
        /// Name of CI
        /// </summary>
        public string name { get; set; }
        /// <summary>id of the object in the list </summary>
        public string id { get; set; }
        /// <summary>
        /// Entity
        /// </summary>
        public string entities_name { get; set; }
        /// <summary>
        /// entity ID
        /// </summary>
        public string entities_id { get; set; }
        /// <summary>
        /// Type of CI
        /// </summary>
        public string itemtype { get; set; }
        /// <summary>
        /// Serial number
        /// </summary>
        public string serial { get; set; }
        /// <summary>
        /// Inventory number
        /// </summary>
        public string otherserial { get; set; }
        /// <summary>
        /// name of CI type
        /// </summary>
        public string itemtype_name { get; set; }
        /// <summary>
        /// This object contains basic GLPI CI information, sufficient for basic search. 
        /// </summary>
        /// <param name="Iindex1">Unique Index</param>
        /// <param name="name1">Nane of CI</param>
        /// <param name="id1">ID of CI</param>
        /// <param name="entities_name1">What entity the object belongs</param>
        /// <param name="entities_id1">id of the entity</param>
        /// <param name="itemtype1">type of CI </param>
        /// <param name="serial1">Serial number of CI</param>
        /// <param name="otherserial1">Inventory number of CI</param>
        /// <param name="itemtype_name1">name of the type of CI(as seen by GLPI, must match OTRS types)</param>
        public GLPI_Partial_CI(int Iindex1, string name1, string id1, string entities_name1, string entities_id1, string itemtype1, string serial1, string otherserial1, string itemtype_name1)
        {
            this.Iindex = Iindex1;
            this.name = name1;
            this.id = id1;
            this.entities_name = entities_name1;
            this.entities_id = entities_id1;
            this.itemtype = itemtype1;
            this.serial = serial1;
            this.otherserial = otherserial1;
            this.itemtype_name = itemtype_name1;
        }
        /// <summary>
        /// parameterless constructor to be used to define dynamically code behaviour for XML parsing 
        /// </summary>
        public GLPI_Partial_CI() 
        { }
    }
}