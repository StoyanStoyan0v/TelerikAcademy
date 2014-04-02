function getCount(sequence, number) {
    var count = 0;
    sequence.forEach(function (element) {
        if (element === number) {
            count++;
        }
    });
    return count;
}
function onClick() {
    var sequence = document.getElementById("seq").value.split(/[\s,]+/);
    var number = document.getElementById("num").value;
    document.getElementById("result").value = getCount(sequence, number) + " times.";
}