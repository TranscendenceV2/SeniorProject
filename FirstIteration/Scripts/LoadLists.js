$(function () {
    var sub = $("input[name=options]:checked").val();
    $('#filterDay').change(function () {
        var temp = $("input[name=options]:checked").val();
        if (isOptionValid(temp) && temp !== sub){
            sub = $("input[name=options]:checked").val();
            if (sub == 2)
                $("#loadpartial").load('/Chart/_EmployeeDropDowns');
            else
                $("#loadpartial").load('/Chart/_FundingSourceDropDowns');
        }               
    })
});

function isOptionValid(option) {
    return (typeof option !== "undefined");
}
