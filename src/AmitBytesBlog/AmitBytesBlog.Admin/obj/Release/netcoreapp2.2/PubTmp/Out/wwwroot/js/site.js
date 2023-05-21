// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*mouse context menu*/
$(function () {
    $("body").on("contextmenu", function (evt) {
        evt.stopPropagation();
        evt.preventDefault();
    });
});

