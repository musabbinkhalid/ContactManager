// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on('shown.bs.modal', '#viewmodal', function (e) {

    e.preventDefault();

    var id = parseInt($(e.relatedTarget).data("id"), 10);
    if (isNaN(id))
        id = 0;
    var url = unescape($(this).data('url')).replace("{Id}", id);

    $('#viewmodal .modal-body').load(url, function () {

    });
});

$(document).on('shown.bs.modal', '#editmodal', function (e) {

    e.preventDefault();

    var id = parseInt($(e.relatedTarget).data("id"), 10);
    if (isNaN(id))
        id = 0;
    var url = unescape($(this).data('url')).replace("{Id}", id);

    $('#editmodal .modal-body').load(url, function () {

    });
});

$(document).on("submit", ".form-save", function (e) {

    e.preventDefault();
    var $this = this;
    var data = new FormData($(this)[0]);
    var id = data.get("Id");

    $.ajax({
        url: $(this).attr("action"),
        type: 'POST',
        data: data,
        cache: false,
        contentType: false,
        processData: false

    }).done(function (data) {
        if ($($this).data("callback") != null) {
            $('.modal-backdrop').hide();
            eval($($this).data("callback"));
        }

        if ($($this).data("modal") != null)
            $($($this).data("modal")).modal('hide');

    }).fail(function () {
        $($($this).data("modal")).modal('hide');
    }););
return false;
});

function deleteClicked() {
    var id = $("#Id").val();
    if (confirm("Are you sure ?")) {


        $.ajax({
            url: "Home/Delete",
            type: 'POST',
            data: "{'Id': '" + id + "'}",
            cache: false,
            contentType: "Json",
            processData: false

        }).done(function (data) {
            if ($($this).data("callback") != null) {
                $('.modal-backdrop').hide();
                eval($($this).data("callback"));
            }

            if ($($this).data("modal") != null)
                $($($this).data("modal")).modal('hide');

        }).fail(function () {
            $($($this).data("modal")).modal('hide');
        });
    }
    else {
        return false;
    }

}