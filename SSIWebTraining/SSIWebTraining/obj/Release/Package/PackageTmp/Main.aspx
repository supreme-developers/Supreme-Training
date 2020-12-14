<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="SSIWebTraining.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="row">
        <div class="col-md-12">
            <h1>Welcome Back Eric!
                <small></small>
            </h1>
        </div><br /><br />
        <div class="row">
             <div class="col-lg-4 col-xs-6 rounded">
              <!-- small box -->
              <div class="small-box bg-yellow">
                <div class="inner">
                  <h3>Add User</h3>
                    <p>12 Current Users</p>
                </div>
                <div class="icon">
                  <i class="ion ion-person-add"></i>
                </div>
                <a href="#" class="small-box-footer">
                  Click Here To Begin <i class="fa fa-arrow-circle-right"></i>
                </a>
              </div>
            </div>

           
        <!-- ./col -->
            <div class="col-lg-4 col-xs-6 rounded">
                <!-- small box -->
                <div class="small-box bg-green">
                    <div class="inner">
                        <h3>Reports</h3>

                        <p>User Info</p>
                    </div>
                    <div class="icon">
                        <i class="ion ion-stats-bars"></i>
                    </div>
                    <a href="#" class="small-box-footer">Click Here to view Reports<i class="fa fa-arrow-circle-right"></i>
                    </a>
                </div>
            </div>
        <!-- ./col -->
           
        <!-- ./col -->
        <div class="col-lg-4 col-xs-6 rounded">
          <!-- small box -->
          <div class="small-box bg-red">
            <div class="inner">
              <h3>Calendar</h3>

              <p>View upcoming deadlines</p>
            </div>
            <div class="icon">
              <i class="ion ion-calendar"></i>
            </div>
            <a href="#" class="small-box-footer">
              More info <i class="fa fa-arrow-circle-right"></i>
            </a>
          </div>
        </div>
        </div>
    </div>
     <style>
        .rounded {
  -webkit-border-radius: 50px !important;
     -moz-border-radius: 50px !important;
          border-radius: 50px !important;
        }
    </style>
</asp:Content>
