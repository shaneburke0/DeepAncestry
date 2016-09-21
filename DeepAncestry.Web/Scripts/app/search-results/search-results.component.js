angular.module('searchResults', []);
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