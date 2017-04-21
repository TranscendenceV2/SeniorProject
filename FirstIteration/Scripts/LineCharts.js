$(function () {
    $('#generate').on('click', function () {
        var dept = $('#ddldepartment').val();
        var year = $('#ddlyear').val();
        var fund = $('#ddlfundcategory option:selected').text().replace("\n", "").trim();
        fund = fund.includes("--") ? undefined : fund;
        year = year.includes("--") ? undefined : year;
            $.ajax({
                url: '/Chart/LineData',
                data: { id: dept, source: fund, year: year },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        drawLine(data);
                    }
                    else {
                        alert('data is null');
                    }
                }
            });
    });
});

$(function () {
    $('#employee').on('click', function () {
        var dept = $('#ddldepartment').val();
        var year = $('#ddlyear').val();
        var empl = $('#ddlstaff').val();
        if (empl != null && empl != "") {
            $.ajax({
                url: '/Chart/LineData',
                data: { id: dept, employee: empl, year: year },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        drawLine(data);                       
                    }
                    else {
                        alert('Employee has no transactions');
                    }
                }
            });
        }

    });
});

function drawLine(jsonData) {
    Highcharts.chart('chart_div', {

        chart: {
            zoomType: 'x'
        },
        data: {
            d: jsonData
        },
        title: {
            text: 'Monthly Income by Funding Source'
        },

        subtitle: {
            text: 'Clay Behavioral Health'
        },
        xAxis: {
            categories: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
        },
        yAxis: {
            title: {
                text: 'Revenue ($)'
            }
        },
        plotOptions: {
            line: {
                dataLabels: {
                    enabled: true
                },
                enableMouseTracking: false
            }
        },
        legend: {
            layout: 'horizontal',
            align: 'center',
            verticalAlign: 'bottom',
            y : 25
        },
        series: jsonData,
    });
}
