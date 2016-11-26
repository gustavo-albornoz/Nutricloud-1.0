<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="nutricloud_webforms.Reportes" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div class="row seccionRep">
    <div class="container">
        <h3>Reportes</h3>
    </div>
</div>


<div class="container charts-cont">
    <div class="divider"></div>
    <h5>Estadísticas del día anterior</h5>
   
     <asp:Chart ID="Chart1" runat="server" Height="508px" Width="568px">
        <Series>
            <asp:Series ChartType="Pie" Color="Green" Font="Montserrat, 8.249999pt" Name="Nutrientes-dia"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

<h5>Detalle de nutrientes</h5>

<h5>Calorias: 
    <asp:Label ID="CaloriasD" runat="server"></asp:Label></h5>
    Carbohidratos: 
    <asp:Label ID="CarbohidratosD" runat="server"></asp:Label>
    <br />
    Proteinas: 
    <asp:Label ID="ProteinasD" runat="server"></asp:Label>
    <br />
    Grasas: 
    <asp:Label ID="GrasasD" runat="server"></asp:Label>
    <br />
    Potasio: 
    <asp:Label ID="PotasioD" runat="server"></asp:Label>
    <br />
    Calcio: 
    <asp:Label ID="CalcioD" runat="server"></asp:Label>
    <br />
    Fosforo: 
    <asp:Label ID="FosforoD" runat="server"></asp:Label>
    <br />
    Hierro: 
    <asp:Label ID="HierroD" runat="server"></asp:Label>
    <br />
    Agua: 
    <asp:Label ID="AguaD" runat="server"></asp:Label>
    <br />
    Colesterol: 
    <asp:Label ID="ColesterolD" runat="server"></asp:Label>
    <br />
    Vitamina C: 
    <asp:Label ID="VitaCD" runat="server"></asp:Label>
    <br />

     <h5>Estadísticas de la ultima quincena</h5>
   
     <asp:Chart ID="Chart2" runat="server" Width="790px">
        <Series>
            <asp:Series ChartType="Column" Color="Green" Font="Montserrat, 8.249999pt" Name="Nutrientes-quince"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>

<h5>Detalle de nutrientes</h5>

<h5>Calorias: 
    <asp:Label ID="CaloriasQ" runat="server"></asp:Label></h5>
    <br />
    Carbohidratos: 
    <asp:Label ID="CarbohidratosQ" runat="server"></asp:Label>
    <br />
    Proteinas: 
    <asp:Label ID="ProteinasQ" runat="server"></asp:Label>
    <br />
    Grasas: 
    <asp:Label ID="GrasasQ" runat="server"></asp:Label>
    <br />
    Potasio: 
    <asp:Label ID="PotasioQ" runat="server"></asp:Label>
    <br />
    Calcio: 
    <asp:Label ID="CalcioQ" runat="server"></asp:Label>
    <br />
    Fosforo: 
    <asp:Label ID="FosforoQ" runat="server"></asp:Label>
    <br />
    Hierro: 
    <asp:Label ID="HierroQ" runat="server"></asp:Label>
    <br />
    Agua: 
    <asp:Label ID="AguaQ" runat="server"></asp:Label>
    <br />
    Colesterol: 
    <asp:Label ID="ColesterolQ" runat="server"></asp:Label>
    <br />
    Vitamina C: 
    <asp:Label ID="VitaCQ" runat="server"></asp:Label>
    <br />

</div>

<div class="row">
        <a href="#" class="btn right waves-effect ">Descargar en PDF</a>
    </div>
    <div class="container charts-cont">
<h4>Evaluacion de tu alimentacion</h4>
<h5>Ayer</h5>
<asp:Panel ID="Panel2" runat="server"></asp:Panel>
<h5>Los ultimos quince dias</h5>
<asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>

</asp:Content>