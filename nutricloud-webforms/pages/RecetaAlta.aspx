﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="RecetaAlta.aspx.cs" Inherits="nutricloud_webforms.pages.RecetaAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style type="text/css">
     .file-up {
    background-color: transparent !important;
    box-shadow: none !important;
 }

 .file-up input
 {
    opacity: 1 !important;
    color: #383838;
    font-size: 15px !important;
 }
</style>
    <div class="row seccionPerfil">
        <div class="container">
            <h3>Alta de receta</h3>
        </div>
    </div>

    <div class="container">
            <div class="row">
                <div class="file-field input-field">
                    <div class="btn file-up">
                        <%--<span>Imagen</span>--%>
                        <asp:FileUpload ID="imagenReceta" runat="server"/>
                     </div>
                    <%--<div class="file-path-wrapper">
                        <input class="file-path validate" type="text">
                    </div>--%>
                </div>
                <h6>Título</h6>
                <asp:TextBox runat="server" ID="titulo_receta"></asp:TextBox>
                 <h6>Descripción</h6>
                <asp:TextBox runat="server" ID="descripcion_receta"></asp:TextBox>
                <h6 style="padding-bottom: 20px;">Receta</h6>
                <asp:TextBox ID="receta_texto" TextMode="MultiLine" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
                <asp:LinkButton runat="server" CssClass="button btn waves-effect orange btn-ingresar" OnClick="SubirEntrada" Text="Guardar"></asp:LinkButton> 
            </div>
    </div>
    <!--/container-->
    <style>
        form button {
            background-color: rgba(0, 0, 0, 0.26) !important;
        }
    </style>
    <script src="/Nutricloud/scripts/tinymce/js/tinymce/tinymce.min.js"></script>
    <script>tinymce.init({ selector: 'textarea' });</script>
</asp:Content>
