function extract(text) {
    var isTag = false;
    var result = "";
    for (var i = 0; i < text.length; i++) {
        if (text[i] === "<") {
            isTag = true;
        } else if (text[i] === ">") {
            isTag = false;
        } else {
            if (!isTag) {
                result += text[i];
            } 
        }
    }
    return result;
}

var text = "<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>";

document.writeln("Initial text: " + text.replace(/</g, "&lt").replace(/>/g, "&gt") + "<br/><br/>");
document.writeln("Result: " + extract(text));