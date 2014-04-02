function onChange(fieldname, input) {
    document.getElementById(fieldname).value = input;
}

function getGreatest() {
    var firstNum = parseInt(document.getElementById("firstNum").value);
    var secondNum = parseInt(document.getElementById("secondNum").value);
    var thirdNum = parseInt(document.getElementById("thirdNumber").value)
    var fourthNum = parseInt(document.getElementById("fourthNum").value);
    var fifthNum = parseInt(document.getElementById("fifthNumber").value)
    
    var result = Math.max(firstNum, secondNum, thirdNum, fourthNum, fifthNum);
    
    document.getElementById("result").value = "Max number: " + result;
}