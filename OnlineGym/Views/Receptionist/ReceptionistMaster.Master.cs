using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Receptionist
{
    public partial class ReceptionistMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("RecCookie");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            Response.Redirect("../Login.aspx");
        }
    }
}