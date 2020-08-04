function ModalLoader(type, Id) {
   // alert(type);
    if (type == 'active') {
        $('#deActive_modal').text(Id);
    } else {
        $('#Active_modal').text(Id);
    }
    return false;
}


$('#ActivateBtn').click(function () {
    $('#deactivemodal').modal('toggle');
    const Id = $('#Active_modal').text();
   // alert(Id);
    const PostJson = {
        'idToActive': $('#Active_modal').text()
    };
    
    $.ajax({
        url: '/AdministratorCustomers/User_Activate',
        type: "post",
        data: JSON.stringify(PostJson),
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.Errortype == "Success") {
                AlertToUser("deactivemodal", data);
                //$('#act').show();
                //$('#deAct').hide();
                location.reload(true);
            } else {
                alert(data.Errormessage);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("مشکل در برقراری ارتباط با سرور");
        }
    });

});

$('#deleteCus').click(function () {
    $('#modal').modal('toggle');
    const Id = $('#deActive_modal').text();
   // alert(Id);
    const PostJson = {
        'idTodeActive': $('#deActive_modal').text()
    };
    
    $.ajax({
        url: '/AdministratorCustomers/User_deActivate',
        type: "post",
        data: JSON.stringify(PostJson),
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.Errortype == "Success") {
                AlertToUser("deleteCus", data);
                //$('#act').hide();
                //$('#deAct').show();
                
                location.reload(true);
            } else {
                alert(data.Errormessage);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("مشکل در برقراری ارتباط با سرور");
        }
    });

});