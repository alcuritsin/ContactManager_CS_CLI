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
        public void LoadDB()
        {
            //  При старте загрузить базу в программу.
            xmlInput("db_contacts", ref Program.contacts);
        }
        public void UploadDB()
        {
            //  При выходе выгрузить накопленное в файл.
            xmlOutput("db_contacts", ref Program.contacts);
        }

        public void CreateNewContact()
        {
            //  Создание нового контакта.
            Program.dsp.ShowFrame("Ввод нового контакта:");

            Contact contact = new Contact();

            contact.ContactID = (uint)Program.contacts.Count() + 1;

            contact.Surname = Program.dsp.RequestUser("Фамилия: ");
            contact.Name = Program.dsp.RequestUser("Имя: ");
            contact.Patronymic = Program.dsp.RequestUser("Отчество: ");

            //  День рождения
            contact.DateOfBirth.YearOfBirth = Convert.ToUInt32(Program.dsp.RequestUser("Год рождения (int): "));
            contact.DateOfBirth.MonthOfBirth = Convert.ToUInt32(Program.dsp.RequestUser("Месяц рождения (int): "));
            contact.DateOfBirth.DayOfBirth = Convert.ToUInt32(Program.dsp.RequestUser("День рождения (int): "));
            //  Телефоны
            contact.PhoneNumbers.Mobile = Program.dsp.RequestUser("Мобилный номер: ");
            contact.PhoneNumbers.Work = Program.dsp.RequestUser("Рабочий номер: ");
            //  email
            contact.Email.Work = Program.dsp.RequestUser("email: ");

            contact.City = Program.dsp.RequestUser("Город: ");

            Program.contacts.Add(contact);

            Program.dsp.ShowMesage("Новый контакт добавлен.");

            Program.dsp.ShowReseption();
        }

        public void EditContact()
        {
            //  Редактировние контакта
            Program.dsp.ShowFrame("Редактирование контакта по ID:");

            uint id = Convert.ToUInt32(Program.dsp.RequestUser("Введите ID: "));
            bool successful = false;

            Contact e_contact = new Contact();

            foreach (Contact contact in Program.contacts)
            {
                if (contact.ContactID == id)
                {
                    e_contact = contact;    //  Делаем копию контакта.

                    //  Просим пользователя внести коррективы.
                    e_contact.Surname = Program.dsp.RequestUser("Фамилия: " + e_contact.Surname + ">> ");
                    e_contact.Name = Program.dsp.RequestUser("Имя: " + e_contact.Name + ">> ");
                    e_contact.Patronymic = Program.dsp.RequestUser("Отчество: " + e_contact.Patronymic + ">> ");

                    //  День рождения
                    e_contact.DateOfBirth.YearOfBirth = Convert.ToUInt32(Program.dsp.RequestUser("Год рождения (int): " + e_contact.DateOfBirth.YearOfBirth + ">> "));
                    e_contact.DateOfBirth.MonthOfBirth = Convert.ToUInt32(Program.dsp.RequestUser("Месяц рождения (int): " + e_contact.DateOfBirth.MonthOfBirth + ">> "));
                    e_contact.DateOfBirth.DayOfBirth = Convert.ToUInt32(Program.dsp.RequestUser("День рождения (int): " + e_contact.DateOfBirth.DayOfBirth + ">> "));
                    //  Телефоны
                    e_contact.PhoneNumbers.Mobile = Program.dsp.RequestUser("Мобилный номер: " + e_contact.PhoneNumbers.Mobile + ">> ");
                    e_contact.PhoneNumbers.Work = Program.dsp.RequestUser("Рабочий номер: " + e_contact.PhoneNumbers.Work + ">> ");
                    //  email
                    e_contact.Email.Work = Program.dsp.RequestUser("email: " + e_contact.Email.Work + ">> ");

                    e_contact.City = Program.dsp.RequestUser("Город: " + e_contact.City + ">> ");

                    //  Удаляем текущий элемент из колекции
                    successful = Program.contacts.Remove(contact);

                    if (successful)
                    {
                        Program.dsp.ShowMesage("Редактирование прошло успешно.");
                        //  Добавляем отредактированный контакт
                        Program.contacts.Add(e_contact);
                    }
                    else
                    {
                        Program.dsp.ShowMesage("Что-то пошло не так... :(");
                    }
                    break;  //  Дальше не смотрим.
                }
            }

            if (!successful)
            {
                Program.dsp.RequestUser("Указанного ID в базе не обноружено...");
            }

            Program.dsp.ShowReseption();
        }

        public void DeleteContact()
        {
            //  Удаление сонтакта по ID
            Program.dsp.ShowFrame("Удаление контакта по ID:");

            uint id = Convert.ToUInt32(Program.dsp.RequestUser("Введите ID: "));
            bool successful = false;

            foreach (Contact contact in Program.contacts)
            {
                if (contact.ContactID == id)
                {
                    //  Удаляем текущий элемент из колекции
                    successful = Program.contacts.Remove(contact);

                    if (successful)
                    {
                        Program.dsp.ShowMesage("Удаление прошло успешно.");
                    }
                    else
                    {
                        Program.dsp.ShowMesage("При удалении возникла проблема :(");
                    }
                    break;
                }

            }

            if (!successful)
            {
                Program.dsp.RequestUser("Указанного ID в базе не обноружено...");
            }

            Program.dsp.ShowReseption();
        }

        public void ExportDB()
        {

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
