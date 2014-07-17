var Animal =(function () {
    function Animal(species, legsCount) {
        this.species = species;
        this.legsCount = legsCount;
    }

    Animal.prototype.toString = function () {

        return this.species + " " + this.legsCount;
    };
    return Animal;
}());
