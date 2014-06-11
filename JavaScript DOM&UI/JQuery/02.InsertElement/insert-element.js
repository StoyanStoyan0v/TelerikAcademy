/**
 * Created by ShOnZi on 6/11/2014.
 */

function insertBefore(nextElementId,newElemtagName,content){
    var elem = $(newElemtagName);
    elem.text(content);
    $('#'+nextElementId).before(elem);
}

function insertAfter(nextElementId,newElemtagName,content){
    var elem = $(newElemtagName);
    elem.text(content);
    $('#'+nextElementId).after(elem);
}

window.onload= function () {

    insertBefore(4,'<div>',3);
    insertAfter(5,'<div>',6);
}