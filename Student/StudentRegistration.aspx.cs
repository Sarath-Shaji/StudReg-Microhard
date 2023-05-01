using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student
{
    public partial class StudentRegistration : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            int i = obj.Fn_Nonquery("insert into Stud_Details(Stud_Code,Stud_Name,Address,Email,Mobile_Number,Join_date) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')");
            if (i != 0)
            {
                Label1.Text = "Inserted";
            }
        }
    }
}