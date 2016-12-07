<%@ Page Title="" Language="C#" MasterPageFile="~/HeaderFooter.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="nutricloud_webforms.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../scripts/Perfil.js"></script>
    <div class="row seccionPerfil">
        <div class="container">
            <h3>Perfil</h3>
        </div>
    </div>
    <div class="container">
        <%--Información general--%>
        <div class="row">
            <div class="col l9 m9 s12 perfil">
                <div class="divtop">
                    <a href="javascript:void(0);" class="listaHeader">
                        <h4>Información General</h4>
                    </a>
                    <asp:Label ID="lblAviso" runat="server" Text="" Font-Bold="true" CssClass="btn-link btn-lg aviso" Style="text-decoration: none"></asp:Label>
                    <div class="row">
                        <ul class="infogral datosp">
                            <li>
                                <div class="row nobottom">
                                    <div class="col l6 s12">
                                        <h6>Miembro desde:
                                        <asp:Label ID="LblFechaRegistro" runat="server" Text="Label"></asp:Label>
                                        </h6>
                                    </div>
                                    <div class="col l6 s12">
                                        <h6>Último ingreso:
                                        <asp:Label ID="LblFechaUltimoIngreso" runat="server" Text="Label"></asp:Label>
                                        </h6>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row">
                                    <div>
                                        <asp:Image ID="imgPerfil" ImageUrl="../Content/img/usuario.png" CssClass="imgperfil circle responsive-img" runat="server" />
                                    </div>
                                </div>
                                <div class="row nobottom">
                                    <div class="col s10">
                                        <asp:FileUpload ID="fileImgPerfil" runat="server" />
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row marginrow nobottom">
                                    <div class="col l3 s12">
                                        <h6>Email:</h6>
                                    </div>
                                    <div class="col l9 s12">
                                        <asp:Label ID="LblEmail" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row marginrow nobottom">
                                    <div class="col l3 s12">
                                        <h6>Nombre:</h6>
                                    </div>
                                    <div class="col l9 s12">
                                        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row marginrow nobottom">
                                    <div class="col l3 s12">
                                        <h6>Fecha de nacimiento: </h6>
                                    </div>
                                    <div class="col l9 s12">
                                        <asp:TextBox ID="TxtFechaNacimiento" runat="server" CssClass="datepicker fecha" TextMode="Date"></asp:TextBox>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row marginrow nobottom">
                                    <div class="col l3 s12">
                                        <h6>Fecha de nacimiento con datePicker: </h6>
                                    </div>
                                    <div class="col l9 s12">
                                        <input id="fechaNac" type="date" class="datepicker">
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row marginrow nobottom">
                                    <h6>Género:</h6>
                                    <asp:RadioButtonList ID="rblGenero" runat="server"></asp:RadioButtonList>
                                </div>
                            </li>
                            <asp:Panel ID="pnlErroresInfoGral" runat="server" CssClass="panel-errores"></asp:Panel>
                            <li class="row btn-registro nomargin nobottom">
                                <asp:Button ID="btnActualizarInfoGral" runat="server" CssClass="btn waves-effect orange waves-input-wrapper" Text="Actualizar" OnClick="btnActualizarInfoGral_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <%-- //Información general --%>

        <%--Datos físicos--%>
        <div class="row nobottom" id="divDatosFisicos" runat="server">
            <div class="col l9 m9 s12 perfil">
                <div class="divtop">
                    <a href="javascript:void(0);" class="listaHeader" id="datosfis">
                        <h4>Datos Físicos </h4>
                        <i class="material-icons arrowp">keyboard_arrow_down</i>
                    </a>
                    <asp:Label ID="LblAviso2" runat="server" Text="" Font-Bold="true" CssClass="btn-link btn-lg aviso" Style="text-decoration: none"></asp:Label>
                    <div class="row mostrarrow">
                        <ul class="infogral datosp nobottom">
                            <li>
                                <div class="row nobottom">
                                    <div class="col l3 s12">
                                        <h6>Peso Actual (Kg): </h6>
                                    </div>
                                    <div class="col l9 s12">
                                        <asp:TextBox ID="TxtPeso" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row nobottom">
                                    <div class="col l3 s12">
                                        <h6>Altura (Cm): </h6>
                                    </div>
                                    <div class="col l9 s12">
                                        <asp:TextBox ID="TxtAltura" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <h6 style="float: left;">Actividad: </h6>
                                <div class="questionp">
                                    <span class="actividadp">¿Qué actividad debo elegir?</span>
                                    <div class="showup">
                                        <div class="arrow" style="left: 104.5px;"></div>
                                        <div class="popover-content">
                                            <div>
                                                <p>
                                                    <b>Sedentario</b> – Actividades de la vida diaria, trabajo de escritorio o conducir. 
                                                    Puede incluir tareas de hogar moderadas y de pie, sin realización de ejercicios.
                                                </p>
                                                <p>
                                                    <b>Poco Activo</b> – Además de las actividades de la vida diaria, efectúa actividades más intensas, 
                                                    tales como largos períodos de pie o tareas del hogar. Algún tipo de ejercicio ligero, tal como caminar o andar lento en bicicleta.
                                                </p>
                                                <p>
                                                    <b>Activo</b> – Un mínimo sentado o descansando y puede trabajar de pie o efectuando alguna labor física. 
                                                    Realizan regularmente ejercicio moderado, como bailar, caminar a paso ligero o nadar.
                                                </p>
                                                <p>
                                                    <b>Deportista</b> – Ambiente de trabajo físicamente intensivo, como la construcción y/o realizar actividades vigorosas la mayoría de los días de la semana, 
                                                    como correr, usando aparatos de gimnasio o participar en deportes físicos. 
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <asp:RadioButtonList ID="rblActividad" runat="server"></asp:RadioButtonList>
                            </li>
                            <li>
                                <h6>Objetivo: </h6>
                                <asp:RadioButtonList ID="rblObjetivo" runat="server"></asp:RadioButtonList>
                            </li>
                            <asp:Panel ID="pnlErroresDatosFisicos" runat="server" CssClass="panel-errores"></asp:Panel>
                            <li class="row btn-registro nomargin nobottom">
                                <asp:Button ID="btnActualizarDatosFisicos" runat="server" CssClass="btn waves-effect orange btn-ingresar" Text="Actualizar Datos Físicos" OnClick="btnActualizarDatosFisicos_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <%-- //Datos físicos --%>

        <%-- Ingesta diaria --%>
        <div class="row" id="divIngestaDiaria" runat="server">
            <div class="col l9 m9 s12 perfil">
                <div class="divtop">
                    <a href="javascript:void(0);" class="listaHeader" id="datosing">
                        <h4>Ingesta Diaria Recomendada </h4>
                        <i class="material-icons arrowp2">keyboard_arrow_down</i>
                    </a>
                    <div class="row mostrarrow2">
                        <ul class="infogral datosp">
                            <li>
                                <h6>Carbohidratos (Gr.): </h6>
                                <asp:Label ID="CCarbo" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Proteinas (Gr.): </h6>
                                <asp:Label ID="CProt" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Grasas (Gr.): </h6>
                                <asp:Label ID="CGrasas" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Agua (Gr.): </h6>
                                <asp:Label ID="CAgua" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Fibra (Gr.): </h6>
                                <asp:Label ID="CFibra" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Calcio (Mg.): </h6>
                                <asp:Label ID="CCalcio" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Hierro (Mg.): </h6>
                                <asp:Label ID="CHierro" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Fosforo (Mg.): </h6>
                                <asp:Label ID="CFosfo" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Zinc (Mg.): </h6>
                                <asp:Label ID="CZinc" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Potasio (Mg.): </h6>
                                <asp:Label ID="CPot" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Colesterol (Mg.): </h6>
                                <asp:Label ID="CCol" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Sodio (Mg.): </h6>
                                <asp:Label ID="CSodio" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Vitamina B1 (Mg.): </h6>
                                <asp:Label ID="CVB1" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Vitamina B2 (Mg.): </h6>
                                <asp:Label ID="CVB2" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Vitamina B3 (Mg.): </h6>
                                <asp:Label ID="CVB3" runat="server"></asp:Label>
                            </li>
                            <li>
                                <h6>Vitamina C (Mg.): </h6>
                                <asp:Label ID="CVitc" runat="server"></asp:Label>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <span class="ir-arriba icon-arrow-up2"><i class="material-icons">keyboard_arrow_up</i></span>
        <%-- //Ingesta diaria --%>

        <!--<div class="row">
            <div class="divtop">
                <h4 class="listaHeader">Mis recetas</h4>
                <div class="row mtop">
                </div>
            </div>
        </div>-->
    </div>

    <script></script>
</asp:Content>
