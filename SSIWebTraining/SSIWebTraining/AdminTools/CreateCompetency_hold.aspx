<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="CreateCompetency_hold.aspx.cs" Inherits="SSIWebTraining.CreateCompetency" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

  
    <link href="../css/jquery.rateyo.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>New Comptency Exam  </h2><br />
    <div class="row">
        <div class="col-lg-6 col-lg-offset-3 input-group input-group-lg col-xs-8">
                   <label id="lblTestname" for="TextBox1">Exam Name</label>
                   <input id="TestName" type="text" runat="server" placeholder="Begin Typing Exam Name Here..." class="form-control input-lg" required />
                   
               </div>
    </div>
    <div class="row">
      <div class="col-lg-6 input-group input-group-lg col-lg-offset-3 col-xs-8">
                   <label id="lblJobRole" for="Jobroles">Job Roles</label><br />
                  <telerik:RadComboBox runat="server" ID="Jobroles" EmptyMessage="Job Roles" CssClass="myClass colorArrow" EnableEmbeddedSkins="false"
                        MarkFirstMatch="true"  DataValueField="ID" EnableLoadOnDemand="true" DropDownAutoWidth="Enabled" style="width:100%"
                        Skin="MetroTouch" ShowToggleImage="True" InputCssClass="form-control input-lg"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" DataTextField="JobRole" >
                   </telerik:RadComboBox>
                   <%-- <asp:EntityDataSource ID="DSJobRoles" runat="server" ConnectionString="name=SSIRentEntities"
                     DefaultContainerName="SSIRentEntities" EntitySetName="tblHREmployeeJobRoles" 
                        Select="ID, JobRole" OrderBy="JobRole"    ></asp:EntityDataSource>--%>

       </div>
    </div>
    <div class="row">
        <div class="col-lg-6 input-group input-group-lg col-lg-offset-3 col-xs-8">
                   <label id="lblJobTitles" for="RadComboBoxJobTitles">Job Titles</label><br />
                  <telerik:RadComboBox runat="server" ID="RadComboBoxJobTitles" EmptyMessage="Job Titles" CssClass="myClass colorArrow" style="width:100%"
                        MarkFirstMatch="true" InputCssClass="form-control input-lg"  DataValueField="JobTitleID" EnableLoadOnDemand="true" DropDownAutoWidth="Enabled"
                        Skin="MetroTouch" ShowToggleImage="True"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" DataTextField="JobTitle" >
                   </telerik:RadComboBox>
                  

        </div>
    </div>
   <div class="row">
        <div class="col-lg-6 input-group input-group-lg col-lg-offset-3 col-xs-8">
                       <label id="lblJobResp" for="Jobroles">Job Responsibilities</label><br />
                      <telerik:RadComboBox runat="server" ID="RadComboBoxJobResp" EmptyMessage="Responsibilities" CssClass="myClass colorArrow" style="width:100%"
                            MarkFirstMatch="true"  DataValueField="QualificationID" EnableLoadOnDemand="true" DropDownAutoWidth="Enabled"
                            Skin="MetroTouch" ShowToggleImage="True" InputCssClass="form-control input-lg"  CheckBoxes="true" EnableCheckAllItemsCheckBox="true" DataTextField="Qualification" >
                       </telerik:RadComboBox>
         </div>
    </div>
     <div class="row"><br />
        <div class="col-lg-2 input-group input-group-lg col-lg-offset-5 col-xs-8 text-right">
            <button id="btnNext" class="btn btn-info btn-lg btn-block fa-2x">Create Course  <span class="fa fa-book"></span></button>
        </div>
    </div>
    <div class="jumbotron" style="display:none">
        <div>
            <div id="rateYo"></div>
        </div>
    </div>
        
  <script src="js/jquery.rateyo.min.js"></script>      
    <script>
        $(function () {
            $("#rateYo").rateYo({
                starWidth: "50px",
                normalFill: "#F39C12",
                ratedFill: "#3C8DBC"
            });

        });
    </script>
</asp:Content>
