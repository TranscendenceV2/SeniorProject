$(function () {
    $('#generate').on('click', function () {
        var dept = $('#ddldepartment').val();
        var fund = $('#ddlfundcategory option:selected').text();
        if (dept != null && dept != "") {
            $.ajax({
                url: '/Chart/LineData',
                data: { id: dept, source: fund },
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
                    
        } else {
            alert('No Department Selected!');            
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
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },
        series: jsonData,
    });
}