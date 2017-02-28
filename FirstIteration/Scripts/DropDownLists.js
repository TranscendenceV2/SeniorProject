$(function () {
    $('#ddldepartment').change(function () {
        var sub = $('#ddldepartment').val();
        if (sub != null && sub != "") {
            $('#ddlstaff').html(' <option value="">--Select Staff Member--</option>');
            $.ajax({
                url: '/Chart/StaffList',
                data: { id: sub },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        $.each(data, function (i, item) {                            
                            $("#ddlstaff").append($("<option></option>").val(item.Value).html(item.text));
                        });
                    }
                    else {
                        $('#ddlstaff').html(' <option value="">--No Staff Detected--</option>');
                    }
                }
            });
        }
        else {
            $('#ddlstaff').html(' <option value="">--Select State--</option>');
        }
    });
});

/*$(function () {
    $('#ddldepartment').change(function () {
        var sub = $('#ddldepartment').val();
        if (sub != null && sub != "") {
            $('#ddlfunding').html(' <option value="">--Select Funding Source--</option>');
            $.ajax({
                url: '/Chart/FundingSourceList',
                data: { id: sub },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        $.each(data, function (i, item) {
                            $("#ddlfunding").append($("<option></option>").val(item.text).html(item.Value));
                        });
                    }
                    else {
                        $('#ddlfunding').html(' <option value="">--No Funding Sources Detected--</option>');
                    }
                }
            });
        }
        else {
            $('#ddlstaff').html(' <option value="">--Select State--</option>');
        }
    });
});*/