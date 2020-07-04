<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Main.aspx.cs" Inherits="Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Freela</title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div>
        <a href="MasterPage.master"></a><table style="width: 333px; height: 1px">
            <tr>
                <td style="width: 100px">
                    <asp:GridView ID="gvNoticia" runat="server" Width="500px">
                    </asp:GridView>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
