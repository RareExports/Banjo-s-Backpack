// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BBUI
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using OpenTK.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class BBUI
  {
    private static bool setup = false;
    private static byte[] statsIMG;
    private static List<byte[]> numberTextures = new List<byte[]>();
    private static byte[] _BC;
    private static byte[] _BNC;
    private static byte[] _PC;
    private static byte[] _PNC;
    private static byte[] _GC;
    private static byte[] _GNC;
    private static byte[] _YC;
    private static byte[] _YNC;
    private static byte[] _OC;
    private static byte[] _ONC;
    private static int[] t_numbers = new int[10];
    private static int t_stats = 0;
    private static int[] t_cjinjos = new int[5];
    private static int[] t_ncjinjos = new int[5];

    public static void Setup()
    {
      if (!BBUI.setup)
      {
        try
        {
          OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
          string str = Application.StartupPath + "\\resources\\";
          BBUI.statsIMG = File.ReadAllBytes(str + "stats.bin");
          BBUI._BC = File.ReadAllBytes(str + "jinjo\\BC.bin");
          BBUI._BNC = File.ReadAllBytes(str + "jinjo\\BNC.bin");
          BBUI._PC = File.ReadAllBytes(str + "jinjo\\PC.bin");
          BBUI._PNC = File.ReadAllBytes(str + "jinjo\\PNC.bin");
          BBUI._GC = File.ReadAllBytes(str + "jinjo\\GC.bin");
          BBUI._GNC = File.ReadAllBytes(str + "jinjo\\GNC.bin");
          BBUI._YC = File.ReadAllBytes(str + "jinjo\\YC.bin");
          BBUI._YNC = File.ReadAllBytes(str + "jinjo\\YNC.bin");
          BBUI._OC = File.ReadAllBytes(str + "jinjo\\OC.bin");
          BBUI._ONC = File.ReadAllBytes(str + "jinjo\\ONC.bin");
          for (int index = 0; index < 10; ++index)
            BBUI.GenerateTexture(ref BBUI.t_numbers[index], File.ReadAllBytes(str + (object) index + ".bin"), 32, 32);
          for (int index = 0; index < 5; ++index)
          {
            switch (index)
            {
              case 0:
                BBUI.GenerateTexture(ref BBUI.t_ncjinjos[index], BBUI._BNC, 64, 64);
                BBUI.GenerateTexture(ref BBUI.t_cjinjos[index], BBUI._BC, 64, 64);
                break;
              case 1:
                BBUI.GenerateTexture(ref BBUI.t_ncjinjos[index], BBUI._GNC, 64, 64);
                BBUI.GenerateTexture(ref BBUI.t_cjinjos[index], BBUI._GC, 64, 64);
                break;
              case 2:
                BBUI.GenerateTexture(ref BBUI.t_ncjinjos[index], BBUI._ONC, 64, 64);
                BBUI.GenerateTexture(ref BBUI.t_cjinjos[index], BBUI._OC, 64, 64);
                break;
              case 3:
                BBUI.GenerateTexture(ref BBUI.t_ncjinjos[index], BBUI._PNC, 64, 64);
                BBUI.GenerateTexture(ref BBUI.t_cjinjos[index], BBUI._PC, 64, 64);
                break;
              case 4:
                BBUI.GenerateTexture(ref BBUI.t_ncjinjos[index], BBUI._YNC, 64, 64);
                BBUI.GenerateTexture(ref BBUI.t_cjinjos[index], BBUI._YC, 64, 64);
                break;
            }
          }
          BBUI.GenerateTexture(ref BBUI.t_stats, BBUI.statsIMG, 64, 256);
        }
        catch
        {
        }
      }
      BBUI.setup = true;
    }

    private static void GenerateTexture(ref int textureName, byte[] pixels, int w, int h)
    {
      OpenTK.Graphics.OpenGL.GL.GenTextures(1, out textureName);
      OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, textureName);
      OpenTK.Graphics.OpenGL.GL.TexImage2D<byte>(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, 0, OpenTK.Graphics.OpenGL.PixelInternalFormat.Rgba, w, h, 0, OpenTK.Graphics.OpenGL.PixelFormat.Rgba, OpenTK.Graphics.OpenGL.PixelType.UnsignedByte, pixels);
      OpenTK.Graphics.OpenGL.GL.TexParameter(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureMinFilter, 9729);
      OpenTK.Graphics.OpenGL.GL.TexParameter(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureMagFilter, 9729);
    }

    private static void Draw2DRectangle(float min_x, float min_y, float max_x, float max_y)
    {
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Triangles);
      OpenTK.Graphics.OpenGL.GL.TexCoord2(0, 0);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, max_y, 0.0f);
      OpenTK.Graphics.OpenGL.GL.TexCoord2(0, 1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, min_y, 0.0f);
      OpenTK.Graphics.OpenGL.GL.TexCoord2(1, 1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(1f, min_y, 0.0f);
      OpenTK.Graphics.OpenGL.GL.TexCoord2(1, 0);
      OpenTK.Graphics.OpenGL.GL.Vertex3(1f, max_y, 0.0f);
      OpenTK.Graphics.OpenGL.GL.TexCoord2(0, 0);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, max_y, 0.0f);
      OpenTK.Graphics.OpenGL.GL.TexCoord2(1, 1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(1f, min_y, 0.0f);
      OpenTK.Graphics.OpenGL.GL.End();
    }

    public static void DrawStats(LevelStat ls)
    {
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      OpenTK.Graphics.OpenGL.GL.Viewport(0, 0, 120, 120);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Projection);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      Glu.Perspective(45.0, 1.0, 1.0, 100000.0);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Modelview);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(-2f, 0.0f, -5f);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.DepthTest);
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Color3(1f, 1f, 1f);
      OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, BBUI.t_stats);
      BBUI.Draw2DRectangle(-2f, -2f, 2f, 2f);
      float x1 = 0.0f;
      string str = ls.jiggy.ToString();
      OpenTK.Graphics.OpenGL.GL.Translate(1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, 0.8f, 0.0f);
      for (int index1 = 0; index1 < str.Length; ++index1)
      {
        int index2 = int.Parse(str[index1].ToString());
        OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, BBUI.t_numbers[index2]);
        OpenTK.Graphics.OpenGL.GL.Translate(x1, 0.0f, 0.0f);
        BBUI.Draw2DRectangle(0.0f, 0.0f, 1f, 1f);
        x1 = 0.6f;
      }
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, -0.1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      float x2 = 0.0f;
      foreach (char ch in ls.note.ToString())
      {
        int index = int.Parse(ch.ToString());
        OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, BBUI.t_numbers[index]);
        OpenTK.Graphics.OpenGL.GL.Translate(x2, 0.0f, 0.0f);
        BBUI.Draw2DRectangle(0.0f, 0.0f, 1f, 1f);
        x2 = 0.6f;
      }
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, -0.8f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      float x3 = 0.0f;
      foreach (char ch in ls.eh.ToString())
      {
        int index = int.Parse(ch.ToString());
        OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, BBUI.t_numbers[index]);
        OpenTK.Graphics.OpenGL.GL.Translate(x3, 0.0f, 0.0f);
        BBUI.Draw2DRectangle(0.0f, 0.0f, 1f, 1f);
        x3 = 0.6f;
      }
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, -0.9f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      float x4 = 0.0f;
      foreach (char ch in ls.mumbo.ToString())
      {
        int index = int.Parse(ch.ToString());
        OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, BBUI.t_numbers[index]);
        OpenTK.Graphics.OpenGL.GL.Translate(x4, 0.0f, 0.0f);
        BBUI.Draw2DRectangle(0.0f, 0.0f, 1f, 1f);
        x4 = 0.6f;
      }
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.DepthTest);
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }

    public static void DrawJinjos(int x, int y, bool[] jinjos)
    {
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Viewport(x, y, 400, 100);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Projection);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      Glu.Perspective(45.0, 1.0 * 4.0, 1.0, 100000.0);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Modelview);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      OpenTK.Graphics.OpenGL.GL.Translate(-2f, -1f, -3f);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      int x1 = 1;
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.DepthTest);
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Color3(1f, 1f, 1f);
      for (int index = 0; index < 5; ++index)
      {
        if (jinjos[index])
          OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, BBUI.t_cjinjos[index]);
        else
          OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, BBUI.t_ncjinjos[index]);
        BBUI.Draw2DRectangle(0.0f, 0.0f, 1f, 1f);
        OpenTK.Graphics.OpenGL.GL.Translate((float) x1, 0.0f, 0.0f);
      }
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.DepthTest);
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }

    public static void DrawAxis(int x, int y, GLCamera BBCamera)
    {
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Viewport(x, y, 100, 100);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Projection);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      Glu.Perspective(45.0, 1.0, 1.0, 100000.0);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Modelview);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, 0.0f, -5f);
      OpenTK.Graphics.OpenGL.GL.Rotate(BBCamera.GetXRotation(), 1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(BBCamera.GetYRotation(), 0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(BBCamera.GetZRotation(), 0.0f, 0.0f, 1f);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.LineWidth(4f);
      OpenTK.Graphics.OpenGL.GL.Color3(1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Lines);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, 0.0f, -1f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0, 0, 0);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.Color3(0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Lines);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0, 0, 0);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.Color3(0.0f, 0.0f, 1f);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Lines);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }
  }
}
