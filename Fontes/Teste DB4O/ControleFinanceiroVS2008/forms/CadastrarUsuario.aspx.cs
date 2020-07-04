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

public partial class forms_CadastrarUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.txtNome.Focus();
        }
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.txtEmail.Text != this.txtEmailConfirmado.Text)
            {
                throw new Exception("Email não confirmado!");
            }
            Usuario u = new Usuario();
            u.nome = this.txtNome.Text;
            u.apelido = this.txtApelido.Text;
            u.email = this.txtEmail.Text;
            u.senha = this.txtSenha.Text;
            u.cadastrar();
            Session["Usuario"] = u;
            Response.Redirect("efetuarlogin.aspx");
        }
        catch (Exception erro)
        {
            this.lblMensagem.Text = erro.Message;
        }
    }
}
