"use strict";

function Edit(html_id, edit_url)
$.get(edit_url, function (data, status) {
    $('#' + html_id.replaceWith(data));
});

function Save(html_id, edit_url) {
    $.Save(html_url, edit_url)
    $('#' + html_id.Save(data));
}