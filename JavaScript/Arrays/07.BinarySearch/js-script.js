function getNum() {
    var input = document.getElementById("seq").value;
    var num = document.getElementById("num").value;
    var nums = input.split(" ");

    var upper = nums.length-1;
    var lower = 0;

    while (upper >= lower) {
        var mid = Math.floor((lower + upper) / 2);
        if (parseInt(nums[mid]) === parseInt(num)) {
            document.getElementById("result").value = "Element " + num + " found at index " + mid;
            return;
        } else if (parseInt(nums[mid]) > parseInt(num)) {
            upper = mid - 1;
        } else {
            lower = mid + 1;
        }
    }
    document.getElementById("result").value = "Element " + num + " not found!";       
}