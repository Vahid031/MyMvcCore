let permissions;

$(function () {
    AJAX({
        url: '../Account/CheckAuthentication',
        async: false,
        success: function (result) {

            if (result == true) {
                if (permissions == undefined) {

                    AJAX({
                        type: 'Post',
                        url: '../Permission/_Menu',
                        async: false,
                        success: function (data) {

                            permissions = data;
                        }

                    });
                }

                CreateMenu();
            }
        }

    });
});

function Messages(type, message) {
    $('#Alert').removeClass('alert-success alert-info alert-warning alert-danger');

    $('#Alert').addClass('alert-' + type);
    $('#Alert .text').html(message);


    $('#Alert').hide().slideDown(300).delay(3000).slideUp(300);
}

//function GotoUrl(url) {
//    if (url == undefined)
//        url = '../'

//    Ajax('Post', '../Account/Check_Authentication', [], function (data, status, xhr) {

//        if (JSON.parse(data) == true) {
//            $('#Content').PartialView({
//                url: url
//            });
//        }
//        else {
//            $('#TopNavigation').hide();
//            $('#RightNavigation').hide();
//            $("main[role='main']").css("padding", "0");

//            $('#Content').PartialView({
//                url: '../Account/Index'
//            });

//        }
//    });
//}

function AJAX(params) {
    $.ajax({
        type: params.type == undefined ? 'GET' : params.type,
        url: params.url,
        data: params.data == undefined ? {} : params.data,
        dataType: params.dataType == undefined ? 'json' : params.dataType,
        async: params.async == undefined ? true : params.async,
        cache: params.cache != undefined ? params.cache : false,
        processData: params.processData != undefined ? params.processData : true,
        beforeSend: params.beforeSend != undefined ? params.beforeSend : function () { },//$('#loading').fadeIn(); },
        complete: params.complete != undefined ? params.complete : function () { },//$('#loading').fadeOut(); },
        success: params.success != undefined ? params.success : function (data) { console.log(data) },
        contentType: params.contentType == undefined ? "application/x-www-form-urlencoded; charset=utf-8" : params.contentType,
        failure: function () { alert('failure'); },
        error: function (xhr, Result, ajaxOptions, thrownError) {

            switch (xhr.status) {
                case 401:
                    Messages('danger', 'شما به این صفحه دسترسی ندارید');
                case 403:
                    Messages('warning', 'شما به این صفحه دسترسی ندارید');
                case 404:
                    Messages('danger', 'دسترسی غیرمجاز');

            }
        }
    });
}

function prepareLoadedForm() {
    $('.operationform').removeData('validator');
    $('.operationform').removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse('.operationform');
}

function Popup(title, type, url, data, callBack, popupSize, popupContainer) {

    type = type ? type : 'Get';
    data = data ? data : {};

    if (popupContainer == undefined) {
        popupContainer = '#mdlMain';
    }
    $(popupContainer + ' .modal-body').PartialView({
        type: type,
        url: url,
        data: data
    });

    $(popupContainer + ' .modal-title').text(title);
    $(popupContainer + ' .modal-dialog').removeClass('modal-lg');
    $(popupContainer + ' .modal-dialog').removeClass('modal-sm');

    if (popupSize == 'lg' | popupSize == 'sm')
        $(popupContainer + ' .modal-dialog').addClass('modal-' + popupSize);


    $(popupContainer).modal();

    if (typeof callBack === 'function')
        callBack();
    else if (callBack != undefined)
        eval(callBack);

}

function CreateMenu() {


    $(".sidebar nav ul").remove();
    var ul_sidebar = FillMenu(permissions, 1, 'sidebar');

    $(ul_sidebar).addClass("navbar-nav mb-5");
    $(ul_sidebar).attr("id", "sidebar");
    $(".sidebar nav").append(ul_sidebar);


    $(".topnav ul").remove();
    var ul_topnav = FillMenu(permissions, 1, 'topnav');

    $(ul_topnav).addClass("navbar-nav menu");
    $(ul_topnav).attr("id", "topnav");

    $(".topnav").append(ul_topnav);


    $('.menu-btn.side').off('change').on('change', function () {

        if ($(this).prop('checked') == false) {
            $("main[role='main']").css("margin-right", "0");
            $(".sidebar").css("width", "0");
        }
        else {
            $("main[role='main']").css("margin-right", "250px");
            $(".sidebar").css("width", "250px");
        }
    });

    $('main[role="main"]').on('click', function () {
        if ($('.menu-btn.side').prop('checked') == true) {
            $('.menu-btn.side').trigger('click');
        }
    });

    $('.topnav').show();


    //$(window).resize(function () {
    //    var display = $('#RightNavigation').css("display");
    //    var w = this.innerWidth;
    //    var h = this.innerHeight;

    //    if (display != 'none' && w > 768)
    //        $("main[role='main']").css("margin-right", "300px");
    //    else
    //        $("main[role='main']").css("margin-right", "0");
    //});



}

function FillMenu(data, parentId, dataParent) {

    var ul = document.createElement("ul");
    var filtered = $.grep(data, function (el) {
        return el.ParentId == parentId & el.Visible;
    });

    $.each(filtered, function (i, item) {

        var li = document.createElement("li");
        li.setAttribute("class", "nav-item");

        var a = document.createElement("a");

        if (item.Icon.length > 0) {
            $(a).append(`<i class='${item.icon}'></i>`);
        }
        a.append("  " + item.Title);

        var sub_ul = FillMenu(data, item.Id, "Sub" + dataParent + item.Id);
        sub_ul.setAttribute("class", "collapse navbar-nav");
        sub_ul.setAttribute("id", "Sub" + dataParent + item.Id);
        sub_ul.setAttribute("data-parent", "#" + dataParent);

        if (sub_ul.hasChildNodes()) {
            a.setAttribute("href", "#Sub" + dataParent + item.Id);
            a.setAttribute("data-toggle", "collapse");
            a.setAttribute("aria-expanded", "false");
            a.setAttribute("class", "dropdown-toggle nav-link");
            li.appendChild(a);
            li.appendChild(sub_ul);
        }
        else {
            //a.setAttribute("onclick", "GotoUrl('" + item.url + "')");
            a.setAttribute("href", item.Url);
            a.setAttribute("class", "nav-link");
            li.appendChild(a);
        }
        ul.appendChild(li);
    });

    return ul;
}

function MvcAlert(callBack) {

    $('#mdlConfirm').modal();

    $($('#mdlConfirm').find('a').get(0)).off("click").on("click", callBack);

}

function HasPermission(controller, action) {

    if (permissions == undefined) {
        AJAX({
            type: 'Post',
            url: '../Permission/_Menu',
            success: function (data) { permissions = data; },
            async: false
        });
    }


    var result = $.grep(permissions, function (e) {
        return e.Controller.toLowerCase() == controller.toLowerCase() & e.Action.toLowerCase() == action.toLowerCase()
    });


    return (result.length > 0);
}

$.fn.PartialView = function (options) {

    var container = $(this);
    var callBack;

    callBack = options.callBack;

    AJAX({
        type: options.type,
        url: options.url,
        data: options.data,
        success: function (data) { permissions = data; },
        dataType: "html",
        beforeSend: function () {
            var height = container.height();
            var width = container.width();

            container.html(`<div class="loader" style="height:${height}px;width:${width}px"><span></span></div>`);
        },
        complete: function () {
        },
        success: function (data) {

            container.fadeOut(50, function () {
                container.html(data);

                if ($('.operationform').length > 0) {
                    prepareLoadedForm();
                }

                if (typeof callBack === 'function')
                    callBack();
                else if (callBack != undefined)
                    eval(callBack);



                container.fadeIn(50);
                container.PartialViewHandler();
            });
        },
    });
}

$.fn.ResetForm = function () {

    container = $(this);

    var $validator = container.validate();
    $(this).find(".field-validation-error span").each(function () {
        $validator.settings.success($(this));
    })
    $validator.resetForm();

    container.find('input[type=text]').each(function () {
        $(this).val("");
        $(this).removeData('previousValue');
    });

    container.find('input[type=hidden]').each(function () {
        $(this).val("");
    });

    container.find('select.selectpicker').each(function () {
        $(this).val(null);
        $(this).selectpicker('refresh');
    });

    container.find('input[type=checkbox]').each(function () {
        $(this).prop("checked", false);
    });

    $(this).find('.btn-delete').each(function () {

        $(this).html('<i class="fa fa-trash"></i> حذف');
        if (!$(this).hasClass('btn btn-danger'))
            $(this).addClass('btn btn-danger');
    });

    $(this).find('.btn-cancel').each(function () {

        $(this).html('<i class="fa fa-spinner"></i> صرفنظر');
        if (!$(this).hasClass('btn btn-secondary'))
            $(this).addClass('btn btn-secondary');
    });

    $(this).find('.btn-save').each(function () {

        $(this).html('<i class="fa fa-plus"></i> ذخیره');
        $(this).removeClass('btn btn-primary');
        $(this).addClass('btn btn-success');

        if ($(this).attr('type') == 'submit') {
            var id = $(this).parents('form').first().find(".Id").first().val();

            if (!(id == '' || id == 0)) {
                $(this).html('<i class="fa fa-edit"></i> ذخیره');
                $(this).removeClass('btn btn-success');
                $(this).addClass('btn btn-primary');
            }
        }

    });

    $(this).find('.btn-add').each(function () {

        $(this).html('<i class="fa fa-plus"></i> جدید');
        if (!$(this).hasClass('btn btn-success'))
            $(this).addClass('btn btn-success');
    });
}

$.fn.PartialViewHandler = function () {

    $(this).find('.datepicker').each(function () {
        var options = {
            placeholder: "روز / ماه / سال",
            twodigit: true,
            closeAfterSelect: false,
            sync: true,
            gotoToday: false
        }
        $(this).PersianDatePicker(options);
    });

    $(this).find('.selectpicker').each(function () {
        $(this).selectpicker();
    });

    $(this).find('input[type="password"]').each(function () {

        var element = $(this);
        var a = document.createElement('a');
        a.setAttribute('class', 'Password');
        a.innerHTML = '<i class="fa fa-eye-slash" />';
        element.after(a);

        $(a).on('click', function () {
            if (element.attr('type') === 'password') {
                element.attr('type', 'text');
                $(this).html('<i class="fa fa-eye" />');
            }
            else {
                element.attr('type', 'password');
                $(this).html('<i class="fa fa-eye-slash" />');
            }
        });
    });


    $(this).find('.btn-delete').each(function () {

        $(this).html('<i class="fa fa-trash"></i> حذف');
        if (!$(this).hasClass('btn btn-danger'))
            $(this).addClass('btn btn-danger');
    });

    $(this).find('.btn-cancel').each(function () {

        $(this).html('<i class="fa fa-spinner"></i> صرفنظر');
        if (!$(this).hasClass('btn btn-secondary'))
            $(this).addClass('btn btn-secondary');
    });

    $(this).find('.btn-save').each(function () {

        $(this).html('<i class="fa fa-plus"></i> ذخیره');
        $(this).removeClass('btn btn-primary');
        $(this).addClass('btn btn-success');

        if ($(this).attr('type') == 'submit') {
            var id = $(this).parents('form').first().find(".Id").first().val();

            if (!(id == '' || id == 0)) {
                $(this).html('<i class="fa fa-edit"></i> ذخیره');
                $(this).removeClass('btn btn-success');
                $(this).addClass('btn btn-primary');
            }
        }

    });

    $(this).find('.btn-add').each(function () {

        $(this).html('<i class="fa fa-plus"></i> جدید');
        if (!$(this).hasClass('btn btn-success'))
            $(this).addClass('btn btn-success');
    });
}

$.fn.HandleValidation = function () {

    var container = $(this);

    container.find(".numeric").each(function () {

        $(this).bind("keyup", function () {
            var _this = $(this);
            _this.val(_this.val().replace(/\D/g, ''));
            //_this.val(_this.val().replace(/[^0-9]+\./, ''));
        });
    });

    container.find(".persian").each(function () {

        $(this).bind("keyup", function () {
            var _this = $(this);
            _this.val(_this.val().replace(/[^\u0600-\u06FF_ ]*$/, ''));
        });
    });

    container.find(".persian_numerical").each(function () {

        $(this).bind("keyup", function () {
            var _this = $(this);
            _this.val(_this.val().replace(/[^\u0600-\u06FF_ 0-9]*$/, ''));
        });
    });

    container.find(".seperator").on("keyup", function () {
        var str = $(this).val();

        if (!isNaN(str) && (str).length > 3) {
            $(this).val(str.replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
        }

    });
}
