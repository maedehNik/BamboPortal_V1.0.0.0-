$("#pnllogin").validate({
    rules: {
        adusername: {
            required: true
        },
        adpassword: {
            required: true
        }
    },
    messages: {
        adusername: {
            required: "نام کاربری را وارد کنید"
        },
        adpassword: {
            required: "رمز عبور را وارد کنید"
        }
    }
});