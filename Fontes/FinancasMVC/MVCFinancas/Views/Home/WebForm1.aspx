<%@ Page Language="C#" MasterPageFile="~/Views/Master/MasterPage.master" AutoEventWireup="true" 
CodeBehind="WebForm1.aspx.cs" Inherits="MVCFinancas.Views.Home.WebForm1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Categorias!" CssClass="etiqueta" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ConteudoLancamento" runat="server">
  <table id="tblPrincipal" class="tabelinha">
  <tr>
    <td>
        <asp:Label ID="lblConta" runat="server" Text="Selecione a conta: " />
    </td>
    <td>
        <asp:DropDownList ID="ddlConta" runat="server">
        </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td>
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição: " />
    </td>
    <td>
        <asp:TextBox ID="txtDescricao" runat="server" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
        <asp:Label id="lblMensagem" runat="server" />
    </td>
  </tr>
  <tr>
    <td colspan="2">
         <asp:Button ID="btnCadastrar" runat="server" Text="Cadastre-a!" 
        onclick="Clicado" />
    </td>
  </tr>
 </table>
 <table id="tblGrid" class="tabelinha">
    <tr>
        <td>
            <asp:GridView ID="grdCategoria" runat="server" Width="700px">
                <EmptyDataTemplate>
                    <asp:Label ID="lblGridVazio" runat="server" 
                        Text="Não há categorias cadastradas."></asp:Label>
                </EmptyDataTemplate>
            
            </asp:GridView>
        </td>
    </tr>
 </table>
</asp:Content> 