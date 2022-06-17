// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.PickableObject
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class PickableObject
  {
    public byte[] m_colorID = new byte[3];
    private static byte[] gColorID = new byte[3]
    {
      (byte) 1,
      (byte) 0,
      (byte) 0
    };

    public PickableObject()
    {
      this.m_colorID[0] = PickableObject.gColorID[0];
      this.m_colorID[1] = PickableObject.gColorID[1];
      this.m_colorID[2] = PickableObject.gColorID[2];
      ++PickableObject.gColorID[0];
      if (PickableObject.gColorID[0] < byte.MaxValue)
        return;
      PickableObject.gColorID[0] = (byte) 0;
      ++PickableObject.gColorID[1];
      if (PickableObject.gColorID[1] < byte.MaxValue)
        return;
      PickableObject.gColorID[1] = (byte) 0;
      ++PickableObject.gColorID[2];
    }

    public static void reset()
    {
      PickableObject.gColorID[0] = (byte) 1;
      PickableObject.gColorID[1] = (byte) 1;
      PickableObject.gColorID[2] = (byte) 1;
    }
  }
}
