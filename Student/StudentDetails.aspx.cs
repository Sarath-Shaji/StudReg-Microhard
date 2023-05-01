using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Student
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        ConCls obj = new ConCls();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid_Bind();
            }



        }

        public void Grid_Bind()
        {
            string sel = "select * from Stud_Details";
            DataSet ds = obj.Fn_Dataset(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }



        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int usrid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from Stud_Details where Stud_id=" + usrid + "";
            int a = obj.Fn_Nonquery(del);

            Grid_Bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Grid_Bind();
        }

       
    

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
             GridView1.EditIndex = -1;
             Grid_Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
        int i = e.RowIndex;
        int usrid = Convert.ToInt32(GridView1.DataKeys[i].Value);

        TextBox txtcode = (TextBox)GridView1.Rows[i].Cells[1].Controls[0];
        TextBox txtname = (TextBox)GridView1.Rows[i].Cells[2].Controls[0];
        TextBox txtaddr = (TextBox)GridView1.Rows[i].Cells[3].Controls[0];
        TextBox txtmail = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
        TextBox txtphone = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];

        string upd = "update Stud_Details set Stud_code='" + txtcode.Text + "' ,Stud_Name='" + txtname.Text + "',Address='" + txtaddr.Text + "',Email='" + txtmail.Text + "',Mobile_Number=" + txtphone.Text + " where Stud_Id=" + usrid + "";
        int b = obj.Fn_Nonquery(upd);

        GridView1.EditIndex = -1;
        Grid_Bind();
    }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = GridView1.Rows[index];

                string id = row.Cells[0].Text;
                string code = row.Cells[1].Text;
                string name = row.Cells[2].Text;
                string address = row.Cells[3].Text;
                string email = row.Cells[4].Text;
                string phone = row.Cells[5].Text;
                string joindate = row.Cells[6].Text;


                Session["SelectedRow"] = new List<string> { id, code, name, address, email, phone, joindate };

                Response.Redirect("Print.aspx");
            }
        }
    }
}