// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.TextFile
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BanjoKazooieLevelEditor
{
  [XmlRoot("TextFile", Namespace = "BanjoKazooieLevelEditor")]
  [Serializable]
  public class TextFile
  {
    public bool topFirst = true;
    public string description = "";
    public string level = "";
    public int pointer;
    public List<TextFilePart> parts = new List<TextFilePart>();

    public TextFile()
    {
    }

    public TextFile(List<TextFilePart> parts_, string level_, int pointer_, bool topFirst_)
    {
      this.parts = parts_;
      this.level = level_;
      this.pointer = pointer_;
      this.topFirst = topFirst_;
    }
  }
}
