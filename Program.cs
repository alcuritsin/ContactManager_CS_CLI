using System;
using System.Collections.Generic;

using static System.Console;

namespace ContactManager
{

    public class Program
    {
        public static AppActions app = new AppActions();
        public static Displey dsp = new Displey();
        public static List<Contact> contacts = new List<Contact>(3);

        static void Main()
        {
            app.LoadDB();
            dsp.ShowReseption();

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                        //  вернуться на главный экран
                        dsp.ShowReseption();
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        //  показать все контакты
                        dsp.ContactShowAll();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //  добавить новый контакт
                        app.CreateNewContact();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        //  редактировать контакт по ID
                        app.EditContact();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        //  удалить контакт по ID
                        app.DeleteContact();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        //  экспорт в указанный файл
                        app.ExportDB();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        //  импортировать из указанного файла
                        app.ImportBD();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        //  сохраниться
                        app.UploadDB();
                        dsp.ShowReseption();
                        break;
                    default:
                        break;
                }
            }
            while (key.Key != ConsoleKey.Escape); // по нажатию на Escape завершаем цикл

            app.UploadDB();

            dsp.ShowEnd();

            ReadLine();
        }
    }
}
