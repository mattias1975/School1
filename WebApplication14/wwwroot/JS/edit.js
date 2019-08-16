"use strict";

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

}

// inject respone Student in list "id:studentlist"


function AddTheacherToCourse(html_id, Course_id, Teacher_Id, edit_url) {

    $.post(edit_url,
        {
            cId: Course_id,
            tId: Teacher_Id

        }

        , function (data, status) {
            $('#Teacher' + Teacher_Id).replaceWith('');
            $('#CurrentTeacher').replace(data);
;
   
        });

}

function AddStudentToCourse(html_id, CourseStudent_id, Student_Id, edit_url) {
    $.post(edit_url,
        {

            coId: CourseStudent_id,
            SoId: Student_Id

        }
        , function (data, status) {

            $('#Student' + Student_Id).replaceWith('');
            $('#studentlist').append(data);
        }
    );
}
function DeleteStudentFromCourse(Course_Id, Student_Id, edit_url) {
    $.post(edit_url,
        {
            course_id: Course_Id,
            student_Id: Student_Id
        }
        , function (data, status) {

            $('#Student' + Student_Id).replaceWith('');
            $('#allStudents').append(data);


        }
    );
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
    console.log($('#CourseName' + course_id).val());
    var course = {
        Id: course_id,
        CourseName: $('#CourseName' + course_id).val(),
        Assigment: $('#Assigment' + course_id).val()
    };
    $.post(edit_url,
        {
            course: course
        }
        , function (data, status) {
            $('#' + html_id).replaceWith(data);
        });
};


function EditTeacher(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function SaveEditTheacher(html_id, course_id, edit_url) {
    var course = {
        Id: Course_id,
        TeacherId: $('#Teacher' + course_id).val(),

    }
    $.post(edit_url,
        {
            course: course
        }
        , function (data, status) {

            $("#Courselist").append(data);

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

function Delete(html_id, edit_url) {


    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}
