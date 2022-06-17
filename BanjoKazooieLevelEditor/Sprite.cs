// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Sprite
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Collections.Generic;
using System.Drawing;

namespace BanjoKazooieLevelEditor
{
  public class Sprite
  {
    public int id;
    public string name = "";
    public int pointer;
    public List<Bitmap> frames = new List<Bitmap>();
    public short numberFrames;
    public SpriteTextureFormat textureFormat = SpriteTextureFormat.CI4;
    public byte animationByte;
    public int imagesPerFrame = 1;
    public bool compressed = true;

    public Sprite(int id_, string name_, int pointer_, bool compressed_)
    {
      this.id = id_;
      this.name = name_;
      this.pointer = pointer_;
      this.compressed = compressed_;
    }
  }
}
