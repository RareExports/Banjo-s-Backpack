// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.VertGL
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class VertGL
  {
    public bool animateVertColour;
    public bool scrollTexture;
    public bool scrollTextureSlow;
    public bool scrollTextureFast;
    public short x;
    public short y;
    public short z;
    public short u;
    public short v;
    public byte r;
    public byte g;
    public byte b;
    public byte a;

    public VertGL(
      short x_,
      short y_,
      short z_,
      byte r_,
      byte g_,
      byte b_,
      byte a_,
      short u_,
      short v_)
    {
      this.x = x_;
      this.y = y_;
      this.z = z_;
      this.r = r_;
      this.g = g_;
      this.b = b_;
      this.a = a_;
      this.u = u_;
      this.v = v_;
    }

    public static VertGL clone(VertGL v) => new VertGL(v.x, v.y, v.z, v.r, v.g, v.b, v.a, v.u, v.v);
  }
}
