$(document).ready(function () {

    $('#datosfis').on('click', function (event) {
        event.preventDefault();
        $('.mostrarrow').slideToggle("slow");
        $('.arrowp').toggleClass('arrow-rotate');
    })

    $('#datosing').on('click', function (event) {
        event.preventDefault();
        $('.mostrarrow2').slideToggle("slow");
        $('.arrowp2').toggleClass('arrow-rotate');
    })

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

 
    $("#fechaNac").datepicker();
    $("#fechaNac").removeClass("hasDatepicker");

});

