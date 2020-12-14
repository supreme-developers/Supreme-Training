using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SSIWebTraining.Objects.Models;
using SSIWebTraining.Controllers;

namespace SSIWebTraining.AdminTools
{
    public partial class EditCA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompetencyController cntrl = new CompetencyController();
            rptComps.DataSource = cntrl.GetCompetencyDefinitions();
            rptComps.DataBind();          
        }
    }
}