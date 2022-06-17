// Decompiled with JetBrains decompiler
// Type: Collada141.fx_annotate_common
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
  [XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [RummageKeepReflectionSafe]
  [Serializable]
  public class fx_annotate_common
  {
    private string bool2Field;
    private string bool3Field;
    private string bool4Field;
    private bool boolField;
    private string float2Field;
    private string float2x2Field;
    private string float3Field;
    private string float3x3Field;
    private string float4Field;
    private string float4x4Field;
    private double floatField;
    private string int2Field;
    private string int3Field;
    private string int4Field;
    private long intField;
    private string nameField;
    private string stringField;

    public bool @bool
    {
      get => this.boolField;
      set => this.boolField = value;
    }

    public string bool2
    {
      get => this.bool2Field;
      set => this.bool2Field = value;
    }

    public string bool3
    {
      get => this.bool3Field;
      set => this.bool3Field = value;
    }

    public string bool4
    {
      get => this.bool4Field;
      set => this.bool4Field = value;
    }

    public long @int
    {
      get => this.intField;
      set => this.intField = value;
    }

    public string int2
    {
      get => this.int2Field;
      set => this.int2Field = value;
    }

    public string int3
    {
      get => this.int3Field;
      set => this.int3Field = value;
    }

    public string int4
    {
      get => this.int4Field;
      set => this.int4Field = value;
    }

    public double @float
    {
      get => this.floatField;
      set => this.floatField = value;
    }

    public string float2
    {
      get => this.float2Field;
      set => this.float2Field = value;
    }

    public string float3
    {
      get => this.float3Field;
      set => this.float3Field = value;
    }

    public string float4
    {
      get => this.float4Field;
      set => this.float4Field = value;
    }

    public string float2x2
    {
      get => this.float2x2Field;
      set => this.float2x2Field = value;
    }

    public string float3x3
    {
      get => this.float3x3Field;
      set => this.float3x3Field = value;
    }

    public string float4x4
    {
      get => this.float4x4Field;
      set => this.float4x4Field = value;
    }

    public string @string
    {
      get => this.stringField;
      set => this.stringField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string name
    {
      get => this.nameField;
      set => this.nameField = value;
    }
  }
}
