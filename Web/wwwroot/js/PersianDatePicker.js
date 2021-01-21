
var datePicker = function (options, textbox) {

    options = options || {};

    // set options
    this.placeholder = options.placeholder !== undefined ? options.placeholder : "";
    this.swapNextPrev = options.swapNextPrev !== undefined ? options.swapNextPrev : false;
    this.twodigit = options.twodigit !== undefined ? options.twodigit : true;
    this.closeAfterSelect = options.closeAfterSelect !== undefined ? options.closeAfterSelect : true;
    this.forceFarsiDigits = options.forceFarsiDigits !== undefined ? options.forceFarsiDigits : true;
    this.markToday = options.markToday !== undefined ? options.markToday : true;
    this.markHolidays = options.markHolidays !== undefined ? options.markHolidays : true;
    this.highlightSelectedDay = options.highlightSelectedDay !== undefined ? options.highlightSelectedDay : true;
    this.sync = options.sync !== undefined ? options.sync : false;
    this.gotoToday = options.gotoToday !== undefined ? options.gotoToday : false;
    this.pastYearsCount = !isNaN(options.pastYearsCount) ? options.pastYearsCount : 95;
    this.futureYearsCount = !isNaN(options.futureYearsCount) ? options.futureYearsCount : 10;
    this.position = !isNaN(options.position) ? options.position : '';
    this.isCalClicked = !isNaN(options.isCalClicked) ? options.isCalClicked : false;
    this.isSynced = !isNaN(options.isSynced) ? options.isSynced : false;
    this.txtMiladiDate = textbox;
    this.txtJalaliDate = document.createElement("input");
    this.container;

};

datePicker.prototype.init = function () {

    var obj = this;

    $(obj.txtMiladiDate).attr("type", "hidden");
    var orgDate = Date.parse($(obj.txtMiladiDate).val());

    $(obj.txtJalaliDate).attr("type", "text");
    $(obj.txtJalaliDate).attr("class", $(obj.txtMiladiDate).attr("class"));
    $(obj.txtMiladiDate).after(obj.txtJalaliDate);
    $(obj.txtMiladiDate).removeClass();
    $(obj.txtJalaliDate).val(MiladiToJalali(orgDate));

    if (obj.placeholder.length > 0) {
        $(obj.txtJalaliDate).attr("placeholder", obj.placeholder);
    }

    // create main div for calendar, below input element
    $(obj.txtJalaliDate).after("<div class='bd-main collapse'></div>");

    obj.container = $(obj.txtJalaliDate).next('.bd-main');

    // create calendar div inside main div
    obj.container.append("<div class='bd-calendar'></div>");

    // create title div and table inside calendar div
    obj.container.find('.bd-calendar').append("<div class='bd-title'></div>");
    var titleDiv = obj.container.find('.bd-title');
    obj.container.find('.bd-calendar').append("<table class='bd-table' cellspacing='0' cellpadding='0'></table>");

    // create month and year drop downs and next/prev month buttons inside title div
    if (obj.swapNextPrev)
        titleDiv.append("<button type='button' class='bd-prev' title='ماه قبلی' data-toggle='tooltip'><i class='fa fa-2x fa-arrow-circle-left' /></button>");
    else
        titleDiv.append("<button type='button' class='bd-next' title='ماه بعدی' data-toggle='tooltip'><i class='fa fa-2x fa-arrow-circle-right' /></button>");

    titleDiv.append("<div class='bd-dropdown'></div><div class='bd-dropdown'></div>");
    titleDiv.find('.bd-dropdown:nth-child(2)').append("<select class='bd-month'></select>");
    titleDiv.find('.bd-dropdown:nth-child(3)').append("<select class='bd-year'></select>");

    if (obj.swapNextPrev)
        titleDiv.append("<button type='button' class='bd-next' title='ماه بعدی' data-toggle='tooltip'><i class='fa fa-2x fa-arrow-circle-right' /></button>");
    else
        titleDiv.append("<button type='button' class='bd-prev' title='ماه قبلی' data-toggle='tooltip'><i class='fa fa-2x fa-arrow-circle-left' /></button>");

    $.each(MONTH_NAMES, function (key, value) {
        obj.container.find(".bd-month").append($("<option></option>").attr("value", key).text(value));
    });

    // create table header and body
    obj.container.find('.bd-table').append("<thead><tr></tr></thead>");
    $.each(DAY_NAMES, function (key, value) {
        obj.container.find('.bd-table thead tr').append($("<th></th>").text(value));
    });

    obj.container.find('.bd-table').append("<tbody class='bd-table-days'></tbody>");

    // create go to todays button
    if (obj.gotoToday) {
        obj.container.find('.bd-calendar').append("<div class='bd-goto-today'>برو به امروز</div>");
    }


    // make first page of calendar
    var g = new Date();
    var j = toJalali(g.getFullYear(), g.getMonth() + 1, g.getDate());

    {
        obj.container.find(".bd-year").find('option').remove();

        for (let i = 0; i < obj.pastYearsCount + obj.futureYearsCount; i++) {
            var tempYear = ((parseInt(j.jy) - obj.pastYearsCount) + i) + '';
            if (obj.forceFarsiDigits) {
                for (var k = 0; k < 10; k++) {
                    var rgx = new RegExp(k, 'g');
                    tempYear = tempYear.replace(rgx, FA_NUMS[k]);
                }
            }
            obj.container.find(".bd-year").append($('<option>', {
                value: (parseInt(j.jy) - obj.pastYearsCount) + i,
                text: tempYear
            }));
        }

    }


    obj.container.find(".bd-month").val(j.jm);
    obj.container.find(".bd-year").val(j.jy);


}

datePicker.prototype.draw = function () {

    g = new Date();
    j = toJalali(g.getFullYear(), g.getMonth() + 1, g.getDate());


    var year = this.container.find('.bd-year').val();
    var month = this.container.find('.bd-month').val();
    var daysCount = monthDays(year, month);
    var firstDayOfMonth = GetFirstDayOfMonth(year, month);

    this.container.find(".bd-table-days").empty();

    var dayIndex = 1;
    var rowIndex = 1;



    while (dayIndex <= daysCount) {

        this.container.find(".bd-table-days").append($('<tr>', {
            class: "tr-" + rowIndex
        }));

        for (let i = 0; i < 7; i++) {

            var button = $('<button></button>');
            var holiday = isHohiday(year, month, dayIndex);

            if (dayIndex == 1) {
                var j = 0;
                while (j < firstDayOfMonth) {
                    $(".bd-table-days .tr-1").append($('<td>', {
                        class: "bd-empty-cell"
                    })
                    );
                    j++;
                    i++;
                }
            }
            if (i < 7 && dayIndex <= daysCount) {
                button.addClass(`day day-${dayIndex}`);
                button.attr('type', 'button');

                if (holiday.result) {
                    button.attr('data-toggle', 'tooltip');
                    button.attr('data-placement', 'bottom');
                    button.attr('title', holiday.message);
                }

                button.text(this.forceFarsiDigits ? FA_NUMS[dayIndex] : dayIndex);

                // mark todays day by adding .bd-today class
                if (this.markToday) {
                    if (dayIndex == j.jd && j.jm == month && j.jy == year) {
                        button.addClass('bd-today');
                    }
                }

                // mark holidays by adding .bd-holiday class
                if (this.markHolidays) {
                    if (i == 6 || holiday.result) {
                        button.addClass('bd-holiday');
                    }
                }

                var td = $('<td></td>');

                td.append(button);

                this.container.find(".bd-table-days .tr-" + rowIndex).append(td);

                dayIndex++;
            }
        }
        rowIndex++;
    }

    if (this.highlightSelectedDay) {

        var value = this.container.before().val().split("/");

        if (value[0] == year && value[1] == month) {
            this.container.find(".bd-selected-day").removeClass("bd-selected-day");
            this.container.find(".day-" + parseInt(value[2])).addClass("bd-selected-day");
        }
    }

    this.container.find('[data-toggle="tooltip"]').tooltip();
}

datePicker.prototype.handler = function () {

    var obj = this;

    obj.container.prev('input').on("focus", function () {
        obj.container.removeClass("collapse");
        if (obj.sync && obj.isSynced === false) {
            obj.syncCalendar();
            obj.isSynced = true;
        }
        obj.setCalendarPosition();
    }).on('blur', function () {
        if (obj.isCalClicked == false) {
            obj.container.addClass("collapse");
            obj.isSynced = false;
        } else {
            obj.isCalClicked = false;
            $(this).focus();
            event.preventDefault();
        }
    });

    obj.container.prev('input').on("change", function () {
        $(obj.txtMiladiDate).val(JalaliToMiladi($(obj.txtJalaliDate).val()));
    });

    obj.container.on('mousedown', function (e) {
        obj.isCalClicked = true;
    });

    obj.container.find(".bd-month , .bd-year").on('change', function (e) {
        obj.draw();
        obj.setCalendarPosition();
    });

    obj.container.on("click", "button.day", function (e) {

        var month = obj.container.find(".bd-month").val();
        var year = obj.container.find(".bd-year").val();
        var day = $(this).attr('class').split(" ")[$(this).attr('class').split(" ").indexOf('day') + 1].split("-")[1];

        var input = obj.container.prev("input");

        var datestr = year + "/" + month + "/" + day;

        if (obj.twodigit) {
            datestr = fixDate(datestr);
        }

        input.val(datestr);
        input.trigger("change");

        if (obj.closeAfterSelect) {
            obj.isCalClicked = false;
            input.trigger("blur");
        }

        if (obj.highlightSelectedDay) {
            obj.container.find(".bd-selected-day").removeClass("bd-selected-day");
            $(this).addClass("bd-selected-day");
        }
    });

    obj.container.on("click", ".bd-next", function (e) {

        var ddlMonth = obj.container.find(".bd-month");
        var ddlYear = obj.container.find(".bd-year");

        if (ddlMonth.val() < 12) {
            ddlMonth.val(parseInt(ddlMonth.val()) + 1);
        } else if (ddlYear.val() != ddlYear[0].options[ddlYear[0].length - 1].value) {
            ddlMonth.val(1);
            ddlYear.val(parseInt(ddlYear.val()) + 1);
        }

        obj.draw();
        obj.setCalendarPosition();
    });

    obj.container.on("click", ".bd-prev", function (e) {

        var ddlMonth = obj.container.find(".bd-month");
        var ddlYear = obj.container.find(".bd-year");

        if (ddlMonth.val() > 1) {
            ddlMonth.val(parseInt(ddlMonth.val()) - 1);
        } else if (ddlYear.val() != ddlYear[0].options[0].value) {
            ddlMonth.val(12);
            ddlYear.val(parseInt(ddlYear.val()) - 1);
        }

        obj.draw();
        obj.setCalendarPosition();
    });

    obj.container.on("click", ".bd-goto-today", function (e) {

        var g = new Date();
        var j = toJalali(g.getFullYear(), g.getMonth() + 1, g.getDate());

        obj.container.find(".bd-month").val(j.jm);
        obj.container.find(".bd-year").val(j.jy);

        obj.draw();
        obj.setCalendarPosition();
    });
}

datePicker.prototype.setCalendarPosition = function () {

    var obj = this;
    let calendarContainer = obj.container.get(0);
    let input = obj.txtJalaliDate;
    
    input.offsetHeight; // input height
    calendarContainer.offsetHeight; // calendar height;

    if (obj.position === 'top') {
        calendarContainer.style.top = `${-1 * calendarContainer.offsetHeight}px`; // top
    }
    else if (obj.position === 'auto') {
        // find parent element
        let parentElement = document.querySelector(`body`);


        let elementsDistance = getDistanceBetweenElements(
            parentElement
            , input
        );

        if ((parentElement.offsetHeight - elementsDistance) - (input.offsetHeight + calendarContainer.offsetHeight) > 0)
            calendarContainer.style.top = `${input.offsetHeight}px`; // bottom
        else if (elementsDistance - (input.offsetHeight + calendarContainer.offsetHeight) > 0)
            calendarContainer.style.top = `${-1 * calendarContainer.offsetHeight}px`; // top
        else
            calendarContainer.style.top = `${input.offsetHeight}px`; // bottom
    }
    else {
        // bottom or any other values
        calendarContainer.style.top = `${input.offsetHeight}px`; // bottom
    }

    let isOut = isOutOfViewport(calendarContainer);
    if (isOut.left)
        calendarContainer.style.left = 0;

    function getPositionAtCenter(element) {
        const { top, left } = element.getBoundingClientRect();
        return {
            x: left,
            y: top
        };
    }
    function getDistanceBetweenElements(a, b) {
        const aPosition = getPositionAtCenter(a);
        const bPosition = getPositionAtCenter(b);

        return Math.abs(aPosition.y - bPosition.y);
    }
    function isOutOfViewport(elem) {
        // Get element's bounding
        var bounding = elem.getBoundingClientRect();

        // Check if it's out of the viewport on each side
        var out = {};
        out.top = bounding.top < 0;
        out.left = bounding.left < 0;
        out.bottom = bounding.bottom > (window.innerHeight || document.documentElement.clientHeight);
        out.right = bounding.right > (window.innerWidth || document.documentElement.clientWidth);
        out.any = out.top || out.left || out.bottom || out.right;
        out.all = out.top && out.left && out.bottom && out.right;

        return out;
    };
}

datePicker.prototype.syncCalendar = function () {
    var ddlYear = this.container.find(".bd-year");
    var ddlMonth = this.container.find(".bd-month");

    var inputValue = fixDate($(this.txtJalaliDate).val());
    if (inputValue === "")
        return;

    inputValue = inputValue.split("/");
    ddlMonth.val(parseInt(inputValue[1]));
    ddlYear.val(parseInt(inputValue[0]));
    ddlYear.trigger("change");

    if (this.highlightSelectedDay) {
        this.container.find(".bd-selected-day").removeClass("bd-selected-day");
        this.container.find(".day-" + parseInt(inputValue[2])).addClass("bd-selected-day");
    }

}

datePicker.prototype.getSelectPosition = function () {
    var obj = this,
        $window = $(window),
        pos = obj.container.offset(),
        $container = obj.position,
        containerPos;

    if (obj.options.container && $container.length && !$container.is('body')) {
        containerPos = $container.offset();
        containerPos.top += parseInt($container.css('borderTopWidth'));
        containerPos.left += parseInt($container.css('borderLeftWidth'));
    } else {
        containerPos = { top: 0, left: 0 };
    }

    var winPad = obj.options.windowPadding;

    this.sizeInfo.selectOffsetTop = pos.top - containerPos.top - $window.scrollTop();
    this.sizeInfo.selectOffsetBot = $window.height() - this.sizeInfo.selectOffsetTop - this.sizeInfo.selectHeight - containerPos.top - winPad[2];
    this.sizeInfo.selectOffsetLeft = pos.left - containerPos.left - $window.scrollLeft();
    this.sizeInfo.selectOffsetRight = $window.width() - this.sizeInfo.selectOffsetLeft - this.sizeInfo.selectWidth - containerPos.left - winPad[1];
    this.sizeInfo.selectOffsetTop -= winPad[0];
    this.sizeInfo.selectOffsetLeft -= winPad[3];
}


// DatePicker Methods

function fixDate(date) {
    if (date === "")
        return "";

    date = date.split("/");


    if (date[1].length < 2) {
        if (date[1] < 10) {
            date[1] = "0" + date[1];
        }
    }
    if (date[2].length < 2) {
        if (date[2] < 10) {
            date[2] = "0" + date[2];
        }
    }
    date = date.join("/");
    return date;
}

function convertToJWeek(dayOfWeekG) {
    var dayOfWeekJ;
    if (dayOfWeekG < 6) {
        dayOfWeekJ = dayOfWeekG + 1;
    } else {
        dayOfWeekJ = 0;
    }
    return dayOfWeekJ;
}

function isLeapYear(year) {
    // isleap calculator, supported year: 1243 - 1473
    var mod;
    if (year > 1243 && year < 1473) {
        mod = year % 33;
        if (mod == 1 || mod == 5 || mod == 9 || mod == 13 || mod == 17 || mod == 22 || mod == 26 || mod == 30) {
            return true;
        } else {
            return false;
        }
    } else {
        return "unknown";
    }
}

function isHohiday(year, month, day) {

    if (Holidays[year] === undefined)
        return { result: false, message: '' };

    if (Holidays[year][month] === undefined)
        return { result: false, message: '' };

    if (Holidays[year][month][day] === undefined)
        return { result: false, message: '' };


    return { result: true, message: Holidays[year][month][day] };
}

function monthDays(year, month) {
    if (month < 7) {
        return 31;
    } else if (month < 12) {
        return 30;
    } else {
        if (isLeapYear(year)) {
            return 30;
        } else {
            return 29;
        }
    }
}

function GetFirstDayOfMonth(year, month) {

    var g = new Date(JalaliToMiladi(year + "/" + month + "/" + 1));

    return convertToJWeek(g.getDay());
}

// Convert Jalai & MiLadi To Each Other

function toJalali(gy, gm, gd) {
    return d2j(g2d(gy, gm, gd))
}

function toMiladi(jy, jm, jd) {
    return d2g(j2d(jy, jm, jd))
}

function isValidJalaliDate(jy, jm, jd) {
    return jy >= -61 && 3177 >= jy && jm >= 1 && 12 >= jm && jd >= 1 && jd <= jalaliMonthLength(jy, jm)
}

function isLeapJalaliYear(jy) {
    return 0 === jalCal(jy).leap;
}

function jalaliMonthLength(jy, jm) {
    return 6 >= jm ? 31 : 11 >= jm ? 30 : isLeapJalaliYear(jy) ? 30 : 29;
}

function jalCal(jy) {
    var i, a, n, r, t, o, v,
        e = [-61, 9, 38, 199, 426, 686, 756, 818, 1111, 1181, 1210, 1635, 2060, 2097, 2192, 2262, 2324, 2394, 2456, 3178],
        l = e.length,
        u = jy + 621,
        m = -14,
        g = e[0];

    //if (g > jy || jy >= e[l - 1])
    //    throw new Error("Invalid Jalali year " + jy);

    for (v = 1; l > v && (i = e[v], a = i - g, !(i > jy)); v += 1) m = m + 8 * div(a, 33) + div(mod(a, 33), 4), g = i;

    return o = jy - g,
        m = m + 8 * div(o, 33) + div(mod(o, 33) + 3, 4), 4 === mod(a, 33) && a - o === 4 && (m += 1),
        r = div(u, 4) - div(3 * (div(u, 100) + 1), 4) - 150,
        t = 20 + m - r, 6 > a - o && (o = o - a + 33 * div(a + 4, 33)),
        n = mod(mod(o + 1, 33) - 1, 4), -1 === n && (n = 4),
        { leap: n, gy: u, march: t };
}

function j2d(jy, jm, jd) {
    var n = jalCal(jy);
    return g2d(n.gy, 3, n.march) + 31 * (jm - 1) - div(jm, 7) * (jm - 7) + jd - 1
}

function d2j(d) {
    var i, a, n, r = d2g(d).gy, t = r - 621, o = jalCal(t), v = g2d(r, 3, o.march);

    if (n = d - v, n >= 0) {
        if (185 >= n)
            return a = 1 + div(n, 31), i = mod(n, 31) + 1, { jy: t, jm: a, jd: i }; n -= 186
    }
    else
        t -= 1, n += 179, 1 === o.leap && (n += 1);

    return a = 7 + div(n, 30), i = mod(n, 30) + 1, { jy: t, jm: a, jd: i }
}

function g2d(gy, gm, gd) {
    var n = div(1461 * (gy + div(gm - 8, 6) + 100100), 4) + div(153 * mod(gm + 9, 12) + 2, 5) + gd - 34840408;

    return n = n - div(3 * div(gy + 100100 + div(gm - 8, 6), 100), 4) + 752
}

function d2g(d) {
    var i, a, n, r, t;

    return i = 4 * d + 139361631, i = i + 4 * div(3 * div(4 * d + 183187720, 146097), 4) - 3908,
        a = 5 * div(mod(i, 1461), 4) + 308,
        n = div(mod(a, 153), 5) + 1,
        r = mod(div(a, 153), 12) + 1,
        t = div(i, 1461) - 100100 + div(8 - r, 6),
        { gy: t, gm: r, gd: n };
}

function div(d, i) {
    return ~~(d / i)
}

function mod(d, i) {
    return d - ~~(d / i) * i
}


function MiladiToJalali(_date, withTime) {

    _date = new Date(_date);

    var gy = _date.getFullYear();
    var gm = _date.getMonth() + 1;
    var gd = _date.getDate();

    var result = '';

    if (!(gy == 1970 && gm == 1 && gd == 1)) {

        var j = toJalali(gy, gm, gd);
        result = `${j.jy}/${("0" + j.jm).slice(-2)}/${("0" + j.jd).slice(-2)}`;

        if (withTime == true) {
            result = `${("0" + _date.getHours()).slice(-2)}:${("0" + _date.getMinutes()).slice(-2)}  ` + result;
        }

        if (!isValidJalaliDate(j.jy, j.jm, j.jd)) {
            result = '';
        }
    }

    return result;
}

function JalaliToMiladi(_date) {

    var jy = _date.split('/')[0];
    var jm = _date.split('/')[1];
    var jd = _date.split('/')[2];

    var result = '';
    if (isValidJalaliDate(jy, jm, jd)) {
        var g = toMiladi(parseInt(jy), parseInt(jm), parseInt(jd));
        result = g.gy + "/" + g.gm + "/" + g.gd;
    }
    return result;
}


const FA_NUMS = ['٠', '١', '٢', '٣', '۴', '۵', '۶', '٧', '٨', '٩', '١٠', '١١', '١٢', '١٣', '١۴', '١۵', '١۶', '١٧', '١٨', '١٩', '٢٠', '٢١', '٢٢', '٢٣', '٢۴', '٢۵', '٢۶', '٢٧', '٢٨', '٢٩', '٣٠', '٣١', '٣٢'];
const MONTH_NAMES = {
    1: "فروردین",
    2: "اردیبهشت",
    3: "خرداد",
    4: "تیر",
    5: "مرداد",
    6: "شهریور",
    7: "مهر",
    8: "آبان",
    9: "آذر",
    10: "دی",
    11: "بهمن",
    12: "اسفند"
}
const DAY_NAMES = {
    "شنبه": "ش"
    , "یکشنبه": "ی"
    , "دوشنبه": "د"
    , "سه شنبه": "س"
    , "چهارشنبه": "چ"
    , "پنج شنبه": "پ"
    , "جمعه": "ج"
}
const Holidays = {
    1399: {
        1: {
            1: "عید نوروز",
            2: "عید نوروز",
            3: "عید نوروز، مبعث رسول اکرم(ص)",
            4: "عید نوروز",
            12: "روز جمهوری اسلامی ایران",
            13: "روز طبیعت",
            21: "ولادت حضرت قائم (عج)"
        },
        2: {
            26: "شهادت حضرت امام علی (ع)"
        },
        3: {
            4: "عید سعید فطر",
            5: "عید سعید فطر",
            14: " رحلت حضرت امام خمینی (ره)",
            15: "قیام خونین 15 خرداد",
            28: "شهادت حضرت امام جعفر صادق (ع)"
        },
        4: {},
        5: {
            10: "عید سعید قربان",
            18: "عید سعید غدیر خم"
        },
        6: {
            8: "تاسوعای حسینی",
            9: "عاشورای حسینی"
        },
        7: {
            17: "اربعین حسینی",
            25: "رحلت حضرت رسول اکرم (ص)",
            26: "شهادت حضرت امام رضا (ع)"
        },
        8: {
            4: "شهادت حضرت امام حسن عسکری (ع)",
            13: "ولادت حضرت رسول اکرم (ص)"
        },
        9: {},
        10: {
            28: "شهادت حضرت فاطمه زهرا (س)"
        },
        11: {
            22: "پیروزی انقلاب اسلامی ایران"
        },
        12: {
            7: "ولادت حضرت امام علی (ع)",
            21: "مبعث حضرت رسول اکرم (ص)",
            29: "روز ملی شدن صنعت نفت"
        }
    }
}



$.fn.PersianDatePicker = function (options) {

    var textbox = $(this).get(0);


    var obj = new datePicker(options, textbox);

    obj.init();

    obj.draw();
    obj.setCalendarPosition()

    obj.handler();



}





