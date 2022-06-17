// Decompiled with JetBrains decompiler
// Type: Collada141.InputLocalOffset
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
  public class InputLocalOffset
  {
    private ulong offsetField;
    private string semanticField;
    private ulong setField;
    private bool setFieldSpecified;
    private string sourceField;

    [XmlAttribute]
    public ulong offset
    {
      get => this.offsetField;
      set => this.offsetField = value;
    }

    [XmlAttribute(DataType = "NMTOKEN")]
    public string semantic
    {
      get => this.semanticField;
      set => this.semanticField = value;
    }

    [XmlAttribute]
    public string source
    {
      get => this.sourceField;
      set => this.sourceField = value;
    }

    [XmlAttribute]
    public ulong set
    {
      get => this.setField;
      set => this.setField = value;
    }

    [XmlIgnore]
    public bool setSpecified
    {
      get => this.setFieldSpecified;
      set => this.setFieldSpecified = value;
    }
  }
}
