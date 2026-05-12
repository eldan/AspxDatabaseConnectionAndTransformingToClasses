
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace DB_Creatures
{
    public partial class UploadImagePage : System.Web.UI.Page
    {

        public string lblError;
        public string lblMessage;



        protected void Page_Load(object sender, EventArgs e)
        {
            form1.Enctype = "multipart/form-data";

            lblMessage = "";
            lblError = "";

            if (IsPostBack)
            {
                try
                {
                    HttpPostedFile uploadedFile =  Request.Files.Count > 0 ? Request.Files[0] : null;

                    if (uploadedFile == null ||
                        uploadedFile.ContentLength == 0)
                    {
                        lblError =
                            "Please select a file to upload.";
                        return;
                    }

                    string fileName =
                        Path.GetFileName(uploadedFile.FileName);

                    string fileExtension =
                        Path.GetExtension(fileName).ToLower();

                    if (fileExtension != ".jpg" &&
                        fileExtension != ".jpeg" &&
                        fileExtension != ".png")
                    {
                        lblError =
                            "Only JPG and PNG formats are allowed.";
                        return;
                    }

                    int maxFileSize = 524288000;

                    if (uploadedFile.ContentLength > maxFileSize)
                    {
                        lblError =
                            "File size must be under 500 MB.";
                        return;
                    }

                    string uniqueFileName =
                        GenerateUniqueFileName(fileExtension);

                    string imagesFolderPath =
                        Server.MapPath("~/uploadedImages/");

                    if (!Directory.Exists(imagesFolderPath))
                    {
                        Directory.CreateDirectory(imagesFolderPath);
                    }

                    string filePath =
                        Path.Combine(imagesFolderPath,
                        uniqueFileName);

                    uploadedFile.SaveAs(filePath);

                    lblMessage =
                        "File uploaded successfully!<br/>Unique filename: "
                        + uniqueFileName;
                }
                catch (Exception ex)
                {
                    lblError =
                        "Error uploading file: " + ex.Message;
                }
            }
        }

        private string GenerateUniqueFileName(string extension)
        {
            string guid = Guid.NewGuid().ToString("N");
            string timestamp =
                DateTime.Now.ToString("yyyyMMddHHmmss");

            return $"specialimage_{timestamp}_{guid}{extension}";
        }

    }

}
           
