trips.controller('TripsController', function($scope,$routeParams,  identity, auth, notifier,trips) {

    $scope.identity=identity;

    getTrip();
    getInfo();
    getCities();

    $scope.join= function (id) {
        trips.joinTrip(id).then(function () {
            notifier.success("You have successfully joined the trip!");
        }, function (error) {
            notifier.error("You have failed to join the trip!");
        });
    };

    function getTrip(){

        trips.getTrip($routeParams.id).then(function (data) {
            $scope.trip = data;
        });

    }
    function getCities () {
        trips.getCities().then(function (data) {
            $scope.cities=data;
        })
    }
    function getInfo() {
        auth.userInfo().then(function (user) {
            $scope.isADriver= user.isDriver;
        });
    }

});

