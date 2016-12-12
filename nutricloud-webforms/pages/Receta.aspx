<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Receta.aspx.cs" Inherits="nutricloud_webforms.pages.Receta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row seccionPerfil">
        <div class="container">
            <h3>Receta</h3>
        </div>
    </div>

    <div class="container">
        <div class="row fechanota grey-text">
            <asp:Label ID="fechanota" runat="server"></asp:Label>
        </div>
        <div class="row titlenota">
            <h4 runat="server" id="receta_titulo"></h4>
        </div>
        <div class="row">
                <div class="row">
                    <div class="col offset-m3 m6 s12">
                        <asp:Image ID="imgReceta" runat="server"/>
                     </div>
                </div>
                 <div class="row">
                    <div class="col l10 s12">
                        <i>
                            <div id="receta_descripcion" runat="server"></div>
                        </i>
                    </div>
                </div>
                <div class="row">
                    <div class="col l10 s12">
                        <div id="receta_texto" runat="server"></div>
                    </div>
                </div>
               <asp:LinkButton runat="server" CssClass="button btn waves-effect orange btn-ingresar" OnClick="EditarReceta" Text="Editar"></asp:LinkButton>
                <asp:LinkButton runat="server" CssClass="button btn waves-effect orange btn-ingresar" OnClick="EliminarReceta" Text="Eliminar"></asp:LinkButton>  
        </div><!--/row-->
    </div><!--/container-->

</asp:Content>
