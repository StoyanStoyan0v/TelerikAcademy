function fourthTask($body,$br) {
    var animals = [
        new Animal('Cat', 4),
        new Animal('Dog', 3),
        new Animal('Cat', 2),
        new Animal('Dog', 5),
        new Animal('Bird', 2),
        new Animal('Bear', 4),
        new Animal('Spider', 6),
        new Animal('Spider', 8),
        new Animal('Caterpillar', 80)

    ];


    $body.append('-----Grouped animals by species(task 4)-----'.fontcolor('blue'));
    $body.append($br.clone());
    _.chain(animals)
        .groupBy('species')
        .each(function (item) {
            $body.append(item.join(', '));
            $body.append($br.clone());
        });

    $body.append($br.clone());

    $body.append('-----Sorted animals by number of legs(task 4)-----'.fontcolor('blue'));
    $body.append($br.clone());
    _.chain(animals)
        .sortBy('legsCount')
        .each(function (item) {
            $body.append(item.toString());
            $body.append($br.clone());
        });

    $body.append($br.clone());

}
