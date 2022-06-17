// Decompiled with JetBrains decompiler
// Type: Collada141.cameraOpticsTechnique_commonOrthographic
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
  public class cameraOpticsTechnique_commonOrthographic
  {
    private ItemsChoiceType[] itemsElementNameField;
    private TargetableFloat[] itemsField;
    private TargetableFloat zfarField;
    private TargetableFloat znearField;

    [XmlElement("aspect_ratio", typeof (TargetableFloat))]
    [XmlElement("xmag", typeof (TargetableFloat))]
    [XmlElement("ymag", typeof (TargetableFloat))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public TargetableFloat[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType[] ItemsElementName
    {
      get => this.itemsElementNameField;
      set => this.itemsElementNameField = value;
    }

    public TargetableFloat znear
    {
      get => this.znearField;
      set => this.znearField = value;
    }

    public TargetableFloat zfar
    {
      get => this.zfarField;
      set => this.zfarField = value;
    }
  }
}
