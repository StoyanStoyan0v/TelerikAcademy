define(['requester','jquery-private','crypto'],function (HTTPRequester,jq) {
    var Renderer = (function () {

        var $body=jq('body'),
            successMessage=jq('<div/>').addClass('msg-container').addClass ('success-msg'),
            errorMessage=jq('<div/>').addClass('msg-container').addClass ('error-msg'),
            chatContainer=jq('<div/>').addClass('chat-container'),
            userName=jq('<input/>').addClass('name-input'),
            userPassword=jq('<input/>').attr('type','password').addClass('password-input'),
            logInBtn,
            registerBtn,
            logOutBtn,
            textInput=jq('<input/>'),
            postBtn=jq('<button/>').html('Post'),
            loggedView=jq('<div/>').addClass('logged'),
            notLoggedView=jq('<div/>').addClass('not-logged');

        function Renderer() {


        }

        function register() {
            if(6>userName.val().length || userName.val().length>40){
                successMessage.html('Username must be between 6 and 40 characters.').show().delay(2000).fadeOut(2000);
                return;
            }
            if(6>userPassword.val().length || userPassword.val().length>40){
                successMessage.html('Password must be between 5 and 10 characters.').show().delay(2000).fadeOut(2000);
                return;
            }
           var user= {
               username: userName.val(),
               authCode: CryptoJS.SHA1(userName.val()+ userPassword.val()).toString()
           };

            HTTPRequester.postJSON('http://localhost:3000/user',user).then(
                function (data) {
                    logIn();
                },
                function (error) {
                    errorMessage.html(error.message).show().delay(2000).fadeOut(2000);
                }
            );
        }

        function logIn() {

            var user = {
                username: userName.val(),
                authCode: CryptoJS.SHA1(userName.val() + userPassword.val()).toString()
            };
            HTTPRequester.postJSON('http://localhost:3000/auth', user).then(
                function (data) {
                    localStorage.setItem('user', data.username);
                    localStorage.setItem('sessionKey',data.sessionKey);
                    initializePage(data);
                },
                function (error) {
                    errorMessage.html('Invalid username or password').show().delay(2000).fadeOut(2000);
                }
            );
        }

        function logOut(){
            HTTPRequester.logout('http://localhost:3000/user',localStorage['sessionKey']).then(
                function (data) {
                    localStorage.clear();
                    successMessage.html('You have logged out successfully').show().delay(2000).fadeOut(2000);
                    initializePage();
                },
                function(error){
                    errorMessage.html(error.responseText).show().delay(2000).fadeOut(2000);
                }
            );

        }

        function initializePage(data) {
            logInBtn=jq('<button/>').addClass('login-btn').html('Log in').click(function () {
                logIn();
            });
            registerBtn=jq('<button/>').addClass('reg-btm').html('Register').click(function () {
                register();
            });
            logOutBtn=jq('<button/>').addClass('logOutBtn').css('margin','10px').html('Log out').click(function () {
                logOut();
            });
            $body.html('');
            loggedView.html('');
            notLoggedView.html('');
            if (data || localStorage['sessionKey']) {
                loggedView.append(jq('<span/>').html('Hello, <b>' + localStorage['user'] + '<b/> !'))
                    .append(logOutBtn).append(jq('<br/>'));
                loggedView.append(jq('<span>').html('Text: '))
                    .append(textInput).append(postBtn.click(function () {
                        var post = {
                            title: Math.random().toString(),
                            body: textInput.val()
                        };

                        HTTPRequester.postJSON('http://localhost:3000/post', post, localStorage['sessionKey'])
                            .then(function () {
                                successMessage.html('You have posted you message successfully').show().delay(2000).fadeOut(2000);
                                loadItems('http://localhost:3000/post')
                            }, function (error) {
                                errorMessage.html('You have failed to post your message.').show().delay(2000).fadeOut(2000);
                            });
                    }));
                jq($body).append(loggedView)
            } else {
                notLoggedView.append(jq('<span/>').html('Username: ')).append(userName).append(jq('<br/>'))
                    .append(jq('<span/>').html('Password: '))
                    .append(userPassword)
                    .append(jq('<br/>'))
                    .append(registerBtn)
                    .append(logInBtn);

                jq($body).append(notLoggedView);

            }
            jq($body).append(successMessage);
            jq($body).append(errorMessage);
            $body.append(jq('<br/>'));
            jq($body).append(chatContainer);
        }

        function renderItems(data) {
            chatContainer.html('');
            chatContainer.append(jq('<h2/>').text('Chat'));
            successMessage.html('Messages successfully loaded!').show().delay(2000).fadeOut(2000);
            var users = data;
            for (var i = 0; i < users.length; i++) {
                var $div=jq('<div/>').addClass('msg');
                $div.append($div.clone().html('Text: '+users[i].body))
                    .append($div.clone().html('Posted by '+users[i].user.username + ' on '+ users[i].postDate.substr(0,19)
                        .replace('T',' ')));
                chatContainer.append($div);
            }
        }

        function loadItems(url) {
            HTTPRequester.getJSON(url)
                .then(function (data) {
                    renderItems(data);
                }, function (error) {
                    successMessage.html('Messages failed to load!').show().delay(2000).fadeOut(2000);
                });
        }
        Renderer.loadPage= function (url) {
            initializePage();
            loadItems(url);
        };
        return Renderer;
    }());
    return Renderer;
});

