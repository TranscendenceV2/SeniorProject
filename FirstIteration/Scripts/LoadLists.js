$(function () {
    var sub = $("input[name=options]:checked").val();
    $('#filterDay').change(function () {
        if (isOptionValid($("input[name=options]:checked").val()))
            sub = $("input[name=options]:checked").val();

        if (sub == 2)
            $("#loadpartial").load('/Chart/_EmployeeDropDowns');
        else
            $("#loadpartial").load('/Chart/_FundingSourceDropDowns');
    })
});

function isOptionValid(option) {
    return (typeof option !== "undefined");
}
