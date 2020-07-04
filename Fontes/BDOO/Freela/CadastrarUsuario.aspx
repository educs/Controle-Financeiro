<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CadastrarUsuario.aspx.cs" Inherits="CadastrarUsuario" Title="Untitled Page" Theme="Tema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMenu" Runat="Server">
    <asp:CreateUserWizard ID="wzdUsuario" runat="server" Width="400px" AnswerLabelText="Resposta de Segurança:" AnswerRequiredErrorMessage="Resposta de Segurança Requerida" BackColor="#EFF3FB" 
        BorderColor="#B5C7DE" BorderStyle="Solid" BorderWidth="1px" CancelButtonText="Cancelar" CompleteSuccessText="Conta criada com sucesso!" 
        ConfirmPasswordCompareErrorMessage="Senha e confirmação de senha não conferem!" ConfirmPasswordLabelText="Confirme a Senha:" ConfirmPasswordRequiredErrorMessage="Confirmação de Senha requerida." 
        CreateUserButtonText="Crie Usuário" DuplicateEmailErrorMessage="Endereço de email já usado! Por favor, informe outro." DuplicateUserNameErrorMessage="Usuário já usado. Por favor, selecione outro usuário." 
        EmailRegularExpressionErrorMessage="Por favor, entre um email válido." EmailRequiredErrorMessage="E-mail requerido." FinishCompleteButtonText="Finalizar" FinishPreviousButtonText="Anterior" Font-Names="Verdana" 
        Font-Size="0.8em" InvalidAnswerErrorMessage="Por favor, entre outra resposta de segurança." InvalidEmailErrorMessage="Por favor, entre outro endereço de e-mail." InvalidQuestionErrorMessage="Por favor, entre outra pergunta de segurança." 
        PasswordLabelText="Senha:" PasswordRegularExpressionErrorMessage="Por favor, entre outra senha." PasswordRequiredErrorMessage="Senha requerida." QuestionLabelText="Questão de Segurança:" QuestionRequiredErrorMessage="Questão de Segurança requerida." 
        StartNextButtonText="Próximo" StepNextButtonText="Próximo" StepPreviousButtonText="Anterior" UnknownErrorMessage="Sua conta não foi criada. Por favor, tente novamente." UserNameLabelText="Nome de Usuário:" UserNameRequiredErrorMessage="Nome de Usuário requerido." >
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

