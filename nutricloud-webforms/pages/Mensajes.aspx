<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="nutricloud_webforms.Pages.Mensajes" %>
<%@ Register Src="~/User_Control/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Mensajes runat="server" ID="ucMensajes" />
</asp:Content>
