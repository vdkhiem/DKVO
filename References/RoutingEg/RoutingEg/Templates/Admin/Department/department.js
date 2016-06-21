myApp.controller('departmentController', function ($scope, $http) {
    $scope.Msg = "This is from Department";

    $http({ method: 'Get', url:'/Departments/GetDepartments' })
                .then(function (response) {
                    $scope.depts = response.data;
                });
});