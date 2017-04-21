$(function () {
    $('#generate').click(function () {
        var X;
        var dept = $('#ddldepartment').val();
        var year = $('#ddlyear').val();
        var fund = $('#ddlfundcategory option:selected').text().replace("\n", "").trim();
        fund = fund.includes("--") ? undefined : fund;
        year = year.includes("--") ? undefined : year;

        if ($('#ddldepartment option:selected').text().replace("\n", "").trim().includes("--")) {
            X = undefined;
        }else if (dept != null && typeof fund === 'undefined') {
            X = $('#ddldepartment option:selected').text().replace("\n", "").trim() + " Revenue by Month";
        }else if (typeof fund !== 'undefined') {
            X = $('#ddldepartment option:selected').text().replace("\n", "").trim() + " " + $('#ddlfundcategory option:selected').text().replace("\n", "").trim() + " Revenue by Month";
        }

            $.ajax({
                url: '/Chart/BarData',
                data: { id: dept, source: fund , year: year, X: X},
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
            type: 'column',
            zoomType: 'x',
            panning: true,
            panKey: 'shift'
        },
        title: {
            text: 'Monthly Revenue'
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
            minRange: 3
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
        credits: {
            text: 'Transcendence 2017'
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
