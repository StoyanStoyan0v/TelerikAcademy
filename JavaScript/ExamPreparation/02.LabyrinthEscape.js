function Solve(args) {
    var maze = [],
        firstArg = args[0],
        n = parseInt(firstArg.split(" ")[0]),
        m = parseInt(firstArg.split(" ")[1]),
        secondArg = args[1],
        r = parseInt(secondArg.split(" ")[0]),
        c = parseInt(secondArg.split(" ")[1]),
        directions = [],
        score = 0,
        result = "",
        counter = 1,
        cells = 0;

    for (var i = 0; i < n; i += 1) {

        var row = [];

        for (var j = 0; j < m; j += 1) {           
            row.push(counter);
            counter++;

        }

        maze.push(row);
    }
    
    for (var a = 2; a < args.length; a++) {
        directions.push(args[a]);
    }

    while(true) {
        
        if (r >= n || r < 0 || c >= m || c < 0 || maze[r][c] === 0) {
            break;
        } else {
            score += maze[r][c];
            maze[r][c] = 0;
            cells++;
        }

        switch (directions[r][c]) {
            case 'l': c--; break;
            case 'r': c++; break;
            case 'u': r--; break;
            case 'd': r++; break;
        }
    }
    if (r >= n || r < 0 || c >= m || c < 0) {
        result += "out " + score;
    } else {       
        result = "lost " + cells;
    }

    return result ;
}