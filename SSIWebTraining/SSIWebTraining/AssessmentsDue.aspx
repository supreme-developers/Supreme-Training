<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MobileMaster.Master" AutoEventWireup="true" CodeBehind="AssessmentsDue.aspx.cs" Inherits="SSIWebTraining.AssessmentsDue" %>

<%@ Register Assembly="Syncfusion.EJ.Web, Version=14.3450.0.49, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://cdn.syncfusion.com/14.1.0.41/js/web/flat-azure/ej.web.all.min.css" />
   <%-- <link href="themes/responsive-css/ej.responsive.css" rel="stylesheet" />

    <link href="themes/responsive-css/ejgrid.responsive.css" rel="stylesheet" type="text/css" />--%>
    <style>

       .e-rowcell {

            white-space: normal !important;

        }
        .Collapse:before {
          content: "\e625";
          }
          
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="AssessmentsDueApp">
        <div id="AssessmentsDueCtrl" ng-controller="AssessmentsDueCtrl">
     <div class="row">
            <div class="col-lg-10 col-md-10 col-sm-10">
                <h2><span class="glyphicon glyphicon-th-list"></span>
                    <label></label>
                    Assessments</h2> <asp:Label ForeColor="white" runat="server" Visible="false" ID="LabelMessage" Text=""></asp:Label>
            </div>
            <div class="col-lg-2">
                    <%--<button type="button" class="btn btn-success  pull-right" onclick="location.href='/AdminTools/DefineCA.aspx'"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> New Competency</button>--%>
            </div>

        </div>
         
            <div class="row">
                <div class="col-lg-12">
                    
                     <telerik:RadComboBox runat="server" ID="EmployeeList" TabIndex="2" EmptyMessage="Select an Employee"
                         OnClientSelectedIndexChanged="OnClientSelectedIndexChanged" 
                        Style="width: 100%"
                        InputCssClass="form-control input-lg" Skin="MetroTouch" ShowToggleImage="True"
                            DataValueField="EmployeeID" DataTextField="EmployeeNumber">                                             
                    </telerik:RadComboBox>
                    <br />
                       <div class="row">
                <div class="col-lg-12">
                    <div id="searchControl" class="col-lg-12 input-group input-group-lg hidden">
                        <input id="searchbox" type="text" placeholder="Search Competencies..." class="form-control input-lg e-ejinputtext" />
                        <span class="input-group-btn">
                            <button id="search" type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                        </span>
                    </div>
                </div>
            </div><br />
                     <div id="Grid">
                      
                     </div>
               
                </div>
        </div>
            </div>
      
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
    <script src="https://code.angularjs.org/tools/system.js"></script> 

   <script src="http://cdn.syncfusion.com/js/assets/external/jsrender.min.js"></script>
    <script src="http://cdn.syncfusion.com/14.3.0.52/js/web/ej.web.all.min.js"> </script> 
    <script src="http://cdn.syncfusion.com/14.3.0.52/js/common/ej.widget.angular.min.js"> </script>
    <script src="js/CompControllers/AssessmentsDue.js"></script>
<%--     <script src="systemjs.config.js"></script>--%>

    <script>
        $("body").keydown(function () {
            if (event.keyCode == 13) {
                document.activeElement.blur();
                return false;
            }
        });
      //  var gridObj = $("#Grid").ejGrid("instance");
        $(function () {
          //  angular.element('#AssessmentsDueCtrl').scope().GetAssessorAssessments('709');
          //  buildGrid();
        });
        //$('#searchbox').keyup(function (event) {
        //    return false;
        //            event.preventDefault();
        //            if (event.keyCode == 13) {
        //                alert('stop');
        //                $("#search").click();
                        
        //            }
        //        });
        function OnClientSelectedIndexChanged(sender, eventArgs) {         
            $('#searchControl').removeClass('hidden');
            var item = eventArgs.get_item();

            angular.element('#AssessmentsDueCtrl').scope().GetAssessorAssessments(item.get_value());
           
          //  console.log(item.get_value());
            buildGrid();
           
            
        }
        function buildGrid()
        {
            
            if (typeof angular.element('#AssessmentsDueCtrl').scope().Assessments !== "undefined" && angular.element('#AssessmentsDueCtrl').scope().Assessments.length > 1) {
                
                $('#searchbox').change(function () {
                    onSearching();
                });
              
                $("#Grid").ejGrid({
                    columns: [
                             { field: "Description", headerText: "Comptency", allowFiltering: true},
					         { field: "PercentComplete", headerText: "Percent Completed", format: "{0:p0}"},					        
					         {
					             headerText: "Begin Assessing",
					             commands: angular.element('#AssessmentsDueCtrl').scope().command,
					             isUnbound: true
					         }
                    ],
                    dataSource: angular.element('#AssessmentsDueCtrl').scope().Assessments,
                    allowSearching: true,
                    allowPaging: true,
                    pageSettings: { pageSize: 10 },
                    detailsDataBound: function (args){console.log},
                  
                    toolbarSettings: {
                        showToolbar: true,
                        customToolbarItems: ["Collapse", {
                            templateID: "#Refresh"
                        }]
                    },
                    toolbarClick: "onToolBarClick",
                    collapseAll: true
                });
                $("#search").ejButton({ click: "onSearching", size: "small" });
               // var gridObj = $("#Grid").ejGrid("instance");
            }
            else {
                setTimeout(function () {
                    buildGrid();
                }, 250);
            }
        }
       
        function onSearching(args) {
           
            var obj = $("#Grid").ejGrid("instance");
            var val = $("#searchbox").val();
          
            obj.search(val);
        }
        function onToolBarClick(args) {
            var tbarObj = $(args.target),
              grid = this;
            if (tbarObj.hasClass("Collapse")) grid.collapseAll(); 
        }

        function AddDaysToDate(sDate, iAddDays, sSeperator) {
            //Purpose: Add the specified number of dates to a given date.
            var date = new Date(sDate);
            date.setDate(date.getDate() + parseInt(iAddDays));
            var sEndDate = LPad(date.getMonth() + 1, 2) + sSeperator + LPad(date.getDate(), 2) + sSeperator + date.getFullYear();
            return sEndDate;
        }
        function LPad(sValue, iPadBy) {
            sValue = sValue.toString();
            return sValue.length < iPadBy ? LPad("0" + sValue, iPadBy) : sValue;
        }

        function onClick(args) {
            var gridObj = $("#Grid").data("ejGrid");
            //getting corresponding record
            var data = gridObj.getSelectedRecords()[0].Name;
            location.href = 'Assessment.aspx?assessmentID=' + data;
        }
    </script>
   
</asp:Content>

