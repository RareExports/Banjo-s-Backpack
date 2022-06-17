// Decompiled with JetBrains decompiler
// Type: Collada141.convex_mesh
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
  public class convex_mesh
  {
    private string convex_hull_ofField;
    private Collada141.extra[] extraField;
    private object[] itemsField;
    private Collada141.source[] sourceField;
    private vertices verticesField;

    [XmlElement("source")]
    public Collada141.source[] source
    {
      get => this.sourceField;
      set => this.sourceField = value;
    }

    public vertices vertices
    {
      get => this.verticesField;
      set => this.verticesField = value;
    }

    [XmlElement("lines", typeof (lines))]
    [XmlElement("linestrips", typeof (linestrips))]
    [XmlElement("polygons", typeof (polygons))]
    [XmlElement("polylist", typeof (polylist))]
    [XmlElement("triangles", typeof (triangles))]
    [XmlElement("trifans", typeof (trifans))]
    [XmlElement("tristrips", typeof (tristrips))]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "anyURI")]
    public string convex_hull_of
    {
      get => this.convex_hull_ofField;
      set => this.convex_hull_ofField = value;
    }
  }
}
