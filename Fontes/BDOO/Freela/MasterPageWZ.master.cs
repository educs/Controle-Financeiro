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
using Freela.Controladora;
using Freela.Interface;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.Session.IsNewSession)
        {
            this.pnLogado.Visible = true;
            this.setUsuario(Session["NomeUsuario"].ToString());
            this.Login.Visible = false;
        }
    }

    public void setUsuario(string value)
    {
        this.lbUsuario.Text = value;
    }

    protected void Logar(object sender, EventArgs e)
    {
        Session["NomeUsuario"] = this.Login.UserName.ToLower();
        Response.Redirect("lancar.aspx");
    }
    protected void BtSair_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        this.Login.Visible = true;
        this.pnLogado.Visible = false;
        Response.Redirect("default.aspx");
    }
}
