<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="DefineCA.aspx.cs" Inherits="SSIWebTraining.AdminTools.DefineCA" %>

<%@ Register Assembly="Syncfusion.Shared.Web, Version=13.3451.0.7, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.Web.UI.WebControls.Shared" TagPrefix="syncfusion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <link href="css/MngCompetencies.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-10 col-md-10 col-sm-10">
            <h2>
                <span class="fa fa-plus"></span>
                <label id="pageType"></label>
                Competency</h2>
        </div>
        <div class="col-lg-2 ">
            <button type="button" class="btn btn-info pull-right" onclick="location.href='/AdminTools/EditCA.aspx'"><span class="glyphicon glyphicon-th-list" aria-hidden="true"></span>  Competency List</button>
        </div>
    </div>
    <br />
    <div ng-app="CompApp">
        <div class="panel-group" id="accordion">
            <div id="CACtrl" ng-controller="CACtrl">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a id="collapseSetup" data-toggle="collapse" class="clickable" data-parent="#accordion" href="#Setup"><span class="glyphicon glyphicon-wrench"></span>
                                <label id="lblSetup" class="clickable" >Step 1: Setup </label> {{"  -  " + defHeaderObj.Description }}
                            </a>
                        </h4>
                    </div>
                    <div id="Setup" class="panel-collapse collapse in">
                        <div class="panel-body text-center">
                            <div class="row ">
                                <div class="col-lg-4 col-lg-offset-1">
                                    <div class="row form-group">
                                        <%--<label for="Jobroles" class="col-form-label col-lg-3">Description </label>--%>
                                        <div class="col-lg-12">
                                            <h4 class="pull-left">Description</h4>
                                            <input id="Descr" class="form-control input-lg" required ng-model="defHeaderObj.Description"
                                                placeholder="Description..." tabindex="1" />
                                            <p id="pDescr" class="text-red pull-left hidden">Description is required</p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-lg-12 pull-left">
                                            <span class="text-blue pull-left">Define Competency by: </span>
                                            <label class="radio-inline pull-left">
                                                <input id="rRole" type="radio" name="define" value="Role" divname="Role" />Role
                                            </label>
                                            <label id="resp" class="radio-inline pull-left">
                                                <input id="rResp" type="radio" name="define" value="Resp" divname="Responsibility" />Responsibility
                                            </label>
                                            <label class="radio-inline pull-left">
                                                <input id="rTitle" type="radio" name="define" value="Title" divname="Title" />Title
                                            </label>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div id="Role" class="col-lg-12 hidden w3-animate-zoom defineBy">

                                            <telerik:RadComboBox runat="server" ID="Jobroles" EmptyMessage="Select a Job Role"
                                                EnableEmbeddedSkins="false" Style="width: 100%" TabIndex="2"
                                                MarkFirstMatch="true" DataValueField="ID"
                                                Skin="MetroTouch" ShowToggleImage="True" InputCssClass="form-control input-lg" CheckBoxes="false"
                                                EnableCheckAllItemsCheckBox="true" DataTextField="JobRole">
                                            </telerik:RadComboBox>
                                        </div>
                                        <div id="Responsibility" class="col-lg-12 hidden w3-animate-left defineBy">
                                            <telerik:RadComboBox runat="server" ID="RadComboBoxJobResp" EmptyMessage="Select a Responsibilty" TabIndex="2"
                                                DataValueField="QualificationID" EnableLoadOnDemand="true" Style="width: 100%"
                                                Skin="MetroTouch" ShowToggleImage="True" InputCssClass="form-control input-lg" CheckBoxes="false"
                                                DataTextField="Qualification">
                                            </telerik:RadComboBox>
                                        </div>
                                        <div id="Title" class="col-lg-12 hidden w3-animate-right defineBy">
                                            <telerik:RadComboBox runat="server" ID="RadComboBoxJobTitles" TabIndex="2" EmptyMessage="Select a Job Title" Style="width: 100%"
                                                InputCssClass="form-control input-lg" DataValueField="JobTitleID"
                                                Skin="MetroTouch" ShowToggleImage="True" CheckBoxes="false" DataTextField="JobTitle">
                                            </telerik:RadComboBox>
                                        </div>
                                        <p id="pDefineBy" class="text-red pull-left hidden">A Job Role, Responsibility, or Title is required for each Competency.</p>
                                    </div>
                                    <div class="row form-group">
                                        <%--<label for="RadComboBoxJobTitles" class="col-lg-3 col-form-label">Job Title</label>--%>
                                        <div class="col-lg-12">
                                            <h4 class="pull-left">Passing Grade</h4>
                                            <input id="PassingGrade" class="form-control input-lg" required ng-model="defHeaderObj.PassingGrade"
                                                placeholder="Passing Grade..." tabindex="4" />
                                            <p class="text-red pull-left hidden">Please enter a NUMERIC Passing Grade.</p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <%--<label for="RadComboBoxJobTitles" class="col-lg-3 col-form-label">Job Title</label>--%>
                                        <div class="col-lg-12"><h4 class="pull-left">Notify Days</h4>
                                            <input id="NotifyDays" class="form-control input-lg" required ng-model="defHeaderObj.NotifyDays"
                                                placeholder="Notify Days..." tabindex="6" />
                                            <p class="text-red pull-left hidden">Please enter NUMERIC Notification Day(s).</p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-lg-offset-1">
                                    <div class="row form-group">
                                        <%--<label for="NotifyDays" class="col-lg-3 col-form-label">Notify Days</label>--%>
                                         <div class="col-lg-12"><h4 class="pull-left">Notify Email<span style="font-size: 12px"> (separate multiple emails with semicolon(;))</span></h4>
                                            <input id="NotifyEmail" class="form-control input-lg" required ng-model="defHeaderObj.NotifyEmail"
                                                placeholder="Notify Email..." tabindex="6" type="email" />
                                            <p class="text-red pull-left hidden">Please enter a correct Email Address.</p>
                                        </div>
                                       
                                    </div>
                                    <div class="row form-group">
                                        <%--<label for="recQ" class="col-lg-3 col-form-label">Recurrence Quantity</label>--%>
                                        <div class="col-lg-6">
                                            <h4 class="pull-left">Recurrence Qty</h4>
                                            <%--<label for="recQ" class="col-form-label">Recurrence Quantity</label><br />--%>
                                            <input id="recQ" class="form-control input-lg" required ng-model="defHeaderObj.RecurrenceQty"
                                                placeholder="Recurrence Qty..." tabindex="7" />
                                            <p class="text-red pull-left hidden">Please enter a NUMERIC Recurrence Quantity.</p>
                                        </div>
                                        <div class="col-lg-6">
                                            <h4 class="pull-left">Unit of Measure</h4>
                                            <telerik:RadComboBox runat="server" ID="RadComboBoxUOM" EmptyMessage="Unit of Measure"
                                                MarkFirstMatch="true" DataValueField="SchedulingRecurrenceUOMID" EnableLoadOnDemand="true" Style="width: 100%"
                                                Skin="MetroTouch" ShowToggleImage="True" InputCssClass="form-control input-lg" CheckBoxes="false"
                                                EnableCheckAllItemsCheckBox="true" DataTextField="Description" TabIndex="8">
                                            </telerik:RadComboBox>
                                            <p class="text-red pull-left hidden">Please select a Unit of Measure.</p>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <%--<label for="recQ" class="col-lg-3 col-form-label">Recurrence Quantity</label>--%>
                                        <div class="col-lg-6">
                                            <h4 class="pull-left">On Failure Recurrence Qty</h4>
                                            <%--<label for="recQ" class="col-form-label">Recurrence Quantity</label><br />--%>
                                            <input id="frecQ" class="form-control input-lg" required ng-model="defHeaderObj.Failure_RecurrenceQty"
                                                placeholder="Failure Recurrence Qty..." tabindex="7" />
                                            <p class="text-red pull-left hidden">Please enter a NUMERIC Failure Recurrence Quantity.</p>
                                        </div>
                                        <div class="col-lg-6">
                                            <h4 class="pull-left">Failure Unit of Measure</h4>
                                            <telerik:RadComboBox runat="server" ID="RadComboBoxFUOM" EmptyMessage="Unit of Measure"
                                                MarkFirstMatch="true" DataValueField="SchedulingRecurrenceUOMID" EnableLoadOnDemand="true" Style="width: 100%"
                                                Skin="MetroTouch" ShowToggleImage="True" InputCssClass="form-control input-lg" CheckBoxes="false"
                                                EnableCheckAllItemsCheckBox="true" DataTextField="Description" TabIndex="8">
                                            </telerik:RadComboBox>
                                            <p class="text-red pull-left hidden">Please select a Unit of Measure for Assessment Failures.</p>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <button id="saveHeader" type="button" class="btn btn-lg btn-success pull-right"><i class="glyphicon glyphicon-floppy-disk"></i> Save</button>
                        </div>
                    </div>
                </div>
                <div id="CurrentQuestions"  class="panel panel-default hidden">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a id="collapseCurrentQuestions" class="clickable" data-toggle="collapse" data-parent="#accordion" href="#panelCQ"><span class="glyphicon glyphicon-question-sign"></span>
                                <label class="clickable">Current Questions</label>
                            </a>
                        </h4>
                    </div>
                    <div id="panelCQ"  class="panel-collapse collapse">
                        <div class="panel-body text-center">
                            <div class="row">
                                <div class="col-lg-12">
                                 <button id="AddTasks" type="button" class="btn btn-success pull-right" data-toggle="collapse" href="#DragDrop">
                                        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> Add Tasks
                                    </button>    
                                </div>
                            </div>
                            <div class="row">       
                                     
                                <div class="col-lg-10" >
                                    <div id="MngCompCtrl" class="row"  ng-controller="MngCompCtrl">
                                        <div class="col-lg-12 text-center w3-animate-left boxheader">    <%--ng-init="getCompetencyDefinitionDetails()"     --%>                                     
                                            <div class="col-lg-3 col-md-4 col-sm-12" ng-repeat="data in HeaderDefObjects track by $index ">
                                                <div id="{{'divcurrent' + $index}}" class="box" >
                                                    <div class="bgimages" ng-class="needCheckMark({{ data.CompDefHeaderID }})">
                                                        <span id="{{'span' + data.CompetencyID }}" competencyid="{{ data.CompetencyID }}" 
                                                            myIndex="{{ $index }}"  class="fa fa-times fa-3x pull-right danger"
                                                            onclick="RemoveCompetency(this);" ></span>
                                                        <div class="box-content">
                                                            
                                                            <%--<img class="check" src="../img/blueCheck.png" width="50" height="50" />--%>
                                                            <%--<h2><i class="fa fa-clipboard fa-1x"></i></h2>--%>
                                                            <h2 class="tag-title">{{ data.CompetencyTypeName }}</h2>
                                                            <h3 class="tag-title2">Level {{ data.LevelID }}
                                                            </h3>

                                                            <hr />
                                                            <p>
                                                                <i class="glyphicon glyphicon-question-sign"></i>
                                                                {{ data.Question | cut:true:75:' ...'}}
                                                            </p>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="panelTasks" class="panel panel-success">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a id="collapseDragDrop" data-parent="#accordion" class="clickable" href="#DragDrop" data-toggle="collapse"><span id="spanTasks" class="glyphicon glyphicon-plus"></span>
                                <label class="clickable" id="labelAddTasks">Step 2: Add Tasks</label>
                            </a>
                        </h4>
                    </div>
                    <div id="DragDrop" class="panel-collapse collapse" >
                        <%--<div class="panel-body text-center">--%>
                            <div id="divAddRow" class="row" ng-controller="CompCtrl">
                                <div class="col-lg-10 col-lg-offset-1"><br />
                                    <div id="row1" ng-repeat="task in tasks" class="input-group input-group-lg addTask w3-animate-bottom">
                                        <input id="{{'input' + $index}}" class="form-control input-lg" taskindex="{{ $index }}" onkeypress="EnterKeyPressed(event, this)" 
                                             ng-model="task.Task" placeholder="Add New Task Here..." ng-keypress="AddTaskElement($index)" />
                                        <span class="input-group-btn">
                                            <button id="{{'btn' + $index}}" type="button" ng-click="AddTask(task, $index);"
                                                class="btn btn-info btn-flat">
                                                <i id="{{'i' + $index}}" class="fa fa-plus"></i>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                                
                            </div>
                        <div class="row" ng-show="loading">
                            <div class="col-lg-10 col-lg-offset-5">
                                <div class="fa fa-spinner fa-5x faa-spin animated"  ></div>
                            </div>
                        </div>
                        
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="row">
                                        <div class="col-lg-10 col-lg-offset-1">
                                            <div class="panel panel-default filterable" ng-hide="currentTasks.length == 0"  > <%----%>
                                                <div class="panel-body text-center">
                                                    <div class="row">
                                                        <div class="col-lg-10 col-lg-offset-1 input-group input-group-lg">
                                                            <input id="searchbox" type="text" placeholder="Search..." class="form-control input-lg"
                                                                ng-model="searchTasks" />
                                                            <span class="input-group-btn">
                                                                <button type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                                                            </span>                                   
                                                              <select id="top-rows-per-page" class="form-control"  ng-model="numPerPage"
                                                                  ng-options='option.value as option.name for option in itemNumberOptions' >
                                                                  <option value="" selected>Tasks Per Page</option>
                                                               </select>
                                                        </div>
                                                    </div>
                                                    <br /> 
                                                    <div id="divEditRow" class="row">
                                                       
                                                        <table class="table table-condensed table-bordered
                                                            table-hover">
                                                            <thead>
                                                                <tr>
                                                                    <th class="text-center">Move</th>
                                                                     <%--<th class="text-center">Sort</th>--%>
                                                                     <th  class="text-center">Task</th>
                                                                     <th></th>
                                                                </tr>
                                                            </thead>
                                                            <tbody id="sortable"  ng-model="filteredcurrentTasks" >
                                                                <tr ng-repeat="task in filteredcurrentTasks | filter:searchTasks track by $index" style="cursor: move;" >
                                                                <td   class="col-lg-1">
                                                                   <span id="tdMove" class="glyphicon glyphicon-move fa-2x"></span><%--<input value="{{ $index + 1 }}" />--%>
                                                                </td>
                                                                   <%-- <td class="col-lg-1 input-group-lg">
                                                                        <input id="{{'sort' + $index}}" type="text" class="form-control input-lg"
                                                                        ng-model="task.Sort" disabled />

                                                                    </td>--%>
                                                                    <td class="col-lg-9 input-group-lg">
                                                                        <input id="{{'einput' + $index}}" type="text" class="form-control input-lg" 
                                                                            ng-model="task.Task" disabled  />
                                                                    </td>
                                                                    <td class="col-lg-1 input-group-lg pull-left">
                                                                        <span class="input-group-btn">
                                                                        <button id="{{'ebtn' + $index}}" type="button" class="btn btn-info btn-flat" ng-click="EditItem($index, task, 'UpdateTask', null, $scope);"><i id="{{'ei' + $index}}" class="fa fa-pencil"></i></button>
                                                                        <button type="button" class="btn btn-danger" ng-click="DeleteItem($index, task, 'DeleteTask', filteredcurrentTasks);"><i class="fa fa-trash"></i></button>
                                                                    </span>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        
                                                      
                                                    </div>
                                                    <pagination
                                                        page="currentPage"
                                                        boundary-links="true"
                                                        total-items="currentTasks.length"
                                                        items-per-page="numPerPage">
                                                        </pagination>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                             <%-- Div below is no longer used --%>
                            <div class="row" style="display:none">
                                <asp:Repeater ID="rptTabs" runat="server">
                                    <HeaderTemplate>
                                        <div id="groups" class="col-lg-2 col-md-0 col-sm-0 col-xs-0 bhoechie-tab-menu">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div id="groupList" class="list-group list-group-horizontal">
                                            <a id="a<%# Eval("CompetencyGroupID") %>" ng-click="setGroupID($event, null);" onclick="setGroupID(this.id);"
                                                href="#" indexnum="<%# Container.ItemIndex%>" class="list-group-item text-center groupLink
                                                    <%# Container.ItemIndex == 0 ? " active" : ""%>">
                                                <%# Eval("GroupName") %>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <div class="col-lg-10" ng-controller="CompCtrl">
                                    <div id="search" class="row typelevelrow">
                                        <div id="divSearch" class="col-lg-4">
                                            <div class="input-group input-group-lg">
                                                <input id="searchBar" type="text" placeholder="Search..." ng-model="searchText" class="form-control input-lg">
                                                <span class="input-group-btn">
                                                    <button type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                                                </span>

                                            </div>
                                        </div>
                                        <div class="col-lg-2 col-sm-6">
                                            <select class="form-control input-lg" ng-model="selectedTypes"
                                                ng-options="type as type.CompetencyTypeName for type in types">
                                                <option value="" selected>All Types</option>
                                            </select>
                                        </div>
                                        <div class="col-lg-2 col-sm-6">
                                            <select class="form-control input-lg" ng-model="selectedLevels" ng-options="level as level.Level for level in levels">
                                                <option value="" selected>All Levels</option>
                                            </select>

                                        </div>
                                        <div class="col-lg-2 col-sm-12">
                                            <button id="SaveCompelete" type="button" class="btn btn-success"><span class="glyphicon glyphicon-floppy-save" aria-hidden="true"></span>Save and Complete</button>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 text-center w3-animate-top boxheader">
                                            <div class="col-lg-4 col-md-6 col-sm-12" ng-repeat="data in currentComps | filter:searchText |
                                                         filter: {CompetencyTypeID : selectedTypes.CompetencyTypeID}: true | filter: {LevelID : selectedLevels.LevelID}: true track by $index ">
                                                <div id="{{'div' + $index}}" class="box">
                                                    <div id="{{'bgimage' + data.CompetencyID }}" class="bgimages" competencyid="{{ data.CompetencyID }}"
                                                        onclick="selectComp(this);" ng-class="needCheckMark({{ data.CompDefHeaderID }})">
                                                        <div class="box-content">
                                                            <%--<img class="check" src="../img/blueCheck.png" width="50" height="50" />--%>
                                                            <%--<h2><i class="fa fa-clipboard fa-1x"></i></h2>--%>
                                                            <h2 class="tag-title">{{ data.CompetencyTypeName }}</h2>
                                                            <h3 class="tag-title2">Level {{ data.LevelID }}
                                                            </h3>

                                                            <hr />
                                                            <p>
                                                                <i class="glyphicon glyphicon-question-sign"></i>
                                                                {{ data.Question | cut:true:75:' ...'}}
                                                            </p>

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div><br />
                            <%-- Div above is no longer used --%>
                        <%--</div>--%>
                    </div>
                </div>
                 
                <%-- Final Panel Ends Here --%>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
    <script src="../js/CompControllers/MngCompetency.js"></script>
    <script src="../js/Angular-Pagination/angularPagination.js"></script>
 
    <script>
       
        function Wait(e, object)
        {
           
            e.preventDefault();
            
        }
        function EnterKeyPressed(e, me)
        {
            var index = $(me).attr('taskindex');
         //   angular.element('#CACtrl').scope().AddTaskElement(index);

            if (e.keyCode == 13) {
                $('#btn' + index).click();
                var newindex = parseInt(index) + 1;
                $('#input' + newindex).focus();
            }
            
        }
        var currentGroupID = 0;
        $(function () {
            getQS();//this is looking for a query string to know if page is in edit or add mode
            if (angular.element('#CACtrl').scope().compHeaderID > 0) {

                $('#collapseDragDrop').attr('data-toggle', 'collapse');
                setEditPanels();               
                $('#pageType').text('Edit');
                waitForHeaderToLoad();
                setDropDowns();                
               // $('#collapseDragDrop').click();
            }
            else {
                $('#pageType').text('Create');
            }
        });
        $('#tdMove').mousedown(function () {
        })
        $('input[name=define]').change(function () {
            var JobroleID = $find('<%=Jobroles.ClientID %>');
            var TitleID = $find('<%=RadComboBoxJobTitles.ClientID %>');
            var RespID = $find('<%=RadComboBoxJobResp.ClientID %>');

            JobroleID.clearSelection();
            TitleID.clearSelection();
            RespID.clearSelection();

            var divID = $(this).attr('divname');
            $('.defineBy').addClass('hidden');
            $('#' + divID).removeClass('hidden');
        });
        $('#AddTasks').click(function () {
           // $('#collapseCurrentQuestions').click();
            $('#collapseDragDrop').click();
        });

        $('#collapseCurrentQuestions').click(function () {
            angular.element('#MngCompCtrl').scope().getCompetencyDefinitionDetails();
        });
        function setEditPanels()
        {
           // $('#CurrentQuestions').removeClass('hidden');
            //$('#collapseCurrentQuestions').click(); //this expands the Current Questions Tab
            $('#lblSetup').text('Setup:   ');
            $('#panelTasks').removeClass('panel-success').addClass('panel-primary');
            $('#labelAddTasks').text('All Tasks');
            $('#spanTasks').removeClass('glyphicon-plus').addClass('glyphicon-pencil');
            //$('#AddTasks').click();
            
        }
        function setDropDowns()
        {

            if (typeof angular.element('#CACtrl').scope().defHeaderObj !== "undefined") {

                console.log(angular.element('#CACtrl').scope().defHeaderObj);
                console.log($find('<%=RadComboBoxJobTitles.ClientID %>').get_items().get_count());

                var UOMID = $find('<%=RadComboBoxUOM.ClientID %>');
                var UOM = UOMID.findItemByValue(angular.element('#CACtrl').scope().defHeaderObj.UOMSchedulingRecurrenceID);
                 var FUOMID = $find('<%=RadComboBoxFUOM.ClientID %>');
                var FUOM = FUOMID.findItemByValue(angular.element('#CACtrl').scope().defHeaderObj.Failure_UOMSchedulingRecurrenceID);
                UOM.select();
                FUOM.select();

                if (angular.element('#CACtrl').scope().defHeaderObj.JobTitleID != null)
                {
                    $('#rTitle').attr('checked', 'checked');
                    $('#' + $('#rTitle').attr('divname')).removeClass('hidden');//the actual combobox is hidden in a div. The corresponding div names are stored on the radiobuttons

                    var TitleID = $find('<%=RadComboBoxJobTitles.ClientID %>');
                    var title = TitleID.findItemByValue(angular.element('#CACtrl').scope().defHeaderObj.JobTitleID);
                    title.select();
                }

                if (angular.element('#CACtrl').scope().defHeaderObj.JobRoleID != null) {
                    $('#rRole').attr('checked', 'checked');
                    $('#' + $('#rRole').attr('divname')).removeClass('hidden');//the actual combobox is hidden in a div. The corresponding div names are stored on the radiobuttons
                    var JobroleID = $find('<%=Jobroles.ClientID %>');
                    var role = JobroleID.findItemByValue(angular.element('#CACtrl').scope().defHeaderObj.JobRoleID);
                    role.select();
                }
                if (angular.element('#CACtrl').scope().defHeaderObj.JobResponsibilityID != null) {
                    $('#rResp').attr('checked', 'checked');
                    $('#' + $('#rResp').attr('divname')).removeClass('hidden');//the actual combobox is hidden in a div. The corresponding div names are stored on the radiobuttons
                    var RespID = $find('<%=RadComboBoxJobResp.ClientID %>');
                    var resp = RespID.findItemByValue(angular.element('#CACtrl').scope().defHeaderObj.JobResponsibilityID);
                    resp.select();
                }
            }
            else {
                setTimeout(function () {
                    setDropDowns();
                }, 250);
            }
        }
        function setGroupID(id) {
            currentGroupID = id.substring(1);
        }

        $('#searchBar').keydown(function () {
            angular.element('#CACtrl').scope().loadData(currentGroupID);
        });

        function selectComp(e, compObject) {
            var compID = $(e).attr('competencyID');
            if (!$(e).hasClass('bgimage')) {
                $(e).addClass('bgimage');
                angular.element('#CACtrl').scope().InsertDetail(compID);
            }
            else {
                $(e).removeClass('bgimage');
                angular.element('#CACtrl').scope().RemoveCompetency_fromDefinition(compID);
                
                //delete ID from list here
            }
        }        

        $('.groupLink').click(function () {
            var i = $(this).attr('indexNum');
            $('a.groupLink').removeClass('active');
            $(this).addClass("active");

            $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
            $("div.bhoechie-tab>div.bhoechie-tab-content").eq(i).addClass("active");

        });

        $('#saveHeader').click(function (e) {
             var JobroleID = $find('<%=Jobroles.ClientID %>').get_value();
             var TitleID = $find('<%=RadComboBoxJobTitles.ClientID %>').get_value();
             var RespID = $find('<%=RadComboBoxJobResp.ClientID %>').get_value();
            var UOMID = $find('<%=RadComboBoxUOM.ClientID%>').get_value();
            var FUOMID = $find('<%=RadComboBoxFUOM.ClientID%>').get_value();
            
             var headerObject;
             var Descr = $('#Descr').val();
             var PassingGrade = $('#PassingGrade').val();
             var NotifyDays = $('#NotifyDays').val();
             var NotifyEmail = $('#NotifyEmail').val();
             var recQty = $('#recQ').val();
             var frecQ = $('#frecQ').val();

             if (validateHeader()) {

                 headerObject = {
                     'CompetencyDefHdrID': 0, 'JobTitleID': TitleID, 'JobRoleID': JobroleID, 'JobResponsibilityID': RespID, 'Description': Descr,
                     'PassingGrade': PassingGrade, 'NotifyDays': NotifyDays, 'NotifyEmail': NotifyEmail, 'RecurrenceQty': recQty, 'UOMSchedulingRecurrenceID': UOMID, 'Failure_RecurrenceQty': frecQ, 'Failure_UOMSchedulingRecurrenceID': FUOMID
                 };

                 angular.element('#CACtrl').scope().InsertHeader(headerObject);
                 // angular.element('#CACtrl').scope().$apply();

                 swal({ title: "Awesome! Setup Complete!", imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });
                 
                 $('#collapseDragDrop').attr('data-toggle', 'collapse');
                 $('#collapseDragDrop').click();
                 $('#collapseSetup').click();
                 waitForHeaderID(); //at this point the scope.defHeader is undefined b/c jquery does not wait until it is defined before it continues. This function will deal with that issue.
             }
             //   $('.groupLink').first().click();
        });
        function RemoveCompetency(me)
        {
            
            swal({
                title: "Wait!", text: "Removing this competency Question may result in historical data issues. Are you sure you want to continue", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55",
                confirmButtonText: "Yes, delete it!", closeOnConfirm: true,
                closeOnCancel: true
            },
           function (isConfirm) {
               if (isConfirm) {
                   var compID = $(me).attr('competencyid');
                   var myIndex = $(me).attr('myIndex');
                   angular.element('#MngCompCtrl').scope().RemoveCompetency_fromDefinition(compID, myIndex);
                   
               }
           });
            
            
           
        }

        $('#SaveCompelete').click(function () {
            swal({
                title: "Competency Saved Successfully!", text: "Where to Next?", type: "success", showCancelButton: true, cancelButtonColor: "#DD6B55",
                confirmButtonColor: "#3C8DBC", confirmButtonText: "Go to Competency List!", cancelButtonText: "Stay Here!", closeOnConfirm: false,
                closeOnCancel: false
            },
            function (isConfirm) {
                if (isConfirm) { location.href = '/AdminTools/EditCA.aspx?'; }
                else { location.href = '/AdminTools/DefineCA.aspx?'; }
            });
        });


         function waitForHeaderID() {
             if (typeof angular.element('#CACtrl').scope().defHeader !== "undefined") {
                 $('.groupLink').first().click();
             }
             else {
                 setTimeout(function () {
                     waitForHeaderID();
                 }, 250);
             }
         }
         function waitForHeaderToLoad() {
             if (angular.element('#CACtrl').scope().headerLoaded == true && typeof angular.element('#CACtrl').scope().defHeaderObj !== "undefined") {                 
                 $('.groupLink').first().click();
                 angular.element('#CACtrl').scope().getTasks(angular.element('#CACtrl').scope());
             }
             else {
                 setTimeout(function () {
                     waitForHeaderToLoad();
                 }, 250);
             }
         }
         function getQS() {
             if (typeof angular.element('#CACtrl').scope().compHeaderID !== "undefined") {
                 $('.groupLink').first().click();
             }
             else {
                 setTimeout(function () {
                     getQS();
                 }, 250);
             }
         }
         function isEmail(email) {
             var regex = /^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$/;
             
             return regex.test(email.replace(/\s/g, "")); //this replaces all spaces with nothing
         }
         function validateHeader() {
             var valid = true;

             var JobroleID = $find('<%=Jobroles.ClientID %>').get_value();
             var TitleID = $find('<%=RadComboBoxJobTitles.ClientID %>').get_value();
             var RespID = $find('<%=RadComboBoxJobResp.ClientID %>').get_value();
             var UOMID = $find('<%=RadComboBoxUOM.ClientID %>').get_value();
             var FUOMID = $find('<%=RadComboBoxFUOM.ClientID %>').get_value();

                     if ($('#Descr').val() == '') {
                         $('#Descr').addClass('inputValidation').next('p').removeClass('hidden');
                         valid = false;
                     }
                     else {
                         $('#Descr').removeClass('inputValidation').next('p').addClass('hidden');
                     }

                     if (!$.isNumeric($('#PassingGrade').val())) {
                         $('#PassingGrade').addClass('inputValidation').next('p').removeClass('hidden');
                         valid = false;
                     }
                     else {
                         $('#PassingGrade').removeClass('inputValidation').next('p').addClass('hidden');
                     }

                     if (!$.isNumeric($('#NotifyDays').val())) {
                         $('#NotifyDays').addClass('inputValidation').next('p').removeClass('hidden');
                         valid = false;
                     }
                     else
                         $('#NotifyDays').removeClass('inputValidation').next('p').addClass('hidden');
                    
                     if (!isEmail($('#NotifyEmail').val()))
                     {
                         $('#NotifyEmail').addClass('inputValidation').next('p').removeClass('hidden');
                         valid = false;
                     }
                     else
                         $('#NotifyEmail').removeClass('inputValidation').next('p').addClass('hidden');
                     

                     if (!$.isNumeric($('#recQ').val())) {
                         $('#recQ').addClass('inputValidation').next('p').removeClass('hidden');
                         valid = false;
                     }
                     else {
                         $('#recQ').removeClass('inputValidation').next('p').addClass('hidden');
                     }
                     if (!$.isNumeric($('#frecQ').val())) {
                         $('#frecQ').addClass('inputValidation').next('p').removeClass('hidden');
                         valid = false;
                     }
                     else {
                         $('#frecQ').removeClass('inputValidation').next('p').addClass('hidden');
                     }
                     if (UOMID == '')
                     {
                        valid = false;
                        $('#<%=RadComboBoxUOM.ClientID%>').next('p').removeClass('hidden');
                     }
                     else
                     {
                          $('#<%=RadComboBoxUOM.ClientID%>').next('p').addClass('hidden');
                     }
             //Falure Unit of Measure
                    if (FUOMID == '')
                     {
                        valid = false;
                        $('#<%=RadComboBoxFUOM.ClientID%>').next('p').removeClass('hidden');
                     }
                     else
                     {
                          $('#<%=RadComboBoxFUOM.ClientID%>').next('p').addClass('hidden');
                     }

                     if ($("input:radio[name=define]").is(':checked')) {

                         if ($('#rRole').is(':checked')) //This Crap wasn't working -->[ $("input:radio[name=define]").val() == 1] so I'm the id of the option value
                         {
                             if (JobroleID == '') {
                                 $("#pDefineBy").removeClass('hidden');
                                 valid = false;
                             }
                             else
                                 $("#pDefineBy").addClass('hidden');
                         }

                         if ($('#rResp').is(':checked')) {

                             if (RespID == '') {
                                 $("#pDefineBy").removeClass('hidden');
                                 valid = false;
                             }
                             else
                                 $("#pDefineBy").addClass('hidden');
                         }

                         if ($('#rTitle').is(':checked')) {
                             if (TitleID == '') {
                                 $("#pDefineBy").removeClass('hidden');
                                 valid = false;
                             }
                             else
                                 $("#pDefineBy").addClass('hidden');
                         }
                     }
                     else {
                         $("#pDefineBy").removeClass('hidden');

                     }
                     return valid;
 }

 //function getParameterByName(name) {
 //    console.log(RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search));
 //    var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
 //    return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
 //}
    </script>
    <style>
        .addTask
        {
            margin-bottom: 20px;
        }
        .box {
            height: 250px !important;
            cursor: pointer;
        }

        .check {
            opacity: .5;
        }

        .inputValidation {
            border: 1px solid red;
        }
        .clickable{
            cursor:pointer !important;
        }
        .fadeOut {
            visibility: hidden;
            opacity: 0;
            transition: visibility 0s 2s, opacity 2s linear;
        }
    </style>
</asp:Content>
