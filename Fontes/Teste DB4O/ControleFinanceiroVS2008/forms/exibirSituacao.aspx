<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="exibirSituacao.aspx.cs" Inherits="forms_exibirSituacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:GridView ID="gvLancamento" runat="server" AutoGenerateColumns="False" 
         onrowdatabound="gvLancamento_RowDataBound" ShowFooter="True" 
         CellPadding="4" ForeColor="#333333" GridLines="None" >
         <RowStyle BackColor="#E3EAEB" />
        <Columns>
            <asp:BoundField DataField="descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="data" HeaderText="Data" />
            <asp:BoundField HeaderText="Valor" />
        </Columns>
         <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
         <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
         <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
         <EditRowStyle BackColor="#7C6F57" />
         <AlternatingRowStyle BackColor="White" />
     </asp:GridView>
</asp:Content>

