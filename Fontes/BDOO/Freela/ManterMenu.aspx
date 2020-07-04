<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManterMenu.aspx.cs" Inherits="ManterMenu" Title="Manutenção do Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" Runat="Server">
    <div style="text-align: center">
        &nbsp;<table border="0" width="500">
            <tr>
                <td align="right" >
                    <strong>Nome do Item:</strong></td>
                <td align="left" >
                    <asp:TextBox ID="tbNome" runat="server" /></td>
            </tr>
            <tr>
                <td align="right"><strong>
                    Link:</strong></td>
                <td align="left">
                    <asp:TextBox ID="tbLink" runat="server" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                    <asp:Button ID="btIncluir" runat="server" OnClick="btIncluir_Click" Text="Incluir" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                    <asp:Label ID="lbMensagem" runat="server" Font-Bold="True"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:GridView ID="gvMenu" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        Width="500px" OnRowCommand="Selecionar" OnRowDataBound="Carregando">
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField SelectText="Selecionar" ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

