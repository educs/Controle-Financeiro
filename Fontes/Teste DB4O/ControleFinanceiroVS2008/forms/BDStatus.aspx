<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="BDStatus.aspx.cs" Inherits="forms_BDStatus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblUsuario" runat="server" Text="Usuários:" />
    <asp:GridView ID="gvUsuario" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="CarregarFilho">
        <Columns>
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Apelido" HeaderText="Apelido" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:TemplateField HeaderText="Conta">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:GridView ID="gvConta" runat="server" onrowdatabound="CarregarCategoria">
                        <Columns>
                            <asp:TemplateField HeaderText="Categoria">
                                <ItemTemplate>
                                    <asp:GridView ID="gvCategoria" runat="server">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvLancamento" runat="server" 
                                                        onrowdatabound="CarregarLancamento"></asp:GridView>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />Contas:<br />
    <asp:GridView ID="gvConta" runat="server" >
    
    </asp:GridView>
    
    <br />Categorias:<br />
    <asp:GridView ID="gvCategoria" runat="server" >
    
    </asp:GridView>
    <br />Produtos: <br />
    <asp:GridView ID="gvProduto" runat="server" >
    </asp:GridView>
</asp:Content>

