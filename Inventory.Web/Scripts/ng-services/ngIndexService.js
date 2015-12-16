(function () {
    var app = angular.module("app");

    app.factory("indexService", ["$http", function ($http) {
        return {
            getInventoryItems: function () {
                return $http.get("/Alerts/GetAlertsDetail");
            },
            addInventoryItem: function (inventoryName) {
                return $http.post("/", {
                    Name: inventoryName
                });
            }
        };
    }]);
})();