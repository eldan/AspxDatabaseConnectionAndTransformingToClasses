<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="DB_Creatures.AdminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Welcome Admin</h1>
        <table style="width: 100%">
            <%=tableData %>
        </table>
        <hr />
        <div>
            <input name="FoodName" placeholder="FoodName" />
            <input type="file"  name="FoodImage" accept=".jpg,.jpeg,.png" runat="server" />
            <input type="number" name="Price" placeholder="Price" />
            <input type="number" name="NumInStock" placeholder="NumInStock" />
            <input name="Animal" placeholder="Animal" />
            <input name="Company" placeholder="Company" />
            <button type="submit" name="add">Add</button>
        </div>
    </form>
</body>
</html>
