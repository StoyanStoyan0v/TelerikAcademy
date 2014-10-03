trips.controller('DriversController', function($scope, $location, identity, drivers) {
    $scope.identity=identity;

    $scope.up= function () {
        page++;
    };
    $scope.down= function () {
        if(page>0) {
            page--;
        }
    };
});

