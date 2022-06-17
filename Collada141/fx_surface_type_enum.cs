// Decompiled with JetBrains decompiler
// Type: Collada141.fx_surface_type_enum
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
  [GeneratedCode("xsd", "4.0.30319.1")]
  [XmlType(Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [Serializable]
  public enum fx_surface_type_enum
  {
    UNTYPED,
    [XmlEnum("1D")] Item1D,
    [XmlEnum("2D")] Item2D,
    [XmlEnum("3D")] Item3D,
    RECT,
    CUBE,
    DEPTH,
  }
}
