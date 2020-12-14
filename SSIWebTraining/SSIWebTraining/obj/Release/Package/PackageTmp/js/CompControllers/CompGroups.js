/// <reference path="bower_components/nya-bootstrap-select/dist/js/nya-bs-select.js" />



var app = angular
.module('GroupApp', [])
.controller('GroupCtrl', function ($scope, AddGroup, $http, EditGroup, DeleteGroup) {
    var id_generator = function (id) {
        return id + 1
    }
    
    $scope.groups = [{ 'id': 1, 'name': '' }];
   

    $http.get("/Group/GetGroups")
        .success(function (data) {           
            $scope.editGroups = data;
        });
    //dataFactory.call().success(function (data) {
    //    $scope.editGroups = data;
    //});
    $scope.AddGroup = function (group, i) {
        var jsonGroup = JSON.stringify(group);
        jsonGroup = jQuery.parseJSON(jsonGroup);
                   
        if (typeof jsonGroup.GroupName !== 'undefined' && jsonGroup.GroupName != '') {
            AddGroup.AddGrouptoDB(group);
            $scope.editGroups.push(group);
            //disable controls and style
            $('#btn' + i).attr('class', 'btn btn-success btn-flat');
            $('#btn' + i).attr('disabled', 'disabled');
            $('#i' + i).attr('class', 'fa fa-check');
            $('#input' + i).attr('disabled', 'disabled');
            $('#input' + i).fadeOut(2000);
            $('#btn' + i).fadeOut(2000);
            $scope.groups.splice(0, 1);
        }
        else
        {
            alert('Please Enter a Group.');
        }
    }
    $scope.AddElement = function (i) {
        if (!angular.isDefined($scope.groups[i + 1])) {
            var newgroup = {
                'id': id_generator(i),
                'name': ''
            }
            $scope.groups.push(newgroup);
        }
    }
    $scope.setTab = function (i, event) {
        //alert($(event.target).prop('tagName'));
       
       
        $('a.groupLink').removeClass('active');
        $(event.target).addClass("active");
        //var index = me.index();
        $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
        $("div.bhoechie-tab>div.bhoechie-tab-content").eq(i).addClass("active");
    }


    $scope.EditGroup = function (index, group) {
        if ($('#einput' + index).attr('disabled')) {
            $('#einput' + index).removeAttr('disabled');
            $('#ei' + index).attr('class', 'fa fa-save');
            $('#ebtn' + index).attr('class', 'btn btn-success btn-flat');
        }
        else {
            EditGroup.EditGroupinDB(group);
            $('#einput' + index).attr('disabled', 'disabled');
            $('#ebtn' + index).attr('class', 'btn btn-info btn-flat');
            $('#ei' + index).attr('class', 'fa fa-pencil');
        }
    };
    $scope.DeleteGroup = function (index,group)
    {
        if (confirm('Are you sure you want to permanently Delete this Group?'))
        {
            DeleteGroup.DeleteGroup(group);
            $scope.editGroups.splice($scope.editGroups.indexOf(group), 1)
        }
    }
              
})
.factory("AddGroup", ['$http', function ($http){
    var fac = {};
    fac.AddGrouptoDB = function(group)
    {
        $http.post("/Group/AddGroup", group).success(function (response) {
            // alert(response.status);
        })
    }
    return fac;
}])
.factory("EditGroup", ['$http', function ($http) {
    var fac = {};
    fac.EditGroupinDB = function (group) {
        $http.post("/Group/EditGroup", group).success(function (response) {
            // alert(response.status);
        })
    }
    return fac;
}])
.factory("DeleteGroup", ['$http', function ($http) {
var fac = {};
fac.DeleteGroup = function (group) {
    $http.post("/Group/DeleteGroup", group).success(function (response) {
        // alert(response.status);
    })
}
return fac;
}])
          
