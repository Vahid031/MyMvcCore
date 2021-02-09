$(function () {

    TreeOrder();
});

function TreeOrder() {

    var tree;

    AJAX({
        url: '../Permission/_Tree',
        success: function (data) {

            tree = $("#tree-order").Tree({
                data: data,
                expandAll: true,
                showIcon: true,
                dragable: true
            });

            $(tree).on('dropNode', function (e, id, parentId) {

                AJAX({
                    type: 'Post',
                    url: '../Permission/ChangePeriority',
                    data: { id: id, parentId: parentId },
                    success: function (data) {
                        if (data != true) {
                            TreeOrder();
                        }
                    }
                });

            });
        }
    });

}