function group(arr, prop) {
    var tempArr = [];
    for (var i = 0; i < arr.length; i++) {
        if (tempArr[arr[i][prop]] === undefined) {
            tempArr[arr[i][prop]] = [];
        }
        tempArr[arr[i][prop]].push(arr[i]);
    }
    return tempArr;
}
function groupBy(prop) {
    document.writeln("-------------------------------------------------<br/>")
    document.writeln("<strong><em>Group by " + (prop==="fname" ? "first name" :(prop==="lname" ? "last name" : "age")) + ": </strong></em><br/>")
    var groupByFname = group(people, prop);
    for (var prop in groupByFname) {
        document.writeln("<em>" + prop + ":</em> <br/>")
        document.writeln(groupByFname[prop] + "<br/>");
    }
    document.writeln("--------------------------------------------------<br/>")
}

var Person = function (fname, lname, age) {
    return {
        fname: fname,
        lname: lname,
        age: age,
        toString: function () {
            return "  " + fname + " " + lname + " | age: " + age;
        }
    }
}

var people = [new Person("Ivan", "Petrov", 25), new Person("George", "Petrov", 25), new Person("Ivan", "Ivanov", 20)];

groupBy("fname");
groupBy("lname");
groupBy("age");



String.prototype.repeat = function (count) {
    var str = "";
    for (var i = 0; i < count; i += 1) {
        str += String(this);
    }
    return str;
};

var repeated = '-'.repeat(20)

document.writeln(repeated);