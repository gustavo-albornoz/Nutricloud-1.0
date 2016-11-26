$(function () {

    CargaComidas();

    $("#datepicker").datepicker({
        showOn: "button",
        buttonImage: "../../content/img/calendario.png",
        buttonImageOnly: true,
        buttonText: "Seleccione la Fecha",
        altField: "#alternate",
        altFormat: "DD, d MM, yy",
        onSelect: function () {
            CargaComidas();
        }
    });

    // seteo la fecha de hoy
    $('#datepicker').datepicker().datepicker('setDate', 'today');

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

function getCargaRapida(event) {
    $.ajax({
        type: "POST",
        url: "Home.aspx/cargaRapida",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            setCargaRapida(response.d, event);
        },
        error: function (msg) {
            alert("Hubo un error en getCargaRapida")
        }
    });
}

function setCargaRapida(favoritos, event) {

    favoritos.forEach(function (f) {

        var strFav = "<div class='row favorito'>" +
        "<div class='col s9'>" +
        "<p>" +
        "<input class='checkBoxCR' type='checkbox' id='c" + f.id + "' />" +
        "<label class='nombre' for='c" + f.id + "'>" + f.nombre + "</label>" +
        "<input type='hidden' class='idAlimento' value='" + f.id + "' />" +
        "<input type='hidden' class='kcalAlimento' value='" + f.kcal + "' />" +
        "<input type='hidden' class='nombreAlimento' value='" + f.nombre + "' />" +
        "<input type='hidden' class='idUsuarioAlimento' value='' />" +
        "</p>" +
        "</div>" +
        "<div class='input-field col s3'>" +
        "<input class='porcionCR' id='p" + f.id + "' type='text' class='validate' disabled>" +
        "<label class='labelPorcionCR' for='p" + f.id + "' data-error='wrong' data-success='right'>Porci&oacute;n</label>" +
        "</div>" +
        "</div>";

        // convierto el string a html 
        var htmlFav = $.parseHTML(strFav)[0];
        // lo appendeo en el div #alimentos
        $("#alimentos").append(htmlFav);
    });

    // string del boton "Agregar" que tiene en el atributo "data-tipo-consumo" el tipo de comida
    var strBoton = "<a href='#' data-tipo-consumo='" + event.target.dataset.tipoComida + "' class='modal-action modal-close waves-effect waves-green btn-flat'>Agregar</a>"
    // convierto el string a html
    var htmlBoton = $.parseHTML(strBoton)[0];
    // lo appendeo en el div #agregarCargaRapida
    $("#agregarCargaRapida").append(htmlBoton);

    // seteo el evento click de boton "Agregar"
    $(htmlBoton).click(function (node) {

        debugger;
        if (!validarCargaRapida2()) {
            alert("Hay campos vacíos o con formato incorrecto");
            return;
        }

        // obtengo del atributo data-tipo-consumo el tipo de comida
        var tipoConsumo = node.target.dataset.tipoConsumo;
        /*
        // obtengo todos nodos que tenga la clase .favorito, que son los nodos que contienen todo el html del favorito
        var favoritos = $(".favorito");
        
        // los itero
        for (var i = 0; i < favoritos.length; i++) {

            // obtengo el valor de la propiedad checked de cada CheckBox
            var favoritoChekeado = $(favoritos[i]).find(".checkBoxCR")[0].checked;

            // si el favorito esta chekeado
            if (favoritoChekeado) {

                //obtengo los datos del favorito
                var nombre = $(favoritos[i]).find(".nombre")[0].textContent;
                var porcion = $(favoritos[i]).find(".porcionCR")[0].value;
                var idAlimento = $(favoritos[i]).find(".idAlimento")[0].value;
                var kcalAlimento = $(favoritos[i]).find(".kcalAlimento")[0].value;
                
                // obtengo las calorias totales
                var kcalTotal = (kcalAlimento * porcion) / 100;

                // string del html que va a ir al diario
                var strF = "<div class='row item-alimento'>" +
                    "<div class='col s8'>" +
                    "<a class='alimento' href='Alimento.aspx?Idalimento=" + idAlimento + "'>" + nombre + "</a>" +
                    "<input type='hidden' class='idUsuarioAlimento' value='' />" +
                    "<input type='hidden' class='idAlimento' value='" + idAlimento + "' />" +
                    "</div>" +
                    "<div class='col s4' style='text-align: right'>" +
                    "<span class='cantidadCalorias'>" + kcalTotal.toString().replace(".", ",") + "</span><span> kcal</span>" +
                    "</div>" +
                    "<div class='col s12'>" +
                    "<span class='cantidadPorcion'>" + porcion + "</span><span> gr</span>" +
                    "</div>" +
                    "</div>";
                          
                // lo convierto a html
                var htmlF = $.parseHTML(strF)[0];
                // lo appendeo
                $("#" + tipoConsumo + "-listado").append(htmlF);

            };
            
        }

        // obtengo todas la calorias de los alimentos de ese tipo de comida
        var calorias = $("#" + tipoConsumo).find(".cantidadCalorias");
        var totalCalorias = 0;

        // itero y acumulo las calorias
        for (var i = 0; i < calorias.length; i++) {
            var cal = parseFloat(calorias[i].textContent);
            totalCalorias = totalCalorias + cal;
        }

        // la seteo en el total del html
        $("#" + tipoConsumo).find(".total_cal")[0].textContent = totalCalorias.toString().replace(".", ",");
        */

        actualizarDiario2(tipoConsumo);
        // elimino el contenido del div que tiene todos los favoritos
        $("#alimentos").empty();
        // y elimino el boton "AGREGAR"
        $("#agregarCargaRapida").empty();
        // cierro el modal
        $('.modal').closeModal();
    });

    validarCargaRapida();
}

function CargaComidas() {

    var fechaSeleccionada = $("#alternate").val();

    $.ajax({
        type: "POST",
        url: "Home.aspx/getAlimentos",
        data: "{fecha:'" + fechaSeleccionada + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#lista-comidas").html(response.d);
            $('.modal-trigger').leanModal({
                complete: function () {
                    // elimino el contenido del div que tiene todos los favoritos
                    $("#alimentos").empty();
                    // y elimino el boton "AGREGAR"
                    $("#agregarCargaRapida").empty();
                }
            });

            $('.cargaRapida').click(function (event) {
                getCargaRapida(event);
            });
        },
        error: function (msg) {
            alert("error en cargaComidas()");
        }
    });
}

function actualizarDiario() {

    var request = {};
    // esta array va contener los datos de todos los alimentos del diario
    var diario = [];
    // obtengo todos los tipos de comida del diario
    var tiposDeComida = $(".tipoComida");

    for (var i = 0; i < tiposDeComida.length; i++) {

        // obtengo los alimentos del tipo de comida
        var alimentos = $(tiposDeComida[i]).find(".item-alimento");

        for (var j = 0; j < alimentos.length; j++) {

            // de cada alimentos obtengo sus datos
            var cantidad = $(tiposDeComida[i]).find(".cantidadPorcion")[j].textContent;
            var idAlimento = $(tiposDeComida[i]).find(".idAlimento")[j].value;
            var idUsuarioAlimento = $(tiposDeComida[i]).find(".idUsuarioAlimento")[j].value;
            var fecha = new Date();

            // los guardo en un json
            var a = {
                cantidad: cantidad,
                idAlimento: idAlimento,
                fecha: fecha,
                tipoDeComida: tiposDeComida[i].id,
                idUsuarioAlimento: idUsuarioAlimento
            };

            // y los aniado a la lista
            diario.push(a);
        }
    }


    // lo aniado al request
    request.diario = diario;

    $.ajax({
        type: "POST",
        url: "Home.aspx/actualizarDiario",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            // como la operacion fue exitosa cargo de vuelta el diario
            CargaComidas();
        },
        error: function (msg) {
            alert("actualizarDiario()");
        }
    });
}

function eliminar(idUsuarioAllimento) {
    $.ajax({
        type: "POST",
        url: "Home.aspx/deleteAlimentos",
        data: "{id_usuario_alimento:'" + idUsuarioAllimento + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            CargaComidas();
        }
    });
}

function validarCargaRapida() {
    // obtengo todos nodos que tenga la clase .favorito, que son los nodos que contienen todo el html del favorito
    var favoritos = $(".favorito");

    // los itero
    favoritos.toArray().forEach(function (favorito) {

        var c = $(favorito).find(".checkBoxCR")[0];
        var p = $(favorito).find(".porcionCR")[0];
        var lp = $(favorito).find(".labelPorcionCR")[0];

        $(p).blur(function (node) {

            var value = node.target.value;

            if (!/^[0-9]{1,5}$/.test(value) || parseInt(value) == 0) {
                $(node.target).addClass("invalid");
                alert("Vacío o formato incorrecto");
            } else {
                $(node.target).removeClass("invalid");
            }

        });

        $(c).click(function () {
            if (p.disabled) {
                p.disabled = false;
            } else {
                p.disabled = true;
                $(p).val("");

                if ($(p).hasClass("invalid")) {
                    $(p).removeClass("invalid");
                }

                if ($(lp).hasClass("active")) {
                    $(lp).removeClass("active");
                }
            }

        })

    });

}

function validarCargaRapida2() {

    // obtengo todos nodos que tenga la clase .favorito, que son los nodos que contienen todo el html del favorito
    var favoritos = $(".favorito");
    var todoValidado = true;

    // los itero
    for (var i = 0; i < favoritos.length; i++) {

        // obtengo el valor de la propiedad checked de cada CheckBox
        var favoritoChekeado = $(favoritos[i]).find(".checkBoxCR")[0].checked;

        // si el favorito esta chekeado
        if (favoritoChekeado) {

            var porcion = $(favoritos[i]).find(".porcionCR")[0].value;

            if (!/^[0-9]{1,5}$/.test(porcion) || parseInt(porcion) == 0) {
                todoValidado = false;
            }

        };

    }

    return todoValidado;
}

function actualizarDiario2(tipocomida) {

    var request = {};
    // esta array va contener los datos de todos los alimentos del diario
    var diario = [];
    // obtengo todos nodos que tenga la clase .favorito, que son los nodos que contienen todo el html del favorito
    var favoritos = $(".favorito");

    // los itero
    for (var i = 0; i < favoritos.length; i++) {

        // obtengo el valor de la propiedad checked de cada CheckBox
        var favoritoChekeado = $(favoritos[i]).find(".checkBoxCR")[0].checked;

        // si el favorito esta chekeado
        if (favoritoChekeado) {

            //obtengo los datos del favorito
            var nombre = $(favoritos[i]).find(".nombre")[0].textContent;
            var cantidad = $(favoritos[i]).find(".porcionCR")[0].value;
            var idAlimento = $(favoritos[i]).find(".idAlimento")[0].value;
            var kcalAlimento = $(favoritos[i]).find(".kcalAlimento")[0].value;

            // los guardo en un json
            var alimento = {
                cantidad: cantidad,
                idAlimento: idAlimento,
                fecha: $("#datepicker").datepicker("getDate"),
                tipoDeComida: tipocomida
            };

            diario.push(alimento);
        };
    }

    request.diario = diario;

    $.ajax({
        type: "POST",
        url: "Home.aspx/actualizarDiario",
        data: JSON.stringify(request),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            // como la operacion fue exitosa cargo de vuelta el diario
            CargaComidas();
            // pongo el scroll en el tipo comida 
            window.location.hash = "#" + tipocomida + "-listado";
        },
        error: function (msg) {
            alert("actualizarDiario()");
        }
    });
}