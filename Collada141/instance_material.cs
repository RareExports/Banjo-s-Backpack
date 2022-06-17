// Decompiled with JetBrains decompiler
// Type: Collada141.instance_material
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
  public class instance_material
  {
    private instance_materialBind[] bindField;
    private instance_materialBind_vertex_input[] bind_vertex_inputField;
    private Collada141.extra[] extraField;
    private string nameField;
    private string sidField;
    private string symbolField;
    private string targetField;

    [XmlElement("bind")]
    public instance_materialBind[] bind
    {
      get => this.bindField;
      set => this.bindField = value;
    }

    [XmlElement("bind_vertex_input")]
    public instance_materialBind_vertex_input[] bind_vertex_input
    {
      get => this.bind_vertex_inputField;
      set => this.bind_vertex_inputField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string symbol
    {
      get => this.symbolField;
      set => this.symbolField = value;
    }

    [XmlAttribute(DataType = "anyURI")]
    public string target
    {
      get => this.targetField;
      set => this.targetField = value;
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
