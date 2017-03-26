$(function () {
    $('#generate').click(function () {
        var dept = $('#ddldepartment').val();
        if (dept != null && dept != "") {
            $.ajax({
                url: '/Chart/BarData',
                data: { id: dept },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        //alert(JSON.stringify(data));
                        //console.log(JSON.stringify(data));
                        drawColumn(data);
                    }
                    else {
                        alert('data is null');
                    }
                }
            });

        } else {
            alert('No Department Selected!');
        }

    });
});

function drawColumn(jsonData) {
    Highcharts.chart('visualization', {
        chart: {
            type: 'column'
        },
        title: {
            text: 'Monthly Revenue by Funding Source'
        },
        subtitle: {
            text: 'Clay Behavioral Health'
        },
        xAxis: {
            categories: [
                'Jan',
                'Feb',
                'Mar',
                'Apr',
                'May',
                'Jun',
                'Jul',
                'Aug',
                'Sep',
                'Oct',
                'Nov',
                'Dec'
            ],
            crosshair: true
        },
        yAxis: {
            min: 0,
            title: {
                text: 'Revenue ($)'
            }
        },
        tooltip: {
            headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
            pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                '<td style="padding:0"><b>{point.y:.1f} $</b></td></tr>',
            footerFormat: '</table>',
            shared: true,
            useHTML: true
        },
        plotOptions: {
            column: {
                pointPadding: 0.2,
                borderWidth: 0
            }
        },
        series: jsonData,

    });
}
