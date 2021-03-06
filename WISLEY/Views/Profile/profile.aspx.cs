﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Collab;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Quiz;
using WISLEY.BLL.User;

namespace WISLEY
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null && Session["uid"] != null)
            {
                LbEmail.Text = Session["email"].ToString();
                hidotheremail.Value = Session["uid"].ToString();
                userid.Value = Session["uid"].ToString();
                
                if (Session["success"] != null)
                {
                    toast(this, Session["success"].ToString(), "Success", "success");
                    Session["success"] = null;
                }

                if (Request.QueryString["id"] != null)
                {
                    userid.Value = Request.QueryString["id"];
                }

                if (!Page.IsPostBack)
                {
                    User user = new User().SelectById(userid.Value);
                    LbEmail.Text = user.email;
                    LbName.Text = user.name;
                    LbType.Text = user.userType;
                    LbWISPoints.Text = user.points.ToString();
                    LbBio.Text = user.bio;
                    TbBio.Text = user.bio;
                    LbDob.Text = "Date of Birth: ";
                    LbContact.Text = "Contact Number: ";
                    if (!String.IsNullOrEmpty(user.dob))
                    {
                        LbDob.Text += user.dob;
                    }
                    else
                    {
                        LbDob.Text += "Not set";
                    }
                    if (!String.IsNullOrEmpty(user.contactNo))
                    {
                        LbContact.Text += user.contactNo;
                    }
                    else
                    {
                        LbContact.Text += "Not set";
                    }
                    if (String.IsNullOrEmpty(user.bio))
                    {
                        LbBio.Text = "Currently Empty";
                    }
                    else
                    {
                        LbBio.Text = user.bio;
                    }
                    List <Post> userposts = new Post().SelectByUser(userid.Value);
                    List <Quiz> quizposts = new Quiz().SelectByUserId(userid.Value);
                    List <Badge> unlockedbadges = new Badge().SelectByUserId(userid.Value, "Unlocked");
                    List <Badge> lockedbadges = new Badge().SelectByUserId(userid.Value, "Locked");
                    userpost.DataSource = userposts;
                    userpost.DataBind();
                    userquiz.DataSource = quizposts;
                    userquiz.DataBind();
                    unlocked_badges.DataSource = unlockedbadges;
                    unlocked_badges.DataBind();
                    locked_badges.DataSource = lockedbadges;
                    locked_badges.DataBind();
                    LbNofUnlockedBadges.Text = new Badge().GetBadgeCount(userid.Value, "Unlocked").ToString();
                    LbNofLockedBadges.Text = new Badge().GetBadgeCount(userid.Value, "Locked").ToString();
                }
            }
            else
            {
                Session["error"] = "You must be logged in to view profile!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }

        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            if (Request.QueryString["id"] != null)
            {
                user = new User().SelectById(Request.QueryString["id"]);
            }

            return user;
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btneditProfile_Click(object sender, EventArgs e)
        {
            Session["email"] = LbEmail.Text;
            Response.Redirect("editprofile.aspx");
        }


        protected void btnchangeAvatar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/Views/Gacha/Avatar.aspx"));
        }

        protected void btnEditBio_Click(object sender, EventArgs e)
        {
            TbBio.Visible = true;
            btnCancelChanges.Visible = true;
            btnSaveChanges.Visible = true;
            btnEditBio.Visible = false;
            LbBioDesc.Visible = true;
        }

        protected void btnCancelChanges_Click(object sender, EventArgs e)
        {
            TbBio.Visible = false;
            btnCancelChanges.Visible = false;
            btnSaveChanges.Visible = false;
            btnEditBio.Visible = true;
            LbBioDesc.Visible = false;
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string email = LbEmail.Text.ToString();
            string bio = TbBio.Text;

            User user = new User();
            int result = user.UpdateBio(email, bio);
            if (result == 1)
            {
                TbBio.Visible = false;
                btnCancelChanges.Visible = false;
                btnSaveChanges.Visible = false;
                btnEditBio.Visible = true;
                LbBioDesc.Visible = false;
                Session["success"] = "Your changes have been saved!";
                Response.Redirect("profile.aspx");
            }
            else
            {
                toast(this, "Changes were unable to be saved, please inform system administrator!", "Error", "error");
            }
        }

        protected void userpost_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            List<Post> userposts = new Post().SelectByUser(userid.Value);
            if (userposts.Count < 1 && e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void userpost_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewpost")
            {
                Session["postId"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Board/viewpost.aspx"));
            }
            if (e.CommandName == "download")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string grpId = commandArgs[0];
                string fileName = commandArgs[1];
                string folderPath = Server.MapPath("~/Public/uploads/posts/") + grpId + "/" + user().id;

                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("content-disposition", $"filename={fileName}");
                Response.TransmitFile(folderPath + "\\" + fileName);
            }
        }

        protected void userquiz_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            List<Quiz> quizposts = new Quiz().SelectByUserId(userid.Value);
            foreach (RepeaterItem rt in userquiz.Items)
            {
                int totalquestions = int.Parse((rt.FindControl("LbNofQuestions") as Label).Text);
                if (totalquestions == 0)
                {
                    rt.FindControl("viewquiz").Visible = false;
                    rt.FindControl("LbUnavailable").Visible = true;
                }
            }
            if (quizposts.Count < 1 && e.Item.ItemType == ListItemType.Footer)
            {
                e.Item.FindControl("LbErr").Visible = true;
            }
        }

        protected void userquiz_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "viewquiz")
            {
                Response.Redirect(Page.ResolveUrl("~/Views/Quiztool/viewquiz.aspx?id=" + e.CommandArgument.ToString()));
            }

            if (e.CommandName == "deletequiz")
            {
                int result = new Quiz().DeleteById(e.CommandArgument.ToString());
                if (result == 1)
                {
                    Session["success"] = "Quiz deleted!";
                    Response.Redirect("profile.aspx");
                }
                else
                {
                    toast(this, "Quiz could not be deleted, please inform system administrator!", "Error", "error");
                }
            }

            if (e.CommandName == "editquiz")
            {
                Session["quizId"] = e.CommandArgument.ToString();
                Response.Redirect(Page.ResolveUrl("~/Views/Quiztool/editquiz.aspx"));
            }
        }

        protected void locked_badges_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (locked_badges.Items.Count < 1)
            {
                if (e.Item.ItemType == ListItemType.Footer)
                {
                    e.Item.FindControl("LbErr").Visible = true;
                }
            }
        }
    }
}