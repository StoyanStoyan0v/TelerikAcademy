function multiply() {
    var input = document.getElementById("seq").value;
    var numbers = input.split(" ");
    var result = "";
    numbers.forEach(function (item) {
        result += parseInt(item) * 5 + " ";
    });

    document.getElementById("result").value = result;
    
}