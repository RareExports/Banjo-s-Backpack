// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.F3DEX
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using Tao.OpenGl;

namespace BanjoKazooieLevelEditor
{
  internal class F3DEX
  {
    public int textureFormat;
    public int texelSize;
    public int lineSize;
    public int cms;
    public int cmt;
    public static int FMT_RGBA = 0;
    public static int FMT_YUV = 1;
    public static int FMT_CI = 2;
    public static int FMT_IA = 3;
    public static int FMT_I = 3;
    public static int PS_4 = 0;
    public static int PS_8 = 1;
    public static int PS_16 = 2;
    public static int PS_32 = 3;

    public bool ReadModel(
      ref byte[] bytesInFile,
      ref int collStart,
      ref int F3DStart,
      ref int F3DCommands,
      ref int F3DEnd,
      ref int vertStart,
      ref int VTCount,
      ref int textureCount,
      ref F3DEX_VERT[] verts,
      ref List<byte[]> commands,
      ref Texture[] textures)
    {
      if (!this.readBase(ref bytesInFile, ref collStart, ref F3DStart, ref F3DCommands, ref F3DEnd, ref vertStart, ref VTCount, ref textureCount))
        return false;
      verts = new F3DEX_VERT[VTCount];
      this.ripVerts(ref bytesInFile, ref verts, VTCount, vertStart);
      textures = this.getTextures(ref bytesInFile);
      int num1 = 0;
      int num2 = F3DStart;
      for (; num1 < F3DCommands; ++num1)
      {
        byte[] numArray = new byte[8];
        for (int index = 0; index < 8; ++index)
          numArray[index] = bytesInFile[num2 + index];
        num2 += 8;
        commands.Add(numArray);
      }
      return true;
    }

    private bool readBase(
      ref byte[] bytesInFile,
      ref int collStart,
      ref int F3DStart,
      ref int F3DCommands,
      ref int F3DEnd,
      ref int vertStart,
      ref int VTCount,
      ref int textureCount)
    {
      if (bytesInFile[3] != (byte) 11)
        return false;
      collStart = (int) bytesInFile[4] * 16777216 + (int) bytesInFile[5] * 65536 + (int) bytesInFile[6] * 256 + (int) bytesInFile[7] + 24;
      F3DStart = (int) bytesInFile[12] * 16777216 + (int) bytesInFile[13] * 65536 + (int) bytesInFile[14] * 256 + (int) bytesInFile[15] + 8;
      F3DCommands = (int) bytesInFile[F3DStart - 6] * 256 + (int) bytesInFile[F3DStart - 5];
      F3DEnd = F3DStart + F3DCommands * 8;
      vertStart = (int) bytesInFile[16] * 16777216 + (int) bytesInFile[17] * 65536 + (int) bytesInFile[18] * 256 + (int) bytesInFile[19] + 24;
      VTCount = (int) bytesInFile[50] * 256 + (int) bytesInFile[51];
      textureCount = (int) bytesInFile[60] * 256 + (int) bytesInFile[61];
      return true;
    }

    private Texture[] getTextures(ref byte[] bytesInFile)
    {
      int length1 = (int) bytesInFile[60] * 256 + (int) bytesInFile[61];
      Texture[] textures = new Texture[length1];
      if (length1 == 0)
        textures = new Texture[1];
      int num = length1 * 16 + 64;
      int index1 = 0;
      for (int textureTableOffset_ = 64; textureTableOffset_ < num; textureTableOffset_ += 16)
      {
        int textureOffset_ = (int) bytesInFile[textureTableOffset_] * 16777216 + (int) bytesInFile[textureTableOffset_ + 1] * 65536 + (int) bytesInFile[textureTableOffset_ + 2] * 256 + (int) bytesInFile[textureTableOffset_ + 3];
        int textureWidth_ = (int) bytesInFile[textureTableOffset_ + 8];
        int textureHeight_ = (int) bytesInFile[textureTableOffset_ + 9];
        textures[index1] = new Texture(textureTableOffset_, (uint) textureOffset_, textureWidth_, textureHeight_);
        ++index1;
      }
      int length2 = (int) bytesInFile[57] * 65536 + (int) bytesInFile[58] * 256 + (int) bytesInFile[59] - length1 * 16 - 8;
      if (length2 > 0)
      {
        byte[] numArray = new byte[length2];
        if (num + length2 <= bytesInFile.Length)
        {
          for (int index2 = 0; index2 < length2; ++index2)
            numArray[index2] = bytesInFile[num + index2];
        }
      }
      else
        textures[0] = new Texture(0, 0U, 1, 1);
      return textures;
    }

    private void ripVerts(ref byte[] bytesInFile, ref F3DEX_VERT[] verts, int VTCount, int offset)
    {
      for (int index = 0; index < VTCount; ++index)
      {
        int x_ = (int) (short) ((int) bytesInFile[offset] * 256 + (int) bytesInFile[offset + 1]);
        short num1 = (short) ((int) bytesInFile[offset + 2] * 256 + (int) bytesInFile[offset + 3]);
        short num2 = (short) ((int) bytesInFile[offset + 4] * 256 + (int) bytesInFile[offset + 5]);
        short num3 = (short) ((int) bytesInFile[offset + 8] * 256 + (int) bytesInFile[offset + 9]);
        short num4 = (short) ((int) bytesInFile[offset + 10] * 256 + (int) bytesInFile[offset + 11]);
        float num5 = (float) bytesInFile[offset + 12] / (float) byte.MaxValue;
        float num6 = (float) bytesInFile[offset + 13] / (float) byte.MaxValue;
        float num7 = (float) bytesInFile[offset + 14] / (float) byte.MaxValue;
        float num8 = (float) bytesInFile[offset + 15] / (float) byte.MaxValue;
        int y_ = (int) num1;
        int z_ = (int) num2;
        int u_ = (int) num3;
        int v_ = (int) num4;
        double r_ = (double) num5;
        double g_ = (double) num6;
        double b_ = (double) num7;
        double a_ = (double) num8;
        F3DEX_VERT f3DexVert = new F3DEX_VERT((short) x_, (short) y_, (short) z_, (short) u_, (short) v_, (float) r_, (float) g_, (float) b_, (float) a_);
        verts[index] = f3DexVert;
        offset += 16;
      }
    }

    public void GL_EndDL(int cmdno, int count)
    {
      if (cmdno + 4 < count)
        return;
      Gl.glDisable(3553);
    }

    public void GL_G_SETTIMG(
      ref int currentTexture,
      int textureCount,
      uint w1,
      ref Texture[] textures,
      byte[] commandCheck,
      ref bool newTexture,
      float sScale,
      float tScale)
    {
      uint num = w1 << 8 >> 8;
      bool flag = false;
      for (int index = 0; index < textureCount && !flag; ++index)
      {
        if ((int) textures[index].textureOffset == (int) num || (int) textures[index].indexOffset == (int) num)
        {
          currentTexture = index;
          flag = true;
        }
      }
      if (commandCheck[0] == (byte) 240)
        return;
      newTexture = true;
      textures[currentTexture].setRatio(sScale, tScale);
    }

    public void GL_G_Combine(uint w1)
    {
      if (w1 == 1058404863U)
        Gl.glDisable(3553);
      else
        Gl.glEnable(3553);
    }

    public void GL_SETGEOMETRYMODE(uint w1)
    {
      Gl.glDisable(2884);
      int num = (int) ((uint) (((int) w1 & 16777215) << 8) >> 8);
      bool flag1 = (uint) (num & 4096) > 0U;
      bool flag2 = (uint) (num & 8192) > 0U;
      bool flag3 = (uint) (num & 12288) > 0U;
      if (flag1)
        Gl.glCullFace(1028);
      if (flag2)
        Gl.glCullFace(1029);
      if (flag2 & flag1)
        Gl.glCullFace(1032);
      if (!(flag1 | flag2 | flag3))
        return;
      Gl.glEnable(2884);
    }

    public void GL_G_SETTILE(byte[] command, ref Texture tex)
    {
      uint num1 = (uint) ((int) command[4] * 16777216 + (int) command[5] * 65536 + (int) command[6] * 256) + (uint) command[7];
      uint num2 = (uint) ((int) command[1] * 65536 + (int) command[2] * 256) + (uint) command[3];
      Gl.glEnable(3553);
      this.textureFormat = (int) (byte) ((uint) command[1] >> 5);
      this.texelSize = (int) (byte) ((uint) (byte) ((int) command[1] >> 3 << 6) >> 6);
      this.lineSize = (int) (num2 >> 9) & 15;
      this.cmt = (int) (num1 >> 18) & 2;
      this.cms = (int) (num1 >> 8) & 3;
    }

    public void GL_G_LOADTLUT()
    {
    }

    public void GL_VTX(
      ref byte[] bytesInFile,
      byte[] cmd,
      ref F3DEX_VERT[] cache,
      ref F3DEX_VERT[] verts,
      ref Texture texture,
      int textureCount,
      ref int texturesGL,
      ref bool newTexture)
    {
      int num1 = (int) cmd[4] * 16777216 + (int) cmd[5] * 65536 + (int) cmd[6] * 256 + (int) cmd[7];
      int num2 = (int) cmd[1];
      int num3 = (int) cmd[2];
      int num4 = (int) cmd[3];
      byte num5 = (byte) ((uint) cmd[1] >> 1);
      byte num6 = (byte) ((uint) cmd[2] >> 2);
      if (num5 > (byte) 63)
        num5 = (byte) 63;
      uint index1 = ((uint) (num1 << 8) >> 8) / 16U;
      try
      {
        for (int index2 = (int) num5; index2 < (int) num6 + (int) num5; ++index2)
        {
          if ((long) index1 < (long) verts.Length)
            cache[index2] = verts[(int) index1];
          ++index1;
        }
      }
      catch (Exception ex)
      {
      }
      if (!newTexture)
        return;
      this.F3DEX_2_GL_TEXTURE(ref bytesInFile, ref texture, textureCount, ref texturesGL, true);
      newTexture = false;
    }

    public void F3DEX_2_GL_TEXTURE(
      ref byte[] bytesInFile,
      ref Texture texture,
      int textureCount,
      ref int texturesGL,
      bool deleteTextureGL)
    {
      Gl.glEnable(3553);
      byte[] numArray = new byte[texture.textureWidth * texture.textureHeight * 4];
      byte[] textureN64Bytes = new byte[texture.textureSize];
      int num = !texture.palLoaded ? (int) texture.textureOffset + 64 + textureCount * 16 : (int) texture.indexOffset + 64 + textureCount * 16;
      try
      {
        for (int index = 0; index < textureN64Bytes.Length; ++index)
        {
          if (num + index < bytesInFile.Length)
            textureN64Bytes[index] = bytesInFile[num + index];
          else
            break;
        }
      }
      catch (Exception ex)
      {
      }
      if (texture.pixels == null)
      {
        if (this.textureFormat == 0)
        {
          if (this.texelSize == 2)
          {
            Gl.glEnable(3553);
            numArray = this.CONVERT_RGBA5551_RGBA8888(ref texture, ref textureN64Bytes);
          }
          if (this.texelSize == 3)
          {
            Gl.glEnable(3553);
            try
            {
              for (int index = 0; index < numArray.Length; ++index)
                numArray[index] = bytesInFile[num + index];
            }
            catch (Exception ex)
            {
            }
          }
        }
        else if (this.textureFormat == 2)
        {
          if (this.texelSize == 0)
          {
            Gl.glEnable(3553);
            numArray = this.CONVERT_CI4_RGBA8888(ref texture, ref textureN64Bytes);
          }
          if (this.texelSize == 1)
          {
            Gl.glEnable(3553);
            numArray = this.CONVERT_CI8_RGBA8888(ref texture, ref textureN64Bytes);
          }
        }
        else if (this.textureFormat == 3)
        {
          if (this.texelSize == 0)
          {
            Gl.glEnable(3553);
            numArray = this.CONVERT_IA4_RGBA8888(ref texture, ref textureN64Bytes);
          }
          if (this.texelSize == 1)
          {
            Gl.glEnable(3553);
            numArray = this.CONVERT_IA8_RGBA8888(ref texture, ref textureN64Bytes);
          }
          if (this.texelSize == 2)
          {
            Gl.glEnable(3553);
            numArray = this.CONVERT_IA16_RGBA8888(ref texture, ref textureN64Bytes);
          }
        }
        texture.pixels = numArray;
      }
      if (this.texelSize > 2 && this.textureFormat != 0)
      {
        if (deleteTextureGL)
          Gl.glDeleteTextures(1, ref texturesGL);
        Gl.glEnable(3553);
        Gl.glGenTextures(1, out texturesGL);
        Gl.glEnable(3553);
        Gl.glBindTexture(3553, texturesGL);
        try
        {
          Gl.glTexImage2D(3553, 0, 6408, texture.textureWidth, texture.textureHeight, 0, 6408, 5121, (object) textureN64Bytes);
        }
        catch (Exception ex)
        {
        }
      }
      else
      {
        if (deleteTextureGL)
          Gl.glDeleteTextures(1, ref texturesGL);
        Gl.glEnable(3553);
        Gl.glGenTextures(1, out texturesGL);
        Gl.glEnable(3553);
        Gl.glBindTexture(3553, texturesGL);
        Gl.glTexImage2D(3553, 0, 6408, texture.textureWidth, texture.textureHeight, 0, 6408, 5121, (object) texture.pixels);
      }
      Gl.glTexParameterf(3553, 34046, 16f);
      Gl.glTexParameteri(3553, 10240, 9729);
      Gl.glTexParameteri(3553, 10241, 9729);
      if (this.cms == 0)
        Gl.glTexParameteri(3553, 10242, 10497);
      if (this.cms == 2)
        Gl.glTexParameteri(3553, 10242, 33071);
      if (this.cmt == 0)
        Gl.glTexParameteri(3553, 10243, 10497);
      if (this.cmt != 2)
        return;
      Gl.glTexParameteri(3553, 10243, 33071);
    }

    public byte[] CONVERT_RGBA5551_RGBA8888(ref Texture texture, ref byte[] textureN64Bytes)
    {
      int index1 = 0;
      uint index2 = 0;
      byte[] numArray = new byte[texture.textureWidth * texture.textureHeight * 4];
      try
      {
        for (int index3 = 0; index3 < texture.textureHeight; ++index3)
        {
          for (int index4 = 0; index4 < texture.textureWidth; ++index4)
          {
            ushort num1 = (ushort) ((uint) textureN64Bytes[(int) index2] * 256U + (uint) textureN64Bytes[(int) index2 + 1]);
            byte num2 = (byte) ((uint) (byte) ((uint) textureN64Bytes[(int) index2 + 1] << 7) >> 7) != (byte) 0 ? byte.MaxValue : (byte) 0;
            numArray[index1] = (byte) (((int) num1 & 63488) >> 8);
            numArray[index1 + 1] = (byte) (((int) num1 & 1984) << 5 >> 8);
            numArray[index1 + 2] = (byte) (((int) num1 & 62) << 18 >> 16);
            numArray[index1 + 3] = num2;
            index1 += 4;
            index2 += 2U;
          }
          if (this.lineSize > 0)
            index2 += (uint) (this.lineSize * 4 - texture.textureWidth);
        }
      }
      catch (Exception ex)
      {
      }
      return numArray;
    }

    public byte[] CONVERT_CI4_RGBA8888(ref Texture texture, ref byte[] textureN64Bytes)
    {
      int index1 = 0;
      uint index2 = 0;
      byte[] numArray = new byte[texture.textureWidth * texture.textureHeight * 4];
      try
      {
        for (int index3 = 0; index3 < texture.textureHeight; ++index3)
        {
          for (int index4 = 0; index4 < texture.textureWidth / 2; ++index4)
          {
            byte index5 = (byte) ((uint) textureN64Bytes[(int) index2] >> 4);
            byte index6 = (byte) ((uint) (byte) ((uint) textureN64Bytes[(int) index2] << 4) >> 4);
            numArray[index1] = texture.red[(int) index5];
            numArray[index1 + 1] = texture.green[(int) index5];
            numArray[index1 + 2] = texture.blue[(int) index5];
            numArray[index1 + 3] = texture.alpha[(int) index5];
            numArray[index1 + 4] = texture.red[(int) index6];
            numArray[index1 + 5] = texture.green[(int) index6];
            numArray[index1 + 6] = texture.blue[(int) index6];
            numArray[index1 + 7] = texture.alpha[(int) index6];
            index1 += 8;
            ++index2;
          }
          index2 += (uint) (this.lineSize * 8 - texture.textureWidth / 2);
        }
      }
      catch (Exception ex)
      {
      }
      return numArray;
    }

    public byte[] CONVERT_CI8_RGBA8888(ref Texture texture, ref byte[] textureN64Bytes)
    {
      int index1 = 0;
      uint index2 = 0;
      byte[] numArray = new byte[texture.textureWidth * texture.textureHeight * 4];
      try
      {
        for (int index3 = 0; index3 < texture.textureHeight; ++index3)
        {
          for (int index4 = 0; index4 < texture.textureWidth; ++index4)
          {
            numArray[index1] = texture.red[(int) textureN64Bytes[(int) index2]];
            numArray[index1 + 1] = texture.green[(int) textureN64Bytes[(int) index2]];
            numArray[index1 + 2] = texture.blue[(int) textureN64Bytes[(int) index2]];
            numArray[index1 + 3] = texture.alpha[(int) textureN64Bytes[(int) index2]];
            index1 += 4;
            ++index2;
          }
          index2 += (uint) (this.lineSize * 8 - texture.textureWidth);
        }
      }
      catch (Exception ex)
      {
      }
      return numArray;
    }

    public byte[] CONVERT_IA4_RGBA8888(ref Texture texture, ref byte[] textureN64Bytes)
    {
      byte[] numArray = new byte[texture.textureWidth * texture.textureHeight * 4];
      try
      {
        for (int index = 0; index < textureN64Bytes.Length / 2; ++index)
        {
          byte num1 = (byte) ((uint) textureN64Bytes[index] >> 4);
          numArray[index * 8] = (byte) ((uint) num1 * 17U);
          numArray[index * 8 + 1] = (byte) ((uint) num1 * 17U);
          numArray[index * 8 + 2] = (byte) ((uint) num1 * 17U);
          numArray[index * 8 + 3] = (byte) ((uint) num1 * 17U);
          byte num2 = (byte) ((uint) (byte) ((uint) textureN64Bytes[index] << 4) >> 4);
          numArray[index * 4] = (byte) ((uint) num2 * 17U);
          numArray[index * 5 + 1] = (byte) ((uint) num2 * 17U);
          numArray[index * 6 + 2] = (byte) ((uint) num2 * 17U);
          numArray[index * 7 + 3] = (byte) ((uint) num2 * 17U);
        }
      }
      catch (Exception ex)
      {
      }
      return numArray;
    }

    public byte[] CONVERT_IA8_RGBA8888(ref Texture texture, ref byte[] textureN64Bytes)
    {
      byte[] numArray = new byte[texture.textureWidth * texture.textureHeight * 4];
      int index1 = 0;
      try
      {
        int index2 = 0;
        for (int index3 = 0; index3 < texture.textureHeight; ++index3)
        {
          for (int index4 = 0; index4 < texture.textureWidth; ++index4)
          {
            byte num1 = (byte) ((uint) textureN64Bytes[index2] >> 4);
            byte num2 = (byte) ((int) textureN64Bytes[index2] << 4 >> 4);
            numArray[index1] = (byte) ((uint) num1 * 17U);
            numArray[index1 + 1] = (byte) ((uint) num1 * 17U);
            numArray[index1 + 2] = (byte) ((uint) num1 * 17U);
            numArray[index1 + 3] = (byte) ((uint) num2 * 17U);
            index1 += 4;
            ++index2;
          }
          index2 += this.lineSize * 8 - texture.textureWidth;
        }
      }
      catch (Exception ex)
      {
      }
      return numArray;
    }

    public byte[] CONVERT_IA16_RGBA8888(ref Texture texture, ref byte[] textureN64Bytes)
    {
      byte[] numArray = new byte[texture.textureWidth * texture.textureHeight * 4];
      int index1 = 0;
      try
      {
        int index2 = 0;
        for (int index3 = 0; index3 < texture.textureHeight; ++index3)
        {
          for (int index4 = 0; index4 < texture.textureWidth; ++index4)
          {
            byte num1 = textureN64Bytes[index2];
            byte num2 = textureN64Bytes[index2 + 1];
            numArray[index1] = num1;
            numArray[index1 + 1] = num1;
            numArray[index1 + 2] = num1;
            numArray[index1 + 3] = num2;
            index1 += 4;
            index2 += 2;
          }
          index2 += this.lineSize * 4 - texture.textureWidth;
        }
      }
      catch (Exception ex)
      {
      }
      return numArray;
    }

    public void GL_VTX_PICKING(byte[] cmd, ref F3DEX_VERT[] cache, ref F3DEX_VERT[] verts)
    {
      int num1 = (int) cmd[4] * 16777216 + (int) cmd[5] * 65536 + (int) cmd[6] * 256 + (int) cmd[7];
      int num2 = (int) cmd[1];
      int num3 = (int) cmd[2];
      int num4 = (int) cmd[3];
      byte num5 = (byte) ((uint) cmd[1] >> 1);
      byte num6 = (byte) ((uint) cmd[2] >> 2);
      if (num5 > (byte) 63)
        num5 = (byte) 63;
      uint index1 = ((uint) (num1 << 8) >> 8) / 16U;
      try
      {
        for (int index2 = (int) num5; index2 < (int) num6 + (int) num5; ++index2)
        {
          if ((long) index1 < (long) verts.Length)
            cache[index2] = verts[(int) index1];
          ++index1;
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void GL_TRI1(byte[] com, ref F3DEX_VERT[] cache, ref Texture texture)
    {
      short index1 = (short) ((int) com[5] / 2);
      short index2 = (short) ((int) com[6] / 2);
      short index3 = (short) ((int) com[7] / 2);
      Gl.glBegin(4);
      Gl.glColor4f(cache[(int) index1].r, cache[(int) index1].g, cache[(int) index1].b, cache[(int) index1].a);
      Gl.glTexCoord2f((float) cache[(int) index1].u * texture.textureWRatio, (float) cache[(int) index1].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index1].x, (float) cache[(int) index1].y, (float) cache[(int) index1].z);
      Gl.glColor4f(cache[(int) index2].r, cache[(int) index2].g, cache[(int) index2].b, cache[(int) index2].a);
      Gl.glTexCoord2f((float) cache[(int) index2].u * texture.textureWRatio, (float) cache[(int) index2].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index2].x, (float) cache[(int) index2].y, (float) cache[(int) index2].z);
      Gl.glColor4f(cache[(int) index3].r, cache[(int) index3].g, cache[(int) index3].b, cache[(int) index3].a);
      Gl.glTexCoord2f((float) cache[(int) index3].u * texture.textureWRatio, (float) cache[(int) index3].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index3].x, (float) cache[(int) index3].y, (float) cache[(int) index3].z);
      Gl.glEnd();
    }

    public void GL_TRI1_PICKING(byte[] com, ref F3DEX_VERT[] cache)
    {
      short index1 = (short) ((int) com[5] / 2);
      short index2 = (short) ((int) com[6] / 2);
      short index3 = (short) ((int) com[7] / 2);
      Gl.glBegin(4);
      Gl.glVertex3f((float) cache[(int) index1].x, (float) cache[(int) index1].y, (float) cache[(int) index1].z);
      Gl.glVertex3f((float) cache[(int) index2].x, (float) cache[(int) index2].y, (float) cache[(int) index2].z);
      Gl.glVertex3f((float) cache[(int) index3].x, (float) cache[(int) index3].y, (float) cache[(int) index3].z);
      Gl.glEnd();
    }

    public void GL_TRI1_PICKING(byte[] com, ref F3DEX_VERT[] cache, byte r, byte g, byte b)
    {
      short index1 = (short) ((int) com[5] / 2);
      short index2 = (short) ((int) com[6] / 2);
      short index3 = (short) ((int) com[7] / 2);
      Gl.glBegin(4);
      Gl.glColor3b(r, g, b);
      Gl.glVertex3f((float) cache[(int) index1].x, (float) cache[(int) index1].y, (float) cache[(int) index1].z);
      Gl.glVertex3f((float) cache[(int) index2].x, (float) cache[(int) index2].y, (float) cache[(int) index2].z);
      Gl.glVertex3f((float) cache[(int) index3].x, (float) cache[(int) index3].y, (float) cache[(int) index3].z);
      Gl.glEnd();
    }

    public void GL_TRI2(byte[] com, ref F3DEX_VERT[] cache, ref Texture texture)
    {
      short index1 = (short) ((int) com[1] / 2);
      short index2 = (short) ((int) com[2] / 2);
      short index3 = (short) ((int) com[3] / 2);
      short index4 = (short) ((int) com[5] / 2);
      short index5 = (short) ((int) com[6] / 2);
      short index6 = (short) ((int) com[7] / 2);
      Gl.glBegin(4);
      Gl.glColor4f(cache[(int) index1].r, cache[(int) index1].g, cache[(int) index1].b, cache[(int) index1].a);
      Gl.glTexCoord2f((float) cache[(int) index1].u * texture.textureWRatio, (float) cache[(int) index1].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index1].x, (float) cache[(int) index1].y, (float) cache[(int) index1].z);
      Gl.glColor4f(cache[(int) index2].r, cache[(int) index2].g, cache[(int) index2].b, cache[(int) index2].a);
      Gl.glTexCoord2f((float) cache[(int) index2].u * texture.textureWRatio, (float) cache[(int) index2].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index2].x, (float) cache[(int) index2].y, (float) cache[(int) index2].z);
      Gl.glColor4f(cache[(int) index3].r, cache[(int) index3].g, cache[(int) index3].b, cache[(int) index3].a);
      Gl.glTexCoord2f((float) cache[(int) index3].u * texture.textureWRatio, (float) cache[(int) index3].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index3].x, (float) cache[(int) index3].y, (float) cache[(int) index3].z);
      Gl.glColor4f(cache[(int) index4].r, cache[(int) index4].g, cache[(int) index4].b, cache[(int) index4].a);
      Gl.glTexCoord2f((float) cache[(int) index4].u * texture.textureWRatio, (float) cache[(int) index4].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index4].x, (float) cache[(int) index4].y, (float) cache[(int) index4].z);
      Gl.glColor4f(cache[(int) index5].r, cache[(int) index5].g, cache[(int) index5].b, cache[(int) index5].a);
      Gl.glTexCoord2f((float) cache[(int) index5].u * texture.textureWRatio, (float) cache[(int) index5].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index5].x, (float) cache[(int) index5].y, (float) cache[(int) index5].z);
      Gl.glColor4f(cache[(int) index6].r, cache[(int) index6].g, cache[(int) index6].b, cache[(int) index6].a);
      Gl.glTexCoord2f((float) cache[(int) index6].u * texture.textureWRatio, (float) cache[(int) index6].v * texture.textureHRatio);
      Gl.glVertex3f((float) cache[(int) index6].x, (float) cache[(int) index6].y, (float) cache[(int) index6].z);
      Gl.glEnd();
    }

    public void GL_TRI2_PICKING(byte[] com, ref F3DEX_VERT[] cache)
    {
      short index1 = (short) ((int) com[1] / 2);
      short index2 = (short) ((int) com[2] / 2);
      short index3 = (short) ((int) com[3] / 2);
      short index4 = (short) ((int) com[5] / 2);
      short index5 = (short) ((int) com[6] / 2);
      short index6 = (short) ((int) com[7] / 2);
      Gl.glBegin(4);
      Gl.glVertex3f((float) cache[(int) index1].x, (float) cache[(int) index1].y, (float) cache[(int) index1].z);
      Gl.glVertex3f((float) cache[(int) index2].x, (float) cache[(int) index2].y, (float) cache[(int) index2].z);
      Gl.glVertex3f((float) cache[(int) index3].x, (float) cache[(int) index3].y, (float) cache[(int) index3].z);
      Gl.glVertex3f((float) cache[(int) index4].x, (float) cache[(int) index4].y, (float) cache[(int) index4].z);
      Gl.glVertex3f((float) cache[(int) index5].x, (float) cache[(int) index5].y, (float) cache[(int) index5].z);
      Gl.glVertex3f((float) cache[(int) index6].x, (float) cache[(int) index6].y, (float) cache[(int) index6].z);
      Gl.glEnd();
    }

    public void GL_TRI2_PICKING(byte[] com, ref F3DEX_VERT[] cache, byte r, byte g, byte b)
    {
      short index1 = (short) ((int) com[1] / 2);
      short index2 = (short) ((int) com[2] / 2);
      short index3 = (short) ((int) com[3] / 2);
      short index4 = (short) ((int) com[5] / 2);
      short index5 = (short) ((int) com[6] / 2);
      short index6 = (short) ((int) com[7] / 2);
      Gl.glBegin(4);
      Gl.glColor3b(r, g, b);
      Gl.glVertex3f((float) cache[(int) index1].x, (float) cache[(int) index1].y, (float) cache[(int) index1].z);
      Gl.glVertex3f((float) cache[(int) index2].x, (float) cache[(int) index2].y, (float) cache[(int) index2].z);
      Gl.glVertex3f((float) cache[(int) index3].x, (float) cache[(int) index3].y, (float) cache[(int) index3].z);
      Gl.glVertex3f((float) cache[(int) index4].x, (float) cache[(int) index4].y, (float) cache[(int) index4].z);
      Gl.glVertex3f((float) cache[(int) index5].x, (float) cache[(int) index5].y, (float) cache[(int) index5].z);
      Gl.glVertex3f((float) cache[(int) index6].x, (float) cache[(int) index6].y, (float) cache[(int) index6].z);
      Gl.glEnd();
    }

    public void GL_TRI2_PICKING(
      byte[] com,
      ref F3DEX_VERT[] cache,
      byte r,
      byte g,
      byte b,
      byte r2,
      byte g2,
      byte b2)
    {
      short index1 = (short) ((int) com[1] / 2);
      short index2 = (short) ((int) com[2] / 2);
      short index3 = (short) ((int) com[3] / 2);
      short index4 = (short) ((int) com[5] / 2);
      short index5 = (short) ((int) com[6] / 2);
      short index6 = (short) ((int) com[7] / 2);
      Gl.glBegin(4);
      Gl.glColor3b(r, g, b);
      Gl.glVertex3f((float) cache[(int) index1].x, (float) cache[(int) index1].y, (float) cache[(int) index1].z);
      Gl.glVertex3f((float) cache[(int) index2].x, (float) cache[(int) index2].y, (float) cache[(int) index2].z);
      Gl.glVertex3f((float) cache[(int) index3].x, (float) cache[(int) index3].y, (float) cache[(int) index3].z);
      Gl.glColor3b(r2, g2, b2);
      Gl.glVertex3f((float) cache[(int) index4].x, (float) cache[(int) index4].y, (float) cache[(int) index4].z);
      Gl.glVertex3f((float) cache[(int) index5].x, (float) cache[(int) index5].y, (float) cache[(int) index5].z);
      Gl.glVertex3f((float) cache[(int) index6].x, (float) cache[(int) index6].y, (float) cache[(int) index6].z);
      Gl.glEnd();
    }

    public void GEN_F3D_TEXTURE(ref byte[] file, ref int f3dexlocation)
    {
      file[f3dexlocation] = (byte) 187;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 0;
      file[f3dexlocation + 3] = (byte) 1;
      file[f3dexlocation + 4] = (byte) 128;
      file[f3dexlocation + 5] = (byte) 0;
      file[f3dexlocation + 6] = (byte) 128;
      file[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
    }

    public void GEN_F3D_TEXTURE_EM(ref byte[] file, ref int f3dexlocation)
    {
      file[f3dexlocation] = (byte) 187;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 0;
      file[f3dexlocation + 3] = (byte) 1;
      file[f3dexlocation + 4] = (byte) 7;
      file[f3dexlocation + 5] = (byte) 192;
      file[f3dexlocation + 6] = (byte) 7;
      file[f3dexlocation + 7] = (byte) 192;
      f3dexlocation += 8;
    }

    public void GEN_F3D_SETOTHERMODE_H(ref byte[] file, ref int f3dexlocation)
    {
      file[f3dexlocation] = (byte) 186;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 14;
      file[f3dexlocation + 3] = (byte) 2;
      file[f3dexlocation + 4] = (byte) 0;
      file[f3dexlocation + 5] = (byte) 0;
      file[f3dexlocation + 6] = (byte) 128;
      file[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
    }

    public void GEN_G_SETTIMG(
      ref byte[] file,
      ref int f3dexlocation,
      int fmt,
      int pixSze,
      byte w,
      int offset)
    {
      file[f3dexlocation] = (byte) 253;
      file[f3dexlocation + 1] = (byte) ((fmt << 5) + (pixSze << 3));
      file[f3dexlocation + 2] = (byte) 0;
      file[f3dexlocation + 3] = (byte) 0;
      file[f3dexlocation + 4] = w;
      file[f3dexlocation + 5] = (byte) (offset >> 16);
      file[f3dexlocation + 6] = (byte) (offset >> 8);
      file[f3dexlocation + 7] = (byte) offset;
      f3dexlocation += 8;
    }

    public void GEN_G_RDPPIPESYNC(ref byte[] file, ref int f3dexlocation)
    {
      file[f3dexlocation] = (byte) 231;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 0;
      file[f3dexlocation + 3] = (byte) 0;
      file[f3dexlocation + 4] = (byte) 0;
      file[f3dexlocation + 5] = (byte) 0;
      file[f3dexlocation + 6] = (byte) 0;
      file[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
    }

    public void GEN_F3DDL(ref byte[] file, ref int f3dexlocation)
    {
      file[f3dexlocation] = (byte) 6;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 0;
      file[f3dexlocation + 3] = (byte) 0;
      file[f3dexlocation + 4] = (byte) 3;
      file[f3dexlocation + 5] = (byte) 0;
      file[f3dexlocation + 6] = (byte) 0;
      file[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
    }

    public void GEN_EndDL(ref byte[] file, ref int f3dexlocation)
    {
      file[f3dexlocation] = (byte) 184;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 0;
      file[f3dexlocation + 3] = (byte) 0;
      file[f3dexlocation + 4] = (byte) 0;
      file[f3dexlocation + 5] = (byte) 0;
      file[f3dexlocation + 6] = (byte) 0;
      file[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
    }

    public void GEN_VTX(ref byte[] file, ref int f3dexlocation, ref byte[] vtxCommand)
    {
      file[f3dexlocation] = (byte) 4;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 129;
      file[f3dexlocation + 3] = byte.MaxValue;
      file[f3dexlocation + 4] = (byte) 1;
      file[f3dexlocation + 5] = vtxCommand[5];
      file[f3dexlocation + 6] = vtxCommand[6];
      file[f3dexlocation + 7] = vtxCommand[7];
      f3dexlocation += 8;
    }

    public void GEN_TRI1(ref byte[] file, ref int f3dexlocation, int[] verts)
    {
      file[f3dexlocation] = (byte) 191;
      file[f3dexlocation + 1] = (byte) 0;
      file[f3dexlocation + 2] = (byte) 0;
      file[f3dexlocation + 3] = (byte) 0;
      file[f3dexlocation + 4] = (byte) 0;
      file[f3dexlocation + 5] = (byte) (verts[0] * 2);
      file[f3dexlocation + 6] = (byte) (verts[1] * 2);
      file[f3dexlocation + 7] = (byte) (verts[2] * 2);
      f3dexlocation += 8;
    }

    public void GEN_TRI2(ref byte[] file, ref int f3dexlocation, int[] verts, int[] verts2)
    {
      file[f3dexlocation] = (byte) 177;
      file[f3dexlocation + 1] = (byte) (verts[0] * 2);
      file[f3dexlocation + 2] = (byte) (verts[1] * 2);
      file[f3dexlocation + 3] = (byte) (verts[2] * 2);
      file[f3dexlocation + 4] = (byte) 0;
      file[f3dexlocation + 5] = (byte) (verts2[0] * 2);
      file[f3dexlocation + 6] = (byte) (verts2[1] * 2);
      file[f3dexlocation + 7] = (byte) (verts2[2] * 2);
      f3dexlocation += 8;
    }

    public void GEN_G_LOADTLUT(ref byte[] file, ref int f3dexlocation, int[] verts, int[] verts2)
    {
    }

    public void GEN_DLNoTextures(
      ref byte[] header,
      ref int f3dexlocation,
      int cullMode,
      byte texMode)
    {
      header[f3dexlocation] = (byte) 182;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 31;
      header[f3dexlocation + 6] = (byte) 50;
      header[f3dexlocation + 7] = (byte) 4;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 183;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = texMode;
      header[f3dexlocation + 6] = (byte) cullMode;
      header[f3dexlocation + 7] = (byte) 4;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 186;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 14;
      header[f3dexlocation + 3] = (byte) 2;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 128;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 231;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 252;
      header[f3dexlocation + 1] = (byte) 98;
      header[f3dexlocation + 2] = (byte) 254;
      header[f3dexlocation + 3] = (byte) 4;
      header[f3dexlocation + 4] = (byte) 63;
      header[f3dexlocation + 5] = (byte) 21;
      header[f3dexlocation + 6] = (byte) 249;
      header[f3dexlocation + 7] = byte.MaxValue;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 6;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 3;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 32;
      f3dexlocation += 8;
    }

    public void CI2F3dex(
      ref byte[] header,
      ref int f3dexlocation,
      TextureOffset textureOffset,
      int cullMode,
      byte texMode)
    {
      header[f3dexlocation] = (byte) 182;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 31;
      header[f3dexlocation + 6] = (byte) 50;
      header[f3dexlocation + 7] = (byte) 4;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 183;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = texMode;
      header[f3dexlocation + 6] = (byte) cullMode;
      header[f3dexlocation + 7] = (byte) 4;
      f3dexlocation += 8;
      if (texMode == (byte) 8)
        this.GEN_F3D_TEXTURE(ref header, ref f3dexlocation);
      else
        this.GEN_F3D_TEXTURE_EM(ref header, ref f3dexlocation);
      this.GEN_G_SETTIMG(ref header, ref f3dexlocation, F3DEX.FMT_RGBA, F3DEX.PS_16, (byte) 2, textureOffset.offset);
      header[f3dexlocation] = (byte) 245;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 1;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 1;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      if (textureOffset.palSize == 16)
      {
        header[f3dexlocation] = (byte) 240;
        header[f3dexlocation + 1] = (byte) 0;
        header[f3dexlocation + 2] = (byte) 0;
        header[f3dexlocation + 3] = (byte) 0;
        header[f3dexlocation + 4] = (byte) 1;
        header[f3dexlocation + 5] = (byte) 3;
        header[f3dexlocation + 6] = (byte) 192;
        header[f3dexlocation + 7] = (byte) 0;
      }
      else
      {
        header[f3dexlocation] = (byte) 240;
        header[f3dexlocation + 1] = (byte) 0;
        header[f3dexlocation + 2] = (byte) 0;
        header[f3dexlocation + 3] = (byte) 0;
        header[f3dexlocation + 4] = (byte) 1;
        header[f3dexlocation + 5] = (byte) 63;
        header[f3dexlocation + 6] = (byte) 192;
        header[f3dexlocation + 7] = (byte) 0;
      }
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 186;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 14;
      header[f3dexlocation + 3] = (byte) 2;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 128;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 253;
      header[f3dexlocation + 1] = (byte) 80;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 2;
      int num1 = textureOffset.palSize != 16 ? textureOffset.offset + 512 : textureOffset.offset + 32;
      header[f3dexlocation + 5] = (byte) (num1 >> 16);
      header[f3dexlocation + 6] = (byte) (num1 >> 8);
      header[f3dexlocation + 7] = (byte) num1;
      f3dexlocation += 8;
      byte num2 = 0;
      byte num3 = 0;
      if (textureOffset.height == 64)
        num2 = (byte) 128;
      if (textureOffset.width == 64)
        num3 = (byte) 96;
      if (textureOffset.height == 32)
        num2 = (byte) 64;
      if (textureOffset.width == 32)
        num3 = (byte) 80;
      if (textureOffset.height == 16)
        num2 = (byte) 0;
      if (textureOffset.width == 16)
        num3 = (byte) 64;
      if (textureOffset.height == 32 && textureOffset.width == 32)
      {
        num3 = (byte) 80;
        num2 = (byte) 64;
      }
      header[f3dexlocation] = (byte) 245;
      header[f3dexlocation + 1] = (byte) 80;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 7;
      header[f3dexlocation + 5] = (byte) 1;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      byte num4 = 63;
      byte num5 = 242;
      if (textureOffset.height == 64 && textureOffset.width == 64)
      {
        num4 = (byte) 63;
        num5 = (byte) 242;
      }
      else if (textureOffset.height == 32 && textureOffset.width == 32 && textureOffset.palSize != 16)
      {
        num4 = (byte) 31;
        num5 = (byte) 242;
      }
      else if (textureOffset.height == 32 && textureOffset.width == 32 && textureOffset.palSize == 16)
      {
        num4 = (byte) 63;
        num5 = (byte) 244;
      }
      else if (textureOffset.height == 64 && textureOffset.width == 32 && textureOffset.palSize != 16)
      {
        num4 = (byte) 63;
        num5 = (byte) 242;
      }
      else if (textureOffset.height == 64 && textureOffset.width == 32 && textureOffset.palSize == 16)
      {
        num4 = (byte) 63;
        num5 = (byte) 244;
      }
      else if (textureOffset.height == 32 && textureOffset.width == 64 && textureOffset.palSize != 16)
      {
        num4 = (byte) 63;
        num5 = (byte) 241;
      }
      else if (textureOffset.height == 32 && textureOffset.width == 64 && textureOffset.palSize == 16)
      {
        num4 = (byte) 63;
        num5 = (byte) 242;
      }
      header[f3dexlocation] = (byte) 243;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 7;
      header[f3dexlocation + 5] = num4;
      header[f3dexlocation + 6] = num5;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      int num6 = textureOffset.width / 8;
      byte num7 = (byte) (textureOffset.cmt << 2);
      if (textureOffset.palSize == 16)
      {
        header[f3dexlocation] = (byte) 245;
        header[f3dexlocation + 1] = (byte) 64;
        header[f3dexlocation + 2] = (byte) num6;
        header[f3dexlocation + 3] = (byte) 0;
        header[f3dexlocation + 4] = (byte) 0;
        header[f3dexlocation + 5] = (byte) (1U + (uint) num7);
        header[f3dexlocation + 6] = (byte) ((uint) num2 + (uint) (byte) textureOffset.cms);
        header[f3dexlocation + 7] = num3;
        f3dexlocation += 8;
      }
      else
      {
        int num8 = num6 * 2;
        header[f3dexlocation] = (byte) 245;
        header[f3dexlocation + 1] = (byte) 72;
        header[f3dexlocation + 2] = (byte) num8;
        header[f3dexlocation + 3] = (byte) 0;
        header[f3dexlocation + 4] = (byte) 0;
        header[f3dexlocation + 5] = (byte) (1U + (uint) num7);
        header[f3dexlocation + 6] = (byte) ((uint) num2 + (uint) (byte) textureOffset.cms);
        header[f3dexlocation + 7] = num3;
        f3dexlocation += 8;
      }
      int num9 = textureOffset.width - 1;
      int num10 = textureOffset.height - 1;
      byte num11 = (byte) (num9 >> 2);
      byte num12 = (byte) (num9 << 6);
      byte num13 = (byte) (num10 >> 6);
      int num14 = (int) (byte) (num10 << 2);
      byte num15 = num11;
      byte num16 = (byte) ((uint) num12 + (uint) num13);
      byte num17 = (byte) num14;
      header[f3dexlocation] = (byte) 242;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = num15;
      header[f3dexlocation + 6] = num16;
      header[f3dexlocation + 7] = num17;
      f3dexlocation += 8;
      header[f3dexlocation] = (byte) 231;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 0;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 0;
      f3dexlocation += 8;
      if (texMode == (byte) 8)
      {
        header[f3dexlocation] = (byte) 252;
        header[f3dexlocation + 1] = (byte) 18;
        header[f3dexlocation + 2] = (byte) 152;
        header[f3dexlocation + 3] = (byte) 4;
        header[f3dexlocation + 4] = (byte) 63;
        header[f3dexlocation + 5] = (byte) 21;
        header[f3dexlocation + 6] = byte.MaxValue;
        header[f3dexlocation + 7] = byte.MaxValue;
        f3dexlocation += 8;
      }
      else
      {
        header[f3dexlocation] = (byte) 252;
        header[f3dexlocation + 1] = byte.MaxValue;
        header[f3dexlocation + 2] = (byte) 153;
        header[f3dexlocation + 3] = byte.MaxValue;
        header[f3dexlocation + 4] = byte.MaxValue;
        header[f3dexlocation + 5] = (byte) 20;
        header[f3dexlocation + 6] = (byte) 254;
        header[f3dexlocation + 7] = (byte) 63;
        f3dexlocation += 8;
      }
      header[f3dexlocation] = (byte) 6;
      header[f3dexlocation + 1] = (byte) 0;
      header[f3dexlocation + 2] = (byte) 0;
      header[f3dexlocation + 3] = (byte) 0;
      header[f3dexlocation + 4] = (byte) 3;
      header[f3dexlocation + 5] = (byte) 0;
      header[f3dexlocation + 6] = (byte) 0;
      header[f3dexlocation + 7] = (byte) 32;
      f3dexlocation += 8;
    }

    public void ExportTexture(ref byte[] bytesInFile, ref Texture texture, int textureDataOffset)
    {
      byte[] numArray1 = new byte[texture.textureWidth * texture.textureHeight * 4];
      int index1 = 0;
      byte[] numArray2 = new byte[texture.textureSize];
      int num1 = !texture.palLoaded ? (int) texture.textureOffset + 64 + textureDataOffset : (int) texture.indexOffset + 64 + textureDataOffset;
      try
      {
        for (int index2 = 0; index2 < numArray2.Length; ++index2)
        {
          if (num1 + index2 < bytesInFile.Length)
            numArray2[index2] = bytesInFile[num1 + index2];
          else
            break;
        }
      }
      catch (Exception ex)
      {
      }
      if (texture.pixels != null)
        return;
      if (this.textureFormat == 0)
      {
        if (this.texelSize == 2)
        {
          uint index3 = 0;
          try
          {
            for (int index4 = 0; index4 < texture.textureHeight; ++index4)
            {
              for (int index5 = 0; index5 < texture.textureWidth; ++index5)
              {
                ushort num2 = (ushort) ((uint) numArray2[(int) index3] * 256U + (uint) numArray2[(int) index3 + 1]);
                byte num3 = (byte) ((uint) (byte) ((uint) numArray2[(int) index3 + 1] << 7) >> 7) != (byte) 0 ? byte.MaxValue : (byte) 0;
                numArray1[index1] = (byte) (((int) num2 & 63488) >> 8);
                numArray1[index1 + 1] = (byte) (((int) num2 & 1984) << 5 >> 8);
                numArray1[index1 + 2] = (byte) (((int) num2 & 62) << 18 >> 16);
                numArray1[index1 + 3] = num3;
                index3 += 2U;
                index1 += 4;
              }
              if (this.lineSize > 0)
                index3 += (uint) (this.lineSize * 4 - texture.textureWidth);
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (this.texelSize == 3)
        {
          Gl.glEnable(3553);
          try
          {
            for (int index6 = 0; index6 < numArray1.Length; ++index6)
              numArray1[index6] = bytesInFile[num1 + index6];
          }
          catch (Exception ex)
          {
          }
        }
      }
      else if (this.textureFormat == 2)
      {
        if (this.texelSize == 0)
        {
          try
          {
            int index7 = 0;
            for (int index8 = 0; index8 < texture.textureHeight; ++index8)
            {
              for (int index9 = 0; index9 < texture.textureWidth / 2; ++index9)
              {
                byte index10 = (byte) ((uint) numArray2[index7] >> 4);
                byte index11 = (byte) ((uint) (byte) ((uint) numArray2[index7] << 4) >> 4);
                numArray1[index1] = texture.red[(int) index10];
                numArray1[index1 + 1] = texture.green[(int) index10];
                numArray1[index1 + 2] = texture.blue[(int) index10];
                numArray1[index1 + 3] = texture.alpha[(int) index10];
                numArray1[index1 + 4] = texture.red[(int) index11];
                numArray1[index1 + 5] = texture.green[(int) index11];
                numArray1[index1 + 6] = texture.blue[(int) index11];
                numArray1[index1 + 7] = texture.alpha[(int) index11];
                index1 += 8;
                ++index7;
              }
              index7 += this.lineSize * 8 - texture.textureWidth / 2;
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (this.texelSize == 1)
        {
          try
          {
            int index12 = 0;
            for (int index13 = 0; index13 < texture.textureHeight; ++index13)
            {
              for (int index14 = 0; index14 < texture.textureWidth; ++index14)
              {
                numArray1[index1] = texture.red[(int) numArray2[index12]];
                numArray1[index1 + 1] = texture.green[(int) numArray2[index12]];
                numArray1[index1 + 2] = texture.blue[(int) numArray2[index12]];
                numArray1[index1 + 3] = texture.alpha[(int) numArray2[index12]];
                index1 += 4;
                ++index12;
              }
              index12 += this.lineSize * 8 - texture.textureWidth;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      else if (this.textureFormat == 3)
      {
        if (this.texelSize == 1)
        {
          try
          {
            int index15 = 0;
            for (int index16 = 0; index16 < texture.textureHeight; ++index16)
            {
              for (int index17 = 0; index17 < texture.textureWidth; ++index17)
              {
                byte num4 = (byte) ((uint) numArray2[index15] >> 4);
                byte num5 = (byte) ((int) numArray2[index15] << 4 >> 4);
                numArray1[index1] = (byte) ((uint) num4 * 17U);
                numArray1[index1 + 1] = (byte) ((uint) num4 * 17U);
                numArray1[index1 + 2] = (byte) ((uint) num4 * 17U);
                numArray1[index1 + 3] = (byte) ((uint) num5 * 17U);
                index1 += 4;
                ++index15;
              }
              index15 += this.lineSize * 8 - texture.textureWidth;
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (this.texelSize == 2)
        {
          Gl.glEnable(3553);
          try
          {
            int index18 = 0;
            for (int index19 = 0; index19 < texture.textureHeight; ++index19)
            {
              for (int index20 = 0; index20 < texture.textureWidth; ++index20)
              {
                byte num6 = numArray2[index18];
                byte num7 = numArray2[index18 + 1];
                numArray1[index1] = num6;
                numArray1[index1 + 1] = num6;
                numArray1[index1 + 2] = num6;
                numArray1[index1 + 3] = num7;
                index1 += 4;
                index18 += 2;
              }
              index18 += this.lineSize * 4 - texture.textureWidth;
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      else if (this.textureFormat == 3)
      {
        if (this.texelSize == 0)
        {
          Gl.glEnable(3553);
          try
          {
            for (int index21 = 0; index21 < numArray2.Length / 2; ++index21)
            {
              byte num8 = (byte) ((uint) numArray2[index21] >> 4);
              numArray1[index21 * 8] = (byte) ((uint) num8 * 17U);
              numArray1[index21 * 8 + 1] = (byte) ((uint) num8 * 17U);
              numArray1[index21 * 8 + 2] = (byte) ((uint) num8 * 17U);
              numArray1[index21 * 8 + 3] = (byte) ((uint) num8 * 17U);
              byte num9 = (byte) ((uint) (byte) ((uint) numArray2[index21] << 4) >> 4);
              numArray1[index21 * 4] = (byte) ((uint) num9 * 17U);
              numArray1[index21 * 5 + 1] = (byte) ((uint) num9 * 17U);
              numArray1[index21 * 6 + 2] = (byte) ((uint) num9 * 17U);
              numArray1[index21 * 7 + 3] = (byte) ((uint) num9 * 17U);
            }
          }
          catch (Exception ex)
          {
          }
        }
        if (this.texelSize == 1)
        {
          Gl.glEnable(3553);
          try
          {
            for (int index22 = 0; index22 < numArray2.Length; ++index22)
            {
              byte num10 = (byte) ((uint) numArray2[index22] / 16U);
              numArray1[index22 * 4] = (byte) ((uint) num10 * 17U);
              numArray1[index22 * 4 + 1] = (byte) ((uint) num10 * 17U);
              numArray1[index22 * 4 + 2] = (byte) ((uint) num10 * 17U);
              numArray1[index22 * 4 + 3] = (byte) ((uint) num10 * 17U);
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      texture.pixels = numArray1;
    }
  }
}
