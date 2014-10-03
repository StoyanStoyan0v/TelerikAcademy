trips.controller('SignUpCtrl', function($scope, $location, auth, notifier) {

    $scope.signup = function(user) {

            auth.signup(user).then(function () {
                notifier.success('You have successfully registered an account!');
                $location.path('/');
            }, function () {
                notifier.error('You have failed to register an account! Invalid e-mail or password!');
            })
        }

});