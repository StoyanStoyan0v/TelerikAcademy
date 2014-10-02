using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SubstringSearcher.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SubstringSearcher" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SubstringSearcher.svc or SubstringSearcher.svc.cs at the Solution Explorer and start debugging.
    public class SubstringSearcher : ISubstringSearcher
    {
     
        public int GetSubstringCount(string substringPattern, string text)
        {
            int count = 0;
            int index = text.IndexOf(substringPattern);

            while (index!=-1)
            {
                count++;
                index = text.IndexOf(substringPattern, index + 1);
            }
            return count;
        }
    }
}
