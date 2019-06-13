﻿"use strict";

function EditStudent(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function SaveEditStudent(html_id, student_id, edit_url) {
    var student = {
        Id: student_id,
        name: $('#name' + student_id).val(),
        email: $('#email' + student_id).val()
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
            name: $('#name').val(),
            email: $('#email').val()
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

function EditTeacher(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}
function SaveEditTeacher(html_id, teacher_id, edit_url) {
    var teacher = {
        Id: teacher_id,
        name: $('#name' + teacher_id).val(),
        email: $('#email' + teacher_id).val()
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
            name: $('#name').val(),
            email: $('#email').val()
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

//Course

function EditCourse(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}
function SaveEditCourse(html_id, course_id, edit_url) {
    var course = {
        Id: course_id,
        CourseName: $('#CourseName' + course_id).val(),
        Assigment: $('#Assigment' + course_id).val()
    }
    $.post(edit_url,
        {
            course: course
        }
        , function (data, status) {
            $('#' + html_id).replaceWith(data);
        });
};

function CreateCourse(create_url) {

    $.post(create_url,
        {
            CourseName: $('#CourseName').val(),
            Assigment: $('#Assigment').val()
        }
        , function (data, status) {

            $("#Courselist").append(data);
        });

}
function DeleteCourse(html_id, edit_url) {


    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}
