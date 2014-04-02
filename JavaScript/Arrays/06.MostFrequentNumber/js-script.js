function getNum() {
    var input = document.getElementById("seq").value
    var nums = input.split(" ");
    var map = [];
    var maxCount = 0;
    var keyMax;
    for (var i = 0; i < nums.length; i++) {
        if (map[nums[i]] !== undefined) {
            map[nums[i]]++;
        } else {
            map[nums[i]] = 1;
        }

        if (map[nums[i]] > maxCount) {
            keyMax = nums[i];
            maxCount = map[nums[i]];
        }
    }
    
    document.getElementById("result").value = input!=="" ? keyMax + "(" + maxCount + " times)" : "The sequence is empty.";
}