﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/navbar.Master" AutoEventWireup="true" CodeBehind="createGroup.aspx.cs" Inherits="WISLEY.Views.Group.createGroup" %>


<asp:Content ID="Content2" ContentPlaceHolderID="contentHolder1" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <h1 class="col-12 text-center">Create Group</h1>
            <div class="col-8 card-body border border-primary">
                <form action="POST">

                    <div class="form-row justify-content-start mb-4">
                        <div class="col-2">
                            <label for="groupName">Group Name</label>
                        </div>
                        <div class="col-6">
                            <input type="text" id="groupName" class="form-control">
                        </div>
                    </div>

                    
                    <div class="form-row justify-content-start">
                        <div class="col-2">
                            <label for="groupDescription">Group Description</label>
                        </div>
                        <div class="col-6">
                        <textarea class="form-control rounded-0" id="groupDescription" rows="3" placeholder="Message">
                        </textarea>
  
                        
                        </div>
                    </div>

                    div.row

                </form>
            </div>
        </div>
    </div>


</asp:Content>  