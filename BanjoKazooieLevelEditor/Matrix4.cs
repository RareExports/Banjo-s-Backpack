// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Matrix4
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace BanjoKazooieLevelEditor
{
  public class Matrix4 : Matrix
  {
    public static Matrix4 I = Matrix4.NewI();

    public Matrix4()
      : base(4, 4)
    {
    }

    public Matrix4(float[,] matrix)
      : base(matrix)
    {
      if (this.rows != 4 || this.cols != 4)
        throw new ArgumentException();
    }

    public static Matrix4 NewI() => new Matrix4(new float[4, 4]
    {
      {
        1f,
        0.0f,
        0.0f,
        0.0f
      },
      {
        0.0f,
        1f,
        0.0f,
        0.0f
      },
      {
        0.0f,
        0.0f,
        1f,
        0.0f
      },
      {
        0.0f,
        0.0f,
        0.0f,
        1f
      }
    });

    public static bool IsEqual(Matrix4 m1, Matrix4 m2) => (double) m1.matrix[0, 0] == (double) m2.matrix[0, 0] && (double) m1.matrix[0, 1] == (double) m2.matrix[0, 1] && (double) m1.matrix[0, 2] == (double) m2.matrix[0, 2] && (double) m1.matrix[0, 3] == (double) m2.matrix[0, 3] && (double) m1.matrix[1, 0] == (double) m2.matrix[1, 0] && (double) m1.matrix[1, 1] == (double) m2.matrix[1, 1] && (double) m1.matrix[1, 2] == (double) m2.matrix[1, 2] && (double) m1.matrix[1, 3] == (double) m2.matrix[1, 3] && (double) m1.matrix[2, 0] == (double) m2.matrix[2, 0] && (double) m1.matrix[2, 1] == (double) m2.matrix[2, 1] && (double) m1.matrix[2, 2] == (double) m2.matrix[2, 2] && (double) m1.matrix[2, 3] == (double) m2.matrix[2, 3] && (double) m1.matrix[3, 0] == (double) m2.matrix[3, 0] && (double) m1.matrix[3, 1] == (double) m2.matrix[3, 1] && (double) m1.matrix[3, 2] == (double) m2.matrix[3, 2] && (double) m1.matrix[3, 3] == (double) m2.matrix[3, 3];

    public static Vector3 operator *(Matrix4 matrix4, Vector3 v)
    {
      float[,] matrix = matrix4.matrix;
      float num = (float) ((double) matrix[3, 0] * (double) v.x + (double) matrix[3, 1] * (double) v.y + (double) matrix[3, 2] * (double) v.z) + matrix[3, 3];
      return new Vector3(((float) ((double) matrix[0, 0] * (double) v.x + (double) matrix[0, 1] * (double) v.y + (double) matrix[0, 2] * (double) v.z) + matrix[0, 3]) / num, ((float) ((double) matrix[1, 0] * (double) v.x + (double) matrix[1, 1] * (double) v.y + (double) matrix[1, 2] * (double) v.z) + matrix[1, 3]) / num, ((float) ((double) matrix[2, 0] * (double) v.x + (double) matrix[2, 1] * (double) v.y + (double) matrix[2, 2] * (double) v.z) + matrix[2, 3]) / num);
    }

    public static Matrix4 operator *(Matrix4 mat1, Matrix4 mat2)
    {
      float[,] matrix1 = mat1.matrix;
      float[,] matrix2 = mat2.matrix;
      return new Matrix4(new float[4, 4]
      {
        {
          (float) ((double) matrix1[0, 0] * (double) matrix2[0, 0] + (double) matrix1[0, 1] * (double) matrix2[1, 0] + (double) matrix1[0, 2] * (double) matrix2[2, 0] + (double) matrix1[0, 3] * (double) matrix2[3, 0]),
          (float) ((double) matrix1[0, 0] * (double) matrix2[0, 1] + (double) matrix1[0, 1] * (double) matrix2[1, 1] + (double) matrix1[0, 2] * (double) matrix2[2, 1] + (double) matrix1[0, 3] * (double) matrix2[3, 1]),
          (float) ((double) matrix1[0, 0] * (double) matrix2[0, 2] + (double) matrix1[0, 1] * (double) matrix2[1, 2] + (double) matrix1[0, 2] * (double) matrix2[2, 2] + (double) matrix1[0, 3] * (double) matrix2[3, 2]),
          (float) ((double) matrix1[0, 0] * (double) matrix2[0, 3] + (double) matrix1[0, 1] * (double) matrix2[1, 3] + (double) matrix1[0, 2] * (double) matrix2[2, 3] + (double) matrix1[0, 3] * (double) matrix2[3, 3])
        },
        {
          (float) ((double) matrix1[1, 0] * (double) matrix2[0, 0] + (double) matrix1[1, 1] * (double) matrix2[1, 0] + (double) matrix1[1, 2] * (double) matrix2[2, 0] + (double) matrix1[1, 3] * (double) matrix2[3, 0]),
          (float) ((double) matrix1[1, 0] * (double) matrix2[0, 1] + (double) matrix1[1, 1] * (double) matrix2[1, 1] + (double) matrix1[1, 2] * (double) matrix2[2, 1] + (double) matrix1[1, 3] * (double) matrix2[3, 1]),
          (float) ((double) matrix1[1, 0] * (double) matrix2[0, 2] + (double) matrix1[1, 1] * (double) matrix2[1, 2] + (double) matrix1[1, 2] * (double) matrix2[2, 2] + (double) matrix1[1, 3] * (double) matrix2[3, 2]),
          (float) ((double) matrix1[1, 0] * (double) matrix2[0, 3] + (double) matrix1[1, 1] * (double) matrix2[1, 3] + (double) matrix1[1, 2] * (double) matrix2[2, 3] + (double) matrix1[1, 3] * (double) matrix2[3, 3])
        },
        {
          (float) ((double) matrix1[2, 0] * (double) matrix2[0, 0] + (double) matrix1[2, 1] * (double) matrix2[1, 0] + (double) matrix1[2, 2] * (double) matrix2[2, 0] + (double) matrix1[2, 3] * (double) matrix2[3, 0]),
          (float) ((double) matrix1[2, 0] * (double) matrix2[0, 1] + (double) matrix1[2, 1] * (double) matrix2[1, 1] + (double) matrix1[2, 2] * (double) matrix2[2, 1] + (double) matrix1[2, 3] * (double) matrix2[3, 1]),
          (float) ((double) matrix1[2, 0] * (double) matrix2[0, 2] + (double) matrix1[2, 1] * (double) matrix2[1, 2] + (double) matrix1[2, 2] * (double) matrix2[2, 2] + (double) matrix1[2, 3] * (double) matrix2[3, 2]),
          (float) ((double) matrix1[2, 0] * (double) matrix2[0, 3] + (double) matrix1[2, 1] * (double) matrix2[1, 3] + (double) matrix1[2, 2] * (double) matrix2[2, 3] + (double) matrix1[2, 3] * (double) matrix2[3, 3])
        },
        {
          (float) ((double) matrix1[3, 0] * (double) matrix2[0, 0] + (double) matrix1[3, 1] * (double) matrix2[1, 0] + (double) matrix1[3, 2] * (double) matrix2[2, 0] + (double) matrix1[3, 3] * (double) matrix2[3, 0]),
          (float) ((double) matrix1[3, 0] * (double) matrix2[0, 1] + (double) matrix1[3, 1] * (double) matrix2[1, 1] + (double) matrix1[3, 2] * (double) matrix2[2, 1] + (double) matrix1[3, 3] * (double) matrix2[3, 1]),
          (float) ((double) matrix1[3, 0] * (double) matrix2[0, 2] + (double) matrix1[3, 1] * (double) matrix2[1, 2] + (double) matrix1[3, 2] * (double) matrix2[2, 2] + (double) matrix1[3, 3] * (double) matrix2[3, 2]),
          (float) ((double) matrix1[3, 0] * (double) matrix2[0, 3] + (double) matrix1[3, 1] * (double) matrix2[1, 3] + (double) matrix1[3, 2] * (double) matrix2[2, 3] + (double) matrix1[3, 3] * (double) matrix2[3, 3])
        }
      });
    }

    public static Matrix4 operator *(Matrix4 m, float scalar) => new Matrix4(Matrix.Multiply((Matrix) m, scalar));

    public static Matrix4 GetRotationMatrixX(double angle)
    {
      if (angle == 0.0)
        return Matrix4.I;
      float num1 = (float) Math.Sin(angle);
      float num2 = (float) Math.Cos(angle);
      float[,] matrix = new float[4, 4];
      matrix[0, 0] = 1f;
      matrix[1, 1] = num2;
      matrix[1, 2] = -num1;
      matrix[2, 1] = num1;
      matrix[2, 2] = num2;
      matrix[3, 3] = 1f;
      return new Matrix4(matrix);
    }

    public static Matrix4 GetRotationMatrixY(double angle)
    {
      if (angle == 0.0)
        return Matrix4.I;
      float num1 = (float) Math.Sin(angle);
      float num2 = (float) Math.Cos(angle);
      float[,] matrix = new float[4, 4];
      matrix[0, 0] = num2;
      matrix[0, 2] = num1;
      matrix[1, 1] = 1f;
      matrix[2, 0] = -num1;
      matrix[2, 2] = num2;
      matrix[3, 3] = 1f;
      return new Matrix4(matrix);
    }

    public static Matrix4 GetRotationMatrixZ(double angle)
    {
      if (angle == 0.0)
        return Matrix4.I;
      float num1 = (float) Math.Sin(angle);
      float num2 = (float) Math.Cos(angle);
      float[,] matrix = new float[4, 4];
      matrix[0, 0] = num2;
      matrix[0, 1] = -num1;
      matrix[1, 0] = num1;
      matrix[1, 1] = num2;
      matrix[2, 2] = 1f;
      matrix[3, 3] = 1f;
      return new Matrix4(matrix);
    }

    public static Matrix4 GetRotationMatrix(double ax, double ay, double az)
    {
      Matrix4 matrix4_1 = (Matrix4) null;
      Matrix4 matrix4_2 = (Matrix4) null;
      Matrix4 matrix4_3 = (Matrix4) null;
      if (ax != 0.0)
        matrix4_3 = Matrix4.GetRotationMatrixX(ax);
      if (ay != 0.0)
        matrix4_1 = Matrix4.GetRotationMatrixY(ay);
      if (az != 0.0)
        matrix4_2 = Matrix4.GetRotationMatrixZ(az);
      if (matrix4_1 != null)
      {
        if (matrix4_3 != null)
          matrix4_3 *= matrix4_1;
        else
          matrix4_3 = matrix4_1;
      }
      if (matrix4_2 != null)
      {
        if (matrix4_3 != null)
          matrix4_3 *= matrix4_2;
        else
          matrix4_3 = matrix4_2;
      }
      return matrix4_3 ?? Matrix4.I;
    }

    public static Matrix4 GetRotationMatrix(Vector3 axis, double angle)
    {
      if (angle == 0.0)
        return Matrix4.I;
      float x = axis.x;
      float y = axis.y;
      float z = axis.z;
      float num1 = (float) Math.Sin(angle);
      float num2 = (float) Math.Cos(angle);
      double num3 = (double) x;
      float num4 = (float) (num3 * num3);
      double num5 = (double) y;
      float num6 = (float) (num5 * num5);
      double num7 = (double) z;
      float num8 = (float) (num7 * num7);
      float num9 = x * y;
      float num10 = x * z;
      float num11 = y * z;
      float[,] matrix = new float[4, 4];
      matrix[0, 0] = num4 + (1f - num4) * num2;
      matrix[1, 0] = (float) ((double) num9 * (1.0 - (double) num2) + (double) z * (double) num1);
      matrix[2, 0] = (float) ((double) num10 * (1.0 - (double) num2) - (double) y * (double) num1);
      matrix[3, 0] = 0.0f;
      matrix[0, 1] = (float) ((double) num9 * (1.0 - (double) num2) - (double) z * (double) num1);
      matrix[1, 1] = num6 + (1f - num6) * num2;
      matrix[2, 1] = (float) ((double) num11 * (1.0 - (double) num2) + (double) x * (double) num1);
      matrix[3, 1] = 0.0f;
      matrix[0, 2] = (float) ((double) num10 * (1.0 - (double) num2) + (double) y * (double) num1);
      matrix[1, 2] = (float) ((double) num11 * (1.0 - (double) num2) - (double) x * (double) num1);
      matrix[2, 2] = num8 + (1f - num8) * num2;
      matrix[3, 2] = 0.0f;
      matrix[3, 0] = 0.0f;
      matrix[3, 1] = 0.0f;
      matrix[3, 2] = 0.0f;
      matrix[3, 3] = 1f;
      return new Matrix4(matrix);
    }

    public static Matrix4 GetRotationMatrix(Vector3 source, Vector3 destination)
    {
      Vector3 axis = Vector3.CrossProduct(source, destination);
      if (!(axis != Vector3.Zero))
        return Matrix4.I;
      axis.Normalize();
      double angle = Math.Acos((double) source.DotProduct(destination));
      return Matrix4.GetRotationMatrix(axis, angle);
    }

    public static Matrix4 GetTranslationMatrix(float tx, float ty, float tz) => new Matrix4(new float[4, 4]
    {
      {
        1f,
        0.0f,
        0.0f,
        tx
      },
      {
        0.0f,
        1f,
        0.0f,
        ty
      },
      {
        0.0f,
        0.0f,
        1f,
        tz
      },
      {
        0.0f,
        0.0f,
        0.0f,
        1f
      }
    });

    public static Matrix4 GetScaleMatrix(float sx, float sy, float sz) => new Matrix4(new float[4, 4]
    {
      {
        sx,
        0.0f,
        0.0f,
        0.0f
      },
      {
        0.0f,
        sy,
        0.0f,
        0.0f
      },
      {
        0.0f,
        0.0f,
        sz,
        0.0f
      },
      {
        0.0f,
        0.0f,
        0.0f,
        1f
      }
    });
  }
}
