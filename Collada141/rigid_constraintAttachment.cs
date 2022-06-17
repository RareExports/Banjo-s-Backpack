// Decompiled with JetBrains decompiler
// Type: Collada141.rigid_constraintAttachment
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
  public class rigid_constraintAttachment
  {
    private object[] itemsField;
    private string rigid_bodyField;

    [XmlElement("extra", typeof (extra))]
    [XmlElement("rotate", typeof (rotate))]
    [XmlElement("translate", typeof (TargetableFloat3))]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    [XmlAttribute(DataType = "anyURI")]
    public string rigid_body
    {
      get => this.rigid_bodyField;
      set => this.rigid_bodyField = value;
    }
  }
}
