using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winapp.Classes;

namespace winapp.Classes
{
    public class CProjectSizesChart
    {
        internal CProjectSizesChart(string name)
        {
            this.projectSizeName = name;
            countProjects(); 
        }

        private void countProjects()
        {
            long projectSizeID = ((ProjectSizes)(App.workObjects.projectSizesTable.ProjectSizesList.Where(x => x.szProjectSize.Equals(projectSizeName))).First()).lID;
            projectCount = App.workObjects.projectsTable.ProjectsList.Count(n => n.lProjectSizeID == projectSizeID);
        }
        public string projectSizeName { get; set; }
        public int projectCount { get; set; }
    }
}
