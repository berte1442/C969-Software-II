using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogInForm
{
    public class Calender
    {
        static public int WeekCalenderDayMinus(DateTime selectedDate)
        {
            int dayMinus = 0;
            if ((int)selectedDate.DayOfWeek == 0)
            {
                dayMinus = 0;
            }
            else if ((int)selectedDate.DayOfWeek == 1)
            {
                dayMinus = 1;
            }
            else if ((int)selectedDate.DayOfWeek == 2)
            {
                dayMinus = 2;
            }
            else if ((int)selectedDate.DayOfWeek == 3)
            {
                dayMinus = 3;
            }
            else if ((int)selectedDate.DayOfWeek == 4)
            {
                dayMinus = 4;
            }
            else if ((int)selectedDate.DayOfWeek == 5)
            {
                dayMinus = 5;
            }
            else if ((int)selectedDate.DayOfWeek == 6)
            {
                dayMinus = 6;
            }

            return dayMinus;
        }
        static public int WeekCalenderDayAdd(DateTime selectedDate)
        {
            int dayAdd = 0;
            if ((int)selectedDate.DayOfWeek == 0)
            {
                dayAdd = 7;
            }
            else if ((int)selectedDate.DayOfWeek == 1)
            {
                dayAdd = 6;
            }
            else if ((int)selectedDate.DayOfWeek == 2)
            {
                dayAdd = 5;
            }
            else if ((int)selectedDate.DayOfWeek == 3)
            {
                dayAdd = 4;
            }
            else if ((int)selectedDate.DayOfWeek == 4)
            {
                dayAdd = 3;
            }
            else if ((int)selectedDate.DayOfWeek == 5)
            {
                dayAdd = 2;
            }
            else if ((int)selectedDate.DayOfWeek == 6)
            {
                dayAdd = 1;
            }

            return dayAdd;
        }
        static public int MonthMaxDay(DateTime selectedDate)
        {
            int monthMaxDay;
            int year = selectedDate.Year;
            int month = selectedDate.Month;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 ||
                month == 10 || month == 12)
            {
                monthMaxDay = 31;
            }
            else if (month == 2)  // following checks for leap year
            {
                if (year % 4 == 0)
                {
                    monthMaxDay = 29;
                }
                else if (year % 100 == 0)
                {
                    monthMaxDay = 28;
                }
                else if (year % 400 == 0)
                {
                    monthMaxDay = 29;
                }
                else
                {
                    monthMaxDay = 28;
                }
            }
            else
            {
                monthMaxDay = 30;
            }
            return monthMaxDay;
        }
    }
}
