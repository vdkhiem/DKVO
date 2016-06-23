kvApp.factory("crudServiceLogin", function ($http) {
    crudObj = {};

    crudObj.login = function (user) {
        //alert("crudEmpObj.login");
        var User;

        User = $http({ method: 'Post', url: 'Admin/Login', data: user }).
        then(function (response) {
            return response.data;
        });

        return User;
    };

    return crudObj;
});

kvApp.controller("loginController", function ($scope, crudServiceLogin) {
    //alert("loginController");
    $scope.Login = function (User) {
        //alert(User);
        crudServiceLogin.login(User).then(function (result) {
            $scope.Msg = result.Email + " Has been login successfully";
        });
    };

});