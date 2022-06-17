// Decompiled with JetBrains decompiler
// Type: Collada141.instance_effect
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
  public class instance_effect
  {
    private Collada141.extra[] extraField;
    private string nameField;
    private instance_effectSetparam[] setparamField;
    private string sidField;
    private instance_effectTechnique_hint[] technique_hintField;
    private string urlField;

    [XmlElement("technique_hint")]
    public instance_effectTechnique_hint[] technique_hint
    {
      get => this.technique_hintField;
      set => this.technique_hintField = value;
    }

    [XmlElement("setparam")]
    public instance_effectSetparam[] setparam
    {
      get => this.setparamField;
      set => this.setparamField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "anyURI")]
    public string url
    {
      get => this.urlField;
      set => this.urlField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string sid
    {
      get => this.sidField;
      set => this.sidField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string name
    {
      get => this.nameField;
      set => this.nameField = value;
    }
  }
}
