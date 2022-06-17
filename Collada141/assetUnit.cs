// Decompiled with JetBrains decompiler
// Type: Collada141.assetUnit
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
  public class assetUnit
  {
    private double meterField;
    private string nameField;

    public assetUnit()
    {
      this.meterField = 1.0;
      this.nameField = nameof (meter);
    }

    [XmlAttribute]
    [DefaultValue(1.0)]
    public double meter
    {
      get => this.meterField;
      set => this.meterField = value;
    }

    [XmlAttribute(DataType = "NMTOKEN")]
    [DefaultValue("meter")]
    public string name
    {
      get => this.nameField;
      set => this.nameField = value;
    }
  }
}
