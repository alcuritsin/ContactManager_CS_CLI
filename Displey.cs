using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static System.Console;

namespace ContactManager
{
    public class Displey
    {
        public void ShowReseption()
        {
            //  Главное меню, ресепшен...
            ShowSign();
            ShowMenu();
            ShowAmount();
        }
        public void ShowFrame(string title)
        {
            ShowSign();
            WriteLine(title + "\n");
        }

        public void ShowMesage(string msg)
        {
            WriteLine(msg);
        }

        public string RequestUser(string msg)
        {
            //  Запрос у пользователя
            Write(msg);
            return ReadLine();
        }

        public void ShowSign()
        {
            Clear();
            WriteLine(
                "+----+----+----+----+----+----*----+----+----+----+----+----+\n" +
                "+                        Приложение:                        +\n" +
                "+                     Контакт менеджер                      +\n" +
                "+                 формат файлов xml, json                   +\n" +
                "+----+----+----+----+----+----*----+----+----+----+----+----+");
        }
        public void ShowMenu()
        {
            WriteLine(
                "     Меню\n" +
                "   Escape - выход\n" +
                "        0 - вернуться на главный экран (этот)\n" +
                "        1 - показать все контакты\n" +
                "        2 - добавить новый контакт\n" +
                "        3 - редактировать контакт по ID\n" +
                "        4 - удалить контакт по ID\n" +
                "        5 - экспорт в указанный файл\n" +
                "        6 - импортировать из указанного файла\n" +
                "        7 - сохраниться :)\n\n");
        }
        public void ShowAmount()
        {
            WriteLine(
                $"в базе {Program.contacts.Count} контактов");
        }

        //public void 
        public void ContactShowAll()
        {

            ShowSign();
            foreach (var contact in Program.contacts)
            {
                ContactShowOne(contact);
            }

            ShowAmount();
            WriteLine("\n\n        0 - вернуться на главный экран (этот)\n");
        }
        public void ContactShowOne(Contact contact)
        {
            WriteLine($"     id: {contact.ContactID}");
            WriteLine($"contact: {contact.Surname} {contact.Name} {contact.Patronymic}");
            WriteLine($"  birth: {contact.DateOfBirth.YearOfBirth}.{contact.DateOfBirth.MonthOfBirth}.{contact.DateOfBirth.DayOfBirth}\tage: AgeNow");
            WriteLine($"M_phone: {contact.PhoneNumbers.Mobile}");
            WriteLine($"W_phone: {contact.PhoneNumbers.Work}");
            WriteLine($"W_email: {contact.Email.Work}");
            WriteLine($"   city: {contact.City}");
        }
    }
}
