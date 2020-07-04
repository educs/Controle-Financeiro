<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarUsuario.aspx.cs" Inherits="CadastrarUsuario" Title="Untitled Page" Theme="Tema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" Runat="Server">
    <asp:CreateUserWizard ID="wzdUsuario" runat="server" Width="400px" AnswerLabelText="Resposta de Seguran�a:" AnswerRequiredErrorMessage="Resposta de Seguran�a Requerida" BackColor="#EFF3FB" 
        BorderColor="#B5C7DE" BorderStyle="Solid" BorderWidth="1px" CancelButtonText="Cancelar" CompleteSuccessText="Conta criada com sucesso!" 
        ConfirmPasswordCompareErrorMessage="Senha e confirma��o de senha n�o conferem!" ConfirmPasswordLabelText="Confirme a Senha:" ConfirmPasswordRequiredErrorMessage="Confirma��o de Senha requerida." 
        CreateUserButtonText="Crie Usu�rio" DuplicateEmailErrorMessage="Endere�o de email j� usado! Por favor, informe outro." DuplicateUserNameErrorMessage="Usu�rio j� usado. Por favor, selecione outro usu�rio." 
        EmailRegularExpressionErrorMessage="Por favor, entre um email v�lido." EmailRequiredErrorMessage="E-mail requerido." FinishCompleteButtonText="Finalizar" FinishPreviousButtonText="Anterior" Font-Names="Verdana" 
        Font-Size="0.8em" InvalidAnswerErrorMessage="Por favor, entre outra resposta de seguran�a." InvalidEmailErrorMessage="Por favor, entre outro endere�o de e-mail." InvalidQuestionErrorMessage="Por favor, entre outra pergunta de seguran�a." 
        PasswordLabelText="Senha:" PasswordRegularExpressionErrorMessage="Por favor, entre outra senha." PasswordRequiredErrorMessage="Senha requerida." QuestionLabelText="Quest�o de Seguran�a:" QuestionRequiredErrorMessage="Quest�o de Seguran�a requerida." 
        StartNextButtonText="Pr�ximo" StepNextButtonText="Pr�ximo" StepPreviousButtonText="Anterior" UnknownErrorMessage="Sua conta n�o foi criada. Por favor, tente novamente." UserNameLabelText="Nome de Usu�rio:" UserNameRequiredErrorMessage="Nome de Usu�rio requerido." >
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title="Cadastre sua Conta!">
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" Title="Completo">
            </asp:CompleteWizardStep>
        </WizardSteps>
        <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
        <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
        <ContinueButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
        <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
        <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
            Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <CreateUserButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" ForeColor="#284E98" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <StepStyle Font-Size="0.8em" />
    </asp:CreateUserWizard>
</asp:Content>

