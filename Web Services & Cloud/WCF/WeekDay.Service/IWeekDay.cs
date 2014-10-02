using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WeekDay.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWeekDay" in both code and config file together.
    [ServiceContract]
    public interface IWeekDay
    {
        [OperationContract]
        string GetDay(DateTime date);
    }
}
