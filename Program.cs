using System;
using System.Collections.Generic;

using static System.Console;

namespace ContactManager
{
    class Program
    {
        public class Contact
        {
            public string ContactID { get; set; }           //  id
            public string Surname { get; set; }             //  Фамилия
            public string Name { get; set; }                //  Имя
            public string Patronymic { get; set; }          //  Отчество
            //public DateOfBirth DateOfBirth { get; set; }    //  Дата рождения
            //public PhoneNumbers PhoneNumbers { get; set; }  //  Телефонные номера
            //public Email Email { get; set; }                //  Клектронный адрес
            public string City { get; set; }
            Contact() { }
            ~Contact() { }

            public Contact(
                string _contactID,
                string _surname,
                string _name,
                string _patronymic,
                string _city)
            {
                ContactID = _contactID;
                Surname = _surname;
                Name = _name;
                Patronymic = _patronymic;
                City = _city;
            }

            public void info()
            {
                WriteLine($"     id: {ContactID}");
                WriteLine($"contact: {Surname} {Name} {Patronymic}");
                WriteLine($"   city: {City}");
            }
        }
        
        static void Main()
        {
            List<Contact> contacts = new List<Contact>(3);

        }
    }
}
