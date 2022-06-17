// Decompiled with JetBrains decompiler
// Type: Collada141.fx_surface_init_cube_common
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
  public class fx_surface_init_cube_common
  {
    private object[] itemsField;

    [XmlElement("all", typeof (fx_surface_init_cube_commonAll))]
    [XmlElement("face", typeof (fx_surface_init_cube_commonFace))]
    [XmlElement("primary", typeof (fx_surface_init_cube_commonPrimary))]
    public object[] Items
    {
      get => this.itemsField;
      set => this.itemsField = value;
    }
  }
}
