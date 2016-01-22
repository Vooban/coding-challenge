(function () {

    var app = angular.module('suggestionApp.main');

    //Declaring the Controller
    app.controller('suggestionController', function ($scope, suggestionAppService) {
        $scope.Criteria = "q"; //The Object used for selecting value
        $scope.filterValue = ""; //The object used to read value entered into textbox for filtering information from table

        //loadSuggestions();

        //Function  to Load all Suggestions
        function loadSuggestions() {
            var promise = suggestionAppService.getSuggestions();
            promise.then(function (resp) {
                $scope.Suggestions = resp.data;
                $scope.Message = "Call is Completed Successfully";
            }, function (err) {
                $scope.Suggestions = null;
                $scope.Message = "Call Failed " + err.status;
            });
        };

        //Function to Load Suggestions based on criteria
        $scope.getFilteredData = function () {
            if ($scope.filterValue != null) {
                //Trigger the service only after 3 characters
                if ($scope.filterValue.length >= 3) {
                    var promise = suggestionAppService.getFilteredData($scope.Criteria, $scope.filterValue);
                    promise.then(function (resp) {
                        $scope.Suggestions = resp.data;
                        $scope.Message = "Call is Completed Successfully";
                    }, function (err) {
                        //Clear the results
                        $scope.Suggestions = null;
                        $scope.Message = "Call Failed " + err.status;
                    });
                }
                else {
                    //Clear the results
                    $scope.Suggestions = null;
                    $scope.Message = "Call Failed " + err.status;
                }
            }
            else {
                //Clear the results
                $scope.Suggestions = null;
                $scope.Message = "Call Failed " + err.status;
            }
        };
    });

})();