"use strict";

angular.module("myApp", [
  "ngRoute",
  "myApp.suggestions"
]).
config(["$routeProvider", function ($routeProvider) {
    $routeProvider.otherwise({ redirectTo: "/suggestions" });
}]);