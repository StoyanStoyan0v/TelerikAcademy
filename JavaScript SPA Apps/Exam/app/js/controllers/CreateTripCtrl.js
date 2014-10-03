trips.controller('CreateTripCtrl', function($scope,$location,  notifier,trips) {

    getCities();

    $scope.create = function (trip,createForm) {
        if(createForm.$valid) {
            trips.createTrip(trip).then(function () {
                    notifier.success('Trip successfully created!');
                }
            )
        }
    };
    function getCities () {
        trips.getCities().then(function (data) {
            $scope.cities=data;
        })
    }
    $scope.cancel = function() {
        $location.path('/home');
    }
});

