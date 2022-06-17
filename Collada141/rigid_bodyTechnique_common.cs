// Decompiled with JetBrains decompiler
// Type: Collada141.rigid_bodyTechnique_common
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
  public class rigid_bodyTechnique_common
  {
    private rigid_bodyTechnique_commonDynamic dynamicField;
    private TargetableFloat3 inertiaField;
    private object itemField;
    private TargetableFloat massField;
    private object[] mass_frameField;
    private rigid_bodyTechnique_commonShape[] shapeField;

    public rigid_bodyTechnique_commonDynamic dynamic
    {
      get => this.dynamicField;
      set => this.dynamicField = value;
    }

    public TargetableFloat mass
    {
      get => this.massField;
      set => this.massField = value;
    }

    [XmlArrayItem("rotate", typeof (rotate), IsNullable = false)]
    [XmlArrayItem("translate", typeof (TargetableFloat3), IsNullable = false)]
    public object[] mass_frame
    {
      get => this.mass_frameField;
      set => this.mass_frameField = value;
    }

    public TargetableFloat3 inertia
    {
      get => this.inertiaField;
      set => this.inertiaField = value;
    }

    [XmlElement("instance_physics_material", typeof (InstanceWithExtra))]
    [XmlElement("physics_material", typeof (physics_material))]
    public object Item
    {
      get => this.itemField;
      set => this.itemField = value;
    }

    [XmlElement("shape")]
    public rigid_bodyTechnique_commonShape[] shape
    {
      get => this.shapeField;
      set => this.shapeField = value;
    }
  }
}
