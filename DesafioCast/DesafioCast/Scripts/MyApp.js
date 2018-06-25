var myApp = angular.module('myApp', []);

myApp.controller('myCtrl', function ($scope, $http) {

    $scope.pessoa = "";



    $scope.Listar = function()
    {
        $http.get("http://localhost:50702/Pessoa/Getpessoa")
            .success(function (result) {
                $scope.pessoa = result;
                console.log("ok");
            })
        .error(function (error) {
            console.log(error);
        });
    }


    $scope.AddPessoa = function (pessoa)
    {
        $http.post("/Pessoa/AddPessoa", { value: pessoa })
            .success(function (result) {
                $scope.pessoa = result;
            })
        .error(function (error) {
            console.log(error);
        });

    }




});
