using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL_SITE;
using REF_SITE;
using System.Data;

namespace Appointment
{
    public partial class AppointmentForm : System.Web.UI.Page
    {
        public string _str;
        public static int _temp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["ap_id"]))
                {
                    LoadRow(Request.QueryString["ap_id"]);
                }

                if (!String.IsNullOrEmpty(Request.QueryString["dlt_ap_id"]))
                {
                    Delete_App(Request.QueryString["dlt_ap_id"]);
                }

                LoadTable();
                GetAppToDropdwn();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                REF_Client oREF_Client = new REF_Client();

                oREF_Client.APPOINTMENT_ID = _temp;
                oREF_Client.APPOINTMENT_NAME =TextBox1.Text;
                oREF_Client.PARENT = DropDownList1.SelectedItem.Text;
                oREF_Client.LIMIT_MONTH = Convert.ToInt32(TextBox2.Text);
                oREF_Client.LIMIT_YEAR = Convert.ToInt32(TextBox2.Text);
                oREF_Client.STATUS = 1;
                oREF_Client.CREATED_BY = 1;
                oREF_Client.CREATED_DATE = DateTime.Now.ToString();
                oREF_Client.MODIFIED_BY = 1;
                oREF_Client.MODIFIED_DATE = DateTime.Now.ToString();

                Label5.Text = Convert.ToString(oREF_Client.APPOINTMENT_ID);

                BL_Client oBL_Client = new BL_Client();

                oBL_Client.Insert(oREF_Client, null);

                //saved
                LoadTable();
                GetAppToDropdwn();
                Clear();
            }
            catch (Exception ex)
            {
                //pls try again
                Label5.Text = ex.Message.ToString();
            }
        }

        protected void LoadTable()
        {
            BL_Client oBL_Client = new BL_Client();
            DataTable dt = oBL_Client.Select(null);

            try
            {
                //display table
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        _str = _str + "<tr>" +
                           "<td>" + dt.Rows[i]["APPOINTMENT_ID"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["APPOINTMENT_NAME"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["PARENT"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["LIMIT_MONTH"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["LIMIT_YEAR"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["STATUS"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["CREATED_BY"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["CREATED_DATE"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["MODIFIED_BY"].ToString() + "</td>" +
                           "<td>" + dt.Rows[i]["MODIFIED_DATE"].ToString() + "</td>" +
                           "<td><a href='AppointmentForm.aspx?ap_id=" + dt.Rows[i]["APPOINTMENT_ID"].ToString() + "'>edit</a></td>" +
                           "<td><a href='AppointmentForm.aspx?dlt_ap_id=" + dt.Rows[i]["APPOINTMENT_ID"].ToString() + "'>delete</a></td>" +
                           "</tr>";
                    }
                }
            }
            catch (Exception ex)
            {
                Label5.Text = ex.Message.ToString();
            }
        }

        protected void GetAppToDropdwn()
        {
            BL_Client oBL_Client = new BL_Client();
            DataTable dt = oBL_Client.SelectAppToDrop(null);

            try
            {
                if (dt.Rows.Count != 0)
                {
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "APPOINTMENT_NAME";
                    DropDownList1.DataValueField = "APPOINTMENT_ID";
                    DropDownList1.DataBind();
                }

            }
            catch (Exception ex)
            {
                //pls try again
                Label1.Text = ex.Message.ToString();
            }
        }

        protected void LoadRow(string _ap_id)
        {
            BL_Client oBL_Client = new BL_Client();
            DataTable dt = oBL_Client.SelectOne(_ap_id, null);

            Button1.Text = "Update";

            try
            {
                //display table
                if (dt.Rows.Count > 0)
                {
                    _temp = Convert.ToInt32(dt.Rows[0]["APPOINTMENT_ID"]);
                    TextBox1.Text = dt.Rows[0]["APPOINTMENT_NAME"].ToString();
                    DropDownList1.SelectedItem.Text = dt.Rows[0]["PARENT"].ToString();
                    TextBox2.Text = dt.Rows[0]["LIMIT_MONTH"].ToString();
                    TextBox3.Text = dt.Rows[0]["LIMIT_YEAR"].ToString();
                }

            }
            catch (Exception ex)
            {
                Label5.Text = ex.Message.ToString();
            }
        }

        protected void Delete_App(string _dlt_ap_id)
        {
            BL_Client oBL_Client = new BL_Client();

            try
            {
                oBL_Client.DeleteOne(_dlt_ap_id, null);
            }
            catch (Exception ex)
            {
                Label5.Text = ex.Message.ToString();
            }
        }

        protected void Clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Button1.Text = "Insert";
            _temp = 0;
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            Clear();
            LoadTable();
            GetAppToDropdwn();
        }
    }
}