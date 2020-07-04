using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using financa.model;

public partial class EfetuarLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.txtApelido.Focus();
            if (Session["Usuario"] != null)
            {
                string apelido = ((Usuario)Session["Usuario"]).apelido;
                this.txtApelido.Text = apelido;
                this.lblMensagem.Text = "Usuário " + apelido + " cadastrado com sucesso!";
            }
        }
    }


    protected void btnLogar_Click(object sender, EventArgs e)
    {
        Usuario u = new Usuario();
        if (u.logar(this.txtApelido.Text, this.txtSenha.Text))
        {
            Session["Usuario"] = u;
            Response.Redirect("IncluirLancamento.aspx");
        }
        else
        {
            lblMensagem.Text = "Usuário inválido!";
        }

    }
}
