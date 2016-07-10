var kvApp = angular.module("kvApp", ["ngRoute", "ngStorage"]);

// Occurs when application start
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
    .when("/Login", {
        templateUrl: "Templates/Common/Login.html",
        controller: "loginController"
    })
    .when("/Register", {
        templateUrl: "Templates/Common/Register.html",
        controller: "loginController"
    })
    .otherwise({
        template: "<h1>Welcome to rubic 2016</h1>",
        controller: "homeCtroller"
    });
});

// Occurs when application is refresh
// $rootScrope is global variable
kvApp.run(function ($rootScope) {
    $rootScope.LoginedUser = null;

});

kvApp.controller("homeController", function ($scope, $http) {
    $scope.msg = "Welcome Dkvo";
    $http({ method: 'Get', url: 'Admin/GetAppMenus' })
        .then(function (response) {
            $scope.appMenus = response.data;
        });

    $scope.isBaseParentId = function (menu) {
        return menu.BaseParentId == null;
    };

});







