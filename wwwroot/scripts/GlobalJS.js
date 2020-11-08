function SuccessMessage(data) {
    $("html, body").animate({ scrollTop: 0 }, "medium");
    $("#divSuccess .message").html(data.message);
    $("#divSuccess").show().delay(2000).fadeOut("medium");
}
function ErrorMessage(data) {
    $("html, body").animate({ scrollTop: 0 }, "medium");
    $("#divError .message").html(data.message);
    $("#divError").show().delay(2000).fadeOut("medium");
}

function HttpPost(url, formData, callback) {
    $.ajax({
        url: url,
        data: formData,
        type: "POST",
        contentType: false,
        processData: false,
        success: function (response) {
            //$("#BigLoader").modal('hide');
            if (response.success) {
                SuccessMessage(response);
                if (typeof callback == 'function') {
                    callback(response);
                }
            }
            //else {
            //    ErrorMessage(response);
            //}

            //return response;
        },
        error: function (response) {
            ErrorMessage(response);
            if (typeof callback == 'function') {
                callback(response);
            }
        }
    });
}
function HttpGet(url, callback) {
    $.ajax({
        url: url,
        type: "GET",
        success: function (response) {
            if (response.success) {
                SuccessMessage(response);
                if (typeof callback == 'function') {
                    callback(response);
                }
            }
        },
        error: function (response) {
            ErrorMessage(response);
            if (typeof callback == 'function') {
                callback(response);
            }
        }
    });
}
function HttpPut(url, formData, callback) {
    $.ajax({
        url: url,
        data: formData,
        type: "PUT",
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.success) {
                SuccessMessage(response);
                if (typeof callback == 'function') {
                    callback(response);
                }
            }
        },
        error: function (response) {
            ErrorMessage(response);
            if (typeof callback == 'function') {
                callback(response);
            }
        }
    });
}
function HttpDelete(url, formData, callback) {
    $.ajax({
        url: url,
        data: formData,
        type: "DELETE",
        contentType: false,
        processData: false,
        success: function (response) {
            if (response.success) {
                SuccessMessage(response);
                if (typeof callback == 'function') {
                    callback(response);
                }
            }
        },
        error: function (response) {
            ErrorMessage(response);
            if (typeof callback == 'function') {
                callback(response);
            }
        }
    });
}
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