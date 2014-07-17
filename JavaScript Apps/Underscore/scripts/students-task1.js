function firstTask($body,$br) {
    var students = [
        new Person("Pesho", "Ivanov"),
        new Person("George", "Petrov"),
        new Person("Ivan", "Dimitrov"),
        new Person("Anton", "Stefanov"),
        new Person("Zlatka", "Martinova")
    ];


    $body.append('-----Students with first name before last(1 task)-----'.fontcolor('blue'));
    $body.append($br.clone());
    _.chain(students).filter(function (item) {
        if (item.fname < item.lname) {
            return item.toString();
        }
    })
        .each(function (item) {
            $body.append(item.toString());
            $body.append($br.clone());
        });


    $body.append($br.clone());
    $body.append('-----Students sorted by full name(1 task)-----'.fontcolor('blue'));
    $body.append($br.clone());
    _.chain(students)
        .sortBy(function (item) {
            return item.toString();
        })
        .reverse()
        .each(function (item) {
            $body.append(item.toString());
            $body.append($br.clone());
        });
    $body.append($br.clone());
}
