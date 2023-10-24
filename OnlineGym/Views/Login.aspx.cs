using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
        }
        public static string AgentId = "";
        public static string AgentName = "";
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            if (AdminRadio.Checked)
            {
                if(loginEmail.Value == "admin@1gmail.com" && loginPass.Value == "adminPass")
                {
                    HttpCookie cookie = new HttpCookie("AuthCookie");
                    cookie.Values["username"] = "admin";
                    Response.Cookies.Add(cookie);
                    Response.Redirect("Admin/Coaches.aspx");
                }
                else
                {
                    ErrMsg.Text = "Admin Login Credentials are Incorrect";
                }
            }
            else
            {
                try
                {
                    string Query = "Select RecepId, RecepName,RecepEmail, RecepPass From ReceptionistTbl where RecepEmail = '{0}' and RecepPass = '{1}'";
                    Query = string.Format(Query, loginEmail.Value, loginPass.Value);
                    DataTable dt = Con.GetData(Query);
                    if(dt.Rows.Count == 0)
                    {
                        ErrMsg.Text = "Invalid Receptionist Credentials!!!";
                    }
                    else
                    {
                        AgentId = dt.Rows[0][0].ToString();
                       // Response.Write(AgentId);

                        AgentName = dt.Rows[0][1].ToString();
                        //
                        //Response.Write(AgentId);

                        HttpCookie cookie = new HttpCookie("RecCookie");
                        cookie.Values["username"] = AgentName;
                        Response.Cookies.Add(cookie);
                        Response.Redirect("Receptionist/Members.aspx");
                    }

                }
                catch(Exception ex)
                {
                    ErrMsg.Text = ex.Message;
                }
            }
        }
    }
}