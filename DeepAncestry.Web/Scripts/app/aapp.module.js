var deepAncestryApp = angular.module('deepAncestryApp', ['ngRoute', 'core', 'basicSearch', 'advancedSearch', 'searchResults']);

deepAncestryApp.config(['$locationProvider', '$routeProvider',
    function config($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider.
          when('/', {
              template: '<basic-search></basic-search>'
          }).
          when('/advanced', {
              template: '<advanced-search></advanced-search>'
          }).
          otherwise('/');
    }
]);