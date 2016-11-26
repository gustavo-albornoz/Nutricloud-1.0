<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPro.Master" AutoEventWireup="true" CodeBehind="Mensajes.aspx.cs" Inherits="nutricloud_webforms.Profesionales.Mensajes" %>
<%@ Register Src="~/User_Control/Mensajes.ascx" TagPrefix="uc1" TagName="Mensajes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:mensajes runat="server" id="ucMensajes" />
</asp:Content>
