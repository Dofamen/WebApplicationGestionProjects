using AccesDBGestionProject.Data;
using AccesDBGestionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationGestionProjects.Assignment_page
{
    /*
     * Probleme dans la fonction load_Grid qui n'acche pas le last name et fisrt name
     */
    public partial class GestionAssigment : System.Web.UI.Page
    {
        private DPEdbContext dbContext = new DPEdbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                load_DdEmploye();
                load_DdProject();
            }
            load_grid();
        }

        private void load_grid() ////// PROBLEME
        {
            //SOLUTION 1 NE MARCHE PAS
            //GridViewAssigment.DataSource = (from a in dbContext.assignments
            //                                select new {a.EmployeeID, a.ProjectID ,
            //                                    a.Employee.firstName, a.Employee.lastName,
            //                                    a.Project.name }).ToList();


            //SOLUTION 1 NE MARCHE PAS AVEC SQL RAW
            //GridViewAssigment.DataSource = dbContext.assignments.SqlQuery("SELECT emp.employeID, p.projectID, emp.firstName, emp.lastName, p.name " +
            //    "FROM Employees emp, Projects p, Assignments a " +
            //    "WHERE emp.employeID = a.EmployeeID AND p.projectID = a.ProjectID").ToList();

            GridViewAssigment.DataBind();
        }
        private void load_DdEmploye()
        {
            DropDownListEmploye.DataSource = (from emp in dbContext.employees
                                              let person = new {EmployeId= emp.employeID,
                                                  fullname = emp.firstName +" " + emp.lastName}
                                              select person).ToList();
            DropDownListEmploye.DataTextField = "fullname";
            DropDownListEmploye.DataValueField = "EmployeId";
            DropDownListEmploye.DataBind();
        }
        private void load_DdProject()
        {
            DropDownListProject.DataSource = (from project in dbContext.projects
                                              select project).ToList();

            DropDownListProject.DataTextField = "name";
            DropDownListProject.DataValueField = "projectID";
            DropDownListProject.DataBind();
        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            Assignment assignment = new Assignment();
            Int32 idEmp = int.Parse(DropDownListEmploye.SelectedValue.ToString());
            Int32 idProj = int.Parse(DropDownListProject.SelectedValue.ToString());

            assignment.EmployeeID = idEmp;
            assignment.ProjectID = idProj;
            dbContext.assignments.Add(assignment);
            dbContext.SaveChanges();
            load_grid();
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void BtDel_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridViewDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            DropDownListEmploye.SelectedValue = GridViewAssigment.SelectedRow.Cells[0].Text;
            DropDownListProject.SelectedValue = GridViewAssigment.SelectedRow.Cells[1].Text;
        }

        protected void BtCherche_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(TBZoneCherche.Text))
            {
                switch (RBSearch.SelectedValue)
                {
                    case "Project":
                        GridViewAssigment.DataSource = (from a in dbContext.assignments
                                                        where a.Project.name == TBZoneCherche.Text
                                                        select new { a.EmployeeID, a.ProjectID, a.Employee.firstName, a.Employee.lastName, a.Project.name }
                                                        ).ToList();
                        break;
                    case "Employe":
                        GridViewAssigment.DataSource = (from a in dbContext.assignments
                                                          where a.Employee.firstName == TBZoneCherche.Text
                                                          select new { a.EmployeeID, a.ProjectID , a.Employee.firstName, a.Employee.lastName, a.Project.name }
                                                          ).ToList();
                        break;
                    default:
                        break;
                }
                GridViewAssigment.DataBind();
            }
        }
    }
}