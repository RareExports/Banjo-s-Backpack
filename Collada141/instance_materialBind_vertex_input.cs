// Decompiled with JetBrains decompiler
// Type: Collada141.instance_materialBind_vertex_input
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
  public class instance_materialBind_vertex_input
  {
    private string input_semanticField;
    private ulong input_setField;
    private bool input_setFieldSpecified;
    private string semanticField;

    [XmlAttribute(DataType = "NCName")]
    public string semantic
    {
      get => this.semanticField;
      set => this.semanticField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string input_semantic
    {
      get => this.input_semanticField;
      set => this.input_semanticField = value;
    }

    [XmlAttribute]
    public ulong input_set
    {
      get => this.input_setField;
      set => this.input_setField = value;
    }

    [XmlIgnore]
    public bool input_setSpecified
    {
      get => this.input_setFieldSpecified;
      set => this.input_setFieldSpecified = value;
    }
  }
}
