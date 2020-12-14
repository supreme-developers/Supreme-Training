<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="ManageAssessors.aspx.cs" Inherits="SSIWebTraining.AdminTools.ManageAssessors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../css/ngDialog/ngDialog.min.css" rel="stylesheet" />
    <link href="../css/ngDialog/ngDialog-theme-default.min.css" rel="stylesheet" />
    <link href="../css/ngDialog/ngDialog-theme-plain.min.css" rel="stylesheet" />
   
    <style lang="css">
       .maxHeight{
           max-height: 400px;
       }
        .minHeight{
           max-height: 400px;
       }

        tr.selected {
            background-color: #FCF8E3;
        }

        .FAtext {
            font-family: 'FontAwesome';
            content: "\f00c";
            font-size: 13px;
        }

        .panel-body {
            padding: 0px;
        }

        body {
            padding-top: 20px;
            background-color: #F7F7F7;
        }

        .list-group {
            margin-bottom: 0px;
        }

            .list-group panel.active {
                background-color: #030;
                border-color: #aed248;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-10 col-md-10 col-sm-10">
            <h2><span class="fa fa-unlock"></span>
                <label id="pageType"></label>
                Assessors Setup</h2>
        </div>
        <div class="col-lg-2 ">
            <%--<button type="button" class="btn btn-info pull-right" onclick="location.href='/AdminTools/EditCA.aspx'"><span class="glyphicon glyphicon-th-list" aria-hidden="true"></span>  Competency List</button>--%>
        </div>
    </div>
    <br />

    <div ng-app="AssessorApp">
        <div ng-controller="AssessorCtrl">
   
             <script type="text/ng-template" id="dialogWithNestedConfirmDialogId">
                <div class="ngdialog-message">
                    <h4>Add an Assessor</h3><br>
                 
                 <select id="top-rows-per-page" class="form-control input-lg col-lg-6" 
                        ng-options='employee.EmployeeID as employee.Name for employee in employees' 
                        ng-model="confirmValue"  >
                        <option value="" selected>To Begin, Select an Employee</option>
                    </select>   <br><br>

                </div>
                <div class="ngdialog-buttons">
                    <button type="button" class="ngdialog-button btn-danger" ng-click="closeThisDialog('Cancel')">Close</button>
                    <button type="button" class="ngdialog-button btn-success" ng-click="AddAssessor(0,'JobRole', confirmValue)">Submit</button>
                </div>
            </script>
            <div class="row">
                <div class="col-lg-3">
                    <div class="panel panel-primary filterable">
                        <div class="panel-heading ">
                            <h4 class="panel-title">
                                <a id="assessorsheader" data-parent="#objects" class="clickable" href="#assessors" data-toggle="collapse">Current Assessors
                                </a>
                            </h4>
                        </div>
                         <div class="panel-body">
                             <input id="searchbox_assessors" type="text" placeholder="Search..." 
                                        ng-model="searchAssessors" class="form-control input-lg" /> 
                        </div>
                        <div id="assessors" class="panel-footer pre-scrollable minHeight w3-padding-0">
                            <div class="list-group " style="width: 100%">                                 
                                <div ng-repeat="assessor in assessors | filter: searchAssessors" class="list-group-item ">
                                    <a class="fa fa-close pull-right" ng-click="deleteAssessor(assessor.EmployeeID)" style="cursor:pointer" ></a>
                                    <a  ng-href="#" ng-model="selectedAssessor" 
                                        ng-click="loadAllObjects(assessor.EmployeeID)">
                                        <div>{{assessor.Name}}</div>
                                    </a>
                                </div>
                                
                                
                            </div>
                        </div>
                        <a class="btn btn-success btn-block" ng-click="ModalAddAssessor()">Add Assessor  <span class="fa fa-plus fa-1x"></span></a>
                    </div>
                    <div class="col-lg-9 col-lg-offset-1">
                      <%--  <select id="top-rows-per-page" class="form-control input-lg col-lg-6" 
                            ng-options='employee.EmployeeID as employee.Name for employee in employees' ng-change="loadAllObjects()" ng-model="selectedAssessor" >
                            <option value="" selected>To Begin, Select an Employee</option>
                        </select>--%>
                    </div>
                </div>                
                <div class="col-lg-9">
                    <div class="row" ng-show="loading">
                            <div class=" col-lg-offset-4 ">
                                <div class="fa fa-spinner fa-pulse fa-2x"  ></div><br />
                            </div>
                     </div>
                    <div class="row">
                    <div class="col-lg-8 col-lg-offset-1 w3-animate-zoom" ng-show="employeeSelected && !loading"> <%--Job Resp--%>
                            <div class="panel panel-info filterable">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a id="comps" data-parent="#objects" class="clickable" href="#competencies" data-toggle="collapse">
                                            Competencies
                                        </a>
                                    </h4>
                                </div>
                                <div id="competencies" class="panel-body text-center  pre-scrollable maxHeight">  
                                    <table id="tblComps" class="table table-striped table-bordered table-responsive table-condensed table-inverse">
                                       
                                        <tbody class="rep-drag connectedSortable">
                                            <tr>
                                                <td class="col-lg-6">
                                                    <input id="searchbox" type="text" placeholder="Search..." class="form-control input-lg" ng-model="searchComps" />
                                                </td>
                                            </tr>
                                             <tr ng-repeat="comp in Competencies | filter: searchComps">
                                                    <td class="col-lg-10" align="left">
                                                        <div class="checkbox checkbox-info">
                                                            <input id="{{'comp' + $index }}" class="styled" type="checkbox" ng-checked="comp.Selected" ng-true-value="1" ng-false-value="0"
                                                                ng-model="comp.Selected" ng-change="manageAssignment(comp.CompDefHeaderID, comp, 'Competency')" />
                                                            <label for="{{'comp' +  $index }}">
                                                                {{comp.Description}}
                                                            </label>
                                                        </div>
                                                    </td>
                                                </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    <div class="col-lg-6 w3-animate-zoom hidden" ng-show="employeeSelected && !loading">
                            <div class="panel panel-info filterable">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a id="collapseDragDrop" data-parent="#objects" class="clickable" href="#JobRoles" data-toggle="collapse">
                                            Job Roles
                                        </a>
                                    </h4>
                                </div>
                                <div id="JobRoles" class="panel-body text-center pre-scrollable maxHeight">
                                    <table id="tbljobroles" class="table table-condensed table-bordered" >
                                        <tbody class="rep-drag connectedSortable">
                                            <tr>
                                                <td class="col-lg-6">
                                                    <input id="searchJobRoles" type="text" placeholder="Search..." class="form-control input-lg" ng-model="searchJobRoles" />
                                                </td>
                                            </tr>
                                            <tr ng-repeat="role in jobroles | filter: searchJobRoles">
                                                <td class="col-lg-10" align="left">
                                                    <div class="checkbox checkbox-info">
                                                        <input id="{{'role' + $index }}" class="styled fa-2x" type="checkbox" ng-checked="role.Selected" ng-true-value="1" ng-false-value="0"
                                                            ng-model="role.Selected" ng-change="manageAssignment(role.ID, role, 'JobRole')">
                                                        <label for="{{'role' + $index }}">
                                                            {{role.JobRole}}
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                        </table>
 
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row hidden">
                         <div class="col-lg-6 w3-animate-zoom" ng-show="employeeSelected && !loading">
                                <div class="panel panel-info filterable">
                                    <div class="panel-heading">
                                        <h4 class="panel-title">
                                            <a id="jt" data-parent="#objects" class="clickable" href="#JobTitles" data-toggle="collapse">
                                                Job Titles
                                            </a>
                                        </h4>
                                    </div>
                              
                                    <div id="JobTitles" class="panel-body text-center  pre-scrollable maxHeight">
                                        <table id="tbljobtitles" class="table table-condensed table-bordered">
                                            <tbody class="rep-drag connectedSortable">
                                                <tr>
                                                    <td class="col-lg-6">
                                                        <input id="searchJobTitles" type="text" placeholder="Search..." class="form-control input-lg" ng-model="searchJobTitles" />
                                                    </td>
                                                </tr>
                                                <tr ng-repeat="title in jobtitles | filter:searchJobTitles">
                                                    <td class="col-lg-10" align="left">

                                                        <div class="checkbox checkbox-info">
                                                            <input id="{{'title' + $index }}" class="styled" type="checkbox" ng-checked="title.Selected" ng-true-value="1" ng-false-value="0"
                                                                ng-model="title.Selected" ng-change="manageAssignment(title.JobTitleID, title, 'JobTitle')" />
                                                            <label for="{{'title' +  $index }}">
                                                                {{title.JobTitle}}
                                                            </label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>


                                    </div>
                                </div>
                            </div><%--Job Titles--%>
                            <div class="col-lg-6 w3-animate-zoom" ng-show="employeeSelected && !loading"> <%--Job Resp--%>
                            <div class="panel panel-info filterable">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a id="jr" data-parent="#objects" class="clickable" href="#JobResp" data-toggle="collapse">
                                            Job Responsiblities
                                        </a>
                                    </h4>
                                </div>
                               
                                <div id="JobResp" class="panel-body text-center  pre-scrollable maxHeight">  
                                     <table id="tbljobresps" class="table table-condensed table-bordered">
                                        <tbody class="rep-drag connectedSortable">
                                            <tr>
                                                <td class="col-lg-6">
                                                    <input id="searchJobResps" type="text" placeholder="Search..." class="form-control input-lg" ng-model="searchJobResps" />
                                                </td>
                                            </tr>
                                            <tr ng-repeat="resp in jobresps | filter:searchJobResps">
                                                <td class="col-lg-10" align="left">
                                                    <div class="checkbox checkbox-info">
                                                        <input id="{{'resp' + $index }}" class="styled" type="checkbox" ng-checked="resp.Selected" ng-true-value="1" ng-false-value="0" class="checkbox-success"
                                                            ng-model="resp.Selected" ng-change="manageAssignment(resp.QualificationID, resp, 'JobResp')" />
                                                        <label for="{{'resp' + $index }}">
                                                            {{resp.Qualification}}
                                                        </label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div><%--Job Resp End--%>
                    </div>
                </div>
            </div>
            <br />                          
            <div class="row">
                <div class="col-lg-12" id="objects">
                     
                    <%--<div class="row"  ng-hide="loading">
                        <h3 class="col-lg-10 col-lg-offset-1" ng-show="employeeSelected">Select an item that defines a competency below to give evaluators access: </h3><br /><br /><br /><br />
                       
                    </div>--%>
                    <div class="row" style="display:none">
                        <div class="col-lg-12">
                            <div class="panel panel-success filterable">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a id="collapseDragDrops" data-parent="#accordion" class="clickable" href="#Assigned" data-toggle="collapse">
                                            Assigned Objects
                                        </a>
                                    </h4>
                                </div>
                                <div id="Assigned" class="panel-body text-center  pre-scrollable">
                                    <table id="tblassigned" class="table table-condensed table-bordered table-hover connectedSortable" style="height: ">
                                        <thead>
                                            <tr>
                                                <th class="text-center">Move</th>
                                                <th class="text-center">Description</th>
                                            </tr>
                                        </thead>
                                        <tbody class="rep-drag connectedSortable">
                                        <tr >
                                            
                                        </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                  
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
    <script src="../js/CompControllers/Assessors.js"></script>
    <script src="../js/ngDialog.min.js"></script>
   <script>
       $(function () {
           //$("#tbljobroles tbody.rep-drag, #tblassigned, #tbljobtitles tbody.rep-drag,#tbljobresp tbody.rep-drag").sortable({
           //    revert: true,
           //    connectWith: ".connectedSortable",
           //    cursor: "move",
           //    delay: 150,
           //    helper: function (e, item) {
           //        var helper = $('<tr/>');
           //        if (!item.hasClass('selected')) {
           //            item.addClass('selected').siblings().removeClass('selected');
           //        }
           //        var elements = item.parent().children('.selected').clone();
           //        item.data('multidrag', elements).siblings('.selected').remove();
           //        return helper.append(elements);
           //    },
           //    stop: function (e, info) {
           //        console.log(info);
           //        info.item.after(info.item.data('multidrag')).remove();
           //    }
           //}).disableSelection();
           function deleteAssessor(employeeID)
           {
               alert(employeeID);
           }
           $('.connectedSortable tr').click(function () {
               $(this).toggleClass("selected");
           })
       });
   </script>
</asp:Content>
