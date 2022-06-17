// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.TriangleGL
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class TriangleGL
  {
    public Face pickObj;
    public VertGL[] verts;
    public int textureSetting;
    public CollisionType collisionType;
    public GroundType groundType;
    public SoundType soundType;
    public bool genWave;

    public TriangleGL(VertGL[] verts_, int textureSetting_)
    {
      this.verts = verts_;
      this.textureSetting = textureSetting_;
      this.pickObj = new Face();
    }

    public TriangleGL(VertGL[] verts_, int textureSetting_, Face pickObj_)
    {
      this.verts = verts_;
      this.textureSetting = textureSetting_;
      this.pickObj = pickObj_;
    }

    public static TriangleGL clone(TriangleGL t) => new TriangleGL(new VertGL[3]
    {
      VertGL.clone(t.verts[0]),
      VertGL.clone(t.verts[1]),
      VertGL.clone(t.verts[2])
    }, t.textureSetting);
  }
}
