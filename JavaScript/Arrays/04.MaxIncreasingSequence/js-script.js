function getSequence() {
    var input = document.getElementById("seq").value;

    var numbers = input.split(" ");
    var startIndex = 0;
    var index;
    var count = 1;
    var maxCount = 1;

    for (var i = 1; i < numbers.length; i++) {
        if (numbers[i] > numbers[i - 1]) {
            count++;
            if (count > maxCount) {
                maxCount = count;
                index = startIndex;
            }
        } else {
            count = 1;
            startIndex = i;
        }
    }

    var result = numbers.splice(index, maxCount);

    document.getElementById("result").value = result;
}