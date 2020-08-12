

//=================================================================================================
//{Start}For administrator addBlogCategory

if ($("#AddBlogCategorySubmiter").length == 1) {

    $(function () {
        
        $("#AddBlogCategorySubmiter").on("submit", function (e) {
            e.preventDefault();
            DisableBTN("AddBlogCategorySubmiter");
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (data) {
                    console.log(data)
                    const jsondata = data;
                    console.log(jsondata.Errortype)
                    if (jsondata.Errortype == "Success") {
                        AlertToUser("AddBlogCategorySubmiter", data);
                    } else if (jsondata.Errortype == "ErrorWithList") {
                        AlertToUser("AddBlogCategorySubmiter", data);
                    } else {
                        AlertToUser("AddBlogCategorySubmiter", data);
                    }
                }
            });
        });
    });
}
    //{END}For administrator addBlogCategory
    //=================================================================================================

//=================================================================================================
//{Start}For administrator addBlogGroups

if ($("#AddBlogGroupSubmiter").length == 1) {
    
    $(function () {

        $("#AddBlogGroupSubmiter").on("submit", function (e) {
            e.preventDefault();
            DisableBTN("AddBlogGroupSubmiter");
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (data) {
                    console.log(data)
                    const jsondata = data;
                    console.log(jsondata.Errortype)
                    if (jsondata.Errortype == "Success") {
                        AlertToUser("AddBlogGroupSubmiter", data);
                    } else if (jsondata.Errortype == "ErrorWithList") {
                        AlertToUser("AddBlogGroupSubmiter", data);
                    } else {
                        AlertToUser("AddBlogGroupSubmiter", data);
                    }
                }
            });
        });
    });
}
    //{END}For administrator AddBlogGroups
    //=================================================================================================

//=================================================================================================
//{Start}For administrator addBlogTags

if ($("#AddBlogTagSubmiter").length == 1) {

    $(function () {

        $("#AddBlogTagSubmiter").on("submit", function (e) {
            e.preventDefault();
            DisableBTN("AddBlogTagSubmiter");
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (data) {
                    console.log(data)
                    const jsondata = data;
                    console.log(jsondata.Errortype)
                    if (jsondata.Errortype == "Success") {
                        AlertToUser("AddBlogTagSubmiter", data);
                    } else if (jsondata.Errortype == "ErrorWithList") {
                        AlertToUser("AddBlogTagSubmiter", data);
                    } else {
                        AlertToUser("AddBlogTagSubmiter", data);
                    }
                }
            });
        });
    });
}
    //{END}For administrator AddBlogTags
    //=================================================================================================

//=================================================================================================
//{Start}For administrator BlogAddPost

if ($("#NewPostSubmiter").length == 1) {

    $(function () {
        var textareaValue = $("#summernote").code();
        alert(textareaValue);
        $("#AddPostModel_Text").val(textareaValue);
        $("#NewPostSubmiter").on("submit", function (e) {
            e.preventDefault();
            DisableBTN("NewPostSubmiter");
            $.ajax({
                url: this.action,
                type: this.method,
                data: $(this).serialize(),
                success: function (data) {
                    console.log(data)
                    const jsondata = data;
                    console.log(jsondata.Errortype)
                    if (jsondata.Errortype == "Success") {
                        AlertToUser("NewPostSubmiter", data);
                    } else if (jsondata.Errortype == "ErrorWithList") {
                        AlertToUser("NewPostSubmiter", data);
                    } else {
                        AlertToUser("NewPostSubmiter", data);
                    }
                }
            });
        });
    });
}
    //{END}For administrator BlogAddPost
    //=================================================================================================