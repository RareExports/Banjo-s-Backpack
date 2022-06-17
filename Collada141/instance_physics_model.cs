// Decompiled with JetBrains decompiler
// Type: Collada141.instance_physics_model
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
  public class instance_physics_model
  {
    private Collada141.extra[] extraField;
    private InstanceWithExtra[] instance_force_fieldField;
    private Collada141.instance_rigid_body[] instance_rigid_bodyField;
    private Collada141.instance_rigid_constraint[] instance_rigid_constraintField;
    private string nameField;
    private string parentField;
    private string sidField;
    private string urlField;

    [XmlElement("instance_force_field")]
    public InstanceWithExtra[] instance_force_field
    {
      get => this.instance_force_fieldField;
      set => this.instance_force_fieldField = value;
    }

    [XmlElement("instance_rigid_body")]
    public Collada141.instance_rigid_body[] instance_rigid_body
    {
      get => this.instance_rigid_bodyField;
      set => this.instance_rigid_bodyField = value;
    }

    [XmlElement("instance_rigid_constraint")]
    public Collada141.instance_rigid_constraint[] instance_rigid_constraint
    {
      get => this.instance_rigid_constraintField;
      set => this.instance_rigid_constraintField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "anyURI")]
    public string url
    {
      get => this.urlField;
      set => this.urlField = value;
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

    [XmlAttribute(DataType = "anyURI")]
    public string parent
    {
      get => this.parentField;
      set => this.parentField = value;
    }
  }
}
