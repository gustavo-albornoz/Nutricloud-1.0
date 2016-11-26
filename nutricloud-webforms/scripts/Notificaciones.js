$(document).ready(function(){

    getNotificaciones();
    
    function getNotificaciones() {

        $.ajax({
            type: "POST",
            url: "Notificaciones.aspx/getNotificaciones",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false
        }).then(function (response) {
            setNotificaciones(response);
        });
    }

    function getNombreMes(number) {
        var monthNames = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio",
            "Agosto", "Septiembre", "Octubre", "Noviembre", "Deciembre"];

        return monthNames[number];
    };

    function getFechaNotificacion(fecha) {

        var dt = parseInt(fecha.substring(6, fecha.length - 2));
        var dateNotificacion = new Date(dt);
        var dateActual = new Date();

        if ( dateNotificacion.getFullYear() == dateActual.getFullYear() 
            && dateNotificacion.getMonth() == dateActual.getMonth() 
            && dateNotificacion.getDate() == dateActual.getDate()) {

            var horas = dateActual.getHours() - dateNotificacion.getHours();

            if (horas != 0) {
                var fecha = "Hace " + horas + " horas";
            } else {
                var minutos = dateActual.getMinutes() - dateNotificacion.getMinutes();
                var fecha = "Hace " + minutos + " minutos";
            }
           
        } else {
            var fecha = dateNotificacion.getDate() + " de " + getNombreMes(dateNotificacion.getMonth()) + " a las " + dateNotificacion.getHours() + ":" + dateNotificacion.getMinutes();
        }
        
        return fecha;
    }

    function setNotificaciones(parameter) {

        var notificaciones = parameter.d;

        notificaciones.forEach(function (n) {

            var strNode = "<li class='collection-item notificacion'>" + n.notificacion.nombre_autor_nota + " public&oacute; una nota nueva: " + n.notificacion.titulo_nota
                + "<div class='fechaNotificacion'>" + getFechaNotificacion(n.fecha) + "<div>"
                + "</li>";

            var node = $.parseHTML(strNode)[0];
            
            if (!n.notificacion.leida_notificacion) {
                $(node).addClass("notificacion_no_vista");
            }

            $(node).attr("data-id-nota", n.notificacion.id_nota);
            $(node).attr("data-id-notificacion", n.notificacion.id_notificacion);
            $(node).attr("data-tipo-notificacion", "BLOG_NOTA");
            $("#notificaciones").append(node);

            $(node).click(function (node) {

                var idNota = parseInt($(node.target).attr("data-id-nota"));
                var idNotificacion = parseInt($(node.target).attr("data-id-notificacion"));
                var tipoNotificacion = $(node.target).attr("data-tipo-notificacion");

                var data = { id: idNotificacion, tipo: tipoNotificacion };

                $.ajax({
                    type: "POST",
                    url: "Notificaciones.aspx/marcarComoLeida",
                    data: JSON.stringify(data),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json"
                }).then(function () {
                    var url = window.location.protocol + "//" + window.location.host + "/Pages/Nota.aspx?id=" + idNota;
                    window.location.href = url;
                });

            });
        })
    }
});