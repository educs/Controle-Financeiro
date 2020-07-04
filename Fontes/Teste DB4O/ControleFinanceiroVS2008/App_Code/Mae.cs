using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using financa.model;
using financa.model.fabrica;

/// <summary>
/// Summary description for Mae
/// </summary>
public class Mae : System.Web.UI.Page
{
	public Mae()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    protected void VerificarSessao()
    {
        if (Session["Usuario"] == null)
            Response.Redirect("EfetuarLogin.aspx");
    }

    protected void CarregarGrid(GridView grid, IList fonte)
    {
        grid.DataSource = fonte;
        grid.DataBind();
    }
}
