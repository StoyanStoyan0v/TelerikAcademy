var Person = function (fname, lname, age) {
    return {
        age: age,
        toString: function () {
            return fname + " " + lname;
        }
    }
}

var people = [new Person("Pesho", "Ivanov", 25), new Person("Ivan", "Petrov", 20), new Person("Peter", "Stoyanov", 23)];

var maxAge = 999;
var youngestPerson;
for (var i = 0; i < people.length; i++) {
    document.writeln(i+1+". "+people[i] + ", " + people[i].age + "<br/>");
    if (people[i].age < maxAge) {
        maxAge = people[i].age;
        youngestPerson = people[i];
    }
}

document.writeln("<br>The youngest person is " + youngestPerson + ".");