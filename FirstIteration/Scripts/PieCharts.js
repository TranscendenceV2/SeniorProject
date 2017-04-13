$(function () {
    $('#generate').click(function () {
        var dept = $('#ddldepartment').val();
        var fund = $('#ddlfundcategory option:selected').text();
        //if (dept != null && dept != "") {
            $.ajax({
                url: '/Chart/PieData',
                data: { id: dept, source: fund },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        //alert(JSON.stringify(data));
                        //console.log(JSON.stringify(data));
                        drawPie(data);
                    }
                    //else {
                        //alert('data is null');
                    //}
                }
            });

        //} else {
           // alert('No Department Selected!');
        //}

    });
});

$(function () {
    $('#employee').click(function () {
        var dept = $('#ddldepartment').val();
        var empl = $('#ddlstaff').val();
        if (empl != null && empl != "") {
            $.ajax({
                url: '/Chart/PieData',
                data: { id: dept, employee: empl },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        //alert(JSON.stringify(data));
                        //console.log(JSON.stringify(data));
                        drawPie(data);
                    }                    
                }
            });

        //} else {
            //alert('No Employee Selected!');
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