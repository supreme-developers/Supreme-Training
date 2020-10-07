var app = angular
.module('AssessorApp', ['ui.bootstrap', 'ui', 'ngDialog'])
.controller('AssessorCtrl', function ($scope, $http, Assign, Unassign, $rootScope, ngDialog, $timeout, AddNewAssesor, DeleteAssessor) {
    $scope.employeeSelected = false;
    $scope.$on('LOAD', function () { $scope.loading = true;  });
    $scope.$on('UNLOAD', function () { $scope.loading = false; });

    $scope.selectedAssessor = [];
    $scope.selectedEmployee = [];
    $scope.getAssessors = function () {
        $scope.assessors = []; //This ensures assessors will refresh everytime
        $http.get("/Assessor/GetAssessors")
            .success(function (data) {               
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.assessors = jsonComp;
            });
    }
    $scope.getEmployees = function () {
        $scope.employees = []; //This ensures assessors will refresh everytime
        $http.get("/Assessor/GetEmployees")
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.employees = jsonComp;
            });
    }
    $scope.jobroles = [];
    $scope.jobresps = [];
    $scope.jobtitles = [];
    $scope.manageAssignment = function (roleID, object, type) {
        //assign or unassign
        if (object.Selected)
            Assign.AssigntoDB(roleID, type, $scope);
        else
            Unassign.UnassigntoDB(roleID, type, $scope);
    }


    $scope.loadAllObjects = function (employeeID) {
        console.log(employeeID);
        $scope.selectedAssessor = employeeID;
        $scope.employeeSelected = true;
        $scope.getJobRoles();
        $scope.getJobTitles();
        $scope.getJobResps();
       
    }

    $scope.getJobRoles = function () {
        $scope.$emit('LOAD');
        //$scope.jobroles = []; //This ensures assessors will refresh everytime
        $http.get("/Assessor/GetJobRoles?" + 'EmployeeID=' + $scope.selectedAssessor)
            .success(function (data) {
                console.log(data);
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);              
                $scope.jobroles = jsonComp;              
            });
    }
    $scope.getJobTitles = function () {
        $http.get("/Assessor/GetJobTitles?" + 'EmployeeID=' + $scope.selectedAssessor)
            .success(function (data) {
                // console.log(data);
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.jobtitles = jsonComp;
                $scope.$emit('UNLOAD');
            });
    }
    $scope.getJobResps = function () {
         //This ensures assessors will refresh everytime
        $http.get("/Assessor/GetJobResps?" + 'EmployeeID=' + $scope.selectedAssessor)
            .success(function (data) {
                // console.log(data);
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.jobresps = jsonComp;
            });
    }


    $scope.Assign = function (ID, type)
    {
      Assign.AssigntoDB(ID, type, $scope);
        
    }
    $scope.deleteAssessor = function (employeeID)
    {
        swal({
            title: "Wait!", text: "Are you sure you want to delete this Assessor and all related assignments?", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!", closeOnConfirm: true,
            closeOnCancel: true
        },
          function (isConfirm) {
              if (isConfirm) {
                  $scope.selectedAssessor = employeeID;
                  DeleteAssessor.DeleteAssessortoDB(0, '', $scope);
              }

          });
    }

    $scope.getAssessors();
    $scope.getEmployees();

    $scope.AddAssessor = function (roleID, type, assessor) {
        $scope.selectedAssessor = assessor
        AddNewAssesor.AddNewAssesortoDB(roleID, type, $scope);

        swal("Success!", "The Employee is now an Assessor!", "success", { imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });
    }
   
    $scope.ModalAddAssessor = function () {
        ngDialog.openConfirm({
            template: 'dialogWithNestedConfirmDialogId',
            className: 'ngdialog-theme-default',
            width: 650,
            //preCloseCallback: function (value) {

            //    var nestedConfirmDialog = ngDialog.openConfirm({
            //        template:
            //                '<p>Are you sure you want to close the parent dialog?</p>' +
            //                '<div class="ngdialog-buttons">' +
            //                    '<button type="button" class="ngdialog-button ngdialog-button-danger" ng-click="closeThisDialog(0)">No' +
            //                    '<button type="button" class="ngdialog-button ngdialog-button-success" ng-click="confirm(1)">Yes' +
            //                '</button></div>',
            //        plain: true,
            //        className: 'ngdialog-theme-default'
            //    });

            //    return nestedConfirmDialog;
            //},
            scope: $scope
        })
        .then(function (value) {
            console.log('resolved:' + value);
            // Perform the save here
        }, function (value) {
            console.log('rejected:' + value);

        });
    };

})

.factory("Assign", ['$http', function ($http, $scope) {
    var fac = {};

    fac.AssigntoDB = function (ID, type, $scope) {
        console.log(ID);
        console.log(type);
        console.log($scope.selectedAssessor);
        $http.post("/Assessor/ManagerAssignments?" + 'ObjectID=' + ID + '&ObjectType=' + type + '&EmployeeID=' + $scope.selectedAssessor).success(function (response) {
           
        })
    }
    return fac;
}])

.factory("AddNewAssesor", ['$http', function ($http, $scope) {
    var fac = {};

    fac.AddNewAssesortoDB = function (ID, type, $scope) {       
        $http.post("/Assessor/ManagerAssignments?" + 'ObjectID=' + ID + '&ObjectType=' + type + '&EmployeeID=' + $scope.selectedAssessor).success(function (response) {
            $scope.getAssessors();
            $scope.getEmployees();
        })
    }
    return fac;
}])

    .factory("DeleteAssessor", ['$http', function ($http, $scope) {
        var fac = {};

        fac.DeleteAssessortoDB = function (ID, type, $scope) {
            $http.post("/Assessor/RemoveManagerAssignments?" + 'ObjectID=' + ID + '&ObjectType=' + type + '&EmployeeID=' + $scope.selectedAssessor).success(function (response) {
                swal("Success!", "The Assessor was removed!", "success", { imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });
                $scope.getAssessors();
                $scope.getEmployees();
            })
        }
        return fac;
    }])


.factory("Unassign", ['$http', function ($http, $scope) {
    var fac = {};
    fac.UnassigntoDB = function (ID, type, $scope) {
        $http.post("/Assessor/RemoveManagerAssignments?" + 'ObjectID=' + ID + '&ObjectType=' + type + '&EmployeeID=' + $scope.selectedAssessor).success(function (response) {
            
        })
    }
    return fac;
}])
