using DB_Creatures.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace DB_Creatures
{
  public partial class Game : System.Web.UI.Page
  {
    Creature[] creatures;

    protected void Page_Load(object sender, EventArgs e)
    {
      string query = "SELECT * FROM Creatures";
      if (IsPostBack)
      {
        if (Request.Form["filter"].ToString() == "cowandchicken")
        {
          query = "SELECT * FROM Creatures WHERE Image = 'cow.png' OR Image = 'chicken.png'";
        }
        else if (Request.Form["filter"].ToString() == "chicken")
        {
          query = "SELECT * FROM Creatures WHERE Image = 'chicken.png'";
        }
        else if (Request.Form["filter"].ToString() == "sheep")
        {
          query = "SELECT * FROM Creatures WHERE Image = 'sheep.png'";
        }
      }
      DataTable dt = DatabaseHelper.ExecuteDataTable(query);
      int len = dt.Rows.Count;
      creatures = new Creature[len];
      for (int i = 0; i < len; i++)
      {
        string name = dt.Rows[i]["CreatureName"].ToString();
        string image = dt.Rows[i]["Image"].ToString();
        int power = int.Parse(dt.Rows[i]["Power"].ToString());
        int posX = int.Parse(dt.Rows[i]["PosX"].ToString());
        int posY = int.Parse(dt.Rows[i]["PosY"].ToString());
        creatures[i] = new Creature(name, image, power, posX, posY);
      }
    }

    public string DrawAllCreatures()
    {
      string str = "";
      for (int i = 0; i < creatures.Length; i++)
      {
        str += creatures[i].GetHtml();
      }
      return str;
    }
  }
}
