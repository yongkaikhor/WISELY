﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WISLEY.Views.Quiztool
{
    public partial class question : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                if (Session["success"] != null)
                {
                    toast(this, Session["success"].ToString(), "Success", "success");
                    Session["success"] = null;
                }
                if (Session["error"] != null)
                {
                    toast(this, Session["error"].ToString(), "Error", "error");
                    Session["error"] = null;
                }
                if (Session["quizId"] != null)
                {
                    LbQuizId.Text = Session["quizId"].ToString();
                }
                if (Session["next"] != null)
                {
                    LbQuestionNo.Text = Session["next"].ToString();
                }
                else
                {
                    if (Session["previous"] != null)
                    {
                        LbQuestionNo.Text = Session["previous"].ToString();
                    }
                }
                if (LbQuestionNo.Text == "1")
                {
                    btnPrevious.Visible = false;
                }
                if (DdlOptions.SelectedItem.Value == "2")
                {
                    TbOption3.Visible = false;
                    LbOption3.Visible = false;
                    TbOption4.Visible = false;
                    LbOption4.Visible = false;
                    TbOption5.Visible = false;
                    LbOption5.Visible = false;
                }
                else if (DdlOptions.SelectedItem.Value == "3")
                {
                    TbOption3.Visible = true;
                    LbOption3.Visible = true;
                    TbOption4.Visible = false;
                    LbOption4.Visible = false;
                    TbOption5.Visible = false;
                    LbOption5.Visible = false;
                }
                else if (DdlOptions.SelectedItem.Value == "4")
                {
                    TbOption3.Visible = true;
                    LbOption3.Visible = true;
                    TbOption4.Visible = true;
                    LbOption4.Visible = true;
                    TbOption5.Visible = false;
                    LbOption5.Visible = false;
                }
                else if (DdlOptions.SelectedItem.Value == "5")
                {
                    TbOption3.Visible = true;
                    LbOption3.Visible = true;
                    TbOption4.Visible = true;
                    LbOption4.Visible = true;
                    TbOption5.Visible = true;
                    LbOption5.Visible = true;
                }
            }
            else
            {
                Session["error"] = "You must be logged in to have access to the quiz creator!";
                Response.Redirect(Page.ResolveUrl("~/Views/index.aspx"));
            }
        }

        public void toast(Page page, string message, string title, string type)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastmsg", "toastnotif('" + message + "','" + title + "','" + type.ToLower() + "');", true);
        }

        protected void DdlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlOptions.SelectedItem.Value == "2")
            {
                TbOption3.Visible = false;
                LbOption3.Visible = false;
                TbOption4.Visible = false;
                LbOption4.Visible = false;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "3")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = false;
                LbOption4.Visible = false;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "4")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = true;
                LbOption4.Visible = true;
                TbOption5.Visible = false;
                LbOption5.Visible = false;
            }
            else if (DdlOptions.SelectedItem.Value == "5")
            {
                TbOption3.Visible = true;
                LbOption3.Visible = true;
                TbOption4.Visible = true;
                LbOption4.Visible = true;
                TbOption5.Visible = true;
                LbOption5.Visible = true;
            }
        }
        int questionNo = 0;

        public bool ValidateInput(string option1, string option2, string option3, string option4, string option5)
        {
            bool valid = true;
            if (String.IsNullOrEmpty(option1))
            {
                toast(this, "Please enter an answer for Option 1!", "Error", "error");
                valid = false;
            }
            else if (String.IsNullOrEmpty(option2))
            {
                toast(this, "Please enter an answer for Option 2!", "Error", "error");
                valid = false;
            }
            else if ((DdlOptions.SelectedItem.Value == "3" || DdlOptions.SelectedItem.Value == "4" || DdlOptions.SelectedItem.Value == "5" ) && String.IsNullOrEmpty(option3))
            {
                toast(this, "Please enter an answer for Option 3!", "Error", "error");
                valid = false;
            }
            else if ((DdlOptions.SelectedItem.Value == "4" || DdlOptions.SelectedItem.Value == "5") && String.IsNullOrEmpty(option4))
            {
                toast(this, "Please enter an answer for Option 4!", "Error", "error");
                valid = false;
            }
            else if (DdlOptions.SelectedItem.Value == "5" && String.IsNullOrEmpty(option5))
            {
                toast(this, "Please enter an answer for Option 5!", "Error", "error");
                valid = false;
            }
            if (DdlCorrect.SelectedItem.Value == "N/A")
            {
                toast(this, "Please select correct answer!", "Error", "error");
                valid = false;
            }
            return valid;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (ValidateInput(TbOption1.Text, TbOption2.Text, TbOption3.Text, TbOption4.Text, TbOption5.Text))
            {
                questionNo = int.Parse(LbQuestionNo.Text);
                questionNo += 1;
                Session["next"] = questionNo.ToString();
                Session["previous"] = null;
                Session["success"] = "Question " + LbQuestionNo.Text + " saved!";
                Response.Redirect("question.aspx");
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (ValidateInput(TbOption1.Text, TbOption2.Text, TbOption3.Text, TbOption4.Text, TbOption5.Text))
            {
                questionNo = int.Parse(LbQuestionNo.Text);
                questionNo -= 1;
                Session["next"] = null;
                Session["previous"] = questionNo.ToString();
                Session["success"] = "Question " + LbQuestionNo.Text + " saved!";
                Response.Redirect("question.aspx");
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Session["success"] = "Your quiz has been saved! You may view it in your profile.";
            Response.Redirect(Page.ResolveUrl("~/Views/Profile/profile.aspx"));
        }
    }
}