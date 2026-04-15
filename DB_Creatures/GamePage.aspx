<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GamePage.aspx.cs" Inherits="DB_Creatures.Game" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Game.css" />
</head>
<body>
    <form id="form1" runat="server">
        <button type="submit" name="filter" value="chicken">Chickens only</button>
        <button type="submit" name="filter" value="sheep">Sheep only</button>
        <button type="submit" name="filter" value="cowandchicken">Cows and Chickens</button>
        <button type="submit" name="filter" value="nofilter">No Filter</button>
        <%=DrawAllCreatures() %>
    </form>
</body>
</html>
