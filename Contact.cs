using System;

using static System.Console;

namespace ContactManager
{
    [Serializable]
    public class Contact
    {
        public uint ContactID { get; set; }           //  id
        public string Surname { get; set; }             //  Фамилия
        public string Name { get; set; }                //  Имя
        public string Patronymic { get; set; }          //  Отчество
        public DateOfBirth DateOfBirth { get; set; }    //  Дата рождения
        public PhoneNumbers PhoneNumbers { get; set; }  //  Телефонные номера
        public Email Email { get; set; }                //  Клектронный адрес
        public string City { get; set; }
        public Contact() { }

        ~Contact() { }

        public Contact(
            uint _contactID,
            string _surname,
            string _name,
            string _patronymic,
            DateOfBirth dateOfBirth,
            PhoneNumbers phoneNumbers,
            Email email,
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
            WriteLine($"  birth: {DateOfBirth.YearOfBirth}.{DateOfBirth.MonthOfBirth}.{DateOfBirth.DayOfBirth}\tage: AgeNow");
            WriteLine($"M_phone: {PhoneNumbers.Mobile}");
            WriteLine($"W_phone: {PhoneNumbers.Work}");
            WriteLine($"W_email: {Email.Work}");
            WriteLine($"   city: {City}");
        }
    }

}
