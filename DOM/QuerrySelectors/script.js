document.onload=(function () {

    'use strict';

    function traverseAllSelectors(selector) {
        var selectors = selector.split(' '),
            object = document;
            
        for (var i = 0; i < selectors.length; i++) {
            switch (selectors[i][0]) {
                case '#': object = object.getElementById(selectors[i]); break;
                case '.': object = object.getElementsByClassName(selectors[i])[0]; break;
                default: object = object.childNodes[selectors[i]]; break;
            }
        }
        return object;
    };

    document.querySelector = function querySelector(selector) {               
        return traverseAllSelectors(selector)[0];
    }

    document.querySelectorAll =  function querySelectorAll(selector) {
        return traverseAllSelectors(selector);
    }
})();