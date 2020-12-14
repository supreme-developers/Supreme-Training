<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BootStrap.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SSIWebTraining.Home" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <script src="js/jquery.scroll_to.js"></script>
    <script src="js/jquery.snapscroll.js"></script>

    <div class="container-fluid">
        <div class="hero hidden">
            <hgroup>
                <h1 class="page-header">Supreme Services Training</h1>
                <h3>Click the button below to get started.</h3>
            </hgroup>
            <asp:Button ID="LoginButton" runat="server" Text="Log In" SkinID="HeroButton" OnClick="Login_Click" />
            <%--<button id="LoadingButton" runat="server" visible="false" class="btn btn-hero btn-lg"><i class="fa fa-refresh fa-spin"></i>  Loading</button>--%>
        </div>
    </div>

    <style>
        body, html {
            height: 100%;
            width: 100%;
            background-repeat: no-repeat;
            background: linear-gradient(rgba(0,0,0,.5), rgba(0,0,0,.5)), url('../img/offshorerig.jpg');
            position: absolute;
            z-index: 2;
        }

        /********************************/
        /*          Hero Headers        */
        /********************************/
        .hero {
            position: absolute;
            top: 50%;
            left: 50%;
            z-index: 3;
            color: #fff;
            text-align: center;
            text-transform: uppercase;
            text-shadow: 1px 1px 0 rgba(0,0,0,.75);
            -webkit-transform: translate3d(-50%,-50%,0);
            -moz-transform: translate3d(-50%,-50%,0);
            -ms-transform: translate3d(-50%,-50%,0);
            -o-transform: translate3d(-50%,-50%,0);
            transform: translate3d(-50%,-50%,0);
        }

            .hero h1 {
                font-size: 5em;
                font-weight: bold;
                font-family: "Palatino Linotype", "Book Antiqua", Palatino, serif;
                margin: 0;
                padding: 0;
            }

        /********************************/
        /*          Custom Buttons      */
        /********************************/
        .btn.btn-lg {
            padding: 10px 40px;
        }

        .btn.btn-hero,
        .btn.btn-hero:focus {
            color: #f5f5f5;
            background-color: navy;
            border-color: Black;
            outline: none;
            margin: 20px auto;
            font-family: "Arial Black", Gadget, sans-serif;
        }

            .btn.btn-hero:hover {
                color: #f5f5f5;
                background-color: navy;
                border-color: white;
                outline: none;
                margin: 20px auto;
            }



        /********************************/
        /*          Media Queries       */
        /********************************/
        @media screen and (min-width: 980px) {
            .hero {
                width: 980px;
            }
        }

        @media screen and (max-width: 640px) {
            .hero h1 {
                font-size: 4em;
            }
        }
    </style>

    <script>
        $(document).ready(function () {
            $('div.hidden').fadeIn(5000).removeClass('hidden');
        });
    </script>

</asp:Content>
