var app = angular
.module('AssessmentsDueApp', [])
.controller('AssessmentsDueCtrl', function ($scope, $http)
{
    $scope.GetAssessorAssessments = function () {
        $scope.Assessments = [];
        $http.get("/EmployeeSnapshot/GetAssessorAssessments")
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                console.log(jsonComp);
                $scope.Assessments = jsonComp;
            });
    }

    $scope.GetAssessorAssessments();
    $scope.grouping = { groupedColumns: ["Name"], showToggleButton: true, showDropArea: false };
})