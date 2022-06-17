// Decompiled with JetBrains decompiler
// Type: Collada141.accessor
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
  public class accessor
  {
    private ulong countField;
    private ulong offsetField;
    private Collada141.param[] paramField;
    private string sourceField;
    private ulong strideField;

    public accessor()
    {
      this.offsetField = 0UL;
      this.strideField = 1UL;
    }

    [XmlElement("param")]
    public Collada141.param[] param
    {
      get => this.paramField;
      set => this.paramField = value;
    }

    [XmlAttribute]
    public ulong count
    {
      get => this.countField;
      set => this.countField = value;
    }

    [XmlAttribute]
    [DefaultValue(typeof (ulong), "0")]
    public ulong offset
    {
      get => this.offsetField;
      set => this.offsetField = value;
    }

    [XmlAttribute(DataType = "anyURI")]
    public string source
    {
      get => this.sourceField;
      set => this.sourceField = value;
    }

    [XmlAttribute]
    [DefaultValue(typeof (ulong), "1")]
    public ulong stride
    {
      get => this.strideField;
      set => this.strideField = value;
    }
  }
}
