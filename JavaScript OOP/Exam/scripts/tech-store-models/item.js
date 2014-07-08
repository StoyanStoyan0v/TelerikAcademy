define([], function () {
    var NAME_LENGTH={
        MAX:40,
        MIN:6
        },
     ERROR_MSG="The name's length must be between 6 and 30 characters long.!";

    var Item=(function () {
        function Item(type, name, price) {

            if (name.length < NAME_LENGTH.MIN || NAME_LENGTH.MAX < name.length ) {
                throw new Error(ERROR_MSG);
            }
            this.itemType = type;
            this.itemName = name;
            this.price = price;
        }
        return Item;
    }());

    return Item;
});