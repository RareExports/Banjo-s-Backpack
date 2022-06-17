// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.TextureSetting
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

namespace BanjoKazooieLevelEditor
{
  public class TextureSetting
  {
    public int width;
    public int height;
    public int cms;
    public int cmt;
    public float textureHRatio;
    public float textureWRatio;
    public bool cull_none;
    public bool cull_front;
    public bool cull_back;
    public bool cull_both;
    public string name = "";
    public bool fromSolid;
    public bool fromAlpha;
    public int CULLNONE = 2;
    public int CULLFRONT = 18;
    public int CULLBACK = 34;
    public int CULLBOTH = 50;
    public bool hasAlpha;
    public int palSize = 16;
    public bool processed;
    public byte textureMode = 8;
    public int textureData;
    public bool ISALPHA;

    public TextureSetting(int w_, int h_, int cms_, int cmt_, int textureData_)
    {
      this.width = w_;
      this.height = h_;
      this.cms = cms_;
      this.cmt = cmt_;
      this.textureData = textureData_;
    }

    public TextureSetting(
      int w_,
      int h_,
      int cms_,
      int cmt_,
      int textureData_,
      bool cback,
      bool cfront,
      bool cboth,
      byte texMode,
      float texHR,
      float texWR,
      int palSize_,
      bool isA,
      bool proc)
    {
      this.textureMode = texMode;
      this.width = w_;
      this.height = h_;
      this.cms = cms_;
      this.cmt = cmt_;
      this.textureData = textureData_;
      this.cull_back = cback;
      this.cull_front = cfront;
      this.cull_both = cboth;
      this.textureHRatio = texHR;
      this.textureWRatio = texWR;
      this.palSize = palSize_;
      this.ISALPHA = isA;
      this.processed = proc;
    }

    public int getCullMode()
    {
      if (this.cull_none)
        return this.CULLNONE;
      if (this.cull_back)
        return this.CULLBACK;
      if (this.cull_both)
        return this.CULLBOTH;
      return this.cull_front ? this.CULLFRONT : this.CULLBACK;
    }

    public void setTextureMode(byte mode) => this.textureMode = mode;

    public void setRatio(float sScale, float tScale)
    {
      this.textureHRatio = tScale / 32f / (float) this.height;
      this.textureWRatio = sScale / 32f / (float) this.width;
    }

    public static TextureSetting clone(TextureSetting t) => new TextureSetting(t.width, t.height, t.cms, t.cmt, t.textureData, t.cull_back, t.cull_front, t.cull_both, t.textureMode, t.textureHRatio, t.textureWRatio, t.palSize, t.ISALPHA, t.processed);

    public bool equal(TextureSetting t)
    {
      bool flag = false;
      if (this.width == t.width && this.height == t.height && this.textureData == t.textureData && this.cmt == t.cmt && this.cms == t.cms && this.cull_back == t.cull_back && this.cull_both == t.cull_both && this.cull_front == t.cull_front && this.cull_none == t.cull_none && this.ISALPHA == t.ISALPHA && this.fromAlpha == t.fromAlpha && this.fromSolid == t.fromSolid && (int) this.textureMode == (int) t.textureMode)
        flag = true;
      return flag;
    }
  }
}
