using System;

namespace ContactManager
{
    [Serializable]
    public class DateOfBirth
    {
        //  Дата рождения
        public uint YearOfBirth { get; set; }    // Год рождения
        public uint MonthOfBirth { get; set; }   //  Месяц рождения
        public uint DayOfBirth { get; set; }     //  День рождения

        public DateOfBirth() { }
        ~DateOfBirth() { }
        public DateOfBirth(uint year,uint month, uint day)
        {
            YearOfBirth = year;
            MonthOfBirth = month;
            DayOfBirth = day;
        }
        public uint AgeNow()
        {
            //  Посчитать возраст
            //  todo
            return 0;
        }
    }
}
