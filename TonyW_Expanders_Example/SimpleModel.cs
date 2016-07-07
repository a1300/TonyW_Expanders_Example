using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TonyW_Expanders_Example
{
    public class SimpleModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return (LastName == null && FirstName == null) ? "You haven't specified an Name" : String.Format("{0}, {1}", LastName, FirstName);
        }
    }
}
