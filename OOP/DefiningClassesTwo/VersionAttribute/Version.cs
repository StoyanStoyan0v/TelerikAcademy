using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionAttribute
{
    //Set where the attribute can be used and set multiple usage to a single element to false.
    [AttributeUsage(AttributeTargets.Struct |
  AttributeTargets.Class | AttributeTargets.Interface,
  AllowMultiple = false)]
    public class VersionAttribute : System.Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
}
