'use strict';
app.controller('booksController', ['$scope', 'booksService', function ($scope, booksService) {

    $scope.orders = [];

    booksService.getBooks().then(function (results) {

        $scope.books = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);