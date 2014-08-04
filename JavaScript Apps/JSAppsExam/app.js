define('jquery-private', ['jquery'], function (jq) {
    return jq.noConflict( true );
});
(function () {

    require.config({
        paths: {
            requester: 'http-requester',
            renderer:'renderer',
            handlebars:'./bower_components/handlebars/handlebars.min',
            underscore:'./underscore/underscore',
            crypto:'./bower_components/cryptojs-sha1',
            jquery: './bower_components/jquery/dist/jquery.min'
        }
    });


    require(['renderer', 'jquery-private'],
        function (Renderer, jq) {
            var url = 'http://localhost:3000/post',
                app = Renderer.loadPage(url);
        });

}());
