// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKLevelName
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKLevelName
  {
    public string levelName = "";
    public int start;
    public int end;

    public BKLevelName(string levelName_, int start_, int end_)
    {
      this.levelName = levelName_;
      this.start = start_;
      this.end = end_;
    }
  }
}
