function seventhTask($body,$br) {
    var people = [
        new Person("Pesho", "Dimitrov"),
        new Person("George", "Dimitrov"),
        new Person("Ivan", "Dimitrov"),
        new Person("Anton", "Stefanov"),
        new Person("Zlatka", "Martinova"),
        new Person("Pesho", "Ivanov"),
        new Person("Pesho", "Petrov"),
        new Person("Ivan", "Dimitrov"),
        new Person("Pesho", "Dimitrov"),
        new Person("Zlatka", "Martinova")
    ];


    $body.append('-----The most popular first and last names (task 7)-----'.fontcolor('blue'));
    $body.append($br.clone());

    $body.append('The most popular first name: ');
    var mostCommonFirstName = _.chain(people).countBy('fname').pairs().max(_.last);
    $body.append(mostCommonFirstName.head().value() + ' -> ' + mostCommonFirstName.tail().value() + ' times');
    $body.append($br.clone());

    $body.append('The most popular last name: ');
    var mostCommonLastName = _.chain(people).countBy('lname').pairs().max(_.last);
    $body.append(mostCommonLastName.head().value() + ' -> ' + mostCommonLastName.tail().value() + ' times');

}
