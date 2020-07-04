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

namespace Web
{
    public partial class _Default : System.Web.UI.Page
    {
        CUsuario usr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.gvUsuarios.DataSource = Usuario.listar();
                this.gvUsuarios.DataBind();
            }
        }

        protected CUsuario Usuario
        {
            get
            {
                if (usr == null)
                    usr = new CUsuario();
                return usr;
            }
            set
            {
                this.usr = value;
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtNome.Text == string.Empty)
                    throw new Exception("Digite o nome do Usuário");
                if (this.txtSenha.Text == string.Empty)
                    throw new Exception("Digite a senha do Usuário");
                Usuario.nome = this.txtNome.Text;
                Usuario.apelido = this.txtApelido.Text;
                Usuario.senha = this.txtSenha.Text;
                Usuario.cadastrar();
                this.lblMensagem.Text = "Usuário cadastrado com sucesso!";
            }
            catch (Exception ERRO)
            {
                this.lblMensagem.Text = ERRO.Message;
            }
        }
    }
}
