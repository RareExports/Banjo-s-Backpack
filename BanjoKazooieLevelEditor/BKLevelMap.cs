// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKLevelMap
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKLevelMap
  {
    public static string getLevelName(byte levelID)
    {
      string levelName;
      switch (levelID)
      {
        case 1:
          levelName = "Mumbo's Mountain";
          break;
        case 2:
          levelName = "Treasure Trove Cove";
          break;
        case 3:
          levelName = "Clanker's Cavern";
          break;
        case 4:
          levelName = "Bubblegloop Swamp";
          break;
        case 5:
          levelName = "Freezeezy Peak";
          break;
        case 6:
          levelName = "Grunty's Lair";
          break;
        case 7:
          levelName = "Gobi's Valley";
          break;
        case 8:
          levelName = "Click Clock Wood";
          break;
        case 9:
          levelName = "Rusty Bucket Bay";
          break;
        case 10:
          levelName = "Mad Monster Mansion";
          break;
        case 11:
          levelName = "Spiral Mountain";
          break;
        case 12:
          levelName = "Final Battle";
          break;
        case 13:
          levelName = "Cutscenes";
          break;
        default:
          levelName = "UNKNOWN";
          break;
      }
      return levelName;
    }
  }
}
