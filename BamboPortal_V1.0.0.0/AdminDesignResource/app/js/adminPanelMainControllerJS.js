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
    //=================================================================================================
    //{Start}For administrator addtype
    if ($("#AddTypeSubmiter").length == 1) {
        $(function () {
            $("#AddTypeSubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddTypeSubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddTypeSubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddTypeSubmiter", data);
                        } else {
                            AlertToUser("AddTypeSubmiter", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For administrator addtype
    //=================================================================================================
    //=================================================================================================
    //{Start}For administrator AddMainCategorySubmiter
    if ($("#AddMainCategorySubmiter").length == 1) {
        $(function () {
            $("#AddMainCategorySubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddMainCategorySubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddMainCategorySubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddMainCategorySubmiter", data);
                        } else {
                            AlertToUser("AddMainCategorySubmiter", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For administrator AddMainCategorySubmiter
    //=================================================================================================
    //=================================================================================================
    //{Start}For administrator AddSubCategory
    if ($("#AddSubCategorySubmiter").length == 1) {
        $(function () {
            $("#AddSubCategorySubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddSubCategorySubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddSubCategorySubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddSubCategorySubmiter", data);
                        } else {
                            AlertToUser("AddSubCategorySubmiter", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For administrator AddSubCategory
    //=================================================================================================
    //=================================================================================================
    //{Start}For administrator AddSubCategory
    if ($("#AddSubCategoryKey").length == 1) {
        $(function () {
            $("#AddSubCategoryKey").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddSubCategoryKey");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddSubCategoryKey", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddSubCategoryKey", data);
                        } else {
                            AlertToUser("AddSubCategoryKey", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For administrator AddSubCategory
    //=================================================================================================
    //=================================================================================================
    //{Start}For administrator AddSubCategory
    if ($("#AddSubCateGoryValuesOfKeysSubmiter").length == 1) {
        $(function () {
            $("#AddSubCateGoryValuesOfKeysSubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddSubCateGoryValuesOfKeysSubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddSubCateGoryValuesOfKeysSubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddSubCateGoryValuesOfKeysSubmiter", data);
                        } else {
                            AlertToUser("AddSubCateGoryValuesOfKeysSubmiter", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For administrator AddSubCategory
    //=================================================================================================
});
//=================================================================================================
//{Start}got Json of ErrorReporterModel--> AllErrors For validate from backend serverside Validation{
function ValidationOrNotValidateDatas(data, formID) {
    var AllInps = $("#" + formID).parent().find('input');
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
//Redirection in the end of id will redirect user to Formid+Redirection .val() url 
function AlertToUser(FormID, data) {
    setTimeout(function () {


        if (data.Errortype == "Success") {
            swal("درخواست با موفقیت ثبت شد!", data.Errormessage, "success").then(function (e) {
                $("#" + FormID + "_SubmitBTN").removeClass("m-loader m-loader--light m-loader--right").prop("disabled", false);
                try {
                    if ($("#" + FormID + "Redirection").val().length > 0) {
                        window.location.replace(window.location.origin + $("#" + FormID + "Redirection").val());
                    } else {

                        location.reload();
                    }
                } catch{
                    location.reload();
                }
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
//{Start}FormPoster{
function PosterCreator(idForm) {
    $("#" + idForm).on("submit", function (e) {
        e.preventDefault();
        DisableBTN(idForm);
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (data) {
                console.log(data)
                const jsondata = data;
                console.log(jsondata.Errortype)
                if (jsondata.Errortype == "Success") {
                    AlertToUser(idForm, data);
                } else if (jsondata.Errortype == "ErrorWithList") {
                    AlertToUser(idForm, data);
                } else {
                    AlertToUser(idForm, data);
                }
            }
        });
        return false;
    });

}
//}{END}FormPoster