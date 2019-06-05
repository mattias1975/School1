"use strict";

function EditStudent(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function SaveEditStudent(html_id, student_id, edit_url) {
    var student = {
        Id: student_id,
        Name: $('#Name' + student_id).val(),
        Email: $('#Email' + student_id).val()
    }
    $.post(edit_url,
        {
            student: student
        }
        , function (data, status) {
            $('#' + html_id).replaceWith(data);
        });
};

function CreateStudent(create_url) {
  
    $.post(create_url,
        {
            Name: $('#name').val(),
            Email: $('#email').val()
        }
        , function (data, status) {

            $("#studentlist").append(data);
        });



    // inject respone Student in list "id:studentlist"

}
function DeleteStudent(html_id, edit_url) {
    
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
        });
    }
//Teacher
function SaveEditTeacher(html_id, teacher_id, edit_url) {
    var teacher = {
        Id: teacher_id,
        Name: $('#name' + teacher_id).val(),
        Email: $('#email' + teacher_id).val()
    }
    $.post(edit_url,
        {
            teacher: teacher
        }
        , function (data, status) {
            $('#' + html_id).replaceWith(data);
        });
};

function CreateItem(create_url) {
 
    $.post(create_url,
        {
            Name: $('#name').val(),
            Email: $('#email').val()
        }
        , function (data, status) {

            $("#teacherlist").append(data);
        });



    // inject respone Student in list "id:studentlist"

}
function DeleteTeacher(html_id, edit_url) {


    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

    


