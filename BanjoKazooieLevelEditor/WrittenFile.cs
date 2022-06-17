// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.WrittenFile
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  internal class WrittenFile
  {
    public string filename = "";
    public string address = "";
    public int pointer;
    public int modelAPointer;
    public int modelBPointer;
    public bool replaceModel;
    public string replacementModelFile = "";
    public string replacementModelBFile = "";
    public BoundingBox setupBounds;

    public WrittenFile(
      string file_,
      BoundingBox bb_,
      int pointer_,
      int modelAPointer_,
      int modelBPointer_,
      string replacementModelFile_,
      string replacementModelBFile_)
    {
      this.setupBounds = bb_;
      this.filename = file_;
      this.filename = this.filename.Replace("\\", "");
      this.address = this.filename.Replace(".bin", "");
      this.pointer = pointer_;
      this.modelAPointer = modelAPointer_;
      this.modelBPointer = modelBPointer_;
      this.replacementModelFile = replacementModelFile_;
      this.replacementModelBFile = replacementModelBFile_;
      if (!(this.replacementModelFile == "") || !(this.replacementModelBFile == ""))
        return;
      this.replaceModel = false;
    }
  }
}
