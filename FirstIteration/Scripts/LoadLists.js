jQuery(function ($) {
    $('#filterDay').change(function () {
        sub = $('#filterDay input:radio:checked').val();
        if (sub == 2)
            $("#loadpartial").load('/Chart/_EmployeeDropDowns');
        else
            $("#loadpartial").load('/Chart/_FundingSourceDropDowns');
        })
    });
