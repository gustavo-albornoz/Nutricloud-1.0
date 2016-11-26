<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="PerfilSocial.aspx.cs" Inherits="nutricloud_webforms.Pages.PerfilSocial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="container">
            <div class="row">
                <div class="col s12 text-center">
                    <h3>
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                    </h3>
                </div>
            </div>

            <div class="row">
                <div class="col s2 offset-s5">
                    <img class="imgperfil circle responsive-img" src="../Content/img/usuario.png">
                </div>
                <div class="col s3">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnSeguir" runat="server" OnClick="btnSeguir_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
    </div>

</asp:Content>
