<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Header.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebApplicationGestionProjects.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="icon" href="/docs/4.0/assets/img/favicons/favicon.ico">
    <link rel="canonical" href="https://getbootstrap.com/docs/4.0/examples/cover/">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="cover-container d-flex h-100 p-3 mx-auto flex-column text-center" style="color:white">
    <main role="main" class="inner cover" style="margin-top:10%">
        <h1 class="cover-heading">Welcome to DashBoard.</h1>
        
        <p class="lead" >Manage your worker and your projects</p>
        <p class="lead">
          <a href="#" class="btn btn-lg btn-success">Start Here</a>
        </p>
      </main>

      <footer class="mastfoot mt-auto">
        <div class="inner"  style="margin-top:20%;">
          <p>Cover template for <a href="https://getbootstrap.com/">Bootstrap</a>, by @mhd.</p>
        </div>
      </footer>
    </div>
</asp:Content>
