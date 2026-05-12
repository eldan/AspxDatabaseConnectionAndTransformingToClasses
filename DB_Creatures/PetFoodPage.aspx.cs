using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Creatures
{
    public partial class PetFoodPage : System.Web.UI.Page
    {
        public string tableData;
        protected void Page_Load(object sender, EventArgs e)
        {
           
           // string query = "SELECT * FROM PetFood ";
            string query = "SELECT * FROM PetFood WHERE Animal = 'Cat'";
            DataTable dt = Utils.DBHelper.ExecuteDataTable(query);
            int len = dt.Rows.Count;
            string dataString = "";
            for (int i = 0; i < len; i++)
            {
                //Each creature is shown as a <tr>
                dataString += "<tr>";
                dataString += $"<td><img style='height:50px' src='./PetFoodImages/{dt.Rows[i]["FoodImage"]}'/></td>";
                dataString += $"<td>{dt.Rows[i]["FoodName"]}</td>";
                dataString += $"<td>{dt.Rows[i]["Price"]}</td>";
                dataString += $"<td>{dt.Rows[i]["NumInStock"]}</td>";
                dataString += $"<td>{dt.Rows[i]["Animal"]}</td>";
                dataString += $"<td>{dt.Rows[i]["Company"]}</td>";
                dataString += "</tr>";
            }
            tableData = dataString;
        }
  
    }
}