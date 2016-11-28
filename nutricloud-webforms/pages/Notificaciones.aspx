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

        .aviso {
            background-color: #F27E1B80;
        }

        .fechaNotificacion {
            color: #686C68;
            font-size: 0.8em;
            width: 200px;
        }

    </style>
    
    <div class="row">
        <div class="col s12 m10 offset-m1">
            <h5 id="avisosh5" style="display: none;">Avisos</h5>
            <ul id="avisos" style="display: none;" class="collection"></ul>
            <h5>Notificaciones</h5>
            <ul id="notificaciones" class="collection">
            </ul>
        </div>
    </div>

     <!-- Modal -->
    <div id="modal1" class="modal modal-fixed-footer">
        <div class="modal-content">
            HOLA
        </div>
        <div class="modal-footer">
             <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Agree</a>
             <a href="#!" class=" modal-action modal-close waves-effect waves-green btn-flat">Agree</a>
        </div>
    </div>

</asp:Content>
