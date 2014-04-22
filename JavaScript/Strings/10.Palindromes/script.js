function isPalindrome(word) {
    var reversed = "";
    for (var i = word.length - 1; i >= 0; i--) {
        reversed+=word[i];
    }
    if (word===reversed) {
        return true;
    }
    return false;
}

function extractPalindromes(text) {
    var palindromes = [];
    text.split(" ").forEach(function (word) {
        if (word[word.length - 1] === "," || word[word.length - 1] === "." || word[word.length - 1] === "!" || word[word.length - 1] === "?") {
            word = word.substr(0, word.length - 1);
        }
        
        if (isPalindrome(word)) {
            palindromes.push(word);
        }
    });
    return palindromes;
}

var text = "The word NEVEN is palindrome. The other is the name of the group ABBA and one of it's songs SOS.";

document.writeln("Text: " + text + "<br/>Palindromes:<br/>");
document.writeln(extractPalindromes(text).join("<br/>"));