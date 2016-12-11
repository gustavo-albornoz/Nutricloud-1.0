$(document).ready(function () {

    $('.collapsible').collapsible();

    $('.show').on('click', function (event) {
        event.preventDefault;
        $(this).closest(".rec").find(".recomendacion").slideToggle("fast");
    });

    $.ajax({
        type: "POST",
        url: "ReportesPDF.aspx/cargaRepoDia",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: setRepoDia,
        error: function (msg) {
            alert("Hubo un error en la grafica diaria");
        }
    });

    function setRepoDia(response) {
        var reporteD = response.d;
        var arr = [];

        reporteD = JSON.parse(reporteD);

        for (var key in reporteD) {
            // arr.push(resultados, reporteD[resultados])
            var tmpArray = [];
            tmpArray.push(key);
            tmpArray.push(reporteD[key]);
            arr.push(tmpArray);
        }

        var plot1 = jQuery.jqplot('chartdia', [arr],
            {
                seriesDefaults: {
                    // Make this a pie chart.
                    renderer: $.jqplot.PieRenderer,
                    rendererOptions: {
                        // Put data labels on the pie slices.
                        // By default, labels show the percentage of the slice.
                        showDataLabels: true,
                        seriesColors: ["#f44336", "#2196f3", "#ffeb3b", "#ff5252", "#4caf50", "#e040fb", "#ff9800"]

                    }
                },
                legend: { show: true, location: 'e' }
            });
    }

    window.onresize = function (event) {
        plot1.replot({ resetAxes: true });
    }

    $.ajax({
        type: "POST",
        url: "ReportesPDF.aspx/cargaRepoQuince",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: setRepoQuince,
        error: function (msg) {
            alert("Hubo un error en la grafica quincenal");
        }
    });

    function setRepoQuince(response) {

        var reporteQ = response.d;
        var arr1 = [];
        var arr2 = [];
        var arr3 = [];
        var arr4 = [];
        var arr5 = [];

        reporteQ = JSON.parse(reporteQ);

        for (var key in reporteQ[0]) {
            // arr.push(resultados, reporteD[resultados])
            var tmpArray = [];
            tmpArray.push(key);
            tmpArray.push(reporteQ[0][key]);
            arr1.push(tmpArray);
        }
        for (var key in reporteQ[1]) {
            // arr.push(resultados, reporteD[resultados])
            var tmpArray = [];
            tmpArray.push(key);
            tmpArray.push(reporteQ[1][key]);
            arr2.push(tmpArray);
        }
        for (var key in reporteQ[2]) {
            // arr.push(resultados, reporteD[resultados])
            var tmpArray = [];
            tmpArray.push(key);
            tmpArray.push(reporteQ[2][key]);
            arr3.push(tmpArray);
        }
        for (var key in reporteQ[3]) {
            // arr.push(resultados, reporteD[resultados])
            var tmpArray = [];
            tmpArray.push(key);
            tmpArray.push(reporteQ[3][key]);
            arr4.push(tmpArray);
        }
        for (var key in reporteQ[4]) {
            // arr.push(resultados, reporteD[resultados])
            var tmpArray = [];
            tmpArray.push(key);
            tmpArray.push(reporteQ[4][key]);
            arr5.push(tmpArray);
        }

        var plot2 = $.jqplot('chartquince', [arr1, arr2, arr3, arr4, arr5],
            {
                /*title: 'Customized Date Axis',*/
                legend: { show: true },
                axes: {
                    xaxis: {
                        renderer: $.jqplot.DateAxisRenderer,
                        tickRenderer: $.jqplot.CanvasAxisTickRenderer,
                        tickOptions: {
                            angle: -30,
                            formatString: '%d-%b-%Y'
                        }
                    },
                    yaxis: {
                        label: 'gramos'
                    }

                },
                series: [{
                    lineWidth: 4,
                    markerOptions: { style: 'circle' },
                }],
                series: [
                            { label: 'Proteina' },
                            { label: 'Carbohidratos' },
                            { label: 'Grasas' },
                            { label: 'Agua' },
                            { label: 'Fibra' }
                ],
            });
    }

    window.onresize = function (event) {
        plot2.replot({ resetAxes: true });
    }

});