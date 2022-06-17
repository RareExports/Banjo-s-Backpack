// Decompiled with JetBrains decompiler
// Type: Collada141.fx_surface_format_hint_common
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
  public class fx_surface_format_hint_common
  {
    private fx_surface_format_hint_channels_enum channelsField;
    private Collada141.extra[] extraField;
    private fx_surface_format_hint_option_enum[] optionField;
    private fx_surface_format_hint_precision_enum precisionField;
    private bool precisionFieldSpecified;
    private fx_surface_format_hint_range_enum rangeField;

    public fx_surface_format_hint_channels_enum channels
    {
      get => this.channelsField;
      set => this.channelsField = value;
    }

    public fx_surface_format_hint_range_enum range
    {
      get => this.rangeField;
      set => this.rangeField = value;
    }

    public fx_surface_format_hint_precision_enum precision
    {
      get => this.precisionField;
      set => this.precisionField = value;
    }

    [XmlIgnore]
    public bool precisionSpecified
    {
      get => this.precisionFieldSpecified;
      set => this.precisionFieldSpecified = value;
    }

    [XmlElement("option")]
    public fx_surface_format_hint_option_enum[] option
    {
      get => this.optionField;
      set => this.optionField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }
  }
}
