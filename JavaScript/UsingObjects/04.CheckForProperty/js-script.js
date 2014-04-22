function checkForProperty(obj, property) {
    for (prop in obj) {
        if (prop === property) {
            return true;
        }
    }
    return false;
}

var person = {
    fname: "Pesho",
    mname: "Peshov",
    lname: "Peshov",
    age: 25,
    location: "New_Zealand"
}

document.writeln("Object: person<br/>Properties:<br/>")

for (prop in person) {
    document.writeln(prop + ": " + person[prop] + "<br/>");
}

document.writeln("<br/> Does the object \"person\" contains a property \"sname\": <b>" +
    (checkForProperty(person, "sname") ? "Yes." : "No.") + "</b>");
document.writeln("<br/> Does the object \"person\" contains a property \"age\": <b>" +
    (checkForProperty(person, "age") ? "Yes." : "No.") + "</b>");