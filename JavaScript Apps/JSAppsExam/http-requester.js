define(['jquery-private'], function (jq) {
    var HTTPRequester = (function () {
        function getPromise(requestURL, data, sessionKey) {
            var type, _data;
            if (data) {
                type = 'POST';
                _data = JSON.stringify(data)
            } else {

                type = 'GET';
                _data = {};

            }
            return jq.ajax({
                beforeSend: function (xhrObj) {

                        xhrObj.setRequestHeader("Content-Type", 'application/json');
                        xhrObj.setRequestHeader("Accept", 'application/json');
                    if(sessionKey){
                        xhrObj.setRequestHeader('X-SessionKey', sessionKey);
                    }

                },
                data: _data,
                url: requestURL,
                type: type
            });

        }

        function HTTPRequester() {

        }

        HTTPRequester.getJSON = function (requestURL ) {
            return getPromise(requestURL);
        };

        HTTPRequester.postJSON = function (requestURL, data, sessionKey) {
            return getPromise(requestURL,  data, sessionKey);
        };

        HTTPRequester.logout= function (requestURL, sessionKey) {
            return jq.ajax({
                beforeSend: function (xhrObj) {
                    xhrObj.setRequestHeader("Content-Type", 'application/json');
                    xhrObj.setRequestHeader("Accept", 'application/json');
                    xhrObj.setRequestHeader('X-SessionKey', sessionKey);

                },
                url: requestURL,
                type: 'PUT'
            });
        };
        return HTTPRequester;
    }());
    return HTTPRequester;
});



