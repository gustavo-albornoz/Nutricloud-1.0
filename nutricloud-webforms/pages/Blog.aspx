<%@ Page Title="" Language="C#" MasterPageFile="~/Anon.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="nutricloud_webforms.Pages.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row seccionPro">
        <div class="container">
            <h3>Blog</h3>
        </div>
    </div>

    <div class="container">
        <p style="font-size: 20px;">Encontrá los mejores consejos de nutrición de la mano de profesionales. </p>
        <div class="row">
            <div class="col l6 s12">
                <a href="RecetaAlta.aspx" class="button btn waves-effect orange btn-ingresar" id="receta" runat="server">Agregar Receta</a>
                <a href="NotaAlta.aspx" class="button btn waves-effect orange btn-ingresar" id="nota" runat="server">Nueva Nota</a>
            </div>
            <div class="col l6 s12 search-blog">
                <div class="input-field">
                    <input id="search" type="search" required>
                    <label for="search"><i class="material-icons orange-text">search</i></label>
                </div>
            </div>
        </div>
        <div class="collection">

                <asp:Label runat="server" ID="msjNoHayNotas"></asp:Label>
                <asp:Repeater ID="RepeaterNotas" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton CommandArgument=<%# Eval("id_blog_nota") %> Cssclass="collection-item" OnClick="Ver" runat="server">
                            <div class="row">
                                <asp:Image ImageUrl=<%# Eval("imagen_nota") %> CssClass="col l3 m3 s12 img-blog responsive-img" runat="server"/>
                                <div class="col l9 m9 s12 note-blog">
                                    <h5><%# Eval("titulo_nota") %></h5>
                                    <p class="grey-text">
                                        <%# Eval("descripcion_nota") %>
                                    </p>                 
                                    <span>Leer Más</span>
                                </div>
                            </div>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>

        </div>
        <!--coleccion-->

        <ul class="paginador">
            <li class="disabled"><a href="#!"><i class="material-icons">chevron_left</i></a></li>
            <li class="active"><a href="#!">1</a></li>
            <li class="waves-effect"><a href="#!">2</a></li>
            <li class="waves-effect"><a href="#!">3</a></li>
            <li class="waves-effect"><a href="#!">4</a></li>
            <li class="waves-effect"><a href="#!">5</a></li>
            <li class="waves-effect"><a href="#!"><i class="material-icons">chevron_right</i></a></li>
        </ul>
    </div>
    <!--container-->
</asp:Content>
