<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Recomendaciones.ascx.cs" Inherits="nutricloud_webforms.User_Control.Recomendaciones" %>

<asp:Label ID="lblErrorAyer" runat="server" Text="Los valores estan debajo de los minimos como para poder evaluar. Completa tu ingesta mas detalladamente." Visible="false"></asp:Label>

<div id="divRecomendaciones" runat="server">
    <a id="ttCalorias" runat="server">Calorías</a>
    <a id="ttCarbohidratos" runat="server">Carbohidratos</a>
    <a id="ttProteinas" runat="server">Proteínas</a>
    <a id="ttGrasas" runat="server">Grasas</a>
    <a id="ttFibra" runat="server">Fibra</a>
    <a id="ttAgua" runat="server">Agua</a>
    <a id="ttPotasio" runat="server">Potasio</a>
    <a id="ttSodio" runat="server">Sodio</a>
    <a id="ttCalcio" runat="server">Calcio</a>
    <a id="ttHierro" runat="server">Hierro</a>
    <a id="ttFosforo" runat="server">Fósforo</a>
    <a id="ttColesterol" runat="server">Colesterol</a>
</div>

<script>
    $(document).ready(function () {
        $('.tooltipped').tooltip({ html: "true", delay: 50 });
    });
</script>
