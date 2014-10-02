using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubstringSearcher.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISubstringSearcher" in both code and config file together.
    [ServiceContract]
    public interface ISubstringSearcher
    {
        [OperationContract]
        int GetSubstringCount(string substringPattern, string text);
    }
}
