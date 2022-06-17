// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.TextFilePart
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Xml.Serialization;

namespace BanjoKazooieLevelEditor
{
  [XmlRoot("TextFilePart", Namespace = "BanjoKazooieLevelEditor")]
  [Serializable]
  public class TextFilePart
  {
    public byte[] hex;
    public bool top;
    public int headID;
    public bool ans;
    public bool needsHeader;
    public int group = 1;

    public TextFilePart()
    {
    }

    public TextFilePart(
      byte[] hex_,
      int headID_,
      bool top_,
      bool ans_,
      bool needsHeader_,
      int group_)
    {
      this.hex = hex_;
      this.headID = headID_;
      this.ans = ans_;
      this.top = top_;
      this.needsHeader = needsHeader_;
      this.group = group_;
    }
  }
}
