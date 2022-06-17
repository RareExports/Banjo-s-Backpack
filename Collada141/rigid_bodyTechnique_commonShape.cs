// Decompiled with JetBrains decompiler
// Type: Collada141.rigid_bodyTechnique_commonShape
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
  public class rigid_bodyTechnique_commonShape
  {
    private TargetableFloat densityField;
    private Collada141.extra[] extraField;
    private rigid_bodyTechnique_commonShapeHollow hollowField;
    private object item1Field;
    private object itemField;
    private object[] itemsField;
    private TargetableFloat massField;

    public rigid_bodyTechnique_commonShapeHollow hollow
    {
      get => this.hollowField;
      set => this.hollowField = value;
    }

    public TargetableFloat mass
    {
      get => this.massField;
      set => this.massField = value;
    }

    public TargetableFloat density
    {
      get => this.densityField;
      set => this.densityField = value;
    }

    [XmlElement("instance_physics_material", typeof (InstanceWithExtra))]
    [XmlElement("physics_material", typeof (physics_material))]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    [XmlElement("box", typeof (box))]
    [XmlElement("capsule", typeof (capsule))]
    [XmlElement("cylinder", typeof (cylinder))]
    [XmlElement("instance_geometry", typeof (instance_geometry))]
    [XmlElement("plane", typeof (plane))]
    [XmlElement("sphere", typeof (sphere))]
    [XmlElement("tapered_capsule", typeof (tapered_capsule))]
    [XmlElement("tapered_cylinder", typeof (tapered_cylinder))]
    public object Item1
    {
      get => this.item1Field;
      set => this.item1Field = value;
    }

    [XmlElement("rotate", typeof (rotate))]
    [XmlElement("translate", typeof (TargetableFloat3))]
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
  }
}
