//
var chart_1 = new Chart( $("#chart_1"), {
    type: 'bar',
    data: {
        labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
        datasets: [{
            label: '# of Votes',
            data: [12, 19, 3, 5, 2, 3],
            borderColor: 'rgba(255,99,132,1)',
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});


//
var data = {
    labels: ["Red", "Blue", "Yellow", "Green", "Purple", "Orange"],
    datasets: [{
        label: '# of Votes',
        data: [120, 19, 3, 5, 2, 3],
        borderColor: 'rgba(255,99,132,1)',
        borderWidth: 1,
        lineTension: 0
    }]
}

var chart_2 = new Chart( $("#chart_2"), {
    type: 'line',
    data: data,
   
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
        
    }
});