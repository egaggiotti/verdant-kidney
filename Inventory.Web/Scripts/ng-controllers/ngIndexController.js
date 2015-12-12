var app = angular.module("app", []);

    app.controller("index", ["$scope", function ($scope) {
        $scope.headerMessage = "Moravia developers test ";
    }]);