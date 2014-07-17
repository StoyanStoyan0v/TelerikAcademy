function fifthTask($body,$br) {
    var animals = [
        new Animal("Kangaroo", 2),
        new Animal("Cat", 4),
        new Animal("Dog", 4),
        new Animal("Spider", 6),
        new Animal("Bird", 2),
        new Animal("Chicken", 2),
        new Animal("Spider", 8),
        new Animal("Centipede", 100),
        new Animal("Caterpillar", 100)
    ];

    $body.append('----Total count of legs(task 5)-----'.fontcolor('blue'));
    $body.append($br.clone());
    var totalCountOfLegs = 0;
    _.each(animals, function (item) {

        totalCountOfLegs += item.legsCount;
    });

    $body.append(totalCountOfLegs);
    $body.append($br.clone());
    $body.append($br.clone());
}

