<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LogIn.ascx.cs" Inherits="nutricloud_webforms.LogIn" %>

<div class="col s12">
    <a class="modal-trigger" href="#modal1">Iniciar Sesión</a>
    <!-- Modal -->
    <div id="modal1" class="modal modal-fixed-footer">
        <div class="modal-content">
            <div class="modalrow green-nutri">
                <h4>Iniciar Sesión</h4>
            </div>
            <asp:UpdatePanel ID="UpdatePanelLogin" runat="server">
                <ContentTemplate>
                    <div class="row nomargin nobottom">
                        <div class="row nomargin nobottom">
                            <div class="col s12">
                                <label for="TxtEmail">Email</label>
                                <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                            </div>
                            <!--/.col s12-->
                        </div>
                        <div class="row nomargin nobottom">
                            <div class="col s12">
                                <label for="TxtPass">Contraseña</label>
                                <asp:TextBox TextMode="Password" ID="TxtPass" runat="server"></asp:TextBox>
                            </div>
                            <!--/.col s12-->
                        </div>
                        <asp:Panel ID="pnlErrores" runat="server" CssClass="panel-errores"></asp:Panel>
                    </div>
                    <!--/row-->
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ingresar" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:UpdateProgress ID="UpdateProgressLogin" runat="server">
                <ProgressTemplate>
                    <div class="row nomargin nobottom">
                        <div class="col s4 offset-s4 center">
                            <div class="preloader-wrapper small active">
                                <div class="spinner-layer spinner-green-only">
                                    <div class="circle-clipper left">
                                        <div class="circle"></div>
                                    </div>
                                    <div class="gap-patch">
                                        <div class="circle"></div>
                                    </div>
                                    <div class="circle-clipper right">
                                        <div class="circle"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="modal-footer">
                <asp:Button ID="ingresar" runat="server" Text="Ingresar" CssClass="btn waves-effect green-nutri" OnClick="Button_Aceptar_Click" />
                <a href="#">Olvidaste tu contraseña?</a>
            </div>
        </div>
    </div>
</div>
