$(function () {
    $('#ddldepartment').change(function () {
        var sub = $('#ddldepartment').val();
        $('#ddlfundcodename').html(' <option value="">--No Department Selected--</option>');
        if (sub != null && sub != "") {
            $('#ddlstaff').html(' <option value="">--Select Staff Member--</option>');
            $.ajax({
                url: '/Chart/StaffList',
                data: { id: sub },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        $.each(data, function (i, item) {                            
                            $("#ddlstaff").append($("<option></option>").val(item.value).html(item.text));
                        });
                    }
                    else {
                        $('#ddlstaff').html(' <option value="">--No Staff Detected--</option>');
                    }
                }
            });
        }
        else {
            $('#ddlstaff').html(' <option value="">--No Department Selected--</option>');
        }
    });
});

$(function () {
    $('#ddldepartment').change(function () {
        var sub = $('#ddldepartment').val();
        $('#ddlfundcodename').html(' <option value="">--No Department Selected--</option>');
        if (sub != null && sub != "") {
            $('#ddlfundcategory').html(' <option value="">--Select Funding Category--</option>');
            $.ajax({
                url: '/Chart/FundingCategoryList',
                data: { id: sub },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        $.each(data, function (i, item) {
                            $("#ddlfundcategory").append($("<option></option>").html(item.text));
                        });
                    }
                    else {
                        $('#ddlfundcategory').html(' <option value="">--No Funding Categories Detected--</option>');
                    }
                }
            });
        }
        else {
            $('#ddlfundcategory').html(' <option value="">--No Department Selected--</option>');
        }
    });
});