using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winapp;
using winapp.Pages;

namespace winapp.Classes
{
    public class CProjectCharts
    {
        internal CProjectCharts()
        {
            setProjectChartsData();
        }

        void setProjectChartsData()
        {
            foreach(ProjectSizes projectSize in App.workObjects.projectSizesTable.ProjectSizesList)
            {
                projectSizesCharts.Add(new CProjectSizesChart(projectSize.szProjectSize));
            }

            foreach(Projects project in App.workObjects.projectsTable.ProjectsList)
            {
                projectDeadlineCharts.Add(new CProjectDeadlineChart(project.EndDate));
            }
        }

        public List<CProjectSizesChart> projectSizesCharts = new List<CProjectSizesChart>();
        public List<CProjectDeadlineChart> projectDeadlineCharts = new List<CProjectDeadlineChart>();
    }
}
