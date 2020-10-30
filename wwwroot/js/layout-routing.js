var Placeholder;
var title;

$(function () {
    Placeholder = $("#Placeholder"); /// render partial views.
    title = $("title"); // render titles.
});
var routingApp = $.sammy("#Placeholder", function () {
    this.get("#/Home/Dashboard", function (context) {
        title.html("Dashboard");
        $.get("/Home/Dashboard", function (data) {
            context.$element().html(data);
        });
    });   
    this.get("#/Categories/Index", function (context) {
        title.html("Categories");
        $.get("/Categories/Index", function (data) {
            context.$element().html(data);
        });
    });
    this.get("#/Categories/Create", function (context) {
        title.html("Create");
        $.get("/Categories/Create", function (data) {
            context.$element().html(data);
        });
    });
       
    this.get("#/Items/Index", function (context) {
        title.html("Items");
        $.get("/Items/Index", function (data) {
            context.$element().html(data);
        });
    });
    this.get("#/Items/Create", function (context) {
        title.html("Create");
        $.get("/Items/Create", function (data) {
            context.$element().html(data);
        });
    });
    
    this.get("#/Users/Index", function (context) {
        title.html("Users");
        $("#loader").css('visibility', 'visible');
        $.get("/Users/Index", function (data) {
            context.$element().html(data);
            $("#loader").css('visibility', 'hidden');

        });
    });
    this.get("#/Users/Create", function (context) {
        title.html("Create");
        $.get("/Users/Create", function (data) {
            context.$element().html(data);
        });
    });

   
   
});

$(function () {
    routingApp.run("#/Home/Dashboard"); // default routing page.
});






function IfLinkNotExist(type, path) {
    if (!(type != null && path != null))
        return false;

    var isExist = true;

    if (type.toLowerCase() == "get") {
        if (routingApp.routes.get != undefined) {
            $.map(routingApp.routes.get, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    } else if (type.toLowerCase() == "post") {
        if (routingApp.routes.post != undefined) {
            $.map(routingApp.routes.post, function (item) {
                if (item.path.toString().replace("/#", "#").replace(/\\/g, '').replace("$/", "").indexOf(path) >= 0) {
                    isExist = false;
                }
            });
        }
    }
    return isExist;
}

function SuccessMessage(data) {
    $("html, body").animate({ scrollTop: 0 }, "medium");
    $("#divSuccess .message").html(data);
    $("#divSuccess").show().delay(2000).fadeOut("medium");
}
function ErrorMessage(data) {
    $("html, body").animate({ scrollTop: 0 }, "medium");
    $("#divError .message").html(data);
    $("#divError").show().delay(2000).fadeOut("medium");
}