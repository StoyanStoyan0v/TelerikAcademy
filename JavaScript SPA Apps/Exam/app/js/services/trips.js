trips.factory('trips', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function($http, $q, identity, authorization, baseServiceUrl) {
    var tripsApi = baseServiceUrl+'api/trips';

    return {
        getTrips: function () {
            var deferred = $q.defer();
            $http.get(tripsApi, {
                headers: {'Content-Type': 'application/x-www-form-urlencoded'}
            })
                .success(function (data) {
                    deferred.resolve(data);
                }, function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        getTrip: function (id) {
            var deferred = $q.defer();

            $http.get(tripsApi + '/' + id, {
                headers: authorization.getAuthorizationHeader()
            })
                .success(function (data) {
                    deferred.resolve(data);
                }, function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        joinTrip: function (id) {
            var deferred = $q.defer();
            $http.defaults.headers.put = authorization.getAuthorizationHeader();
            $http.put(tripsApi + '/' + id, {}, {
                headers: authorization.getAuthorizationHeader()
            })
                .success(function (data) {
                    deferred.resolve(data);
                }).error( function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        createTrip: function (trip) {
            var deferred = $q.defer();
            console.log(trip);
            $http.post(tripsApi, trip, {

                headers: authorization.getAuthorizationHeader()
            })
             .success(function (data) {
                    deferred.resolve(data);
                }).error(function (response) {
                    console.log(response);
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        getCities: function () {
            var deferred = $q.defer();

            $http.get(baseServiceUrl + 'api/cities')
                .success(function (data) {
                    deferred.resolve(data);
                }, function (response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }
    }
}]);

