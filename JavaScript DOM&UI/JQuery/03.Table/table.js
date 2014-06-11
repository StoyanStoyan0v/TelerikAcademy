function generateRow(table,fname,lname,grade) {

        var tr = $('<tr>');
        tr.append('<td>' + fname + '</td>'+'<td>' + lname + '</td>'+'<td>' + grade + '</td>');
        table.append(tr);

}

window.onload=function() {
    var students = [
            {
                fname: 'Peter',
                lname: 'Ivanov',
                grade: 3
            },
            {
                fname: 'Milena',
                lname: 'Grigorova',
                grade: 6
            },
            {
                fname: 'Gergana',
                lname: 'Borisova',
                grade: 12
            },
            {
                fname: 'Boyko',
                lname: 'Petrov',
                grade: 7
            }
        ],
        table = $('<table>'),
        tr = $('<tr>');

    tr.append('<th>First name</th>');
    tr.append('<th>Last name</th>');
    tr.append('<th>Grade</th>');

    table.append(tr);

    for (var i = 0; i < students.length; i++) {
        generateRow(table, students[i].fname, students[i].lname, students[i].grade);
    }
    $('body').first().append(table);

}
