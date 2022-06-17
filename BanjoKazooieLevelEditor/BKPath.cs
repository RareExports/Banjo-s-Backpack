// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKPath
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Collections.Generic;

namespace BanjoKazooieLevelEditor
{
  public class BKPath : PickableObject
  {
    public int pathObject = -1;
    public List<ObjectData> nodes = new List<ObjectData>();

    public static BKPath clone(BKPath p)
    {
      BKPath bkPath = new BKPath();
      bkPath.pathObject = p.pathObject;
      foreach (ObjectData node in p.nodes)
        bkPath.nodes.Add(ObjectData.fullClone(node));
      return bkPath;
    }

    public bool IsPathLooped()
    {
      bool flag = true;
      foreach (ObjectData node in this.nodes)
      {
        if (node.nodeOutUID == (short) 0)
          return false;
      }
      return flag;
    }

    public int GetFirstNode()
    {
      int firstNode = 0;
      foreach (ObjectData node in this.nodes)
      {
        if (!node.node_in)
          return firstNode;
        ++firstNode;
      }
      return -1;
    }
  }
}
