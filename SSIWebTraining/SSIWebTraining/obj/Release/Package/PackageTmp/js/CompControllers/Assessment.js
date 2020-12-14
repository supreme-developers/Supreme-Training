

var app = angular
.module('modAssessment', [])
.config(function($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
})
.controller('AssessmentCtrl', function ($scope, $http, $location, updateTaskComp, FinalizeCompetency, updatePercent) {
   
    $scope.currentTaskID = 0;
    $scope.currentIndex = 0;
    $scope.CompName = '';
    $scope.percent = 0;
    $scope.currentTask = {};
    $scope.charNeeded = 50;
    $scope.totalCharNeeded = $scope.charNeeded;
    $scope.hideArrows = function () {
        if ($scope.currentIndex == 0) {
            $('.previousarrow').hide();
        }
    }
    $scope.hideLeftArrow = function (index) {      
        return 0 === index;
    };
    $scope.hideRightArrow = function (index, task) {
        var hide = false;        
        if (index == $scope.Tasks.length - 1) {// if the current slide is the last slide
            hide = true;
        }        
        if (typeof $('input[name=comp' + index + ']:checked').val() === 'undefined') //if nothing selected yet
            hide = true;

        if (task.Competent == 0 && (task.Note == null || task.Note.length < $scope.charNeeded))
        {
            hide = true;           
        }        

        return hide;
    };
    $scope.countCharacters = function (task) {    
        
            $scope.totalCharNeeded = $scope.charNeeded - task.Note.length;
            if ($scope.totalCharNeeded < 0)
                $scope.totalCharNeeded = 0;
    }
    $scope.CompleteCompetency = function () {
        
        if ($scope.EmployeeSign_LastSix != null  && $scope.EmployeeSign_LastSix == $scope.LastSix) //&&ensure digits match Employee
        {
            FinalizeCompetency.FinalizeCompetency($scope);
        }
        else
        {
            console.log($scope.EmployeeSign_LastSix);
            console.log($scope.LastSix);
            swal("Invalid Signature! Please sign with Time Card Number.", "Please Try Again!", "warning");
        }
       
    };
    $scope.saveTask = function (task) {
        $scope.saveComp(task);
        swal("Task Saved Successfully!", "", "success");

    }
    console.log($location.search());

    $scope.saveComp = function(task)
    {       
        updateTaskComp.updateTaskComp(task.CompetencyAssessment_DetailID, task.Competent, task.Note);
    }
    if (typeof $location.search().CompAssessmentID !== 'undefined') {
       
        $scope.CompAssessmentID = $location.search().CompAssessmentID; //this gets query string from url       
    }
    else {
        $scope.CompAssessmentID = 0;
    }
    if (typeof $location.search().trainingView !== 'undefined') {
       
        $scope.trainingView = $location.search().trainingView; //this gets query string from url       
        
    }
    else {
        $scope.trainingView = false;
    }

    $scope.prevSlide = function () {      
        $scope.currentIndex = ($scope.currentIndex > 0) ? parseInt($scope.currentIndex - 1) : $scope.Tasks.length - 1;
        $scope.percent = String(Math.round((parseInt($scope.currentIndex) / parseInt($scope.Tasks.length)) * 100)) + '%';        
    };
    $scope.nextSlide = function (task) {
        $scope.totalCharNeeded = $scope.charNeeded;
        
        if (!task.Competent)
            $scope.saveComp(task);

        $scope.currentIndex = ($scope.currentIndex < $scope.Tasks.length - 1) ? ++$scope.currentIndex : 0;
        $scope.percent = String(Math.round((parseInt($scope.currentIndex + 1) / parseInt($scope.Tasks.length)) * 100)) + '%';

        updatePercent.updatePercent($scope);
        //update database
       
    };

    $scope.isCurrentSlideIndex = function (index) {
        $('#progressBar' + index).width($scope.percent);

        return $scope.currentIndex === index;
    };
    $scope.CompChange = function (task, index)
    {
        console.log(task.Competent);
        if (task.Competent)  {//if competent update DB. If not, a note is required and nothing is saved until the note is provided
            if (index == $scope.Tasks.length - 1) {
                $scope.completeMessage();
            }

            console.log(task.Competent);
            updateTaskComp.updateTaskComp(task.CompetencyAssessment_DetailID, task.Competent, '');
        }
    }
    $scope.backToList = function (index)
    {      
        if ($scope.currentIndex == $scope.Tasks.length - 1)
        {
            $scope.completeMessage();
        }
        else
            location.href = 'AssessmentsDue.aspx?';
    }
    $scope.completeMessage = function ()
    {
        //Make part of message -----If employee is not competent, he will need to retake the competency...
  var keepGoing = true;
                  $.each($scope.Tasks, function (key, value) {
                      if (keepGoing && (value.Competent == false)) {
                          $scope.EmployeeisCompetent = 'No';
                          keepGoing = false;
                      }
                  });

        swal({
            title: "All Tasks Complete!", text: "Click Continue to Review and Finalize.", type: "success", showCancelButton: true, confirmButtonColor: "#A5DC86",
            confirmButtonText: "Continue", closeOnConfirm: true, cancelButtonText: "Wait a Moment",
            closeOnCancel: true
        },
          function (isConfirm) {
              if (isConfirm) {

                
                  $('#Review').removeClass('hidden');
                  $('#Tasks').addClass('hidden');
              }

          });
    }

    $scope.setCurrentTask = function () {
        var keepGoing = true;
        $.each($scope.Tasks, function (key, value) {
            
            if (keepGoing && (value.Competent == null || key == $scope.Tasks.length - 1))
            {
                $scope.currentIndex = key;
                $scope.percent = String(Math.round((parseInt($scope.currentIndex + 1) / parseInt($scope.Tasks.length)) * 100)) + '%';

                if (key == $scope.Tasks.length - 1 && value.Competent != null)
                {
                    $('#Review').removeClass('hidden');
                    $('#Tasks').addClass('hidden');
                }
                keepGoing = false;
            }
        });
        
    };

    $http.get("/Assessment/GetEmployeeAssessment?CompetencyAssessmentID=" + $scope.CompAssessmentID)
      .success(function (data) {
          console.log($scope.CompAssessmentID);
          console.log('eri');
          $scope.Tasks = [];
          var jsonComp = JSON.stringify(data);
          jsonComp = jQuery.parseJSON(jsonComp);
          $scope.Tasks = jsonComp;
          $scope.CompName = jsonComp[0].ComptencyTitle;
          $scope.EmployeeSign_LastSix = jsonComp[0].EmployeeSign_LastSix;
          $scope.Employee = jsonComp[0].Employee;
          $scope.Assessor = jsonComp[0].Assessor;
          $scope.DateAssessed = jsonComp[0].DateAssessed;
          $scope.EmployeeisCompetent = jsonComp[0].EmployeeisCompetent;
          
          $scope.LastSix = jsonComp[0].LastSix;
          $scope.IsCompetent = jsonComp[0].IsCompetent;
          $scope.percent = String(Math.round((parseInt($scope.currentIndex + 1) / parseInt($scope.Tasks.length)) * 100)) + '%';

          $scope.setCurrentTask();
      });
    
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
    .factory("updateTaskComp", ['$http', function ($http) {
        var fac = {};
        fac.updateTaskComp = function (DetailID, IsCompetent, Note) {
            $http.post("/Assessment/updateEmpTaskCompetency?CompetencyAssessment_DetailID=" + DetailID + "&IsCompetent=" + IsCompetent + "&Note=" + Note).success(function (response) {
            })
        }
        return fac;
    }])
      .factory("updatePercent", ['$http', function ($http) {
          var fac = {};
          fac.updatePercent = function ($scope) {
              $http.post("/Assessment/UpdatePercentComplete?CompetencyAssessmentID=" + $scope.CompAssessmentID + "&percent=" + $scope.percent.replace('%','')).success(function (response) {
              })
          }
          return fac;
      }])
.factory("FinalizeCompetency", ['$http', function ($http, $scope) {
    var fac = {};
    var message;
    var mtype;
    fac.FinalizeCompetency = function ($scope) {
        $http.post("/Assessment/FinalizeCompetency?CompetencyAssessmentID=" + $scope.CompAssessmentID + "&LastSix=" + $scope.LastSix)
            .then(function successCallback(response) {
            message = '';
            mtype = 'success';
          
                    if (response.data.isCompetent == false) {
                            message = 'The employee is NOT YET Competent and will need to be reassessed in 30 days.'
                            mtype = 'warning'
                        }

                        swal({
                            title: "Competency Complete!", text: message, type: mtype, showCancelButton: false, confirmButtonColor: "#A5DC86",
                            confirmButtonText: "OK", closeOnConfirm: true, cancelButtonText: "",
                            closeOnCancel: true
                        },
                            function (isConfirm) {
                                if (isConfirm) {
                                    location.href = 'AssessmentsDue.aspx';
                                }

                            }
                        )
                },
                    function errorCallback(response) {                       
                        swal({
                                    title: "Oops! Something went wrong! Some data may not have been saved!", text: "Click the button below to be redirected to where the error occured. If the problem persists, please contact the Training Manager.", type: 'error', showCancelButton: false, confirmButtonColor: "#A5DC86",
                                    confirmButtonText: "Let's try this again!", closeOnConfirm: true, cancelButtonText: "",
                                    closeOnCancel: true
                                },
                               function (isConfirm) {
                                   if (isConfirm) {
                                       location.reload();
                                   }

                               }
                        )
                    }

        )
    }
    return fac;
}])
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