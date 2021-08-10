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

    public class Program
    {
        public static AppActions app = new AppActions();
        public static Displey dsp = new Displey();
        public static List<Contact> contacts = new List<Contact>(3);

        static void Main()
        {
            app.LoadDB();
            dsp.ShowReseption();

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        //  вернуться на главный экран
                        dsp.ShowReseption();
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //  показать все контакты
                        dsp.ContactShowAll();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //  добавить новый контакт
                        app.CreateNewContact();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //  редактировать контакт по ID
                        app.EditContact();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //  удалить контакт по ID
                        app.DeleteContact();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        //  экспорт в указанный файл
                        app.ExportDB();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        //  импортировать из указанного файла
                        app.ImportBD();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        //  сохраниться
                        app.UploadDB();
                        break;
                    default:
                        break;
                }
            }
            while (key.Key != ConsoleKey.Escape); // по нажатию на Escape завершаем цикл

            app.UploadDB();

            dsp.ShowEnd();
//#if !true
//            //  Проверка контакта.
            
//            Contact contact = new Contact
//            {
//                ContactID = 1,
//                Surname = "Курицын",
//                Name = "Алексей",
//                Patronymic = "Юрьевич",
//                DateOfBirth = new DateOfBirth(1984, 1, 18),
//                PhoneNumbers = new PhoneNumbers("+7 (123) 456 78 90", "+7 (123) 456 78 90"),
//                Email = new Email("work@mail.com"),
//                City = "Екатеринбург"
//            };

//            contact.info();

//            //  XML - Serializer
//            XmlSerializer xml = new XmlSerializer(typeof(Contact));
//            using (FileStream file_xml = new FileStream("contact.xml", FileMode.OpenOrCreate))
//            {
//                xml.Serialize(file_xml, contact);
//            }

//            //  XML - Deserialize
//            Contact xml_contact = new Contact();
//            using (FileStream file_xml = new FileStream("contact.xml", FileMode.OpenOrCreate))
//            {
//                xml_contact = (Contact)xml.Deserialize(file_xml);
//            }
//            WriteLine("\nxml--");
//            xml_contact.info();

//            //  JSON - Serializer
//            JsonSerializerOptions options = new JsonSerializerOptions
//            {
//                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
//                WriteIndented = true
//            };
//            using (FileStream file_json = new FileStream("contact.json", FileMode.OpenOrCreate))
//            {
//                await JsonSerializer.SerializeAsync(file_json, contact, options);
//            }

//            //  JSON - Deserialize
//            Contact json_contact = new Contact();
//            using (FileStream file_json = new FileStream("contact.json", FileMode.OpenOrCreate))
//            {
//                json_contact = await JsonSerializer.DeserializeAsync<Contact>(file_json);
//            }
//            WriteLine("\njson--");
//            json_contact.info(); 
//#endif
//#if true

//            Contact contact1 = new Contact
//            {
//                ContactID = 1,
//                Surname = "Курицын",
//                Name = "Алексей",
//                Patronymic = "Юрьевич",
//                DateOfBirth = new DateOfBirth(1984, 1, 18),
//                PhoneNumbers = new PhoneNumbers("+7 (123) 456 78 90", "+7 (123) 456 78 90"),
//                Email = new Email("work@mail.com"),
//                City = "Екатеринбург"
//            };
//            Contact contact2 = new Contact
//            {
//                ContactID = 2,
//                Surname = "Ivanov",
//                Name = "Ivan",
//                Patronymic = "Ivanivich",
//                DateOfBirth = new DateOfBirth(1990, 12, 31),
//                PhoneNumbers = new PhoneNumbers("+7 (098) 765 43 21", "+7 (098) 765 43 21"),
//                Email = new Email("ivanov@mail.com"),
//                City = "Cheliabinsk"
//            };
//            contacts.Add(contact1);
//            contacts.Add(contact2);

//            app.xmlOutput("contacts", ref contacts);
//            app.jsonOutput("contacts", ref contacts);

//            List<Contact> xml_contacts = new List<Contact>(3);
//            List<Contact> json_contacts = new List<Contact>(3);

//            app.xmlInput("contacts", ref xml_contacts);
//            app.jsonInput("contacts", ref json_contacts);

//            WriteLine("xml_input");
//            dsp.ContactShowAll(ref xml_contacts);

//            WriteLine("json_input");
//            dsp.ContactShowAll(ref json_contacts);

//#endif


        }
    }
}
