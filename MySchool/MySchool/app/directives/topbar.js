'use strict';
app.directive('topBar', topBar);

function topBar() {
    return {
        restrict: 'E',
        replace: true,
        templateUrl: '/app/views/layout/topbar.html'
    }
}