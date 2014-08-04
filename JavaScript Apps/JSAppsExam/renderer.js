define(['requester','jquery-private','crypto'],function (HTTPRequester,jq) {
    var Renderer = (function () {

        var $body=jq('body'),
            successMessage=jq('<div/>').addClass('msg-container').addClass ('success-msg'),
            errorMessage=jq('<div/>').addClass('msg-container').addClass ('error-msg'),
            chatContainer=jq('<div/>').addClass('chat-container'),
            userName=jq('<input/>').addClass('name-input'),
            userPassword=jq('<input/>').addClass('password-input'),
            logInBtn=jq('<button/>').addClass('login-btn').html('Log in').click(function () {
                logIn();
            }),
            registerBtn=jq('<button/>').addClass('reg-btm').html('Register').click(function () {
                register();
            }),
            logOutBtn=jq('<button/>').addClass('logOutBtn').html('Log out').click(function () {
                logOut();
            }),
            titleInput=jq('<input/>'),
            textInput=jq('<input/>'),
            postBtn=jq('<button/>').html('Post'),
            loggedView=jq('<div/>').addClass('logged'),
            notLoggedView=jq('<div/>').addClass('not-logged'),
            sessionKeyKeep='';

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
			   authCode:userPassword.val()
               //authCode: CryptoJS.SHA1(userName.val()+ userPassword.val()).toString()
           };

            HTTPRequester.postJSON('http://localhost:3000/user',user).then(
                function (data) {
                    successMessage.html('You have registered successfully').show().delay(2000).fadeOut(2000);
                    logged=data.body;
                    logIn();
                },
                function (error) {
                    errorMessage.html(error.message).show().delay(2000).fadeOut(2000);
                }
            );
        }

        function logIn(){
            var user= {
                username: userName.val(),
				authCode:userPassword.val()
                //authCode: CryptoJS.SHA1(userName.val()+ userPassword.val()).toString()
            };
            HTTPRequester.postJSON('http://localhost:3000/auth',user).then(
                function (data) {
                    sessionKeyKeep=data.sessionKey;
                    initializePage(data);
                },
                function(error){
                    errorMessage.html(error.message).show().delay(2000).fadeOut(2000);
                }
            );
        }

        function logOut(){
            HTTPRequester.logout('http://localhost:3000/user',sessionKeyKeep).then(
                function (data) {
                    successMessage.html('You have logged out successfully').show().delay(2000).fadeOut(2000);
                },
                function(error){
                    errorMessage.html(error.responseText).show().delay(2000).fadeOut(2000);
                }
            );
            initializePage();
        }

        function initializePage(data){
            $body.html('');
            if(data) {
                loggedView.append(jq('<span/>').html('Hello, '+data.username +' !')).append(logOutBtn).append(jq('<br/>'));
                loggedView.append(jq('<span>').html('Title: ')).append(titleInput).append(jq('<br/>'))
                    .append(jq('<span>').html('Text: '))
                    .append(textInput).append(postBtn.click(function () {

                    var post = {
                        title: titleInput.val(),
                        body: textInput.val()
                    };
                    HTTPRequester.postJSON('http://localhost:3000/post', post, sessionKeyKeep)
                        .then(function () {
                            successMessage.html('You have posted you message successfully').show().delay(2000).fadeOut(2000);
                            loadItems('http://localhost:3000/post')
                        }, function (error) {
                            errorMessage.html('You have failed to post your message.').show().delay(2000).fadeOut(2000);
                        });
                }));
                jq($body).append(loggedView)
            }else {
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
            var $filterName=jq('<input>').addClass('filter'),
                $filterPatter=jq('<input>').addClass('filter'),
                $filterBtn=jq('<button/>').html('Filter');
            $body.append(jq('<span/>').html('Name: ')).append($filterName).append(jq('<span/>').html('Pattern: ')).append($filterPatter).append($filterBtn);

            jq($filterBtn).click( function () {
                var specificUrl='http://localhost:3000/post?';

                if($filterName.val()!=='' && $filterPatter.val() !=='') {
                    specificUrl+='pattern= '+$filterPatter.val().trim().replace(/\s+/g,'%20')
                        .substr(2)+'&user='+$filterName.val().trim().replace(/\s/g,'%20');
                }else if($filterName.val()!==''){
                    specificUrl+='&user='+$filterName.val().trim().replace(/\s/g,'%20');
                }
                else if($filterPatter.val()!==''){
                    specificUrl+='pattern= '+$filterPatter.val().trim().replace(/\s/g,'%20');
                }

                loadItems(specificUrl);
            });
            jq($body).append(chatContainer);
        }

        function renderItems(data) {
            chatContainer.html('');
            successMessage.html('Messages successfully loaded!').show().delay(2000).fadeOut(2000);
            console.log(data);
            var users = data;
            for (var i = 0; i < users.length; i++) {
                var $div=jq('<div/>').addClass('msg');
                $div.append($div.clone().html('Title: '+users[i].title))
                    .append($div.clone().html('Text: '+users[i].body))
                    .append($div.clone().html('Name: '+users[i].user.username))
                    .append($div.clone().html('Date: '+users[i].postDate));
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

