<%@ Page Title="" Language="C#" MasterPageFile="~/Anon.Master" AutoEventWireup="true" CodeBehind="Buscador.aspx.cs" Inherits="nutricloud_webforms.Buscador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row seccionHeader">
        <div class="container">
            <h3>Buscador de Alimentos</h3>
        </div>
    </div>
    <!--/seccionHeader-->

    <div class="container">
        <div class="row">
         

            <div class="col s12 home">
                <div class="divtop">
                    <asp:Button class="btn waves-effect orange btn-buscar" OnClick="Buscar_Click" runat="server" Text="Buscar"></asp:Button>
                    <asp:TextBox ID="TxtBuscar" type="text" size="30" class="altercalendar" runat="server" placeholder="Buscar alimentos" />
                </div>
                <div class="list-food buscador-food">
                    <div class="row">
                        <div class="col s12 m12 resultados">
                            <h5>Resultados de Búsqueda</h5>
                            <ul>
                                <asp:Repeater ID="repalimentos" runat="server">
                                    <ItemTemplate>
                                        <li>
                                            <h6><a href='Alimento.aspx?Idalimento=<%#Eval("id_alimento") %>'><%# Eval("nombre_alimento") %></a></h6>
                                            <span>
                                                <asp:Label ID="LblCaloria" runat="server" Text='<%# Eval("energia_kcal") %>' CssClass="caloriab"></asp:Label></span>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <asp:Label ID="lblMsjSinResultados" runat="server"></asp:Label>
                        </div>
                    </div>
                    <!--/row-->
                </div>
                <!--/listfood-->
            </div>
            <!--/col9-->
        </div>
        <!--/row-->
    </div>
    <!--/container-->
      <span class="ir-arriba icon-arrow-up2"><i class="material-icons">keyboard_arrow_up</i></span>

     <script>
        $(document).ready(function () {

            $('.ir-arriba').click(function () {
                $('body, html').animate({
                    scrollTop: '0px'
                }, 300);
            });

            $(window).scroll(function () {
                if ($(this).scrollTop() > 0) {
                    $('.ir-arriba').slideDown(300);
                } else {
                    $('.ir-arriba').slideUp(300);
                }
            });

        });
    </script>



</asp:Content>
