using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for _Mae
/// </summary>
public class _Mae: System.Web.UI.Page
{
    public _Mae()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    protected void _CarregarDropDown(DropDownList ddl, string valor, string texto, IList fonteDados, string incluiOpção)
    {
        ddl.DataSource = fonteDados;
        ddl.DataValueField = valor;
        ddl.DataTextField = texto;
        ddl.DataBind();
        if (fonteDados.Count > 0 && incluiOpção!=String.Empty)
        {
            ddl.Items.Insert(0, incluiOpção);
        }
    }


    protected void _CarregarGrid(GridView grid, IList fonteDados)
    {
        grid.DataSource = fonteDados;
        grid.DataBind();
    }

    protected void _VerificarSessao()
    {
        if (this.Session.IsNewSession)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
