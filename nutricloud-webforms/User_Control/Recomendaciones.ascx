<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Recomendaciones.ascx.cs" Inherits="nutricloud_webforms.User_Control.Recomendaciones" %>



<asp:Label ID="lblErrorAyer" runat="server" Text="Los valores estan debajo de los minimos como para poder evaluar. Completa tu ingesta mas detalladamente." Visible="false"></asp:Label>

<div id="divRecomendaciones" runat="server">
    <div class="row">
        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlCalorias" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Calorías</span>
                    <p id="pCalorias" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rCalorias"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlCarbohidratos" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Carbohidratos</span>
                    <p id="pCarbohidratos" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rCarbohidratos"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlProteinas" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Proteínas</span>
                    <p id="pProteinas" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rProteinas"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlGrasas" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Grasas</span>
                    <p id="pGrasas" runat="server"></p>
                     <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rGrasas"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

    <div class="row">
        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlFibra" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Fibra</span>
                    <p id="pFibra" runat="server"></p>
                     <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rFibra"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlAgua" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Agua</span>
                    <p id="pAgua" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rAgua"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlPotasio" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Potasio</span>
                    <p id="pPotasio" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rPotasio"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlSodio" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Sodio</span>
                    <p id="pSodio" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rSodio"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>

    <div class="row">
        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlCalcio" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Calcio</span>
                    <p id="pCalcio" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rCalcio"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlHierro" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Hierro</span>
                    <p id="pHierro" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rHierro"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlFosforo" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Fósforo</span>
                    <p id="pFosforo" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rFosforo"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="col s12 m6 l3">
            <asp:Panel ID="pnlColesterol" runat="server" CssClass="card">
                <div class="card-content grey-text text-darken-3">
                    <span class="card-title grey-text text-darken-3">Colesterol</span>
                    <p id="pColesterol" runat="server"></p>
                    <div class="rec">
                        <asp:Button cssClass="show btn_rec btn cyan lighten-5" runat="server" text="Qué hacer?" OnClientClick="return false;"/>
                        <div class="recomendacion">
                            <p runat="server" id="rColesterol"></p>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</div>

