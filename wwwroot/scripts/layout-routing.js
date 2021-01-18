var Placeholder;
var title;

$(function () {
    Placeholder = $("#Placeholder"); /// render partial views.
    title = $("title"); // render titles.
});
var routingApp = $.sammy("#Placeholder", function () {
    this.get("#", function (context) {
        title.html("Dashboard");
        $.get("/Home/Dashboard", function (data) {
            context.$element().html(data);
        });
    });
    this.get("#/Home/Dashboard", function (context) {
        title.html("Dashboard");
        $.get("/Home/Dashboard", function (data) {
            context.$element().html(data);
        });
    });
    this.get("#/Categories/Index", function (context) {
        title.html("Categories");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Categories/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Categories/Create", function (context) {
        title.html("Create");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Categories/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Categories/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        debugger;
        let id = this.params['id'];
        $.get("/Categories/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
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

