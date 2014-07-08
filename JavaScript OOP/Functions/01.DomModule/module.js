var domModule = (function () {

    var selectorMap={};

    function appendChild(element, selector) {
        $(selector).first().append(element);
    }

    function removeChild(selector, child) {
        $(selector).find(child).first().remove();
    }

    function addHandler(selector, event, eventHandler) {
        $(selector).first().on(event, eventHandler);
    }
    function getElement(selector){
        return $(selector).first();
    }

    function appendToBuffer(selector,elementNode) {
        if (!selectorMap[selector]) {
            selectorMap[selector]=[];

        }
        selectorMap[selector].push(elementNode);

        if(selectorMap[selector].length===100){
            for (var i = 0; i < 100; i++) {
               appendChild(selectorMap[selector][i],selector);
            }
        }

    }
    return{
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        getElement:getElement,
        appendToBuffer:appendToBuffer

    }
})();

$(document).ready(function () {
    var div = $('<div/>');
    div.addClass('some-div');
    domModule.appendChild(div,'body');
    var input = $('<input/>').attr('type','button').attr('value','Click');
    domModule.appendChild(input,'body');
    domModule.addHandler('input','click', function () {
       alert("Wow!");
    })
    var divElement = domModule.getElement('.some-div');
    console.log(divElement);
    domModule.removeChild('body','.some-div');
    var div = $('<div/>');
    domModule.appendChild(div,'body');
    var innerDiv=$('<div/>');
    console.log(innerDiv);
    for (var i = 0; i < 99; i++) {

        innerDiv.text(i+1);
        domModule.appendToBuffer('div',innerDiv.clone());
    }
    innerDiv.text(100);
    domModule.appendToBuffer('div',innerDiv.clone());
});






