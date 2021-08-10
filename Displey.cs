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
        public void ContactShowAll(ref List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                ContactShowOne(contact);
            }
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
