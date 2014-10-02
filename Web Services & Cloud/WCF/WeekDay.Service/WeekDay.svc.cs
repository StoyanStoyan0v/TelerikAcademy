using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WeekDay.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WeekDay" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WeekDay.svc or WeekDay.svc.cs at the Solution Explorer and start debugging.
    public class WeekDay : IWeekDay
    {
        public string GetDay(DateTime date)
        {
            var culture = new System.Globalization.CultureInfo("bg-BG");
            return culture.DateTimeFormat.GetDayName(date.DayOfWeek);
        }
    }
}