<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Muro.aspx.cs" Inherits="nutricloud_webforms.Muro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row seccionFood">
        <div class="container">
            <h3>Muro</h3>
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <nav class="searchnav">
                    <div class="nav-wrapper">
                        <div class="input-field">
                            <asp:TextBox ID="busqueda" runat="server" type="search" placeholder="Buscar Amigos"></asp:TextBox>
                            <label for="busqueda"><i class="material-icons orange-text">search</i></label>
                        </div>
                    </div>
                </nav>
                <div class=" row comment">
                    <div class="imagemuro propiaimg">
                        <img src="../Content/img/apple.png" class="responsive-img" />
                    </div>
                    <div class="col s10">
                        <label for="TxtEstado">Cómo te sientes hoy?</label>
                        <asp:TextBox ID="TxtEstado" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:Label ID="lblError" runat="server" Text="*Debe escribir un estado" Visible="false" CssClass="text-error"></asp:Label>
                        <asp:Button ID="Button1" runat="server" CssClass="button btn waves-effect orange" Text="Subir Entrada" OnClick="Button1_Click" AutoPostback="true" />
                    </div>
                </div>

                <div class="row">
                    <div class="col s12 home muromsj">
                        <asp:Repeater ID="rMuro" runat="server">
                            <ItemTemplate>
                                <div class="row item-muro">
                                    <div class="row">
                                        <div class="imagemuro">
                                            <img src="../Content/img/apple.png" class="responsive-img" />
                                        </div>
                                        <div class="col s10">
                                            <a href='PerfilSocial.aspx?id=<%# Eval("id_usuario_seguido") %>'>
                                                <%# (String.IsNullOrEmpty(Eval("nombre_usuario_seguido").ToString()) ? "Anónimo" : Eval("nombre_usuario_seguido"))%>
                                            </a>
                                            <span><%# Eval("f_publicacion") %></span>
                                            <p><%# Eval("estado") %></p>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        $(function () {
            $("#ContentPlaceHolder1_busqueda").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        type: "POST",
                        url: "Muro.aspx/GetUsuarios",
                        data: "{nombre:'" + request.term + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            //response($.parseJSON(data.d));
                            response($.map($.parseJSON(data.d), function (item) {
                                var o = new Object();

                                o.label = item.Detalle;
                                o.value = item.Id;

                                return o;
                            }));
                        }
                    });
                },
                minLength: 3,
                //delay: 500,
                select: function (event, ui) {
                    //$("#ContentPlaceHolder1_busqueda").val(ui.item.label);
                    window.location.href = "PerfilSocial.aspx?id=" + ui.item.value;
                }
            });
        });
    </script>

</asp:Content>
