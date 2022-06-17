// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BoundingBox
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace BanjoKazooieLevelEditor
{
  public struct BoundingBox
  {
    public int smallX;
    public int smallY;
    public int smallZ;
    public int largeX;
    public int largeY;
    public int largeZ;

    public int getSize() => ((IEnumerable<int>) new int[6]
    {
      Math.Abs(this.smallX),
      Math.Abs(this.smallY),
      Math.Abs(this.smallZ),
      this.largeX,
      this.largeY,
      this.largeZ
    }).Max();
  }
}
