trips.controller('HomePageController', function($scope, $location, identity, auth, notifier,trips,drivers,stats) {
    $scope.identity=identity;

    getTrips();
    getDrivers();
    getStats();

    $scope.logout =function(){
        auth.logout();
        notifier.success('You have logged out successfully!');
        identity.setCurrentUser(undefined);

        $location.path('/');
    };

    function getTrips() {
        trips.getTrips().then(function (data) {
            $scope.allTrips=data;
        });
    }

    function getDrivers() {
        drivers.getDrivers().then(function (data) {
            $scope.allDrivers=data;
        });
    }

    function getStats(){
        stats.getStats().then(function (data) {
            $scope.stats=data;
        })
    }

});
