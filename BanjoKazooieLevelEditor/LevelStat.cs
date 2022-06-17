// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.LevelStat
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class LevelStat
  {
    public int note;
    public int red;
    public int gold;
    public int egg;
    public int mumbo;
    public int jiggy;
    public int eh;

    public LevelStat(int note_, int egg_, int red_, int gold_, int mumbo_, int jiggy_, int eh_)
    {
      this.note = note_;
      this.egg = egg_;
      this.red = red_;
      this.gold = gold_;
      this.mumbo = mumbo_;
      this.jiggy = jiggy_;
      this.eh = eh_;
    }
  }
}
