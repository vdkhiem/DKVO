kvApp.factory("crudServiceLogin", function ($http) {
    crudObj = {};

    crudObj.login = function (user) {
        var User;

        User = $http({ method: 'Post', url: 'Admin/Login', data: user }).
        then(function (response) {            
            return response.data;
        });

        return User;
    };

    crudObj.register = function (user) {        
        var User;

        User = $http({ method: 'Post', url: 'Admin/Register', data: user }).
        then(function (response) {
            return response.data;
        });

        return User;
    };

    crudObj.signout = function (user) {
        var User;

        User = $http({ method: 'Post', url: 'Admin/SignOut'}).
        then(function (response) {
            return response.data;
        });

        return User;
    };

    return crudObj;
});

kvApp.controller("loginController", function ($scope, $rootScope, $sessionStorage, $location, crudServiceLogin) {

    // To check user has been logined to the system.
    if ($sessionStorage.SessionLoginedUser != null) {
        $rootScope.LoginedUser = $sessionStorage.SessionLoginedUser;
        $location.path("/kvApp.html");
        $window.location = "#";
        return;
    }

    $scope.Login = function (User) {
        crudServiceLogin.login(User).then(function (result) {
            if (result.IsSignedIn) {
                $scope.Msg = result.Email + " Has been login successfully.";
                $rootScope.LoginedUser = result;
                $sessionStorage.SessionLoginedUser = result;
                $location.path("/kvApp.html");
            } else {
                $scope.Msg = "Wrong user name or password";
            }
        });
    };

    $scope.Register = function (User) {
        crudServiceLogin.register(User).then(function (result) {
            if (result.ErrorMessage != null && result.ErrorMessage == "") {
                $scope.Msg = result.Email + " Has been created successfully.";
                $location.path("Login");
            } else {
                $scope.Msg = result.ErrorMessage;
            }
        });
    };

    $scope.SignOut = function () {
        crudServiceLogin.signout().then(function (result) {
            delete $sessionStorage.SessionLoginedUser;
            $rootScope.LoginedUser = null;
            $location.path("/kvApp.html");
        });
    };


});

kvApp.controller("logoutController", function ($scope, $rootScope, $sessionStorage, $location, crudServiceLogin) {
    $scope.SignOut = function () {
        crudServiceLogin.signout().then(function (result) {
            delete $sessionStorage.SessionLoginedUser;
            $rootScope.LoginedUser = null;
            $location.path("/kvApp.html");
        });
    };
});