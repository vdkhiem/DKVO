var myApp = angular.module("myApp", ['ngRoute']);

myApp.config(function ($routeProvider) {
    $routeProvider.when('/Department', {
        templateUrl: 'Templates/Admin/Department/Department.html',
        controller: 'departmentController'
    });
    $routeProvider.when('/Employee', {
        templateUrl: 'Templates/Admin/Employee/Employee.html',
        controller: 'employeeController'
    });
    $routeProvider.otherwise({
        redirectTo: '/'
    });
});
