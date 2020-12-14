<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Training.Master" AutoEventWireup="true" CodeBehind="EditCA.aspx.cs" Inherits="SSIWebTraining.AdminTools.EditCA" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    
    <link href="css/MngCompetencies.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div ng-app="CompApp">
        <div class="row">
            <div class="col-lg-10 col-md-10 col-sm-10">
                <h2>
                    <label>All</label>
                    Competencies</h2>
            </div>
            <div class="col-lg-2">
                    <button type="button" class="btn btn-success  pull-right" onclick="location.href='/AdminTools/DefineCA.aspx'"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> New Competency</button>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-12">
                    <div class="col-lg-12 input-group input-group-lg">
                        <input id="searchbox" type="text" placeholder="Search..." class="form-control input-lg" />
                        <span class="input-group-btn">
                            <button type="button" class="btn btn-primary"><span class="glyphicon glyphicon-search" aria-hidden="true"></span></button>
                        </span>
                    </div>
               
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-primary filterable">
                            <div class="panel-heading">
                                <h3 class="panel-title fa-1x">Current Competencies</h3>
                                <div class="pull-right">
                                    <%--<button type="button" class="btn btn-default btn-xs btn-filter"><span class="glyphicon glyphicon-filter"></span> Filter</button>--%>
                                    <%--<span class="clickable filter btn-filter" title="Toggle table filter">
								<i class="glyphicon glyphicon-filter "></i>
							</span>--%>
                                </div>
                            </div>                           
                            <table id="AllComps" class="table table-striped table-bordered table-responsive table-condensed table-inverse"
                                 ng-controller="MngCompCtrl" > <%--ng-init="getCompetencyDefinitions()" --%>
                                <thead>
                                    <tr>
                                        <th class="text-center">Description</th>
                                        <th class="text-center">Defined By</th>
                                        <th class="text-center">Passing Grade</th>
                                        <th class="text-center">Notify Days</th>
                                        <th class="text-center">Recurrence</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr class="hidden" style="display: none">
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                        <td class="text-center"></td>
                                    </tr>
                                    <asp:Repeater ID="rptComps" runat="server" Visible="true">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr id="<%# "tr" +  Eval("CompDefHeaderID") %>">
                                                <td><%# Eval("Description") %></td>
                                                <td><%# Eval("DefinedBy") %></td>
                                                <td class="text-center"><%# Eval("PassingGrade") %></td>
                                                <td class="text-center"><%# Eval("NotifyDays") %></td>
                                                <td><%# Eval("Recurrence") %></td>
                                                <td class="text-center">
                                                    <button type="button" class="btn btn-primary btn-xs btn-filter btn-lg btnEdit"
                                                        defheaderid="<%# Eval("CompDefHeaderID") %>" onclick="btnEdit(this);">
                                                        <span class="glyphicon glyphicon-pencil fa-2x"></span>
                                                    </button>
                                                     <button id="<%# "btn" +  Eval("CompDefHeaderID") %>" type="button"
                                                          class="btn btn-danger btn-xs btn-filter btn-lg btnDelete" 
                                                         parentID="<%# "tr" +  Eval("CompDefHeaderID") %>" defheaderid="<%# Eval("CompDefHeaderID") %>" >
                                                        <span class="glyphicon glyphicon-remove fa-2x"></span>
                                                    </button>
                                                </td>
                                            </tr>
                                        </ItemTemplate>

                                        <FooterTemplate></FooterTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>                        
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- /.modal -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PageScripts" runat="server">
     <script src="../js/CompControllers/MngCompetency.js"></script>
    <script src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../plugins/datatables/dataTables.bootstrap.min.js"></script>
    

    <script>
        function btnEdit(me)
        {
            var compHeaderID = $(me).attr('defHeaderID');
            window.location.href = '/AdminTools/DefineCA.aspx#?compHeaderID=' + compHeaderID;
        }
       
       

        $(function () {
          var dataTable =  $('#AllComps').DataTable({
                "paging": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": false
          });


          $('#AllComps tbody').on('click', 'button.btnDelete', function () {
              var defheaderid = $(this).attr('defheaderid');
              var me = $(this);
                  swal({
                      title: "Wait!", text: "Removing this Entire Competency may result in historical data issues. Are you sure you want to continue?", type: "warning", showCancelButton: true, confirmButtonColor: "#DD6B55",
                      confirmButtonText: "Yes, delete it!", closeOnConfirm: true,
                      closeOnCancel: true
                  },
               function (isConfirm) {
                   if (isConfirm) {
                       dataTable
                       .row($(me).parents('tr'))
                       .remove()
                       .draw(false);
                       angular.element('#AllComps').scope().RemoveCompetencyDefinition(defheaderid);

                   }
               });
             
          });

          $(".btnEdits").click(function () {
              var compHeaderID = $(this).attr('defHeaderID');
              window.location.href = '/AdminTools/DefineCA.aspx#?compHeaderID=' + compHeaderID;
              //angular.element('#MngCompCtrl').scope().loadDetails(compHeaderID);              
              //waitForDetailData();
          });

          function waitForDetailData() {
              if (typeof angular.element('#MngCompCtrl').scope().detailsLoaded !== "undefined") {
                  //just wait
              }
              else {
                  setTimeout(function () {
                      waitForDetailData();
                  }, 250);
              }
          }

            $("#searchbox").keyup(function () {
                
                dataTable.search(this.value).draw();
            });
          
        });
    </script>
  
     <style>
             .box {
            height: 300px !important;
            cursor: pointer;
        }

        .check {
            opacity: .5;
        }

        .inputValidation {
            border: 1px solid red;
        }
         .dataTables_filter{
             display: none;
         }
        .filterable {
            margin-top: 15px;
        }

            .filterable .panel-heading .pull-right {
                margin-top: -20px;
            }

            .filterable .filters input[disabled] {
                background-color: transparent;
                border: none;
                cursor: auto;
                box-shadow: none;
                padding: 0;
                height: auto;
            }

                .filterable .filters input[disabled]::-webkit-input-placeholder {
                    color: #333;
                }

                .filterable .filters input[disabled]::-moz-placeholder {
                    color: #333;
                }

                .filterable .filters input[disabled]:-ms-input-placeholder {
                    color: #333;
                }
        .btn-filter{
            cursor:pointer;
        }
    </style>
</asp:Content>
