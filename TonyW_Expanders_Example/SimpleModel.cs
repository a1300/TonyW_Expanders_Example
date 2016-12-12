using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace OptionsDialog
{
    public enum CategoryType
    {
        Image = 0,
        GeneralInformation = 1,
        AddressData
    }

    public class Category
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; }

        public override string ToString()
        {
            return Name ?? "No Category-Name";
        }
    }
}
