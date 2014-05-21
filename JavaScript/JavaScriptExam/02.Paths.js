function solve(args) {

    function inRange(position,maxPosition) {
        return 0<=position && position<maxPosition;
    }

    var matrixSizes = args[0],
        m = matrixSizes.split(' ')[0],
        n = matrixSizes.split(' ')[1],
        r = 0,
        c=0,
        directions = args.slice(1),
        dirs = [],
        sum = 0,
        visited = {};
        
    for (var i = 0; i < directions.length; i++) {
        dirs.push(directions[i].split(' '));
    }

    while (true) {

        if (!inRange(r,m) || !inRange(c,n)) {
            return 'successed with ' + sum;
        }

        if (visited[r * n + c]) {
            return 'failed at (' + r + ', ' + c + ')';
        }

        sum += Math.pow(2, r) + c;
        visited[r * n + c] = true;

        switch (dirs[r][c]) {
            case 'dr': r++; c++; break;
            case 'ur': r--; c++; break
            case 'ul': r--; c--; break;
            case 'dl': r++; c--; break;
            default: break;
        }
    }



}

args = [
  '3 5',
  'dr dl dr ur ul',
  'dr dr ul ur ur',
  'dl dr ur dl ur'
]

