// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    $(document).on('keyup', 'div.productTable input.qty', function (e) {
        if (!((e.keyCode > 95 && e.keyCode < 106)
            || (e.keyCode > 47 && e.keyCode < 58)
            || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 46)) {
            return false;
        } else {
            if ($(this).val() != "") {
                reCalculateCost();
            }
        }
    });

    $(document).on('keyup', 'div.deliverableTable input.qty', function (e) {
        if (!((e.keyCode > 95 && e.keyCode < 106)
            || (e.keyCode > 47 && e.keyCode < 58)
            || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 46)) {
            return false;
        } else {
            if ($(this).val() != "") {
                reCalculateCost();
            }
        }
    });
});
