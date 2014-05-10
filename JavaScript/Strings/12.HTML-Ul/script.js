(function () {
    //Difine constructor for Person and create the objects in the array above.
    function Person(name, age) {
        this.toString = function () {
            return document.getElementById("list-item").innerHTML.replace("-{name}-", name).replace("{age}-", age);
        };
    }

    var people = [new Person("Peter", 18), new Person("George", 20), new Person("Ivan", 25), new Person("Stoyan", 23)],
        someDiv = document.getElementById("list-item"),
        list = document.createElement("ul");

    for (var i = 0; i < people.length; i++) {
        var listItem = document.createElement("li");
        listItem.innerHTML = people[i].toString();
        list.appendChild(listItem);
    }

    someDiv.appendChild(list);

})();