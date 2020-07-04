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

public partial class Lancar : _Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //base._VerificarSessao();
        if (!this.IsPostBack)
        {
            this._AtualizarPagina();
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
    protected void EditarReceita(object sender, GridViewEditEventArgs e)
    {
        CLancamento l = new CLancamento(this.gvReceita.Rows[e.NewEditIndex].Cells[1].Text);
        this.tbDataReceita.Text = l.Data.ToString();
        this.tbDescricaoReceita.Text = l.Descricao;
        this.tbValorReceita.Text = l.Valor.ToString();
        this.ddlCategoriaReceita.SelectedValue = l.Categoria.Codigo.ToString();
    }
}
