using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Admin
{
    public partial class Coaches : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {

            HttpCookie cookie = Request.Cookies.Get("AuthCookie");

            if(cookie == null)
            {
                ErrMsg.Text = "Admin should Login First...";
                Response.Redirect("../Login.aspx");
                //Server.Transfer("Views/Login.aspx");
            }

            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowCoaches();
            }
        }
        private void ShowCoaches()
        {
            string Query = "select * from CoachTbl";
            CoachList.DataSource = Con.GetData(Query);
            CoachList.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = CNameTb.Value;
                string gender = CGenCb.SelectedValue; 
                string phone = PhoneTb.Value;
                string DOB = CDOBTb.Value;
                string Address = CAddTb.Value;
                string experience = CExperTb.Value;
                string email = EmailTb.Value;

                string Query = "insert into CoachTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
                Query = string.Format(Query, name, gender, DOB, phone, experience, Address, email);
                Con.setData(Query);
                ShowCoaches();
                SuccMsg.Text = "Coach Added!!!";
                ErrMsg.Text = "";

                CNameTb.Value = "";
                CGenCb.SelectedIndex = -1;
                PhoneTb.Value = "";
                CDOBTb.Value = DateTime.Now.ToString();
                CAddTb.Value = "";
                CExperTb.Value = "";
                EmailTb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }

        protected void CoachList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CNameTb.Value = CoachList.SelectedRow.Cells[2].Text;
            CGenCb.Text = CoachList.SelectedRow.Cells[3].Text;
            CDOBTb.Value = CoachList.SelectedRow.Cells[4].Text;
            PhoneTb.Value = CoachList.SelectedRow.Cells[5].Text;
            CExperTb.Value = CoachList.SelectedRow.Cells[6].Text;
            CAddTb.Value = CoachList.SelectedRow.Cells[7].Text;
            EmailTb.Value = CoachList.SelectedRow.Cells[8].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = CNameTb.Value;
                string gender = CGenCb.SelectedValue;
                string phone = PhoneTb.Value;
                string DOB = CDOBTb.Value;
                string Address = CAddTb.Value;
                string experience = CExperTb.Value;
                string email = EmailTb.Value;

                int id = int.Parse(CoachList.SelectedRow.Cells[1].Text);
                
                string Query = "update CoachTbl set CName = '{0}', CGen = '{1}', CDOB = '{2}', Cphone = '{3}', CExperience = '{4}', CAddress = '{5}', CEmail = '{6}' where CId = '{7}'";
                
                Query = string.Format(Query, name, gender, DOB, phone, experience, Address, email, id);
                
                Con.setData(Query);
                ShowCoaches();
                SuccMsg.Text = "Coach Edited!!!";
                ErrMsg.Text = "";

                CNameTb.Value = "";
                CGenCb.SelectedIndex = -1;
                PhoneTb.Value = "";
                CDOBTb.Value = DateTime.Now.ToString();
                CAddTb.Value = "";
                CExperTb.Value = "";
                EmailTb.Value = "";
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(CoachList.SelectedRow.Cells[1].Text);

            string Query = "delete from CoachTbl where CId = '{0}' ";
            Query = string.Format(Query, id);
            Con.setData(Query);
            ShowCoaches();
            SuccMsg.Text = "Coach Deleted!!!";
            ErrMsg.Text = "";

            CNameTb.Value = "";
            CGenCb.SelectedIndex = -1;
            PhoneTb.Value = "";
            CDOBTb.Value = DateTime.Now.ToString();
            CAddTb.Value = "";
            CExperTb.Value = "";
            EmailTb.Value = "";
        }
    }
}