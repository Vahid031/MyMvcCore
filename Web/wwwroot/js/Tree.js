
$(function () {

    $.fn.Tree = function (options) {

        var obj = new treeview(options, $(this));

        obj.init();
        obj.draw(null, obj.container);
        obj.handler();

        if (obj.expandAll == true) {
            obj.container.find('ul:not(:first-child) li span[role="menubar"]').parent('li').children('ul').toggle();
            obj.container.find('ul:not(:first-child) li span[role="menubar"]').removeClass('fa-rotate-90');

            obj.container.find('ul:first-child > li > span[role="menubar"]').trigger('click');
        }


        return obj;
    }
});

var treeview = function (options, container) {
    this.container = container;

    options = options ? options : {};

    this.data = options.data ? options.data : [];
    this.checkbox = options.checkbox ? options.checkbox : false;
    this.autoChecked = options.autoChecked ? options.autoChecked : false;
    this.showIcon = options.showIcon ? options.showIcon : false;
    this.selectable = options.selectable ? options.selectable : false;
    this.expandAll = options.expandAll ? options.expandAll : false;
    this.dragable = options.dragable ? options.dragable : false;

}

treeview.prototype.init = function () {
    this.container.empty();

    this.treeId = 'treexxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });

    if (!this.container.hasClass('tree'))
        this.container.addClass('tree');
}

treeview.prototype.draw = function (parentId, parent) {

    var obj = this;

    var filtered = $.grep(obj.data, function (el) {
        return el.parentId == parentId;
    });

    var ul = document.createElement("ul");

    $.each(filtered, function (i, item) {

        var children = $.grep(obj.data, function (el) {
            return el.parentId == item.id;
        });

        var li = document.createElement("li");

        if (obj.dragable == true) {
            $(li).attr("draggable", true);
        }

        $(li).attr("id", obj.treeId + "_li_" + item.id);
        $(li).attr("data-id", item.id);
        $(li).attr("data-order", item.order);

        if (children.length > 0) {
            $(li).append("<span role='menubar' class='fa fa-angle-down fa-rotate-90'></span>");
        }
        
        if (item.icon.length > 0 && obj.showIcon == true) {
            $(li).append(`<i class='${item.icon}'></i>`);
        }

        if (obj.checkbox == true) {
            $(li).append(`<input type='checkbox' id='${obj.treeId + "_cb_" + item.id}' value='${item.id}' ${item.checked === true ? 'checked="checkbox"' : ''} ${item.disable === true ? 'disabled' : ''}>`);
            $(li).append(`<label for='${obj.treeId + "_cb_" + item.id}' class="tree-text" ${item.disable === true ? 'disabled' : ''}>${item.title}</label>`);
        }
        else {
            $(li).append(`<label class="tree-text" ${item.disable === true ? 'disabled' : ''}>${item.title}</label>`);
        }
        $(li).append("<div class='tree-clear'></div>");

        obj.draw(item.id, li);

        $(ul).append(li);
    });

    $(parent).append(ul);


}

treeview.prototype.Values = function () {
    var obj = this;

    return obj.container.find("input:checkbox:checked").map(function () {
        return $(this).attr('Value');
    }).get();
}

treeview.prototype.handler = function () {

    var obj = this;


    obj.container.off("click", "ul li .tree-text").on("click", "ul li .tree-text:not([disabled])", function () {
        obj.container.find('.tree-select').removeClass('tree-select');

        var id = $(this).parent('li').attr('data-id');

        if (obj.selectable == true) {
            $(this).parent('li').children('.tree-text').addClass("tree-select");

            $(obj).triggerHandler('select', [id]);
        }
    });

    obj.container.off("click", "ul li span[role='menubar']").on("click", "ul li span[role='menubar']", function () {
        $(this).parent('li').children('ul').slideToggle('1500');
        $(this).toggleClass('fa-rotate-90');
    });

    obj.container.off("click", "input:checkbox").on("click", "input:checkbox", function () {
        var checked = $(this).prop('checked');

        if (obj.autoChecked == true) {

            $(this).siblings("ul").find("input:checkbox").prop("checked", checked);

            $(this).parents("li").each(function () {

                var anySelect = false;
                var ul = $(this).parent("ul");

                ul.find('li').each(function () {
                    var checkBox = $(this).find('input:checkbox').first();
                    anySelect |= checkBox.prop('checked');
                });

                ul.parent('li').find('input:checkbox').first().prop('checked', anySelect);
            });
        }
    });

    obj.container.off('dragstart', 'li').on('dragstart', 'li', function (e) {

        if (obj.dragable == true)
            e.originalEvent.dataTransfer.setData(obj.container.attr('id'), e.target.id);

    });

    obj.container.off("drop", 'ul').on("drop", 'ul', function (e) {
        e.preventDefault();
        e.stopPropagation();

        if (obj.dragable != true)
            return;

        var drag_li = document.getElementById(e.originalEvent.dataTransfer.getData(obj.container.attr('id')));

        var isParent = false;

        var data = $(drag_li).find("li");

        $.each(data, function (i, item) {

            if ($(e.target).parents("li").first().attr('id') == $(item).attr('id'))
                isParent = true;
        });

        var drop_li = $(e.target).parents("li").first();
        var drag_li_parent = $(drag_li).parents('li').first();

        var id = $(drag_li).attr('data-id');
        var parentId = $(drop_li).attr('data-id');

        if (!isParent && id != parentId) {
            if ($(drop_li).find('li').length == 0)
                $(drop_li).html("<span role='menubar' class='fa fa-angle-down fa-rotate-90'></span>" + $(drop_li).html());

            drop_li.find("ul").first().append(drag_li);


            if ($(drag_li_parent).find('li').length == 0) {
                $(drag_li_parent).find("span[role='menubar']").first().remove();
                $(drag_li_parent).children('ul').hide();
            }

            $(obj).triggerHandler('dropNode', [id, parentId]);
        }
    });

    obj.container.off("dragover", 'ul').on("dragover", 'ul', function (e) { e.preventDefault(); });
}



