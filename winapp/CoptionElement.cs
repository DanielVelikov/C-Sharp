using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp
{
    internal class COptionElement
    {
        internal COptionElement(String name, String Image)
        {
            szName = name;
            szImage = Image;
        }
        internal String szName;
        internal String szImage;
    }
}
