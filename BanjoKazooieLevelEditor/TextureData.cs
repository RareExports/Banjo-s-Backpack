// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.TextureData
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class TextureData
  {
    public byte[] n64 = new byte[1];
    public byte[] gl = new byte[1];
    public int width;
    public int height;

    public TextureData()
    {
    }

    public TextureData(byte[] n64_, byte[] gl_, int w_, int h_)
    {
      this.n64 = n64_;
      this.gl = gl_;
      this.width = w_;
      this.height = h_;
    }
  }
}
