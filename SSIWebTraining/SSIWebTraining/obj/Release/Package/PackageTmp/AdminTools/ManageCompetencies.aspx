<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="ManageCompetencies.aspx.cs" Inherits="SSIWebTraining.AdminTools.ManageCompetencies" %>

<%@ Register Assembly="Syncfusion.Shared.Web, Version=13.3451.0.7, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89" Namespace="Syncfusion.Web.UI.WebControls.Shared" TagPrefix="syncfusion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../plugins/select2/select2.min.css" rel="stylesheet" />
    <link href="css/MngCompetencies.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="col-lg-10 col-md-9 col-sm-8 col-xs-9">
                <h2>Competency Groups Q&A</h2>
                <br />
            </div>
            <div id="divbtnAddComp" class="col-lg-2 col-md-3 col-sm-4 col-xs-3 divCompetencies pull-right">
                <button type="button" class="btn btn-success "><i class="glyphicon glyphicon-plus"></i> Add Competency</button>
            </div>
            <div id="divbtnBack" class="col-lg-2 col-md-2 col-sm-2 col-xs-3 backBtn">
                <button id="btnBack" type="button" class="btn btn-danger"><i class="glyphicon glyphicon-remove"></i> Cancel</button>
            </div>
    </div>
    </div>   
    <div class="row" ng-app="CompApp">
        <div id="CompCtrl" ng-controller="CompCtrl" >
            <div id="groupDDL" class="row">
                <div class="col-lg-8 col-sm-8 col-xs-8 col-sm-offset-2 col-xs-offset-1 col-lg-offset-0">
                    <select  class="form-control input-lg" groupID="{{ CompetencyGroupID }}" ng-model="selectedGroup" 
                        ng-options="group.CompetencyGroupID as group.GroupName for group in Groups | orderBy: 'GroupName'" onchange="groupSelect(this);">
                        <option value="" selected>Select a Group</option>
                    </select>
                </div>
          
            </div>
            <asp:Repeater ID="rptTabs" runat="server">
                    <HeaderTemplate>
                        <div id="groups" class="col-lg-2 col-md-2 col-sm-2 col-xs-2 bhoechie-tab-menu">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div id="groupList" class="list-group list-group-horizontal">
                            <a id="a<%# Eval("CompetencyGroupID") %>" ng-click="setGroupID($event, null);"
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
            
            <div id="divCompetencies" class="w3-animate-left col-lg-8 col-md-8 col-sm-10 col-xs-10 col-lg-offset-0 col-md-offset-2 col-sm-offset-1  divCompetencies">
                <div id="search" class="row typelevelrow">
                    <div id="divSearch" class="col-lg-4">
                        <div class="input-group input-group-lg">
                            <input type="text" placeholder="Search..." ng-model="searchText" class="form-control input-lg">
                            <span class="input-group-btn">
                                <button type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                            </span>

                        </div>
                    </div>
                    <div class="col-lg-3 col-sm-6">
                        <select class="form-control input-lg" ng-model="selectedTypes"
                            ng-options="type as type.CompetencyTypeName for type in types">
                            <option value="" selected>All Types</option>
                        </select>

                    </div>
                    <div class="col-lg-3 col-sm-6">
                        <select class="form-control input-lg" ng-model="selectedLevels" ng-options="level as level.Level for level in levels">
                            <option value="" selected>All Levels</option>
                        </select>

                    </div>
                </div>
                
                
                
                <div class="row">
                    <div class="col-lg-12 text-center w3-animate-top">
                        <div class="col-lg-4 col-md-6 col-sm-12" ng-repeat="data in currentComps | filter:searchText |
                                                         filter: {CompetencyTypeID : selectedTypes.CompetencyTypeID}: true | filter: {LevelID : selectedLevels.LevelID}: true track by $index ">
                            <div id="{{'div' + $index}}" class="box">
                                <span class="box-content">
                                    <%--<h2><i class="fa fa-clipboard fa-1x"></i></h2>--%>
                                    <h2 class="tag-title">{{ data.CompetencyTypeName }}</h2>
                                    <h3 class="tag-title2">Level {{ data.LevelID }}
                                    </h3>
                                    <hr />
                                    <p>
                                        <i class="glyphicon glyphicon-question-sign"></i>
                                        {{ data.Question | cut:true:75:' ...'}}
                                    </p>
                                    <br />
                                    <button id="{{ data.CompetencyID }}" type="button" index="{{ $index }}" onclick="setEdit(this.id, this);"
                                        class="btn btn-info btn-block editComp">
                                        <i class="glyphicon glyphicon-edit"></i> Edit</button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                   
                   
                </div>
            
            <div id="divAddComp" style="display: none">
                <div id="row1" class="col-lg-8 col-md-8 col-sm-8 col-lg-offset-0 col-md-offset-2 col-sm-offset-2 addComp form-group">
                    <telerik:RadComboBox ID="RadComboBoxType" runat="server" Skin="MetroTouch" EmptyMessage="Select Competency Type..."
                        EnableLoadOnDemand="true" DataValueField="CompetencyTypeID" Width="100%" CssClass="w3-animate-right" ng-model="comp.Type"
                        OnItemsRequested="RadComboBoxType_ItemsRequested" DataTextField="CompetencyTypeName" TabIndex="1">
                    </telerik:RadComboBox>

                    <telerik:RadComboBox ID="RadComboBoxLevels" runat="server" Skin="MetroTouch" CssClass="w3-animate-right" EmptyMessage="Select a Level..."
                        Width="100%" TabIndex="2">
                        <Items>
                            <telerik:RadComboBoxItem Value="1" Text="Level 1" />
                            <telerik:RadComboBoxItem Value="2" Text="Level 2"  />
                            <telerik:RadComboBoxItem Value="3" Text="Level 3"  />
                        </Items>
                    </telerik:RadComboBox>

                    <div class="input-group input-group-lg addComp w3-animate-right">
                        <span class="input-group-btn">
                            <button type="button" class="btn btn-warning btn-flat">
                                <i class="fa fa-question-circle"></i>
                            </button>
                        </span>
                        <input id="question" class="form-control input-lg questionAdd" required ng-model="comp.question"
                            placeholder="Question..." tabindex="3" />
                    </div>
                    <div id="rw2" class="input-group input-group-lg addComp w3-animate-right form-group">
                        <span class="input-group-btn">
                            <button type="button" class="btn btn-info btn-flat">
                                <i class="fa fa-exclamation-circle"></i>
                            </button>
                        </span>
                        <input id="answer" class="form-control input-lg" ng-model="comp.answer" required placeholder="Answer..." tabindex="4" />
                    </div>
                    <button id="btnCreateComp" type="button" index="$index" tabindex="5"
                        class="btn btn-success btn-lg btn-block w3-margin-top w3-animate-left">
                        <i class="fa fa-plus"></i> Add</button>
                </div>
            </div>
            <div id="divEditComp" style="display:none ">
                <div id="row2" class="col-lg-7 col-md-7 col-sm-7 col-lg-offset-1 col-sm-offset-2 col-md-offset-2 addComp"  >

                   <telerik:RadComboBox ID="RadComboBoxEditType" runat="server" Skin="MetroTouch" EmptyMessage="Select Competency Type..."
                        EnableLoadOnDemand="false" DataValueField="CompetencyTypeID" Width="100%" CssClass="w3-animate-right"
                       DataTextField="CompetencyTypeName" TabIndex="1" >
                    </telerik:RadComboBox>
                  
                    <telerik:RadComboBox ID="RadComboBoxEditLevel" runat="server" Skin="MetroTouch" CssClass="w3-animate-right" 
                        EmptyMessage="Select a Level..." TabIndex="2"
                        Width="100%">
                        <Items>
                            <telerik:RadComboBoxItem Value="1" Text="Level 1" />
                            <telerik:RadComboBoxItem Value="2" Text="Level 2" />
                            <telerik:RadComboBoxItem Value="3" Text="Level 3" />
                        </Items>
                    </telerik:RadComboBox>
            <div ng-repeat="comp in currentComp track by $index">
                    <div class="input-group input-group-lg addComp w3-animate-right">
                        <span class="input-group-btn">
                            <button type="button" class="btn btn-warning btn-flat">
                                <i class="fa fa-question-circle"></i>
                            </button>
                        </span>
                        <input id="equestion" class="form-control input-lg questionAdd" ng-model="comp.Question" tabindex="3"
                            placeholder="Question..."  />
                    </div>
                    <div id="rw3" class="input-group input-group-lg addComp w3-animate-right">
                        <span class="input-group-btn">
                            <button type="button" class="btn btn-info btn-flat">
                                <i class="fa fa-exclamation-circle"></i>
                            </button>
                        </span>
                        <input id="eanswer" class="form-control input-lg" ng-model="comp.Answer" placeholder="Answer..." tabindex="4" />
                    </div>
                <div class="row">
                    <div class="col-lg-12" >
                        <div class="btn-group col-lg-6">
                            <button id="btnDeleteComp" type="button" index="{{ $index }}" style="width:100%" ng-click="DeleteComp(comp.CompetencyID);"
                                class="btn btn-danger btn-lg w3-margin-top w3-animate-left">
                                <i class="fa fa-trash-o"></i> Delete</button>
                        </div>
                        <div class="btn-group col-lg-6" >
                            <button id="btnSaveComp" type="button" index="{{ $index }}" onclick="editComp();" tabindex="5"
                             style="width:100%"  class="btn  btn-success btn-lg w3-margin-top w3-animate-left">
                                <i class="fa fa-save"></i> Save</button>
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
  
    <script src="../js/CompControllers/MngCompetency.js"></script>
    <%--<script src="../js/CompControllers/CompGroups.js"></script>--%>
    <script src="../plugins/select2/select2.full.min.js"></script>

   
<script>
    var setupComplete = false;

    function groupSelect(me)
    {
        var groupID = me.value.replace("number:", "");
       
        angular.element('#CompCtrl').scope().groupID = groupID
        angular.element('#CompCtrl').scope().loadData(groupID);
    }
    $(function () {
        $(".cmbbox").select2();
        CreateScripts();
    });
    function setGroupInfo()
    {
        $('.groupLink').first().click();
    }
    function setEdit(id, me)
    {
        var etypecmbo = $find('<%=RadComboBoxEditType.ClientID %>');
        var elvlcmbo = $find('<%=RadComboBoxEditLevel.ClientID %>');
        
        angular.element('#CompCtrl').scope().SetCompetencyID(id, etypecmbo, elvlcmbo, me.getAttribute("index"));
       
    }
    function CreateErrorMessage(message, controlID) {
        $('<div class="alert alert-danger w3-animate-top text-center " role="alert" style="width: 100%"><i class="fa fa-close "><i/> ' + message + '</div>').insertBefore(controlID).delay(2000).fadeOut();
    }
    $('#answer').keydown(function (e) {
        var code = e.keyCode || e.which
        if (code == 13)
        {
            $('#btnCreateComp').click();
        }

    });
    $('#eanswer').keydown(function (e) {
        var code = e.keyCode || e.which
        if (code == 13) {
            $('#btnSaveComp').click();
        }

    });
   
    $('#btnBack').click(function () {
        $('.divCompetencies').show();
        $('#divAddComp').hide();
        $('#divEditComp').hide();
        $('#divbtnBack').hide();
    });
   
    function editComp () {
           
            var ecomboLvl = $find('<%=RadComboBoxEditLevel.ClientID %>');
            var ecomboType = $find('<%=RadComboBoxEditType.ClientID %>');
            var data = getComboValues(ecomboType,ecomboLvl);
            var compObject;
            var question = $('#equestion');
            var answer = $('#eanswer');
           
            if (question.val() == '') {
                CreateErrorMessage('Please Enter a Question.', '#<%=RadComboBoxEditType.ClientID%>');
                return;
            }

            if (answer.val() == '') {
                CreateErrorMessage('Please Enter a Question.','#<%=RadComboBoxEditType.ClientID%>');
                return;
            }
            

            if (data.lvl != '' && data.type != '') {
                compObject = { 'CompetencyID': 0, 'Question': question.val(), 'Answer': answer.val(), 'CompetencyGroupID': 0, 'CompetencyTypeID': data.type, 'LevelID': data.lvl };
                angular.element('#CompCtrl').scope().EditComp(compObject);
                angular.element('#CompCtrl').scope().$apply();
                swal("Success!", "Competency Edited Successfully!", "success", { imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });
                $('.active').click();
                //swal({ title: "Sweet! Competency Edited Successfully!", text: "Add another one!", imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });
                //swal({ title: "Auto close alert!", text: "I will close in 2 seconds.", timer: 2000, showConfirmButton: false });
                // just gonna leave this here in case --> $('<div class="alert alert-success w3-animate-top text-center " role="alert" style="width: 100%"><i class="fa fa-check "><i/> Competency Added Successfully!</div>').insertBefore('#<%=RadComboBoxType.ClientID%>').delay(2000).fadeOut();
            }
            else {
                if (data.lvl == '' || data.type == '')
                    CreateErrorMessage('Please select a group and type before submitting.','#<%=RadComboBoxEditType.ClientID%>');
            }
        };
    function CreateScripts()
    {
        $('#divbtnAddComp').click(function () {
            var comboLvl = $find('<%=RadComboBoxLevels.ClientID %>');
            var comboType = $find('<%=RadComboBoxType.ClientID %>');
            //comboLvl.clearItems();
            clearCombo(comboLvl);
            clearCombo(comboType);
            $('#answer').val('');
            $('#question').val('');

            $('.divCompetencies').hide();
            $('#divAddComp').show();
            $('#divbtnBack').show();
        });
        function clearCombo(combo)
        {
            combo.clearSelection();
            combo.set_emptyMessage(combo.get_emptyMessage());
        }
        function CreateErrorMessage(message) {           
            $('<div class="alert alert-danger w3-animate-top text-center " role="alert" style="width: 100%"><i class="fa fa-close "><i/> ' + message + '</div>').insertBefore('#<%=RadComboBoxType.ClientID%>').delay(2000).fadeOut();
         }
        $(document).on('keydown', '.questionAdds', (function (e) {
            //this function clones the parent group and if one below it does not exist, it adds it to the DOM
            var currentRowNum = $(this).parent().parent().parent().attr('id').replace(/row/, '');
            var nxtRowNum = parseInt(currentRowNum, 10) + 1;
            if ($('#row' + nxtRowNum).parent().length === 0) {
                $('div.addComp:last').after($('<br/><div class="row">').add($('div.addComp:first').clone().prop('id', 'row' + nxtRowNum)).add($()));
                $('div.addComp:last input').val('');
            }
        }));

        $('.groupLink').click(function () {
           var i = $(this).attr('indexNum');
            $('a.groupLink').removeClass('active');
            $(this).addClass("active");
          
            $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
            $("div.bhoechie-tab>div.bhoechie-tab-content").eq(i).addClass("active");
            $('.divCompetencies').show();
            $('#divAddComp').hide();
            $('#divEditComp').hide();
            $('#divbtnBack').hide();
        });

        function CreateErrorMessage(message, controlID) {
            $('<div class="alert alert-danger w3-animate-top text-center " role="alert" style="width: 100%"><i class="fa fa-close "><i/> ' + message + '</div>').insertBefore(controlID).delay(2000).fadeOut();
        }

        

        $('#btnCreateComp').click(function (e) {
            
                var comboLvl = $find('<%=RadComboBoxLevels.ClientID %>');
                var comboType = $find('<%=RadComboBoxType.ClientID %>');
                var data = getComboValues(comboType, comboLvl);
                var compObject;
                var question = $('#question');
                var answer = $('#answer');
                
                if (question.val() == '')
                {
                    CreateErrorMessage('Please Enter a Question.','#<%=RadComboBoxType.ClientID%>');
                    return;
                }
                if (answer.val() == '') {
                    CreateErrorMessage('Please Enter an Answer.','#<%=RadComboBoxType.ClientID%>');
                    return;
                }
                if (data.lvl != '' && data.type != '') {
                    compObject = { 'CompetencyID': 0, 'Question': question.val(), 'Answer': answer.val(), 'CompetencyGroupID': 0, 'CompetencyTypeID': data.type, 'LevelID': data.lvl };
                    angular.element('#CompCtrl').scope().AddComp(compObject);
                    angular.element('#CompCtrl').scope().$apply();

                    question.val('');
                    answer.val('');
                    // swal("Good job!", "Competency Added Successfully!", "success");
                    swal({ title: "Sweet! Competency Added!", text: "Add another one!", imageUrl: "../img/thumbs-up.jpg", timer: 1000, showConfirmButton: false });
                    //swal({ title: "Auto close alert!", text: "I will close in 2 seconds.", timer: 2000, showConfirmButton: false });
                    // just gonna leave this here in case --> $('<div class="alert alert-success w3-animate-top text-center " role="alert" style="width: 100%"><i class="fa fa-check "><i/> Competency Added Successfully!</div>').insertBefore('#<%=RadComboBoxType.ClientID%>').delay(2000).fadeOut();
                }
                else {
                    if (data.lvl == '' || data.type == '')
                        CreateErrorMessage('Please select a group and type before submitting.','#<%=RadComboBoxType.ClientID%>');
                }
            
        });
        //click the first link to show competency details
        $('.groupLink').first().click();
       
    }
    function getComboValues(typeComboID, lvlComboID) {       
        var lvl = lvlComboID.get_value();
        var type = typeComboID.get_value();

        return { "type": type, "lvl": lvl }
    };
   // alert(window.outerWidth);
   
</script>

    <style>
        #divSearch{
            padding-bottom: 20px;
        }
        .rcbReadOnly
        {
            -webkit-user-select: auto !important;
            -moz-user-select: auto !important;
            -ms-user-select: auto !important;
            user-select: auto !important;         
        }
        #groupDDL{
            padding-bottom: 20px;
        }

      @media all and (max-width: 1455px) { /* screen size until 1000px */
            .tag-title{
                font-size: 1.5em;
            }
            .tag-title2{
                font-size: 1em;
            }

            #groups{
                display:none;
            }
            #groupDDL{
                visibility:visible;
            }
            h2{
              font-size:  1.5em;
            }
        }
        @media all and (min-width: 1455px) {
            #groupDDL{
                visibility: hidden;
                padding-bottom: 0px;
            }
        }
    </style>
     <%--@media all and (max-width: 1200px) { /* screen size until 1200px */
            body {
                font-size: 1em; /* 1x default size */
            }
            h2{
                font-size: 1em;
            }
        }

        @media all and (max-width: 1000px) { /* screen size until 1000px */
            body {
                font-size: .7em; /* 1.2x default size */
            }
            h2{
                font-size: .5em;
            }

        }

        @media all and (max-width: 500px) { /* screen size until 500px */
            body {
                font-size: 0.5em; /* 0.8x default size */
            }
            
             h2{
                font-size: 1.2em;
            }
        }--%>
</asp:Content>
