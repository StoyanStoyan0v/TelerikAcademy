Array.prototype.isArray = true;

var ObjectCopier = function () {
    var self = this; //this variable allow to access the public method inside the private one

    var copyArray = function (arr) { //private function
        var tempArr = [];
        for (var i = 0; i < arr.length; i++) {
            if (typeof (arr[i]) === "object" && arr[i].isArray) {
                tempArr.push(copyArray(arr[i]));
            } else if (typeof (arr[i]) === "object") {
                tempArr.push(self.deepCopy(arr[i]))
            } else {
                tempArr.push(arr[i]);
            }
        }
        return tempArr;
    }

    this.deepCopy = function (object) { //public function
        var tempCopy = {};
        if (typeof (object) === "object" && object.isArray) {
            tempCopy = copyArray(object);
        } else if (typeof (object) === "object") {
            for (prop in object) {
                tempCopy[prop] = this.deepCopy(object[prop]);
            }
        } else {
            tempCopy = object;
        }
        return tempCopy;
    }
};
var copier = new ObjectCopier();

var oldObject = {
    number: 5,
    object: {
        x: 3,
        arr: [1, 2, 3]
    },
    arr: [3, 2, { a: 3, b: 5 } ]
};
var newObject = copier.deepCopy(oldObject);

//change the old object and compare
oldObject.object = { a: 10, array: [3, 5, 8 + "[" + [5, 7, 9] + "]"] };

document.write("<strong>oldObject.object properties (after being changed):</strong><br/>" +
               "someObject.object.a: " + oldObject.object.a + "<br/>" +
               "someObject.object.array: " + oldObject.object.array + "<br/> <br/>" +
               "<strong>newObject.object properties (copied from the old object before being changed):</strong> <br/>" +
               "newObject.object.x: " + newObject.object.x + "<br/>" +
               "newObject.object.arr: " + newObject.object.arr);