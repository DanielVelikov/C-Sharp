using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winapp.Classes;

namespace winapp.Classes
{
    public class CProjectDeadlineChart
    {
        internal CProjectDeadlineChart(DateTime date)
        {
            this.projectDeadline = date.ToString("MMM");
            countProjects(date);
        }

        void countProjects(DateTime date)
        {
            projectCount = App.workObjects.projectsTable.ProjectsList.Count(n => n.EndDate.Month == date.Month);
        }

        public string projectDeadline { get; set; }
        public int projectCount { get; set; }
    }
}
