// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.LevelEntryPoint
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class LevelEntryPoint
  {
    public byte scene;
    public byte entry;
    public int pntr;
    public int loc;
    public int warp;
    public int objectId;
    public bool inuse;

    public LevelEntryPoint(byte scene_, byte entry_, int pntr_, int loc_, int warp_)
    {
      this.scene = scene_;
      this.entry = entry_;
      this.pntr = pntr_;
      this.loc = loc_;
      this.warp = warp_;
      this.getObjId();
    }

    private void getObjId()
    {
      switch (this.entry)
      {
        case 1:
          this.objectId = 1;
          break;
        case 2:
          this.objectId = 2;
          break;
        case 3:
          this.objectId = 21;
          break;
        case 4:
          this.objectId = 118;
          break;
        case 5:
          this.objectId = 119;
          break;
        case 6:
          this.objectId = 120;
          break;
        case 7:
          this.objectId = 121;
          break;
        case 8:
          this.objectId = 122;
          break;
        case 9:
          this.objectId = 123;
          break;
        case 10:
          this.objectId = 124;
          break;
        case 11:
          this.objectId = 125;
          break;
        case 12:
          this.objectId = 126;
          break;
        case 13:
          this.objectId = (int) sbyte.MaxValue;
          break;
        case 14:
          this.objectId = 117;
          break;
        case 15:
          this.objectId = 116;
          break;
        case 16:
          this.objectId = 115;
          break;
        case 17:
          this.objectId = 114;
          break;
        case 18:
          this.objectId = 259;
          break;
        case 19:
          this.objectId = 260;
          break;
        case 20:
          this.objectId = 261;
          break;
      }
    }
  }
}
