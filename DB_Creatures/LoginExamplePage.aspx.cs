using DB_Creatures.Utils;
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

      string inputUserName = "info@eldanet.com";
      string inputUserPassword= "123456";
      string query = $"SELECT PName, FName, Address FROM Users WHERE Email = '{inputUserName}' AND UserPassword = '{inputUserPassword}'";
      DataTable dt = DatabaseHelper.ExecuteDataTable(query);
      int len = dt.Rows.Count;
      if (len > 0)
      {
        string fullName = dt.Rows[0]["PName"].ToString()+" "+ dt.Rows[0]["FName"].ToString();
        string address = dt.Rows[0]["Address"].ToString();
        fullName = char.ToUpper(fullName[0]) + fullName.Substring(1);
        resultOfConnection = "Authentication OK: <b>"+ fullName+" </b> from "+ address;
      } else
      {
        resultOfConnection = "Authentication Failed";
      }

    }
	}
}
