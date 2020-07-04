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

public partial class forms_BDStatus : Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CarregarGrid(this.gvUsuario, new Usuario().listar());
        this.CarregarGrid(this.gvConta, new Conta().listar());
        this.CarregarGrid(this.gvCategoria, new Categoria().listar());
        this.CarregarGrid(this.gvProduto, new Produto().listar());
    }
   
    protected void CarregarFilho(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Usuario u = (Usuario)e.Row.DataItem;
            this.CarregarGrid((GridView)e.Row.Cells[3].FindControl("gvConta"), u.contas);
        }
    }
    protected void CarregarCategoria(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Conta c = (Conta)e.Row.DataItem;
            this.CarregarGrid((GridView)e.Row.Cells[0].FindControl("gvCategoria"), c.categorias);
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
}
