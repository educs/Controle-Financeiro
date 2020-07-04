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

public partial class forms_CadastrarConta : Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.VerificarSessao();
        if (!this.IsPostBack)
        {
            this.txtDescricao.Focus();
        }
    }

    private Usuario Usuario
    {
        get
        {
            return (Usuario)Session["Usuario"];
        }
        set
        {
            Session["Usuario"] = value;
        }
    }


    protected void Clicou(object sender, EventArgs e)
    {
        Conta c = new Conta();

        try{
            c.descricao = this.txtDescricao.Text;
            c.valor = Decimal.Parse(this.txtValor.Text);
            this.Usuario = this.Usuario.incluirConta(c);
            this.lblMensagem.Text = "Conta " + c.descricao + " criada com sucesso!";
        }
            catch(FormatException fEr){
                String d = fEr.Message;
                this.lblMensagem.Text = "Dados informados incorretamente. Redigite!";
            }
            catch (Exception er){
                 this.lblMensagem.Text = er.Message;
            }
            finally{
                c = null;
            }

    }
}
