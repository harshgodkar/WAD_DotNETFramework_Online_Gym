using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineGym.Views.Receptionist
{
    public partial class Payment : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("RecCookie");

            if (cookie == null)
            {
                ErrMsg.Text = "Receptionist should Login First...";
                Response.Redirect("../Login.aspx");
                
            }
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowPaymentsDetails();
                GetMembers();
                

                int item = int.Parse(MemberCb.SelectedValue);
                GetPlan(item);

            }
        }
        private void ShowPaymentsDetails()
        {
            string Query = "select * from PaymentTbl";
            PaymentList.DataSource = Con.GetData(Query);
            PaymentList.DataBind();
        }

        private void GetMembers()
        {
            string Query = "Select * from MemberTbl";
            MemberCb.DataTextField = Con.GetData(Query).Columns["MName"].ToString();
            MemberCb.DataValueField = Con.GetData(Query).Columns["MId"].ToString();
            MemberCb.DataSource = Con.GetData(Query);
            MemberCb.DataBind();
        }
        private void GetPlan(int i)
        {
            
                string Query = "select * from MemberTbl where MId = '{0}'";
                Query = string.Format(Query, i);
                PayPlanListIp.DataTextField = Con.GetData(Query).Columns["Mplan"].ToString();
                PayPlanListIp.DataSource = Con.GetData(Query);
                PayPlanListIp.DataBind();
        
        }
            
        protected void MemberCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int item = int.Parse(MemberCb.SelectedValue);
            GetPlan(item);
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int MemId = int.Parse(MemberCb.SelectedValue);
                
                string Queryt = "select MName, Mplan from MemberTbl where MId='{0}'";
                Queryt = string.Format(Queryt, MemId);
                DataTable dt = Con.GetData(Queryt);
                string month = dt.Rows[0][1].ToString();
                string MemName = dt.Rows[0][0].ToString();

                //string month = PayPlanListIp.SelectedValue;
                string pdate = Paydate.Value;
                int amt = int.Parse(PayAmt.Value);
                string agent = Login.AgentId;


                string Query = "insert into PaymentTbl values('{0}', '{1}', {2}, '{3}', '{4}', '{5}')";
                Query = string.Format(Query, month, MemName, MemId, amt, pdate, agent);
                Con.setData(Query);
                ShowPaymentsDetails();
                SuccMsg.Text = "Payment Added!!!";
                ErrMsg.Text = "";

                MemberCb.SelectedIndex = -1;
                PayPlanListIp.SelectedIndex = -1;
                Paydate.Value = "";
                PayAmt.Value = "";
                //string agent = Login.AgentId;

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }
    }
}