<%@ Page Language="C#" MasterPageFile="~/MasterPage/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
CodeFile="IncluirLancamento.aspx.cs" Inherits="forms_IncluirLancamento" Title="Registro de Gastos / Despesas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<script runat="server">
  [System.Web.Services.WebMethod]
  [System.Web.Script.Services.ScriptMethod]
  public static string mostraImagem(string contextKey)
  {
      //p.Response.Output.WriteLine("<a href='ExibirComprovante.aspx'>Exibir Comprovante</a>");
      return "<a href='ExibirComprovante.aspx?Id='" + contextKey + ">Visualizar comprovante</a>";// "<a href='ExibirComprovante.aspx'>Exibir </a>";
  }
</script>
<asp:Content ID="cntCabecalho" ContentPlaceHolderID="head" runat="server">
    <asp:Label ID="lblTitulo" runat="server" Text="Registro de Lançamentos!"  CssClass="etiqueta"/>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
    function selecionarProduto(source, eventArgs)
    {
        var results = eval('('  + eventArgs.get_value() + ')');
        $get('ctl00$ContentPlaceHolder1$ctl07$txtProduto').value = results.Nome;
    }
</script>
    <table id="tblPrincipal">
    <tr>
        <td>
            <asp:UpdatePanel ID="upCalendario" runat="server">
                <ContentTemplate>
                    <asp:Calendar ID="calData" runat="server" BackColor="White" BorderColor="#5D7B9D" 
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" 
                        Height="190px" NextPrevFormat="FullMonth" Width="350px"  >
                        <SelectedDayStyle BackColor="#5D7B9D" ForeColor="White" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                            VerticalAlign="Bottom" />
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <TitleStyle BackColor="#5D7B9D" BorderColor="Black" BorderWidth="4px" 
                        Font-Bold="True" Font-Size="12pt" ForeColor="#FFFFFF" />
                    </asp:Calendar>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="calData" EventName="SelectionChanged" />
                </Triggers>
            </asp:UpdatePanel>
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
                    <td align="right">
                         <asp:Label ID="lblConta" Text="Conta" runat="server" />
                   </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlConta" runat="server" AutoPostBack="True" 
                            DataTextField="descricao" 
                            OnSelectedIndexChanged="ddlConta_SelectedIndexChanged1" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="lblCategoria" runat="server" Text="Categoria" />
                    </td>
                    <td align="left">
                        <asp:UpdatePanel ID="upCategoria" runat="server">
                            <ContentTemplate>
                                    <asp:DropDownList ID="ddlCategoria" runat="server"
                                    DataTextField="descricao" AutoPostBack="True" />
                             </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlConta" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>        
                    </td>   
                </tr>
             </table>
                <ajaxToolkit:Accordion 
                    ID="accLancamento"
                    runat="server"
                    SelectedIndex="0"
                    HeaderCssClass="accordionHeader"
                    HeaderSelectedCssClass="accordionHeaderSelected"
                    ContentCssClass="accordionContent"
                    AutoSize="None"
                    FadeTransitions="true"
                    TransitionDuration="250"
                    FramesPerSecond="40"
                    RequireOpenedPane="true"
                    SuppressHeaderPostbacks="true">
                    <Panes>
                        <ajaxToolkit:AccordionPane runat="server"
                            HeaderCssClass="accordionHeader"
                            HeaderSelectedCssClass="accordionHeaderSelected"
                            ContentCssClass="accordionContent">
                           <Header>Genérico</Header>
                            <Content>
                            <table>
                                 <tr>
                                    <td align="right">
                                        <asp:Label ID="lblDescricao" runat="server" Text="Breve descrição..." />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDescricao" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblValor" runat="server" Text="Valor Total" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtValor" runat="server" />
                                        <ajaxToolkit:MaskedEditExtender ID="mskValor"
                                            runat="server" DisplayMoney="Left" MaskType="Number" Mask="999,999.99" 
                                            TargetControlID="txtValor" InputDirection="RightToLeft" CultureName="pt-BR"  >
                                        </ajaxToolkit:MaskedEditExtender>
                                    </td>
                                </tr>
                                </table>
                            </Content>
                            </ajaxToolkit:AccordionPane>
                            <ajaxToolkit:AccordionPane 
                                runat="server"
                                HeaderCssClass="accordionHeader"
                                HeaderSelectedCssClass="accordionHeaderSelected"
                                ContentCssClass="accordionContent">
                                <Header>Detalhado</Header>
                                <Content>
                                <table>
                                    <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="upProduto" runat="server">
                                            <ContentTemplate>
                                                <table border="1" style="border-color:Black">
                                                    <tr>
                                                        <td align="right">
                                                            Produto:
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtProduto" runat="server"></asp:TextBox>
                                                            &nbsp;x
                                                            <ajaxToolkit:AutoCompleteExtender 
                                                                runat="server" 
                                                                ID="compDescricao" 
                                                                TargetControlID="txtProduto"
                                                                ServicePath="completaProduto.asmx"
                                                                ServiceMethod="listarProduto"
                                                                MinimumPrefixLength="1" 
                                                                CompletionInterval="1000"
                                                                EnableCaching="true"
                                                                CompletionSetCount="20" 
                                                                CompletionListCssClass="autocomplete_completionListElement" 
                                                                CompletionListItemCssClass="autocomplete_listItem" 
                                                                CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                                                                DelimiterCharacters=";, :"
                                                                OnClientItemSelected="selecionarProduto"
                                                                >
                                                            </ajaxToolkit:AutoCompleteExtender>
                                                            <asp:TextBox ID="txtQuantidade" runat="server" Width="40px"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblValorProduto" runat="server">Valor Unitário:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                                <asp:TextBox ID="txtValorProduto" runat="server" />
                                                                <ajaxToolkit:MaskedEditExtender ID="mskValorProduto" runat="server" DisplayMoney="Left" 
                                                                    MaskType="Number" Mask="999,999.99" TargetControlID="txtValorProduto" InputDirection="RightToLeft"  >
                                                                </ajaxToolkit:MaskedEditExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label id="lblMensagemProduto" runat="server" /><br />
                                                            <asp:Button ID="btnIncluir" Text="Incluir" runat="server" 
                                                                onclick="btnIncluir_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="gvProdutos" runat="server" Width="100%" CellPadding="4" 
                                                                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" >
                                                                <Columns>
                                                                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                                                    <asp:BoundField DataField="Valor" HeaderText="Valor" />
                                                                </Columns>
                                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                                <EmptyDataTemplate>
                                                                    <asp:Label ID="lblSemProduto" runat="server" 
                                                                        Text="Não há registro de produtos para esse lançamento."></asp:Label>
                                                                </EmptyDataTemplate>
                                                                
                                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                                <EditRowStyle BackColor="#999999" />
                                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                                
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="btnIncluir" EventName="Click" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                   </table>
                                </Content>
                            </ajaxToolkit:AccordionPane>
                            </Panes>
                            </ajaxToolkit:Accordion>
                            <table>
                                <tr>
                                    <td>
                                        Comprovante</td>
                                    <td>
                                        <asp:FileUpload ID="uplComprovante" runat="server"   />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                         <asp:Button ID="btnCadastrar" runat="server" Text="Lançar!" 
                                            onclick="Cadastrar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                    <td colspan="2">
                              <asp:Label id="lblMensagem" runat="server" CssClass="etiquetaMensagem"  />
                                <br />
                                <asp:GridView ID="grdLancamento" runat="server" Width="100%" AutoGenerateColumns="False"
                                    onrowdatabound="grdLancamento_RowDataBound" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None"  >
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                       
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblImagem" runat="server" Text="Visualizar Comprovante" ></asp:Label>
                                                  <ajaxToolkit:HoverMenuExtender 
                                                    ID="hm1" runat="server" 
                                                    TargetControlID="lblImagem" 
                                                    PopupControlID="pnlImagem" 
                                                    PopupPosition="Top"
                                                    DynamicControlID="lblImagem"
                                                    DynamicContextKey='<%# HttpUtility.HtmlEncode(Convert.ToString(Eval("Id"))) %>'
                                                    DynamicServiceMethod="mostraImagem"
                                                      />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="descricao" HeaderText="Descrição" />
                                        <asp:BoundField DataField="data" HeaderText="Data" />
                                        <asp:BoundField HeaderText="Valor" />
                                    </Columns>
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <EmptyDataTemplate>
                                        <asp:Label ID="lblSemLancamento" runat="server" 
                                            Text="Não há registro de lançamentos."></asp:Label>
                                    </EmptyDataTemplate>
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    
                                </asp:GridView>
                    </td>
                </tr>
    </table>
            <asp:Panel ID="pnlImagem" runat="server"> Teste</asp:Panel>
 
 </asp:Content>

