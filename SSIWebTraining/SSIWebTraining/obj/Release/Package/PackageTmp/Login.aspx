<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BootStrap.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SSIWebTraining.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="css/login.css" rel="stylesheet" />
    <%--<link href="css/3DButtons.css" rel="stylesheet" />--%>

    <div class="container">
         <div class="row" >
        <div class="col-md-6  text-center" >
            <asp:Login ID="Login2" runat="server" EnableViewState="true" OnAuthenticate="Login2_Authenticate" RenderOuterTable="false">

            <LayoutTemplate>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton">
                    <div class="container">
                        <div class="card card-container">
                            <img src="img/SSI-CompAssurance.png" class="profile-img-card"  alt="supreme" /><br />
                            <%--<p id="profile-name" class="profile-name-card">&nbsp;</p>--%>
                            <div class="form-signin">
                                <div class="input-group input-group-lg">
                                   
                                    <asp:TextBox ID="UserName" class="form-control input-lg" runat="server" placeholder="User Name" required="true"></asp:TextBox>
                                     <span class="input-group-addon input-lg"><i class="fa fa-user"></i></span>
                                </div>
                            <br />
                            <div class="input-group input-group-lg ">
                                <asp:TextBox ID="Password" TextMode="Password" class="form-control" runat="server" placeholder="Password" required="true" MaxLength="9"></asp:TextBox>
                                <span class="input-group-addon input-lg"><i class="fa fa-lock fa-1x"></i></span>
                            </div><br />
                                <div style="color: red">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                
                              <asp:LinkButton ID="LoginButton" CssClass="btn btn-info btn-lg" runat="server" Text="Sign In" CommandName="Login" ></asp:LinkButton>
                            </div>
                            <br />
                            <button type="button" class="btn-link" data-toggle="modal" data-target="#InfoModal">Need Help Signing In?</button>
                        </div>
                         
                    </div>
                  
                   
                </asp:Panel>
                    </div>
            </LayoutTemplate>
        </asp:Login>
        </div>
    </div>
        
        <div class="card card-container col-lg-12 col-lg-offset-5" style="display:none">
            <img class="profile-img-card" src="img/SSI-Comp.png.png" alt="supreme" />
            <p id="profile-name" class="profile-name-card">&nbsp;</p>
            <div class="form-signin">
                <div class="input-group input-group-lg">
                    <span class="input-group-addon input-lg"><i class="glyphicon glyphicon-user"></i></span>
                    <asp:TextBox ID="inputUserName" class="form-control" runat="server" placeholder="User Name" required="true"></asp:TextBox>
                </div>
                <br />
                <div class="input-group input-group-lg">
                    <span class="input-group-addon input-lg"><i class="glyphicon glyphicon-lock"></i></span>
                    <asp:TextBox ID="inputPassword" TextMode="Password" class="form-control" runat="server" placeholder="Password" required="true" MaxLength="9"></asp:TextBox>
                </div>
                <br />
                
                <asp:Button ID="btnSignIns" CssClass="btn btn-info" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />                        
                <%--<button ID="btnSignIn" type="button" class="btn btn-info btn-lg" 
                    onserverclick="btnSignIn_Click">Sign In</button>--%>
            </div>
            <br />
            <button type="button" class="btn-link" data-toggle="modal" data-target="#InfoModal">Need Help Signing In?</button>
        </div>

    </div>

    <%--Info Modal--%>
    <div class="modal fade bs-example-modal-lg" id="InfoModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-md">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <img src="img/SSI_Logo_highres_enhanced.png" /> Supreme Services Competencies
                         <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </h3>
                </div>
                <div class ="panel-body" >
                <div class="form-group" style="font-size: medium">
                     <span class="help-block"> A user login requires the first letter of the user's first name plus full last name.
                    The password is the user's 9 digit social security number. </span>
                    <span> <b>Example User: John Doeing </b> </span>
                    <br />
                    <br />
                     Username: <asp:TextBox ID="tb1" runat="server" Enabled="false" Text="jdoeing"></asp:TextBox>
                    <br />
                    Password: <asp:TextBox ID="tb2" runat="server" Enabled="false" Text="*********"></asp:TextBox>
                </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnClose" SkinID="PrimaryButton" runat="server" Text="Close" data-dismiss="modal" />
                    </div>
            </div>
        </div>
    </div>

</asp:Content>
