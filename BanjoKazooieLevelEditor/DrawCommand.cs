// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.DrawCommand
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class DrawCommand
  {
    public byte cmdNo;
    public int commandLength;
    public int dlStartOffset;
    public int dlEndOffset;
    public int boneID = -1;
    public bool nested;

    public DrawCommand(
      byte cmdNo_,
      int cmdLength_,
      int dlStartOffset_,
      int dlEndOffset_,
      int boneID_,
      bool nested_)
    {
      this.cmdNo = cmdNo_;
      this.commandLength = cmdLength_;
      this.dlStartOffset = dlStartOffset_;
      this.dlEndOffset = dlEndOffset_;
      this.boneID = boneID_;
      this.nested = nested_;
    }
  }
}
