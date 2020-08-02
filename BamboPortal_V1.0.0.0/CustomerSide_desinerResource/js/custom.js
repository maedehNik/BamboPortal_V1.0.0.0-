$(document).ready(function(){
    $(".account-li").on("click" , function(){
        $(".tshsubmneu").slideToggle();
    })
    var revapi;
    jQuery(document).ready(function () {
        setInterval(function () {
            $('.owl-prev').trigger('click');
        }, 3000);
        revapi = jQuery("#rev_slider_1").revolution({
            sliderType: "standard",
            sliderLayout: "fullscreen",
            fullScreenOffsetContainer: ".navigation",
            delay: 9000,
            navigation: {
                keyboardNavigation: "off",
                mouseScrollNavigation: "on",
                onHoverStop: "off",
                touch: {
                    touchenabled: "on",
                    swipe_threshold: 75,
                    swipe_min_touches: 1,
                    swipe_direction: "horizontal",
                    drag_block_vertical: false
                },
                bullets: {
                    enable: true,
                    rtl: true,
                    hide_onmobile: false,
                    style: "hebe",
                    hide_onleave: false,
                    direction: "horizontal",
                    h_align: "center",
                    v_align: "bottom",
                    h_offset: 0,
                    v_offset: 10,
                    space: 5,
                    tmp: '<span class="tp-bullet-inner"></span>'
                }
            },
            responsiveLevels: [4096, 1024, 767, 480],
            gridwidth: 1230,
            gridheight: 720
        });
        $("#LoaderSpinner").delay(200).hide(0);
    });
    var cartChild = $(".cart-items").children().length;
    if(cartChild == 0){
        $(".no-item").show();
    }
    $(".full-screen-menu-trigger").on("click" , function(){
        $(".shopping-cart-slide.active").removeClass("active")
    })
    $(".filters-size a").on("click" , function(){
        $(this).toggleClass("selection-active");
    })
    $(".shcqm").on("click" , function () {
        var thisVal = parseInt($(this).next().val());
        if(thisVal > 1){
            thisVal--;
        }
        $(this).next().val(thisVal)
        var FirstPrice = $(this).parent().parent().parent().find(".first-price").find("span").data("price");
        var LastPrice = FirstPrice * thisVal;
        $(this).parent().parent().parent().find(".last-price").find("span").text(formatMoney(LastPrice));
        updateCart();
    })
    $(".shcqp").on("click" , function () {
        var thisVal = parseInt($(this).parent().find(".qty").val());
        var newVal = thisVal + 1;
        $(this).parent().find(".qty").val(newVal)
        var FirstPrice = $(this).parent().parent().parent().find(".first-price").find("span").data("price");
        var LastPrice = FirstPrice * newVal;
        $(this).parent().parent().parent().find(".last-price").find("span").text(formatMoney(LastPrice));
        updateCart();
    })
    $(".remove-cart-item").on("click" , function(){
        $(this).parent().parent().remove();
        updateCart();
        checkCart();
    })
    $(".cart-item-remove").on("click" , function () {
        $(this).parent().remove();
        var sideCart = $(".side-cart").children().length;
        if(sideCart == 0){
            $(".no-item").show();
        }
    })
    $("#login-form").validate({
        rules: {
            mobile: {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            password: {
                required: true
            }
        },
        messages: {
            mobile: {
                required: "شماره موبایل را وارد کنید",
                digits: "شماره موبایل معتبر وارد کنید",
                minlength: "شماره موبایل معتبر وارد کنید",
                maxlength: "شماره موبایل معتبر وارد کنید"
            },
            password: {
                required: "کلمه عبور را وارد کنید"
            }
        }
    });
    $("#reset-pw-form").validate({
        rules: {
            resetmobile: {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            }
        },
        messages: {
            resetmobile: {
                required: "شماره موبایل را وارد کنید",
                digits: "شماره موبایل معتبر وارد کنید",
                minlength: "شماره موبایل معتبر وارد کنید",
                maxlength: "شماره موبایل معتبر وارد کنید"
            }
        }
    });
    $("#registration-form").validate({
        rules: {
            firstname: {
                required: true
            },
            lastname: {
                required: true
            },
            sumobile: {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            supassword: {
                required: true,
                minlength: 8
            },
            surpassword: {
                required: true,
                minlength: 8,
                equalTo: "#supassword"
            },
            ghinput: {
                required: true,
            }
        },
        messages: {
            firstname: {
                required: "نام را وارد کنید"
            },
            lastname: {
                required: "نام خانوادگی را وارد کنید"
            },
            sumobile: {
                required: "شماره موبایل را وارد کنید",
                digits: "شماره موبایل معتبر وارد کنید",
                minlength: "شماره موبایل معتبر وارد کنید",
                maxlength: "شماره موبایل معتبر وارد کنید"
            },
            supassword: {
                required: "کلمه عبور را وارد کنید",
                minlength: "کلمه عبور باید حداقل 8 کاراکتر باشد"
            },
            surpassword: {
                required: "تکرار کلمه عبور را وارد کنید",
                minlength: "کلمه عبور باید حداقل 8 کاراکتر باشد",
                equalTo: "تکرار کلمه عبور اشتباه است"
            },
            ghinput: {
                required: "پذیرفتن قوانین الزامی است",
            }
        }
    });
    $("#account-form").validate({
        rules: {
            firstname: {
                required: true
            },
            lastname: {
                required: true
            },
            mobile: {
                required: true,
                digits: true,
                minlength: 11,
                maxlength: 11
            },
            email: {
                required: true,
                email: true
            }
        },
        messages: {
            firstname: {
                required: "نام را وارد کنید"
            },
            lastname: {
                required: "نام خانوادگی را وارد کنید"
            },
            mobile: {
                required: "شماره موبایل را وارد کنید",
                digits: "شماره موبایل معتبر وارد کنید",
                minlength: "شماره موبایل معتبر وارد کنید",
                maxlength: "شماره موبایل معتبر وارد کنید"
            },
            email: {
                required: "ایمیل را وارد کنید",
                email: "ایمیل معتبر وارد کنید"
            }
        }
    });
    $("#account-form2").validate({
        rules: {
            password: {
                required: true,
                minlength: 8
            },
            rpassword: {
                required: true,
                minlength: 8,
                equalTo: "#password"
            },
        },
        messages: {
            password: {
                required: "کلمه عبور را وارد کنید",
                minlength: "کلمه عبور باید حداقل 8 کاراکتر باشد"
            },
            rpassword: {
                required: "تکرار کلمه عبور را وارد کنید",
                minlength: "کلمه عبور باید حداقل 8 کاراکتر باشد",
                equalTo: "تکرار کلمه عبور اشتباه است"
            },
        }
    });
    $("#account-form3").validate({
        rules: {
            province: {
                required: true,
            },
            city: {
                required: true,
            },
            area: {
                required: true,
            },
            pcode: {
                required: true,
                digits: true,
                minlength: 10,
                maxlength: 10
            },
            address: {
                required: true,
                maxlength: 150
            }
        },
        messages: {
            province: {
                required: "استان را انتخاب کنید",
            },
            city: {
                required: "شهر را انتخاب کنید",
            },
            area: {
                required: "منطقه را وارد کنید",
            },
            pcode: {
                required: "کد پستی را وارد کنید",
                digits: "کد پستی معتبر وارد کنید",
                minlength: "کد پستی معتبر وارد کنید",
                maxlength: "کد پستی معتبر وارد کنید"
            },
            address: {
                required: "ادرس را وارد کنید",
                maxlength: "آدرس معتبر وارد کنید"
            }
        }
    });
    $("header").on("click" , function () {
        $(".forgot-password-bg").fadeOut();
    })
    $(".forgot-password").on("click" , function () {
        $(".forgot-password-bg").fadeIn();
    })
    $(".forgot-password-inner h5 i").on("click" , function () {
        $(this).parent().parent().parent().fadeOut();
    })
    $(".change-mobile-inner h5 i").on("click" , function () {
        $(this).parent().parent().parent().fadeOut();
    })
    $(".codebox").keyup(function(){
        if($(this).val().length > 1){
            $(this).val("");
        }
    })
    $(".change-phone").on("click" , function () {
        $(".change-mobile-bg").fadeIn();
    })
    $(".verify-submit").on("click" , function () {
        var code1 = $("#codeBox1").val();
        var code2 = $("#codeBox2").val();
        var code3 = $("#codeBox3").val();
        var code4 = $("#codeBox4").val();
        if(code1 == "" || code2 == "" || code3 == "" || code4 == ""){
            $(".verify-error").addClass("verify-error-show");
            return false;
        }
    })
    $(".show-more").on("click" , function(){
        $(this).parent().next().next().slideToggle(500);
    })
    $(".dmbutton").on("click" , function(){
        var thisNum = $(this).data("number");
        $("#mmodal").find(".number").text(thisNum);
    })
    $(".alert-inner .fa-times").on("click" , function () {
        $(this).parent().parent().parent().fadeOut();
    })
    $(".alert-inner .conf-btn").on("click" , function () {
        $(this).parent().parent().parent().fadeOut();
    })
})
checkCart();
function checkCart() {
    var childLen = $(".tbdy").children().length
    if(childLen == 0){
        $(".cart-no-item").addClass("show-no-item");
    }
}
function disableCoupon() {
    $(".coupon-input").addClass("disabled").attr("disabled","disabled");
    $(".coupon-fa i").removeClass("fa-check");
    $(".coupon-fa i").addClass("fa-times");
    $(".coupon-fa").addClass("coupon-remove");
}
function enableCoupon() {
    $(".coupon-input").removeClass("disabled").removeAttr("disabled");
    $(".coupon-fa i").addClass("fa-check");
    $(".coupon-fa i").removeClass("fa-times");
    $(".coupon-fa").removeClass("coupon-remove");
}
function updateCart() {
    var items = $('.total-items'),
        sum = 0;
    $.each(items, function(value) {
        var itemValue = items[value].innerHTML.replace(/\D/g,'');
        sum += !isNaN(itemValue) ? parseInt(itemValue) : 0;
    });
    $(".total-price-bottom").text(formatMoney(sum));
    var shippingPRC = $(".shipping-price-bottom").text().replace(/\D/g,'');
    var off = $(".off-price-bottom").text().replace(/\D/g,'');
    var last = parseInt(sum) + parseInt(shippingPRC) - parseInt(off);
    var total = $(".cart-total").text(formatMoney(last));
}
function addToCart(){
    var cartNum = $(".menu-basket span").text();
    cartNum++;
    $(".menu-basket span").text(cartNum);
}
function formatMoney(amount, decimalCount = 0, decimal = ".", thousands = ",") {
    try {
        decimalCount = Math.abs(decimalCount);
        decimalCount = isNaN(decimalCount) ? 2 : decimalCount;
        const negativeSign = amount < 0 ? "-" : "";
        let i = parseInt(amount = Math.abs(Number(amount) || 0).toFixed(decimalCount)).toString();
        let j = (i.length > 3) ? i.length % 3 : 0;
        var last = negativeSign + (j ? i.substr(0, j) + thousands : '') + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousands) + (decimalCount ? decimal + Math.abs(amount - i).toFixed(decimalCount).slice(2) : "");
        return last;
    } catch (e) {
        console.log(e)
    }
}
function getCodeBoxElement(index) {
    return document.getElementById('codeBox' + index);
}
function onKeyUpEvent(index, event) {
    const eventCode = event.which || event.keyCode;
    if (getCodeBoxElement(index).value.length === 1) {
        if (index !== 4) {
            getCodeBoxElement(index+ 1).focus();
        } else {
            getCodeBoxElement(index).blur();
            console.log('submit code ');
        }
    }
    if (eventCode === 8 && index !== 1) {
        getCodeBoxElement(index - 1).focus();
    }
}
function onFocusEvent(index) {
    for (item = 1; item < index; item++) {
        const currentElement = getCodeBoxElement(item);
        if (!currentElement.value) {
            currentElement.focus();
            break;
        }
    }
}
function success(title){
    $(".alert-bg").fadeIn();
    $(".alert-bg").find(".alert-text").text(title);
}
function danger(title){
    $(".alert-bg2").fadeIn();
    $(".alert-bg2").find(".alert-text").text(title);
    $(".alert-bg2").find(".alert-text").addClass("danger-color");
}