// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Matrix3
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace BanjoKazooieLevelEditor
{
  public class Matrix3 : Matrix
  {
    public Matrix3()
      : base(3, 3)
    {
    }

    public Matrix3(float[,] matrix)
      : base(matrix)
    {
      if (this.rows != 3 || this.cols != 3)
        throw new ArgumentException();
    }

    public static Matrix3 I() => new Matrix3(new float[3, 3]
    {
      {
        1f,
        0.0f,
        0.0f
      },
      {
        0.0f,
        1f,
        0.0f
      },
      {
        0.0f,
        0.0f,
        1f
      }
    });

    public static Vector3 operator *(Matrix3 matrix3, Vector3 v)
    {
      float[,] matrix = matrix3.matrix;
      return new Vector3((float) ((double) matrix[0, 0] * (double) v.x + (double) matrix[0, 1] * (double) v.y + (double) matrix[0, 2] * (double) v.z), (float) ((double) matrix[1, 0] * (double) v.x + (double) matrix[1, 1] * (double) v.y + (double) matrix[1, 2] * (double) v.z), (float) ((double) matrix[2, 0] * (double) v.x + (double) matrix[2, 1] * (double) v.y + (double) matrix[2, 2] * (double) v.z));
    }

    public static Matrix3 operator *(Matrix3 mat1, Matrix3 mat2)
    {
      float[,] matrix1 = mat1.matrix;
      float[,] matrix2 = mat2.matrix;
      return new Matrix3(new float[3, 3]
      {
        {
          (float) ((double) matrix1[0, 0] * (double) matrix2[0, 0] + (double) matrix1[0, 1] * (double) matrix2[1, 0] + (double) matrix1[0, 2] * (double) matrix2[2, 0]),
          (float) ((double) matrix1[0, 0] * (double) matrix2[0, 1] + (double) matrix1[0, 1] * (double) matrix2[1, 1] + (double) matrix1[0, 2] * (double) matrix2[2, 1]),
          (float) ((double) matrix1[0, 0] * (double) matrix2[0, 2] + (double) matrix1[0, 1] * (double) matrix2[1, 2] + (double) matrix1[0, 2] * (double) matrix2[2, 2])
        },
        {
          (float) ((double) matrix1[1, 0] * (double) matrix2[0, 0] + (double) matrix1[1, 1] * (double) matrix2[1, 0] + (double) matrix1[1, 2] * (double) matrix2[2, 0]),
          (float) ((double) matrix1[1, 0] * (double) matrix2[0, 1] + (double) matrix1[1, 1] * (double) matrix2[1, 1] + (double) matrix1[1, 2] * (double) matrix2[2, 1]),
          (float) ((double) matrix1[1, 0] * (double) matrix2[0, 2] + (double) matrix1[1, 1] * (double) matrix2[1, 2] + (double) matrix1[1, 2] * (double) matrix2[2, 2])
        },
        {
          (float) ((double) matrix1[2, 0] * (double) matrix2[0, 0] + (double) matrix1[2, 1] * (double) matrix2[1, 0] + (double) matrix1[2, 2] * (double) matrix2[2, 0]),
          (float) ((double) matrix1[2, 0] * (double) matrix2[0, 1] + (double) matrix1[2, 1] * (double) matrix2[1, 1] + (double) matrix1[2, 2] * (double) matrix2[2, 1]),
          (float) ((double) matrix1[2, 0] * (double) matrix2[0, 2] + (double) matrix1[2, 1] * (double) matrix2[1, 2] + (double) matrix1[2, 2] * (double) matrix2[2, 2])
        }
      });
    }

    public static Matrix3 operator *(Matrix3 m, float scalar) => new Matrix3(Matrix.Multiply((Matrix) m, scalar));
  }
}
