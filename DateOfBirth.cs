using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager
{
    [Serializable]
    public class DateOfBirth
    {
        //  Дата рождения
        public int YearOfBirth { get; set; }    // Год рождения
        public int MonthOfBirth { get; set; }   //  Месяц рождения
        public int DayOfBirth { get; set; }     //  День рождения

        public DateOfBirth()
        { 
        }
        ~DateOfBirth()
        {
        }
    }
}
