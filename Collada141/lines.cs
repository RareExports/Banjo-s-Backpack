// Decompiled with JetBrains decompiler
// Type: Collada141.lines
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
  public class lines
  {
    private ulong countField;
    private Collada141.extra[] extraField;
    private InputLocalOffset[] inputField;
    private string materialField;
    private string nameField;
    private string pField;

    [XmlElement("input")]
    public InputLocalOffset[] input
    {
      get => this.inputField;
      set => this.inputField = value;
    }

    public string p
    {
      get => this.pField;
      set => this.pField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string name
    {
      get => this.nameField;
      set => this.nameField = value;
    }

    [XmlAttribute]
    public ulong count
    {
      get => this.countField;
      set => this.countField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string material
    {
      get => this.materialField;
      set => this.materialField = value;
    }
  }
}
