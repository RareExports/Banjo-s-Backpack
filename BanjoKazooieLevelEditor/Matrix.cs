// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Matrix
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace BanjoKazooieLevelEditor
{
  public class Matrix
  {
    public float[,] matrix;
    public int rows;
    public int cols;

    public Matrix(int rows, int cols)
    {
      this.matrix = new float[rows, cols];
      this.rows = rows;
      this.cols = cols;
    }

    public Matrix(float[,] matrix)
    {
      this.matrix = matrix;
      this.rows = matrix.GetLength(0);
      this.cols = matrix.GetLength(1);
    }

    public float[] ToGLMatrix()
    {
      float[] glMatrix = new float[16];
      int index1 = 0;
      for (int index2 = 0; index2 < this.cols; ++index2)
      {
        for (int index3 = 0; index3 < this.rows; ++index3)
        {
          glMatrix[index1] = this.matrix[index3, index2];
          ++index1;
        }
      }
      return glMatrix;
    }

    protected static float[,] Multiply(Matrix matrix, float scalar)
    {
      int rows = matrix.rows;
      int cols = matrix.cols;
      float[,] matrix1 = matrix.matrix;
      float[,] numArray = new float[rows, cols];
      for (int index1 = 0; index1 < rows; ++index1)
      {
        for (int index2 = 0; index2 < cols; ++index2)
          numArray[index1, index2] = matrix1[index1, index2] * scalar;
      }
      return numArray;
    }

    protected static float[,] Multiply(Matrix matrix1, Matrix matrix2)
    {
      int rows1 = matrix1.rows;
      int cols1 = matrix1.cols;
      int rows2 = matrix2.rows;
      int cols2 = matrix2.cols;
      if (cols1 != rows2)
        throw new ArgumentException();
      float[,] matrix3 = matrix1.matrix;
      float[,] matrix4 = matrix2.matrix;
      float[,] numArray = new float[rows1, cols2];
      for (int index1 = 0; index1 < rows1; ++index1)
      {
        for (int index2 = 0; index2 < cols2; ++index2)
        {
          float num = 0.0f;
          for (int index3 = 0; index3 < cols1; ++index3)
            num += matrix3[index1, index3] * matrix4[index3, index2];
          numArray[index1, index2] = num;
        }
      }
      return numArray;
    }

    public static Matrix operator *(Matrix m, float scalar) => new Matrix(Matrix.Multiply(m, scalar));

    public static Matrix operator *(Matrix m1, Matrix m2) => new Matrix(Matrix.Multiply(m1, m2));

    public override string ToString()
    {
      string str = "";
      for (int index1 = 0; index1 < this.rows; ++index1)
      {
        if (index1 > 0)
          str += "|";
        for (int index2 = 0; index2 < this.cols; ++index2)
        {
          if (index2 > 0)
            str += ",";
          str += (string) (object) this.matrix[index1, index2];
        }
      }
      return "(" + str + ")";
    }
  }
}
