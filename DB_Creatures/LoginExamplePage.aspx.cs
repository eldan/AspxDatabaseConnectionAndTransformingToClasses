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

      string inputUserName = "eldan";
      string inputUserPassword= "123";
      string query = $"SELECT * FROM Users WHERE UserName = '{inputUserName}' AND UserPassword = '{inputUserPassword}'";
      DataTable dt = DatabaseHelper.ExecuteDataTable(query);
      int len = dt.Rows.Count;
      if (len > 0)
      {
        string fullName = dt.Rows[0]["UserFName"].ToString();
        fullName = char.ToUpper(fullName[0]) + fullName.Substring(1);
        resultOfConnection = "Authentication OK: <b>"+ fullName+"</b>";
      } else
      {
        resultOfConnection = "Authentication Failed";
      }

    }
	}
}
