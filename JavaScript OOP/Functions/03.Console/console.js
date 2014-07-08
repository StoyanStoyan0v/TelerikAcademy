var console = (function () {

    function writeLine() {
        var line=$('<div/>');
        if(arguments.length===1){
            line.text(arguments[0]);
            $('#console-container').append(line);
        }else{
            var text = arguments[0];
            for (var i = 1; i < arguments.length; i++) {
                var placeholder = "{" + (i - 1) + "}";
                var ind = text.indexOf(placeholder)
                while (ind!== -1) {
                    text = text.replace(placeholder, arguments[i]);
                    ind = text.indexOf(placeholder, ind + 1);
                }
            }
            line.text(text);
            $('#console-container').append(line);
        }
    }

    return{
        writeLine:writeLine,
        writeError:writeLine,
        writeWarning:writeLine
    }

})();

$(document).ready(function () {
    console.writeLine("Hello world!");
    console.writeLine("{0} says: Hello {1}! {0} said 'Hello {1}!'",'Pesho','world');
});