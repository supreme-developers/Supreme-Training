<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="SnapShots.aspx.cs" Inherits="SSIWebTraining.AdminTools.SnapShots" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
          .panel-body{
    padding : 0px;
}
    </style>
         <link href="../css/ngDialog/ngDialog.min.css" rel="stylesheet" />
    <link href="../css/ngDialog/ngDialog-theme-default.min.css" rel="stylesheet" />
    <link href="../css/ngDialog/ngDialog-theme-plain.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-lg-10 col-md-10 col-sm-10">
            <h2><span class="fa fa-camera"></span>
                <label id="pageType">Employee</label>
                 Snapshot </h2><br />
        </div>
        <div class="col-lg-2 ">
            <%--<button type="button" class="btn btn-info pull-right" onclick="location.href='/AdminTools/EditCA.aspx'"><span class="glyphicon glyphicon-th-list" aria-hidden="true"></span>  Competency List</button>--%>
        </div>
    </div>
    <div ng-app="SnapshotApp">
        <div ng-controller="SnapshotCtrl">
                <script type="text/ng-template" id="dialogWithNestedConfirmDialogId">
                <div class="ngdialog-message">
                    <h4>Add a Competency</h3><br>
                  <div id="allComps" class="row" >
                    <div class="col-lg-12">
                        <div class="panel panel-primary filterable">
                            <div class="panel-heading">
                                <h3 class="panel-title fa-1x">Current Competencies</h3>
                                <div class="pull-right">
                                 
                                </div>
                            </div>                           
                            <table id="AllComps" class="table table-striped table-bordered table-responsive table-condensed table-inverse"> 
                                <thead>
                                    <tr>
                                        <th class="text-center">Description</th>
                                        <th class="text-center">Defined By</th>
                                        <th class="text-center">Recurrence</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr  ng-repeat="comp in Competencies | filter:search | offset: (CompcurrentPage - 1) * CompnumPerPage | limitTo:CompnumPerPage track by $index" >
                                        <td class="text-left"> {{comp.Description}}</td>
                                        <td class="text-left"> {{comp.DefinedBy}}</td>
                                        <td class="text-left"> {{comp.Recurrence}}</td>
                                        <td class="text-center">
                                            <button type="button" class="btn btn-primary" ng-click="AddToSnapshot(comp.CompDefHeaderID)">
                                              <span class="glyphicon glyphicon-plus"></span>
                                            </button></td>
                                    </tr>
                                </tbody>
                            </table>  
                            <div class="row">
                                <div class="col-lg-6">
                                     <pagination
                                        page="CompcurrentPage"
                                        boundary-links="true"
                                        total-items="Competencies.length"
                                        items-per-page="CompnumPerPage">
                                    </pagination>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
               

                </div>
                <div class="ngdialog-buttons">
                    <button type="button" class="ngdialog-button btn-danger" ng-click="closeThisDialog('Cancel')">Close</button>                    
                </div>
            </script>
                <div id="snapshot" class="row w3-animate-left">
                <div class="col-lg-3">
                    <div class="panel panel-primary filterable ">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a id="assessorsheader" data-parent="#objects" class="clickable" href="#assessors" data-toggle="collapse">Select an Employee
                                </a>
                            </h4>
                        </div>
                        <div id="ssEmployees" class="panel-body pre-scrollable">
                            <div class="list-group " style="width: 100%">
                                <div ng-repeat="ssEmployee in ssEmployees" class="list-group-item ">
                                    <a ng-href="#" ng-model="selectedssEmployee.Name" ng-click="selectEmployee(ssEmployee.Name, ssEmployee.EmployeeID)">
                                        <div>{{ssEmployee.Name}}</div>
                                    </a>

                                </div>
                            </div>
                             
                        </div>
                    </div>
                </div>
                <div class="col-lg-8">
                   <div class="panel panel-info filterable w3-animate-zoom" ng-show="ssEmployeeEmployeeID > 0">
                        <div class="panel-heading">
                            <h4 class="fa-2x panel-title text-center">
                               {{ ssEmployeeName }}'S COMPETENCIES
                            </h4>          
                        </div>
                        <div id="Competencies" class="panel-body">
                            <table class="table table-condensed table-bordered table-hover">
                                <thead>
                                    <tr>
                                        <th class="text-center">Competency Description</th>
                                        <th class="text-center">Defined By</th>
                                        <th>Date Due</th>
                                        <th>Remove</th>
                                    </tr>
                                </thead>
                                <tbody ng-model="employeeComps" >
                                    <tr ng-repeat="employeeComp in employeeComps | filter:search | offset: (currentPage - 1) * numPerPage | limitTo:numPerPage" >
                                        <td class="col-lg-5">
                                           {{employeeComp.Description}}
                                        </td>
                                        
                                        <td class="col-lg-5 input-group-lg">
                                            {{employeeComp.DefinedBy}}
                                        </td>
                                        <td class="col-lg-2 input-group-lg ">
                                             {{employeeComp.DateDue}}
                                        </td>
                                        <td class="col-lg-1 " align="center">
                                            <span class="input-group-btn">                                                
                                                <button type="button" class="btn btn-danger" ng-click="RemoveComp(employeeComp.CompetencyDefHeaderID);" ><i class="fa fa-trash"></i></button>
                                            </span>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="row">
                                <div class="col-lg-8">
                                    <pagination
                                        page="currentPage"
                                        boundary-links="true"
                                        total-items="employeeComps.length"
                                        items-per-page="numPerPage">
                                    </pagination>
                                </div>
                                <div class="col-lg-4" style="padding-right: 25px !important"><br />
                                    <button id="AddComp" type="button" class="btn btn-success pull-right" ng-click="ModalAddAssessor();" >
                                        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> Add Competency
                                    </button>
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
    <script src="../js/CompControllers/Snapshot.js"></script>
     <script src="../js/CompControllers/MngCompetency.js"></script>
     <script src="../js/Angular-Pagination/angularPagination.js"></script>
    <script src="../js/ngDialog.min.js"></script>
</asp:Content>
