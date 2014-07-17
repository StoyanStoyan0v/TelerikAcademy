function thirdTask($body,$br) {
    var students = [
        new Person("Pesho", "Ivanov"),
        new Person("George", "Petrov"),
        new Person("Ivan", "Dimitrov"),
        new Person("Anton", "Stefanov"),
        new Person("Zlatka", "Martinova")
    ];

    if (!Person.prototype.marks) {
        Person.prototype.marks = [];
    }

    function addRandomMarks() {
        for (var i = 0; i < students.length; i++) {
            students[i].marks = new Array(10);
            for (var j = 0; j < students[i].marks.length; j++) {
                students[i].marks[j] = ((Math.random() * 10 + 2) / 2).toFixed();
            }
        }
    }

    addRandomMarks();

    var sorted = _.sortBy(students, function (item) {
        var totalScore = 0;
        _.each(item.marks, function (item) {
            totalScore += item;
        })
        return totalScore;
    }).reverse();

    $body.append('-----Person with higher marks-----'.fontcolor('blue'));
    $body.append($br.clone());
    $body.append(sorted[0].toString() + " " + sorted[0].marks.join(', '));
    $body.append($br.clone());
    $body.append($br.clone());
}


