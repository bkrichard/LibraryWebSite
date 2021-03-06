﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectHelper;

namespace BookReviewSite
{
    public partial class ReviewOverview : System.Web.UI.Page
    {
        DateTime d1 = DateTime.Now;
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = (User)Session["User"];
            ReviewList rl = new ReviewList();
            rl = rl.GetByUserID(user.ID);

            lblRegistered.Text = user.DateCreated.ToString();
            TimeSpan DateDiff = (d1 - user.DateCreated);
            double PostPerDay = user.UserBooks.Count / DateDiff.TotalDays;
            lblPostsMade.Text = rl.Count + " (" + Math.Round(PostPerDay, 2) + " per day)";
            lblBooksPosted.Text = user.UserBooks.Count.ToString(); 
        }
    }
}