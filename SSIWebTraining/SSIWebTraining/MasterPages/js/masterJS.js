
var app = angular
.module('modTrainingMPage', [])
 
.controller('TrainingMPageCtrl', function ($scope, $http, $location, updateTaskComp, FinalizeCompetency, updatePercent) {
    if (typeof $location.search().mobile !== 'undefined') {
        //decide if toolbar needed
    }
})