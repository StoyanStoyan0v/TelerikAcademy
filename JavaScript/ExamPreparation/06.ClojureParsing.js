function Solve(params) {
    var sum = function (args) {
        var result = 0;
        args.forEach(function (element) {          
            result += parseInt(element);            
        });
        return result;
    },
        substr = function (args) {
            var result = parseInt(args[0])*2;
            args.forEach(function (element) {
                result -= parseInt(element);
            });
            return result;
    },
        multiply = function (args) {
            var result = 1;
            args.forEach(function (element) {          
                result *= parseInt(element);            
            });
            return result;        
    },
        divide= function (args) {
            var result = parseInt(args[0])*parseInt(args[0]);
            args.forEach(function (element) {
                if (result !== 0) {
                    result /= parseInt(element);
                }
            });
            return parseInt(result);
    },
        map = [];
   
    for (var element in params) {
        var line = params[element].replace(/\s+/g, ' ').trim(),
            firstSpace = line.indexOf('def ') + 3,
            bracket = line.indexOf('(', firstSpace),
            zero = line.indexOf(' 0 ');

        if (zero === -1) {
            zero = line.indexOf(' 0')
        }
        if (zero !== -1 && (zero - bracket > 4) && (line[bracket + 1] === "/" || line[bracket + 2] === "/")) {
            return "Division by zero! At Line:" + (parseInt(element) + 1);
        }

        if (line.indexOf('def ') !== -1) {
            var secondSpace = line.indexOf(' ', firstSpace + 1),
            variable = line.slice(firstSpace + 1, secondSpace).trim();
           
            if (variable.indexOf("(") !== -1) {
                secondSpace = bracket;
                variable = line.slice(firstSpace + 1, secondSpace);
                secondSpace -= 1;
            }

            if (bracket !== -1) {                
                map[variable] = line.slice(secondSpace + 2, line.length - 2).trim().split(' ');
            }
            else {
                map[variable] = line.slice(secondSpace + 1, line.length - 1).trim().split(' ');
            }
                       
        }
        else {
            params[element] = params[element].slice(1, params[element].length - 1).trim().split(' ');
        }
    }

    function evaluate(args) {

        var operation,
            res = [];

        if (args.length > 1) {
            operation = args.shift();
        }

        args.forEach(function (arg) {
            arg = arg.trim();
            if (isNaN(arg) && arg!=='') {
                res.push(parseInt(evaluate(map[arg])));
            }
            else if(arg!==''){
                res.push(parseInt(arg));
            }
        });

        switch (operation) {
            case '+': return sum(res);
            case '-': return substr(res);
            case '*': return multiply(res);
            case '/': return divide(res);
            default: return res[0];
        }
    }

    return evaluate(params[params.length - 1]);
}

