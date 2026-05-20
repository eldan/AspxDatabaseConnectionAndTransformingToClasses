using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Creatures
{
    public partial class SpecificProductPage : System.Web.UI.Page
    {
        public string imageProduct;
        public string productName;
        public string price;
        public string numInStock;
        public string animal;
        public string company;
        public string msg;
        protected void Page_Load(object sender, EventArgs e)
        {
            string productIdValue = Request.QueryString["ProductId"];
            string query = $"SELECT * FROM PetFood Where Id={productIdValue}";
            DataTable dt = Utils.DBHelper.ExecuteDataTable(query);
            if (dt.Rows.Count >0)
            {
                imageProduct = dt.Rows[0]["FoodImage"].ToString();
                productName = dt.Rows[0]["FoodName"].ToString();
                price = dt.Rows[0]["Price"].ToString();
                numInStock = dt.Rows[0]["NumInStock"].ToString();
                animal = dt.Rows[0]["Animal"].ToString();
                company = dt.Rows[0]["Company"].ToString();
            }
            else
            {
                msg = "ERRR Not found"; 
            }
            

        }
    }
}