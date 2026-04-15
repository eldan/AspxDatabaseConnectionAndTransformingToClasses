using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DB_Creatures
{
  public class Creature
  {
    private string creatureName;
    private string image;
    private int power;
    private int posX;
    private int posY;

    public Creature(string creatureName, string image, int power, int posX, int posY) {
      this.creatureName = creatureName;
      this.image = image;
      this.power = power;
      this.posX = posX;
      this.posY = posY;
    }
    
    public string GetHtml()
    {
      string str = "";
      str += "<div class='postionCreature' style='left:" + posX + "px; top:" + posY + "px'>";
      str += "<div class='CreatureProperty'>" + creatureName + "</div>";
      str += "<img src='Images/Creatures/" + image + "' title='(" + power + ")'/>";
      str += "</div>";
      return str;
    }




  }
}
