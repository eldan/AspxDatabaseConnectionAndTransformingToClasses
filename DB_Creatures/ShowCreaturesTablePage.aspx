<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCreaturesTablePage.aspx.cs" Inherits="DB_Creatures.ShowDBTables" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <a href="GamePage.aspx" target="_blank">Open Game</a>
    <div>
      <%=ShowCreatursDetails() %>
      <hr />
      <h2>Add an Item (creature)</h2>
      <div>Creature Name</div>
      <div>
        <input type="text" name="ItemName" />
      </div>

      <div>
        Image Name
      </div>
      <div>
        <input type="text" name="ItemImage" />
      </div>
    </div>

    <div>
      PosX
    </div>
    <div>
      <input type="text" name="PosX" />
    </div>

    <div>
      PosY
    </div>
    <div>
      <input type="text" name="PosY" />
    </div>
    
    <div>
      Power
    </div>
    <div>
      <input type="text" name="Power" />
    </div>
    <div>
      <button type="submit" name="add">Add</button>
    </div>
  </form>
</body>
</html>
