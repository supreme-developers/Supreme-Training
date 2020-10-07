/// <reference path="bower_components/nya-bootstrap-select/dist/js/nya-bs-select.js" />
/// <reference path="D:\Development\TFS\Supreme\.NET Code\SSITraining\SSIWebTraining\SSIWebTraining\AdminTools/CompGroups.aspx" />
/// <reference path="D:\Development\TFS\Supreme\.NET Code\SSITraining\SSIWebTraining\SSIWebTraining\sweetAlert/sweetalert.min.js" />


var app = angular
.module('CompApp', ['ui.bootstrap', 'ui', 'ssi.sortable'])
.controller('CompCtrl', function ($scope, $http, AddComp, EditComp, SetCompStatus) {
    var id_generator = function (id) {
        return parseInt(id + 1);
    }
    $scope.comps = [{ 'CompetencyID': 0, 'Question': '', 'Answer': '', 'CompetencyGroupID': 0, 'CompetencyTypeID': 0, 'LevelID': 0, 'CompetencyTypeName': '' }];
    
    $scope.comps.splice(0, 1);

    $http.get("/Group/GetGroups")
           .success(function (data) {
               $scope.Groups = data;
           });

   
       
   
    $http.get("/Competency/GetCompetencyTypes")
      .success(function (data) {
          $scope.types = data;
      });

    $scope.levels = [
       { "LevelID": 1, "Level": 'Level 1' },
       { "LevelID": 2, "Level": 'Level 2' },
       { "LevelID": 3, "Level": 'Level 3' }
    ]

    //$scope.filter = function () {
    //    var data = $scope.currentComps;       
    //    $scope.currentComps = [];
    //    $scope.currentComps = data;
    //    $scope.$apply();
    //};
    $scope.groupID = 0;
    $scope.CompetencyID = 0;

    $scope.loadData = function (groupID) {       
        $http.get("/Competency/GetCompetencies", { params: { "GroupID": groupID } }, { cache: false })
            .success(function (data) {
                var jsonComp = JSON.stringify(data);
                jsonComp = jQuery.parseJSON(jsonComp);
                $scope.currentComps = data;
            });
    };
    $scope.getComp = function (compID, typeCombo, lvlCombo) {
        $http.get("/Competency/GetCompetency", { params: { "CompID": compID } }, { cache: false })
            .success(function (data) {
                $scope.currentComp = data;

                var jsoncomp = JSON.stringify(data);
                var comps = jQuery.parseJSON(jsoncomp);
                $('.divCompetencies').hide();
                $('#divEditComp').show();
                $('#divbtnBack').show();
                //The following sets the Combo box fields in ManageCompetencies.aspx since the are Telerik and cannot be used with Angular.
                $.each(comps, function (key, value) {
                    var type = typeCombo.findItemByValue(value.CompetencyTypeID);
                    type.select();
                    var lvl = lvlCombo.findItemByValue(value.LevelID);
                    lvl.select();
                   
                });
                //$scope.eType = jsonGroup.CompetencyTypeID;
                //$scope.eLevel = jsonGroup.LevelID;
                   

            });
    };
    $scope.AddComp = function (comp) {
        var jsonComp = JSON.stringify(comp);
        jsonComp = jQuery.parseJSON(jsonComp);
        jsonComp.CompetencyGroupID = $scope.groupID;
      
        if (typeof jsonComp.groupID !== 0 && jsonComp.question != '') {
            AddComp.AddComptoDB(jsonComp, $scope);
            //$scope.loadData(jsonComp.group);
            //$scope.currentComps.splice(0, 1);
        }
        else {
            alert('Please Enter a Group.');
        }
    }

    $scope.DeleteComp = function (compID) {        
        SetCompStatus.SetCompStatusinDB(compID, 'Inactive', $scope);
       
    }

    $scope.EditComp = function (comp) {
        var jsonComp = JSON.stringify(comp);
        jsonComp = jQuery.parseJSON(jsonComp);
        jsonComp.CompetencyID = $scope.CompetencyID;
        jsonComp.CompetencyGroupID = $scope.groupID;

        if (typeof jsonComp.groupID !== 0 && jsonComp.question != '') {
            EditComp.EditComptoDB(jsonComp);
            //$scope.loadData(jsonComp.group);
            //$scope.currentComps.splice(0, 1);
        }
        else {
            alert('Please Enter a Group.');
        }
    }

    $scope.setGroupID = function ($event) {
        
        var id = $event.target.id.substring(1); //remove the a in front
        $scope.groupID = id;
        $scope.loadData(id);
       
    }
    $scope.SetCompetencyID = function (id, typeCombo, lvlCombo, editID) {     
        $scope.CompetencyID = id;
        $scope.editID = editID;
        $scope.getComp(id, typeCombo, lvlCombo);
    }
    $scope.AddElement = function (i, groupID, type) {
        //the below checks to see if there are QA elements that exist after the current one. If not, another needs to be added.
        if (!angular.isDefined($scope.comps[i + 1]) ) {
            var compQA = {
                'id': id_generator(i),
                'question': '',
                'answer': '',
                'group': groupID,
                'Type': type
            }
            $scope.comps.push(compQA);
            // AddComp.AddAddComptoDB(compQA);
        }
    }

})
    
.controller('CACtrl', function ($scope, $http, $location, InsertHeader, InsertDetail, RemoveCompetency_fromDefinition, UpdateHeader, AddTask, UpdateItem, updateAllSorts) {
    $scope.tasks = [{ 'CompetencyDefTaskID': 0, 'CompDefHeaderID': 0, 'Task': '', 'Active': 1, 'CreateDateTime': '', 'CreateUserID': 0 }];
    $scope.currentTasks = [];
    $scope.filteredcurrentTasks = []
  , $scope.currentPage = 1
  , $scope.numPerPage = 10
  , $scope.maxSize = 5;

    $scope.$on('LOAD', function () { $scope.loading = true; console.log($scope.loading);});
    $scope.$on('UNLOAD', function () { $scope.loading = false; });

    $scope.dragStart = function (e, ui) {
        ui.item.data('start', ui.item.index());        
    }

    $scope.removePaging = function () {
        $scope.preNumPerPage = $scope.numPerPage;
        $scope.numPerPage = 10000;
    };


    $scope.dragEnd = function (e, ui) {
        var start = ui.item.data('start'),
            end = ui.item.index();
       
        console.log(start + ' - ' + end);
        updateAllSorts.updateAllTasksinDB(start, end, $scope);
    }

    sortableEle = $('#sortable').sortable({
        start: $scope.dragStart,
        update: $scope.dragEnd
    });

   
    $scope.itemNumberOptions = [
    { name: '10', value: '10' },
    { name: '20', value: '20' },
    { name: '50', value: '50' }];
    $scope.holdOriginalNumPerPage = 10;

    $scope.form = { type: $scope.itemNumberOptions[1].value };

    var id_generator = function (id) {
        return parseInt(id + 1);
    }

    $scope.setHeader = function (compDefHeader) {
        $scope.HeaderDefObject = [];
        $scope.headerLoaded = false;
        $http.get("/Competency/GetCompHeaderDetails?" + "compHeaderID=" + compDefHeader)
          .success(function (data) {
              var jsonComp = JSON.stringify(data);
              jsonComp = jQuery.parseJSON(jsonComp);
              $scope.defHeaderObj = data;
              $scope.headerLoaded = true;
              $scope.defHeader = compDefHeader;
          });
    };

    $scope.goTo = function() {
        window.location.href = '/admintools/defineca.aspx'
        };


    if (typeof $location.search().compHeaderID !== 'undefined') {
        $scope.compHeaderID = $location.search().compHeaderID; //this gets query string from url
        $scope.setHeader($scope.compHeaderID);
    }
    else {
        $scope.compHeaderID = 0;
    }

    $scope.HeaderObject = [{
        'CompetencyDefHdrID': 0, 'JobTitleID': 0, 'JobRoleID': 0, 'JobResponsibilityID': 0, 'Description': '',
        'PassingGrade': 0, 'NotifyDays': 0, 'RecurrenceQty': 0, 'UOMSchedulingRecurrenceID': 0
    }];

    $scope.$watch('currentPage + numPerPage + currentTasks + Taskdropped', function (value) {
        if ($scope.numPerPage == null) //If 'Tasks Per Page is selected, set the null to 10
        {
            $scope.numPerPage = 10;
        }
        var begin = (($scope.currentPage - 1) * $scope.numPerPage),
            end = begin + parseInt($scope.numPerPage);
        $scope.filteredcurrentTasks = $scope.currentTasks.slice(begin, end);
    });

    $scope.updateAllSorts = function (start, end, $scope) {     
        updateAllSorts.updateAllTasksinDB(start, end, $scope);
    }
    $scope.EditItem = function (index, object, commandName, currentList, $scope) {

        if (commandName.indexOf("Delete") >= 0) {
            UpdateItem.UpdateIteminDB(object, commandName);
            currentList.splice(currentList.indexOf(object), 1);
            $scope.getTasks($scope);
            //$scope.refreshTasks();
        }
        else {
            if ($('#einput' + index).attr('disabled')) {
                $('#einput' + index).removeAttr('disabled');
                $('#sort' + index).removeAttr('disabled');
                $('#ei' + index).attr('class', 'fa fa-save');
                $('#ebtn' + index).attr('class', 'btn btn-success btn-flat');
            }
            else {
                UpdateItem.UpdateIteminDB(object, commandName);
                $('#einput' + index).attr('disabled', 'disabled');
                $('#sort' + index).attr('disabled', 'disabled');
                $('#ebtn' + index).attr('class', 'btn btn-info btn-flat');
                $('#ei' + index).attr('class', 'fa fa-pencil');
            }
        }
    }
    $scope.DeleteItem = function (index, object, commandName, currentList) {

        swal({
            title: "Wait!", text: "Removing this item may result in historical data issues. Are you sure you want to continue?", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55",
            confirmButtonText: "Yes, delete it!", closeOnConfirm: true,
            closeOnCancel: true
        },
         function (isConfirm) {
             if (isConfirm) {
                 
                 $scope.EditItem(index, object, commandName, currentList, $scope);
             }
             
         });

    }
   
   

    $scope.defHeader = 0;

    //$scope.loadData = function (groupID) {       
    //    $scope.currentComps = []; //This ensures currentComps will refresh everytime
    //    $scope.groupID = groupID;
    //    $http.get("/Competency/GetCompetencies_withDefHeader?" + "GroupID=" + groupID + "&compHeaderID=" + $scope.defHeader)
    //        .success(function (data) {
    //            var jsonComp = JSON.stringify(data);
    //            jsonComp = jQuery.parseJSON(jsonComp);
    //            $scope.currentComps = data;
    //        });
    //};

    $scope.needCheckMark = function (compdefHeaderID) {
        return compdefHeaderID == $scope.defHeader ? 'bgimage' : '';
    };

    $scope.InsertHeader = function (HeaderObject) {
        var jsonHeader = JSON.stringify(HeaderObject);
        jsonHeader = jQuery.parseJSON(jsonHeader);
        
        if ($scope.defHeader == 0) {
            InsertHeader.InsertHeader(jsonHeader, $scope);
            
        }
        else {
            UpdateHeader.UpdateHeader(jsonHeader, $scope);
        }
    }

    $scope.getTasks = function ($scope) {
    $scope.$emit('LOAD');          
        $scope.currentTasks = [];
        
        $http.get("/Competency/GetCurrentTasks", { params: { "CompDefHeaderID": $scope.defHeader } }, { cache: false })
           .success(function (data) {
               
               var jsonComp = JSON.stringify(data);
               jsonComp = jQuery.parseJSON(jsonComp);    
               $scope.currentTasks = data;
               console.log($scope.loading + 'er');
               $scope.$emit('UNLOAD');
               console.log('unLoad');
           })
    }
    $scope.AddTask = function (task, i) {
        var jsonTask = JSON.stringify(task);
        jsonTask = jQuery.parseJSON(jsonTask);
        jsonTask.CompDefHeaderID = $scope.defHeader;
        task.Sort = parseInt(i + 1);

        if (typeof jsonTask.Task !== 'undefined' && jsonTask.Task != '') {
            $scope.filteredcurrentTasks.push(task);
            $scope.AddTaskElement(i);
            $scope.tasks.splice(0, 1);
            $scope.keepcurrentPage = $scope.currentPage;
            AddTask.AddTasktoDB(jsonTask, $scope);


            
        }
        else {
            alert('Please Enter a Task.');
        }
    }
    
    $scope.AddTaskElement = function (i) {
        if (!angular.isDefined($scope.tasks[i + 1])) {
            var newID = id_generator(i);
            var newtask = {
                'CompetencyDefTaskID': newID,
                'CompDefHeaderID': $scope.defHeader,
                'Sort': parseInt(i + 1),
                'Task': '',
                'Active': 1
            }
            
            $scope.tasks.push(newtask);
        }
    }
    $scope.InsertDetail = function (CompetencyID) {        
        InsertDetail.InsertDetail(CompetencyID, $scope);
    }
    $scope.RemoveCompetency_fromDefinition = function (CompetencyID, index) {
        RemoveCompetency_fromDefinition.RemoveCompetency_fromDefinition(CompetencyID, index, $scope);       
    }

    //$scope.setGroupID = function ($event) {      
    //    var id = $event.target.id.substring(1); //remove the a in front
    //    $scope.groupID = id;
    //    $scope.loadData(id);
    //}

})
.controller('MngCompCtrl', function ($scope, $http, $location, RemoveCompetency_fromDefinition, RemoveCompetencyDefinition) {
    
    $scope.HeaderDefObject = [{
        'JobTitle': '', 'JobRole': '', 'JobResponsibility': '', 'Description': '',
        'PassingGrade': 0, 'NotifyDays': 0, 'Recurrence':''
    }];

    $scope.getCompetencyDefinitions = function () {
        $scope.HeaderDefinitions = [];
        $http.get("/Competency/GetCompetencyDefinitions?")
        .success(function (data) {
            var jsonComp = JSON.stringify(data);
            jsonComp = jQuery.parseJSON(jsonComp);
            $scope.HeaderDefinitions = jsonComp;
        });
    }
     
    $scope.getCompetencyDefinitionDetails = function () {
        $scope.HeaderDefObjects = [];
        $http.get("/Competency/GetCompDefDetails?compHeaderID=" + $scope.compHeaderID)
        .success(function (data) {
            var jsonComp = JSON.stringify(data);
            jsonComp = jQuery.parseJSON(jsonComp);
            $scope.HeaderDefObjects = data;
            $scope.compRemoved = false;
        });
    }

    $scope.RemoveCompetency_fromDefinition = function (CompetencyID, index) {
        $scope.HeaderDefObjects.splice(index, 1);
        RemoveCompetency_fromDefinition.RemoveCompetency_fromDefinition(CompetencyID, index, $scope);
    }

    $scope.RemoveCompetencyDefinition = function (CompDefHeaderID) {
        RemoveCompetencyDefinition.RemoveCompetencyDefinition(CompDefHeaderID);
    }

})

.factory("AddComp", ['$http', function ($http, $scope) {
    var fac = {};
    fac.AddComptoDB = function (comp, $scope) {
        $http.post("/Competency/AddEditComp", comp).success(function (response) {
            $scope.currentComps.push(response);
            $scope.$apply(); 
        })
    }
    return fac;
}])
.factory("EditComp", ['$http', function ($http, $scope) {
        var fac = {};
        fac.EditComptoDB = function (comp) {
            $http.post("/Competency/AddEditComp", comp).success(function (response) {
                $scope.currentComps.push(response);
                $scope.$apply();
                // alert(response.status);
            })
        }
        return fac;
}])
.factory("SetCompStatus", ['$http', function ($http, $scope) {
    var fac = {};   
    fac.SetCompStatusinDB = function (compID, statusCode, $scope) {
        $http.post("/Competency/SetCompStatus?" + 'compID=' + compID + '&statusCode=' + statusCode).success(function (response) {
       
            swal("Good job!", response, "success", { imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });

         $scope.currentComps.splice($scope.editID, 1);
         $('.divCompetencies').show();
         $('#divEditComp').hide();
         
        })
    }
    return fac;
}])
.factory("InsertHeader", ['$http', function ($http, $scope) {
    var fac = {};
    fac.InsertHeader = function (headerObj, $scope) {
        $http.post("/Competency/InsertHeader", headerObj).success(function (response) {
            $scope.defHeader = response;
            $scope.getTasks($scope);
            $scope.tasks = [{ 'CompetencyTaskID': 0, 'CompDefHeaderID': $scope.defHeader, 'Task': '', 'Active': 1}];
           // $scope.$apply();
        })
    }
    return fac;
}])
.factory("UpdateHeader", ['$http', function ($http, $scope) {
    var fac = {};
    fac.UpdateHeader = function (headerObj, $scope) {
        headerObj.CompDefHeaderID = $scope.defHeader;
        $http.post("/Competency/UpdateHeader", headerObj).success(function (response) {
            //$scope.defHeader = response;
            //$scope.$apply();
        })
    }
    return fac;
}])
.factory("InsertDetail", ['$http', function ($http, $scope) {
    var fac = {};
    fac.InsertDetail = function (CompetencyID, $scope) {        
        $http.post("/Competency/InsertDetail?" + 'compHeaderID=' + $scope.defHeader + '&CompetencyID=' + CompetencyID).success(function (response) {           
        })
    }
    return fac;
}])
.factory("RemoveCompetency_fromDefinition", ['$http', function ($http, $scope) {
    var fac = {};

    fac.RemoveCompetency_fromDefinition = function (CompetencyID, index, $scope) {
        $http.post("/Competency/RemoveCompetency_fromDefinition?" + 'CompetencyID=' + CompetencyID + '&compDefHeaderID=' + $scope.defHeader).success(function (response) {
            $scope.compRemoved = true;            
        })
    }
    return fac;
}])
.factory("RemoveCompetencyDefinition", ['$http', function ($http, $scope) {
    var fac = {};

    fac.RemoveCompetencyDefinition = function (CompDefHeaderID) {
        $http.post("/Competency/RemoveCompetencyDefinition?" + 'compDefHeaderID=' + CompDefHeaderID).success(function (response) {
        })
    }
    return fac;
}])
    .factory("AddTask", ['$http', function ($http) {
        var fac = {};
        var newTask = {};
        fac.AddTasktoDB = function (task, $scope) {
            $http.post("/Competency/AddTask", task).success(function (response) {
                $scope.getTasks($scope);
                //$scope.currentPage = $scope.keepcurrentPage;
                // alert(response.status);
            })
        }
        return fac;
    }])
     .factory("updateAllSorts", ['$http', function ($http) {
         var fac = {};
         var newTask = {};
         fac.updateAllTasksinDB = function (oldSort, newSort, $scope) {
             $http.post("/Competency/UpdateAllTaskSorts?" + 'oldSort=' + oldSort + '&newSort=' + newSort + '&compDefHeader=' + $scope.defHeader).success(function (response) {
                 $scope.getTasks($scope);
                 // alert(response.status);
             })
         }
         return fac;
     }])
.factory("UpdateItem", ['$http', function ($http) {
    var fac = {};
    fac.UpdateIteminDB = function (object, commandName) {  

        $http.post("/Competency/" + commandName, object).success(function (response) {
            // alert(response.status);
        })
    }
    return fac;
}])
.filter('cut', function () {
    return function (value, wordwise, max, tail) {
        if (!value) return '';

        max = parseInt(max, 10);
        if (!max) return value;
        if (value.length <= max) return value;

        value = value.substr(0, max);
        if (wordwise) {
            var lastspace = value.lastIndexOf(' ');
            if (lastspace != -1) {
                //Also remove . and , so its gives a cleaner result.
                if (value.charAt(lastspace - 1) == '.' || value.charAt(lastspace - 1) == ',') {
                    lastspace = lastspace - 1;
                }
                value = value.substr(0, lastspace);
            }
        }

        return value + (tail || ' …');
    };
})



