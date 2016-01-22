(function () {

var app = angular.module('suggestionApp.main');
   
    //Declaring Service
    app.service('suggestionAppService', function ($http) {
        //The function to read all Suggestions
        this.getSuggestions = function () {
            var res = $http.get("/suggestions/GetAllSuggestions");
            return res;
        };
        //The function to read Suggestions based on filter and its value
        //The function reads all records if value is not entered
        //Else based on the filter and its value, the Suggestions will be returned
        this.getFilteredData = function (filter, value) {
            var res;
            if (value.length == 0) {
                res = $http.get("/suggestions");
                return res;
            } else {
                res = $http.get("/suggestions?" + filter + "=" + value);
                return res;
            }
        };
    });
})();