'use strict';


var trips =angular.module('trips', [
  'ngRoute','ngResource','ngCookies'
]).
config(['$routeProvider', function($routeProvider,$httpProvider) {
        $routeProvider
            .when('/home',{
                templateUrl:'partials/home.html'
            })
            .when('/register', {
                templateUrl: 'partials/register.html'
            })
            .when('/login', {
                templateUrl: 'partials/login.html'
            })
            .when('/games', {
                templateUrl: 'partials/games.html'
            })
            .when('/game-in-progress/:id',{
                templateUrl:'partials/game-in-progress.html'
            })
            .when('/trips',{
                templateUrl:'partials/trips.html'
            })
            .when('/drivers',{
                templateUrl:'partials/drivers.html'
            })
            .when('/trip-details/:id',{
                templateUrl:'partials/trip-details.html'
            })
            .when('/create-trip',{
                templateUrl:'partials/create-trip.html'
            })
            .when('/driver-details/:id',{
                templateUrl:'partials/driver-details.html'
            })
            .otherwise({redirectTo: '/home'});
    }])
        .constant('baseServiceUrl','http://spa2014.bgcoder.com/');


