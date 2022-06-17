// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.GEOBJ
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BanjoKazooieLevelEditor
{
  internal class GEOBJ
  {
    public static string convertVerts(F3DEX_VERT[] verts)
    {
      string str = "";
      for (int index = 0; index < verts.Length; ++index)
        str = str + "v " + verts[index].x.ToString() + " " + verts[index].y.ToString() + " " + verts[index].z.ToString() + Environment.NewLine + "#vcolor " + (object) (float) ((double) verts[index].r * (double) byte.MaxValue) + " " + (object) (float) ((double) verts[index].g * (double) byte.MaxValue) + " " + (object) (float) ((double) verts[index].b * (double) byte.MaxValue) + " " + (object) (float) ((double) verts[index].a * (double) byte.MaxValue) + Environment.NewLine;
      return str;
    }

    public static string convertFace(uint v1, uint v2, uint v3, int vtIndex) => "f " + (object) v1 + "/" + (object) vtIndex + " " + (object) v2 + "/" + (object) (vtIndex + 1) + " " + (object) v3 + "/" + (object) (vtIndex + 2) + Environment.NewLine + "#fvcolorindex " + (object) v1 + " " + (object) v2 + " " + (object) v3 + Environment.NewLine;

    public static void writeTexture(string file, byte[] pixels, int width, int height)
    {
      byte[] source = new byte[pixels.Length];
      for (int index = 0; index < pixels.Length; index += 4)
      {
        source[index] = pixels[index + 2];
        source[index + 1] = pixels[index + 1];
        source[index + 2] = pixels[index];
        source[index + 3] = pixels[index + 3];
      }
      Rectangle rect = new Rectangle(0, 0, width, height);
      Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      Marshal.Copy(source, 0, scan0, source.Length);
      bitmap.UnlockBits(bitmapdata);
      bitmap.Save(file, ImageFormat.Png);
    }

    public static string convertSkeleton(List<Bone> skeleton)
    {
      string str = "";
      foreach (Bone bone in skeleton)
      {
        str = str + "#joint " + (object) bone.id + Environment.NewLine;
        str = str + "#jointposition " + bone.x.ToString() + " " + bone.y.ToString() + " " + bone.z.ToString() + Environment.NewLine;
      }
      foreach (Bone bone in skeleton)
      {
        if (bone.parent != (short) -1)
          str = str + "#connection " + (object) bone.parent + " " + (object) bone.id + Environment.NewLine;
      }
      return str;
    }
  }
}
