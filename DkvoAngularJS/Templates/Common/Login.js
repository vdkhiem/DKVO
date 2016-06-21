kvApp.factory('crudServiceLogin', function ($http) {
    crudObj = {};

    crudEmpObj.login = function (user) {
        var User;

        User = $http({ method: 'Post', url: '/Admin/Login/', data: user }).
        then(function (response) {
            return response.data;
        });

        return User;
    };

    return crudObj;
});

kvApp.controller("loginController", function ($scope, crudServiceLogin) {

    $scope.Login = function (User) {
        crudServiceLogin.login(User).then(function (result) {
            $scope.Msg = result.Email + " Has been login successfully";
        });
    };

});