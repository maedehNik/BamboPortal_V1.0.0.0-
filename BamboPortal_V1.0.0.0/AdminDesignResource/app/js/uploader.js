$(document).ready(function () {
    $("body").on("click", ".remove-prw-img", function () {
        $(this).parent().hide();
        var id = $(this).attr("id").replace("img-", "");
        $("#SkipImageIDS").val(id + "," + $("#SkipImageIDS").val())
        return false;
    })
    // delete e axs zamani ke upload shode
    $(function () {
        var imagesPreview = function (input, placeToInsertImagePreview) {
            if (input.files) {
                mApp.block("#MultipartUploaderSubmiter", {
                    overlayColor: "#2c2e3e", type: "loader", state: "success", message: "در حال بارگزاری"
                });
                $("#SkipImageIDS").val("");
                $(placeToInsertImagePreview).html("");
                var filesAmount = input.files.length;
                var _i = 0;
                for (i = 0; i < filesAmount; i++) {
                    var reader = new FileReader();
                    reader.onload = function (event) {
                        $($.parseHTML('<div class="col-lg-3" style="position: relative;"><button class="btn btn-danger remove-prw-img" id="img-' + _i + '" style="position: absolute;top: 0;right: 0;z-index: 999!important;padding: 7px;"><i class="fa fa-trash"></i></button><img src="' + event.target.result + '"></div>')).appendTo(placeToInsertImagePreview);
                        console.log($(".gallery").html());
                        _i++;
                    }


                    setTimeout(function () {
                        mApp.unblock("#MultipartUploaderSubmiter");
                    }, 1000);
                    reader.readAsDataURL(input.files[i]);
                }
            }
        };
        $('#UploadedImages').on('change', function () {
            imagesPreview(this, 'div.gallery');
        });
    });
    // namayeshe ax ha bad az entekhab kardan
    $(".uimg").on("click", function () {
        $(".upload-left .img-border").removeClass("no-border");
        $(".upload-left div video").hide();
        $(".show-file").hide();
        $(".upload-left div img").show();
        $(".uimg").parent().removeClass("active-border");
        $(".uvideo").parent().removeClass("active-border");
        $(".ufile").removeClass("active-border");
        $(this).parent().addClass("active-border");
        setTimeout(function () {
            $(".upload-left").addClass("upload-left-active");
        }, 500)
        $(".upload-right").removeClass("col-lg-12");
        $(".upload-right").addClass("col-lg-9");
        var picsrc = $(this).attr("src");
        var picname = $(this).data('name');
        var piclabel = $(this).data('label');
        var picdesc = $(this).data('desc');
        $(".left-img").attr("src", picsrc);
        $(".picname").val(picname);
        $(".piclabel").val(piclabel);
        $(".picdesc").val(picdesc);
        $(".deleteimgbtn").data('name', picname)
    })
    $(".uvideo").on("click", function () {
        $(".upload-left .img-border").removeClass("no-border");
        $(".upload-left div img").hide();
        $(".show-file").hide();
        $(".upload-left div video").show();
        $(".uimg").parent().removeClass("active-border");
        $(".uvideo").parent().removeClass("active-border");
        $(".ufile").removeClass("active-border");
        $(this).parent().addClass("active-border");
        setTimeout(function () {
            $(".upload-left").addClass("upload-left-active");
        }, 500)
        $(".upload-right").removeClass("col-lg-12");
        $(".upload-right").addClass("col-lg-9");
        var picsrc = $(this).attr("src");
        var picname = $(this).data('name');
        var piclabel = $(this).data('label');
        var picdesc = $(this).data('desc');
        var picurl = $(this).data('url');
        $(".left-img").attr("src", picsrc);
        $(".picname").val(picname);
        $(".piclabel").val(piclabel);
        $(".picdesc").val(picdesc);
        $(".upload-left div video source").attr("src", picurl);
        $(".deleteimgbtn").data('name', picname)
    })
    $(".ufile").on("click", function () {
        $(".upload-left .img-border").addClass("no-border");
        $(".upload-left div img").hide();
        $(".show-file").show();
        $(".upload-left div video").hide();
        $(".ufile").removeClass("active-border");
        $(".uvideo").parent().removeClass("active-border");
        $(".uimg").parent().removeClass("active-border");
        $(this).addClass("active-border");
        setTimeout(function () {
            $(".upload-left").addClass("upload-left-active");
        }, 500)
        $(".upload-right").removeClass("col-lg-12");
        $(".upload-right").addClass("col-lg-9");
        var picsrc = $(this).attr("src");
        var picname = $(this).data('name');
        var piclabel = $(this).data('label');
        var picdesc = $(this).data('desc');
        var picurl = $(this).data('url');
        $(".left-img").attr("src", picsrc);
        $(".picname").val(picname);
        $(".piclabel").val(piclabel);
        $(".picdesc").val(picdesc);
        $(".upload-left div video source").attr("src", picurl);
        $(".deleteimgbtn").data('name', picname)
    })
    // ersale data be forme samte chap bad az click rooye an ha
    $(".deleteimgbtn").on("click", function (e) {
        var data = $(this).data('name');
        $('#deleteimg').find('#data-name').text(data);
    })
    // pak kardane axe click shode
    $(".ubtn1").on("click", function () {
        $(".ubtn1").hide();
        $(".ubtn2").hide();
        $(".ubtn3").show();
        $(".ubtn4").show();
        $(".picinps").removeAttr("disabled");
    })
    $(".ubtn3 , .ubtn4").on("click", function () {
        $(".ubtn1").show();
        $(".ubtn2").show();
        $(".ubtn3").hide();
        $(".ubtn4").hide();
        $(".picinps").attr("disabled", "disabled");
    })
    // dokme haye forme samte chap
    $(".custom-dropzone").on("click", function () {
        $(".file-selected").click();
    })
    // baz shodane safheye entekhabe file
    $(".gal-btn").on("click", function () {
        $(".uploader-header li span").removeClass("active-upload");
        $(this).addClass("active-upload")
        $(".upload-div").hide();

        //mApp.block("#uploader", {
        //    overlayColor: "#2c2e3e", type: "loader", state: "success", message: "درحال چک کردن حریم دسترسی و دریافت اطلاعات از سمت سرور ..."
        //});
        //$.ajax({
        //    url: '/AdministratorUploader/Gallery',
        //    type: "get",
        //    success: function (data) {
        //        $(".gal-div").html(data);
        //        setTimeout(function () {
        //            mApp.unblock("#uploader")
        //            $(".gal-div").show(200);
        //            $(".select-uploader").show();
        //            $(".upload-fields").hide();
        //        }, 1000);
        //    },
        //    error: function (jqXHR, textStatus, errorThrown) {
        //        swal("مشکل در برقراری ارتباط با سرور", data.Errormessage, "error");
        //        setTimeout(function () {
        //            mApp.unblock("#uploader")
        //            $(".gal-div").show();
        //            $(".select-uploader").show();
        //            $(".upload-fields").hide();
        //        }, 1000);

        //    }
        //});
        $(".gal-div").show(200);
        $(".select-uploader").show();
        $(".upload-fields").hide();


    })
    $(".upload-btn").on("click", function () {
        $(".uploader-header li span").removeClass("active-upload");
        $(this).addClass("active-upload")
        $(".upload-div").show();
        $(".gal-div").hide();
        $(".select-uploader").hide();
        $(".upload-fields").show();
    })
    // menuye balaye uploader
    $(".gal-h3").on("click", function () {
        $(".gal-h3").removeClass("h3-active");
        $(this).addClass("h3-active")
        $(".gal-h3").next().not($(this).next()).slideUp();
        if ($(this).next().css("display") == 'block') {
            $(this).next().slideUp();
            $(this).removeClass("h3-active");
        } else {
            $(this).next().slideDown();
        }
    })
    // loade daste bani haye file ha
    $(".Checks").on("click", function () {
        var allcheckdimg = [];
        var allimageIds = "";
        $(".Checks:checkbox:checked").each(function () {
            var ImageBigSrc = $("#OrginalsizeofIMG-" + $(this).attr("id").replace("CK-", ""));
            var thimnail = $("#img-" + $(this).attr("id").replace("CK-", ""));
            const ImgsSelectedjson = {
                'idOfImg': $(this).attr("id"),
                'ImageBigSrc': $(ImageBigSrc).val(),
                'thimnail': $(thimnail).attr("src")

            };
            allimageIds += $(this).attr("id").replace("CK-", "") + ",";
            allcheckdimg.push(ImgsSelectedjson);
        });
        const JsonObjtoSend = {
            'Allimgs': allcheckdimg,
            'AllIds': allimageIds
        };
        console.log(JsonObjtoSend);
        console.log(JSON.stringify($(JsonObjtoSend)));
        $("#DataSelectedFromGallery").val(JSON.stringify($(JsonObjtoSend)));
    });
    //=======================================SelectedIMGS
    $(".UploadEndsForWork").on("click", function () {
        $('#uploader').modal('toggle');
        var ImgsforSlider = JSON.parse($("#DataSelectedFromGallery").val());
        console.log(ImgsforSlider);
        $("#AllImagesByID").val(ImgsforSlider[0].AllIds);
        console.log("allids = " + $("#AllImagesByID").val());
        var strofSliderImfgs = "";
        $('.mySlides').remove();
        console.log($(".mySlides").length);
        mApp.block(".slideshow-container", { overlayColor: "#000000", state: "primary" });
        for (var t = 0; t < ImgsforSlider[0].Allimgs.length; t++) {
            strofSliderImfgs += generateSliderItem(ImgsforSlider[0].Allimgs[t], t);
        }
        strofSliderImfgs += '<a class="prev" onclick="plusSlides(-1)">❯</a><a class="next" onclick="plusSlides(1)">❮</a>';
        setTimeout(function () { mApp.unblock(".slideshow-container") }, 1000);
        console.log("allimgs" + strofSliderImfgs);
        $(".slideshow-container").html(strofSliderImfgs);
    });

    //=================================================== SetSlider
    function generateSliderItem(objsenderss, k) {
        var noneorBlock = "none";
        if (k == 0) {
            noneorBlock = "block";
        }
        return '<div class="mySlides" style="display: ' + noneorBlock + ';position: relative" > <img src="' + objsenderss.thimnail + '" data-url="' + objsenderss.ImageBigSrc + '" style="width:100%" /></div>';
    }


})