<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nutricloud_webforms.Default" %>

<%@ Register Src="~/User_Control/SignIn.ascx" TagPrefix="uc1" TagName="SignIn" %>
<%@ Register Src="~/User_Control/LogIn.ascx" TagPrefix="uc1" TagName="LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1.0, user-scalable=no" />
    <title>nutricloud</title>

    <!-- CSS  -->
    <link href="Content/materialize.css" type="text/css" rel="stylesheet" />
    <link href="Content/style.css" type="text/css" rel="stylesheet" />
    <link href="Content/responsive.css" type="text/css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="scripts/jquery.min.js" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <%--<link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css" />--%>
    <script src="scripts/modernizr.js"></script>

    <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet' type='text/css' />
    <link href='https://fonts.googleapis.com/css?family=Muli:400,300|Righteous' rel='stylesheet' type='text/css' />

    <!-- Icon -->
    <link rel="apple-touch-icon" sizes="57x57" href="Content/img/icon/apple-icon-57x57.png" />
    <link rel="apple-touch-icon" sizes="60x60" href="Content/img/icon/apple-icon-60x60.png" />
    <link rel="apple-touch-icon" sizes="72x72" href="Content/img/icon/apple-icon-72x72.png" />
    <link rel="apple-touch-icon" sizes="76x76" href="Content/img/icon/apple-icon-76x76.png" />
    <link rel="apple-touch-icon" sizes="114x114" href="Content/img/icon/apple-icon-114x114.png" />
    <link rel="apple-touch-icon" sizes="120x120" href="Content/img/icon/apple-icon-120x120.png" />
    <link rel="apple-touch-icon" sizes="144x144" href="Content/img/icon/apple-icon-144x144.png" />
    <link rel="apple-touch-icon" sizes="152x152" href="Content/img/icon/apple-icon-152x152.png" />
    <link rel="apple-touch-icon" sizes="180x180" href="Content/img/icon/apple-icon-180x180.png" />
    <link rel="icon" type="image/png" sizes="192x192" href="Content/img/icon/android-icon-192x192.png" />
    <link rel="icon" type="image/png" sizes="32x32" href="Content/img/icon/favicon-32x32.png" />
    <link rel="icon" type="image/png" sizes="96x96" href="Content/img/icon/favicon-96x96.png" />
    <link rel="icon" type="image/png" sizes="16x16" href="Content/img/icon/favicon-16x16.png" />
    <link rel="manifest" href="Content/img/icon/manifest.json" />
    <meta name="msapplication-TileColor" content="#ffffff" />
    <meta name="msapplication-TileImage" content="Content/img/icon/ms-icon-144x144.png" />
    <meta name="theme-color" content="#ffffff" />
</head>
<body id="top" class="scrollspy">
    <form id="formDefault" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Pre Loader -->
        <div id="loader-wrapper">
            <div id="loader"></div>

            <div class="loader-section section-left"></div>
            <div class="loader-section section-right"></div>

        </div>

        <div class="section no-pad-bot ptop" id="index-banner">
            <div class="navbar-fixed">
                <nav id="nav_f" class="header-index" role="navigation">
                    <div class="container">
                        <div class="nav-wrapper sticky">
                            <a id="logo-container" href="#top" class="brand-logo">
                                <img src="Content/img/logo.png" />nutricloud
                            </a>
                            <ul id="nav-mobile" class="right side-nav">
                                <li><a href="Pages/Blog.aspx">Blog</a></li>
                                <li><a href="Pages/Buscador.aspx">Alimentos</a></li>
                                <li><a href="#intro">Nosotros</a></li>
                                <li><%--Formulario LogIn--%>
                                    <uc1:LogIn runat="server" ID="LogIn" />
                                </li>
                            </ul>
                            <a href="#" data-activates="nav-mobile" class="button-collapse">
                                <i class="material-icons">menu</i>
                            </a>
                        </div>
                    </div>
                </nav>
            </div>
            <div class="container index-banner">
                <div class="row">
                    <div class="col l8 m12 s12 titulo-index">
                        <h1>Sentite saludable con Nutricloud
                        </h1>
                        <h4>La aplicación que te ayuda a alimentarte bien y lograr tu peso ideal.</h4>
                    </div>
                    <!--/.col7-->
                    <%--Formulario de SignIn--%>
                    <uc1:SignIn runat="server" ID="SignIn" />

                </div>
                <!--/.row-->
            </div>
            <!--/.container-->
        </div>
        <!--/.section no-pad-bot ptop-->

        <div id="intro" class="section scrollspy npad">
            <div class="container" id="scrollf">
                <!--   Icon Section   -->
                <div class="row">
                    <div class="col s12">
                        <h2 class="center header text_h2">Nada mejor que una aplicación para tu salud.
                        <span class="span_h2">nutricloud </span>te ofrece un control <span class="span_h2">24x7</span>, analizando tu alimentación y haciendo sugerencias en base a tu objetivo.
                        </h2>
                    </div>

                    <div class="col s12 m4 l4">
                        <div class="center promo promo-example">
                            <i class="material-icons">library_books</i>
                            <h5 class="promo-caption">Diario Alimentario</h5>
                            <p class="light center">Ingresá tu alimentación diaria y tu ingesta de líquidos; contamos con miles de opciones.</p>
                        </div>
                    </div>
                    <div class="col s12 m4 l4">
                        <div class="center promo promo-example">
                            <i class="material-icons">trending_up</i>
                            <h5 class="promo-caption">Seguimiento Personalizado</h5>
                            <p class="light center">Analizamos tu dieta y te ofrecemos alimentos alternativos para lograr tu objetivo.</p>
                        </div>
                    </div>
                    <div class="col s12 m4 l4">
                        <div class="center promo promo-example">
                            <i class="material-icons">done</i>
                            <h5 class="promo-caption">Asesoramiento</h5>
                            <p class="light center">Contamos con un grupo de profesionales para responder a todas tus preguntas.</p>
                        </div>
                    </div>
                </div>
                <!--/.row-->
            </div>
            <!--/.container-->
        </div>
        <div class="container-resp green-nutri">
            <div class="row row-resp">
                <div class="resp-align">
                    <div class="col s12 m12 l6 txt-resp">
                        <p>
                            <h3>Podés disfrutar de nutricloud en cualquier dispositivo que tengas sin necesidad de instalar nada.
                            <br />
                                Es simple, rápido y cómodo!
                            </h3>
                        </p>
                    </div>
                    <div class="col s12 m12 l6 img-resp">
                        <img class="responsive-img" src="Content/img/responsive.png" />
                    </div>
                </div>
            </div>
        </div>


        <div class="section scrollspy" id="work">
            <div class="container">
                <h3 class="header text_b">Cómo funciona?</h3>
                <div class="row">
                    <div class="col s12 m4 l4">
                        <div class="card">
                            <div class="card-image waves-effect waves-block waves-light">
                                <img class="activator" src="Content/img/card3.jpg"/>
                            </div>
                            <div class="card-content green-nutri">
                                <span class="card-title activator white-text">Base de datos
                                <i class="material-icons right icon-plus">add</i>
                                </span>
                            </div>
                            <div class="card-reveal">
                                <span class="card-title white-text">
                                    <i class="material-icons right icon-plus orange-text">clear</i>
                                    Base de datos de alimentos
                                </span>
                                <p>Contamos con alimentos y productos alimenticios por peso, cantidad y porciones. También podés averiguar los valores nutricionales de los mismos.</p>
                            </div>
                        </div>
                    </div>

                    <div class="col s12 m4 l4">
                        <div class="card">
                            <div class="card-image waves-effect waves-block waves-light">
                                <img class="activator" src="Content/img/card2.jpg"/>
                            </div>
                            <div class="card-content green-nutri">
                                <span class="card-title activator white-text">Estadísticas
                                <i class="material-icons right icon-plus">add</i>
                                </span>
                            </div>
                            <div class="card-reveal">
                                <span class="card-title white-text">
                                    <i class="material-icons right icon-plus orange-text">clear</i>
                                    Estadísticas de tu progreso
                                </span>
                                <p>Si necesitás un reporte de tu evolución, podrás descargarlo con todo el detalle de tu ingesta y la evolución de tu peso.</p>
                            </div>
                        </div>
                    </div>

                    <div class="col s12 m4 l4">
                        <div class="card">
                            <div class="card-image waves-effect waves-block waves-light">
                                <img class="activator" src="Content/img/card4.jpg"/>
                            </div>
                            <div class="card-content green-nutri">
                                <span class="card-title activator white-text">Blog de nutrición
                                <i class="material-icons right icon-plus">add</i>
                                </span>
                            </div>
                            <div class="card-reveal">
                                <span class="card-title white-text">
                                    <i class="material-icons right icon-plus orange-text">clear</i>
                                    Blog de nutrición
                                </span>
                                <p>Los mejores posts de nutrición con recetas, tips y noticias.</p>
                            </div>
                        </div>
                    </div>
                </div>
                <!--/.row-->
            </div>
        </div>



        <footer id="contact" class="page-footer scrollspy">
            <div class="container">
                <div class="row nobottom">

                    <div class="col l6 s12">
                        <p class="grey-text text-lighten-4">
                            Nutricloud es comer saludable y vivir mejor.<br />
                            2016&reg; Todos los derechos reservados.
                        </p>

                    </div>
                </div>
            </div>
            <!--
        <div class="footer-copyright  grey darken-3">
          <div class="container">
            Made by <a class="white-text" href="#">Nutricloud</a>
          </div>
        </div>-->
        </footer>
    </form>

    <!--  Scripts-->
    <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script src="scripts/materialize.js"></script>
    <script src="scripts/init.js"></script>
    <script src="scripts/Chart.min.js"></script>

    <!--script nav-->
    <script>
        $(window).scroll(function () {
            if ($(this).scrollTop() > 550) {
                $('nav').addClass("sticky");
            }
            else {
                $('nav').removeClass("sticky");
            }
        });
    </script>

    <!--Modal-->
    <script>
        $(document).ready(function () {
            $('.modal-trigger').leanModal();
        });
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            var options = [


        {
            selector: '#scrollf', offset: 10, callback: function ()

            { Materialize.showStaggeredList("#scrollf"); }
        },

            ];

            Materialize.scrollFire(options);

        });
    </script>
</body>
</html>
