define('jquery-private', ['jquery'], function (jq) {
    return jq.noConflict( true );
});
(function () {

    require.config({
        paths: {
            sammy: './bower_components/sammy/lib/min/sammy-latest.min',
            requester: 'http-requester',
            controller: 'controller',
            jquery: './bower_components/jquery/dist/jquery.min'
        }
    });

    require(['controller', 'jquery-private'],
        function (Controller, jq) {
            var element = '#chat-container',
                url = 'http://crowd-chat.herokuapp.com/posts',
                app = Controller(element, url);
            app.run('#/index');
        });
}());
