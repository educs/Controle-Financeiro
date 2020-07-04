<%@ Page Language="C#" MasterPageFile="~/MasterPageWZ.master" AutoEventWireup="true" CodeFile="WizardLancamento.aspx.cs" Inherits="WizardLancamento" Title="Controle Financeiro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" Runat="Server">
  <asp:ScriptManager ID="sm" runat="server" />
    <table border="0">
        <tr>
            <td style="width: 100px;" colspan="2">
                <asp:Wizard ID="wzLancamento" runat="server" ActiveStepIndex="2" BackColor="#EFF3FB" BorderColor="#B5C7DE" 
                    BorderWidth="1px" HeaderText="Controle Financeiro"  FinishPreviousButtonText="Anterior" FinishPreviousButtonType="Image" StepPreviousButtonImageUrl="~/imagens/previous.PNG"
                     Font-Names="Verdana" Font-Size="0.8em" StepNextButtonText="Próximo" StepNextButtonType="Image" StepNextButtonImageUrl="~/imagens/next.PNG"
                     StepPreviousButtonText="Anterior" StepPreviousButtonType="Image" Width="500px" FinishPreviousButtonImageUrl="~/imagens/voltar.PNG" FinishPreviousButtonStyle-Width="30px" FinishPreviousButtonStyle-Height="15px" >
                    <WizardSteps>
                        <asp:WizardStep ID="stpConta" runat="server" Title="Cadastrar a Conta" StepType="Start" >
                        </asp:WizardStep>
                        <asp:WizardStep ID="stpCategoria" runat="server" Title="Cadastrar Categoria" StepType="step">
                            <asp:DropDownList ID="ddlCategoria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MostrarDetalhe" />
                            <asp:Panel runat="server" ID="pnDetalhe" >
                            <table>
                            <tr>
                                <td style="width: 100px;" colspan="2">
                                    <asp:RadioButtonList ID="rbtTipo" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="0">Receita</asp:ListItem>
                                        <asp:ListItem Value="1">Despesa</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:DropDownList ID="ddlBem" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 100px">Descrição
                                </td>
                                <td >
                                    <asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" >
                                    <asp:Label ID="lbMensagem" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btRegistrar" runat="server" Text="Atualizar!" OnClick="btRegistrar_Click" />
                                    <asp:Button ID="btExcluir" runat="server" Text="Excluir!" OnClick="btExcluir_Click" />
                                </td>
                            </tr>
                            </table>
                        </asp:Panel>
                        </asp:WizardStep>
                        <asp:WizardStep ID="stpLancamento" runat="server" Title="Efetuar Lan&#231;amento" StepType="Finish">
                            <table border="0">
                                <tr>
                                    <td style="width: 100px;" colspan="2">
                                    <ajax:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="400px">
                                        <ajax:TabPanel ID="tpReceita" runat="server" HeaderText="Receita" >
                                            <ContentTemplate>
                                                <asp:UpdatePanel runat="server" ID="upReceita">
                                                    <ContentTemplate>
                                                        <TABLE><TBODY><TR>
                                                             <TD style="WIDTH: 100px" align=right>Descrição</TD>
                                                             <TD style="WIDTH: 100px" colSpan=3>
                                                                <asp:TextBox id="tbDescricaoReceita" runat="server" Width="250px" />
                                                             </TD>
                                                            </TR>
                                                            <TR><TD style="WIDTH: 100px" align=right>Valor</TD><TD style="WIDTH: 100px"><asp:TextBox id="tbValorReceita" runat="server" Width="100px" __designer:wfdid="w101"></asp:TextBox> </TD><TD style="WIDTH: 100px" align=right><asp:Label id="lbDataReceita" runat="server" Text="Data" __designer:wfdid="w102">
                                                            </asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="tbDataReceita" runat="server" Width="100px" __designer:wfdid="w103"></asp:TextBox> <ajax:CalendarExtender id="ceDataReceita" runat="server" TargetControlID="tbDataReceita" Format="d MMMM, yyyy" PopupButtonID="Image1">
                                                            </ajax:CalendarExtender> </TD></TR><TR><TD align=right>Categoria</TD><TD colSpan=3><asp:DropDownList id="ddlCategoriaReceita" runat="server" Width="200px" __designer:wfdid="w105"></asp:DropDownList> </TD></TR><TR><TD align=center colSpan=4>&nbsp; <asp:Button id="BtLancarReceita" onclick="BtLancar_Click" runat="server" Text="Lançar!" __designer:wfdid="w106"></asp:Button> </TD></TR><TR><TD colSpan=4><asp:GridView id="gvReceita" runat="server" Width="100%" ForeColor="#333333" __designer:wfdid="w107" HeaderStyle-BackColor="DarkBlue" GridLines="None" CellPadding="4" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnRowEditing="EditarReceita">
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
                    </ajax:TabPanel>
                    <ajax:TabPanel ID="tpDespesa" runat="server" HeaderText="Despesa">
                        <ContentTemplate>
                            <asp:UpdatePanel runat="server" ID="upDespesa">
                                <ContentTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px" align=right>Descrição</TD><TD style="WIDTH: 100px" colSpan=3><asp:TextBox id="tbDescricaoDespesa" runat="server" Width="250px" __designer:wfdid="w22"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 100px" align=right>Valor</TD><TD><asp:TextBox id="tbValorDespesa" runat="server" Width="100px" __designer:wfdid="w23"></asp:TextBox> </TD><TD align=right><asp:Label id="lbDataDespesa" runat="server" Text="Data" __designer:wfdid="w24"></asp:Label> </TD><TD style="WIDTH: 100px"><asp:TextBox id="tbDataDespesa" runat="server" Width="100px" __designer:wfdid="w25"></asp:TextBox> <ajax:CalendarExtender id="ceDataDespesa" runat="server" PopupButtonID="Image1" Format="d MMMM, yyyy" TargetControlID="tbDataDespesa">
                                </ajax:CalendarExtender> </TD></TR><TR><TD align=right>Categoria</TD><TD style="WIDTH: 177px" colSpan=3><asp:DropDownList id="ddlCategoriaDespesa" runat="server" Width="200px" __designer:wfdid="w27"></asp:DropDownList> </TD></TR><TR><TD align=center colSpan=4><asp:Button id="BtLancarDespesa" onclick="BtLancar_Click" runat="server" Text="Lançar!" __designer:wfdid="w28"></asp:Button> </TD></TR><TR><TD colSpan=4><asp:GridView id="gvDespesa" runat="server" Width="100%" ForeColor="#333333" __designer:wfdid="w29" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" CellPadding="4" GridLines="None" HeaderStyle-BackColor="DarkBlue">
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
                    </ajax:TabPanel>
                </ajax:TabContainer>
           </td>
        </tr>
    </table>
                        </asp:WizardStep>
                    </WizardSteps>
                    <StartNavigationTemplate>
                        <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Próximo" />
                    </StartNavigationTemplate>
                    <StepStyle Font-Size="0.8em" ForeColor="#333333" HorizontalAlign="Center" />
                    <SideBarButtonStyle  BackColor="#284E98" Font-Names="Verdana" ForeColor="White" />
                    <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
                        BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
                    <SideBarStyle BackColor="#284E98" Font-Size="0.9em" VerticalAlign="Top" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px" VerticalAlign="Top"
                        Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                </asp:Wizard>
                
    </table>
</asp:Content>


