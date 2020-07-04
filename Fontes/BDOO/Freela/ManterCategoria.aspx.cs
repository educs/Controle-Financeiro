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
using Freela.Interface;
using Freela.Controladora;

public partial class ManterCategoria: _Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base._VerificarSessao();
        if (!this.IsPostBack)
        {
            this.AtualizarDropDown();
        }
    }

    private void AtualizarDropDown()
    {
        IBem b = new CBem();
        base._CarregarDropDown(this.ddlCategoria, "codigo", "descricao", (IList)new CCategoria().Selecionar(), "Novo...");
        base._CarregarDropDown(this.ddlBem, "codigo", "descricao", (IList)b.Selecionar(Session["NomeUsuario"].ToString()), "Selecione...");
    }
    protected void btRegistrar_Click(object sender, EventArgs e)
    {
        ICategoria ac;

        try
        {
            ac = new CCategoria(Convert.ToInt32(this.ddlCategoria.SelectedValue));
            ac.Descricao = this.tbDescricao.Text;
            ac.Tipo = Convert.ToByte(this.rbtTipo.SelectedItem.Value);
            ac.Bem.Codigo = Convert.ToInt16(this.ddlBem.SelectedValue);
            ac.Salvar();
            this.lbMensagem.Text = "Categoria <b>" + ac.Descricao + "</b> cadastrada com sucesso.";
        }
        catch (Exception _Erro)
        {
            this.lbMensagem.Text = _Erro.Message;
        }
    }

    protected void btExcluir_Click(object sender, EventArgs e)
    {
        ICategoria ac;

        try
        {
            ac = new CCategoria(Convert.ToInt32(this.ddlCategoria.SelectedValue));
            ac.Excluir();
            this.lbMensagem.Text = "Categoria <b>" + ac.Descricao + "</b> excluída com sucesso!";
        }
        catch (Exception _Erro)
        {
            this.lbMensagem.Text = _Erro.Message;
        }

    }

    protected void MostrarDetalhe(object sender, EventArgs e)
    {
        this.pnDetalhe.Visible = true;
        if (((DropDownList)sender).SelectedIndex != 0)
        {
            ICategoria ac = new CCategoria(Convert.ToInt32(((DropDownList)sender).SelectedValue));
            this.tbDescricao.Text = ac.Descricao;
            this.ddlBem.SelectedValue = ac.Bem.Codigo.ToString();
            this.rbtTipo.SelectedValue = ac.Tipo.ToString();
        }
        else
        {
            this.tbDescricao.Text = String.Empty;
            this.ddlBem.SelectedIndex = -1;
            this.rbtTipo.SelectedIndex = -1;
        }
    }
}
