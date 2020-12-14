<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="Assessment.aspx.cs" Inherits="SSIWebTraining.Assessment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="modAssessment">
        <div id="AssessmentCtrl" ng-controller="AssessmentCtrl" >
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <h2>
                        <label id="description">Start</label> an Assessment
                    </h2>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                     <select id="ddlEmployees" class="form-control input-lg w3-round" 
                         ng-model="selectedEmployee" ng-change="GetEmployeeCompetencies(selectedEmployee)">   
                        <option value="" selected>Select an Employee</option>
                        <option ng-repeat="employee in Employees"
                             value="{{employee.EmployeeID}}"  >{{employee.name}}</option>      
                    </select>
                     <%--class="selectpicker" ng-options="employee as employee.name for employee in Employees"--%>
                </div>
                 <div class="col-lg-6">
                    </div>
            </div><br /><br />
             <div class="row">
                  <h3>
                        {{selectedEmployee.name}}'s Competency Assessments
                   </h3>
                    <div class="col-lg-12 text-center w3-animate-bottom">
                        <div class="col-lg-3 col-md-6 col-sm-12" ng-repeat="data in employeeCompetencies track by $index ">
                            <div id="{{'div' + $index}}" class="box">
                                 <span class="pull-right-container">
                                          <small class="label pull-right bg-red">Due in 3 days</small>
                                        </span><br />
                                <span class="box-content">
                                    <%--<h2><i class="fa fa-clipboard fa-1x"></i></h2>--%>
                                    <h2 class="tag-title">{{ data.Description }}</h2>
                                    <h3 class="tag-title2">{{ data.DefinedBy }}
                                    </h3>
                                    <hr />
                                    <p>
                                      <i class="glyphicon glyphicon-question-sign"></i>
                                       Passing Grade {{ data.PassingGrade}}
                                    </p>
                                    <br />
                                    <button id="{{ data.CompDefHeaderID }}" type="button" index="{{ $index }}" 
                                        class="btn btn-success btn-block editComp fa-2x"> Begin
                                        <i class="glyphicon glyphicon-play-circle "></i> </button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
    <style>
   
    </style>
    <script src="js/CompControllers/Assessment.js"></script>
 
    <script>
        $(function () {
           
        });
    </script>
</asp:Content>
