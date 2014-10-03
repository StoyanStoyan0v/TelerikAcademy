trips.factory('drivers', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function($http, $q, identity, authorization, baseServiceUrl) {
    var driversApi = baseServiceUrl+'api/drivers';

    return {

        getDrivers: function () {
            var deferred = $q.defer();
            $http.get(driversApi,{
                headers:{'Content-Type':'application/x-www-form-urlencoded'}
            })
                .success(function(data) {
                    deferred.resolve(data);
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        getDriver: function (id) {
            var deferred = $q.defer();

            $http.get(driversApi+'/'+id,{
                headers:authorization.getAuthorizationHeader()
            })
                .success(function(data) {
                    deferred.resolve(data);
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        getDriverByPage: function (name,page) {

        },
        getDriverByPageAndUsername: function (page) {
            
        }
    }
}]);