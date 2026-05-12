<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImagePage.aspx.cs" Inherits="DB_Creatures.UploadImagePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">       
    <title>Upload Image</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Upload Image</h2>
            <input type="file"  name="fileUploadControl" accept=".jpg,.jpeg,.png" runat="server" />
            <br /><br />
            <button type="submit">Upload</button>
            <br /><br />
            <div style="color: green;"><%=lblMessage %></div>
            <div style="color: red;"><%=lblError %></div>

        </div>
    </form>
</body>
</html>