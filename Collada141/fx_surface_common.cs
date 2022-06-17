// Decompiled with JetBrains decompiler
// Type: Collada141.fx_surface_common
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
  public class fx_surface_common
  {
    private Collada141.extra[] extraField;
    private string formatField;
    private fx_surface_format_hint_common format_hintField;
    private object init_as_nullField;
    private object init_as_targetField;
    private fx_surface_init_cube_common init_cubeField;
    private fx_surface_init_from_common[] init_fromField;
    private fx_surface_init_planar_common init_planarField;
    private fx_surface_init_volume_common init_volumeField;
    private object itemField;
    private uint mip_levelsField;
    private bool mipmap_generateField;
    private bool mipmap_generateFieldSpecified;
    private fx_surface_type_enum typeField;

    public fx_surface_common() => this.mip_levelsField = 0U;

    public object init_as_null
    {
      get => this.init_as_nullField;
      set => this.init_as_nullField = value;
    }

    public object init_as_target
    {
      get => this.init_as_targetField;
      set => this.init_as_targetField = value;
    }

    public fx_surface_init_cube_common init_cube
    {
      get => this.init_cubeField;
      set => this.init_cubeField = value;
    }

    public fx_surface_init_volume_common init_volume
    {
      get => this.init_volumeField;
      set => this.init_volumeField = value;
    }

    public fx_surface_init_planar_common init_planar
    {
      get => this.init_planarField;
      set => this.init_planarField = value;
    }

    [XmlElement("init_from")]
    public fx_surface_init_from_common[] init_from
    {
      get => this.init_fromField;
      set => this.init_fromField = value;
    }

    [XmlElement(DataType = "token")]
    public string format
    {
      get => this.formatField;
      set => this.formatField = value;
    }

    public fx_surface_format_hint_common format_hint
    {
      get => this.format_hintField;
      set => this.format_hintField = value;
    }

    [XmlElement("size", typeof (long))]
    [XmlElement("viewport_ratio", typeof (double))]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    [DefaultValue(typeof (uint), "0")]
    public uint mip_levels
    {
      get => this.mip_levelsField;
      set => this.mip_levelsField = value;
    }

    public bool mipmap_generate
    {
      get => this.mipmap_generateField;
      set => this.mipmap_generateField = value;
    }

    [XmlIgnore]
    public bool mipmap_generateSpecified
    {
      get => this.mipmap_generateFieldSpecified;
      set => this.mipmap_generateFieldSpecified = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute]
    public fx_surface_type_enum type
    {
      get => this.typeField;
      set => this.typeField = value;
    }
  }
}
