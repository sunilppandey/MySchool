'use strict';
app.factory('booksService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var booksServiceFactory = {};

    var _getBooks = function () {

        return $http.get(serviceBase + 'api/books/books').then(function (results) {
            return results;
        });
    };

    booksServiceFactory.getBooks = _getBooks;

    return booksServiceFactory;

}]);