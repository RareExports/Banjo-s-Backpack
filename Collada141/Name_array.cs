// Decompiled with JetBrains decompiler
// Type: Collada141.Name_array
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using RummageAttributes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
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
  public class Name_array
  {
    private ulong countField;
    private string idField;
    private string nameField;
    private string[] textField;

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
    public ulong count
    {
      get => this.countField;
      set => this.countField = value;
    }

    [XmlElement("Name")]
    public string _Text_
    {
      get => COLLADA.ConvertFromArray<string>((IList<string>) this.Values);
      set => this.Values = COLLADA.ConvertStringArray(value);
    }

    [XmlIgnore]
    public string[] Values
    {
      get => this.textField;
      set => this.textField = value;
    }
  }
}
