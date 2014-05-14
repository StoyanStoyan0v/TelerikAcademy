function Solve(params) {
    var sizes = params[0].split(' '),
        n = sizes[0],
        m = sizes[1],
        j = sizes[2],
        start = params[1].split(' '),
        r = parseInt(start[0]),
        c = parseInt(start[1]),
        jumps = params.slice(2),
        jumpsArr = [jumps.length];
        sum = 0,
        jumpsCount = 0,
        isOut = false,
        used = {};
    
    for (var i = 0; i < jumps.length; i++) {
        var dir = jumps[i].split(" ");
        jumpsArr[i] = {
            row: parseInt(dir[0]),
            col: parseInt(dir[1])
        };
    }

    for (var i = 0; i <= jumpsArr.length; i++) {

        if (r < 0 || c < 0 || r >= n || c >= m) {
            isOut = true;
            break;
            
        }else if (used[r * m + c]) {
            break;
        }
        
        jumpsCount++;
        sum += parseInt(r * m + c + 1);
        used[r * m + c] = true;

        if (i === parseInt(j)) {
            i = 0;
        }
        r += parseInt(jumpsArr[i].row);
        c += parseInt(jumpsArr[i].col);
        
    }
    return isOut ? "escaped " + sum : "caught " + jumpsCount;
}
