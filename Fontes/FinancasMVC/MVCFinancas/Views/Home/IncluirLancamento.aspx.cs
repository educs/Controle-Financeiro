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
using MVCFinancas.Controllers;

namespace MVCFinancas.Views.Home
{

    public partial class IncluirLancamento : Mae
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.VerificarSessao();
            if (!this.IsPostBack)
            {
                this.ddlConta.DataSource = this.Usuario.contas;
                if (((List<Conta>)this.ddlConta.DataSource).Count <= 0)
                    Response.Redirect("CadastrarConta.aspx");
                this.ddlConta.DataBind();
                this.CarregarGrid();
                this.calData.SelectedDate = DateTime.Now;
                //ListItem li = new ListItem("Selecione...", "0");
                //this.ddlConta.Items.Insert(0, li);
                //this.ddlConta_SelectedIndexChanged(sender, e);
            }
        }

        private Usuario Usuario
        {
            get
            {
                return (Usuario)Session["Usuario"];
            }
        }

        private void CarregarGrid()
        {
            this.grdLancamento.DataSource = this.Usuario.lancamentos;
            this.grdLancamento.DataBind();
        }

        protected void ddlConta_SelectedIndexChanged1(object sender, EventArgs e)
        {
            this.ddlCategoria.DataSource = new Conta(this.ddlConta.SelectedItem.Text, this.Usuario).categorias;
            if (((List<Categoria>)this.ddlCategoria.DataSource).Count == 0)
                Response.Redirect("CadastrarCategoria.aspx");
            this.ddlCategoria.DataBind();
        }

        protected void btnCarregar_Click(object sender, EventArgs e)
        {
            this.ddlConta_SelectedIndexChanged1(sender, e);
        }

        protected void Cadastrar(object sender, EventArgs e)
        {
            Lancamento l = FabricaLancamento.fabricarLancamento(this.rbtTipoLancamento.SelectedValue, this.uplComprovante.PostedFile.InputStream);

            l.descricao = this.txtDescricao.Text;
            l.valor = Decimal.Parse(this.txtValor.Text);
            l.data = this.calData.SelectedDate;
            l.registrar();
            this.lblMensagem.Text = "Registrado com sucesso!";
            this.CarregarGrid();
        }

        protected void grdLancamento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Drawing.Image img;
                Lancamento l = (Lancamento)e.Row.DataItem;
                if (l.GetType().Name.Equals("LancamentoCredito"))
                {
                    img = System.Drawing.Image.FromStream(((LancamentoCredito)l).comprovanteCredito);
                    Session["comp"] = ((LancamentoCredito)l).comprovanteCredito;
                }
                else
                {
                    Session["comp"] = ((LancamentoDebito)l).comprovantePagamento;
                    img = System.Drawing.Image.FromStream(((LancamentoDebito)l).comprovantePagamento);
                }
                string name = "comp" + img.GetHashCode().ToString();
                //Session["comp"] = img;
                e.Row.Cells[0].Text = "<a href='ExibirComprovante.aspx?comp=" + name + "'>comprovante</a>";
            }
        }

    }
}