"use strict";

function Edit(html_id, edit_url)
$.get(edit_url, function (data, status) {
    $('#' + html_id.replaceWith(data));
});

function Save(html_id, edit_url) {
    $.Save(html_url, edit_url)
    $('#' + html_id.Save(data));
}

function DeleteItem(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });

    function CreateStundent(create_url)
    var student = {
    }
    $.post(create_url,
        {
            Name: $('#Name').val(),
            Course: $('#CourseName').val(),
            Email: $('#Email').val()
        });
    }
    