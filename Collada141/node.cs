// Decompiled with JetBrains decompiler
// Type: Collada141.node
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
  public class node
  {
    private asset assetField;
    private Collada141.extra[] extraField;
    private string idField;
    private InstanceWithExtra[] instance_cameraField;
    private Collada141.instance_controller[] instance_controllerField;
    private Collada141.instance_geometry[] instance_geometryField;
    private InstanceWithExtra[] instance_lightField;
    private InstanceWithExtra[] instance_nodeField;
    private ItemsChoiceType2[] itemsElementNameField;
    private object[] itemsField;
    private string[] layerField;
    private string nameField;
    private node[] node1Field;
    private string sidField;
    private NodeType typeField;

    public node() => this.typeField = NodeType.NODE;

    public asset asset
    {
      get => this.assetField;
      set => this.assetField = value;
    }

    [XmlElement("lookat", typeof (lookat))]
    [XmlElement("matrix", typeof (matrix))]
    [XmlElement("rotate", typeof (rotate))]
    [XmlElement("scale", typeof (TargetableFloat3))]
    [XmlElement("skew", typeof (skew))]
    [XmlElement("translate", typeof (TargetableFloat3))]
    [XmlChoiceIdentifier("ItemsElementName")]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }

    [XmlElement("ItemsElementName")]
    [XmlIgnore]
    public ItemsChoiceType2[] ItemsElementName
    {
      get => this.itemsElementNameField;
      set => this.itemsElementNameField = value;
    }

    [XmlElement("instance_camera")]
    public InstanceWithExtra[] instance_camera
    {
      get => this.instance_cameraField;
      set => this.instance_cameraField = value;
    }

    [XmlElement("instance_controller")]
    public Collada141.instance_controller[] instance_controller
    {
      get => this.instance_controllerField;
      set => this.instance_controllerField = value;
    }

    [XmlElement("instance_geometry")]
    public Collada141.instance_geometry[] instance_geometry
    {
      get => this.instance_geometryField;
      set => this.instance_geometryField = value;
    }

    [XmlElement("instance_light")]
    public InstanceWithExtra[] instance_light
    {
      get => this.instance_lightField;
      set => this.instance_lightField = value;
    }

    [XmlElement("instance_node")]
    public InstanceWithExtra[] instance_node
    {
      get => this.instance_nodeField;
      set => this.instance_nodeField = value;
    }

    [XmlElement("node")]
    public node[] node1
    {
      get => this.node1Field;
      set => this.node1Field = value;
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

    [XmlAttribute(DataType = "NCName")]
    public string sid
    {
      get => this.sidField;
      set => this.sidField = value;
    }

    [XmlAttribute]
    [DefaultValue(NodeType.NODE)]
    public NodeType type
    {
      get => this.typeField;
      set => this.typeField = value;
    }

    [XmlAttribute(DataType = "Name")]
    public string[] layer
    {
      get => this.layerField;
      set => this.layerField = value;
    }
  }
}
