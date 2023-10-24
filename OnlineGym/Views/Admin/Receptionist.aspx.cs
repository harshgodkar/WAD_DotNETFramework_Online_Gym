using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Admin
{
    public partial class Receptionist : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("AuthCookie");

            if (cookie == null)
            {
                ErrMsg.Text = "Admin should Login First...";
                Response.Redirect("../Login.aspx");
                //Server.Transfer("Views/Login.aspx");
            }
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowReceptionists();
            }
        }

        private void ShowReceptionists()
        {
            string Query = "select * from ReceptionistTbl";
            ReceptionistList.DataSource = Con.GetData(Query);
            ReceptionistList.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = RecNameTb.Value;
                string gender = RecGenCb.SelectedValue;
                string phone = RecPhoneTb.Value;
                string DOB = RecDOBTb.Value;
                string Address = RecAddTb.Value;
                string email = RecEmailTb.Value;
                string pass = RecPasswordtb.Value;

                string Query = "insert into ReceptionistTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
                Query = string.Format(Query, name, gender, DOB, Address, phone, email, pass);
                Con.setData(Query);
                ShowReceptionists();
                SuccMsg.Text = "Receptionist Added!!!";
                ErrMsg.Text = "";

                RecNameTb.Value = "";
                RecGenCb.SelectedIndex = -1;
                RecPhoneTb.Value = "";
                RecDOBTb.Value = DateTime.Now.ToString();
                RecAddTb.Value = "";
                RecEmailTb.Value = "";
                RecPasswordtb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = RecNameTb.Value;
                string gender = RecGenCb.SelectedValue;
                string phone = RecPhoneTb.Value;
                string DOB = RecDOBTb.Value;
                string Address = RecAddTb.Value;
                string email = RecEmailTb.Value;
                string pass = RecPasswordtb.Value;

                int id = int.Parse(ReceptionistList.SelectedRow.Cells[1].Text);

                string Query = "update ReceptionistTbl set RecepName = '{0}', RecepGen = '{1}', RecepDOB = '{2}', RecepAdd = '{3}', RecepPhone = '{4}', RecepEmail = '{5}', RecepPass = '{6}' where RecepId = '{7}'";
                Query = string.Format(Query, name, gender, DOB, Address, phone, email, pass, id);
                Con.setData(Query);
                ShowReceptionists();
                SuccMsg.Text = "Receptionist Updated!!!";
                ErrMsg.Text = "";

                RecNameTb.Value = "";
                RecGenCb.SelectedIndex = -1;
                RecPhoneTb.Value = "";
                RecDOBTb.Value = DateTime.Now.ToString();
                RecAddTb.Value = "";
                RecEmailTb.Value = "";
                RecPasswordtb.Value = "";

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }

        protected void ReceptionistList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecNameTb.Value = ReceptionistList.SelectedRow.Cells[2].Text;
            RecGenCb.Text = ReceptionistList.SelectedRow.Cells[3].Text;
            RecDOBTb.Value = ReceptionistList.SelectedRow.Cells[4].Text;
            RecAddTb.Value = ReceptionistList.SelectedRow.Cells[5].Text;
            RecPhoneTb.Value = ReceptionistList.SelectedRow.Cells[6].Text;
            RecEmailTb.Value = ReceptionistList.SelectedRow.Cells[7].Text;
            RecPasswordtb.Value = ReceptionistList.SelectedRow.Cells[8].Text;
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ReceptionistList.SelectedRow.Cells[1].Text);

            string Query = "delete from ReceptionistTbl where RecepId = '{0}' ";
            Query = string.Format(Query, id);
            Con.setData(Query);
            ShowReceptionists();
            SuccMsg.Text = "Receptionist Deleted!!!";
            ErrMsg.Text = "";

            RecNameTb.Value = "";
            RecGenCb.SelectedIndex = -1;
            RecPhoneTb.Value = "";
            RecDOBTb.Value = DateTime.Now.ToString();
            RecAddTb.Value = "";
            RecEmailTb.Value = "";
            RecPasswordtb.Value = "";
        }
    }
}