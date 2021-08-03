using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class Contact
    {
        //  Карточка контакта
        public int ContactID { get; set; }              //  id
        public string Surname { get; set; }             //  Фамилия
        public string Name { get; set; }                //  Имя
        public string Patronymic { get; set; }          //  Отчество
        public DateOfBirth DateOfBirth { get; set; }    //  Дата рождения
        public PhoneNumbers PhoneNumbers { get; set; }  //  Телефонные номера
        public Email Email { get; set; }                //  Клектронный адрес
        public string City { get; set; }                //  Город контакта
    }
}
