﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;

namespace WISLEY
{
    public partial class viewpost : System.Web.UI.Page
    {
        public int commcount()
        {
            List<Comment> allComments = new Comment().SelectByPost(LbPostID.Text);
            return allComments.Count;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["postId"] != null && Session["email"] != null)
            {
                LbEmail.Text = Session["email"].ToString();
                LbPostID.Text = Session["postId"].ToString();
                commcount();
                postdata.SelectCommand = "SELECT post.*, [User].name FROM POST " +
                    "INNER JOIN [User] ON post.userId = [User].Id " +
                    "WHERE Id = " + LbPostID.Text;
                commentdata.SelectCommand = "SELECT comment.*, [User].name FROM COMMENT " +
                    "INNER JOIN [User] ON comment.userId = [User].Id " +
                    "WHERE postId = " + LbPostID.Text + "ORDER BY Id DESC";
                if (Session["success"] != null)
                {
                    toast(this, "Comment posted!", "Success", "success");
                    Session["success"] = null;
                }
            }
            else
            {
                Session["error"] = "You must be logged in to view posts!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        public bool ValidateInput(string content)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(content))
            {
                toast(this, "Please enter some content!", "Error", "error");
                valid = false;
            }
            return valid;
        }

        protected void btncomment_Click(object sender, EventArgs e)
        {
            if (ValidateInput(tbcomment.Text))
            {
                string postId = LbPostID.Text;
                string content = tbcomment.Text;
                string date = DateTime.Now.ToString("dd/MM/yyyy");

                Comment comment = new Comment(postId, LbEmail.Text, content, date);
                int result = comment.AddComment();

                if (result == 1)
                {
                    Session["success"] = "toast";
                    Response.Redirect("viewpost.aspx");
                }
                else
                {
                    toast(this, "Unable to post comment, please inform system administrator!", "Error", "error");
                }
            }
        }

        protected void commentinfo_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewprofile")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id="+ e.CommandArgument.ToString()));
            }

            if (e.CommandName == "editcomm")
            {
                e.Item.FindControl("commcontent").Visible = false;
                e.Item.FindControl("tbUpcomm").Visible = true;
                e.Item.FindControl("editbtns").Visible = true;
            }

            if (e.CommandName == "cancel")
            {
                e.Item.FindControl("commcontent").Visible = true;
                e.Item.FindControl("tbUpcomm").Visible = false;
                e.Item.FindControl("editbtns").Visible = false;
            }

            if (e.CommandName == "save")
            {
                string commId = e.CommandArgument.ToString();
                TextBox content = e.Item.FindControl("tbUpcomm") as TextBox;
                string dateedit = DateTime.Now.ToString("dd/MM/yyyy");
                if (ValidateInput(content.Text))
                {
                    Comment comment = new Comment();
                    int result = comment.UpdateComment(commId, content.Text, dateedit);
                    if (result == 1)
                    {
                        toast(this, "Changes saved!", "Success", "success");
                        e.Item.FindControl("commcontent").Visible = true;
                        e.Item.FindControl("tbUpcomm").Visible = false;
                        e.Item.FindControl("editbtns").Visible = false;
                        commentinfo.DataSourceID = "commentdata";
                    }
                    else
                    {
                        toast(this, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
                        e.Item.FindControl("commcontent").Visible = true;
                        e.Item.FindControl("tbUpcomm").Visible = false;
                        e.Item.FindControl("editbtns").Visible = false;
                    }
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("collab.aspx");
        }

        protected void post_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewpost")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx?id="+ e.CommandArgument.ToString()));
            }
        }

        protected void commentinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            LinkButton userId = (LinkButton)e.Item.FindControl("viewprofile");
            if (userId.Text != LbEmail.Text)
            {
                e.Item.FindControl("btnEdit").Visible = false;
            }
        }
    }
}