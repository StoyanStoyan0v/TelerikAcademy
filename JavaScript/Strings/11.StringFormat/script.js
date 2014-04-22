if (!String.format) {
    String.format = function format() {
        var text = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var placeholder = "{" + (i - 1) + "}";
            var ind = text.indexOf(placeholder)
            while (ind!== -1) {
                text = text.replace(placeholder, arguments[i]);
                ind = text.indexOf(placeholder, ind + 1);
            }
        }
        return text;
    }
}

document.writeln(String.format("Hello {0}!", "Peter") + "<br/>");

var format = "{0}, {1}, {0} text {2}";

document.writeln(String.format(format, 1, "Pesho", "Gosho"));