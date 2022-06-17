// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.GLCamera
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace BanjoKazooieLevelEditor
{
  public class GLCamera
  {
    private Vector3 position = new Vector3(0.0f, 0.0f, -2161f);
    private Vector3 rotation = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 up = new Vector3(0.0f, 1f, 0.0f);
    private Matrix4 ryMatrix = Matrix4.I;
    private Matrix4 rxMatrix = Matrix4.I;
    private float movementSpeed = 10f;

    public float MovementSpeed
    {
      set => this.movementSpeed = value;
    }

    public float X
    {
      set => this.position.x = value;
      get => this.position.x;
    }

    public float Y
    {
      set => this.position.y = value;
      get => this.position.y;
    }

    public float Z
    {
      set => this.position.z = value;
      get => this.position.z;
    }

    public float Yaw
    {
      set
      {
        this.rotation.y = value;
        this.ryMatrix = Matrix4.GetRotationMatrixY(Core.ToRadians((double) this.rotation.y));
      }
      get => this.rotation.y;
    }

    public float Pitch
    {
      set
      {
        this.rotation.x = value;
        if ((double) this.rotation.x < -180.0)
          this.rotation.x = 360f + this.rotation.x;
        if ((double) this.rotation.x > 180.0)
          this.rotation.x = 360f - this.rotation.x;
        this.rxMatrix = Matrix4.GetRotationMatrixX(Core.ToRadians((double) this.rotation.x));
      }
      get => this.rotation.x;
    }

    public float Roll
    {
      set => this.rotation.z = value;
      get => this.rotation.z;
    }

    public float GetXRotation() => this.rotation.x;

    public float GetYRotation() => this.rotation.y;

    public float GetZRotation() => this.rotation.z;

    public void Reset()
    {
      this.position = new Vector3(0.0f, 0.0f, -2161f);
      this.rotation = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void LookAt(Vector3 target)
    {
      this.rotation.x = 0.0f;
      this.rotation.y = 0.0f;
      this.rotation.z = 0.0f;
      this.position.x = target.x * -1f;
      this.position.y = (float) ((double) target.y * -1.0 - 50.0);
      this.position.z = (float) ((double) target.z * -1.0 - 500.0);
      this.ryMatrix = Matrix4.GetRotationMatrixY(Core.ToRadians((double) this.rotation.y));
      this.rxMatrix = Matrix4.GetRotationMatrixX(Core.ToRadians((double) this.rotation.x));
    }

    public void PanUpdate(bool forward, bool back, bool left, bool right)
    {
      float movementSpeed = this.movementSpeed;
      float num1 = (float) Math.Sin(Core.ToRadians((double) this.rotation.y)) * movementSpeed;
      float num2 = (float) Math.Cos(Core.ToRadians((double) this.rotation.y)) * movementSpeed;
      float num3 = (float) Math.Sin(Core.ToRadians((double) this.rotation.x)) * movementSpeed;
      Vector3 vector3 = new Vector3();
      if (forward)
      {
        vector3.x -= num1;
        vector3.z += num2;
        vector3.y += num3;
      }
      if (back)
      {
        vector3.x += num1;
        vector3.z -= num2;
        vector3.y -= num3;
      }
      if (left)
      {
        vector3.x -= num2;
        vector3.z -= num1;
      }
      if (right)
      {
        vector3.x += num2;
        vector3.z += num1;
      }
      this.position += vector3;
    }

    public void MouseUpdate(int mouseDeltaX, int mouseDeltaY)
    {
      this.rotation.y += (float) mouseDeltaX * 0.25f;
      this.rotation.x += (float) mouseDeltaY * 0.25f;
      if ((double) this.rotation.x <= -90.0)
        this.rotation.x = -90f;
      if ((double) this.rotation.x >= 90.0)
        this.rotation.x = 90f;
      this.ryMatrix = Matrix4.GetRotationMatrixY(Core.ToRadians((double) this.rotation.y));
      this.rxMatrix = Matrix4.GetRotationMatrixX(Core.ToRadians((double) this.rotation.x));
    }

    public float[] GetWorldToViewMatrix() => (this.rxMatrix * this.ryMatrix * Matrix4.GetTranslationMatrix(this.position.x, this.position.y, this.position.z)).ToGLMatrix();
  }
}
