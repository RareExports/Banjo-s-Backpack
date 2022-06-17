// Decompiled with JetBrains decompiler
// Type: Collada141.rigid_constraintTechnique_commonLimits
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
  public class rigid_constraintTechnique_commonLimits
  {
    private rigid_constraintTechnique_commonLimitsLinear linearField;
    private rigid_constraintTechnique_commonLimitsSwing_cone_and_twist swing_cone_and_twistField;

    public rigid_constraintTechnique_commonLimitsSwing_cone_and_twist swing_cone_and_twist
    {
      get => this.swing_cone_and_twistField;
      set => this.swing_cone_and_twistField = value;
    }

    public rigid_constraintTechnique_commonLimitsLinear linear
    {
      get => this.linearField;
      set => this.linearField = value;
    }
  }
}
