using System;
using System.Collections.Generic;
using System.IO;

using System.Xml;
using System.Xml.Serialization;

using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;

using static System.Console;
using Microsoft.Extensions.Options;

namespace ContactManager
{
    class Program
    {

        static async Task Main()
        {
            //List<Contact> contacts = new List<Contact>(3);
            //Contact contact = new Contact("1","Курицын","Алексей","Юрьевич","Екатеринбург");
            Contact contact = new Contact
            {
                ContactID = 1,
                Surname = "Курицын",
                Name = "Алексей",
                Patronymic = "Юрьевич",
                DateOfBirth = new DateOfBirth(1984,1,18),
                PhoneNumbers = new PhoneNumbers("+7 (123) 456 78 90", "+7 (123) 456 78 90"),
                Email = new Email("work@mail.com"),
                City = "Екатеринбург"
            };

            contact.info();

            //XML - Serializer
            XmlSerializer xml = new XmlSerializer(typeof(Contact));
            using (FileStream file_xml = new FileStream("contact.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(file_xml, contact);
            }

            Contact xml_contact = new Contact();
            using (FileStream file_xml = new FileStream("contact.xml", FileMode.OpenOrCreate))
            {
                xml_contact = (Contact)xml.Deserialize(file_xml);
            }
            WriteLine("\nxml--");
            xml_contact.info();

            //JSON
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            using (FileStream file_json = new FileStream("contact.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(file_json, contact, options);
            }

            Contact json_contact = new Contact();
            using (FileStream file_json = new FileStream("contact.json", FileMode.OpenOrCreate))
            {
                json_contact = await JsonSerializer.DeserializeAsync<Contact>(file_json);
            }
            WriteLine("\njson--");
            json_contact.info();


        }
    }
}
