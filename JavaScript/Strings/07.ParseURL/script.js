function UrlParser(url) {
    var index = url.indexOf(":");   
    var secondIndex = url.indexOf("/", index + 3);

    return {
        protocol: url.substring(0, index+1 ),
        server: url.substring(index + 3, secondIndex),
        resources: url.substring(secondIndex, url.length)
    }
}

function parser() {
    var url = new UrlParser(document.getElementById("input").value);
    
    document.getElementById("protocol").value = url.protocol;
    document.getElementById("server").value = url.server;
    document.getElementById("resources").value = url.resources;
}