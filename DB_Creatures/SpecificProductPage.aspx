<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecificProductPage.aspx.cs" Inherits="DB_Creatures.SpecificProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="color:red"><%=msg %></div>
            <img style='height:200px' src='./PetFoodImages/<%=imageProduct %>'/>
            <h1><%=productName %> | (<%=company %>) | Food for <%=animal %></h1>
            <h2>The price is: <%=price %> nis</h2>
        </div>
    </form>
</body>
</html>
