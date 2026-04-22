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
  public partial class RegisterExamplePage : System.Web.UI.Page
  {
    public string msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {

      string emailToAdd = "fakeuser4@gmail.com";
      string userPasswordToAdd = "123456";
      string pNameToAdd = "Oy";
      string fNameToAdd = "Vey";
      string fakeAddress = "Fake Street 123, Natanya Neve Fake";

      // in real life, check that essensial fields are not empty, and that the email is in a valid format, and that the password is strong enough, etc.
      // example check that password is 4 char and above
      if (userPasswordToAdd.Length < 4)
      {
        msg = "Too short!!!";
      }
      // check that email is not occupied by another user
      string checkEmailQuery = $"SELECT * FROM Users WHERE Email = '{emailToAdd}'";
      DataTable dt = DatabaseHelper.ExecuteDataTable(checkEmailQuery);

      if (dt.Rows.Count > 0)
      {
        msg = "Email is already occupied.";
        return;
      }

      string query = $"INSERT INTO Users (Email, UserPassword, PName, FName, Address) " +
                     $"VALUES ('{emailToAdd}', '{userPasswordToAdd}', '{pNameToAdd}', '{fNameToAdd}', '{fakeAddress}')";

      int rowsAffected = DatabaseHelper.DoQuery(query);

      if (rowsAffected > 0)
      {
        msg = "User registered successfully.";
      }
      else
      {
        msg = "Failed to register user";
      }
    }
  }
}
