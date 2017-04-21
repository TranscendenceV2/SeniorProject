$(function () {
    $('#generate').click(function () {
        var dept = $('#ddldepartment').val();
        var year = $('#ddlyear').val();
        var fund = $('#ddlfundcategory option:selected').text().replace("\n", "").trim();
        fund = fund.includes("--") ? undefined : fund;
        year = year.includes("--") ? undefined : year;
            $.ajax({
                url: '/Chart/PieData',
                data: { id: dept, source: fund, year: year },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        drawPie(data);
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
                url: '/Chart/PieData',
                data: { id: dept, employee: empl, year: year },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        drawPie(data);
                    }                    
                }
            });
        } else if(dept != "" && empl == ""){
            alert("Please select an employee")
        } else {
            alert("Please select a department")
        }
    });
});

function drawPie(d) {
    Highcharts.chart('pie_div', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        credits: {
            text: 'Transcendence 2017'
        },
        title: {
            text: 'Revenue Comparisons by Year'
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },        
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [d]
    }
    );
}