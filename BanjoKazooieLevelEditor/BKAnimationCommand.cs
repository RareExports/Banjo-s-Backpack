// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKAnimationCommand
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKAnimationCommand
  {
    public ushort unknown;
    public ushort frameNumber;
    public short transformFactor;

    public BKAnimationCommand(ushort unknown_, ushort frameNumber_, short transformFactor_)
    {
      this.unknown = unknown_;
      this.frameNumber = frameNumber_;
      this.transformFactor = transformFactor_;
    }
  }
}
