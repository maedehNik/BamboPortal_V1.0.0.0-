$(document).ready(function () {
    //=================================================================================================
    //{Start}For administrator Profile
    if ($("#ProfileFormChangeSubmiter").length == 1) {
        $(function () {

            $("#ProfileFormChangeSubmiter").on("submit", function (e) {
                e.preventDefault();
                var frmVlalidation = $('#ProfileFormChangeSubmiter').valid();
                if (frmVlalidation == true) {
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
                                $("#ProfileFormChangeSubmiterbtn").show(400);
                                location.reload();
                            } else if (jsondata.Errortype == "ErrorWithList") {
                                $("#ProfileFormChangeSubmiter_DangerMessage").text(jsondata.Errormessage);
                                $("#ProfileFormChangeSubmiter_DangerMessage").show(200);
                                setTimeout(function () {
                                    $("#ProfileFormChangeSubmiter_DangerMessage").hide(200);
                                }, 5000);
                                ValidationOrNotValidateDatas(data, "ProfileFormChangeSubmiter");
                                $("#ProfileFormChangeSubmiterbtn").show(400);
                            } else {
                                $("#ProfileFormChangeSubmiter_DangerMessage").text(jsondata.Errormessage);
                                $("#ProfileFormChangeSubmiter_DangerMessage").show(200);
                                setTimeout(function () {
                                    $("#ProfileFormChangeSubmiter_DangerMessage").hide(200);
                                }, 5000);
                                $("#ProfileFormChangeSubmiterbtn").show(400);
                            }


                        }
                    });
                }
            });
        });
    }
    //{END}For administrator Profile
    //=================================================================================================
    //=================================================================================================
    //{Start}For administrator ChangeAuth Information
    if ($("#AUTHChangeSubmiter").length == 1) {
        $(function () {

            $("#AUTHChangeSubmiter").on("submit", function (e) {
                e.preventDefault();
                var frmVlalidation = $('#AUTHChangeSubmiter').valid();
                if (frmVlalidation == true) {
                    $("#AUTHChangeSubmiterbtn").hide(400);

                    $.ajax({
                        url: this.action,
                        type: this.method,
                        data: $(this).serialize(),
                        success: function (data) {
                            console.log(data)
                            const jsondata = data;
                            
                            if (jsondata.Errortype == "Success") {
                                $("#AUTHChangeSubmiter_SucceessMessage").text(jsondata.Errormessage);
                                $("#AUTHChangeSubmiter_SucceessMessage").show(200);
                                setTimeout(function () {
                                    $("#AUTHChangeSubmiter_SucceessMessage").hide(200);
                                }, 5000);
                                $("#AUTHChangeSubmiterbtn").show(400);
                                location.reload();
                            } else if (jsondata.Errortype == "ErrorWithList") {
                                $("#AUTHChangeSubmiter_DangerMessage").text(jsondata.Errormessage);
                                $("#AUTHChangeSubmiter_DangerMessage").show(200);
                                setTimeout(function () {
                                    $("#AUTHChangeSubmiter_DangerMessage").hide(200);
                                }, 5000);
                                ValidationOrNotValidateDatas(data, "AUTHChangeSubmiter");
                                $("#AUTHChangeSubmiterbtn").show(400);
                            } else {
                                $("#AUTHChangeSubmiter_DangerMessage").text(jsondata.Errormessage);
                                $("#AUTHChangeSubmiter_DangerMessage").show(200);
                                setTimeout(function () {
                                    $("#AUTHChangeSubmiter_DangerMessage").hide(200);
                                }, 5000);
                                $("#AUTHChangeSubmiterbtn").show(400);
                            }


                        }
                    });
                }
            });
        });
    }
    //{END}For administrator ChangeAuth Information
    //=================================================================================================


});
//=================================================================================================
//{Start}got Json of ErrorReporterModel--> AllErrors For validate from backend serverside Validation
function ValidationOrNotValidateDatas(data, formID) {
    const AllInps = $("#" + formID).parent().find('input');
    var __iValidationOrNotValidateDatas = 0
    for (__iValidationOrNotValidateDatas = 0; __iValidationOrNotValidateDatas < AllInps.length; __iValidationOrNotValidateDatas++) {
        $(AllInps[__iValidationOrNotValidateDatas]).removeClass("input-validation-error");
        var idinp = $(AllInps[__iValidationOrNotValidateDatas]).attr('id');
        $("#" + idinp + "ERR").remove();
    }
    const AllErrors = data.AllErrors;
    var allErrorsCounter = 0;
    for (allErrorsCounter = 0; allErrorsCounter < AllErrors.length; allErrorsCounter++) {
        NotValidation(AllErrors[allErrorsCounter].ErrorMessage, AllErrors[allErrorsCounter].IdOfProperty);
    }
}
function NotValidation(messagetxt, inputID) {
    $("#" + inputID).addClass('input-validation-error');
    if ($("#" + inputID + "ERR").length == 0) {
        $("#" + inputID).after('<span id="' + inputID + 'ERR" class="field-validation-error" data-valmsg-replace="true">' + messagetxt + '</span>');
        console.log(' if len ==0 ;>><span id="' + inputID + 'ERR" class="field-validation-error" data-valmsg-replace="true">' + messagetxt + '</span>')
    } else {
        console.log(' if len !=0 ;>><span id="' + inputID + 'ERR" class="field-validation-error" data-valmsg-replace="true">' + messagetxt + '</span>')
        $("#" + inputID + "ERR").remove();
        $("#" + inputID).after('<span id="' + inputID + 'ERR" class="field-validation-error" data-valmsg-replace="true">' + messagetxt + '</span>');
    }
}
function ThisIsValid(inputID) {
    $("#" + inputID + "ERR").hide(100);
    $("#" + inputID).removeClass("input-validation-error");

}
//{END}got Json of ErrorReporterModel--> AllErrors For validate from backend serverside Validation
//=================================================================================================