// Decompiled with JetBrains decompiler
// Type: Collada141.common_color_or_texture_typeTexture
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
  public class common_color_or_texture_typeTexture
  {
    private extra extraField;
    private string texcoordField;
    private string textureField;

    public extra extra
    {
      get => this.extraField;
      set => this.extraField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string texture
    {
      get => this.textureField;
      set => this.textureField = value;
    }

    [XmlAttribute(DataType = "NCName")]
    public string texcoord
    {
      get => this.texcoordField;
      set => this.texcoordField = value;
    }
  }
}
