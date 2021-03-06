﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WISLEY.BLL.Notification;
using WISLEY.BLL.Profile;
using WISLEY.BLL.Schedule;
using WISLEY.BLL.User;

namespace WISLEY
{
    public partial class todoplan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblSelectedDate.Text = Session["selectDate"].ToString();
        }

        public User currUser()
        {
            User user = new User().SelectByEmail(Session["email"].ToString());
            return user;
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("schedule.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                int userId = currUser().id;
                string selectedToDoDate = LblSelectedDate.Text;
                string todoTitle = tbTitle.Text.ToString();
                string todoDesc = tbDesc.Text.ToString();
                string status = "";

                Planner todoPlan = new Planner(userId, selectedToDoDate, todoTitle, todoDesc, status);
                int count = todoPlan.AddToDoList();
                int currentpoints = currUser().points;
                Badge badge = new Badge().SelectByBadgeId(currUser().id.ToString(), 11);
                Notify notify = new Notify(currUser().email, currUser().email, DateTime.Now.ToString(), "badge", -1, -1, 11);

                if (count == 1)
                {
                    if (badge.status == "Locked")
                    {
                        currentpoints += 50;
                        currUser().UpdateWISPoints(currUser().id, currentpoints);
                        badge.UpdateBadge(currUser().id.ToString(), 11, DateTime.Now.ToString("dd/MM/yyyy"), "Unlocked");
                        notify.AddBadgeNotif();
                    }
                    Session["success"] = "Your plan has been added sucessfully!";
                    Response.Redirect("schedule.aspx");
                }

                else
                {
                    Session["error"] = "There was an error while adding your plan, please contact system administrator!";
                    Response.Redirect("schedule.aspx");
                }
            }
        }

        public bool validateInput()
        {
            bool isValid = false;

            if (String.IsNullOrEmpty(tbTitle.Text))
            {
                toast(this, "Please enter your title!", "Error", "error");
            }

            else if (String.IsNullOrEmpty(tbDesc.Text))
            {
                toast(this, "Please enter your description!", "Error", "error");
            }

            else
            {
                isValid = true;
            }

            return isValid;
        }
    }
}