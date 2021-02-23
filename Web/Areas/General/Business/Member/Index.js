$(function () {

    Load_Member();

    if (HasPermission('Member', '_Create')) {
        $('#btnAdd').on('click', function () {
            Popup('ثبت کاربر جدید', 'Get', '../Member/_Create', {}, Load_Member, 'lg');            
        });

        $('#btnAdd').parent().ResetForm();
    }
    else {
        $('#btnAdd').remove();
    }
  
});


function Load_Member() {

    var ddlGender = $('<select></select>');
    ddlGender.addClass('form-control selectpicker');
    ddlGender.css('min-width', '50px');
    ddlGender.append(`<option>همه</option>`);
    ddlGender.append(`<option value="true">آقا</option>`);
    ddlGender.append(`<option value="false">خانم</option>`);

    var datepicker = $('<input type="text"></input>');
    datepicker.addClass('form-control datepicker');




    var columns = [
        {
            title: '',
            contentType: ContentType.selectRow,
            attribute: {
                class: 'fa fa-2x fa-caret-left',
                style: 'color:blue;cursor: pointer;'
            }
        },
        {
            title: 'ردیف',
            contentType: ContentType.rowNumber
        },
        {
            title: "نام",
            key: "Person.FirstName"
        },
        {
            title: "نام خانوادگی",
            key: "Person.LastName"
        },
        {
            title: "کد ملی",
            key: "Person.NationalCode"
        },
        {
            title: "جنسیت",
            contentType: ContentType.function,
            key: "Person.Gender",
            func: function (e) {
                if (e.Person.Gender == true)
                    return 'آقا';
                else if (e.Person.Gender == false)
                    return 'خانم';
                else
                    return '';
            },
            search: ddlGender
        },
        {
            title: "تاریخ تولد",
            contentType: ContentType.function,
            key: "Person.Birthday",
            func: function (e) {
                return MiladiToJalali(e.Person.Birthday);
            },
            search: datepicker
        },
        {
            title: "شماره تلفن",
            key: "Person.PhoneNumber",
        },
        {
            title: "شماره همراه",
            key: "Person.MobileNumber",
        },
        {
            title: "پست اکترونیکی",
            key: "Person.Email",
        },
        {
            contentType: ContentType.text,
            title: 'ویرایش',
            event: {
                click: function (e) {
                    Update_Member(e.data.row.Person.Id);
                }
            },
            attribute: {
                class: 'fa fa-2x fa-edit',
                style: 'color:blue;cursor: pointer;'
            },
            visible: HasPermission('Member', '_Update')
        },
        {
            contentType: ContentType.text,
            title: 'حذف',
            event: {
                click: function (e) {
                    MvcAlert(function () { Delete_Member(e.data.row.Person.Id) });
                }
            },
            attribute: {
                class: 'fa fa-2x fa-trash',
                style: 'color:red;cursor: pointer;'
            },
            visible: HasPermission('Member', '_Delete')
        }
    ];

    if (HasPermission('Member', '_List')) {
        $("#frm-grid").GridView({
            url: '../Member/_List',
            columns: columns
        });
    }

}

function Select_Member(id) {
    alert(id);
}

function Delete_Member(id) {
    
    AJAX({
        type: 'Post',
        url: '../Member/_Delete',
        data: { id: id },
        success: function (data, status, xhr) {

            Messages(data.type, data.message);
            $("#frm-grid").GridView(data.Paging);
        }
    });
}

function Update_Member(id) {

    Popup('ویرایش کاربر', 'Post', '../Member/_Update', { id: id }, Load_Member, 'lg');
}