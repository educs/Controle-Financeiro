using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class forms_CadastrarCategoria : Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.VerificarSessao();
        if (!this.IsPostBack)
        {
            this.ddlConta.DataSource = this.Usuario.contas;
            if (((List<Conta>)this.ddlConta.DataSource).Count <= 0)
                Response.Redirect("CadastrarConta.aspx");
            this.ddlConta.DataBind();
            this.txtDescricao.Focus();
        }
        this.CarregarGrid(this.grdCategoria, new Conta(this.ddlConta.SelectedItem.Text, (Usuario)Session["Usuario"]).categorias);
    }

    private Usuario Usuario
    {
        get
        {
            return (Usuario)Session["Usuario"];
        }
    }

    protected void Clicado(object sender, EventArgs e)
    {
        try
        {
            Categoria cat = new Categoria();

            Conta c = this.Usuario.contas.Find(comecaCom);
            cat.descricao = this.txtDescricao.Text;
            c.adicionarCategoria(cat);
            this.lblMensagem.Text = "Categoria " + cat.descricao + " cadastrada com sucesso!";
            this.CarregarGrid(this.grdCategoria, new Conta(this.ddlConta.SelectedItem.Text, (Usuario)Session["Usuario"]).categorias);
        }
        catch (Exception erro)
        {
            this.lblMensagem.Text = erro.Message;
        }
    }

    private bool comecaCom(Conta c)
    {
        return (this.ddlConta.SelectedItem.Text == c.descricao);
    }

}
