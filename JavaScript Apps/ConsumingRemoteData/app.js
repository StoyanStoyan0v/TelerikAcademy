(function () {
    'use strict';

    require(['scripts/01.http-requester'], function (HTTPRequester) {
        var DELAY_TIME=2000,
            FADE_TIME=2000;

        function renderRow(student) {
            var $tr = $('<tr/>'),
                $td = $('<td/>'),
                $currentRow;
            $currentRow = $tr.clone();
            $td.clone().html(student.id).addClass('students-id').appendTo($currentRow);
            $td.clone().html(student.name).appendTo($currentRow);
            $td.clone().html(student.grade).appendTo($currentRow);
            $('table').append($currentRow);
        }

        function loadStudents() {
            $("table").find("tr:gt(0)").remove();
            HTTPRequester.getJSON('http://localhost:3000/students ', 'application/json')
                .then(function (data) {
                    var i;
                    for (i = 0; i < data.students.length; i++) {
                        renderRow(data.students[i]);
                    }
                }, function (error) {
                    $('#error').html(error.responseText);
                });

        }

        function addStudent() {
            var name = $('#lname').val(),
                grade = $('#grade').val(),
                student = {
                    name: name,
                    grade: grade
                };
            if (name.length < 2) {
                $('#error').html("Student's name must be at least 2 characters long.")
                    .show().delay(DELAY_TIME).fadeOut(FADE_TIME);
                return;
            }

            if (1 > grade || grade > 12) {
                $('#error').html("Student's grade must be between 1 and 12.")
                    .show().delay(DELAY_TIME).fadeOut(FADE_TIME);
                return;
            }

            HTTPRequester.postJSON('http://localhost:3000/students ', 'application/json', student)
                .then(function () {
                    $('#success').html('Student ' + student.name + ' successfully added.')
                        .show().delay(DELAY_TIME).fadeOut(FADE_TIME);
                    loadStudents();
                }, function (error) {
                    $('#error').html('Student was not added due to error.')
                        .show().delay(DELAY_TIME).fadeOut(FADE_TIME);
                });
        }

        function deleteStudent() {
            var _id = $('#student-id').val();
            if(!isIdAvailable(_id)) {
                $('#error').html("Id " + _id + " was not found.")
                    .show().delay(DELAY_TIME).fadeOut(FADE_TIME);
                return;
            }
            HTTPRequester.postJSON('http://localhost:3000/students/' + _id +'/')
                .then(function () {
                    $('#success').html('Student with id ' + _id + ' successfully deleted.')
                        .show().delay(DELAY_TIME).fadeOut(FADE_TIME);
                    loadStudents();
                }, function (error) {
                    $('#error').html('Student was not deleted due to error.')
                        .show().delay(DELAY_TIME).fadeOut(FADE_TIME);
                });
        }

        function isIdAvailable(id){
            var elements = $('.students-id');
            console.log(elements);
            for (var i = 0; i < elements.length; i++) {
                if(elements[i].textContent===id){
                    return true;
                }
            }
            return false;
        }
        loadStudents();

        $('#add-btn').click(function () {
            addStudent();
        });
        $('#delete-btn').click(function () {
            deleteStudent();
        });

    });
}());