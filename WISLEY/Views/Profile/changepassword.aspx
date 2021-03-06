﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="WISLEY.changepassword" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title mb-4">Change Password</h5>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbNewPassword" ID="LbNewPassword" runat="server" Text="New password"></asp:Label>
                    <asp:TextBox ID="TbNewPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="md-form md-outline">
                    <asp:Label AssociatedControlID="TbConfirmPassword" ID="LbConfirmPassword" runat="server" Text="Confirm password"></asp:Label>
                    <asp:TextBox ID="TbConfirmPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button CssClass="btn btn-danger" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                    <asp:Button CssClass="btn btn-success" ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
