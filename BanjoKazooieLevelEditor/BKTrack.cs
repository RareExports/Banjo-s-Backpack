// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKTrack
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKTrack
  {
    public string trackName = "";
    public int trackID;

    public BKTrack(int trackID_)
    {
      this.trackID = trackID_;
      this.trackName = BKTrack.setTrackName(this.trackID);
    }

    public static string setTrackName(int trackID)
    {
      string str = "";
      switch (trackID)
      {
        case 0:
          str = "Nothing";
          break;
        case 1:
          str = "Final Battle with Grunty";
          break;
        case 2:
          str = "Mumbo's Mountain";
          break;
        case 3:
          str = "Freezeezy Peak";
          break;
        case 4:
          str = "MMM - Church";
          break;
        case 5:
          str = "Treasure Trove Cove";
          break;
        case 6:
          str = "BGS - Main";
          break;
        case 7:
          str = "CC - Fighting Crabs";
          break;
        case 8:
          str = "Main Conect Intro";
          break;
        case 9:
          str = "Note";
          break;
        case 10:
          str = "Jinjo";
          break;
        case 11:
          str = "Red Feather";
          break;
        case 12:
          str = "Egg";
          break;
        case 13:
          str = "Jiggy dance";
          break;
        case 14:
          str = "Wind Blowing - Start Rare Logo";
          break;
        case 15:
          str = "MMM";
          break;
        case 16:
          str = "Spiral Mountain";
          break;
        case 17:
          str = "TTC - Water, Seagulls";
          break;
        case 18:
          str = "TTC - Fighting Big Crab";
          break;
        case 19:
          str = "TTC - Inside Crab";
          break;
        case 20:
          str = "Gold Feather";
          break;
        case 21:
          str = "Extra Life";
          break;
        case 22:
          str = "Honeycomb";
          break;
        case 23:
          str = "Hollow Honeycomb";
          break;
        case 24:
          str = "Completed Honeycomb";
          break;
        case 25:
          str = "Beta?";
          break;
        case 26:
          str = "Dead Banjo";
          break;
        case 27:
          str = "MM - Inside Termite's hill";
          break;
        case 28:
          str = "Clanker Cavern";
          break;
        case 29:
          str = "Mumbo's Spell";
          break;
        case 30:
          str = "Grunty's Lair - Mumbo's Mountain";
          break;
        case 31:
          str = "CC - In Clanker";
          break;
        case 32:
          str = "Gobi's Valley";
          break;
        case 33:
          str = "MMM - In the main house";
          break;
        case 34:
          str = "MMM - In chruch yard";
          break;
        case 35:
          str = "MMM - In church";
          break;
        case 36:
          str = "GV - In tomb";
          break;
        case 37:
          str = "Invunerability";
          break;
        case 38:
          str = "GV - Sandybutts Maze";
          break;
        case 39:
          str = "GV - Ruppe";
          break;
        case 40:
          str = "TTC - Sandcastle";
          break;
        case 41:
          str = "CCW - Summer";
          break;
        case 42:
          str = "CCW - Winter";
          break;
        case 43:
          str = "Right";
          break;
        case 44:
          str = "Wrong";
          break;
        case 45:
          str = "Fanfare before Jiggy";
          break;
        case 46:
          str = "CCW - Autumn";
          break;
        case 47:
          str = "CCW - Main Hub";
          break;
        case 48:
          str = "All Jinjos Collected";
          break;
        case 49:
          str = "Game Over";
          break;
        case 50:
          str = "Intro screen";
          break;
        case 51:
          str = "RBB - Main";
          break;
        case 52:
          str = "Snacker tune";
          break;
        case 53:
          str = "RBB - In machine room";
          break;
        case 54:
          str = "All 100 Note";
          break;
        case 55:
          str = "Door opening";
          break;
        case 56:
          str = "MMM - Church door closing";
          break;
        case 57:
          str = "Beta Song";
          break;
        case 58:
          str = "FP - Race";
          break;
        case 59:
          str = "FP - Race Winner";
          break;
        case 60:
          str = "FP - Race Loser";
          break;
        case 61:
          str = "Jiggy Appearance";
          break;
        case 62:
          str = "Beta Sound";
          break;
        case 63:
          str = "Cauldron";
          break;
        case 64:
          str = "Witch Falling";
          break;
        case 65:
          str = "Mumbo's Hut";
          break;
        case 66:
          str = "Open Note Door";
          break;
        case 67:
          str = "Warp in to level sound";
          break;
        case 68:
          str = "CCW - Nabnut";
          break;
        case 69:
          str = "CCW - In bee Nest";
          break;
        case 70:
          str = "CCW - Top of tree";
          break;
        case 71:
          str = "BGS - Tip tup choir";
          break;
        case 72:
          str = "CCW - Summer house";
          break;
        case 73:
          str = "CCW - Autumn house";
          break;
        case 74:
          str = "RBB - Warehouse by Snacker";
          break;
        case 75:
          str = "CCW - Fighting Zubbas";
          break;
        case 76:
          str = "RBB - Quarters";
          break;
        case 77:
          str = "Beta Mumbo's Mountain";
          break;
        case 78:
          str = "Start - whistle pitch bend up";
          break;
        case 79:
          str = "Whistle Pitch bend down";
          break;
        case 80:
          str = "Grunty's Lair - TTC/CC";
          break;
        case 81:
          str = "Grunty's Lair - TTC/CCW";
          break;
        case 82:
          str = "Grunty's Lair - CC/BGS";
          break;
        case 83:
          str = "Grunty's Lair - BGS/FP";
          break;
        case 84:
          str = "Grunty's Lair - GV";
          break;
        case 85:
          str = "BGS - Mr Vile - eating Yumblies";
          break;
        case 86:
          str = "Bridge to Grunty's Lair";
          break;
        case 87:
          str = "Turbo Talon Trot";
          break;
        case 88:
          str = "Wellies move";
          break;
        case 89:
          str = "Grunty's Lair - FP";
          break;
        case 90:
          str = "Boggy's Igloo Sad";
          break;
        case 91:
          str = "Boggy's Igloo Happy";
          break;
        case 92:
          str = "Beta Game Over";
          break;
        case 93:
          str = "Grunty's Lair GV/MMM";
          break;
        case 94:
          str = "Grunty's Lair MMM/RBB";
          break;
        case 95:
          str = "CCW - Spring";
          break;
        case 96:
          str = "CCW - Nabnut's spare room";
          break;
        case 97:
          str = "FP - Light the tree";
          break;
        case 98:
          str = "RBB - Fighting the Kabooms";
          break;
        case 99:
          str = "Grunty's Lair - CCW/Game Show";
          break;
        case 100:
          str = "World Opening";
          break;
        case 101:
          str = "Filling a jigsaw picture";
          break;
        case 102:
          str = "FP - Christmas Tree";
          break;
        case 103:
          str = "Start - Rare Logo";
          break;
        case 104:
          str = "FP - We are the Twinklies";
          break;
        case 105:
          str = "Cauldron";
          break;
        case 106:
          str = "MMM - Puzzle board";
          break;
        case 107:
          str = "FP - Wozza's Cave";
          break;
        case 108:
          str = "Grunty's Intro";
          break;
        case 109:
          str = "CCW - Gnawty's house";
          break;
        case 110:
          str = "Start Select screen - Bed";
          break;
        case 111:
          str = "Pause Screen";
          break;
        case 112:
          str = "MMM - In loggo";
          break;
        case 113:
          str = "Grunty's Furnace Fun";
          break;
        case 114:
          str = "BGS - Beat the frogs";
          break;
        case 115:
          str = "Start Selection screen - gameboy";
          break;
        case 116:
          str = "Grunty's Main Room - Cackles";
          break;
        case 117:
          str = "Red Feather Pillow";
          break;
        case 118:
          str = "Gold Feather Pillow";
          break;
        case 119:
          str = "Blue Egg Pillow";
          break;
        case 120:
          str = "Open a Note door";
          break;
        case 121:
          str = "Cheato";
          break;
        case 122:
          str = "Brentilda";
          break;
        case 123:
          str = "Skull Square";
          break;
        case 124:
          str = "Grunty square";
          break;
        case 125:
          str = "Banjo square";
          break;
        case 126:
          str = "Joker square";
          break;
        case (int) sbyte.MaxValue:
          str = "Music square";
          break;
        case 128:
          str = "Machine Room";
          break;
        case 129:
          str = "Brentilda - strum";
          break;
        case 130:
          str = "Puzzle out";
          break;
        case 131:
          str = "Gobi Valley - SNS";
          break;
        case 132:
          str = "Treasure Trove Cove - SNS";
          break;
        case 133:
          str = "Freezeezy Peak - SNS";
          break;
        case 134:
          str = "Mad Monster Mansion - SNS";
          break;
        case 135:
          str = "Click Clock Wood - SNS";
          break;
        case 136:
          str = "Collection of SNS Item";
          break;
        case 137:
          str = "Jinjo charge";
          break;
        case 138:
          str = "Turbo Talon Trot short";
          break;
        case 139:
          str = "Strum";
          break;
        case 140:
          str = "Jinjonator";
          break;
        case 141:
          str = "Jinjonator appearing";
          break;
        case 142:
          str = "Cast List";
          break;
        case 143:
          str = "Jinjonator charging";
          break;
        case 144:
          str = "Grunty's Big Door opening";
          break;
        case 145:
          str = "Grunty falling";
          break;
        case 146:
          str = "Grunty's spell";
          break;
        case 147:
          str = "Bottles game piece";
          break;
        case 148:
          str = "Bottles game music";
          break;
        case 149:
          str = "Start of bottles game";
          break;
        case 150:
          str = "Pick a piece up";
          break;
        case 151:
          str = "Put a piece down";
          break;
        case 152:
          str = "Start of Bottles game";
          break;
        case 153:
          str = "Barbeque tune";
          break;
        case 154:
          str = "Jinjonator hitting Grunty";
          break;
        case 155:
          str = "Jinjonator hitting Grunty 2";
          break;
        case 156:
          str = "Jinjonator hitting Grunty 3";
          break;
        case 157:
          str = "Jinjonator hitting Grunty 4";
          break;
        case 158:
          str = "Jinjonator hitting Grunty 5";
          break;
        case 159:
          str = "Jinjonator hitting Grunty 6";
          break;
        case 160:
          str = "Jinjonator hitting Grunty 7";
          break;
        case 161:
          str = "Jinjonator hitting Grunty 8";
          break;
        case 162:
          str = "Jinjonator hitting Grunty 9";
          break;
        case 163:
          str = "Jinjonator hitting Grunty 10";
          break;
        case 164:
          str = "Barbeque Shock 1";
          break;
        case 165:
          str = "Barbeque Shock 2";
          break;
        case 166:
          str = "Barbeque Shock 3";
          break;
        case 167:
          str = "Barbeque Shock 4";
          break;
        case 168:
          str = "Grunty's Lament";
          break;
        case 169:
          str = "Tooty's theme";
          break;
        case 170:
          str = "Beach theme";
          break;
        case 171:
          str = "Grunty's Lament";
          break;
        case 172:
          str = "Final Game Over";
          break;
      }
      return str;
    }
  }
}
