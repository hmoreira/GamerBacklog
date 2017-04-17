var app = angular.module('app', ['ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.pagination']);

app.controller("consultaPedidoCtrl", function ($scope, $http) {

    $http.get('/cliente/ObtemClientes/')
        .then(function (response) {
            var data = response.data;
            $scope.clientes = data;
        });

    $scope.colunasGrid =
        [{ field: 'PedidoId', name: 'Número' }, { field: 'NomeCliente', name: 'Cliente' },
         { field: 'ValorTotal', name: 'Valor Total' }];

    $scope.gridOptions = {
        enableSorting: true,
        enablePaginationControls: false,
        paginationPageSize: 10,
        columnDefs: $scope.colunasGrid,
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
            var cellTemplate = 'ui-grid/selectionRowHeader';   // you could use your own template here
            $scope.gridApi.core.addRowHeaderColumn(
                { name: 'rowHeaderCol', displayName: '', width: 30, cellTemplate: cellTemplate });
        }
    };

    $scope.gridOptions.onRegisterApi = function (gridApi) {
        $scope.gridApi2 = gridApi;
    }

    $scope.Pesquisar = function () {

        if ($scope.dataEntregaIni != null)
        {
            if ($scope.dataEntregaFim == null)
            {
                alert('Data de entrega final deve ser informada se existe data de entrega inicial');
                return;
            }
            else
            {
                if ($scope.dataEntregaFim < $scope.dataEntregaIni) {
                    alert('Data de entrega final não pode ser inferior a data inicial');
                    return;
                }
            }
        }

        $http({
            url: '/pedido/ObtemPedidos/',
            method: "GET",
            params: {
                clienteId: $scope.clienteSelected == null ? 0 : $scope.clienteSelected.ClienteId,
                dataInicial: $scope.dataEntregaIni,
                dataFinal: $scope.dataEntregaFim,
                idPedido: $scope.numeroPedido    
            }
        }).then(function (response) {
            var data = response.data;
            $scope.gridOptions.data = data;
        });
    }
});

app.controller("cadastroGameCtrl", function ($scope, $http) {

    $scope.selectedPlatforms = [];

    $http.get('/platform/ObtemPlataformas/')
        .then(function (response) {
            var data = response.data;
            $scope.platforms = data;
        });

    //$scope.Excluir = function (idx) {
    //    $scope.ValorTotal -= $scope.itens[idx].Valor;
    //    $scope.itens.splice(idx, 1);
    //}

    $scope.toggleSelection = function toggleSelection(platformId) {

        var idx = $scope.selectedPlatforms.indexOf(platformId);

        // Is currently selected
        if (idx > -1) {
            $scope.selectedPlatforms.splice(idx, 1);
        }
        else { // Is newly selected
            $scope.selectedPlatforms.push(platformId);
        }
        console.log($scope.selectedPlatforms);
    };

    $scope.desativaInclusao = function() {
        if ( ($scope.selectedPlatforms.length == 0) && ($scope.nomeGame != null)) {
            return false;
        }
    }

    $scope.Incluir = function () {

        if ($scope.selectedPlatforms.length == 0) {
            alert('O game precisa ser de pelo menos uma plataforma!');
            return;
        }

        $http.post('/game/Adicionar/',
        {
            nome: $scope.nomeGame,
            platformIds: $scope.selectedPlatforms
        }).then(function(response) {
            var data = response.data;
            alert('Game adicionado com sucesso!');
            $scope.selectedPlatforms = [];
            $scope.selectedPlatform = null;
            $scope.nomeGame = null;
        }, function (response) {
            var data = response.data;
            alert('Erro: ' + data);
            //$scope.status = response.status;
        });
    }
});