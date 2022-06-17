// Decompiled with JetBrains decompiler
// Type: Collada141.rigid_constraintTechnique_commonSpring
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
  public class rigid_constraintTechnique_commonSpring
  {
    private rigid_constraintTechnique_commonSpringAngular angularField;
    private rigid_constraintTechnique_commonSpringLinear linearField;

    public rigid_constraintTechnique_commonSpringAngular angular
    {
      get => this.angularField;
      set => this.angularField = value;
    }

    public rigid_constraintTechnique_commonSpringLinear linear
    {
      get => this.linearField;
      set => this.linearField = value;
    }
  }
}
