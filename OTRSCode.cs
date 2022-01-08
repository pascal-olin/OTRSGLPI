using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using CookComputing.XmlRpc;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Dynamic;
using System.Xml.Linq;
using System.Collections;
//using SercoIEToolsIntegration.com.githubusercontent.raw;
using SercoIEToolsIntegration;
using SercoIEToolsIntegration.Properties;
using System.Configuration;
using System.Collections.Specialized;
using static SercoIEToolsIntegration.Common;
// original ...
using System.Reflection;
using System.Windows.Forms;
//using static SercoIEToolsIntegration.OTRSTicketSearchReplyObjectClass;
// full XML class delete up to here 
//delete down to here 
/// <summary>
/// Serco Informatique d'Entreprise unique namespace for the whole solution.
/// </summary>
namespace SercoIEToolsIntegration
{ 
        /// <summary> 
        /// OTRS Error response </summary>
        /// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "SercoNamespace")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "SercoNamespace", IsNullable = false)]
public partial class OTRSTicketCreateResponse
{

    private ticketCreateResponseError errorField;

    /// <remarks/>
    public ticketCreateResponseError Error
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
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "SercoNamespace")]
public partial class ticketCreateResponseError
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
/// <summary>
/// OTRS response after ticket creation 
/// </summary>
/// <remarks/>
// [System.SerializableAttribute()]
//  [System.ComponentModel.DesignerCategoryAttribute("code")]
//  [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "SercoNamespace")]
//  [System.Xml.Serialization.XmlRootAttribute(Namespace = "SercoNamespace", IsNullable = false)]
public partial class OTRSTicketCreateResponse
{
    private string articleIDField;
    private string ticketIDField;
    private string ticketNumberField;
    /// <remarks/>
    public string ArticleID
    {
        get
        {
            return this.articleIDField;
        }
        set
        {
            this.articleIDField = value;
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
    }
    /// <summary>
    /// OTRS ticket object used to ADD a new ticket 
    /// </summary>
public partial class NewOTRSTicket
{
        /// <summary>
        ///  new OTRS ticket queue
        /// </summary>
        public string Queue { get; set; }
        /// <summary>
        /// new ticket CustomerUser
        /// </summary>
        public string CustomeUser { get; set; }
        /// <summary>
        /// new OTRS Ticket State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// new OTRS ticket Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// new OTRS ticket PRiority ID 
        /// </summary>
        public string PriorityID { get; set; }
        /// <summary>
        /// new OTRS ticket type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// New OTRS Ticket Timeunit
        /// 
        /// </summary>
        public string TimeUnits { get; set; }
        /// <summary>
        /// FIB number in case we create a FIB (dynamic field in OTRS CSG) 
        /// </summary>
        public string FIBNumber { get; set; }
        /// <summary>
        /// Service name 
        /// </summary>
        public string Service { get; set; }
        /// <summary>
        /// Dictionnary to hold the attachements : remember it MUST be instantiated separately after the object has been created
        /// </summary>
        public Dictionary<string, string> TKT_Attachments { get; set; }


        /// <summary>
        /// NewOTRSTicket holds basic information about ticket
        /// </summary>
        /// <param name="Q1">Queue</param>
        /// <param name="C1">Customer</param>
        /// <param name="S1">State</param>
        /// <param name="T1">Title</param>
        /// <param name="P1">PriorityID</param>
        /// <param name="Ty1">Type</param>
        /// <param name="Time1">Timeunits</param>
        /// <param name="Fib1">FIBNumber</param>
        /// <param name="Service1">Target OTRS service</param>

        public NewOTRSTicket(string Q1, string C1, string S1, string T1, string P1, string Ty1, string Time1, string Fib1, string Service1)
    {
        this.Queue = Q1;
        this.CustomeUser = C1;
        this.State = S1;
        this.Title = T1;
        this.PriorityID = P1;
        this.Type = Ty1;
        this.TimeUnits = Time1;
        this.FIBNumber = Fib1;
        this.Service = Service1;

    }
        /// <summary>
        /// Parameterless Constructor for the TicketObject
        /// </summary>
        public NewOTRSTicket()
        { }
}
    /// <summary>
    /// Object holding TicketArticle information
    /// </summary>
public partial class OTRSTicketArticle
{
        /// <summary>
        /// Associated ticket Number
        /// </summary>
    public string TicketNumber { get; set; }
        /// <summary>
        /// Subject of Article
        /// </summary>
    public string Subject { get; set; }
        /// <summary>
        /// Body
        /// </summary>
    public string Body { get; set; }
        /// <summary>
        /// Content type
        /// </summary>
    public string ContentType { get; set; }
    //public string TimeUnit { get; set; }
    /// <summary>
    /// Time unit
    /// </summary>
    public string TimeUnit { get; set; }
        /// <summary>
        /// Ticket Article object instantiation
        /// </summary>
        /// <param name="T1">Ticket number</param>
        /// <param name="S1">Subject</param>
        /// <param name="B1">Body</param>
        /// <param name="C1">Content Type</param>
        /// <param name="Time1">TimeUnit</param>
    public OTRSTicketArticle(string T1, string S1, string B1, string C1, string Time1)
    {
        this.TicketNumber = T1;
        this.Subject = S1;
        this.Body = B1;
        this.ContentType = C1;
        this.TimeUnit = Time1;
    }
        /// <summary>
        /// Parameterless constuctor  for OTRSTicketArticle
        /// </summary>
    public OTRSTicketArticle()
    { }
}
    /// <summary>
    /// This public class OTRSCode contains all OTRS related code.
    /// </summary>
    public class OTRSCode
    {
        #region fields
        /// <summary>
        /// File path vars.
        /// </summary>
        // to delete private static String errorFilePath = "C:\\OTRS_RPC\\otrserror.xml";
        // to delete private static String requestfilepath = "C:\\OTRS_RPC\\{0}_otrsrequest_Service{1}.xml";
        // to delete private static String responsefilepath = "C:\\OTRS_RPC\\{0}_otrsanswer_Service{1}.xml";
        private static String dateTimeFormat = "yyyyMMddTHHmmss";
        /// <summary>
        /// Default OTRS Queue
        /// </summary>
        public static String OTRS_Queue = "Misc";
        /// <summary>
        /// Debug output or not
        /// </summary>
        public static bool Debug = false;
        //public static String OTRS_Globalurl = "http://sscservicedesk.serco.eu/otrs/nph-genericinterface.pl/Webservice/Inventory";


        //private static SercoIEToolsIntegration.com.githubusercontent.raw.GenericConfigItemConnector OTRSConnector;
        //private static SercoIEToolsIntegration.com.githubusercontent.raw.OTRS_ConfigItem_Search_ConfigItem OTRSSearch;
        #endregion
        #region SERVICE_GETCI
        private const int SERVICE_GETCI = 31;
        /// <summary>
        /// This soap request tells otrs to retrieve CIs.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_GETCI = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <GetCI xmlns=""SercoNameSpace"">
         <UserLogin>po</UserLogin>
         <Password>po</Password>
         <ConfigItemID>{2}</ConfigItemID>
         <Attachments>0</Attachments> 
      </GetCI> 
     </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_SEARCHCI
        private const int SERVICE_SEARCHCI = 32;
        /// <summary>
        /// This soap request tells otrs to retrieve CIs.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_SEARCHCI = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <SearchCI xmlns=""skounamespace"">
         <UserLogin>{0}</UserLogin>
         <Password>{1}</Password>
            <ConfigItem> 
                <Class>Computer</Class>
                <Name>{2}</Name>
            </ConfigItem>
      </SearchCI> 
     </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_INVGETNUMBER
        private const int SERVICE_INVGETNUMBER = 33;
        /// <summary>
        /// This soap request tells otrs to count up the inventory number.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_INVGETNUMBER = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <Dispatch xmlns=""/Core"">
      </Dispatch>
    </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_TICKETNUMBER
        private const int SERVICE_TICKETNUMBER = 1;
        /// <summary>
        /// This soap request tells otrs to count up the ticket number.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_TICKETNUMBER = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <AddCI xmlns=""/SercoNameSpace"">
         <UserLogin>po</UserLogin>
         <Password>po</Password>
            <ConfigItem>
               <Class>Computer</Class>
               <Name>    coincoin     </Name>
                <DeplState>Inactive</DeplState>
                <InciState>Operational</InciState>
                <CIXMLData>
            <Vendor>Lenovo</Vendor>
            <Model>Thinkpad</Model>
            <Description>Thinkpad X300</Description>
            <Type>Desktop</Type>
            <Owner>PO</Owner>
            <SerialNumber>abc12345abc</SerialNumber>
            <OperatingSystem>CentOS 6.0</OperatingSystem>
            <CPU>Intel Core i3</CPU>
            <Ram>4000</Ram>
            <Ram>2000</Ram>
            <HardDisk>
                <HardDisk>/dev</HardDisk>
                <Capacity>50000</Capacity>
            </HardDisk>
            <FQDN>host.example.com</FQDN>
            <NIC>
                <NIC>Eth0</NIC>
                <IPoverDHCP>No</IPoverDHCP>
                <IPAddress>192.168.30.1</IPAddress>
            </NIC>
            <NIC>
                <NIC>Eth1</NIC>
                <IPoverDHCP>Yes</IPoverDHCP>
                <IPAddress>200.34.56.78</IPAddress>
            </NIC>
            <GraphicAdapter>ATI Radeon 300</GraphicAdapter>
            <WarrantyExpirationDate>12/12/1977</WarrantyExpirationDate>
            <InstallDate>1977-12-12</InstallDate>
            <Note>This is a Demo CI</Note>
        </CIXMLData>

            </ConfigItem>
        
      </AddCI>
    </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_ADDCI
        private const int SERVICE_ADDCI = 7;
        /// <summary>
        /// This soap request tells otrs to create an configItem
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_ADDCI = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <AddCI xmlns=""/SercoNameSpace"">
         <UserLogin>{0}</UserLogin>
         <Password>{1}</Password>
            <ConfigItem>
               <Class>Computer</Class>
               <Name>{2}</Name>
                <DeplState>Allocated</DeplState>
                <InciState>Operational</InciState>
                <CIXMLData>
            <Vendor>{3}</Vendor>
            <Model>{4}</Model>
            <Description>Description</Description>
            <Type>{5}</Type>
            <Owner>{6}</Owner>
            <SerialNumber>{7}</SerialNumber>
            <OperatingSystem>{8}</OperatingSystem>
            <CPU>CPUType</CPU>
            <Ram>4000</Ram>
            <Ram>2000</Ram>
            <HardDisk>
                <HardDisk>/dev</HardDisk>
                <Capacity>50000</Capacity>
            </HardDisk>
            <FQDN>host.example.com</FQDN>
            <NIC>
                <NIC>Eth0</NIC>
                <IPoverDHCP>No</IPoverDHCP>
                <IPAddress>192.168.30.1</IPAddress>
            </NIC>
            <NIC>
                <NIC>Eth1</NIC>
                <IPoverDHCP>Yes</IPoverDHCP>
                <IPAddress>200.34.56.78</IPAddress>
            </NIC>
            <GraphicAdapter>ATI Radeon 300</GraphicAdapter>
            <WarrantyExpirationDate>12/12/1977</WarrantyExpirationDate>
            <InstallDate>1977-12-12</InstallDate>
            <Note>This is a Demo CI</Note>
        </CIXMLData>

            </ConfigItem>
        
      </AddCI>
    </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_NEWCI
        private const int SERVICE_NEWCI = 5;
        /// <summary>
        /// This soap request tells otrs to create an configItem
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_NEWCI = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <AddCI xmlns=""/SercoNameSpace"">
         <UserLogin>po</UserLogin>
         <Password>po</Password>
            <ConfigItem>
               <Class>Computer</Class>
               <Name>    coincoin     </Name>
                <DeplState>Inactive</DeplState>
                <InciState>Operational</InciState>
                <CIXMLData>
            <Vendor>Lenovo</Vendor>
            <Model>Thinkpad</Model>
            <Description>Thinkpad X300</Description>
            <Type>Desktop</Type>
            <Owner>PO</Owner>
            <SerialNumber>abc12345abc</SerialNumber>
            <OperatingSystem>CentOS 6.0</OperatingSystem>
            <CPU>Intel Core i3</CPU>
            <Ram>4000</Ram>
            <Ram>2000</Ram>
            <HardDisk>
                <HardDisk>/dev</HardDisk>
                <Capacity>50000</Capacity>
            </HardDisk>
            <FQDN>host.example.com</FQDN>
            <NIC>
                <NIC>Eth0</NIC>
                <IPoverDHCP>No</IPoverDHCP>
                <IPAddress>192.168.30.1</IPAddress>
            </NIC>
            <NIC>
                <NIC>Eth1</NIC>
                <IPoverDHCP>Yes</IPoverDHCP>
                <IPAddress>200.34.56.78</IPAddress>
            </NIC>
            <GraphicAdapter>ATI Radeon 300</GraphicAdapter>
            <WarrantyExpirationDate>12/12/1977</WarrantyExpirationDate>
            <InstallDate>1977-12-12</InstallDate>
            <Note>This is a Demo CI</Note>
        </CIXMLData>

            </ConfigItem>
        
      </AddCI>
    </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_CREATETICKET
        private const int SERVICE_CREATETICKET = 2;
        /// <summary>
        /// This soap request tells otrs to create a new ticket.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// {2}: queue name
        /// {3}: customeruser
        /// {4}: state
        /// {5}: title
        /// {6}: priority id
        /// {7}: type
        /// {8}: time units (minutes)
        /// {9}: Article subject
        /// {10}: Article Body
        /// {11}: Article Contentype
        /// {12}: Article time unit (minutes)
        /// {13}: FIB number (goes in Dynamicfield FIBNumber) 
        /// </summary>
        public static String SOAP_CREATETICKET = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <ticketCreate xmlns=""SercoNamespace"">
         <UserLogin>{0}</UserLogin>
         <Password>{1}</Password>
<Ticket>
         <Queue>{2}</Queue>
         <CustomerUser>{3}</CustomerUser>
         <State>{4}</State>
         <Title>{5}</Title>
         <PriorityID>{6}</PriorityID>
         <Type>{7}</Type>
         <TimeUnits>{8}</TimeUnits>
         <Service>{14}</Service>
</Ticket>
<Article>
             <Subject>{9}</Subject>
             <Body>{10}</Body>
             <ContentType>{11}</ContentType>
             <TimeUnit>{12}</TimeUnit>
</Article>
<DynamicField>
            <Name>FIBNumber</Name>
            <Value>{13}</Value>
</DynamicField>
          </ticketCreate>
    </soap:Body>
  </soap:Envelope>";
        #endregion

//        #region SERVICE_CREATETICKET
//        private const int SERVICE_CREATETICKET = 2;
//        /// <summary>
//        /// This soap request tells otrs to create a new ticket.
//        /// Format params:
//        /// {0}: username
//        /// {1}: password
//        /// {2}: queue name
//        /// {3}: customeruser
//        /// {4}: state
//        /// {5}: title
//        /// {6}: priority id
//        /// {7}: type
//        /// {8}: time units (minutes)
//        /// {9}: Article subject
//        /// {10}: Article Body
//        /// {11}: Article Contentype
//        /// {12}: Article time unit (minutes)
//        /// {13}: FIB number (goes in Dynamicfield FIBNumber) 
//        /// </summary>
//        private static String SOAP_CREATETICKET = @"<?xml version=""1.0"" encoding=""utf-8""?>
//  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
//    <soap:Body>
//      <ticketCreate xmlns=""SercoNamespace"">
//         <UserLogin>{0}</UserLogin>
//         <Password>{1}</Password>
//<Ticket>
//         <Queue>{2}</Queue>
//         <CustomerUser>{3}</CustomerUser>
//         <State>{4}</State>
//         <Title>{5}</Title>
//         <PriorityID>{6}</PriorityID>
//         <Type>{7}</Type>
//         <TimeUnits>{8}</TimeUnits>
//         <Service>{14}</Service>
//</Ticket>
//<Article>
//             <Subject>{9}</Subject>
//             <Body>{10}</Body>
//             <ContentType>{11}</ContentType>
//             <TimeUnit>{12}</TimeUnit>
//</Article>
//<DynamicField>
//            <Name>FIBNumber</Name>
//            <Value>{13}</Value>
//</DynamicField>
//<Attachment>
//            <Content></Content>
//            <ContentType></ContentType>
//            <Filename></Filename>
//</Attachment>
//      </ticketCreate>
//    </soap:Body>
//  </soap:Envelope>";
//        #endregion

        #region SERVICE_CREATETICKETARTICLE
        private const int SERVICE_CREATETICKETARTICLE = 3;
        /// <summary>
        /// This soap request tells otrs to create a new article for a specific ticket.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// {2}: ticket number
        /// {3}: article type
        /// {4}: sender type
        /// {5}: from
        /// {6}: to
        /// {7}: cc
        /// {8}: reply to
        /// {9}: subject
        /// {10}: body
        /// {11}: MessageID
        /// {12}: Charset
        /// {13}: HistoryType
        /// {14}: HistoryComment
        /// {15}: UserID
        /// {16}: NoAgentNotify
        /// {17}: Type
        /// {18}: Loop
        /// </summary>
        private static String SOAP_CREATETICKETARTICLE = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <Dispatch xmlns=""/Core"">
        <c-gensym62>{0}</c-gensym62>
        <c-gensym64>{1}</c-gensym64>

        <c-gensym66>TicketObject</c-gensym66>
        <c-gensym68>ArticleSend</c-gensym68>

        <c-gensym70>TicketID</c-gensym70>
        <c-gensym72>{2}</c-gensym72>

        <c-gensym74>ArticleType</c-gensym74>
        <c-gensym76>{3}</c-gensym76>

        <c-gensym78>SenderType</c-gensym78>
        <c-gensym80>{4}</c-gensym80>

        <c-gensym82>From</c-gensym82>
        <c-gensym84>{5}</c-gensym84>

        <c-gensym86>To</c-gensym86>
        <c-gensym88>{6}</c-gensym88>

        <c-gensym90>Cc</c-gensym90>
        <c-gensym92>{7}</c-gensym92>

        <c-gensym94>ReplyTo</c-gensym94>
        <c-gensym96>{8}</c-gensym96>

        <c-gensym98>Subject</c-gensym98>
        <c-gensym100>{9}</c-gensym100>

        <c-gensym102>Body</c-gensym102>
        <c-gensym104>{10}</c-gensym104>

        <c-gensym106>MessageID</c-gensym106>
        <c-gensym108>{11}</c-gensym108>

        <c-gensym110>Charset</c-gensym110>
        <c-gensym112>{12}</c-gensym112>

        <c-gensym114>HistoryType</c-gensym114>
        <c-gensym116>{13}</c-gensym116>

        <c-gensym118>HistoryComment</c-gensym118>
        <c-gensym120>{14}</c-gensym120>

        <c-gensym122>UserID</c-gensym122>
        <c-gensym124>{15}</c-gensym124>

        <c-gensym126>NoAgentNotify</c-gensym126>
        <c-gensym128>{16}</c-gensym128>

        <c-gensym130>Type</c-gensym130>
        <c-gensym132>{17}</c-gensym132>

        <c-gensym134>Loop</c-gensym134>
        <c-gensym136>{18}</c-gensym136>
      </Dispatch>
    </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_SEARCHTICKETS
        private const int SERVICE_SEARCHTICKETS = 42;
        /// <summary>
        /// This soap request tells otrs to retrieve tickets (open statetype)s.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_SEARCHTICKETS = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <SearchTickets xmlns=""skounamespace"">
         <UserLogin>{0}</UserLogin>
         <Password>{1}</Password>
            <StateType>pending reminder</StateType>
            <StateType>open</StateType>
            <StateType>new</StateType>
            <Subject>
                <Like>{2}</Like>
            </Subject>
      </SearchTickets> 
     </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_GETTICKET
        private const int SERVICE_GETTICKET = 44;
        /// <summary>
        /// This soap request tells otrs to retrieve tickets (open statetype)s.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// </summary>
        private static String SOAP_GETTICKET = @"<?xml version=""1.0"" encoding=""utf-8""?>
  <soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <GetTicket xmlns=""skounamespace"">
         <UserLogin>{0}</UserLogin>
         <Password>{1}</Password>
         <TicketID>{2}</TicketID>
         <DynamicFields>1</DynamicFields>
      </GetTicket> 
     </soap:Body>
  </soap:Envelope>";
        #endregion
        #region SERVICE_UPDATETICKET
        private const int SERVICE_UPDATETICKET = 51;
        /// <summary>
        /// This soap request tells otrs to update an existing ticket.
        /// Format params:
        /// {0}: username
        /// {1}: password
        /// {2}: Ticket number
        /// {3}: customeruser
        /// {4}: state
        /// {5}: title
        /// {6}: priority id
        /// {7}: type
        /// {8}: time units (minutes)
        /// {9}: Article subject
        /// {10}: Article Body
        /// {11}: Article Contentype
        /// {12}: Article time unit (minutes)
        /// {13}: FIB number (goes in Dynamicfield FIBNumber) 
        /// </summary>
        private static String SOAP_UPDATETICKET = @"<?xml version=""1.0"" encoding=""utf-8""?>
<soap:Envelope xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" soap:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
    <soap:Body>
      <UpdateTicket xmlns=""SercoNamespace"">
         <UserLogin>{0}</UserLogin>
         <Password>{1}</Password>
        <TicketNumber>{2}</TicketNumber>
        <Ticket>
         <State>{3}</State>
         <Title>{4}</Title>
         <Queue>{5}</Queue>
        </Ticket>
</UpdateTicket>
</soap:Body>
</soap:Envelope>";
        #endregion

        /// <summary>
        /// Stub to call the GLPIProgram.GLPIGetBasicInventoryToGlobalVariables() function
        /// </summary>
        static public void ChoiceGetGLPI()
        {
            GLPIProgram.GLPIGetBasicInventoryToGlobalVariables();
        }
        /// <summary>
        /// Gets OTRS TICKET (and not articles) detail for that OTRS ticket ID (not ticket number) 
        /// </summary>
        /// <param name="_OTRS_tkt_number">requested ticket number </param>
        /// <remarks>Note that ticket number is contained in a string, this is a requested behaviour</remarks>
        /// <returns>GetTicketResponse object containing the details of the ticket number requested in parameter </returns>
        static public GetTicketResponse OTRSTicketGet(string _OTRS_tkt_number)
        {
            Common.InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            // construct request : 
            DebugWrite("Called with parameter " + _OTRS_tkt_number, ConsoleColor.Green);
            Common.RPC_and_SOAP_Construct_Data.Clear(); // make sure RPC_and_SOAP_Construct_Data is empty
            Common.RPC_and_SOAP_Construct_Data.Add(Common.OTRS_username);
            Common.RPC_and_SOAP_Construct_Data.Add(Common.OTRS_password);
            Common.RPC_and_SOAP_Construct_Data.Add(_OTRS_tkt_number);
            // construct SOAP request and submit to OTRS 
            XmlDocument _XMLOTRSTicket = OTRSserviceCall(OTRS_Globalurl, SERVICE_GETTICKET, RPC_and_SOAP_Construct_Data) ?? null;
            if (_XMLOTRSTicket == null)
            {
                InfoWrite("Empty XMLdocumentTicket returned from OTRS ", ConsoleColor.Red);
                return null;
            }
            StringWriter _stringWriter = new StringWriter();
            XmlTextWriter _xmlTextWriter = new XmlTextWriter(_stringWriter);
            _XMLOTRSTicket.WriteTo(_xmlTextWriter);
            GetTicketResponse _tmpOTRSTicket = new GetTicketResponse();
            string _OTRSTicketString = _stringWriter.ToString();
            if (Common.CommonDoesXMLContainErrorString(_OTRSTicketString))
            {
                InfoWrite("ERROR in XMLdocumentTicket returned from OTRS ", ConsoleColor.Red);
                return null;
            }
            DebugWrite("OTRS Ticket returned XML is : " + _OTRSTicketString, ConsoleColor.Green);
            var myDeserializer = new XmlSerializer(typeof(GetTicketResponse), new XmlRootAttribute("GetTicketResponse"));
            // construct the text reader to hold the XML string 
            using (TextReader _reader = new StringReader(_OTRSTicketString))
            {
                // Construct the XMLTextReader containing the XML stream
                DebugWrite("outer using", ConsoleColor.Yellow);

                using (XmlTextReader _xreader = new XmlTextReader(_reader))
                {
                    _xreader.Namespaces = false;
                    //    // REMEMBER we deserialize an object and NOT a list !
                    try
                    {
                        _tmpOTRSTicket = (GetTicketResponse)myDeserializer.Deserialize(_xreader);
                    }
                    catch (Exception e)
                    {
                        DebugWrite("failed deserialization " + e.Message.ToString(), ConsoleColor.Yellow);
                        return null;
                    }
                    DebugWrite(string.Format("Ticket fields : {0} {1} {2} {3} ",
                        _tmpOTRSTicket.Ticket.TicketNumber.ToString(),
                        _tmpOTRSTicket.Ticket.Owner.ToString(),
                        _tmpOTRSTicket.Ticket.State.ToString(),
                        _tmpOTRSTicket.Ticket.Queue.ToString()),
                        ConsoleColor.Yellow);
                    // <summary>The following approach is an elegant way to retried the Value of a specific variable
                    // returned in an immbeded hash table *dynamicField@ inside the object Ticket
                    // </summary>
                    // deal with FIBNumber in CNES/CSG 
                    try
                    {
                        var _ttemp = _tmpOTRSTicket.Ticket.DynamicField.Where(x => x.Name == "FIBNumber").ToList();
                        _tmpOTRSTicket.Ticket.FIBNumber = _ttemp[0].Value;
                        // Return the ticket 
                        return _tmpOTRSTicket;
                    }
                    catch (Exception e)
                    {
                        InfoWrite("Exception processing FIB number field" + e.Message.ToString(), ConsoleColor.Yellow);
                        return null;

                    }
                }
                }
        }
        //static public void OTRSTicketsToGlobalListOfTickets(SearchTicketsResponse _OTRSticketslist)
        /// <summary>
        /// Add a ticket to the global list of tickets 
        /// </summary>
        /// <param name="_tmpticket">OTRS Ticket</param>
        static public void OTRSTicketsToGlobalListOfTickets(GetTicketResponse _tmpticket)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            // get parameters (name of CI for Search)
            GGlobal_OTRS_Tickets.Add(_tmpticket);
        }
        /// <summary>
        /// Search OTRS for CI with a certain pattenr matching name,
        /// get short list and re-issue as many requests to OTRS for details on those CIs
        /// then loop : 
        /// fills up the public list of configitems OTRSConfigItemsList with the returned CIs
        /// </summary>
        /// <param name="pattern">a search pattern (default *) </param>
        /// 
        static public void OTRSSearchOpenTicketsbySubject(string pattern)
        {
            Common.InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            // get parameters (name of CI for Search)
            if (pattern.Length < 1)
            {
                InfoWrite("Missing OTRS search pattern", ConsoleColor.Red);
                return;
            }
            // empty OTRS global variables.
            Common.GGlobal_OTRSTicketsNumberList = null;
            GGlobal_OTRS_Tickets.Clear(); 

            // first get OTRS to send us all tickets ID matching our condition 
            Common.RPC_and_SOAP_Construct_Data.Clear(); // make sure RPC_and_SOAP_Construct_Data is empty
            Common.RPC_and_SOAP_Construct_Data.Add(Common.OTRS_username);
            Common.RPC_and_SOAP_Construct_Data.Add(OTRS_password);
            RPC_and_SOAP_Construct_Data.Add(pattern);
            // construct SOAP request and submit to OTRS 
            XmlDocument XMLListofTickets = OTRSserviceCall(OTRS_Globalurl, SERVICE_SEARCHTICKETS, RPC_and_SOAP_Construct_Data) ?? null;
            if (XMLListofTickets == null)
            {
                InfoWrite("Empty XMLdocument list of tickets  returned from OTRS ", ConsoleColor.Red);
                //Console.ReadKey();    
                return;
            }
            // convert the returned xmldocument to a string 
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            XMLListofTickets.WriteTo(xmlTextWriter);
            string _TicketsIDlist = stringWriter.ToString();
            SearchTicketsResponse _templistoftickets = new SearchTicketsResponse();
            if (_templistoftickets.TicketID == null) { DebugWrite("_templistoftickets.TicketID is null", ConsoleColor.Red); }
            // if we wanted to change the root element : var mySerializer = new XmlSerializer(typeof(SearchTicketsResponse), new XmlRootAttribute("SearchTicketsResponse"));
//            var mySerializer = new XmlSerializer(typeof(SearchTicketsResponse));
            var myDeserializer = new XmlSerializer(typeof(SearchTicketsResponse), new XmlRootAttribute("SearchTicketsResponse"));
            // construct the text reader to hold the XML string 
            using (TextReader _reader = new StringReader(_TicketsIDlist))
            {
                // Construct the XMLTextReader containing the XML stream
                using (XmlTextReader _xreader = new XmlTextReader(_reader))
                {
                    _xreader.Namespaces = false;
                    // REMEMBER we deserialize an object and NOT a list !
                    Common.GGlobal_OTRSTicketsNumberList = (SearchTicketsResponse)myDeserializer.Deserialize(_xreader);
                }
            }
            Common.DebugWrite("Tickets Search list size is : " + GGlobal_OTRSTicketsNumberList.TicketID.Count().ToString(), ConsoleColor.Yellow);
            // from now we have all tickets id in the GGlobal_OTRSTicketsNumberList Public object. 
            // we can call OTRS for each of them to get the details for each ticket and store these in a list of tickets objects. 
            foreach (string _tmpTicketID in GGlobal_OTRSTicketsNumberList.TicketID)
            {
                Common.InfoWrite(string.Format("Processing (loading) Ticket ID :  {0}", _tmpTicketID.ToString()), ConsoleColor.Green);
                GetTicketResponse _tmpticket = OTRSTicketGet(_tmpTicketID);
                bool _AlreadyInRAM = GGlobal_OTRS_Tickets.Any(r => r.Ticket.TicketNumber == _tmpticket.Ticket.TicketNumber);
    
                if (!(_tmpticket == null) && (!_AlreadyInRAM))
                {
                    OTRSTicketsToGlobalListOfTickets(_tmpticket);
                }
            }
        }
        /// <summary>
        /// This function just displays current OTRS Tickets in Global List
        /// </summary>
        static public void OTRSListTicketsinRAM()
        {
            Common.InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            foreach (GetTicketResponse _tmpTicket in GGlobal_OTRS_Tickets)
            {

                //var _ttemp = _tmpTicket.Ticket.DynamicField.Where(x => x.Name=="FIBNumber").ToList() ;
                //Common.InfoWrite(_ttemp[0].Value + _ttemp[0].Name, ConsoleColor.Green);
                //_tmpTicket.Ticket.FIBNumber = _ttemp[0].Value;
                //string _tfibnumber = _tmpTicket.Ticket.DynamicField[   DynamicField[0].Value.ToString(); 
                InfoWrite(string.Format("Ticket fields : ID {0} owner {1} state {2} queue {3} title {4} FIB (if any) : {5} ",
                        _tmpTicket.Ticket.TicketNumber.ToString(),
                        _tmpTicket.Ticket.Owner.ToString(),
                        _tmpTicket.Ticket.State.ToString(),
                        _tmpTicket.Ticket.Queue.ToString(),
                        _tmpTicket.Ticket.Title.ToString(),
                        _tmpTicket.Ticket.FIBNumber.ToString()),
                        //_tmpTicket.Ticket.DynamicField[0].Value.ToString()),
                        ConsoleColor.Green);
            }

        }
        /// <summary>
        /// Search OTRS for CI with a certain pattenr matching name,
        /// get short list and re-issue as many requests to OTRS for details on those CIs
        /// then loop : 
        /// fills up the public list of configitems OTRSConfigItemsList with the returned CIs
        /// </summary>
        /// <param name="pattern">a search pattern (default *) </param>
        static public void OTRSSearchOTRSCIsByName(string pattern)
        {
            Common.InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            // get parameters (name of CI for Search)
            //string param = pattern; 
            if (pattern.Length < 1 ) { 
                Console.WriteLine("OTRS CI Name search pattern ");
                pattern = Console.ReadLine();
                }
            RPC_and_SOAP_Construct_Data.Clear(); // make sure RPC_and_SOAP_Construct_Data is empty
            RPC_and_SOAP_Construct_Data.Add(OTRS_username);
            RPC_and_SOAP_Construct_Data.Add(OTRS_password);
            RPC_and_SOAP_Construct_Data.Add(pattern);
            // first call OTRS to get the list of CIs 
            XmlDocument XMLListofCIs = OTRSserviceCall(OTRS_Globalurl, SERVICE_SEARCHCI, RPC_and_SOAP_Construct_Data) ?? null;
            if (XMLListofCIs == null)
            {
                InfoWrite("Empty XMLdocument returned ", ConsoleColor.Red);
                //Console.ReadKey();    
                return;
            }
            // convert the returned xmldocument to a string 
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            XMLListofCIs.WriteTo(xmlTextWriter);
            string _ttemp2 = stringWriter.ToString();
            DebugWrite("Returned XML from OTRS is : " + _ttemp2, ConsoleColor.Yellow);
            // store the CI numbers to a list of string 
            List<string> _listofCIs = OTRSSearchCIsXMLtoCIListofString(_ttemp2);
            // foreach CI in the new list : 
            // issue query to OTRS (in OTRSCInumbertoCIXMLresult)
            foreach (string _ttemp3 in _listofCIs)
            {
                DebugWrite(_ttemp3, ConsoleColor.Red);
                string _CIXML = OTRSCInumbertoCIXMLresult(_ttemp3);
                ConfigItem _Confitem = OTRSCIXMLtoCIObject(_CIXML);
                OTRSConfigItemsList.Add(_Confitem);
            }
            // sort the list by name (String) 
            //OTRSConfigItemsList.Sort((x, y) => x.Name.CompareTo(y.Name));
         }
        /// <summary>
        /// Compare 2 identically structured lists (of (left) GLPI CI in GLPI_Partial_CI objects and (right) OTRS ConfigITems. 
        /// </summary>
        /// <param name="_GLPI_List"></param>
        /// <param name="_OTRS_List"></param>
        /// <returns>list of GLPI_PArtial_Objects that did not match</returns>
        public static List<GLPI_Partial_CI> SE_Find_Unmatched_items (List<GLPI_Partial_CI> _GLPI_List, List<ConfigItem> _OTRS_List )
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            var _unmatched_GLPI_Cis = new List<GLPI_Partial_CI>();
            _unmatched_GLPI_Cis.Add(new GLPI_Partial_CI(1, "Name", "ID", "Entityname", "EntityID", "ItemType", "Serial", "OtherSerial", "ItemTypeName"));
            var _matched_GLPI_Cis = new List<GLPI_Partial_CI>();
            _matched_GLPI_Cis.Add(new GLPI_Partial_CI(1, "Name", "ID", "Entityname", "EntityID", "ItemType", "Serial", "OtherSerial", "ItemTypeName"));

            var _GLPI_List2 =_GLPI_List.OrderBy(o => o.name).ToList();
            // OTRSConfigItemsList.Sort((x, y) => x.Name.CompareTo(y.Name));
            _OTRS_List.Sort((x, y) => x.Name.CompareTo(y.Name));
            bool _found = false;             
            foreach (var _tg in _GLPI_List2)
            {
                _found = false;
                foreach (var _to in _OTRS_List)
                {
                    if (_tg.name == _to.Name)
                    {
                        _found = true;
                    }
                }
                if (_found)
                    {
                    _matched_GLPI_Cis.Add(_tg);
                    _found = false;
                    }
                else
                    {
                    _unmatched_GLPI_Cis.Add(_tg);
                    }
                }
            //}
            if (_unmatched_GLPI_Cis.Count > 1) { _unmatched_GLPI_Cis.RemoveAt(0); }
            if (_matched_GLPI_Cis.Count > 1) { _matched_GLPI_Cis.RemoveAt(0); }
            InfoWrite("Matching CIs : ", ConsoleColor.Gray);
            foreach (GLPI_Partial_CI _tmpCI in _matched_GLPI_Cis)
            {
                InfoWrite(_tmpCI.name, ConsoleColor.Green);
            }
            InfoWrite("Count of CIs in _matchedList : " + _matched_GLPI_Cis.Count.ToString(), ConsoleColor.Green );
            InfoWrite("NOT Matching CIs : ", ConsoleColor.Gray);
            foreach (GLPI_Partial_CI _tmpCI in _unmatched_GLPI_Cis)
            {

                InfoWrite(string.Format("GLPI CI unmatched: Entity : {0}, CI Name{1}, Serial{2}, Type{3}, Type Name{4} " ,_tmpCI.entities_name, _tmpCI.name , _tmpCI.serial,_tmpCI.itemtype, _tmpCI.itemtype_name), ConsoleColor.Red);
                // add it to OTRS 
                // we should remove it also but doesn't matter yet 
                GLPIProgram.GLPIGetDetailedCI(_tmpCI.id.ToString());

            }
            InfoWrite("Count of CIs in _UNmatchedList : " + _unmatched_GLPI_Cis .Count.ToString(), ConsoleColor.Red);
            InfoWrite("Count of CIs in _matchedList : " + _matched_GLPI_Cis.Count.ToString(), ConsoleColor.Green);
            // add it 
            return _unmatched_GLPI_Cis; 
            }
        /// <summary>
        /// Set the HttpWebRequest config to allow unsafe header parsing.
        /// </summary>
        /// <returns>bool </returns>
        public static bool setAllowUnsafeHeaderParsing()
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            //Get the assembly that contains the internal class
            Assembly aNetAssembly = Assembly.GetAssembly(typeof(System.Net.Configuration.SettingsSection));
            if (aNetAssembly != null)
            {
                //Use the assembly in order to get the internal type for the internal class
                Type aSettingsType = aNetAssembly.GetType("System.Net.Configuration.SettingsSectionInternal");
                if (aSettingsType != null)
                {
                    //Use the internal static property to get an instance of the internal settings class.
                    //If the static instance isn't created allready the property will create it for us.
                    object anInstance = aSettingsType.InvokeMember("Section",
                      BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.NonPublic, null, null, new object[] { });

                    if (anInstance != null)
                    {
                        //Locate the private bool field that tells the framework is unsafe header parsing should be allowed or not
                        FieldInfo aUseUnsafeHeaderParsing = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic | BindingFlags.Instance);
                        if (aUseUnsafeHeaderParsing != null)
                        {
                            aUseUnsafeHeaderParsing.SetValue(anInstance, true);
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns a HttpWebRequest for otrs soap action.
        /// </summary>
        /// <param name="url">target URL </param>
        /// <returns>Webrequest object that can be then reused </returns>
        /// 
        public static HttpWebRequest OTRScreateWebRequest(string url)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Headers.Add("SOAP:Action");
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
                webRequest.Proxy = WebRequest.DefaultWebProxy;
                return webRequest;
            }
            catch (Exception e)
            {
                Common.InfoWrite("failed Getting PS FIBs information, probably communication error : --> " + e.Message.ToString(), ConsoleColor.Yellow);
                return null;
            }

        }
        /// <summary>
        /// Performs a service call to the otrs system.
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <param name="service">the service defined in the OTRSCodeStructure, containing all proper XML strings</param>
        /// <param name="data">the arrary containing the parameters to be replaced in the Service XML structure (e.g. id/password/action/etc</param>
        /// <returns>an XMLDocument containing the XML reply from OTRS </returns>
        public static XmlDocument OTRSserviceCall(string url, int service, ArrayList data)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            HttpWebRequest request = null;
            request = OTRScreateWebRequest(url);
            if (request == null)
            {
                return null;
            }
            //HttpWebResponse response = null;
            try
            {
                //HttpWebRequest 
                //request = OTRScreateWebRequest(url);
                //response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception e)
            {
                DebugWrite("Exception raised with trying to access the service" + e.Message.ToString(), ConsoleColor.Red);
            }

            //            if (!(response == null || response.StatusCode != HttpStatusCode.OK))
                if (true)
                {
                    XmlDocument soapEnvelopeXml = OTRSFeedServiceVariabletoSoapXml(service, data);
                using (var stringWriter = new StringWriter())
                    try
                    {
                        // issue the web request via stream
                        using (Stream stream = request.GetRequestStream())
                        {
                            soapEnvelopeXml.Save(stream);
                        }
                    }
                    catch (WebException e)
                    {
                        Common.InfoWrite("Error accessing the OTRS WebServices : " + e.Message.ToString(),ConsoleColor.Red);
                        if (e.Status == WebExceptionStatus.ProtocolError)
                        {
                            WebResponse eresp = e.Response;
                            using (StreamReader sr = new StreamReader(eresp.GetResponseStream()))
                            {
                                String sresp = "\r\n<" + DateTime.Now.ToString(dateTimeFormat) + ">\r\n" + sr.ReadToEnd();
                                //File.AppendAllText(errorFilePath, sresp);
                                // display exception 
                                DebugWrite("web exception protocol error" + sresp, ConsoleColor.Red);
                            }
                        }
                    }
                // if we are here, there is no protocol error 
                Common.DebugWrite("No protocol error,about to process asyncResult", ConsoleColor.Green);
                IAsyncResult asyncResult = null;
                string soapResult = String.Empty;
                try
                {
                    asyncResult = request.BeginGetResponse(null, null);
                    asyncResult.AsyncWaitHandle.WaitOne();
                }

                catch (Exception e)
                {
                    InfoWrite("Exception catched at try asyncResult " + e.Message, ConsoleColor.Red);
                    return (null);
                }
                try
                {
                    using (WebResponse webResponse = request.EndGetResponse(asyncResult))
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                        Common.DebugWrite("OTRS Raw soapResult is : " + soapResult, ConsoleColor.White);
                        // string soapResult contains the full response from OTRS. 
                        //  we can parse it using our OTRS Classes. 
                        // 
                        // configitem parse. 
                        // get rid of the soap enveloppe;
                        XDocument xDoc = XDocument.Parse(soapResult);
                        // get rid of the soap enveloppe. 
                        var unwrappedResponse = xDoc.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" +
                            "Body")
                            .First()
                            .FirstNode
                            ;
                        xDoc = XDocument.Parse(unwrappedResponse.ToString());
                        StringWriter stringWriter = new StringWriter();
                        XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                        xDoc.WriteTo(xmlTextWriter);
                        soapResult = stringWriter.ToString();
                    }
                }
                catch (WebException e)
                {
                    DebugWrite("Exception raised while using webResponse or StreamReader " + e.Message.ToString(), ConsoleColor.Red);

                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        WebResponse eresp = e.Response;
                        using (StreamReader sr = new StreamReader(eresp.GetResponseStream()))
                        {
                            String sresp = "\r\n<" + DateTime.Now.ToString(dateTimeFormat) + ">\r\n" + sr.ReadToEnd();
                            //File.AppendAllText(errorFilePath, sresp);
                            // display exception 
                            DebugWrite("WebException Error Response: " + sresp, ConsoleColor.Red);
                        }
                    }

                }
                // debug only DebugWrite(soapResult, ConsoleColor.Green);
                // debug step by step loop Console.ReadKey();
                //DebugWrite answer to file
                //File.WriteAllText(String.Format(responsefilepath, DateTime.Now.ToString(dateTimeFormat), service), soapResult);

                XmlDocument _returnXMLDoc = new XmlDocument();

                try
                {
                    _returnXMLDoc.LoadXml(soapResult);
                }
                catch (Exception e)
                {
                    DebugWrite("Exception raised with saving XML result to string" + e.Message.ToString(), ConsoleColor.Red);
                }

                return _returnXMLDoc;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Add (not replace) a CI to OTRS (normally from a pulled CI from GLPI) 
        /// </summary>
        /// <param name="_CI"> a configitem type  CI object </param>
        /// <returns>String containing CIXML</returns>
        public static string OTRSAddCItoOTRSCMDB(ConfigItem _CI)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            //DebugWrite("--> OTRSAddCItoOTRSCMDB", ConsoleColor.Magenta);
            ArrayList data = new ArrayList();
            data.Clear();
            data.Add(OTRS_username);
            data.Add(OTRS_password);
            data.Add(_CI.Name);
            data.Add(_CI.CIXMLData.Vendor);
            data.Add(_CI.CIXMLData.Model);
            data.Add(_CI.CIXMLData.Type);
            data.Add(_CI.CIXMLData.Owner);
            data.Add(_CI.CIXMLData.SerialNumber);
            data.Add(_CI.CIXMLData.OperatingSystem);
            XmlDocument _CIToAddToOTRS = OTRSserviceCall(OTRS_Globalurl, SERVICE_ADDCI, data);
            // convert XMLdocument to string 
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            _CIToAddToOTRS.WriteTo(xmlTextWriter);
            string _OTRSXMLResponse = stringWriter.ToString();
            //string _ttemp = _temp.ToString();
            DebugWrite(_OTRSXMLResponse, ConsoleColor.Cyan);
            return _OTRSXMLResponse;
        }
        /// <summary>
        /// returns a string containing the XML of the OTRS CI number (as string) passed as argument (or null if no CI with that number in OTRS)
        /// </summary>
        /// <param name="_CINumber">String containing the CI number to look for </param>
        /// <returns>
        /// XML string containing the OTRS CI 
        /// </returns>
        public static string OTRSCInumbertoCIXMLresult(string _CINumber)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            // DebugWrite("--> OTRSCInumbertoCIXMLresult", ConsoleColor.Magenta);

            ArrayList data = new ArrayList();
            data.Clear();
            data.Add(OTRS_username);
            data.Add(OTRS_password);
            data.Add(_CINumber);
            XmlDocument _OTRS_CI_XML = OTRSserviceCall(OTRS_Globalurl, SERVICE_GETCI, data);
            if (_OTRS_CI_XML != null)
            {
                // convert XMLdocument to string 
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                _OTRS_CI_XML.WriteTo(xmlTextWriter);
                string _OTRS_CI_XML_String = stringWriter.ToString();
                //string _ttemp = _temp.ToString();
                DebugWrite(_OTRS_CI_XML_String, ConsoleColor.Cyan);
                return _OTRS_CI_XML_String;
            }
            else { return null; }
        }
        /// <summary>
        /// OTRSSearchCIsXMLtoCIListofString
        /// </summary>
        /// <param name="_XMLString"></param>
        /// <returns>
        /// List of ConfigItem Objects 
        /// </returns>
        private static List<string> OTRSSearchCIsXMLtoCIListofString(string _XMLString)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            // quick and dirty way to check if a value has been returned : 
            // if (!_XMLString.Contains("< SearchCIResponse xmlns = \"SercoNamespace\" >< ConfigItemIDs /></ SearchCIResponse >"))
            // {
            //var SubXML = xDoc.Root.Elements().ToString();
            DebugWrite("_XMLString : " + _XMLString , ConsoleColor.Yellow);
            var SubXML = _XMLString.ToString();
                //soapResult = ConfitemSearch results;
                // Deserialise our XML using our ConfigItem object, REMEMBER the namespace definition is mandatory in our object definition 
                XmlSerializer TopOTRSConfigItem = new XmlSerializer(typeof(SearchCIResponse));
                var tempvar = new List<string>();
            try
            {
                DebugWrite("before using", ConsoleColor.Yellow);
                using (TextReader soapreader = new StringReader(SubXML))
                {
                    DebugWrite("before deserialize", ConsoleColor.Yellow);
                    var OTRSConfigITemResult = (SearchCIResponse)TopOTRSConfigItem.Deserialize(soapreader);
                    // Console.WriteLine(OTRSConfigITemResult);
                    // Console.WriteLine("     CId     --> " + OTRSConfigITemResult.ConfigItemIDs.ToString());
                    foreach (var tt in OTRSConfigITemResult.ConfigItemIDs)
                    {
                        DebugWrite("CCID from tt : " + tt.ToString(), ConsoleColor.Green);
                        //Console.WriteLine("CCID from tt : " + tt.ToString());
                        tempvar.Add(tt.ToString());
                    }
                }
            }
            catch (Exception except)
            {
                Console.WriteLine("Catched exception : " + except.Message);
            }
            return tempvar;
        }
        /// <summary>
        /// XMLtoCI  inputs OTRS XML String (without enveloppe)
        /// </summary>
        /// 
        /// Output : OTRS ConfigItem Object 
        /// 
        private static ConfigItem OTRSCIXMLtoCIObject(string _XMLString)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
                if (_XMLString.Contains("<GetCIResponse xmlns"))
            {
                // transform _XmlString to XMLdoc to remove the root object
                XDocument xDoc = XDocument.Parse(_XMLString);
                string SubXML = xDoc.Root.Elements().First().ToString();
                _XMLString = SubXML;
            }
                XmlSerializer TopOTRSConfigItem = new XmlSerializer(typeof(ConfigItem));
            var retvalue = new ConfigItem() ; 
            using (TextReader soapreader = new StringReader(_XMLString))
            {
                // soapreader.Namespaces = false;
                var OTRSConfigITem = (ConfigItem)TopOTRSConfigItem.Deserialize(soapreader);
                // get rid of "null" values in XML answer
                OTRSConfigITem.CIXMLData.OperatingSystem = OTRSConfigITem.CIXMLData.OperatingSystem ?? "Empty";
                OTRSConfigITem.CIXMLData.Model = OTRSConfigITem.CIXMLData.Model ?? "Empty";
                OTRSConfigITem.CIXMLData.SerialNumber = OTRSConfigITem.CIXMLData.SerialNumber ?? "Empty";
                OTRSConfigITem.CIXMLData.Vendor = OTRSConfigITem.CIXMLData.Vendor ?? "Empty";
                retvalue = OTRSConfigITem;
            }
            return retvalue;
        }
        /// <summary>
        /// Returns an XmlDocument ready to be sent to OTRS for the stated service.
        /// Parameter RPC_and_SOAP_Construct_Data is an arraylist containing the information pertinent for this service call. 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        private static XmlDocument OTRSFeedServiceVariabletoSoapXml(int service, ArrayList data)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            DebugWrite("Data contains" + data.Count.ToString(), ConsoleColor.White);
            var _cnt = 0;
            foreach (var _nn in data)
            {
                DebugWrite("data "+_cnt+"  is " + _nn.ToString(), ConsoleColor.White);
                _cnt++; 

            }
            //DebugWrite("--> OTRSFeedServiceVariabletoSoapXml", ConsoleColor.Magenta);
            XmlDocument retVal = new XmlDocument();
            switch (service)
            {
                case  services.SERVICE_GETGLPIPartialCI:
                    {
                        String soapenv = String.Format(services.XML_GETGLPIPartialCI,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_GETCI:
                    {
                        String soapenv = String.Format(SOAP_GETCI,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_SEARCHCI:
                    {
                        String soapenv = String.Format(SOAP_SEARCHCI,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_SEARCHTICKETS:
                    {
                        String soapenv = String.Format(SOAP_SEARCHTICKETS,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_GETTICKET:
                    {
                        String soapenv = String.Format(SOAP_GETTICKET,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_INVGETNUMBER:
                    {
                        String soapenv = String.Format(SOAP_INVGETNUMBER,
                            data[0].ToString()
                            , data[1].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_TICKETNUMBER:
                    {
                        String soapenv = String.Format(SOAP_TICKETNUMBER,
                            data[0].ToString()
                            , data[1].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_CREATETICKET:
                    {
                        String soapenv = String.Format(SOAP_CREATETICKET,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString()
                            , data[3].ToString()
                            , data[4].ToString()
                            , data[5].ToString()
                            , data[6].ToString()
                            , data[7].ToString()
                            , data[8].ToString()
                            , data[9].ToString()
                            , data[10].ToString()
                            , data[11].ToString()
                            , data[12].ToString()
                            , data[13].ToString()
                            , data[14].ToString());

                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_UPDATETICKET:
                    {
                        String soapenv = String.Format(SOAP_UPDATETICKET,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString()
                            , data[3].ToString()
                            , data[4].ToString()
                            , data[5].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }

                case SERVICE_CREATETICKETARTICLE:
                    {
                        String soapenv = String.Format(SOAP_CREATETICKETARTICLE,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString()
                            , data[3].ToString()
                            , data[4].ToString()
                            , data[5].ToString()
                            , data[6].ToString()
                            , data[7].ToString()
                            , data[8].ToString()
                            , data[9].ToString()
                            , data[10].ToString()
                            , data[11].ToString()
                            , data[12].ToString()
                            , data[13].ToString()
                            , data[14].ToString()
                            , data[15].ToString()
                            , data[16].ToString()
                            , data[17].ToString()
                            , data[18].ToString());
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                case SERVICE_ADDCI:
                    {
                        String soapenv = String.Format(SOAP_ADDCI,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString()
                            , data[3].ToString()
                            , data[4].ToString()
                            , data[5].ToString()
                            , data[6].ToString()
                            , data[7].ToString()
                            , data[8].ToString()
                           );
                        DebugWrite("SOAP string :  " + soapenv, ConsoleColor.White);
                        retVal.LoadXml(soapenv);
                        return retVal;
                    }
                default:
                    {
                        throw new Exception("InvalidServiceException: The requested OTRS service does not exist.");
                    }
            }
        }
        /// <summary>
        /// Adds a ticket to OTRS (Objects _TKT and _ART must be complete) 
        /// </summary>
        /// <param name="_TKT">new NewOTRSTicket object fully filled</param>
        /// <param name="_ART">new OTRSTicketArticle object fully filled</param>
        /// <returns>string containing the XML structure required to submit this new ticket/article to  OTRS for creation</returns>
        public static string OTRSAddTKTtoOTRS(NewOTRSTicket _TKT, OTRSTicketArticle _ART)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            ArrayList data = new ArrayList();
            data.Clear();
            data.Add(OTRS_username);
            data.Add(OTRS_password);
            data.Add(_TKT.Queue);
            data.Add(_TKT.CustomeUser);
            data.Add(_TKT.State);
            data.Add(_TKT.Title);
            data.Add(_TKT.PriorityID);
            data.Add(_TKT.Type);
            data.Add(_TKT.TimeUnits);
            data.Add(_ART.Subject);
            data.Add(_ART.Body);
            data.Add(_ART.ContentType);
            data.Add(_ART.TimeUnit);
            data.Add(_TKT.FIBNumber);
            data.Add(_TKT.Service);
            // handle attachements 
            var s2 = SOAP_CREATETICKET; // backup the SOAP Enveloppe

            if (!(_TKT.TKT_Attachments == null))
            {
                // construct dynamically the attachement XML to be embbedded in the SOAP envelope
                InfoWrite("found attachement in ticket:", ConsoleColor.Blue);
                foreach (var _tt in _TKT.TKT_Attachments.Keys)
                {
                    Common.InfoWrite("Adding To OTRS XML  object OTRS TKT attachment : " + _tt, ConsoleColor.Blue);

                    SOAP_CREATETICKET = SOAP_CREATETICKET.Replace("</DynamicField>", "</DynamicField><Attachment>" +
                        "<Content>" +
                        _TKT.TKT_Attachments[_tt] +
                        "</Content>" +
                        "<ContentType>" +
                            "text/plain; charset=utf8" +
                        "</ContentType>" +
                        "<Filename>" +
                            _tt +
                        "</Filename>" +
                        "</Attachment>");
                }
                Common.DebugWrite("SOAP " + SOAP_CREATETICKET, ConsoleColor.Blue);
            }
            //InfoWrite("About to call OTRSserviceCall", ConsoleColor.White);
            XmlDocument _temp = OTRSserviceCall(OTRS_Globalurl, SERVICE_CREATETICKET, data);
            // restore the variable (it is public) 
            if (!(s2 == null)) { SOAP_CREATETICKET = s2; }
            if (_temp != null)
            {
                // convert XMLdocument to string 
                //InfoWrite("About to Create stringwriter", ConsoleColor.White);
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                _temp.WriteTo(xmlTextWriter);
                string _ttemp = stringWriter.ToString();
                //InfoWrite(_ttemp, ConsoleColor.Cyan);
                return _ttemp;
            }
            else
            {
                Common.DebugWrite("OTRSAddTKTtoOTRS OTRS XML response is null ", ConsoleColor.Red);
                return null;
            }
        }
        /// <summary>
        /// This function will close the OTRS GETticketResponse object passed as parameter.  
        /// </summary>
        /// <param name="_tkt">the GETTicketResponse Object to be closed </param>
        /// <returns></returns>
        public static Boolean OTRSCloseTKTtoOTRS(GetTicketResponse _tkt)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            _tkt.Ticket.State = "closed successful";
            OTRSCode.OTRSUpdateTKTtoOTRS(_tkt.Ticket.TicketNumber, _tkt);
            return true;
        }
        /// <summary>
        /// This function will update the GetTicketResponse object passed as parameter. 
        /// </summary>
        /// <param name="_tktid">the ticketnumber</param>
        /// <param name="_TKT">the GetTicketResponse to update</param>
        /// <returns></returns>
        public static string OTRSUpdateTKTtoOTRS(string _tktid, GetTicketResponse _TKT)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            ArrayList data = new ArrayList();
            data.Clear();
            data.Add(OTRS_username);
            data.Add(OTRS_password);
            data.Add(_tktid);
            data.Add(_TKT.Ticket.State);
            //data.Add(_TKT.State);
            data.Add(_TKT.Ticket.Title);
            data.Add(_TKT.Ticket.Queue);
            //data.Add(_TKT.Type);
            //data.Add(_TKT.TimeUnits);
            //data.Add(_ART.Subject);
            //data.Add(_ART.Body);
            //data.Add(_ART.ContentType);
            //data.Add(_ART.TimeUnit);
            //data.Add(_TKT.FIBNumber);
            //InfoWrite("About to call OTRSserviceCall", ConsoleColor.White);
            XmlDocument _temp = OTRSserviceCall(OTRS_Globalurl, SERVICE_UPDATETICKET, data);
            if (_temp != null)
            {
                // convert XMLdocument to string 
                StringWriter stringWriter = new StringWriter();
                XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
                _temp.WriteTo(xmlTextWriter);
                string _ttemp = stringWriter.ToString();
                //InfoWrite(_ttemp, ConsoleColor.Cyan);
                return _ttemp;
            }
            else
            {
                Common.DebugWrite("OTRSUpdateTKTtoOTRS OTRS XML response is null ", ConsoleColor.Red);
                return null;
            }
        }
        /// <summary>
        /// Deserialize OTRS XML ticket response to ticket object
        /// </summary> 
        public static OTRSTicketCreateResponse OTRSrespTXMLtotktrespObject(string _XMLString)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            if (_XMLString != null)
            {
                if (_XMLString.Contains("<Error><ErrorCode>"))
                {
                    // transform _XmlString to XMLdoc to remove the root object
                    XDocument xDoc = XDocument.Parse(_XMLString);
                    //XmlDocument xDoc = new XmlDocument();
                    //xDoc.LoadXml(_XMLString);
                    string SubXML = xDoc.Root.Elements().First().ToString();
                    //string SubXML = xDoc.Root.Value;
                    _XMLString = SubXML;
                    return null;
                }
                else
                {
                    XmlSerializer _OTRSresponse = new XmlSerializer(typeof(OTRSTicketCreateResponse));
                    var retvalue = new OTRSTicketCreateResponse();
                    using (TextReader soapreader = new StringReader(_XMLString))
                    {
                        // soapreader.Namespaces = false;
                        var OTRSResponse = (OTRSTicketCreateResponse)_OTRSresponse.Deserialize(soapreader);
                        retvalue = OTRSResponse;
                    }
                    return retvalue;
                }
            }
            return null;
        }
        /// <summary>OTRS response in XML form to OTRS Ticket object, NOT USED YET, KEPT For Reference </summary>
        /// <returns>An NewOTRSticket object</returns>
        /// <param name="_XMLString">The fully formed XML to send to OTRS webservices</param>
        private static NewOTRSTicket OTRSRespXMLtoOTRSRespObject(string _XMLString)
        {
            //DebugWrite("--> OTRSTKTXMLtoTKTObject", ConsoleColor.Magenta);
            if (_XMLString.Contains("<GetCIResponse xmlns"))
            {
                // transform _XmlString to XMLdoc to remove the root object
                XDocument xDoc = XDocument.Parse(_XMLString);
                //XmlDocument xDoc = new XmlDocument();
                //xDoc.LoadXml(_XMLString);
                string SubXML = xDoc.Root.Elements().First().ToString();
                //string SubXML = xDoc.Root.Value;
                _XMLString = SubXML;
            }
            XmlSerializer TopOTRSConfigItem = new XmlSerializer(typeof(NewOTRSTicket));
            var retvalue = new NewOTRSTicket();
            using (TextReader soapreader = new StringReader(_XMLString))
            {
                // soapreader.Namespaces = false;
                var OTRSConfigITem = (NewOTRSTicket)TopOTRSConfigItem.Deserialize(soapreader);
                // get rid of "null" values in XML answer
                //OTRSConfigITem.CIXMLData.OperatingSystem = OTRSConfigITem.CIXMLData.OperatingSystem ?? "Empty";
                //OTRSConfigITem.CIXMLData.Model = OTRSConfigITem.CIXMLData.Model ?? "Empty";
                //OTRSConfigITem.CIXMLData.SerialNumber = OTRSConfigITem.CIXMLData.SerialNumber ?? "Empty";
                //OTRSConfigITem.CIXMLData.Vendor = OTRSConfigITem.CIXMLData.Vendor ?? "Empty";
                retvalue = OTRSConfigITem;
            }
            return retvalue;
        }
    }
}