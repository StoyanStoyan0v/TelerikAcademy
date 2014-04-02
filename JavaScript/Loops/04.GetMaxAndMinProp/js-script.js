var elements = [window, navigator, document];

window.onload = function () {
    for (var i = 0; i < elements.length; i++) {
        var isFirstItt = true;
        for (var property in elements[i]) {
            var min;
            var max;
            if (isFirstItt) {
                min = property;
                max = property;
                isFirstItt = false;
            }
            if (property > max) {
                max = property; 
            }

            if (property < min) {
                min = property;
            }
        }
        document.getElementById(i + 1).innerHTML = "Min: " + min + "\n" + "Max: " + max;
    }
}