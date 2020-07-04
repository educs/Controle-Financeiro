<%@ Control Language="C#" AutoEventWireup="false" CodeFile="UCMenu.ascx.cs" Inherits="UCMenu" %>
<asp:Menu ID="mnPortchal" runat="server" BackColor="LightSteelBlue" DataSourceID="SiteMapDataSource1"
    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="Black" 
    StaticSubMenuIndent="10px" StaticEnableDefaultPopOutImage="False" EnableTheming="True" StaticDisplayLevels="2" BorderStyle="Solid" BorderWidth="1px" >
    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
    <DynamicMenuStyle BackColor="#F7F6F3" />
    <StaticSelectedStyle BackColor="#5D7B9D" />
    <DynamicSelectedStyle BackColor="#5D7B9D" />
    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
    <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
</asp:Menu>
<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" ShowStartingNode="False" />
