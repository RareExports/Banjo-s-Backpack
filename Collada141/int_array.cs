// Decompiled with JetBrains decompiler
// Type: Collada141.int_array
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
  public class int_array
  {
    private ulong countField;
    private string idField;
    private string maxInclusiveField;
    private string minInclusiveField;
    private string nameField;
    private int[] textField;

    public int_array()
    {
      this.minInclusiveField = "-2147483648";
      this.maxInclusiveField = "2147483647";
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
    public ulong count
    {
      get => this.countField;
      set => this.countField = value;
    }

    [XmlAttribute(DataType = "integer")]
    [DefaultValue("-2147483648")]
    public string minInclusive
    {
      get => this.minInclusiveField;
      set => this.minInclusiveField = value;
    }

    [XmlAttribute(DataType = "integer")]
    [DefaultValue("2147483647")]
    public string maxInclusive
    {
      get => this.maxInclusiveField;
      set => this.maxInclusiveField = value;
    }

    [XmlText]
    public string _Text_
    {
      get => COLLADA.ConvertFromArray<int>((IList<int>) this.Values);
      set => this.Values = COLLADA.ConvertIntArray(value);
    }

    [XmlIgnore]
    public int[] Values
    {
      get => this.textField;
      set => this.textField = value;
    }
  }
}
