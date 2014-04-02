var num = 127;
document.writeln(checkIfPrime(num) ? num + " is a prime number.<br>" : num + " is not a prime number.<br>")

num = 15;
document.writeln(checkIfPrime(num) ? num + " is a prime number.<br>" : num + " is not a prime number.<br>")

function checkIfPrime(number) {
    var isPrime = true;
    for (var i = 2; i < Math.sqrt(number); i++) {
        if (number % i == 0) {
            return isPrime = false;                     
        }
    }
    return isPrime;
}