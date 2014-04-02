var number = 12;
document.writeln("The third bit of " + number + " is " + checkBit(number) + ".<br>" );
number = 16;
document.writeln("The third bit of " + number + " is " + checkBit(number) + ".<br>");
function checkBit(number) {
    return bitValue = (number & (1 << 3)) >> 3;   
}