angular
    .module("umbraco")
    .controller(
        "perplexFlexController",
        function perplexFlexController($scope) {
            $scope.model.value = $scope.model.value || {};
        }
    );
