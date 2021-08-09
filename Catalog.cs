using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    [Serializable]
    public class Catalog
    {
        //  Каталог контактов
        public List<Contact> Contact { get; set; } = new List<Contact>();
        public Catalog()
        {
        }
        ~Catalog()
        {
        }

        public void AddContact(Contact contact)
        {
            Contact.Add(contact);
        }
    }
}