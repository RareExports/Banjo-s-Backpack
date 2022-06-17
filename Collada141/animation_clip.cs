// Decompiled with JetBrains decompiler
// Type: Collada141.animation_clip
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
  public class animation_clip
  {
    private asset assetField;
    private double endField;
    private bool endFieldSpecified;
    private Collada141.extra[] extraField;
    private string idField;
    private InstanceWithExtra[] instance_animationField;
    private string nameField;
    private double startField;

    public animation_clip() => this.startField = 0.0;

    public asset asset
    {
      get => this.assetField;
      set => this.assetField = value;
    }

    [XmlElement("instance_animation")]
    public InstanceWithExtra[] instance_animation
    {
      get => this.instance_animationField;
      set => this.instance_animationField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "ID")]
    public string id
    {
      get => this.idField;
      set => this.idField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string name
    {
      get => this.nameField;
      set => this.nameField = value;
    }

    [XmlAttribute]
    [DefaultValue(0.0)]
    public double start
    {
      get => this.startField;
      set => this.startField = value;
    }

    [XmlAttribute]
    public double end
    {
      get => this.endField;
      set => this.endField = value;
    }

    [XmlIgnore]
    public bool endSpecified
    {
      get => this.endFieldSpecified;
      set => this.endFieldSpecified = value;
    }
  }
}
