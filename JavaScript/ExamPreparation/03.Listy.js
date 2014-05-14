function Solve(params) {
    var sum = function (args) {
        var result = 0;
        args.forEach(function (element) {          
            result += parseInt(element);            
        });
        return result;
    },
        avg = function (args) {
        return sum(args)/args.length;
    },
        min = function (args) {

        return args.sort(function (a, b) {
            return a - b;
        })[0];
    },
        max= function (args) {
            return args.sort(function (a, b) {
                return b-a;
        })[0];
    },
        map = [];

    params.forEach(function (element) {
        element.replace(/\s+/g, ' ').trim();
        if (element[0] === 'd') {
            var firstSpace = element.indexOf(' '),
            secondSpace = element.indexOf(' ', firstSpace + 1),
            variable = element.slice(firstSpace + 1, secondSpace);

            if (variable.indexOf('[')!== -1) {
                secondSpace = element.indexOf('[');
                variable = element.slice(firstSpace + 1, secondSpace);
                secondSpace -= 1;
            }
            map[variable] = element.slice(secondSpace + 1);
        }
        
    });

    function evaluate(line) {        
        var firstBracket = line.indexOf('['),
            func = line.slice(0, firstBracket).trim(),
            args = line.slice(firstBracket + 1, line.length - 1).split(','),
            res = [];
        args.forEach(function (arg) {
            if (isNaN(parseInt(arg))) {
                var elem = evaluate(map[arg.trim()]);
                
                if (Array.isArray(elem)) {
                    elem.forEach(function (e) {
                        res.push(e);
                    });
                }else {
                    res.push(parseInt(elem));
                }
            }else {
                res.push(parseInt(arg));
            }
        });
        
        switch (func) {
            case 'sum': return sum(res);
            case 'avg': return avg(res);
            case 'min': return min(res);
            case 'max': return max(res);
            default:
                if (res.length === 1) {
                    return res.join('');
                } else {
                    return res;
                }
        }
    }

    return evaluate(params[params.length - 1]);

}
