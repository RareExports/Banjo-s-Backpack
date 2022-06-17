// Decompiled with JetBrains decompiler
// Type: Collada141.morph
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
  public class morph
  {
    private Collada141.extra[] extraField;
    private MorphMethodType methodField;
    private string source1Field;
    private Collada141.source[] sourceField;
    private morphTargets targetsField;

    public morph() => this.methodField = MorphMethodType.NORMALIZED;

    [XmlElement("source")]
    public Collada141.source[] source
    {
      get => this.sourceField;
      set => this.sourceField = value;
    }

    public morphTargets targets
    {
      get => this.targetsField;
      set => this.targetsField = value;
    }

    [XmlElement("extra")]
    public Collada141.extra[] extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute]
    [DefaultValue(MorphMethodType.NORMALIZED)]
    public MorphMethodType method
    {
      get => this.methodField;
      set => this.methodField = value;
    }

    [XmlAttribute("source", DataType = "anyURI")]
    public string source1
    {
      get => this.source1Field;
      set => this.source1Field = value;
    }
  }
}
