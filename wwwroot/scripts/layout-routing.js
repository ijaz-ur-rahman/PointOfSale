var Placeholder;
var title;
var heading;

$(function () {
    Placeholder = $("#Placeholder"); /// render partial views.
    title = $("title"); // render titles.
    heading = $("#main_heading"); // render heading.
});
var routingApp = $.sammy("#Placeholder", function () {
    this.get("#", function (context) {
        title.html("Dashboard");
        heading.html("Dashboard");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Home/Dashboard", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Home/Dashboard", function (context) {
        title.html("Dashboard");
        heading.html("Dashboard");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Home/Dashboard", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Categories/Index", function (context) {
        title.html("Categories");
        heading.html("Categories List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Categories/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Categories/Create", function (context) {
        title.html("Create");
        heading.html("Create Category");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Categories/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Categories/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        //debugger;
        let id = this.params['id'];
        $.get("/Categories/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });

    this.get("#/Items/Index", function (context) {
        title.html("Items");
        heading.html("Items List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Items/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Items/Create", function (context) {
        title.html("Create");
        heading.html("Create Item");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Items/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Items/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        debugger;
        let id = this.params['id'];
        $.get("/Items/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Items/Delete", function (context) {
        title.html("Delete");
        heading.html("Delete Item");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Items/Delete", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });

    this.get("#/Users/Index", function (context) {
        title.html("Users");
        heading.html("Users List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Users/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Users/Create", function (context) {
        title.html("Create");
        heading.html("Create User");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Users/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });



});

$(function () {
    routingApp.run("#/Home/Dashboard"); // default routing page.
});





// routing code
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

