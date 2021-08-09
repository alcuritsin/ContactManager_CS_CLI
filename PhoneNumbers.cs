using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    public class PhoneNumbers
    {
        //  Телефонные номера
        public string Mobile { get; set; }  //  Мобильный
        public string Work { get; set; }    //  Рабочий

        public PhoneNumbers() { }
        public PhoneNumbers(string mobile, string work)
        {
            Mobile = mobile;
            Work = work;
        }
        ~PhoneNumbers() { }
    }
}
