var app = angular
.module('AssessmentsDueApp', ['ejangular'])
.controller('AssessmentsDueCtrl', function ($scope, $http, $rootScope)
{
    
    $scope.AssessmentID = 0;
 
    $scope.grouping = { };
    //$scope.shipdetails = [
    //                    { Name: 'Hanari Carnes', City: 'Brazil' },
    //                    { Name: 'Split Rail Beer & Ale', City: 'USA' },
    //                    { Name: 'Ricardo Adocicados', City: 'Brazil' }
    //];

    $scope.GetAssessorAssessments = function (employeeId) {
        alert('adf');
        console.log('mad');
        console.log(employeeId);
       
        $scope.Assessments = [{Name: '', Description:'', DateDue:'', DefinedBy:'', Recurrence:'' }];
        $http.get("/EmployeeSnapshot/GetAssessorAssessments?selectedEmployeeID=" + employeeId)
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                
                //console.log(jsonComp);
                $scope.Assessments = jsonComp;
                $scope.grouping = { groupedColumns: ["Name"], showToggleButton: false, showDropArea: false };
            });
    }

   // $scope.GetAssessorAssessments('709');

    $scope.onClick = function (args) {
        var gridObj = $("#Grid").data("ejGrid");
        //getting corresponding record EmployeeID value            
        var employeeID = gridObj.getSelectedRecords()[0].EmployeeID;
     
        var compDefHeaderID = gridObj.getSelectedRecords()[0].CompetencyDefHeaderID;
        $http.get("/EmployeeSnapshot/EmployeeAssessedWithin24Hours?EmployeeID=" + employeeID + "&CompDefHeaderID=" + compDefHeaderID)
           .success(function (data) {
               var jsonComp = JSON.stringify(data.toLowerCase());
               jsonComp = JSON.parse(jsonComp) == 'true';
               console.log('json' + jsonComp);
               
               if (jsonComp)
               {
                   $scope.CreateEmployeeAssessment(compDefHeaderID, employeeID, $scope);
               }
               else
               {
                   swal("The employee has already been assessed for this Competency in the last 24 Hours.", "If the employee needs to be assessed again, try again after 24 hours.", "error");
               }
               
           });


        

    }
    $scope.command = [{
        type: "start", buttonOptions: {
            text: "Start",
            width: "100",
            click: $scope.onClick
        }
    }];

    $scope.CreateEmployeeAssessment = function (compDefHeaderID, employeeID, $scope) {
        $http.get("/Assessment/CreateEmployeeAssessment?compDefHeaderID=" + compDefHeaderID + "&EmployeeID=" + employeeID)
          .success(function (data) {
              $scope.AssessmentID = data;
              location.href = 'Assessment.aspx?CompDefHeaderID=' + compDefHeaderID + '&employeeID=' + employeeID + "&CompAssessmentID=" + $scope.AssessmentID;
          });
    }

    $scope.GetAssessorAssessments = function (employeeId) {
        console.log(employeeId);
       // $scope.Assessments = [{ Name: '', Description: '', DateDue: '', DefinedBy: '', Recurrence: '' }];
        $scope.Assessments = [];
        console.log($scope.Assessments);
        
        $http.get("/EmployeeSnapshot/GetAssessorAssessments?selectedEmployeeID=" + employeeId)
            .success(function (data) {
                console.log('success');
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
             
                $scope.Assessments = jsonComp;
                console.log($scope.Assessments);

                $scope.grouping = { groupedColumns: ["Name"], showToggleButton: true, showDropArea: false };
            })
        .error(function (data, status) {
            console.error('Repos error', status, data);
        });
        console.log('probl');
    }
    
})