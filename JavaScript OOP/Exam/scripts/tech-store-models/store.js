define(['tech-store-models/item'], function (Item) {
    var Store = (function () {

        var ITEM_TYPES = ['accessory', 'smart-phone', 'notebook', 'pc' , 'tablet'],
            NAME_LENGTH = {
                MAX: 30,
                MIN: 6
            },
           ERROR_MESSAGES=["The name's length must be between 6 and 30 characters long.!",
               'Trying to add an object that is not an instance of Item.'];



        function getSortedItems(sortBy) {

            return this._items.sort(sortBy);
        }

        function sortByName(item1, item2) {
            var firstItem = item1.itemName.toUpperCase(),
                secondItem = item2.itemName.toUpperCase();

            if (firstItem < secondItem) {
                return -1;
            } else if (firstItem > secondItem) {
                return 1;
            }
            else {
                return 0;
            }

        }

        function sortByPrice(item1, item2) {
            return item1.price - item2.price;
        }

        function Store(name) {
            if (name.length < NAME_LENGTH.MIN || NAME_LENGTH.MAX < name.length) {
                throw new Error(ERROR_MESSAGES[0]);
            }
            this._name = name;
            this._items = [];
        }

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof  Item)) {
                    throw {
                        message: ERROR_MESSAGES[1]
                    };
                }
                this._items.push(item);
                return this;
            },
            getAll: function () {
                return getSortedItems.call(this, sortByName);
            },
            getSmartPhones: function () {
                var allItems = getSortedItems.call(this, sortByName), itemsToReturn = [];
                allItems.map(function (item) {
                    if (item.itemType === ITEM_TYPES[1]) {
                        itemsToReturn.push(item);
                    }
                });
                return itemsToReturn;
            },
            getMobiles: function () {
                var allItems = getSortedItems.call(this, sortByName), itemsToReturn = [];
                allItems.map(function (item) {
                    if (item.itemType === ITEM_TYPES[1] || item.itemType === ITEM_TYPES[4]) {
                        itemsToReturn.push(item);
                    }
                });
                return itemsToReturn;
            },
            getComputers: function () {
                var allItems = getSortedItems.call(this, sortByName), itemsToReturn = [];
                allItems.map(function (item) {
                    if (item.itemType === ITEM_TYPES[2] || item.itemType === ITEM_TYPES[3]) {
                        itemsToReturn.push(item);
                    }
                });
                return itemsToReturn;
            },
            filterItemsByType: function (filterType) {
                var allItems = getSortedItems.call(this, sortByName), itemsToReturn = [];
                allItems.map(function (item) {
                    if (item.itemType === filterType) {
                        itemsToReturn.push(item);
                    }
                });
                return itemsToReturn;
            },
            filterItemsByPrice: function (options) {
                var allItems = getSortedItems.call(this, sortByPrice), min, max, itemsToReturn = [];
                if (!options) {
                    min = 0;
                    max = Number.MAX_VALUE;
                } else {
                    min = options.min || 0;
                    max = options.max || allItems[allItems.length - 1].price;
                }

                allItems.map(function (item) {
                    if (min < item.price && item.price < max) {
                        itemsToReturn.push(item);
                    }
                });
                return itemsToReturn;
            },
            countItemsByType: function () {
                var count = [];
                for (var i = 0; i < this._items.length; i++) {
                    var itemType = this._items[i].itemType;
                    if (!count[itemType]) {
                        count[itemType] = 0;
                    }
                    count[itemType]++;

                }
                return count;

            },
            filterItemsByName: function (partOfName) {
                var allItems = getSortedItems.call(this, sortByName);
                var itemsToReturn = [];
                allItems.map(function (item) {
                    if (item.itemName.toLowerCase().indexOf(partOfName.toLowerCase()) !== -1) {
                        itemsToReturn.push(item);
                    }
                });
                return itemsToReturn;
            }

        };
        return Store;
    }());

    return Store;
});