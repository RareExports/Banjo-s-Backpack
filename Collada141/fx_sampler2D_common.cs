// Decompiled with JetBrains decompiler
// Type: Collada141.fx_sampler2D_common
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
  public class fx_sampler2D_common
  {
    private string border_colorField;
    private Collada141.extra[] extraField;
    private fx_sampler_filter_common magfilterField;
    private fx_sampler_filter_common minfilterField;
    private fx_sampler_filter_common mipfilterField;
    private float mipmap_biasField;
    private byte mipmap_maxlevelField;
    private string sourceField;
    private fx_sampler_wrap_common wrap_sField;
    private fx_sampler_wrap_common wrap_tField;

    public fx_sampler2D_common()
    {
      this.wrap_sField = fx_sampler_wrap_common.WRAP;
      this.wrap_tField = fx_sampler_wrap_common.WRAP;
      this.minfilterField = fx_sampler_filter_common.NONE;
      this.magfilterField = fx_sampler_filter_common.NONE;
      this.mipfilterField = fx_sampler_filter_common.NONE;
      this.mipmap_maxlevelField = byte.MaxValue;
      this.mipmap_biasField = 0.0f;
    }

    [XmlElement(DataType = "NCName")]
    public string source
    {
      get => this.sourceField;
      set => this.sourceField = value;
    }

    [DefaultValue(fx_sampler_wrap_common.WRAP)]
    public fx_sampler_wrap_common wrap_s
    {
      get => this.wrap_sField;
      set => this.wrap_sField = value;
    }

    [DefaultValue(fx_sampler_wrap_common.WRAP)]
    public fx_sampler_wrap_common wrap_t
    {
      get => this.wrap_tField;
      set => this.wrap_tField = value;
    }

    [DefaultValue(fx_sampler_filter_common.NONE)]
    public fx_sampler_filter_common minfilter
    {
      get => this.minfilterField;
      set => this.minfilterField = value;
    }

    [DefaultValue(fx_sampler_filter_common.NONE)]
    public fx_sampler_filter_common magfilter
    {
      get => this.magfilterField;
      set => this.magfilterField = value;
    }

    [DefaultValue(fx_sampler_filter_common.NONE)]
    public fx_sampler_filter_common mipfilter
    {
      get => this.mipfilterField;
      set => this.mipfilterField = value;
    }

    public string border_color
    {
      get => this.border_colorField;
      set => this.border_colorField = value;
    }

    [DefaultValue(typeof (byte), "255")]
    public byte mipmap_maxlevel
    {
      get => this.mipmap_maxlevelField;
      set => this.mipmap_maxlevelField = value;
    }

    [DefaultValue(typeof (float), "0")]
    public float mipmap_bias
    {
      get => this.mipmap_biasField;
      set => this.mipmap_biasField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }
  }
}
