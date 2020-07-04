<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CadastrarUsuario.aspx.cs" Inherits="forms_CadastrarUsuario" Title="Cadastre-se!" %>
    <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
  <html>
    <head id="Head1" runat="server">
        <title>Cadastro de Usuário</title>
        <link href="../App_Themes/Tema/Estilo.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
    <form id="frmPrincipal" runat="server" class="formPrincipal">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    </div>
    <img src="../imagens/finance.jpg" width="200px" alt="Sistema de Controle e Apoio Financeiro" />
        <table class="tabelinha">
            <tr>
                <td align="right" style="width:50%">
                    <asp:Label ID="lblNome" runat="server" Text="Nome > " />
               </td>
               <td align="left">
                       <asp:TextBox ID="txtNome" runat="server" Width="200px" />
               </td>
           </tr>
           <tr>
               <td align="right">
                       <asp:Label ID="lblApelido" runat="server" Text="Usuário > " />
              </td>
               <td align="left">
                       <asp:TextBox ID="txtApelido" runat="server" Width="100px" />
              </td>
           </tr>
           <tr>
               <td align="right">
                       <asp:Label ID="lblSenha" runat="server" Text="Senha > "  />
               </td>
               <td align="left">
                       <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" Width="100px" />
               </td>
           </tr>
           <tr>
               <td align="right">
                       <asp:Label ID="lblEmail" runat="server" Text="Email > " />
               </td>
               <td align="left">
                       <asp:TextBox ID="txtEmail" runat="server" Width="200px" />
               </td>
           </tr>
           <tr>
               <td align="right">
                       <asp:Label ID="lblEmailConfirmado" runat="server" Text="Confirme o Email > " />
               </td>
               <td align="left">
                       <asp:TextBox ID="txtEmailConfirmado" runat="server" Width="200px" />
               </td>
           </tr>
           <tr>
               <td colspan="2" align="center">
                       <asp:Label id="lblMensagem" runat="server" CssClass="etiquetaMensagem" />
               </td>
           </tr>
           <tr>
               <td colspan="2" align="center">
                       <asp:Button ID="btnCadastrar" runat="server" Text="Cadastre-se!" 
                        onclick="btnCadastrar_Click" />
                   </td>
              </tr>
          </table>
      </form>
</body>
</html>
