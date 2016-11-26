<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPro.Master" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="nutricloud_webforms.pages.Entrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row seccionPro">
        <div class="container">
            <h3>Entrada de Blog</h3>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="col l6 s12">
                <img class="imgentrada responsive-img" src="../Content/img/picture.png">
            </div>
        </div>
        <div class="row">
            <div class="col s10">
                <input type="file" />
            </div>
        </div>
        <div class="row">
            <textarea rows="10" cols="60">
                Ingresa el contenido de la entrada.
            </textarea>
            <a href="Nota.aspx" class="button btn waves-effect orange btn-ingresar">Subir entrada</a>
        </div>
    </div>
    <!--/container-->
    <style>
        form button {
            background-color: rgba(0, 0, 0, 0.26) !important;
        }
    </style>
</asp:Content>
