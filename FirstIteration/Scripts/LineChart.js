
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
        drawColumn(chartData);
        drawLine(chartData);
        drawPie();
        drawTable();
        drawTable2();
    });
});


function drawColumn(d) {
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

function drawLine(d) {

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

function drawPie() {

    var data = google.visualization.arrayToDataTable([
          ['Task', 'Hours per Day'],
          ['Medicaid', 11],
          ['State', 12],
          ['Commercial', 5]
    ]);

    var options = {
        title: 'Budget Comparison'
    };

    var chart = new google.visualization.PieChart(document.getElementById('pie_div'));

    chart.draw(data, options);
}
function drawTable() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Source');
    data.addColumn('number', 'Funding Amount');
    data.addColumn('boolean', 'Goal Reached');
    data.addRows([
      ['Medicaid', { v: 10000, f: '$10,000' }, true],
      ['State', { v: 8000, f: '$8,000' }, false],
      ['Commercial', { v: 12500, f: '$12,500' }, true]
    ]);

    var table = new google.visualization.Table(document.getElementById('table_div'));

    table.draw(data, { showRowNumber: true, width: '100%', height: '100%' });
}
function drawTable2() {
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Representative');
    data.addColumn('number', 'Revenue');
    data.addColumn('boolean', 'Full Time Employee');
    data.addRows([
      ['Mike', { v: 10000, f: '$3,000' }, true],
      ['Jim', { v: 8000, f: '$7,500' }, false],
      ['Alice', { v: 12500, f: '$12,500' }, true],
      ['Bob', { v: 7000, f: '$10,000' }, true]
    ]);

    var table = new google.visualization.Table(document.getElementById('stat_div'));

    table.draw(data, { showRowNumber: true, width: '100%', height: '100%' });
}
google.load('visualization', '1', { packages: ['corechart', 'table'] });
