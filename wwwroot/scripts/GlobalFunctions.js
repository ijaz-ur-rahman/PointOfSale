
function HttpPOST(url, formData, callback) {
    $("#loader").removeClass("fadeOut").addClass("fadeIn");
    $.ajax({
        url: url,
        data: formData,
        type: "POST",
        contentType: false,
        processData: false,
        success: function (response) {
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
            if (typeof callback == 'function') {
                callback(response);
            }
        },
        error: function (ex) {
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
            ohSnap(ex.message, { 'color': 'red', 'duration': '10000' });
        }
    });
}
function HttpGET(url, callback) {
    $("#loader").removeClass("fadeOut").addClass("fadeIn");
    $.ajax({
        url: url,
        type: "GET",
        success: function (response) {
            $("#loader").removeClass("fadeIn").addClass("fadeOut");

            if (typeof callback == 'function') {
                callback(response);
            }
        },
        error: function (ex) {
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
            ohSnap(ex.message, { 'color': 'red', 'duration': '10000' });
        }
    });
}
function HttpDELETE(url, formData, callback) {
    $("#loader").removeClass("fadeOut").addClass("fadeIn");
    $.ajax({
        url: url,
        data: formData,
        type: "DELETE",
        contentType: false,
        processData: false,
        success: function (response) {
            $("#loader").removeClass("fadeIn").addClass("fadeOut");

            if (typeof callback == 'function') {
                callback(response);
            }
        },
        error: function (response) {
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
            ohSnap(ex.message, { 'color': 'red', 'duration': '10000' });
        }
    });
}
//function HttpPUT(url, formData, callback) {
//    $.ajax({
//        url: url,
//        data: formData,
//        type: "PUT",
//        contentType: false,
//        processData: false,
//        success: function (response) {
//            if (response.success) {
//                SuccessMessage(response);
//                if (typeof callback == 'function') {
//                    callback(response);
//                }
//            }
//        },
//        error: function (response) {
//            ErrorMessage(response);
//            if (typeof callback == 'function') {
//                callback(response);
//            }
//        }
//    });
//}
function BindArray(array) {
    $($(".ng-repeat").get().reverse()).each(function (i) {
        var loop_info = $(this).attr("data");
        var fin = loop_info.match(/(.*) in (\d+) to length/);
        var variable = fin[1],
            initial = 1,
            final = array.length;
        var htm = $(this).html(), printed = "";
        for (j = initial; j <= final; j++) {
            var temp = htm;
            var r = new RegExp(variable, "g");
            temp = temp.replace(r, j);
            printed += temp;
        }
        $(this).html(printed);
    });
}