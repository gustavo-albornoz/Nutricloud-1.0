<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPro.Master" AutoEventWireup="true" CodeBehind="NotaAlta.aspx.cs" Inherits="nutricloud_webforms.Pages.NotaAlta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row seccionPerfil">
        <div class="container">
            <h3>Alta de Nota</h3>
        </div>
    </div>

    <div class="container">
            <div class="row">
                <div class="file-field input-field">
                    <div class="btn">
                        <span>Imagen</span>
                        <asp:FileUpload ID="imagen" runat="server"/>
                     </div>
                    <div class="file-path-wrapper">
                        <input class="file-path validate" type="text">
                    </div>
                </div>
                <h6>Título</h6>
                <asp:TextBox runat="server" ID="titulo"></asp:TextBox>
                 <h6>Descripción</h6>
                <asp:TextBox runat="server" ID="descripcion"></asp:TextBox>
                <h6 style="padding-bottom: 20px;">Nota</h6>
                <asp:TextBox ID="texto" TextMode="MultiLine" runat="server" ValidateRequestMode="Disabled"></asp:TextBox>
                <asp:LinkButton runat="server" CssClass="button btn waves-effect orange btn-ingresar" OnClick="Guardar" Text="Guardar"></asp:LinkButton> 
            </div>
    </div>
    <!--/container-->
    <style>
        form button {
            background-color: rgba(0, 0, 0, 0.26) !important;
        }
    </style>
</asp:Content>
