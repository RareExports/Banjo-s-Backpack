// Decompiled with JetBrains decompiler
// Type: Collada141.effectFx_profile_abstractProfile_COMMONTechniqueLambert
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
  public class effectFx_profile_abstractProfile_COMMONTechniqueLambert
  {
    private common_color_or_texture_type ambientField;
    private common_color_or_texture_type diffuseField;
    private common_color_or_texture_type emissionField;
    private common_float_or_param_type index_of_refractionField;
    private common_color_or_texture_type reflectiveField;
    private common_float_or_param_type reflectivityField;
    private common_float_or_param_type transparencyField;
    private common_transparent_type transparentField;

    public common_color_or_texture_type emission
    {
      get => this.emissionField;
      set => this.emissionField = value;
    }

    public common_color_or_texture_type ambient
    {
      get => this.ambientField;
      set => this.ambientField = value;
    }

    public common_color_or_texture_type diffuse
    {
      get => this.diffuseField;
      set => this.diffuseField = value;
    }

    public common_color_or_texture_type reflective
    {
      get => this.reflectiveField;
      set => this.reflectiveField = value;
    }

    public common_float_or_param_type reflectivity
    {
      get => this.reflectivityField;
      set => this.reflectivityField = value;
    }

    public common_transparent_type transparent
    {
      get => this.transparentField;
      set => this.transparentField = value;
    }

    public common_float_or_param_type transparency
    {
      get => this.transparencyField;
      set => this.transparencyField = value;
    }

    public common_float_or_param_type index_of_refraction
    {
      get => this.index_of_refractionField;
      set => this.index_of_refractionField = value;
    }
  }
}
