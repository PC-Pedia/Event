
function CreateModal() {
    
    var modal = new tingle.modal({
        footer: false,
        stickyFooter: false,
        closeMethods: ['overlay', 'button', 'escape'],
        closeLabel: "Close",
        cssClass: ['msg', 'custom-class-2'],
        onOpen: function () {

        },
        onClose: function () {

        },
        beforeClose: function () {
            // here's goes some logic
            // e.g. save content before closing the modal
            return true; // close the modal
            return false; // nothing happens
        }
    });

    //modal.addFooterBtn('sss', 'btn btn-danger', function () {
    //    // here goes some logic
    //    modal.close();
    //});



    return modal;
}


function ShowMessage(message)
{
    //var Icon = '';

    //if (message.type == "success")
    //{
    //    Icon = 'fa fa-check'
    //}
    //else if (message.type == "danger")
    //{
    //    Icon = 'fa fa-times';
    //}
    debugger;
    var icn = '<span data-notify="icon" class="fa fa-circle-o"></span> ';
    var body = '';

    for (var i = 0, len = message.body.length; i < len; i++) {
        body +=  " <br /> " + icn + message.body[i] ;
    }


    debugger;
    $.notify({
        // options
        //icon: 'fa fa-circle-o',
        //title: 'Bootstrap notify',
        message: body,
        //target: '_blank'
    }, {
            // settings
            element: 'body',
            position: null,
            type: message.type,
            allow_dismiss: true,
            newest_on_top: true,
            showProgressbar: false,
            placement: {
                from: "top",
                align: "right"
            },
            offset: 20,
            spacing: 10,
            z_index: 1000,
            delay: 150000,
            timer: 10000,
            url_target: '_blank',
            mouse_over: null,
            animate: {
                enter: 'animated fadeInDown',
                exit: 'animated fadeOutUp'
            },
            onShow: null,
            onShown: null,
            onClose: null,
            onClosed: null,
            icon_type: 'class',
            template: '<div data-notify="container" class="col-xs-11 col-sm-3 alert alert-{0} msg" role="alert">' +
            '<button type="button" aria-hidden="true" class="close" data-notify="dismiss">×</button>' +
            '<span>&nbsp&nbsp&nbsp&nbsp</span>' +
            
            '<span data-notify="title"><strong>{1}</strong></span> ' +
            '<span data-notify="message" class="rtl">{2}</span>' +
            '<div class="progress" data-notify="progressbar">' +
            '<div class="progress-bar progress-bar-{0}" role="progressbar" aria-valuenow="0" aria-valuemin="0" aria-valuemax="100" style="width: 0%;"></div>' +
            '</div>' +
            '<a href="{3}" target="{4}" data-notify="url"></a>' +
            '</div>'
        });

}


function UpdateList(action) {
    

    StartLoading();

    debugger;
    var Forminfo = $("#searchForm").serializeArray();
    
     debugger;
    var url = action;
    $.ajax({
        type: "Get",
        url: url,
        data: Forminfo,
        beforeSend: function () {

        },
        success: function (data) {

            $("#List").html(data);
        }
    }).done(function (data) {

        StopLoading();

    });

}


function ShowModal(content) {
    var options = {};
    $('[data-remodal-id=modal]').html(content);
    var modal = $('[data-remodal-id=modal]').remodal(options);
    modal.open();

}


function StartLoading()
{
    debugger;
    $("#btnSearch").hide();
    $("#loading").show();
  
}

function StopLoading() {
    debugger;
    $("#loading").hide();
    $("#btnSearch").show();
}


