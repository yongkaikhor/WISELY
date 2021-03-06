﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Profile;

namespace WISLEY.Views.Group
{
    public partial class members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Request.QueryString["groupId"] != null && !isGroupMember(user().email))
                {
                    Session["error"] = "You are not a member of this group.";
                    Response.Redirect(Page.ResolveUrl("~/Views/Board/collab.aspx"));
                }
                else
                {
                    memberData.SelectCommand = "Select * from [User] " +
                    "where email in (Select userEmail from [GroupUserRelations] where groupID = '" + getGroupDetails().id + "')";

                }

            }
            else
            {
                Session["error"] = "You must be logged in to view members!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }

        }

        public bool isGroupMember(string email)
        {
            BLL.Group.Group grp = new BLL.Group.Group();
            List<BLL.Group.Group> grpList = grp.getGroupsJoined(email);
            bool isMember = false;
            for (int i = 0; i < grpList.Count; i++)
            {
                if (grpList[i].id == int.Parse(Request.QueryString["groupId"]))
                {
                    isMember = true;
                }
            }
            return isMember;
        }

        public void toast(Page page, string message, string title, string type)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void memberCommands(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "removeFromGroup")
            {
                BLL.Group.Group grp = new BLL.Group.Group();
                grp.removeMemberFromGroup(e.CommandArgument.ToString(), Request.QueryString["groupId"]);
                Response.Redirect(Request.RawUrl);

            }
        }

        protected void memberList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField userEmail = (HiddenField)e.Item.FindControl("userEmail");
                //System.Diagnostics.Debug.WriteLine(userEmail.Value);
                //System.Diagnostics.Debug.WriteLine(user().email);

                if (user().userType != "Teacher")
                {
                    e.Item.FindControl("userDeleteBtn").Visible = false;
                }

                if (userEmail.Value.ToString() == user().email)
                {
                    System.Diagnostics.Debug.WriteLine("entered");

                    e.Item.FindControl("userDeleteBtn").Visible = false;

                }
            }

            //if (e.Item.ItemType == ListItemType.Footer && postinfo.Items.Count < 1)
            //{
            //    e.Item.FindControl("LbErr").Visible = true;
            //}

        }

        public BLL.Group.Group getGroupDetails()
        {
            string grpId = Request.QueryString["groupId"];
            BLL.Group.Group grp = new BLL.Group.Group().getGroupByID(grpId);
            return grp;
        }

        public User user()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

    }
}