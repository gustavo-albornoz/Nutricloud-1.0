<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carga_rapida.ascx.cs" Inherits="nutricloud_webforms.User_Control.Carga_rapida" %>


<a class="waves-effect waves-light btn orange lighten-1 modal-trigger" href="#modal_fav">
    <i class="material-icons left-i">star</i>
    Carga Rápida
</a>

<!-- Modal Favoritos -->
<div id="modal_fav" class="modal modal-fixed-footer">
    <div class="modal-content">
        <h5>Mis Favoritos</h5>
        <div class="row item-alimento">
            <!--<div class="col s8">
                    <a class="alimento" href="Alimento.aspx?Idalimento=79">Cuadril</a>
                </div>
                <div class="col s4">
                    <span class="calorias">0,00kcal</span>
                </div>-->
            <asp:Repeater ID="repalimentos" runat="server">
                <ItemTemplate>
                    <ul>
                        <li>
                            <h6><a href='Alimento.aspx?Idalimento=<%#Eval("id_alimento") %>'><%# Eval("alimento1") %></a></h6>
                            <span>
                                <asp:Label ID="LblCaloria" runat="server" Text='<%# Eval("energia_kcal") %>' CssClass="caloriab"></asp:Label>
                            </span>
                        </li>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Label ID="lblMsjSinResultados" runat="server"></asp:Label>
        </div>
    </div>
    <div class="modal-footer">
        <a href="#!" class="modal-action modal-close waves-effect waves-green btn-flat ">Agregar</a>
    </div>
</div>
