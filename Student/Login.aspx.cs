using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student
{
    public partial class Login : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cid = obj.Fn_Scalar("select count(Id) from USERS where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'");

            if (cid == "1")
            {
                Response.Redirect("Userhome.aspx");
            }
            else
            {
                Label1.Text = "Invalid Credentials";
            }
        }
    }
}