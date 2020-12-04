/// <reference path="../testapp.js" />

app.controller("dynamicPagedListController", function ($scope, $http) {
    $scope.pageIndex = 1;
    $scope.pageSize = 5;
    $scope.searchString = "";
    $scope.pageIndexes = [5, 10, 25, 50];

    $scope.init = function () {
        $scope.builtUrl = "/api/posts";

        $scope.registerList();
    };

    $scope.registerList = function () {
        $http.get($scope.builtUrl + "/page" + $scope.pageIndex + "/size" + $scope.pageSize + "/" + $scope.searchString)
            .then(function (response) {
                $scope.registerData = response.data.ItemList;
                $scope.TotalItems = response.data.PagingInfo.TotalItems;
                $scope.TotalPages = response.data.PagingInfo.TotalPages;
            }, function (error) {
                alert('failed ' + error.data);
            });
    }

    $scope.pageChanged = function () {
        $scope.registerList();
    }

    $scope.changePageSize = function () {
        $scope.pageIndex = 1;

        $scope.registerList();
    }
});