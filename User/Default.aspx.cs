﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace User
{
    public partial class Default : System.Web.UI.Page
    {
        String Conn = ConfigurationManager.ConnectionStrings["CnnctSrngUserDB"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton _lnkbtnPermission = (LinkButton)Page.Master.FindControl("_lnkbtnPermission");
            LinkButton _lnkbtnUserList = (LinkButton)Page.Master.FindControl("_lnkbtnUserList");
            LinkButton _lnkbtnLogOut = (LinkButton)Page.Master.FindControl("_lnkbtnLogOut");
            if (Session["id"] == null)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Wrong Entries", "alert('Logged Out Timeout');", true);
                Response.Redirect("Login.aspx");

            }
            else
            {
                SqlConnection Connect = new SqlConnection(Conn);
                LinkButton _lnkbtnUserName = (LinkButton)Page.Master.FindControl("_lnkbtnUserName");
                _lnkbtnUserName.Text = "Hello, " + Session["id"].ToString() + "!";
                string CurrentUser = Session["id"].ToString();
                SqlCommand Cmd = new SqlCommand("SELECT * FROM USERS WHERE USERNAME=@UserName", Connect);
                Cmd.Parameters.AddWithValue("@UserName", CurrentUser);
                Connect.Open();
                SqlDataReader Reader = Cmd.ExecuteReader();
                while (Reader.Read())
                {
                    int UserTypeID = Convert.ToInt32(Reader["USERTYPEID"].ToString());
                    if (UserTypeID == 1)
                    {
                        _lnkbtnPermission.Visible = true;
                    }
                    else
                    {
                        _lnkbtnPermission.Visible = false;
                    }
                }
                Connect.Close();
            }
        }
    }
}