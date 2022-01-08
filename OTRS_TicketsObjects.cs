using System.Collections.Generic;
using System.Xml.Serialization;
namespace SercoIEToolsIntegration
{

    /// <remarks/>
    /// <summary>
    /// This partial class holds the objects required to store OTRS Tickets responses (basically only the ticketID).</summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //to be used to serialize with namespaces [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "skounamespace")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "")]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable = false)]
    //to be used to serialise root with namespaces [System.Xml.Serialization.XmlRootAttribute(Namespace = "skounamespace", IsNullable = false)]
    public partial class SearchTicketsResponse
    {
        /// <summary>
        /// Ticket id Field for parsing 
        /// </summary>
        private List<string> ticketIDField = new List<string>();
        //to be used to decorate the outer array [XmlArray("SearchTicketsResponse")]
        //to be used to decorate the inner array [XmlArrayItem("TicketID")]
        /// <summary>
        /// Ticket ID for deserialising 
        /// </summary>
        [XmlElement("TicketID")]
        public List<string> TicketID
        {
            get
            {
                return this.ticketIDField;
            }
            set
            {
                this.ticketIDField = value;
            }
        }
    }
    /// OTRS Ticket object 
    /// <remarks/>
    /// <summary> dummy object required by the deserializer to comply with the XML structure returned
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "skounamespace")]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "skounamespace", IsNullable = false)]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable = false)]
    public partial class GetTicketResponse
    {

        private GetTicketResponseTicket ticketField;

        /// <remarks/>
        /// <summary>Ticket number, used to serialise ticketsearch response from OTRS</summary>
        public GetTicketResponseTicket Ticket
        {
            get
            {
                return this.ticketField;
            }
            set
            {
                this.ticketField = value;
            }
        }
    }





    /// <remarks/>
    /// <summary> Object holding OTRS ticket (not article) information</summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "skounamespace")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class GetTicketResponseTicket
    {

        private string ageField;

        private string archiveFlagField;

        private ushort changeByField;

        private string changedField;

        private string createByField;

        private string createTimeUnixField;

        private string createdField;

        private string customerIDField;

        private string customerUserIDField;

        private GetTicketResponseTicketDynamicField[] dynamicFieldField;


        private string escalationResponseTimeField;

        private string escalationSolutionTimeField;

        private string escalationTimeField;

        private string escalationUpdateTimeField;

        private string groupIDField;

        private string lockField;

        private byte lockIDField;

        private string ownerField;

        private string ownerIDField;

        private string priorityField;

        private byte priorityIDField;

        private string queueField;

        private byte queueIDField;

        private string realTillTimeNotUsedField;

        private string responsibleField;

        private byte responsibleIDField;

        private string sLAIDField;

        private string serviceIDField;

        private string stateField;

        private string stateIDField;

        private string stateTypeField;

        private string ticketIDField;

        private string ticketNumberField;

        private string titleField;

        private string typeField;

        private byte typeIDField;

        private string unlockTimeoutField;

        private string untilTimeField;

        /// bodge to have some dynamic fields in the ticket object 
        /// 
        private string FIBNumberField; 

        /// <remarks/>
        /// <summary>Age of ticket in Minutes. internal OTRS</summary>
        public string Age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        /// <summary>Internal use </summary>
        public string ArchiveFlag
        {
            get
            {
                return this.archiveFlagField;
            }
            set
            {
                this.archiveFlagField = value;
            }
        }

        /// <remarks/>
        /// <summary>Who last updated the ticket</summary>
        public ushort ChangeBy
        {
            get
            {
                return this.changeByField;
            }
            set
            {
                this.changeByField = value;
            }
        }

        /// <remarks/>
        /// <summary>When was last change (handled as string)</summary>
        public string Changed
        {
            get
            {
                return this.changedField;
            }
            set
            {
                this.changedField = value;
            }
        }

        /// <remarks/>
        /// <summary>Who created the ticket</summary>
        public string CreateBy
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
        /// <summary>Epoch value of create time </summary>
        public string CreateTimeUnix
        {
            get
            {
                return this.createTimeUnixField;
            }
            set
            {
                this.createTimeUnixField = value;
            }
        }

        /// <remarks/>
        /// <summary>When created (handled as string></summary>
        public string Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        /// <summary>unique Customer ID</summary>
        public string CustomerID
        {
            get
            {
                return this.customerIDField;
            }
            set
            {
                this.customerIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Unique Customer user ID (OTRS internal indexed)</summary>
        public string CustomerUserID
        {
            get
            {
                return this.customerUserIDField;
            }
            set
            {
                this.customerUserIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Hash table containing ALL dynamic fields for this ticket in OTRS, has to be parsed to get the field information</summary>

        [System.Xml.Serialization.XmlElementAttribute("DynamicField")]
        public GetTicketResponseTicketDynamicField[] DynamicField
        {
            get
            {
                return this.dynamicFieldField;
            }
            set
            {
                this.dynamicFieldField = value;
            }
        }



        /// <remarks/>
        /// <summary> SLA escalation response time</summary>
        public string EscalationResponseTime
        {
            get
            {
                return this.escalationResponseTimeField;
            }
            set
            {
                this.escalationResponseTimeField = value;
            }
        }

        /// <remarks/>
        /// <summary>SLA Escalation Solution time</summary>
        public string EscalationSolutionTime
        {
            get
            {
                return this.escalationSolutionTimeField;
            }
            set
            {
                this.escalationSolutionTimeField = value;
            }
        }

        /// <remarks/>
        /// <summary>SLA Escalation Time</summary>
        public string EscalationTime
        {
            get
            {
                return this.escalationTimeField;
            }
            set
            {
                this.escalationTimeField = value;
            }
        }

        /// <remarks/>
        /// <summary>SLA escalation update time</summary>
        public string EscalationUpdateTime
        {
            get
            {
                return this.escalationUpdateTimeField;
            }
            set
            {
                this.escalationUpdateTimeField = value;
            }
        }

        /// <remarks/>
        /// <summary>Group ID (string, could be upgraded ton int64)</summary>
        public string GroupID
        {
            get
            {
                return this.groupIDField;
            }
            set
            {
                this.groupIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Lock flag </summary>
        public string Lock
        {
            get
            {
                return this.lockField;
            }
            set
            {
                this.lockField = value;
            }
        }

        /// <remarks/>
        /// <summary> ID of the lock</summary>
        public byte LockID
        {
            get
            {
                return this.lockIDField;
            }
            set
            {
                this.lockIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Who owns this ticket</summary>
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
        /// <summary>ID of the owner</summary>
        public string OwnerID
        {
            get
            {
                return this.ownerIDField;
            }
            set
            {
                this.ownerIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Priority flag </summary>
        public string Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        /// <summary>Priority ID </summary>
        public byte PriorityID
        {
            get
            {
                return this.priorityIDField;
            }
            set
            {
                this.priorityIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Queue name </summary>
        public string Queue
        {
            get
            {
                return this.queueField;
            }
            set
            {
                this.queueField = value;
            }
        }

        /// <remarks/>
        /// <summary>Queue ID </summary>
        public byte QueueID
        {
            get
            {
                return this.queueIDField;
            }
            set
            {
                this.queueIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Not sure what this does ?</summary>
        public string RealTillTimeNotUsed
        {
            get
            {
                return this.realTillTimeNotUsedField;
            }
            set
            {
                this.realTillTimeNotUsedField = value;
            }
        }

        /// <remarks/>
        /// <summary> Responsible for this ticket </summary>
        public string Responsible
        {
            get
            {
                return this.responsibleField;
            }
            set
            {
                this.responsibleField = value;
            }
        }

        /// <remarks/>
        /// <summary> ID of responsible for this ticket</summary>
        public byte ResponsibleID
        {
            get
            {
                return this.responsibleIDField;
            }
            set
            {
                this.responsibleIDField = value;
            }
        }

        /// <remarks/>
        /// <summary> ID of the applied SLA</summary>
        public string SLAID
        {
            get
            {
                return this.sLAIDField;
            }
            set
            {
                this.sLAIDField = value;
            }
        }

        /// <remarks/>
        /// <summary> ID of the requested service</summary>
        public string ServiceID
        {
            get
            {
                return this.serviceIDField;
            }
            set
            {
                this.serviceIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Current State of ticket</summary>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        /// <summary>Current State ID</summary>
        public string StateID
        {
            get
            {
                return this.stateIDField;
            }
            set
            {
                this.stateIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Current state Type (e.g. open or close)</summary>
        public string StateType
        {
            get
            {
                return this.stateTypeField;
            }
            set
            {
                this.stateTypeField = value;
            }
        }

        /// <remarks/>
        /// <summary> Internal ID of ticket (this is NOT the ticket number) </summary>
        public string TicketID
        {
            get
            {
                return this.ticketIDField;
            }
            set
            {
                this.ticketIDField = value;
            }
        }

        /// <remarks/>
        /// <summary> Ticket number (this is what appears as unique ID but is not) </summary>
        public string TicketNumber
        {
            get
            {
                return this.ticketNumberField;
            }
            set
            {
                this.ticketNumberField = value;
            }
        }

        /// <remarks/>
        /// <summary> Title for this ticket (would be the subject in case of Email)</summary>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        /// <summary> Type of ticket</summary>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        /// <summary> ID of the type</summary>
        public byte TypeID
        {
            get
            {
                return this.typeIDField;
            }
            set
            {
                this.typeIDField = value;
            }
        }

        /// <remarks/>
        /// <summary>Timeout before unlocking ??? </summary>
        public string UnlockTimeout
        {
            get
            {
                return this.unlockTimeoutField;
            }
            set
            {
                this.unlockTimeoutField = value;
            }
        }

        /// <remarks/>
        /// <summary>not sure what this does </summary>
        public string UntilTime
        {
            get
            {
                return this.untilTimeField;
            }
            set
            {
                this.untilTimeField = value;
            }
        }
        /// <remarks/>
        /// <summary>not sure what this does </summary>
        public string FIBNumber
        {
            get
            {
                return this.FIBNumberField;
            }
            set
            {
                this.FIBNumberField = value;
            }
        }

        //string FIBNumberField;
    }

    //---------------------------------------------
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "skounamespace")]
    public partial class GetTicketResponseTicketDynamicField
    {

        private string nameField;

        private string valueField;

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
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }





    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Ticket
    {

        private string ageField;

        private string archiveFlagField;

        private byte changeByField;

        private string changedField;

        private byte createByField;
        // to int 
        private string createTimeUnixField;

        private string createdField;

        private object customerIDField;

        private object customerUserIDField;

        private byte escalationResponseTimeField;

        private byte escalationSolutionTimeField;

        private byte escalationTimeField;

        private byte escalationUpdateTimeField;

        private byte groupIDField;

        private string lockField;

        private byte lockIDField;

        private string ownerField;

        private byte ownerIDField;

        private string priorityField;

        private byte priorityIDField;

        private string queueField;

        private byte queueIDField;

        private byte realTillTimeNotUsedField;

        private string responsibleField;

        private byte responsibleIDField;

        private object sLAIDField;

        private string ServiceField;

        private object serviceIDField;

        private string stateField;

        private string stateIDField;

        private string stateTypeField;

        private string ticketIDField;

        private ulong ticketNumberField;

        private string titleField;

        private string typeField;

        private byte typeIDField;

        private byte unlockTimeoutField;

        private string untilTimeField;

        /// <remarks/>
        public string Age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        public string ArchiveFlag
        {
            get
            {
                return this.archiveFlagField;
            }
            set
            {
                this.archiveFlagField = value;
            }
        }

        /// <remarks/>
        public byte ChangeBy
        {
            get
            {
                return this.changeByField;
            }
            set
            {
                this.changeByField = value;
            }
        }

        /// <remarks/>
        public string Changed
        {
            get
            {
                return this.changedField;
            }
            set
            {
                this.changedField = value;
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
        public string CreateTimeUnix
        {
            get
            {
                return this.createTimeUnixField;
            }
            set
            {
                this.createTimeUnixField = value;
            }
        }

        /// <remarks/>
        public string Created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }

        /// <remarks/>
        public object CustomerID
        {
            get
            {
                return this.customerIDField;
            }
            set
            {
                this.customerIDField = value;
            }
        }

        /// <remarks/>
        public object CustomerUserID
        {
            get
            {
                return this.customerUserIDField;
            }
            set
            {
                this.customerUserIDField = value;
            }
        }

        /// <remarks/>
        public byte EscalationResponseTime
        {
            get
            {
                return this.escalationResponseTimeField;
            }
            set
            {
                this.escalationResponseTimeField = value;
            }
        }

        /// <remarks/>
        public byte EscalationSolutionTime
        {
            get
            {
                return this.escalationSolutionTimeField;
            }
            set
            {
                this.escalationSolutionTimeField = value;
            }
        }

        /// <remarks/>
        public byte EscalationTime
        {
            get
            {
                return this.escalationTimeField;
            }
            set
            {
                this.escalationTimeField = value;
            }
        }

        /// <remarks/>
        public byte EscalationUpdateTime
        {
            get
            {
                return this.escalationUpdateTimeField;
            }
            set
            {
                this.escalationUpdateTimeField = value;
            }
        }

        /// <remarks/>
        public byte GroupID
        {
            get
            {
                return this.groupIDField;
            }
            set
            {
                this.groupIDField = value;
            }
        }

        /// <remarks/>
        public string Lock
        {
            get
            {
                return this.lockField;
            }
            set
            {
                this.lockField = value;
            }
        }

        /// <remarks/>
        public byte LockID
        {
            get
            {
                return this.lockIDField;
            }
            set
            {
                this.lockIDField = value;
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
        public byte OwnerID
        {
            get
            {
                return this.ownerIDField;
            }
            set
            {
                this.ownerIDField = value;
            }
        }

        /// <remarks/>
        public string Priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        public byte PriorityID
        {
            get
            {
                return this.priorityIDField;
            }
            set
            {
                this.priorityIDField = value;
            }
        }

        /// <remarks/>
        public string Queue
        {
            get
            {
                return this.queueField;
            }
            set
            {
                this.queueField = value;
            }
        }

        /// <remarks/>
        public byte QueueID
        {
            get
            {
                return this.queueIDField;
            }
            set
            {
                this.queueIDField = value;
            }
        }

        /// <remarks/>
        public byte RealTillTimeNotUsed
        {
            get
            {
                return this.realTillTimeNotUsedField;
            }
            set
            {
                this.realTillTimeNotUsedField = value;
            }
        }

        /// <remarks/>
        public string Responsible
        {
            get
            {
                return this.responsibleField;
            }
            set
            {
                this.responsibleField = value;
            }
        }

        /// <remarks/>
        public byte ResponsibleID
        {
            get
            {
                return this.responsibleIDField;
            }
            set
            {
                this.responsibleIDField = value;
            }
        }

        /// <remarks/>
        public object SLAID
        {
            get
            {
                return this.sLAIDField;
            }
            set
            {
                this.sLAIDField = value;
            }
        }
        /// <remarks/>
        public string Service
        {
            get
            {
                return this.ServiceField;
            }
            set
            {
                this.ServiceField = value;
            }
        }

        /// <remarks/>
        public object ServiceID
        {
            get
            {
                return this.serviceIDField;
            }
            set
            {
                this.serviceIDField = value;
            }
        }

        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string StateID
        {
            get
            {
                return this.stateIDField;
            }
            set
            {
                this.stateIDField = value;
            }
        }

        /// <remarks/>
        public string StateType
        {
            get
            {
                return this.stateTypeField;
            }
            set
            {
                this.stateTypeField = value;
            }
        }

        /// <remarks/>
        public string TicketID
        {
            get
            {
                return this.ticketIDField;
            }
            set
            {
                this.ticketIDField = value;
            }
        }

        /// <remarks/>
        public ulong TicketNumber
        {
            get
            {
                return this.ticketNumberField;
            }
            set
            {
                this.ticketNumberField = value;
            }
        }

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public byte TypeID
        {
            get
            {
                return this.typeIDField;
            }
            set
            {
                this.typeIDField = value;
            }
        }

        /// <remarks/>
        public byte UnlockTimeout
        {
            get
            {
                return this.unlockTimeoutField;
            }
            set
            {
                this.unlockTimeoutField = value;
            }
        }

        /// <remarks/>
        public string UntilTime
        {
            get
            {
                return this.untilTimeField;
            }
            set
            {
                this.untilTimeField = value;
            }
        }
    }









}






