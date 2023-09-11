// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.GeneralSettings
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace BanjoKazooieLevelEditor
{
  public class GeneralSettings : Form
  {
    private byte[] FCF698;
    private List<byte> F9CAE0;
    private List<byte> F37F90;
    public bool updatedF37F90;
    public bool updatedF9CAE0;
    public bool updatedFCF698;
    private int bitsRemaining = 37;
    private byte start = 93;
    private byte[] levels = new byte[11];
    private short[] doors = new short[12];
    private short[] mumboCosts = new short[5];
    private List<BKLevelName> bklevelnames = new List<BKLevelName>();
    private List<BKMusicMap> bkmusicmaps = new List<BKMusicMap>();
    private List<BKTrack> bkTracks = new List<BKTrack>();
    private MusicReassignment mrf;
    private DataTable musicTable = new DataTable();
    private DataTable startLevelsTable = new DataTable();
    private TextBox[] levelNames_tb;
    private Label[] level_lbls;
    private SceneReassignmentForm srf;
    private List<BKSkyBox> bkSkyBoxs = new List<BKSkyBox>();
    private List<BkSkyBoxDigit> bkSkyBoxDigits = new List<BkSkyBoxDigit>();
    private List<BKSceneDigit> bkscenedigits = new List<BKSceneDigit>();
    private DataTable skyMapTable = new DataTable();
    private SkyBoxReassignment sbrf;
    private ScenePickerForm spf;
    private List<WarpLocation> everyWarp = new List<WarpLocation>();
    private List<LevelEntryPoint> levelEntries = new List<LevelEntryPoint>();
    private List<LevelEntryPoint> everyEntry = new List<LevelEntryPoint>();
    private int selectedWarpID;
    private WarpLocation selectedWarp;
    private LevelEntryPoint selectedEntry;
    private List<SetupFile> setups;
    private IContainer components;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label5;
    private TextBox textBox1;
    private Label label6;
    private TabPage tabPage10;
    private ListBox level_lb;
    private Label label50;
    private TextBox entry_tb;
    private Label label51;
    private Button warpsUpdate_btn;
    private Label label52;
    private ListBox warp_lb;
    private TabPage tabPage9;
    private Button skyUpdate_btn;
    private DataGridView skymap_gv;
    private TabPage tabPage8;
    private Button updateMusic_btn;
    private DataGridView map_gv;
    private TabPage tabPage6;
    private Button sceneAssignment_update;
    private ListView sceneAssignment_lv;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private TabPage tabPage2;
    private TableLayoutPanel tableLayoutPanel7;
    private Label label4;
    private Label label1;
    private TableLayoutPanel tableLayoutPanel3;
    private TextBox door12_tb;
    private Label label19;
    private Label label7;
    private TextBox door7_tb;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private Label label13;
    private TextBox door1_tb;
    private TextBox door2_tb;
    private TextBox door3_tb;
    private TextBox door4_tb;
    private TextBox door5_tb;
    private TextBox door8_tb;
    private TextBox door9_tb;
    private Label label14;
    private Label label15;
    private Label label16;
    private TextBox door10_tb;
    private TextBox door11_tb;
    private Label label17;
    private TextBox door6_tb;
    private Button clearDoor_btn;
    private Button updateDoors_btn;
    private TableLayoutPanel tableLayoutPanel6;
    private Label label21;
    private Label label30;
    private Label bits_lbl;
    private TableLayoutPanel tableLayoutPanel1;
    private Label label3;
    private TextBox mmm_tb;
    private Label lbl9;
    private Label lbl8;
    private Label lbl7;
    private Label lbl6;
    private Label lbl5;
    private Label lbl4;
    private TextBox mm_tb;
    private TextBox ttc_tb;
    private TextBox cc_tb;
    private TextBox bgs_tb;
    private TextBox fp_tb;
    private TextBox gv_tb;
    private TextBox rbb_tb;
    private TextBox ccw_tb;
    private Label lbl10;
    private Label lbl11;
    private Label lbl12;
    private TextBox grunt_tb;
    private TextBox red_tb;
    private Label label2;
    private Button update_btn;
    private Button clear_btn;
    private TabPage tabPage1;
    private Button update_constants_btn;
    private TableLayoutPanel tableLayoutPanel5;
    private Label label45;
    private Label label31;
    private TextBox mJiggies_tb;
    private Label label20;
    private ComboBox hideNEH_cb;
    private TextBox extraH_tb;
    private Label label25;
    private ComboBox hideJN_cb;
    private Label label23;
    private TextBox extraHS_tb;
    private ComboBox specialLevel_cb;
    private Label label24;
    private TableLayoutPanel tableLayoutPanel4;
    private Label label38;
    private Label label39;
    private Label label40;
    private Label label41;
    private Label label42;
    private Label label43;
    private Label label44;
    private TextBox mEggs_tb;
    private TextBox mEggsCh_tb;
    private TextBox mFeathers_tb;
    private TextBox mGFeathersCh_tb;
    private TextBox mNotes_tb;
    private TextBox mGFeathers_tb;
    private TextBox mFeathersCh_tb;
    private TabPage tabPage5;
    private TableLayoutPanel tableLayoutPanel10;
    private TextBox tb10;
    private Label label26;
    private Label label27;
    private Label label28;
    private Label label36;
    private Label label37;
    private Label label46;
    private Label lbl3;
    private Label lbl2;
    private TextBox tb4;
    private TextBox tb3;
    private TextBox tb2;
    private TextBox tb1;
    private TextBox tb5;
    private TextBox tb6;
    private TextBox tb7;
    private TextBox tb8;
    private TextBox tb9;
    private Label lbl1;
    private TextBox tb11;
    private TextBox tb12;
    private Label label47;
    private Label label48;
    private Label label49;
    private TextBox tb13;
    private Label lbl13;
    private Button updateNames_btn;
    private TabPage tabPage7;
    private Button startLevelUpdate_btn;
    private TabControl tabControl1;
    private Panel panel4;
    private TableLayoutPanel tableLayoutPanel8;
    private Label label18;
    private Label label22;
    private TableLayoutPanel tableLayoutPanel9;
    private Label label29;
    private Label label32;
    private Label label33;
    private Label label34;
    private Label label35;
    private TextBox termiteCost_tb;
    private TextBox crocCost_tb;
    private TextBox walrusCost_tb;
    private TextBox pumpkinCost_tb;
    private TextBox beeCost_tb;
    private Button resetTokens_btn;
    private Button updateTokens_btn;
    private Panel panel2;
    private Panel panel1;
    private DataGridView startLevel_dgv;

    public GeneralSettings(
      ref List<byte> F9CAE0_,
      ref List<byte> F37F90_,
      ref byte[] FCF698_,
      List<SetupFile> setups_,
      List<LevelEntryPoint> everyEntry_)
    {
      this.InitializeComponent();
      this.setups = setups_;
      this.setupTables();
      this.FCF698 = FCF698_;
      this.F9CAE0 = F9CAE0_;
      this.F37F90 = F37F90_;
      this.createLevelList();
      this.createMusicList();
      this.createSkyBoxList();
      this.createSceneList();
      this.initData();
      int index1 = 1996;
      for (int index2 = 0; index2 < 12; ++index2)
      {
        this.doors[index2] = (short) ((int) this.FCF698[index1] * 256 + (int) this.FCF698[index1 + 1]);
        index1 += 2;
      }
      int index3 = 6984;
      for (int index4 = 0; index4 < 11; ++index4)
      {
        this.levels[index4] = this.FCF698[index3];
        index3 += 4;
      }
      this.levelNames_tb = new TextBox[13]
      {
        this.tb1,
        this.tb2,
        this.tb3,
        this.tb4,
        this.tb5,
        this.tb6,
        this.tb7,
        this.tb8,
        this.tb9,
        this.tb10,
        this.tb11,
        this.tb12,
        this.tb13
      };
      this.level_lbls = new Label[13]
      {
        this.lbl1,
        this.lbl2,
        this.lbl3,
        this.lbl4,
        this.lbl5,
        this.lbl6,
        this.lbl7,
        this.lbl8,
        this.lbl9,
        this.lbl10,
        this.lbl11,
        this.lbl12,
        this.lbl13
      };
      this.ripMusicDigits();
      this.ripLevelNames();
      this.ripSkyBoxs();
      this.populateMapList();
      this.populateWarpList();
      this.everyEntry = everyEntry_;
      this.disableEditing();
      this.initPuzzlesAndDoors();
      this.sbrf = new SkyBoxReassignment(this.bkSkyBoxDigits);
      this.spf = new ScenePickerForm(this.bkscenedigits);
      this.srf = new SceneReassignmentForm();
      this.mrf = new MusicReassignment(ref this.bkTracks);
    }

    private void setupTables()
    {
      foreach (Control control in (ArrangedElementCollection) this.tabControl1.Controls)
        control.BackColor = SystemColors.ActiveBorder;
      this.musicTable.Columns.Add("Map", typeof (string));
      this.musicTable.Columns.Add("Primary Track", typeof (string));
      this.musicTable.Columns.Add("Secondary Track", typeof (string));
      this.skyMapTable.Columns.Add("Map", typeof (string));
      this.skyMapTable.Columns.Add("SkyBox 1", typeof (string));
      this.skyMapTable.Columns.Add("Scale 1", typeof (string));
      this.skyMapTable.Columns.Add("SkyBox 2", typeof (string));
      this.skyMapTable.Columns.Add("Scale 2", typeof (string));
      this.skyMapTable.Columns.Add("SkyBox 3", typeof (string));
      this.skyMapTable.Columns.Add("Scale 3", typeof (string));
      this.startLevelsTable.Columns.Add("MapID", typeof (int));
      this.startLevelsTable.Columns.Add("Map", typeof (string));
    }

    private void ripSkyBoxs()
    {
      for (int index = 34736; index < 35735; index += 40)
      {
        int sceneID_ = (int) this.F9CAE0[index] * 256 + (int) this.F9CAE0[index + 1];
        int num1 = (int) this.F9CAE0[index + 4] * 256 + (int) this.F9CAE0[index + 5];
        short num2 = (short) ((int) this.F9CAE0[index + 8] * 256 + (int) this.F9CAE0[index + 9]);
        int num3 = (int) this.F9CAE0[index + 16] * 256 + (int) this.F9CAE0[index + 17];
        short num4 = (short) ((int) this.F9CAE0[index + 20] * 256 + (int) this.F9CAE0[index + 21]);
        int num5 = (int) this.F9CAE0[index + 28] * 256 + (int) this.F9CAE0[index + 29];
        short num6 = (short) ((int) this.F9CAE0[index + 32] * 256 + (int) this.F9CAE0[index + 33]);
        int skyBoxModel_ = num1;
        int secondarySkyBoxModel_ = num3;
        int thirdSkyBoxModel_ = num5;
        int scaleSB1_ = (int) num2;
        int scaleSB2_ = (int) num4;
        int scaleSB3_ = (int) num6;
        this.bkSkyBoxs.Add(new BKSkyBox(sceneID_, skyBoxModel_, secondarySkyBoxModel_, thirdSkyBoxModel_, (short) scaleSB1_, (short) scaleSB2_, (short) scaleSB3_));
      }
    }

    private void createSkyBoxList()
    {
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1981));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1982));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1983));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1984));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1985));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1986));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1987));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1988));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1989));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1990));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1991));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1992));
      this.bkSkyBoxDigits.Add(new BkSkyBoxDigit(1997));
    }

    private void createSceneList()
    {
      for (int sceneID_ = 1; sceneID_ < 154; ++sceneID_)
      {
        BKSceneDigit bkSceneDigit = new BKSceneDigit(sceneID_);
        if (bkSceneDigit.mapName != "")
          this.bkscenedigits.Add(bkSceneDigit);
      }
      foreach (BKSceneDigit bkscenedigit in this.bkscenedigits)
        this.level_lb.Items.Add((object) bkscenedigit.mapName);
    }

    private void initData()
    {
      this.mEggsCh_tb.Text = ((int) this.F37F90[782870] * 256 + (int) this.F37F90[782871]).ToString();
      this.mEggs_tb.Text = ((int) this.F37F90[782878] * 256 + (int) this.F37F90[782879]).ToString();
      this.mFeathersCh_tb.Text = ((int) this.F37F90[782902] * 256 + (int) this.F37F90[782903]).ToString();
      this.mFeathers_tb.Text = ((int) this.F37F90[782910] * 256 + (int) this.F37F90[782911]).ToString();
      this.mGFeathersCh_tb.Text = ((int) this.F37F90[782934] * 256 + (int) this.F37F90[782935]).ToString();
      this.mGFeathers_tb.Text = ((int) this.F37F90[782938] * 256 + (int) this.F37F90[782939]).ToString();
      this.mNotes_tb.Text = ((int) this.F37F90[19162] * 256 + (int) this.F37F90[19163]).ToString();
      this.mJiggies_tb.Text = ((int) this.F37F90[568414] * 256 + (int) this.F37F90[568415]).ToString();
      this.extraH_tb.Text = ((int) this.F37F90[568490] * 256 + (int) this.F37F90[568491]).ToString();
      this.extraHS_tb.Text = ((int) this.F37F90[568494] * 256 + (int) this.F37F90[568495]).ToString();
      this.termiteCost_tb.Text = ((int) this.F37F90[305126] * 256 + (int) this.F37F90[305127]).ToString();
      this.crocCost_tb.Text = ((int) this.F37F90[305134] * 256 + (int) this.F37F90[305135]).ToString();
      this.walrusCost_tb.Text = ((int) this.F37F90[305142] * 256 + (int) this.F37F90[305143]).ToString();
      this.pumpkinCost_tb.Text = ((int) this.F37F90[305150] * 256 + (int) this.F37F90[305151]).ToString();
      this.beeCost_tb.Text = ((int) this.F37F90[305158] * 256 + (int) this.F37F90[305159]).ToString();
      byte num1 = this.F37F90[568479];
      byte num2 = this.F37F90[570539];
      byte num3 = this.F37F90[571219];
      this.specialLevel_cb.SelectedIndex = (int) num1 - 1;
      this.hideJN_cb.SelectedIndex = (int) num2 - 1;
      this.hideNEH_cb.SelectedIndex = (int) num3 - 1;
    }

    private void createLevelList()
    {
      for (byte levelID = 1; levelID < (byte) 14; ++levelID)
      {
        string levelName = BKLevelMap.getLevelName(levelID);
        if (levelName != "")
        {
          this.specialLevel_cb.Items.Add((object) levelName);
          this.hideJN_cb.Items.Add((object) levelName);
          this.hideNEH_cb.Items.Add((object) levelName);
        }
      }
    }

    private void createMusicList()
    {
      for (int trackID_ = 0; trackID_ < 173; ++trackID_)
        this.bkTracks.Add(new BKTrack(trackID_));
    }

    public void ripMusicDigits()
    {
      for (int index = 43248; index < 44272; index += 8)
      {
        int mapID_ = (int) this.F9CAE0[index] * 256 + (int) this.F9CAE0[index + 1];
        int num1 = (int) this.F9CAE0[index + 2] * 256 + (int) this.F9CAE0[index + 3];
        int num2 = (int) this.F9CAE0[index + 4] * 256 + (int) this.F9CAE0[index + 5];
        int trackID_ = num1;
        int secondaryTrackID_ = num2;
        this.bkmusicmaps.Add(new BKMusicMap(mapID_, trackID_, secondaryTrackID_));
      }
    }

    private void initPuzzlesAndDoors()
    {
      this.mm_tb.Text = this.levels[0].ToString();
      this.ttc_tb.Text = this.levels[1].ToString();
      this.cc_tb.Text = this.levels[2].ToString();
      this.bgs_tb.Text = this.levels[3].ToString();
      this.fp_tb.Text = this.levels[4].ToString();
      this.gv_tb.Text = this.levels[5].ToString();
      this.mmm_tb.Text = this.levels[6].ToString();
      this.rbb_tb.Text = this.levels[7].ToString();
      this.ccw_tb.Text = this.levels[8].ToString();
      this.grunt_tb.Text = this.levels[9].ToString();
      this.red_tb.Text = this.levels[10].ToString();
      this.door1_tb.Text = this.doors[0].ToString();
      this.door2_tb.Text = this.doors[1].ToString();
      this.door3_tb.Text = this.doors[2].ToString();
      this.door4_tb.Text = this.doors[3].ToString();
      this.door5_tb.Text = this.doors[4].ToString();
      this.door6_tb.Text = this.doors[5].ToString();
      this.door7_tb.Text = this.doors[6].ToString();
      this.door8_tb.Text = this.doors[7].ToString();
      this.door9_tb.Text = this.doors[8].ToString();
      this.door10_tb.Text = this.doors[9].ToString();
      this.door11_tb.Text = this.doors[10].ToString();
      this.door12_tb.Text = this.doors[11].ToString();
      this.calcBitsRemaining();
    }

    private void calcBitsRemaining()
    {
      this.bitsRemaining = 37;
      for (int index = 0; index < this.levels.Length; ++index)
      {
        byte num = (byte) (Math.Floor(Math.Log((double) this.levels[index], 2.0)) + 1.0);
        if (this.levels[index] == (byte) 0)
          num = (byte) 1;
        this.bitsRemaining -= (int) num;
      }
      this.bits_lbl.Text = "Bits Remaining " + (object) this.bitsRemaining;
      if (this.bitsRemaining < 0)
        this.update_btn.Enabled = false;
      else
        this.update_btn.Enabled = true;
    }

    public void ripLevelNames()
    {
      string levelName_ = "";
      int start_ = 0;
      for (int index = 86068; index < 86302; ++index)
      {
        if (this.F9CAE0[index] == (byte) 0 && levelName_.Length > 0)
        {
          this.bklevelnames.Add(new BKLevelName(levelName_, start_, index));
          levelName_ = "";
        }
        else if (this.F9CAE0[index] != (byte) 0)
        {
          if (levelName_ == "")
            start_ = index;
          levelName_ += ((char) this.F9CAE0[index]).ToString();
        }
      }
    }

    public void populateMapList()
    {
      for (int index = 0; index < this.bklevelnames.Count<BKLevelName>(); ++index)
      {
        try
        {
          this.levelNames_tb[index].Text = this.bklevelnames[index].levelName;
          this.levelNames_tb[index].MaxLength = this.level_lbls[index].Text.Length;
        }
        catch (Exception ex)
        {
        }
      }
      for (int index = 0; index < this.setups.Count<SetupFile>(); ++index)
      {
        this.sceneAssignment_lv.Items.Add(new ListViewItem(new string[2]
        {
          this.setups[index].name,
          BKLevelMap.getLevelName((byte) this.setups[index].levelID)
        }));
        this.startLevelsTable.Rows.Add((object) this.setups[index].sceneID, (object) this.setups[index].name);
      }
      this.startLevel_dgv.DataSource = (object) this.startLevelsTable;
      this.startLevel_dgv.Columns[0].Visible = false;
      for (int index = 0; index < this.bkmusicmaps.Count<BKMusicMap>(); ++index)
      {
        try
        {
          string str = "?";
          foreach (SetupFile setup in this.setups)
          {
            if (setup.sceneID == this.bkmusicmaps[index].mapID)
            {
              str = setup.name;
              break;
            }
          }
          this.musicTable.Rows.Add((object) str, (object) this.bkmusicmaps[index].trackName, (object) this.bkmusicmaps[index].secondaryTrackName);
        }
        catch (Exception ex)
        {
        }
      }
      this.map_gv.DataSource = (object) this.musicTable.DefaultView;
      this.map_gv.Columns[0].Width = 270;
      this.map_gv.Columns[1].Width = 270;
      this.map_gv.Columns[2].Width = 270;
      for (int index = 0; index < this.map_gv.Columns.Count; ++index)
        this.map_gv.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
      for (int index = 0; index < this.bkSkyBoxs.Count<BKSkyBox>(); ++index)
      {
        try
        {
          this.skyMapTable.Rows.Add((object) this.bkSkyBoxs[index].mapName, (object) this.bkSkyBoxs[index].SB1Name, (object) this.bkSkyBoxs[index].scaleSB1.ToString("x"), (object) this.bkSkyBoxs[index].SB2Name, (object) this.bkSkyBoxs[index].scaleSB2.ToString("x"), (object) this.bkSkyBoxs[index].SB3Name, (object) this.bkSkyBoxs[index].scaleSB3.ToString("x"));
        }
        catch (Exception ex)
        {
        }
      }
      this.skymap_gv.DataSource = (object) this.skyMapTable.DefaultView;
      this.skymap_gv.Columns[0].Width = 220;
      this.skymap_gv.Columns[1].Width = 220;
      this.skymap_gv.Columns[2].Width = 70;
      this.skymap_gv.Columns[3].Width = 220;
      this.skymap_gv.Columns[4].Width = 70;
      this.skymap_gv.Columns[5].Width = 220;
      this.skymap_gv.Columns[6].Width = 70;
      for (int index = 0; index < this.skymap_gv.Columns.Count; ++index)
        this.skymap_gv.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void populateWarpList()
    {
      for (short id_ = 0; id_ < (short) 288; ++id_)
      {
        WarpLocation warpLocation = new WarpLocation((int) id_);
        if (warpLocation.name != "")
        {
          this.everyWarp.Add(warpLocation);
          this.warp_lb.Items.Add((object) warpLocation.name);
        }
      }
    }

    private void map_gv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      int num = (int) this.mrf.ShowDialog();
      int selectedTrack = this.mrf.selectedTrack;
      if (selectedTrack != -1)
      {
        if (e.ColumnIndex == 1)
        {
          this.bkmusicmaps[e.RowIndex].trackName = this.bkTracks[selectedTrack].trackName;
          this.bkmusicmaps[e.RowIndex].trackID = this.bkTracks[selectedTrack].trackID;
        }
        else if (e.ColumnIndex == 2)
        {
          this.bkmusicmaps[e.RowIndex].secondaryTrackName = this.bkTracks[selectedTrack].trackName;
          this.bkmusicmaps[e.RowIndex].secondaryTrackID = this.bkTracks[selectedTrack].trackID;
        }
        bool flag = false;
        for (int index1 = 43248; index1 < 44272 && !flag; index1 += 8)
        {
          if ((int) this.F9CAE0[index1] * 256 + (int) this.F9CAE0[index1 + 1] == this.bkmusicmaps[e.RowIndex].mapID)
          {
            if (e.ColumnIndex == 1)
            {
              this.F9CAE0[index1 + 2] = (byte) 0;
              this.F9CAE0[index1 + 3] = (byte) this.bkTracks[selectedTrack].trackID;
              this.musicTable.Rows[e.RowIndex].BeginEdit();
              this.musicTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkmusicmaps[e.RowIndex].trackName;
              this.musicTable.Rows[e.RowIndex].EndEdit();
            }
            else if (e.ColumnIndex == 2)
            {
              this.F9CAE0[index1 + 4] = (byte) 0;
              this.F9CAE0[index1 + 5] = (byte) this.bkTracks[selectedTrack].trackID;
              this.musicTable.Rows[e.RowIndex].BeginEdit();
              this.musicTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkmusicmaps[e.RowIndex].secondaryTrackName;
              this.musicTable.Rows[e.RowIndex].EndEdit();
            }
            flag = true;
            this.map_gv.DataSource = (object) this.musicTable;
            this.map_gv.DataSource = (object) this.musicTable.DefaultView;
            this.map_gv.Columns[0].Width = 270;
            this.map_gv.Columns[1].Width = 270;
            this.map_gv.Columns[2].Width = 270;
            for (int index2 = 0; index2 < this.map_gv.Columns.Count; ++index2)
              this.map_gv.Columns[index2].SortMode = DataGridViewColumnSortMode.NotSortable;
          }
        }
      }
      this.mrf.selectedTrack = -1;
    }

    private void numOnly_KeyPress(object sender, KeyPressEventArgs e)
    {
      try
      {
        if (((IEnumerable<string>) new string[10]
        {
          "1",
          "2",
          "3",
          "4",
          "5",
          "6",
          "7",
          "8",
          "9",
          "0"
        }).Contains<string>(e.KeyChar.ToString()) || e.KeyChar == '\b')
          return;
        e.Handled = true;
      }
      catch
      {
      }
    }

    private void clear_btn_Click(object sender, EventArgs e)
    {
      for (int index = 0; index < this.levels.Length; ++index)
        this.levels[index] = (byte) 1;
      this.initPuzzlesAndDoors();
    }

    private void validatePuzzles()
    {
      this.mm_tb.Text = this.mm_tb.Text == "" ? "0" : this.mm_tb.Text;
      this.ttc_tb.Text = this.ttc_tb.Text == "" ? "0" : this.ttc_tb.Text;
      this.cc_tb.Text = this.cc_tb.Text == "" ? "0" : this.cc_tb.Text;
      this.bgs_tb.Text = this.bgs_tb.Text == "" ? "0" : this.bgs_tb.Text;
      this.fp_tb.Text = this.fp_tb.Text == "" ? "0" : this.fp_tb.Text;
      this.gv_tb.Text = this.gv_tb.Text == "" ? "0" : this.gv_tb.Text;
      this.mmm_tb.Text = this.mmm_tb.Text == "" ? "0" : this.mmm_tb.Text;
      this.rbb_tb.Text = this.rbb_tb.Text == "" ? "0" : this.rbb_tb.Text;
      this.ccw_tb.Text = this.ccw_tb.Text == "" ? "0" : this.ccw_tb.Text;
      this.grunt_tb.Text = this.grunt_tb.Text == "" ? "0" : this.grunt_tb.Text;
      this.red_tb.Text = this.red_tb.Text == "" ? "0" : this.red_tb.Text;
    }

    private void updatePuzzle2(int l, byte n)
    {
      this.levels[l] = n;
      this.calcBitsRemaining();
    }

    private void updatePuzzle(TextBox t, int l)
    {
      try
      {
        this.updatePuzzle2(l, Convert.ToByte(t.Text));
      }
      catch
      {
        this.updatePuzzle2(l, (byte) 1);
      }
      t.Text = this.levels[l].ToString();
    }

    private void mm_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 0);
    }

    private void ttc_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 1);
    }

    private void cc_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 2);
    }

    private void bgs_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 3);
    }

    private void fp_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 4);
    }

    private void gv_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 5);
    }

    private void mmm_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 6);
    }

    private void rbb_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 7);
    }

    private void ccw_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 8);
    }

    private void grunt_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 9);
    }

    private void red_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Back)
        e.Handled = true;
      else
        this.updatePuzzle(sender as TextBox, 10);
    }

    private void update_btn_Click(object sender, EventArgs e)
    {
      byte num1 = 93;
      int index1 = 6984;
      for (int index2 = 0; index2 < 11; ++index2)
      {
        byte num2 = (byte) (Math.Floor(Math.Log((double) this.levels[index2], 2.0)) + 1.0);
        if (this.levels[index2] == (byte) 0)
          num2 = (byte) 1;
        this.FCF698[index1] = this.levels[index2];
        this.FCF698[index1 + 1] = num2;
        this.FCF698[index1 + 2] = (byte) 0;
        this.FCF698[index1 + 3] = num1;
        num1 += num2;
        index1 += 4;
      }
      this.updatedFCF698 = true;
    }

    private void updateDoors_btn_Click(object sender, EventArgs e)
    {
      this.doors[0] = Convert.ToInt16(this.door1_tb.Text);
      this.doors[1] = Convert.ToInt16(this.door2_tb.Text);
      this.doors[2] = Convert.ToInt16(this.door3_tb.Text);
      this.doors[3] = Convert.ToInt16(this.door4_tb.Text);
      this.doors[4] = Convert.ToInt16(this.door5_tb.Text);
      this.doors[5] = Convert.ToInt16(this.door6_tb.Text);
      this.doors[6] = Convert.ToInt16(this.door7_tb.Text);
      this.doors[7] = Convert.ToInt16(this.door8_tb.Text);
      this.doors[8] = Convert.ToInt16(this.door9_tb.Text);
      this.doors[9] = Convert.ToInt16(this.door10_tb.Text);
      this.doors[10] = Convert.ToInt16(this.door11_tb.Text);
      this.doors[11] = Convert.ToInt16(this.door12_tb.Text);
      for (int index = 0; index < 12; ++index)
      {
        if (this.doors[index] > (short) 10000)
          this.doors[index] = (short) 10000;
      }
      int index1 = 1996;
      for (int index2 = 0; index2 < 12; ++index2)
      {
        this.FCF698[index1] = (byte) ((uint) this.doors[index2] >> 8);
        this.FCF698[index1 + 1] = (byte) this.doors[index2];
        index1 += 2;
      }
      this.updatedFCF698 = true;
    }

    private void clearDoor_btn_Click(object sender, EventArgs e)
    {
      int index1 = 1996;
      for (int index2 = 0; index2 < 12; ++index2)
      {
        this.doors[index2] = (short) ((int) this.FCF698[index1] * 256 + (int) this.FCF698[index1 + 1]);
        index1 += 2;
      }
    }

    private void update_constants_btn_Click(object sender, EventArgs e)
    {
      this.F37F90[782871] = Convert.ToByte(this.mEggsCh_tb.Text);
      this.F37F90[782879] = Convert.ToByte(this.mEggs_tb.Text);
      this.F37F90[782903] = Convert.ToByte(this.mFeathersCh_tb.Text);
      this.F37F90[782911] = Convert.ToByte(this.mFeathers_tb.Text);
      this.F37F90[782935] = Convert.ToByte(this.mGFeathersCh_tb.Text);
      this.F37F90[782939] = Convert.ToByte(this.mGFeathers_tb.Text);
      this.F37F90[19163] = Convert.ToByte(this.mNotes_tb.Text);
      this.F37F90[568359] = Convert.ToByte(this.mNotes_tb.Text);
      this.F37F90[783339] = Convert.ToByte(this.mNotes_tb.Text);
      this.F37F90[786095] = Convert.ToByte(this.mNotes_tb.Text);
      this.F37F90[19162] = (byte) 0;
      this.F37F90[568358] = (byte) 0;
      this.F37F90[783338] = (byte) 0;
      this.F37F90[786094] = (byte) 0;
      this.F37F90[568415] = Convert.ToByte(this.mJiggies_tb.Text);
      this.F37F90[568491] = Convert.ToByte(this.extraH_tb.Text);
      this.F37F90[568495] = Convert.ToByte(this.extraHS_tb.Text);
      this.F37F90[568479] = (byte) (this.specialLevel_cb.SelectedIndex + 1);
      this.F37F90[570539] = (byte) (this.hideJN_cb.SelectedIndex + 1);
      this.F37F90[571219] = (byte) (this.hideNEH_cb.SelectedIndex + 1);
      this.updatedF37F90 = true;
    }

    private void updateTokens_btn_Click(object sender, EventArgs e)
    {
      short int16_1 = Convert.ToInt16(this.termiteCost_tb.Text);
      this.F37F90[305126] = (byte) ((uint) int16_1 >> 8);
      this.F37F90[305127] = (byte) int16_1;
      short int16_2 = Convert.ToInt16(this.crocCost_tb.Text);
      this.F37F90[305134] = (byte) ((uint) int16_2 >> 8);
      this.F37F90[305135] = (byte) int16_2;
      short int16_3 = Convert.ToInt16(this.walrusCost_tb.Text);
      this.F37F90[305142] = (byte) ((uint) int16_3 >> 8);
      this.F37F90[305143] = (byte) int16_3;
      short int16_4 = Convert.ToInt16(this.pumpkinCost_tb.Text);
      this.F37F90[305150] = (byte) ((uint) int16_4 >> 8);
      this.F37F90[305151] = (byte) int16_4;
      short int16_5 = Convert.ToInt16(this.beeCost_tb.Text);
      this.F37F90[305158] = (byte) ((uint) int16_5 >> 8);
      this.F37F90[305159] = (byte) int16_5;
      this.updatedF37F90 = true;
    }

    private void resetTokens_btn_Click(object sender, EventArgs e)
    {
      this.termiteCost_tb.Text = "5";
      this.crocCost_tb.Text = "10";
      this.walrusCost_tb.Text = "15";
      this.pumpkinCost_tb.Text = "20";
      this.beeCost_tb.Text = "25";
    }

    private void updateNames_btn_Click(object sender, EventArgs e)
    {
      for (int index1 = 0; index1 < this.levelNames_tb.Length; ++index1)
      {
        try
        {
          int[] numArray = this.Text2Hex(this.levelNames_tb[index1].Text);
          int index2 = 0;
          int start = this.bklevelnames[index1].start;
          for (; index2 < numArray.Length; ++index2)
          {
            this.F9CAE0[start] = (byte) numArray[index2];
            ++start;
          }
          for (; start < this.bklevelnames[index1].end; ++start)
            this.F9CAE0[start] = (byte) 0;
        }
        catch (Exception ex)
        {
        }
      }
      this.updatedF9CAE0 = true;
    }

    private int[] Text2Hex(string text)
    {
      List<int> intList = new List<int>();
      for (int index = 0; index < text.Length; ++index)
        intList.Add((int) text[index]);
      return intList.ToArray();
    }

    private void sceneAssignment_lv_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      int num = (int) this.srf.ShowDialog();
      if (this.srf.newLevel != -1)
      {
        int selectedIndex = this.sceneAssignment_lv.SelectedIndices[0];
        byte newLevel = (byte) this.srf.newLevel;
        this.setups[selectedIndex].levelID = (int) newLevel;
        bool flag = false;
        for (int index = 33412; index < 34451 && !flag; index += 8)
        {
          if ((int) this.F9CAE0[index + 4] * 256 + (int) this.F9CAE0[index + 5] == this.setups[selectedIndex].sceneID)
          {
            this.F9CAE0[index + 6] = (byte) 0;
            this.F9CAE0[index + 7] = newLevel;
            this.sceneAssignment_lv.Items[selectedIndex] = new ListViewItem(new string[2]
            {
              this.setups[selectedIndex].name,
              BKLevelMap.getLevelName(newLevel)
            });
            flag = true;
          }
        }
      }
      this.srf.newLevel = -1;
    }

    private void map_lv_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void sceneAssignment_update_Click(object sender, EventArgs e) => this.updatedF9CAE0 = true;

    private void startLevelUpdate_btn_Click(object sender, EventArgs e)
    {
      if (this.startLevel_dgv.SelectedRows.Count <= 0)
        return;
      byte num = Convert.ToByte(this.startLevel_dgv.SelectedRows[0].Cells[0].Value);
      this.F37F90[254331] = num;
      this.F37F90[624378] = num;
      this.F37F90[625582] = num;
      this.updatedF37F90 = true;
    }

    private void updateMusic_btn_Click(object sender, EventArgs e) => this.updatedF9CAE0 = true;

    private void skymap_gv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == 0)
      {
        int num1 = (int) this.spf.ShowDialog();
        string newMap = this.spf.newMap;
        if (newMap != "undef")
        {
          bool flag1 = false;
          for (int index1 = 34736; index1 < 35735 && !flag1; index1 += 40)
          {
            if ((int) this.F9CAE0[index1] * 256 + (int) this.F9CAE0[index1 + 1] == this.bkSkyBoxs[e.RowIndex].sceneID)
            {
              int num2 = 1;
              bool flag2 = false;
              for (int index2 = 0; index2 < this.bkscenedigits.Count && !flag2; ++index2)
              {
                if (newMap == this.bkscenedigits[index2].mapName)
                {
                  num2 = this.bkscenedigits[index2].sceneID;
                  flag2 = true;
                }
              }
              for (int index3 = 0; index3 < this.bkSkyBoxs.Count; ++index3)
              {
                if (num2 == this.bkSkyBoxs[index3].sceneID)
                {
                  int num3 = (int) MessageBox.Show("This scene already has a skybox assigned to it");
                  this.spf.newMap = "undef";
                  return;
                }
              }
              this.bkSkyBoxs[e.RowIndex].sceneID = num2;
              this.bkSkyBoxs[e.RowIndex].mapName = newMap;
              this.F9CAE0[index1] = (byte) (num2 >> 8);
              this.F9CAE0[index1 + 1] = (byte) num2;
              this.skyMapTable.Rows[e.RowIndex].BeginEdit();
              this.skyMapTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkSkyBoxs[e.RowIndex].mapName;
              this.skyMapTable.Rows[e.RowIndex].EndEdit();
              flag1 = true;
            }
          }
        }
        this.spf.newMap = "undef";
      }
      else if (e.ColumnIndex == 2 || e.ColumnIndex == 4 || e.ColumnIndex == 6)
      {
        SkyboxScale skyboxScale1 = new SkyboxScale((int) this.bkSkyBoxs[e.RowIndex].scaleSB1);
        if (e.ColumnIndex == 2)
        {
          SkyboxScale skyboxScale2 = new SkyboxScale((int) this.bkSkyBoxs[e.RowIndex].scaleSB1);
          int num = (int) skyboxScale2.ShowDialog();
          short size = skyboxScale2.size;
          this.bkSkyBoxs[e.RowIndex].scaleSB1 = size;
          bool flag = false;
          for (int index = 34736; index < 35735 && !flag; index += 40)
          {
            if ((int) this.F9CAE0[index] * 256 + (int) this.F9CAE0[index + 1] == this.bkSkyBoxs[e.RowIndex].sceneID)
            {
              this.F9CAE0[index + 8] = (byte) ((uint) size >> 8);
              this.F9CAE0[index + 9] = (byte) size;
              this.skyMapTable.Rows[e.RowIndex].BeginEdit();
              this.skyMapTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkSkyBoxs[e.RowIndex].scaleSB1.ToString("x");
              this.skyMapTable.Rows[e.RowIndex].EndEdit();
              flag = true;
            }
          }
        }
        if (e.ColumnIndex == 4)
        {
          SkyboxScale skyboxScale3 = new SkyboxScale((int) this.bkSkyBoxs[e.RowIndex].scaleSB2);
          int num = (int) skyboxScale3.ShowDialog();
          short size = skyboxScale3.size;
          this.bkSkyBoxs[e.RowIndex].scaleSB2 = size;
          bool flag = false;
          for (int index = 34736; index < 35735 && !flag; index += 40)
          {
            if ((int) this.F9CAE0[index] * 256 + (int) this.F9CAE0[index + 1] == this.bkSkyBoxs[e.RowIndex].sceneID)
            {
              this.F9CAE0[index + 20] = (byte) ((uint) size >> 8);
              this.F9CAE0[index + 21] = (byte) size;
              this.skyMapTable.Rows[e.RowIndex].BeginEdit();
              this.skyMapTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkSkyBoxs[e.RowIndex].scaleSB2.ToString("x");
              this.skyMapTable.Rows[e.RowIndex].EndEdit();
              flag = true;
            }
          }
        }
        if (e.ColumnIndex == 6)
        {
          SkyboxScale skyboxScale4 = new SkyboxScale((int) this.bkSkyBoxs[e.RowIndex].scaleSB3);
          int num = (int) skyboxScale4.ShowDialog();
          short size = skyboxScale4.size;
          this.bkSkyBoxs[e.RowIndex].scaleSB3 = size;
          bool flag = false;
          for (int index = 34736; index < 35735 && !flag; index += 40)
          {
            if ((int) this.F9CAE0[index] * 256 + (int) this.F9CAE0[index + 1] == this.bkSkyBoxs[e.RowIndex].sceneID)
            {
              this.F9CAE0[index + 32] = (byte) ((uint) size >> 8);
              this.F9CAE0[index + 33] = (byte) size;
              this.skyMapTable.Rows[e.RowIndex].BeginEdit();
              this.skyMapTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkSkyBoxs[e.RowIndex].scaleSB3.ToString("x");
              this.skyMapTable.Rows[e.RowIndex].EndEdit();
              flag = true;
            }
          }
        }
        this.skymap_gv.DataSource = (object) this.skyMapTable;
        this.skymap_gv.DataSource = (object) this.skyMapTable.DefaultView;
        this.skymap_gv.Columns[0].Width = 220;
        this.skymap_gv.Columns[1].Width = 220;
        this.skymap_gv.Columns[2].Width = 70;
        this.skymap_gv.Columns[3].Width = 220;
        this.skymap_gv.Columns[4].Width = 70;
        this.skymap_gv.Columns[5].Width = 220;
        this.skymap_gv.Columns[6].Width = 70;
        for (int index = 0; index < this.skymap_gv.Columns.Count; ++index)
          this.skymap_gv.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
      }
      else
      {
        int num4 = (int) this.sbrf.ShowDialog();
        string newBox = this.sbrf.newBox;
        if (newBox != "undef")
        {
          int num5 = 0;
          for (int index4 = 0; index4 < this.bkSkyBoxDigits.Count<BkSkyBoxDigit>() && num5 == 0; ++index4)
          {
            if (newBox == this.bkSkyBoxDigits[index4].name)
            {
              num5 = this.bkSkyBoxDigits[index4].id;
              if (e.ColumnIndex == 1)
              {
                this.bkSkyBoxs[e.RowIndex].SB1Name = newBox;
                this.bkSkyBoxs[e.RowIndex].skyBoxModel = num5;
              }
              else if (e.ColumnIndex == 3)
              {
                this.bkSkyBoxs[e.RowIndex].SB2Name = newBox;
                this.bkSkyBoxs[e.RowIndex].secondarySkyBoxModel = num5;
              }
              else if (e.ColumnIndex == 5)
              {
                this.bkSkyBoxs[e.RowIndex].SB3Name = newBox;
                this.bkSkyBoxs[e.RowIndex].thirdSkyBoxModel = num5;
              }
              bool flag = false;
              for (int index5 = 34736; index5 < 35735 && !flag; index5 += 40)
              {
                if ((int) this.F9CAE0[index5] * 256 + (int) this.F9CAE0[index5 + 1] == this.bkSkyBoxs[e.RowIndex].sceneID)
                {
                  if (e.ColumnIndex == 1)
                  {
                    this.F9CAE0[index5 + 4] = (byte) (num5 >> 8);
                    this.F9CAE0[index5 + 5] = (byte) num5;
                    this.skyMapTable.Rows[e.RowIndex].BeginEdit();
                    this.skyMapTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkSkyBoxs[e.RowIndex].SB1Name;
                    this.skyMapTable.Rows[e.RowIndex].EndEdit();
                  }
                  else if (e.ColumnIndex == 3)
                  {
                    this.F9CAE0[index5 + 12] = (byte) 63;
                    this.F9CAE0[index5 + 13] = (byte) 0;
                    this.F9CAE0[index5 + 16] = (byte) (num5 >> 8);
                    this.F9CAE0[index5 + 17] = (byte) num5;
                    this.skyMapTable.Rows[e.RowIndex].BeginEdit();
                    this.skyMapTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkSkyBoxs[e.RowIndex].SB2Name;
                    this.skyMapTable.Rows[e.RowIndex].EndEdit();
                  }
                  else if (e.ColumnIndex == 5)
                  {
                    this.F9CAE0[index5 + 28] = (byte) (num5 >> 8);
                    this.F9CAE0[index5 + 29] = (byte) num5;
                    this.skyMapTable.Rows[e.RowIndex].BeginEdit();
                    this.skyMapTable.Rows[e.RowIndex][e.ColumnIndex] = (object) this.bkSkyBoxs[e.RowIndex].SB3Name;
                    this.skyMapTable.Rows[e.RowIndex].EndEdit();
                  }
                  flag = true;
                  this.skymap_gv.DataSource = (object) this.skyMapTable;
                  this.skymap_gv.DataSource = (object) this.skyMapTable.DefaultView;
                  this.skymap_gv.Columns[0].Width = 220;
                  this.skymap_gv.Columns[1].Width = 220;
                  this.skymap_gv.Columns[2].Width = 70;
                  this.skymap_gv.Columns[3].Width = 220;
                  this.skymap_gv.Columns[4].Width = 70;
                  this.skymap_gv.Columns[5].Width = 220;
                  this.skymap_gv.Columns[6].Width = 70;
                }
              }
            }
          }
        }
        this.sbrf.newBox = "undef";
      }
    }

    private void warp_lb_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        this.selectedWarp = this.everyWarp[this.warp_lb.SelectedIndex];
        bool flag = false;
        for (int index = 0; index < this.everyEntry.Count<LevelEntryPoint>() && !flag; ++index)
        {
          if (this.selectedWarp.id == this.everyEntry[index].warp)
          {
            this.selectedEntry = this.everyEntry[index];
            this.selectedWarpID = index;
          }
        }
        this.enableEditing();
      }
      catch
      {
        this.disableEditing();
      }
    }

    private void disableEditing()
    {
      this.level_lb.Enabled = false;
      this.entry_tb.Enabled = false;
      this.update_btn.Enabled = false;
    }

    private void enableEditing()
    {
      this.level_lb.Enabled = true;
      this.entry_tb.Enabled = true;
      this.update_btn.Enabled = true;
      this.entry_tb.Text = this.selectedEntry.entry.ToString();
      this.level_lb.SelectedIndex = 0;
      for (int index = 0; index < this.bkscenedigits.Count<BKSceneDigit>(); ++index)
      {
        if ((int) this.selectedEntry.scene == this.bkscenedigits[index].sceneID)
          this.level_lb.SelectedIndex = index;
      }
    }

    private string fileToString(byte[] file)
    {
      StringBuilder stringBuilder = new StringBuilder(((IEnumerable<byte>) file).Count<byte>() * 2);
      foreach (byte num in file)
        stringBuilder.AppendFormat("{0:x2}", (object) num);
      return stringBuilder.ToString();
    }

    private void warpsUpdate_btn_Click(object sender, EventArgs e)
    {
      if (this.level_lb.SelectedIndex == -1 || this.warp_lb.SelectedIndex == -1 || !(this.entry_tb.Text != ""))
        return;
      this.selectedEntry.scene = (byte) this.bkscenedigits[this.level_lb.SelectedIndex].sceneID;
      this.selectedEntry.entry = Convert.ToByte(this.entry_tb.Text);
      this.everyEntry[this.selectedWarpID] = this.selectedEntry;
      Regex regex = new Regex("27BDFFE8AFBF0014AFA[\\dA-F]001[8C][\\dA-F]*?0C0C[\\dA-F][\\dA-F][\\dA-F][\\dA-F]2405([\\dA-F][\\dA-F])([\\dA-F][\\dA-F])8FBF001427BD001803E0000800000000", RegexOptions.IgnoreCase);
      byte[] file = new byte[200];
      for (int index = 0; index < 200 && this.selectedEntry.pntr + index < this.F37F90.Count<byte>(); ++index)
        file[index] = this.F37F90[this.selectedEntry.pntr + index];
      string input = this.fileToString(file);
      try
      {
        MatchCollection matchCollection = regex.Matches(input);
        if (matchCollection.Count > 0)
        {
          Match match = matchCollection[0];
          if (match.Groups.Count == 3)
          {
            int index = this.selectedEntry.pntr + match.Groups[1].Index / 2;
            this.F37F90[index] = this.selectedEntry.scene;
            this.F37F90[index + 1] = this.selectedEntry.entry;
          }
        }
      }
      catch (Exception ex)
      {
      }
      this.updatedF37F90 = true;
    }

    private void level_lb_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void puzzel_tb_Leave(object sender, EventArgs e) => this.validatePuzzles();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.label5 = new Label();
      this.textBox1 = new TextBox();
      this.label6 = new Label();
      this.tabPage10 = new TabPage();
      this.level_lb = new ListBox();
      this.label50 = new Label();
      this.entry_tb = new TextBox();
      this.label51 = new Label();
      this.warpsUpdate_btn = new Button();
      this.label52 = new Label();
      this.warp_lb = new ListBox();
      this.tabPage9 = new TabPage();
      this.skyUpdate_btn = new Button();
      this.skymap_gv = new DataGridView();
      this.tabPage8 = new TabPage();
      this.updateMusic_btn = new Button();
      this.map_gv = new DataGridView();
      this.tabPage6 = new TabPage();
      this.sceneAssignment_update = new Button();
      this.sceneAssignment_lv = new ListView();
      this.columnHeader1 = new ColumnHeader();
      this.columnHeader2 = new ColumnHeader();
      this.tabPage2 = new TabPage();
      this.panel2 = new Panel();
      this.tableLayoutPanel6 = new TableLayoutPanel();
      this.label21 = new Label();
      this.label30 = new Label();
      this.clear_btn = new Button();
      this.update_btn = new Button();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.label3 = new Label();
      this.mmm_tb = new TextBox();
      this.lbl9 = new Label();
      this.lbl8 = new Label();
      this.lbl7 = new Label();
      this.lbl6 = new Label();
      this.lbl5 = new Label();
      this.lbl4 = new Label();
      this.mm_tb = new TextBox();
      this.ttc_tb = new TextBox();
      this.cc_tb = new TextBox();
      this.bgs_tb = new TextBox();
      this.fp_tb = new TextBox();
      this.gv_tb = new TextBox();
      this.rbb_tb = new TextBox();
      this.ccw_tb = new TextBox();
      this.lbl10 = new Label();
      this.lbl11 = new Label();
      this.lbl12 = new Label();
      this.grunt_tb = new TextBox();
      this.red_tb = new TextBox();
      this.label2 = new Label();
      this.bits_lbl = new Label();
      this.panel1 = new Panel();
      this.tableLayoutPanel7 = new TableLayoutPanel();
      this.label4 = new Label();
      this.label1 = new Label();
      this.updateDoors_btn = new Button();
      this.clearDoor_btn = new Button();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.door12_tb = new TextBox();
      this.label19 = new Label();
      this.label7 = new Label();
      this.door7_tb = new TextBox();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.label13 = new Label();
      this.door1_tb = new TextBox();
      this.door2_tb = new TextBox();
      this.door3_tb = new TextBox();
      this.door4_tb = new TextBox();
      this.door5_tb = new TextBox();
      this.door8_tb = new TextBox();
      this.door9_tb = new TextBox();
      this.label14 = new Label();
      this.label15 = new Label();
      this.label16 = new Label();
      this.door10_tb = new TextBox();
      this.door11_tb = new TextBox();
      this.label17 = new Label();
      this.door6_tb = new TextBox();
      this.panel4 = new Panel();
      this.tableLayoutPanel8 = new TableLayoutPanel();
      this.label18 = new Label();
      this.label22 = new Label();
      this.tableLayoutPanel9 = new TableLayoutPanel();
      this.label29 = new Label();
      this.label32 = new Label();
      this.label33 = new Label();
      this.label34 = new Label();
      this.label35 = new Label();
      this.termiteCost_tb = new TextBox();
      this.crocCost_tb = new TextBox();
      this.walrusCost_tb = new TextBox();
      this.pumpkinCost_tb = new TextBox();
      this.beeCost_tb = new TextBox();
      this.resetTokens_btn = new Button();
      this.updateTokens_btn = new Button();
      this.tabPage1 = new TabPage();
      this.update_constants_btn = new Button();
      this.tableLayoutPanel5 = new TableLayoutPanel();
      this.label45 = new Label();
      this.label31 = new Label();
      this.mJiggies_tb = new TextBox();
      this.label20 = new Label();
      this.hideNEH_cb = new ComboBox();
      this.extraH_tb = new TextBox();
      this.label25 = new Label();
      this.hideJN_cb = new ComboBox();
      this.label23 = new Label();
      this.extraHS_tb = new TextBox();
      this.specialLevel_cb = new ComboBox();
      this.label24 = new Label();
      this.tableLayoutPanel4 = new TableLayoutPanel();
      this.label38 = new Label();
      this.label39 = new Label();
      this.label40 = new Label();
      this.label41 = new Label();
      this.label42 = new Label();
      this.label43 = new Label();
      this.label44 = new Label();
      this.mEggs_tb = new TextBox();
      this.mEggsCh_tb = new TextBox();
      this.mFeathers_tb = new TextBox();
      this.mGFeathersCh_tb = new TextBox();
      this.mNotes_tb = new TextBox();
      this.mGFeathers_tb = new TextBox();
      this.mFeathersCh_tb = new TextBox();
      this.tabPage5 = new TabPage();
      this.tableLayoutPanel10 = new TableLayoutPanel();
      this.tb10 = new TextBox();
      this.label26 = new Label();
      this.label27 = new Label();
      this.label28 = new Label();
      this.label36 = new Label();
      this.label37 = new Label();
      this.label46 = new Label();
      this.lbl3 = new Label();
      this.lbl2 = new Label();
      this.tb4 = new TextBox();
      this.tb3 = new TextBox();
      this.tb2 = new TextBox();
      this.tb1 = new TextBox();
      this.tb5 = new TextBox();
      this.tb6 = new TextBox();
      this.tb7 = new TextBox();
      this.tb8 = new TextBox();
      this.tb9 = new TextBox();
      this.lbl1 = new Label();
      this.tb11 = new TextBox();
      this.tb12 = new TextBox();
      this.label47 = new Label();
      this.label48 = new Label();
      this.label49 = new Label();
      this.tb13 = new TextBox();
      this.lbl13 = new Label();
      this.updateNames_btn = new Button();
      this.tabPage7 = new TabPage();
      this.startLevel_dgv = new DataGridView();
      this.startLevelUpdate_btn = new Button();
      this.tabControl1 = new TabControl();
      this.tableLayoutPanel2.SuspendLayout();
      this.tabPage10.SuspendLayout();
      this.tabPage9.SuspendLayout();
      ((ISupportInitialize) this.skymap_gv).BeginInit();
      this.tabPage8.SuspendLayout();
      ((ISupportInitialize) this.map_gv).BeginInit();
      this.tabPage6.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tableLayoutPanel6.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel7.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.panel4.SuspendLayout();
      this.tableLayoutPanel8.SuspendLayout();
      this.tableLayoutPanel9.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tableLayoutPanel5.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.tabPage5.SuspendLayout();
      this.tableLayoutPanel10.SuspendLayout();
      this.tabPage7.SuspendLayout();
      ((ISupportInitialize) this.startLevel_dgv).BeginInit();
      this.tabControl1.SuspendLayout();
      this.SuspendLayout();
      this.tableLayoutPanel2.BackColor = Color.White;
      this.tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.38583f));
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.61417f));
      this.tableLayoutPanel2.Controls.Add((Control) this.label5, 0, 10);
      this.tableLayoutPanel2.Controls.Add((Control) this.textBox1, 1, 6);
      this.tableLayoutPanel2.Location = new Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 11;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel2.Size = new Size(200, 100);
      this.tableLayoutPanel2.TabIndex = 0;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(4, 211);
      this.label5.Name = "label5";
      this.label5.Size = new Size(102, 13);
      this.label5.TabIndex = 41;
      this.label5.Text = "RED HONEYCOMB";
      this.textBox1.BorderStyle = BorderStyle.None;
      this.textBox1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.textBox1.Location = new Point(129, 130);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(67, 14);
      this.textBox1.TabIndex = 7;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(4, 109);
      this.label6.Margin = new Padding(3);
      this.label6.Name = "label6";
      this.label6.Size = new Size(85, 13);
      this.label6.TabIndex = 29;
      this.label6.Text = "GOBI'S VALLEY";
      this.tabPage10.Controls.Add((Control) this.level_lb);
      this.tabPage10.Controls.Add((Control) this.label50);
      this.tabPage10.Controls.Add((Control) this.entry_tb);
      this.tabPage10.Controls.Add((Control) this.label51);
      this.tabPage10.Controls.Add((Control) this.warpsUpdate_btn);
      this.tabPage10.Controls.Add((Control) this.label52);
      this.tabPage10.Controls.Add((Control) this.warp_lb);
      this.tabPage10.Location = new Point(4, 22);
      this.tabPage10.Name = "tabPage10";
      this.tabPage10.Padding = new Padding(3);
      this.tabPage10.Size = new Size(835, 474);
      this.tabPage10.TabIndex = 9;
      this.tabPage10.Text = "Warps";
      this.tabPage10.UseVisualStyleBackColor = true;
      this.level_lb.FormattingEnabled = true;
      this.level_lb.Location = new Point(258, 22);
      this.level_lb.Name = "level_lb";
      this.level_lb.Size = new Size(205, 420);
      this.level_lb.TabIndex = 14;
      this.level_lb.SelectedIndexChanged += new EventHandler(this.level_lb_SelectedIndexChanged);
      this.label50.AutoSize = true;
      this.label50.Location = new Point(13, 6);
      this.label50.Name = "label50";
      this.label50.Size = new Size(33, 13);
      this.label50.TabIndex = 13;
      this.label50.Text = "Warp";
      this.entry_tb.Location = new Point(469, 22);
      this.entry_tb.Name = "entry_tb";
      this.entry_tb.Size = new Size(74, 20);
      this.entry_tb.TabIndex = 12;
      this.entry_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.label51.AutoSize = true;
      this.label51.Location = new Point(466, 6);
      this.label51.Name = "label51";
      this.label51.Size = new Size(31, 13);
      this.label51.TabIndex = 11;
      this.label51.Text = "Entry";
      this.warpsUpdate_btn.Location = new Point(468, 48);
      this.warpsUpdate_btn.Name = "warpsUpdate_btn";
      this.warpsUpdate_btn.Size = new Size(75, 23);
      this.warpsUpdate_btn.TabIndex = 10;
      this.warpsUpdate_btn.Text = "Update";
      this.warpsUpdate_btn.UseVisualStyleBackColor = true;
      this.warpsUpdate_btn.Click += new EventHandler(this.warpsUpdate_btn_Click);
      this.label52.AutoSize = true;
      this.label52.Location = new Point((int) byte.MaxValue, 6);
      this.label52.Name = "label52";
      this.label52.Size = new Size(33, 13);
      this.label52.TabIndex = 9;
      this.label52.Text = "Level";
      this.warp_lb.FormattingEnabled = true;
      this.warp_lb.Location = new Point(14, 22);
      this.warp_lb.Name = "warp_lb";
      this.warp_lb.Size = new Size(205, 420);
      this.warp_lb.TabIndex = 8;
      this.warp_lb.SelectedIndexChanged += new EventHandler(this.warp_lb_SelectedIndexChanged);
      this.tabPage9.Controls.Add((Control) this.skyUpdate_btn);
      this.tabPage9.Controls.Add((Control) this.skymap_gv);
      this.tabPage9.Location = new Point(4, 22);
      this.tabPage9.Name = "tabPage9";
      this.tabPage9.Padding = new Padding(3);
      this.tabPage9.Size = new Size(835, 474);
      this.tabPage9.TabIndex = 8;
      this.tabPage9.Text = "Skyboxes";
      this.tabPage9.UseVisualStyleBackColor = true;
      this.skyUpdate_btn.Location = new Point(745, 451);
      this.skyUpdate_btn.Name = "skyUpdate_btn";
      this.skyUpdate_btn.Size = new Size(90, 23);
      this.skyUpdate_btn.TabIndex = 12;
      this.skyUpdate_btn.Text = "Update";
      this.skyUpdate_btn.UseVisualStyleBackColor = true;
      this.skyUpdate_btn.Click += new EventHandler(this.updateMusic_btn_Click);
      this.skymap_gv.AllowUserToAddRows = false;
      this.skymap_gv.AllowUserToDeleteRows = false;
      this.skymap_gv.AllowUserToResizeRows = false;
      this.skymap_gv.BorderStyle = BorderStyle.None;
      this.skymap_gv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      this.skymap_gv.ColumnHeadersHeight = 20;
      this.skymap_gv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.skymap_gv.Cursor = Cursors.Default;
      this.skymap_gv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.skymap_gv.Location = new Point(0, 0);
      this.skymap_gv.MultiSelect = false;
      this.skymap_gv.Name = "skymap_gv";
      this.skymap_gv.ReadOnly = true;
      this.skymap_gv.RowHeadersVisible = false;
      this.skymap_gv.ShowCellErrors = false;
      this.skymap_gv.ShowCellToolTips = false;
      this.skymap_gv.ShowEditingIcon = false;
      this.skymap_gv.ShowRowErrors = false;
      this.skymap_gv.Size = new Size(835, 445);
      this.skymap_gv.TabIndex = 9;
      this.skymap_gv.CellDoubleClick += new DataGridViewCellEventHandler(this.skymap_gv_CellDoubleClick);
      this.tabPage8.Controls.Add((Control) this.updateMusic_btn);
      this.tabPage8.Controls.Add((Control) this.map_gv);
      this.tabPage8.Location = new Point(4, 22);
      this.tabPage8.Name = "tabPage8";
      this.tabPage8.Padding = new Padding(3);
      this.tabPage8.Size = new Size(835, 474);
      this.tabPage8.TabIndex = 7;
      this.tabPage8.Text = "Music Assignment";
      this.tabPage8.UseVisualStyleBackColor = true;
      this.updateMusic_btn.Location = new Point(745, 451);
      this.updateMusic_btn.Name = "updateMusic_btn";
      this.updateMusic_btn.Size = new Size(90, 23);
      this.updateMusic_btn.TabIndex = 11;
      this.updateMusic_btn.Text = "Update";
      this.updateMusic_btn.UseVisualStyleBackColor = true;
      this.updateMusic_btn.Click += new EventHandler(this.updateMusic_btn_Click);
      this.map_gv.AllowUserToAddRows = false;
      this.map_gv.AllowUserToDeleteRows = false;
      this.map_gv.AllowUserToResizeRows = false;
      this.map_gv.BorderStyle = BorderStyle.None;
      this.map_gv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      this.map_gv.ColumnHeadersHeight = 20;
      this.map_gv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.map_gv.Cursor = Cursors.Default;
      this.map_gv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.map_gv.Location = new Point(0, 0);
      this.map_gv.MultiSelect = false;
      this.map_gv.Name = "map_gv";
      this.map_gv.ReadOnly = true;
      this.map_gv.RowHeadersVisible = false;
      this.map_gv.ShowCellErrors = false;
      this.map_gv.ShowCellToolTips = false;
      this.map_gv.ShowEditingIcon = false;
      this.map_gv.ShowRowErrors = false;
      this.map_gv.Size = new Size(835, 445);
      this.map_gv.TabIndex = 7;
      this.map_gv.CellDoubleClick += new DataGridViewCellEventHandler(this.map_gv_CellDoubleClick);
      this.tabPage6.BackColor = SystemColors.ActiveBorder;
      this.tabPage6.Controls.Add((Control) this.sceneAssignment_update);
      this.tabPage6.Controls.Add((Control) this.sceneAssignment_lv);
      this.tabPage6.Location = new Point(4, 22);
      this.tabPage6.Name = "tabPage6";
      this.tabPage6.Padding = new Padding(3);
      this.tabPage6.Size = new Size(835, 474);
      this.tabPage6.TabIndex = 5;
      this.tabPage6.Text = "Scene Assignment";
      this.tabPage6.UseVisualStyleBackColor = true;
      this.sceneAssignment_update.Location = new Point(745, 451);
      this.sceneAssignment_update.Name = "sceneAssignment_update";
      this.sceneAssignment_update.Size = new Size(90, 23);
      this.sceneAssignment_update.TabIndex = 9;
      this.sceneAssignment_update.Text = "Update";
      this.sceneAssignment_update.UseVisualStyleBackColor = true;
      this.sceneAssignment_update.Click += new EventHandler(this.sceneAssignment_update_Click);
      this.sceneAssignment_lv.Columns.AddRange(new ColumnHeader[2]
      {
        this.columnHeader1,
        this.columnHeader2
      });
      this.sceneAssignment_lv.FullRowSelect = true;
      this.sceneAssignment_lv.GridLines = true;
      this.sceneAssignment_lv.Location = new Point(0, 0);
      this.sceneAssignment_lv.MultiSelect = false;
      this.sceneAssignment_lv.Name = "sceneAssignment_lv";
      this.sceneAssignment_lv.Size = new Size(835, 445);
      this.sceneAssignment_lv.TabIndex = 8;
      this.sceneAssignment_lv.UseCompatibleStateImageBehavior = false;
      this.sceneAssignment_lv.View = View.Details;
      this.sceneAssignment_lv.SelectedIndexChanged += new EventHandler(this.map_lv_SelectedIndexChanged);
      this.sceneAssignment_lv.MouseDoubleClick += new MouseEventHandler(this.sceneAssignment_lv_MouseDoubleClick);
      this.columnHeader1.Text = "Map";
      this.columnHeader1.Width = 415;
      this.columnHeader2.Text = "Parent Level";
      this.columnHeader2.Width = 410;
      this.tabPage2.BackColor = SystemColors.ActiveBorder;
      this.tabPage2.Controls.Add((Control) this.panel2);
      this.tabPage2.Controls.Add((Control) this.panel1);
      this.tabPage2.Controls.Add((Control) this.panel4);
      this.tabPage2.Location = new Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(835, 474);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Unlockable Requirements";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.panel2.Controls.Add((Control) this.tableLayoutPanel6);
      this.panel2.Controls.Add((Control) this.clear_btn);
      this.panel2.Controls.Add((Control) this.update_btn);
      this.panel2.Controls.Add((Control) this.tableLayoutPanel1);
      this.panel2.Controls.Add((Control) this.bits_lbl);
      this.panel2.Location = new Point(6, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(247, 478);
      this.panel2.TabIndex = 71;
      this.tableLayoutPanel6.BackColor = Color.White;
      this.tableLayoutPanel6.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel6.ColumnCount = 2;
      this.tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.40385f));
      this.tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.59615f));
      this.tableLayoutPanel6.Controls.Add((Control) this.label21, 0, 0);
      this.tableLayoutPanel6.Controls.Add((Control) this.label30, 0, 0);
      this.tableLayoutPanel6.Location = new Point(10, 13);
      this.tableLayoutPanel6.Margin = new Padding(0);
      this.tableLayoutPanel6.Name = "tableLayoutPanel6";
      this.tableLayoutPanel6.RowCount = 1;
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel6.Size = new Size(209, 20);
      this.tableLayoutPanel6.TabIndex = 42;
      this.label21.AutoSize = true;
      this.label21.Location = new Point(164, 4);
      this.label21.Margin = new Padding(3);
      this.label21.Name = "label21";
      this.label21.Size = new Size(39, 13);
      this.label21.TabIndex = 25;
      this.label21.Text = "Jiggies";
      this.label30.AutoSize = true;
      this.label30.Location = new Point(4, 4);
      this.label30.Margin = new Padding(3);
      this.label30.Name = "label30";
      this.label30.Size = new Size(33, 13);
      this.label30.TabIndex = 24;
      this.label30.Text = "Level";
      this.clear_btn.Location = new Point(63, 299);
      this.clear_btn.Name = "clear_btn";
      this.clear_btn.Size = new Size(75, 23);
      this.clear_btn.TabIndex = 10;
      this.clear_btn.Text = "Clear";
      this.clear_btn.UseVisualStyleBackColor = true;
      this.clear_btn.Click += new EventHandler(this.clear_btn_Click);
      this.update_btn.Location = new Point(144, 299);
      this.update_btn.Name = "update_btn";
      this.update_btn.Size = new Size(75, 23);
      this.update_btn.TabIndex = 11;
      this.update_btn.Text = "Update";
      this.update_btn.UseVisualStyleBackColor = true;
      this.update_btn.Click += new EventHandler(this.update_btn_Click);
      this.tableLayoutPanel1.BackColor = Color.White;
      this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.40385f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.59615f));
      this.tableLayoutPanel1.Controls.Add((Control) this.label3, 0, 10);
      this.tableLayoutPanel1.Controls.Add((Control) this.mmm_tb, 1, 6);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl9, 0, 5);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl8, 0, 4);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl7, 0, 3);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl6, 0, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl5, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl4, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.mm_tb, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.ttc_tb, 1, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.cc_tb, 1, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.bgs_tb, 1, 3);
      this.tableLayoutPanel1.Controls.Add((Control) this.fp_tb, 1, 4);
      this.tableLayoutPanel1.Controls.Add((Control) this.gv_tb, 1, 5);
      this.tableLayoutPanel1.Controls.Add((Control) this.rbb_tb, 1, 7);
      this.tableLayoutPanel1.Controls.Add((Control) this.ccw_tb, 1, 8);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl10, 0, 6);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl11, 0, 7);
      this.tableLayoutPanel1.Controls.Add((Control) this.lbl12, 0, 8);
      this.tableLayoutPanel1.Controls.Add((Control) this.grunt_tb, 1, 9);
      this.tableLayoutPanel1.Controls.Add((Control) this.red_tb, 1, 10);
      this.tableLayoutPanel1.Controls.Add((Control) this.label2, 0, 9);
      this.tableLayoutPanel1.Location = new Point(10, 32);
      this.tableLayoutPanel1.Margin = new Padding(0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 12;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.Size = new Size(209, 230);
      this.tableLayoutPanel1.TabIndex = 9;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(4, 211);
      this.label3.Name = "label3";
      this.label3.Size = new Size(102, 13);
      this.label3.TabIndex = 41;
      this.label3.Text = "RED HONEYCOMB";
      this.mmm_tb.BorderStyle = BorderStyle.None;
      this.mmm_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.mmm_tb.Location = new Point(164, 130);
      this.mmm_tb.Name = "mmm_tb";
      this.mmm_tb.Size = new Size(41, 14);
      this.mmm_tb.TabIndex = 7;
      this.mmm_tb.KeyUp += new KeyEventHandler(this.mmm_tb_KeyUp);
      this.mmm_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.lbl9.AutoSize = true;
      this.lbl9.Location = new Point(4, 109);
      this.lbl9.Margin = new Padding(3);
      this.lbl9.Name = "lbl9";
      this.lbl9.Size = new Size(85, 13);
      this.lbl9.TabIndex = 29;
      this.lbl9.Text = "GOBI'S VALLEY";
      this.lbl8.AutoSize = true;
      this.lbl8.Location = new Point(4, 88);
      this.lbl8.Margin = new Padding(3);
      this.lbl8.Name = "lbl8";
      this.lbl8.Size = new Size(101, 13);
      this.lbl8.TabIndex = 28;
      this.lbl8.Text = "FREEZEEZY PEAK";
      this.lbl7.AutoSize = true;
      this.lbl7.Location = new Point(4, 67);
      this.lbl7.Margin = new Padding(3);
      this.lbl7.Name = "lbl7";
      this.lbl7.Size = new Size(130, 13);
      this.lbl7.TabIndex = 27;
      this.lbl7.Text = "BUBBLEGLOOP SWAMP";
      this.lbl6.AutoSize = true;
      this.lbl6.Location = new Point(4, 46);
      this.lbl6.Margin = new Padding(3);
      this.lbl6.Name = "lbl6";
      this.lbl6.Size = new Size(113, 13);
      this.lbl6.TabIndex = 26;
      this.lbl6.Text = "CLANKER'S CAVERN";
      this.lbl5.AutoSize = true;
      this.lbl5.Location = new Point(4, 25);
      this.lbl5.Margin = new Padding(3);
      this.lbl5.Name = "lbl5";
      this.lbl5.Size = new Size(138, 13);
      this.lbl5.TabIndex = 25;
      this.lbl5.Text = "TREASURE TROVE COVE";
      this.lbl4.AutoSize = true;
      this.lbl4.Location = new Point(4, 4);
      this.lbl4.Margin = new Padding(3);
      this.lbl4.Name = "lbl4";
      this.lbl4.Size = new Size(118, 13);
      this.lbl4.TabIndex = 24;
      this.lbl4.Text = "MUMBO'S MOUNTAIN";
      this.mm_tb.BorderStyle = BorderStyle.None;
      this.mm_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.mm_tb.Location = new Point(164, 4);
      this.mm_tb.Name = "mm_tb";
      this.mm_tb.Size = new Size(41, 14);
      this.mm_tb.TabIndex = 1;
      this.mm_tb.KeyUp += new KeyEventHandler(this.mm_tb_KeyUp);
      this.mm_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.ttc_tb.BorderStyle = BorderStyle.None;
      this.ttc_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ttc_tb.Location = new Point(164, 25);
      this.ttc_tb.Name = "ttc_tb";
      this.ttc_tb.Size = new Size(41, 14);
      this.ttc_tb.TabIndex = 2;
      this.ttc_tb.KeyUp += new KeyEventHandler(this.ttc_tb_KeyUp);
      this.ttc_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.cc_tb.BorderStyle = BorderStyle.None;
      this.cc_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cc_tb.Location = new Point(164, 46);
      this.cc_tb.Name = "cc_tb";
      this.cc_tb.Size = new Size(41, 14);
      this.cc_tb.TabIndex = 3;
      this.cc_tb.KeyUp += new KeyEventHandler(this.cc_tb_KeyUp);
      this.cc_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.bgs_tb.BorderStyle = BorderStyle.None;
      this.bgs_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.bgs_tb.Location = new Point(164, 67);
      this.bgs_tb.Name = "bgs_tb";
      this.bgs_tb.Size = new Size(41, 14);
      this.bgs_tb.TabIndex = 4;
      this.bgs_tb.KeyUp += new KeyEventHandler(this.bgs_tb_KeyUp);
      this.bgs_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.fp_tb.BorderStyle = BorderStyle.None;
      this.fp_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.fp_tb.Location = new Point(164, 88);
      this.fp_tb.Name = "fp_tb";
      this.fp_tb.Size = new Size(41, 14);
      this.fp_tb.TabIndex = 5;
      this.fp_tb.KeyUp += new KeyEventHandler(this.fp_tb_KeyUp);
      this.fp_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.gv_tb.BorderStyle = BorderStyle.None;
      this.gv_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.gv_tb.Location = new Point(164, 109);
      this.gv_tb.Name = "gv_tb";
      this.gv_tb.Size = new Size(41, 14);
      this.gv_tb.TabIndex = 6;
      this.gv_tb.KeyUp += new KeyEventHandler(this.gv_tb_KeyUp);
      this.gv_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.rbb_tb.BorderStyle = BorderStyle.None;
      this.rbb_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.rbb_tb.Location = new Point(164, 151);
      this.rbb_tb.Name = "rbb_tb";
      this.rbb_tb.Size = new Size(41, 14);
      this.rbb_tb.TabIndex = 8;
      this.rbb_tb.KeyUp += new KeyEventHandler(this.rbb_tb_KeyUp);
      this.rbb_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.ccw_tb.BorderStyle = BorderStyle.None;
      this.ccw_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.ccw_tb.Location = new Point(164, 172);
      this.ccw_tb.Name = "ccw_tb";
      this.ccw_tb.Size = new Size(41, 14);
      this.ccw_tb.TabIndex = 9;
      this.ccw_tb.KeyUp += new KeyEventHandler(this.ccw_tb_KeyUp);
      this.ccw_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.lbl10.AutoSize = true;
      this.lbl10.Location = new Point(4, 130);
      this.lbl10.Margin = new Padding(3);
      this.lbl10.Name = "lbl10";
      this.lbl10.Size = new Size(141, 13);
      this.lbl10.TabIndex = 35;
      this.lbl10.Text = "MAD MONSTER MANSION";
      this.lbl11.AutoSize = true;
      this.lbl11.Location = new Point(4, 151);
      this.lbl11.Margin = new Padding(3);
      this.lbl11.Name = "lbl11";
      this.lbl11.Size = new Size(114, 13);
      this.lbl11.TabIndex = 36;
      this.lbl11.Text = "RUSTY BUCKET BAY";
      this.lbl12.AutoSize = true;
      this.lbl12.Location = new Point(4, 172);
      this.lbl12.Margin = new Padding(3);
      this.lbl12.Name = "lbl12";
      this.lbl12.Size = new Size(113, 13);
      this.lbl12.TabIndex = 37;
      this.lbl12.Text = "CLICK CLOCK WOOD";
      this.grunt_tb.BorderStyle = BorderStyle.None;
      this.grunt_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.grunt_tb.Location = new Point(164, 193);
      this.grunt_tb.Name = "grunt_tb";
      this.grunt_tb.Size = new Size(41, 14);
      this.grunt_tb.TabIndex = 38;
      this.grunt_tb.KeyUp += new KeyEventHandler(this.grunt_tb_KeyUp);
      this.grunt_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.red_tb.BorderStyle = BorderStyle.None;
      this.red_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.red_tb.Location = new Point(164, 214);
      this.red_tb.Name = "red_tb";
      this.red_tb.Size = new Size(41, 14);
      this.red_tb.TabIndex = 39;
      this.red_tb.KeyUp += new KeyEventHandler(this.red_tb_KeyUp);
      this.red_tb.Leave += new EventHandler(this.puzzel_tb_Leave);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(4, 190);
      this.label2.Name = "label2";
      this.label2.Size = new Size(70, 13);
      this.label2.TabIndex = 40;
      this.label2.Text = "GRUNTILDA";
      this.bits_lbl.AutoSize = true;
      this.bits_lbl.Location = new Point(14, 267);
      this.bits_lbl.Name = "bits_lbl";
      this.bits_lbl.Size = new Size(40, 13);
      this.bits_lbl.TabIndex = 0;
      this.bits_lbl.Text = "bits left";
      this.panel1.Controls.Add((Control) this.tableLayoutPanel7);
      this.panel1.Controls.Add((Control) this.updateDoors_btn);
      this.panel1.Controls.Add((Control) this.clearDoor_btn);
      this.panel1.Controls.Add((Control) this.tableLayoutPanel3);
      this.panel1.Location = new Point(437, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(189, 474);
      this.panel1.TabIndex = 70;
      this.tableLayoutPanel7.BackColor = Color.White;
      this.tableLayoutPanel7.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel7.ColumnCount = 2;
      this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.55844f));
      this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.44156f));
      this.tableLayoutPanel7.Controls.Add((Control) this.label4, 0, 0);
      this.tableLayoutPanel7.Controls.Add((Control) this.label1, 1, 0);
      this.tableLayoutPanel7.Location = new Point(10, 9);
      this.tableLayoutPanel7.Margin = new Padding(0);
      this.tableLayoutPanel7.Name = "tableLayoutPanel7";
      this.tableLayoutPanel7.RowCount = 1;
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel7.Size = new Size(165, 24);
      this.tableLayoutPanel7.TabIndex = 47;
      this.label4.AutoSize = true;
      this.label4.Location = new Point(4, 4);
      this.label4.Margin = new Padding(3);
      this.label4.Name = "label4";
      this.label4.Size = new Size(61, 13);
      this.label4.TabIndex = 26;
      this.label4.Text = "Notes Door";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(72, 4);
      this.label1.Margin = new Padding(3);
      this.label1.Name = "label1";
      this.label1.Size = new Size(81, 13);
      this.label1.TabIndex = 25;
      this.label1.Text = "Required Notes";
      this.updateDoors_btn.Location = new Point(100, 297);
      this.updateDoors_btn.Name = "updateDoors_btn";
      this.updateDoors_btn.Size = new Size(75, 23);
      this.updateDoors_btn.TabIndex = 46;
      this.updateDoors_btn.Text = "Update";
      this.updateDoors_btn.UseVisualStyleBackColor = true;
      this.updateDoors_btn.Click += new EventHandler(this.updateDoors_btn_Click);
      this.clearDoor_btn.Location = new Point(19, 297);
      this.clearDoor_btn.Name = "clearDoor_btn";
      this.clearDoor_btn.Size = new Size(75, 23);
      this.clearDoor_btn.TabIndex = 45;
      this.clearDoor_btn.Text = "Clear";
      this.clearDoor_btn.UseVisualStyleBackColor = true;
      this.tableLayoutPanel3.BackColor = Color.White;
      this.tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel3.ColumnCount = 2;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.55844f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.44156f));
      this.tableLayoutPanel3.Controls.Add((Control) this.door12_tb, 1, 11);
      this.tableLayoutPanel3.Controls.Add((Control) this.label19, 0, 11);
      this.tableLayoutPanel3.Controls.Add((Control) this.label7, 0, 10);
      this.tableLayoutPanel3.Controls.Add((Control) this.door7_tb, 1, 6);
      this.tableLayoutPanel3.Controls.Add((Control) this.label8, 0, 5);
      this.tableLayoutPanel3.Controls.Add((Control) this.label9, 0, 4);
      this.tableLayoutPanel3.Controls.Add((Control) this.label10, 0, 3);
      this.tableLayoutPanel3.Controls.Add((Control) this.label11, 0, 2);
      this.tableLayoutPanel3.Controls.Add((Control) this.label12, 0, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.label13, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.door1_tb, 1, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.door2_tb, 1, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.door3_tb, 1, 2);
      this.tableLayoutPanel3.Controls.Add((Control) this.door4_tb, 1, 3);
      this.tableLayoutPanel3.Controls.Add((Control) this.door5_tb, 1, 4);
      this.tableLayoutPanel3.Controls.Add((Control) this.door8_tb, 1, 7);
      this.tableLayoutPanel3.Controls.Add((Control) this.door9_tb, 1, 8);
      this.tableLayoutPanel3.Controls.Add((Control) this.label14, 0, 6);
      this.tableLayoutPanel3.Controls.Add((Control) this.label15, 0, 7);
      this.tableLayoutPanel3.Controls.Add((Control) this.label16, 0, 8);
      this.tableLayoutPanel3.Controls.Add((Control) this.door10_tb, 1, 9);
      this.tableLayoutPanel3.Controls.Add((Control) this.door11_tb, 1, 10);
      this.tableLayoutPanel3.Controls.Add((Control) this.label17, 0, 9);
      this.tableLayoutPanel3.Controls.Add((Control) this.door6_tb, 1, 5);
      this.tableLayoutPanel3.Location = new Point(10, 32);
      this.tableLayoutPanel3.Margin = new Padding(0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 12;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel3.Size = new Size(165, 253);
      this.tableLayoutPanel3.TabIndex = 44;
      this.door12_tb.BorderStyle = BorderStyle.None;
      this.door12_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door12_tb.Location = new Point(72, 235);
      this.door12_tb.Name = "door12_tb";
      this.door12_tb.Size = new Size(64, 14);
      this.door12_tb.TabIndex = 40;
      this.label19.AutoSize = true;
      this.label19.Location = new Point(4, 232);
      this.label19.Name = "label19";
      this.label19.Size = new Size(54, 13);
      this.label19.TabIndex = 42;
      this.label19.Text = "DOOR 12";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(4, 211);
      this.label7.Name = "label7";
      this.label7.Size = new Size(54, 13);
      this.label7.TabIndex = 41;
      this.label7.Text = "DOOR 11";
      this.door7_tb.BorderStyle = BorderStyle.None;
      this.door7_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door7_tb.Location = new Point(72, 130);
      this.door7_tb.Name = "door7_tb";
      this.door7_tb.Size = new Size(64, 14);
      this.door7_tb.TabIndex = 7;
      this.label8.AutoSize = true;
      this.label8.Location = new Point(4, 109);
      this.label8.Margin = new Padding(3);
      this.label8.Name = "label8";
      this.label8.Size = new Size(48, 13);
      this.label8.TabIndex = 29;
      this.label8.Text = "DOOR 6";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(4, 88);
      this.label9.Margin = new Padding(3);
      this.label9.Name = "label9";
      this.label9.Size = new Size(48, 13);
      this.label9.TabIndex = 28;
      this.label9.Text = "DOOR 5";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(4, 67);
      this.label10.Margin = new Padding(3);
      this.label10.Name = "label10";
      this.label10.Size = new Size(48, 13);
      this.label10.TabIndex = 27;
      this.label10.Text = "DOOR 4";
      this.label11.AutoSize = true;
      this.label11.Location = new Point(4, 46);
      this.label11.Margin = new Padding(3);
      this.label11.Name = "label11";
      this.label11.Size = new Size(48, 13);
      this.label11.TabIndex = 26;
      this.label11.Text = "DOOR 3";
      this.label12.AutoSize = true;
      this.label12.Location = new Point(4, 25);
      this.label12.Margin = new Padding(3);
      this.label12.Name = "label12";
      this.label12.Size = new Size(48, 13);
      this.label12.TabIndex = 25;
      this.label12.Text = "DOOR 2";
      this.label13.AutoSize = true;
      this.label13.Location = new Point(4, 4);
      this.label13.Margin = new Padding(3);
      this.label13.Name = "label13";
      this.label13.Size = new Size(48, 13);
      this.label13.TabIndex = 24;
      this.label13.Text = "DOOR 1";
      this.door1_tb.BorderStyle = BorderStyle.None;
      this.door1_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door1_tb.Location = new Point(72, 4);
      this.door1_tb.Name = "door1_tb";
      this.door1_tb.Size = new Size(64, 14);
      this.door1_tb.TabIndex = 1;
      this.door2_tb.BorderStyle = BorderStyle.None;
      this.door2_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door2_tb.Location = new Point(72, 25);
      this.door2_tb.Name = "door2_tb";
      this.door2_tb.Size = new Size(64, 14);
      this.door2_tb.TabIndex = 2;
      this.door3_tb.BorderStyle = BorderStyle.None;
      this.door3_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door3_tb.Location = new Point(72, 46);
      this.door3_tb.Name = "door3_tb";
      this.door3_tb.Size = new Size(64, 14);
      this.door3_tb.TabIndex = 3;
      this.door4_tb.BorderStyle = BorderStyle.None;
      this.door4_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door4_tb.Location = new Point(72, 67);
      this.door4_tb.Name = "door4_tb";
      this.door4_tb.Size = new Size(64, 14);
      this.door4_tb.TabIndex = 4;
      this.door5_tb.BorderStyle = BorderStyle.None;
      this.door5_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door5_tb.Location = new Point(72, 88);
      this.door5_tb.Name = "door5_tb";
      this.door5_tb.Size = new Size(64, 14);
      this.door5_tb.TabIndex = 5;
      this.door8_tb.BorderStyle = BorderStyle.None;
      this.door8_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door8_tb.Location = new Point(72, 151);
      this.door8_tb.Name = "door8_tb";
      this.door8_tb.Size = new Size(64, 14);
      this.door8_tb.TabIndex = 8;
      this.door9_tb.BorderStyle = BorderStyle.None;
      this.door9_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door9_tb.Location = new Point(72, 172);
      this.door9_tb.Name = "door9_tb";
      this.door9_tb.Size = new Size(64, 14);
      this.door9_tb.TabIndex = 9;
      this.label14.AutoSize = true;
      this.label14.Location = new Point(4, 130);
      this.label14.Margin = new Padding(3);
      this.label14.Name = "label14";
      this.label14.Size = new Size(48, 13);
      this.label14.TabIndex = 35;
      this.label14.Text = "DOOR 7";
      this.label15.AutoSize = true;
      this.label15.Location = new Point(4, 151);
      this.label15.Margin = new Padding(3);
      this.label15.Name = "label15";
      this.label15.Size = new Size(48, 13);
      this.label15.TabIndex = 36;
      this.label15.Text = "DOOR 8";
      this.label16.AutoSize = true;
      this.label16.Location = new Point(4, 172);
      this.label16.Margin = new Padding(3);
      this.label16.Name = "label16";
      this.label16.Size = new Size(48, 13);
      this.label16.TabIndex = 37;
      this.label16.Text = "DOOR 9";
      this.door10_tb.BorderStyle = BorderStyle.None;
      this.door10_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door10_tb.Location = new Point(72, 193);
      this.door10_tb.Name = "door10_tb";
      this.door10_tb.Size = new Size(64, 14);
      this.door10_tb.TabIndex = 38;
      this.door11_tb.BorderStyle = BorderStyle.None;
      this.door11_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door11_tb.Location = new Point(72, 214);
      this.door11_tb.Name = "door11_tb";
      this.door11_tb.Size = new Size(64, 14);
      this.door11_tb.TabIndex = 39;
      this.label17.AutoSize = true;
      this.label17.Location = new Point(4, 190);
      this.label17.Name = "label17";
      this.label17.Size = new Size(54, 13);
      this.label17.TabIndex = 40;
      this.label17.Text = "DOOR 10";
      this.door6_tb.BorderStyle = BorderStyle.None;
      this.door6_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.door6_tb.Location = new Point(72, 109);
      this.door6_tb.Name = "door6_tb";
      this.door6_tb.Size = new Size(64, 14);
      this.door6_tb.TabIndex = 6;
      this.panel4.BackColor = SystemColors.AppWorkspace;
      this.panel4.Controls.Add((Control) this.tableLayoutPanel8);
      this.panel4.Controls.Add((Control) this.tableLayoutPanel9);
      this.panel4.Controls.Add((Control) this.resetTokens_btn);
      this.panel4.Controls.Add((Control) this.updateTokens_btn);
      this.panel4.Location = new Point(254, 0);
      this.panel4.Name = "panel4";
      this.panel4.Size = new Size(181, 474);
      this.panel4.TabIndex = 69;
      this.tableLayoutPanel8.BackColor = Color.White;
      this.tableLayoutPanel8.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel8.ColumnCount = 2;
      this.tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.55844f));
      this.tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.44156f));
      this.tableLayoutPanel8.Controls.Add((Control) this.label18, 0, 0);
      this.tableLayoutPanel8.Controls.Add((Control) this.label22, 1, 0);
      this.tableLayoutPanel8.Location = new Point(6, 10);
      this.tableLayoutPanel8.Margin = new Padding(0);
      this.tableLayoutPanel8.Name = "tableLayoutPanel8";
      this.tableLayoutPanel8.RowCount = 1;
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 48f));
      this.tableLayoutPanel8.Size = new Size(166, 28);
      this.tableLayoutPanel8.TabIndex = 43;
      this.label18.AutoSize = true;
      this.label18.Location = new Point(4, 4);
      this.label18.Margin = new Padding(3);
      this.label18.Name = "label18";
      this.label18.Size = new Size(54, 13);
      this.label18.TabIndex = 26;
      this.label18.Text = "Transform";
      this.label22.AutoSize = true;
      this.label22.Location = new Point(72, 4);
      this.label22.Margin = new Padding(3);
      this.label22.Name = "label22";
      this.label22.Size = new Size(89, 13);
      this.label22.TabIndex = 25;
      this.label22.Text = "Required Tokens";
      this.tableLayoutPanel9.BackColor = Color.White;
      this.tableLayoutPanel9.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel9.ColumnCount = 2;
      this.tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.55844f));
      this.tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.44156f));
      this.tableLayoutPanel9.Controls.Add((Control) this.label29, 0, 4);
      this.tableLayoutPanel9.Controls.Add((Control) this.label32, 0, 3);
      this.tableLayoutPanel9.Controls.Add((Control) this.label33, 0, 2);
      this.tableLayoutPanel9.Controls.Add((Control) this.label34, 0, 1);
      this.tableLayoutPanel9.Controls.Add((Control) this.label35, 0, 0);
      this.tableLayoutPanel9.Controls.Add((Control) this.termiteCost_tb, 1, 0);
      this.tableLayoutPanel9.Controls.Add((Control) this.crocCost_tb, 1, 1);
      this.tableLayoutPanel9.Controls.Add((Control) this.walrusCost_tb, 1, 2);
      this.tableLayoutPanel9.Controls.Add((Control) this.pumpkinCost_tb, 1, 3);
      this.tableLayoutPanel9.Controls.Add((Control) this.beeCost_tb, 1, 4);
      this.tableLayoutPanel9.Location = new Point(6, 37);
      this.tableLayoutPanel9.Margin = new Padding(0);
      this.tableLayoutPanel9.Name = "tableLayoutPanel9";
      this.tableLayoutPanel9.RowCount = 5;
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.Size = new Size(166, 108);
      this.tableLayoutPanel9.TabIndex = 14;
      this.label29.AutoSize = true;
      this.label29.Location = new Point(4, 88);
      this.label29.Margin = new Padding(3);
      this.label29.Name = "label29";
      this.label29.Size = new Size(28, 13);
      this.label29.TabIndex = 28;
      this.label29.Text = "BEE";
      this.label32.AutoSize = true;
      this.label32.Location = new Point(4, 67);
      this.label32.Margin = new Padding(3);
      this.label32.Name = "label32";
      this.label32.Size = new Size(56, 13);
      this.label32.TabIndex = 27;
      this.label32.Text = "PUMPKIN";
      this.label33.AutoSize = true;
      this.label33.Location = new Point(4, 46);
      this.label33.Margin = new Padding(3);
      this.label33.Name = "label33";
      this.label33.Size = new Size(54, 13);
      this.label33.TabIndex = 26;
      this.label33.Text = "WALRUS";
      this.label34.AutoSize = true;
      this.label34.Location = new Point(4, 25);
      this.label34.Margin = new Padding(3);
      this.label34.Name = "label34";
      this.label34.Size = new Size(37, 13);
      this.label34.TabIndex = 25;
      this.label34.Text = "CROC";
      this.label35.AutoSize = true;
      this.label35.Location = new Point(4, 4);
      this.label35.Margin = new Padding(3);
      this.label35.Name = "label35";
      this.label35.Size = new Size(55, 13);
      this.label35.TabIndex = 24;
      this.label35.Text = "TERMITE";
      this.termiteCost_tb.BorderStyle = BorderStyle.None;
      this.termiteCost_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.termiteCost_tb.Location = new Point(72, 4);
      this.termiteCost_tb.Name = "termiteCost_tb";
      this.termiteCost_tb.Size = new Size(64, 14);
      this.termiteCost_tb.TabIndex = 1;
      this.crocCost_tb.BorderStyle = BorderStyle.None;
      this.crocCost_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.crocCost_tb.Location = new Point(72, 25);
      this.crocCost_tb.Name = "crocCost_tb";
      this.crocCost_tb.Size = new Size(64, 14);
      this.crocCost_tb.TabIndex = 2;
      this.walrusCost_tb.BorderStyle = BorderStyle.None;
      this.walrusCost_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.walrusCost_tb.Location = new Point(72, 46);
      this.walrusCost_tb.Name = "walrusCost_tb";
      this.walrusCost_tb.Size = new Size(64, 14);
      this.walrusCost_tb.TabIndex = 3;
      this.pumpkinCost_tb.BorderStyle = BorderStyle.None;
      this.pumpkinCost_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.pumpkinCost_tb.Location = new Point(72, 67);
      this.pumpkinCost_tb.Name = "pumpkinCost_tb";
      this.pumpkinCost_tb.Size = new Size(64, 14);
      this.pumpkinCost_tb.TabIndex = 4;
      this.beeCost_tb.BorderStyle = BorderStyle.None;
      this.beeCost_tb.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.beeCost_tb.Location = new Point(72, 88);
      this.beeCost_tb.Name = "beeCost_tb";
      this.beeCost_tb.Size = new Size(64, 14);
      this.beeCost_tb.TabIndex = 5;
      this.resetTokens_btn.Location = new Point(16, 296);
      this.resetTokens_btn.Name = "resetTokens_btn";
      this.resetTokens_btn.Size = new Size(75, 23);
      this.resetTokens_btn.TabIndex = 16;
      this.resetTokens_btn.Text = "Reset";
      this.resetTokens_btn.UseVisualStyleBackColor = true;
      this.updateTokens_btn.Location = new Point(97, 296);
      this.updateTokens_btn.Name = "updateTokens_btn";
      this.updateTokens_btn.Size = new Size(75, 23);
      this.updateTokens_btn.TabIndex = 17;
      this.updateTokens_btn.Text = "Update";
      this.updateTokens_btn.UseVisualStyleBackColor = true;
      this.updateTokens_btn.Click += new EventHandler(this.updateTokens_btn_Click);
      this.tabPage1.BackColor = SystemColors.ActiveBorder;
      this.tabPage1.Controls.Add((Control) this.update_constants_btn);
      this.tabPage1.Controls.Add((Control) this.tableLayoutPanel5);
      this.tabPage1.Controls.Add((Control) this.tableLayoutPanel4);
      this.tabPage1.Location = new Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(835, 474);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Max Items";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.update_constants_btn.Location = new Point(760, 451);
      this.update_constants_btn.Name = "update_constants_btn";
      this.update_constants_btn.Size = new Size(75, 23);
      this.update_constants_btn.TabIndex = 62;
      this.update_constants_btn.Text = "Update";
      this.update_constants_btn.UseVisualStyleBackColor = true;
      this.update_constants_btn.Click += new EventHandler(this.update_constants_btn_Click);
      this.tableLayoutPanel5.BackColor = Color.White;
      this.tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel5.ColumnCount = 2;
      this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.38583f));
      this.tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.61417f));
      this.tableLayoutPanel5.Controls.Add((Control) this.label45, 0, 0);
      this.tableLayoutPanel5.Controls.Add((Control) this.label31, 0, 1);
      this.tableLayoutPanel5.Controls.Add((Control) this.mJiggies_tb, 1, 0);
      this.tableLayoutPanel5.Controls.Add((Control) this.label20, 0, 5);
      this.tableLayoutPanel5.Controls.Add((Control) this.hideNEH_cb, 1, 5);
      this.tableLayoutPanel5.Controls.Add((Control) this.extraH_tb, 1, 1);
      this.tableLayoutPanel5.Controls.Add((Control) this.label25, 0, 2);
      this.tableLayoutPanel5.Controls.Add((Control) this.hideJN_cb, 1, 4);
      this.tableLayoutPanel5.Controls.Add((Control) this.label23, 0, 4);
      this.tableLayoutPanel5.Controls.Add((Control) this.extraHS_tb, 1, 2);
      this.tableLayoutPanel5.Controls.Add((Control) this.specialLevel_cb, 1, 3);
      this.tableLayoutPanel5.Controls.Add((Control) this.label24, 0, 3);
      this.tableLayoutPanel5.Location = new Point(415, 0);
      this.tableLayoutPanel5.Margin = new Padding(0);
      this.tableLayoutPanel5.Name = "tableLayoutPanel5";
      this.tableLayoutPanel5.RowCount = 6;
      this.tableLayoutPanel5.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel5.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel5.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel5.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel5.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel5.RowStyles.Add(new RowStyle());
      this.tableLayoutPanel5.Size = new Size(417, 201);
      this.tableLayoutPanel5.TabIndex = 64;
      this.label45.AutoSize = true;
      this.label45.Location = new Point(4, 4);
      this.label45.Margin = new Padding(3);
      this.label45.Name = "label45";
      this.label45.Size = new Size(87, 13);
      this.label45.TabIndex = 36;
      this.label45.Text = "Jiggies Per Level";
      this.label31.AutoSize = true;
      this.label31.Location = new Point(4, 31);
      this.label31.Margin = new Padding(3);
      this.label31.Name = "label31";
      this.label31.Size = new Size(96, 13);
      this.label31.TabIndex = 26;
      this.label31.Text = "Empty Honeycomb";
      this.mJiggies_tb.Location = new Point(267, 4);
      this.mJiggies_tb.Name = "mJiggies_tb";
      this.mJiggies_tb.Size = new Size(104, 20);
      this.mJiggies_tb.TabIndex = 48;
      this.label20.AutoSize = true;
      this.label20.Location = new Point(4, 138);
      this.label20.Name = "label20";
      this.label20.Size = new Size(242, 13);
      this.label20.TabIndex = 60;
      this.label20.Text = "Level to hide Notes and Extra Honeycomb Pieces";
      this.hideNEH_cb.FormattingEnabled = true;
      this.hideNEH_cb.Location = new Point(267, 141);
      this.hideNEH_cb.Name = "hideNEH_cb";
      this.hideNEH_cb.Size = new Size(104, 21);
      this.hideNEH_cb.TabIndex = 61;
      this.extraH_tb.Location = new Point(267, 31);
      this.extraH_tb.Name = "extraH_tb";
      this.extraH_tb.Size = new Size(104, 20);
      this.extraH_tb.TabIndex = 51;
      this.label25.AutoSize = true;
      this.label25.Location = new Point(4, 55);
      this.label25.Name = "label25";
      this.label25.Size = new Size(178, 13);
      this.label25.TabIndex = 52;
      this.label25.Text = "Empty Honeycomb for Special Level";
      this.hideJN_cb.FormattingEnabled = true;
      this.hideJN_cb.Location = new Point(267, 113);
      this.hideJN_cb.Name = "hideJN_cb";
      this.hideJN_cb.Size = new Size(104, 21);
      this.hideJN_cb.TabIndex = 59;
      this.label23.AutoSize = true;
      this.label23.Location = new Point(4, 110);
      this.label23.Name = "label23";
      this.label23.Size = new Size(155, 13);
      this.label23.TabIndex = 56;
      this.label23.Text = "Level to hide Jiggies and Notes";
      this.extraHS_tb.Location = new Point(267, 58);
      this.extraHS_tb.Name = "extraHS_tb";
      this.extraHS_tb.Size = new Size(104, 20);
      this.extraHS_tb.TabIndex = 53;
      this.specialLevel_cb.FormattingEnabled = true;
      this.specialLevel_cb.Location = new Point(267, 85);
      this.specialLevel_cb.Name = "specialLevel_cb";
      this.specialLevel_cb.Size = new Size(104, 21);
      this.specialLevel_cb.TabIndex = 54;
      this.label24.AutoSize = true;
      this.label24.Location = new Point(4, 82);
      this.label24.Name = "label24";
      this.label24.Size = new Size(131, 13);
      this.label24.TabIndex = 55;
      this.label24.Text = "Honeycomb Special Level";
      this.tableLayoutPanel4.BackColor = Color.White;
      this.tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel4.ColumnCount = 2;
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.12448f));
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.87552f));
      this.tableLayoutPanel4.Controls.Add((Control) this.label38, 0, 5);
      this.tableLayoutPanel4.Controls.Add((Control) this.label39, 0, 4);
      this.tableLayoutPanel4.Controls.Add((Control) this.label40, 0, 3);
      this.tableLayoutPanel4.Controls.Add((Control) this.label41, 0, 2);
      this.tableLayoutPanel4.Controls.Add((Control) this.label42, 0, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.label43, 0, 0);
      this.tableLayoutPanel4.Controls.Add((Control) this.label44, 0, 6);
      this.tableLayoutPanel4.Controls.Add((Control) this.mEggs_tb, 1, 0);
      this.tableLayoutPanel4.Controls.Add((Control) this.mEggsCh_tb, 1, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.mFeathers_tb, 1, 2);
      this.tableLayoutPanel4.Controls.Add((Control) this.mGFeathersCh_tb, 1, 5);
      this.tableLayoutPanel4.Controls.Add((Control) this.mNotes_tb, 1, 6);
      this.tableLayoutPanel4.Controls.Add((Control) this.mGFeathers_tb, 1, 4);
      this.tableLayoutPanel4.Controls.Add((Control) this.mFeathersCh_tb, 1, 3);
      this.tableLayoutPanel4.Location = new Point(0, 0);
      this.tableLayoutPanel4.Margin = new Padding(0);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 7;
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 27f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 31f));
      this.tableLayoutPanel4.Size = new Size(415, 201);
      this.tableLayoutPanel4.TabIndex = 63;
      this.label38.AutoSize = true;
      this.label38.Location = new Point(4, 141);
      this.label38.Margin = new Padding(3);
      this.label38.Name = "label38";
      this.label38.Size = new Size(133, 13);
      this.label38.TabIndex = 29;
      this.label38.Text = "Max Gold Feathers Cheato";
      this.label39.AutoSize = true;
      this.label39.Location = new Point(4, 112);
      this.label39.Margin = new Padding(3);
      this.label39.Name = "label39";
      this.label39.Size = new Size(96, 13);
      this.label39.TabIndex = 28;
      this.label39.Text = "Max Gold Feathers";
      this.label40.AutoSize = true;
      this.label40.Location = new Point(4, 85);
      this.label40.Margin = new Padding(3);
      this.label40.Name = "label40";
      this.label40.Size = new Size(108, 13);
      this.label40.TabIndex = 27;
      this.label40.Text = "Max Feathers Cheato";
      this.label41.AutoSize = true;
      this.label41.Location = new Point(4, 58);
      this.label41.Margin = new Padding(3);
      this.label41.Name = "label41";
      this.label41.Size = new Size(71, 13);
      this.label41.TabIndex = 26;
      this.label41.Text = "Max Feathers";
      this.label42.AutoSize = true;
      this.label42.Location = new Point(4, 31);
      this.label42.Margin = new Padding(3);
      this.label42.Name = "label42";
      this.label42.Size = new Size(91, 13);
      this.label42.TabIndex = 25;
      this.label42.Text = "Max Eggs Cheato";
      this.label43.AutoSize = true;
      this.label43.Location = new Point(4, 4);
      this.label43.Margin = new Padding(3);
      this.label43.Name = "label43";
      this.label43.Size = new Size(57, 13);
      this.label43.TabIndex = 24;
      this.label43.Text = "Max Eggs:";
      this.label44.AutoSize = true;
      this.label44.Location = new Point(4, 169);
      this.label44.Margin = new Padding(3);
      this.label44.Name = "label44";
      this.label44.Size = new Size(58, 13);
      this.label44.TabIndex = 35;
      this.label44.Text = "Max Notes";
      this.mEggs_tb.Location = new Point(293, 4);
      this.mEggs_tb.Name = "mEggs_tb";
      this.mEggs_tb.Size = new Size(66, 20);
      this.mEggs_tb.TabIndex = 35;
      this.mEggsCh_tb.Location = new Point(293, 31);
      this.mEggsCh_tb.Name = "mEggsCh_tb";
      this.mEggsCh_tb.Size = new Size(66, 20);
      this.mEggsCh_tb.TabIndex = 36;
      this.mFeathers_tb.Location = new Point(293, 58);
      this.mFeathers_tb.Name = "mFeathers_tb";
      this.mFeathers_tb.Size = new Size(66, 20);
      this.mFeathers_tb.TabIndex = 39;
      this.mGFeathersCh_tb.Location = new Point(293, 141);
      this.mGFeathersCh_tb.Name = "mGFeathersCh_tb";
      this.mGFeathersCh_tb.Size = new Size(66, 20);
      this.mGFeathersCh_tb.TabIndex = 44;
      this.mNotes_tb.Location = new Point(293, 169);
      this.mNotes_tb.Name = "mNotes_tb";
      this.mNotes_tb.Size = new Size(66, 20);
      this.mNotes_tb.TabIndex = 46;
      this.mGFeathers_tb.Location = new Point(293, 112);
      this.mGFeathers_tb.Name = "mGFeathers_tb";
      this.mGFeathers_tb.Size = new Size(66, 20);
      this.mGFeathers_tb.TabIndex = 43;
      this.mFeathersCh_tb.Location = new Point(293, 85);
      this.mFeathersCh_tb.Name = "mFeathersCh_tb";
      this.mFeathersCh_tb.Size = new Size(66, 20);
      this.mFeathersCh_tb.TabIndex = 40;
      this.tabPage5.BackColor = SystemColors.ActiveBorder;
      this.tabPage5.Controls.Add((Control) this.tableLayoutPanel10);
      this.tabPage5.Controls.Add((Control) this.updateNames_btn);
      this.tabPage5.Location = new Point(4, 22);
      this.tabPage5.Name = "tabPage5";
      this.tabPage5.Padding = new Padding(3);
      this.tabPage5.Size = new Size(835, 474);
      this.tabPage5.TabIndex = 4;
      this.tabPage5.Text = "Level Names";
      this.tabPage5.UseVisualStyleBackColor = true;
      this.tableLayoutPanel10.BackColor = Color.White;
      this.tableLayoutPanel10.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel10.ColumnCount = 2;
      this.tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel10.Controls.Add((Control) this.tb10, 1, 9);
      this.tableLayoutPanel10.Controls.Add((Control) this.label26, 0, 8);
      this.tableLayoutPanel10.Controls.Add((Control) this.label27, 0, 7);
      this.tableLayoutPanel10.Controls.Add((Control) this.label28, 0, 6);
      this.tableLayoutPanel10.Controls.Add((Control) this.label36, 0, 5);
      this.tableLayoutPanel10.Controls.Add((Control) this.label37, 0, 4);
      this.tableLayoutPanel10.Controls.Add((Control) this.label46, 0, 3);
      this.tableLayoutPanel10.Controls.Add((Control) this.lbl3, 0, 2);
      this.tableLayoutPanel10.Controls.Add((Control) this.lbl2, 0, 1);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb4, 1, 3);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb3, 1, 2);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb2, 1, 1);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb1, 1, 0);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb5, 1, 4);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb6, 1, 5);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb7, 1, 6);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb8, 1, 7);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb9, 1, 8);
      this.tableLayoutPanel10.Controls.Add((Control) this.lbl1, 0, 0);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb11, 1, 10);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb12, 1, 11);
      this.tableLayoutPanel10.Controls.Add((Control) this.label47, 0, 9);
      this.tableLayoutPanel10.Controls.Add((Control) this.label48, 0, 10);
      this.tableLayoutPanel10.Controls.Add((Control) this.label49, 0, 11);
      this.tableLayoutPanel10.Controls.Add((Control) this.tb13, 1, 12);
      this.tableLayoutPanel10.Controls.Add((Control) this.lbl13, 0, 12);
      this.tableLayoutPanel10.Location = new Point(0, 0);
      this.tableLayoutPanel10.Margin = new Padding(0);
      this.tableLayoutPanel10.Name = "tableLayoutPanel10";
      this.tableLayoutPanel10.RowCount = 13;
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel10.Size = new Size(835, 272);
      this.tableLayoutPanel10.TabIndex = 15;
      this.tb10.BorderStyle = BorderStyle.None;
      this.tb10.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb10.Location = new Point(421, 193);
      this.tb10.Name = "tb10";
      this.tb10.Size = new Size(181, 14);
      this.tb10.TabIndex = 10;
      this.label26.AutoSize = true;
      this.label26.Location = new Point(4, 172);
      this.label26.Margin = new Padding(3);
      this.label26.Name = "label26";
      this.label26.Size = new Size(85, 13);
      this.label26.TabIndex = 29;
      this.label26.Text = "GOBI'S VALLEY";
      this.label27.AutoSize = true;
      this.label27.Location = new Point(4, 151);
      this.label27.Margin = new Padding(3);
      this.label27.Name = "label27";
      this.label27.Size = new Size(101, 13);
      this.label27.TabIndex = 28;
      this.label27.Text = "FREEZEEZY PEAK";
      this.label28.AutoSize = true;
      this.label28.Location = new Point(4, 130);
      this.label28.Margin = new Padding(3);
      this.label28.Name = "label28";
      this.label28.Size = new Size(130, 13);
      this.label28.TabIndex = 27;
      this.label28.Text = "BUBBLEGLOOP SWAMP";
      this.label36.AutoSize = true;
      this.label36.Location = new Point(4, 109);
      this.label36.Margin = new Padding(3);
      this.label36.Name = "label36";
      this.label36.Size = new Size(113, 13);
      this.label36.TabIndex = 26;
      this.label36.Text = "CLANKER'S CAVERN";
      this.label37.AutoSize = true;
      this.label37.Location = new Point(4, 88);
      this.label37.Margin = new Padding(3);
      this.label37.Name = "label37";
      this.label37.Size = new Size(138, 13);
      this.label37.TabIndex = 25;
      this.label37.Text = "TREASURE TROVE COVE";
      this.label46.AutoSize = true;
      this.label46.Location = new Point(4, 67);
      this.label46.Margin = new Padding(3);
      this.label46.Name = "label46";
      this.label46.Size = new Size(118, 13);
      this.label46.TabIndex = 24;
      this.label46.Text = "MUMBO'S MOUNTAIN";
      this.lbl3.AutoSize = true;
      this.lbl3.Location = new Point(4, 46);
      this.lbl3.Margin = new Padding(3);
      this.lbl3.Name = "lbl3";
      this.lbl3.Size = new Size(106, 13);
      this.lbl3.TabIndex = 23;
      this.lbl3.Text = "GRUNTILDA'S LAIR";
      this.lbl2.AutoSize = true;
      this.lbl2.Location = new Point(4, 25);
      this.lbl2.Margin = new Padding(3);
      this.lbl2.Name = "lbl2";
      this.lbl2.Size = new Size(106, 13);
      this.lbl2.TabIndex = 22;
      this.lbl2.Text = "SPIRAL MOUNTAIN";
      this.tb4.BorderStyle = BorderStyle.None;
      this.tb4.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb4.Location = new Point(421, 67);
      this.tb4.Name = "tb4";
      this.tb4.Size = new Size(181, 14);
      this.tb4.TabIndex = 4;
      this.tb3.BorderStyle = BorderStyle.None;
      this.tb3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb3.Location = new Point(421, 46);
      this.tb3.Name = "tb3";
      this.tb3.Size = new Size(181, 14);
      this.tb3.TabIndex = 3;
      this.tb2.BorderStyle = BorderStyle.None;
      this.tb2.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb2.Location = new Point(421, 25);
      this.tb2.Name = "tb2";
      this.tb2.Size = new Size(181, 14);
      this.tb2.TabIndex = 2;
      this.tb1.BorderStyle = BorderStyle.None;
      this.tb1.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb1.Location = new Point(421, 4);
      this.tb1.Name = "tb1";
      this.tb1.Size = new Size(181, 14);
      this.tb1.TabIndex = 1;
      this.tb5.BorderStyle = BorderStyle.None;
      this.tb5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb5.Location = new Point(421, 88);
      this.tb5.Name = "tb5";
      this.tb5.Size = new Size(181, 14);
      this.tb5.TabIndex = 5;
      this.tb6.BorderStyle = BorderStyle.None;
      this.tb6.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb6.Location = new Point(421, 109);
      this.tb6.Name = "tb6";
      this.tb6.Size = new Size(181, 14);
      this.tb6.TabIndex = 6;
      this.tb7.BorderStyle = BorderStyle.None;
      this.tb7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb7.Location = new Point(421, 130);
      this.tb7.Name = "tb7";
      this.tb7.Size = new Size(181, 14);
      this.tb7.TabIndex = 7;
      this.tb8.BorderStyle = BorderStyle.None;
      this.tb8.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb8.Location = new Point(421, 151);
      this.tb8.Name = "tb8";
      this.tb8.Size = new Size(181, 14);
      this.tb8.TabIndex = 8;
      this.tb9.BorderStyle = BorderStyle.None;
      this.tb9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb9.Location = new Point(421, 172);
      this.tb9.Name = "tb9";
      this.tb9.Size = new Size(181, 14);
      this.tb9.TabIndex = 9;
      this.lbl1.AutoSize = true;
      this.lbl1.Location = new Point(4, 4);
      this.lbl1.Margin = new Padding(3);
      this.lbl1.Name = "lbl1";
      this.lbl1.Size = new Size(76, 13);
      this.lbl1.TabIndex = 21;
      this.lbl1.Text = "GAME TOTAL";
      this.tb11.BorderStyle = BorderStyle.None;
      this.tb11.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb11.Location = new Point(421, 214);
      this.tb11.Name = "tb11";
      this.tb11.Size = new Size(181, 14);
      this.tb11.TabIndex = 11;
      this.tb12.BorderStyle = BorderStyle.None;
      this.tb12.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb12.Location = new Point(421, 235);
      this.tb12.Name = "tb12";
      this.tb12.Size = new Size(181, 14);
      this.tb12.TabIndex = 12;
      this.label47.AutoSize = true;
      this.label47.Location = new Point(4, 193);
      this.label47.Margin = new Padding(3);
      this.label47.Name = "label47";
      this.label47.Size = new Size(141, 13);
      this.label47.TabIndex = 35;
      this.label47.Text = "MAD MONSTER MANSION";
      this.label48.AutoSize = true;
      this.label48.Location = new Point(4, 214);
      this.label48.Margin = new Padding(3);
      this.label48.Name = "label48";
      this.label48.Size = new Size(114, 13);
      this.label48.TabIndex = 36;
      this.label48.Text = "RUSTY BUCKET BAY";
      this.label49.AutoSize = true;
      this.label49.Location = new Point(4, 235);
      this.label49.Margin = new Padding(3);
      this.label49.Name = "label49";
      this.label49.Size = new Size(113, 13);
      this.label49.TabIndex = 37;
      this.label49.Text = "CLICK CLOCK WOOD";
      this.tb13.BorderStyle = BorderStyle.None;
      this.tb13.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.tb13.Location = new Point(421, 256);
      this.tb13.Name = "tb13";
      this.tb13.Size = new Size(181, 14);
      this.tb13.TabIndex = 13;
      this.lbl13.AutoSize = true;
      this.lbl13.Location = new Point(4, 256);
      this.lbl13.Margin = new Padding(3);
      this.lbl13.Name = "lbl13";
      this.lbl13.Size = new Size(87, 13);
      this.lbl13.TabIndex = 38;
      this.lbl13.Text = "STOP 'N' SWOP";
      this.updateNames_btn.Location = new Point(745, 451);
      this.updateNames_btn.Name = "updateNames_btn";
      this.updateNames_btn.Size = new Size(90, 23);
      this.updateNames_btn.TabIndex = 16;
      this.updateNames_btn.Text = "Update";
      this.updateNames_btn.UseVisualStyleBackColor = true;
      this.updateNames_btn.Click += new EventHandler(this.updateNames_btn_Click);
      this.tabPage7.BackColor = SystemColors.ActiveBorder;
      this.tabPage7.Controls.Add((Control) this.startLevel_dgv);
      this.tabPage7.Controls.Add((Control) this.startLevelUpdate_btn);
      this.tabPage7.Location = new Point(4, 22);
      this.tabPage7.Name = "tabPage7";
      this.tabPage7.Padding = new Padding(3);
      this.tabPage7.Size = new Size(835, 474);
      this.tabPage7.TabIndex = 6;
      this.tabPage7.Text = "Start Level";
      this.tabPage7.UseVisualStyleBackColor = true;
      this.startLevel_dgv.AllowUserToAddRows = false;
      this.startLevel_dgv.AllowUserToDeleteRows = false;
      this.startLevel_dgv.AllowUserToResizeRows = false;
      this.startLevel_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      this.startLevel_dgv.BorderStyle = BorderStyle.None;
      this.startLevel_dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
      this.startLevel_dgv.ColumnHeadersHeight = 20;
      this.startLevel_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.startLevel_dgv.Cursor = Cursors.Default;
      this.startLevel_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.startLevel_dgv.Location = new Point(5, 4);
      this.startLevel_dgv.MultiSelect = false;
      this.startLevel_dgv.Name = "startLevel_dgv";
      this.startLevel_dgv.ReadOnly = true;
      this.startLevel_dgv.RowHeadersVisible = false;
      this.startLevel_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.startLevel_dgv.ShowCellErrors = false;
      this.startLevel_dgv.ShowCellToolTips = false;
      this.startLevel_dgv.ShowEditingIcon = false;
      this.startLevel_dgv.ShowRowErrors = false;
      this.startLevel_dgv.Size = new Size(824, 442);
      this.startLevel_dgv.TabIndex = 11;
      this.startLevelUpdate_btn.Location = new Point(745, 451);
      this.startLevelUpdate_btn.Name = "startLevelUpdate_btn";
      this.startLevelUpdate_btn.Size = new Size(90, 23);
      this.startLevelUpdate_btn.TabIndex = 10;
      this.startLevelUpdate_btn.Text = "Update";
      this.startLevelUpdate_btn.UseVisualStyleBackColor = true;
      this.startLevelUpdate_btn.Click += new EventHandler(this.startLevelUpdate_btn_Click);
      this.tabControl1.Controls.Add((Control) this.tabPage7);
      this.tabControl1.Controls.Add((Control) this.tabPage5);
      this.tabControl1.Controls.Add((Control) this.tabPage6);
      this.tabControl1.Controls.Add((Control) this.tabPage8);
      this.tabControl1.Controls.Add((Control) this.tabPage9);
      this.tabControl1.Controls.Add((Control) this.tabPage10);
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Location = new Point(12, 5);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(843, 500);
      this.tabControl1.TabIndex = 69;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(868, 517);
      this.Controls.Add((Control) this.tabControl1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "GeneralSettings";
      this.ShowIcon = false;
      this.Text = "General Settings";
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.tabPage10.ResumeLayout(false);
      this.tabPage10.PerformLayout();
      this.tabPage9.ResumeLayout(false);
      ((ISupportInitialize) this.skymap_gv).EndInit();
      this.tabPage8.ResumeLayout(false);
      ((ISupportInitialize) this.map_gv).EndInit();
      this.tabPage6.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.tableLayoutPanel6.ResumeLayout(false);
      this.tableLayoutPanel6.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.tableLayoutPanel7.ResumeLayout(false);
      this.tableLayoutPanel7.PerformLayout();
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.panel4.ResumeLayout(false);
      this.tableLayoutPanel8.ResumeLayout(false);
      this.tableLayoutPanel8.PerformLayout();
      this.tableLayoutPanel9.ResumeLayout(false);
      this.tableLayoutPanel9.PerformLayout();
      this.tabPage1.ResumeLayout(false);
      this.tableLayoutPanel5.ResumeLayout(false);
      this.tableLayoutPanel5.PerformLayout();
      this.tableLayoutPanel4.ResumeLayout(false);
      this.tableLayoutPanel4.PerformLayout();
      this.tabPage5.ResumeLayout(false);
      this.tableLayoutPanel10.ResumeLayout(false);
      this.tableLayoutPanel10.PerformLayout();
      this.tabPage7.ResumeLayout(false);
      ((ISupportInitialize) this.startLevel_dgv).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
