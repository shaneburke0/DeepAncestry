angular.module('basicSearch', ['core.search']);
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
  });