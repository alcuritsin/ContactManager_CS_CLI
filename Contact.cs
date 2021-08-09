using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    [Serializable]
    public class Contact
    {
        //  Карточка контакта
        public string ContactID { get; set; }           //  id
        public string Surname { get; set; }             //  Фамилия
        public string Name { get; set; }                //  Имя
        public string Patronymic { get; set; }          //  Отчество
        public DateOfBirth DateOfBirth { get; set; }    //  Дата рождения
        public PhoneNumbers PhoneNumbers { get; set; }  //  Телефонные номера
        public Email Email { get; set; }                //  Клектронный адрес
        public string City { get; set; }                //  Город контакта

        public Contact()
        {
        }
        ~Contact()
        {
        }
        
        public override string ToString()
        {
            // Приведение объекта к строке.
            return Surname + " " + Name + " " + Patronymic;
        }

        public void print()
        {
            Console.WriteLine($"-- Контакт = ContactID: {ContactID}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Patronymic: {Patronymic}\n");

            Console.WriteLine($"DateOfBirth: {DateOfBirth.YearOfBirth}.{DateOfBirth.MonthOfBirth}.{DateOfBirth.DayOfBirth}\n");

            Console.WriteLine("PhoneNumbers:");
            Console.WriteLine($"-- Work: {PhoneNumbers.Work}");
            Console.WriteLine($"-- Mobile: {PhoneNumbers.Mobile}\n");

            Console.WriteLine("Email:");
            Console.WriteLine($"-- Work: {Email.Work}\n");

            Console.WriteLine($"City: {City}");
        }
    }
}
