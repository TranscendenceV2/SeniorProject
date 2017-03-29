$(function () {
    $('#ddldepartment').change(function () {
        var sub = $('#ddldepartment').val();
        $('#ddlfundcodename').html(' <option value="">--No Data Selected--</option>');
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
            $('#ddlstaff').html(' <option value="">--No Data Selected--</option>');
        }
    });
});

$(function () {
    $('#ddldepartment').change(function () {
        var sub = $('#ddldepartment').val();
        $('#ddlfundcodename').html(' <option value="">--No Data Selected--</option>');
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
            $('#ddlfundcategory').html(' <option value="">--No Data Selected--</option>');
        }
    });
});

/**$(function () {
    $('#ddlfundcategory').change(function () {
        var sub1 = $('#ddldepartment').val();
        var sub2 = $('#ddlfundcategory option:selected').text();
        if (sub1 != null && sub1 != "") {
            $('#ddlfundcodename').html(' <option value="">--Select Funding Code Name--</option>');
            $.ajax({
                url: '/Chart/FundingCodeNameList',
                data: { id: sub1, text: sub2 },
                type: 'post',
                success: function (data) {
                    if (data != null && data != "") {
                        $.each(data, function (i, item) {
                            $("#ddlfundcodename").append($("<option></option>").val(item.Value).html(item.text));
                        });
                    }
                    else {
                        $('#ddlfundcodename').html(' <option value="">--No Fund Code Name Detected--</option>');
                    }
                }
            });
        }
        else {
            $('#ddlfundcodename').html(' <option value="">--No Data Selected--</option>');
        }
    });
});**/