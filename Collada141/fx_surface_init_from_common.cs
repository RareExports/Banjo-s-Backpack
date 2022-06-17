// Decompiled with JetBrains decompiler
// Type: Collada141.fx_surface_init_from_common
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using RummageAttributes;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Collada141
{
  [GeneratedCode("xsd", "4.0.30319.1")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class fx_surface_init_from_common
  {
    private fx_surface_face_enum faceField;
    private uint mipField;
    private uint sliceField;
    private string valueField;

    public fx_surface_init_from_common()
    {
      this.mipField = 0U;
      this.sliceField = 0U;
      this.faceField = fx_surface_face_enum.POSITIVE_X;
    }

    [XmlAttribute]
    [DefaultValue(typeof (uint), "0")]
    public uint mip
    {
      get => this.mipField;
      set => this.mipField = value;
    }

    [XmlAttribute]
    [DefaultValue(typeof (uint), "0")]
    public uint slice
    {
      get => this.sliceField;
      set => this.sliceField = value;
    }

    [XmlAttribute]
    [DefaultValue(fx_surface_face_enum.POSITIVE_X)]
    public fx_surface_face_enum face
    {
      get => this.faceField;
      set => this.faceField = value;
    }

    [XmlText(DataType = "IDREF")]
    public string Value
    {
      get => this.valueField;
      set => this.valueField = value;
    }
  }
}
