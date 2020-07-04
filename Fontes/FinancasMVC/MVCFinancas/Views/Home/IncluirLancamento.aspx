<%@ Page Language="C#" MasterPageFile="~/Views/Master/MasterPage.master"  AutoEventWireup="true" 
CodeBehind="IncluirLancamento.aspx.cs" Inherits="MVCFinancas.View.Home.IncluirLancamento" Title="Registro de Gastos / Despesas" %>
<asp:Content ID="cntCabecalho" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Registro de Lançamentos!"  CssClass="etiqueta"/>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ConteudoLancamento" Runat="Server">
<table id="tblPrincipal" class="tabelinha">
    <tr>
        <td>
            <asp:Calendar ID="calData" runat="server" BackColor="White" BorderColor="White" 
                BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" 
                Height="190px" NextPrevFormat="FullMonth" Width="350px" >
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TodayDayStyle BackColor="#CCCCCC" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                    VerticalAlign="Bottom" />
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                    Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
            </asp:Calendar>
       </td>
       <td>
            <table id="tblLancamento">
                <tr>
                    <td colspan="2">
                         <asp:RadioButtonList ID="rbtTipoLancamento" runat="server" 
                             RepeatDirection="Horizontal" >
                             <asp:ListItem Value="C">Crédito</asp:ListItem>
                             <asp:ListItem Value="D">Débito</asp:ListItem>
                         </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                         <asp:Label ID="lblConta" Text="Conta" runat="server" />
                   </td>
                    <td>
                        <asp:DropDownList ID="ddlConta" runat="server" AutoPostBack="True" 
                            DataTextField="descricao" 
                            OnSelectedIndexChanged="ddlConta_SelectedIndexChanged1" />
                        <asp:Button ID="btnCarregar" runat="server" onclick="btnCarregar_Click" 
                            Text="..." />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCategoria" runat="server" Text="Categoria" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategoria" runat="server"
                        DataTextField="descricao" />
                    </td>            
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescricao" runat="server" Text="Breve descrição..." />
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValor" runat="server" Text="Quanto?" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtValor" runat="server" />
                        <cc1:maskededitextender ID="mskValor" runat="server" DisplayMoney="Left" 
                            MaskType="Number" Mask="999,999.99" TargetControlID="txtValor" 
                            InputDirection="RightToLeft"  >
                        </cc1:maskededitextender>
                    </td>
                </tr>
                <tr>
                    <td>
                        Comprovante</td>
                    <td>
                        <input id="uplComprovante" type="file" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                         <asp:Button ID="btnCadastrar" runat="server" Text="Lançar!" 
                            onclick="Cadastrar" />
                            <br />
                             <asp:Label id="lblMensagem" runat="server" />
                    </td>
                </tr>
                
            </table>
          </td>
       </tr>
       <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdLancamento" runat="server" Width="100%" 
                            onrowdatabound="grdLancamento_RowDataBound"  >
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Image ID="imgComprovante" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <asp:Label ID="lblSemLancamento" runat="server" 
                                    Text="Não há registro de lançamentos."></asp:Label>
                            </EmptyDataTemplate>
                            
                        </asp:GridView>
                    </td>
                </tr>
   </table>
</asp:Content>

