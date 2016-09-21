angular.module('advancedSearch', ['core.search']);
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
  });