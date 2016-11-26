<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Mensajes.ascx.cs" Inherits="nutricloud_webforms.User_Control.Mensajes" %>
<div class="container mensajes">
    <div class="row">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="col l6 m6 s12 leftmsg">
                    <h5>Mensajes con Profesionales</h5>
                    <%--Lista de conversaciones--%>
                    <ul>
                        <asp:Repeater ID="rConversaciones" runat="server" OnItemDataBound="rConversaciones_ItemDataBound">
                            <ItemTemplate>
                                <li>
                                    <asp:LinkButton ID="LnkConv" CommandArgument='<%# Eval("id_consulta_conversacion") %>' runat="server" OnClick="lnkConversacion_Click"><%# Eval("asunto") %></asp:LinkButton>
                                    <i class="material-icons">keyboard_arrow_right</i>
                                    <asp:Label ID="lblMsjsNoLeidos" runat="server" CssClass="new badge green-nutri" Visible="false"></asp:Label>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>

                <div class="col l6 m6 s12 rightmsj">
                    <%--Mensaje seleccionado / Nuevo--%>
                    <div class="btn-newc">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nueva Consulta" OnClick="btnNuevo_Click" />
                    </div>
                    <div>
                        <asp:Panel ID="pnlMsjs" runat="server"></asp:Panel>
                    </div>
                    <div class="container-cerrar">
                        <asp:Label ID="lblCerrada" runat="server" Visible="false" CssClass="text-error" Text="Conversación cerrada"></asp:Label>
                        <asp:Button ID="btnCerrar" runat="server" Visible="false" CssClass="btn waves-effect orange waves-input-wrapper" Text="Cerrar" OnClick="btnCerrar_Click1" />
                    </div>
                    <asp:Panel ID="pnlNuevoMsj" runat="server">
                        <label for="TxtAsunto">Asunto</label>
                        <asp:TextBox ID="TxtAsunto" runat="server"></asp:TextBox>
                        <label for="TxtMensaje">Mensaje</label>
                        <asp:TextBox ID="TxtMensaje" runat="server"></asp:TextBox>
                        <asp:Button ID="btnenviar" runat="server" Text="Enviar" CssClass="btn waves-effect enviarmsj" OnClick="btnenviar_Click" AutoPostback="true" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
