using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> mySession = (List<string>)Session["SelectedRow"];

            Label1.Text = mySession[0];
            Label2.Text = mySession[1];
            Label3.Text = mySession[2];
            Label4.Text = mySession[3];
            Label5.Text = mySession[4];
            Label6.Text = mySession[5];
            Label7.Text = mySession[6];
        }
    }
}