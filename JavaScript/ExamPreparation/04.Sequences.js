    function Solve(array) {
        var count = 1;
    
        for (var i = 2; i < parseInt(array[0])+1; i++) {
            if (parseInt(array[i]) < parseInt(array[i - 1])) {
                count++;
            }
        }
        return count;
    }
