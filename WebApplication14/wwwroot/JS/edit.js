"use strict";

function EditListItem(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function SaveEditItem(html_id, student_id, edit_url) {
    var student = {
        Id: student_id,
        Name: $('#name' + student_id).val(),
        CourseName: $('#course' + student_id).val(),
        Email: $('#email' + student_id).val()
    }
    $.post(edit_url,
        {
            student: student
        }
        , function (data, status) {
            $('#' + html_id).replaceWith(data);
        });
};

function CreateItem(create_url) {
    var student = {

    }
    //alert("1")
    //ajax post
    $.post(create_url,
        {
            Name: $('#name').val(),
            Course: $('#course').val(),
            Email: $('#email').val()
        }
        , function (data, status) {

            $("#studentlist").append(data);
        });



    // inject respone Student in list "id:studentlist"

}

//function rrr (html_id, edit_url) {
//    $.get(edit_url, function (data, status) {
//        $('#' + html_id).replaceWith(data);
//    });
//};
