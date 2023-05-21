// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
    /*Active Inactive Navigation*/
    $('.nav-item .nav-link').click(function (event) {
        var $btn = $(this);
        $btn.parent().siblings().each(function () {
            $(this).children().removeClass('active');
        });
        $btn.addClass('active');
    });
});
