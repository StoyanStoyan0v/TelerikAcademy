function sort() {
    var input = document.getElementById("seq").value;

    var numbers = input.split(" ");

    for (var i = 0; i < numbers.length - 1; i++) {
        var minIndex = i;
        for (var j = i + 1; j < numbers.length; j++) {
            if (numbers[minIndex] > numbers[j]) {
                minIndex = j;
            }
        }

        swap(numbers, i, minIndex);
    }

    document.getElementById("result").value = numbers;
}

function swap(arr, a, b) {
    var temp = arr[a];
    arr[a] = arr[b];
    arr[b] = temp;
}