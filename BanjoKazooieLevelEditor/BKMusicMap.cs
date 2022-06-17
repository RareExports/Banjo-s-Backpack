// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BKMusicMap
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BKMusicMap
  {
    public string trackName = "";
    public string secondaryTrackName = "";
    public int trackID;
    public int secondaryTrackID;
    public int mapID;

    public BKMusicMap(int mapID_, int trackID_, int secondaryTrackID_)
    {
      this.trackID = trackID_;
      this.secondaryTrackID = secondaryTrackID_;
      this.mapID = mapID_;
      this.trackName = BKTrack.setTrackName(this.trackID);
      this.secondaryTrackName = BKTrack.setTrackName(this.secondaryTrackID);
    }
  }
}
