<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManterCategoria.aspx.cs" Inherits="ManterCategoria" Title="Categorias" Theme="Tema" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" Runat="Server">
<table border="0" width="400">
    <tr align="center">
        <td>
            <asp:DropDownList runat="server" ID="ddlCategoria" AutoPostBack="True" OnSelectedIndexChanged="MostrarDetalhe" />
            <cc1:DynamicPopulateExtender ID="DynamicPopulateExtender1" runat="server" TargetControlID="pnDetalhe"
                ServiceMethod="MostrarDetalhe" />
        </td>
    </tr>
        <asp:Panel runat="server" ID="pnDetalhe" Visible="false">
        <tr>
            <td style="width: 100px;" colspan="2">
                <asp:RadioButtonList ID="rbtTipo" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0">Receita</asp:ListItem>
                    <asp:ListItem Value="1">Despesa</asp:ListItem>
                </asp:RadioButtonList>
                <asp:DropDownList ID="ddlBem" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 100px">Descrição
            </td>
            <td >
                <asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox>
            </td>
        </tr>
    <tr>
        <td align="center" colspan="2" >
            <asp:Label ID="lbMensagem" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btRegistrar" runat="server" Text="Atualizar!" OnClick="btRegistrar_Click" />
                <asp:Button ID="btExcluir" runat="server" Text="Excluir!" OnClick="btExcluir_Click" />
            </td>
        </tr>
    </asp:Panel>
</table>        
</asp:Content>

