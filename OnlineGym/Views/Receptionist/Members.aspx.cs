using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Receptionist
{
    public partial class Members : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("RecCookie");

            if (cookie == null)
            {
                ErrMsg.Text = "Receptionist should Login First...";
                Response.Redirect("../Login.aspx");
                //Server.Transfer("Views/Login.aspx");
            }
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowMembers();
            }
        }
        private void ShowMembers()
        {
            string Query = "select * from MemberTbl";
            MemberList.DataSource = Con.GetData(Query);
            MemberList.DataBind();
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string MemName = MemNameTb.Value;
                string MemGen = MemGenCb.SelectedValue;
                int MemAge = int.Parse(MemAgeTb.Value);
                string MemPhone = MemPhoneTb.Value;
                string MemTiming = MemTimingList.SelectedValue;
                string MemJoin = MemJoinDate.Value;
                string MemPlan = MemShipList.SelectedValue;

                string Query = "insert into MemberTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')";
                Query = string.Format(Query, MemName, MemGen, MemAge, MemPhone, MemTiming, MemJoin, MemPlan);
                Con.setData(Query);
                ShowMembers();
                SuccMsg.Text = "Member Added!!!";
                ErrMsg.Text = "";

                MemNameTb.Value = "";
                MemGenCb.SelectedIndex = -1;
                MemAgeTb.Value = "";
                MemPhoneTb.Value = "";
                MemTimingList.SelectedIndex = -1;
                MemJoinDate.Value = "";
                MemShipList.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }

        protected void MemberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MemNameTb.Value = MemberList.SelectedRow.Cells[2].Text;
            MemGenCb.Text = MemberList.SelectedRow.Cells[3].Text;
            MemAgeTb.Value = MemberList.SelectedRow.Cells[4].Text;
            MemPhoneTb.Value = MemberList.SelectedRow.Cells[5].Text;
            MemTimingList.Text = MemberList.SelectedRow.Cells[6].Text;
            MemJoinDate.Value = MemberList.SelectedRow.Cells[7].Text;
            MemShipList.Text = MemberList.SelectedRow.Cells[8].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string MemName = MemNameTb.Value;
                string MemGen = MemGenCb.SelectedValue;
                int MemAge = int.Parse(MemAgeTb.Value);
                string MemPhone = MemPhoneTb.Value;
                string MemTiming = MemTimingList.SelectedValue;
                string MemJoin = MemJoinDate.Value;
                string MemPlan = MemShipList.SelectedValue;

                int id = int.Parse(MemberList.SelectedRow.Cells[1].Text);

                string Query = "update MemberTbl set MName = '{0}', MGen = '{1}', MAge = '{2}', MPhone = '{3}', MTiming = '{4}', MJoin = '{5}', Mplan = '{6}' where MId = '{7}' ";
                Query = string.Format(Query, MemName, MemGen, MemAge, MemPhone, MemTiming, MemJoin, MemPlan, id);
                Con.setData(Query);
                ShowMembers();
                SuccMsg.Text = "Member Edited!!!";
                ErrMsg.Text = "";

                MemNameTb.Value = "";
                MemGenCb.SelectedIndex = -1;
                MemAgeTb.Value = "";
                MemPhoneTb.Value = "";
                MemTimingList.SelectedIndex = -1;
                MemJoinDate.Value = "";
                MemShipList.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";

            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(MemberList.SelectedRow.Cells[1].Text);

                string Query = "delete from MemberTbl where MId = '{0}' ";
                Query = string.Format(Query, id);
                Con.setData(Query);
                ShowMembers();
                SuccMsg.Text = "Member Deleted!!!";
                ErrMsg.Text = "";

                MemNameTb.Value = "";
                MemGenCb.SelectedIndex = -1;
                MemAgeTb.Value = "";
                MemPhoneTb.Value = "";
                MemTimingList.SelectedIndex = -1;
                MemJoinDate.Value = "";
                MemShipList.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }

        private void searchMem()
        {
            string Query = "select * from MemberTbl where MName like '%{0}%'";
            Query = string.Format(Query, SearchMem.Text);
            MemberList.DataSource = Con.GetData(Query);
            MemberList.DataBind();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {

            searchMem();
        }

        protected void SearchMem_TextChanged(object sender, EventArgs e)
        {
            searchMem();
        }
    }
}