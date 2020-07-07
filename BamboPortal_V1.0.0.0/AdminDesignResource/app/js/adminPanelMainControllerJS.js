$(document).ready(function () {
    //=================================================================================================
    //{Start}For administrator Profile
    if ($("#ProfileFormChangeSubmiter").length == 1) {
        $(function () {

            $("#ProfileFormChangeSubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("ProfileFormChangeSubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("ProfileFormChangeSubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("ProfileFormChangeSubmiter", data);
                        } else {
                            AlertToUser("ProfileFormChangeSubmiter", data);
                        }
                    }
                });

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
                DisableBTN("AUTHChangeSubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;

                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AUTHChangeSubmiter", data);
                        }
                        else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AUTHChangeSubmiter", data);
                        }
                        else {
                            AlertToUser("AUTHChangeSubmiter", data);
                        }
                    }
                });

            });
        });
    }
    //{END}For administrator ChangeAuth Information
    //=================================================================================================


});
//=================================================================================================
//{Start}got Json of ErrorReporterModel--> AllErrors For validate from backend serverside Validation{
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
//}{END}got Json of ErrorReporterModel--> AllErrors For validate from backend serverside Validation
//=================================================================================================
//=================================================================================================
//{Start}AlertAndLoading For User{

function AlertToUser(FormID, data) {
    setTimeout(function () {


        if (data.Errortype == "Success") {
            swal("درخواست با موفقیت ثبت شد!", data.Errormessage, "success").then(function (e) {
                $("#" + FormID + "_SubmitBTN").removeClass("m-loader m-loader--light m-loader--right").prop("disabled", false);
                location.reload();
            })
        }
        else if (data.Errortype == "ErrorWithList") {
            swal("متاسفانه در ارسال درخواست مشکلی بوجود آمده", data.Errormessage, "error").then(function (e) {
                ValidationOrNotValidateDatas(data, FormID);
                $("#" + FormID + "_SubmitBTN").removeClass("m-loader m-loader--light m-loader--right").prop("disabled", false);
            })
        }
        else {
            swal("متاسفانه در ارسال درخواست مشکلی بوجود آمده", data.Errormessage, "error").then(function (e) {
                $("#" + FormID + "_SubmitBTN").removeClass("m-loader m-loader--light m-loader--right").prop("disabled", false);
            })
        }

    }, 1000);

}
function DisableBTN(idForm) {
    $("#" + idForm + "_SubmitBTN").addClass("m-loader m-loader--light m-loader--right").prop("disabled", true);
}
//}{END}AlertAndLoading For User