(function () {
    var app = angular.module("app");

    app.controller("index", ["$scope", "indexService",
        function ($scope, indexService) {
            $scope.headerMessage = "Moravia developers test ";
            $scope.inventories = [];
            $scope.inventoryName = "";

            var validateInventoryName = function () {
                return true;
            }

            $scope.addNewInventory = function () {
                if (validateInventoryName()) {
                    indexService.addInventoryItem($scope.inventoryName);
                }
            }
        }
    ]);
})();