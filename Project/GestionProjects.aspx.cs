using AccesDBGestionProject.Data;
using AccesDBGestionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationGestionProjects.Project
{
    public partial class GestionProjects : System.Web.UI.Page
    {
        private DPEdbContext dbContext = new DPEdbContext();
        private static List<DateTime> listDate = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {
            load_grid();
        }
        private void clear_page()
        {
            Calendar1.SelectedDates.Clear();
            listDate.Clear();
            TBId.Text = "";
            TBname.Text = "";
        }

        private void load_grid()
        {
            GridViewProjects.DataSource = (from p in dbContext.projects
                                           select p).ToList();
            GridViewProjects.DataBind();
        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDates.Count >=2)
            {
                AccesDBGestionProject.Models.Project project = new AccesDBGestionProject.Models.Project();

                project.name = TBname.Text;
                project.startDate = Calendar1.SelectedDates[0];
                project.endDate = Calendar1.SelectedDates[1];
                dbContext.projects.Add(project);
                dbContext.SaveChanges();
                load_grid();
                clear_page();
            }
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDates.Count >= 2)
            {
                AccesDBGestionProject.Models.Project project = new AccesDBGestionProject.Models.Project();
                Int32 id = int.Parse(TBId.Text);
                project = dbContext.projects.Find(id);

                project.name = TBname.Text;
                project.startDate = Calendar1.SelectedDates[0];
                project.endDate = Calendar1.SelectedDates[1];
                dbContext.SaveChanges();
                load_grid();
                clear_page();
            }
        }

        protected void BtDel_Click(object sender, EventArgs e)
        {
            AccesDBGestionProject.Models.Project project = new AccesDBGestionProject.Models.Project();
            Int32 id = int.Parse(TBId.Text);
            project = dbContext.projects.Find(id);

            dbContext.projects.Remove(project);
            dbContext.SaveChanges();
            load_grid();
            clear_page();
        }

        protected void GridViewDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calendar1.SelectedDates.Clear();
            Int32 id = int.Parse(GridViewProjects.SelectedValue.ToString());
            AccesDBGestionProject.Models.Project project = new AccesDBGestionProject.Models.Project();

            project = dbContext.projects.Find(id);

            TBId.Text = project.projectID.ToString();
            TBname.Text = project.name;
            Calendar1.SelectedDates.Add(project.startDate);
            Calendar1.SelectedDates.Add(project.endDate);

        }

        protected void BtCherche_Click(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsSelected)
            {
                listDate.Add(e.Day.Date);
                Session["SelectedDates"] = listDate;

            }


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                if (newList.Count >= 2)
                {
                    Session["SelectedDates"] = null;

                }
                else
                foreach (DateTime dt in newList)
                {
                    Calendar1.SelectedDates.Add(dt);
                }
                listDate.Clear();

            }
        }
    }
}