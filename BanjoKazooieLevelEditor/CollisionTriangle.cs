// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.CollisionTriangle
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class CollisionTriangle
  {
    public int[] verts;
    public CollisionType collisionType;
    public GroundType groundType;
    public SoundType soundType;

    public CollisionTriangle(
      int[] verts_,
      CollisionType collisionType_,
      GroundType groundType_,
      SoundType soundType_)
    {
      this.verts = verts_;
      this.collisionType = collisionType_;
      this.groundType = groundType_;
      this.soundType = soundType_;
    }
  }
}
