

var app = angular
.module('modAssessment', [])
.controller('AssessmentCtrl', function ($scope, $http) {

    
    $http.get("/Assessment/GetManager_Employees")
    .success(function (data) {
        $scope.Employees = [];
        var jsonComp = JSON.stringify(data);
        jsonComp = jQuery.parseJSON(jsonComp);
        $scope.Employees = jsonComp;
    });

    $scope.GetEmployeeCompetencies = function (employeeID) {
        if (employeeID == '')
            employeeID = 0;
        $http.get("/Assessment/GetEmployeeCompetencies?EmployeeID=" + employeeID)
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.employeeCompetencies = data;
            });
    };
    
})
.directive('selectWatcher', function ($timeout) {
  
    return {
        link: function (scope, element, attr) {
            var last = attr.last;
            if (last === "true") {
                $timeout(function () {
                    $(element).parent().selectpicker('val', '');
                    $(element).parent().selectpicker('refresh');
                });
            }
        }
    };
});