// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.CameraObject
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Collections.Generic;

namespace BanjoKazooieLevelEditor
{
  internal class CameraObject : BaseCamera
  {
    public List<byte> bytes = new List<byte>();
    public BoundingBox bb;
    public int type;
    public short id;
    public float x;
    public float y;
    public float z;
    public float speed;
    public float pitch;
    public float yaw;
    public float roll;
    public float pitch3;
    public float yaw3;
    public float roll3;
    public float camHSpeed;
    public float camVSpeed;
    public float camRotation;
    public float camAccel;
    public int Type3Arg5;
    public float camCDist;
    public float camFDist;

    public CameraObject(
      short id_,
      float x_,
      float y_,
      float z_,
      float t3a2f1,
      float t3a2f2,
      float t3a3f1,
      float t3a3f2,
      float t3a4f1,
      float t3a4f2,
      float t3a4f3,
      int t3a5,
      int type_)
    {
      this.type = type_;
      this.id = id_;
      this.x = x_;
      this.y = y_;
      this.z = z_;
      this.camHSpeed = t3a2f1;
      this.camVSpeed = t3a2f2;
      this.camRotation = t3a3f1;
      this.camAccel = t3a3f2;
      this.pitch3 = t3a4f1;
      this.yaw3 = t3a4f2;
      this.roll3 = t3a4f3;
      this.Type3Arg5 = t3a5;
      this.bb.largeX = 50;
      this.bb.largeY = 50;
      this.bb.largeZ = 50;
      this.bb.smallX = -50;
      this.bb.smallY = -50;
      this.bb.smallZ = 0;
    }

    public CameraObject(
      short id_,
      float x_,
      float y_,
      float z_,
      float pitch_,
      float yaw_,
      float roll_,
      int type_)
    {
      this.type = type_;
      this.id = id_;
      this.x = x_;
      this.y = y_;
      this.z = z_;
      this.pitch = pitch_;
      this.roll = roll_;
      this.yaw = yaw_;
      this.bb.largeX = 50;
      this.bb.largeY = 50;
      this.bb.largeZ = 50;
      this.bb.smallX = -50;
      this.bb.smallY = -50;
      this.bb.smallZ = 0;
    }

    public CameraObject(
      short id_,
      float x_,
      float y_,
      float z_,
      float t3a2f1,
      float t3a2f2,
      float t3a3f1,
      float t3a3f2,
      float t3a4f1,
      float t3a4f2,
      float t3a4f3,
      int t3a5,
      float t3a6f1,
      float t3a6f2,
      int type_)
    {
      this.type = type_;
      this.id = id_;
      this.x = x_;
      this.y = y_;
      this.z = z_;
      this.camHSpeed = t3a2f1;
      this.camVSpeed = t3a2f2;
      this.camRotation = t3a3f1;
      this.camAccel = t3a3f2;
      this.pitch3 = t3a4f1;
      this.yaw3 = t3a4f2;
      this.roll3 = t3a4f3;
      this.Type3Arg5 = t3a5;
      this.camCDist = t3a6f1;
      this.camFDist = t3a6f2;
      this.bb.largeX = 50;
      this.bb.largeY = 50;
      this.bb.largeZ = 50;
      this.bb.smallX = -50;
      this.bb.smallY = -50;
      this.bb.smallZ = 0;
    }

    public static CameraObject clone(CameraObject c) => new CameraObject(c.id, c.x, c.y, c.z, c.pitch, c.yaw, c.roll, c.type)
    {
      bb = c.bb,
      type = c.type,
      speed = c.speed,
      pitch3 = c.pitch3,
      yaw3 = c.yaw3,
      roll3 = c.roll3,
      camHSpeed = c.camHSpeed,
      camVSpeed = c.camVSpeed,
      camRotation = c.camRotation,
      camAccel = c.camAccel,
      Type3Arg5 = c.Type3Arg5,
      camCDist = c.camCDist,
      camFDist = c.camFDist
    };
  }
}
