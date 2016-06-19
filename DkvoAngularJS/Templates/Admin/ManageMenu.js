kvApp.controller("londonCtrl", function ($scope, $http) {
    $scope.msg = "I love London";
    $http({ method: 'Get', url: 'Departments/GetDepartments' })
            .then(function (response) {
                $scope.depts = response.data;
            });
});