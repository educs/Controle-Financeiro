<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EfetuarLogin.aspx.cs" Inherits="EfetuarLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../App_Themes/Tema/Estilo.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmPrincipal" runat="server" class="formPrincipal">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    </div>
    <img src="../imagens/finance.jpg" width="200px" alt="Sistema de Controle e Apoio Financeiro" />
    <table class="tabelinha" >
        <tr>
            <td colspan="2">
                <asp:Label ID="lblTitulo" runat="server" Text="Login" CssClass="etiqueta" />
            </td>
            </tr>
        <tr>
            <td align="right" style="width:50%">
                Apelido ></td>
            <td align="left">
                <asp:TextBox ID="txtApelido" runat="server" ToolTip="Apelido do Usuário" 
                    Width="100px" /></td>
        </tr>
        <tr>
            <td align="right">
                senha ></td>
            <td align="left">
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" 
                    ToolTip="Senha do Usuário" Width="100px" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnLogar" runat="server" onclick="btnLogar_Click" 
                    Text="Logue-se!" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                     <ContentTemplate>
                        <asp:Label ID="lblMensagem" runat="server"  CssClass="etiquetaMensagem"  />
                     </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnLogar" EventName="click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>   
        </tr>
        
        <tr>
            <td colspan="2">
                Não é cadastrado? <a href='CadastrarUsuario.aspx'>Clique aqui</a> e cadastre-se!
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
