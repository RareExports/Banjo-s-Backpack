// Decompiled with JetBrains decompiler
// Type: Collada141.effectFx_profile_abstractProfile_COMMON
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
  [XmlRoot("profile_COMMON", IsNullable = false, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class effectFx_profile_abstractProfile_COMMON
  {
    private asset assetField;
    private Collada141.extra[] extraField;
    private string idField;
    private object[] itemsField;
    private effectFx_profile_abstractProfile_COMMONTechnique techniqueField;

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

    public effectFx_profile_abstractProfile_COMMONTechnique technique
    {
      get => this.techniqueField;
      set => this.techniqueField = value;
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
  }
}
