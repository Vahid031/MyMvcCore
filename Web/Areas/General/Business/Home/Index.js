$(function () {

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

    $('.menu-btn.side').trigger('click');

});