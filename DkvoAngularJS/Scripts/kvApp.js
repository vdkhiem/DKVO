var kvApp = angular.module("kvApp", ["ngRoute"]);

kvApp.controller("homeController", function ($scope, $http) {
    $scope.msg = "Welcome Dkvo";
    $http({ method: 'Get', url: 'Admin/GetAppMenus' })
            .then(function (response) {
                alert(response.data);
                $scope.appMenus = response.data;
            });

});

kvApp.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "main.htm",
    })
    .when("/ManageMenu", {
        templateUrl: "Templates/Admin/ManageMenu.html",
        controller: "londonCtrl"
    })
    .when("/paris", {
        templateUrl: "paris.htm",
        controller: "parisCtrl"
    })
    .otherwise({
        template: "<h1>None</h1><p>Nothing has been selected,</p>",
        controller: "homeCtroller"
    });
});




