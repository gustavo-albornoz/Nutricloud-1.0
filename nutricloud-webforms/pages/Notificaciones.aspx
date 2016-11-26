<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Notificaciones.aspx.cs" Inherits="nutricloud_webforms.Pages.Notificaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../scripts/Notificaciones.js"></script>
    <style>
        .notificacion_vista {
            background-color: lightblue;
        }

        .notificacion_no_vista {
            background-color: #3d870833;
        }

        .notificacion:hover {
            cursor: pointer;
            background-color: #3D87081A;
        }

        .fechaNotificacion {
            color: #686C68;
            font-size: 0.8em;
        }

    </style>
    
    <div class="row">
        <div class="col s12 m10 offset-m1">
            <ul id="notificaciones" class="collection">
            </ul>
        </div>
    </div>

</asp:Content>
