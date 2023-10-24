using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace OnlineGym.Views.Admin
{
    public partial class Equipments : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies.Get("AuthCookie");

            if (cookie == null)
            {
                ErrMsg.Text = "Admin should Login First...";
                Response.Redirect("../Login.aspx");
            }
            Con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowEquipments();
            }
        }

        private void ShowEquipments()
        {
            string Query = "select * from EquipmentTbl";
            EquipList.DataSource = Con.GetData(Query);
            EquipList.DataBind();
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = EquNameTb.Value;
                string desc = EquDescTb.Value;
                string use = EquTb.Value;
                string deldate = EquDelDate.Value;
                int cost = int.Parse(EquCost.Value);

                string Query = "insert into EquipmentTbl values('{0}', '{1}', '{2}', '{3}', '{4}')";
                Query = string.Format(Query, name, desc, use, deldate, cost);
                Con.setData(Query);
                ShowEquipments();
                SuccMsg.Text = "Equipment Added!!!";
                ErrMsg.Text = "";

                EquNameTb.Value = "";
                EquDescTb.Value = "";
                EquDelDate.Value = DateTime.Now.ToString();
                EquTb.Value = "";
                EquCost.Value = "0";

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
                string name = EquNameTb.Value;
                string desc = EquDescTb.Value;
                string use = EquTb.Value;
                string deldate = EquDelDate.Value;
                int cost = int.Parse(EquCost.Value);

                int id = int.Parse(EquipList.SelectedRow.Cells[1].Text);

                string Query = "update EquipmentTbl set EquipName = '{0}', EquipDesc = '{1}', EquipUse = '{2}', DeliveryDate = '{3}', EquipCost = '{4}' where EquipId = '{5}'";
                Query = string.Format(Query, name, desc, use, deldate, cost, id);
                Con.setData(Query);
                ShowEquipments();
                SuccMsg.Text = "Equipment Updated!!!";
                ErrMsg.Text = "";

                EquNameTb.Value = "";
                EquDescTb.Value = "";
                EquDelDate.Value = DateTime.Now.ToString();
                EquTb.Value = "";
                EquCost.Value = "0";

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
                SuccMsg.Text = "";
            }
        }

        protected void EquipList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EquNameTb.Value = EquipList.SelectedRow.Cells[2].Text;
            EquDescTb.Value = EquipList.SelectedRow.Cells[3].Text;
            EquDelDate.Value = EquipList.SelectedRow.Cells[5].Text;
            EquTb.Value = EquipList.SelectedRow.Cells[4].Text;
            EquCost.Value = EquipList.SelectedRow.Cells[6].Text;
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(EquipList.SelectedRow.Cells[1].Text);

            string Query = "delete from EquipmentTbl where EquipId = '{0}' ";

            Query = string.Format(Query, id);
            Con.setData(Query);
            ShowEquipments();
            SuccMsg.Text = "Equipment Deleted!!!";
            ErrMsg.Text = "";

            EquNameTb.Value = "";
            EquDescTb.Value = "";
            EquDelDate.Value = DateTime.Now.ToString();
            EquTb.Value = "";
            EquCost.Value = "0";
        }
    }
}