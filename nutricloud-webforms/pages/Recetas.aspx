<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Recetas.aspx.cs" Inherits="nutricloud_webforms.Pages.Recetas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row seccionPerfil">
        <div class="container">
            <h3>Recetas</h3>
        </div>
    </div>

    <div class="container">
       <!-- <p style="font-size: 20px;">Encontrá los mejores consejos de nutrición de la mano de profesionales. </p>-->
        <div class="row">
            <div class="col l6 s12">
                <a href="RecetaAlta.aspx" class="button btn waves-effect orange btn-ingresar">Agregar Receta</a>
            </div>
            <div class="col l6 s12 search-blog">
               
            </div>
        </div>
        <div class="collection listaRecetas">
               <asp:Label runat="server" ID="msjNoHayRecetas"></asp:Label>
                <asp:Repeater ID="RepeaterRecetas" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton CommandArgument=<%# Eval("id_usuario_receta") %> class="collection-item" OnClick="VerReceta" runat="server">
                            <div class="row">
                                <asp:Image ID="imgReceta" ImageUrl=<%# Eval("imagen_receta") %> CssClass="col l3 m3 s12 img-blog responsive-img" runat="server"/>
                                <%--<div class="col l3 m3 s12 img-blog responsive-img"></div>--%>
                                <div class="col l9 m9 s12 note-blog">
                                    <h5><%# Eval("titulo_receta") %></h5>
                                    <p class="grey-text">
                                        <%# Eval("descripcion_receta") %>
                                    </p>                 
                                    <span>Leer Más</span>
                                     <p class="grey-text">
                                        <asp:Label CssClass="grey-text" ID="Label1" runat="server" Text=<%# Eval("f_publicacion") %>></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        <!--coleccion-->

        
    </div>
    <!--container-->
</asp:Content>
