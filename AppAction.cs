using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

using System.IO;

namespace ContactManager
{
    public class AppAction
    {
        private const string dbFileName = "Contacts_DB.xml";    //  Имя файла базы данных контактов.

        public void xDB(ref List<Contact> catalog)
        {
            //  Не получилось :(
            XmlSerializer formatter = new XmlSerializer(typeof(Contact));

            catalog = null;
            using (FileStream fs = new FileStream("_"+dbFileName,FileMode.OpenOrCreate ))
            {
                Contact newContact = (Contact)formatter.Deserialize(fs);
            }

            //using (FileStream fs = new FileStream(dbFileName, FileMode.OpenOrCreate))
            //{
            //    dbCatalog = (Catalog)formatter.Deserialize(fs);
            //}
        }
        public void dbReadXml(ref Catalog dbCatalog, string dbFile = dbFileName)
        {
            //  Считывает каталог контактов
            XmlDocument xDoc = new XmlDocument();

            xDoc.Load(dbFile);

            //  получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            //  обход всех узлов в корневом элементе
            foreach (XmlElement xNode in xRoot)
            {
                Contact contact = new Contact();

                foreach (XmlNode xChild in xNode.ChildNodes)
                {
                    //Console.WriteLine($"attribute: {xChild.Name} - {xChild.InnerText}");

                    switch (xChild.Name)
                    {
                        case "ContactID":
                            contact.ContactID = xChild.InnerText;
                            break;

                        case "Surname":
                            contact.Surname = xChild.InnerText;
                            break;
                        case "Name":
                            contact.Name = xChild.InnerText;
                            break;
                        case "Patronymic":
                            contact.Patronymic = xChild.InnerText;
                            break;

                        case "DateOfBirth":
                            DateOfBirth dateOfBirth = new DateOfBirth();
                            
                            foreach (XmlNode childNode in xChild)
                            {
                                switch (childNode.Name)
                                {
                                    case "YearOfBirth":
                                        dateOfBirth.YearOfBirth = Int32.Parse(childNode.InnerText);
                                        break;
                                    case "MonthOfBirth":
                                        dateOfBirth.MonthOfBirth = Int32.Parse(childNode.InnerText);
                                        break;
                                    case "DayOfBirth":
                                        dateOfBirth.DayOfBirth = Int32.Parse(childNode.InnerText);
                                        break;
                                }
                            }
                            contact.DateOfBirth = dateOfBirth;
                            break;

                        case "PhoneNumbers":
                            PhoneNumbers phoneNumbers = new PhoneNumbers();
                            foreach (XmlNode childNode in xChild)
                            {
                                switch (childNode.Name)
                                {
                                    case "Mobile":
                                        phoneNumbers.Mobile = childNode.InnerText;
                                        break;
                                    case "Work":
                                        phoneNumbers.Work = childNode.InnerText;
                                        break;
                                }
                            }
                            contact.PhoneNumbers = phoneNumbers;
                            break;

                        case "Email":
                            Email email = new Email();
                            foreach (XmlNode childNode in xChild)
                            {
                                switch (childNode.Name)
                                {
                                    case "Work":
                                        email.Work = childNode.InnerText;
                                        break;
                                }
                            }
                            contact.Email = email;
                            break;

                        case "City":
                            contact.City = xChild.InnerText;
                            break;
                    }
                }

                //contact.print();

                dbCatalog.AddContact(contact);

            }

        }
        void dbWrite(ref Catalog dbCatalog, string dbFile = dbFileName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(dbFile);

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (Contact contact in dbCatalog)
            {

            }

        }
    }

    
}
