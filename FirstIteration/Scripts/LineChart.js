
$(document).ready(function () {
    //Load Data Here
    var chartData = null;
    $.ajax({
        url: '/Chart/GetSalesData',
        type: 'GET',
        dataType: 'json',
        data: '',
        success: function (d) {
            chartData = d;
        },
        error: function () {
            alert('Error!');
        }

    }).done(function () {
        drawChart(chartData);
    });
});

function drawChart(d) {
    var chartData = d;
    var data = null;
    data = google.visualization.arrayToDataTable(chartData);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, {
        type: 'number',
        label: data.getColumnLabel(0),
        calc: function () { return 0; }
    }, {
        type: 'number',
        label: data.getColumnLabel(1),
        calc: function () { return 0; }
    }, {
        type: 'number',
        label: data.getColumnLabel(2),
        calc: function () { return 0; }
    }, {
        type: 'number',
        label: data.getColumnLabel(3),
        calc: function () { return 0; }
    }]);

    var chart = new google.visualization.ColumnChart(document.getElementById('visualization'));
    var options = {
        title: 'Revenue Report',
        legend: 'right', // bottom
        hAxis: {
            title: 'Year',
            format: '#',
        },
        vAxis: {
            minValue: 0,
            maxValue: 100000,
            title: 'Revenues in Dollars',
        },
        chartArea: {
            left: 100, top: 25, bottom: 50, right: 150, width: '90%', height: '80%'
        },
        animation: {
            duration: 1000
        }
    };

    var runFirstTime = google.visualization.events.addListener(chart, 'ready', function () {
        google.visualization.events.removeListener(runFirstTime);
        chart.draw(data, options);
    });

    chart.draw(view, options);
}
google.load('visualization', '1', { packages: ['corechart'] });
