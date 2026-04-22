using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DB_Creatures.Utils;


namespace DB_Creatures
{
  public partial class ShowDBTables : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      GenerateLotsOfItems();
      if (IsPostBack)
      {
        if (Request.Form["delete"]!=null)
        {
          int theItemIdToDelete = int.Parse(Request.Form["delete"].ToString());
          DeleteAnItem(theItemIdToDelete);
        }
        else if (Request.Form["update"]!=null)
        {
          int theItemIdToUpdate = int.Parse(Request.Form["update"].ToString());
          UpdateAnItem(theItemIdToUpdate);
        }
        else if (Request.Form["ItemName"]!=null)
        {
          string itemName = Request.Form["ItemName"].ToString();
          string itemImage = Request.Form["ItemImage"].ToString();
          int posX = int.Parse(Request.Form["PosX"].ToString());
          int posY = int.Parse(Request.Form["PosY"].ToString());
          int power = int.Parse(Request.Form["Power"].ToString());
          InsertAnItem(itemName, itemImage, power, posX, posY);
        }

        //if (!string.IsNullOrEmpty(Request.Form["delete"]))
        //{
        //  int theItemIdToDelete = int.Parse(Request.Form["delete"].ToString());
        //  DeleteAnItem(theItemIdToDelete);
        //}
        //else if (!string.IsNullOrEmpty(Request.Form["update"]))
        //{
        //  int theItemIdToUpdate = int.Parse(Request.Form["update"].ToString());
        //  UpdateAnItem(theItemIdToUpdate);
        //}
        //else if (!string.IsNullOrEmpty(Request.Form["ItemName"]))
        //{
        //  string itemName = Request.Form["ItemName"].ToString();
        //  string itemImage = Request.Form["ItemImage"].ToString();
        //  int posX = int.Parse(Request.Form["PosX"].ToString());
        //  int posY = int.Parse(Request.Form["PosX"].ToString());
        //  int power = int.Parse(Request.Form["Power"].ToString());
        //  InsertAnItem(itemName, itemImage, power, posX, posY);
        //}
      }
      
    }
    public string ShowCreatursDetails()
    {
      string query = "SELECT * FROM Creatures";
      DataTable dt = DatabaseHelper.ExecuteDataTable(query);
      int len = dt.Rows.Count;
      string dataString = "<table style='border: 1px solid black'>";
      for (int i = 0; i < len; i++)
      {
        //Each creature is shown as a <tr>
        dataString += "<tr>";
        dataString += "<td>" + dt.Rows[i]["Id"] + "</td>";
        dataString += "<td>" + dt.Rows[i]["CreatureName"] + "</td>";
        dataString += "<td>" + dt.Rows[i]["Image"] + "</td>";
        dataString += "<td>" + dt.Rows[i]["PosX"] + "</td>";
        dataString += "<td>" + dt.Rows[i]["PosY"] + "</td>";
        dataString += "<td>" + dt.Rows[i]["Power"] + "</td>";

        dataString += "<td><button name='delete' value='" + dt.Rows[i]["Id"] + "'> " + "Delete</button></td>";
        dataString += "<td><button name='update' value='" + dt.Rows[i]["Id"] + "'> " + "Update</button></td>";
        dataString += "</tr>";
      }
      dataString += "</table>";
      return dataString;
    }
    private void DeleteAnItem(int Id)
    {
      string query = "DELETE FROM Creatures WHERE Id = " + Id + "";
      DatabaseHelper.DoQuery(query);
    }
    private void UpdateAnItem(int Id)
    {
      // Example: Will Add 10px to PosX
      // First Get the value of PoxX of specific Id
      string query = "SELECT * FROM Creatures WHERE Id = " + Id + "";
      DataTable dt = DatabaseHelper.ExecuteDataTable(query);
      int posX = int.Parse(dt.Rows[0]["PosX"].ToString());

      // Second lets add 10 to the value
      int newPosX = posX + 10;

      // Third Update the Database
      query = "UPDATE Creatures SET PosX = '" + newPosX + "' WHERE Id = " + Id + "";
      DatabaseHelper.DoQuery(query);
    }
    private void InsertAnItem(string creatureName, string image, int posX, int posY, int power)
    {
      string query = "INSERT INTO Creatures (CreatureName, [Image], PosX, PosY, Power) VALUES ('" + creatureName + "', '" + image + "', '" + posX + "', '" + posY + "', '" + power + "')";
      DatabaseHelper.DoQuery(query);
    }

    private void GenerateLotsOfItems()
    {
      Random rnd = new Random();
      string[] arrImages = { "chicken.png", "cow.png", "sheep.png" };
      for (int i = 0; i < 20; i++)
      {
        int posX = rnd.Next(1,800);
        int posY = rnd.Next(1, 800);
        string creatureName = "Creature " + i;
        string image = arrImages[i%3];
        string query = "INSERT INTO Creatures (CreatureName, [Image], PosX, PosY, Power) VALUES ('" + creatureName + "', '" + image + "', '" + posX + "', '" + posY + "', '" + 100 + "')";
        DatabaseHelper.DoQuery(query);
      }
      
    }
  }
}
