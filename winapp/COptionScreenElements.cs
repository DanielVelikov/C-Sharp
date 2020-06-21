using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winapp
{
    internal class COptionScreenElements
    {
        internal COptionScreenElements()
        {
            optionElements.Add(new COptionElement("Project Management", "TableImages/generic.jpg"));
            optionElements.Add(new COptionElement("Project Overview", "TableImages/generic.jpg"));
            optionElements.Add(new COptionElement("Transaction Management", "TableImages/generic.jpg"));
            optionElements.Add(new COptionElement("Transaction Overview", "TableImages/generic.jpg"));
        }
        internal List<COptionElement> optionElements = new List<COptionElement>();
    }
}
