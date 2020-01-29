﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Masters/sidebar.master" AutoEventWireup="true" CodeBehind="schedule.aspx.cs" Inherits="WISLEY.Views.Schedule.schedules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="sidebarContent" runat="server">
    <div class="col-12 border border-secondary">
        <div class="card">
            <div class="card-body m-0 m-auto">
                <div class="row">
                    <div class="col-sm-12 col-md-12 col-lg-12">
                        <h3 class="text-center font-weight-bold">My Calendar</h3>
                        <asp:Calendar ID="calendarPlan" runat="server" BackColor="White" BorderColor="Black" Font-Names="Arial Black" Font-Size="10pt" ForeColor="Black" Height="430px" Width="690px" ShowGridLines="True" OnSelectionChanged="calendarPlan_SelectionChanged" OnDayRender="calendarPlan_DayRender">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" VerticalAlign="Middle" />
                            <DayStyle Width="14%" Font-Bold="True" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="White" Font-Bold="True" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#1F78C0" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <TodayDayStyle BackColor="#4899E1" Font-Bold="True" />
                            <WeekendDayStyle Font-Bold="True" ForeColor="Red" />
                        </asp:Calendar>
                    </div>
                </div>
            </div>
        </div>

        <br/>

        <div class="card">
            <div class="card-body">
                <h3 class="text-center font-weight-bold">Your To-Do-Lists</h3>
                <% string todoTitle = Request.QueryString["todoTitle"]; %>
                <% if (string.IsNullOrEmpty(todoTitle))
                    { %>
                <div class="card-body">
                    <h2 class="font-weight-bold text-center">Currently Empty</h2>
                </div>
                <asp:SqlDataSource runat="server" ID="postToDoList" ConnectionString="<%$ connectionStrings: ConnStr %>"></asp:SqlDataSource>
                <% } %>

                <% else
                    { %>
                <asp:Repeater ID="todolistRepeater" runat="server" DataSourceID="postToDoList" OnItemCommand="todolist_ItemCommand">
                    <ItemTemplate>
                        <div class="card-body">
                            <h2 class="font-weight-bold"><%#Eval("ToDotitle") %></h2>
                            <asp:Button runat="server" ID="btnEditToDo" CssClass="btn btn-info" OnClick="btnEditToDo_Click" Text="Edit to-do-list" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                
                <div class="card-body">
                    <p class="font-weight-bold">Total number of to-do-list: <%=ToDoListcount().ToString() %></p>
                </div>
                <% } %>
            </div>
        </div>
    </div>
</asp:Content>
