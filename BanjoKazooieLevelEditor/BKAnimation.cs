// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKAnimation
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Collections.Generic;

namespace BanjoKazooieLevelEditor
{
  public class BKAnimation
  {
    public ushort startFrame;
    public ushort endFrame;
    public List<BKAnimationSection> sections = new List<BKAnimationSection>();

    public BKAnimation(byte[] animationData)
    {
      this.startFrame = (ushort) (((uint) animationData[0] << 8) + (uint) animationData[1]);
      this.endFrame = (ushort) (((uint) animationData[2] << 8) + (uint) animationData[3]);
      ushort num1 = (ushort) (((uint) animationData[4] << 8) + (uint) animationData[5]);
      ushort index1 = 8;
      while (this.sections.Count < (int) num1)
      {
        BKAnimationSection animationSection = new BKAnimationSection((ushort) (((int) animationData[(int) index1] << 8) + (int) animationData[(int) index1 + 1] >> 4), (TransformationType) ((int) animationData[(int) index1 + 1] & 15));
        ushort index2 = (ushort) ((uint) index1 + 2U);
        ushort num2 = (ushort) (((uint) animationData[(int) index2] << 8) + (uint) animationData[(int) index2 + 1]);
        index1 = (ushort) ((uint) index2 + 2U);
        if (this.sections.Count != 17)
          ;
        while (animationSection.commands.Count < (int) num2)
        {
          BKAnimationCommand animationCommand = new BKAnimationCommand((ushort) ((uint) animationData[(int) index1] >> 6), (ushort) (((int) animationData[(int) index1] << 8) + (int) animationData[(int) index1 + 1] & 16383), (short) (((int) animationData[(int) index1 + 2] << 8) + (int) animationData[(int) index1 + 3]));
          index1 += (ushort) 4;
          animationSection.commands.Add(animationCommand);
        }
        this.sections.Add(animationSection);
      }
    }
  }
}
