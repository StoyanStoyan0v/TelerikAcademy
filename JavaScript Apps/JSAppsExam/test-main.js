define('jquery-private', ['jquery'], function (jq) {
    return jq.noConflict( true );
});
(function () {

    require.config({
        baseUrl:'tests',
        paths: {
            requester: '../http-requester',
            underscore:'../underscore/underscore',
            jquery: '../bower_components/jquery/dist/jquery.min',
            mocha:'../bower_components/mocha/mocha',
            chai: '../bower_components/chai/chai'
        }
    });

    require(['mocha', 'chai'], function () {
        mocha.setup('bdd');
        require(['tests'], function() {
            mocha.run();
        });
    });

}());
