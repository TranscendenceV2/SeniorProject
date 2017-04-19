$(function () {
    var modalID;
    $("#upload-list li").click(function () {
        var id = $(this).attr("id");
        if (!modalID || modalID !== id) {
            $.ajax({
                url: "/Chart/UploadModal/" + id,
                success: function (response) {
                    $("#modal-wrapper").html(response);
                    modalID = id;
                },
                complete: function () {
                    $("#submit").on("click", fileSubmit);

                    $("#file").filestyle({
                        buttonText: "Find CSV",
                        icon: false,
                        placeholder: "No file chosen",
                        buttonName: "btn-primary"
                    });

                    $("#upload-modal").modal({
                        backdrop: "static",
                        keyboard: false
                    });
                }
            });
        } else {
            $("#upload-modal").modal("toggle");
        }
    });

    function fileSubmit() {
        var formData = new FormData();
        var files = $("#file").get(0).files;

        if (files.length > 0) {
            formData.append("CsvUpload", files[0]);
            formData.append("UploadType", modalID);
        } else {
            $("#help-block").html("<font color='red'>No files found!</font>");
            $("#file").filestyle("clear");
            return;
        }

        var extension = $("#file").val().split(".").pop().toUpperCase();
        if (extension !== "CSV") {
            $("#help-block").html("<font color='red'>Incorrect file type uploaded!</font>");
            $("#file").filestyle("clear");
            return;
        }
        
        $("#modal-content :button").prop("disabled", true);
        $("#help-block").html("Please wait...");

        $.ajax({
            url: "/Chart/UploadCsv",
            contentType: false,
            processData: false,
            data: formData,
            type: "POST",
            success: function (response) {
                $("#help-block").html("<font color='green'>Upload successful: " + response + " rows inserted</font>");
            },
            error: function(xhr, status, message){
                $("#help-block").html("<font color='red'>Error " + xhr.status + ": " + message + "</font>");
            },
            complete: function () {
                $("#modal-content :button").prop("disabled", false);
            }
        });
    }
});