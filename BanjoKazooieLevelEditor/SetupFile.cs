// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SetupFile
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class SetupFile
  {
    public string name = "";
    public int pointer;
    public int modelAPointer;
    public int modelBPointer;
    public int sceneID;
    public int levelID;
    public BoundingBox bounds;
    public BoundingBox boundsA;

    public SetupFile(string name, int pointer, int sceneID, int modelAPointer, int modelBPointer)
    {
      this.name = name;
      this.pointer = pointer;
      this.modelAPointer = modelAPointer;
      this.modelBPointer = modelBPointer;
      this.sceneID = sceneID;
    }
  }
}
