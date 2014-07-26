define(['sammy','requester','jquery-private'],function (Sammy,HTTPRequester,jq) {
    var Controller = function (element, url) {
        function renderMsg(msg) {
            return jq('<div/>')
                .addClass('message-box')
                .append(jq('<div/>').addClass('msg').html(msg.text))
                .append(jq('<div/>').addClass('by').html('by ' + msg.by));
        }

        var reloadMessages = function (url, header) {
            HTTPRequester.getJSON(url, header).then(function (data) {
                var chatList = jq('<div/>');
                for (var i = 0; i < data.length; i++) {
                    chatList.prepend(renderMsg(data[i]));
                }
                jq(element).html(chatList);
            });

        };

        var sendMessage = function (url, header, data) {

            HTTPRequester.postJSON(url, header, data).then(function () {
                jq('#msg').val('');
            }, function (error) {
                jq('body').html(error.responseText);
            });
        };

        function sendData() {
            var msg = {
                user: jq('#name').val() || 'Unnamed',
                text: jq('#msg').val()

            };
            sendMessage(url, "application/json", msg);
            reloadMessages(url, "application/json");
        }

        return Sammy(element, function () {
            this.get('#/index', function () {
                setInterval(function () {
                    reloadMessages(url, "application/json");
                }, 1000);

                jq('#send-btn').click(function () {
                    sendData();
                });
                jq('#msg').on('keydown', function (e) {
                    if (e.keyCode === 13) {
                        sendData();
                    }
                });
            });
        });

    };
    return Controller;
});
