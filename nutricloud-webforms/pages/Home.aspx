<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="nutricloud_webforms.Home" %>

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
                            <asp:LinkButton ID="btnAgregar" runat="server" CssClass="waves-effect waves-light btn orange lighten-1" OnClick="btnAgregar_Click">
                                <i class="material-icons left-i">add</i>
                                Agregar
                            </asp:LinkButton>
                        </li>
                        <li >
                            <a href="#reporte-dia" class="waves-effect waves-light btn orange lighten-1">Ver reporte Diario</a>
                        </li>
                        <li style="text-align:center">
                             <span>Total calorías: <span id="calorias-dia">0</span></span>
                           
                        </li>
                    </ul>
                </div>
            </div>

            <div class="col l9 m12 s12 home">
                <div class="divtop" id="calendario">
                    <input type="text" id="datepicker">
                    <input type="text" id="alternate" name="name" class="altercalendar" readonly="readonly" />
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
            <div id="reporte-dia" class="reporte">
                <h4>Reporte Diario</h4>

                <div class="row">
                    <div id="chartdia" class="col l8 s12"></div>

                    <div class="col l4 s12">
                        <ul class="collapsible moreinfoR" data-collapsible="accordion">
                            <li>
                                <div class="collapsible-header"><i class="material-icons">info_outline</i>Ver Información Detallada</div>
                                <div class="collapsible-body">
                                    Calorias (Kcal): <span id="CaloriasD"></span>
                                    <br />
                                    Carbohidratos (Gr.): <span id="CarbohidratosD"></span>
                                    <br />
                                    Proteinas (Gr.): <span id="ProteinasD"></span>
                                    <br />
                                    Grasas (Gr.): <span id="GrasasD"></span>
                                    <br />
                                    Fibra (Gr.): <span id="FibraD"></span>
                                    <br />
                                    Potasio (Mg.): <span id="PotasioD"></span>
                                    <br />
                                    Calcio (Mg.): <span id="CalcioD"></span>
                                    <br />
                                    Fosforo (Mg.): <span id="FosforoD"></span>
                                    <br />
                                    Hierro (Mg.): <span id="HierroD"></span>
                                    <br />
                                    Sodio (Mg.): <span id="SodioD"></span>
                                    <br />
                                    Agua (Gr.): <span id="AguaD"></span>
                                    <br />
                                    Colesterol (Mg.): <span id="ColesterolD"></span>
                                    <br />
                                    Vitamina C (Mg.): <span id="VitaCD"></span>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--/reporte-->
        </div>
        <!--/row-->
    </div>
    <!--/container-->
    <span class="ir-arriba icon-arrow-up2"><i class="material-icons">keyboard_arrow_up</i></span>

    <!-- Modal Favoritos -->
    <div id="modal_fav" class="modal modal-fixed-footer">
        <div class="modal-content" style="max-height:360px; overflow:hidden; overflow-y:scroll;">
            <h5>Mis Favoritos</h5>
            <div class="row item-alimento fav-modal">
                <div id="alimentos" class="container"></div>
                <div id="nohayfavoritos" style="padding: 5px; display: none">No tiene alimentos favoritos</div>
            </div>
        </div>
        <div class="modal-footer">
            <div id="agregarCargaRapida"></div>
        </div>
    </div>

    <script src="../scripts/materialize.js"></script>
    <script src="../scripts/Home.js"></script>


    <script src="../scripts/jqPlot/jquery.jqplot.js" type="text/javascript"></script>
    <script src="../scripts/jqPlot/plugins/jqplot.pieRenderer.min.js"></script>
    <script src="../scripts/jqPlot/plugins/jqplot.barRenderer.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/jqPlot/plugins/jqplot.dateAxisRenderer.js"></script>
    <script src="../scripts/jqPlot/plugins/jqplot.categoryAxisRenderer.min.js" type="text/javascript"></script>

    <script>
        $(document).ready(function () {
            $('.collapsible').collapsible();
        });
    </script>

</asp:Content>
