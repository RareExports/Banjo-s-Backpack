// Decompiled with JetBrains decompiler
// Type: Collada141.skin
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
  public class skin
  {
    private string bind_shape_matrixField;
    private Collada141.extra[] extraField;
    private skinJoints jointsField;
    private string source1Field;
    private Collada141.source[] sourceField;
    private skinVertex_weights vertex_weightsField;

    public string bind_shape_matrix
    {
      get => this.bind_shape_matrixField;
      set => this.bind_shape_matrixField = value;
    }

    [XmlElement("source")]
    public Collada141.source[] source
    {
      get => this.sourceField;
      set => this.sourceField = value;
    }

    public skinJoints joints
    {
      get => this.jointsField;
      set => this.jointsField = value;
    }

    public skinVertex_weights vertex_weights
    {
      get => this.vertex_weightsField;
      set => this.vertex_weightsField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute("source", DataType = "anyURI")]
    public string source1
    {
      get => this.source1Field;
      set => this.source1Field = value;
    }
  }
}
