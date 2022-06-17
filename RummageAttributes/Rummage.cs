// Decompiled with JetBrains decompiler
// Type: RummageAttributes.Rummage
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace RummageAttributes
{
  public static class Rummage
  {
    public static Type Safe([RummageAssumeTypeSafe] Type type) => type;
  }
}
