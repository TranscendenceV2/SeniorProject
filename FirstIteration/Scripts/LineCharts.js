$(function () {
    $('#generate').on('click', function () {
        var dept = $('#ddldepartment').val();
        var year = $('#ddlyear').val();
        var fund = $('#ddlfundcategory option:selected').text();
        //if (dept != null && dept != "") {
            $.ajax({
                url: '/Chart/LineData',
                data: { id: dept, source: fund, year: year },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        //alert(JSON.stringify(data));
                        //console.log(JSON.stringify(data));
                        drawLine(data);
                    }
                    else {
                        alert('data is null');
                    }
                }
            });
                    
        //} else {
         //   alert('No Department Selected!');            
        //}

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
                        //alert(JSON.stringify(data));
                        //console.log(JSON.stringify(data));
                        drawLine(data);
                    }
                    else {
                        alert('Employee has no transactions');
                    }
                }
            });

        //} else {
           // alert('No Employee Selected!');
        }

    });
});

function drawLine(jsonData) {
    Highcharts.chart('chart_div', {

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
