trips.controller('LoginCtrl', function($scope, $location, $rootScope,notifier, identity,auth) {


    $scope.login = function (user) {
        auth.login(user).then(function (response) {
            if (response) {
                notifier.success('You have successfully logged in!');
                $location.path('/');
            }
            else {
                notifier.error('Invalid username and/or password');
            }
        }, function () {
            notifier.error('Invalid username and/or password');
        });
    };
    $scope.logout = function() {
        auth.logout().then(function() {
            notifier.success('Successful logout!');
            if ($scope.user) {
                $scope.user.email = '';
                $scope.user.username = '';
                $scope.user.password = '';
            }
            $location.path('/');
        })
    }
});