<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="nutricloud_webforms.Reportes" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Src="~/User_Control/Recomendaciones.ascx" TagPrefix="uc1" TagName="Recomendaciones" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../scripts/jqPlot/jquery.jqplot.js" type="text/javascript"></script>
    <script src="../scripts/jqPlot/plugins/jqplot.pieRenderer.min.js"></script>
    <script src="../scripts/jqPlot/plugins/jqplot.barRenderer.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/jqPlot/plugins/jqplot.dateAxisRenderer.js"></script>
    <script src="../scripts/jqPlot/plugins/jqplot.categoryAxisRenderer.min.js" type="text/javascript"></script>


    <div class="row seccionRep">
        <div class="container">
            <h3>Reportes</h3>
        </div>
    </div>


    <div class="container charts-cont">
        <div class="divider"></div>
        <h5>Estadísticas del día anterior</h5>

        <div class="row">
            <div class="col l8 s12" id="chartdia">
            </div>

            <div class="col l4 s12">
                <ul class="collapsible moreinfoR" data-collapsible="accordion">
                    <li>
                        <div class="collapsible-header"><i class="material-icons">info_outline</i>Ver Información Detallada</div>
                        <div class="collapsible-body">
                            Calorias (Kcal): 
    <asp:Label ID="CaloriasD" runat="server"></asp:Label>
                            <br />
                            Carbohidratos (Gr.): 
    <asp:Label ID="CarbohidratosD" runat="server"></asp:Label>
                            <br />
                            Proteinas (Gr.): 
    <asp:Label ID="ProteinasD" runat="server"></asp:Label>
                            <br />
                            Grasas (Gr.): 
    <asp:Label ID="GrasasD" runat="server"></asp:Label>
                            <br />
                            Fibra (Gr.): 
    <asp:Label ID="FibraD" runat="server"></asp:Label>
                            <br />
                            Potasio (Mg.): 
    <asp:Label ID="PotasioD" runat="server"></asp:Label>
                            <br />
                            Calcio (Mg.): 
    <asp:Label ID="CalcioD" runat="server"></asp:Label>
                            <br />
                            Fosforo (Mg.): 
    <asp:Label ID="FosforoD" runat="server"></asp:Label>
                            <br />
                            Hierro (Mg.): 
    <asp:Label ID="HierroD" runat="server"></asp:Label>
                            <br />
                            Sodio (Mg.): 
    <asp:Label ID="SodioD" runat="server"></asp:Label>
                            <br />
                            Agua (Gr.): 
    <asp:Label ID="AguaD" runat="server"></asp:Label>
                            <br />
                            Colesterol (Mg.): 
    <asp:Label ID="ColesterolD" runat="server"></asp:Label>
                            <br />
                            Vitamina C (Mg.): 
    <asp:Label ID="VitaCD" runat="server"></asp:Label>
                            <br />
                        </div>
                    </li>
                </ul>
            </div>
        </div>
        <h5>Estadísticas de la última Quincena</h5>

        <div class="row">

            <div class="col l8 s12" id="chartquince"></div>

            <div class="col l4 s12">
                <ul class="collapsible moreinfoR" data-collapsible="accordion">
                    <li>
                        <div class="collapsible-header"><i class="material-icons">info_outline</i>Ver Información Detallada</div>
                        <div class="collapsible-body">
                            Calorias (Kcal.): 
    <asp:Label ID="CaloriasQ" runat="server"></asp:Label>
                            <br />
                            Carbohidratos (Gr.): 
    <asp:Label ID="CarbohidratosQ" runat="server"></asp:Label>
                            <br />
                            Proteinas (Gr.): 
    <asp:Label ID="ProteinasQ" runat="server"></asp:Label>
                            <br />
                            Grasas (Gr.): 
    <asp:Label ID="GrasasQ" runat="server"></asp:Label>
                            <br />
                            Fibra (Gr.): 
    <asp:Label ID="FibraQ" runat="server"></asp:Label>
                            <br />
                            Potasio (Mg.): 
    <asp:Label ID="PotasioQ" runat="server"></asp:Label>
                            <br />
                            Calcio (Mg.): 
    <asp:Label ID="CalcioQ" runat="server"></asp:Label>
                            <br />
                            Fosforo (Mg.): 
    <asp:Label ID="FosforoQ" runat="server"></asp:Label>
                            <br />
                            Hierro (Mg.): 
    <asp:Label ID="HierroQ" runat="server"></asp:Label>
                            <br />
                            Sodio (Mg.): 
    <asp:Label ID="SodioQ" runat="server"></asp:Label>
                            <br />
                            Agua (Gr.): 
    <asp:Label ID="AguaQ" runat="server"></asp:Label>
                            <br />
                            Colesterol (Mg.): 
    <asp:Label ID="ColesterolQ" runat="server"></asp:Label>
                            <br />
                            Vitamina C (Mg.): 
    <asp:Label ID="VitaCQ" runat="server"></asp:Label>
                            <br />

                        </div>
                    </li>
                </ul>
            </div>

        </div>
    </div>

    <div class="row">
        <asp:LinkButton runat="server" CssClass="btn right waves-effect downloadP" OnClick="Button_Descargar_Click" Text="Descargar en PDF"></asp:LinkButton>
    </div>
    <div class="container charts-cont">
        <h5>Evaluación de tu Alimentación</h5>

        <ul id="rec" class="collapsible popout" data-collapsible="accordion">
            <li>
                <div class="collapsible-header"><i class="material-icons">assignment</i>Ayer</div>
                <div class="collapsible-body">
                    <div class="container">
                        <uc1:Recomendaciones runat="server" ID="RecomendacionesAyer" />
                    </div>
                </div>
            </li>
            <li>
                <div class="collapsible-header"><i class="material-icons">assignment</i>Últimos Quince días</div>
                <div class="collapsible-body">
                    <div class="container">
                        <uc1:Recomendaciones runat="server" ID="RecomendacionesQuince" />
                    </div>
                </div>
            </li>
        </ul>
    </div>
    <script src="../scripts/materialize.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.collapsible').collapsible();
        });
    </script>

    <script>

        $(document).ready(function () {


            $.ajax({
                type: "POST",
                url: "Reportes.aspx/cargaRepoDia",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: setRepoDia,
                error: function (msg) {
                    alert("Hubo un error en la grafica diaria");
                }
            });

            function setRepoDia(response) {
                var reporteD = response.d;
                var arr = [];

                reporteD = JSON.parse(reporteD);

                for (var key in reporteD) {
                    // arr.push(resultados, reporteD[resultados])
                    var tmpArray = [];
                    tmpArray.push(key);
                    tmpArray.push(reporteD[key]);
                    arr.push(tmpArray);
                }

                 var plot1 = jQuery.jqplot('chartdia', [arr],
                    {
                        seriesDefaults: {
                            // Make this a pie chart.
                            renderer: $.jqplot.PieRenderer,
                            rendererOptions: {
                                // Put data labels on the pie slices.
                                // By default, labels show the percentage of the slice.
                                showDataLabels: true,
                                seriesColors: ["#f44336", "#2196f3", "#ffeb3b", "#ff5252", "#4caf50", "#e040fb", "#ff9800"]

                            }
                        },
                        legend: { show: true, location: 'e' }
                    });
            }

            window.onresize = function (event) {
                plot1.replot();
            }

            $.ajax({
                type: "POST",
                url: "Reportes.aspx/cargaRepoQuince",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: setRepoQuince,
                error: function (msg) {
                    alert("Hubo un error en la grafica quincenal");
                }
            });


            function setRepoQuince(response) {

                var reporteQ = response.d;
                var arr1 = [];
                var arr2 = [];
                var arr3 = [];
                var arr4 = [];
                var arr5 = [];

                reporteQ = JSON.parse(reporteQ);

                for (var key in reporteQ[0]) {
                    // arr.push(resultados, reporteD[resultados])
                    var tmpArray = [];
                    tmpArray.push(key);
                    tmpArray.push(reporteQ[0][key]);
                    arr1.push(tmpArray);
                }
                for (var key in reporteQ[1]) {
                    // arr.push(resultados, reporteD[resultados])
                    var tmpArray = [];
                    tmpArray.push(key);
                    tmpArray.push(reporteQ[1][key]);
                    arr2.push(tmpArray);
                }
                for (var key in reporteQ[2]) {
                    // arr.push(resultados, reporteD[resultados])
                    var tmpArray = [];
                    tmpArray.push(key);
                    tmpArray.push(reporteQ[2][key]);
                    arr3.push(tmpArray);
                }
                for (var key in reporteQ[3]) {
                    // arr.push(resultados, reporteD[resultados])
                    var tmpArray = [];
                    tmpArray.push(key);
                    tmpArray.push(reporteQ[3][key]);
                    arr4.push(tmpArray);
                }
                for (var key in reporteQ[4]) {
                    // arr.push(resultados, reporteD[resultados])
                    var tmpArray = [];
                    tmpArray.push(key);
                    tmpArray.push(reporteQ[4][key]);
                    arr5.push(tmpArray);
                }


                var plot2 = $.jqplot('chartquince', [arr1, arr2, arr3, arr4, arr5],
                    {
                        /*title: 'Customized Date Axis',*/
                        legend: { show: true },
                        axes: {
                            xaxis: {
                                renderer: $.jqplot.DateAxisRenderer,
                                tickRenderer: $.jqplot.CanvasAxisTickRenderer,
                                tickOptions: {
                                    angle: -30,
                                    formatString: '%d-%b-%Y'
                                }
                            },
                            yaxis: {
                                label: 'gramos'
                            }

                        },
                        series: [{
                            lineWidth: 4,
                            markerOptions: { style: 'circle' },
                        }],
                        series: [
                                    { label: 'Proteina' },
                                    { label: 'Carbohidratos' },
                                    { label: 'Grasas' },
                                    { label: 'Agua' },
                                    { label: 'Fibra' }
                        ],
                    });
            }

            window.onresize = function (event) {
                plot2.replot({ resetAxes: true });
            }

        });


    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            $('.show').on('click', function (event) {
                event.preventDefault;
                $(this).closest(".rec").find(".recomendacion").slideToggle("fast");
            });
        });
    </script>
</asp:Content>
