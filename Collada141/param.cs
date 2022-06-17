// Decompiled with JetBrains decompiler
// Type: Collada141.param
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
  public class param
  {
    private string nameField;
    private string semanticField;
    private string sidField;
    private string typeField;
    private string valueField;

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

    [XmlAttribute(DataType = "NMTOKEN")]
    public string semantic
    {
      get => this.semanticField;
      set => this.semanticField = value;
    }

    [XmlAttribute(DataType = "NMTOKEN")]
    public string type
    {
      get => this.typeField;
      set => this.typeField = value;
    }

    [XmlText]
    public string Value
    {
      get => this.valueField;
      set => this.valueField = value;
    }
  }
}
