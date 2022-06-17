// Decompiled with JetBrains decompiler
// Type: Collada141.visual_sceneEvaluate_sceneRender
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
  public class visual_sceneEvaluate_sceneRender
  {
    private string camera_nodeField;
    private instance_effect instance_effectField;
    private string[] layerField;

    [XmlElement("layer", DataType = "NCName")]
    public string[] layer
    {
      get => this.layerField;
      set => this.layerField = value;
    }

    public instance_effect instance_effect
    {
      get => this.instance_effectField;
      set => this.instance_effectField = value;
    }

    [XmlAttribute(DataType = "anyURI")]
    public string camera_node
    {
      get => this.camera_nodeField;
      set => this.camera_nodeField = value;
    }
  }
}
