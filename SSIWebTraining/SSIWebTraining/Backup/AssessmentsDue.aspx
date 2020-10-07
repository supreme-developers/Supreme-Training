<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="AssessmentsDue.aspx.cs" Inherits="SSIWebTraining.AssessmentsDue" %>


<%@ Register Assembly="Syncfusion.EJ.Web, Version=14.3.0.49, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.JavaScript.Web" TagPrefix="ej" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="http://cdn.syncfusion.com/14.1.0.41/js/web/flat-azure/ej.web.all.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div ng-app="AssessmentsDueApp">
    <div ng-controller="AssessmentsDueCtrl">
    <div class="content-container-fluid">
        <div class="row">
            
            <div class="cols-sample-area">
                <ej:grid runat='server' [allowPaging]="true" [allowSorting]="true" [dataSource]="Assessments">
                    <e-columns></e-columns>

                </ej:grid>

                <div id="grouping" ej-grid e-datasource="Assessments" e-allowpaging="true"  e-allowgrouping="true"  e-groupsettings="grouping">
                    <div e-columns>
                        <div e-column e-field="Name" e-headertext="Employee"  e-textalign="right" e-width="75"></div>
                      <div e-column e-field="Description" e-headertext="Competency" e-width="80"></div>
                        <div e-column e-field="DefinedBy" e-headertext="Defined By" e-textalign="right"  e-width="75"></div>
                        <div e-column e-field="Recurrence" e-headertext="Freight" e-textalign="right" e-width="75"></div> <%--e-format="{0:C}"--%>
                       
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
    </div> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
    <script src="https://code.angularjs.org/tools/system.js"></script> 

   <script src="http://cdn.syncfusion.com/js/assets/external/jsrender.min.js"></script>
    <script src="http://cdn.syncfusion.com/14.1.0.41/js/web/ej.web.all.min.js"> </script> 
    <script src="http://cdn.syncfusion.com/14.1.0.41/js/common/ej.angular2.min.js"></script>
    <script src="js/CompControllers/AssessmentsDue.js"></script>
<%--     <script src="systemjs.config.js"></script>--%>
   
</asp:Content>

