// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ErasedObject
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace BanjoKazooieLevelEditor
{
  internal class ErasedObject : IComparable
  {
    public int address;
    public int type;

    public ErasedObject(int address_, int type_)
    {
      this.address = address_;
      this.type = type_;
    }

    public int CompareTo(object obj) => this.address.CompareTo(((ErasedObject) obj).address);
  }
}
