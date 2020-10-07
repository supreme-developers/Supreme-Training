var app = angular
.module('SnapshotApp', ['ui.bootstrap', 'ui', 'ngDialog'])
.filter('offset', function () {
    return function (input, start) {
        return input.slice(start);
    };
})
.controller('SnapshotCtrl', function ($scope, $http, ngDialog, AddToSnapshot, RemovefromSnapshot)
{
    $scope.currentPage = 1, $scope.numPerPage = 10, $scope.maxSize = 10;
    $scope.CompcurrentPage = 1, $scope.CompnumPerPage = 10, $scope.CompmaxSize = 10;
    $scope.ssEmployeeEmployeeID = 0;
    $scope.getSnapshotEmployees = function () {
        $scope.ssEmployees = []; 
        $http.get("/EmployeeSnapshot/GetSnapshotEmployees")
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.ssEmployees = jsonComp;
            });
    }

    $scope.selectEmployee = function (name, employeeID) {       
        $scope.ssEmployeeName = name;
        $scope.ssEmployeeEmployeeID = employeeID;
        $scope.getEmployeeCompetencies();
    }

    $scope.getEmployeeCompetencies = function () {
        $scope.employeeComps = [];
        $http.get("/EmployeeSnapshot/GetAllEmployeeCompetencies?" + "EmployeeID=" + $scope.ssEmployeeEmployeeID)
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.employeeComps = jsonComp;
            });
    }

    $scope.GetCompetecies = function (hide,show)
    {
        //$('#' + hide).hide();
        //$('#' + show).show();
        $scope.showAllComps = true;
        $scope.GetCompetencyDefinitions();
    }

    $scope.GetCompetencyDefinitions = function () {
        $scope.Competencies = [];
        $http.get("/EmployeeSnapshot/GetCompetencyDefinitions?" + "EmployeeID=" + $scope.ssEmployeeEmployeeID)
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                console.log(jsonComp);
                $scope.Competencies = jsonComp;
            });
    }

    $scope.AddToSnapshot = function (defheaderid) {
        swal({
            title: "Wait!", text: "Are you sure you want to add this Competency to " + $scope.ssEmployeeName + "'s Snapshot?", type: "warning", showCancelButton: true, confirmButtonColor: "#008D4C",
            confirmButtonText: "Yes, Add it!", closeOnConfirm: true,
            closeOnCancel: true
        },
       function (isConfirm) {
           if (isConfirm) {
               AddToSnapshot.AddToSnapshotDB(defheaderid, $scope);
               swal("Success!", "The Competency has been added to " + $scope.ssEmployeeName + "'s Snapshot!", "success", { imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });
           }

       });
       
    }

    $scope.ModalAddAssessor = function () {
        $scope.GetCompetencyDefinitions();
        ngDialog.openConfirm({
            template: 'dialogWithNestedConfirmDialogId',
            className: 'ngdialog-theme-default',
            width: 1000,
            scope: $scope
        })
        .then(function (value) {
            console.log('resolved:' + value);
            // Perform the save here
        }, function (value) {
            console.log('rejected:' + value);

        });
    }

    $scope.RemoveComp = function (CompetencyDefHeaderID) {
               swal({
            title: "Wait!", text: "Removing this Competency may result in historical data issues. Are you sure you want to continue?", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!", closeOnConfirm: true,
            closeOnCancel: true
        },
         function (isConfirm) {
             if (isConfirm) {
                 RemovefromSnapshot.RemovefromSnapshotDB(CompetencyDefHeaderID, $scope);
             }

         });

    }


    $scope.getSnapshotEmployees();

    
})
.factory("AddToSnapshot", ['$http', function ($http, $scope) {
    var fac = {};

    fac.AddToSnapshotDB = function (defheaderid, $scope) {
        $http.post("/EmployeeSnapshot/AddToSnapshot?" + 'EmployeeID=' + $scope.ssEmployeeEmployeeID + '&CompDefHeaderID=' + defheaderid).success(function (response) {
            $scope.getEmployeeCompetencies();
            $scope.GetCompetencyDefinitions();
        })
    }
    return fac;
}])
.factory("RemovefromSnapshot", ['$http', function ($http, $scope) {
    var fac = {};

    fac.RemovefromSnapshotDB = function (defheaderid, $scope) {
        $http.post("/EmployeeSnapshot/RemovefromSnapshot?" + 'EmployeeID=' + $scope.ssEmployeeEmployeeID + '&CompDefHeaderID=' + defheaderid).success(function (response) {
            $scope.getEmployeeCompetencies();
        })
    }
    return fac;
}])
