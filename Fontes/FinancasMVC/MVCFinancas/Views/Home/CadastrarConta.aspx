<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Views/Master/MasterPage.master"  CodeBehind=" MVCFinancas.Views.Home.CadastrarConta.aspx.cs" 
    Inherits="CadastrarConta" Title="Untitled Page" %>
<asp:Content ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de conta!"  CssClass="etiqueta"/>
</asp:Content>
<asp:Content id="Content" ContentPlaceHolderID="ConteudoConta" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblDesc" runat="server" Text="Descricao" ></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" ></asp:TextBox>
                
            </td>
        </tr>
    </table>


   <asp:Label ID="lblDescricao" runat="server" Text="Descrição: " />
   <asp:TextBox ID="txtDescricao" runat="server" />
   <br />
   <asp:Label ID="lblValor" runat="server" Text="Valor Inicial : " />
   <asp:TextBox ID="txtValor" runat="server" />
   <br />
   <asp:Label id="lblMensagem" runat="server" />
   <br />
   <asp:Button ID="btnCadastrar" runat="server" Text="Cadastre-a!" 
        onclick="Clicou" />
</asp:Content>