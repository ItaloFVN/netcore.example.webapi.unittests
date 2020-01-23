app = angular.module('app', []);

app.controller('controller',  function($scope, $http){
    $scope.nome = '';
    $scope.titulo = "Lista de nomes";
    $scope.pessoas = [];
    $scope.buscarNome = function(){
        $http({
            method: 'GET',
            url: 'https://localhost:44345/pessoas?term=' + $scope.nome
        }).then(function successo(response) {
            $scope.pessoas = response.data;
            if (response.data == 0){
                alert("Nenhum nome registrado!");
            }
        }, function erro(response) {
            alert('Erro de conexão: Codigo ' + JSON.stringify(response.status));
        });
    }
})