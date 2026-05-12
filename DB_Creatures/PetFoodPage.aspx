<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PetFoodPage.aspx.cs" Inherits="DB_Creatures.PetFoodPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Pet food table</h1>
        <table style="width:100%">
            <%=tableData %>
        </table>
    </form>
</body>
</html>
