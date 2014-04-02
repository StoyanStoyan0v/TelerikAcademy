var number = 123456789;
checkNumber(number);
number = 987654321;
checkNumber(number);

function checkNumber(number) {
    if (number[2] == "7") {
        document.writeln("The third digit of " + number + " is 7.<br>");
    } else {
        document.writeln("The third digit of " + number + " is not 7.<br>");
    }
}