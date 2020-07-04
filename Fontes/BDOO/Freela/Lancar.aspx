<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Lancar.aspx.cs" Inherits="Lancar" Title="Lançamentos" Theme="Tema" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" Runat="Server">
    <table border="0">
        <tr>
            <td style="width: 100px;" colspan="2">
                <asp:ScriptManager ID="sm" runat="server" />
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="400px">
                    <cc1:TabPanel ID="tpReceita" runat="server" HeaderText="Receita" >
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="upReceita">
                                <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px" align=right>Descrição</TD><TD style="WIDTH: 100px" colSpan=3><asp:TextBox id="tbDescricaoReceita" runat="server" Width="250px"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 100px" align=right>Valor</TD><TD style="WIDTH: 100px"><asp:TextBox id="tbValorReceita" runat="server" Width="100px"></asp:TextBox> </TD><TD style="WIDTH: 100px" align=right><asp:Label id="lbDataReceita" runat="server" Text="Data"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="tbDataReceita" runat="server" Width="100px"></asp:TextBox> <cc1:CalendarExtender id="ceDataReceita" runat="server" TargetControlID="tbDataReceita" Format="d MMMM, yyyy" PopupButtonID="Image1"></cc1:CalendarExtender> </TD></TR><TR><TD align=right>Categoria</TD><TD colSpan=3><asp:DropDownList id="ddlCategoriaReceita" runat="server" Width="200px"></asp:DropDownList> </TD></TR><TR><TD align=center colSpan=4>&nbsp; <asp:Button id="BtLancarReceita" onclick="BtLancar_Click" runat="server" Text="Lançar!"></asp:Button> </TD></TR><TR><TD colSpan=4><asp:GridView id="gvReceita" runat="server" Width="100%" ForeColor="#333333" HeaderStyle-BackColor="DarkBlue" GridLines="None" CellPadding="4" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnRowEditing="EditarReceita">
<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

<RowStyle BackColor="#E3EAEB"></RowStyle>
<Columns>
    <asp:CommandField EditText="Editar" ShowCancelButton="False" ShowEditButton="True" />
    <asp:BoundField DataField="codigo" ReadOnly="True" />
    <asp:BoundField DataField="descricao" HeaderText="Descri&#231;&#227;o" />
<asp:BoundField DataField="valor" DataFormatString="{0:c}" HeaderText="Valor"></asp:BoundField>
<asp:BoundField DataField="data" DataFormatString="{0:d}" HeaderText="Data"></asp:BoundField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#7C6F57"></EditRowStyle>

<AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
</asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel ID="tpDespesa" runat="server" HeaderText="Despesa">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="upDespesa">
                                <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px" align=right>Descrição</TD><TD style="WIDTH: 100px" colSpan=3><asp:TextBox id="tbDescricaoDespesa" runat="server" Width="250px"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 100px" align=right>Valor</TD><TD><asp:TextBox id="tbValorDespesa" runat="server" Width="100px"></asp:TextBox> </TD><TD align=right><asp:Label id="lbDataDespesa" runat="server" Text="Data"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="tbDataDespesa" runat="server" Width="100px"></asp:TextBox> <cc1:CalendarExtender id="ceDataDespesa" runat="server" PopupButtonID="Image1" Format="d MMMM, yyyy" TargetControlID="tbDataDespesa"></cc1:CalendarExtender> </TD></TR><TR><TD align=right>Categoria</TD><TD style="WIDTH: 177px" colSpan=3><asp:DropDownList id="ddlCategoriaDespesa" runat="server" Width="200px"></asp:DropDownList> </TD></TR><TR><TD align=center colSpan=4><asp:Button id="BtLancarDespesa" onclick="BtLancar_Click" runat="server" Text="Lançar!"></asp:Button> </TD></TR><TR><TD colSpan=4><asp:GridView id="gvDespesa" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" HeaderStyle-BackColor="DarkBlue" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False">
                                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#E3EAEB" />
                                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="Navy" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#7C6F57" />
                                                <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField EditText="Editar" ShowCancelButton="False" ShowEditButton="True" />
        <asp:BoundField DataField="descricao" HeaderText="Descri&#231;&#227;o" />
        <asp:BoundField DataField="valor" DataFormatString="{0:c}" HeaderText="Valor" />
        <asp:BoundField DataField="data" DataFormatString="{0:d}" HeaderText="Data" />
    </Columns>
                                            </asp:GridView> </TD></TR></TBODY></TABLE>
</ContentTemplate>
                            </asp:UpdatePanel>
                        </ContentTemplate>
                    </cc1:TabPanel>
                </cc1:TabContainer>
           </td>
        </tr>
    </table>
</asp:Content>