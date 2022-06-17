// Decompiled with JetBrains decompiler
// Type: Collada141.instance_rigid_bodyTechnique_common
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
  public class instance_rigid_bodyTechnique_common
  {
    private string angular_velocityField;
    private instance_rigid_bodyTechnique_commonDynamic dynamicField;
    private TargetableFloat3 inertiaField;
    private object itemField;
    private TargetableFloat massField;
    private object[] mass_frameField;
    private instance_rigid_bodyTechnique_commonShape[] shapeField;
    private string velocityField;

    public instance_rigid_bodyTechnique_common()
    {
      this.angular_velocityField = "0.0 0.0 0.0";
      this.velocityField = "0.0 0.0 0.0";
    }

    [DefaultValue("0.0 0.0 0.0")]
    public string angular_velocity
    {
      get => this.angular_velocityField;
      set => this.angular_velocityField = value;
    }

    [DefaultValue("0.0 0.0 0.0")]
    public string velocity
    {
      get => this.velocityField;
      set => this.velocityField = value;
    }

    public instance_rigid_bodyTechnique_commonDynamic dynamic
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
    public instance_rigid_bodyTechnique_commonShape[] shape
    {
      get => this.shapeField;
      set => this.shapeField = value;
    }
  }
}
