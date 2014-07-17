function secondTask($body,$br) {
    var MIN_AGE = 18,
        MAX_AGE = 24,
        students = [
            new Person("Pesho", "Ivanov"),
            new Person("George", "Petrov"),
            new Person("Ivan", "Dimitrov"),
            new Person("Anton", "Stefanov"),
            new Person("Zlatka", "Martinova")
        ];

    if (!Person.prototype.age) {
        Person.prototype.age = Number;
    }

    function addRandomAges() {
        for (var i = 0; i < students.length; i++) {
            students[i].age = Math.floor(Math.random() * 50);
        }
    }


    addRandomAges();

    var filtered = _.filter(students, function (item) {
        if (MIN_AGE <= item.age && item.age < MAX_AGE) {
            return item.toString();
        }
    });

    $body.append('-----Students with age between 18 and 24(2 task)-----'.fontcolor('blue'));
    $body.append($br.clone());
    if (filtered.length === 0) {
        var p = $('<span/>').css('color', 'red').html('If no people are shown, ' +
            'refresh the page till result comes. (randomly generated)');
        $body.append(p);
        $body.append($br.clone());

    }
    _.each(filtered, function (item) {
        $body.append(item.toString() + " " + item.age);
        $body.append($br.clone());
    });
    $body.append($br.clone());
}

