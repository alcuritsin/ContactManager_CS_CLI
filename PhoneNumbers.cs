using System;

namespace ContactManager
{
    [Serializable]
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
