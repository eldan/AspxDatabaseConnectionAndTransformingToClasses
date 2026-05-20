using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DB_Creatures
{
    public partial class AdminPage : System.Web.UI.Page
    {
        public string tableData;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Fixed: Proper null check for session
            if (Session["isLogin"] == null || Session["isAdmin"] == null ||
                Session["isLogin"].ToString() != "true" || Session["isAdmin"].ToString() != "true")
            {
                Response.Redirect("LoginExamplePage.aspx");
                return;
            }
            else
            {
                if (IsPostBack)
                {
                    if (Request.Form["delete"] != null)
                    {
                        int theItemIdToDelete = int.Parse(Request.Form["delete"].ToString());
                        DeleteAnItem(theItemIdToDelete);
                    }
                    else if (Request.Form["update"] != null)
                    {
                        int theItemIdToUpdate = int.Parse(Request.Form["update"].ToString());
                        UpdateAnItem(theItemIdToUpdate);
                    }
                    else
                    {
                        string foodImage = UploadimageAndReturnFileName();
                        string foodName = Request.Form["FoodName"].ToString();
                        int price = int.Parse(Request.Form["Price"].ToString());
                        int numInStock = int.Parse(Request.Form["NumInStock"].ToString());
                        string animal = Request.Form["Animal"].ToString();
                        string company = Request.Form["Company"].ToString();

                        InsertAnItem(foodName, foodImage, price, numInStock, animal, company);
                    }
                }
                string query = "SELECT * FROM PetFood ";
                // string query = "SELECT * FROM PetFood WHERE Animal = 'Cat'";
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
                    dataString += $"<td><button name='delete' value='{dt.Rows[i]["Id"]}'>" + "Delete</button></td>";
                    dataString += $"<td><button name='update' value='{dt.Rows[i]["Id"]}'>" + "Update</button></td>";
                    dataString += "</tr>";
                }
                tableData = dataString;
            }


        }

        private void DeleteAnItem(int Id)
        {
            string query = $"DELETE FROM PetFood WHERE Id = {Id}";
            Utils.DBHelper.DoQuery(query);
        }
        private void UpdateAnItem(int Id)
        {
            string query = $"SELECT NumInStock FROM PetFood WHERE Id = {Id}";
            DataTable dt = Utils.DBHelper.ExecuteDataTable(query);
            int numInStock = int.Parse(dt.Rows[0]["NumInStock"].ToString());

            if (numInStock > 0) numInStock--;

            // Third Update the Database
            query = $"UPDATE PetFood SET NumInStock = '{numInStock}' WHERE Id = {Id}";
            Utils.DBHelper.ExecuteDataTable(query);
        }
        private void InsertAnItem(string foodName, string foodImage, int price, int numInStock, string animal, string company)
        {

            string query = $"INSERT INTO PetFood (FoodName, FoodImage, Price, NumInStock, Animal, Company) VALUES ('{foodName}', '{foodImage}', {price}, {numInStock}, '{animal}', '{company}')";
            Utils.DBHelper.DoQuery(query);
        }



        protected string UploadimageAndReturnFileName()
        {
            string lblError = "";
            string lblMessage = "";
            form1.Enctype = "multipart/form-data";

            try
            {
                HttpPostedFile uploadedFile = Request.Files.Count > 0 ? Request.Files[0] : null;

                if (uploadedFile == null ||
                    uploadedFile.ContentLength == 0)
                {
                    lblError = "Please select a file to upload.";

                }

                string fileName = Path.GetFileName(uploadedFile.FileName);

                string fileExtension = Path.GetExtension(fileName).ToLower();

                if (fileExtension != ".jpg" &&
                    fileExtension != ".jpeg" &&
                    fileExtension != ".png")
                {
                    lblError =
                        "Only JPG and PNG formats are allowed.";

                }

                int maxFileSize = 524288000;

                if (uploadedFile.ContentLength > maxFileSize)
                {
                    lblError = "File size must be under 500 MB.";

                }

                string uniqueFileName = GenerateUniqueFileName(fileExtension);

                string imagesFolderPath = Server.MapPath("~/PetFoodImages/");

                if (!Directory.Exists(imagesFolderPath))
                {
                    Directory.CreateDirectory(imagesFolderPath);
                }

                string filePath =
                    Path.Combine(imagesFolderPath, uniqueFileName);

                uploadedFile.SaveAs(filePath);

                lblMessage =
                    "File uploaded successfully!<br/>Unique filename: "
                    + uniqueFileName;
                return uniqueFileName;
            }
            catch (Exception ex)
            {
                lblError =
                    "Error uploading file: " + ex.Message;
                return null;
            }

        }

        private string GenerateUniqueFileName(string extension)
        {
            string guid = Guid.NewGuid().ToString("N");
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            return $"tomthecat_{timestamp}_{guid}{extension}";
        }
    }
}