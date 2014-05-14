function Solve(params) {
    var N = parseInt(params[0]),
        currentSum = parseInt(params[1]),
        maxSum = parseInt(params[1]),
        tempStartIndex = 0,
        startIndex = 0,
        endIndex = 0;

    for (var i = 2; i < params.length; i++) {
        if (currentSum < 0) {
            currentSum = parseInt(params[i]);
            tempStartIndex = i;
        }
        else {
            currentSum += parseInt(params[i]);
        }

        if (currentSum > maxSum) {
            maxSum = currentSum;
            startIndex = tempStartIndex;
            endIndex = i;
        }
    }

    return maxSum;

}
