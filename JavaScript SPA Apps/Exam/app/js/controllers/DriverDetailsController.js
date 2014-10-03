trips.controller('DriverDetailsCtrl', function($scope,$location,$routeParams, notifier,drivers) {

    $scope.sort = 'from';

    getDriver();

    function getDriver () {
        drivers.getDriver($routeParams.id).then(function (data) {
            $scope.driver=data;
        })
    }
});

