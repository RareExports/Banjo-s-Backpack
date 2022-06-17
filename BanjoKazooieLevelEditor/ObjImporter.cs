// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ObjImporter
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  internal class ObjImporter
  {
    public List<VertProperties> vertColours = new List<VertProperties>();
    public List<VertProperties> alphaVertColours = new List<VertProperties>();
    public List<VertProperties> TotalAlphaVertPoperties = new List<VertProperties>();
    public List<VertProperties> TotalVertPoperties = new List<VertProperties>();
    private float vertScale = 1000f;
    private List<int[]> verts = new List<int[]>();
    private List<double[]> vertTs = new List<double[]>();
    private List<int> F3DVerts = new List<int>();
    private List<int> F3DCVerts = new List<int>();
    private List<int[]> faceVs = new List<int[]>();
    private List<int[]> faceVTs = new List<int[]>();
    private List<int[]> faceCs = new List<int[]>();
    private List<string> faceTextureMap = new List<string>();
    private List<int[]> alphaVerts = new List<int[]>();
    private List<double[]> alphaVertTs = new List<double[]>();
    public List<int[]> alphaFaceVs = new List<int[]>();
    private List<int[]> alphaFaceVTs = new List<int[]>();
    private List<int[]> alphaFaceCs = new List<int[]>();
    private List<string> alphafaceTextureMap = new List<string>();
    private bool[] isAlpha;
    private string[] textureNames;
    private string[] textureFiles;
    private List<int> texturePalSize = new List<int>();
    private List<string> alphaTextureNames;
    private string[] alphaTextureFiles;
    private List<int> alphaTexturePalSize = new List<int>();
    private string dir = "";
    private byte[] pixels5551;
    private ArrayList completeCITextures = new ArrayList();
    private List<byte[]> completeAlphaTextures = new List<byte[]>();
    private byte[] completeCITexture;
    private int width;
    private int height;
    private float originalScale;
    private List<int[]> vertsO = new List<int[]>();
    private List<int[]> alphaVertsO = new List<int[]>();
    public F3DEX f3dex = new F3DEX();

    private void RipOBJMesh(ref string obj)
    {
      char[] separator = new char[2]{ '\r', '\n' };
      string[] strArray = obj.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (Regex.IsMatch(strArray[index], "^v "))
        {
          Match match = Regex.Match(strArray[index], "^v (\\S+) (\\S+) (\\S+)");
          if (match.Success)
          {
            double num1 = Convert.ToDouble(match.Groups[1].Value) * (double) this.vertScale;
            double num2 = Convert.ToDouble(match.Groups[2].Value) * (double) this.vertScale;
            double num3 = Convert.ToDouble(match.Groups[3].Value) * (double) this.vertScale;
            this.verts.Add(new int[3]
            {
              Convert.ToInt32(num1),
              Convert.ToInt32(num2),
              Convert.ToInt32(num3)
            });
          }
        }
        if (Regex.IsMatch(strArray[index], "^vt "))
        {
          Match match = Regex.Match(strArray[index], "^vt (\\S+) (\\S+)");
          if (match.Success)
            this.vertTs.Add(new double[2]
            {
              Convert.ToDouble(match.Groups[1].Value),
              Convert.ToDouble(match.Groups[2].Value)
            });
        }
        if (Regex.IsMatch(strArray[index], "^#vcolor "))
        {
          Match match = Regex.Match(strArray[index], "#vcolor ([\\d.]+) ([\\d.]+) ([\\d.]+) ?([\\d.]+)?");
          if (match.Success)
            this.vertColours.Add(new VertProperties()
            {
              red = Convert.ToByte(Convert.ToDouble(match.Groups[1].Value)),
              green = Convert.ToByte(Convert.ToDouble(match.Groups[2].Value)),
              blue = Convert.ToByte(Convert.ToDouble(match.Groups[3].Value)),
              alpha = match.Groups[4].Value == string.Empty ? byte.MaxValue : Convert.ToByte(Convert.ToDouble(match.Groups[4].Value))
            });
        }
      }
      if (this.vertTs.Count != 0)
        return;
      this.vertTs.Add(new double[2]);
    }

    private void RipFaces(ref string obj)
    {
      Regex regex1 = new Regex("^f \\d+(?:\\/\\d+){0,2} \\d+(?:\\/\\d+){0,2}[\\r\\n]?$", RegexOptions.Multiline);
      obj = regex1.Replace(obj, "");
      Regex regex2 = new Regex("^f (\\d+(?:\\/\\d+){0,2}) (\\d+(?:\\/\\d+){0,2}) (\\d+(?:\\/\\d+){0,2}) (\\d+(?:\\/\\d+){0,2})\\r?\\n#fvcolorindex (\\d+) (\\d+) (\\d+) (\\d+)");
      obj = regex2.Replace(obj, "f $1 $2 $3\r\n#fvcolorindex $5 $6 $7\r\nf $3 $4 $1\r\n#fvcolorindex $7 $8 $5");
      Regex regex3 = new Regex("^f (\\d+(?:\\/\\d+){0,2}) (\\d+(?:\\/\\d+){0,2}) (\\d+(?:\\/\\d+){0,2}) (\\d+(?:\\/\\d+){0,2})$", RegexOptions.Multiline);
      obj = regex3.Replace(obj, "f $1 $2 $3\r\nf $3 $4 $1");
      Regex regex4 = new Regex("^f (\\d+(?:\\/\\d+){0,2} ){4,}.*$");
      obj = regex4.Replace(obj, "");
      Regex regex5 = new Regex("^#fvcolorindex (?:\\d+ ){4,}.*$", RegexOptions.Multiline);
      obj = regex5.Replace(obj, "");
      string str1 = "";
      int num = 0;
      char[] separator = new char[2]{ '\r', '\n' };
      string[] strArray = obj.Split(separator, StringSplitOptions.RemoveEmptyEntries);
      for (int index = 0; index < strArray.Length; ++index)
      {
        if (Regex.IsMatch(strArray[index], ".*usemtl.*"))
        {
          Match match = Regex.Match(strArray[index], ".*usemtl (.*)");
          if (match.Success)
            str1 = match.Groups[1].Value;
        }
        if (Regex.IsMatch(strArray[index], "^f "))
        {
          Match match1 = Regex.Match(strArray[index], "^f (\\d+)\\/?(\\d+)?(?:\\/\\d+)? (\\d+)\\/?(\\d+)?(?:\\/\\d+)? (\\d+)\\/?(\\d+)?(?:\\/\\d+)?");
          if (match1.Success)
          {
            this.faceVs.Add(new int[3]
            {
              Convert.ToInt32(match1.Groups[1].Value) - 1,
              Convert.ToInt32(match1.Groups[3].Value) - 1,
              Convert.ToInt32(match1.Groups[5].Value) - 1
            });
            this.faceVTs.Add(new int[3]
            {
              match1.Groups[2].Value == string.Empty ? 0 : Convert.ToInt32(match1.Groups[2].Value) - 1,
              match1.Groups[4].Value == string.Empty ? 0 : Convert.ToInt32(match1.Groups[4].Value) - 1,
              match1.Groups[6].Value == string.Empty ? 0 : Convert.ToInt32(match1.Groups[6].Value) - 1
            });
          }
          if (index + 1 == strArray.Length)
          {
            this.faceCs.Add(new int[3]{ -1, -1, -1 });
          }
          else
          {
            int[] numArray = new int[3]{ -1, -1, -1 };
            Match match2 = Regex.Match(strArray[index + 1], "^#fvcolorindex (\\d+) (\\d+) (\\d+)");
            if (match2.Success)
            {
              numArray[0] = match2.Groups[1].Value == string.Empty ? -1 : Convert.ToInt32(match2.Groups[1].Value) - 1;
              numArray[1] = match2.Groups[2].Value == string.Empty ? -1 : Convert.ToInt32(match2.Groups[2].Value) - 1;
              numArray[2] = match2.Groups[3].Value == string.Empty ? -1 : Convert.ToInt32(match2.Groups[3].Value) - 1;
            }
            this.faceCs.Add(numArray);
          }
          this.faceTextureMap.Add(str1);
          ++num;
        }
      }
      if (this.textureNames.Length == 0)
        return;
      string str2 = this.textureNames[0];
      for (int index1 = 0; index1 < this.faceTextureMap.Count; ++index1)
      {
        bool flag = false;
        for (int index2 = 0; index2 < this.textureNames.Length && !flag; ++index2)
        {
          if (this.faceTextureMap[index1] == this.textureNames[index2])
          {
            flag = true;
            str2 = this.faceTextureMap[index1];
          }
        }
        if (!flag)
          this.faceTextureMap[index1] = str2;
      }
    }

    private void RipMTL(ref string obj)
    {
      Match match1 = Regex.Match(obj, "mtllib (.*)", RegexOptions.IgnoreCase);
      if (match1.Success)
      {
        string path = this.dir + match1.Groups[1].Value;
        if (File.Exists(path))
        {
          StreamReader streamReader = new StreamReader((Stream) File.Open(path, FileMode.Open));
          string end = streamReader.ReadToEnd();
          streamReader.Close();
          this.StripLeadingSpaceAndDoubleSpaces(ref end);
          List<string> stringList1 = new List<string>();
          List<string> stringList2 = new List<string>();
          char[] separator = new char[2]{ '\r', '\n' };
          string[] strArray = end.Split(separator, StringSplitOptions.RemoveEmptyEntries);
          for (int index = 0; index < strArray.Length; ++index)
          {
            if (Regex.IsMatch(strArray[index], "newmtl "))
            {
              Match match2 = Regex.Match(strArray[index], "newmtl (.*)", RegexOptions.IgnoreCase);
              if (match2.Success)
              {
                string str = match2.Groups[1].Value.Trim();
                bool flag = false;
                while (index < strArray.Length && !flag)
                {
                  ++index;
                  Match match3 = Regex.Match(strArray[index], "map_?Kd (.*)", RegexOptions.IgnoreCase);
                  if (match3.Success)
                  {
                    flag = true;
                    stringList1.Add(str);
                    stringList2.Add(match3.Groups[1].Value.Trim());
                  }
                  else if (Regex.Match(strArray[index], "newmtl (.*)", RegexOptions.IgnoreCase).Success || index == strArray.Length - 1)
                  {
                    flag = true;
                    --index;
                    stringList1.Add(str);
                    stringList2.Add("");
                  }
                }
              }
            }
          }
          this.textureNames = stringList1.ToArray();
          this.textureFiles = stringList2.ToArray();
        }
        else
        {
          this.textureNames = new string[0];
          this.textureFiles = new string[0];
        }
      }
      else
      {
        this.textureNames = new string[0];
        this.textureFiles = new string[0];
      }
    }

    private void RipTextureCI(
      ref List<TextureData> TextureDataList,
      ref List<TextureData> TextureDataAlphaList,
      ref List<TextureSetting> TextureSettingsList,
      ref List<TextureSetting> TextureSettingsAlphaList)
    {
      string str = "";
      try
      {
        this.texturePalSize = new List<int>();
        this.isAlpha = new bool[this.textureFiles.Length];
        for (int index = 0; index < this.textureFiles.Length; ++index)
        {
          this.isAlpha[index] = false;
          if (this.textureFiles[index] != "" && this.textureFiles[index] != null)
          {
            str = this.dir + this.textureFiles[index];
            Bitmap image = new Bitmap(this.dir + this.textureFiles[index]);
            ImageHandler.CorrectSize(ref image);
            int width = image.Width;
            int height = image.Height;
            List<Color> uniqueColors = ImageHandler.GetUniqueColors(ref image);
            bool alpha = false;
            if (uniqueColors.Count <= 22 || width * height >= 4096)
            {
              if (uniqueColors.Count > 16)
                image = ImageHandler.ConvertTo16Colour(image);
              TextureData textureData = new TextureData(ImageHandler.ConvertImageToCI4(image, ref alpha), ImageHandler.ConvertImageToRGBA8888(image), image.Width, image.Height);
              if (alpha)
              {
                TextureDataAlphaList.Add(textureData);
                TextureSetting textureSetting = new TextureSetting(textureData.width, textureData.height, 0, 0, TextureDataAlphaList.Count<TextureData>() - 1);
                textureSetting.name = this.textureNames[index];
                textureSetting.setRatio(0.5f, 0.5f);
                textureSetting.palSize = 16;
                textureSetting.ISALPHA = true;
                textureSetting.cull_back = true;
                TextureSettingsAlphaList.Add(textureSetting);
              }
              else
              {
                TextureDataList.Add(textureData);
                TextureSetting textureSetting = new TextureSetting(textureData.width, textureData.height, 0, 0, TextureDataList.Count<TextureData>() - 1);
                textureSetting.name = this.textureNames[index];
                textureSetting.setRatio(0.5f, 0.5f);
                textureSetting.palSize = 16;
                textureSetting.cull_back = true;
                TextureSettingsList.Add(textureSetting);
              }
              this.texturePalSize.Add(16);
            }
            else if (width * height < 4096)
            {
              this.texturePalSize.Add(256);
              if (uniqueColors.Count > 256)
                image = ImageHandler.ConvertTo256Colour(image);
              TextureData textureData = new TextureData(ImageHandler.ConvertImageToCI8(image, ref alpha), ImageHandler.ConvertImageToRGBA8888(image), image.Width, image.Height);
              if (alpha)
              {
                TextureDataAlphaList.Add(textureData);
                TextureSetting textureSetting = new TextureSetting(textureData.width, textureData.height, 0, 0, TextureDataAlphaList.Count<TextureData>() - 1);
                textureSetting.name = this.textureNames[index];
                textureSetting.setRatio(0.5f, 0.5f);
                textureSetting.palSize = 256;
                textureSetting.ISALPHA = true;
                textureSetting.cull_back = true;
                TextureSettingsAlphaList.Add(textureSetting);
              }
              else
              {
                TextureDataList.Add(textureData);
                TextureSetting textureSetting = new TextureSetting(textureData.width, textureData.height, 0, 0, TextureDataList.Count<TextureData>() - 1);
                textureSetting.name = this.textureNames[index];
                textureSetting.setRatio(0.5f, 0.5f);
                textureSetting.palSize = 256;
                textureSetting.cull_back = true;
                TextureSettingsList.Add(textureSetting);
              }
            }
          }
          else
          {
            TextureDataList.Add(new TextureData());
            TextureSetting textureSetting = new TextureSetting(0, 0, 0, 0, -1);
            textureSetting.name = this.textureNames[index];
            textureSetting.setRatio(0.5f, 0.5f);
            textureSetting.cull_back = true;
            TextureSettingsList.Add(textureSetting);
            this.texturePalSize.Add(0);
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occured while converting texture " + str + ", please check all files are present and try again.");
      }
    }

    private void RipTexture5551(string texture, int index)
    {
      Bitmap bitmap1 = new Bitmap(this.dir + texture);
      if (bitmap1.PixelFormat == PixelFormat.Format8bppIndexed || bitmap1.PixelFormat == PixelFormat.Format4bppIndexed)
      {
        Bitmap bitmap2 = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppPArgb);
        using (Graphics graphics = Graphics.FromImage((Image) bitmap2))
          graphics.DrawImage((Image) bitmap1, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height));
        bitmap1 = bitmap2;
      }
      Color[] colorArray = new Color[bitmap1.Width * bitmap1.Height];
      int index1 = 0;
      for (int y = 0; y < bitmap1.Height; ++y)
      {
        for (int x = 0; x < bitmap1.Width; ++x)
        {
          colorArray[index1] = bitmap1.GetPixel(x, y);
          ++index1;
        }
      }
      byte[] numArray = new byte[bitmap1.Width * bitmap1.Height * 4];
      this.width = bitmap1.Width;
      this.height = bitmap1.Height;
      int index2 = 0;
      for (int index3 = 0; index3 < colorArray.Length; ++index3)
      {
        numArray[index2] = colorArray[index3].R;
        numArray[index2 + 1] = colorArray[index3].G;
        numArray[index2 + 2] = colorArray[index3].B;
        numArray[index2 + 3] = colorArray[index3].A;
        index2 += 4;
      }
      this.pixels5551 = new byte[bitmap1.Width * bitmap1.Height * 2];
      int index4 = 0;
      for (int index5 = 0; index5 < numArray.Length; index5 += 4)
      {
        byte num1 = (byte) ((int) numArray[index5] >> 3 << 3);
        int num2 = (int) (byte) ((int) numArray[index5 + 1] >> 3 << 3);
        byte num3 = (byte) ((int) numArray[index5 + 2] >> 3 << 3);
        byte num4;
        if (numArray[index5 + 3] == (byte) 0)
        {
          num4 = (byte) 0;
          this.isAlpha[index] = true;
        }
        else
          num4 = (byte) 1;
        byte num5 = (byte) (num2 >> 5);
        byte num6 = (byte) ((uint) num1 + (uint) num5);
        byte num7 = (byte) ((uint) (byte) (num2 << 3) + ((uint) num3 >> 2) + (uint) num4);
        this.pixels5551[index4] = num6;
        this.pixels5551[index4 + 1] = num7;
        index4 += 2;
      }
      this.completeCITextures.Add((object) this.pixels5551);
    }

    private void RecenterUVs()
    {
      try
      {
        for (int index = 0; index < this.faceVTs.Count; ++index)
        {
          if (this.faceVTs[index][0] != -1 && this.faceVTs[index][1] != -1)
          {
            int num1 = this.faceVTs[index][2];
          }
          if (this.faceVTs[index][0] != -1 && this.faceVTs[index][1] != -1 && this.faceVTs[index][2] != -1)
          {
            double num2 = Math.Round((this.vertTs[this.faceVTs[index][0]][0] + this.vertTs[this.faceVTs[index][1]][0] + this.vertTs[this.faceVTs[index][2]][0]) / 3.0);
            double[] numArray1 = new double[2]
            {
              this.vertTs[this.faceVTs[index][0]][0],
              this.vertTs[this.faceVTs[index][0]][1]
            };
            double[] numArray2 = new double[2]
            {
              this.vertTs[this.faceVTs[index][1]][0],
              this.vertTs[this.faceVTs[index][1]][1]
            };
            double[] numArray3 = new double[2]
            {
              this.vertTs[this.faceVTs[index][2]][0],
              this.vertTs[this.faceVTs[index][2]][1]
            };
            bool flag = false;
            if (num2 > 1.0 || num2 < 1.0)
            {
              numArray1[0] -= num2;
              numArray2[0] -= num2;
              numArray3[0] -= num2;
              flag = true;
            }
            double num3 = Math.Round((this.vertTs[this.faceVTs[index][0]][1] + this.vertTs[this.faceVTs[index][1]][1] + this.vertTs[this.faceVTs[index][2]][1]) / 3.0);
            if (num3 > 1.0 || num3 < 1.0)
            {
              numArray1[1] -= num3;
              numArray2[1] -= num3;
              numArray3[1] -= num3;
              flag = true;
            }
            if (flag)
            {
              this.vertTs.Add(numArray1);
              this.vertTs.Add(numArray2);
              this.vertTs.Add(numArray3);
              this.faceVTs[index][2] = this.vertTs.Count - 1;
              this.faceVTs[index][1] = this.vertTs.Count - 2;
              this.faceVTs[index][0] = this.vertTs.Count - 3;
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void CopyVerts()
    {
      for (int index = 0; index < this.verts.Count; ++index)
        this.vertsO.Add(new int[3]
        {
          this.verts[index][0],
          this.verts[index][1],
          this.verts[index][2]
        });
      for (int index = 0; index < this.alphaVerts.Count; ++index)
        this.alphaVertsO.Add(new int[3]
        {
          this.alphaVerts[index][0],
          this.alphaVerts[index][1],
          this.alphaVerts[index][2]
        });
    }

    private void CalcPrecision(int attemptNo)
    {
      bool flag = false;
      for (int index1 = 0; index1 < this.verts.Count && !flag; ++index1)
      {
        for (int index2 = 0; index2 < 3 && !flag; ++index2)
        {
          if (this.verts[index1][index2] >= (int) short.MaxValue || this.verts[index1][index2] <= -32767)
          {
            this.vertScale = 1f / (float) attemptNo;
            flag = true;
          }
        }
      }
      for (int index3 = 0; index3 < this.alphaVerts.Count && !flag; ++index3)
      {
        for (int index4 = 0; index4 < 3 && !flag; ++index4)
        {
          if (this.alphaVerts[index3][index4] >= (int) short.MaxValue || this.alphaVerts[index3][index4] <= -32767)
          {
            this.vertScale = 1f / (float) attemptNo;
            flag = true;
          }
        }
      }
      for (int index5 = 0; index5 < this.verts.Count & flag; ++index5)
      {
        for (int index6 = 0; index6 < 3; ++index6)
          this.verts[index5][index6] = (int) ((double) this.vertsO[index5][index6] / (double) this.originalScale * (double) this.vertScale);
      }
      for (int index7 = 0; index7 < this.alphaVerts.Count & flag; ++index7)
      {
        for (int index8 = 0; index8 < 3; ++index8)
          this.alphaVerts[index7][index8] = (int) ((double) this.alphaVertsO[index7][index8] / (double) this.originalScale * (double) this.vertScale);
      }
      if (!flag)
        return;
      ++attemptNo;
      this.CalcPrecision(attemptNo);
    }

    public void ImportObj(
      string inFile,
      ref List<TriangleGL> triangleGLs,
      ref List<TriangleGL> triangleGLAlphas,
      ref List<TextureData> TextureDataList,
      ref List<TextureData> TextureDataAlphaList,
      ref List<TextureSetting> TextureSettings,
      ref List<TextureSetting> TextureSettingsAlpha,
      ref float scale)
    {
      try
      {
        this.originalScale = scale;
        this.vertScale = scale;
        this.dir = Path.GetDirectoryName(inFile);
        this.dir += "\\";
        StreamReader streamReader = new StreamReader((Stream) File.Open(inFile, FileMode.Open));
        string end = streamReader.ReadToEnd();
        streamReader.Close();
        this.StripLeadingSpaceAndDoubleSpaces(ref end);
        this.RipMTL(ref end);
        this.RipOBJMesh(ref end);
        this.RipFaces(ref end);
        this.RipTextureCI(ref TextureDataList, ref TextureDataAlphaList, ref TextureSettings, ref TextureSettingsAlpha);
        if (TextureDataList.Count == 0)
          TextureDataList.Add(new TextureData());
        this.RecenterUVs();
        this.SplitAlpha(ref TextureSettingsAlpha);
        this.CopyVerts();
        this.CalcPrecision(1);
        scale = this.vertScale;
        for (int index1 = 0; index1 < this.faceVs.Count; ++index1)
        {
          VertGL[] verts_ = new VertGL[3];
          int num1 = 0;
          int num2 = 0;
          int textureSetting_ = -1;
          for (int index2 = 0; index2 < TextureSettings.Count && textureSetting_ == -1; ++index2)
          {
            if (this.faceTextureMap[index1] == TextureSettings[index2].name)
            {
              textureSetting_ = index2;
              num1 = TextureSettings[index2].width;
              num2 = TextureSettings[index2].height;
            }
          }
          for (int index3 = 0; index3 < 3; ++index3)
          {
            double[] numArray1 = new double[2]
            {
              this.vertTs[this.faceVTs[index1][index3]][0],
              this.vertTs[this.faceVTs[index1][index3]][1]
            };
            short u_ = (short) (numArray1[0] * (double) num1 * 256.0 / 4.0);
            numArray1[1] = numArray1[1] >= 1.0 || numArray1[1] <= 0.0 ? numArray1[1] * -1.0 + 1.0 : 1.0 - numArray1[1] % 1.0;
            short v_ = (short) (numArray1[1] * (double) num2 * 256.0 / 4.0);
            byte[] numArray2 = new byte[4]
            {
              byte.MaxValue,
              byte.MaxValue,
              byte.MaxValue,
              byte.MaxValue
            };
            if (this.faceCs[index1][index3] != -1)
            {
              numArray2[0] = this.vertColours[this.faceCs[index1][index3]].red;
              numArray2[1] = this.vertColours[this.faceCs[index1][index3]].green;
              numArray2[2] = this.vertColours[this.faceCs[index1][index3]].blue;
              numArray2[3] = this.vertColours[this.faceCs[index1][index3]].alpha;
            }
            VertGL vertGl = new VertGL(Convert.ToInt16(this.verts[this.faceVs[index1][index3]][0]), Convert.ToInt16(this.verts[this.faceVs[index1][index3]][1]), Convert.ToInt16(this.verts[this.faceVs[index1][index3]][2]), numArray2[0], numArray2[1], numArray2[2], numArray2[3], u_, v_);
            verts_[index3] = vertGl;
          }
          triangleGLs.Add(new TriangleGL(verts_, textureSetting_));
        }
        for (int index = 0; index < triangleGLs.Count; ++index)
        {
          int textureSetting = triangleGLs[index].textureSetting;
        }
        for (int index4 = 0; index4 < this.alphaFaceVs.Count; ++index4)
        {
          VertGL[] verts_ = new VertGL[3];
          int num3 = 0;
          int num4 = 0;
          int textureSetting_ = -1;
          for (int index5 = 0; index5 < TextureSettingsAlpha.Count && textureSetting_ == -1; ++index5)
          {
            if (this.alphafaceTextureMap[index4] == TextureSettingsAlpha[index5].name)
            {
              textureSetting_ = index5;
              num3 = TextureSettingsAlpha[index5].width;
              num4 = TextureSettingsAlpha[index5].height;
            }
          }
          for (int index6 = 0; index6 < 3; ++index6)
          {
            double[] alphaVertT = this.alphaVertTs[this.alphaFaceVTs[index4][index6]];
            short u_ = (short) (alphaVertT[0] * (double) num3 * 256.0 / 4.0);
            alphaVertT[1] = alphaVertT[1] >= 1.0 || alphaVertT[1] <= 0.0 ? alphaVertT[1] * -1.0 + 1.0 : 1.0 - alphaVertT[1] % 1.0;
            short v_ = (short) (alphaVertT[1] * (double) num4 * 256.0 / 4.0);
            byte[] numArray = new byte[4]
            {
              byte.MaxValue,
              byte.MaxValue,
              byte.MaxValue,
              byte.MaxValue
            };
            if (this.alphaFaceCs[index4][index6] != -1)
            {
              numArray[0] = this.alphaVertColours[this.alphaFaceCs[index4][index6]].red;
              numArray[1] = this.alphaVertColours[this.alphaFaceCs[index4][index6]].green;
              numArray[2] = this.alphaVertColours[this.alphaFaceCs[index4][index6]].blue;
              numArray[3] = this.alphaVertColours[this.alphaFaceCs[index4][index6]].alpha;
            }
            VertGL vertGl = new VertGL(Convert.ToInt16(this.alphaVerts[this.alphaFaceVs[index4][index6]][0]), Convert.ToInt16(this.alphaVerts[this.alphaFaceVs[index4][index6]][1]), Convert.ToInt16(this.alphaVerts[this.alphaFaceVs[index4][index6]][2]), numArray[0], numArray[1], numArray[2], numArray[3], u_, v_);
            verts_[index6] = vertGl;
          }
          triangleGLAlphas.Add(new TriangleGL(verts_, textureSetting_));
        }
        for (int index7 = 0; index7 < triangleGLs.Count<TriangleGL>(); ++index7)
        {
          bool flag1 = false;
          for (int index8 = 0; index8 < 3 && !flag1; ++index8)
          {
            if (triangleGLs[index7].verts[index8].a != byte.MaxValue)
              flag1 = true;
          }
          if (flag1)
          {
            if (triangleGLs[index7].textureSetting != -1)
            {
              TextureSetting t = TextureSetting.clone(TextureSettings[triangleGLs[index7].textureSetting]);
              bool flag2 = true;
              if (TextureSettings[triangleGLs[index7].textureSetting].textureData != -1)
              {
                for (int index9 = 0; index9 < TextureDataAlphaList.Count & flag2; ++index9)
                {
                  if (((IEnumerable<byte>) TextureDataList[TextureSettings[triangleGLs[index7].textureSetting].textureData].n64).SequenceEqual<byte>((IEnumerable<byte>) TextureDataAlphaList[index9].n64))
                  {
                    t.textureData = index9;
                    flag2 = false;
                  }
                }
                if (flag2)
                {
                  TextureDataAlphaList.Add(TextureDataList[TextureSettings[triangleGLs[index7].textureSetting].textureData]);
                  t.textureData = TextureDataAlphaList.Count - 1;
                  TextureSettingsAlpha.Add(t);
                  triangleGLs[index7].textureSetting = TextureSettingsAlpha.Count - 1;
                }
              }
              if (!flag2 || TextureSettings[triangleGLs[index7].textureSetting].textureData == -1)
              {
                bool flag3 = true;
                for (int index10 = 0; index10 < TextureSettingsAlpha.Count & flag3; ++index10)
                {
                  if (TextureSettingsAlpha[index10].equal(t))
                  {
                    triangleGLs[index7].textureSetting = index10;
                    flag3 = false;
                  }
                }
                if (flag3)
                {
                  TextureSettingsAlpha.Add(t);
                  triangleGLs[index7].textureSetting = TextureSettingsAlpha.Count - 1;
                }
              }
            }
            triangleGLAlphas.Insert(0, triangleGLs[index7]);
            triangleGLs.RemoveAt(index7);
            --index7;
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Unable to convert OBJ file, visit banjosbackpack.com for more help");
      }
    }

    public void writeObj()
    {
      string str1 = "";
      for (int index = 0; index < this.verts.Count; ++index)
        str1 = str1 + "v " + (object) this.verts[index][0] + " " + (object) this.verts[index][1] + " " + (object) this.verts[index][2] + Environment.NewLine;
      for (int index = 0; index < this.faceVs.Count; ++index)
        str1 = str1 + "f " + (object) (this.faceVs[index][0] + 1) + " " + (object) (this.faceVs[index][1] + 1) + " " + (object) (this.faceVs[index][2] + 1) + Environment.NewLine;
      StreamWriter streamWriter1 = new StreamWriter("C:\\Users\\Admin\\Documents\\testA.obj");
      streamWriter1.WriteLine(str1);
      streamWriter1.Close();
      string str2 = "";
      for (int index = 0; index < this.alphaVerts.Count; ++index)
        str2 = str2 + "v " + (object) this.alphaVerts[index][0] + " " + (object) this.alphaVerts[index][1] + " " + (object) this.alphaVerts[index][2] + Environment.NewLine;
      for (int index = 0; index < this.alphaFaceVs.Count; ++index)
        str2 = str2 + "f " + (object) (this.alphaFaceVs[index][0] + 1) + " " + (object) (this.alphaFaceVs[index][1] + 1) + " " + (object) (this.alphaFaceVs[index][2] + 1) + Environment.NewLine;
      StreamWriter streamWriter2 = new StreamWriter("C:\\Users\\Admin\\Documents\\testB.obj");
      streamWriter2.WriteLine(str2);
      streamWriter2.Close();
    }

    private void SplitAlpha(ref List<TextureSetting> TextureSettingsAlpha)
    {
      if (TextureSettingsAlpha.Count<TextureSetting>() <= 0)
        return;
      for (int index1 = 0; index1 < this.faceVs.Count; ++index1)
      {
        string faceTexture = this.faceTextureMap[index1];
        bool flag1 = false;
        for (int index2 = 0; index2 < TextureSettingsAlpha.Count<TextureSetting>() && !flag1; ++index2)
        {
          if (TextureSettingsAlpha[index2].name == faceTexture)
          {
            bool flag2 = false;
            if (this.faceCs[index1][0] != -1 && this.faceCs[index1][1] != -1 && this.faceCs[index1][2] != -1)
            {
              int num1 = this.vertColours[this.faceCs[index1][0]].alpha != byte.MaxValue || this.vertColours[this.faceCs[index1][1]].alpha != byte.MaxValue ? 1 : (this.vertColours[this.faceCs[index1][2]].alpha != byte.MaxValue ? 1 : 0);
            }
            else
              flag2 = true;
            this.alphaVerts.Add(this.verts[this.faceVs[index1][0]]);
            this.alphaVerts.Add(this.verts[this.faceVs[index1][1]]);
            this.alphaVerts.Add(this.verts[this.faceVs[index1][2]]);
            this.alphaVertTs.Add(this.vertTs[this.faceVTs[index1][0]]);
            this.alphaVertTs.Add(this.vertTs[this.faceVTs[index1][1]]);
            this.alphaVertTs.Add(this.vertTs[this.faceVTs[index1][2]]);
            if (!flag2)
            {
              this.alphaVertColours.Add(this.vertColours[this.faceCs[index1][0]]);
              this.alphaVertColours.Add(this.vertColours[this.faceCs[index1][1]]);
              this.alphaVertColours.Add(this.vertColours[this.faceCs[index1][2]]);
            }
            int[] numArray1 = new int[3]
            {
              this.alphaVerts.Count - 3,
              this.alphaVerts.Count - 2,
              this.alphaVerts.Count - 1
            };
            int[] numArray2 = new int[3]
            {
              this.alphaVerts.Count - 3,
              this.alphaVerts.Count - 2,
              this.alphaVerts.Count - 1
            };
            int[] numArray3;
            if (flag2)
              numArray3 = new int[3]{ -1, -1, -1 };
            else
              numArray3 = new int[3]
              {
                this.alphaVertColours.Count - 3,
                this.alphaVertColours.Count - 2,
                this.alphaVertColours.Count - 1
              };
            this.alphaFaceVs.Add(numArray1);
            this.alphaFaceVTs.Add(numArray2);
            this.alphaFaceCs.Add(numArray3);
            this.alphafaceTextureMap.Add(faceTexture);
            int[] collection = new int[3]
            {
              this.faceVs[index1][0],
              this.faceVs[index1][1],
              this.faceVs[index1][2]
            };
            new List<int>((IEnumerable<int>) collection).Sort();
            for (int index3 = 0; index3 < 2; ++index3)
            {
              if (collection[index3] > collection[index3 + 1])
              {
                int num2 = collection[index3];
                collection[index3] = collection[index3 + 1];
                collection[index3 + 1] = num2;
                index3 = 0;
              }
            }
            this.faceVs.RemoveAt(index1);
            this.faceVTs.RemoveAt(index1);
            this.faceCs.RemoveAt(index1);
            this.faceTextureMap.RemoveAt(index1);
            --index1;
            flag1 = true;
          }
        }
      }
    }

    public void StripLeadingSpaceAndDoubleSpaces(ref string obj)
    {
      Regex regex1 = new Regex(" +");
      obj = regex1.Replace(obj, " ");
      Regex regex2 = new Regex("\r");
      obj = regex2.Replace(obj, "\n");
      Regex regex3 = new Regex("\n\n");
      obj = regex3.Replace(obj, "\n");
      Regex regex4 = new Regex("s+$", RegexOptions.Multiline);
      obj = regex4.Replace(obj, "");
      Regex regex5 = new Regex("^\\s+", RegexOptions.Multiline);
      obj = regex5.Replace(obj, "");
      ref string local1 = ref obj;
      local1 = local1.Replace("\n ", "\n");
      ref string local2 = ref obj;
      local2 = local2.Replace("\t", " ");
    }

    public void ripDebugTexture(
      byte[] bytesInFile,
      int paletteLocation,
      int width,
      int height,
      string name)
    {
      int num1 = paletteLocation + 32;
      byte[] numArray1 = new byte[32];
      for (int index = 0; index < 32; ++index)
        numArray1[index] = bytesInFile[paletteLocation + index];
      byte[] numArray2 = new byte[16];
      byte[] numArray3 = new byte[16];
      byte[] numArray4 = new byte[16];
      byte[] numArray5 = new byte[16];
      int index1 = 0;
      for (int index2 = 0; index2 < 16; ++index2)
      {
        numArray2[index2] = numArray1[index1];
        numArray2[index2] >>= 3;
        numArray2[index2] *= (byte) 8;
        ushort num2 = (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) (ushort) ((uint) numArray1[index1] * 256U + (uint) numArray1[index1 + 1]) << 5) >> 3) >> 8);
        numArray3[index2] = (byte) num2;
        numArray3[index2] *= (byte) 8;
        numArray4[index2] = numArray1[index1 + 1];
        numArray4[index2] <<= 2;
        numArray4[index2] >>= 3;
        numArray4[index2] *= (byte) 8;
        numArray5[index2] = numArray1[index1 + 1];
        numArray5[index2] <<= 7;
        numArray5[index2] >>= 7;
        numArray5[index2] = numArray5[index2] != (byte) 1 ? (byte) 0 : byte.MaxValue;
        index1 += 2;
      }
      byte[] numArray6 = new byte[width * height / 2];
      for (int index3 = 0; index3 < numArray6.Length; ++index3)
        numArray6[index3] = bytesInFile[num1 + index3];
      byte[] numArray7 = new byte[width * height * 4];
      int index4 = 0;
      for (int index5 = 0; index5 < numArray6.Length; ++index5)
      {
        byte index6 = (byte) ((uint) numArray6[index5] >> 4);
        byte index7 = (byte) ((uint) (byte) ((uint) numArray6[index5] << 4) >> 4);
        numArray7[index4] = numArray2[(int) index6];
        numArray7[index4 + 1] = numArray3[(int) index6];
        numArray7[index4 + 2] = numArray4[(int) index6];
        numArray7[index4 + 3] = numArray5[(int) index6];
        numArray7[index4 + 4] = numArray2[(int) index7];
        numArray7[index4 + 5] = numArray3[(int) index7];
        numArray7[index4 + 6] = numArray4[(int) index7];
        numArray7[index4 + 7] = numArray5[(int) index7];
        index4 += 8;
      }
      byte[] source = new byte[numArray7.Length];
      for (int index8 = 0; index8 < numArray7.Length; index8 += 4)
      {
        source[index8] = numArray7[index8 + 2];
        source[index8 + 1] = numArray7[index8 + 1];
        source[index8 + 2] = numArray7[index8];
        source[index8 + 3] = numArray7[index8 + 3];
      }
      Rectangle rect = new Rectangle(0, 0, width, height);
      Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppPArgb);
      BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
      IntPtr scan0 = bitmapdata.Scan0;
      Marshal.Copy(source, 0, scan0, source.Length);
      bitmap.UnlockBits(bitmapdata);
      bitmap.Save("C:\\Users\\Admin\\Desktop\\betaMM\\" + name, ImageFormat.Png);
    }
  }
}
