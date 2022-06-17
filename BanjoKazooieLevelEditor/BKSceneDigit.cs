// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKSceneDigit
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKSceneDigit
  {
    public string mapName = "";
    public int sceneID;

    public BKSceneDigit(int sceneID_)
    {
      this.sceneID = sceneID_;
      this.setMapName();
    }

    private void setMapName()
    {
      switch (this.sceneID)
      {
        case 1:
          this.mapName = "SM - Spiral Mountain";
          break;
        case 2:
          this.mapName = "MM - Mumbo's Mountain";
          break;
        case 5:
          this.mapName = "TTC - Blubber's Ship";
          break;
        case 6:
          this.mapName = "TTC - Nipper's Shell";
          break;
        case 7:
          this.mapName = "TTC - Treasure Trove Cove";
          break;
        case 10:
          this.mapName = "TTC - Sandcastle";
          break;
        case 11:
          this.mapName = "CC - Clanker's Cavern";
          break;
        case 12:
          this.mapName = "MM - Ticker's Tower";
          break;
        case 13:
          this.mapName = "BGS - Bubblegloop Swamp";
          break;
        case 14:
          this.mapName = "MM - Mumbo's Hut";
          break;
        case 16:
          this.mapName = "BGS - Mr. Vile";
          break;
        case 17:
          this.mapName = "BGS - Tiptup Chior";
          break;
        case 18:
          this.mapName = "GV - Gobi's Valley";
          break;
        case 19:
          this.mapName = "GV - Puzzle Room";
          break;
        case 20:
          this.mapName = "GV - King Sandybutt's Tomb";
          break;
        case 21:
          this.mapName = "GV - Water Room";
          break;
        case 22:
          this.mapName = "GV - Rubee";
          break;
        case 26:
          this.mapName = "GV - Jinxy";
          break;
        case 27:
          this.mapName = "MMM - Mad Monster Mansion";
          break;
        case 28:
          this.mapName = "MMM - Church";
          break;
        case 29:
          this.mapName = "MMM - Cellar";
          break;
        case 30:
          this.mapName = "CS - Intro";
          break;
        case 31:
          this.mapName = "CS - N Cube";
          break;
        case 32:
          this.mapName = "CS - Beach Ending w/out 100 jiggies";
          break;
        case 33:
          this.mapName = "CC - Inside Clanker - Witch Switch";
          break;
        case 34:
          this.mapName = "CC - Inside Clanker";
          break;
        case 35:
          this.mapName = "CC - Inside Clanker - Gold Feathers";
          break;
        case 36:
          this.mapName = "MMM - Tumblar's Shed";
          break;
        case 37:
          this.mapName = "MMM - Well";
          break;
        case 38:
          this.mapName = "MMM - Dining Room";
          break;
        case 39:
          this.mapName = "FP - Freezeezy Peak";
          break;
        case 40:
          this.mapName = "MMM - Egg Room";
          break;
        case 41:
          this.mapName = "MMM - Note Room";
          break;
        case 42:
          this.mapName = "MMM - Feather Room";
          break;
        case 43:
          this.mapName = "MMM - Secret Church Room";
          break;
        case 44:
          this.mapName = "MMM - Bathroom";
          break;
        case 45:
          this.mapName = "MMM - Bedroom";
          break;
        case 46:
          this.mapName = "MMM - Gold Feather Room";
          break;
        case 47:
          this.mapName = "MMM - Drainpipe";
          break;
        case 48:
          this.mapName = "MMM - Mumbo's Hut";
          break;
        case 49:
          this.mapName = "RBB - Rusty Bucket Bay";
          break;
        case 52:
          this.mapName = "RBB - Machine Room";
          break;
        case 53:
          this.mapName = "RBB - Big Fish Warehouse";
          break;
        case 54:
          this.mapName = "RBB - Boat Room";
          break;
        case 55:
          this.mapName = "RBB - First Blue Container";
          break;
        case 56:
          this.mapName = "RBB - Third Blue Container";
          break;
        case 57:
          this.mapName = "RBB - Sea-Grublin's Cabin";
          break;
        case 58:
          this.mapName = "RBB - Kaboom's Room";
          break;
        case 59:
          this.mapName = "RBB - Mini Kaboom's Room";
          break;
        case 60:
          this.mapName = "RBB - Kitchen";
          break;
        case 61:
          this.mapName = "RBB - Navigation Room";
          break;
        case 62:
          this.mapName = "RBB - Second Blue Container";
          break;
        case 63:
          this.mapName = "RBB - Captain's Room";
          break;
        case 64:
          this.mapName = "CCW - Click Clock Wood";
          break;
        case 65:
          this.mapName = "FP - Boggy's Igloo";
          break;
        case 67:
          this.mapName = "Click Clock Woods - Spring";
          break;
        case 68:
          this.mapName = "Click Clock Woods - Summmer";
          break;
        case 69:
          this.mapName = "Click Clock Woods - Fall";
          break;
        case 70:
          this.mapName = "Click Clock Woods - Winter";
          break;
        case 71:
          this.mapName = "BGS - Mumbo's Hut";
          break;
        case 72:
          this.mapName = "FP - Mumbo's Hut";
          break;
        case 74:
          this.mapName = "CCW - Mumbo - Spring";
          break;
        case 75:
          this.mapName = "CCW - Mumbo - Summer";
          break;
        case 76:
          this.mapName = "CCW - Mumbo - Fall";
          break;
        case 77:
          this.mapName = "CCW - Mumbo - Winter";
          break;
        case 83:
          this.mapName = "FP - Christmas Tree";
          break;
        case 90:
          this.mapName = "CCW - Beehive - Summer";
          break;
        case 91:
          this.mapName = "CCW - Beehive - Spring";
          break;
        case 92:
          this.mapName = "CCW - Beehive - Fall";
          break;
        case 94:
          this.mapName = "CCW - Nabnuts House - Spring";
          break;
        case 95:
          this.mapName = "CCW - Nabnuts House - Summer";
          break;
        case 96:
          this.mapName = "CCW - Nabnuts House - Fall";
          break;
        case 97:
          this.mapName = "CCW - Nabnuts House - Winter";
          break;
        case 98:
          this.mapName = "CCW - Nabnut's Attic - Winter";
          break;
        case 99:
          this.mapName = "CCW - Nabnut's Attic - Fall";
          break;
        case 100:
          this.mapName = "CCW - Nabnut's Attic 2 - Winter";
          break;
        case 101:
          this.mapName = "CCW - Whipcrack Room - Spring";
          break;
        case 102:
          this.mapName = "CCW - Whipcrack Room - Summer";
          break;
        case 103:
          this.mapName = "CCW - Whipcrack Room - Fall";
          break;
        case 104:
          this.mapName = "CCW - Whipcrack Room - Winter";
          break;
        case 105:
          this.mapName = "GL - Floor 1";
          break;
        case 106:
          this.mapName = "GL - Floor 2";
          break;
        case 107:
          this.mapName = "GL - Floor 3";
          break;
        case 108:
          this.mapName = "GL - Pipe Room";
          break;
        case 109:
          this.mapName = "GL - TTC Entrance";
          break;
        case 110:
          this.mapName = "GL - Floor 5";
          break;
        case 111:
          this.mapName = "GL - Floor 6";
          break;
        case 112:
          this.mapName = "GL - CC Entrance";
          break;
        case 113:
          this.mapName = "GL - Floor 4";
          break;
        case 114:
          this.mapName = "GL - BGS Entrance";
          break;
        case 116:
          this.mapName = "GL - Lava Room";
          break;
        case 117:
          this.mapName = "GL - MMM Entrance";
          break;
        case 118:
          this.mapName = "GL - Floor 6";
          break;
        case 119:
          this.mapName = "GL - RBB Entrance";
          break;
        case 120:
          this.mapName = "GL - MMM Puzzle";
          break;
        case 121:
          this.mapName = "GL - Floor 7";
          break;
        case 122:
          this.mapName = "GL - Coffin Room";
          break;
        case 123:
          this.mapName = "CS - Going through Grunty's hallway, then to door!";
          break;
        case 124:
          this.mapName = "CS - Banjo Sleeping";
          break;
        case 125:
          this.mapName = "CS - Tooty Running to Bottles";
          break;
        case (int) sbyte.MaxValue:
          this.mapName = "FP - Wozza's Cave";
          break;
        case 128:
          this.mapName = "GL - Path to Quiz show";
          break;
        case 129:
          this.mapName = "CS - Grunty running out door";
          break;
        case 130:
          this.mapName = "CS - Tooty and Grunty in machines";
          break;
        case 131:
          this.mapName = "CS - You lose";
          break;
        case 133:
          this.mapName = "CS - Outside tower, thunder";
          break;
        case 134:
          this.mapName = "CS - Grunty rides outside her lair";
          break;
        case 135:
          this.mapName = "CS - Witch falling towards ground";
          break;
        case 136:
          this.mapName = "CS - Grunty hits ground";
          break;
        case 137:
          this.mapName = "CS - Tooty's being captured";
          break;
        case 138:
          this.mapName = "?? - Test house";
          break;
        case 139:
          this.mapName = "RBB - Anchor Room";
          break;
        case 140:
          this.mapName = "SM - Banjo's House";
          break;
        case 141:
          this.mapName = "MMM - Septic Tank";
          break;
        case 142:
          this.mapName = "GL - Furnace Fun";
          break;
        case 143:
          this.mapName = "TTC - Sharkfood Island";
          break;
        case 144:
          this.mapName = "GL - Boss";
          break;
        case 145:
          this.mapName = "CS - Game Select";
          break;
        case 146:
          this.mapName = "GV - Secret Blue Egg";
          break;
        case 147:
          this.mapName = "GL - Floor 8";
          break;
        case 148:
          this.mapName = "CS - Mumbo's Barbecue";
          break;
        case 149:
          this.mapName = "CS - Beach Ending - Have 100 Jiggies";
          break;
        case 150:
          this.mapName = "CS - Beach, about to show cast list";
          break;
        case 151:
          this.mapName = "CS - Beach, - after Pictures";
          break;
        case 152:
          this.mapName = "CS - Klungo Can't move Boulder w/out 100 Jiggies";
          break;
        case 153:
          this.mapName = "CS - Klungo Can't Move Boulder w/ 100 Jiggies";
          break;
      }
    }
  }
}
