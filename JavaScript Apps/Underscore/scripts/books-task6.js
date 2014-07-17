function sixthTask($body,$br) {
    var books = [
        {
            author: "Francis Scott Fizgerald ",
            title: "The Great Gatsby"
        },
        {
            author: "Joan Rowling",
            title: "Harry Potters and the Deathly Hallows"
        },
        {
            author: "Joan Rowling",
            title: "Harry Potters and the Chamber of Secrets"
        },
        {
            author: "John Steinback",
            title: "East from Heaven"
        },
        {
            author: "Vladimir Nabokov",
            title: "Lolita"
        },
        {
            author: "Astrid Lindgren",
            title: "Pippie The Long Stocking"
        },
        {
            author: "Astrid Lindgren",
            title: "Emil from Ljoneberya"
        },
        {
            author: "Joan Rowling",
            title: "Harry Potter and the Goblet of Fire"
        }
    ];


    $body.append('-----The most popular author (task 6)-----'.fontcolor('blue'));
    $body.append($br.clone());

    var mostPopularAuthor = _.chain(books).countBy('author').pairs().max(_.last);
    $body.append(mostPopularAuthor.head().value() + " -> " + mostPopularAuthor.tail().value() + " books");
    $body.append($br.clone());
    var counter = 1;
    _.each(books, function (item) {
        if (item.author === mostPopularAuthor.head().value()) {
            $body.append(counter + ". " + item.title);
            $body.append($br.clone());
            counter++;
        }
    });
    $body.append($br.clone());
}
