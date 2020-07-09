$(document).ready(function () {
    $("body").on("click", ".remove-prw-img", function () {
        $(this).parent().hide();
    })
    // delete e axs zamani ke upload shode
    $(function () {
        var imagesPreview = function (input, placeToInsertImagePreview) {
            if (input.files) {
                var filesAmount = input.files.length;
                for (i = 0; i < filesAmount; i++) {
                    var reader = new FileReader();
                    reader.onload = function (event) {
                        $($.parseHTML('<div class="col-lg-3" style="position: relative;"><button class="btn btn-danger remove-prw-img" style="position: absolute;top: 0;right: 0;z-index: 999!important;padding: 7px;"><i class="fa fa-trash"></i></button><img src="' + event.target.result + '"></div>')).appendTo(placeToInsertImagePreview);
                    }
                    reader.readAsDataURL(input.files[i]);
                }
            }
        };
        $('.file-selected').on('change', function () {
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
        $(".gal-div").show();
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
})