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
]);angular.module('advancedSearch', ['core.search']);
angular.
  module('advancedSearch').
  component('advancedSearch', {
      templateUrl: '/Scripts/app/advanced-search/advanced-search.template.html',
      controller: ['Search',
        function AdvancedSearchController(Search) {
            var self = this;
            self.results = [];

            self.search = function (name, male, female, direction) {
                var gender = "";

                if (male === true && female !== true) {
                    gender = "male";
                } else if (female === true && male !== true) {
                    gender = "female";
                }

                Search.post({ name: name, gender: gender, direction: direction }, function (list) {
                    self.results = list;
                });
            }
        }
      ]
  });angular.module('basicSearch', ['core.search']);
angular.
  module('basicSearch').
  component('basicSearch', {
      templateUrl: '/Scripts/app/basic-search/basic-search.template.html',
      controller: ['Search',
        function BasicSearchController(Search) {
            var self = this;
            self.results = [];

            self.search = function (name, male, female) {
                var gender = "";

                if (male === true && female !== true) {
                    gender = "male";
                } else if (female === true && male !== true) {
                    gender = "female";
                }

                Search.get({ name: name, gender: gender }, function (list) {
                    self.results = list;
                });
            }
        }
      ]
  });angular.module('core', ['core.search']);angular.module('core.search', ['ngResource']);
angular.
  module('core.search').
  factory('Search', ['$resource',
    function ($resource) {
        return $resource('/api/search?name=:name&gender=:gender&direction=:direction', { }, {
            get: {
                method: 'GET',
                isArray: true
            },
            post: {
                method: 'POST',
                params: { name: "", gender:"", direction: "" },
                isArray: true
            }
        });
    }
  ]);angular.module('searchResults', []);
angular.
  module('searchResults').
  component('searchResults', {
      bindings: {
          data: '@'
      },
      templateUrl: '/Scripts/app/search-results/search-results.template.html',
      controller: ['$scope',
        function SearchResultsController($scope) {
            var self = this;

            self.list = data;
        }
      ]
  });