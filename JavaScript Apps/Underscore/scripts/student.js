var Person = (function () {

    function Person(firstName, lastName) {
        this.fname = firstName;
        this.lname = lastName;

    }

    Person.prototype.toString = function () {
        return this.fname + " " + this.lname;
    };

    return Person;
}());
