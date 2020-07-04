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

public partial class WizardLancamento : _Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Session["NomeUsuario"] = "du";
            this.AtualizarDropDown();
            //this.wzLancamento.MoveTo(this.wzLancamento.WizardSteps[1]);
        }
        //else this.wzLancamento.MoveTo(this.wzLancamento.WizardSteps[2]);
    }

    private void AtualizarDropDown()
    {
        IBem b = new CBem();
        base._CarregarDropDown(this.ddlCategoria, "codigo", "descricao", (IList)new CCategoria().Selecionar(), "Novo...");
        base._CarregarDropDown(this.ddlBem, "codigo", "descricao", (IList)b.Selecionar(Session["NomeUsuario"].ToString()), "Selecione...");
    }

    public static void MostrarDetalhe(TextBox controle)
    {
        //if (controle.SelectedIndex != 0)
        //{
        //ICategoria ac = new CCategoria(Convert.ToInt32(this.ddlCategoria.SelectedValue));
        //controle.Text = ac.Descricao;
        //    this.tbDescricao.Text = ac.Descricao;
        //    this.ddlBem.SelectedValue = ac.Bem.Codigo.ToString();
        //    this.rbtTipo.SelectedValue = ac.Tipo.ToString();
        //}
        //else
        //{
        //    this.tbDescricao.Text = String.Empty;
        //    //this.ddlBem.SelectedIndex = -1;
        //    this.rbtTipo.SelectedIndex = -1;
        //}
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
            //this.ddlBem.SelectedIndex = -1;
            this.rbtTipo.SelectedIndex = -1;
        }
    }

    protected void EditarReceita(object sender, GridViewEditEventArgs e)
    {
        CLancamento l = new CLancamento(this.gvReceita.Rows[e.NewEditIndex].Cells[1].Text);
        this.tbDataReceita.Text = l.Data.ToString();
        this.tbDescricaoReceita.Text = l.Descricao;
        this.tbValorReceita.Text = l.Valor.ToString();
        this.ddlCategoriaReceita.SelectedValue = l.Categoria.Codigo.ToString();
    }

    private void _AtualizarPagina()
    {
        ILancamento l = new CLancamento();
        ICategoria c = new CCategoria();
        string valor, texto;
        valor = "codigo";
        texto = "descricao";

        try
        {
            base._CarregarGrid(this.gvReceita, (IList)l.Selecionar((byte)0));
            base._CarregarGrid(this.gvDespesa, (IList)l.Selecionar((byte)1));
            base._CarregarDropDown(this.ddlCategoriaReceita, valor, texto, (IList)c.Selecionar((byte)0), "Selecione...");
            base._CarregarDropDown(this.ddlCategoriaDespesa, valor, texto, (IList)c.Selecionar((byte)1), "Selecione...");
        }
        catch (Exception _Erro)
        {
        }
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

    protected void BtLancar_Click(object sender, EventArgs e)
    {
        ILancamento lanc = new CLancamento();
        //byte tipo = 0;

        if (((Button)sender).ID == "BtLancarReceita")
        {
            lanc.Descricao = this.tbDescricaoReceita.Text;
            lanc.Valor = Convert.ToDecimal(this.tbValorReceita.Text);
            lanc.Categoria = new CCategoria(Convert.ToInt16(this.ddlCategoriaReceita.SelectedValue));
        }
        else
        {
            lanc.Descricao = this.tbDescricaoDespesa.Text;
            lanc.Valor = Convert.ToDecimal(this.tbValorDespesa.Text);
            lanc.Categoria = new CCategoria(Convert.ToInt16(this.ddlCategoriaDespesa.SelectedValue));
        }
        lanc.Data = DateTime.Now;
        //if (this.tpReceita.Enabled)
        //    tipo = 2;
        //else if (this.tpDespesa.Enabled)
        //    tipo = 1;
        lanc.Lancar();
        this._AtualizarPagina();
    }
}
