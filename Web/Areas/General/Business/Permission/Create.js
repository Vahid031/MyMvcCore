$(function () {

    var $container = $('#frm-permission');

    var id = $container.find('#Permission_Id').val();


    if (id != '' && id > 0) {

        $container.find('.btn-delete').on('click', function () {

            MvcAlert(function () {

                AJAX({
                    type: 'Post',
                    url: '../Permission/_Delete',
                    data: { id: id },
                    success: function (data) {

                        Messages(data.type, data.message);

                        if (data.success == true)
                            $container.find('.btn-cancel').trigger('click');
                    }
                });
            });
        });
    }
    else {
        $container.find('.btn-delete').remove();
    }

    $container.on('click', '.btn-cancel', function () {
        $('#tree-create-permission').find('*').removeClass('tree-select');
        $container.find('.btn-delete').remove();
        $container.ResetForm();
    });


    $container.on("submit", function (e) {
        e.preventDefault();

        AJAX({
            type: 'Post',
            url: '../Permission/_Create',
            data: $container.serialize(),
            success: function (data) {

                Messages(data.type, data.message);

                if (data.success == true)
                    $container.find('.btn-cancel').trigger('click');
            }
        });
    });


    $container.HandleValidation();
});