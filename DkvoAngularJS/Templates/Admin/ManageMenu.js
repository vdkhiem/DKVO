kvApp.controller("londonCtrl", function ($scope, $http) {    
    $scope.msg = "I love London";
    $http({ method: 'Get', url: 'Admin/GetMenus' })
            .then(function (response) {
                $scope.menus = response.data;
            });
});