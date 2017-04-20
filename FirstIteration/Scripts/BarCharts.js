$(function () {
    $('#generate').click(function () {
        var dept = $('#ddldepartment').val();
        var year = $('#ddlyear').val();
        var fund = $('#ddlfundcategory option:selected').text().replace("\n", "").trim();
        fund = fund.includes("--") ? undefined : fund;
        year = year.includes("--") ? undefined : year;

            $.ajax({
                url: '/Chart/BarData',
                data: { id: dept, source: fund , year: year},
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        drawColumn(data);
                    }
                }
            });
    });
});

$(function () {
    $('#employee').click(function () {
        var dept = $('#ddldepartment').val();
        var year = $('#ddlyear').val();
        var empl = $('#ddlstaff').val();    
        if (empl != null && empl != "") {
            $.ajax({
                url: '/Chart/BarData',
                data: { id: dept, employee: empl, year: year },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        drawColumn(data);
                    }
                }
            });
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
