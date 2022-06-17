// Decompiled with JetBrains decompiler
// Type: Collada141.common_newparam_type
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
  public class common_newparam_type
  {
    private ItemChoiceType itemElementNameField;
    private object itemField;
    private string semanticField;
    private string sidField;

    [XmlElement(DataType = "NCName")]
    public string semantic
    {
      get => this.semanticField;
      set => this.semanticField = value;
    }

    [XmlElement("float", typeof (double))]
    [XmlElement("float2", typeof (double))]
    [XmlElement("float3", typeof (double))]
    [XmlElement("float4", typeof (double))]
    [XmlElement("sampler2D", typeof (fx_sampler2D_common))]
    [XmlElement("surface", typeof (fx_surface_common))]
    [XmlChoiceIdentifier("ItemElementName")]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    [XmlIgnore]
    public ItemChoiceType ItemElementName
    {
      get => this.itemElementNameField;
      set => this.itemElementNameField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string sid
    {
      get => this.sidField;
      set => this.sidField = value;
    }
  }
}
