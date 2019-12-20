﻿<%@ Page Title="" Language="C#" MasterPageFile="~/group.Master" AutoEventWireup="true" CodeBehind="collab.aspx.cs" Inherits="WISLEY.collab" %>

<asp:Content ID="Content2" ContentPlaceHolderID="groupPosts" runat="server">
    <h3 class="font-weight-bold text-center">Collaboration Board</h3>
    <form runat="server">
        <div class="container">
            <div class="card">
                <div class="card-body">
                    <div class="md-form md-outline">
                        <asp:Label ID="LbPost" AssociatedControlID="tbtitle" runat="server" Text="Post Title"></asp:Label>
                        <asp:TextBox ID="tbtitle" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <hr />
                    <div class="md-form md-outline">
                        <asp:Label ID="LbDesc" AssociatedControlID="tbcontent" runat="server" Text="Post Description"></asp:Label>
                        <asp:TextBox ID="tbcontent" runat="server" TextMode="MultiLine" CssClass="form-control" Rows="6"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="custom-file">
                                <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-input" />
                                <asp:Label ID="LbFile" AssociatedControlID="fileUpload" runat="server" Text="Upload a file" CssClass="custom-file-label"></asp:Label>
                            </div>
                        </div>   
                        <div class="col-lg-6 text-right">
                            <asp:Button CssClass="btn btn-success ml-auto" ID="btnpost" runat="server" Text="Post" OnClick="btnpost_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <% if (allPosts().Count > 0)
                { %>
            <% foreach (var post in allPosts())
                { %>
            <div class="card mt-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <h4 class="card-title"><% =post.title %></h4>
                        </div>
                        <div class="col-lg-6 text-right">
                            <div class="dropup">
                                <button type="button" class="btn btn-sm btn-info dropdown-toggle" data-toggle="dropdown" aria-expanded="false" aria-haspopup="true">More Options</button>
                                <div class="dropdown-menu">
                                    <asp:LinkButton ID="LinkEdit" CssClass="dropdown-item" runat="server">Edit<i class="fas fa-pencil mr-1"></i></asp:LinkButton>
                                    <asp:LinkButton ID="LinkDel" CssClass="dropdown-item" runat="server">Delete<i class="fas fa-trash mr-1"></i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="media mt-4 px-1">
                        <img class="card-img-100 d-flex z-depth-1 mr-3" src="https://picsum.photos/100"
                            alt="Generic placeholder image">
                        <div class="media-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <h5 class="font-weight-bold mt-0">
                                        <a href="#">Danny Newman</a>
                                    </h5>
                                </div>
                                <div class="col-lg-6">
                                    <i class="fas fa-clock mr-1"></i><span>Created on: <% =post.datecreated.ToShortDateString() %>
                                    </span>
                                </div>
                            </div>
                            <% =post.content %>
                        </div>
                    </div>
                    <hr />
                    <h5 class="text-center my-3">Comments</h5>
                    <div class="accordion" role="tablist" id="commentacc" aria-multiselectable="true">
                        <div class="card">
                            <div class="card-header" role="tab" id="commhead">
                                <a data-toggle="collapse" data-parent="#commentacc" href="#comms" aria-expanded="true"
                                    aria-controls="comms">
                                    <div class="card-header border-0 font-weight-bold"><%=allComments.Count.ToString() %> comment(s)<i class="fas fa-angle-down rotate-icon mr-1"></i></div>
                                </a>
                            </div>
                            <div id="comms" class="collapse" role="tabpanel" aria-labelledby="commhead" data-parent="#commentacc">
                                <div class="card-body">
                                    <asp:Button ID="btnAddComment" runat="server" Text="Add Comment" CssClass="btn btn-sm btn-info" OnClick="btnAddComment_Click" />
                                    <% if (allComments.Count > 0)
                                        { %><% foreach (var comment in allComments)
                                                { %>
                                    <div class="media d-block d-md-flex mt-4">
                                        <img class="card-img-64 d-flex mx-auto mb-3" src="https://picsum.photos/100"
                                            alt="Generic placeholder image">
                                        <div class="media-body text-center text-md-left ml-md-3 ml-0">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <h5 class="font-weight-bold mt-0">
                                                        <a href="#">Howard</a>
                                                    </h5>
                                                </div>
                                                <div class="col-lg-6">
                                                    <i class="fas fa-clock mr-1"></i><span>Posted on: <% =comment.datecreate.ToShortDateString() %></span>
                                                </div>
                                            </div>
                                            <%=comment.content %>
                                        </div>
                                        <%} %>
                                        <%} %>
                                        <% else
                                            { %>
                                        <h5 class="mt-3 font-weight-bold">No Comments</h5>
                                        <%} %>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <%} %>            <%} %><% else
                                            { %>
                <div class="text-center mt-3">
                    <h4 class="font-weight-bold">No Posts</h4>
                </div>
                <% } %>
            </div>
        </div>
    </form>
</asp:Content>
