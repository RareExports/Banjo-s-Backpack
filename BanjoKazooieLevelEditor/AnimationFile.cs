// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.AnimationFile
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Collections.Generic;

namespace BanjoKazooieLevelEditor
{
  public class AnimationFile
  {
    public int id;
    public int offset;
    public string name = "";
    public int pointer;
    public List<int> modelPointers = new List<int>();

    public AnimationFile(int id_, int offset_, string name_, List<int> modelPointers_)
    {
      this.id = id_;
      this.pointer = 24216 + this.id * 8;
      this.modelPointers = modelPointers_;
      this.offset = offset_;
      this.name = name_;
    }

    public override string ToString() => this.name;
  }
}
