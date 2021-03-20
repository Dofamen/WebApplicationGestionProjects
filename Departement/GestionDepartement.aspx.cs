using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.DynamicData;
using AccesDBGestionProject.Data;
using AccesDBGestionProject.Models;
using AccesDBGestionProject;

namespace WebApplicationGestionProjects.Departement
{
    
    public partial class GestionDepartement : System.Web.UI.Page
    {
        DPEdbContext dbContext = new DPEdbContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewDepartement.DataSource = (from dep in dbContext.departements
                                              select dep).ToList();
            GridViewDepartement.DataBind();
        }

        protected void BtAdd_Click(object sender, EventArgs e)
        {
            AccesDBGestionProject.Models.Departement newdep = new AccesDBGestionProject.Models.Departement();

            newdep.Description = TBDescription.Text;
            newdep.Ville = TBVille.Text;
            dbContext.departements.Add(newdep);
            dbContext.SaveChanges();
            
        }

        protected void GridViewDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            AccesDBGestionProject.Models.Departement newdep = new AccesDBGestionProject.Models.Departement();

            Int32 iddep = int.Parse(GridViewDepartement.SelectedValue.ToString());
            newdep = dbContext.departements.Find(iddep);

            TBDescription.Text = newdep.Description.ToString();
            TBId.Text = newdep.departementID.ToString();
            TBVille.Text = newdep.Ville.ToString();
            
        }

        protected void BtUpdate_Click(object sender, EventArgs e)
        {
            AccesDBGestionProject.Models.Departement newdep = new AccesDBGestionProject.Models.Departement();

            Int32 iddep = int.Parse(TBId.Text.ToString());
            newdep = dbContext.departements.Find(iddep);

            newdep.Ville = TBVille.Text;
            newdep.Description = TBDescription.Text;

            dbContext.SaveChanges();
        }

        protected void BtDel_Click(object sender, EventArgs e)
        {
            AccesDBGestionProject.Models.Departement newdep = new AccesDBGestionProject.Models.Departement();

            Int32 iddep = int.Parse(TBId.Text.ToString());
            newdep = dbContext.departements.Find(iddep);

            dbContext.departements.Remove(newdep);
            dbContext.SaveChanges();
        }

        protected void BtCherche_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TBZoneCherche.Text))
            {
                switch (RBSearch.SelectedValue)
                {
                    case "Description":
                        GridViewDepartement.DataSource = (from dep in dbContext.departements
                                                          where dep.Description == TBZoneCherche.Text
                                                          select dep).ToList();
                        break;
                    case "Ville":
                        GridViewDepartement.DataSource = (from dep in dbContext.departements
                                                          where dep.Ville == TBZoneCherche.Text
                                                          select dep).ToList();
                        break;
                    default:
                        break;
                }
                GridViewDepartement.DataBind();
            }
            
            
        }
    }
}