﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="WISLEY.Views.Quiz.question" %>

<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container">
        <div class="card z-depth-3 pb-0 px-0">
            <div class="card-body px-5">
                <h5 class="card-title mb-4">Question <asp:Label ID="LbQuestionNo" runat="server" Text="1"></asp:Label></h5>
                <div class="md-form md-outline">
                    <asp:Label ID="LbOptions" runat="server" Text="Number of options: "></asp:Label>
                    <asp:DropDownList ID="DdlOptions" runat="server">
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div>
                    <div class="md-form md-outline">      
                        <asp:Label AssociatedControlID="TbOption1" ID="LbOption1" runat="server" Text="Option 1"></asp:Label>
                        <asp:TextBox ID="TbOption1" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbOption2" ID="LbOption2" runat="server" Text="Option 2"></asp:Label>
                        <asp:TextBox ID="TbOption2" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbOption3" ID="LbOption3" runat="server" Text="Option 3"></asp:Label>
                        <asp:TextBox ID="TbOption3" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbOption4" ID="LbOption4" runat="server" Text="Option 4"></asp:Label>
                        <asp:TextBox ID="TbOption4" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="md-form md-outline">
                        <asp:Label AssociatedControlID="TbOption5" ID="LbOption5" runat="server" Text="Option 5"></asp:Label>
                        <asp:TextBox ID="TbOption5" runat="server" Width="600px" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="md-form md-outline">
                    <asp:Label ID="LbCorrect" runat="server" Text="Select correct answer: "></asp:Label>
                    <asp:DropDownList ID="DdlCorrect" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="text-right">
                    <asp:Button CssClass="btn btn-info" ID="btnNext" runat="server" Text="Next Question >"/>
                    <asp:Button CssClass="btn btn-info" ID="btnSave" runat="server" Text="< Previous Question"/>
                    <asp:Button CssClass="btn btn-danger" ID="btnExit" runat="server" Text="Exit"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>