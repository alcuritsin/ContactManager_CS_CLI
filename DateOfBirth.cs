using System;
using System.Buffers;

namespace ContactManager
{
    [Serializable]
    public class DateOfBirth
    {
        //  Дата рождения
        public uint YearOfBirth { get; set; } // Год рождения
        public uint MonthOfBirth { get; set; } //  Месяц рождения
        public uint DayOfBirth { get; set; } //  День рождения

        public DateOfBirth()
        {
        }

        ~DateOfBirth()
        {
        }

        public DateOfBirth(uint year, uint month, uint day)
        {
            YearOfBirth = year;
            MonthOfBirth = month;
            DayOfBirth = day;
        }

        public uint AgeNow()
        {
            //  Посчитать возраст
            //  todo
            int age=0;
            DateTime today = DateTime.Today;
            DateTime birth = new DateTime(Convert.ToInt32(YearOfBirth), Convert.ToInt32(MonthOfBirth),
                Convert.ToInt32(DayOfBirth));

            age = today.Year - birth.Year;

            if (today.Month < birth.Month || (today.Month == birth.Month && today.Day < birth.Day))
            {
                age--;
            }

            return Convert.ToUInt32(age);
        }
    }
}