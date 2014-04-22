

function replace(text) {
    var stack = [];
    var replaced = "";    
    for (var i = 0; i < text.length; i++) {
        if (text[i] + text[i + 1] === "<u") {
            i += 7;
            stack.push("up");
        } else if (text[i] + text[i + 1] === "<l") {
            i += 8;
            stack.push("low");
        } else if (text[i] + text[i + 1] === "<m") {
            i += 8;
            stack.push("mix");
        } else if (text[i] + text[i + 1] + text[i + 2] === "</u") {
            i += 8;
            stack.pop();
        } else if (text[i] + text[i + 1] + text[i + 2] === "</l") {
            i += 9;
            stack.pop();
        } else if (text[i] + text[i + 1] + text[i + 2] === "</m") {
            i += 9;
            stack.pop();
        } else {
            var state = stack[stack.length - 1];
            if (state === "up") {
                replaced += text[i].toUpperCase();
            } else if (state === "low") {
                replaced += text[i].toLowerCase();
            } else if (state === "mix") {
                if (parseInt(Math.random()*2) >0.5) {
                    replaced += text[i].toLowerCase()
                } else {
                    replaced += text[i].toUpperCase();
                }
            } else {
                replaced += text[i];
            }
        }
    }
    return replaced;
}

var initialText = "This text is <upcase> upcased </upcase>. This is <lowcase>LOWCASED</lowcase>. This is <mixcase>mixcased text</mixcase>. And this is <upcase>upcased with<lowcase> SOME LOWCASED IN NESTED TAG AND <mixcase> double nested mixcased</mixcase></lowcase></upcase>.";
var changedText = replace(initialText);

document.writeln("<strong>Initial text: </strong>This text is &ltupcase&gt upcased &lt/upcase&gt. This is &ltlowcase&gtLOWCASED&lt/lowcase&gt. This is &ltmixcase&gtmixcased text&lt/mixcase&gt. And this is &ltupcase&gtupcased with&ltlowcase&gt SOME LOWCASED IN NESTED TAG AND &ltmixcase&gt double nested mixcased&lt/mixcase&gt&lt/lowcase&gt&lt/upcase&gt. <br/> <br/>");
document.writeln("<strong>Changed text: </strong>" + changedText + "<br/>")