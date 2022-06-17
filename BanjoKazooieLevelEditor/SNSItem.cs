// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SNSItem
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Drawing;

namespace BanjoKazooieLevelEditor
{
  public class SNSItem
  {
    public byte flag;
    public string name = "";
    public int level;
    public int loc;
    public byte unknown;
    public byte colorOffset;
    public Color particle;

    public SNSItem(int loc_, int level_, byte unknown_, byte flag_)
    {
      this.loc = loc_;
      this.level = level_;
      this.unknown = unknown_;
      this.flag = flag_;
      switch (this.loc)
      {
        case 22912:
          this.name = "Cyan Egg";
          this.colorOffset = (byte) 235;
          break;
        case 22920:
          this.name = "Green Egg";
          this.colorOffset = (byte) 226;
          break;
        case 22932:
          this.name = "Red Egg";
          this.colorOffset = (byte) 223;
          break;
        case 22944:
          this.name = "Yellow Egg";
          this.colorOffset = (byte) 220;
          break;
        case 22956:
          this.name = "Pink Egg";
          this.colorOffset = (byte) 232;
          break;
        case 22968:
          this.name = "Blue Egg";
          this.colorOffset = (byte) 229;
          break;
      }
    }

    public void SetColour(byte r, byte g, byte b) => this.particle = Color.FromArgb((int) r, (int) g, (int) b);
  }
}
