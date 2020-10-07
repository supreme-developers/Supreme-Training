<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="CompGroups.aspx.cs" Inherits="SSIWebTraining.CompGroups" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Comptency Groups  </h2><br /><br />
    <h4>Add a Group</h4>
    <div ng-app="GroupApp">
        <div ng-controller="GroupCtrl">

    <div id="divAddRow" class="row" > 
        <div class="col-lg-8" >
              <div id="row1" ng-repeat="group in groups" class="input-group input-group-lg addGroup w3-animate-bottom">
                        <input id="{{'input' + $index}}" class="form-control input-lg txtAddGroup" ng-keypress="AddElement($index);" 
                            ng-model="group.GroupName" placeholder="Group Name..." /> 
                        <span class="input-group-btn">
                          <button id="{{'btn' + $index}}" type="button" ng-click="AddGroup(group, $index);"
                              class="btn btn-info btn-flat"><i id="{{'i' + $index}}" class="fa fa-plus"></i></button>
                        </span>
               </div>            
        </div>
    </div>
    <h4>Current Groups</h4>
    <div id="divEditRow" class="row">
         <div class="col-lg-8" ng-repeat="data in editGroups track by $index">             
              <div   class="input-group input-group-lg editGroup w3-animate-top" >
                  <input id="{{'einput' + $index}}" type="text" class="form-control input-lg" 
                      ng-model="data.GroupName" disabled/>
                    <span class="input-group-btn">
                      <button id="{{'ebtn' + $index}}" type="button" class="btn btn-info btn-flat" ng-click="EditGroup($index, data);"><i id="{{'ei' + $index}}" class="fa fa-pencil"></i></button>
                      <button type="button" class="btn btn-danger" ng-click="DeleteGroup($index, data);"><i class="fa fa-trash"></i></button>
                    </span>
                    
               </div>
        </div>
    </div>
            </div>
        </div>
    <style>
        .addGroup
        {
            margin-bottom: 20px;
        }
        .editGroup{
            margin-bottom: 20px;
        }
        /* now the element will fade out before it is removed from the DOM */
        input[type="text"][disabled] {
           color: darkgray;
           background-color: #D3D9DD;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
    <%--<script src="../js/AppFactory.js"></script>--%>
    <script src="../js/CompControllers/CompGroups.js"></script>
    <script>
   
        $(function () {
            CreateScripts();
        });
       
        function CreateScripts()
        {
            //$(document).on('keydown', '.txtAddGroup', (function (e) {
            //    //this function clones the parent group and if one below it does not exist, it adds it to the DOM
            //    var currentRowNum = $(this).parent().attr('id').replace(/row/, '');
            //    var nxtRowNum = parseInt(currentRowNum, 10) + 1;
            //    if ($('#row' + nxtRowNum).parent().length === 0) {
                   
            //        $('div.addGroup:last').after($('<br/>').add($('div.addGroup:first').clone().prop('id', 'row' + nxtRowNum)));                   
            //        $('div.addGroup:last input').val('');
            //    }
            //}));
        }
    </script>
</asp:Content>