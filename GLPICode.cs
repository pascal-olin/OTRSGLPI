using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Dynamic;
using System.Xml.Linq;
using System.Collections;
using xxxx;
using System.Reflection;
using static xxxx.Common;

namespace xxxx
{ 
    /// <summary>
    /// Specific class to process XML elements as dynamic objects 
    /// </summary>
    public class XmlToDynamic
    {

        ///       
        /// 
        /// <summary>
        /// /// recursively Parse XML RPC as key, value (like an associative array) using expandobject 
        /// so that
        /// XcarX
        /// XmakeXFordX/makeX
        /// XmodelXExplorerX/modelX
        /// XcolorXSilverX/colorX
        /// X/carX
        /// becomes 
        /// public class Car
        ///{
        ///public string make;
        ///public string model;
        ///public string color;
        ///}
    /// </summary>
    /// <param name="parent">parent tag object that will be filled in  </param>
    /// <param name="node">XElement </param>
    public static void Parse(dynamic parent, XElement node)
        {
            if (node.HasElements)
            {
                if (node.Elements(node.Elements().First().Name.LocalName).Count() > 1)
                {
                    //list
                    var item = new ExpandoObject();
                    var list = new List<dynamic>();
                    foreach (var element in node.Elements())
                    {
                        Parse(list, element);
                    }

                    AddProperty(item, node.Elements().First().Name.LocalName, list);
                    AddProperty(parent, node.Name.ToString(), item);
                }
                else
                {
                    var item = new ExpandoObject();

                    foreach (var attribute in node.Attributes())
                    {
                        AddProperty(item, attribute.Name.ToString(), attribute.Value.Trim());
                    }

                    //element
                    foreach (var element in node.Elements())
                    {
                        Parse(item, element);
                    }

                    AddProperty(parent, node.Name.ToString(), item);
                }
            }
            else
            {
                AddProperty(parent, node.Name.ToString(), node.Value.Trim());
            }
        }

        private static void AddProperty(dynamic parent, string name, object value)
        {
            if (parent is List<dynamic>)
            {
                (parent as List<dynamic>).Add(value);
            }
            else
            {
                (parent as IDictionary<String, object>)[name] = value;
            }
        }
    } // end of public class XmlToDynamic
    /// <summary>
    /// This class contains GLPI dedicated code.
    /// </summary>
    public class GLPIProgram
    {
        /// <summary>
        /// Void method to fetch all dropdowns static public variables.
        /// </summary>
        public static void GLPIFetchAllDropdowns()
        {
            //OTRSserviceCall(url, SERVICE_GETCI, RPC_and_SOAP_Construct_Data);
            InfoWrite("Getting Locations", ConsoleColor.White);
            string _ttemp = GLPIProgram.GLPIGetDropDown("locations");
            InfoWrite("Getting OSes", ConsoleColor.White);
            _ttemp = GLPIProgram.GLPIGetDropDown("operatingsystems");
            InfoWrite("Getting Models", ConsoleColor.White);
            _ttemp = GLPIProgram.GLPIGetDropDown("computermodels");
            InfoWrite("Getting States", ConsoleColor.White);
            _ttemp = GLPIProgram.GLPIGetDropDown("states");
             InfoWrite("Getting Manufacturers", ConsoleColor.White);
            _ttemp = GLPIProgram.GLPIGetDropDown("manufacturer");
            InfoWrite("Getting Computertypes", ConsoleColor.White);
            _ttemp = GLPIProgram.GLPIGetDropDown("computertypes");
        }
    /// <summary>
    /// this function will format the GLPI XML query strings (those in services.cs) with required variables (login/password/etc). 
    /// </summary>
    /// 
    /// <param name="service">the service to be called </param> 
    /// <param name="data"> parameters to be added to the service call (username/password/details/etc</param>
    /// <returns>returns formatted string, ready to be passed to function GLPIissueRPCtoServer for processing</returns>
    private static string GLPIFeedServiceVariabletoXml(int service, ArrayList data)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            switch (service)
            {
                case services.SERVICE_GETGLPIPartialCI:
                    {
                        String soapenv = String.Format(services.XML_GETGLPIPartialCI,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString());
                        return soapenv;
                    }
                case services.SERVICE_GETGLPISessionID:
                    {
                        String soapenv = String.Format(services.XML_GETGLPISessionID,
                            data[0].ToString()
                            , data[1].ToString());
                            // , RPC_and_SOAP_Construct_Data[2].ToString());
                        return soapenv;
                    }
                case services.SERVICE_GETGLPIDropDown:
                    {
                        String soapenv = String.Format(services.XML_GETGLPIDropDown,
                            data[0].ToString()
                            , data[1].ToString());
                        return soapenv;
                    }
                case services.SERVICE_GETGLPIPdetailedCI:
                    {
                        String soapenv = String.Format(services.XML_GETGLPIPdetailedCI,
                            data[0].ToString()
                            , data[1].ToString()
                            , data[2].ToString());
                        return soapenv;
                    }

                default:
                    {
                        throw new Exception("InvalidServiceException: The requested GLPI service does not exist.");
                    }

            }
        }
        /// <summary>
                    /// save the obtained GLPI list of CIs as csv
                    /// </summary>
                    /// <param name="_Mylist">list to save</param>
                    /// <param name="_mypath">CSV path</param>
                    /// <returns>bool success or not</returns>
        public static bool Store_list_as_CSV(List<GLPI_Partial_CI> _Mylist, string _mypath)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            //public void WriteCSV<T>(IEnumerable<T> items, string path)
            //{
            //Type itemType = typeof(T);
            //var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            //                    .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(_mypath))
            {
                //writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in _Mylist)
                {
                    // writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));

                    writer.WriteLine(string.Join(", ", item.id, item.itemtype, item.itemtype_name, item.name, item.entities_id, item.entities_name, item.serial, item.otherserial));

                }

            }
            return true;
        }
        // transmit and receive XML via RPC 
        // HttpWebRequest request;
        /// <summary>
        /// GLPIissueRPCtoServer will simply run the selected XML query and return the resulted XML as a string
        /// </summary>
        /// <param name="_XMLQuery">GLPI specifi RPC XML query including the service to be called and the parameters.</param>
        /// <returns>String containing XML RPC_and_SOAP_Construct_Data response</returns>
        public static string GLPIissueRPCtoServer(string _XMLQuery)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            // always display the XmlQuery for debug purpose
            DebugWrite(_XMLQuery,ConsoleColor.Red);
            byte[] requestData = Encoding.ASCII.GetBytes(_XMLQuery);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(services.GLPI_Globalurl);
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestData.Length;
            // idiotproof try/catch loop : display exception for debug 
            try
            {
                using (Stream requestStream = request.GetRequestStream())
                    requestStream.Write(requestData, 0, requestData.Length);
            }
            catch (Exception exept)
            {
                InfoWrite("Catched exception : " + exept.Message,ConsoleColor.Red);
            }
            string result = null;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                            result = reader.ReadToEnd();
                    }
                } // end of using ..
            } // end of try loop.
            catch (Exception exept)
            {
                InfoWrite("Catched exception : " + exept.Message,ConsoleColor.Yellow);
            }
            // just display GLPI response. 
            DebugWrite("GLPI response to query : " + result,ConsoleColor.Red);
            if (!(result == null))
            {
                // clean the returned XML 
                result = result.Replace("\n", "");
                result = result.Replace("\r", "");
            }
            // pause ? 
            // Console.ReadKey();
            return result;
        } // end of process_rpc 
       /// <summary>
        /// parse XML from XMLString to Dictionary (simple requests such as logon or test ) 
        /// </summary>
        /// <param name="_XMLString">process the login requests (works for connectivity test as well) </param>
        /// <returns>Dictionally of string (e.g. associative arrays containing the structure of the input XML</returns>
        public static Dictionary<string, string> GLPIProcessloginXML(string _XMLString)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            XDocument xDoc = null;
            Dictionary<string, string> _myDictionary = new Dictionary<string, string>();
            if (!(_XMLString == null))
            {
                try
                {
                    xDoc = XDocument.Parse(_XMLString);
                }
                catch (Exception exept)
                {
                    InfoWrite("Catched exception : " + exept.Message,ConsoleColor.Yellow);
                }
                // we should only consider nodes under the <struct> node .
                foreach (XElement element in xDoc.Descendants("struct"))
                {
                    IEnumerable<XElement> de =
                    from el in element.Descendants()
                    select el;
                    foreach (XElement el in de)
                        DebugWrite(el.Name + "  " + el.Value,ConsoleColor.Blue);
                        DebugWrite("looping in element :" + element.Name.ToString(),ConsoleColor.Blue);
                        DebugWrite("found in " + element.Name.ToString(),ConsoleColor.Blue);
                        bool hassubname = element.Descendants("name").Any();
                        if (hassubname)
                        {
                            DebugWrite("--> name found in element",ConsoleColor.Blue);
                            bool hassubname2 = element.Elements("name").Any();
                            if (hassubname2)
                            {
                                XElement subname = element.Element("name");
                                DebugWrite("found name " + subname.Value,ConsoleColor.Blue);
                            }

                        }

                    string tagname = "";
                    string tagvalue = "";
                    string prevtagname = "";
                    string prevtagvalue = "";
                    InfoWrite("- listing subElements -",ConsoleColor.Blue);
                    _myDictionary.Add("key", "value");
                    foreach (XElement subelement in element.Elements("member"))
                    {
                        tagname = subelement.Element("name").Value;
                        tagvalue = subelement.Element("value").Value;
                        DebugWrite("ctag " + tagname + " value " + tagvalue + " ptag " + prevtagname + " pvalue " + prevtagvalue,ConsoleColor.Blue);
                        if (!(prevtagname == "name" && tagname == "value"))
                        {
                            _myDictionary.Add(tagname, tagvalue);
                        }
                        prevtagname = tagname;
                        prevtagvalue = tagvalue;
                    }
                    DebugWrite("---end---",ConsoleColor.Blue);
                    foreach (KeyValuePair<string, string> KV in _myDictionary)
                    {
                        DebugWrite(KV.Key + " " + KV.Value,ConsoleColor.Blue);
                    }
                }
            }
            DebugWrite("End of Function",ConsoleColor.Blue);
            return _myDictionary;
        } // end of function processingXML 
        /// <summary>
        /// Clever code to Deserialize any XML-RPC type answer containing a list of object 
        /// </summary>
        /// <typeparam name="T">List T to be returned </typeparam>
        /// <param name="_XMLString">String to be desrialized </param>
        /// <param name="typeofobject">a string containing the exact type of objects to deserialize</param>
        /// <returns>Returns a list T of objects passed as reference (by name) </returns>
        public static List<T> runtimeXMLtoListofObjects<T>(string _XMLString, string typeofobject)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            // local variables : 
            // create a reference object by string using the information we have : the object type 
            Type thistype = Type.GetType(typeofobject);
            // var aa = Activator.CreateInstance.typeofobject();
            object obj = Activator.CreateInstance(thistype);
            // we cannot access obj properties or method b4 run time ! this will not work : obj."name" =  );
            //obj.name = "1";
            dynamic expando = new ExpandoObject();
            // dynamically create a list of fields that we want to parse from XML (object fields name must match XML field names. ) 
            List<string> _FieldNames = new List<string>();
            List<string> _tt = new List<string>();
            List<PropertyInfo> propsofobject = new List<PropertyInfo>() ;
            foreach (var prop in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                DebugWrite(prop.Name, ConsoleColor.White);
                DebugWrite(prop.PropertyType.Name, ConsoleColor.White);
                if (prop.PropertyType.Name.ToString().ToUpper().Contains("STRING"))
                {
                    _FieldNames.Add(prop.Name.ToString());
                    _tt.Add(prop.Name.ToString());
                    propsofobject.Add(prop);
                    prop.SetValue(obj, "dummy", null);
                    // obj.prop.Name.ToString() = "placeholder";
                }

                //var _tt = _FieldNames;
            } // end foreach var prop

            XDocument xDoc = null;
            int looper = 0; // number of objects 
            int ngroups = 0; // number of groups of objects 
            if (true)
            {
                var listType = typeof(List<>).MakeGenericType(thistype);
                IList list = (IList)Activator.CreateInstance(listType);
                IList lst = (IList)Activator.CreateInstance((typeof(List<>).MakeGenericType(thistype)));
                if (!(_XMLString == null))
                {
                    try
                    {
                        xDoc = XDocument.Parse(_XMLString);
                    }
                    catch (Exception exept)
                    {
                        Console.WriteLine("Catched exception : " + exept.Message);
                    }
                    // loop below is really parsing the returned XML, we should only consider nodes under the <struct> node, the rest is irrelevant. 
                    // first check if this XML is not an error reply
                    if (xDoc.Descendants("fault").Any())
                    {
                        InfoWrite("Error REturned by GLPI for " + typeofobject.ToString() + ", stopping", ConsoleColor.Red);
                        return null ; 
                    }
                    foreach (XElement element in xDoc.Descendants("struct"))
                    {
                        ngroups += 1;
                        IEnumerable<XElement> de =
                        from el in element.Descendants()
                        select el;
                        foreach (XElement el in de)
                            ;
                        // check if a "name" element is present in descendants
                        bool hassubname = element.Descendants("name").Any();
                        if (hassubname)
                        {
                            //Console.WriteLine("--> name found in element");
                            bool hassubname2 = element.Elements("name").Any();
                            if (hassubname2)
                            {
                                XElement subname = element.Element("name");
                                //     Console.WriteLine("found name " + subname.Value);
                            }
                        }
                        string tagname = "";
                        string tagvalue = "";
                        string prevtagname = "";
                        string prevtagvalue = "";
                        object obji = Activator.CreateInstance(thistype);

                        // Console.WriteLine("- listing subElements -");
                        // now check the descendants of the memebers 
                        foreach (XElement subelement in element.Elements("member"))
                        {
                            // process only the "name / value" pairs of each element 
                            tagname = subelement.Element("name").Value;
                            tagvalue = subelement.Element("value").Value;

                            // store value to the proper column 
                            // if name, we add an object to the list 
                            //foreach (string _uu in _tt) // that meant for each object element
                            foreach (PropertyInfo _uu in propsofobject)
                            {

                                // following is a bit tricky, but seems to work. 
                                // note that _uu must NOT be null or else this will crash the code 
                                //if (tagname == _uu)
                                if (tagname == _uu.Name.ToString())
                                {
                                    //InfoWrite("adding to list : " + _uu.Name.ToString() + " for tagname " + tagname + " and tag value : " + tagvalue, ConsoleColor.Red);
                                    // create new object in list for first value (which is always the ID for dropdowns)
                                    // Console.Write("ttt");
                                    if (tagname == "id")
                                    {
                                        looper += 1;
                                        //reset expando 
                                        //expando = null;
                                        //expando["id"] = tagvalue;
                                        _uu.SetValue(obji, tagvalue, null);
                                    }
                                    else
                                    {
                                        _uu.SetValue(obji, tagvalue, null);
                                    }
                                }
                            }
                            // this is where we are meant to add the object to the list 
                            prevtagname = tagname;
                            prevtagvalue = tagvalue;
                        }
                        list.Add(obji);
                        DebugWrite("List size for" + typeofobject + " is : " + list.Count.ToString(), ConsoleColor.White);

                    } // end forach Xelement in Xdoc.descendants <struct> 
                      // debug, display the list of objects obtained. 
                    string _output = "Object : ";
                    foreach (object dd3 in list)
                            {
                        _output = "Object : ";
                        foreach (PropertyInfo _uu in propsofobject)
                        {
                            //string _oo = dd3.
                            string _oo = _uu.GetValue(dd3, null).ToString();
                            _output += " " + _oo + " --- ";
                        }
                            DebugWrite("object name " + _output, ConsoleColor.Cyan);
                        
                    }
                    InfoWrite("List size for --> " + typeofobject + " is : " + list.Count.ToString(),ConsoleColor.White);
                    // Console.Write(list.ToString());
                    }
                    InfoWrite("End of Function, processed " + looper.ToString() + " Records in " + ngroups + " Groups", ConsoleColor.Cyan);
                //debug Console.ReadKey();
                return list as List<T>; ;
                //return list as IList;
                }
                else { return null; } // to be checked , unreachable code 

            } // end of function runtimeXMLtoListofObjects.
        /// <summary>
        /// parse XML from XMLString to Dictionary ( only for computers/printers/ list
        /// This function is to be removed and replaced by runtimeXMLtoListofObjects
        /// </summary>
        /// <param name="_XMLString">string to be deserialised</param>
        /// <returns>LIST of T : GLPIpartialCI objects</returns>
        public static List<GLPI_Partial_CI> tGLPI_XMLAllCItoGLPIListofObjects(string _XMLString)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            List<GLPI_Partial_CI> _TTT = runtimeXMLtoListofObjects<GLPI_Partial_CI>(_XMLString, "GLPI_Partial_CI");
            return _TTT;
        }
        //        public static List<GLPI_Partial_CI> GLPI_XMLAllCItoGLPIListofObjects(string _XMLString)
//        {
//            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

//            // local variables : 
//            XDocument xDoc = null;
//            int looper = 0;
//            int ngroups = 0;
//            // var d = new Dictionary<int, List<object>>();
//            var ll2 = new List<GLPI_Partial_CI>();
//            GLPI_Partial_CI _tmp = new GLPI_Partial_CI(1, "Name", "ID", "Entityname", "EntityID", "ItemType", "Serial", "OtherSerial", "ItemTypeName");
//            Type _tmpType = _tmp.GetType();
//            PropertyInfo[] properties = _tmpType.GetProperties();
//            // we define a temp variable _tmp of the same type as our objects contained in the list, 
//            // this will allow us to determine each property name and type for this object, 
//            // we will then be able to create the list of <string> _tt that will contain the property name for strings only 
//            // so we can afterwards allocate the value of object.property by looping in _tt and pull the <value><string> from the XML for that <value><name>  
//            // this of course means that the XML-RPC field <name> natches EXACTLY our object properties for all <strings>
//            List<string> _tt = new List<string>();

//            foreach (PropertyInfo property  in properties)
//            {

//                DebugWrite(" Type " + property.PropertyType.ToString() +  "Name: " + property.Name + ", Value: " + property.GetValue(_tmp, null),ConsoleColor.Red);
//                if (property.PropertyType.ToString().ToUpper().Contains("STRING")) // we keep only the strings (GLPI always returns strings anyway) 
//                {
//                    _tt.Add(property.Name);
//                }             
//            }
//        //}
//            // add top row
//            ll2.Add(new GLPI_Partial_CI(1, "Name", "ID", "Entityname", "EntityID", "ItemType", "Serial", "OtherSerial", "ItemTypeName"));
//            if (!(_XMLString == null))
//            {
//                try
//                {
//                    xDoc = XDocument.Parse(_XMLString);
//                }
//                catch (Exception exept)
//                {
//                    Console.WriteLine("Catched exception : " + exept.Message);
//                }
//                // we should only consider nodes under the <struct> node .
//                foreach (XElement element in xDoc.Descendants("struct"))
//                {
//                    ngroups += 1;
//                    IEnumerable<XElement> de =
//                    from el in element.Descendants()
//                    select el;
//                    foreach (XElement el in de)
//                        //Console.WriteLine(el.Name + "  " + el.Value);
//                        //Console.WriteLine("looping in element :" + element.Name.ToString());
//                        // Console.WriteLine("found in " + element.Name.ToString())
//                        ;
//                    // check if a "name" element is present in descendants
//                    bool hassubname = element.Descendants("name").Any();
//                    if (hassubname)
//                    {
//                        //Console.WriteLine("--> name found in element");
//                        bool hassubname2 = element.Elements("name").Any();
//                        if (hassubname2)
//                        {
//                            XElement subname = element.Element("name");
//                            //     Console.WriteLine("found name " + subname.Value);
//                        }
//                    }
//                    string tagname = "";
//                    string tagvalue = "";
//                    string prevtagname = "";
//                    string prevtagvalue = "";
//                    // Console.WriteLine("- listing subElements -");
//                    // now check the descendants of the memebers 
//                    foreach (XElement subelement in element.Elements("member"))
//                    {
//                        // process only the "name / value" pairs of each element 
//                        tagname = subelement.Element("name").Value;
//                        tagvalue = subelement.Element("value").Value;
//                        // Console.WriteLine("ctag " + tagname + " value " + tagvalue + " ptag " + prevtagname + " pvalue " + prevtagvalue);
//                        // store value to the proper column 
//                        // if name, we add an object to the list 
//                        foreach (string _uu in _tt)
//                        {
//                            InfoWrite("Looping in _tt to extract _uu values" +_uu, ConsoleColor.DarkGreen);
//                            // following is a bit tricky, but seems to work. 
//                            // note that _uu must NOT be null or else this will crash the code 
//                            if (tagname == _uu)
//                            {
//                                // create new object in list for first value (which has to be "name") 
//                                if (tagname == "name") { looper += 1; ll2.Add(new GLPI_Partial_CI(0, " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ")); ll2[looper].name = tagvalue; }
//                                else
//                                {

//                                    ll2[looper].GetType().GetProperty(_uu).SetValue(ll2[looper], tagvalue);
//                                    InfoWrite("setting value of  " + ll2[looper].GetType().GetProperty(_uu).ToString() + " index  " + looper + " to " + tagvalue + " for object name " + _uu, ConsoleColor.Green);
//                                }
//                            }
//                        }
//                        /*
//                        if (tagname == "name") { looper += 1; ll2.Add(new GLPI_Partial_CI(0, " - ", " - ", " - ", " - ", " - ", " - ", " - ", " - ")); ll2[looper].name = tagvalue; }
//                        if (tagname == "id") { ll2[looper].id = tagvalue; Console.WriteLine("processing id : " + tagvalue); }
//                        if (tagname == "entities_name") { ll2[looper].entities_name = tagvalue; }
//                        if (tagname == "entities_id") { ll2[looper].entities_id = tagvalue; }
//                        if (tagname == "itemtype") { ll2[looper].itemtype = tagvalue; }
//                        if (tagname == "serial") { ll2[looper].serial = tagvalue; }
//                        if (tagname == "otherserial") { ll2[looper].otherserial = tagvalue; }
//                        if (tagname == "itemtype_name") { ll2[looper].itemtype_name = tagvalue; }
//                        */
//                        /* 
//iI- listing subElements -
//Name: Iindex, Value: 1
//Name: name, Value: Name
//Name: id, Value: ID
//Name: entities_name, Value: Entityname
//Name: entities_id, Value: EntityID
//Name: itemtype, Value: ItemType
//Name: serial, Value: Serial
//Name: otherserial, Value: OtherSerial
//Name: itemtype_name, Value: ItemTypeName
//processing id : 1440
//processing id : 760
//GLPI list size : 3store: in shortlist.CSV ?
//                         * 
//                         */
//                        prevtagname = tagname;
//                        prevtagvalue = tagvalue;
//                    }
                  
//                    foreach (GLPI_Partial_CI dd3 in ll2)
//                    {
//                        DebugWrite("name " + dd3.name + " id " + dd3.id + " entity " + dd3.entities_name + " itemtype " + dd3.itemtype + " Serial " + dd3.serial,ConsoleColor.Blue);
//                    }
//                } // end forach Xelement in Xdoc.descendants <struct> 
//            }
//            DebugWrite ("End of Function, processed " + looper.ToString() + " Records in " + ngroups + " Groups",ConsoleColor.Cyan);
//            //debug Console.ReadKey();
//            return ll2;
            
//        } // end of function processingXMLComputerlist 
        /// <summary>
        /// Tranforms a full object XML (As string) returned by GLPI into a configitem object 
        /// </summary>
        /// <param name="_XMLString">The string XML to be converted</param>
        /// <returns>ConfigItem Object (GLPI structure) </returns>
        public static ConfigItem GLPIXMLtoCIObject (string _XMLString)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            // transform _XmlString to Xdocumnt to deserialize 
            XDocument _xDoc = XDocument.Parse(_XMLString);
            ConfigItem _GLPICIObjectVar = new ConfigItem();
            // we have to instantiate the subobject (otherwise we get an error : Object reference not set to an instance of an object.) 
            _GLPICIObjectVar.CIXMLData = new ConfigItemCIXMLData();
            //InfoWrite(_xDoc.Descendants("member").Where(y => (string)y.Element("name") == "name").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault(), ConsoleColor.Cyan);
            //InfoWrite(_xDoc.Descendants("member").Where(y => (string)y.Element("name") == "id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault(), ConsoleColor.Cyan);
            //InfoWrite(_xDoc.Descendants("member").Where(y => (string)y.Element("name") == "locations_id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault(), ConsoleColor.Cyan);
            //InfoWrite(_xDoc.Descendants("member").Where(y => (string)y.Element("name") == "computertypes_id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault(), ConsoleColor.Cyan);
            //InfoWrite(_xDoc.Descendants("member").Where(y => (string)y.Element("name") == "serial").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault(), ConsoleColor.Cyan);
            _GLPICIObjectVar.Name = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "name").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault();
            //_GLPICIObjectVar.CIXMLData.SerialNumber = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "serial").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "Empty" ;
            //etc etc etc 
            _GLPICIObjectVar.CIXMLData.SerialNumber = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "serial").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            _GLPICIObjectVar.CIXMLData.Owner = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "contact").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            _GLPICIObjectVar.CIXMLData.Model = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "computermodels_id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            _GLPICIObjectVar.CIXMLData.OperatingSystem = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "operatingsystems_id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            _GLPICIObjectVar.CIXMLData.Vendor = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "manufacturers_id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            _GLPICIObjectVar.CIXMLData.InstallDate = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "date_mod").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            _GLPICIObjectVar.CurDeplState = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "states_id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            _GLPICIObjectVar.CIXMLData.Type = _xDoc.Descendants("member").Where(y => (string)y.Element("name") == "computertypes_id").Select(z => (string)z.Descendants("string").FirstOrDefault()).FirstOrDefault() ?? "0";
            return _GLPICIObjectVar;
        } // end function glpiXMLtoCIObject
        /// <summary>
        /// returns a full ConfigItem object from the GLPI number given in argument. this object structure makes it compatible with OTRS SOAP addconfigitem.
        /// 
        /// </summary>
        /// <param name="_GLPICINumber">string containing the GLPI CI number to be returned</param>
        /// <returns> ConfigItem object </returns>
        public static ConfigItem GLPIGetDetailedCI(string _GLPICINumber)
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            StringBuilder data = new StringBuilder();
            ArrayList dataGLPI = new ArrayList(); // this will transmit the variables to the GLPI query contained in the service class
            // login to get session id
            string Globsessionid = GLPIGetSession(services.glpiusername, services.glpipassword);
            // xml structure to get GLPI computers list, position of the arguments in the query is critical. 
            // fill up the RPC_and_SOAP_Construct_Data variable for this call. 
            //ArrayList dataGLPI = new ArrayList(); // this will transmit the variables to the GLPI query contained in the service class
            dataGLPI.Clear();
            dataGLPI.Add(services.glpiusername); //username
                                                 //            dataGLPI.Add(services.glpipassword); //password
            dataGLPI.Add(_GLPICINumber); //CI number in GLPI
            dataGLPI.Add(Globsessionid); //Sessionid
            string _XMLQueryGLPIDetailedCI = GLPIFeedServiceVariabletoXml(services.SERVICE_GETGLPIPdetailedCI, dataGLPI);
            // issue request to GLPI 
            // InfoWrite(XMLQueryGLPIDetailedCI + ""  , ConsoleColor.Yellow); 
            InfoWrite("Submitted XML is :", ConsoleColor.Green);
            InfoWrite(_XMLQueryGLPIDetailedCI, ConsoleColor.Green);

            string _tCIXML = GLPIissueRPCtoServer(_XMLQueryGLPIDetailedCI);
            // test if the returned string is not an error string 
            if (Common.CommonDoesXMLContainErrorString(_tCIXML) == false)
            {

                //dataGLPI.Add(Globsessionid); //ticket number
                // now create a GLPIObject using the OTRS object model, and fill is up with the GLPI RPC_and_SOAP_Construct_Data. 
                // after that it will be easy to create a list of GLPI object and compare them with the list of OTRS object (already done but may be not sufficient) 
                // and / or update / create the OTRS object accordingly ! 
                ConfigItem _newOTRSCIobjectFromGLPICI = new ConfigItem();
                // instantiate the subobject
                _newOTRSCIobjectFromGLPICI.CIXMLData = new ConfigItemCIXMLData();
                _newOTRSCIobjectFromGLPICI = GLPIXMLtoCIObject(_tCIXML);
                InfoWrite("full XML returned from GLPI is : ", ConsoleColor.Yellow);
                InfoWrite(_tCIXML, ConsoleColor.Yellow);
                //string _vv = glpiCIobject.CIXMLData.OperatingSystem?.ToString() ?? "null value" ;
                //InfoWrite("Operating system " + _vv , ConsoleColor.Yellow);
                InfoWrite("Operating system " + _newOTRSCIobjectFromGLPICI.CIXMLData.OperatingSystem?.ToString(), ConsoleColor.Yellow);
                InfoWrite("SerialNumber " + _newOTRSCIobjectFromGLPICI.CIXMLData.SerialNumber.ToString() ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("Model " + _newOTRSCIobjectFromGLPICI.CIXMLData.Model.ToString() ?? "empty ", ConsoleColor.Yellow);
                // set model value from dropdown back into our object (we can to this as it's a string) 
                string _currDropdown = " model ";
                try
                {
                int _ivv = Int32.Parse(_newOTRSCIobjectFromGLPICI.CIXMLData.Model.ToString());
                _ivv -= 1; 
                //string _vv = GGlobal_GLPIModels[Int32.Parse(glpiCIobject.CIXMLData.Model.ToString())].name;
                string _vv = GGlobal_GLPIModels[_ivv].name;
                _currDropdown = " model "; 
                _newOTRSCIobjectFromGLPICI.CIXMLData.Model = _vv;
                InfoWrite("Model from list :  " + _vv ?? "empty ", ConsoleColor.Yellow);
                    //_ivv = Int32.Parse(glpiCIobject.CIXMLData.Model.ToString());
                    // set vendor value from dropdown back into our object (we can to this as it's a string)
                    _currDropdown = " Vendor ";

                    _vv = GGlobal_GLPIManufacturers[Int32.Parse(_newOTRSCIobjectFromGLPICI.CIXMLData.Vendor.ToString())-1].name;
                _newOTRSCIobjectFromGLPICI.CIXMLData.Vendor = _vv;
                InfoWrite("Vendor from list :  " + _vv ?? "empty ", ConsoleColor.Yellow);
                    _currDropdown = " OS ";

                    // set vendor value from dropdown back into our object (we can to this as it's a string) 
                _ivv = Int32.Parse(_newOTRSCIobjectFromGLPICI.CIXMLData.OperatingSystem.ToString());
                    if (_ivv > 0)
                    {
                        _vv = GGlobal_GLPIOperatingystems[Int32.Parse(_newOTRSCIobjectFromGLPICI.CIXMLData.OperatingSystem.ToString()) - 1].name;
                        _newOTRSCIobjectFromGLPICI.CIXMLData.OperatingSystem = _vv;
                        InfoWrite("OS from list :  " + _vv ?? "empty ", ConsoleColor.Yellow);
                    }
                    _currDropdown = " type ";

                    // set type value from dropdown back into our object (we can to this as it's a string) 
                    _vv = GGlobal_GLPIComputerTypes[Int32.Parse(_newOTRSCIobjectFromGLPICI.CIXMLData.Type.ToString())-1].name;
                _newOTRSCIobjectFromGLPICI.CIXMLData.Type = _vv;
                InfoWrite("type from list :  " + _vv ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("datafieldSerial " + _newOTRSCIobjectFromGLPICI.cIXMLDataField.SerialNumber.ToString() ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("Owner " + _newOTRSCIobjectFromGLPICI.cIXMLDataField.Owner.ToString() ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("Vendor " + _newOTRSCIobjectFromGLPICI.cIXMLDataField.Vendor.ToString() ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("InstallDate " + _newOTRSCIobjectFromGLPICI.cIXMLDataField.InstallDate.ToString() ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("CurDeplState " + _newOTRSCIobjectFromGLPICI.CurDeplState.ToString() ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("type " + _newOTRSCIobjectFromGLPICI.cIXMLDataField.Type.ToString() ?? "empty ", ConsoleColor.Yellow);
                InfoWrite("About to submit this record to OTRS ", ConsoleColor.Red);
                }
                catch (Exception except)
                {
                    Console.WriteLine("Catched exception processing : " + _currDropdown + except.Message);
                }
                InfoWrite("Adding this CI to OTRS using the OTRSAddCItoOTRSCMDB method", ConsoleColor.Cyan);
                string _re = OTRSCode.OTRSAddCItoOTRSCMDB(_newOTRSCIobjectFromGLPICI);
                return _newOTRSCIobjectFromGLPICI;
            }
            else { return null; }
        }     
        /// <summary>
        /// Simply gets a GLPI session id for future use
        /// </summary>
        /// <param name="_GLPIUsername">string : username </param>
        /// <param name="_GLPIPassword">String password </param>
        /// <returns>GLPI session number as a string </returns>
        public static string GLPIGetSession(string _GLPIUsername, string _GLPIPassword )
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);

            StringBuilder data = new StringBuilder();
            ArrayList dataGLPI = new ArrayList(); // this will transmit the variables to the GLPI query contained in the service class
            dataGLPI.Clear();
            dataGLPI.Add(_GLPIUsername); //username
            dataGLPI.Add(_GLPIPassword); //password
            string _XMLLogon = GLPIFeedServiceVariabletoXml(services.SERVICE_GETGLPISessionID, dataGLPI);
            // issue login request from GLPI (we need the session id) 
            InfoWrite("submitted logon XML string : " + _XMLLogon, ConsoleColor.Gray);
            string _stringXMLAnswer = GLPIissueRPCtoServer(_XMLLogon) ?? null; // avoid null object exception in case of network issue. 
            InfoWrite("received logon XML answer string : " + _stringXMLAnswer, ConsoleColor.Gray);

            if (_stringXMLAnswer == null )
            {
                return null; 
            }
            string path = string.Empty;
            string _xmlInputData = string.Empty;
            string _xmlOutputData = string.Empty;
            //string result = GLPIissueRPCtoServer(loginXml2);
            _xmlInputData = _stringXMLAnswer;
            
            Dictionary<string, string> loginResult = new Dictionary<string, string>();
            if (!(_stringXMLAnswer.Contains("faultString"))) { 
            loginResult = GLPIProcessloginXML(_stringXMLAnswer);
            // Global session id will be reused later
                string _Globsessionid = loginResult["session"] ?? null;
                if (!(_Globsessionid == null))
                {
                    return loginResult["session"];
                }
                else { return null; }

            }
            else { return null; }
        }
        /// <summary>
        /// Gets a GLPI dropdown as an XML String
        /// </summary>
        /// <param name="_DropDown">Exact name of the dropdown</param>
        /// <returns>XML string containing the returned list of objects (to be deserialized later</returns>
        public static string GLPIGetDropDown(string _DropDown)
        {// computer_type
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            StringBuilder data = new StringBuilder();
            ArrayList dataGLPI = new ArrayList(); // this will transmit the variables to the GLPI query contained in the service class
            string Globsessionid = "";
            Globsessionid = GLPIGetSession(services.glpiusername, services.glpipassword) ?? null ;
            if (Globsessionid == null )
            {
                return null; 
            }
            // xml structure to get GLPI computers list, position of the arguments in the query is critical. 
            // fill up the RPC_and_SOAP_Construct_Data variable for this call. 
            //ArrayList dataGLPI = new ArrayList(); // this will transmit the variables to the GLPI query contained in the service class
            dataGLPI.Clear();
            //dataGLPI.Add(services.glpiusername); //username
                                                 //            dataGLPI.Add(services.glpipassword); //password
            dataGLPI.Add(_DropDown); //ticket number
            dataGLPI.Add(Globsessionid); //ticket number
            string XMLQueryGLPIDropDown = GLPIFeedServiceVariabletoXml(services.SERVICE_GETGLPIDropDown, dataGLPI);
            // issue request to GLPI 
            // InfoWrite(XMLQueryGLPIDetailedCI + ""  , ConsoleColor.Yellow);
            DebugWrite("Submitted XML is :"+XMLQueryGLPIDropDown, ConsoleColor.Green);

            string _tCIXML = GLPIissueRPCtoServer(XMLQueryGLPIDropDown);
            //dataGLPI.Add(Globsessionid); //ticket number
            // now create a GLPIObject using th OTRS object model, and fill is up with the GLPI RPC_and_SOAP_Construct_Data. 
            // after that it will be easy to create a list of GLPI object and compare them with the list of OTRS object (already done but may be not sufficient) 
            // and / or update / create the OTRS object accordingly ! 
            // for the moment ConfigItem glpiCIobject = glpiXMLtoCIObject(_tCIXML);
            DebugWrite("full XML returned is : ", ConsoleColor.Gray);
            DebugWrite(_tCIXML, ConsoleColor.Yellow);
            var __t1 = new GLPI_Model("1","2","3");
            if (_DropDown == "locations")
            {
                List<GLPI_Location> Global_GLPILocations = runtimeXMLtoListofObjects<GLPI_Location>(_tCIXML, "xxxx.GLPI_Location");
                foreach (GLPI_Location gloc in Global_GLPILocations)
                {
                    DebugWrite("Location found and globalised : " + gloc.name + gloc.id, ConsoleColor.Green);
                }
                GGlobal_GLPILocations = Global_GLPILocations;
                return (_tCIXML);
            }
            else if (_DropDown == "operatingsystems")
            {
                List<GLPI_Operating_System> Global_GLPIOperatingystems = runtimeXMLtoListofObjects<GLPI_Operating_System>(_tCIXML, "xxxx.GLPI_Operating_System");
                foreach (GLPI_Operating_System gos in Global_GLPIOperatingystems)
                {
                    DebugWrite("OS found and globalised : " + gos.name + gos.id, ConsoleColor.Green);
                }
                GGlobal_GLPIOperatingystems = Global_GLPIOperatingystems;
                return (_tCIXML);
            }
            else if (_DropDown == "computermodels")
            {
                List<GLPI_Model> Global_GLPIModels = runtimeXMLtoListofObjects<GLPI_Model>(_tCIXML, "xxxx.GLPI_Model");
                foreach (GLPI_Model gmod in Global_GLPIModels)
                {
                    DebugWrite("models found and globalised : " + gmod.name + gmod.id, ConsoleColor.Green);
                }
                GGlobal_GLPIModels = Global_GLPIModels;
                return (_tCIXML);
            }
            else if (_DropDown == "states")
            {
                List<GLPI_States> Global_GLPIStates = runtimeXMLtoListofObjects<GLPI_States>(_tCIXML, "xxxx.GLPI_States");
                if (Global_GLPIStates == null)
                {
                    return null;
                }
                foreach (GLPI_States gmod in Global_GLPIStates)
                {
                    InfoWrite("models found and globalised : " + gmod.name + gmod.id, ConsoleColor.Green);
                }
                return (_tCIXML);

            }
            else if (_DropDown == "manufacturer")
            {
                List<GLPI_Manufacturer> Global_GLPIManufacturers = runtimeXMLtoListofObjects<GLPI_Manufacturer>(_tCIXML, "xxxx.GLPI_Manufacturer");
                if (Global_GLPIManufacturers == null)
                {
                    return null;
                }
                foreach (GLPI_Manufacturer gman in Global_GLPIManufacturers)
                {
                    DebugWrite("Manufacturers found and globalised : " + gman.name + gman.id, ConsoleColor.Green);
                }
                GGlobal_GLPIManufacturers = Global_GLPIManufacturers;
                return (_tCIXML);

            }
            else if (_DropDown == "computertypes")
            {
                List<GLPI_Computer_Type> Global_GLPIComputerTypes = runtimeXMLtoListofObjects<GLPI_Computer_Type>(_tCIXML, "xxxx.GLPI_Computer_Type");
                if (Global_GLPIComputerTypes == null)
                {
                    return null;
                }
                foreach (GLPI_Computer_Type gman in Global_GLPIComputerTypes)
                {
                    DebugWrite("ComputerTypes found and globalised : " + gman.name + gman.id, ConsoleColor.Green);
                }
                GGlobal_GLPIComputerTypes = Global_GLPIComputerTypes;
                return (_tCIXML);

            }


            else
            {
                ////            List<GLPI_Model> _tdropdown =  GenericXMLtoListofObjectsT<GLPI_Model>(_tCIXML, __t1.GetType());
                //InfoWrite("About to call specific method", ConsoleColor.Gray);
                //List<GLPI_Model> _tdropdown = runtimeXMLtoListofObjects<GLPI_Model>(_tCIXML, "xxxx.GLPI_Model"); // computermodels, operatingsystems, etc 
                //foreach (GLPI_Model model in _tdropdown)
                //{
                //    InfoWrite("found : " + model.name + " " + model.comment + " " + model.id, ConsoleColor.Cyan);
                //}
                //DebugWrite("About to call runtime method", ConsoleColor.Gray);
                return (_tCIXML);
            }
            //List<GLPI_Model> Global_GLPIModels = runtimeXMLtoListofObjects<GLPI_Model>(_tCIXML, "xxxx.GLPI_Model");
            //     IList<GLPI_Operating_System> Global_GLPIOperatingystems = runtimeXMLtoListofObjects<GLPI_Operating_System>(_tCIXML, "xxxx.GLPI_Operating_System");
            /* List<GLPI_Operating_System> Global_GLPIOperatingystems = runtimeXMLtoListofObjects<GLPI_Operating_System> (_tCIXML, "xxxx.GLPI_Operating_System");
            var Global_GLPIOperatingystems2 = Global_GLPIOperatingystems; 
            foreach (GLPI_Operating_System gos in Global_GLPIOperatingystems2)
            {
                InfoWrite("OS found and globalised : " + gos.name + gos.id, ConsoleColor.Green);
            }
            return (_tCIXML);
           */

        }
        /// <summary>
        /// Get basic GLPI inventory variables in memory (global public List of GLPIGLPI_Partial_CI ComputersSummaryList
        /// </summary>
        public static void GLPIGetBasicInventoryToGlobalVariables()
        {
            InfoWrite("-->" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString(), ConsoleColor.Magenta);
            StringBuilder data = new StringBuilder();
            ArrayList dataGLPI = new ArrayList(); // this will transmit the variables to the GLPI query contained in the service class
            dataGLPI.Clear();
            dataGLPI.Add(services.glpiusername); //username
            dataGLPI.Add(services.glpipassword); //password
            //dataGLPI.Add("dummy"); //ticket number
            string XMLQueryGLPILogin = GLPIFeedServiceVariabletoXml(services.SERVICE_GETGLPISessionID, dataGLPI);
            // issue login request from GLPI
            string _tloginresult = GLPIissueRPCtoServer(XMLQueryGLPILogin);
            //dataGLPI.Add(Globsessionid); //ticket number

            // ask GLPI web services status state (if needed) 
            string glpistatus = "<?xml version=\"1.0\"?>" +
            "<methodCall>" +
            "<methodName>glpi.test</methodName>" +
            "<params><param><value></value></param></params>" +
            "</methodCall>";
            string glpilistallmethods = "<?xml version=\"1.0\"?>" +
            "<methodCall>" +
            "<methodName>glpi.listAllMethods</methodName>" +
            "<params><param><value></value></param></params>" +
            "</methodCall>";
            // ====================================
            string path = string.Empty;
            string xmlInputData = string.Empty;
            string xmlOutputData = string.Empty;
            xmlInputData = _tloginresult;
            Dictionary<string, string> loginResult = new Dictionary<string, string>();
            loginResult = GLPIProcessloginXML(_tloginresult);
            // Global session id will be reused later
            string Globsessionid = "";
            Globsessionid = loginResult["session"];
            // xml structure to get GLPI computers list, position of the arguments in the query is critical. 

            // fill up the RPC_and_SOAP_Construct_Data variable for this call. 
            dataGLPI.Clear();
            dataGLPI.Add(services.glpiusername); //username
            dataGLPI.Add(services.glpipassword); //password
            dataGLPI.Add(Globsessionid); //ticket number
            string XMLQueryGLPIListallobjects = GLPIFeedServiceVariabletoXml(services.SERVICE_GETGLPIPartialCI, dataGLPI);
            // request list of computers from GLPI 
            DebugWrite(XMLQueryGLPIListallobjects, ConsoleColor.Yellow);
            string inventoryComputers = GLPIissueRPCtoServer(XMLQueryGLPIListallobjects);
            DebugWrite(inventoryComputers,ConsoleColor.Yellow);
            // deserialize the result :
            // here we try our generic method for all CIs XML 
            GLPIComputersSummaryList = runtimeXMLtoListofObjects<GLPI_Partial_CI>(inventoryComputers, "xxxx.GLPI_Partial_CI");
            foreach (GLPI_Partial_CI gci in GLPIComputersSummaryList)
            {
                InfoWrite("CIs found and globalised : " + gci.name + gci.id, ConsoleColor.Green);
            }
            DebugWrite("End of GLPI main",ConsoleColor.Blue);
    }
}
}
