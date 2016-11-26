﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="nutricloud_webforms.Home" %>
<%@ Register Src="~/User_Control/Carga_rapida.ascx" TagPrefix="uc1" TagName="Carga_rapida" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row seccionHeader">
        <div class="container">
            <h3>Tu Consumo Diario</h3>
        </div>
    </div>
    <!--/seccionHeader-->
    <div class="container">
        <div class="row">
            <div class="col l3 m12 s12 menu-left">
                <div class="btn_group">
                    <h5>Mis Alimentos</h5>
                    <ul>
                        <li>
                            <a class="waves-effect waves-light btn orange lighten-1" href="buscador.aspx">
                                <i class="material-icons left-i">add</i>
                                Agregar
                            </a>
                        </li>
                        <li>
                            <%--<uc1:Carga_rapida runat="server" ID="Carga_rapida" />--%>
                        </li>
                    </ul>
                </div>
            </div>

            <div class="col l9 m12 s12 home">
                <div class="divtop" id="calendario">
                    <input type="text" id="datepicker">
                    <input type="text" id="alternate" name="name" class="altercalendar" />
                </div>

                <div id="lista-comidas" class="list-food">
                </div>
            </div>
            <!--/col9-->
        </div>
        <!--/row-->
    </div>
    <!--/container-->
    <div class="container">
        <div class="row">
            <div class="reporte">
                <h3>Reporte</h3>
            </div>
            <!--/reporte-->
        </div>
        <!--/row-->
    </div>
    <!--/container-->
    <span class="ir-arriba icon-arrow-up2"><i class="material-icons">keyboard_arrow_up</i></span>

    <!-- Modal Favoritos -->
    <div id="modal_fav" class="modal modal-fixed-footer">
        <div class="modal-content">
            <h5>Mis Favoritos</h5>
            <div class="row item-alimento fav-modal">
                <div id="alimentos" class="container">
                </div>
            </div>
        </div>
        <div class="modal-footer">
             <div id="agregarCargaRapida"></div>
        </div>
    </div>

    <script src="../scripts/materialize.js"></script>
    <script src="../scripts/Home.js"></script>

</asp:Content>
