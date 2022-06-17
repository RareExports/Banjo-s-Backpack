// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Bone
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Collections.Generic;

namespace BanjoKazooieLevelEditor
{
  public class Bone
  {
    public short id;
    public short animationID;
    public short parent;
    public float x;
    public float y;
    public float z;
    public float frame_xTranslation;
    public float frame_yTranslation;
    public float frame_zTranslation;
    public float frame_xRotation;
    public float frame_yRotation;
    public float frame_zRotation;
    public float frame_xScale = 1f;
    public float frame_yScale = 1f;
    public float frame_zScale = 1f;
    public Matrix4 computedMatrix = Matrix4.NewI();
    public List<MTransform> transformOrder = new List<MTransform>();
    public List<int> verts = new List<int>();
    public uint dl;

    public void ClearTransformOrder(MTransform transform)
    {
      if (!this.transformOrder.Contains(transform))
        return;
      this.transformOrder.Remove(transform);
    }

    public Bone(short id_, short animationID_, short parent_, float x_, float y_, float z_)
    {
      this.id = id_;
      this.animationID = animationID_;
      this.parent = parent_;
      this.x = x_;
      this.y = y_;
      this.z = z_;
    }

    public void ClearTranformations()
    {
      this.frame_xTranslation = 0.0f;
      this.frame_yTranslation = 0.0f;
      this.frame_zTranslation = 0.0f;
      this.frame_xRotation = 0.0f;
      this.frame_yRotation = 0.0f;
      this.frame_zRotation = 0.0f;
      this.frame_xScale = 1f;
      this.frame_yScale = 1f;
      this.frame_zScale = 1f;
      this.transformOrder.Clear();
      this.computedMatrix = Matrix4.NewI();
    }
  }
}
