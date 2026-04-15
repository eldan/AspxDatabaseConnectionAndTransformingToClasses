using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


namespace DB_Creatures.Utils
{
  public class DatabaseHelper
  {
    public static SqlConnection ConnectToDb()
    {
      string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\WEB\\DB_Creatures_03_msql\\DB_Creatures\\App_Data\\db_creature.mdf;Integrated Security=True";

      SqlConnection conn = new SqlConnection(connString);
      return conn;
    }

    public static void DoQuery(string sql)
    {
      SqlConnection conn = ConnectToDb();
      conn.Open();

      SqlCommand com = new SqlCommand(sql, conn);
      com.ExecuteNonQuery();
      conn.Close();
    }

    public static bool IsExist(string sql)
    {

      SqlConnection conn = ConnectToDb();
      conn.Open();
      SqlCommand com = new SqlCommand(sql, conn);
      SqlDataReader data = com.ExecuteReader();

      bool found = Convert.ToBoolean(data.Read());
      conn.Close();
      return found;
    }

    public static DataTable ExecuteDataTable(string sql)
    {
      SqlConnection conn = ConnectToDb();
      conn.Open();

      DataTable dt = new DataTable();

      SqlDataAdapter tableAdapter = new SqlDataAdapter(sql, conn);

      tableAdapter.Fill(dt);
      conn.Close();

      return dt;
    }

  }
}

