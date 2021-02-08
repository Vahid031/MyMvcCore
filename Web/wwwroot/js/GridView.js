
const ContentType = {
    data: 0,
    calculate: 1,
    rowNumber: 2,
    selectRow: 3,
    text: 4,
    function: 5
}

const FieldType = {
    textBox: 'text',
    button: 'button',
    url: 'a',
    lable: 'span',
    password: 'password',
    image: 'img',
    dropdown: 'select'
}

$.fn.CreateTable = function (options) {

    var columns = options.columns;

    if (columns == undefined) {
        alert('columns not defiend!')
    }



    var table, thead, tbody, tfoot, tr, td, a, element, search;

    // Create Table
    table = document.createElement("table");

    table.setAttribute("class", "tbl-grid");


    // Create Header
    {
        thead = document.createElement("thead");
        tbody = document.createElement("tbody");
        tr = document.createElement("tr");
        trSearch = document.createElement("tr");

        var title, sort, content, contentType;

        columns.forEach(function (col, j) {

            title = col.title ? col.title : '';
            sort = col.sort ? col.sort : true;
            content = col.key ? col.key : '';
            contentType = col.contentType ? col.contentType : ContentType.data;
            search = col.search;

            if (search == undefined) {

                search = $('<input type="text"></input>');
                search.addClass('form-control');
            }

            // Header
            td = document.createElement("th");

            if (sort === true && (contentType == ContentType.data | contentType == ContentType.function) && content != '') {

                a = document.createElement("a");
                a.setAttribute("data-th", content + " ascending");
                a.innerHTML = "<i class='fa fa-sort'></i>" + " " + title

                td.appendChild(a);
            }
            else
                td.innerHTML = title;
            tr.appendChild(td);

            // Search
            td = document.createElement("td");
            td.setAttribute("data-th", title);

            if ((contentType == ContentType.data | contentType == ContentType.function) && content != '') {

                search.attr('name', content);

                $(td).append(search);
            }

            trSearch.appendChild(td);
        });

        thead.appendChild(tr);
        tbody.appendChild(trSearch);
    }

    // Create Footer
    {
        tfoot = document.createElement("tfoot");
        tr = document.createElement("tr");
        td = document.createElement("td");

        td.setAttribute("colspan", columns.length);

        tr.appendChild(td);
        tfoot.appendChild(tr);
    }

    table.appendChild(thead);
    table.appendChild(tbody);
    table.appendChild(tfoot);

    $(this).html(table);
    $(this).addClass('content-grid');
    $(this).append(`<div class="overlay"></div>`);

    $(this).PartialViewHandler();
}

$.fn.GridView = function (options) {

    var container = $(this);

    options = options ? options : {};
    var params = options.params ? options.params : {};
    var url = options.url;
    var type = options.type;
    var columns = options.columns;


    if (params["pageSize"] == undefined)
        params["pageSize"] = 5;

    if (params["pageNumber"] == undefined)
        params["pageNumber"] = 1;

    if (params["order"] == undefined)
        params["order"] = '';


    var table, tbody, tr, td;
    // Create Table
    table = container.children("table").get(0);

    if (container.prop("tagName") == 'TABLE')
        table = container.get(0);

    if (table == undefined) {
        container.CreateTable({
            columns: columns
        });

        table = container.children("table").get(0);
    }

    table.setAttribute('data-order', params.order);
    table.setAttribute('disable', 'dasable');

    $(table).find('tbody tr:first-child *[name]').each(function () {
        var param = $(this).attr('name');
        var value = $(this).val();

        if (value.length > 0)
            params[param] = value;
        else if (params[param])
            $(this).val(params[param]);

    });


    if (columns == undefined) {
        columns = $(table).data('columns');
    }
    else {

        for (var i = 0; i < columns.length; i++) {
            if (columns[i]["visible"] == undefined)
                columns[i]["visible"] = true;
        }

        $(table).data('columns', columns);
    }

    if (url == undefined) {
        url = $(table).data('url');
    }
    else {
        $(table).data('url', url);
    }

    if (type == undefined) {
        type = $(table).data('type') ? type : 'POST';
    }
    else {
        $(table).data('type', type ? type : 'POST');
    }

    var title, content, func, fieldType, contentType, event, attribute, element;

    // Create Body
    {
        // Remove Last Rows
        tbody = table.getElementsByTagName("tbody")[0];


        AJAX({
            type: type,
            url: url,
            data: params,
            success: function (data) {

                $(tbody).children("tr:not(:first-child)").remove();

                BindData(data.Data);

                $(table).Paging(data.Paging, columns);
            },
            beforeSend: function () {
                container.find('.overlay').first().show();

            },
            complete: function () {
                container.find('.overlay').first().hide();
                $(table).removeAttr('disable');
                $(table).GridHandler();
                $(table).find('select.page-columns').trigger('change');
            }

        });


        function BindData(data) {

            // Add New Rows
            data.forEach(function (row, i) {
                tr = document.createElement("tr");

                columns.forEach(function (col, j) {

                    fieldType = col.fieldType ? col.fieldType : FieldType.lable;
                    contentType = col.contentType ? col.contentType : ContentType.data;
                    title = col.title ? col.title : '';
                    content = col.key ? col.key : '';
                    func = col.func ? col.func : function (e) { return ''; };
                    attribute = col.attribute ? col.attribute : undefined;
                    event = col.event ? col.event : undefined;

                    td = document.createElement("td");
                    td.setAttribute("data-th", title);

                    element = ElementByFieldType(fieldType);

                    for (key in attribute) {
                        if (attribute.hasOwnProperty(key)) {
                            element.setAttribute(key, key == 'id' ? attribute[key] + "_" + i : attribute[key]);
                        }
                    }

                    for (key in event) {
                        if (event.hasOwnProperty(key)) {
                            $(element).on(key, { row: row }, event[key]);
                            //$(element).on(key, event[key](row));
                        }
                    }


                    switch (contentType) {
                        case ContentType.data:
                            element.innerHTML = GetField(row, content);
                            break;
                        case ContentType.selectRow:
                            element.innerHTML = content;
                            $(element).addClass("selection");
                            break;
                        case ContentType.rowNumber:
                            element.innerHTML = (params.pageNumber - 1) * params.pageSize + i + 1;
                            break;
                        case ContentType.calculate:
                            element.innerHTML = '';
                            break;
                        case ContentType.function:
                            element.innerHTML = func(row);
                            break;
                        default:
                            element.innerHTML = content;
                    }


                    td.appendChild(element);
                    tr.appendChild(td);
                });
                tbody.appendChild(tr);
            });

        }

    }
}

$.fn.GridHandler = function () {
    var table = $(this);

    table.find('.page-size').unbind('change').on('change', function () {

        if (table.attr('disable') != undefined)
            return;


        table.GridView({
            params: {
                pageNumber: 1,
                pageSize: parseInt($(this).val()),
                order: table.attr('data-order')
            }
        });
    });

    table.find('.page-number').unbind('change').on('change', function () {

        if (table.attr('disable') != undefined)
            return;

        table.GridView({
            params: {
                pageNumber: parseInt($(this).val()),
                pageSize: parseInt(table.find('select.page-size').val()),
                order: table.attr('data-order')
            }
        });

    });

    table.find('.page-columns').on('change', function (e) {
        e.stopPropagation();

        if (table.attr('disable') != undefined || $(this).val().length == 0)
            return;

        var values = $(this).val();

        var columns = table.data("columns");

        var el;

        columns.forEach(function (col, i) {
            el = table.find('thead tr th').get(i);

            if ($.inArray(i.toString(), values) > -1) {

                $(el).show();
                columns[i]["visible"] = true;
            }
            else {
                $(el).hide();
                columns[i]["visible"] = false;
            }
        });

        table.data("columns", columns);

        // Body
        table.children('tbody').children('tr').each(function (j, row) {

            columns.forEach(function (col, i) {

                el = $(row).children('td').get(i);

                if (col.visible == false) {
                    $(el).hide();

                }
                else
                    $(el).show();

            });
        });


        table.find('tfoot tr td').first().attr('colspan', values.length);

        $(this).parent().find('.filter-option-inner-inner').text(`${values.length} مورد`);

    });

    table.find('tfoot a').unbind('click').on('click', function () {

        if (table.attr('disable') != undefined)
            return;

        var pageNumber = parseInt($(this).attr('data-th'));

        if (pageNumber != undefined)
            table.GridView({
                params: {
                    pageNumber: pageNumber,
                    pageSize: parseInt(table.find('select.page-size').val()),
                    order: table.attr('data-order')
                }
            });
    });

    table.find("thead tr th a").unbind('click').on("click", function () {

        if (table.attr('disable') != undefined)
            return;

        var preColumnName = $(this).parents('table').attr('data-order').split(' ')[0];
        var preOrderType = $(this).parents('table').attr('data-order').split(' ')[1];
        var newColumnName = $(this).attr("data-th").split(' ')[0];
        var newOrderType = "ascending";

        $(this).parents("thead").find("i").each(function (i) {
            $(this).attr("class", "fa fa-sort");
        });

        $(this).find("i").attr("class", "fa fa-sort-asc");

        if (preColumnName == newColumnName && preOrderType == 'ascending') {
            newOrderType = 'descending';
            $(this).find("i").attr("class", "fa fa-sort-desc");
        }

        table.attr('data-order', newColumnName + ' ' + newOrderType);

        table.GridView({
            params: {
                pageNumber: parseInt(table.find('select.page-number').val()),
                pageSize: parseInt(table.find('select.page-size').val()),
                order: table.attr('data-order')
            }
        });
    });

    table.find("tbody tr td .selection").unbind('click').on("click", function () {

        if (table.attr('disable') != undefined)
            return;

        $(this).parents("tbody").find("tr").removeClass("selected");
        $(this).parents("tr").addClass("selected");
    });

    table.find('tbody tr:first-child').unbind('change').on('change', function (e) {

        if (table.attr('disable') != undefined)
            return;

        //if (event.keyCode === 13) {

        table.GridView({
            params: {
                pageNumber: 1,
                pageSize: parseInt(table.find('select.page-size').val()),
                order: table.attr('data-order')
            }
        });
        //}
    });

    table.children('tbody > tr:first-child select').unbind('change').on('change', function (e) {

        if (table.attr('disable') != undefined)
            return;

        table.GridView({
            params: {
                pageNumber: 1,
                pageSize: parseInt(table.find('.page-size').val()),
                order: table.attr('data-order')
            }
        });

    });
}

$.fn.Paging = function (paging, columns) {

    var pageNumber = paging.pageNumber,
        pageSize = paging.pageSize,
        rowCount = paging.rowCount

    var pageBoxCount = 5;
    var pageCount = Math.ceil(rowCount / pageSize);

    var pageFrom = 1;
    var pageTo = pageCount;
    if (rowCount == 0) {
        pageFrom = 0;
        pageTo = 0;
        pageSize = 0;
        pageNumber = 0;
    }

    var needFirst = false;
    var needNext = (pageNumber == pageCount || rowCount == 0) ? false : true;
    var needBack = (pageNumber == 1 || rowCount == 0) ? false : true;
    var needLast = false;

    if (pageCount > pageBoxCount && rowCount != 0) {
        if (pageNumber <= (Math.ceil(pageBoxCount / 2))) {
            pageFrom = 1;
            pageTo = pageBoxCount;
            needFirst = false;
            needLast = true;
        }
        else if (pageNumber >= pageCount - (Math.floor(pageBoxCount / 2))) {
            pageFrom = pageCount - pageBoxCount + 1;
            pageTo = pageCount;
            needFirst = true;
            needLast = false;
        }
        else {
            pageFrom = pageNumber - (Math.ceil(pageBoxCount / 2)) + 1;
            pageTo = pageNumber + (Math.floor(pageBoxCount / 2));
            needFirst = true;
            needLast = true;
        }

    }


    var ul, li, a, i, div, divParent, span, select, option;
    // Pagination
    divParent = document.createElement("div");
    divParent.setAttribute("class", "row");

    div = document.createElement("div");
    div.setAttribute("class", "col-auto")

    ul = document.createElement("ul");
    ul.setAttribute("class", "pagination pagination-sm"); // justify-content-center

    // First Data
    {
        li = document.createElement("li");
        a = document.createElement("a");
        li.setAttribute("class", "page-item");
        a.innerHTML = "<i class='fa fa-angle-double-right' />";
        a.setAttribute("class", "page-link");

        if (needFirst)
            a.setAttribute("data-th", 1);
        else
            li.setAttribute("class", "page-item disabled");

        li.appendChild(a);
        ul.appendChild(li);
    }

    // Back Data
    {
        li = document.createElement("li");
        a = document.createElement("a");
        li.setAttribute("class", "page-item");
        a.innerHTML = "<i class='fa fa-angle-right' />";
        a.setAttribute("class", "page-link");

        if (needBack)
            a.setAttribute("data-th", pageNumber - 1);
        else
            li.setAttribute("class", "page-item disabled");

        li.appendChild(a);
        ul.appendChild(li);
    }

    // inner Data
    for (var i = pageFrom; i <= pageTo; i++) {
        li = document.createElement("li");
        a = document.createElement("a");

        li.setAttribute("class", "page-item");
        a.setAttribute("class", "page-link");
        a.setAttribute("data-th", i);
        a.append(i);
        if (i == pageNumber)
            li.setAttribute("class", "page-item active");

        li.appendChild(a);
        ul.appendChild(li);
    }

    // Next Data
    {
        li = document.createElement("li");
        a = document.createElement("a");
        li.setAttribute("class", "page-item");
        a.innerHTML = "<i class='fa fa-angle-left' />";
        a.setAttribute("class", "page-link");

        if (needNext)
            a.setAttribute("data-th", pageNumber + 1);
        else
            li.setAttribute("class", "page-item disabled");

        li.appendChild(a);
        ul.appendChild(li);
    }

    // Last Data
    {
        li = document.createElement("li");
        a = document.createElement("a");
        li.setAttribute("class", "page-item");
        a.innerHTML = "<i class='fa fa-angle-double-left' />";
        a.setAttribute("class", "page-link");

        if (needLast)
            a.setAttribute("data-th", pageCount);
        else
            li.setAttribute("class", "page-item disabled");

        li.appendChild(a);
        ul.appendChild(li);
    }

    div.appendChild(ul);
    divParent.appendChild(div);
    ul = undefined;


    // Visible Columns
    {
        div = document.createElement("div");
        div.setAttribute("class", "col-auto pl-0")

        //span = document.createElement("span");
        //span.append("نمایش : ");
        //div.appendChild(span);

        select = document.createElement("select");
        select.setAttribute("class", "page-columns selectpicker");
        select.setAttribute("multiple", "");
        select.setAttribute("data-selected-text-format", "count");
        select.setAttribute("data-size", 10);

        for (var i = 0; i < columns.length; i++) {
            option = document.createElement("option");
            option.setAttribute("value", i);
            option.append(columns[i].title);

            if (columns[i].visible == true)
                option.setAttribute("selected", "selected");

            select.appendChild(option);
        }

        div.appendChild(select);
        divParent.appendChild(div);
    }


    // Record Count
    {
        div = document.createElement("div");
        div.setAttribute("class", "col-auto pl-0")

        span = document.createElement("span");
        span.append("تعداد رکورد : ");
        div.appendChild(span);

        select = document.createElement("select");
        select.setAttribute("class", "page-size selectpicker");
        select.setAttribute("data-size", 10);

        for (var i = 0; i < 5; i++) {
            option = document.createElement("option");
            option.setAttribute("value", 5 * Math.pow(2, i));
            option.append(5 * Math.pow(2, i));

            if (pageSize == 5 * Math.pow(2, i))
                option.setAttribute("selected", "selected");

            select.appendChild(option);
        }

        div.appendChild(select);
        divParent.appendChild(div);
    }

    // Page Number
    {
        div = document.createElement("div");
        div.setAttribute("class", "col-auto pl-0")

        span = document.createElement("span");
        span.append("صفحه : ");
        div.appendChild(span);

        select = document.createElement("select");
        select.setAttribute("class", "page-number selectpicker");
        select.setAttribute("data-size", 10);

        for (var i = 1; i <= pageCount; i++) {
            option = document.createElement("option");
            option.setAttribute("value", i);
            option.append(i);

            if (pageNumber == i)
                option.setAttribute("selected", "selected");

            select.appendChild(option);
        }
        div.appendChild(select);
        select = undefined;
        option = undefined;

        divParent.appendChild(div);
    }

    // Paging Info
    {
        div = document.createElement("div");
        div.setAttribute("class", "col-auto pl-0 pt-2")

        span = document.createElement("span");
        span.append(
            "نمایش" + " " + ((pageNumber * pageSize) - pageSize + 1) + " " +
            "تا" + " " + ((pageNumber == pageCount) ? rowCount : (pageNumber * pageSize)) + " " +
            "از" + " " + rowCount);
        div.appendChild(span);
        divParent.appendChild(div);
    }

    var tfoot = $(this).children("tfoot").get(0);
    var tr = $(tfoot).children("tr").get(0);
    var td = $(tr).children("td").get(0);
    td.innerHTML = "";
    td.appendChild(divParent);
    $(td).PartialViewHandler();
}

function ElementByFieldType(fieldType) {
    var element;

    switch (fieldType) {
        case FieldType.textBox:
            element = document.createElement('input');
            element.setAttribute('type', 'text');
            break;
        case FieldType.button:
            element = document.createElement('button');
            break;
        case FieldType.url:
            element = document.createElement('a');
            break;
        case FieldType.lable:
            element = document.createElement('span');
            break;
        case FieldType.password:
            element = document.createElement('input');
            element.setAttribute('type', 'password');
            break;
        case FieldType.image:
            element = document.createElement('img');
            break;
        case FieldType.dropdown:
            element = document.createElement('select');
            break;
        default:
            element = document.createElement('span');
    }

    return element;
}

function GetField(row, field) {

    var spl, result;

    if (field != undefined) {
        spl = field.split('.');
        result = row[spl[0]];
        for (var i = 1; i < spl.length; i++) {
            if (result == undefined) {
                result = "";
                break;
            }
            else {
                result = result[spl[i]];
            }
        }
    }

    return result;
}



