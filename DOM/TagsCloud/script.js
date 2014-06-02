function onBodyLoad() {

    function getTagsCount(tags) {
        var tagsCount = [];

        for (var i = 0; i < tags.length; i++) {
            if (!tagsCount[tags[i]]) {
                tagsCount[tags[i]] = 0;
            }
            tagsCount[tags[i]]++;
        }

        return tagsCount;
    }

    function generateTag(tagName, tagCount, minFontSize, maxFontSize) {
        var tag = document.createElement('span');
        tag.style.fontSize = parseInt(maxFontSize / minFontSize) * tagCount * 7+'px';
        tag.innerHTML = tagName+' ';
        
        return tag;
    }

    function generateTagCloud(tags, minFontSize, maxFontSize) {

        var tagsCount = getTagsCount(tags),
            cloud = document.createElement('div');

        cloud.style.width = '250px';
        cloud.style.height = '200px';
        cloud.style.borderColor = 'black';
        cloud.style.borderStyle = 'solid';
        cloud.style.borderWidth = '1px';
        cloud.style.padding = '5px';

        for (var tagName  in tagsCount ) {
            var tag = cloud.appendChild(generateTag(tagName, tagsCount[tagName], minFontSize, maxFontSize));
            cloud.appendChild(tag);
        }

        document.body.appendChild(cloud);
    }


    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net",
        ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net",
        "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms",
        "html", "javascript", "http", "http", "CMS"];

    generateTagCloud(tags, 17, 42);

}


