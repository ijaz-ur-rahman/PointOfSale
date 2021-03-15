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
        let id = this.params['id'];
        $.get("/Items/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    
    this.get("#/Customers/Index", function (context) {
        title.html("Items");
        heading.html("Customer List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Customers/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Customers/Create", function (context) {
        title.html("Create");
        heading.html("Create Customer");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Customers/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Customers/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        let id = this.params['id'];
        $.get("/Customers/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Suppliers/Index", function (context) {
        title.html("Items");
        heading.html("Supplier List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Suppliers/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Suppliers/Create", function (context) {
        title.html("Create");
        heading.html("Create Suppliers");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Suppliers/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Suppliers/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        let id = this.params['id'];
        $.get("/Suppliers/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/UOM/Index", function (context) {
        title.html("Unit Of Measurement");
        heading.html("Unit Of Measurement List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/UOM/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/UOM/Create", function (context) {
        title.html("Create");
        heading.html("Create Unit Of Measurement");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/UOM/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/UOM/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        let id = this.params['id'];
        $.get("/UOM/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Payables/Index", function (context) {
        title.html("Payables");
        heading.html("Payable List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Payables/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Payables/Create", function (context) {
        title.html("Create");
        heading.html("Create Payables");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Payables/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Payables/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        let id = this.params['id'];
        $.get("/Payables/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });

    this.get("#/Receivables/Index", function (context) {
        title.html("Receivable");
        heading.html("Receivable List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Receivables/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Receivables/Create", function (context) {
        title.html("Create");
        heading.html("Create Receivable");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/Receivables/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/Receivables/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        let id = this.params['id'];
        $.get("/Receivables/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });

    this.get("#/PurchaseOrders/Index", function (context) {
        title.html("Purchase Orders");
        heading.html("Purchase Order List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/PurchaseOrders/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/PurchaseOrders/Create", function (context) {
        title.html("Create");
        heading.html("Create Purchase Order");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/PurchaseOrders/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/PurchaseOrders/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        let id = this.params['id'];
        $.get("/PurchaseOrders/Edit/" + id, function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/SaleOrders/Index", function (context) {
        title.html("Sale Orders");
        heading.html("Sale Order List");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/SaleOrders/Index", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/SaleOrders/Create", function (context) {
        title.html("Create");
        heading.html("Create Sale Order");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        $.get("/SaleOrders/Create", function (data) {
            context.$element().html(data);
            $("#loader").removeClass("fadeIn").addClass("fadeOut");
        });
    });
    this.get("#/SaleOrders/Edit/:id", function (context) {
        title.html("Edit");
        $("#loader").removeClass("fadeOut").addClass("fadeIn");
        let id = this.params['id'];
        $.get("/SaleOrders/Edit/" + id, function (data) {
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

