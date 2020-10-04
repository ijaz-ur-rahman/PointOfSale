var Placeholder;
var titleContent;

$(function () {
    Placeholder = $("#Placeholder"); /// render partial views.
    titleContent = $("title"); // render titles.
});
var routingApp = $.sammy("#Placeholder", function () {
    this.get("#/Users/Index", function (context) {
        titleContent.html("Users Page");
        $.get("/Users/Index", function (data) {
            context.$element().html(data);
        });
    });
    this.get("#/Home/Index", function (context) {
        titleContent.html("Home Page");
        $.get("/Home/Index", function (data) {
            context.$element().html(data);
        });
    });

   
   
});

$(function () {
    routingApp.run("#/Users/Index"); // default routing page.
});