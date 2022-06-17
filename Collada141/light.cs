// Decompiled with JetBrains decompiler
// Type: Collada141.light
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
  [XmlRoot(IsNullable = false, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class light
  {
    private asset assetField;
    private Collada141.extra[] extraField;
    private string idField;
    private string nameField;
    private Collada141.technique[] techniqueField;
    private lightTechnique_common technique_commonField;

    public asset asset
    {
      get => this.assetField;
      set => this.assetField = value;
    }

    public lightTechnique_common technique_common
    {
      get => this.technique_commonField;
      set => this.technique_commonField = value;
    }

    [XmlElement("technique")]
    public Collada141.technique[] technique
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

    [XmlAttribute(DataType = "NCName")]
    public string name
    {
      get => this.nameField;
      set => this.nameField = value;
    }
  }
}
