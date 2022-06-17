// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.WarpLocation
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class WarpLocation
  {
    public int id;
    public string name = "";

    public WarpLocation(int id_)
    {
      this.id = id_;
      this.setName();
    }

    public void setName()
    {
      switch (this.id)
      {
        case 5:
          this.name = "GV - Jinxy's Tomb";
          break;
        case 6:
          this.name = "GV - Jinxy's Tomb Outside";
          break;
        case 9:
          this.name = "BGS - Mumbo's Hut";
          break;
        case 10:
          this.name = "BGS - Mumbo's Hut Outside";
          break;
        case 11:
          this.name = "TTC - Nipper Outside";
          break;
        case 12:
          this.name = "TTC - Entrance";
          break;
        case 13:
          this.name = "CC - Entrance";
          break;
        case 14:
          this.name = "BGS - Entrance";
          break;
        case 15:
          this.name = "GV - Entrance";
          break;
        case 16:
          this.name = "MMM - Entrance";
          break;
        case 17:
          this.name = "RBB - Entrance";
          break;
        case 18:
          this.name = "CCW Spring - Vine Room";
          break;
        case 19:
          this.name = "CCW Summer - Vine Room ";
          break;
        case 20:
          this.name = "CCW Fall - Vine Room";
          break;
        case 21:
          this.name = "CCW Winter - Vine Room";
          break;
        case 22:
          this.name = "MM - Mumbo's Hut";
          break;
        case 23:
          this.name = "MM - Mumbo's Hut Outside";
          break;
        case 24:
          this.name = "MM - Ticker's Tower";
          break;
        case 25:
          this.name = "MM - Ticker's Tower outside";
          break;
        case 26:
          this.name = "MM - Ticker's Tower Top";
          break;
        case 27:
          this.name = "MM - Ticker's Tower Top outside";
          break;
        case 28:
          this.name = "CS - Musical Number";
          break;
        case 29:
          this.name = "CS - Title Screen";
          break;
        case 30:
          this.name = "CS - End (Not 100 Jiggies)";
          break;
        case 34:
          this.name = "GL - Floor 3 Note Door";
          break;
        case 35:
          this.name = "GL - Floor 4 Entrance";
          break;
        case 36:
          this.name = "GL - Pipe Room CC Entrance";
          break;
        case 37:
          this.name = "GL - Pipe Room";
          break;
        case 38:
          this.name = "GL - Floor 3 Pipe Room Entrance";
          break;
        case 39:
          this.name = "GL - Floor 3 TTC Lobby";
          break;
        case 40:
          this.name = "GL - TTC Lobby";
          break;
        case 41:
          this.name = "CCW - Winter Attic 2";
          break;
        case 42:
          this.name = "CCW - Fall Attic";
          break;
        case 43:
          this.name = "CCW - Winter Attic";
          break;
        case 44:
          this.name = "CCW - Winter Attic 2 (Outside)";
          break;
        case 45:
          this.name = "CCW - Fall Attic (Outside)";
          break;
        case 46:
          this.name = "CCW - Winter Attic (Outside)";
          break;
        case 54:
          this.name = "THE END appears on screen";
          break;
        case 56:
          this.name = "GL Floor 6 high entrance";
          break;
        case 57:
          this.name = "GL Floor 6 entrance";
          break;
        case 58:
          this.name = "GL Floor 2 pipe entrance";
          break;
        case 59:
          this.name = "GL Floor 2 Pipe Room";
          break;
        case 60:
          this.name = "GL Floor 3";
          break;
        case 61:
          this.name = "GL Floor 2 entrance";
          break;
        case 62:
          this.name = "GL Grunty statue in middle of room - 260 note door entrance";
          break;
        case 63:
          this.name = "GL Floor 3 front entrance";
          break;
        case 64:
          this.name = "FP Mumbo's Hut";
          break;
        case 65:
          this.name = "FP Boggy's Igloo";
          break;
        case 66:
          this.name = "FP Christmas Tree";
          break;
        case 67:
          this.name = "FP Outside Mumbo's Hut";
          break;
        case 68:
          this.name = "FP Boggy's Igloo exit";
          break;
        case 69:
          this.name = "FP Outside Christmas Tree";
          break;
        case 70:
          this.name = "BGS Tanktup Inside";
          break;
        case 76:
          this.name = "PRESS START appears on screen";
          break;
        case 78:
          this.name = "GAME OVER appears on screen";
          break;
        case 80:
          this.name = "GL Outside Mumbo's Mountain";
          break;
        case 81:
          this.name = "GL Outside Mumbo's Mountain";
          break;
        case 83:
          this.name = "GL Floor 5 Outside Gobi's Valley";
          break;
        case 84:
          this.name = "GL Floor 5 Entrance";
          break;
        case 85:
          this.name = "GL FP area entrance";
          break;
        case 86:
          this.name = "GL Floor 1 near note door";
          break;
        case 87:
          this.name = "GL Floor 5 Entrance";
          break;
        case 88:
          this.name = "CCW Spring whip crack room Outside";
          break;
        case 89:
          this.name = "CCW Summer whip crack room Outside";
          break;
        case 90:
          this.name = "CCW Autumn whip crack room Outside";
          break;
        case 91:
          this.name = "CCW Winter whip crack room Outside";
          break;
        case 92:
          this.name = "GV Memory Game Puzzle";
          break;
        case 94:
          this.name = "GV Water Room (Star door) top entrance";
          break;
        case 95:
          this.name = "GV Water Room (Star door) bottom entrance";
          break;
        case 96:
          this.name = "GV Rubee's room";
          break;
        case 97:
          this.name = "GV Memory puzzle Outside";
          break;
        case 98:
          this.name = "GV Middle primid Outside";
          break;
        case 99:
          this.name = "GV Star piramid Outside";
          break;
        case 100:
          this.name = "GV Kazooie piramid Outside";
          break;
        case 101:
          this.name = "GV Kazooie piramid Outside";
          break;
        case 102:
          this.name = "BGS right Mr Vile nostral Inside";
          break;
        case 103:
          this.name = "BGS left Mr Vile nostral Inside";
          break;
        case 104:
          this.name = "BGS tanktup Outside";
          break;
        case 105:
          this.name = "BGS right Mr Vile nostral Outside";
          break;
        case 106:
          this.name = "BGS left Mr Vile nostral Outside";
          break;
        case 107:
          this.name = "TTC Sandcastle";
          break;
        case 108:
          this.name = "TTC cave leading to lighthouse area";
          break;
        case 109:
          this.name = "TTC Lighthouse area";
          break;
        case 110:
          this.name = "TTC Inside Blubers Ship (top of ship)";
          break;
        case 111:
          this.name = "TTC Inside Blubers Ship (bottom of ship)";
          break;
        case 112:
          this.name = "TTC Light House Bottom ";
          break;
        case 113:
          this.name = "TTC Light House Top";
          break;
        case 114:
          this.name = "TTC Sandcastle Outside";
          break;
        case 115:
          this.name = "FP entrance (warp disc)";
          break;
        case 116:
          this.name = "Grunty Boss Battle (Top of tower)";
          break;
        case 117:
          this.name = "TTC blubber's ship top Outside";
          break;
        case 118:
          this.name = "TTC blubber's ship bottom Outside";
          break;
        case 119:
          this.name = "GL Beauty machine room entrance";
          break;
        case 120:
          this.name = "Furnace Fun Back door entrance";
          break;
        case 121:
          this.name = "MMM Nappers room (front door entrance)";
          break;
        case 122:
          this.name = "MMM Nappers room (chimmney entrance)";
          break;
        case 123:
          this.name = "MMM Inside Well (Top entrance)";
          break;
        case 124:
          this.name = "MMM Tumblar's Shead";
          break;
        case 125:
          this.name = "MMM Church";
          break;
        case 126:
          this.name = "MMM Bonus room";
          break;
        case 129:
          this.name = "MMM Cellar Room Entrance";
          break;
        case 130:
          this.name = "MMM Red Feather Room";
          break;
        case 131:
          this.name = "MMM Egg Room";
          break;
        case 132:
          this.name = "MMM Note Room";
          break;
        case 133:
          this.name = "MMM Golden Feather Room";
          break;
        case 134:
          this.name = "MMM Bedroom";
          break;
        case 135:
          this.name = "MMM Bathroom";
          break;
        case 136:
          this.name = "MMM front door Outside";
          break;
        case 137:
          this.name = "MMM Clock Switch";
          break;
        case 138:
          this.name = "MMM Well Outside (TOP)";
          break;
        case 139:
          this.name = "MMM Tumblar's Shead Outside";
          break;
        case 140:
          this.name = "MMM Church Front Door Outside";
          break;
        case 141:
          this.name = "MMM Bonus Room Outside";
          break;
        case 142:
          this.name = "MMM Chimney Outside";
          break;
        case 143:
          this.name = "MMM drain pipe Outside (low)";
          break;
        case 144:
          this.name = "MMM Cellar Room Outside";
          break;
        case 145:
          this.name = "MMM red feather room Outside";
          break;
        case 146:
          this.name = "MMM egg room Outside";
          break;
        case 147:
          this.name = "MMM Bathroom Outside";
          break;
        case 148:
          this.name = "MMM golden feather room Outside";
          break;
        case 149:
          this.name = "MMM bedroom Outside";
          break;
        case 150:
          this.name = "MMM note room Outside";
          break;
        case 151:
          this.name = "MMM top of clock tower";
          break;
        case 152:
          this.name = "MMM clock tower face";
          break;
        case 153:
          this.name = "MMM Mumbo's Hut Outside";
          break;
        case 154:
          this.name = "MMM Mumbo's Hut Entrance";
          break;
        case 155:
          this.name = "CC Hoop room propeller room entrance";
          break;
        case 156:
          this.name = "CC Hoop room top entrance";
          break;
        case 157:
          this.name = "CC Inside clankers mouth entrance";
          break;
        case 158:
          this.name = "CC propeller room";
          break;
        case 159:
          this.name = "MM Entrance Warp pad";
          break;
        case 160:
          this.name = "RBB Captain's cabin";
          break;
        case 161:
          this.name = "RBB sailers cabin";
          break;
        case 162:
          this.name = "RBB Propeller switch room";
          break;
        case 163:
          this.name = "RBB Kitchen";
          break;
        case 164:
          this.name = "RBB Navigation Room";
          break;
        case 165:
          this.name = "RBB Vent room - tnt boxes";
          break;
        case 166:
          this.name = "RBB Propeller room";
          break;
        case 167:
          this.name = "RBB Container Room";
          break;
        case 168:
          this.name = "RBB boat room";
          break;
        case 169:
          this.name = "RBB container Room 1";
          break;
        case 170:
          this.name = "RBB container Room 2";
          break;
        case 171:
          this.name = "RBB container Room 3";
          break;
        case 172:
          this.name = "RBB Captain's Cabin OUTSIDE";
          break;
        case 174:
          this.name = "RBB Propeller Switch Room OUTSIDE";
          break;
        case 175:
          this.name = "RBB Kitchen OUTSIDE";
          break;
        case 176:
          this.name = "RBB Navagation Room OUTSIDE";
          break;
        case 177:
          this.name = "RBB TNT room OUTSIDE";
          break;
        case 178:
          this.name = "RBB funnel OUTSIDE";
          break;
        case 179:
          this.name = "RBB Exit Near Shark";
          break;
        case 180:
          this.name = "RBB container Room 1 OUTSIDE";
          break;
        case 181:
          this.name = "RBB container Room 2 OUTSIDE";
          break;
        case 182:
          this.name = "RBB container Room 3 OUTSIDE";
          break;
        case 183:
          this.name = "RBB Boss Boom Box OUTSIDE";
          break;
        case 184:
          this.name = "RBB Boss Boom Box";
          break;
        case 214:
          this.name = "CCW Winter OUTSIDE";
          break;
        case 215:
          this.name = "CCW Spring OUTSIDE";
          break;
        case 216:
          this.name = "CCW Summer OUTSIDE";
          break;
        case 217:
          this.name = "CCW Autumn OUTSIDE";
          break;
        case 218:
          this.name = "CCW Winter entrance";
          break;
        case 219:
          this.name = "CCW Spring entrance";
          break;
        case 220:
          this.name = "CCW Summer entrance";
          break;
        case 221:
          this.name = "CCW Autumn entrance";
          break;
        case 222:
          this.name = "GV Middel Pyramid OUTSIDE";
          break;
        case 223:
          this.name = "CCW Mumbo spring OUTSIDE";
          break;
        case 240:
          this.name = "CCW Winter OUTSIDE";
          break;
        case 241:
          this.name = "CCW Spring OUTSIDE";
          break;
        case 249:
          this.name = "Sharkfood Island OUTSIDE";
          break;
        case 250:
          this.name = "GL RBB OUTSIDE";
          break;
        case 251:
          this.name = "GL BGS OUTSIDE";
          break;
        case 252:
          this.name = "FP Waza Cave OUTSIDE";
          break;
        case 253:
          this.name = "FP Waza Cave";
          break;
        case 256:
          this.name = "GL Entrance to BGS area";
          break;
        case 257:
          this.name = "GL BGS area entrance";
          break;
        case 258:
          this.name = "GL MMM area entrance";
          break;
        case 259:
          this.name = "GL Lava room entrance";
          break;
        case 260:
          this.name = "GL grunty's mouth (approaching Lava room)";
          break;
        case 261:
          this.name = "GL water room entrance";
          break;
        case 262:
          this.name = "GL water room (Near CCW entrance)";
          break;
        case 263:
          this.name = "GL water room (640 Note door)";
          break;
        case 264:
          this.name = "GL water room lowest entrance (near RBB area)";
          break;
        case 265:
          this.name = "GL RBB Area Entrance";
          break;
        case 266:
          this.name = "GL Floor 7 Entrance";
          break;
        case 267:
          this.name = "GL Floor 7 High Entrance";
          break;
        case 268:
          this.name = "GL Floor 6 (450 note door entrance)";
          break;
        case 271:
          this.name = "CCW Bee hive (Autumn)";
          break;
        case 272:
          this.name = "CCW bee hive front OUTSIDE(spring)";
          break;
        case 273:
          this.name = "CCW bee hive top OUTSIDE (summer)";
          break;
        case 274:
          this.name = "CCW bee hive top OUTSIDE (autumn)";
          break;
        case 275:
          this.name = "GL Mad Monster Mansion Puzzle room (entrance)";
          break;
        case 276:
          this.name = "GL tunnel between MMM puzzle room and RBB area (entrance)";
          break;
        case 277:
          this.name = "GL Floor 4 (top)";
          break;
        case 278:
          this.name = "GL Floor 7 (765 note door)";
          break;
        case 279:
          this.name = "GL Area connecting to Furnace Fun (entrance)";
          break;
        case 280:
          this.name = "SM Banjo's House";
          break;
        case 281:
          this.name = "SM Banjo's House OUTSIDE";
          break;
        case 282:
          this.name = "GL Floor 1";
          break;
        case 283:
          this.name = "SM Grunty's Lair OUTSIDE";
          break;
        case 284:
          this.name = "RBB anchor room OUTSIDE";
          break;
        case 285:
          this.name = "RBB anchor room entrance";
          break;
        default:
          this.name = "";
          break;
      }
    }
  }
}
