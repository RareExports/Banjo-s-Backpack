// Decompiled with JetBrains decompiler
// Type: Collada141.ItemChoiceType
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.CodeDom.Compiler;
using System.Xml.Serialization;

namespace Collada141
{
  [GeneratedCode("xsd", "4.0.30319.1")]
  [XmlType(IncludeInSchema = false, Namespace = "http://www.collada.org/2005/11/COLLADASchema")]
  [Serializable]
  public enum ItemChoiceType
  {
    @float,
    float2,
    float3,
    float4,
    sampler2D,
    surface,
  }
}
