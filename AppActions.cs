using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using System.Xml;
using System.Xml.Serialization;

using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;


namespace ContactManager
{
    public class AppActions
    {
        public Contact xmlDeserializer(string file)
        {
            //  XML - Deserialize
            XmlSerializer xml_formatter = new XmlSerializer(typeof(Contact));

            Contact xml_contact = new Contact();
            using (FileStream file_xml = new FileStream("contact.xml", FileMode.OpenOrCreate))
            {
                xml_contact = (Contact)xml_formatter.Deserialize(file_xml);
            }
            return xml_contact;
        }

        //  Xml
        public void xmlInput(string file_name, ref List<Contact> contacts)
        {
            //  XML - Deserialize to List
            XmlSerializer xml_formatter = new XmlSerializer(typeof(List<Contact>));

            using (FileStream file_xml = new FileStream(file_name + ".xml", FileMode.OpenOrCreate))
            {
                contacts = (List<Contact>)xml_formatter.Deserialize(file_xml);
            }
        }
        public void xmlOutput(string file_name, ref List<Contact> contacts)
        {
            //  XML - Serializer from List
            XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
            using (FileStream file_xml = new FileStream(file_name + ".xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(file_xml, contacts);
            }

        }

        //  Json
        public void jsonInput(string file_name, ref List<Contact> contacts)
        {
            //  JSON - Deserialize to List
            using (FileStream fileJsonInput = new FileStream(file_name + ".json", FileMode.OpenOrCreate))
            {
                contacts = JsonSerializer.DeserializeAsync<List<Contact>>(fileJsonInput).Result;
            }

        }
        public void jsonOutput(string file_name, ref List<Contact> contacts)
        {
            //  JSON - Serializer from List
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            using (FileStream fileJsonOutput = new FileStream(file_name + ".json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(fileJsonOutput, contacts, options);
            }
        }
    }
}
