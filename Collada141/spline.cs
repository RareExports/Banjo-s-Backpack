// Decompiled with JetBrains decompiler
// Type: Collada141.spline
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
  public class spline
  {
    private bool closedField;
    private splineControl_vertices control_verticesField;
    private Collada141.extra[] extraField;
    private Collada141.source[] sourceField;

    public spline() => this.closedField = false;

    [XmlElement("source")]
    public Collada141.source[] source
    {
      get => this.sourceField;
      set => this.sourceField = value;
    }

    public splineControl_vertices control_vertices
    {
      get => this.control_verticesField;
      set => this.control_verticesField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute]
    [DefaultValue(false)]
    public bool closed
    {
      get => this.closedField;
      set => this.closedField = value;
    }
  }
}
