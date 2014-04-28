var ObjectCopier = function () {
    this.deepCopy = function (object) {

        var tempCopy = {};

        if (typeof(object)==="object") {
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
        arr:[1,2,3]
    },
    arr: [3,2,{a:3,b:5}]
}
var newObject = copier.deepCopy(oldObject);

//change the old object and compare
oldObject.object = { a: 10, array: [3, 5, 8,"[",[5, 7, 9],"]"] };

document.writeln("<strong>oldObject.object properties (after being changed):</strong><br/>");
document.writeln("someObject.object.a: " + oldObject.object.a + "<br/>");
document.writeln("someObject.object.array: " + oldObject.object.array + "<br/> <br/>");

document.writeln("<strong>newObject.object properties (copied from the old object before being changed):</strong> <br/>");
document.writeln("newObject.object.x: " + newObject.object.x + "<br/>");
document.writeln("newObject.object.arr: " + newObject.object.arr);