// Decompiled with JetBrains decompiler
// Type: Collada141.instance_effectTechnique_hint
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
  public class instance_effectTechnique_hint
  {
    private string platformField;
    private string profileField;
    private string refField;

    [XmlAttribute(DataType = "NCName")]
    public string platform
    {
      get => this.platformField;
      set => this.platformField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string profile
    {
      get => this.profileField;
      set => this.profileField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string @ref
    {
      get => this.refField;
      set => this.refField = value;
    }
  }
}
