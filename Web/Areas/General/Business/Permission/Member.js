$(function () {

    $('#ddlmember , input:radio[name="AccessType"]').on('change', function () {

        Tree_MemberPermission($('#ddlmember').val());
    });

});


function Tree_MemberPermission(memberId) {

    var tree;

    var isDenied = $('input:radio[name="AccessType"]:checked').val();

    isDenied = Boolean(isDenied == 'true');

    if (!(memberId > 0))
        return;

    AJAX({
        type: 'Post',
        url: '../Member/_Permission',
        data: { id: memberId, isDenied: isDenied },
        success: function (data) {

            tree = $("#tree-permission").Tree({
                data: data,
                showIcon: true,
                checkbox: true,
                expandAll: true
            });

            $('#nav-member .btn-save').on('click', function () {

                isDenied = $('input:radio[name="AccessType"]:checked').val();

                AJAX({
                    type: 'Post',
                    url: '../Permission/SetMemberPermission',
                    data: { memberId: memberId, permissionId: tree.Values(), isDenied: isDenied },
                    success: function (data) {

                        Messages(data.type, data.message);
                    }

                });
            });
        }
    });

}