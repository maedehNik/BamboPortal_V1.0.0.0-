$(document).ready(function () {
    $("#profile-form").validate({
        rules: {
            firstname: {
                required: true
            },
            lastname: {
                required: true
            },
            email: {
                required: true,
                email: true
            },
            phone: {
                required: true,
                minlength: 11,
                digits: true
            },
            password: {
                minlength: 8
            },
            repassword: {
                minlength: 8,
                equalTo: "#password"
            }
        },
        messages: {
            firstname: {
                required: "نام را وارد کنید"
            },
            lastname: {
                required: "نام خانوادگی را وارد کنید"
            },
            email: {
                required: "ایمیل را وارد کنید",
                email: "ایمیل معتبر وارد کنید"
            },
            phone: {
                required: "شماره تلفن را وارد کنید",
                minlength: "شماره تلفن معتبر وارد کنید",
                digits: "شماره تلفن معتبر وارد کتید"
            },
            password: {
                minlength: "حداقل 8 کاراکتر وارد کتید"
            },
            repassword: {
                minlength: "حداقل 8 کاراکتر وارد کتید",
                equalTo: "تکرار رمز عبور اشتباه است"
            }
        }
    });
    $("#cusform").validate({
        rules: {
            firstname_cus: {
                required: true
            },
            lastname_cus: {
                required: true
            },
            pername_add: {
                required: true
            },
            nickname_cus: {
                required: true
            },
            email_cus: {
                required: true,
                email: true
            },
            phone_cus: {
                required: true,
                minlength: 11,
                digits: true
            },
            phone_cus2: {
                required: true,
                minlength: 11,
                digits: true
            },
            prov_cust: {
                required: true,
            },
            city_cust: {
                required: true,
            },
            add_cust: {
                required: true,
            },
            pc_cust: {
                required: true,
                digits: true
            },
            permi_select: {
                required: true,
            },
            username_cus: {
                required: true,
            },
            pw_cus: {
                required: true,
                minlength: 8
            },
            repw_cus: {
                required: true,
                minlength: 8,
                equalTo: "#pw_cus"
            }
        },
        messages: {
            firstname_cus: {
                required: "نام را وارد کنید"
            },
            lastname_cus: {
                required: "نام خانوادگی را وارد کنید"
            },
            pername_add: {
                required: "نام دسترسی را وارد کنید"
            },
            nickname_cus: {
                required: "نام مستعار را وارد کنید"
            },
            email_cus: {
                required: "ایمیل را وارد کنید",
                email: "ایمیل معتبر وارد کنید"
            },
            phone_cus: {
                required: "شماره تلفن را وارد کنید",
                minlength: "شماره تلفن معتبر وارد کنید",
                digits: "شماره تلفن معتبر وارد کتید"
            },
            phone_cus2: {
                required: "شماره تلفن را وارد کنید",
                minlength: "شماره تلفن معتبر وارد کنید",
                digits: "شماره تلفن معتبر وارد کتید"
            },
            prov_cust: {
                required: "استان را وارد کنید",
            },
            city_cust: {
                required: "شهر را وارد کنید",
            },
            add_cust: {
                required: "آدرس را وارد کنید",
            },
            pc_cust: {
                required: "کد پستی را وارد کنید",
                digits: "کد پستی معتبر وارد کنید"
            },
            permi_select: {
                required: "دسترسی را انتخاب کنید",
            },
            username_cus: {
                required: "نام کاربری را وارد کنید",
            },
            pw_cus: {
                required: "رمز عبور را وارد کنید",
                minlength: "حداقل 8 کاراکتر وارد کتید"
            },
            repw_cus: {
                required: "تکرار رمز عبور را وارد کنید",
                minlength: "حداقل 8 کاراکتر وارد کتید",
                equalTo: "تکرار رمز عبور اشتباه است"
            }
        }
    });
    $(".deactivate-btn").on("click", function(e) {
        var data = $(this).data('name');
        $('#deactivemodal').find('#data-name').text(data);
    })
    $(".deleteArtc").on("click", function(e) {
        var data = $(this).data('name');
        $('#deleteArtc').find('#data-name').text(data);
    })
    $(".cus-delete-btn").on("click", function(e) {
        var data = $(this).data('name');
        $('#deleteCus').find('#data-name-delete').text(data);
    })
    $(".deleteimgbtn").on("click", function(e) {
        var data = $(this).data('name');
        $('#deleteimg').find('#data-name').text(data);
    })
    $(".personal-btn").on("click", function() {
        $("cust_title").text("اطلاعات شخصی");
        $(".cus-prof-menu li").removeClass("active-cust-profile");
        $(this).addClass("active-cust-profile");
        $(".address-cust").hide();
        $(".per-info").show();
    })
    $(".address-btn").on("click", function() {
        $("cust_title").text("آدرس ها");
        $(".cus-prof-menu li").removeClass("active-cust-profile");
        $(this).addClass("active-cust-profile");
        $(".per-info").hide();
        $(".address-cust").show();
    })
    $(".personal-btn2").on("click", function() {
        $("cust_title").text("اطلاعات شخصی");
        $(".cus-prof-menu li").removeClass("active-cust-profile");
        $(this).addClass("active-cust-profile");
        $(".address-cust").hide();
        $(".per-info").show();
        $(".user-info").hide();
    })
    $(".userbtn2").on("click", function() {
        if (!$(this).hasClass("tshdisabled-validation")) {
            $("cust_title").text("اطلاعات کاربری");
            $(".cus-prof-menu li").removeClass("active-cust-profile");
            $(this).addClass("active-cust-profile");
            $(".address-cust").hide();
            $(".per-info").hide();
            $(".user-info").show();
        }
    })
    $(".address-btn2").on("click", function() {
        if (!$(this).hasClass("tshdisabled-validation")) {
            $("cust_title").text("مدیریت دسترسی ها");
            $(".cus-prof-menu li").removeClass("active-cust-profile");
            $(this).addClass("active-cust-profile");
            $(".per-info").hide();
            $(".address-cust").show();
            $(".user-info").hide();
        }
    })
    var BootstrapSelect = {
        init: function() {
            $(".m_selectpicker").selectpicker();
        },
    };
    jQuery(document).ready(function() {
        BootstrapSelect.init();
    });
    $(".tshnext-1").on("click", function() {
        setTimeout(function() {
            if ($("#firstname_cus-error").css("display") == 'inline-block' ||
                $("#lastname_cus-error").css("display") == 'inline-block' ||
                $("#nickname_cus-error").css("display") == 'inline-block' ||
                $("#email_cus-error").css("display") == 'inline-block' ||
                $("#phone_cus-error").css("display") == 'inline-block' ||
                $("#phone_cusw-error").css("display") == 'inline-block') {} else {
                $(".userbtn2").removeClass("tshdisabled-validation");
                $("cust_title").text("اطلاعات کاربری");
                $(".cus-prof-menu li").removeClass("active-cust-profile");
                $(".userbtn2").addClass("active-cust-profile");
                $(".address-cust").hide();
                $(".per-info").hide();
                $(".user-info").show();
            }
        }, 200)
    })
    $(".tshnext-2").on("click", function() {
        setTimeout(function() {
            if ($("#username_cus-error").css("display") == 'inline-block' ||
                $("#pw_cus-error").css("display") == 'inline-block' ||
                $("#repw_cus-error").css("display") == 'inline-block') {} else {
                $(".address-btn2").removeClass("tshdisabled-validation");
                $("cust_title").text("مدیریت دسترسی ها");
                $(".cus-prof-menu li").removeClass("active-cust-profile");
                $(".address-btn2").addClass("active-cust-profile");
                $(".per-info").hide();
                $(".address-cust").show();
                $(".user-info").hide();
            }
        }, 200)
    })
    $("#blgform").validate({
        rules: {
            postsubj: {
                required: true
            },
            mindesc: {
                required: true
            },
            grpdd: {
                required: true
            },
            catdd: {
                required: true
            },
            tagdd: {
                required: true
            },
            srchvl: {
                required: true
            },
            grpname: {
                required: true
            },
            grptkn: {
                required: true
            },
            catname: {
                required: true
            },
            catname2: {
                required: true
            },
            tagname: {
                required: true
            }
        },
        messages: {
            postsubj: {
                required: "موضوع پست را وارد کنید"
            },
            mindesc: {
                required: "توضیحات مختصر را وارد کنید"
            },
            grpdd: {
                required: "گروه را انتخاب کنید"
            },
            catdd: {
                required: "دسته بندی را انتخاب کنید"
            },
            tagdd: {
                required: "دسته بندی را انتخاب کنید"
            },
            srchvl: {
                required: "ارزش جستجو را وارد کنید"
            },
            grpname: {
                required: "نام گروه را وارد کنید"
            },
            grptkn: {
                required: "نشانه گروه را وارد کنید"
            },
            catname: {
                required: "نام دسته بندی را وارد کنید"
            },
            catname2: {
                required: "دسته بندی را انتخاب کنید"
            },
            tagname: {
                required: "نام برچسب را وارد کنید"
            }
        }
    });

    $("#pgfrm").validate({
        rules: {
            catnamepg: {
                required: true
            },
            nm1: {
                required: true
            },
            nm2: {
                required: true
            },
            nm3: {
                required: true
            },
            nm4: {
                required: true
            },
            nm5: {
                required: true
            },
            nm6: {
                required: true
            },
            nm7: {
                required: true
            },
            nm8: {
                required: true
            },
            nm9: {
                required: true
            },
            nm10: {
                required: true
            },
            nm11: {
                required: true
            },
        },
        messages: {
            catnamepg: {
                required: "نام سردسته محصول را وارد کنید"
            },
            nm1: {
                required: "سردسته محصول را انتخاب کنید"
            },
            nm2: {
                required: "نام گروه اصلی را وارد کنید"
            },
            nm3: {
                required: "گروه اصلی محصول را انتخاب کنید"
            },
            nm4: {
                required: "نام گروه را وارد کنید"
            },
            nm5: {
                required: "نام ویژگی را وارد کنید"
            },
            nm6: {
                required: "گروه محصول را انتخاب کنید"
            },
            nm7: {
                required: "ویژگی محصول را انتخاب کنید"
            },
            nm8: {
                required: "نام جزئیات را وارد کنید"
            },
            nm9: {
                required: "نام برچسب اصلی را وارد کنید"
            },
            nm10: {
                required: "توضیحات را وارد کنید"
            },
            nm11: {
                required: "نام برچسب محصول را وارد کنید"
            },
        }
    });


    $(".tagsub").on("click", function () {
        setTimeout(function() {
            $("#catname2-error").appendTo($("#catname2-error").parent());
        }, 0.001)
    })
    $(".sendblg").on("click", function() {
        setTimeout(function() {
            $("#grpdd-error").appendTo($("#grpdd-error").parent());
            $("#catdd-error").appendTo($("#catdd-error").parent());
            $("#tagdd-error").appendTo($("#tagdd-error").parent());
        }, 0.001)
    })
    $(".saveadmin").on("click", function() {
        setTimeout(function() {
            $("#permi_select-error").appendTo($("#permi_select-error").parent());
        }, 0.001)
    })
    $(".prdn2").on("click", function() {
        setTimeout(function() {
            $("#prd6-error").appendTo($("#prd6-error").parent());
            $("#prd7-error").appendTo($("#prd7-error").parent());
            $("#prd8-error").appendTo($("#prd8-error").parent());
            $("#prd9-error").appendTo($("#prd9-error").parent());
        }, 0.001)
    })
    $(".prdn3").on("click", function() {
        setTimeout(function() {
            $("#prd10-error").appendTo($("#prd10-error").parent());
            $("#prd11-error").appendTo($("#prd11-error").parent());
        }, 0.001)
    })
    $(".prdn4").on("click", function() {
        setTimeout(function() {
            $("#prd14-error").appendTo($("#prd14-error").parent());
            $("#prd15-error").appendTo($("#prd15-error").parent());
            $("#prd20-error").appendTo($("#prd20-error").parent());
            $("#prd21-error").appendTo($("#prd21-error").parent());
            $("#prd22-error").appendTo($("#prd22-error").parent());
        }, 0.001)
    })
    $(".tga").on("click", function() {
        setTimeout(function() {
            $("#nm1-error").appendTo($("#nm1-error").parent());
            $("#nm3-error").appendTo($("#nm3-error").parent());
            $("#nm6-error").appendTo($("#nm6-error").parent());
            $("#nm7-error").appendTo($("#nm7-error").parent());
        }, 0.001)
    })
    $(".inner-stat-text").parent().on("click", function() {
        if ($("#m_chart_sales_stats").css("display") == 'none') {
            $("#m_chart_sales_stats").addClass("disblock");
            $("#m_chart_sales_stats").removeClass("disnone");
            $("#m_chart_sales_stats2").addClass("disnone");
            $("#m_chart_sales_stats2").removeClass("disblock");
            $(".stat-text").text("نمودار قیمت سال")
            $(".inner-stat-text").text("نمودار قیمت ماه")
        } else {
            $("#m_chart_sales_stats").removeClass("disblock");
            $("#m_chart_sales_stats").addClass("disnone");
            $("#m_chart_sales_stats2").removeClass("disnone");
            $("#m_chart_sales_stats2").addClass("disblock");
            $(".inner-stat-text").text("نمودار قیمت سال")
            $(".stat-text").text("نمودار قیمت ماه")
        }
    })
    $(".inner-stat-text2").parent().on("click", function() {
        if ($("#m_chart_sales_stats3").css("display") == 'none') {
            $("#m_chart_sales_stats3").addClass("disblock");
            $("#m_chart_sales_stats3").removeClass("disnone");
            $("#m_chart_sales_stats4").addClass("disnone");
            $("#m_chart_sales_stats4").removeClass("disblock");
            $(".stat-text2").text("میزان فروش سال")
            $(".inner-stat-text2").text("میزان فروش ماه")
        } else {
            $("#m_chart_sales_stats3").removeClass("disblock");
            $("#m_chart_sales_stats3").addClass("disnone");
            $("#m_chart_sales_stats4").removeClass("disnone");
            $("#m_chart_sales_stats4").addClass("disblock");
            $(".inner-stat-text2").text("میزان فروش سال")
            $(".stat-text2").text("میزان فروش ماه")
        }
    })
    var tlHeight = $(".tshlc .m-timeline-2__items").height();
    $('head').append('<style>.tshlc .m-timeline-2:before{height:' + tlHeight + 'px!important;}</style>');
    $(".gal-btn").on("click", function() {
        $(".uploader-header li span").removeClass("active-upload");
        $(this).addClass("active-upload")
        $(".upload-div").hide();
        $(".gal-div").show();
        $(".select-uploader").show();
        $(".upload-fields").hide();
    })
    $(".upload-btn").on("click", function() {
        $(".uploader-header li span").removeClass("active-upload");
        $(this).addClass("active-upload")
        $(".upload-div").show();
        $(".gal-div").hide();
        $(".select-uploader").hide();
        $(".upload-fields").show();
    })
    $(".gal-h3").on("click", function() {
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
    $(".ubtn1").on("click", function() {
        $(".ubtn1").hide();
        $(".ubtn2").hide();
        $(".ubtn3").show();
        $(".ubtn4").show();
        $(".picinps").removeAttr("disabled");
    })
    $(".ubtn3 , .ubtn4").on("click", function() {
        $(".ubtn1").show();
        $(".ubtn2").show();
        $(".ubtn3").hide();
        $(".ubtn4").hide();
        $(".picinps").attr("disabled", "disabled");
    })
    $(".uimg").on("click", function() {
        $(".upload-left .img-border").removeClass("no-border");
        $(".upload-left div video").hide();
        $(".show-file").hide();
        $(".upload-left div img").show();
        $(".uimg").parent().removeClass("active-border");
        $(".uvideo").parent().removeClass("active-border");
        $(".ufile").removeClass("active-border");
        $(this).parent().addClass("active-border");
        setTimeout(function() {
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
        $(".deleteimgbtn").data('name',picname)
    })
    $(".uvideo").on("click", function() {
        $(".upload-left .img-border").removeClass("no-border");
        $(".upload-left div img").hide();
        $(".show-file").hide();
        $(".upload-left div video").show();
        $(".uimg").parent().removeClass("active-border");
        $(".uvideo").parent().removeClass("active-border");
        $(".ufile").removeClass("active-border");
        $(this).parent().addClass("active-border");
        setTimeout(function() {
            $(".upload-left").addClass("upload-left-active");
        }, 500)
        $(".upload-right").removeClass("col-lg-12");
        $(".upload-right").addClass("col-lg-9");
        var picsrc = $(this).attr("src");
        var picname = $(this).data('name');
        var piclabel = $(this).data('label');
        var picdesc = $(this).data('desc');
        var picurl = $(this).data('url');
        $(".left-img").attr("src" , picsrc);
        $(".picname").val(picname);
        $(".piclabel").val(piclabel);
        $(".picdesc").val(picdesc);
        $(".upload-left div video source").attr("src" , picurl);
        $(".deleteimgbtn").data('name',picname)
    })
    $(".ufile").on("click", function() {
        $(".upload-left .img-border").addClass("no-border");
        $(".upload-left div img").hide();
        $(".show-file").show();
        $(".upload-left div video").hide();
        $(".ufile").removeClass("active-border");
        $(".uvideo").parent().removeClass("active-border");
        $(".uimg").parent().removeClass("active-border");
        $(this).addClass("active-border");
        setTimeout(function() {
            $(".upload-left").addClass("upload-left-active");
        }, 500)
        $(".upload-right").removeClass("col-lg-12");
        $(".upload-right").addClass("col-lg-9");
        var picsrc = $(this).attr("src");
        var picname = $(this).data('name');
        var piclabel = $(this).data('label');
        var picdesc = $(this).data('desc');
        var picurl = $(this).data('url');
        $(".left-img").attr("src" , picsrc);
        $(".picname").val(picname);
        $(".piclabel").val(piclabel);
        $(".picdesc").val(picdesc);
        $(".upload-left div video source").attr("src" , picurl);
        $(".deleteimgbtn").data('name',picname)
    })
    $(".delete-selected-pic").on("click", function() {
        $(this).parent().parent().remove();
    })
    $(".custom-dropzone").on("dragend dragenter dragleave dragover dragstart drop", function() {
        return false;
    })
    $(".custom-dropzone").on("click", function() {
        $(".file-selected").click();
    })

    $("body").on("click", ".remove-prw-img" , function(){
        $(this).parent().hide();
    })
    $(".btn-remove-slider-img").on("click" , function(){
        var parChLen = $(".slideshow-container").children().length;
        if(parChLen == "3"){
            $(".slideshow-container").remove();
        }
        $(this).parent().remove();
        $(".next").click();
    })
    $(".mySlides").on("click" , function(){
        var imgSrc = $(this).find("img").data("url");
        $("#viewmodal").modal();
        $(".view-img").attr("src",imgSrc);
    })
    ////$('.clockpicker').clockpicker();
    //$("#pdpDefault").persianDatepicker({ alwaysShow: false, });
    //$("#pdpDefault2").persianDatepicker({ alwaysShow: false, });
    $(".today").click();
    var now = new Date().toLocaleTimeString('en-US', { hour12: false,
        hour: "numeric",
        minute: "numeric"});
    $(".ttime").val(now);
    $("#sv-form").validate({
        rules: {
            sv1: {
                required: true
            },
            sv2: {
                required: true
            },
            sv3: {
                required: true
            },
            sv4: {
                required: true
            },
            sv5: {
                required: true
            },
            sv6: {
                required: true
            },
            sv7: {
                required: true
            },
            sv8: {
                required: true
            },
        },
        messages: {
            sv1: {
                required: "تاریخ را انتخاب کنید"
            },
            sv2: {
                required: "ساعت را انتخاب کنید"
            },
            sv3: {
                required: "کد محصول را وارد کنید"
            },
            sv4: {
                required: "نام محصول را وارد کنید"
            },
            sv5: {
                required: "میزان وارده را وارد کنید"
            },
            sv6: {
                required: "قیمت وارده را وارد کنید"
            },
            sv7: {
                required: "انبار را انتخاب کنید"
            },
            sv8: {
                required: "جزئیات محصول را وارد کنید"
            },
        }
    });
    $("#sv-form2").validate({
        rules: {
            sv1: {
                required: true
            },
            sv2: {
                required: true
            },
            sv3: {
                required: true
            },
            sv4: {
                required: true
            },
            sv5: {
                required: true
            },
            sv6: {
                required: true
            },
            sv7: {
                required: true
            },
            sv8: {
                required: true
            },
        },
        messages: {
            sv1: {
                required: "تاریخ را انتخاب کنید"
            },
            sv2: {
                required: "ساعت را انتخاب کنید"
            },
            sv3: {
                required: "کد محصول را وارد کنید"
            },
            sv4: {
                required: "نام محصول را وارد کنید"
            },
            sv5: {
                required: "میزان صادره را وارد کنید"
            },
            sv6: {
                required: "قیمت صادره را وارد کنید"
            },
            sv7: {
                required: "انبار را انتخاب کنید"
            },
            sv8: {
                required: "جزئیات محصول را وارد کنید"
            },
        }
    });
    $(".tshdeacprod").on("click" , function () {
        var thisName = $(this).data("name");
        $("#deactivemodal2").find("#data-name2").text(thisName);
    })
    $(".sv-form-btn").on("click", function() {
        setTimeout(function() {
            $("#sv7-error").appendTo($("#sv7-error").parent());
            $("#sv7-error").appendTo($("#sv7-error").parent());
            $("#sv7-error").appendTo($("#sv7-error").parent());
        }, 0.001)
    })
    $(".sv-form-btn2").on("click", function() {
        setTimeout(function() {
            $("#sv77-error").appendTo($("#sv77-error").parent());
            $("#sv77-error").appendTo($("#sv77-error").parent());
            $("#sv77-error").appendTo($("#sv77-error").parent());
        }, 0.001)
    })
    $(".custom-chevron").on("click" , function(){
        if($(this).hasClass("custom-chevron-active")){
            $(".rr-right").addClass("col-lg-4");
            $(this).next().show();
            $(".rr-left").addClass("col-lg-8");
            $(".rr-left").removeClass("col-lg-12");
            $(this).removeClass("custom-chevron-active")
        }else{
            $(".rr-right").removeClass("col-lg-4");
            $(this).next().hide();
            $(".rr-left").removeClass("col-lg-8");
            $(".rr-left").addClass("col-lg-12");
            $(this).addClass("custom-chevron-active")
        }
    })
})
$(function() {
    var imagesPreview = function(input, placeToInsertImagePreview) {
        if (input.files) {
            var filesAmount = input.files.length;
            for (i = 0; i < filesAmount; i++) {
                var reader = new FileReader();
                reader.onload = function(event) {
                    $($.parseHTML('<div class="col-lg-3" style="position: relative;"><button class="btn btn-danger remove-prw-img" style="position: absolute;top: 0;right: 0;z-index: 999!important;padding: 7px;"><i class="fa fa-trash"></i></button><img src="'+event.target.result+'"></div>')).appendTo(placeToInsertImagePreview);
                }
                reader.readAsDataURL(input.files[i]);
            }
        }
    };
    $('.file-selected').on('change', function() {
        imagesPreview(this, 'div.gallery');
    });
});
function closeDI() {
    $("#deleteimg").fadeOut();
}

function loadChart(clicked, obj) {
    $(".m-widget17__chart canvas").hide();
    $(obj).show();
    $(".tshic").removeClass("tshic-active");
    $(clicked).addClass("tshic-active");
}
var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    //slides[slideIndex - 1].style.display = "block";
    //dots[slideIndex - 1].className += " active";
}