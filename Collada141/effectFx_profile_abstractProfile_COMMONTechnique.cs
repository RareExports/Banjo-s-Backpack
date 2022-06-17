// Decompiled with JetBrains decompiler
// Type: Collada141.effectFx_profile_abstractProfile_COMMONTechnique
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
  [XmlType(AnonymousType = true, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class effectFx_profile_abstractProfile_COMMONTechnique
  {
    private asset assetField;
    private Collada141.extra[] extraField;
    private string idField;
    private object itemField;
    private object[] itemsField;
    private string sidField;

    public asset asset
    {
      get => this.assetField;
      set => this.assetField = value;
    }

    [XmlElement("image", typeof (image))]
    [XmlElement("newparam", typeof (common_newparam_type))]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    [XmlElement("blinn", typeof (effectFx_profile_abstractProfile_COMMONTechniqueBlinn))]
    [XmlElement("constant", typeof (effectFx_profile_abstractProfile_COMMONTechniqueConstant))]
    [XmlElement("lambert", typeof (effectFx_profile_abstractProfile_COMMONTechniqueLambert))]
    [XmlElement("phong", typeof (effectFx_profile_abstractProfile_COMMONTechniquePhong))]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => this.idField;
      set => this.idField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string sid
    {
      get => this.sidField;
      set => this.sidField = value;
    }
  }
}
