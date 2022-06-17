// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Core
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using Collada141;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  internal class Core
  {
    private float near = 100f;
    private float far = 35000f;
    public bool drawCamTrigRadius;
    public bool drawFlagRadius;
    public bool drawEnemyRadius;
    public bool drawWarpRadius;
    public bool drawUnknownRadius;
    private int texturesGL;
    private byte[] rect_pixel = new byte[0];
    private IntPtr wire;
    public F3DEX f3dex = new F3DEX();
    private int height;
    private int width;
    private bool usingARB;

    public static double ToRadians(double val) => Math.PI / 180.0 * val;

    public Core() => this.readINI();

    private void readINI()
    {
      try
      {
        StreamReader streamReader = new StreamReader(Application.StartupPath + "\\resources\\mw.ini");
        string end = streamReader.ReadToEnd();
        streamReader.Close();
        if (Regex.IsMatch(end, "NEAR:([^\\r\\n]*)"))
          this.near = Convert.ToSingle(Regex.Match(end, "NEAR:([^\\r\\n]*)").Groups[1].Value);
        if (!Regex.IsMatch(end, "FAR:([^\\r\\n]*)"))
          return;
        this.far = Convert.ToSingle(Regex.Match(end, "FAR:([^\\r\\n]*)").Groups[1].Value);
      }
      catch
      {
      }
    }

    public void ClearScreenAndLoadIdentity()
    {
      OpenTK.Graphics.OpenGL.GL.Clear(OpenTK.Graphics.OpenGL.ClearBufferMask.DepthBufferBit | OpenTK.Graphics.OpenGL.ClearBufferMask.ColorBufferBit);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
    }

    public void LoadIdentity() => OpenTK.Graphics.OpenGL.GL.LoadIdentity();

    public void DeleteDL(uint dl) => OpenTK.Graphics.OpenGL.GL.DeleteLists(dl, 1);

    public void DeleteDLs(List<uint> dls)
    {
      foreach (uint dl in dls)
        OpenTK.Graphics.OpenGL.GL.DeleteLists(dl, 1);
    }

    public void DeleteTextures(List<int> dls)
    {
      for (int index = 0; index < dls.Count; ++index)
      {
        if (index != -1)
        {
          uint dl = (uint) dls[index];
          OpenTK.Graphics.OpenGL.GL.DeleteTextures(1, ref dl);
        }
      }
    }

    public void DeleteBuffers(List<uint> buffers)
    {
      for (int index = 0; index < buffers.Count; ++index)
      {
        if (index != -1)
        {
          uint buffer = buffers[index];
          if (this.usingARB)
            OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(1, ref buffer);
          else
            OpenTK.Graphics.OpenGL.GL.DeleteBuffers(1, ref buffer);
        }
      }
    }

    public void DeleteBuffer(uint buffer)
    {
      if (this.usingARB)
        OpenTK.Graphics.OpenGL.GL.Arb.DeleteBuffers(1, ref buffer);
      else
        OpenTK.Graphics.OpenGL.GL.DeleteBuffers(1, ref buffer);
    }

    public uint GenerateDL()
    {
      try
      {
        int list = OpenTK.Graphics.OpenGL.GL.GenLists(1);
        OpenTK.Graphics.OpenGL.GL.NewList((uint) list, OpenTK.Graphics.OpenGL.ListMode.Compile);
        return (uint) list;
      }
      catch (Exception ex)
      {
        return 0;
      }
    }

    public void EndDL() => OpenTK.Graphics.OpenGL.GL.EndList();

    public void RenderDL(uint dl) => OpenTK.Graphics.OpenGL.GL.CallList(dl);

    public static void InitGl()
    {
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.DepthTest);
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.CullFace);
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.ShadeModel(OpenTK.Graphics.OpenGL.ShadingModel.Smooth);
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.Blend);
      OpenTK.Graphics.OpenGL.GL.BlendFunc(OpenTK.Graphics.OpenGL.BlendingFactorSrc.SrcAlpha, OpenTK.Graphics.OpenGL.BlendingFactorDest.OneMinusSrcAlpha);
      OpenTK.Graphics.OpenGL.GL.ClearColor(0.2f, 0.5f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.BindTexture(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, 0);
      OpenTK.Graphics.OpenGL.GL.TexParameter(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureMinFilter, 9728);
      OpenTK.Graphics.OpenGL.GL.TexParameter(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureMagFilter, 9728);
      OpenTK.Graphics.OpenGL.GL.TexParameter(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureWrapS, 33071);
      OpenTK.Graphics.OpenGL.GL.TexParameter(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, OpenTK.Graphics.OpenGL.TextureParameterName.TextureWrapT, 33071);
      OpenTK.Graphics.OpenGL.GL.TexParameter(OpenTK.Graphics.OpenGL.TextureTarget.Texture2D, (OpenTK.Graphics.OpenGL.TextureParameterName) 34046, 16);
    }

    public void drawCamera(CameraObject cam)
    {
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      if (cam.type == 2)
      {
        OpenTK.Graphics.OpenGL.GL.Translate(cam.x, cam.y, cam.z);
        OpenTK.Graphics.OpenGL.GL.Rotate(cam.roll, 0.0f, 0.0f, 1f);
        OpenTK.Graphics.OpenGL.GL.Rotate(cam.yaw, 0.0f, 1f, 0.0f);
        OpenTK.Graphics.OpenGL.GL.Rotate(cam.pitch, 1f, 0.0f, 0.0f);
      }
      if (cam.type == 3 || cam.type == 1)
        OpenTK.Graphics.OpenGL.GL.Translate(cam.x, cam.y, cam.z);
      int num1 = -50;
      int num2 = -50;
      int num3 = 0;
      int num4 = 50;
      int num5 = 50;
      int x1 = -40;
      int y1 = 55;
      int x2 = 40;
      int y2 = 85;
      int z2 = 50;
      OpenTK.Graphics.OpenGL.GL.Color3(1f, 1f, 1f);
      OpenTK.Graphics.OpenGL.GL.LineWidth(0.2f);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Lines);
      this.DrawLine(num1, num2, num3, num4, num2, num3);
      this.DrawLine(num1, num5, num3, num4, num5, num3);
      this.DrawLine(num1, num2, num3, num1, num5, num3);
      this.DrawLine(num4, num2, num3, num4, num5, num3);
      this.DrawLine(num1, num2, num3, 0, 0, z2);
      this.DrawLine(num1, num5, num3, 0, 0, z2);
      this.DrawLine(num4, num2, num3, 0, 0, z2);
      this.DrawLine(num4, num5, num3, 0, 0, z2);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Triangles);
      OpenTK.Graphics.OpenGL.GL.Color3(Color.Black);
      OpenTK.Graphics.OpenGL.GL.LineWidth(0.2f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, num3);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0, y2, num3);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, num3);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, num3);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0, y2, num3);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, num3);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }

    public uint drawCameraPicking(CameraObject cam)
    {
      int list = OpenTK.Graphics.OpenGL.GL.GenLists(1);
      OpenTK.Graphics.OpenGL.GL.NewList((uint) list, OpenTK.Graphics.OpenGL.ListMode.Compile);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      if (cam.type == 2)
      {
        OpenTK.Graphics.OpenGL.GL.Translate(cam.x, cam.y, cam.z);
        OpenTK.Graphics.OpenGL.GL.Rotate(cam.roll, 0.0f, 0.0f, 1f);
        OpenTK.Graphics.OpenGL.GL.Rotate(cam.yaw, 0.0f, 1f, 0.0f);
        OpenTK.Graphics.OpenGL.GL.Rotate(cam.pitch, 1f, 0.0f, 0.0f);
      }
      if (cam.type == 3 || cam.type == 1)
        OpenTK.Graphics.OpenGL.GL.Translate(cam.x, cam.y, cam.z);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.CullFace);
      int x1 = -50;
      int y1 = -50;
      int z1 = 50;
      int x2 = 50;
      int y2 = 90;
      int z2 = 0;
      OpenTK.Graphics.OpenGL.GL.Color3((float) cam.m_colorID[0] / (float) byte.MaxValue, (float) cam.m_colorID[1] / (float) byte.MaxValue, (float) cam.m_colorID[2] / (float) byte.MaxValue);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Triangles);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y1, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z2);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z1);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.EndList();
      OpenTK.Graphics.OpenGL.GL.Flush();
      return (uint) list;
    }

    public void DrawInvisibleWall()
    {
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.CullFace);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Quads);
      OpenTK.Graphics.OpenGL.GL.Color3(0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-10000f, 10000f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(10000f, 10000f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(10000f, -10000f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-10000f, -10000f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.Enable(OpenTK.Graphics.OpenGL.EnableCap.CullFace);
    }

    public void DrawPathController(float x, float y, float z)
    {
      float y1 = 50f;
      float y2 = -50f;
      float num = 25f;
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(x, y, z);
      OpenTK.Graphics.OpenGL.GL.Color3(0.0f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.TriangleFan);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, y2, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(num, 0.0f, num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-num, 0.0f, num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-num, 0.0f, -num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(num, 0.0f, -num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(num, 0.0f, num);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.TriangleFan);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, y1, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-num, 0.0f, num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(num, 0.0f, num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(num, 0.0f, -num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-num, 0.0f, -num);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-num, 0.0f, num);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      OpenTK.Graphics.OpenGL.GL.Flush();
      OpenTK.Graphics.OpenGL.GL.EndList();
    }

    public void DrawCamTrigger(
      float x,
      float y,
      float z,
      ushort radius,
      byte r,
      byte g,
      byte b)
    {
      int sx = -25;
      int sy = -25;
      int sz = -25;
      int lx = 25;
      int ly = 25;
      int lz = 25;
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(x, y, z);
      OpenTK.Graphics.OpenGL.GL.Color3((float) r / (float) byte.MaxValue, (float) g / (float) byte.MaxValue, (float) b / (float) byte.MaxValue);
      this.DrawCube(sx, sy, sz, lx, ly, lz);
      if (radius != (ushort) 0 && this.drawCamTrigRadius)
      {
        this.wire = OpenTK.Graphics.Glu.NewQuadric();
        OpenTK.Graphics.Glu.QuadricDrawStyle(this.wire, QuadricDrawStyle.Line);
        OpenTK.Graphics.Glu.Sphere(this.wire, (double) radius, 5, 5);
        OpenTK.Graphics.Glu.DeleteQuadric(this.wire);
      }
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }

    public void SetView(int height_, int width_)
    {
      this.height = height_;
      this.width = width_;
      OpenTK.Graphics.OpenGL.GL.Viewport(0, 0, this.width, this.height);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Projection);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      Tao.OpenGl.Glu.gluPerspective(45.0, 1.0 * (double) ((float) this.width / (float) this.height), (double) this.near, (double) this.far);
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Modelview);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      this.rect_pixel = new byte[(this.width + 1) * (this.height + 1) * 3 + 3];
    }

    public byte[] BackBufferSelect(int x, int y, uint dl)
    {
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Fog);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Lighting);
      OpenTK.Graphics.OpenGL.GL.ShadeModel(OpenTK.Graphics.OpenGL.ShadingModel.Flat);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 0.0f, 0.0f, 1f);
      OpenTK.Graphics.OpenGL.GL.CallList(dl);
      byte[] pixels = new byte[3];
      int[] data = new int[4];
      OpenTK.Graphics.OpenGL.GL.GetInteger(OpenTK.Graphics.OpenGL.GetPName.Viewport, data);
      OpenTK.Graphics.OpenGL.GL.ReadPixels<byte>(x, data[3] - y, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.Rgb, OpenTK.Graphics.OpenGL.PixelType.UnsignedByte, pixels);
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      return pixels;
    }

    public byte[] BackBufferSelect(int x, int y, List<uint> dl)
    {
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Fog);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Lighting);
      OpenTK.Graphics.OpenGL.GL.ShadeModel(OpenTK.Graphics.OpenGL.ShadingModel.Flat);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 0.0f, 0.0f, 1f);
      for (int index = 0; index < dl.Count<uint>(); ++index)
        OpenTK.Graphics.OpenGL.GL.CallList(dl[index]);
      byte[] pixels = new byte[3];
      int[] data = new int[4];
      OpenTK.Graphics.OpenGL.GL.GetInteger(OpenTK.Graphics.OpenGL.GetPName.Viewport, data);
      OpenTK.Graphics.OpenGL.GL.ReadPixels<byte>(x, data[3] - y, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.Rgb, OpenTK.Graphics.OpenGL.PixelType.UnsignedByte, pixels);
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      return pixels;
    }

    private void CalculateActiveBones(ref List<ActiveBone> activeSkeleton, int amount)
    {
      for (int index = 0; index < activeSkeleton.Count; ++index)
      {
        if (activeSkeleton[index].length != 16777216)
        {
          activeSkeleton[index].length -= amount;
          if (activeSkeleton[index].length < 7)
          {
            activeSkeleton.RemoveAt(index);
            --index;
          }
        }
      }
    }

    public void GetBuffersFromBKModelFile(
      ref byte[] bytesInFile,
      ref uint vboVertexHandle,
      ref float[] vertexData,
      ref uint vboColorHandle,
      ref uint vboTexCoordHandle,
      ref List<uint> iboHandles,
      ref List<ushort[]> iboData,
      ref List<int> texturesGL)
    {
      List<ushort> ushortList = new List<ushort>();
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      bool newTexture = false;
      bool flag = false;
      int currentTexture = 0;
      float sScale = 0.0f;
      float tScale = 0.0f;
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      ushort[] numArray1 = new ushort[32];
      Texture[] textures = new Texture[1];
      try
      {
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        if (!this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
          return;
        vertexData = new float[VTCount * 3];
        float[] data1 = new float[VTCount * 4];
        float[] data2 = new float[VTCount * 2];
        int index1 = 0;
        int index2 = 0;
        int index3 = 0;
        foreach (F3DEX_VERT f3DexVert in verts)
        {
          vertexData[index1] = (float) f3DexVert.x;
          vertexData[index1 + 1] = (float) f3DexVert.y;
          vertexData[index1 + 2] = (float) f3DexVert.z;
          data1[index2] = f3DexVert.r;
          data1[index2 + 1] = f3DexVert.g;
          data1[index2 + 2] = f3DexVert.b;
          data1[index2 + 3] = f3DexVert.a;
          data2[index3] = (float) f3DexVert.u;
          data2[index3 + 1] = (float) f3DexVert.v;
          index1 += 3;
          index2 += 4;
          index3 += 2;
        }
        if (this.usingARB)
        {
          OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(1, out vboVertexHandle);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, vboVertexHandle);
          OpenTK.Graphics.OpenGL.GL.Arb.BufferData<float>(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, (IntPtr) (vertexData.Length * 4), vertexData, OpenTK.Graphics.OpenGL.BufferUsageArb.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, 0);
          OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(1, out vboColorHandle);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, vboColorHandle);
          OpenTK.Graphics.OpenGL.GL.Arb.BufferData<float>(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, (IntPtr) (data1.Length * 4), data1, OpenTK.Graphics.OpenGL.BufferUsageArb.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, 0);
        }
        else
        {
          OpenTK.Graphics.OpenGL.GL.GenBuffers(1, out vboVertexHandle);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, vboVertexHandle);
          OpenTK.Graphics.OpenGL.GL.BufferData<float>(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, (IntPtr) (vertexData.Length * 4), vertexData, OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, 0);
          OpenTK.Graphics.OpenGL.GL.GenBuffers(1, out vboColorHandle);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, vboColorHandle);
          OpenTK.Graphics.OpenGL.GL.BufferData<float>(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, (IntPtr) (data1.Length * 4), data1, OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, 0);
        }
        for (int index4 = 0; index4 < F3DCommands; ++index4)
        {
          byte[] command = commands[index4];
          uint w1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
          int num1 = (int) command[1];
          int num2 = (int) command[2];
          int num3 = (int) command[3];
          if (command[0] == (byte) 184 && index4 + 1 < F3DCommands)
          {
            int num4 = (int) commands[index4 + 1][0];
          }
          if (command[0] == (byte) 253)
            this.f3dex.GL_G_SETTIMG(ref currentTexture, textureCount, w1, ref textures, commands[index4 + 2], ref newTexture, sScale, tScale);
          if (command[0] == (byte) 252)
            this.f3dex.GL_G_Combine(w1);
          if (command[0] == (byte) 182)
          {
            newTexture = false;
            flag = false;
          }
          int num5 = (int) command[0];
          if (command[0] == (byte) 245)
            this.f3dex.GL_G_SETTILE(command, ref textures[currentTexture]);
          if (command[0] == (byte) 240)
          {
            int palSize = (int) ((w1 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
            textures[currentTexture].loadPalette(bytesInFile, textureCount, palSize);
            if (commands[index4 + 4][0] == (byte) 186)
              newTexture = true;
          }
          if (command[0] == (byte) 187)
          {
            sScale = (float) (w1 >> 16) / 65536f;
            tScale = (float) (w1 & (uint) ushort.MaxValue) / 65536f;
          }
          if (command[0] == (byte) 4)
          {
            byte[] numArray2 = commands[index4];
            int num6 = (int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256 + (int) command[7];
            int num7 = (int) command[1];
            int num8 = (int) command[2];
            int num9 = (int) command[3];
            byte num10 = (byte) ((uint) command[1] >> 1);
            byte num11 = (byte) ((uint) command[2] >> 2);
            if (num10 > (byte) 63)
              num10 = (byte) 63;
            uint num12 = ((uint) (num6 << 8) >> 8) / 16U;
            try
            {
              for (int index5 = (int) num10; index5 < (int) num11 + (int) num10; ++index5)
              {
                if ((long) num12 < (long) verts.Length)
                  numArray1[index5] = (ushort) num12;
                ++num12;
              }
            }
            catch (Exception ex)
            {
            }
            if (texturesGL.Count > 0)
            {
              ushort[] array = ushortList.ToArray();
              uint buffers = 0;
              if (this.usingARB)
              {
                OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(1, out buffers);
                OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, buffers);
                OpenTK.Graphics.OpenGL.GL.Arb.BufferData<ushort>(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, (IntPtr) (array.Length * 2), array, OpenTK.Graphics.OpenGL.BufferUsageArb.StaticDraw);
                OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, 0);
              }
              else
              {
                OpenTK.Graphics.OpenGL.GL.GenBuffers(1, out buffers);
                OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, buffers);
                OpenTK.Graphics.OpenGL.GL.BufferData<ushort>(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, (IntPtr) (array.Length * 2), array, OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
                OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, 0);
              }
              iboHandles.Add(buffers);
              iboData.Add(array);
              ushortList.Clear();
            }
            if (newTexture)
            {
              newTexture = false;
              flag = true;
              texturesGL.Add(-1);
              int texturesGL1 = 0;
              this.f3dex.F3DEX_2_GL_TEXTURE(ref bytesInFile, ref textures[currentTexture], textureCount, ref texturesGL1, false);
              List<int> intList = texturesGL;
              intList[intList.Count - 1] = texturesGL1;
            }
            else if (flag)
            {
              List<int> intList = texturesGL;
              intList.Add(intList[intList.Count - 1]);
            }
            else
              texturesGL.Add(-1);
          }
          int num13 = (int) command[0];
          if (command[0] == (byte) 191)
          {
            short index6 = (short) ((int) command[5] / 2);
            short index7 = (short) ((int) command[6] / 2);
            short index8 = (short) ((int) command[7] / 2);
            ushortList.Add(numArray1[(int) index6]);
            ushortList.Add(numArray1[(int) index7]);
            ushortList.Add(numArray1[(int) index8]);
            data2[(int) numArray1[(int) index6] * 2] = (float) verts[(int) numArray1[(int) index6]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index6] * 2 + 1] = (float) verts[(int) numArray1[(int) index6]].v * textures[currentTexture].textureHRatio;
            data2[(int) numArray1[(int) index7] * 2] = (float) verts[(int) numArray1[(int) index7]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index7] * 2 + 1] = (float) verts[(int) numArray1[(int) index7]].v * textures[currentTexture].textureHRatio;
            data2[(int) numArray1[(int) index8] * 2] = (float) verts[(int) numArray1[(int) index8]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index8] * 2 + 1] = (float) verts[(int) numArray1[(int) index8]].v * textures[currentTexture].textureHRatio;
          }
          if (command[0] == (byte) 177)
          {
            short index9 = (short) ((int) command[1] / 2);
            short index10 = (short) ((int) command[2] / 2);
            short index11 = (short) ((int) command[3] / 2);
            ushortList.Add(numArray1[(int) index9]);
            ushortList.Add(numArray1[(int) index10]);
            ushortList.Add(numArray1[(int) index11]);
            data2[(int) numArray1[(int) index9] * 2] = (float) verts[(int) numArray1[(int) index9]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index9] * 2 + 1] = (float) verts[(int) numArray1[(int) index9]].v * textures[currentTexture].textureHRatio;
            data2[(int) numArray1[(int) index10] * 2] = (float) verts[(int) numArray1[(int) index10]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index10] * 2 + 1] = (float) verts[(int) numArray1[(int) index10]].v * textures[currentTexture].textureHRatio;
            data2[(int) numArray1[(int) index11] * 2] = (float) verts[(int) numArray1[(int) index11]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index11] * 2 + 1] = (float) verts[(int) numArray1[(int) index11]].v * textures[currentTexture].textureHRatio;
            short index12 = (short) ((int) command[5] / 2);
            short index13 = (short) ((int) command[6] / 2);
            short index14 = (short) ((int) command[7] / 2);
            ushortList.Add(numArray1[(int) index12]);
            ushortList.Add(numArray1[(int) index13]);
            ushortList.Add(numArray1[(int) index14]);
            data2[(int) numArray1[(int) index12] * 2] = (float) verts[(int) numArray1[(int) index12]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index12] * 2 + 1] = (float) verts[(int) numArray1[(int) index12]].v * textures[currentTexture].textureHRatio;
            data2[(int) numArray1[(int) index13] * 2] = (float) verts[(int) numArray1[(int) index13]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index13] * 2 + 1] = (float) verts[(int) numArray1[(int) index13]].v * textures[currentTexture].textureHRatio;
            data2[(int) numArray1[(int) index14] * 2] = (float) verts[(int) numArray1[(int) index14]].u * textures[currentTexture].textureWRatio;
            data2[(int) numArray1[(int) index14] * 2 + 1] = (float) verts[(int) numArray1[(int) index14]].v * textures[currentTexture].textureHRatio;
          }
        }
        ushort[] array1 = ushortList.ToArray();
        uint buffers1 = 0;
        if (this.usingARB)
        {
          OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(1, out buffers1);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, buffers1);
          OpenTK.Graphics.OpenGL.GL.Arb.BufferData<ushort>(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, (IntPtr) (array1.Length * 2), array1, OpenTK.Graphics.OpenGL.BufferUsageArb.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, 0);
        }
        else
        {
          OpenTK.Graphics.OpenGL.GL.GenBuffers(1, out buffers1);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, buffers1);
          OpenTK.Graphics.OpenGL.GL.BufferData<ushort>(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, (IntPtr) (array1.Length * 2), array1, OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, 0);
        }
        iboHandles.Add(buffers1);
        iboData.Add(array1);
        ushortList.Clear();
        if (this.usingARB)
        {
          OpenTK.Graphics.OpenGL.GL.Arb.GenBuffers(1, out vboTexCoordHandle);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, vboTexCoordHandle);
          OpenTK.Graphics.OpenGL.GL.Arb.BufferData<float>(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, (IntPtr) (data2.Length * 4), data2, OpenTK.Graphics.OpenGL.BufferUsageArb.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.Arb.BindBuffer(OpenTK.Graphics.OpenGL.BufferTargetArb.ArrayBuffer, 0);
        }
        else
        {
          OpenTK.Graphics.OpenGL.GL.GenBuffers(1, out vboTexCoordHandle);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, vboTexCoordHandle);
          OpenTK.Graphics.OpenGL.GL.BufferData<float>(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, (IntPtr) (data2.Length * 4), data2, OpenTK.Graphics.OpenGL.BufferUsageHint.StaticDraw);
          OpenTK.Graphics.OpenGL.GL.BindBuffer(OpenTK.Graphics.OpenGL.BufferTarget.ArrayBuffer, 0);
        }
      }
      catch (Exception ex)
      {
      }
    }

    public float[] DrawDLAnimationFrameVBO(
      ref byte[] bytesInFile,
      List<Bone> skeleton,
      float translationFactor,
      float[] vertexData)
    {
      float[] transformedVertexData = (float[]) vertexData.Clone();
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      F3DEX_VERT[] f3DexVertArray = new F3DEX_VERT[32];
      int[] cache = new int[32];
      Texture[] textures = new Texture[1];
      try
      {
        Stopwatch stopwatch = Stopwatch.StartNew();
        int collStart = 0;
        int VTCount = 0;
        int textureCount1 = 0;
        if (this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount1, ref f3DexVertArray, ref commands, ref textures))
        {
          stopwatch.Stop();
          long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
          stopwatch.Start();
          int num1 = ((int) bytesInFile[4] << 24) + ((int) bytesInFile[5] << 16) + ((int) bytesInFile[6] << 8) + (int) bytesInFile[7];
          int length1 = bytesInFile.Length;
          int amount = 8;
          List<ActiveBone> activeSkeleton = new List<ActiveBone>();
          if (num1 != 0)
          {
            for (int index = num1; index + 4 < length1; index += amount)
            {
              this.CalculateActiveBones(ref activeSkeleton, amount);
              amount = 8;
              switch ((int) bytesInFile[index + 2] + (int) bytesInFile[index + 3])
              {
                case 2:
                  activeSkeleton.Add(new ActiveBone(bytesInFile[index + 9], ((int) bytesInFile[index + 6] << 8) + (int) bytesInFile[index + 7]));
                  List<ActiveBone> activeBoneList1 = activeSkeleton;
                  if (activeBoneList1[activeBoneList1.Count - 1].length == 0)
                  {
                    if (activeSkeleton.Count == 1)
                    {
                      List<ActiveBone> activeBoneList2 = activeSkeleton;
                      activeBoneList2[activeBoneList2.Count - 1].length = 50331648;
                    }
                    else
                    {
                      List<ActiveBone> activeBoneList3 = activeSkeleton;
                      if (activeBoneList3[activeBoneList3.Count - 2].length == 0)
                      {
                        List<ActiveBone> activeBoneList4 = activeSkeleton;
                        activeBoneList4[activeBoneList4.Count - 1].length = 16777216;
                      }
                      else
                      {
                        List<ActiveBone> activeBoneList5 = activeSkeleton;
                        ActiveBone activeBone = activeBoneList5[activeBoneList5.Count - 1];
                        List<ActiveBone> activeBoneList6 = activeSkeleton;
                        int length2 = activeBoneList6[activeBoneList6.Count - 2].length;
                        activeBone.length = length2;
                      }
                    }
                  }
                  amount = 16;
                  break;
                case 3:
                  int start1 = ((int) bytesInFile[index + 8] << 8) + (int) bytesInFile[index + 9];
                  if (activeSkeleton.Count > 0)
                  {
                    List<Bone> skeleton1 = skeleton;
                    List<ActiveBone> activeBoneList7 = activeSkeleton;
                    this.RenderToEndDLVBO(skeleton1, skeleton1[(int) activeBoneList7[activeBoneList7.Count - 1].bone], (Bone) null, (int) activeSkeleton[0].bone, start1, -1, ref bytesInFile, ref commands, textureCount1, ref textures, ref f3DexVertArray, ref cache, ref vertexData, ref transformedVertexData, translationFactor);
                  }
                  else
                  {
                    List<Bone> skeleton2 = skeleton;
                    this.RenderToEndDLVBO(skeleton2, skeleton2[0], (Bone) null, 0, start1, -1, ref bytesInFile, ref commands, textureCount1, ref textures, ref f3DexVertArray, ref cache, ref vertexData, ref transformedVertexData, translationFactor);
                  }
                  amount = 16;
                  break;
                case 5:
                  int start2 = ((int) bytesInFile[index + 8] << 8) + (int) bytesInFile[index + 9];
                  int end1 = ((int) bytesInFile[index + 10] << 8) + (int) bytesInFile[index + 11];
                  if (activeSkeleton.Count >= 2)
                  {
                    List<Bone> skeleton3 = skeleton;
                    List<ActiveBone> activeBoneList8 = activeSkeleton;
                    Bone activeBone = skeleton3[(int) activeBoneList8[activeBoneList8.Count - 1].bone];
                    List<Bone> boneList = skeleton;
                    List<ActiveBone> activeBoneList9 = activeSkeleton;
                    int bone = (int) activeBoneList9[activeBoneList9.Count - 2].bone;
                    Bone parentBone = boneList[bone];
                    int start3 = start2;
                    int end2 = end1;
                    ref byte[] local1 = ref bytesInFile;
                    ref List<byte[]> local2 = ref commands;
                    int textureCount2 = textureCount1;
                    ref Texture[] local3 = ref textures;
                    ref F3DEX_VERT[] local4 = ref f3DexVertArray;
                    ref int[] local5 = ref cache;
                    ref float[] local6 = ref vertexData;
                    ref float[] local7 = ref transformedVertexData;
                    double translationFactor1 = (double) translationFactor;
                    this.RenderToEndDLVBO(skeleton3, activeBone, parentBone, 0, start3, end2, ref local1, ref local2, textureCount2, ref local3, ref local4, ref local5, ref local6, ref local7, (float) translationFactor1);
                  }
                  else if (activeSkeleton.Count > 1)
                  {
                    List<Bone> skeleton4 = skeleton;
                    List<ActiveBone> activeBoneList10 = activeSkeleton;
                    this.RenderToEndDLVBO(skeleton4, skeleton4[(int) activeBoneList10[activeBoneList10.Count - 1].bone], skeleton[(int) activeSkeleton[0].bone], 0, start2, end1, ref bytesInFile, ref commands, textureCount1, ref textures, ref f3DexVertArray, ref cache, ref vertexData, ref transformedVertexData, translationFactor);
                  }
                  else if (activeSkeleton.Count > 0)
                  {
                    List<Bone> skeleton5 = skeleton;
                    this.RenderToEndDLVBO(skeleton5, skeleton5[(int) activeSkeleton[0].bone], skeleton[0], 0, start2, end1, ref bytesInFile, ref commands, textureCount1, ref textures, ref f3DexVertArray, ref cache, ref vertexData, ref transformedVertexData, translationFactor);
                  }
                  else
                  {
                    List<Bone> skeleton6 = skeleton;
                    this.RenderToEndDLVBO(skeleton6, skeleton6[0], skeleton[0], 0, start2, end1, ref bytesInFile, ref commands, textureCount1, ref textures, ref f3DexVertArray, ref cache, ref vertexData, ref transformedVertexData, translationFactor);
                  }
                  amount = 24;
                  break;
                case 10:
                  amount = 16;
                  break;
                case 12:
                  int num2 = ((int) bytesInFile[index + 6] << 8) + (int) bytesInFile[index + 7];
                  amount = 16;
                  break;
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      return transformedVertexData;
    }

    private void RenderToEndDLVBO(
      List<Bone> skeleton,
      Bone activeBone,
      Bone parentBone,
      int activeRoot,
      int start,
      int end,
      ref byte[] bytesInFile,
      ref List<byte[]> commands,
      int textureCount,
      ref Texture[] textures,
      ref F3DEX_VERT[] f3d_verts,
      ref int[] cache,
      ref float[] vertexData,
      ref float[] transformedVertexData,
      float translationFactor)
    {
      Stopwatch stopwatch = Stopwatch.StartNew();
      try
      {
        List<Bone> hierarchy = end == -1 ? this.GetHierarchy(skeleton, activeBone) : this.GetHierarchy(skeleton, parentBone);
        stopwatch.Stop();
        long elapsedMilliseconds1 = stopwatch.ElapsedMilliseconds;
        stopwatch.Reset();
        stopwatch.Start();
        this.CalculateMatrix(hierarchy, translationFactor);
        stopwatch.Stop();
        long elapsedMilliseconds2 = stopwatch.ElapsedMilliseconds;
        int count = commands.Count;
        bool flag1 = true;
        bool flag2 = false;
        if (end > -1)
          flag1 = false;
        F3DEX_VERT[] f3DexVertArray = new F3DEX_VERT[64];
        for (int index1 = start; index1 < count; ++index1)
        {
          byte[] numArray1 = commands[index1];
          int num1 = (int) numArray1[4];
          int num2 = (int) numArray1[5];
          int num3 = (int) numArray1[6];
          int num4 = (int) numArray1[7];
          int num5 = (int) numArray1[1];
          int num6 = (int) numArray1[2];
          int num7 = (int) numArray1[3];
          if (numArray1[0] == (byte) 184)
          {
            if (flag1)
              break;
            index1 = end - 1;
            flag1 = true;
            flag2 = true;
            hierarchy = this.GetHierarchy(skeleton, activeBone);
            this.CalculateMatrix(hierarchy, translationFactor);
          }
          if (numArray1[0] == (byte) 4)
          {
            byte[] numArray2 = commands[index1];
            int num8 = (int) numArray1[4] * 16777216 + (int) numArray1[5] * 65536 + (int) numArray1[6] * 256 + (int) numArray1[7];
            int num9 = (int) numArray1[1];
            int num10 = (int) numArray1[2];
            int num11 = (int) numArray1[3];
            byte num12 = (byte) ((uint) numArray1[1] >> 1);
            byte num13 = (byte) ((uint) numArray1[2] >> 2);
            if (num12 > (byte) 63)
              num12 = (byte) 63;
            uint num14 = ((uint) (num8 << 8) >> 8) / 16U;
            try
            {
              for (int index2 = (int) num12; index2 < (int) num13 + (int) num12; ++index2)
              {
                if ((long) num14 < (long) f3d_verts.Length)
                  cache[index2] = (int) num14;
                ++num14;
              }
            }
            catch (Exception ex)
            {
            }
            if (!flag2)
              num12 = (byte) 0;
            if (activeBone != null)
            {
              for (int index3 = 0; index3 < hierarchy.Count; ++index3)
              {
                for (int index4 = (int) num12; index4 < (int) num13 + (int) num12; ++index4)
                {
                  int num15 = cache[index4];
                  Vector3 vector3_1 = new Vector3(transformedVertexData[num15 * 3], transformedVertexData[num15 * 3 + 1], transformedVertexData[num15 * 3 + 2]);
                  if (index3 == 0)
                    vector3_1 = new Vector3(vertexData[num15 * 3], vertexData[num15 * 3 + 1], vertexData[num15 * 3 + 2]);
                  Vector3 vector3_2 = hierarchy[index3].computedMatrix * vector3_1;
                  transformedVertexData[num15 * 3] = (float) (short) vector3_2.x;
                  transformedVertexData[num15 * 3 + 1] = (float) (short) vector3_2.y;
                  transformedVertexData[num15 * 3 + 2] = (float) (short) vector3_2.z;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    public float[] DrawVertAnimationFrameVBO(
      ref byte[] bytesInFile,
      List<Bone> skeleton,
      float translationFactor,
      float[] vertexData)
    {
      float[] numArray = (float[]) vertexData.Clone();
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      F3DEX_VERT[] f3DexVertArray = new F3DEX_VERT[32];
      Texture[] textures = new Texture[1];
      try
      {
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        if (this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
        {
          this.CalculateMatrix(skeleton, translationFactor);
          for (int index1 = 0; index1 < skeleton.Count; ++index1)
          {
            List<Bone> skeleton1 = skeleton;
            List<Bone> hierarchy = this.GetHierarchy(skeleton1, skeleton1[index1]);
            for (int index2 = 0; index2 < hierarchy.Count; ++index2)
            {
              foreach (int vert in skeleton[index1].verts)
              {
                if (vert < verts.Length)
                {
                  Vector3 vector3_1 = new Vector3(vertexData[vert * 3], vertexData[vert * 3 + 1], vertexData[vert * 3 + 2]);
                  Vector3 vector3_2 = hierarchy[index2].computedMatrix * vector3_1;
                  vertexData[vert * 3] = (float) (short) vector3_2.x;
                  vertexData[vert * 3 + 1] = (float) (short) vector3_2.y;
                  vertexData[vert * 3 + 2] = (float) (short) vector3_2.z;
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      return vertexData;
    }

    private List<Bone> GetHierarchy(List<Bone> skeleton, Bone activeBone)
    {
      List<Bone> hierarchy = new List<Bone>();
      hierarchy.Add(activeBone);
      bool flag = false;
      while (hierarchy[0].parent != (short) -1 && !flag)
      {
        foreach (Bone bone in skeleton)
        {
          if ((int) bone.id == (int) hierarchy[0].parent)
          {
            hierarchy.Insert(0, bone);
            flag = false;
            break;
          }
          flag = true;
        }
      }
      hierarchy.Reverse();
      return hierarchy;
    }

    private void CalculateMatrix(List<Bone> hierarchy, float translationFactor)
    {
      for (int index = 0; index < hierarchy.Count; ++index)
      {
        Bone bone = hierarchy[index];
        Matrix4 translationMatrix1 = Matrix4.GetTranslationMatrix(bone.frame_xTranslation * translationFactor, bone.frame_yTranslation * translationFactor, bone.frame_zTranslation * translationFactor);
        Matrix4 rotationMatrixX = Matrix4.GetRotationMatrixX(this.DegreeToRadian((double) bone.frame_xRotation));
        Matrix4 rotationMatrixY = Matrix4.GetRotationMatrixY(this.DegreeToRadian((double) bone.frame_yRotation));
        Matrix4 rotationMatrixZ = Matrix4.GetRotationMatrixZ(this.DegreeToRadian((double) bone.frame_zRotation));
        Matrix4 scaleMatrix = Matrix4.GetScaleMatrix(bone.frame_xScale, bone.frame_yScale, bone.frame_zScale);
        Matrix4 translationMatrix2 = Matrix4.GetTranslationMatrix(-bone.x, -bone.y, -bone.z);
        Matrix4 translationMatrix3 = Matrix4.GetTranslationMatrix(bone.x, bone.y, bone.z);
        Matrix4 matrix4_1 = translationMatrix1 * translationMatrix3;
        bone.transformOrder.Reverse();
        foreach (int num in bone.transformOrder)
        {
          if (num == 3)
            matrix4_1 *= rotationMatrixX;
          if (num == 4)
            matrix4_1 *= rotationMatrixY;
          if (num == 5)
            matrix4_1 *= rotationMatrixZ;
        }
        bone.transformOrder.Reverse();
        Matrix4 matrix4_2 = matrix4_1 * (scaleMatrix * translationMatrix2);
        bone.computedMatrix = matrix4_2;
      }
    }

    private void RenderToEndDL(
      List<Bone> skeleton,
      Bone activeBone,
      Bone parentBone,
      int activeRoot,
      int start,
      int end,
      ref byte[] bytesInFile,
      ref List<byte[]> commands,
      int textureCount,
      ref Texture[] textures,
      ref F3DEX_VERT[] f3d_verts,
      ref F3DEX_VERT[] cache,
      float translationFactor)
    {
      try
      {
        List<Bone> hierarchy = end == -1 ? this.GetHierarchy(skeleton, activeBone) : this.GetHierarchy(skeleton, parentBone);
        this.CalculateMatrix(hierarchy, translationFactor);
        int count = commands.Count;
        bool flag1 = true;
        bool flag2 = false;
        if (end > -1)
          flag1 = false;
        bool newTexture = false;
        int currentTexture = 0;
        float sScale = 0.0f;
        float tScale = 0.0f;
        F3DEX_VERT[] cache1 = new F3DEX_VERT[64];
        for (int index1 = start; index1 < count; ++index1)
        {
          byte[] command = commands[index1];
          uint w1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
          int num1 = (int) command[1];
          int num2 = (int) command[2];
          int num3 = (int) command[3];
          if (command[0] == (byte) 184)
          {
            this.f3dex.GL_EndDL(index1, commands.Count);
            newTexture = false;
            if (flag1)
              break;
            index1 = end - 1;
            flag1 = true;
            flag2 = true;
            hierarchy = this.GetHierarchy(skeleton, activeBone);
            this.CalculateMatrix(hierarchy, translationFactor);
          }
          if (command[0] == (byte) 253)
            this.f3dex.GL_G_SETTIMG(ref currentTexture, textureCount, w1, ref textures, commands[index1 + 2], ref newTexture, sScale, tScale);
          if (command[0] == (byte) 252)
            this.f3dex.GL_G_Combine(w1);
          if (command[0] == (byte) 183)
            this.f3dex.GL_SETGEOMETRYMODE(w1);
          if (command[0] == (byte) 245)
            this.f3dex.GL_G_SETTILE(command, ref textures[currentTexture]);
          if (command[0] == (byte) 240)
          {
            int palSize = (int) ((w1 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
            textures[currentTexture].loadPalette(bytesInFile, textureCount, palSize);
            if (commands[index1 + 4][0] == (byte) 186)
              newTexture = true;
          }
          if (command[0] == (byte) 187)
          {
            sScale = (float) (w1 >> 16) / 65536f;
            tScale = (float) (w1 & (uint) ushort.MaxValue) / 65536f;
          }
          if (command[0] == (byte) 4)
          {
            this.f3dex.GL_VTX(ref bytesInFile, commands[index1], ref cache, ref f3d_verts, ref textures[currentTexture], textureCount, ref this.texturesGL, ref newTexture);
            byte[] numArray = commands[index1];
            int num4 = (int) numArray[4];
            int num5 = (int) numArray[5];
            int num6 = (int) numArray[6];
            int num7 = (int) numArray[7];
            int num8 = (int) numArray[1];
            int num9 = (int) numArray[2];
            int num10 = (int) numArray[3];
            byte num11 = (byte) ((uint) numArray[1] >> 1);
            if (!flag2)
              num11 = (byte) 0;
            for (int index2 = (int) num11; index2 < cache.Length; ++index2)
            {
              if (cache[index2] != null)
              {
                F3DEX_VERT f3DexVert = F3DEX_VERT.Clone(cache[index2]);
                cache1[index2] = f3DexVert;
              }
            }
            if (activeBone != null)
            {
              for (int index3 = 0; index3 < hierarchy.Count; ++index3)
              {
                for (int index4 = (int) num11; index4 < cache1.Length; ++index4)
                {
                  if (cache1[index4] != null)
                  {
                    Vector3 vector3_1 = new Vector3((float) cache1[index4].x, (float) cache1[index4].y, (float) cache1[index4].z);
                    Vector3 vector3_2 = hierarchy[index3].computedMatrix * vector3_1;
                    cache1[index4].x = (short) vector3_2.x;
                    cache1[index4].y = (short) vector3_2.y;
                    cache1[index4].z = (short) vector3_2.z;
                  }
                }
              }
            }
          }
          if (command[0] == (byte) 191)
            this.f3dex.GL_TRI1(commands[index1], ref cache1, ref textures[currentTexture]);
          if (command[0] == (byte) 177)
            this.f3dex.GL_TRI2(commands[index1], ref cache1, ref textures[currentTexture]);
        }
      }
      catch (Exception ex)
      {
      }
    }

    private double DegreeToRadian(double angle) => Math.PI * angle / 180.0;

    private int GetParentBone(int parent, ref List<Bone> skeleton)
    {
      if (parent == 0 || parent == -1)
        return -1;
      for (int index = 0; index < skeleton.Count; ++index)
      {
        if ((int) skeleton[index].id == parent)
          return index;
      }
      return -1;
    }

    public void TranslateToGEOBJ(
      string dir,
      string outDir,
      int pntr_,
      ref string obj,
      ref string mtl)
    {
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      bool newTexture = false;
      int currentTexture = 0;
      float sScale = 0.0f;
      float tScale = 0.0f;
      int vtIndex1 = 1;
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      uint[] numArray1 = new uint[32];
      Texture[] textures = new Texture[1];
      int[] numArray2 = new int[32];
      bool flag1 = true;
      bool flag2 = false;
      try
      {
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(dir + pntr_.ToString("x"), FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] bytesInFile = new byte[length];
        binaryReader.BaseStream.Read(bytesInFile, 0, (int) length);
        binaryReader.Close();
        if (!this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
          return;
        int textureDataOffset = textures.Length * 16;
        obj = obj + "# Exported with Banjo's Backpack" + Environment.NewLine;
        obj = obj + "mtllib " + pntr_.ToString("x") + ".mtl" + Environment.NewLine;
        obj += GEOBJ.convertVerts(verts);
        for (int index1 = 0; index1 < F3DCommands; ++index1)
        {
          byte[] command = commands[index1];
          uint w1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
          int num1 = (int) command[1];
          int num2 = (int) command[2];
          int num3 = (int) command[3];
          if (command[0] == (byte) 182)
          {
            newTexture = false;
            flag1 = true;
          }
          if (command[0] == (byte) 6)
            obj = obj + "g " + index1.ToString("x") + Environment.NewLine;
          if (command[0] == (byte) 253)
          {
            this.f3dex.GL_G_SETTIMG(ref currentTexture, textureCount, w1, ref textures, commands[index1 + 2], ref newTexture, sScale, tScale);
            newTexture = true;
            flag1 = false;
          }
          if (command[0] == (byte) 245)
            this.f3dex.GL_G_SETTILE(command, ref textures[currentTexture]);
          if (command[0] == (byte) 240)
          {
            int palSize = (int) ((w1 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
            textures[currentTexture].loadPalette(bytesInFile, textureCount, palSize);
            if (commands[index1 + 4][0] == (byte) 186)
              newTexture = true;
          }
          if (command[0] == (byte) 187)
          {
            sScale = (float) (w1 >> 16) / 65536f;
            tScale = (float) (w1 & (uint) ushort.MaxValue) / 65536f;
          }
          if (command[0] == (byte) 4)
          {
            int num4 = (int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256 + (int) command[7];
            int num5 = (int) command[1];
            int num6 = (int) command[2];
            int num7 = (int) command[3];
            byte num8 = (byte) ((uint) command[1] >> 1);
            byte num9 = (byte) ((uint) command[2] >> 2);
            if (num8 > (byte) 63)
              num8 = (byte) 63;
            uint num10 = ((uint) (num4 << 8) >> 8) / 16U;
            try
            {
              for (int index2 = (int) num8; index2 < (int) num9 + (int) num8; ++index2)
              {
                if ((long) num10 < (long) verts.Length)
                  numArray1[index2] = num10;
                ++num10;
              }
            }
            catch (Exception ex)
            {
            }
            if (newTexture)
            {
              if (textures[currentTexture].pixels == null)
              {
                this.f3dex.ExportTexture(ref bytesInFile, ref textures[currentTexture], textureDataOffset);
                GEOBJ.writeTexture(outDir + "image_" + currentTexture.ToString("D4") + ".png", textures[currentTexture].pixels, textures[currentTexture].textureWidth, textures[currentTexture].textureHeight);
                mtl = mtl + "newmtl material_" + currentTexture.ToString("D4") + Environment.NewLine + "map_Kd image_" + currentTexture.ToString("D4") + ".png" + Environment.NewLine + Environment.NewLine;
              }
              obj = obj + "usemtl material_" + currentTexture.ToString("D4") + Environment.NewLine;
              newTexture = false;
            }
            if (flag1)
            {
              if (!flag2)
              {
                mtl = mtl + "newmtl material_null" + Environment.NewLine + Environment.NewLine;
                flag2 = true;
              }
              obj = obj + "usemtl material_null" + Environment.NewLine;
              flag1 = false;
            }
          }
          if (command[0] == (byte) 191)
          {
            short index3 = (short) ((int) command[5] / 2);
            short index4 = (short) ((int) command[6] / 2);
            short index5 = (short) ((int) command[7] / 2);
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index3]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index3]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index4]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index4]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index5]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index5]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj += GEOBJ.convertFace(numArray1[(int) index3] + 1U, numArray1[(int) index4] + 1U, numArray1[(int) index5] + 1U, vtIndex1);
            vtIndex1 += 3;
          }
          if (command[0] == (byte) 177)
          {
            short index6 = (short) ((int) command[1] / 2);
            short index7 = (short) ((int) command[2] / 2);
            short index8 = (short) ((int) command[3] / 2);
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index6]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index6]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index7]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index7]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index8]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index8]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj += GEOBJ.convertFace(numArray1[(int) index6] + 1U, numArray1[(int) index7] + 1U, numArray1[(int) index8] + 1U, vtIndex1);
            int vtIndex2 = vtIndex1 + 3;
            short index9 = (short) ((int) command[5] / 2);
            short index10 = (short) ((int) command[6] / 2);
            short index11 = (short) ((int) command[7] / 2);
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index9]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index9]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index10]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index10]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj = obj + "vt " + (object) ((float) verts[(int) numArray1[(int) index11]].u * textures[currentTexture].textureWRatio) + " " + (object) (float) ((double) verts[(int) numArray1[(int) index11]].v * (double) textures[currentTexture].textureHRatio * -1.0) + Environment.NewLine;
            obj += GEOBJ.convertFace(numArray1[(int) index9] + 1U, numArray1[(int) index10] + 1U, numArray1[(int) index11] + 1U, vtIndex2);
            vtIndex1 = vtIndex2 + 3;
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void TranslateToCollada(
      string dir,
      string outDir,
      int pntr_,
      List<Bone> skeleton,
      string filename)
    {
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      bool newTexture = false;
      int currentTexture = 0;
      float sScale = 0.0f;
      float tScale = 0.0f;
      int num1 = 0;
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      uint[] numArray1 = new uint[32];
      Texture[] textures = new Texture[1];
      int[] numArray2 = new int[32];
      bool flag1 = true;
      bool flag2 = false;
      try
      {
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(dir + pntr_.ToString("x"), FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] bytesInFile = new byte[length];
        binaryReader.BaseStream.Read(bytesInFile, 0, (int) length);
        binaryReader.Close();
        COLLADA collada1 = new COLLADA();
        asset asset = new asset()
        {
          contributor = new assetContributor[1]
          {
            new assetContributor()
            {
              author = "Skill",
              authoring_tool = "Banjo's Backpack"
            }
          },
          unit = new assetUnit()
        };
        asset.unit.name = "meter";
        asset.unit.meter = 1.0;
        asset.up_axis = UpAxisType.Y_UP;
        collada1.asset = asset;
        List<object> objectList1 = new List<object>();
        List<effect> effectList = new List<effect>();
        List<material> materialList = new List<material>();
        if (!this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
          return;
        int textureDataOffset = textures.Length * 16;
        source source1 = new source();
        source1.id = "object-mesh-positions";
        float_array floatArray1 = new float_array();
        floatArray1.id = "object-mesh-positions-array";
        floatArray1.count = (ulong) (((IEnumerable<F3DEX_VERT>) verts).Count<F3DEX_VERT>() * 3);
        source source2 = new source();
        source2.id = "object-mesh-colors";
        float_array floatArray2 = new float_array();
        floatArray2.id = "object-mesh-colors-array";
        floatArray2.count = (ulong) (((IEnumerable<F3DEX_VERT>) verts).Count<F3DEX_VERT>() * 4);
        double[] numArray3 = new double[((IEnumerable<F3DEX_VERT>) verts).Count<F3DEX_VERT>() * 3];
        double[] numArray4 = new double[((IEnumerable<F3DEX_VERT>) verts).Count<F3DEX_VERT>() * 4];
        int index1 = 0;
        int index2 = 0;
        int index3 = 0;
        while (index1 < verts.Length)
        {
          numArray3[index2] = (double) verts[index1].x;
          numArray3[index2 + 1] = (double) verts[index1].y;
          numArray3[index2 + 2] = (double) verts[index1].z;
          numArray4[index3] = (double) verts[index1].r;
          numArray4[index3 + 1] = (double) verts[index1].g;
          numArray4[index3 + 2] = (double) verts[index1].b;
          numArray4[index3 + 3] = (double) verts[index1].a;
          ++index1;
          index2 += 3;
          index3 += 4;
        }
        floatArray1.Values = numArray3;
        source1.Item = (object) floatArray1;
        floatArray2.Values = numArray4;
        source2.Item = (object) floatArray2;
        sourceTechnique_common sourceTechniqueCommon1 = new sourceTechnique_common();
        accessor accessor1 = new accessor();
        accessor1.source = "#object-mesh-positions-array";
        accessor1.stride = 3UL;
        accessor1.count = (ulong) (uint) ((IEnumerable<F3DEX_VERT>) verts).Count<F3DEX_VERT>();
        accessor1.param = new param[3]
        {
          new param() { name = "X", type = "float" },
          new param() { name = "Y", type = "float" },
          new param() { name = "Z", type = "float" }
        };
        sourceTechniqueCommon1.accessor = accessor1;
        source1.technique_common = sourceTechniqueCommon1;
        sourceTechnique_common sourceTechniqueCommon2 = new sourceTechnique_common();
        accessor accessor2 = new accessor();
        accessor2.source = "#object-mesh-colors-array";
        accessor2.stride = 4UL;
        accessor2.count = (ulong) (uint) ((IEnumerable<F3DEX_VERT>) verts).Count<F3DEX_VERT>();
        accessor2.param = new param[4]
        {
          new param() { name = "R", type = "float" },
          new param() { name = "G", type = "float" },
          new param() { name = "B", type = "float" },
          new param() { name = "A", type = "float" }
        };
        sourceTechniqueCommon2.accessor = accessor2;
        source2.technique_common = sourceTechniqueCommon2;
        vertices vertices = new vertices();
        vertices.id = "object-mesh-vertices";
        vertices.input = new InputLocal[1]
        {
          new InputLocal()
          {
            semantic = "POSITION",
            source = "#object-mesh-positions"
          }
        };
        List<string> stringList1 = new List<string>();
        List<string> stringList2 = new List<string>();
        List<string> stringList3 = new List<string>();
        List<uint> uintList = new List<uint>();
        string str1 = "";
        string str2 = "";
        uint num2 = 0;
        List<double> source3 = new List<double>();
        List<image> imageList = new List<image>();
        for (int index4 = 0; index4 < F3DCommands; ++index4)
        {
          byte[] command = commands[index4];
          uint w1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
          int num3 = (int) command[1];
          int num4 = (int) command[2];
          int num5 = (int) command[3];
          if (command[0] == (byte) 182)
          {
            newTexture = false;
            flag1 = true;
          }
          int num6 = (int) command[0];
          if (command[0] == (byte) 253)
          {
            this.f3dex.GL_G_SETTIMG(ref currentTexture, textureCount, w1, ref textures, commands[index4 + 2], ref newTexture, sScale, tScale);
            newTexture = true;
            flag1 = false;
          }
          if (command[0] == (byte) 245)
            this.f3dex.GL_G_SETTILE(command, ref textures[currentTexture]);
          if (command[0] == (byte) 240)
          {
            int palSize = (int) ((w1 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
            textures[currentTexture].loadPalette(bytesInFile, textureCount, palSize);
            if (commands[index4 + 4][0] == (byte) 186)
              newTexture = true;
          }
          if (command[0] == (byte) 187)
          {
            sScale = (float) (w1 >> 16) / 65536f;
            tScale = (float) (w1 & (uint) ushort.MaxValue) / 65536f;
          }
          if (command[0] == (byte) 4)
          {
            int num7 = (int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256 + (int) command[7];
            int num8 = (int) command[1];
            int num9 = (int) command[2];
            int num10 = (int) command[3];
            byte num11 = (byte) ((uint) command[1] >> 1);
            byte num12 = (byte) ((uint) command[2] >> 2);
            if (num11 > (byte) 63)
              num11 = (byte) 63;
            uint num13 = ((uint) (num7 << 8) >> 8) / 16U;
            try
            {
              for (int index5 = (int) num11; index5 < (int) num12 + (int) num11; ++index5)
              {
                if ((long) num13 < (long) verts.Length)
                  numArray1[index5] = num13;
                ++num13;
              }
            }
            catch (Exception ex)
            {
            }
            if (newTexture)
            {
              string str3 = "image_" + currentTexture.ToString("D4") + "_png";
              string str4 = "Material_" + currentTexture.ToString("D4") + "-effect";
              string str5 = "Material_" + currentTexture.ToString("D4") + "-material";
              if (textures[currentTexture].pixels == null)
              {
                this.f3dex.ExportTexture(ref bytesInFile, ref textures[currentTexture], textureDataOffset);
                string str6 = "image_" + currentTexture.ToString("D4") + ".png";
                GEOBJ.writeTexture(outDir + str6, textures[currentTexture].pixels, textures[currentTexture].textureWidth, textures[currentTexture].textureHeight);
                imageList.Add(new image()
                {
                  id = str3,
                  name = str3,
                  Item = (object) str6
                });
                effect effect = new effect()
                {
                  id = str4
                };
                effectFx_profile_abstractProfile_COMMON abstractProfileCommon = new effectFx_profile_abstractProfile_COMMON();
                common_newparam_type commonNewparamType1 = new common_newparam_type();
                common_newparam_type commonNewparamType2 = new common_newparam_type();
                commonNewparamType1.sid = str6 + "-surface";
                commonNewparamType2.sid = str6 + "-sampler";
                fx_surface_common fxSurfaceCommon = new fx_surface_common();
                fxSurfaceCommon.type = fx_surface_type_enum.Item2D;
                fxSurfaceCommon.init_from = new fx_surface_init_from_common[1]
                {
                  new fx_surface_init_from_common() { Value = str3 }
                };
                commonNewparamType1.Item = (object) fxSurfaceCommon;
                commonNewparamType1.ItemElementName = ItemChoiceType.surface;
                commonNewparamType2.Item = (object) new fx_sampler2D_common()
                {
                  source = commonNewparamType1.sid
                };
                commonNewparamType2.ItemElementName = ItemChoiceType.sampler2D;
                effectFx_profile_abstractProfile_COMMONTechniquePhong commonTechniquePhong = new effectFx_profile_abstractProfile_COMMONTechniquePhong()
                {
                  diffuse = new common_color_or_texture_type()
                  {
                    Item = (object) new common_color_or_texture_typeTexture()
                    {
                      texture = (str6 + "-sampler"),
                      texcoord = "object-mesh-map"
                    }
                  }
                };
                abstractProfileCommon.technique = new effectFx_profile_abstractProfile_COMMONTechnique()
                {
                  Item = (object) commonTechniquePhong,
                  sid = "common"
                };
                abstractProfileCommon.Items = new object[2]
                {
                  (object) commonNewparamType1,
                  (object) commonNewparamType2
                };
                effect.Items = new effectFx_profile_abstractProfile_COMMON[1]
                {
                  abstractProfileCommon
                };
                effectList.Add(effect);
                materialList.Add(new material()
                {
                  id = str5,
                  instance_effect = new instance_effect()
                  {
                    url = "#" + str4
                  }
                });
              }
              if (str1.Length > 1)
              {
                string str7 = str1.Substring(0, str1.Length - 1);
                string str8 = str2.Substring(0, str2.Length - 1);
                stringList2.Add(str7);
                stringList1.Add(str8);
                uintList.Add(num2);
              }
              stringList3.Add(str5);
              str1 = "";
              str2 = "";
              num2 = 0U;
              newTexture = false;
            }
            if (flag1)
            {
              int num14 = flag2 ? 1 : 0;
              if (str1.Length > 1)
              {
                string str9 = str2.Substring(0, str2.Length - 1);
                string str10 = str1.Substring(0, str1.Length - 1);
                stringList2.Add(str10);
                stringList1.Add(str9);
                uintList.Add(num2);
                stringList3.Add("");
                str1 = "";
                str2 = "";
                num2 = 0U;
              }
              else
                stringList3.Add("");
              newTexture = false;
              flag1 = false;
            }
          }
          if (command[0] == (byte) 191)
          {
            short index6 = (short) ((int) command[5] / 2);
            short index7 = (short) ((int) command[6] / 2);
            short index8 = (short) ((int) command[7] / 2);
            str1 += string.Format("{0} {0} {3} {1} {1} {4} {2} {2} {5} ", (object) numArray1[(int) index6], (object) numArray1[(int) index7], (object) numArray1[(int) index8], (object) num1, (object) (num1 + 1), (object) (num1 + 2));
            str2 += "3 ";
            ++num2;
            source3.Add((double) verts[(int) numArray1[(int) index6]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index6]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            source3.Add((double) verts[(int) numArray1[(int) index7]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index7]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            source3.Add((double) verts[(int) numArray1[(int) index8]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index8]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            num1 += 3;
          }
          if (command[0] == (byte) 177)
          {
            short index9 = (short) ((int) command[1] / 2);
            short index10 = (short) ((int) command[2] / 2);
            short index11 = (short) ((int) command[3] / 2);
            string str11 = str1 + string.Format("{0} {0} {3} {1} {1} {4} {2} {2} {5} ", (object) numArray1[(int) index9], (object) numArray1[(int) index10], (object) numArray1[(int) index11], (object) num1, (object) (num1 + 1), (object) (num1 + 2));
            string str12 = str2 + "3 ";
            source3.Add((double) verts[(int) numArray1[(int) index9]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index9]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            source3.Add((double) verts[(int) numArray1[(int) index10]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index10]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            source3.Add((double) verts[(int) numArray1[(int) index11]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index11]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            int num15 = num1 + 3;
            short index12 = (short) ((int) command[5] / 2);
            short index13 = (short) ((int) command[6] / 2);
            short index14 = (short) ((int) command[7] / 2);
            str1 = str11 + string.Format("{0} {0} {3} {1} {1} {4} {2} {2} {5} ", (object) numArray1[(int) index12], (object) numArray1[(int) index13], (object) numArray1[(int) index14], (object) num15, (object) (num15 + 1), (object) (num15 + 2));
            str2 = str12 + "3 ";
            num2 += 2U;
            source3.Add((double) verts[(int) numArray1[(int) index12]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index12]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            source3.Add((double) verts[(int) numArray1[(int) index13]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index13]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            source3.Add((double) verts[(int) numArray1[(int) index14]].u * (double) textures[currentTexture].textureWRatio);
            source3.Add((double) verts[(int) numArray1[(int) index14]].v * (double) textures[currentTexture].textureHRatio * -1.0);
            num1 = num15 + 3;
          }
        }
        if (str1.Length > 1)
        {
          string str13 = str1.Substring(0, str1.Length - 1);
          string str14 = str2.Substring(0, str2.Length - 1);
          stringList2.Add(str13);
          stringList1.Add(str14);
          uintList.Add(num2);
        }
        source source4 = new source();
        source4.id = "object-mesh-map";
        source4.Item = (object) new float_array()
        {
          id = "object-mesh-map-0-array",
          count = (ulong) source3.Count<double>(),
          Values = source3.ToArray()
        };
        sourceTechnique_common sourceTechniqueCommon3 = new sourceTechnique_common();
        accessor accessor3 = new accessor();
        accessor3.source = "#object-mesh-map-0-array";
        accessor3.stride = 2UL;
        accessor3.count = (ulong) (uint) (source3.Count<double>() / 2);
        accessor3.param = new param[2]
        {
          new param() { name = "S", type = "float" },
          new param() { name = "T", type = "float" }
        };
        sourceTechniqueCommon3.accessor = accessor3;
        source4.technique_common = sourceTechniqueCommon3;
        mesh mesh = new mesh();
        mesh.source = new source[3]
        {
          source1,
          source2,
          source4
        };
        mesh.vertices = vertices;
        List<object> objectList2 = new List<object>();
        for (int index15 = 0; index15 < stringList2.Count; ++index15)
        {
          polylist polylist = new polylist();
          polylist.input = new InputLocalOffset[3]
          {
            new InputLocalOffset()
            {
              semantic = "VERTEX",
              source = "#object-mesh-positions"
            },
            new InputLocalOffset()
            {
              semantic = "COLOR",
              source = "#object-mesh-colors",
              offset = 1UL
            },
            new InputLocalOffset()
            {
              semantic = "TEXCOORD",
              source = "#object-mesh-map",
              offset = 2UL
            }
          };
          polylist.vcount = stringList1[index15];
          polylist.p = stringList2[index15];
          polylist.count = (ulong) uintList[index15];
          if (stringList3[index15] != "")
            polylist.material = stringList3[index15];
          objectList2.Add((object) polylist);
        }
        mesh.Items = objectList2.ToArray();
        geometry geometry = new geometry();
        geometry.id = "object-mesh";
        geometry.name = "object";
        geometry.Item = (object) mesh;
        library_materials libraryMaterials = new library_materials();
        libraryMaterials.material = materialList.ToArray();
        library_geometries libraryGeometries = new library_geometries();
        libraryGeometries.geometry = new geometry[1]
        {
          geometry
        };
        library_images libraryImages = new library_images();
        libraryImages.image = imageList.ToArray();
        library_effects libraryEffects = new library_effects();
        libraryEffects.effect = effectList.ToArray();
        objectList1.Add((object) libraryImages);
        objectList1.Add((object) libraryEffects);
        objectList1.Add((object) libraryMaterials);
        objectList1.Add((object) libraryGeometries);
        library_visual_scenes libraryVisualScenes = new library_visual_scenes();
        visual_scene visualScene = new visual_scene()
        {
          name = "Scene",
          id = "Scene"
        };
        node node1 = new node()
        {
          id = "sobject",
          name = "sobject",
          type = NodeType.NODE
        };
        List<instance_material> instanceMaterialList = new List<instance_material>();
        for (int index16 = 0; index16 < materialList.Count; ++index16)
        {
          instance_materialBind_vertex_input materialBindVertexInput = new instance_materialBind_vertex_input()
          {
            semantic = "object-mesh-map",
            input_semantic = "TEXCOORD",
            input_set = 0
          };
          instanceMaterialList.Add(new instance_material()
          {
            symbol = materialList[index16].id,
            target = "#" + materialList[index16].id,
            bind_vertex_input = new instance_materialBind_vertex_input[1]
            {
              materialBindVertexInput
            }
          });
        }
        node1.instance_geometry = new instance_geometry[1]
        {
          new instance_geometry()
          {
            url = "#object-mesh",
            bind_material = new bind_material()
            {
              technique_common = instanceMaterialList.ToArray()
            }
          }
        };
        node node2 = new node()
        {
          id = "Armature",
          name = "Armature",
          type = NodeType.NODE
        };
        List<node> bones = new List<node>();
        List<ItemsChoiceType2> itemsChoiceType2List = new List<ItemsChoiceType2>();
        List<int> intList = new List<int>();
        intList.Add(-1);
        for (int index17 = 0; index17 < skeleton.Count; ++index17)
        {
          Bone b = skeleton[index17];
          Bone p = new Bone((short) 0, (short) 0, (short) 0, 0.0f, 0.0f, 0.0f);
          if (b.parent != (short) -1)
          {
            foreach (Bone bone in skeleton)
            {
              if ((int) bone.id == (int) b.parent)
              {
                p = bone;
                break;
              }
            }
          }
          node collada2 = this.BKBoneToCollada(index17, b, p);
          bones.Add(collada2);
        }
        int index18 = 0;
        int index19 = 0;
        while (index18 < bones.Count)
        {
          if (intList.Contains((int) skeleton[index19].parent))
          {
            node parent = this.FindParent(bones, (int) skeleton[index19].parent, (node) null);
            if (parent != null)
            {
              List<node> nodeList = new List<node>();
              if (parent.node1 != null)
                nodeList = ((IEnumerable<node>) parent.node1).ToList<node>();
              nodeList.Add(bones[index18]);
              parent.node1 = nodeList.ToArray();
              intList.Add((int) skeleton[index19].id);
              bones.RemoveAt(index18);
              --index18;
            }
            else
              intList.Add((int) skeleton[index19].id);
          }
          ++index18;
          ++index19;
        }
        node2.node1 = bones.ToArray();
        visualScene.node = new node[2]{ node1, node2 };
        libraryVisualScenes.visual_scene = new visual_scene[1]
        {
          visualScene
        };
        objectList1.Add((object) libraryVisualScenes);
        COLLADAScene colladaScene = new COLLADAScene()
        {
          instance_visual_scene = new InstanceWithExtra()
          {
            url = "#Scene"
          }
        };
        collada1.scene = colladaScene;
        collada1.Items = objectList1.ToArray();
        collada1.Save(filename);
      }
      catch (Exception ex)
      {
      }
    }

    private node FindParent(List<node> bones, int parent, node bone)
    {
      if (bone == null)
      {
        foreach (node bone1 in bones)
        {
          if (bone1.id == "Bone_" + (object) parent)
            return bone1;
          if (bone1.node1 != null)
            bone = this.FindParent(((IEnumerable<node>) bone1.node1).ToList<node>(), parent, bone);
          if (bone != null)
            break;
        }
      }
      return bone;
    }

    public node BKBoneToCollada(int bi, Bone b, Bone p)
    {
      node collada = new node()
      {
        id = "Bone_" + bi.ToString(),
        name = "Bone." + bi.ToString(),
        sid = "Bone_" + bi.ToString(),
        type = NodeType.JOINT
      };
      collada.Items = new object[1]
      {
        (object) new matrix()
        {
          sid = "transform",
          Values = new double[16]
          {
            1.0,
            0.0,
            0.0,
            (double) b.x - (double) p.x,
            0.0,
            1.0,
            0.0,
            (double) b.y - (double) p.y,
            0.0,
            0.0,
            1.0,
            (double) b.z - (double) p.z,
            0.0,
            0.0,
            0.0,
            1.0
          }
        }
      };
      collada.ItemsElementName = new ItemsChoiceType2[1]
      {
        ItemsChoiceType2.matrix
      };
      return collada;
    }

    public BoundingBox DrawModelFile(
      string dir,
      int pntr_,
      float x_,
      float y_,
      float z_,
      int rot_,
      float size,
      ushort radius,
      bool selected,
      bool hasJiggy,
      uint jiggyDList)
    {
      BoundingBox boundingBox = new BoundingBox();
      size /= 100f;
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      bool newTexture = false;
      int currentTexture = 0;
      float sScale = 0.0f;
      float tScale = 0.0f;
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      F3DEX_VERT[] cache = new F3DEX_VERT[32];
      Texture[] textures = new Texture[1];
      try
      {
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(dir + pntr_.ToString("x"), FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] bytesInFile = new byte[length];
        binaryReader.BaseStream.Read(bytesInFile, 0, (int) length);
        binaryReader.Close();
        if (!this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
          return boundingBox;
        int index1 = vertStart - 24;
        int num1 = (int) (short) ((int) bytesInFile[index1] * 256 + (int) bytesInFile[index1 + 1]);
        int num2 = (int) (short) ((int) bytesInFile[index1 + 2] * 256 + (int) bytesInFile[index1 + 3]);
        int num3 = (int) (short) ((int) bytesInFile[index1 + 4] * 256 + (int) bytesInFile[index1 + 5]);
        int num4 = (int) (short) ((int) bytesInFile[index1 + 6] * 256 + (int) bytesInFile[index1 + 7]);
        int num5 = (int) (short) ((int) bytesInFile[index1 + 8] * 256 + (int) bytesInFile[index1 + 9]);
        int num6 = (int) (short) ((int) bytesInFile[index1 + 10] * 256 + (int) bytesInFile[index1 + 11]);
        boundingBox.smallX = num1;
        boundingBox.smallY = num2;
        boundingBox.smallZ = num3;
        boundingBox.largeX = num4;
        boundingBox.largeY = num5;
        boundingBox.largeZ = num6;
        OpenTK.Graphics.OpenGL.GL.PushMatrix();
        OpenTK.Graphics.OpenGL.GL.Translate(x_, y_, z_);
        switch (pntr_)
        {
          case 32808:
          case 34432:
            OpenTK.Graphics.OpenGL.GL.Rotate((float) rot_, 0.0f, 0.0f, 1f);
            goto case 32872;
          case 32872:
            double num7 = (double) size;
            OpenTK.Graphics.OpenGL.GL.Scale((float) num7, (float) num7, (float) num7);
            for (int index2 = 0; index2 < F3DCommands; ++index2)
            {
              byte[] command = commands[index2];
              uint w1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
              int num8 = (int) command[1];
              int num9 = (int) command[2];
              int num10 = (int) command[3];
              if (command[0] == (byte) 184)
              {
                this.f3dex.GL_EndDL(index2, commands.Count);
                newTexture = false;
              }
              if (command[0] == (byte) 253)
                this.f3dex.GL_G_SETTIMG(ref currentTexture, textureCount, w1, ref textures, commands[index2 + 2], ref newTexture, sScale, tScale);
              if (command[0] == (byte) 252)
                this.f3dex.GL_G_Combine(w1);
              if (command[0] == (byte) 183)
                this.f3dex.GL_SETGEOMETRYMODE(w1);
              if (command[0] == (byte) 245)
                this.f3dex.GL_G_SETTILE(command, ref textures[currentTexture]);
              if (command[0] == (byte) 240)
              {
                int palSize = (int) ((w1 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
                textures[currentTexture].loadPalette(bytesInFile, textureCount, palSize);
                if (commands[index2 + 4][0] == (byte) 186)
                  newTexture = true;
              }
              if (command[0] == (byte) 187)
              {
                sScale = (float) (w1 >> 16) / 65536f;
                tScale = (float) (w1 & (uint) ushort.MaxValue) / 65536f;
              }
              if (command[0] == (byte) 4)
                this.f3dex.GL_VTX(ref bytesInFile, commands[index2], ref cache, ref verts, ref textures[currentTexture], textureCount, ref this.texturesGL, ref newTexture);
              if (command[0] == (byte) 191)
                this.f3dex.GL_TRI1(commands[index2], ref cache, ref textures[currentTexture]);
              if (command[0] == (byte) 177)
                this.f3dex.GL_TRI2(commands[index2], ref cache, ref textures[currentTexture]);
            }
            if (hasJiggy)
            {
              OpenTK.Graphics.OpenGL.GL.Translate(0.0f, (float) boundingBox.largeY, 0.0f);
              OpenTK.Graphics.OpenGL.GL.CallList(jiggyDList);
            }
            if (radius != (ushort) 0 && this.drawWarpRadius)
            {
              this.wire = OpenTK.Graphics.Glu.NewQuadric();
              OpenTK.Graphics.Glu.QuadricDrawStyle(this.wire, QuadricDrawStyle.Line);
              OpenTK.Graphics.Glu.Sphere(this.wire, (double) radius, 5, 5);
              OpenTK.Graphics.Glu.DeleteQuadric(this.wire);
            }
            OpenTK.Graphics.OpenGL.GL.PopMatrix();
            return boundingBox;
          default:
            OpenTK.Graphics.OpenGL.GL.Rotate((float) rot_, 0.0f, 1f, 0.0f);
            goto case 32872;
        }
      }
      catch (Exception ex)
      {
      }
      return boundingBox;
    }

    public List<uint> DrawModelFile(
      string dir,
      int pntr_,
      float x_,
      float y_,
      float z_,
      int rot_,
      float size)
    {
      List<uint> uintList = new List<uint>();
      size /= 100f;
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      bool newTexture = false;
      int currentTexture = 0;
      float sScale = 0.0f;
      float tScale = 0.0f;
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      F3DEX_VERT[] cache = new F3DEX_VERT[32];
      Texture[] textures = new Texture[1];
      try
      {
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(dir + pntr_.ToString("x"), FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] bytesInFile = new byte[length];
        binaryReader.BaseStream.Read(bytesInFile, 0, (int) length);
        binaryReader.Close();
        if (!this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
          return uintList;
        int index1 = vertStart - 24;
        int num1 = (int) bytesInFile[index1];
        int num2 = (int) bytesInFile[index1 + 1];
        int num3 = (int) bytesInFile[index1 + 2];
        int num4 = (int) bytesInFile[index1 + 3];
        int num5 = (int) bytesInFile[index1 + 4];
        int num6 = (int) bytesInFile[index1 + 5];
        int num7 = (int) bytesInFile[index1 + 6];
        int num8 = (int) bytesInFile[index1 + 7];
        int num9 = (int) bytesInFile[index1 + 8];
        int num10 = (int) bytesInFile[index1 + 9];
        int num11 = (int) bytesInFile[index1 + 10];
        int num12 = (int) bytesInFile[index1 + 11];
        OpenTK.Graphics.OpenGL.GL.PushMatrix();
        OpenTK.Graphics.OpenGL.GL.Translate(x_, y_, z_);
        switch (pntr_)
        {
          case 32808:
          case 34432:
            OpenTK.Graphics.OpenGL.GL.Rotate((float) rot_, 0.0f, 0.0f, 1f);
            goto case 32872;
          case 32872:
            double num13 = (double) size;
            OpenTK.Graphics.OpenGL.GL.Scale((float) num13, (float) num13, (float) num13);
            for (int index2 = 0; index2 < F3DCommands; ++index2)
            {
              byte[] command = commands[index2];
              uint w1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
              int num14 = (int) command[1];
              int num15 = (int) command[2];
              int num16 = (int) command[3];
              if (command[0] == (byte) 184)
              {
                this.f3dex.GL_EndDL(index2, commands.Count);
                newTexture = false;
              }
              if (command[0] == (byte) 253)
                this.f3dex.GL_G_SETTIMG(ref currentTexture, textureCount, w1, ref textures, commands[index2 + 2], ref newTexture, sScale, tScale);
              if (command[0] == (byte) 252)
                this.f3dex.GL_G_Combine(w1);
              if (command[0] == (byte) 183)
                this.f3dex.GL_SETGEOMETRYMODE(w1);
              if (command[0] == (byte) 245)
                this.f3dex.GL_G_SETTILE(command, ref textures[currentTexture]);
              if (command[0] == (byte) 240)
              {
                int palSize = (int) ((w1 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
                textures[currentTexture].loadPalette(bytesInFile, textureCount, palSize);
                if (commands[index2 + 4][0] == (byte) 186)
                  newTexture = true;
              }
              if (command[0] == (byte) 187)
              {
                sScale = (float) (w1 >> 16) / 65536f;
                tScale = (float) (w1 & (uint) ushort.MaxValue) / 65536f;
              }
              if (command[0] == (byte) 4)
                this.f3dex.GL_VTX(ref bytesInFile, commands[index2], ref cache, ref verts, ref textures[currentTexture], textureCount, ref this.texturesGL, ref newTexture);
              if (command[0] == (byte) 191)
                this.f3dex.GL_TRI1(commands[index2], ref cache, ref textures[currentTexture]);
              if (command[0] == (byte) 177)
                this.f3dex.GL_TRI2(commands[index2], ref cache, ref textures[currentTexture]);
            }
            OpenTK.Graphics.OpenGL.GL.PopMatrix();
            return uintList;
          default:
            OpenTK.Graphics.OpenGL.GL.Rotate((float) rot_, 0.0f, 1f, 0.0f);
            goto case 32872;
        }
      }
      catch (Exception ex)
      {
      }
      return uintList;
    }

    public BoundingBox DrawModelFile(
      string model_,
      float x_,
      float y_,
      float z_,
      int rot_,
      float size,
      ushort radius,
      bool selected)
    {
      BoundingBox boundingBox = new BoundingBox();
      size /= 100f;
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      bool newTexture = false;
      int currentTexture = 0;
      float sScale = 0.0f;
      float tScale = 0.0f;
      Texture[] textures = new Texture[1];
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      F3DEX_VERT[] cache = new F3DEX_VERT[32];
      if (!File.Exists(model_))
        return boundingBox;
      try
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(model_, FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] bytesInFile = new byte[length];
        binaryReader.BaseStream.Read(bytesInFile, 0, (int) length);
        binaryReader.Close();
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        if (!this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
          return boundingBox;
        int index1 = vertStart - 24;
        int num1 = (int) (short) ((int) bytesInFile[index1] * 256 + (int) bytesInFile[index1 + 1]);
        int num2 = (int) (short) ((int) bytesInFile[index1 + 2] * 256 + (int) bytesInFile[index1 + 3]);
        int num3 = (int) (short) ((int) bytesInFile[index1 + 4] * 256 + (int) bytesInFile[index1 + 5]);
        int num4 = (int) (short) ((int) bytesInFile[index1 + 6] * 256 + (int) bytesInFile[index1 + 7]);
        int num5 = (int) (short) ((int) bytesInFile[index1 + 8] * 256 + (int) bytesInFile[index1 + 9]);
        int num6 = (int) (short) ((int) bytesInFile[index1 + 10] * 256 + (int) bytesInFile[index1 + 11]);
        boundingBox.smallX = num1;
        boundingBox.smallY = num2;
        boundingBox.smallZ = num3;
        boundingBox.largeX = num4;
        boundingBox.largeY = num5;
        boundingBox.largeZ = num6;
        int num7 = F3DStart;
        for (int index2 = 0; index2 < F3DCommands; ++index2)
        {
          byte[] numArray = new byte[8];
          for (int index3 = 0; index3 < 8; ++index3)
            numArray[index3] = bytesInFile[num7 + index3];
          commands.Add(numArray);
          num7 += 8;
        }
        OpenTK.Graphics.OpenGL.GL.PushMatrix();
        OpenTK.Graphics.OpenGL.GL.Translate(x_, y_, z_);
        OpenTK.Graphics.OpenGL.GL.Rotate((float) rot_, 0.0f, 1f, 0.0f);
        double num8 = (double) size;
        OpenTK.Graphics.OpenGL.GL.Scale((float) num8, (float) num8, (float) num8);
        for (int index4 = 0; index4 < F3DCommands; ++index4)
        {
          byte[] command = commands[index4];
          uint w1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
          int num9 = (int) command[1];
          int num10 = (int) command[2];
          int num11 = (int) command[3];
          if (command[0] == (byte) 184)
          {
            this.f3dex.GL_EndDL(index4, commands.Count);
            newTexture = false;
          }
          if (command[0] == (byte) 253)
            this.f3dex.GL_G_SETTIMG(ref currentTexture, textureCount, w1, ref textures, commands[index4 + 2], ref newTexture, sScale, tScale);
          if (command[0] == (byte) 252)
            this.f3dex.GL_G_Combine(w1);
          if (command[0] == (byte) 183)
            this.f3dex.GL_SETGEOMETRYMODE(w1);
          if (command[0] == (byte) 245)
            this.f3dex.GL_G_SETTILE(command, ref textures[currentTexture]);
          if (command[0] == (byte) 240)
          {
            int palSize = (int) ((w1 << 8 >> 8 & 16773120U) >> 14) * 2 + 2;
            textures[currentTexture].loadPalette(bytesInFile, textureCount, palSize);
            if (commands[index4 + 4][0] == (byte) 186)
              newTexture = true;
          }
          if (command[0] == (byte) 187)
          {
            sScale = (float) (w1 >> 16) / 65536f;
            tScale = (float) (w1 & (uint) ushort.MaxValue) / 65536f;
          }
          if (command[0] == (byte) 4)
            this.f3dex.GL_VTX(ref bytesInFile, commands[index4], ref cache, ref verts, ref textures[currentTexture], textureCount, ref this.texturesGL, ref newTexture);
          if (command[0] == (byte) 191)
            this.f3dex.GL_TRI1(commands[index4], ref cache, ref textures[currentTexture]);
          if (command[0] == (byte) 177)
            this.f3dex.GL_TRI2(commands[index4], ref cache, ref textures[currentTexture]);
        }
        if (radius != (ushort) 0)
        {
          if (this.drawWarpRadius && model_.Contains("warp"))
          {
            OpenTK.Graphics.OpenGL.GL.Color3(1f, 1f, 1f);
            this.wire = OpenTK.Graphics.Glu.NewQuadric();
            OpenTK.Graphics.Glu.QuadricDrawStyle(this.wire, QuadricDrawStyle.Line);
            OpenTK.Graphics.Glu.Sphere(this.wire, (double) radius, 5, 5);
            OpenTK.Graphics.Glu.DeleteQuadric(this.wire);
          }
          if (this.drawEnemyRadius && model_.Contains("enemy_marker"))
          {
            OpenTK.Graphics.OpenGL.GL.Color3(1f, 0.0f, 0.0f);
            this.wire = OpenTK.Graphics.Glu.NewQuadric();
            OpenTK.Graphics.Glu.QuadricDrawStyle(this.wire, QuadricDrawStyle.Line);
            OpenTK.Graphics.Glu.Sphere(this.wire, (double) radius, 5, 5);
            OpenTK.Graphics.Glu.DeleteQuadric(this.wire);
          }
        }
        OpenTK.Graphics.OpenGL.GL.PopMatrix();
        return boundingBox;
      }
      catch (Exception ex)
      {
      }
      return boundingBox;
    }

    public void unProject(
      float xrot,
      float yrot,
      float xpos,
      float ypos,
      float zpos,
      int x,
      int y,
      out double posX,
      out double posY,
      out double posZ,
      float depth)
    {
      OpenTK.Graphics.OpenGL.GL.MatrixMode(OpenTK.Graphics.OpenGL.MatrixMode.Modelview);
      OpenTK.Graphics.OpenGL.GL.LoadIdentity();
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Fog);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Lighting);
      OpenTK.Graphics.OpenGL.GL.ShadeModel(OpenTK.Graphics.OpenGL.ShadingModel.Flat);
      OpenTK.Graphics.OpenGL.GL.Translate(-xpos, -ypos, -zpos);
      OpenTK.Graphics.OpenGL.GL.Rotate(xrot, 1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(yrot, 0.0f, 1f, 0.0f);
      byte[] numArray1 = new byte[3];
      int[] numArray2 = new int[4];
      double[] numArray3 = new double[16];
      double[] numArray4 = new double[16];
      OpenTK.Graphics.OpenGL.GL.GetInteger(OpenTK.Graphics.OpenGL.GetPName.Viewport, numArray2);
      OpenTK.Graphics.OpenGL.GL.GetDouble(OpenTK.Graphics.OpenGL.GetPName.Modelview0MatrixExt, numArray3);
      OpenTK.Graphics.OpenGL.GL.GetDouble(OpenTK.Graphics.OpenGL.GetPName.ProjectionMatrix, numArray4);
      float[] pixels = new float[1];
      OpenTK.Graphics.OpenGL.GL.ReadPixels<float>(x, numArray2[3] - y, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.DepthComponent, OpenTK.Graphics.OpenGL.PixelType.Float, pixels);
      Tao.OpenGl.Glu.gluUnProject((double) x, (double) (numArray2[3] - y), (double) depth, numArray3, numArray4, numArray2, out posX, out posY, out posZ);
      Core.InitGl();
    }

    public void DrawModelBoundary(BoundingBox bb, bool diag)
    {
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Lines);
      OpenTK.Graphics.OpenGL.GL.Color3(Color.White);
      this.DrawLine(bb.smallX, bb.smallY, bb.smallZ, bb.largeX, bb.smallY, bb.smallZ);
      this.DrawLine(bb.smallX, bb.smallY, bb.smallZ, bb.smallX, bb.smallY, bb.largeZ);
      this.DrawLine(bb.largeX, bb.smallY, bb.smallZ, bb.largeX, bb.smallY, bb.largeZ);
      this.DrawLine(bb.smallX, bb.smallY, bb.largeZ, bb.largeX, bb.smallY, bb.largeZ);
      this.DrawLine(bb.smallX, bb.largeY, bb.smallZ, bb.largeX, bb.largeY, bb.smallZ);
      this.DrawLine(bb.smallX, bb.largeY, bb.smallZ, bb.smallX, bb.largeY, bb.largeZ);
      this.DrawLine(bb.largeX, bb.largeY, bb.smallZ, bb.largeX, bb.largeY, bb.largeZ);
      this.DrawLine(bb.smallX, bb.largeY, bb.largeZ, bb.largeX, bb.largeY, bb.largeZ);
      this.DrawLine(bb.smallX, bb.smallY, bb.largeZ, bb.smallX, bb.largeY, bb.largeZ);
      this.DrawLine(bb.largeX, bb.smallY, bb.largeZ, bb.largeX, bb.largeY, bb.largeZ);
      this.DrawLine(bb.smallX, bb.smallY, bb.smallZ, bb.smallX, bb.largeY, bb.smallZ);
      this.DrawLine(bb.largeX, bb.smallY, bb.smallZ, bb.largeX, bb.largeY, bb.smallZ);
      if (diag)
      {
        this.DrawLine(bb.smallX, bb.smallY, bb.smallZ, bb.largeX, bb.smallY, bb.largeZ);
        this.DrawLine(bb.smallX, bb.smallY, bb.largeZ, bb.largeX, bb.smallY, bb.smallZ);
        this.DrawLine(bb.smallX, bb.largeY, bb.smallZ, bb.largeX, bb.largeY, bb.largeZ);
        this.DrawLine(bb.smallX, bb.largeY, bb.largeZ, bb.largeX, bb.largeY, bb.smallZ);
        this.DrawLine(bb.smallX, bb.smallY, bb.largeZ, bb.largeX, bb.largeY, bb.largeZ);
        this.DrawLine(bb.largeX, bb.smallY, bb.largeZ, bb.smallX, bb.largeY, bb.largeZ);
        this.DrawLine(bb.smallX, bb.smallY, bb.smallZ, bb.largeX, bb.largeY, bb.smallZ);
        this.DrawLine(bb.largeX, bb.smallY, bb.smallZ, bb.smallX, bb.largeY, bb.smallZ);
        this.DrawLine(bb.smallX, bb.smallY, bb.smallZ, bb.smallX, bb.largeY, bb.largeZ);
        this.DrawLine(bb.smallX, bb.smallY, bb.largeZ, bb.smallX, bb.largeY, bb.smallZ);
        this.DrawLine(bb.largeX, bb.smallY, bb.smallZ, bb.largeX, bb.largeY, bb.largeZ);
        this.DrawLine(bb.largeX, bb.smallY, bb.largeZ, bb.largeX, bb.largeY, bb.smallZ);
      }
      OpenTK.Graphics.OpenGL.GL.End();
    }

    public void drawObjectBoundingBox(ObjectData obj)
    {
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate((float) obj.locX, (float) obj.locY, (float) obj.locZ);
      if (obj.pointer == 32808 || obj.pointer == 34432)
        OpenTK.Graphics.OpenGL.GL.Rotate((float) obj.rot, 0.0f, 0.0f, 1f);
      else if (obj.pointer != 32872)
        OpenTK.Graphics.OpenGL.GL.Rotate((float) obj.rot, 0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.LineWidth(2f);
      float num1 = (float) obj.size / 100f;
      if (obj.pointer == 0)
        num1 = 1f;
      if (this.check2D(ref obj) || obj.pointer == 1)
        num1 = 1f;
      double num2 = (double) num1;
      OpenTK.Graphics.OpenGL.GL.Scale((float) num2, (float) num2, (float) num2);
      this.DrawModelBoundary(obj.bb, false);
      if (obj.radius != (ushort) 0)
      {
        if (obj.colour == (byte) 0)
          OpenTK.Graphics.OpenGL.GL.Color3(Color.Red);
        if (obj.colour == (byte) 1)
          OpenTK.Graphics.OpenGL.GL.Color3(Color.Green);
        if (obj.colour == (byte) 2)
          OpenTK.Graphics.OpenGL.GL.Color3(Color.Blue);
        if (obj.colour == (byte) 3)
          OpenTK.Graphics.OpenGL.GL.Color3(Color.White);
        this.wire = OpenTK.Graphics.Glu.NewQuadric();
        OpenTK.Graphics.Glu.QuadricDrawStyle(this.wire, QuadricDrawStyle.Line);
        OpenTK.Graphics.Glu.Sphere(this.wire, (double) obj.radius, 5, 5);
        OpenTK.Graphics.Glu.DeleteQuadric(this.wire);
      }
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }

    private bool check2D(ref ObjectData obj) => obj.objectID == (short) 32 || obj.objectID == (short) 33 || obj.objectID == (short) 34 && obj.specialScript == (short) 6412 || obj.objectID == (short) 35 || obj.objectID == (short) 39 || obj.objectID == (short) 45 || obj.objectID == (short) 81 || obj.objectID == (short) 82 || obj.objectID == (short) 5696 || obj.objectID == (short) 5712 || obj.objectID == (short) 5728 || obj.name == "Enemy Boundary" || obj.name.Contains("End Climb") || obj.name == "Start Climb" || obj.name == "Note" || obj.name.Contains("Start Point") || obj.name.Contains("Entry Point") || obj.name == "warp" || obj.name == "Warp To - Start of Level" || obj.objectID == (short) 389 || obj.objectID == (short) 395 || obj.objectID == (short) 414 || obj.objectID == (short) 297 || obj.objectID == (short) 224 || obj.objectID == (short) 511 || obj.objectID == (short) 512 || obj.objectID == (short) 880 || obj.objectID == (short) 73 || obj.specialScript == (short) 0 && (obj.objectID == (short) 3424 || obj.objectID == (short) 1125 || obj.objectID == (short) 1127 || obj.objectID == (short) 1136 || obj.objectID == (short) 1280 || obj.objectID == (short) 5696 || obj.objectID == (short) 5616 || obj.objectID == (short) 224 || obj.objectID == (short) 5712 || obj.objectID == (short) 5728);

    public double[] screenToWorld(int x, int y, float xrot, float yrot, float zrot)
    {
      double num1 = (double) yrot / 180.0;
      double num2 = (double) xrot / 180.0;
      double num3 = (double) zrot / 180.0;
      int[] numArray1 = new int[4];
      double[] numArray2 = new double[16];
      double[] numArray3 = new double[16];
      OpenTK.Graphics.OpenGL.GL.GetInteger(OpenTK.Graphics.OpenGL.GetPName.Viewport, numArray1);
      OpenTK.Graphics.OpenGL.GL.GetDouble(OpenTK.Graphics.OpenGL.GetPName.Modelview0MatrixExt, numArray2);
      OpenTK.Graphics.OpenGL.GL.GetDouble(OpenTK.Graphics.OpenGL.GetPName.ProjectionMatrix, numArray3);
      int num4 = numArray1[3];
      int num5 = x;
      int num6 = y;
      int num7 = num4 - num6;
      float[] pixels = new float[1];
      OpenTK.Graphics.OpenGL.GL.ReadPixels<float>(num5, num7, 1, 1, OpenTK.Graphics.OpenGL.PixelFormat.DepthComponent, OpenTK.Graphics.OpenGL.PixelType.Float, pixels);
      double objX = 0.0;
      double objY = 0.0;
      double objZ = 0.0;
      Tao.OpenGl.Glu.gluUnProject((double) num5, (double) num7, (double) pixels[0], numArray2, numArray3, numArray1, out objX, out objY, out objZ);
      return new double[3]{ objX, objY, objZ };
    }

    public void DrawModelFilePicking(
      string model_,
      float x_,
      float y_,
      float z_,
      int rot_,
      float size)
    {
      int F3DStart = 0;
      int F3DCommands = 0;
      int F3DEnd = 0;
      int vertStart = 0;
      List<byte[]> commands = new List<byte[]>();
      F3DEX_VERT[] verts = new F3DEX_VERT[32];
      F3DEX_VERT[] cache = new F3DEX_VERT[32];
      Texture[] textures = new Texture[1];
      if (!File.Exists(model_))
        return;
      try
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(model_, FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] bytesInFile = new byte[length];
        binaryReader.BaseStream.Read(bytesInFile, 0, (int) length);
        binaryReader.Close();
        int collStart = 0;
        int VTCount = 0;
        int textureCount = 0;
        if (!this.f3dex.ReadModel(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount, ref verts, ref commands, ref textures))
          return;
        OpenTK.Graphics.OpenGL.GL.PushMatrix();
        OpenTK.Graphics.OpenGL.GL.Translate(x_, y_, z_);
        if (model_.Contains("8028") || model_.Contains("8680"))
          OpenTK.Graphics.OpenGL.GL.Rotate((float) rot_, 0.0f, 0.0f, 1f);
        else if (!model_.Contains("8068"))
          OpenTK.Graphics.OpenGL.GL.Rotate((float) rot_, 0.0f, 1f, 0.0f);
        size /= 100f;
        double num1 = (double) size;
        OpenTK.Graphics.OpenGL.GL.Scale((float) num1, (float) num1, (float) num1);
        for (int index = 0; index < F3DCommands; ++index)
        {
          byte[] numArray = commands[index];
          int num2 = (int) numArray[4];
          int num3 = (int) numArray[5];
          int num4 = (int) numArray[6];
          int num5 = (int) numArray[7];
          int num6 = (int) numArray[1];
          int num7 = (int) numArray[2];
          int num8 = (int) numArray[3];
          if (numArray[0] == (byte) 4)
            this.f3dex.GL_VTX_PICKING(numArray, ref cache, ref verts);
          if (numArray[0] == (byte) 191)
            this.f3dex.GL_TRI1_PICKING(numArray, ref cache);
          else if (numArray[0] == (byte) 177)
            this.f3dex.GL_TRI2_PICKING(numArray, ref cache);
        }
        OpenTK.Graphics.OpenGL.GL.PopMatrix();
      }
      catch (Exception ex)
      {
        OpenTK.Graphics.OpenGL.GL.PopMatrix();
      }
    }

    public byte[] pickRectSelect(Point p1, Point p2, Mode mode, uint objectsDL, BKPath p)
    {
      if (p1.X < 0)
        p1.X = 1;
      if (p2.X > this.width)
        p2.X = this.width - 3;
      if (p1.Y < 0)
        p1.Y = 1;
      if (p2.Y > this.height)
        p2.Y = this.height - 3;
      int width = p2.X - p1.X;
      int height = p2.Y - p1.Y;
      if (this.rect_pixel.Length < (this.width + 1) * (this.height + 1) * 3 + 3)
        this.rect_pixel = new byte[(this.width + 1) * (this.height + 1) * 3 + 3];
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Texture2D);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Fog);
      OpenTK.Graphics.OpenGL.GL.Disable(OpenTK.Graphics.OpenGL.EnableCap.Lighting);
      OpenTK.Graphics.OpenGL.GL.ShadeModel(OpenTK.Graphics.OpenGL.ShadingModel.Flat);
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(0.0f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 1f, 0.0f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 0.0f, 1f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Rotate(0.0f, 0.0f, 0.0f, 1f);
      if (mode == Mode.Path)
      {
        try
        {
          for (int index = 0; index < p.nodes.Count; ++index)
          {
            OpenTK.Graphics.OpenGL.GL.Color3((float) p.nodes[index].m_colorID[0] / (float) byte.MaxValue, (float) p.nodes[index].m_colorID[1] / (float) byte.MaxValue, (float) p.nodes[index].m_colorID[2] / (float) byte.MaxValue);
            this.DrawPriPick((float) p.nodes[index].locX, (float) p.nodes[index].locY, (float) p.nodes[index].locZ);
          }
        }
        catch (Exception ex)
        {
        }
      }
      if (mode == Mode.Object)
        OpenTK.Graphics.OpenGL.GL.CallList(objectsDL);
      int[] data = new int[4];
      OpenTK.Graphics.OpenGL.GL.GetInteger(OpenTK.Graphics.OpenGL.GetPName.Viewport, data);
      if (this.rect_pixel.Length > (width + 1) * (height + 1) * 3 + 3)
        OpenTK.Graphics.OpenGL.GL.ReadPixels<byte>(p1.X, data[3] - p2.Y, width, height, OpenTK.Graphics.OpenGL.PixelFormat.Rgb, OpenTK.Graphics.OpenGL.PixelType.UnsignedByte, this.rect_pixel);
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
      return this.rect_pixel;
    }

    public void DrawLine(F3DEX_VERT v1, F3DEX_VERT v2)
    {
      OpenTK.Graphics.OpenGL.GL.Vertex3(v1.x, v1.y, v1.z);
      OpenTK.Graphics.OpenGL.GL.Vertex3(v2.x, v2.y, v2.z);
    }

    public void DrawLine(int x1, int y1, int z1, int x2, int y2, int z2)
    {
      OpenTK.Graphics.OpenGL.GL.Vertex3(x1, y1, z1);
      OpenTK.Graphics.OpenGL.GL.Vertex3(x2, y2, z2);
    }

    public void DrawCube(int sx, int sy, int sz, int lx, int ly, int lz)
    {
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Quads);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, sy, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, ly, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, ly, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, sy, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, sy, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, sy, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, ly, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, ly, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, sy, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, ly, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, ly, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, sy, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, sy, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, ly, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, ly, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, sy, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, ly, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, ly, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, ly, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, ly, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, sy, lz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(sx, sy, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, sy, sz);
      OpenTK.Graphics.OpenGL.GL.Vertex3(lx, sy, lz);
      OpenTK.Graphics.OpenGL.GL.End();
    }

    public void DrawPriPick(float x, float y, float z)
    {
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(x, y, z);
      this.DrawPri();
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }

    public void DrawPri()
    {
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.TriangleFan);
      OpenTK.Graphics.OpenGL.GL.Vertex3(0.0f, 30f, 0.0f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-25f, -25f, 25f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(25f, -25f, 25f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(25f, -25f, -25f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-25f, -25f, -25f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-25f, -25f, 25f);
      OpenTK.Graphics.OpenGL.GL.End();
      OpenTK.Graphics.OpenGL.GL.Begin(OpenTK.Graphics.OpenGL.BeginMode.Quads);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-25f, -25f, 25f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(-25f, -25f, -25f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(25f, -25f, -25f);
      OpenTK.Graphics.OpenGL.GL.Vertex3(25f, -25f, 25f);
      OpenTK.Graphics.OpenGL.GL.End();
    }

    public void DrawPri(float x, float y, float z, ushort radius, byte c)
    {
      OpenTK.Graphics.OpenGL.GL.PushMatrix();
      OpenTK.Graphics.OpenGL.GL.Translate(x, y, z);
      OpenTK.Graphics.OpenGL.GL.Color3(0.9f, 0.9f, 0.9f);
      this.DrawPri();
      if (radius != (ushort) 0)
      {
        try
        {
          if ((!this.drawEnemyRadius || c != (byte) 3) && (!this.drawFlagRadius || c != (byte) 1))
          {
            if (this.drawUnknownRadius)
            {
              if (c != (byte) 4)
                goto label_12;
            }
            else
              goto label_12;
          }
          if (c == (byte) 0)
            OpenTK.Graphics.OpenGL.GL.Color3(1f, 0.0f, 0.0f);
          if (c == (byte) 1)
            OpenTK.Graphics.OpenGL.GL.Color3(0.0f, 1f, 0.0f);
          if (c == (byte) 4)
            OpenTK.Graphics.OpenGL.GL.Color3(1f, 1f, 0.0f);
          this.wire = OpenTK.Graphics.Glu.NewQuadric();
          OpenTK.Graphics.Glu.QuadricDrawStyle(this.wire, QuadricDrawStyle.Line);
          OpenTK.Graphics.Glu.Sphere(this.wire, (double) radius, 5, 5);
          OpenTK.Graphics.Glu.DeleteQuadric(this.wire);
        }
        catch (Exception ex)
        {
        }
      }
label_12:
      OpenTK.Graphics.OpenGL.GL.PopMatrix();
    }
  }
}
