using AccesDBGestionProject.Data;
using AccesDBGestionProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationGestionProjects
{
    public partial class GestionEmploye : System.Web.UI.Page
    {
        DPEdbContext dbContext = new DPEdbContext();
        protected void Page_Load(object sender, EventArgs e)
        {

            load_GridView();
            if (!Page.IsPostBack)
            {
                load_dropDown();
            }
            
        }

        private void load_GridView()
        {
            GridViewEmploye.DataSource = (from emp in dbContext.employees
                                          select new
                                          {
                                              emp.employeID,
                                              emp.firstName,
                                              emp.lastName,
                                              emp.email,
                                              emp.phone,
                                              emp.departement.Description
                                          }
                                         ).ToList();
            GridViewEmploye.DataBind();
        }

        private void load_dropDown()
        {
            DDownListDepartement.DataSource = (from dep in dbContext.departements
                                               select dep).ToList();
            DDownListDepartement.DataTextField = "Description";
            DDownListDepartement.DataValueField = "departementID";

            DDownListDepartement.DataBind();
        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
           

            employee.firstName = TBfistName.Text;
            employee.lastName = TBlastName.Text;
            employee.phone = TBphone.Text;
            employee.email = TBemail.Text;
            employee.departementID = int.Parse(DDownListDepartement.SelectedValue.ToString());

            dbContext.employees.Add(employee);
            dbContext.SaveChanges();
            load_GridView();

        }

        protected void BtCherche_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBZoneCherche.Text))
            {
                switch (RBSearch.SelectedValue)
                {
                    case "departement":
                        GridViewEmploye.DataSource = (from emp in dbContext.employees
                                                      where emp.departement.Description == TBZoneCherche.Text
                                                      select emp).ToList();
                        break;
                    case "lastname":
                        GridViewEmploye.DataSource = (from emp in dbContext.employees
                                                      where emp.lastName == TBZoneCherche.Text
                                                      select emp).ToList();
                        break;
                    default:
                        break;
                }
                GridViewEmploye.DataBind();
            }
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Int32 idemp = int.Parse(TBId.Text);
            employee = dbContext.employees.Find(idemp);

            employee.firstName = TBfistName.Text;
            employee.lastName = TBlastName.Text;
            employee.email = TBemail.Text;
            employee.phone = TBphone.Text;
            employee.departementID = int.Parse(DDownListDepartement.SelectedValue.ToString());
            dbContext.SaveChanges();
            load_GridView();

        }

        protected void BtDel_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Int32 idemp = int.Parse(TBId.Text);
            employee = dbContext.employees.Find(idemp);
            dbContext.employees.Remove(employee);
            dbContext.SaveChanges();
            load_GridView();
        }

        protected void GridViewEmploye_SelectedIndexChanged(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            Int32 idemp = int.Parse(GridViewEmploye.SelectedValue.ToString());
            employee = dbContext.employees.Find(idemp);

            TBfistName.Text = employee.firstName;
            TBlastName.Text = employee.lastName;
            TBemail.Text = employee.email;
            TBphone.Text = employee.phone;
            TBId.Text = employee.employeID.ToString();
            DDownListDepartement.SelectedValue = employee.departementID.ToString();
        }
    }
}