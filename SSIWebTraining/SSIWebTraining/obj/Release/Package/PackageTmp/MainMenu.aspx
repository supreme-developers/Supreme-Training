<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BootStrap.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="SSIWebTraining.MainMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/dashboard.css" rel="stylesheet" />
    <link href="css/3DButtons.css" rel="stylesheet" />
    <script src="js/SearchTable.js"></script>

    <div class="dashboard">
        <div class="row">

            <%-- Dashboard Tabs--%>
            <div class="col-md-10 col-md-offset-1">
                <ul class="dashboard-tabs">
                    <li class="active">
                        <a href="#profile" class="btn" aria-controls="profile" role="tab" data-toggle="tab">
                            <i class="fa fa-user fa-3x" aria-hidden="true"></i>
                            <h4>Profile</h4>
                        </a>
                    </li>
                    <li>
                        <a href="#users" class="btn" aria-controls="users" role="tab" data-toggle="tab">
                             <i class="fa fa-users fa-3x" aria-hidden="true"></i>
                            <h4>Users</h4>
                        </a>
                    </li>
                    <li>
                        <a href="#competencies" class="btn" aria-controls="competencies" role="tab" data-toggle="tab">
                            <i class="fa fa-folder fa-3x" aria-hidden="true"></i>
                            <h4>Skills</h4>
                        </a>
                    </li>
                    <li>
                        <a href="#settings" class="btn" aria-controls="settings" role="tab" data-toggle="tab">
                            <i class="fa fa-cog fa-3x" aria-hidden="true"></i>
                            <h4> Admin</h4>
                        </a>
                    </li>
                    <li>
                        <a href="#help" class="btn" aria-controls="help" role="tab" data-toggle="tab">
                            <i class="fa fa-wrench fa-3x" aria-hidden="true"></i>
                            <h4>Help</h4>
                        </a>
                    </li>
                </ul>
            </div>


            <div class="tab-content col-md-12">


                <div role="tabpanel" class="tab-pane profile-pane active" id="profile">
                    <div>
                        <div class="tab col-lg-off-12">
                            <div class="header">
                                <h4>Supreme Services Training - Profile Information <span class="fa fa-user fa-1x pull-right"></span></h4>
                            </div>
                            <div class="content">
                                <h2>John Doe</h2>
                                <ul class="list-group">
                                    <div class="list-group-item inactive-link">
                                        <h3 class="list-group-item-heading">Job Title: </h3>
                                        <p class="list-group-item-text"></p>
                                    </div>
                                    <div class="list-group-item inactive-link">
                                        <h3 class="list-group-item-heading">Job Roles:</h3>
                                        <p class="list-group-item-text"></p>
                                        <ul>
                                            <li></li>
                                            <li></li>
                                        </ul> 
                                    </div>
                                     <div class="list-group-item inactive-link">
                                        <h3 class="list-group-item-heading">Job Responsibilities:</h3>
                                        <p class="list-group-item-text"></p>
                                        <ul>
                                            <li></li>
                                            <li></li>
                                        </ul> 
                                    </div>
                                    <div class="list-group-item inactive-link">
                                        <div class="span5">
                                        <h3>Competencies Taken:</h3>
                                            <div>
                                            <input class="form-control" id="system-search-profile" name="q" placeholder="Search for" required>
                                                </div>
                                        <table class="table table-list-search table-striped table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>First </th>
                                                    <th>Date Taken</th>
                                                    <th>Administered By:</th>
                                                    <th>Status</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>Pressure Test</td>
                                                    <td>2009/04/11</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-warning">Pending</span></td>
                                                </tr>
                                                <tr>
                                                    <td>Washmat</td>
                                                    <td>2015/01/06</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-success">Passed</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Washmat</td>
                                                    <td>2015/1/10</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-danger">Failed</span></td>
                                                </tr>
                                                <tr>
                                                    <td>ForkLift</td>
                                                    <td>2014/08/21</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-default">Inactive</span></td>
                                                </tr>      
                                            </tbody>
                                        </table>
                                            </div>
                                    </div>
                                </ul>
                            </div>
                        </div>  
                    </div>
                </div>

                <div role="tabpanel" class="tab-pane profile-pane" id="users">
                    <div>
                        <div class="tab col-lg-off-12">
                            <div class="header">
                                <h4>Supreme Services Training - Users <span class="fa fa-users fa-1x pull-right"></span></h4>
                            </div>
                            <div class="content">
                                <div class="list-group-item inactive-link">
                                        <div class="span5">
                                        <h3>Competencies Taken:</h3>
                                            <div>
                                            <input class="form-control" id="system-search-users" name="q" placeholder="Search for" required>
                                                </div>
                                        <table class="table table-list-search table-striped table-condensed">
                                            <thead>
                                                <tr>
                                                    <th>Competency Given</th>
                                                    <th>Date Taken</th>
                                                    <th>Administered By:</th>
                                                    <th>Status</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>Pressure Test</td>
                                                    <td>2009/04/11</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-warning">Pending</span></td>
                                                </tr>
                                                <tr>
                                                    <td>Washmat</td>
                                                    <td>2015/01/06</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-success">Passed</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Washmat</td>
                                                    <td>2015/1/10</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-danger">Failed</span></td>
                                                </tr>
                                                <tr>
                                                    <td>ForkLift</td>
                                                    <td>2014/08/21</td>
                                                    <td>Admin</td>
                                                    <td><span class="label label-default">Inactive</span></td>
                                                </tr>      
                                            </tbody>
                                        </table>
                                            </div>
                                    </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div role="tabpanel" class="tab-pane profile-pane " id="competencies">
                   <div>
                        <div class="tab col-lg-off-12">
                            <div class="header">
                                <h4>Supreme Services Training - Competencies <span class="fa fa-folder fa-1x pull-right"></span></h4>
                            </div>
                            <div class="content">
                            </div>
                        </div>
                    </div>     
                </div>

                <div role="tabpanel" class="tab-pane profile-pane " id="settings">
                    <div>
                        <div class="tab col-lg-off-12">
                            <div class="header">
                                <h4>Supreme Services Training - Admin Settings <span class="fa fa-cog fa-1x pull-right"></span></h4>
                            </div>
                            <div class="content">
                            </div>
                        </div>
                    </div>
                </div>


                <!-- Begin Help -->
                <div role="tabpanel" class="tab-pane help-pane" id="help">
                    <div class="jumbotron jumbotron-sm">
                        <div class="container">
                            <div class="row">
                                <div class="col-sm-12 col-lg-12">
                                    <h1 class="h1">Need Help? <small>Send us an email!</small></h1>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="container">
                        <div class="row">
                            <div class="col-md-8">
                                <div class="well well-sm">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="name">User Name</label>
                                                <input type="text" class="form-control" id="name" placeholder="Enter name" required="required" />
                                            </div>
                                            <div class="form-group">
                                                <label for="email">Email Address</label>
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-envelope"></span>
                                                    </span>
                                                    <input type="email" class="form-control" id="email" placeholder="Enter email" required="required" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="subject">Subject</label>
                                                <select id="subject" name="subject" class="form-control" required="required">
                                                    <option value="na" selected="">Choose One:</option>
                                                    <option value="service">General Question</option>
                                                    <option value="suggestions">Website Issues</option>
                                                    <option value="product">Support</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="name">Message</label>
                                                <textarea name="message" id="message" class="form-control" rows="9" cols="25" required="required" placeholder="Message"></textarea>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <button type="submit" class="btn btn-primary pull-right" id="btnContactUs">Send Message</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <legend><span class="glyphicon glyphicon-globe"></span>Corporate Office</legend>
                                <address>
                                    <strong>Supreme Service and Specialty, Co.</strong><br>
                                    204 Industrial Avenue C<br>
                                    Houma, Louisiana 70363<br>
                                    <abbr title="Phone">P:</abbr>
                                    (985)-851-7465
                                </address>
                                <address>
                                    <strong>Full Name</strong><br>
                                    <a href="mailto:#">first.last@example.com</a>
                                </address>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Help -->
            </div> 
        </div>
    </div>

    <style>

        .profile-pane > div > div
        {
            width:10%;
        }

    </style>

    <script>

       
    </script>

</asp:Content>
