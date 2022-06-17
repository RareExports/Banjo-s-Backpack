// Decompiled with JetBrains decompiler
// Type: RummageAttributes.RummageKeepReflectionSafeAttribute
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace RummageAttributes
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
  [RummageKeepUsersReflectionSafe]
  public sealed class RummageKeepReflectionSafeAttribute : Attribute
  {
  }
}
