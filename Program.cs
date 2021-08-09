using System;
using System.Collections.Generic;
using System.Xml;

namespace ContactManager
{
    class Program
    {
        static void Main()
        {
            //Catalog dbCatalog = new Catalog();
            List<Contact> catalog = new List<Contact>(3);

            AppAction action = new AppAction();

            //action.xDB(ref dbCatalog);    //  Не получилось.
            action.dbReadXml(ref catalog);

            foreach (Contact contact in dbCatalog.Contact)
            {
                contact.print();
            }

            Console.WriteLine(dbCatalog.Contact.Count);
            
        }
    }
}
