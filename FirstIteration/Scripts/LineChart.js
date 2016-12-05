
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

    var options = {
        title: 'Revenue Report',
        pointSize: 5
    };

    var lineChart = new google.visualization.LineChart(document.getElementById('chart_div'));
    var runFirstTime = google.visualization.events.addListener(lineChart, 'ready', function () {
        google.visualization.events.removeListener(runFirstTime);
        lineChart.draw(data, options);
    });

    lineChart.draw(data, options);
}
google.load('visualization', '1', { packages: ['corechart'] });
