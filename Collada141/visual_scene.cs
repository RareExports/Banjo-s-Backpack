// Decompiled with JetBrains decompiler
// Type: Collada141.visual_scene
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
  public class visual_scene
  {
    private asset assetField;
    private visual_sceneEvaluate_scene[] evaluate_sceneField;
    private Collada141.extra[] extraField;
    private string idField;
    private string nameField;
    private Collada141.node[] nodeField;

    public asset asset
    {
      get => this.assetField;
      set => this.assetField = value;
    }

    [XmlElement("node")]
    public Collada141.node[] node
    {
      get => this.nodeField;
      set => this.nodeField = value;
    }

    [XmlElement("evaluate_scene")]
    public visual_sceneEvaluate_scene[] evaluate_scene
    {
      get => this.evaluate_sceneField;
      set => this.evaluate_sceneField = value;
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
  }
}
