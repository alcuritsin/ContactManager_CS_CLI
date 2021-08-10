using System;

namespace ContactManager
{
    [Serializable]
    public class Email
    {
        //  Электронная почта
        public string Work { get; set; }    //  Рабочая электронная почта
        public Email() { }
        public Email(string email)
        {
            Work = email;
        }
        ~Email() { }
    }
}
