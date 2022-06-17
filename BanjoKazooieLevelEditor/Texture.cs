// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Texture
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class Texture
  {
    public int textureSize;
    public int textureWidth;
    public int textureHeight;
    public float textureHRatio;
    public float textureWRatio;
    public uint textureOffset;
    public uint indexOffset;
    public int textureTableOffset;
    public int palSize;
    public byte[] palette;
    public byte[] red;
    public byte[] green;
    public byte[] blue;
    public byte[] alpha;
    public bool palLoaded;
    public byte[] pixels;

    public Texture(
      int textureTableOffset_,
      uint textureOffset_,
      int textureWidth_,
      int textureHeight_)
    {
      this.textureTableOffset = textureTableOffset_;
      this.textureOffset = textureOffset_;
      this.textureWidth = textureWidth_;
      this.textureHeight = textureHeight_;
      this.indexOffset = this.textureOffset + 32U;
      this.textureSize = this.textureWidth * this.textureHeight * 2;
    }

    public void setRatio(float sScale, float tScale)
    {
      this.textureHRatio = tScale / (float) (this.textureHeight << 5);
      this.textureWRatio = sScale / (float) (this.textureWidth << 5);
    }

    public void loadPalette(byte[] bytesInFile, int textureCount, int palSize)
    {
      this.palSize = palSize / 2;
      this.textureSize = palSize != 32 ? this.textureWidth * this.textureHeight : this.textureWidth * this.textureHeight / 2;
      if (this.palLoaded)
        return;
      this.palette = new byte[palSize];
      this.red = new byte[palSize / 2];
      this.green = new byte[palSize / 2];
      this.blue = new byte[palSize / 2];
      this.alpha = new byte[palSize / 2];
      this.indexOffset = (uint) ((ulong) this.textureOffset + (ulong) palSize);
      int index1 = 0;
      for (uint textureOffset = this.textureOffset; (long) textureOffset < (long) this.textureOffset + (long) palSize; ++textureOffset)
      {
        this.palette[index1] = bytesInFile[(long) (textureOffset + 64U) + (long) (textureCount * 16)];
        ++index1;
      }
      int index2 = 0;
      for (int index3 = 0; index3 < palSize / 2; ++index3)
      {
        this.red[index3] = this.palette[index2];
        this.red[index3] >>= 3;
        this.red[index3] *= (byte) 8;
        ushort num = (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) this.palette[index2] * 256U + (uint) this.palette[index2 + 1]) << 5) >> 3) >> 8);
        this.green[index3] = (byte) num;
        this.green[index3] *= (byte) 8;
        this.blue[index3] = this.palette[index2 + 1];
        this.blue[index3] <<= 2;
        this.blue[index3] >>= 3;
        this.blue[index3] *= (byte) 8;
        this.alpha[index3] = this.palette[index2 + 1];
        this.alpha[index3] <<= 7;
        this.alpha[index3] >>= 7;
        this.alpha[index3] = this.alpha[index3] != (byte) 1 ? (byte) 0 : byte.MaxValue;
        index2 += 2;
      }
      this.palLoaded = true;
    }
  }
}
