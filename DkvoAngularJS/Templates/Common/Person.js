
kvApp.factory('crudServicePerson', function ($http) {
    crudPerObj = {};

    crudPerObj.getAll = function () {
        var Pers;

        Pers = $http({ method: 'Get', url: '/Person/GetPersons' }).
        then(function (response) {
            return response.data;
        });

        return Pers;
    };

    crudPerObj.getByPid = function (pid) {
        var Per;

        Per = $http({ method: 'Get', url: '/Person/Details/', params: { id: pid } }).
        then(function (response) {
            return response.data;
        });

        return Per;
    };

    crudPerObj.deleteByPid = function (pid) {
        var Per;

        Per = $http({ method: 'Post', url: '/Person/Delete/', params: { id: pid } }).
        then(function (response) {
            return response.data;
        });

        return Per;
    };

    crudPerObj.createPerson = function (per) {
        var Per;

        Per = $http({ method: 'Post', url: '/Person/Create/', data: per }).
        then(function (response) {
            return response.data;
        });

        return Per;
    };

    crudPerObj.updateEmployee = function (per) {
        var Per;

        Per = $http({ method: 'Post', url: '/Person/Edit/', data: per }).
        then(function (response) {
            return response.data;
        });

        return Per;
    };

    return crudPerObj;
});

kvApp.controller("personController", function ($scope, $http, crudServicePerson) {
    $scope.msg = "Display Person";
    $http({ method: 'Get', url: 'Person/GetPersons' })
            .then(function (response) {
                $scope.persons = response.data;
            });

    crudServicePerson.getAll().then(function (result) {
        $scope.persons = result;
    });

    $scope.CreatePerson = function (Per) {
        crudServicePerson.createPerson(Per).then(function (result) {
            $scope.Msg = result.FirstName + " Has been created successfully";

            crudServicePerson.getAll().then(function (result) {
                $scope.persons = result;
            });
        });
    };
});