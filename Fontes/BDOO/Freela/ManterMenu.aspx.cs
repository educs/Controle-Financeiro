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
using System.Xml;
using Freela.Interface;
using Freela.Controladora;

public partial class ManterMenu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.CarregarGrid();
        }
    }
    protected void btIncluir_Click(object sender, EventArgs e)
    {
        IMenu ac = new CManterMenu();
        IMenu menu = new CManterMenu();

        menu.Nome = this.tbNome.Text;
        menu.Link = this.tbLink.Text;
        if (ac.GravarItem(menu) > 0)
        {
            this.lbMensagem.Text = "Incluído com sucesso.";
            this.CarregarGrid();
        }
    }

    private void CarregarGrid()
    {
        IMenu ac = new CManterMenu();
        XmlDocument x = new XmlDocument();
        x.LoadXml("D:\\Fontes\\Freela\\Web.sitemap");

        this.gvMenu.DataSource = ac.Consultar(x);
        this.gvMenu.DataBind();
    }

    protected void Selecionar(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Carregando(object sender, GridViewRowEventArgs e)
    {
        string t;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[2].Text = "Link";
            e.Row.Cells[3].Text = "Título";
            e.Row.Cells[4].Text = "Descrição";
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text == "")
                e.Row.Visible = false;
            //else if (e.Row.Cells[5].Text != 0)
                    
            t = e.Row.Cells[1].Text;
            t += e.Row.Cells[5].Text;
        }
        e.Row.Cells[1].Visible = false;
        e.Row.Cells[5].Visible = false;
    }
}
