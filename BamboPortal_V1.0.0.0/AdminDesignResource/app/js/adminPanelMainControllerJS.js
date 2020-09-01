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
    //=================================================================================================
    //{Start}For administrator AddSubCategory
    if ($("#AddMainTagSubmiter").length == 1) {
        $(function () {
            $("#AddMainTagSubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddMainTagSubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddMainTagSubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddMainTagSubmiter", data);
                        } else {
                            AlertToUser("AddMainTagSubmiter", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For administrator AddSubCategory
    //=================================================================================================
    //=================================================================================================
    //{Start}For administrator MultipartUploaderSubmiter
    if ($("#MultipartUploaderSubmiter").length == 1) {
        $(function () {
            $("#MultipartUploaderSubmiter").on("submit", function (e) {
                mApp.block("#MultipartUploaderSubmiter", {
                    overlayColor: "#2c2e3e", type: "loader", state: "success", message: "درحال چک کردن حریم دسترسی و دریافت اطلاعات از سمت سرور ..."
                });
                console.log($(this).serialize());
                var files = $("#UploadedImages").get(0).files;
                var formData = new FormData();
                for (var i = 0; i < files.length; i++) {
                    formData.append(files[i].name, files[i]);
                }
                console.log("files");
                console.log(files);
                console.log($("#ImageName").val());
                formData.append("ImageName", $("#ImageName").val());
                formData.append("ImageAlt", $("#ImageAlt").val());
                formData.append("ImageDescription", $("#ImageDescription").val());
                e.preventDefault();
                console.log(formData);
                console.log("=====================================");
                console.log($(formData).serialize())
                DisableBTN("MultipartUploaderSubmiter");

                AjaxFormToUploader(this.action, this.method, formData);
            });
        });

    }
    function AjaxFormToUploader(urlToAction, type, formdatas) {
        $.ajax({
            url: urlToAction,
            type: type,
            data: formdatas,
            contentType: false,
            processData: false,
            success: function (data) {
                console.log(data)
                const jsondata = data;
                console.log(jsondata.Errortype)
                if (jsondata.Errortype == "Success") {
                    AlertToUser("MultipartUploaderSubmiter", data);
                    $("#ImageName").val("");
                    $("#ImageAlt").val("");
                    $("#ImageDescription").val("");
                    $("#ShownUploaderUpload").hide(200);
                    $("#ShownUploaderUpload").html("");
                    $("#ShownUploaderUpload").show(200);
                    $("#UploadedImages").val("");
                    setTimeout(function () {
                        mApp.unblock("#MultipartUploaderSubmiter")
                    }, 1000);
                } else if (jsondata.Errortype == "ErrorWithList") {
                    AlertToUser("MultipartUploaderSubmiter", data);
                    setTimeout(function () {
                        mApp.unblock("#MultipartUploaderSubmiter")
                    }, 1000);
                } else {
                    AlertToUser("MultipartUploaderSubmiter", data);
                    setTimeout(function () {
                        mApp.unblock("#MultipartUploaderSubmiter")
                    }, 1000);
                }
            },
            error: function (data) {
                setTimeout(function () {
                    mApp.unblock("#MultipartUploaderSubmiter")
                }, 1000);
            }
        });
    }
    //{END}For administrator MultipartUploaderSubmiter
    //=================================================================================================
    //=================================================================================================
    //{Start}For AdministratorStockpile GetVaredeAndSadere - Varede
    if ($("#AddVaredeSubmiter").length == 1) {
        $(function () {
            $("#AddVaredeSubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddVaredeSubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddVaredeSubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddVaredeSubmiter", data);
                        } else {
                            AlertToUser("AddVaredeSubmiter", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For AdministratorStockpile GetVaredeAndSadere - Varede
    //=================================================================================================
    //=================================================================================================
    //{Start}For AdministratorStockpile GetVaredeAndSadere - Sadere
    if ($("#AddSadereSubmiter").length == 1) {
        $(function () {
            $("#AddSadereSubmiter").on("submit", function (e) {
                e.preventDefault();
                DisableBTN("AddSadereSubmiter");
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        console.log(data)
                        const jsondata = data;
                        console.log(jsondata.Errortype)
                        if (jsondata.Errortype == "Success") {
                            AlertToUser("AddSadereSubmiter", data);
                        } else if (jsondata.Errortype == "ErrorWithList") {
                            AlertToUser("AddSadereSubmiter", data);
                        } else {
                            AlertToUser("AddVaredeSubmiter", data);
                        }
                    }
                });
            });
        });
    }
    //{END}For AdministratorStockpile GetVaredeAndSadere - Sadere
    //=================================================================================================



});
//=================================================================================================
//{Start}got Json of ErrorReporterModel--> AllErrors For validate from backend serverside Validation{
function ValidationOrNotValidateDatas(data, formID) {
    $("body input:text").each(function () {
        $(this).removeClass("input-validation-error");
        var idinp = $(this).attr('id');
        $("#" + idinp + "ERR").remove();
        console.log(idinp);
    });

    const AllErrors = data.AllErrors;
    var allErrorsCounter = 0;
    for (allErrorsCounter = 0; allErrorsCounter < AllErrors.length; allErrorsCounter++) {
        NotValidation(AllErrors[allErrorsCounter].ErrorMessage, AllErrors[allErrorsCounter].IdOfProperty);
    }
}
function NotValidation(messagetxt, inputID) {
    console.log("#" + inputID + " : " + $("#" + inputID).length)
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

        console.log("saaaalaaaaam");
        if (data.Errortype == "Success") {
            swal("درخواست با موفقیت ثبت شد!", data.Errormessage, "success").then(function (e) {
                $("#" + FormID + "_SubmitBTN").removeClass("m-loader m-loader--light m-loader--right").prop("disabled", false);
                try {

                    if ($("#" + FormID + "Redirection").val() == "NoReload") {
                    }
                    else if ($("#" + FormID + "Redirection").val().length > 0) {
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


$(".deactivate-btn").on("click", function (e) {
    var data = $(this).data('name');
    $('#deActiveModal').find('#data-name').text(data);
    $("#idTodeactivemodal").val($(this).attr("id").replace("DeActive-", ""));
});
$(".cus-delete-btn").on("click", function (e) {
    var data = $(this).data('name');
    $('#deleteCus').find('#data-name-delete').text(data);
    $("#idTodeleteCus").val($(this).attr("id").replace("Deletebtnproduct-", ""));

});
$(".activate-btn").on("click", function (e) {
    var data = $(this).data('name');
    $('#ActiveModal').find('#data-name-Active').text(data);
    $("#activemodalID").val($(this).attr("id").replace("Active-", ""));
});
function RemoveDeactivityFromBTN(FormID) {
    $("#" + FormID + "_SubmitBTN").removeClass("m-loader m-loader--light m-loader--right").prop("disabled", false);

}

function redirect(url) {
    window.location = url;
}