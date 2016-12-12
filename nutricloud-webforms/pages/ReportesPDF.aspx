<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportesPDF.aspx.cs" Inherits="nutricloud_webforms.Pages.ReportesPDF" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Src="~/User_Control/Recomendaciones.ascx" TagPrefix="uc1" TagName="Recomendaciones" %>

<!DOCTYPE html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0, user-scalable=no" />
        <title>nutricloud</title>

        <!-- CSS  -->
        <link href="/scripts/jqPlot/jquery.jqplot.css" rel="stylesheet" type="text/css" />
        <link href="/content/materialize.css" type="text/css" rel="stylesheet"/>
        <link href="/content/style.css" type="text/css" rel="stylesheet"/>
        <link href="/content/LayoutStyle.css" type="text/css" rel="stylesheet"/>
        <link href="/content/responsive.css" type="text/css" rel="stylesheet"/>
        <link rel="stylesheet" type="text/css" href="/scripts/jquery.min.js"/>
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet"/>
        <link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css"/>
        <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css'/>
        <link href='https://fonts.googleapis.com/css?family=Muli:400,300|Righteous' rel='stylesheet' type='text/css'/>
        <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />

        <!-- Icon -->
        <link rel="apple-touch-icon" sizes="57x57" href="/content/img/icon/apple-icon-57x57.png"/>
        <link rel="apple-touch-icon" sizes="60x60" href="/content/img/icon/apple-icon-60x60.png"/>
        <link rel="apple-touch-icon" sizes="72x72" href="/content/img/icon/apple-icon-72x72.png"/>
        <link rel="apple-touch-icon" sizes="76x76" href="/content/img/icon/apple-icon-76x76.png"/>
        <link rel="apple-touch-icon" sizes="114x114" href="/content/img/icon/apple-icon-114x114.png"/>
        <link rel="apple-touch-icon" sizes="120x120" href="/content/img/icon/apple-icon-120x120.png"/>
        <link rel="apple-touch-icon" sizes="144x144" href="/content/img/icon/apple-icon-144x144.png"/>
        <link rel="apple-touch-icon" sizes="152x152" href="/content/img/icon/apple-icon-152x152.png"/>
        <link rel="apple-touch-icon" sizes="180x180" href="/content/img/icon/apple-icon-180x180.png"/>
        <link rel="icon" type="image/png" sizes="192x192" href="/content/img/icon/android-icon-192x192.png"/>
        <link rel="icon" type="image/png" sizes="32x32" href="/content/img/icon/favicon-32x32.png"/>
        <link rel="icon" type="image/png" sizes="96x96" href="/content/img/icon/favicon-96x96.png"/>
        <link rel="icon" type="image/png" sizes="16x16" href="/content/img/icon/favicon-16x16.png"/>
        <link rel="manifest" href="/content/img/icon/manifest.json"/>
        <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
        <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
 
        <meta name="msapplication-TileColor" content="#ffffff"/>
        <meta name="msapplication-TileImage" content="/content/img/icon/ms-icon-144x144.png"/>
        <meta name="theme-color" content="#ffffff"/>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container charts-cont">
                <div class="divider"></div>
                <h5>Estadísticas del día anterior <asp:Label ID="fechaDiaAnterior" runat="server"></asp:Label></h5>

                <div class="row">
                    <div class="col l8 s12" id="chartdia">
                    </div>
                    <div class="col l4 s12">
                        <div>
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
                    </div>
                </div>
                <h5>Estadísticas de la última Quincena <asp:Label ID="fechasUltimaQuincena" runat="server"></asp:Label></h5>

                <div class="row">

                    <div class="col l8 s12" id="chartquince"></div>

                    <div class="col l4 s12">
                        <div>
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
                    </div>

                </div>
            </div>
        </div>
    </form>

    <!--  Scripts-->
    <script src="../../scripts/jquery.min.js"></script>
    <script src="../scripts/materialize.js"></script>
    <script type="text/javascript" src="/scripts/DateTimePicker.min.js"></script>
    <script src="../../scripts/jquery-ui.min.js"></script>
    
    
    <!-- JQPLOT -->
    <script src="../../scripts/jqPlot/jquery.jqplot.js" type="text/javascript"></script>
    <script src="../../scripts/jqPlot/plugins/jqplot.pieRenderer.min.js"></script>
    <script src="../../scripts/jqPlot/plugins/jqplot.barRenderer.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../scripts/jqPlot/plugins/jqplot.dateAxisRenderer.js"></script>
    <script src="../../scripts/jqPlot/plugins/jqplot.categoryAxisRenderer.min.js" type="text/javascript"></script>
   
     <script src="../../scripts/ReportesPDF.js" type="text/javascript"></script>

</body>
</html>
