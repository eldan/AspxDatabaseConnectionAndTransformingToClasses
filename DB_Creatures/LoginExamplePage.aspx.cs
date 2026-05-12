
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace DB_Creatures
{
    public partial class LoginExample : System.Web.UI.Page
    {
        public string resultOfConnection = "Not Yet Connected";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (true)
            {
                string inputUserName = "info@eldanet.com";
                string inputUserPassword = "123456";
                string query = $"SELECT PName, FName, Address, Role FROM Users WHERE Email = '{inputUserName}' AND UserPassword = '{inputUserPassword}'";
                DataTable dt = Utils.DBHelper.ExecuteDataTable(query);
                int len = dt.Rows.Count;
                if (len > 0)
                {
                    string fullName = dt.Rows[0]["PName"].ToString() + " " + dt.Rows[0]["FName"].ToString();
                    string address = dt.Rows[0]["Address"].ToString();
                    Session["isLogin"] = "true";
                    int userRole = int.Parse(dt.Rows[0]["Role"].ToString());
                    if (userRole == 0)
                    {
                        Session["isAdmin"] = "true";
                        Response.Redirect("AdminPage.aspx");
                    }



                    resultOfConnection = "Authentication OK: <b>" + fullName + " </b> from " + address;
                }
                else
                {
                    resultOfConnection = "Authentication Failed";
                }
            }
            
        }
    }
}
