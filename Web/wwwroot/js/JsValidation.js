$.validator.addMethod('iranianNationalCode', function (value, element, params) {
    //var genre = $(params[0]).val(), year = params[1], date = new Date(value);

    var allDigitEqual = [
        "0000000000", "1111111111", "2222222222", "3333333333", "4444444444",
        "5555555555", "6666666666", "7777777777", "8888888888", "9999999999", "0123456789"
    ];

    if (value == undefined || value == '')
        return true;

    try {
        var a = parseInt(value.charAt(9));
        var b =
            parseInt(value.charAt(0)) * 10 +
            parseInt(value.charAt(1)) * 9 +
            parseInt(value.charAt(2)) * 8 +
            parseInt(value.charAt(3)) * 7 +
            parseInt(value.charAt(4)) * 6 +
            parseInt(value.charAt(5)) * 5 +
            parseInt(value.charAt(6)) * 4 +
            parseInt(value.charAt(7)) * 3 +
            parseInt(value.charAt(8)) * 2;

        b %= 11;
        b -= (b >= 2) ? 11 : 0;

        if ($.inArray(value, allDigitEqual) == -1 && a == Math.abs(b))
            return true;
        else
            return false;

    }
    catch (err) {
        return false;
    }
});

$.validator.unobtrusive.adapters.add('iranianNationalCode', function (options) {
    $(options.form).find('*[data-val-iraniannationalcode]').each(function () {
        options.rules['iranianNationalCode'] = [$(this)];
    });

    options.messages['iranianNationalCode'] = options.message;
});

