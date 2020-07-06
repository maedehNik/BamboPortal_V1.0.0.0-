$(document).ready(function () {
    if ($("#ProfileFormChangeSubmiter").length == 1) {
        $(function () {

            $("#ProfileFormChangeSubmiter").on("submit", function (e) {
                e.preventDefault();
                var frmVlalidation = $('#ProfileFormChangeSubmiter').valid();
                if (frmVlalidation == true) {
                    console.log("form validation : " + frmVlalidation);
                    $("#ProfileFormChangeSubmiterbtn").hide(400);
                    $.ajax({
                        url: this.action,
                        type: this.method,
                        data: $(this).serialize(),
                        success: function (data) {
                            console.log(data)

                            const jsondata = data;
                            console.log(jsondata.Errortype)
                            if (jsondata.Errortype == "Success") {
                                $("#ProfileFormChangeSubmiter_SucceessMessage").text(jsondata.Errormessage);
                                $("#ProfileFormChangeSubmiter_SucceessMessage").show(200);
                                setTimeout(function () {
                                    $("#ProfileFormChangeSubmiter_SucceessMessage").hide(200);
                                }, 5000);
                                location.reload();
                            } else {
                                $("#ProfileFormChangeSubmiter_DangerMessage").text(jsondata.Errormessage);
                                $("#ProfileFormChangeSubmiter_DangerMessage").show(200);
                                setTimeout(function () {
                                    $("#ProfileFormChangeSubmiter_DangerMessage").hide(200);
                                }, 5000);
                                //location.reload();
                            }


                        }
                    });
                }
            });
        });
    }



})