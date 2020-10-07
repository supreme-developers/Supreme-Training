﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="SSIWebTraining.Testing.Testing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!DOCTYPE html>
<html ng-app="drag-and-drop">
  <head lang="en">
    <meta charset="utf-8">
    <title>Drag & Drop: Multiple listsr</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1/jquery-ui.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.0/angular.min.js"></script>
    <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/themes/ui-lightness/jquery-ui.min.css" rel="stylesheet" type="text/css" />
    <link href="https://netdna.bootstrapcdn.com/twitter-bootstrap/2.1.1/css/bootstrap.min.css" rel="stylesheet">
    <script src="angular-dragdrop.min.js"></script>
        <script src="app.js"></script>
    <style>
      .thumbnail { height: 280px !important; }
      .btn-droppable { width: 180px; height: 30px; padding-left: 4px; }
      .btn-draggable { width: 160px; }
      .emage { height: 215px; }
      h1 { padding: .2em; margin: 0; }
      #products { float:left; width: 500px; margin-right: 2em; }
      #cart { width: 200px; float: left; margin-top: 1em; }
      #cart ol { margin: 0; padding: 1em 0 1em 3em; }
    </style>
  </head>
  <body ng-controller="oneCtrl">
    <div id="products">
      <h1 class="ui-widget-header">Products</h1>
      <div id="catalog">
        <h2><a href="#">T-Shirts</a></h2>
        <div>
          <ul>
            <li ng-repeat='item in list1' ng-show="item.title" data-drag="true" data-jqyoui-options="{revert: 'invalid', helper: 'clone'}" ng-model="list1" jqyoui-draggable="{index: {{$index}}, animate: true, placeholder: 'keep'}">{{item.title}}</li>
          </ul>
        </div>
        <h2><a href="#">Bags</a></h2>
        <div>
          <ul>
            <li ng-repeat='item in list2' ng-show="item.title" data-drag="true" data-jqyoui-options="{revert: 'invalid', helper: 'clone'}" ng-model="list2" jqyoui-draggable="{index: {{$index}}, placeholder: 'keep'}">{{item.title}}</li>
          </ul>
        </div>
        <h2><a href="#">Gadgets</a></h2>
        <div>
          <ul>
            <li ng-repeat='item in list3' ng-show="item.title" data-drag="true" data-jqyoui-options="{revert: 'invalid', helper: 'clone'}" ng-model="list3" jqyoui-draggable="{index: {{$index}}, placeholder: 'keep'}">{{item.title}}</li>
          </ul>
        </div>
      </div>
    </div> 
    <div id="cart">
        <h1 class="ui-widget-header">Shopping Cart</h1>
        <div class="ui-widget-content">
            <ol data-drop="true" ng-model='list4' jqyoui-droppable="{multiple:true}">
                <li ng-repeat="item in list4 track by $index" ng-show="item.title" data-drag="true" data-jqyoui-options="{revert: 'invalid', helper: 'clone'}" ng-model="list4" jqyoui-draggable="{index: {{$index}},animate:true}">{{item.title}}</li>
                <li class="placeholder" ng-hide="hideMe()">Add your items here</li>
            </ol>
        </div>
    </div>
  </body>
</html>
    </div>
    </form>
</body>
</html>
