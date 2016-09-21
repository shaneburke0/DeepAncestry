angular.module('core.search', ['ngResource']);
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
  ]);