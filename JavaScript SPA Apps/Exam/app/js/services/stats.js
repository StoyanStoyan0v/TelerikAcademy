trips.factory('stats', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function($http, $q,  authorization, baseServiceUrl) {
    var statsApi = baseServiceUrl+'api/stats';

    return {

        getStats: function () {
            var deferred = $q.defer();
            $http.get('http://spa2014.bgcoder.com/api/stats',{
                headers:{'Content-Type':'application/x-www-form-urlencoded'}
            })
                .success(function(data) {
                    deferred.resolve(data);
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        }
    }
}]);
