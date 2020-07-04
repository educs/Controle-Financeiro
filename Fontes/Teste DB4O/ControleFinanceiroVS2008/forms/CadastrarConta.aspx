<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage/MasterPage.master" CodeFile="CadastrarConta.aspx.cs" Inherits="forms_CadastrarConta"
 Title="Cadastro da Conta" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Cadastro de conta!"  CssClass="etiqueta"/>
</asp:Content>
<asp:Content id="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
            <tr>
                <td align="right">
                    <asp:Label ID="lblDescricao" runat="server" Text="Descrição: " />
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDescricao" runat="server" />                
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblValor" runat="server" Text="Valor Inicial : " />                    
                </td>
                <td align="left">
                    <asp:TextBox ID="txtValor" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:UpdatePanel ID="upCadastro" runat="server">
                        <ContentTemplate>
                            <asp:Label id="lblMensagem" runat="server" CssClass="etiquetaMensagem"  />   
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnCadastrar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                     <asp:Button ID="btnCadastrar" runat="server" Text="Cadastre-a!" 
                        onclick="Clicou" />
                </td>
            </tr>
     </table>
  </asp:Content>