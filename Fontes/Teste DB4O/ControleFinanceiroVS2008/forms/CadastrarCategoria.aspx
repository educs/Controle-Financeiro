<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarCategoria.aspx.cs" Inherits="forms_CadastrarCategoria" Title="Cadastro de Categoria" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de Categorias!" CssClass="etiqueta" />
</asp:Content>
<asp:Content id="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
  <tr>
    <td align="right">
        <asp:Label ID="lblConta" runat="server" Text="Selecione a conta: " />
    </td>
    <td align="left">
        <asp:DropDownList ID="ddlConta" runat="server" AutoPostBack="True" 
        DataTextField="descricao"  />
    </td>
  </tr>
  <tr>
    <td align="right">
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição: " />
    </td>
    <td align="left">
        <asp:TextBox ID="txtDescricao" runat="server" />
   </td>
   </tr >
    <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastre-a!" 
                onclick="Clicado" />
            </td>
       </tr>
    </table>
    <asp:UpdatePanel ID="updCadastro" runat="server">
        <ContentTemplate>
        <table width="100%">
           <tr>
                    <td>
                        <asp:Label id="lblMensagem" runat="server" CssClass="etiquetaMensagem"  />
                    </td>
                </tr>
               <tr>
                    <td>
                        <asp:GridView ID="grdCategoria" runat="server" Width="100%" AllowPaging="true" ForeColor="#333333"  >
                            <EmptyDataTemplate>
                                <asp:Label ID="lblGridVazio" runat="server" 
                                    Text="Não há categorias cadastradas."></asp:Label>
                            </EmptyDataTemplate>
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </td>
                </tr>
         </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnCadastrar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
     </table>
</asp:Content> 