<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MobileMaster.Master" AutoEventWireup="true" CodeBehind="Assessment.aspx.cs" Inherits="SSIWebTraining.Assessment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="AdminTools/css/MngCompetencies.css" rel="stylesheet" />
        <link href="pretty-checkbox-master/src/pretty.css" rel="stylesheet" />
 <style>
     .box{
         min-height: 100px !important;
           position: relative !important;
         /*border-top: 5px solid green !important;
         border-top-width: 20px;*/
     }
     .arrows{
         font-size:45px;
         cursor:pointer;
     }
     .progressBar {
          border-top: 2px solid green;
          position: absolute;          
          /*width:1%;*/
          left:0;
          top:0;
          border-top-width: 7px;
          border-radius: 2px;
        }

  
    
 </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="modAssessment">
        <div id="AssessmentCtrl" ng-controller="AssessmentCtrl">
           <%-- <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    
                </div>
            </div>
            <br />--%>
            <div id="Tasks">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <table>
                            <tr>
                                <td align="left"> 
                                    <h2>
                                    <label id="description">{{CompName}}</label>
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">   <h5> <label id="emp">{{Employee}}</label></h5></td>
                            </tr>
                        </table>
                       
                     <br />
                        
                        <div class="col-lg-8 col-md-12 col-sm-12 col-lg-offset-2" ng-repeat="task in Tasks track by $index ">
                            <div id="{{'div' + $index}}" class="box" ng-hide="!isCurrentSlideIndex($index)">
                                <div id="{{'progressBar' + $index}}" class="progressBar"></div>
                                <div class="box-content">
                                    <h3 class="tag-title w3-animate-opacity fa-1x">{{ $index+1 + "." + "  " + task.Task }}</h3>
                                    <hr />
                                    <div class="row w3-animate-opacity">
                                        <div class="col-lg-10 col-lg-offset-2">
                                            <div class="pretty circle smooth outline-success fa-2x" style="border-radius: 0px; box-shadow: none">
                                                <input type="radio" name="{{'comp' + $index}}" ng-model="task.Competent" ng-value="true" ng-change="CompChange(task, $index)" />
                                                <label><i class="fa fa-smile-o fa-4x"></i>{{task.PositiveLabel}}</label>
                                            </div>
                                            <div class="pretty circle smooth outline-danger fa-2x" style="border-radius: 0px; box-shadow: none">
                                                <input type="radio" name="{{'comp' + $index}}" ng-model="task.Competent" ng-value="false" ng-change="CompChange(task, $index)" />
                                                <label><i class="fa fa-frown-o"></i>{{task.NegativeLabel}}</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div ng-show="task.Competent == 0" class="row">
                                        <div class="col-lg-10 col-lg-offset-1">
                                            <textarea type="text" rows="10" maxlength="255" ng-keyup="countCharacters(task);" class="form-control input-lg" name="{{'note' + $index}}" ng-model="task.Note" ></textarea>
                                            Characters needed to continue: <label class="text-danger">{{totalCharNeeded}}</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <span class="fa fa-chevron-left pull-left arrows fa-3x previousarrow" ng-hide="hideLeftArrow($index)" ng-click="prevSlide()"></span>
                                    <span class="fa fa-chevron-right pull-right arrows success fa-3x nextarrow" ng-hide="hideRightArrow($index, task)" ng-click="nextSlide(task)"></span>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8 col-md-12 col-lg-offset-2">
                        <button type="button" class="btn btn-primary btn-lg btn-block" ng-click="backToList();">Save & Exit <span class="glyphicon glyphicon-floppy-open" aria-hidden="true"></span></button>
                    </div>

                </div>
            </div>
            <div id="Review" class="hidden">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <div class="col-lg-8 col-md-12 col-sm-12 col-lg-offset-2" >
                            <button id="print" type="button" class="btn btn-info btn-lg btn-block" ng-show="trainingView" > Print <span class="glyphicon glyphicon-print" aria-hidden="true"></span></button><br />
                        <h3 class=" text-info"><strong>To complete, review the Competency and have the employee sign off below.</strong></h3>
                            <div class="box printMe">
                                <h2>{{CompName}}</h2>
                                <div class="row text-nowrap">
                                    <div class="col-lg-6 col-md-12 col-sm-12">
                                        <label>Employee: </label>
                                        &nbsp;<label class="text-success">{{' ' + Employee}}</label>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <label>Date: </label>
                                        &nbsp;<label class="text-success">{{DateAssessed}}</label>
                                    </div>
                                    <div class="col-lg-3 col-md-12 col-sm-12">
                                        <label>Competent: </label>
                                        &nbsp;<label class="text-success">{{EmployeeisCompetent}}</label>
                                    </div>
                                </div>
                                <div class="box-content" ng-repeat="task in Tasks track by $index "> 
                                    <h4 class="tag-title w3-animate-opacity fa-1x">{{ task.Task }}</h4>                                    
                                    <div class="row w3-animate-opacity">
                                        <div class="col-lg-8 col-lg-offset-0">
                                            <div class="pretty circle smooth outline-success fa-1x" style="border-radius: 0px; box-shadow: none">
                                                <input type="radio" name="{{'review' + $index}}" ng-disabled="trainingView" ng-model="task.Competent" ng-value="true" ng-change="CompChange(task, $index)" />
                                                <label><i class="fa fa-smile-o " ></i>{{task.PositiveLabel}}</label>
                                            </div>
                                            <div class="pretty circle smooth outline-danger fa-1x" style="border-radius: 0px; box-shadow: none">
                                                <input type="radio" name="{{'review' + $index}}" ng-disabled="trainingView" ng-model="task.Competent" ng-value="false" ng-change="CompChange(task, $index)" />
                                                <label><i class="fa fa-frown-o"></i>{{task.NegativeLabel}}</label>
                                            </div>
                                        </div>
                                    </div>
                                     <div ng-show="task.Competent == 0" class="row">
                                        <div class="col-lg-10 col-lg-offset-0">
                                            <textarea type="text" rows="10" maxlength="255" class="form-control input-lg" 
                                                name="{{'note' + $index}}" ng-model="task.Note" ng-blur="saveTask(task)" ></textarea>
                                        </div>
                                        <div class="col-lg-2">
                                            <button type="button" class="btn btn-success hidden" ng-click="saveTask(task)">Save <span class="fa fa-floppy-o" aria-hidden="true"></span></button>
                                        </div>
                                    </div>
                                    <hr />
                                </div>
                                <div class="row" ng-show="trainingView">
                                    <div class="col-lg-12 text-nowrap">
                                        <table>
                                            <tr>
                                                <td align="right" class="col-lg-3 "><b>Assessor (ES):</b> {{' ' + Assessor }}  </td>
                                                <td align="right" class="col-lg-9 text-left pull-left "><b>Employee (ES): </b>{{' ' + Employee }}   </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                        </div>
                    </div>
                    
                </div>
                <div class="row" ng-hide="trainingView">
                    <div class="col-lg-8 col-md-12 col-sm-12 col-lg-offset-2">
                        <div class="input-group ">
                            <span class="input-group-addon" id="basic-addon1">Time Card Number</span>
                            <input id="lastSix" type="password" ng-disabled="IsCompetent != null" class="form-control input-lg" ng-model="EmployeeSign_LastSix" placeholder="Sign off with Time Card Number" />

                            <span class="input-group-btn">
                                <button type="button" class="btn btn-success btn-lg " ng-hide="IsCompetent != null"  ng-click="CompleteCompetency()">Submit <span class="fa fa-check" aria-hidden="true"></span></button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
    <script src="js/CompControllers/Assessment.js"></script>
    <script src="printThis-master/printThis.js"></script>
    <script>
        $(function () {
          
        });
        $('#print').click(function(){
            $(".printMe").printThis({
                printContainer: false,
                importStyle: true
            });
        });
    </script>

</asp:Content>
