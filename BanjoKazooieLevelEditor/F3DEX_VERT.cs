// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.F3DEX_VERT
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  internal class F3DEX_VERT
  {
    public short x;
    public short y;
    public short z;
    public short u;
    public short v;
    public float r;
    public float g;
    public float b;
    public float a;

    public F3DEX_VERT(
      short x_,
      short y_,
      short z_,
      short u_,
      short v_,
      float r_,
      float g_,
      float b_,
      float a_)
    {
      this.x = x_;
      this.y = y_;
      this.z = z_;
      this.u = u_;
      this.v = v_;
      this.r = r_;
      this.g = g_;
      this.b = b_;
      this.a = a_;
    }

    public static F3DEX_VERT Clone(F3DEX_VERT v) => new F3DEX_VERT(v.x, v.y, v.z, v.u, v.v, v.r, v.g, v.b, v.a);
  }
}
