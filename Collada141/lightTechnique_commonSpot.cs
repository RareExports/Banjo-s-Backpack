// Decompiled with JetBrains decompiler
// Type: Collada141.lightTechnique_commonSpot
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
  public class lightTechnique_commonSpot
  {
    private TargetableFloat3 colorField;
    private TargetableFloat constant_attenuationField;
    private TargetableFloat falloff_angleField;
    private TargetableFloat falloff_exponentField;
    private TargetableFloat linear_attenuationField;
    private TargetableFloat quadratic_attenuationField;

    public TargetableFloat3 color
    {
      get => this.colorField;
      set => this.colorField = value;
    }

    public TargetableFloat constant_attenuation
    {
      get => this.constant_attenuationField;
      set => this.constant_attenuationField = value;
    }

    public TargetableFloat linear_attenuation
    {
      get => this.linear_attenuationField;
      set => this.linear_attenuationField = value;
    }

    public TargetableFloat quadratic_attenuation
    {
      get => this.quadratic_attenuationField;
      set => this.quadratic_attenuationField = value;
    }

    public TargetableFloat falloff_angle
    {
      get => this.falloff_angleField;
      set => this.falloff_angleField = value;
    }

    public TargetableFloat falloff_exponent
    {
      get => this.falloff_exponentField;
      set => this.falloff_exponentField = value;
    }
  }
}
