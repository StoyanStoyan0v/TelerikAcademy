'use strict';

trips.factory('auth', ['$http', '$q', 'identity', 'authorization', 'baseServiceUrl', function($http, $q, identity, authorization, baseServiceUrl) {
    var usersApi = baseServiceUrl+'api/users';

    return {
        signup: function(user) {
            var deferred = $q.defer();

            $http.post(usersApi + '/Register', user)
                .success(function() {
                    deferred.resolve();
                }, function(response) {
                    deferred.reject(response);
                });

            return deferred.promise;
        },
        login: function(user){
            var deferred = $q.defer();
            $http.post(usersApi + '/Login', 'username=' + user.username + '&password=' + user.password + '&grant_type=password',
                {
                    headers: {'Content-Type': 'application/x-www-form-urlencoded'}
                })
                .success(function(response) {
                    if (response["access_token"]) {
                        identity.setCurrentUser(response);
                        console.log( identity.isAuthenticated());
                        deferred.resolve(true);
                    }
                    else {
                        deferred.resolve(false);
                    }
                });

            return deferred.promise;
        },
        userInfo: function () {
            var deferred = $q.defer();

            $http.get(usersApi + '/userInfo', { headers: authorization.getAuthorizationHeader() })
                .success(function(data) {
                    deferred.resolve(data);
                });
            return deferred.promise;
        },
        logout: function() {
            var deferred = $q.defer();

            var headers = authorization.getAuthorizationHeader();
            $http.post(usersApi + '/Logout', {}, { headers: headers })
                .success(function() {
                    identity.setCurrentUser(undefined);
                    deferred.resolve();
                });
            identity.setCurrentUser(undefined);
            return deferred.promise;
        },
        isAuthenticated: function() {
            if (identity.isAuthenticated()) {
                return true;
            }
            else {
                return $q.reject('not authorized');
            }
        }
    }
}]);