$(function () {

    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {

        var current = $(e.relatedTarget).attr('href');
        var target = $(e.target).attr('href');
        var url = $(e.target).attr("data-url");


        if (target == '#nav-new') {

            $('#frm-create-permission').PartialView({
                url: url
            });

            AJAX({
                url: '../Permission/_Tree',
                success: function (data) {

                    var tree = $("#tree-create-permission").Tree({
                        data: data,
                        //expandAll: true,
                        showIcon: true,
                        selectable: true
                    });


                    $(tree).on('select', function (e, id) {

                        var $container = $('#frm-create-permission');

                        $container.PartialView({
                            type: 'Post',
                            url: '../Permission/_Update',
                            data: { id: id },
                            callBack: function () {

                                $container.HandleValidation();
                                $container.find('#btnSave').val('ویرایش');
                            }
                        });
                    });
                }
            });

        }
        else {

            $(target).PartialView({
                url: url
            });
        }
    });

    $('#nav-new-tab').click();


});