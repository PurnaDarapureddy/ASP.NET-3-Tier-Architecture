using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bo;
using bll;
using System.Data;

namespace practiceExam2
{
    
    public partial class pl : System.Web.UI.Page
    {
        bll.user bu = new bll.user();
        bo.user bo = new bo.user();
        void getdata()
        {
            DataSet ds = bu.GetData();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        void getstate()
        {
            DataSet ds = bu.getstate();
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "sname";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "--select--");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList2.Items.Insert(0, "--select--");
                getstate();
                getdata();
            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bo.state = DropDownList1.SelectedItem.Text;
            DataSet ds = bu.getcity(bo.state);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "cname";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "--select--");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bo.uid = Convert.ToInt32(TextBox1.Text);
            bo.uname = TextBox2.Text;
            bo.password = TextBox3.Text;
            string g = "";
            if (RadioButton1.Checked == true)
                g = RadioButton1.Text;
            else
                g = RadioButton2.Text;
            bo.gender = g;
            string h = "";
            if (CheckBox1.Checked == true)
                h = CheckBox1.Text;
            if (CheckBox2.Checked == true)
                h = h + " " + CheckBox2.Text;
            if (CheckBox3.Checked == true)
                h = h + " " + CheckBox3.Text;
            bo.hobbies = h;
            bo.state = DropDownList1.SelectedItem.Text;
            bo.city = DropDownList2.SelectedItem.Text;
            bo.phno = long.Parse( TextBox5.Text);
            bo.email = TextBox6.Text;
            bo.address = TextBox7.Text;
            int i;
            if (Button1.Text == "Insert")
            { i = bu.adduser(bo); }
            else
            { i = bu.Update(bo); }
            if (i != 0)
               getdata();
            Button1.Text = "Insert";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            Label l1 = (Label)row.FindControl("Label1");
            Label l2 = (Label)row.FindControl("Label2");
            Label l3 = (Label)row.FindControl("Label3");
            Label l4 = (Label)row.FindControl("Label4");
            Label l5 = (Label)row.FindControl("Label5");
            Label l6 = (Label)row.FindControl("Label6");
            Label l7 = (Label)row.FindControl("Label7");
            Label l8 = (Label)row.FindControl("Label8");
            Label l9 = (Label)row.FindControl("Label9");
            Label l10 = (Label)row.FindControl("Label10");

            if (e.CommandName=="iDelete")
            { 
                bo.uid = int.Parse(l1.Text);
                int i = bu.Delete(bo);
                if(i!=0)
                {
                    getdata();
                }
            }
            else
            {
                TextBox1.Text = l1.Text;
                TextBox2.Text = l2.Text;
                TextBox3.Text = l3.Text;
                if (RadioButton1.Text == l4.Text)
                    RadioButton1.Checked = true;
               else if (RadioButton2.Text == l4.Text)
                        RadioButton2.Checked = true;
                string[] s = l5.Text.Split();
                foreach(string i in s)
                {
                    if (i == CheckBox1.Text)
                        CheckBox1.Checked = true;
                    else if (i == CheckBox2.Text)
                        CheckBox2.Checked = true;
                    else if (i == CheckBox3.Text)
                        CheckBox3.Checked = true;
                }
                DropDownList1.SelectedItem.Text = l6.Text;
                DropDownList2.SelectedItem.Text = l7.Text;
                TextBox5.Text = l8.Text;
                TextBox6.Text = l9.Text;
                TextBox7.Text = l10.Text;
                Button1.Text = "update";
            }
        }
    }
}