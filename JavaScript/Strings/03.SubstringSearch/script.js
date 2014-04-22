if (!String.searchSubstring) {
    String.prototype.searchSubstring = function (substring, caseSensitive) {
        var count = 0;
        var index;

        if (caseSensitive) {
            index = this.indexOf(substring, 0);
            while (index !== -1) {
                count++;
                index = this.indexOf(substring, index + substring.length);
            }
            return count;
        } else {
            index = this.toLowerCase().indexOf(substring.toLowerCase(), 0);
            while (index !== -1) {
                count++;
                index = this.toLowerCase().indexOf(substring.toLowerCase(), index + substring.length);
            }
            return count;
        }
        
    }
}

function search() {
    var text = document.getElementById("input").value;
    var substr = document.getElementById("word").value;
    if (document.getElementsByName("case")[0].checked) {
        document.getElementById("result").value =
        "Substring \"" + substr + "\" has been found " + text.searchSubstring(substr, true) + " times.";
    }
    if (document.getElementsByName("case")[1].checked) {
        document.getElementById("result").value =
        "Substring \"" + substr + "\" has been found " + text.searchSubstring(substr, false) + " times.";
    }
}