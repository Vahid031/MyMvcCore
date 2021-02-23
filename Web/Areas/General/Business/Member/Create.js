
$(function () {
    alert("aaaaaa");
    var $container = $('#frm-Member');
    debugger
    $container.on("submit", function (e) {
        e.preventDefault();
        AJAX({
            type: 'Post',
            url: '../Member/_Create',
            data: $container.serialize()
            //success: function (data, x, y, w) {
                
            //    Messages(data.type, data.message);

            //    if (data.success == true) {
            //        $container.parents(".modal").modal('hide');
            //    }
            //}
        });
    });

    $container.on('click', '.btn-cancel', function () {
        $container.parents(".modal").modal('hide');
    });

    $container.HandleValidation();
});