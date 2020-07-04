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
using System.Web.Services;
using financa.model;
using financa.model.fabrica;

public partial class forms_IncluirLancamento : Mae
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.VerificarSessao();
        if (!this.IsPostBack){
            this.LimpaTela();
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
        set
        {
            Session["Usuario"] = value;
        }
    }

    private List<Produto> produtos
    {
        get
        {
            if (ViewState["produtos"] == null)
                ViewState["produtos"] = new List<Produto>();

            return (List<Produto>)ViewState["produtos"];
        }
    }

    private Conta contaSelecionada
    {
        get
        {
            return (new Conta(this.ddlConta.SelectedValue, this.Usuario));
        }
    }

    private Categoria categoriaSelecionada
    {
        get
        {
            return contaSelecionada.getCategoria(this.ddlCategoria.SelectedValue);
        }
    }

    private void CarregarGrid()
    {
        Lancamento l = new Lancamento();
        l.usuario = Usuario;
        this.grdLancamento.DataSource = l.listar();
        this.grdLancamento.DataBind();
    }

    private void CarregarCategoria(IList fonte)
    {
        this.ddlCategoria.DataSource = fonte; 
        if (((List<Categoria>)this.ddlCategoria.DataSource).Count == 0)
            Response.Redirect("CadastrarCategoria.aspx");
        this.ddlCategoria.DataBind();
    }
   
    protected void ddlConta_SelectedIndexChanged1(object sender, EventArgs e)
    {
        this.CarregarCategoria(new Conta(this.ddlConta.SelectedItem.Text, this.Usuario).categorias);
       /* this.ddlCategoria.DataSource = new Conta(this.ddlConta.SelectedItem.Text, this.Usuario).categorias;
        if (((List<Categoria>)this.ddlCategoria.DataSource).Count == 0)
            Response.Redirect("CadastrarCategoria.aspx");
        this.ddlCategoria.DataBind();*/
    }

    protected void btnCarregar_Click(object sender, EventArgs e)
    {
        this.ddlConta_SelectedIndexChanged1(sender, e);
    }

    protected void Cadastrar(object sender, EventArgs e)
    {
        long tamanho = this.uplComprovante.PostedFile.InputStream.Length;
        byte[] comp = new byte[tamanho];
        if (this.uplComprovante.HasFile)
            try{
                this.uplComprovante.PostedFile.InputStream.Read(comp, 0, (int)tamanho);
            }catch(Exception erro){
                this.lblMensagem.Text = erro.Message;
            }
        else this.lblMensagem.Text = "Nenhum comprovante anexado.";
        try
        {
            Lancamento l = FabricaLancamento.fabricarLancamento(this.rbtTipoLancamento.SelectedValue, comp);

            //l.valor = Decimal.Parse(this.txtValor.Text);
            l.data = this.calData.SelectedDate;
            if (this.accLancamento.SelectedIndex == 0)
            {
                l.descricao = this.txtDescricao.Text;
            }
            else l.produtos.AddRange(this.produtos);
            l.valor = this.txtValor.Text != string.Empty ? Decimal.Parse(this.txtValor.Text): 0;
            this.categoriaSelecionada.incluirLancamento(l);
            this.LimpaTela();
            this.lblMensagem.Text = "Registrado com sucesso!";
            ViewState["produtos"] = null;
        }
        catch (Exception erro)
        {
            this.lblMensagem.Text = erro.Message;
        }
    }

    protected void grdLancamento_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Drawing.Image img;
            Lancamento l = (Lancamento)e.Row.DataItem;
            img = l.Comprovante;
            if (img == null)
                e.Row.Cells[0].Text = "sem comprovante";
            else
                e.Row.Cells[0].Text = "<a href='ExibirComprovante.aspx?Id=" + l.Id + "&tipo=" + l.GetType().ToString() + "' target='_blank'>Exibir Comprovante</a>";
            e.Row.Cells[3].Text = l.valor.ToString();
        }
    }

    protected void btnIncluir_Click(object sender, EventArgs e)
    {
        Produto p;
        try
        {
            p = new Produto();

            p.Nome = this.txtProduto.Text;
            p.Valor = Decimal.Parse(this.txtValorProduto.Text);
            p.Data = this.calData.SelectedDate;
            p.Quantidade = int.Parse(this.txtQuantidade.Text);
            this.produtos.Add(p);
            this.CarregarGrid(this.gvProdutos, this.produtos);
            this.LimpaProduto();
            this.txtProduto.Focus();
        }
        catch (Exception ERRO)
        {
            this.lblMensagemProduto.Text = ERRO.Message;
        }
        finally
        {
            p = null;
        }
    }

    private void LimpaTela()
    {
        this.rbtTipoLancamento.SelectedIndex = -1;
        this.ddlConta.DataSource = this.Usuario.contas;
        if (((List<Conta>)this.ddlConta.DataSource).Count <= 0)
            Response.Redirect("CadastrarConta.aspx");
        this.ddlConta.DataBind();
        this.CarregarCategoria(new Conta(this.ddlConta.SelectedValue, this.Usuario).categorias);
        this.CarregarGrid();
        this.calData.SelectedDate = DateTime.Now;
        this.txtDescricao.Text = string.Empty;
        this.LimpaProduto();
        this.CarregarGrid(this.gvProdutos, null);
        this.ddlConta.Focus();
    }

    private void LimpaProduto()
    {
        this.txtProduto.Text = string.Empty;
        this.txtValor.Text = string.Empty;
        this.txtValorProduto.Text = string.Empty;
        this.txtQuantidade.Text = string.Empty;
        this.lblMensagem.Text = string.Empty;
    }
} 