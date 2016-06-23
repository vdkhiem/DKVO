myApp.controller('employeeController', function ($scope,$http) {
    $scope.Msg = "This is from Employee";

$http({ method: 'Get', url: '/Employees/GetEmployees' })
            .then(function (response) {
                $scope.emps = response.data;
            });
});