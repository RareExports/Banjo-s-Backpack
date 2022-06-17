// Decompiled with JetBrains decompiler
// Type: Collada141.COLLADA
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using RummageAttributes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Collada141
{
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [XmlRoot(IsNullable = false, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class COLLADA
  {
    private asset assetField;
    private Collada141.extra[] extraField;
    private object[] itemsField;
    private COLLADAScene sceneField;
    private VersionType versionField;
    private static Regex regex = new Regex("\\s+");

    public asset asset
    {
      get => this.assetField;
      set => this.assetField = value;
    }

    [XmlElement("library_animation_clips", typeof (library_animation_clips))]
    [XmlElement("library_animations", typeof (library_animations))]
    [XmlElement("library_cameras", typeof (library_cameras))]
    [XmlElement("library_controllers", typeof (library_controllers))]
    [XmlElement("library_effects", typeof (library_effects))]
    [XmlElement("library_force_fields", typeof (library_force_fields))]
    [XmlElement("library_geometries", typeof (library_geometries))]
    [XmlElement("library_images", typeof (library_images))]
    [XmlElement("library_lights", typeof (library_lights))]
    [XmlElement("library_materials", typeof (library_materials))]
    [XmlElement("library_nodes", typeof (library_nodes))]
    [XmlElement("library_physics_materials", typeof (library_physics_materials))]
    [XmlElement("library_physics_models", typeof (library_physics_models))]
    [XmlElement("library_physics_scenes", typeof (library_physics_scenes))]
    [XmlElement("library_visual_scenes", typeof (library_visual_scenes))]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    public COLLADAScene scene
    {
      get => this.sceneField;
      set => this.sceneField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute]
    public VersionType version
    {
      get => this.versionField;
      set => this.versionField = value;
    }

    public static string ConvertFromArray<T>(IList<T> array)
    {
      if (array == null)
        return (string) null;
      StringBuilder stringBuilder = new StringBuilder();
      if (typeof (T) == typeof (double))
      {
        for (int index = 0; index < array.Count; ++index)
        {
          double num = (double) (object) array[index];
          stringBuilder.Append(num.ToString("0.000000", (IFormatProvider) NumberFormatInfo.InvariantInfo));
          if (index + 1 < array.Count)
            stringBuilder.Append(" ");
        }
      }
      else
      {
        for (int index = 0; index < array.Count; ++index)
        {
          stringBuilder.Append(Convert.ToString((object) array[index], (IFormatProvider) NumberFormatInfo.InvariantInfo));
          if (index + 1 < array.Count)
            stringBuilder.Append(" ");
        }
      }
      return stringBuilder.ToString();
    }

    internal static string[] ConvertStringArray(string arrayStr)
    {
      string[] strArray1 = COLLADA.regex.Split(arrayStr.Trim());
      string[] strArray2 = new string[strArray1.Length];
      for (int index = 0; index < strArray2.Length; ++index)
        strArray2[index] = strArray1[index];
      return strArray2;
    }

    internal static int[] ConvertIntArray(string arrayStr)
    {
      string[] strArray = COLLADA.regex.Split(arrayStr.Trim());
      int[] numArray = new int[strArray.Length];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = int.Parse(strArray[index]);
      return numArray;
    }

    internal static double[] ConvertDoubleArray(string arrayStr)
    {
      string[] strArray = COLLADA.regex.Split(arrayStr.Trim());
      double[] numArray = new double[strArray.Length];
      try
      {
        for (int index = 0; index < numArray.Length; ++index)
          numArray[index] = double.Parse(strArray[index], NumberStyles.Float, (IFormatProvider) CultureInfo.InvariantCulture);
      }
      catch (Exception ex)
      {
        Console.WriteLine((object) ex);
      }
      return numArray;
    }

    internal static bool[] ConvertBoolArray(string arrayStr)
    {
      string[] strArray = COLLADA.regex.Split(arrayStr.Trim());
      bool[] flagArray = new bool[strArray.Length];
      for (int index = 0; index < flagArray.Length; ++index)
        flagArray[index] = bool.Parse(strArray[index]);
      return flagArray;
    }

    public static COLLADA Load(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Open);
      try
      {
        return COLLADA.Load((Stream) fileStream);
      }
      finally
      {
        fileStream.Close();
      }
    }

    public static COLLADA Load(Stream stream) => (COLLADA) new XmlSerializer(typeof (COLLADA)).Deserialize((TextReader) new StreamReader(stream));

    public void Save(string fileName)
    {
      FileStream fileStream = new FileStream(fileName, FileMode.Create);
      try
      {
        this.Save((Stream) fileStream);
      }
      catch (Exception ex)
      {
      }
      finally
      {
        fileStream.Close();
      }
    }

    public void Save(Stream stream)
    {
      XmlTextWriter xmlTextWriter1 = new XmlTextWriter(stream, Encoding.UTF8);
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (COLLADA));
      xmlTextWriter1.Formatting = Formatting.Indented;
      XmlTextWriter xmlTextWriter2 = xmlTextWriter1;
      xmlSerializer.Serialize((XmlWriter) xmlTextWriter2, (object) this);
    }
  }
}
