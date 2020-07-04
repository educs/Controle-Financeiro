<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
    <asp:Content ContentPlaceHolderID="cphMenu" runat="server">
    <div>
      <table id="tbPortchal" height="300" width="400px">
        <tr>
            <td align="center" >
                <asp:ImageButton ID="imgFinanca" runat="server" ImageUrl="~/imagens/finance.jpg"
                    ToolTip="Controle Financeiro" Width="150px" OnClick="imgFinanca_Click"  />
                &nbsp;&nbsp;
                <br />
                <br />
            </td>
        </tr>
      </table>
    </div>
    </asp:Content>
