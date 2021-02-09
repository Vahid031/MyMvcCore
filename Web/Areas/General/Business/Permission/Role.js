$(function () {

    var tree;

    AJAX({
        type: 'Post',
        url: '../Role/_Tree',
        success: function (data, status, xhr) {

            tree = $("#tree-role").Tree({
                data: data,
                selectable: true
            });


            $(tree).on('select', function (e, id, parentId) {

                Tree_RolePermission(id);

            });
        }
    });
});

function Tree_RolePermission(roleId) {

    var tree;

    AJAX({
        type: 'Post',
        url: '../Role/_Permission',
        data: { id: roleId },
        success: function (data) {


            tree = $("#tree-rolePermission").Tree({
                data: data,
                showIcon: true,
                checkbox: true,
                autoChecked: true,
                expandAll: true
            });

            $('#nav-role .btn-save').on('click', function () {

                AJAX({
                    type: 'Post',
                    url: '../Permission/SetRolePermission',
                    data: { roleId: roleId, permissionId: tree.Values() },
                    success: function (data) {

                        Messages(data.type, data.message);
                    }
                });
            });

        }

    });

}