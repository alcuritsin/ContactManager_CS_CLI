using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    [Serializable]
    public class Email
    {
        //  Электронная почта
        public string Work { get; set; }    //  Рабочая электронная почта
        public Email()
        {
        }
        ~Email()
        { 
        }
    }
}
