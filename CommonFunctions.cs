using xxxx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using xxxx.WebReference;
using System.Runtime.InteropServices;
using System.Diagnostics;
//using static xxxx.OTRS_TicketsSearchResponse;
//using PSStudioutilsWS;
namespace xxxx
{
    /// <summary>
    /// OTRSviaSOAP.status
    /// here is the logic of this code so far : 
    /// 1) Call GLPI, gather all CIs in their own array OTRSConfigItemsList (list of GLPI_Partial_CI object) 
    /// 2) Call OTRS, Gather all CIs partial definition in their own array GLPIComputersSummaryList(list of OTRS_ConfigItem_objetcs) 
    /// 3) identify (by name) GLPI CIs that are not in OTRS by comparing the 2 arrays using SE_Find_Unmatched_items
    /// 4) for each of thes GLPI CIs, add them in OTRS. 
    /// Class Common should contain all common functions (not specialised) 
    /// </summary>
    public class Common // Common Variables and Functions 
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]


        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        /// <summary>
        /// Default type for internal tickets (housekeeping or error in application)
        /// </summary>
        public static string OTRS_Default_Type = string.Empty;
        /// <summary>
        /// Default customername to submit tickets 
        /// </summary>
        public static string OTRS_Default_CustomerUser = string.Empty;
        /// <summary>
        /// Default sysadmin to warn in case of problem
        /// </summary>
        public static string OTRS_Default_Sysadmin = string.Empty;
        /// <summary>
        /// Default FIB Service in OTRS (pulled from Configuration file)
        /// </summary>
        public static string GOTRSDefaultFIBService = string.Empty;
        /// <summary>
        /// Default FIB ticket type in OTRS (pulled from Configuration file)
        /// </summary>
        public static string GOTRSDefaultTicketsType = string.Empty;
        /// <summary>
        /// Default FIB queue in OTRS (pulled from Configuration file)
        /// </summary>
        public static string GOTRSDefaultFIBQueue = string.Empty;
        /// <summary>
        /// Default FIB fantom queue in OTRS (pulled from Configuration file)
        /// </summary>
        public static string GOTRSFantomQueue = string.Empty; 
        /// <summary>
        /// Global variable holding the text of FIBs status "being processed" (En cours de realisation)
        /// </summary>
        public static string GFIBStatusOngoing = string.Empty;
        /// <summary>
        /// Global variable holding the text of FIBs status "Waiting contract approval" (En Attente Validation CI)
        /// </summary>
        public static string GFIBStatusWaiting = string.Empty;
        /// <summary>
        /// Datetime at start of code execution for logging purpose
        /// </summary>
        public static DateTime _now = DateTime.Now;
        /// <summary>
        /// Full path of the log file
        /// </summary>
        public static string Glogpath = Environment.GetEnvironmentVariable("TEMP") + "\\"+_now.ToString("yyyyMMdd") + "xxxx.log";

        private static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, 0);
        }

        /// <summary>
        /// Instantiate a list of StringPair to test PS GetDocuments
        /// </summary>
        public static List<StringPair> SingleFiB = new List<StringPair>();
        /// <summary>
        /// instantiate GLPI dropdowns main public variables.
        /// </summary>
        /// <summary>
        /// GLPI LIST of Computers summary objects 
        /// </summary>
        public static List<GLPI_Partial_CI> GLPIComputersSummaryList = new List<GLPI_Partial_CI>();
        /// <summary>
        /// GLPI LIST  of  Models objects
        /// </summary>
        public static List<GLPI_Model> GLPIComputerModels = new List<GLPI_Model>(); // list of models
        /// <summary>
        /// GLPI LIST  of  Manufacturers objects
        /// </summary>
        public static List<GLPI_Manufacturer> GGlobal_GLPIManufacturers = new List<GLPI_Manufacturer>(); // list of manufacturers
        /// <summary>
        /// GLPI List of Models objects
        /// </summary>
        public static List<GLPI_Model> GGlobal_GLPIModels = new List<GLPI_Model>(); // models
        /// <summary>
        /// GLPI List of Operating systems objects
        /// </summary>
        public static List<GLPI_Operating_System> GGlobal_GLPIOperatingystems = new List<GLPI_Operating_System>(); // Operating systems
        /// <summary>
        /// GLPI list of location objects
        /// </summary>
        public static List<GLPI_Location> GGlobal_GLPILocations = new List<GLPI_Location>(); //locations
        /// <summary>
        /// GLPI list of Computer states objects, remember they have to match OTRS ones to be inserted/modified or the change will be rejected by OTRS 
        /// </summary>  
        public static List<GLPI_States> GGlobal_GLPIStates = new List<GLPI_States>(); // states 
        /// <summary>
        /// GLPI list of computer types objects
        /// </summary>
        public static List<GLPI_Computer_Type> GGlobal_GLPIComputerTypes = new List<GLPI_Computer_Type>(); // states 
        /// <summary>
        /// Global object containing the list of open OTRS tickets numbers in RAM (this is not a list, this is an object containing a list) 
        /// </summary>
        public static SearchTicketsResponse GGlobal_OTRSTicketsNumberList = new SearchTicketsResponse();
        /// <summary>
        /// Global Public List of OTRS Tickets Objects in RAM
        /// </summary>
        public static List<GetTicketResponse> GGlobal_OTRS_Tickets = new List<GetTicketResponse>();
        /// <summary>
        /// Gets all properties of the object passed as parameter 
        /// </summary>
        /// <param name="obj">Object to be examined</param>
        /// <returns> a simple space separated string.</returns>
        public static string CommonGetAllProperties(object obj)
        {
            return string.Join(" ", obj.GetType()
                                        .GetProperties()
                                        .Select(prop => prop.GetValue(obj)));
        }
        //public static List<string> GOTicketList = new List<string>(); 
        /// <summary>
        /// All public static variables are declared here. 
        /// </summary>
        public static List<ConfigItem> OTRSConfigItemsList = new List<ConfigItem>();
        /// <summary>
        /// OTRS username
        /// </summary>
        public static String OTRS_username = string.Empty;
        /// <summary>
        ///  OTRS password 
        /// </summary>
        public static String OTRS_password = string.Empty;
        /// <summary>
        /// Debug Flag used all over the code to display or not debug information in the debug area
        /// </summary>
        public static bool Debug = false;
        /// <summary>
        /// if the application is called from outside premises, the URL changes, this flag helps us pick the proper config file.
        /// </summary>
        public static bool isCalled_From_External = false;
        /// <summary>
        /// RPC_and_SOAP_Construct_Data will be used throughout the code to fill up the XML/SOAP requests to be issued to servers. 
        /// </summary>
        public static System.Collections.ArrayList RPC_and_SOAP_Construct_Data = new System.Collections.ArrayList();
        /// <summary>
        /// Globally accessible (public) variable containing OTRS webservices URL
        /// </summary>
        public static String OTRS_Globalurl = string.Empty;
        /// <summary>
        /// RTLogline allows Windows for to display messages from consoleapp thread without having to rely on interthread complexity
        /// </summary>
        public static String RTLogline = string.Empty;
        /// <summary>
        /// Default color for RT messages 
        /// </summary>
        public static ConsoleColor RTColor = ConsoleColor.Black;
        /// <summary>
        /// this list holds the error XMLs returned by OTRS, it is used to create a sysadmin ticket in case of need 
        /// </summary>
        public static List<string> GErrorList = new List<string>();
        /// Startup arguments that will determine application behaviour (batch/interactive/PSonly/etc) 
        public static string Common_startup_args;
        // public static List<String,ConsoleColor> RTLogList =
        /// <summary>
        /// This List will hold the console messages until they are displayed in the GUI (which will empty it) 
        /// </summary>
        public static List<Tuple<string, ConsoleColor>> RTLogList = new List<Tuple<string, ConsoleColor>>() ;
        /// <summary>
        /// Switch debug on or off
        /// </summary>
        static public void ChoiceDebug()
        {
            if (Debug) { Debug = false; }
            else { Debug = true; }
        }
        /// <summary>
        /// Main program initialisation method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            foreach (string arg in args)
            {
                Common_startup_args += " " + arg; 
                InfoWrite("Program initialised with argument " + arg, ConsoleColor.White);
            }
            if (args.Count() < 1)
            {
                InfoWrite("program called with 0 arguments, assuming GUI", ConsoleColor.White);
                Array.Resize(ref args, args.Length + 1);
                args[0] = "/GUI"; 
            }
            // always check if a process with same name is running, if yes : stop 
            string _myname = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            Process[] pname = Process.GetProcessesByName(_myname);
            InfoWrite("number of process with name "+ _myname + " : " + pname.Length, ConsoleColor.White);

            if (pname.Length > 1)
            {
                InfoWrite("Process with same name already running, abort", ConsoleColor.White);
                CommonExitApplication();
            }
            else
            {
                InfoWrite("No other identical process running, proceeding ", ConsoleColor.White);

            }
            if ((args[0].ToUpper() == "/GUI"))
            {
            /*
             * Pre's: Activate and set user and pw in otrs admin interface Core::SOAP
             * Install SOAP::Lite Perl module on the otrs host
             */
            //setting 
            DebugWrite("Initializing window form in separate thread", ConsoleColor.Green);
                // hide command console 
                //var handle = GetConsoleWindow();

                //ShowWindow(handle, 0);
                // Open windows form in a separate thread 
                Task mytask = Task.Run(() =>
            {
                xxxx.statusform form = new xxxx.statusform();
                form.ShowDialog();
            });
            // under .net 4.0 look for : Task.Factory.StartNew
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new statusform());
            CommonOperatorChoice();
            }
                if ((args[0].ToUpper() == "/FULLBATCH"))
                {
                HideConsoleWindow(); // hide the console in batch mode 
                    isCalled_From_External = false; 
                    CommonBatchSequencePStoOTRS();
                InfoWrite("Processing complete, end of program, closing application", ConsoleColor.White);
                }
            if ((args[0].ToUpper() == "/BATCH"))
            {
                isCalled_From_External = false;
                CommonBatchSequencePStoOTRS();
                InfoWrite("Processing complete, end of program, closing application", ConsoleColor.White);
            }

            if ((args[0].ToUpper() == "/INVENT"))
                {
                    isCalled_From_External = false;
                    CommonBatchSequenceGLPItoOTRS();
                }
        }
        /// <summary>
        /// This method can be called any time to check if the XML string is an error reply from webservices
        /// </summary>
        /// <param name="_txml">A string containing the XML to be verified</param>
        /// <returns>True if the XML is an error reply, False otherwise</returns>
        public static Boolean CommonDoesXMLContainErrorString(string _txml)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            if ((_txml.Contains("faultCode")) || (_txml.Contains("faulString")))
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// Get the configuration variables (should be called automatically before anything) 
        /// </summary>
        static public void CommonShortCutChoiceGetConfig()
        {
            CommonGetConfiguration();
        }
        /// <summary>
        /// just call the import CSV code PSCode.PSImportCSVasXML from anywhere
        /// </summary>
        static public void CommonShortCutGetPSXMLfromXcel() {
                PSCode.PSImportCSVasXML("");
            }
        /// <summary>
        /// Spits debug line on console when debug is on
        /// </summary>
        /// <param name="_text">string to display </param>
        /// <param name="_color">any valid .NET ConsoleColor</param>
        public static void DebugWrite(string _text, ConsoleColor _color)
        {
            if (Debug)
            {
                Console.ForegroundColor = _color;
                Console.WriteLine(_text);
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Spits debug lines on console regardless.
        /// </summary>
        /// <param name="_text">Sring to display</param>
        /// <param name="_color">any valid .NET ConsoleColor</param>
        public static void InfoWrite(string _text, ConsoleColor _color)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine(_text);
            Console.ResetColor();
            RTLogline = _text;
            RTColor = _color;
            RTLogList.Add(new Tuple<string, ConsoleColor>(_text, _color));
            // statusform.Self.T
            try
            {
                using (StreamWriter sw = File.AppendText(Glogpath))
                {
                    sw.WriteLine(_now.ToString("yyyyMMdd HH:mm")+ " " + _text);
                }
            }
            catch (Exception e)
            {
                InfoWrite("Cannot write to log file " + e.Message, ConsoleColor.Red);
            }
            //var _sf = new statusform();
            //var tt =_sf.RTlogappend; 
            //_sf.RTlogappend = tt+_text;
            //_sf.RTLOg(_text);
        }
        /// <summary>
        /// Simply displays all GLPICIs in memory 
        /// </summary>
        public static void CommonDisplayAllGLPICIs()
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            String _localv = "list of GLPI objects";
            InfoWrite(_localv, ConsoleColor.Gray);

            foreach (var _gci in GLPIComputersSummaryList)
            {
                _localv = string.Format("GLPI Name: {0} Entity:{1} type:{2} id:{3} serial:{4} otherserial{5}", _gci.name, _gci.entities_name, _gci.itemtype, _gci.id, _gci.serial, _gci.otherserial);
                InfoWrite(_localv, ConsoleColor.Gray);
            }
       }
        /// <summary>
        /// Simply display all OTRS CIs in memory
        /// </summary>
        public static void CommonDisplayAllOTRSCIs()
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            String _localv = "list of OTRS objects";
            InfoWrite(_localv, ConsoleColor.Gray);

            foreach (var _oci in OTRSConfigItemsList)
            {
                _localv = string.Format("OTRS Name: {0} class:{1} type:{2} id:{3} serial:{4} vendor{5}", _oci.Name , _oci.Class, _oci.CIXMLData.Type, _oci.ConfigItemID, _oci.Number, _oci.CIXMLData.Vendor);
                InfoWrite(_localv, ConsoleColor.Gray);
            }
        }
        /// <summary>
        /// Decide what the operator wants to do 
        /// </summary>
        public static void CommonOperatorChoice()
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            while (true)
            {
                String ticketNo = "2328843"; // to delete 
                //allow unsafe header parsing
                // what do we want to do ? :
                InfoWrite("<O>Get OTRS CI, display it (not yet)", ConsoleColor.White);
                InfoWrite("<S>earch OTRS CIs by name and load them in global OTRS CI list", ConsoleColor.White);
                InfoWrite("<L>ist current OTRS CIs in Global OTRS CI list", ConsoleColor.White);
                InfoWrite("<U>get Full GLPI item by glpiID, display it on this console and insert into OTRS as new CI ", ConsoleColor.White);
                InfoWrite("<I>Load ALL GLPI summary inventory in Global GLPI CI List", ConsoleColor.White);
                InfoWrite("<G>List Current GLPI CIs in Global GLPI CI List", ConsoleColor.White);
                InfoWrite("<Y>Compare CI names of GLPI and OTRS Global lists, add all missing names to OTRS  ", ConsoleColor.White);
                InfoWrite("<R>Get GLPI Dropdowns for Full inventory", ConsoleColor.White);
                InfoWrite("<C>Get Environment Configuration (username password URLs)", ConsoleColor.White);
                InfoWrite("<P>Get process studio XML ", ConsoleColor.White);
                InfoWrite("<D>Debug (currently) " + Debug.ToString(), ConsoleColor.White);
                InfoWrite("<T>Get ALL open Tickets ", ConsoleColor.White);
                InfoWrite("<M>List ALL OTRS open Tickets in Memory ", ConsoleColor.White);
                //string Choice = "z"; 
                InfoWrite("<X>Exit", ConsoleColor.White);
                string Choice = (Console.ReadKey().Key.ToString().ToUpper());
                // GUI mode Console.Write(Choice);
                if (Choice == "P")
                {
                    PSCode.PSImportCSVasXML("dummy");
                }
                if (Choice == "X")
                {
                    return;
                }
                if (Choice == "C")
                {
                    //store all config from our XML config file to our global variables. 
                    CommonGetConfiguration();
                }
                if (Choice == "I")
                {
                    GLPIProgram.GLPIGetBasicInventoryToGlobalVariables();
                }
                if (Choice == "D")
                {
                    Common.ChoiceDebug();
                }
                if (Choice == "U")
                {
                    Console.WriteLine("Options CI# for CI, Type for Search");
                    String param = Console.ReadLine();
                    GLPIProgram.GLPIGetDetailedCI(param);
                }
                if (Choice == "Y")
                {
                    OTRSCode.SE_Find_Unmatched_items(GLPIComputersSummaryList, OTRSConfigItemsList);
                }
                if (Choice == "T")
                {
                    OTRSCode.OTRSSearchOpenTicketsbySubject("*");
                }
                if (Choice == "L")
                {
                    foreach (ConfigItem _tmpCI in OTRSConfigItemsList)
                    {
                        //InfoWrite(string.Format(OTRS _tmpCI.Name, ConsoleColor.Gray);
                        InfoWrite(string.Format("OTRS CIs : Model : {0}, CI Name: {1}, Serial: {2}, Deplstate: {3}, Owner: {4} ",
                            _tmpCI.CIXMLData.Model,
                            _tmpCI.Name,
                            _tmpCI.CIXMLData.SerialNumber, 
                            _tmpCI.DeplState,
                            _tmpCI.CIXMLData.Owner),
                            ConsoleColor.Red);

                    }
                    InfoWrite("Count of CIs in OTRSConfigItemsList : " + OTRSConfigItemsList.Count.ToString(), ConsoleColor.Gray);
                }
                if (Choice == "M")
                {
                    OTRSCode.OTRSListTicketsinRAM();
                    }
                if (Choice == "G")
                {
                    foreach (GLPI_Partial_CI _tmpCI in GLPIComputersSummaryList)
                    {
                        InfoWrite(_tmpCI.name + " " + _tmpCI.itemtype_name + " " + _tmpCI.serial + " " + _tmpCI.entities_name, ConsoleColor.Gray);
                    }
                    InfoWrite("Count of CIs in xxxx.GLPIProgram.GLPIComputersSummaryList : " + GLPIComputersSummaryList.Count.ToString(), ConsoleColor.Gray);
                }
                if (Choice == "O")
                {
                    //OTRSserviceCall(url, SERVICE_GETCI, RPC_and_SOAP_Construct_Data);
                    Console.WriteLine("OTRS CI# for CI to be fetched");
                    String param = Console.ReadLine();
                    string _ttemp = OTRSCode.OTRSCInumbertoCIXMLresult(param);
                }
                if (Choice == "R")
                {
                    GLPIProgram.GLPIFetchAllDropdowns();
                }
                if (Choice == "S")
                {
                    OTRSCode.OTRSSearchOTRSCIsByName("");
                }

                //create ticket
                RPC_and_SOAP_Construct_Data.Clear();
                RPC_and_SOAP_Construct_Data.Add(OTRS_username); //username
                RPC_and_SOAP_Construct_Data.Add(OTRS_password); //password
                RPC_and_SOAP_Construct_Data.Add(ticketNo); //ticket number
                RPC_and_SOAP_Construct_Data.Add("RPC Test Ticket"); //ticket title
                RPC_and_SOAP_Construct_Data.Add("Postmaster"); //queue name
                RPC_and_SOAP_Construct_Data.Add("unlock"); //lock status
                RPC_and_SOAP_Construct_Data.Add("2"); //priority id
                RPC_and_SOAP_Construct_Data.Add("New"); //ticket state
                RPC_and_SOAP_Construct_Data.Add("a@b.de"); //customer user
                RPC_and_SOAP_Construct_Data.Add("1"); //owner id (1 is root)
                RPC_and_SOAP_Construct_Data.Add("1"); //user id (1 is root)
                //OTRSserviceCall(url, SERVICE_CREATETICKET, RPC_and_SOAP_Construct_Data);
                //create article for a ticket
                RPC_and_SOAP_Construct_Data.Clear();
                RPC_and_SOAP_Construct_Data.Add(OTRS_username); //username
                RPC_and_SOAP_Construct_Data.Add(OTRS_password); //password
                RPC_and_SOAP_Construct_Data.Add(ticketNo); //ticket number
                RPC_and_SOAP_Construct_Data.Add("email-external"); //article type
                RPC_and_SOAP_Construct_Data.Add("agent"); //sender type
                RPC_and_SOAP_Construct_Data.Add("a@b.de"); //from
                RPC_and_SOAP_Construct_Data.Add("a@b.de"); //to
                RPC_and_SOAP_Construct_Data.Add(""); //cc
                RPC_and_SOAP_Construct_Data.Add(""); //reply to
                RPC_and_SOAP_Construct_Data.Add("Test Ticket using RPC"); //subject
                RPC_and_SOAP_Construct_Data.Add("Herewith I declare this ticket articled!"); //body
                RPC_and_SOAP_Construct_Data.Add(""); //MessageID
                RPC_and_SOAP_Construct_Data.Add("ISO-8859-15"); //Charset
                RPC_and_SOAP_Construct_Data.Add("NewTicket"); //HistoryType
                RPC_and_SOAP_Construct_Data.Add("Created through RPC service"); //HistoryComment
                RPC_and_SOAP_Construct_Data.Add("1"); //UserID
                RPC_and_SOAP_Construct_Data.Add("0"); //NoAgentNotify
                RPC_and_SOAP_Construct_Data.Add("text/plain"); //Type
                RPC_and_SOAP_Construct_Data.Add("0"); //Loop
                //OTRSserviceCall(url, SERVICE_CREATETICKETARTICLE, RPC_and_SOAP_Construct_Data);
            }
        }
        /// <summary>
        /// Get configuration parameters from app?? .config 
        /// </summary>
        public static void CommonGetConfiguration()
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            ExeConfigurationFileMap _myconfig = new ExeConfigurationFileMap();
            // _myconfig.ExeConfigFilename = "App1.config";
            _myconfig.ExeConfigFilename = "App.config";

            if (File.Exists(_myconfig.ExeConfigFilename))
            {
                //try
                //{
                    Configuration config = ConfigurationManager.OpenMappedExeConfiguration(_myconfig, ConfigurationUserLevel.None);

                    //get the relevant section from the config object
                    AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");
                    //get key value pair
                    //var keyValueConfigElement = section.Settings["otrs_url"];
                    //var appSettingsValue = keyValueConfigElement.Value.ToString();
                    //OTRS_Globalurl = appSettingsValue;
                    if (isCalled_From_External)
                    {
                        OTRS_Globalurl = section.Settings["otrs_urlext"].Value.ToString();
                        services.GLPI_Globalurl = section.Settings["glpi_urlext"].Value.ToString();
                        services.PS_Globalurl = section.Settings["PS_urlext"].Value.ToString();
                    }
                    else
                    {
                        OTRS_Globalurl = section.Settings["otrs_url"].Value.ToString();
                        services.GLPI_Globalurl = section.Settings["glpi_url"].Value.ToString();
                        services.PS_Globalurl = section.Settings["PS_url"].Value.ToString();
                    }
                    services.glpiusername = section.Settings["glpi_uname"].Value.ToString();
                    services.glpipassword = section.Settings["glpi_password"].Value.ToString();
                    services.PSusername = section.Settings["PS_uname"].Value.ToString();
                    services.PSpassword = section.Settings["PS_password"].Value.ToString();
                    OTRS_username = section.Settings["otrs_uname"].Value.ToString();
                    OTRS_password = section.Settings["otrs_password"].Value.ToString();
                    OTRS_Default_CustomerUser = section.Settings["OTRS_DefaultCustomerUser"].Value.ToString();
                    OTRS_Default_Sysadmin = section.Settings["OTRS_Default_Sysadmin"].Value.ToString();
                    OTRS_Default_Type = section.Settings["OTRS_Default_Type"].Value.ToString();

                    InfoWrite("OTRS Variables  = " + OTRS_Globalurl + " Username= " + OTRS_username + " Password= " + OTRS_password + " ", ConsoleColor.White);
                    InfoWrite("GLPI Variables  = " + services.GLPI_Globalurl + " Username= " + services.glpiusername + " Password= " + services.glpipassword + " ", ConsoleColor.White);
                    InfoWrite("PS Variables  = " + services.PS_Globalurl + " Username= " + services.PSusername + " Password= " + services.PSpassword + " ", ConsoleColor.White);
                    PSCode.FIBTypes = section.Settings["FIB_Types"].Value.Split(',').Select(p => p.Trim()).ToList();
                    GFIBStatusOngoing = section.Settings["FIBStatusOngoing"].Value.ToString();
                    GFIBStatusWaiting = section.Settings["FIBStatusWaiting"].Value.ToString();
                    GOTRSDefaultFIBService = section.Settings["OTRSDefaultFIBService"].Value.ToString();
                    GOTRSDefaultTicketsType = section.Settings["OTRSDefaultTicketsType"].Value.ToString();
                    GOTRSDefaultFIBQueue = section.Settings["OTRSDefaultFIBQueue"].Value.ToString();
                    GOTRSFantomQueue = section.Settings["OTRSFantomQueue"].Value.ToString();
                    Boolean.TryParse(section.Settings["debug"].Value.ToString(), out Debug);
                //xxxx.WebReference.PStudioUtils = 
                //}
                //catch (Exception e)
                //{
                //    InfoWrite("Something went wrong while parsing the connfiguration file : " + e.Message , ConsoleColor.Red);
                //}
            }
            else
            {
                InfoWrite("Configuration file is missing in object directory.", ConsoleColor.Red);
                InfoWrite("Aborting Execution.", ConsoleColor.Red);

            }
        }
        /// <summary>
        /// This method can be called by any part of the application to exit cleanly.
        /// </summary>
        public static void CommonExitApplication()
        {
            Environment.Exit(0);

        }
        /// <summary>
        /// This method encapsulates all calls to align OTRS and GLPI inventories
        /// </summary>
        public static void CommonBatchSequenceGLPItoOTRS()
        {
            Common.CommonShortCutChoiceGetConfig();
            GLPIProgram.GLPIFetchAllDropdowns();
            GLPIProgram.GLPIGetBasicInventoryToGlobalVariables();
            OTRSCode.OTRSSearchOTRSCIsByName("*");
            OTRSCode.SE_Find_Unmatched_items(GLPIComputersSummaryList, OTRSConfigItemsList);
        }

        /// <summary>
        /// Launch the application in batch mode (non interactive) 
        /// </summary>
        public static void CommonBatchSequencePStoOTRS()
        {
            Common.CommonShortCutChoiceGetConfig();
            OTRSCode.OTRSSearchOpenTicketsbySubject("*");
            PSCode.PSGetAllFIBSinRAM("*");
            // not any more OTRSCode.OTRSListTicketsinRAM();
            // not anymore PSCode.PSDisplayFIBsinRAM();
            PSCode.ComparePSandOTRS();
            //AppendText(this.RTLog, Color.Green, "Compared PS and OTRS");

        }
    }
}
