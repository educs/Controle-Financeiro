using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using financa.model;

public partial class forms_exibirSituacao : Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.VerificarSessao();
        totalizador = 0;
        if (!this.IsPostBack)
        {
            Lancamento l = new Lancamento();
            l.usuario = Usuario;
            this.gvLancamento.DataSource = l.listar();
            this.gvLancamento.DataBind();
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
    protected void carregarFilho(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Conta c = (Conta)e.Row.DataItem;
            this.CarregarGrid((GridView)e.Row.Cells[1].FindControl("gvCategoria"), c.categorias);
        }
    }

    protected void CarregarCategoria(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Categoria c = (Categoria)e.Row.DataItem;
            this.CarregarGrid((GridView)e.Row.Cells[1].FindControl("gvLancamento"), c.lancamentos);
        }
    }

    protected void CarregarLancamento(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Categoria c = (Categoria)e.Row.DataItem;
            this.CarregarGrid((GridView)e.Row.Cells[0].FindControl("gvLancamento"), c.lancamentos);
        }
    }

    private decimal totalizador
    {
        get
        {
            if (ViewState["Total"] == null)
                ViewState["Total"] = decimal.MinValue;
            return (decimal)ViewState["Total"];
        }
        set
        {
            ViewState["Total"] = value;
        }
    }
    protected void gvLancamento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Lancamento l = (Lancamento)e.Row.DataItem;
            e.Row.Cells[2].Text = l.valor.ToString();
            totalizador += l.valor;
        }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[2].Text = totalizador.ToString();
        }
    }
}
