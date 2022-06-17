// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.BkSkyBoxDigit
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class BkSkyBoxDigit
  {
    public int id;
    public string name = "";

    public BkSkyBoxDigit(int id_)
    {
      this.id = id_;
      this.name = this.setName(this.id);
    }

    public string setName(int id_)
    {
      string str = "";
      switch (id_)
      {
        case 1981:
          str = "Sky - Mumbo's Mountain";
          break;
        case 1982:
          str = "Sky - Mumbo's Mountain Clouds";
          break;
        case 1983:
          str = "Sky - Treasure Trove Cove";
          break;
        case 1984:
          str = "Sky - Treasure Trove Cove Clouds";
          break;
        case 1985:
          str = "Sky - Gobi's Valley";
          break;
        case 1986:
          str = "Sky - Mad Monster Mansion";
          break;
        case 1987:
          str = "Sky - Mad Monster Mansion Fog";
          break;
        case 1988:
          str = "Sky - Spiral Mountain";
          break;
        case 1989:
          str = "Sky - Rusty Bucket Bay";
          break;
        case 1990:
          str = "Sky - Freezeezy Peak";
          break;
        case 1991:
          str = "Sky - Freezeezy Peak Clouds";
          break;
        case 1992:
          str = "Sky - Freezeezy Peak More Clouds";
          break;
        case 1997:
          str = "Sky - Beach Ending";
          break;
      }
      return str;
    }
  }
}
