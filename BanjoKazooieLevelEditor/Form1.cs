// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Form1
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using BKGlobalize;
using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Tao.OpenGl;

namespace BanjoKazooieLevelEditor
{
  public class Form1 : Form
  {
    private bool enableDebug;
    private bool processControllerEvents;
    private Color active = SystemColors.ControlDarkDark;
    private Color inactive = SystemColors.ActiveBorder;
    private RomBuilder romBuild = new RomBuilder();
    private bool includeTriggers = true;
    private List<LevelEntryPoint> entryPoints = new List<LevelEntryPoint>();
    private List<LevelEntryPoint> levelEntries = new List<LevelEntryPoint>();
    private List<TextFile> files = new List<TextFile>();
    private bool unlockedEditSettings;
    private List<int> usedJiggyFlags = new List<int>();
    private bool multiselect;
    private bool showStats = true;
    private GECompression ge = new GECompression();
    private bool drawLevelBoundary;
    private bool hideUnknownBytes = true;
    private string inRom = "";
    private int jiggyCount;
    private int honeyCombCount;
    private int mumboTokenCount;
    private int jiggyOffset;
    private int honeyCombOffset;
    private int mumboTokenOffset;
    private byte[] rom;
    private string path = Application.StartupPath;
    public string tmpDir = Application.StartupPath + "\\tmp\\";
    private OpenSetFileForm osff = new OpenSetFileForm();
    private SetupFile selectedFile;
    private SetupFileWritter sfw = new SetupFileWritter();
    private List<WrittenFile> writtenFiles = new List<WrittenFile>();
    private World world = new World();
    private string setupfile = "";
    private string outDir = Application.StartupPath + "\\out\\";
    private string outTxtDir = Application.StartupPath + "\\text\\out\\";
    private List<SetupFile> sfl = new List<SetupFile>();
    private LevelStat ls = new LevelStat(0, 0, 0, 0, 0, 0, 0);
    private ObjectData flagFound;
    private int listDec;
    private int newStart;
    private bool zoomIn;
    private bool zoomOut;
    private bool left;
    private bool right;
    private GLCamera BBCamera = new GLCamera();
    private int newMouseX;
    private int newMouseY;
    private int oldMouseX;
    private int oldMouseY;
    private bool sceneClick;
    private bool RotateSceneClick;
    private bool forceRedraw = true;
    public string replacedModel = "";
    public string replacedModelEx = "";
    private bool rectSelectMode;
    private bool rectSelect;
    private Point startPoint = Point.Empty;
    private Rectangle frameRect = Rectangle.Empty;
    private bool selectMode = true;
    private bool createMode;
    private bool cameraMode;
    private bool selectPathMode;
    private bool createPathMode;
    private bool nodeMoveMode;
    private bool moveMode;
    private bool scaleMode;
    private bool rotateMode;
    private bool duplicateMode;
    private bool camMoveMode;
    private bool yawMode;
    private bool pitchMode;
    private bool rollMode;
    private bool movingObj;
    private bool scalingObj;
    private bool rotatingObj;
    private bool movingNode;
    private bool duplicatingObj;
    private bool xToggle = true;
    private bool yToggle = true;
    private bool zToggle = true;
    private bool camXToggle = true;
    private bool camYToggle = true;
    private bool camZToggle = true;
    private int createPointX;
    private int createPointY;
    private int newEditX;
    private int newEditY;
    private int oldEditX;
    private int oldEditY;
    private bool running = true;
    private bool allObjsErased;
    private int DA2724_location;
    private int E4D7FE_location;
    private int F19250_location;
    private int F361E3_location;
    private int F37F90_location;
    private int F9CAE0_location;
    private int FA3FD0_location;
    private int FA5D96_location;
    private int FA5F50_location;
    private int FA8CE6_location;
    private int FA9150_location;
    private int FAE27E_location;
    private int FAE860_location;
    private int FB1AEB_location;
    private int FB24A0_location;
    private int FB42D9_location;
    private int FB44E0_location;
    private int FB9610_location;
    private int FB9A30_location;
    private int FBE5E2_location;
    private int FBEBE0_location;
    private int FC3FEF_location;
    private int FC4810_location;
    private int FC6C0F_location;
    private int FC6F20_location;
    private int FC8AFC_location;
    private int FC9150_location;
    private int FCF150_location;
    private int FCF698_location;
    private int FD0420_location;
    private int FD5A60_location;
    private int FD6190_location;
    private int FDA2FF_location;
    private int FDAA10_location;
    private int FDAA30_location;
    private List<byte> F9CAE0 = new List<byte>();
    private List<byte> F37F90 = new List<byte>();
    private byte[] globalizedFCF698;
    private int globalizedFCF698Location = 66440624;
    private SetupFileReader sfr = new SetupFileReader();
    private List<AnimationFile> everyAnimation = new List<AnimationFile>();
    private bool loaded;
    private IContainer components;
    private OpenFileDialog SetupFileOpenDialog;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private FolderBrowserDialog folderBrowserDialog1;
    private ToolStripMenuItem save_tsmi;
    private ToolStripMenuItem openSetupFileToolStripMenuItem;
    private ImageList objectImages_il;
    private GroupBox textUpdate_gb;
    private TextBox updateScript_tb;
    private TextBox updateRot_tb;
    private TextBox updateSize_tb;
    private TextBox updateZ_tb;
    private TextBox updateY_tb;
    private TextBox updateX_tb;
    private TextBox updateName_tb;
    private Label script_lbl;
    private Label rotByte_lbl;
    private Label size_lbl;
    private Label label17;
    private Label label18;
    private Label label19;
    private Label label22;
    private Button changeLM_btn;
    private OpenFileDialog changeLM_ofd;
    private ContextMenuStrip objectMenu;
    internal TrackBar CamSpeed_tb;
    private System.Windows.Forms.Timer timer1;
    private Label label2;
    private TextBox baseLevel_tb;
    private TextBox extraModel_tb;
    private Label label3;
    private Button replaceModelEx_btn;
    private Button replaceModel_btn;
    private Label label4;
    private GroupBox replacemodel_gb;
    private Button clear_btn;
    private Label id_lbl;
    private ToolStripMenuItem openRomToolStripMenuItem;
    private OpenFileDialog openFileDialog1;
    private OpenFileDialog openFileDialog2;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem importObjToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private Button warp_btn;
    private TextBox warpTo_tb;
    private Label warpTo_lbl;
    private SaveFileDialog saveFileDialog;
    private TextBox id_tb;
    private Label label1;
    private Label address_lbl;
    private Label objID_lbl;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private OpenFileDialog replaceSetup_ofd;
    private ToolStripMenuItem saveSetupFileToolStripMenuItem;
    private SaveFileDialog saveSetupFileDialog;
    private ToolStripMenuItem loadSetupFileToolStripMenuItem;
    private OpenFileDialog openSetupFileDialog;
    private ToolStripMenuItem textEditorToolStripMenuItem;
    private ToolStripMenuItem saveAsRomToolStripMenuItem;
    private SaveFileDialog saveAsRomFileDialog;
    private ToolStripMenuItem injectorInToolStripMenuItem;
    private TextBox updateB13_tb;
    private TextBox updateB18_tb;
    private TextBox updateB11_tb;
    private TextBox updateB10_tb;
    private Label b11_lbl;
    private Label b10_lbl;
    private Label b13_lbl;
    private Label b18_lbl;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripMenuItem knowAllMovesToolStripMenuItem;
    private ToolStripMenuItem haveNoMovesToolStripMenuItem;
    private FlowLayoutPanel flowLayoutPanel1;
    private Button col_obj_details_btn;
    private TableLayoutPanel tableLayoutPanel3;
    private TableLayoutPanel tableLayoutPanel4;
    private Button col_replacemodel_btn;
    private Button col_levelbounds_btn;
    private GroupBox bounds_gb;
    private TableLayoutPanel tableLayoutPanel8;
    private Label label21;
    private Label label23;
    private Label label24;
    private TextBox minZ_Bounds_tb;
    private TextBox minY_Bounds_tb;
    private TextBox minX_Bounds_tb;
    private Label label28;
    private TableLayoutPanel tableLayoutPanel6;
    private Label label6;
    private Label label7;
    private GroupBox groupBox1;
    private TableLayoutPanel tableLayoutPanel7;
    private Label label8;
    private Label label20;
    private Label label25;
    private Label label26;
    private Label label27;
    private TextBox maxX_Bounds_tb;
    private TextBox maxY_Bounds_tb;
    private TextBox maxZ_Bounds_tb;
    private Button updateBounds_btn;
    private Label label29;
    private Button col_levelentries_btn;
    private GroupBox levelEntries_gb;
    private Button button1;
    private GroupBox groupBox2;
    private Label label30;
    private Button button2;
    private TableLayoutPanel tableLayoutPanel9;
    private Label label31;
    private Label label32;
    private DataGridView levelEntries_dgv;
    private TextBox flag_tb;
    private Label flag_lbl;
    private GroupBox cam3_gb;
    private TableLayoutPanel tableLayoutPanel10;
    private Label label33;
    private Label label34;
    private TextBox camRoll_tb;
    private Label label35;
    private TextBox camYaw_tb;
    private Label label36;
    private TextBox camPitch_tb;
    private Label label37;
    private TextBox camZ_tb;
    private Label label38;
    private TextBox camY_tb;
    private TextBox camX_tb;
    private Label label39;
    private TextBox camID_tb;
    private Label label40;
    private Label label43;
    private Label label44;
    private TextBox camHSpeed_tb;
    private TextBox camVSpeed_tb;
    private TableLayoutPanel tableLayoutPanel11;
    private Label label41;
    private Label label42;
    private Label label45;
    private Label label46;
    private TextBox camRotation_tb;
    private TextBox camAccel_tb;
    private Label label47;
    private Label label48;
    private Label label49;
    private TextBox cam3A5_tb;
    private TextBox camCDist_tb;
    private TextBox camFDist_tb;
    private ContextMenuStrip cameraMenu;
    private ToolStripMenuItem createCameraToolStripMenuItem;
    private Button col_objects_btn;
    private GroupBox objects_gb;
    private DataGridView objects_dgv;
    private ToolStripMenuItem includeCameraTriggersWhenSavingToolStripMenuItem;
    private ToolStripMenuItem createGameplayCameraToolStripMenuItem;
    private ToolStripMenuItem sNSEditorToolStripMenuItem;
    private ToolStripMenuItem puzzleEditorToolStripMenuItem;
    private TextBox updateRad_tb;
    private Label rad_lbl;
    private ToolStripMenuItem createGameplayTiggerToolStripMenuItem;
    private ToolStripMenuItem removeNumbersFromNotedoorToolStripMenuItem;
    private ToolStripMenuItem saveAsRomskillToolStripMenuItem;
    private OpenFileDialog injectDialog;
    private Button col_structs_btn;
    private GroupBox structs_gb;
    private DataGridView structs_dgv;
    private Button col_selPath_btn;
    private GroupBox path_gb;
    private DataGridView path_dgv;
    private TableLayoutPanel tableLayoutPanel14;
    private Label label52;
    private TextBox textBox1;
    private TableLayoutPanel nodeProperties_lp;
    private TextBox nodeZ_tb;
    private Label label53;
    private TextBox nodeX_tb;
    private Label label54;
    private Label label55;
    private TextBox nodeY_tb;
    private TextBox node18_tb;
    private GroupBox pathObject_gb;
    private TableLayoutPanel tableLayoutPanel16;
    private Label label60;
    private TextBox objectNode_tb;
    private TableLayoutPanel tableLayoutPanel15;
    private TextBox textBox2;
    private Label label56;
    private TextBox textBox3;
    private GroupBox groupBox3;
    private TextBox sNodeSpeed_tb;
    private Label label61;
    private TextBox sNodeF_tb;
    private Label label62;
    private Label label63;
    private TextBox sNodeW1_tb;
    private TextBox sNodeUNK3_tb;
    private Label label67;
    private TextBox updateB17_tb;
    private TextBox updateB16_tb;
    private Label b16_lbl;
    private Label b17_lbl;
    private Label animation_lbl;
    private ComboBox animation_cb;
    private TableLayoutPanel tableLayoutPanel13;
    private Label label69;
    private TextBox nodeID_tb;
    private Label label70;
    private TextBox pauseTime_tb;
    private Label label57;
    private ToolTip toolTip1;
    private ToolStrip toolStrip1;
    private ToolStripLabel mode_lbl;
    private ToolStripComboBox mode_cb;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton obj_move_btn;
    private ToolStripButton obj_rot_btn;
    private ToolStripButton obj_scale_btn;
    private ToolStripButton obj_duplicate_btn;
    private ToolStripButton deselect_btn;
    private ToolStripButton delete_btn;
    private ToolStripButton cam_pitch_btn;
    private ToolStripButton cam_yaw_btn;
    private ToolStripButton cam_roll_btn;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripButton eraseAll_btn;
    private Button button3;
    private CheckBox bgA_cb;
    private CheckBox bgB_btn;
    private CheckBox objs_cb;
    private Label label51;
    private Label label59;
    private Label label64;
    private Label label65;
    private CheckBox cameras_cb;
    private ToolStripButton lockZ_btn;
    private ToolStripButton lockY_btn;
    private ToolStripButton lockX_btn;
    private ToolStripLabel toolStripLabel2;
    private ToolStripTextBox yOffset_tb;
    private Panel nodeProperties_gb;
    private Button button4;
    private Panel sNode_gb;
    private Button button5;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private Panel nodeID_gb;
    private Button button6;
    private CheckBox levelStats_cb;
    private Label label14;
    private FlowLayoutPanel flowLayoutPanel2;
    private ToolStripButton assignObject_btn;
    private ToolStripButton moveNode_btn;
    private ToolStripButton linkMode_btn;
    private ToolStripButton removeNode_btn;
    private ToolStripButton deletePath_btn;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton rectSelect_btn;
    private ToolStripMenuItem hideUnknownBytesToolStripMenuItem;
    private Label label58;
    private Label label66;
    private CheckBox levelBound_cb;
    private CheckBox camTrigger_cb;
    private Label label71;
    private CheckBox warpRadius_cb;
    private CheckBox showFlagRadius_cb;
    private Label label72;
    private Label flagRadius_cb;
    private CheckBox enemyRadius_cb;
    private CheckBox unknownRadius_cb;
    private Label label75;
    private ToolStripButton endNode_btn;
    private Button col_cam_btn;
    private ToolStripButton startNewPath_btn;
    private ToolStripButton addNode_btn;
    private ToolStripButton addControllerNode_btn;
    private ToolStripButton deselectPath_btn;
    private ToolStripMenuItem midiToolToolStripMenuItem;
    private ToolStripMenuItem modelEditorToolStripMenuItem;
    private CheckBox levelBoundAlpha_cb;
    private Label label5;
    private TextBox pathID_tb;
    private Label label9;
    private CheckBox useAnimation_cb;
    private CheckBox useSpeed_cb;
    private CheckBox usePause_cb;
    private Panel panel1;
    private Panel panel2;
    private Panel panel3;
    private DataGridView pathControllers_dgv;
    private Label label11;
    private Label label10;
    private CheckBox cc_failsafe_cb;
    private Label failsafe_lbl;
    private ToolStripMenuItem editToolStripMenuItem;
    private ToolStripMenuItem undoToolStripMenuItem;
    private ToolStripMenuItem redoToolStripMenuItem;
    private ToolStripMenuItem historyToolStripMenuItem;
    private TextBox drawDist_tb;
    private Label label12;
    private GLControl LevelViewer;
    private ToolStripButton cam_moveToCurrent_btn;
    private ToolStripMenuItem spriteManagerToolStripMenuItem;

    private void initializeMenu()
    {
      try
      {
        XmlTextReader xmlTextReader = new XmlTextReader(".\\resources\\menu.xml");
        ToolStripMenuItem toolStripMenuItem1 = new ToolStripMenuItem();
        List<ToolStripMenuItem> toolStripMenuItemList = new List<ToolStripMenuItem>();
        ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
        List<int> intList = new List<int>();
        bool flag = false;
        int num1 = 0;
        int index = -1;
        int num2 = -1;
        while (xmlTextReader.Read())
        {
          string name = xmlTextReader.Name;
          if (xmlTextReader.NodeType == XmlNodeType.EndElement)
          {
            if (!(name == "submenu"))
            {
              if (name == "menu")
              {
                this.objectMenu.Items.Add((ToolStripItem) toolStripMenuItem1);
                intList.Clear();
                toolStripMenuItemList.Clear();
              }
            }
            else
            {
              if (num1 > 1)
              {
                toolStripMenuItemList[index - 1].DropDownItems.Add((ToolStripItem) toolStripMenuItemList[index]);
                toolStripMenuItemList.RemoveAt(index);
                --index;
              }
              --num1;
              if (num1 == 0)
              {
                flag = false;
                toolStripMenuItem1.DropDownItems.Add((ToolStripItem) toolStripMenuItemList[index]);
              }
            }
          }
          if (xmlTextReader.NodeType != XmlNodeType.EndElement)
          {
            if (!(name == "menu"))
            {
              if (!(name == "submenu"))
              {
                if (name == "menuitem")
                {
                  ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem();
                  toolStripMenuItem3.Name = xmlTextReader.GetAttribute("name").Replace(" ", "").Replace("'", "");
                  toolStripMenuItem3.Size = new Size(216, 22);
                  toolStripMenuItem3.Text = xmlTextReader.GetAttribute("name");
                  toolStripMenuItem3.Tag = xmlTextReader.GetAttribute("type") == null ? (object) "" : (object) xmlTextReader.GetAttribute("type");
                  toolStripMenuItem3.Click += new EventHandler(this.createItem_MouseClick);
                  if (index != -1 & flag)
                  {
                    toolStripMenuItemList[index].DropDownItems.Add((ToolStripItem) toolStripMenuItem3);
                  }
                  else
                  {
                    toolStripMenuItem1.DropDownItems.Add((ToolStripItem) toolStripMenuItem3);
                    ++num2;
                  }
                }
              }
              else
              {
                ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem();
                toolStripMenuItem4.Name = xmlTextReader.GetAttribute("name").Replace(" ", "").Replace("'", "");
                toolStripMenuItem4.Size = new Size(216, 22);
                toolStripMenuItem4.Text = xmlTextReader.GetAttribute("name");
                ++index;
                toolStripMenuItemList.Add(toolStripMenuItem4);
                if (!flag || num1 == 0)
                {
                  intList.Add(num2);
                  ++num2;
                }
                flag = true;
                ++num1;
              }
            }
            else
            {
              toolStripMenuItem1 = new ToolStripMenuItem();
              toolStripMenuItem1.Name = xmlTextReader.GetAttribute("name").Replace(" ", "").Replace("'", "");
              toolStripMenuItem1.Tag = (object) xmlTextReader.GetAttribute("name");
              toolStripMenuItem1.Text = xmlTextReader.GetAttribute("name");
              toolStripMenuItem1.Size = new Size(216, 22);
              num2 = 0;
              index = -1;
            }
          }
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Failed to load menu");
      }
    }

    public Form1()
    {
      RomHandler.tmpDir = this.tmpDir;
      Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
      this.InitializeComponent();
      if (!File.Exists(this.outDir + "rn64crc.exe"))
      {
        int num = (int) MessageBox.Show("Error: rn64crc NOT FOUND! " + Environment.NewLine + "You need to download rn64crc.exe and put it in ./out/ BB will now close");
        this.Close();
      }
      if (!File.Exists(this.outDir + "gzip.exe"))
      {
        int num = (int) MessageBox.Show("Error: gzip NOT FOUND! " + Environment.NewLine + "You need to download gzip.exe and put it in ./out/ BB will now close");
        this.Close();
      }
      this.initializeMenu();
      this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      this.BBCamera.MovementSpeed = (float) (this.CamSpeed_tb.Value * 2);
      this.readINI();
      this.ReadSetupsXML();
      this.readAnimationsXML();
      if (!(this.inRom != ""))
        return;
      this.locateEORFiles();
      byte[] f = this.arrayCopy(this.F9CAE0_location, 1048576);
      GECompression ge1 = this.ge;
      byte[] Buffer1 = f;
      int length1 = Buffer1.Length;
      ge1.SetCompressedBuffer(Buffer1, length1);
      int compressedSize = 0;
      int fileSize1 = 0;
      this.F9CAE0 = ((IEnumerable<byte>) this.ge.OutputDecompressedBuffer(ref fileSize1, ref compressedSize)).ToList<byte>();
      this.arrayCopy(f, this.F37F90_location, 1048576);
      GECompression ge2 = this.ge;
      byte[] Buffer2 = f;
      int length2 = Buffer2.Length;
      ge2.SetCompressedBuffer(Buffer2, length2);
      compressedSize = 0;
      int fileSize2 = 0;
      this.F37F90 = ((IEnumerable<byte>) this.ge.OutputDecompressedBuffer(ref fileSize2, ref compressedSize)).ToList<byte>();
      this.globalizedFCF698 = new byte[9888];
      this.arrayCopy(this.globalizedFCF698, this.globalizedFCF698Location, 9888);
      this.world.getRomStats(this.F9CAE0);
      this.getEntryPoints();
      this.AssociateScenesWithLevels();
    }

    private void Form1_Load(object sender, EventArgs e) => this.mode_cb.SelectedIndex = 0;

    private int getLevelID(int map)
    {
      for (int index = 33412; index < 34451; index += 8)
      {
        int num1 = (int) this.F9CAE0[index + 4] * 256 + (int) this.F9CAE0[index + 5];
        int levelId = (int) this.F9CAE0[index + 6] * 256 + (int) this.F9CAE0[index + 7];
        int num2 = map;
        if (num1 == num2)
          return levelId;
      }
      return 0;
    }

    public int getNextPointer(int pntr_)
    {
      int num = (int) this.rom[pntr_] * 16777216 + (int) this.rom[pntr_ + 1] * 65536 + (int) this.rom[pntr_ + 2] * 256 + (int) this.rom[pntr_ + 3];
      int nextPointer = (int) this.rom[pntr_ + 8] * 16777216 + (int) this.rom[pntr_ + 1 + 8] * 65536 + (int) this.rom[pntr_ + 2 + 8] * 256 + (int) this.rom[pntr_ + 3 + 8];
      while (num - nextPointer == 0)
      {
        nextPointer = (int) this.rom[pntr_ + 8] * 16777216 + (int) this.rom[pntr_ + 1 + 8] * 65536 + (int) this.rom[pntr_ + 2 + 8] * 256 + (int) this.rom[pntr_ + 3 + 8];
        pntr_ += 8;
      }
      return nextPointer;
    }

    private int getCompressedFileSize(byte[] f, int l)
    {
      this.arrayCopy(f, l, 1048576);
      this.ge.SetCompressedBuffer(f);
      int compressedSize = 0;
      int fileSize = 0;
      this.ge.GetUncompressedSize(ref fileSize, ref compressedSize);
      return compressedSize;
    }

    private void arrayCopy(byte[] f, int l, int length)
    {
      for (int index = 0; index < length && l < this.rom.Length; ++index)
      {
        f[index] = this.rom[l];
        ++l;
      }
    }

    private byte[] arrayCopy(int l, int length)
    {
      byte[] numArray = new byte[length];
      for (int index = 0; index < length && l < this.rom.Length; ++index)
      {
        numArray[index] = this.rom[l];
        ++l;
      }
      return numArray;
    }

    private byte[] arrayCopy(int l)
    {
      List<byte> byteList = new List<byte>();
      for (; l < this.rom.Length; ++l)
        byteList.Add(this.rom[l]);
      return byteList.ToArray();
    }

    private void updateEORFiles(int diff)
    {
      this.F19250_location += diff;
      this.F361E3_location += diff;
      this.F37F90_location += diff;
      this.F9CAE0_location += diff;
      this.FA3FD0_location += diff;
      this.FA5D96_location += diff;
      this.FA5F50_location += diff;
      this.FA8CE6_location += diff;
      this.FA9150_location += diff;
      this.FAE27E_location += diff;
      this.FAE860_location += diff;
      this.FB1AEB_location += diff;
      this.FB24A0_location += diff;
      this.FB42D9_location += diff;
      this.FB44E0_location += diff;
      this.FB9610_location += diff;
      this.FB9A30_location += diff;
      this.FBE5E2_location += diff;
      this.FBEBE0_location += diff;
      this.FC3FEF_location += diff;
      this.FC4810_location += diff;
      this.FC6C0F_location += diff;
      this.FC6F20_location += diff;
      this.FC8AFC_location += diff;
      this.FC9150_location += diff;
      this.FCF698_location += diff;
      this.FD0420_location += diff;
      this.FD5A60_location += diff;
      this.FD6190_location += diff;
      this.FDA2FF_location += diff;
      this.FDAA10_location += diff;
      this.FDAA30_location += diff;
    }

    private void locateEORFiles()
    {
      byte[] f = new byte[1048576];
      this.F19250_location = this.toPNTR(4218, 4226);
      this.F361E3_location = this.F19250_location + this.getCompressedFileSize(f, this.F19250_location);
      this.F37F90_location = this.toPNTR(10234, 10274);
      this.F9CAE0_location = this.F37F90_location + this.getCompressedFileSize(f, this.F37F90_location);
      this.FA3FD0_location = this.toPNTR(10238, 10278);
      this.FA5D96_location = this.FA3FD0_location + this.getCompressedFileSize(f, this.FA3FD0_location);
      this.FA5F50_location = this.toPNTR(10254, 10294);
      this.FA8CE6_location = this.FA5F50_location + this.getCompressedFileSize(f, this.FA5F50_location);
      this.FA9150_location = this.toPNTR(10262, 10302);
      this.FAE27E_location = this.FA9150_location + this.getCompressedFileSize(f, this.FA9150_location);
      this.FAE860_location = this.toPNTR(10270, 10310);
      this.FB1AEB_location = this.FAE860_location + this.getCompressedFileSize(f, this.FAE860_location);
      this.FB24A0_location = this.toPNTR(10358, 10398);
      this.FB42D9_location = this.FB24A0_location + this.getCompressedFileSize(f, this.FB24A0_location);
      this.FB44E0_location = this.toPNTR(10366, 10406);
      this.FB9610_location = this.FB44E0_location + this.getCompressedFileSize(f, this.FB44E0_location);
      this.FB9A30_location = this.toPNTR(10374, 10414);
      this.FBE5E2_location = this.FB9A30_location + this.getCompressedFileSize(f, this.FB9A30_location);
      this.FBEBE0_location = this.toPNTR(10382, 10422);
      this.FC3FEF_location = this.FBEBE0_location + this.getCompressedFileSize(f, this.FBEBE0_location);
      this.FC4810_location = this.toPNTR(10390, 10430);
      this.FC6C0F_location = this.FC4810_location + this.getCompressedFileSize(f, this.FC4810_location);
      this.FC6F20_location = this.toPNTR(10486, 10526);
      this.FC8AFC_location = this.FC6F20_location + this.getCompressedFileSize(f, this.FC6F20_location);
      this.FC9150_location = this.toPNTR(10494, 10534);
      this.FCF698_location = this.FC9150_location + this.getCompressedFileSize(f, this.FC9150_location);
      this.FD0420_location = this.toPNTR(10502, 10542);
      this.FD5A60_location = this.FD0420_location + this.getCompressedFileSize(f, this.FD0420_location);
      this.FD6190_location = this.toPNTR(10474, 10514);
      this.FDA2FF_location = this.FD6190_location + this.getCompressedFileSize(f, this.FD6190_location);
      this.FDAA10_location = this.toPNTR(10242, 10282);
      this.FDAA30_location = this.toPNTR(10246, 10286);
    }

    private int toPNTR(int u, int l) => (int) this.rom[u] * 16777216 + (int) this.rom[u + 1] * 65536 + (int) (short) ((int) this.rom[l] * 256 + (int) this.rom[l + 1]);

    private void camera()
    {
      bool flag = false;
      if (this.zoomIn | this.zoomOut | this.left | this.right)
      {
        this.BBCamera.PanUpdate(this.zoomIn, this.zoomOut, this.left, this.right);
        flag = true;
      }
      Point mousePosition1 = Control.MousePosition;
      this.newMouseX = mousePosition1.X;
      mousePosition1 = Control.MousePosition;
      this.newMouseY = mousePosition1.Y;
      if (this.sceneClick)
        flag = true;
      if (this.forceRedraw)
      {
        flag = true;
        this.forceRedraw = false;
      }
      if (this.RotateSceneClick)
      {
        flag = true;
        this.BBCamera.MouseUpdate(this.newMouseX - this.oldMouseX, this.newMouseY - this.oldMouseY);
      }
      Point mousePosition2 = Control.MousePosition;
      this.oldMouseX = mousePosition2.X;
      mousePosition2 = Control.MousePosition;
      this.oldMouseY = mousePosition2.Y;
      if (!flag)
        return;
      this.world.core.ClearScreenAndLoadIdentity();
      Gl.glPushMatrix();
      Gl.glLoadMatrixf(this.BBCamera.GetWorldToViewMatrix());
      this.world.Redraw(this.BBCamera);
      Gl.glPopMatrix();
      if (this.showStats)
      {
        BBUI.DrawStats(this.ls);
        BBUI.DrawJinjos(this.LevelViewer.Width - 325, 2, this.world.jinjos);
        this.world.core.SetView(this.LevelViewer.Height, this.LevelViewer.Width);
      }
      BBUI.DrawAxis(this.LevelViewer.Width - 90, this.LevelViewer.Height - 90, this.BBCamera);
      this.world.core.SetView(this.LevelViewer.Height, this.LevelViewer.Width);
      this.LevelViewer.SwapBuffers();
    }

    protected override void OnPaint(PaintEventArgs e) => base.OnPaint(e);

    private void readINI()
    {
      try
      {
        StreamReader streamReader = new StreamReader(Application.StartupPath + "\\resources\\mw.ini");
        string end = streamReader.ReadToEnd();
        streamReader.Close();
        if (Regex.IsMatch(end, "ROM:([^\\r\\n]*)"))
        {
          this.inRom = Regex.Match(end, "ROM:([^\\r\\n]*)").Groups[1].Value;
          if (Regex.IsMatch(end, "DEBUG:ENABLED"))
            this.enableDebug = true;
          Regex.IsMatch(end, "DEBUG_TE:ENABLED");
          if (Regex.IsMatch(end, "STACKSIZE:"))
          {
            Match match = Regex.Match(end, "STACKSIZE:(\\d.)");
            try
            {
              this.world.setupStackSize = Convert.ToInt32(match.Groups[1].Value);
            }
            catch
            {
            }
          }
          try
          {
            BinaryReader binaryReader = new BinaryReader((Stream) File.Open(this.inRom, FileMode.Open));
            long length = binaryReader.BaseStream.Length;
            this.rom = new byte[length];
            binaryReader.BaseStream.Read(this.rom, 0, (int) length);
            binaryReader.Close();
            this.enableMWFull();
            this.romBuild.rom = this.rom;
            RomHandler.Rom = this.rom;
            this.romBuild.populateEORPointers();
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show("Banjo's Backpack Failed to open the rom " + ex.Message, "Unable to open rom");
            this.openRom();
            this.forceRedraw = true;
          }
        }
        else
        {
          int num = (int) MessageBox.Show("Banjo's Backpack has detected that this is your first time using the program, please open a Banjo Kazooie Rom");
          this.openRom();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Banjo's Backpack has detected that this is your first time using the program, please open a Banjo Kazooie Rom");
        this.openRom();
      }
    }

    private void writeINI(string file)
    {
      try
      {
        if (!File.Exists(Application.StartupPath + "\\resources\\mw.ini"))
          File.Create(Application.StartupPath + "\\resources\\mw.ini");
        StreamReader streamReader = new StreamReader(Application.StartupPath + "\\resources\\mw.ini");
        string end = streamReader.ReadToEnd();
        streamReader.Close();
        string str = !Regex.IsMatch(end, "ROM:([^\\r\\n]*)") ? end + "ROM:" + file + Environment.NewLine : Regex.Replace(end, "ROM:([^\\r\\n]*)", "ROM:" + file);
        StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\resources\\mw.ini");
        streamWriter.Write(str);
        streamWriter.Close();
      }
      catch (Exception ex1)
      {
        try
        {
          int num = (int) MessageBox.Show("Error: Could not open mw.ini");
          if (MessageBox.Show("Do you want me to try to create the file?", "Attempt 2", MessageBoxButtons.YesNo) != DialogResult.Yes)
            return;
          File.Create(Application.StartupPath + "\\resources\\mw.ini");
          StreamReader streamReader = new StreamReader(Application.StartupPath + "\\resources\\mw.ini");
          string end = streamReader.ReadToEnd();
          streamReader.Close();
          string str = !Regex.IsMatch(end, "ROM:([^\\r\\n]*)") ? end + "ROM:" + file + Environment.NewLine : Regex.Replace(end, "ROM:([^\\r\\n]*)", "ROM:" + file);
          StreamWriter streamWriter = new StreamWriter(Application.StartupPath + "\\resources\\mw.ini");
          streamWriter.Write(str);
          streamWriter.Close();
        }
        catch (Exception ex2)
        {
          int num = (int) MessageBox.Show("Error: General Failure");
        }
      }
    }

    private void KnowMoves(bool knowMoves)
    {
      byte[] numArray = this.arrayCopy(this.F37F90_location, 1048576);
      GECompression ge = this.ge;
      byte[] Buffer = numArray;
      int length = Buffer.Length;
      ge.SetCompressedBuffer(Buffer, length);
      int compressedSize = 0;
      int fileSize = 0;
      this.F37F90 = ((IEnumerable<byte>) this.ge.OutputDecompressedBuffer(ref fileSize, ref compressedSize)).ToList<byte>();
      if (!knowMoves)
      {
        this.F37F90[59470] = (byte) 195;
        this.F37F90[59471] = (byte) 160;
      }
      else
      {
        this.F37F90[59470] = (byte) 15;
        this.F37F90[59471] = (byte) 152;
      }
      FileStream output1 = File.Create(this.outDir + "F37F90.bin");
      BinaryWriter binaryWriter1 = new BinaryWriter((Stream) output1);
      binaryWriter1.Write(this.F37F90.ToArray(), 0, this.F37F90.Count);
      binaryWriter1.Close();
      output1.Close();
      this.romBuild.rom = this.rom;
      this.romBuild.populateEORPointers();
      this.romBuild.outDir = this.outDir;
      this.romBuild.insertDecompressedFile(this.outDir, "F37F90.bin", this.F37F90_location, this.F9CAE0_location - this.F37F90_location, true);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      FileStream output2 = File.Create(this.inRom);
      BinaryWriter binaryWriter2 = new BinaryWriter((Stream) output2);
      binaryWriter2.Write(this.romBuild.rom);
      binaryWriter2.Close();
      output2.Close();
      this.reCRC();
      int num = (int) MessageBox.Show(this.inRom + " has been updated");
    }

    private void reCRC()
    {
      string str = "rn64crc.exe";
      Process process = new Process();
      process.StartInfo.FileName = str;
      process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
      process.StartInfo.Arguments = "-u \"" + this.inRom + "\"";
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      process.WaitForExit();
      process.Close();
    }

    private void PrepRom()
    {
      int compressedSize = 0;
      byte[] numArray = this.arrayCopy(this.F19250_location, this.F361E3_location - this.F19250_location);
      GECompression geCompression = new GECompression();
      byte[] Buffer = numArray;
      geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
      int fileSize = 0;
      byte[] buffer = geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
      buffer[68124] = (byte) 0;
      buffer[68125] = (byte) 0;
      buffer[68126] = (byte) 0;
      buffer[68127] = (byte) 0;
      buffer[68144] = (byte) 16;
      buffer[68145] = (byte) 0;
      buffer[395] = (byte) 145;
      FileStream output1 = File.Create(this.outDir + "F19250.bin");
      BinaryWriter binaryWriter1 = new BinaryWriter((Stream) output1);
      binaryWriter1.Write(buffer, 0, fileSize);
      binaryWriter1.Close();
      output1.Close();
      this.romBuild.rom = this.rom;
      this.romBuild.populateEORPointers();
      this.romBuild.outDir = this.outDir;
      this.romBuild.insertDecompressedFile(this.outDir, "F19250.bin", this.F19250_location, compressedSize, true);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      uint num = 66060288;
      byte[] f37f90;
      byte[] assets;
      new Globalizer(2151677952U, num, this.rom).BeginUpdating(out f37f90, out assets);
      this.F37F90 = ((IEnumerable<byte>) f37f90).ToList<byte>();
      this.insertF37F90();
      this.romBuild.insertAsset(assets, (int) num);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      FileStream output2 = File.Create(this.inRom);
      BinaryWriter binaryWriter2 = new BinaryWriter((Stream) output2);
      binaryWriter2.Write(this.romBuild.rom);
      binaryWriter2.Close();
      output2.Close();
    }

    private void ReadSetupsXML()
    {
      this.sfl = BBXML.ReadSetupsXML();
      this.osff = new OpenSetFileForm();
      this.world.dir = this.tmpDir;
      this.osff.DisplayFiles(this.sfl);
    }

    private void LoadSetupFiles()
    {
      int num = (int) this.osff.ShowDialog();
      int selected = this.osff.selected;
      if (selected == -1)
        return;
      this.world.resetPick();
      this.selectedFile = this.sfl[selected];
      string file_ = this.tmpDir + this.selectedFile.pointer.ToString("x");
      this.world.file = this.selectedFile;
      this.world.ReadSetupFile(file_);
      this.listDec = this.world.GetListDec(this.tmpDir + this.selectedFile.pointer.ToString("x"));
      this.newStart = this.listDec + 4;
      this.world.RenderScene(this.replacedModel, this.replacedModelEx);
      this.world.renderSetup();
      this.world.renderPicking();
      this.world.RenderCameras();
      this.Refresh();
    }

    private void save_tsmi_Click(object sender, EventArgs e)
    {
      try
      {
        int num = 0;
        for (int index = 0; index < this.levelEntries.Count<LevelEntryPoint>(); ++index)
        {
          if (this.levelEntries[index].inuse)
            num = (int) this.levelEntries[index].entry;
        }
        List<LevelEntryPoint> entries_ = new List<LevelEntryPoint>();
        for (int index = 0; index < this.levelEntries.Count<LevelEntryPoint>() && index < num; ++index)
        {
          if (!this.levelEntries[index].inuse && (int) this.levelEntries[index].entry < num)
            entries_.Add(this.levelEntries[index]);
        }
        WrittenFile binaryFileObjects = this.sfw.createBinaryFileObjects(this.tmpDir, this.outDir, this.selectedFile, new List<ObjectData>((IEnumerable<ObjectData>) this.world.objects), new List<ObjectData>((IEnumerable<ObjectData>) this.world.structs), this.world.paths, this.world.cameras, entries_, this.includeTriggers, this.world.file.bounds, this.replacedModel, this.replacedModelEx, this.allObjsErased, "");
        for (int index = 0; index < this.writtenFiles.Count; ++index)
        {
          if (this.writtenFiles[index].filename == binaryFileObjects.filename)
          {
            this.writtenFiles.RemoveAt(index);
            --index;
          }
        }
        this.writtenFiles.Add(binaryFileObjects);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: Failed to Save");
      }
      try
      {
        this.romBuild.rom = this.rom;
        this.romBuild.populateEORPointers();
        this.romBuild.outDir = this.outDir;
        for (int index = 0; index < this.writtenFiles.Count; ++index)
        {
          if (this.writtenFiles[index].replacementModelFile != "" && this.writtenFiles[index].replacementModelBFile == "" && this.selectedFile.modelBPointer != 0)
          {
            int diff;
            if (this.selectedFile.levelID == 7)
            {
              this.romBuild.GVFix(".\\resources\\blank_model_B.bin");
              diff = this.romBuild.insertDecompressedFile(this.outDir, "gv-b.bin", this.writtenFiles[index].modelBPointer, 0, false);
            }
            else
              diff = this.romBuild.insertDecompressedFile(this.outDir, ".\\resources\\blank_model_B.bin", this.writtenFiles[index].modelBPointer, 0, false);
            this.updateEORFiles(diff);
          }
          if (this.writtenFiles[index].replacementModelFile == "" && this.writtenFiles[index].replacementModelBFile != "")
            this.updateEORFiles(this.romBuild.insertDecompressedFile(this.outDir, ".\\resources\\blank_model.bin", this.writtenFiles[index].modelAPointer, 0, false));
          if (this.writtenFiles[index].replacementModelFile != "")
          {
            this.romBuild.correctModelFile(this.writtenFiles[index].replacementModelFile);
            this.updateEORFiles(this.romBuild.insertDecompressedFile("", this.writtenFiles[index].replacementModelFile, this.writtenFiles[index].modelAPointer, 0, false));
          }
          if (this.writtenFiles[index].replacementModelBFile != "" && this.selectedFile.modelBPointer != 0)
          {
            this.romBuild.correctModelFile(this.writtenFiles[index].replacementModelBFile);
            int diff;
            if (this.selectedFile.levelID == 7)
            {
              this.romBuild.GVFix(this.writtenFiles[index].replacementModelBFile);
              diff = this.romBuild.insertDecompressedFile(this.outDir, "gv-b.bin", this.writtenFiles[index].modelBPointer, 0, false);
            }
            else
              diff = this.romBuild.insertDecompressedFile("", this.writtenFiles[index].replacementModelBFile, this.writtenFiles[index].modelBPointer, 0, false);
            this.updateEORFiles(diff);
          }
        }
        for (int index = 0; index < this.writtenFiles.Count; ++index)
        {
          this.updateEORFiles(this.romBuild.insertDecompressedFile(this.outDir, this.writtenFiles[index].filename, this.writtenFiles[index].pointer, 0, false));
          this.romBuild.updateLevelHeader(this.writtenFiles[index].setupBounds, this.selectedFile.bounds, this.F9CAE0, this.F9CAE0_location, this.FA3FD0_location - this.F9CAE0_location, this.selectedFile.sceneID, false);
        }
        this.rom = this.romBuild.rom;
        FileStream output = File.Create(this.inRom);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(this.rom);
        binaryWriter.Close();
        output.Close();
        this.writtenFiles.Clear();
        string str = "rn64crc.exe";
        Process process = new Process();
        process.StartInfo.FileName = str;
        process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
        process.StartInfo.Arguments = "-u \"" + this.inRom + "\"";
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit();
        process.Close();
        this.cleanOutDir();
        RomHandler.Rom = this.rom;
        int num = (int) MessageBox.Show("Changes saved successfully");
        this.locateEORFiles();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occured, please try again. " + Environment.NewLine + "Error: " + (object) ex);
      }
    }

    private void saveAsRomToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.saveAsRomFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        int num = 0;
        for (int index = 0; index < this.levelEntries.Count<LevelEntryPoint>(); ++index)
        {
          if (this.levelEntries[index].inuse)
            num = (int) this.levelEntries[index].entry;
        }
        List<LevelEntryPoint> entries_ = new List<LevelEntryPoint>();
        for (int index = 0; index < this.levelEntries.Count<LevelEntryPoint>() && index < num; ++index)
        {
          if (!this.levelEntries[index].inuse && (int) this.levelEntries[index].entry < num)
            entries_.Add(this.levelEntries[index]);
        }
        WrittenFile binaryFileObjects = this.sfw.createBinaryFileObjects(this.tmpDir, this.outDir, this.selectedFile, new List<ObjectData>((IEnumerable<ObjectData>) this.world.objects), new List<ObjectData>((IEnumerable<ObjectData>) this.world.structs), this.world.paths, this.world.cameras, entries_, this.includeTriggers, this.world.file.bounds, this.replacedModel, this.replacedModelEx, this.allObjsErased, "");
        for (int index = 0; index < this.writtenFiles.Count; ++index)
        {
          if (this.writtenFiles[index].filename == binaryFileObjects.filename)
          {
            this.writtenFiles.RemoveAt(index);
            --index;
          }
        }
        this.writtenFiles.Add(binaryFileObjects);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: Failed to Save");
      }
      try
      {
        this.romBuild.saveAsMode();
        this.romBuild.outDir = this.outDir;
        for (int index = 0; index < this.writtenFiles.Count; ++index)
        {
          if (this.writtenFiles[index].replacementModelFile != "" && this.writtenFiles[index].replacementModelBFile == "" && this.selectedFile.modelBPointer != 0)
          {
            int diff;
            if (this.selectedFile.levelID == 7)
            {
              this.romBuild.GVFix(".\\resources\\blank_model_B.bin");
              diff = this.romBuild.insertDecompressedFile(this.outDir, "gv-b.bin", this.writtenFiles[index].modelBPointer, 0, false);
            }
            else
              diff = this.romBuild.insertDecompressedFile(this.outDir, ".\\resources\\blank_model_B.bin", this.writtenFiles[index].modelBPointer, 0, false);
            this.updateEORFiles(diff);
          }
          if (this.writtenFiles[index].replacementModelFile == "" && this.writtenFiles[index].replacementModelBFile != "")
            this.updateEORFiles(this.romBuild.insertDecompressedFile(this.outDir, ".\\resources\\blank_model.bin", this.writtenFiles[index].modelAPointer, 0, false));
          if (this.writtenFiles[index].replacementModelFile != "")
          {
            this.romBuild.correctModelFile(this.writtenFiles[index].replacementModelFile);
            this.updateEORFiles(this.romBuild.insertDecompressedFile("", this.writtenFiles[index].replacementModelFile, this.writtenFiles[index].modelAPointer, 0, false));
          }
          if (this.writtenFiles[index].replacementModelBFile != "" && this.selectedFile.modelBPointer != 0)
          {
            this.romBuild.correctModelFile(this.writtenFiles[index].replacementModelBFile);
            int diff;
            if (this.selectedFile.levelID == 7)
            {
              this.romBuild.GVFix(this.writtenFiles[index].replacementModelBFile);
              diff = this.romBuild.insertDecompressedFile(this.outDir, "gv-b.bin", this.writtenFiles[index].modelBPointer, 0, false);
            }
            else
              diff = this.romBuild.insertDecompressedFile("", this.writtenFiles[index].replacementModelBFile, this.writtenFiles[index].modelBPointer, 0, false);
            this.updateEORFiles(diff);
          }
        }
        for (int index = 0; index < this.writtenFiles.Count; ++index)
        {
          this.updateEORFiles(this.romBuild.insertDecompressedFile(this.outDir, this.writtenFiles[index].filename, this.writtenFiles[index].pointer, 0, false));
          this.romBuild.updateLevelHeader(this.writtenFiles[index].setupBounds, this.selectedFile.bounds, this.F9CAE0, this.F9CAE0_location, this.FA3FD0_location - this.F9CAE0_location, this.selectedFile.sceneID, false);
        }
        FileStream output = File.Create(this.saveAsRomFileDialog.FileName);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(this.romBuild.rom);
        binaryWriter.Close();
        output.Close();
        this.writtenFiles.Clear();
        string str = "rn64crc.exe";
        Process process = new Process();
        process.StartInfo.FileName = str;
        process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
        process.StartInfo.Arguments = "-u \"" + this.saveAsRomFileDialog.FileName + "\"";
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit();
        process.Close();
        this.cleanOutDir();
        this.romBuild.rom = this.rom;
        this.romBuild.populateEORPointers();
        this.locateEORFiles();
        int num = (int) MessageBox.Show(this.saveAsRomFileDialog.FileName + " saved successfully");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occured, please try again. " + Environment.NewLine + "Error: " + (object) ex);
      }
    }

    private void showObjectButtons()
    {
      this.obj_move_btn.Visible = true;
      this.obj_scale_btn.Visible = true;
      this.obj_rot_btn.Visible = true;
      this.obj_duplicate_btn.Visible = true;
      this.obj_move_btn.Enabled = true;
      this.obj_rot_btn.Enabled = true;
      this.obj_scale_btn.Enabled = true;
      this.obj_duplicate_btn.Enabled = true;
      this.deselect_btn.Visible = true;
      this.delete_btn.Visible = true;
    }

    private void hideObjectButtons()
    {
      this.obj_move_btn.Visible = false;
      this.obj_scale_btn.Visible = false;
      this.obj_rot_btn.Visible = false;
      this.obj_duplicate_btn.Visible = false;
      this.deselect_btn.Visible = false;
      this.delete_btn.Visible = false;
    }

    private void showCamButtons()
    {
      this.obj_move_btn.Visible = true;
      this.cam_moveToCurrent_btn.Visible = true;
      this.cam_pitch_btn.Visible = true;
      this.cam_roll_btn.Visible = true;
      this.cam_yaw_btn.Visible = true;
      this.deselect_btn.Visible = true;
      this.delete_btn.Visible = true;
    }

    private void hideCamButtons()
    {
      this.obj_move_btn.Visible = false;
      this.cam_moveToCurrent_btn.Visible = false;
      this.cam_pitch_btn.Visible = false;
      this.cam_roll_btn.Visible = false;
      this.cam_yaw_btn.Visible = false;
      this.deselect_btn.Visible = false;
      this.delete_btn.Visible = false;
    }

    private void rectSelect_btn_Click(object sender, EventArgs e) => this.toggleRectSelect();

    private void toggleRectSelect()
    {
      if (this.rectSelectMode)
      {
        this.rectSelectMode = false;
        this.rectSelect = false;
        this.rectSelect_btn.BackColor = this.inactive;
      }
      else
      {
        this.rectSelectMode = true;
        this.rectSelect_btn.BackColor = this.active;
      }
    }

    private void delete_btn_Click(object sender, EventArgs e)
    {
      this.deleteSelected();
      this.forceRedraw = true;
    }

    private void editMove_btn_Click(object sender, EventArgs e) => this.toggleMoveMode();

    private void toggleMoveMode()
    {
      this.obj_move_btn.BackColor = this.inactive;
      if (this.selectMode)
      {
        if (this.moveMode)
        {
          this.clearEditMode();
          this.disableAllSubModes();
        }
        else
        {
          this.clearEditMode();
          this.disableAllSubModes();
          this.moveMode = true;
          this.obj_move_btn.BackColor = this.active;
        }
      }
      if (!this.cameraMode)
        return;
      if (this.camMoveMode)
      {
        this.clearEditMode();
        this.disableAllSubModes();
      }
      else
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.camMoveMode = true;
        this.cameraMode = true;
        this.obj_move_btn.BackColor = this.active;
      }
    }

    private void editRotate_btn_Click(object sender, EventArgs e) => this.toggleRotateMode();

    private void toggleRotateMode()
    {
      if (this.rotateMode)
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.obj_rot_btn.BackColor = this.inactive;
      }
      else
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.rotateMode = true;
        this.obj_rot_btn.BackColor = this.active;
      }
    }

    private void scale_btn_Click(object sender, EventArgs e) => this.toggleScaleMode();

    private void toggleScaleMode()
    {
      if (this.scaleMode)
      {
        this.clearEditMode();
        this.disableAllSubModes();
      }
      else
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.scaleMode = true;
        this.obj_scale_btn.BackColor = this.active;
      }
    }

    private void LockScale()
    {
      this.obj_scale_btn.Enabled = false;
      this.updateSize_tb.Enabled = false;
    }

    private void deselect_btn_Click(object sender, EventArgs e) => this.clearSelection();

    private void clearSelection()
    {
      this.world.resetPick();
      this.path_dgv.Rows.Clear();
      this.path_dgv.Columns.Clear();
      this.disableAllModes();
      switch (this.mode_cb.SelectedIndex)
      {
        case 0:
          this.selectMode = true;
          break;
        case 1:
          this.createMode = true;
          break;
        case 2:
          this.cameraMode = true;
          break;
        case 3:
          this.world.ActivatePathMode();
          break;
      }
      this.world.InitGl();
      this.world.renderPicking();
      this.unlockEditSettings();
      if (this.mode_cb.SelectedIndex == 3)
        this.unlockPathSettings();
      this.forceRedraw = true;
      this.Refresh();
    }

    private void Duplicate(int x, int y)
    {
      double[] world = this.world.ScreenToWorld(x, y, this.BBCamera);
      this.world.duplicateSelectedObjects((short) world[0], (short) world[1], (short) world[2]);
      this.forceRedraw = true;
      this.ls = this.world.getLevelStats(this.selectedFile.levelID, this.selectedFile.pointer);
      this.world.pushSetupStack("SelectMode:Duplicated Item");
      this.forceRedraw = true;
    }

    private void duplicate_btn_Click(object sender, EventArgs e) => this.toggleDuplicateMode();

    private void toggleDuplicateMode()
    {
      if (this.duplicateMode)
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.selectMode = true;
      }
      else
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.duplicateMode = true;
        this.obj_duplicate_btn.BackColor = this.active;
      }
    }

    private void toggleYawMode()
    {
      if (this.yawMode)
      {
        this.clearEditMode();
        this.disableAllSubModes();
      }
      else
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.yawMode = true;
        this.cameraMode = true;
        this.cam_yaw_btn.BackColor = this.active;
      }
    }

    private void togglePitchMode()
    {
      if (this.pitchMode)
      {
        this.clearEditMode();
        this.disableAllSubModes();
      }
      else
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.pitchMode = true;
        this.cameraMode = true;
        this.cam_pitch_btn.BackColor = this.active;
      }
    }

    private void toggleRollMode()
    {
      if (this.rollMode)
      {
        this.clearEditMode();
        this.disableAllSubModes();
      }
      else
      {
        this.clearEditMode();
        this.disableAllSubModes();
        this.rollMode = true;
        this.cameraMode = true;
        this.cam_roll_btn.BackColor = this.active;
      }
    }

    private void obj_move_btn_Click(object sender, EventArgs e) => this.toggleMoveMode();

    private void obj_rot_btn_Click(object sender, EventArgs e) => this.toggleRotateMode();

    private void obj_scale_btn_Click(object sender, EventArgs e) => this.toggleScaleMode();

    private void obj_duplicate_btn_Click(object sender, EventArgs e) => this.toggleDuplicateMode();

    private void cam_yaw_btn_Click(object sender, EventArgs e) => this.toggleYawMode();

    private void cam_pitch_btn_Click(object sender, EventArgs e) => this.togglePitchMode();

    private void cam_roll_btn_Click(object sender, EventArgs e) => this.toggleRollMode();

    private void eraseAll_btn_Click(object sender, EventArgs e)
    {
      if (this.selectedFile == null || MessageBox.Show((IWin32Window) this, "This will start a new setup file, are you sure you want to continue?", "", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      for (int index = 0; index < this.levelEntries.Count; ++index)
        this.levelEntries[index].inuse = false;
      this.world.resetStack();
      this.world.DeleteAllStructs();
      this.world.DeleteAllObjects();
      this.world.DeleteAllCameras();
      this.world.eraseDLs();
      this.world.resetPick();
      this.GetFlagOffsetsForOpenLevel();
      this.world.DeactivatePathMode();
      this.allObjsErased = true;
      this.mode_cb.SelectedIndex = 0;
      int num = (int) MessageBox.Show("Please move the start position to the desired location, it is currently set at 0,0,0");
      ObjectData objectData = new ObjectData((short) 1, 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 100, (short) 6412);
      ObjectData data_ = this.world.getObject("Entry Point 1");
      data_.locX = (short) 0;
      data_.locY = (short) 0;
      data_.locZ = (short) 0;
      this.world.AddObj(data_);
      this.world.setSelectedObj(0, 0);
      this.populateEntryData();
      this.populateObjectData();
      this.unlockEditSettings();
      this.world.RenderScene(this.replacedModel, this.replacedModelEx);
      this.world.renderSetup();
      this.ls = this.world.getLevelStats(this.selectedFile.levelID, this.selectedFile.pointer);
      this.forceRedraw = true;
      this.Refresh();
      this.world.pushSetupStack("SelectMode");
    }

    private void endNode_btn_Click(object sender, EventArgs e)
    {
      this.world.setNodeAsEndNode();
      this.updateEditInfo();
      this.world.pushSetupStack("PathMode:End Node");
    }

    private void updateObject()
    {
      short num = 0;
      this.world.updateObject(this.id_tb.Text == "" ? num : Convert.ToInt16(this.id_tb.Text, 16), this.updateScript_tb.Text == "" ? num : short.Parse(this.updateScript_tb.Text, NumberStyles.HexNumber), this.flag_tb.Text == "" ? (short) -1 : Convert.ToInt16(this.flag_tb.Text), this.updateRad_tb.Text == "" ? (ushort) 0 : Convert.ToUInt16(this.updateRad_tb.Text), this.updateX_tb.Text == "" ? num : Convert.ToInt16(this.updateX_tb.Text), this.updateY_tb.Text == "" ? num : Convert.ToInt16(this.updateY_tb.Text), this.updateZ_tb.Text == "" ? num : Convert.ToInt16(this.updateZ_tb.Text), this.updateSize_tb.Text == "" ? num : Convert.ToInt16(this.updateSize_tb.Text), this.updateRot_tb.Text == "" ? num : Convert.ToInt16(this.updateRot_tb.Text), this.updateB10_tb.Text == "" ? (byte) 0 : Convert.ToByte(this.updateB10_tb.Text, 16), this.updateB11_tb.Text == "" ? (byte) 0 : Convert.ToByte(this.updateB11_tb.Text, 16), this.updateB13_tb.Text == "" ? (byte) 0 : Convert.ToByte(this.updateB13_tb.Text, 16), this.updateB18_tb.Text == "" ? (byte) 0 : Convert.ToByte(this.updateB18_tb.Text, 16), this.updateB16_tb.Text == "" ? (byte) 0 : Convert.ToByte(this.updateB16_tb.Text, 16), this.updateB17_tb.Text == "" ? (byte) 0 : Convert.ToByte(this.updateB17_tb.Text, 16));
      this.forceRedraw = true;
      this.updateEditInfo();
      this.Refresh();
      this.world.pushSetupStack("SelectMode:Updated Object " + this.id_tb.Text);
    }

    private void updateCamera()
    {
      try
      {
        short num = 0;
        int camType = this.world.getCamType();
        if (camType == 3)
          this.world.updateCamera3(this.camID_tb.Text == "" ? num : Convert.ToInt16(this.camID_tb.Text, 16), this.camX_tb.Text == "" ? (float) num : Convert.ToSingle(this.camX_tb.Text), this.camY_tb.Text == "" ? (float) num : Convert.ToSingle(this.camY_tb.Text), this.camZ_tb.Text == "" ? (float) num : Convert.ToSingle(this.camZ_tb.Text), this.camYaw_tb.Text == "" ? (float) num : Convert.ToSingle(this.camYaw_tb.Text), this.camPitch_tb.Text == "" ? (float) num : Convert.ToSingle(this.camPitch_tb.Text), this.camRoll_tb.Text == "" ? (float) num : Convert.ToSingle(this.camRoll_tb.Text), this.camHSpeed_tb.Text == "" ? (float) num : Convert.ToSingle(this.camHSpeed_tb.Text), this.camVSpeed_tb.Text == "" ? (float) num : Convert.ToSingle(this.camVSpeed_tb.Text), this.camRotation_tb.Text == "" ? (float) num : Convert.ToSingle(this.camRotation_tb.Text), this.camAccel_tb.Text == "" ? (float) num : Convert.ToSingle(this.camAccel_tb.Text), this.cam3A5_tb.Text == "" ? (int) num : Convert.ToInt32(this.cam3A5_tb.Text, 16), this.camCDist_tb.Text == "" ? (float) num : Convert.ToSingle(this.camCDist_tb.Text), this.camFDist_tb.Text == "" ? (float) num : Convert.ToSingle(this.camFDist_tb.Text));
        if (camType == 2)
          this.world.updateCamera(this.camID_tb.Text == "" ? num : Convert.ToInt16(this.camID_tb.Text, 16), this.camX_tb.Text == "" ? (float) num : Convert.ToSingle(this.camX_tb.Text), this.camY_tb.Text == "" ? (float) num : Convert.ToSingle(this.camY_tb.Text), this.camZ_tb.Text == "" ? (float) num : Convert.ToSingle(this.camZ_tb.Text), this.camYaw_tb.Text == "" ? (float) num : Convert.ToSingle(this.camYaw_tb.Text), this.camPitch_tb.Text == "" ? (float) num : Convert.ToSingle(this.camPitch_tb.Text), this.camRoll_tb.Text == "" ? (float) num : Convert.ToSingle(this.camRoll_tb.Text));
        else if (camType == 1)
          this.world.updateCamera1(this.camID_tb.Text == "" ? num : Convert.ToInt16(this.camID_tb.Text, 16), this.camX_tb.Text == "" ? (float) num : Convert.ToSingle(this.camX_tb.Text), this.camY_tb.Text == "" ? (float) num : Convert.ToSingle(this.camY_tb.Text), this.camZ_tb.Text == "" ? (float) num : Convert.ToSingle(this.camZ_tb.Text), this.camYaw_tb.Text == "" ? (float) num : Convert.ToSingle(this.camYaw_tb.Text), this.camPitch_tb.Text == "" ? (float) num : Convert.ToSingle(this.camPitch_tb.Text), this.camRoll_tb.Text == "" ? (float) num : Convert.ToSingle(this.camRoll_tb.Text), this.camHSpeed_tb.Text == "" ? (float) num : Convert.ToSingle(this.camHSpeed_tb.Text), this.camVSpeed_tb.Text == "" ? (float) num : Convert.ToSingle(this.camVSpeed_tb.Text), this.camRotation_tb.Text == "" ? (float) num : Convert.ToSingle(this.camRotation_tb.Text), this.camAccel_tb.Text == "" ? (float) num : Convert.ToSingle(this.camAccel_tb.Text), this.cam3A5_tb.Text == "" ? (int) num : Convert.ToInt32(this.cam3A5_tb.Text, 16));
        this.world.pushSetupStack("CameraMode:Updated Camera " + this.camID_tb.Text);
        this.forceRedraw = true;
        this.updateEditInfo();
        this.Refresh();
      }
      catch (Exception ex)
      {
      }
    }

    private void updateObjID()
    {
      try
      {
        if (!this.world.singleObjectSelected())
          return;
        this.world.updateObjectID(short.Parse(this.id_tb.Text, NumberStyles.HexNumber));
        this.world.RenderObjects();
        this.world.Redraw(this.BBCamera);
        this.unlockEditSettings();
        this.forceRedraw = true;
        this.Refresh();
        this.LevelViewer.Focus();
        this.world.pushSetupStack("SelectMode: Updated Object");
      }
      catch
      {
      }
    }

    private void updateObjectScript()
    {
      try
      {
        if (!this.world.singleObjectSelected())
          return;
        this.world.updateObjectScript(this.updateScript_tb.Text == "" ? (short) 0 : short.Parse(this.updateScript_tb.Text, NumberStyles.HexNumber));
        this.world.RenderObjects();
        this.world.Redraw(this.BBCamera);
        this.unlockEditSettings();
        this.forceRedraw = true;
        this.Refresh();
        this.LevelViewer.Focus();
        this.world.pushSetupStack("SelectMode: Updated Object");
      }
      catch
      {
      }
    }

    private void id_tb_Leave(object sender, EventArgs e) => this.updateObjID();

    private void id_tb_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.updateObjID();
    }

    private void objectPropertyLeave(object sender, EventArgs e)
    {
      try
      {
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateName_btn_Click(object sender, EventArgs e)
    {
    }

    private void updateB10_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB10_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB10_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateB11_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB11_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB11_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateB13_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB13_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB13_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateB18_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB18_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB18_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateB10_tb_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB10_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB10_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateB11_tb_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB11_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB11_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateB13_tb_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB13_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB13_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateB18_tb_KeyDown(object sender, KeyEventArgs e)
    {
      try
      {
        int int32 = Convert.ToInt32(this.updateB18_tb.Text, 16);
        if (int32 < 0 || int32 > (int) byte.MaxValue)
          this.updateB18_tb.Text = "0";
        this.updateObject();
      }
      catch
      {
      }
    }

    private void updateScript_tb_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.LevelViewer.Focus();
    }

    private void updateScript_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        if (!this.world.singleObjectSelected())
          return;
        this.updateObjectScript();
      }
      catch
      {
      }
    }

    private void camera_properties_update(object sender, EventArgs e)
    {
      try
      {
        if (!this.world.hasSelectedCamera())
          return;
        this.updateCamera();
      }
      catch
      {
      }
    }

    private void camera_properties_update(object sender, KeyEventArgs e)
    {
      try
      {
        if (!this.world.hasSelectedCamera())
          return;
        this.updateCamera();
      }
      catch
      {
      }
    }

    private void updateX_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.updateX_tb.Text, out result);
      if (e.KeyCode == Keys.Up)
        ++result;
      if (e.KeyCode == Keys.Down)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.updateX_tb.Text = result.ToString();
        this.updateObject();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.updateObject();
    }

    private void updateY_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.updateY_tb.Text, out result);
      if (e.KeyCode == Keys.Up)
        ++result;
      if (e.KeyCode == Keys.Down)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.updateY_tb.Text = result.ToString();
        this.updateObject();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.updateObject();
    }

    private void updateZ_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.updateZ_tb.Text, out result);
      if (e.KeyCode == Keys.Up)
        ++result;
      if (e.KeyCode == Keys.Down)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.updateZ_tb.Text = result.ToString();
        this.updateObject();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.updateObject();
    }

    private void updateSize_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.updateSize_tb.Text, out result);
      if (e.KeyCode == Keys.Up && result < (short) 801)
        ++result;
      if (e.KeyCode == Keys.Down && result > (short) 0)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.updateSize_tb.Text = result.ToString();
        this.updateObject();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.updateObject();
    }

    private void updateRot_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.updateRot_tb.Text, out result);
      if (e.KeyCode == Keys.Up && result < (short) 360)
        ++result;
      if (e.KeyCode == Keys.Down && result > (short) 0)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.updateRot_tb.Text = result.ToString();
        this.updateObject();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.updateObject();
    }

    private void AssociateScenesWithLevels()
    {
      for (int index = 33412; index < 34451; index += 8)
      {
        int num1 = (int) this.F9CAE0[index + 4] * 256 + (int) this.F9CAE0[index + 5];
        int num2 = (int) this.F9CAE0[index + 6] * 256 + (int) this.F9CAE0[index + 7];
        foreach (SetupFile setupFile in this.sfl)
        {
          if (setupFile.sceneID == num1)
            setupFile.levelID = num2;
        }
      }
    }

    public void GetFlagOffsetsForOpenLevel()
    {
      this.AssociateScenesWithLevels();
      int num = 0;
      foreach (SetupFile setupFile in this.sfl)
      {
        if (setupFile.sceneID == this.selectedFile.sceneID)
          num = setupFile.levelID;
      }
      switch (num)
      {
        case 1:
          this.jiggyOffset = 1;
          this.honeyCombOffset = 100;
          this.mumboTokenOffset = 201;
          break;
        case 2:
          this.jiggyOffset = 11;
          this.honeyCombOffset = 102;
          this.mumboTokenOffset = 205;
          break;
        case 3:
          this.jiggyOffset = 21;
          this.honeyCombOffset = 104;
          this.mumboTokenOffset = 215;
          break;
        case 4:
          this.jiggyOffset = 31;
          this.honeyCombOffset = 106;
          this.mumboTokenOffset = 220;
          break;
        case 5:
          this.jiggyOffset = 41;
          this.honeyCombOffset = 108;
          this.mumboTokenOffset = 230;
          break;
        case 6:
          this.jiggyOffset = 50;
          this.honeyCombOffset = 0;
          this.mumboTokenOffset = 280;
          break;
        case 7:
          this.jiggyOffset = 61;
          this.honeyCombOffset = 110;
          this.mumboTokenOffset = 240;
          break;
        case 8:
          this.jiggyOffset = 71;
          this.honeyCombOffset = 112;
          this.mumboTokenOffset = 290;
          break;
        case 9:
          this.jiggyOffset = 81;
          this.honeyCombOffset = 102;
          this.mumboTokenOffset = 265;
          break;
        case 10:
          this.jiggyOffset = 91;
          this.honeyCombOffset = 116;
          this.mumboTokenOffset = 250;
          break;
        case 11:
          this.jiggyOffset = 0;
          this.honeyCombOffset = 118;
          this.mumboTokenOffset = 0;
          break;
        case 12:
          this.jiggyOffset = 0;
          this.honeyCombOffset = 0;
          break;
        case 13:
          this.jiggyOffset = 0;
          this.honeyCombOffset = 0;
          break;
      }
      for (int index = 0; index < this.objectMenu.Items.Count; ++index)
        this.objectMenu.Items[index].Visible = true;
    }

    private void openSetupFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.world.DeactivatePathMode();
      this.mode_cb.SelectedIndex = 0;
      this.clearSelection();
      this.openSetupFile();
      this.world.pushSetupStack("SelectMode");
      this.forceRedraw = true;
    }

    private void importObjToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.importPrep();
        this.timer1.Enabled = false;
        int num = (int) new ModelImportForm(this.tmpDir).ShowDialog();
        this.LevelViewer.MakeCurrent();
        this.timer1.Enabled = true;
      }
      catch (Exception ex)
      {
        this.LevelViewer.MakeCurrent();
        this.timer1.Enabled = true;
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) new AboutBox().ShowDialog();
    }

    private void textEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      TextEditorForm textEditorForm = new TextEditorForm(this.tmpDir);
      int num1 = (int) textEditorForm.ShowDialog();
      if (!textEditorForm.updateROM)
        return;
      this.romBuild.rom = this.rom;
      this.romBuild.populateEORPointers();
      this.romBuild.outDir = this.outDir;
      foreach (string file1 in Directory.GetFiles(this.outTxtDir, "*", SearchOption.AllDirectories))
      {
        try
        {
          string file2 = file1.Remove(0, this.outTxtDir.Length);
          this.romBuild.insertDecompressedFile(this.outTxtDir, file2, Convert.ToInt32(file2, 16), 0, false);
          FileStream output = File.Create(this.inRom);
          BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
          binaryWriter.Write(this.romBuild.rom);
          binaryWriter.Close();
          output.Close();
        }
        catch
        {
        }
      }
      foreach (string file in Directory.GetFiles(this.outTxtDir, "*", SearchOption.AllDirectories))
        File.Delete(file);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      string str = "rn64crc.exe";
      Process process = new Process();
      process.StartInfo.FileName = str;
      process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
      process.StartInfo.Arguments = "-u \"" + this.inRom + "\"";
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      process.WaitForExit();
      process.Close();
      int num2 = (int) MessageBox.Show(this.inRom + " has been updated");
    }

    private void puzzleEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      GeneralSettings generalSettings = new GeneralSettings(ref this.F9CAE0, ref this.F37F90, ref this.globalizedFCF698, this.sfl, this.entryPoints);
      int num1 = (int) generalSettings.ShowDialog();
      if (generalSettings.updatedFCF698)
      {
        int globalizedFcF698Location = this.globalizedFCF698Location;
        for (int index = 0; index < this.globalizedFCF698.Length; ++index)
        {
          this.rom[globalizedFcF698Location] = this.globalizedFCF698[index];
          ++globalizedFcF698Location;
        }
        this.romBuild.rom = this.rom;
        RomHandler.Rom = this.rom;
        FileStream output = File.Create(this.inRom);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(this.romBuild.rom);
        binaryWriter.Close();
        output.Close();
      }
      if (generalSettings.updatedF9CAE0)
      {
        FileStream output = File.Create(this.outDir + "F9CAE0.bin");
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(this.F9CAE0.ToArray(), 0, this.F9CAE0.Count);
        binaryWriter.Close();
        output.Close();
        this.injectFile(this.outDir, "F9CAE0.bin", this.F9CAE0_location, this.FA3FD0_location - this.F9CAE0_location, true);
      }
      if (generalSettings.updatedF37F90)
      {
        FileStream output = File.Create(this.outDir + "F37F90.bin");
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(this.F37F90.ToArray(), 0, this.F37F90.Count);
        binaryWriter.Close();
        output.Close();
        this.injectFile(this.outDir, "F37F90.bin", this.F37F90_location, this.F9CAE0_location - this.F37F90_location, true);
      }
      if (!generalSettings.updatedF37F90 && !generalSettings.updatedF9CAE0 && !generalSettings.updatedFCF698)
        return;
      int num2 = (int) MessageBox.Show(this.inRom + " Updated");
    }

    private void hideUnknownBytesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.hideUnknownBytes)
      {
        this.hideUnknownBytes = false;
        this.hideUnknownBytesToolStripMenuItem.Checked = false;
        if (!this.world.isObject() || this.hideUnknownBytes)
          return;
        this.updateB10_tb.Visible = true;
        this.updateB10_tb.Enabled = true;
        this.updateB11_tb.Visible = true;
        this.updateB11_tb.Enabled = true;
        this.updateB13_tb.Visible = true;
        this.updateB13_tb.Enabled = true;
        this.updateB18_tb.Visible = true;
        this.updateB18_tb.Enabled = true;
        this.updateB16_tb.Visible = true;
        this.updateB16_tb.Enabled = true;
        this.updateB17_tb.Visible = true;
        this.updateB17_tb.Enabled = true;
        this.b16_lbl.Visible = true;
        this.b17_lbl.Visible = true;
        this.b10_lbl.Visible = true;
        this.b11_lbl.Visible = true;
        this.b13_lbl.Visible = true;
        this.b18_lbl.Visible = true;
      }
      else
      {
        this.hideUnknownBytes = true;
        this.hideUnknownBytesToolStripMenuItem.Checked = true;
        if (!this.world.isObject() || !this.hideUnknownBytes)
          return;
        this.updateB10_tb.Visible = false;
        this.updateB10_tb.Enabled = false;
        this.updateB11_tb.Visible = false;
        this.updateB11_tb.Enabled = false;
        this.updateB13_tb.Visible = false;
        this.updateB13_tb.Enabled = false;
        this.updateB18_tb.Visible = false;
        this.updateB18_tb.Enabled = false;
        this.b10_lbl.Visible = false;
        this.b11_lbl.Visible = false;
        this.b13_lbl.Visible = false;
        this.b18_lbl.Visible = false;
        this.updateB16_tb.Visible = false;
        this.updateB16_tb.Enabled = false;
        this.updateB17_tb.Visible = false;
        this.updateB17_tb.Enabled = false;
        this.b16_lbl.Visible = false;
        this.b17_lbl.Visible = false;
      }
    }

    private void knowAllMovesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("This will update the currently opened rom " + this.inRom + " is this OK?", "Update Rom", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this.KnowMoves(true);
    }

    private void haveNoMovesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("This will update the currently opened rom " + this.inRom + " is this fine?", "Update Rom", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      this.KnowMoves(false);
    }

    private void sNSEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SNSEditor snsEditor = new SNSEditor(this.F37F90, this.F9CAE0, this.sfl);
      int num1 = (int) snsEditor.ShowDialog();
      if (!snsEditor.updatedRom)
        return;
      this.F37F90 = snsEditor.F37F90;
      this.F9CAE0 = snsEditor.F9CAE0;
      FileStream output1 = File.Create(this.outDir + "F37F90.bin");
      BinaryWriter binaryWriter1 = new BinaryWriter((Stream) output1);
      binaryWriter1.Write(this.F37F90.ToArray(), 0, this.F37F90.Count);
      binaryWriter1.Close();
      output1.Close();
      FileStream output2 = File.Create(this.outDir + "F9CAE0.bin");
      BinaryWriter binaryWriter2 = new BinaryWriter((Stream) output2);
      binaryWriter2.Write(this.F9CAE0.ToArray(), 0, this.F9CAE0.Count);
      binaryWriter2.Close();
      output2.Close();
      this.romBuild.rom = this.rom;
      this.romBuild.populateEORPointers();
      this.romBuild.outDir = this.outDir;
      this.romBuild.insertDecompressedFile(this.outDir, "F9CAE0.bin", this.F9CAE0_location, this.FA3FD0_location - this.F9CAE0_location, true);
      this.romBuild.insertDecompressedFile(this.outDir, "F37F90.bin", this.F37F90_location, this.F9CAE0_location - this.F37F90_location, true);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      FileStream output3 = File.Create(this.inRom);
      BinaryWriter binaryWriter3 = new BinaryWriter((Stream) output3);
      binaryWriter3.Write(this.romBuild.rom);
      binaryWriter3.Close();
      output3.Close();
      this.reCRC();
      int num2 = (int) MessageBox.Show(this.inRom + " Updated");
      this.getEntryPoints();
      if (this.selectedFile == null)
        return;
      this.getLevelEntryPoints(this.selectedFile.sceneID);
      this.populateEntryData();
    }

    private void LevelViewer_MouseLeave(object sender, EventArgs e)
    {
      this.RotateSceneClick = false;
      this.sceneClick = false;
      this.disableAllSubModes();
    }

    private void objectsFound_lv_DoubleClick(object sender, EventArgs e) => this.Refresh();

    private void deleteLevelFiles()
    {
      string[] files = Directory.GetFiles(this.tmpDir);
      for (int index = 0; index < ((IEnumerable<string>) files).Count<string>(); ++index)
      {
        string fileName = Path.GetFileName(files[index]);
        foreach (SetupFile setupFile in this.sfl)
        {
          if (fileName == setupFile.modelAPointer.ToString("x") || fileName == setupFile.modelBPointer.ToString("x") || fileName == setupFile.pointer.ToString("x"))
            File.Delete(files[index]);
        }
      }
    }

    private void openSetupFile()
    {
      int num1 = (int) this.osff.ShowDialog();
      int selected = this.osff.selected;
      if (selected == -1)
        return;
      this.world.resetStack();
      try
      {
        this.deleteLevelFiles();
        this.replacedModel = "";
        this.baseLevel_tb.Text = "";
        this.replacedModelEx = "";
        this.extraModel_tb.Text = "";
      }
      catch
      {
      }
      this.save_tsmi.Enabled = true;
      this.saveAsRomToolStripMenuItem.Enabled = true;
      this.world.eraseDLs();
      this.world.objects.Clear();
      this.selectedFile = this.sfl[selected];
      if (!File.Exists(this.tmpDir + this.selectedFile.pointer.ToString("x")))
      {
        int num2 = (int) this.rom[this.selectedFile.pointer] * 16777216 + (int) this.rom[this.selectedFile.pointer + 1] * 65536 + (int) this.rom[this.selectedFile.pointer + 2] * 256 + (int) this.rom[this.selectedFile.pointer + 3];
        int compressedSize = (int) this.rom[this.selectedFile.pointer + 8] * 16777216 + (int) this.rom[this.selectedFile.pointer + 1 + 8] * 65536 + (int) this.rom[this.selectedFile.pointer + 2 + 8] * 256 + (int) this.rom[this.selectedFile.pointer + 3 + 8] - num2;
        byte[] numArray = new byte[compressedSize];
        int num3 = num2 + 68816;
        for (int index = 0; index < compressedSize; ++index)
          numArray[index] = this.rom[num3 + index];
        GECompression geCompression = new GECompression();
        byte[] Buffer = numArray;
        geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
        int fileSize = 0;
        byte[] buffer = geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
        FileStream output = File.Create(this.tmpDir + this.selectedFile.pointer.ToString("x"));
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(buffer, 0, fileSize);
        binaryWriter.Close();
        output.Close();
      }
      string file_ = this.tmpDir + this.selectedFile.pointer.ToString("x");
      this.world.file = this.selectedFile;
      this.world.ReadSetupFile(file_);
      this.save_tsmi.Enabled = true;
      this.saveSetupFileToolStripMenuItem.Enabled = true;
      this.loadSetupFileToolStripMenuItem.Enabled = true;
      this.listDec = this.world.GetListDec(this.tmpDir + this.selectedFile.pointer.ToString("x"));
      this.newStart = this.listDec + 4;
      this.world.RenderScene(this.replacedModel, this.replacedModelEx);
      this.world.renderSetup();
      this.world.renderPicking();
      this.world.resetPick();
      this.selectedFile = this.world.file;
      this.osff.selected = -1;
      this.world.core.SetView(this.LevelViewer.Height, this.LevelViewer.Width);
      this.GetFlagOffsetsForOpenLevel();
      this.BBCamera.Reset();
      this.zoomIn = false;
      this.zoomOut = false;
      this.left = false;
      this.right = false;
      this.newMouseX = 0;
      this.newMouseY = 0;
      this.oldMouseX = 0;
      this.oldMouseY = 0;
      if (this.selectedFile.modelBPointer == 0)
      {
        this.replacedModelEx = "";
        this.replaceModelEx_btn.Enabled = false;
      }
      else
        this.replaceModelEx_btn.Enabled = true;
      this.selectedFile.levelID = this.getLevelID(this.selectedFile.sceneID);
      this.ls = this.world.getLevelStats(this.selectedFile.levelID, this.selectedFile.pointer);
      this.getLevelEntryPoints(this.selectedFile.sceneID);
      this.populateEntryData();
      this.populateObjectData();
      this.eraseAll_btn.Visible = true;
      this.col_levelbounds_btn.Visible = true;
      this.bounds_gb.Visible = true;
      this.col_levelentries_btn.Visible = true;
      this.levelEntries_gb.Visible = true;
      this.col_objects_btn.Visible = true;
      this.objects_gb.Visible = true;
      this.col_structs_btn.Visible = true;
      this.structs_gb.Visible = true;
      this.minX_Bounds_tb.Text = this.world.file.bounds.smallX.ToString();
      this.minY_Bounds_tb.Text = this.world.file.bounds.smallY.ToString();
      this.minZ_Bounds_tb.Text = this.world.file.bounds.smallZ.ToString();
      this.maxX_Bounds_tb.Text = this.world.file.bounds.largeX.ToString();
      this.maxY_Bounds_tb.Text = this.world.file.bounds.largeY.ToString();
      this.maxZ_Bounds_tb.Text = this.world.file.bounds.largeZ.ToString();
      this.setCameraToStart();
      this.mode_cb.Enabled = true;
      this.Refresh();
    }

    public void populateEntryData()
    {
      this.levelEntries_dgv.Rows.Clear();
      this.levelEntries_dgv.Columns.Clear();
      this.levelEntries_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.levelEntries_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.levelEntries_dgv.AutoGenerateColumns = false;
      this.levelEntries_dgv.RowHeadersVisible = false;
      this.levelEntries_dgv.MultiSelect = false;
      for (int index = 0; index < this.levelEntries.Count<LevelEntryPoint>(); ++index)
        this.levelEntries[index].inuse = false;
      for (int index1 = 0; index1 < this.world.objects.Count<ObjectData>(); ++index1)
      {
        if (this.world.objects[index1].name.Contains("Entry Point") || this.world.objects[index1].name.Contains("Start Point"))
        {
          for (int index2 = 0; index2 < this.levelEntries.Count<LevelEntryPoint>(); ++index2)
          {
            if (this.levelEntries[index2].objectId == (int) this.world.objects[index1].objectID)
              this.levelEntries[index2].inuse = true;
          }
        }
      }
      DataGridViewColumnCollection columns1 = this.levelEntries_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "Object ID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn1.FillWeight = 25f;
      columns1.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewColumnCollection columns2 = this.levelEntries_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Entry ID";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn2.FillWeight = 25f;
      columns2.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewColumnCollection columns3 = this.levelEntries_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "Description";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn3.FillWeight = 25f;
      columns3.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewColumnCollection columns4 = this.levelEntries_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "In Use";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn4.FillWeight = 25f;
      columns4.Add((DataGridViewColumn) viewTextBoxColumn4);
      for (int index = 0; index < this.levelEntries.Count; ++index)
      {
        WarpLocation warpLocation = new WarpLocation(this.levelEntries[index].warp);
        string str = "N";
        if (this.levelEntries[index].inuse)
          str = "Y";
        this.levelEntries_dgv.Rows.Add((object) ("0x" + this.levelEntries[index].objectId.ToString("x")), (object) ("0x" + this.levelEntries[index].entry.ToString("x")), (object) warpLocation.name, (object) str);
      }
      for (int rowIndex = 0; rowIndex < this.levelEntries_dgv.Rows.Count; ++rowIndex)
        this.levelEntries_dgv.AutoResizeRow(rowIndex);
    }

    public void populateObjectData()
    {
      this.objects_dgv.Rows.Clear();
      this.objects_dgv.Columns.Clear();
      this.objects_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.objects_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.objects_dgv.AutoGenerateColumns = false;
      this.objects_dgv.RowHeadersVisible = false;
      this.objects_dgv.MultiSelect = false;
      DataGridViewColumnCollection columns1 = this.objects_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "REF";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn1.FillWeight = 25f;
      columns1.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewColumnCollection columns2 = this.objects_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Object Name";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn2.FillWeight = 25f;
      columns2.Add((DataGridViewColumn) viewTextBoxColumn2);
      DataGridViewColumnCollection columns3 = this.objects_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "X";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn3.FillWeight = 25f;
      columns3.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewColumnCollection columns4 = this.objects_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Y";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn4.FillWeight = 25f;
      columns4.Add((DataGridViewColumn) viewTextBoxColumn4);
      DataGridViewColumnCollection columns5 = this.objects_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn5.HeaderText = "Z";
      viewTextBoxColumn5.ReadOnly = true;
      viewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn5.FillWeight = 25f;
      columns5.Add((DataGridViewColumn) viewTextBoxColumn5);
      this.objects_dgv.Columns[0].Visible = false;
      for (int index = 0; index < this.world.objects.Count<ObjectData>(); ++index)
      {
        if (this.world.objects[index].name != "" && !this.world.objects[index].name.Contains("Camera"))
          this.objects_dgv.Rows.Add((object) index, (object) this.world.objects[index].name, (object) this.world.objects[index].locX, (object) this.world.objects[index].locY, (object) this.world.objects[index].locZ);
      }
      for (int rowIndex = 0; rowIndex < this.objects_dgv.Rows.Count; ++rowIndex)
        this.objects_dgv.AutoResizeRow(rowIndex);
      this.structs_dgv.Rows.Clear();
      this.structs_dgv.Columns.Clear();
      this.structs_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.structs_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.structs_dgv.AutoGenerateColumns = false;
      this.structs_dgv.RowHeadersVisible = false;
      this.structs_dgv.MultiSelect = false;
      DataGridViewColumnCollection columns6 = this.structs_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn6.HeaderText = "REF";
      viewTextBoxColumn6.ReadOnly = true;
      viewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn6.FillWeight = 25f;
      columns6.Add((DataGridViewColumn) viewTextBoxColumn6);
      DataGridViewColumnCollection columns7 = this.structs_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn7.HeaderText = "Object Name";
      viewTextBoxColumn7.ReadOnly = true;
      viewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn7.FillWeight = 25f;
      columns7.Add((DataGridViewColumn) viewTextBoxColumn7);
      DataGridViewColumnCollection columns8 = this.structs_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn8 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn8.HeaderText = "X";
      viewTextBoxColumn8.ReadOnly = true;
      viewTextBoxColumn8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn8.FillWeight = 25f;
      columns8.Add((DataGridViewColumn) viewTextBoxColumn8);
      DataGridViewColumnCollection columns9 = this.structs_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn9 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn9.HeaderText = "Y";
      viewTextBoxColumn9.ReadOnly = true;
      viewTextBoxColumn9.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn9.FillWeight = 25f;
      columns9.Add((DataGridViewColumn) viewTextBoxColumn9);
      DataGridViewColumnCollection columns10 = this.structs_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn10 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn10.HeaderText = "Z";
      viewTextBoxColumn10.ReadOnly = true;
      viewTextBoxColumn10.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn10.FillWeight = 25f;
      columns10.Add((DataGridViewColumn) viewTextBoxColumn10);
      this.structs_dgv.Columns[0].Visible = false;
      for (int index = 0; index < this.world.structs.Count<ObjectData>(); ++index)
      {
        if (this.world.structs[index].name != "" && !this.world.structs[index].name.Contains("Camera"))
          this.structs_dgv.Rows.Add((object) index, (object) this.world.structs[index].name, (object) this.world.structs[index].locX, (object) this.world.structs[index].locY, (object) this.world.structs[index].locZ);
      }
      for (int rowIndex = 0; rowIndex < this.structs_dgv.Rows.Count; ++rowIndex)
        this.structs_dgv.AutoResizeRow(rowIndex);
    }

    private string fileToString(byte[] file)
    {
      StringBuilder stringBuilder = new StringBuilder(((IEnumerable<byte>) file).Count<byte>() * 2);
      foreach (byte num in file)
        stringBuilder.AppendFormat("{0:x2}", (object) num);
      return stringBuilder.ToString();
    }

    private void getLevelEntryPoints(int sceneID)
    {
      this.levelEntries.Clear();
      for (int index = 0; index < this.entryPoints.Count<LevelEntryPoint>(); ++index)
      {
        if ((int) this.entryPoints[index].scene == sceneID)
          this.levelEntries.Add(this.entryPoints[index]);
      }
      for (int index = 0; index + 1 < this.levelEntries.Count; ++index)
      {
        if ((int) this.levelEntries[index].entry > (int) this.levelEntries[index + 1].entry)
        {
          LevelEntryPoint levelEntry = this.levelEntries[index];
          this.levelEntries[index] = this.levelEntries[index + 1];
          this.levelEntries[index + 1] = levelEntry;
          index = -1;
        }
      }
    }

    private void getEntryPoints()
    {
      Regex regex = new Regex("27BDFFE8AFBF0014AFA[\\dA-F]001[8C][\\dA-F]*?0C0C[\\dA-F][\\dA-F][\\dA-F][\\dA-F]2405([\\dA-F][\\dA-F])([\\dA-F][\\dA-F])8FBF001427BD001803E0000800000000", RegexOptions.IgnoreCase);
      List<uint> source = new List<uint>();
      int warp_ = -1;
      for (int index1 = 50160; index1 < 52392; index1 += 4)
      {
        ++warp_;
        uint pntr_ = (uint) ((int) this.F9CAE0[index1] * 16777216 + (int) this.F9CAE0[index1 + 1] * 65536 + (int) this.F9CAE0[index1 + 2] * 256) + (uint) this.F9CAE0[index1 + 3] - 2147483648U - 2650000U;
        bool flag = true;
        for (int index2 = 0; index2 < source.Count<uint>(); ++index2)
        {
          if ((int) source[index2] == (int) pntr_)
            flag = false;
        }
        if (flag)
        {
          try
          {
            source.Add(pntr_);
            byte[] file = new byte[200];
            for (int index3 = 0; index3 < 200 && (long) pntr_ + (long) index3 < (long) this.F37F90.Count<byte>(); ++index3)
              file[index3] = this.F37F90[(int) ((long) pntr_ + (long) index3)];
            string input = this.fileToString(file);
            MatchCollection matchCollection = regex.Matches(input);
            if (matchCollection.Count > 0)
            {
              Match match = matchCollection[0];
              if (match.Groups.Count == 3)
                this.entryPoints.Add(new LevelEntryPoint(Convert.ToByte(match.Groups[1].Value, 16), Convert.ToByte(match.Groups[2].Value, 16), (int) pntr_, index1, warp_));
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
    }

    public void setCameraToStart()
    {
      int maxValue = int.MaxValue;
      for (int index = 0; index < this.world.objects.Count; ++index)
      {
        ObjectData objectData = this.world.objects[index];
        if (objectData.name.Contains("Entry") && (int) objectData.objectID < maxValue)
          this.BBCamera.LookAt(new Vector3((float) objectData.locX, (float) objectData.locY, (float) objectData.locZ));
      }
      this.forceRedraw = true;
    }

    private void deleteSelected()
    {
      if (this.cameraMode)
      {
        this.world.DeleteSelectedObjects();
        this.world.resetPick();
        this.disableAllModes();
        this.cameraMode = true;
        this.world.InitGl();
        this.world.RenderCameraPicking();
        this.unlockEditSettings();
        this.world.pushSetupStack("CameraMode:Deleted Camera");
      }
      else
      {
        this.world.DeleteSelectedObjects();
        this.ls = this.world.getLevelStats(this.selectedFile.levelID, this.selectedFile.pointer);
        this.world.resetPick();
        this.disableAllModes();
        this.selectMode = true;
        this.world.InitGl();
        this.world.renderPicking();
        this.unlockEditSettings();
        this.world.pushSetupStack("SelectMode:Deleted Object");
      }
      this.populateEntryData();
      this.populateObjectData();
      this.forceRedraw = true;
      this.Refresh();
    }

    private void structsFound_lv_DoubleClick(object sender, EventArgs e) => this.Refresh();

    private void ChangeLM_Click(object sender, EventArgs e)
    {
      if (this.world.file != null)
      {
        this.world.RenderScene(this.replacedModel, this.replacedModelEx);
        this.selectedFile = this.world.file;
        this.forceRedraw = true;
        BoundingBox bounds = this.world.file.bounds;
        this.minX_Bounds_tb.Text = ((short) bounds.smallX).ToString();
        this.minY_Bounds_tb.Text = ((short) bounds.smallY).ToString();
        this.minZ_Bounds_tb.Text = ((short) bounds.smallZ).ToString();
        this.maxX_Bounds_tb.Text = ((short) bounds.largeX).ToString();
        this.maxY_Bounds_tb.Text = ((short) bounds.largeY).ToString();
        this.maxZ_Bounds_tb.Text = ((short) bounds.largeZ).ToString();
        this.Refresh();
      }
      else
      {
        int num = (int) MessageBox.Show("Please open a setup file first");
      }
    }

    private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
    {
      if (!(sender is ToolStripMenuItem toolStripMenuItem) || !(toolStripMenuItem.Owner is ContextMenuStrip owner))
        return;
      Control sourceControl = owner.SourceControl;
    }

    private void createItem_MouseClick(object sender, EventArgs e)
    {
      ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
      string name = "";
      if (toolStripMenuItem != null)
        name = toolStripMenuItem.Text;
      double[] world = this.world.ScreenToWorld(this.createPointX, this.createPointY, this.BBCamera);
      ObjectData o1 = toolStripMenuItem.Tag.ToString() == "struct" ? this.world.getStruct(name) : this.world.getObject(name);
      o1.locX = (short) world[0];
      o1.locY = (short) world[1];
      o1.locZ = (short) world[2];
      if (name == "Warp")
      {
        short specialScript_ = 20358;
        try
        {
          WarpDestinationForm warpDestinationForm = new WarpDestinationForm();
          int num = (int) warpDestinationForm.ShowDialog();
          WarpLocation warp = warpDestinationForm.warp;
          if (warp == null)
            return;
          o1 = new ObjectData((short) warp.id, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, specialScript_);
          this.world.FillObjectDetails(ref o1);
          if (o1.locY < (short) 0 && o1.locY > (short) -4)
            o1.locY = (short) 0;
          this.world.AddObj(o1);
          this.world.RenderObjects();
          this.forceRedraw = true;
          return;
        }
        catch
        {
        }
      }
      if (name == "Create Camera Trigger")
        o1 = new ObjectData((short) 0, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, (short) -110);
      if (name == "Sound Spawner: Waterfall")
        o1 = new ObjectData((short) 651, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 1, (short) 6412);
      if (name == "Sound Spawner: Boiling Water")
        o1 = new ObjectData((short) 651, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 2, (short) 6412);
      if (toolStripMenuItem.Text == "Enemy Boundary")
        o1 = new ObjectData((short) 0, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, (short) -114);
      if (toolStripMenuItem.Text == "Magic Boundary")
        o1 = new ObjectData((short) 76, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, (short) -1528);
      if (name == "Running Shoes")
      {
        o1.obj13 = (byte) 128;
        o1.rot = (short) 22;
      }
      if (name == "Wading Boots")
        o1.rot = (short) 20;
      if (o1.locY < (short) 0 && o1.locY > (short) -4)
        o1.locY = (short) 0;
      if (name.Contains("Climbable"))
      {
        if (name.Contains("SM"))
          o1 = this.world.getStruct("SM Tree");
        if (name.Contains("TTC"))
          o1 = this.world.getStruct("TTC Tree");
        if (name.Contains("GV"))
          o1 = this.world.getStruct("GV Tree");
        if (name.Contains("MM"))
          o1 = this.world.getStruct("MM Tree");
        ObjectData o2 = new ObjectData((short) 38, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, (short) 6412);
        this.world.FillObjectDetails(ref o2);
        this.world.AddObj(o2);
        ObjectData o3 = new ObjectData((short) 40, 0, (short) world[0], (short) (world[1] + 375.0), (short) world[2], (short) 0, (short) 100, (short) 6412);
        this.world.FillObjectDetails(ref o3);
        this.world.AddObj(o3);
        o1.locX = (short) world[0];
        o1.locY = (short) world[1];
        o1.locZ = (short) world[2];
      }
      if (name.Equals("Conga"))
      {
        ObjectData o4 = new ObjectData((short) 336, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, (short) 25612);
        this.world.FillObjectDetails(ref o4);
        this.world.AddObj(o4);
      }
      if (name.Contains("Entry Point"))
      {
        ObjectData data_ = this.world.getObject("Camera Entry" + name.Replace("Entry Point", ""));
        data_.locX = (short) world[0];
        data_.locY = (short) world[1];
        data_.locZ = (short) world[2];
        this.world.AddObj(data_);
      }
      if (name == "Jiggy")
      {
        int jiggyOffset = this.jiggyOffset;
        while (this.world.usedJiggyFlags.Contains(jiggyOffset))
          ++jiggyOffset;
        this.world.usedJiggyFlags.Add(jiggyOffset);
        o1.flag = jiggyOffset;
        short specialScript_ = 20628;
        this.world.AddObj(new ObjectData((short) jiggyOffset, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, specialScript_)
        {
          name = "Jiggy Flag"
        });
      }
      if (name == "Empty Honeycomb")
      {
        int honeyCombOffset = this.honeyCombOffset;
        while (this.world.usedHCFlags.Contains(honeyCombOffset))
          ++honeyCombOffset;
        this.world.usedHCFlags.Add(honeyCombOffset);
        o1.flag = honeyCombOffset;
        short specialScript_ = 17684;
        this.world.AddObj(new ObjectData((short) honeyCombOffset, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, specialScript_)
        {
          name = "Empty Honeycomb Flag"
        });
      }
      if (name == "Mumbo Token")
      {
        int mumboTokenOffset = this.mumboTokenOffset;
        while (this.world.usedMTFlags.Contains(mumboTokenOffset))
          ++mumboTokenOffset;
        this.world.usedMTFlags.Add(mumboTokenOffset);
        o1.flag = mumboTokenOffset;
        short specialScript_ = 16276;
        this.world.AddObj(new ObjectData((short) mumboTokenOffset, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, specialScript_)
        {
          name = "Mumbo Token Flag"
        });
      }
      if (name.Contains("Witch Switch") && !name.Contains("Jiggy"))
      {
        short specialScript_ = 6412;
        short objectID_ = 261;
        if (name.Contains("TTC"))
          objectID_ = (short) 117;
        if (name.Contains("MM"))
          objectID_ = (short) 118;
        if (name.Contains("FP") || name.Contains("CCW"))
          objectID_ = (short) 262;
        this.world.AddObj(new ObjectData(objectID_, 0, (short) world[0], (short) world[1], (short) world[2], (short) 0, (short) 100, specialScript_));
      }
      if (o1.locY < (short) 0 && o1.locY > (short) -4)
        o1.locY = (short) 0;
      if (o1.specialScript == (short) 0)
        this.world.AddStruct(o1);
      else
        this.world.AddObj(o1);
      this.world.RenderStructs();
      this.world.RenderObjects();
      this.forceRedraw = true;
      if (o1.cameraID != -1 && this.world.getCameraDesc(o1.cameraID) != "")
        this.world.AddCamera(new CameraObject((short) o1.cameraID, (float) world[0], (float) world[1] + 256f, (float) world[2], 0.0f, 0.0f, 0.0f, 2));
      this.world.renderSetup();
      this.world.RenderCameras();
      this.ls = this.world.getLevelStats(this.selectedFile.levelID, this.selectedFile.pointer);
      this.populateEntryData();
      this.populateObjectData();
      this.forceRedraw = true;
      this.world.pushSetupStack("CreateMode: Added Object");
    }

    private void CamSpeed_tb_Scroll(object sender, EventArgs e) => this.BBCamera.MovementSpeed = (float) (this.CamSpeed_tb.Value * 2);

    private void LevelViewer_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.rectSelect)
      {
        if (this.frameRect.Width == e.X - this.startPoint.X && this.frameRect.Height == e.Y + this.LevelViewer.Location.Y - this.startPoint.Y)
          return;
        ControlPaint.DrawReversibleFrame(this.frameRect, Color.Black, FrameStyle.Dashed);
        this.frameRect.Width = e.X - this.startPoint.X;
        this.frameRect.Height = e.Y + this.LevelViewer.Location.Y - this.startPoint.Y;
        ControlPaint.DrawReversibleFrame(this.frameRect, Color.Black, FrameStyle.Dashed);
      }
      else
      {
        if (this.rectSelectMode)
          return;
        if (this.movingObj || this.movingNode)
        {
          double[] world = this.world.ScreenToWorld(e.X - this.LevelViewer.Location.X, e.Y, this.BBCamera);
          if (!this.cameraMode && !this.world.pathMode)
            this.world.updateLocationForSelectedObjects((short) world[0], (short) world[1], (short) world[2], this.xToggle, this.yToggle, this.zToggle, Convert.ToInt16(this.yOffset_tb.Text));
          else if (this.world.pathMode)
            this.world.updateNodeLocation((short) world[0], (short) world[1], (short) world[2], this.xToggle, this.yToggle, this.zToggle, Convert.ToInt16(this.yOffset_tb.Text));
          else
            this.world.updateCameraLocation((float) (short) world[0], (float) ((int) (short) world[1] + (int) Convert.ToInt16(this.yOffset_tb.Text)), (float) (short) world[2], this.camXToggle, this.camYToggle, this.camZToggle);
          this.forceRedraw = true;
          this.updateEditInfo();
        }
        if (this.scalingObj)
        {
          this.newEditX = e.X;
          this.newEditY = e.Y;
          this.world.updateScaleForSelectedObjects((short) ((this.oldEditY - this.newEditY) * 2));
          this.oldEditX = this.newEditX;
          this.oldEditY = this.newEditY;
          this.updateEditInfo();
        }
        if (!this.rotatingObj)
          return;
        this.newEditX = e.X;
        this.newEditY = e.Y;
        int num = this.newEditX - this.oldEditX;
        if (!this.cameraMode)
        {
          this.world.updateRotateForSelectedObjects((short) num);
        }
        else
        {
          if (this.yawMode)
            this.world.updateCameraYaw((float) (short) num);
          if (this.pitchMode)
          {
            this.newEditY = e.Y;
            this.world.updateCameraPitch((float) (short) ((this.oldEditY - this.newEditY) * 2));
          }
          if (this.rollMode)
            this.world.updateCameraRoll((float) (short) num);
        }
        this.oldEditX = this.newEditX;
        this.oldEditY = this.newEditY;
        this.updateEditInfo();
      }
    }

    private void LevelViewer_MouseDown(object sender, MouseEventArgs e)
    {
      this.Focus();
      Mode selectedIndex = (Mode) this.mode_cb.SelectedIndex;
      this.sceneClick = true;
      this.forceRedraw = true;
      if (e.Button == MouseButtons.Right)
      {
        switch (selectedIndex)
        {
          case Mode.Create:
            this.objectMenu.Show(e.X + this.Location.X, e.Y + this.Location.Y);
            this.createPointX = e.X - this.LevelViewer.Location.X;
            this.createPointY = e.Y;
            return;
          case Mode.Camera:
            if (this.world.hasSelectedCamera())
            {
              if (this.rotateMode || this.yawMode || this.pitchMode || this.rollMode)
                this.rotatingObj = true;
              if (this.camMoveMode)
              {
                this.movingObj = true;
                break;
              }
              break;
            }
            break;
          default:
            if (this.world.pathMode)
            {
              this.oldEditY = e.Y;
              this.oldEditX = e.X;
              if (this.nodeMoveMode)
              {
                this.movingNode = true;
                break;
              }
              break;
            }
            if (this.world.hasSelectedObjects())
            {
              this.oldEditY = e.Y;
              this.oldEditX = e.X;
              if (this.moveMode)
                this.movingObj = true;
              if (this.rotateMode || this.yawMode || this.pitchMode || this.rollMode)
                this.rotatingObj = true;
              if (this.scaleMode)
                this.scalingObj = true;
              if (this.duplicateMode)
              {
                this.Duplicate(this.oldEditX, this.oldEditY);
                break;
              }
              break;
            }
            this.movingObj = false;
            this.rotatingObj = false;
            this.scalingObj = false;
            this.movingNode = false;
            break;
        }
        if (selectedIndex == Mode.Camera && !this.movingObj && !this.yawMode && !this.rollMode && !this.pitchMode)
        {
          this.world.pickCamera(e.X, e.Y, this.BBCamera);
          this.unlockEditSettings();
          if (!this.world.hasSelectedCamera())
          {
            ContextMenuStrip cameraMenu = this.cameraMenu;
            int x1 = e.X + this.Location.X;
            int num = e.Y + this.Location.Y;
            Point location = this.LevelViewer.Location;
            int y1 = location.Y;
            int y2 = num + y1;
            cameraMenu.Show(x1, y2);
            int x2 = e.X;
            location = this.LevelViewer.Location;
            int x3 = location.X;
            this.createPointX = x2 - x3;
            this.createPointY = e.Y;
          }
        }
        else if (this.world.pathMode && !this.movingNode)
        {
          this.hidePathButtons();
          this.startNewPath_btn.Visible = true;
          this.rectSelect_btn.Enabled = false;
          if (this.world.pmode == PathMode.Assign)
          {
            this.world.pickObjectForPath(e.X, e.Y, this.BBCamera);
            this.assignObject_btn.BackColor = this.inactive;
            this.forceRedraw = true;
          }
          else if (this.world.pmode == PathMode.Link)
          {
            this.createPointX = e.X - this.LevelViewer.Location.X;
            this.createPointY = e.Y;
            if (this.world.linkNode(this.createPointX, this.createPointY, this.BBCamera))
            {
              this.world.pmode = PathMode.None;
              this.linkMode_btn.BackColor = this.inactive;
              this.world.pushSetupStack("PathMode: Linked Node");
            }
            this.forceRedraw = true;
          }
          else if (this.world.pmode == PathMode.CreatePath || this.world.pmode == PathMode.CreateNode)
          {
            this.createPointX = e.X - this.LevelViewer.Location.X;
            this.createPointY = e.Y;
            double[] world = this.world.ScreenToWorld(this.createPointX, this.createPointY, this.BBCamera);
            if (this.world.pmode == PathMode.CreatePath)
            {
              this.world.pmode = PathMode.None;
              this.startNewPath_btn.BackColor = this.inactive;
              int num1 = this.world.createNewPath(new ObjectData((short) 0, 0, (short) world[0], (short) (world[1] + (double) Convert.ToInt16(this.yOffset_tb.Text)), (short) world[2], (short) 0, (short) 100, (short) 6416)) ? 1 : 0;
              this.unlockPathSettings();
              if (num1 == 0)
              {
                int num2 = (int) MessageBox.Show("All paths used BB can't calculate any more");
              }
              this.world.pushSetupStack("PathMode:Created Path");
            }
            if (this.world.pmode == PathMode.CreateNode)
            {
              int num3 = this.world.addNode(new ObjectData((short) 0, 0, (short) world[0], (short) (world[1] + (double) Convert.ToInt16(this.yOffset_tb.Text)), (short) world[2], (short) 0, (short) 100, (short) 6416)) ? 1 : 0;
              this.unlockPathSettings();
              if (num3 == 0)
              {
                int num4 = (int) MessageBox.Show("All paths used BB can't calculate any more");
              }
              this.world.pushSetupStack("PathMode:Created Node");
            }
            this.forceRedraw = true;
          }
          else
          {
            this.createPointX = e.X - this.LevelViewer.Location.X;
            this.createPointY = e.Y;
            if (this.world.selectedPath == -1)
              this.world.pickPath(e.X, e.Y, this.multiselect, this.BBCamera);
            else
              this.world.pickPathNode(e.X, e.Y, this.multiselect, this.BBCamera);
          }
          this.world.InitGl();
          this.unlockPathSettings();
          this.updateEditInfo();
        }
        else if (this.selectMode && !this.duplicateMode && !this.moveMode && !this.rotateMode)
        {
          if (!this.scaleMode)
          {
            try
            {
              this.world.core.ClearScreenAndLoadIdentity();
              Gl.glPushMatrix();
              Gl.glLoadMatrixf(this.BBCamera.GetWorldToViewMatrix());
              this.world.pickColorOBJ(e.X, e.Y, this.multiselect);
              Gl.glPopMatrix();
              this.world.InitGl();
              if (this.world.singleObjectSelected())
              {
                this.unlockEditSettings();
                ObjectData selectedObject = this.world.getSelectedObject();
                if (this.enableDebug)
                {
                  int num = (int) MessageBox.Show("Object Selected - " + selectedObject.name);
                }
                if (selectedObject.objectID == (short) 1 || selectedObject.objectID == (short) 45 || selectedObject.objectID == (short) 81 || selectedObject.objectID == (short) 82 || selectedObject.objectID == (short) 5696 || selectedObject.objectID == (short) 5712 || selectedObject.objectID == (short) 5728 || selectedObject.name == "Note" || selectedObject.name == "warp" || selectedObject.name == "Warp To - Start of Level" || selectedObject.objectID == (short) 389 || selectedObject.objectID == (short) 395 || selectedObject.objectID == (short) 405 || selectedObject.objectID == (short) 414 || selectedObject.objectID == (short) 297 || selectedObject.objectID == (short) 224 || selectedObject.objectID == (short) 511 || selectedObject.objectID == (short) 512 || selectedObject.objectID == (short) 880 || selectedObject.objectID == (short) 73)
                  this.LockScale();
                if (selectedObject.specialScript == (short) 0 && (selectedObject.objectID == (short) 3424 || selectedObject.objectID == (short) 1125 || selectedObject.objectID == (short) 1127 || selectedObject.objectID == (short) 1136 || selectedObject.objectID == (short) 1280 || selectedObject.objectID == (short) 5696 || selectedObject.objectID == (short) 5616 || selectedObject.objectID == (short) 224 || selectedObject.objectID == (short) 5712))
                  this.LockScale();
                if (selectedObject.name == "Running Shoes" || selectedObject.name == "Wading Boots")
                  this.rotByte_lbl.Text = "Timer";
                else
                  this.rotByte_lbl.Text = "Rotation";
              }
              else if (this.world.hasSelectedObjects())
              {
                this.unlockBasicEditSettings();
              }
              else
              {
                this.disableAllModes();
                this.selectMode = true;
                this.mode_cb.SelectedIndex = 0;
                this.world.resetPick();
                this.world.InitGl();
                this.unlockEditSettings();
              }
              this.world.renderPicking();
            }
            catch
            {
              if (!this.multiselect)
              {
                this.disableAllModes();
                this.selectMode = true;
                this.mode_cb.SelectedIndex = 0;
                this.world.resetPick();
                this.world.InitGl();
                this.world.renderPicking();
                this.unlockEditSettings();
              }
            }
          }
        }
      }
      if (e.Button != MouseButtons.Left)
        return;
      if (this.rectSelectMode)
      {
        this.rectSelect = true;
        this.startPoint = new Point(e.X, e.Y + this.LevelViewer.Location.Y);
        this.frameRect = new Rectangle(this.PointToScreen(this.startPoint), Size.Empty);
        this.sceneClick = false;
        this.forceRedraw = false;
      }
      else
        this.RotateSceneClick = true;
    }

    private void LevelViewer_MouseUp(object sender, MouseEventArgs e)
    {
      this.sceneClick = false;
      if (e.Button == MouseButtons.Left)
      {
        this.RotateSceneClick = false;
        if (!this.rectSelect)
          return;
        this.rectSelect = false;
        ControlPaint.DrawReversibleFrame(this.frameRect, Color.Black, FrameStyle.Dashed);
        Point p1 = new Point(this.startPoint.X, this.startPoint.Y - this.LevelViewer.Location.Y);
        Point p2 = new Point(this.startPoint.X + this.frameRect.Width, this.startPoint.Y - this.LevelViewer.Location.Y + this.frameRect.Height);
        if (p2.X < p1.X)
        {
          int x = p2.X;
          p2.X = p1.X;
          p1.X = x;
        }
        if (p2.Y < p1.Y)
        {
          int y = p2.Y;
          p2.Y = p1.Y;
          p1.Y = y;
        }
        this.world.InitGl();
        this.world.core.ClearScreenAndLoadIdentity();
        Gl.glPushMatrix();
        Gl.glLoadMatrixf(this.BBCamera.GetWorldToViewMatrix());
        this.world.pickRectSelect(p1, p2, (Mode) this.mode_cb.SelectedIndex);
        Gl.glPopMatrix();
        this.frameRect = Rectangle.Empty;
        this.startPoint = Point.Empty;
        this.world.InitGl();
        this.rectSelectMode = false;
        this.rectSelect = false;
        this.rectSelect_btn.BackColor = this.inactive;
        if (this.world.hasSelectedObjects())
          this.unlockBasicEditSettings();
        this.forceRedraw = true;
      }
      else
      {
        if (this.scalingObj || this.movingObj || this.rotatingObj || this.duplicatingObj || this.movingNode)
          this.world.pushSetupStack("SelectMode:Updated Object");
        this.disableAllSubModes();
      }
    }

    private void LevelViewer_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Alt)
        return;
      switch (e.KeyCode)
      {
        case Keys.ShiftKey:
        case Keys.Shift:
          this.multiselect = true;
          break;
        case Keys.A:
          this.right = true;
          break;
        case Keys.D:
          this.left = true;
          break;
        case Keys.E:
          this.zoomOut = true;
          break;
        case Keys.Q:
          this.zoomIn = true;
          break;
        case Keys.S:
          this.zoomOut = true;
          break;
        case Keys.W:
          this.zoomIn = true;
          break;
      }
    }

    private void LevelViewer_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.ShiftKey:
        case Keys.Shift:
          this.multiselect = false;
          break;
        case Keys.A:
          this.right = false;
          break;
        case Keys.D:
          this.left = false;
          break;
        case Keys.E:
          this.zoomOut = false;
          break;
        case Keys.Q:
          this.zoomIn = false;
          break;
        case Keys.S:
          this.zoomOut = false;
          break;
        case Keys.W:
          this.zoomIn = false;
          break;
      }
    }

    public void importPrep()
    {
      this.disableAllModes();
      this.selectMode = true;
      this.mode_cb.SelectedIndex = 0;
      this.world.resetPick();
      this.world.InitGl();
      this.world.renderSetup();
      this.world.renderPicking();
      this.unlockEditSettings();
    }

    private void ShowGlobalPathButtons() => this.startNewPath_btn.Visible = true;

    private void hidePathButtons()
    {
      this.HideGlobalPathButtons();
      this.HidePathButtons();
      this.HideNodeButtons();
    }

    private void HideGlobalPathButtons() => this.startNewPath_btn.Visible = false;

    private void ShowPathButtons()
    {
      this.addNode_btn.Visible = true;
      this.addControllerNode_btn.Visible = true;
      this.deselectPath_btn.Visible = true;
      this.deletePath_btn.Visible = true;
    }

    private void HidePathButtons()
    {
      this.addNode_btn.Visible = false;
      this.addControllerNode_btn.Visible = false;
      this.deselectPath_btn.Visible = false;
      this.deletePath_btn.Visible = false;
    }

    private void ShowNodeButtons(bool pathController)
    {
      this.assignObject_btn.Visible = !pathController;
      this.moveNode_btn.Visible = !pathController;
      this.linkMode_btn.Visible = true;
      this.endNode_btn.Visible = true;
      this.removeNode_btn.Visible = true;
      this.deselectPath_btn.Visible = true;
      this.removeNode_btn.Text = pathController ? "Delete Controller" : "Delete Node";
    }

    private void ShowMultiNodeButtons()
    {
      this.moveNode_btn.Visible = true;
      this.removeNode_btn.Visible = true;
      this.deselectPath_btn.Visible = true;
      this.removeNode_btn.Text = "Delete Nodes";
    }

    private void HideNodeButtons()
    {
      this.assignObject_btn.Visible = false;
      this.moveNode_btn.Visible = false;
      this.linkMode_btn.Visible = false;
      this.endNode_btn.Visible = false;
      this.removeNode_btn.Visible = false;
      this.deselectPath_btn.Visible = false;
    }

    private void unlockPathSettings()
    {
      this.processControllerEvents = false;
      int num1 = 630;
      int num2 = 500;
      int num3 = 300;
      this.flowLayoutPanel1.SuspendLayout();
      this.hidePathButtons();
      this.path_gb.Visible = false;
      this.col_selPath_btn.Visible = false;
      this.pathObject_gb.Visible = false;
      this.nodeID_gb.Visible = false;
      this.nodeProperties_gb.Visible = false;
      this.sNode_gb.Visible = false;
      this.rectSelect_btn.Enabled = false;
      if (this.world.selectedPath == -1)
      {
        this.ShowGlobalPathButtons();
        this.processControllerEvents = true;
        this.flowLayoutPanel1.ResumeLayout();
        this.flowLayoutPanel1.PerformLayout();
        this.flowLayoutPanel1.Refresh();
      }
      else
      {
        if (this.world.hasSelectedNodes())
        {
          if (this.world.singleNodeSelected())
          {
            if (this.world.getSelectedNodeType() == ObjectType.Path)
            {
              this.rectSelect_btn.Enabled = true;
              this.ShowNodeButtons(false);
            }
            else
              this.ShowNodeButtons(true);
          }
          else
            this.ShowMultiNodeButtons();
        }
        else
          this.ShowPathButtons();
        if (this.world.selectedPath != -1)
        {
          this.path_gb.Height = num3;
          this.path_dgv.Rows.Clear();
          this.path_dgv.Columns.Clear();
          this.path_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          this.path_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
          this.path_dgv.AutoGenerateColumns = false;
          this.path_dgv.RowHeadersVisible = false;
          this.path_dgv.MultiSelect = false;
          this.pathControllers_dgv.Rows.Clear();
          this.pathControllers_dgv.Columns.Clear();
          this.pathControllers_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
          this.pathControllers_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
          this.pathControllers_dgv.AutoGenerateColumns = false;
          this.pathControllers_dgv.RowHeadersVisible = false;
          this.pathControllers_dgv.MultiSelect = false;
          DataGridViewColumnCollection columns1 = this.path_dgv.Columns;
          DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn1.HeaderText = "REF";
          viewTextBoxColumn1.ReadOnly = true;
          viewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          viewTextBoxColumn1.FillWeight = 25f;
          columns1.Add((DataGridViewColumn) viewTextBoxColumn1);
          DataGridViewColumnCollection columns2 = this.path_dgv.Columns;
          DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn2.HeaderText = "ID";
          viewTextBoxColumn2.ReadOnly = true;
          viewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          viewTextBoxColumn2.FillWeight = 25f;
          columns2.Add((DataGridViewColumn) viewTextBoxColumn2);
          DataGridViewColumnCollection columns3 = this.path_dgv.Columns;
          DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn3.HeaderText = "TO";
          viewTextBoxColumn3.ReadOnly = true;
          viewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          viewTextBoxColumn3.FillWeight = 25f;
          columns3.Add((DataGridViewColumn) viewTextBoxColumn3);
          this.path_dgv.Columns[0].Visible = false;
          DataGridViewColumnCollection columns4 = this.pathControllers_dgv.Columns;
          DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn4.HeaderText = "REF";
          viewTextBoxColumn4.ReadOnly = true;
          viewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          viewTextBoxColumn4.FillWeight = 25f;
          columns4.Add((DataGridViewColumn) viewTextBoxColumn4);
          DataGridViewColumnCollection columns5 = this.pathControllers_dgv.Columns;
          DataGridViewTextBoxColumn viewTextBoxColumn5 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn5.HeaderText = "Act %";
          viewTextBoxColumn5.ReadOnly = true;
          viewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          viewTextBoxColumn5.FillWeight = 25f;
          columns5.Add((DataGridViewColumn) viewTextBoxColumn5);
          DataGridViewColumnCollection columns6 = this.pathControllers_dgv.Columns;
          DataGridViewTextBoxColumn viewTextBoxColumn6 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn6.HeaderText = "ID";
          viewTextBoxColumn6.ReadOnly = true;
          viewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          viewTextBoxColumn6.FillWeight = 25f;
          columns6.Add((DataGridViewColumn) viewTextBoxColumn6);
          DataGridViewColumnCollection columns7 = this.pathControllers_dgv.Columns;
          DataGridViewTextBoxColumn viewTextBoxColumn7 = new DataGridViewTextBoxColumn();
          viewTextBoxColumn7.HeaderText = "TO";
          viewTextBoxColumn7.ReadOnly = true;
          viewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          viewTextBoxColumn7.FillWeight = 25f;
          columns7.Add((DataGridViewColumn) viewTextBoxColumn7);
          this.pathControllers_dgv.Columns[0].Visible = false;
          int num4 = 0;
          foreach (ObjectData node in this.world.paths[this.world.selectedPath].nodes)
          {
            if (node.type == ObjectType.Path)
            {
              this.path_dgv.Rows.Add((object) num4, (object) node.uid.ToString("x"), (object) node.nodeOutUID.ToString("x"));
              if (node.node_in || node.node_out)
                ;
            }
            else
            {
              this.pathControllers_dgv.Rows.Add((object) num4, (object) node.activationPercent.ToString(), (object) node.uid.ToString("x"), (object) node.nodeOutUID.ToString("x"));
              if (!node.node_in)
              {
                int num5 = node.node_out ? 1 : 0;
              }
            }
            ++num4;
          }
          for (int rowIndex = 0; rowIndex < this.path_dgv.Rows.Count; ++rowIndex)
            this.path_dgv.AutoResizeRow(rowIndex);
          if (this.world.paths[this.world.selectedPath].pathObject != -1)
          {
            this.pathObject_gb.Text = this.world.objects[this.world.paths[this.world.selectedPath].pathObject].name;
            this.objectNode_tb.Text = this.world.objects[this.world.paths[this.world.selectedPath].pathObject].obj18.ToString("x");
            this.pathObject_gb.Visible = true;
          }
          this.path_dgv.ClearSelection();
          this.pathControllers_dgv.ClearSelection();
          if (this.world.singleNodeSelected())
          {
            this.nodeID_gb.Visible = true;
            this.nodeProperties_gb.Visible = false;
            this.sNode_gb.Visible = false;
            this.path_gb.Height = num2;
            if (this.world.getSelectedNodeType() == ObjectType.SPath)
            {
              this.sNode_gb.Visible = true;
              this.sNode_gb.Location = new Point(this.sNode_gb.Location.X, 375);
              this.path_gb.Height = num1;
            }
            else
              this.nodeProperties_gb.Visible = true;
            try
            {
              if (this.world.getSelectedNodeType() == ObjectType.Path)
              {
                int selectedNode = this.world.getSelectedNode();
                for (int index = 0; index < this.path_dgv.Rows.Count; ++index)
                {
                  if ((int) this.path_dgv.Rows[index].Cells[0].Value == selectedNode)
                    this.path_dgv.Rows[index].Selected = true;
                }
              }
              else
              {
                int selectedNode = this.world.getSelectedNode();
                for (int index = 0; index < this.pathControllers_dgv.Rows.Count; ++index)
                {
                  if ((int) this.pathControllers_dgv.Rows[index].Cells[0].Value == selectedNode)
                    this.pathControllers_dgv.Rows[index].Selected = true;
                }
              }
            }
            catch
            {
            }
          }
          this.col_selPath_btn.Visible = true;
          this.path_gb.Visible = true;
        }
        this.processControllerEvents = true;
        this.flowLayoutPanel1.ResumeLayout();
        this.flowLayoutPanel1.PerformLayout();
        this.flowLayoutPanel1.Refresh();
      }
    }

    public void resetEditSettings()
    {
      this.updateName_tb.Clear();
      this.flag_tb.Clear();
      this.updateRad_tb.Clear();
      this.updateB10_tb.Clear();
      this.updateB11_tb.Clear();
      this.updateB13_tb.Clear();
      this.updateB16_tb.Clear();
      this.updateB17_tb.Clear();
      this.updateB18_tb.Clear();
      this.updateRot_tb.Clear();
      this.updateScript_tb.Clear();
      this.updateSize_tb.Clear();
      this.updateX_tb.Clear();
      this.updateY_tb.Clear();
      this.updateZ_tb.Clear();
      this.cam3A5_tb.Clear();
      this.camAccel_tb.Clear();
      this.camCDist_tb.Clear();
      this.camFDist_tb.Clear();
      this.camHSpeed_tb.Clear();
      this.camID_tb.Clear();
      this.camPitch_tb.Clear();
      this.camRoll_tb.Clear();
      this.camRotation_tb.Clear();
      this.camVSpeed_tb.Clear();
      this.camX_tb.Clear();
      this.camY_tb.Clear();
      this.camZ_tb.Clear();
    }

    public void unlockEditSettings()
    {
      this.resetEditSettings();
      this.flowLayoutPanel1.SuspendLayout();
      this.unlockedEditSettings = false;
      this.col_cam_btn.Visible = false;
      this.col_obj_details_btn.Visible = false;
      this.textUpdate_gb.Visible = false;
      this.cam3_gb.Visible = false;
      this.path_gb.Visible = false;
      this.hideCamButtons();
      this.hideObjectButtons();
      this.hidePathButtons();
      if (this.cameraMode && this.world.hasSelectedCamera())
      {
        this.showCamButtons();
        this.col_cam_btn.Visible = true;
        this.cam3_gb.Visible = true;
        CameraObject selectedCamera = this.world.getSelectedCamera();
        this.camHSpeed_tb.Enabled = false;
        this.camVSpeed_tb.Enabled = false;
        this.camRotation_tb.Enabled = false;
        this.camAccel_tb.Enabled = false;
        this.cam3A5_tb.Enabled = false;
        this.camCDist_tb.Enabled = false;
        this.camFDist_tb.Enabled = false;
        this.camX_tb.Text = "";
        this.camY_tb.Text = "";
        this.camZ_tb.Text = "";
        this.camHSpeed_tb.Text = "";
        this.camVSpeed_tb.Text = "";
        this.camRotation_tb.Text = "";
        this.camAccel_tb.Text = "";
        this.camPitch_tb.Text = "";
        this.camYaw_tb.Text = "";
        this.camRoll_tb.Text = "";
        this.camCDist_tb.Text = "";
        this.camFDist_tb.Text = "";
        if (selectedCamera.type == 2)
        {
          this.camID_tb.Text = selectedCamera.id.ToString("x");
          this.camX_tb.Text = selectedCamera.x.ToString();
          this.camY_tb.Text = selectedCamera.y.ToString();
          this.camZ_tb.Text = selectedCamera.z.ToString();
          this.camYaw_tb.Text = selectedCamera.yaw.ToString();
          this.camPitch_tb.Text = selectedCamera.pitch.ToString();
          this.camRoll_tb.Text = selectedCamera.roll.ToString();
        }
        if (selectedCamera.type == 3 || selectedCamera.type == 1)
        {
          this.camHSpeed_tb.Enabled = true;
          this.camVSpeed_tb.Enabled = true;
          this.camRotation_tb.Enabled = true;
          this.camAccel_tb.Enabled = true;
          this.cam3A5_tb.Enabled = true;
          this.camID_tb.Text = selectedCamera.id.ToString("x");
          this.camX_tb.Text = selectedCamera.x.ToString();
          this.camY_tb.Text = selectedCamera.y.ToString();
          this.camZ_tb.Text = selectedCamera.z.ToString();
          this.camHSpeed_tb.Text = selectedCamera.camHSpeed.ToString();
          this.camVSpeed_tb.Text = selectedCamera.camVSpeed.ToString();
          this.camRotation_tb.Text = selectedCamera.camRotation.ToString();
          this.camAccel_tb.Text = selectedCamera.camAccel.ToString();
          this.camPitch_tb.Text = selectedCamera.pitch3.ToString();
          this.camYaw_tb.Text = selectedCamera.yaw3.ToString();
          this.camRoll_tb.Text = selectedCamera.roll3.ToString();
          this.cam3A5_tb.Text = selectedCamera.Type3Arg5.ToString("x");
          if (selectedCamera.type == 3)
          {
            this.camCDist_tb.Text = selectedCamera.camCDist.ToString();
            this.camFDist_tb.Text = selectedCamera.camFDist.ToString();
            this.camCDist_tb.Enabled = true;
            this.camFDist_tb.Enabled = true;
          }
          this.cam_pitch_btn.Visible = false;
          this.cam_yaw_btn.Visible = false;
          this.cam_roll_btn.Visible = false;
        }
        this.unlockedEditSettings = true;
      }
      else
      {
        this.textUpdate_gb.Visible = true;
        if (this.world.hasSelectedObjects())
          this.showObjectButtons();
        if (this.world.singleObjectSelected())
        {
          ObjectData selectedObject = this.world.getSelectedObject();
          this.col_obj_details_btn.Visible = true;
          this.unlockedEditSettings = true;
          this.textUpdate_gb.Visible = true;
          this.updateScript_tb.Visible = true;
          this.script_lbl.Visible = true;
          this.updateName_tb.Enabled = false;
          this.updateX_tb.Enabled = true;
          this.updateY_tb.Enabled = true;
          this.updateZ_tb.Enabled = true;
          this.updateSize_tb.Enabled = true;
          this.updateRot_tb.Enabled = true;
          this.updateScript_tb.Enabled = true;
          this.updateName_tb.Text = selectedObject.name;
          this.updateX_tb.Text = selectedObject.locX.ToString();
          this.updateY_tb.Text = selectedObject.locY.ToString();
          this.updateZ_tb.Text = selectedObject.locZ.ToString();
          this.updateSize_tb.Text = selectedObject.size.ToString();
          this.updateRot_tb.Text = selectedObject.rot.ToString();
          this.updateScript_tb.Text = selectedObject.specialScript.ToString("x");
          this.id_tb.Text = selectedObject.objectID.ToString("x");
          this.flag_tb.Enabled = false;
          this.flag_tb.Visible = false;
          this.flag_lbl.Visible = false;
          this.updateRad_tb.Visible = false;
          this.rad_lbl.Visible = false;
          if (selectedObject.flag != -1)
          {
            this.flag_tb.Text = selectedObject.flag.ToString("x");
            this.flag_tb.Visible = true;
            this.flag_lbl.Visible = true;
          }
          if (selectedObject.radius != (ushort) 0)
          {
            this.updateRad_tb.Text = selectedObject.radius.ToString();
            this.updateRad_tb.Visible = true;
            this.rad_lbl.Visible = true;
            this.script_lbl.Visible = false;
            this.updateScript_tb.Visible = false;
          }
          this.warpTo_lbl.Visible = false;
          this.warpTo_tb.Visible = false;
          this.warp_btn.Visible = false;
          if (selectedObject.name == "warp")
          {
            this.warpTo_lbl.Visible = true;
            this.warpTo_tb.Visible = true;
            this.warp_btn.Visible = true;
            this.warpTo_tb.Enabled = false;
            this.warpTo_tb.Text = new WarpLocation((int) selectedObject.objectID).name;
          }
          if (this.world.isObject())
          {
            this.address_lbl.Text = selectedObject.address.ToString("x");
            this.address_lbl.Text = this.address_lbl.Text + " " + (object) selectedObject.zoneID;
            this.objID_lbl.Text = "OBJ ID: " + ((int) selectedObject.obj16 * 256 + (int) selectedObject.obj17).ToString("x");
            this.objID_lbl.Visible = true;
            if (!this.hideUnknownBytes)
            {
              this.updateB10_tb.Visible = true;
              this.updateB10_tb.Enabled = true;
              this.updateB11_tb.Visible = true;
              this.updateB11_tb.Enabled = true;
              this.updateB13_tb.Visible = true;
              this.updateB13_tb.Enabled = true;
              this.updateB18_tb.Visible = true;
              this.updateB18_tb.Enabled = true;
              this.updateB16_tb.Visible = true;
              this.updateB16_tb.Enabled = true;
              this.updateB17_tb.Visible = true;
              this.updateB17_tb.Enabled = true;
              this.b10_lbl.Visible = true;
              this.b11_lbl.Visible = true;
              this.b13_lbl.Visible = true;
              this.b18_lbl.Visible = true;
              this.b16_lbl.Visible = true;
              this.b17_lbl.Visible = true;
            }
            this.updateB10_tb.Text = selectedObject.obj10.ToString("x");
            this.updateB11_tb.Text = selectedObject.obj11.ToString("x");
            this.updateB13_tb.Text = selectedObject.obj13.ToString("x");
            this.updateB18_tb.Text = selectedObject.obj18.ToString("x");
            this.updateB16_tb.Text = selectedObject.obj16.ToString("x");
            this.updateB17_tb.Text = selectedObject.obj17.ToString("x");
          }
          else
          {
            this.objID_lbl.Text = "STRUCT";
            this.updateB10_tb.Visible = false;
            this.updateB10_tb.Enabled = false;
            this.updateB11_tb.Visible = false;
            this.updateB11_tb.Enabled = false;
            this.updateB13_tb.Visible = false;
            this.updateB13_tb.Enabled = false;
            this.updateB18_tb.Visible = false;
            this.updateB18_tb.Enabled = false;
            this.updateB16_tb.Visible = false;
            this.updateB16_tb.Enabled = false;
            this.updateB17_tb.Visible = false;
            this.updateB17_tb.Enabled = false;
            this.b10_lbl.Visible = false;
            this.b11_lbl.Visible = false;
            this.b13_lbl.Visible = false;
            this.b18_lbl.Visible = false;
            this.b16_lbl.Visible = false;
            this.b17_lbl.Visible = false;
          }
          if (selectedObject.type == ObjectType.Normal && selectedObject.objectID >= (short) 204 && selectedObject.objectID <= (short) 223)
          {
            this.updateSize_tb.Visible = false;
            this.size_lbl.Visible = false;
            this.cc_failsafe_cb.Visible = true;
            this.failsafe_lbl.Visible = true;
            this.cc_failsafe_cb.Checked = selectedObject.size != (short) 1 && selectedObject.size != (short) 3;
          }
          else
          {
            this.updateSize_tb.Visible = true;
            this.size_lbl.Visible = true;
            this.cc_failsafe_cb.Visible = false;
            this.failsafe_lbl.Visible = false;
          }
        }
        else
        {
          this.textUpdate_gb.Visible = false;
          this.updateName_tb.Enabled = false;
          this.updateX_tb.Enabled = false;
          this.updateY_tb.Enabled = false;
          this.updateZ_tb.Enabled = false;
          this.updateSize_tb.Enabled = false;
          this.updateRot_tb.Enabled = false;
          this.updateScript_tb.Enabled = false;
          this.warpTo_lbl.Visible = false;
          this.warpTo_tb.Visible = false;
          this.warp_btn.Visible = false;
          this.updateB10_tb.Visible = false;
          this.updateB10_tb.Enabled = false;
          this.updateB11_tb.Visible = false;
          this.updateB11_tb.Enabled = false;
          this.updateB13_tb.Visible = false;
          this.updateB13_tb.Enabled = false;
          this.updateB18_tb.Visible = false;
          this.updateB18_tb.Enabled = false;
          this.updateB16_tb.Visible = false;
          this.updateB16_tb.Enabled = false;
          this.updateB17_tb.Visible = false;
          this.updateB17_tb.Enabled = false;
          this.b10_lbl.Visible = false;
          this.b11_lbl.Visible = false;
          this.b13_lbl.Visible = false;
          this.b18_lbl.Visible = false;
          this.b16_lbl.Visible = false;
          this.b17_lbl.Visible = false;
          this.updateName_tb.Clear();
          this.updateX_tb.Clear();
          this.updateY_tb.Clear();
          this.updateZ_tb.Clear();
          this.updateB10_tb.Clear();
          this.updateB11_tb.Clear();
          this.updateB13_tb.Clear();
          this.updateB18_tb.Clear();
          this.updateSize_tb.Clear();
          this.updateRot_tb.Clear();
          this.updateScript_tb.Clear();
        }
      }
      this.flowLayoutPanel1.ResumeLayout();
      this.flowLayoutPanel1.PerformLayout();
      this.flowLayoutPanel1.Refresh();
    }

    public void unlockBasicEditSettings()
    {
      this.flowLayoutPanel1.SuspendLayout();
      this.unlockedEditSettings = false;
      this.col_obj_details_btn.Visible = false;
      this.textUpdate_gb.Visible = false;
      this.cam3_gb.Visible = false;
      this.hideCamButtons();
      this.showObjectButtons();
      this.textUpdate_gb.Visible = false;
      this.unlockedEditSettings = true;
      this.flowLayoutPanel1.ResumeLayout();
      this.flowLayoutPanel1.PerformLayout();
      this.flowLayoutPanel1.Refresh();
    }

    public void updateEditInfo()
    {
      if (this.cameraMode)
      {
        if (!this.world.hasSelectedCamera())
          return;
        CameraObject selectedCamera = this.world.getSelectedCamera();
        if (selectedCamera.type == 2)
        {
          this.camPitch_tb.Text = selectedCamera.pitch.ToString();
          this.camYaw_tb.Text = selectedCamera.yaw.ToString();
          this.camRoll_tb.Text = selectedCamera.roll.ToString();
          this.camX_tb.Text = selectedCamera.x.ToString();
          this.camY_tb.Text = selectedCamera.y.ToString();
          this.camZ_tb.Text = selectedCamera.z.ToString();
        }
        else
        {
          if (selectedCamera.type != 3 && selectedCamera.type != 1)
            return;
          this.camX_tb.Text = selectedCamera.x.ToString();
          this.camY_tb.Text = selectedCamera.y.ToString();
          this.camZ_tb.Text = selectedCamera.z.ToString();
        }
      }
      else if (this.world.pathMode)
      {
        this.world.hasSelectedNodes();
        if (!this.world.singleNodeSelected())
          return;
        if (this.world.getSelectedNodeType() == ObjectType.Path)
        {
          ObjectData node = this.world.paths[this.world.selectedPath].nodes[this.world.getSelectedNode()];
          this.nodeX_tb.Text = node.locX.ToString();
          this.nodeY_tb.Text = node.locY.ToString();
          this.nodeZ_tb.Text = node.locZ.ToString();
          this.nodeID_tb.Text = node.uid.ToString("x");
          this.node18_tb.Text = node.obj18.ToString("x");
          this.node18_tb.Text = node.nodeOutUID.ToString("x");
        }
        else
        {
          try
          {
            ObjectData node = this.world.paths[this.world.selectedPath].nodes[this.world.getSelectedNode()];
            this.pathID_tb.Text = node.pathID.ToString("x");
            this.sNodeF_tb.Text = node.activationPercent.ToString("###########0.###############");
            this.useAnimation_cb.Checked = node.useAnimation;
            this.useSpeed_cb.Checked = node.useSpeed;
            this.usePause_cb.Checked = node.usePause;
            this.animation_cb.SelectedIndex = this.getAnimationNameForNode();
            this.sNodeSpeed_tb.Text = node.speed.ToString("x");
            this.pauseTime_tb.Text = node.pauseTime.ToString();
            this.sNodeW1_tb.Text = node.pw1.ToString("x");
            this.sNodeUNK3_tb.Text = node.unk3.ToString("x");
            this.nodeID_tb.Text = node.uid.ToString("x");
            this.node18_tb.Text = node.nodeOutUID.ToString("x");
          }
          catch (Exception ex)
          {
          }
        }
      }
      else
      {
        if (!this.world.singleObjectSelected())
          return;
        ObjectData selectedObject = this.world.getSelectedObject();
        this.updateName_tb.Text = selectedObject.name;
        this.updateX_tb.Text = selectedObject.locX.ToString();
        this.updateY_tb.Text = selectedObject.locY.ToString();
        this.updateZ_tb.Text = selectedObject.locZ.ToString();
        this.updateSize_tb.Text = selectedObject.size.ToString();
        this.updateRot_tb.Text = selectedObject.rot.ToString();
        this.updateScript_tb.Text = selectedObject.specialScript.ToString("x");
        if (selectedObject.radius != (ushort) 0)
        {
          this.updateRad_tb.Text = selectedObject.radius.ToString();
          ObjectData objectData = selectedObject;
          objectData.specialScript = (short) (((int) objectData.radius << 7) + selectedObject.type);
          this.updateScript_tb.Text = selectedObject.specialScript.ToString("x");
        }
        if (!this.world.isObject())
          return;
        this.updateB10_tb.Text = selectedObject.obj10.ToString("x");
        this.updateB11_tb.Text = selectedObject.obj11.ToString("x");
        this.updateB13_tb.Text = selectedObject.obj13.ToString("x");
        this.updateB18_tb.Text = selectedObject.obj18.ToString("x");
      }
    }

    private void disableAllModes()
    {
      this.selectMode = false;
      this.createMode = false;
      this.cameraMode = false;
      this.moveMode = false;
      this.nodeMoveMode = false;
      this.scaleMode = false;
      this.rotateMode = false;
      this.duplicateMode = false;
      this.yawMode = false;
      this.pitchMode = false;
      this.rollMode = false;
      this.camMoveMode = false;
      this.world.DeactivatePathMode();
      this.col_selPath_btn.Visible = false;
      this.obj_move_btn.BackColor = this.inactive;
      this.obj_rot_btn.BackColor = this.inactive;
      this.obj_scale_btn.BackColor = this.inactive;
      this.obj_duplicate_btn.BackColor = this.inactive;
      this.cam_yaw_btn.BackColor = this.inactive;
      this.cam_pitch_btn.BackColor = this.inactive;
      this.cam_roll_btn.BackColor = this.inactive;
      this.assignObject_btn.BackColor = this.inactive;
      this.moveNode_btn.BackColor = this.inactive;
      this.linkMode_btn.BackColor = this.inactive;
      this.addControllerNode_btn.BackColor = this.inactive;
      this.addNode_btn.BackColor = this.inactive;
      this.hideProperties();
    }

    private void hideProperties()
    {
      this.flowLayoutPanel1.SuspendLayout();
      this.col_obj_details_btn.Visible = false;
      this.textUpdate_gb.Visible = false;
      this.cam3_gb.Visible = false;
      this.path_gb.Visible = false;
      this.flowLayoutPanel1.ResumeLayout();
      this.flowLayoutPanel1.PerformLayout();
      this.flowLayoutPanel1.Refresh();
    }

    private void clearEditMode()
    {
      this.moveMode = false;
      this.nodeMoveMode = false;
      this.scaleMode = false;
      this.rotateMode = false;
      this.duplicateMode = false;
      this.yawMode = false;
      this.pitchMode = false;
      this.rollMode = false;
      this.camMoveMode = false;
      this.obj_move_btn.BackColor = this.inactive;
      this.obj_rot_btn.BackColor = this.inactive;
      this.obj_scale_btn.BackColor = this.inactive;
      this.obj_duplicate_btn.BackColor = this.inactive;
      this.cam_yaw_btn.BackColor = this.inactive;
      this.cam_pitch_btn.BackColor = this.inactive;
      this.cam_roll_btn.BackColor = this.inactive;
    }

    private void disableAllSubModes()
    {
      this.scalingObj = false;
      this.movingObj = false;
      this.rotatingObj = false;
      this.duplicatingObj = false;
      this.movingNode = false;
    }

    private void disableAllPathModes()
    {
      this.world.pmode = PathMode.None;
      this.assignObject_btn.BackColor = this.inactive;
      this.addNode_btn.BackColor = this.inactive;
      this.moveNode_btn.BackColor = this.inactive;
      this.linkMode_btn.BackColor = this.inactive;
    }

    private void importModel_btn_Click(object sender, EventArgs e)
    {
      try
      {
        this.importPrep();
        this.timer1.Enabled = false;
        int num = (int) new ModelImportForm(this.tmpDir).ShowDialog();
        this.LevelViewer.MakeCurrent();
        this.timer1.Enabled = true;
      }
      catch (Exception ex)
      {
        this.LevelViewer.MakeCurrent();
        this.timer1.Enabled = true;
      }
    }

    private void timer1_Tick_1(object sender, EventArgs e)
    {
      if (this.rectSelect)
        return;
      this.camera();
      this.LevelViewer.Invalidate();
    }

    private void replaceModel_btn_Click(object sender, EventArgs e)
    {
      if (this.changeLM_ofd.ShowDialog() != DialogResult.OK)
        return;
      this.replacedModel = this.changeLM_ofd.FileName;
      int startIndex = this.replacedModel.LastIndexOf("\\") + 1;
      this.baseLevel_tb.Text = this.replacedModel.Substring(startIndex, this.replacedModel.Length - startIndex);
      this.Refresh();
    }

    private void replaceModelEx_btn_Click(object sender, EventArgs e)
    {
      if (this.changeLM_ofd.ShowDialog() != DialogResult.OK)
        return;
      this.replacedModelEx = this.changeLM_ofd.FileName;
      int startIndex = this.replacedModelEx.LastIndexOf("\\") + 1;
      this.extraModel_tb.Text = this.replacedModelEx.Substring(startIndex, this.replacedModelEx.Length - startIndex);
      this.Refresh();
    }

    private void clear_btn_Click(object sender, EventArgs e)
    {
      this.replacedModel = "";
      this.baseLevel_tb.Text = "";
      this.replacedModelEx = "";
      this.extraModel_tb.Text = "";
      this.world.RenderScene(this.replacedModel, this.replacedModelEx);
      this.forceRedraw = true;
      this.Refresh();
    }

    private void clearAll_btn_Click(object sender, EventArgs e)
    {
    }

    private void openRomToolStripMenuItem_Click(object sender, EventArgs e) => this.openRom();

    private void openRom()
    {
      int num = 1;
      while (num != 2 && num != 0)
        num = this.openRomAttempt();
      if (num != 0)
        return;
      this.Close();
    }

    public int openRomAttempt()
    {
      bool flag = false;
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return 2;
      try
      {
        string fileName = this.openFileDialog1.FileName;
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(fileName, FileMode.Open));
        long length1 = binaryReader.BaseStream.Length;
        byte[] numArray = new byte[length1];
        binaryReader.BaseStream.Read(numArray, 0, (int) length1);
        binaryReader.Close();
        if (numArray[59] != (byte) 78 || numArray[60] != (byte) 66 || numArray[61] != (byte) 75 || numArray[62] != (byte) 69 || numArray[63] != (byte) 0)
          return MessageBox.Show("Please open a Banjo Kazooie V1.0 NTSC rom", "Invalid Rom", MessageBoxButtons.RetryCancel) == DialogResult.Retry ? 1 : 0;
        if (numArray.Length <= 16781312)
        {
          if (MessageBox.Show("This rom has not been extended in order to use it with Banjo's Backpack the rom will need to be extended, would you like to extend the rom now?" + Environment.NewLine + "BB will open the extended rom automatically once completed", "Extend Rom?", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            RomBuilder romBuilder = new RomBuilder(numArray);
            romBuilder.extendRom();
            numArray = romBuilder.rom;
            fileName += ".ext.z64";
            FileStream output = File.Create(fileName);
            BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
            binaryWriter.Write(numArray);
            binaryWriter.Close();
            output.Close();
            this.writtenFiles.Clear();
            string str = "rn64crc.exe";
            Process process = new Process();
            process.StartInfo.FileName = str;
            process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
            process.StartInfo.Arguments = "-u \"" + fileName + "\"";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
            process.Close();
          }
          else
            return MessageBox.Show("Do you want to retry?", "Invalid Rom", MessageBoxButtons.RetryCancel) == DialogResult.Retry ? 1 : 0;
        }
        else
          flag = true;
        this.rom = numArray;
        RomHandler.Rom = this.rom;
        this.romBuild.rom = this.rom;
        this.romBuild.populateEORPointers();
        this.writeINI(fileName);
        this.inRom = fileName;
        this.locateEORFiles();
        try
        {
          string[] files = Directory.GetFiles(this.tmpDir);
          for (int index = 0; index < ((IEnumerable<string>) files).Count<string>(); ++index)
          {
            string path = files[index];
            if (!Regex.IsMatch(Path.GetFileName(path), "[G-Zg-z]"))
              File.Delete(path);
          }
        }
        catch
        {
        }
        if (!flag)
          this.PrepRom();
        string str1 = "rn64crc.exe";
        Process process1 = new Process();
        process1.StartInfo.FileName = str1;
        process1.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
        process1.StartInfo.Arguments = "-u \"" + fileName + "\"";
        process1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process1.StartInfo.CreateNoWindow = true;
        process1.Start();
        process1.WaitForExit();
        process1.Close();
        this.copyRom(fileName);
        this.enableMWFull();
        byte[] f = this.arrayCopy(this.F9CAE0_location, 1048576);
        GECompression ge1 = this.ge;
        byte[] Buffer1 = f;
        int length2 = Buffer1.Length;
        ge1.SetCompressedBuffer(Buffer1, length2);
        int compressedSize1 = 0;
        int fileSize1 = 0;
        this.F9CAE0 = ((IEnumerable<byte>) this.ge.OutputDecompressedBuffer(ref fileSize1, ref compressedSize1)).ToList<byte>();
        this.arrayCopy(f, this.F37F90_location, 1048576);
        GECompression ge2 = this.ge;
        byte[] Buffer2 = f;
        int length3 = Buffer2.Length;
        ge2.SetCompressedBuffer(Buffer2, length3);
        int compressedSize2 = 0;
        int fileSize2 = 0;
        this.F37F90 = ((IEnumerable<byte>) this.ge.OutputDecompressedBuffer(ref fileSize2, ref compressedSize2)).ToList<byte>();
        this.globalizedFCF698 = new byte[9888];
        this.arrayCopy(this.globalizedFCF698, this.globalizedFCF698Location, 9888);
        this.world.getRomStats(this.F9CAE0);
        this.getEntryPoints();
        this.AssociateScenesWithLevels();
        return 2;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Could not open rom " + ex.Message, "Unable to open rom");
        return 1;
      }
    }

    private void copyRom(string file)
    {
      if (MessageBox.Show("BB will alter this rom so that it can make some changes that would otherwise not be possible, would you like BB to make a copy of your rom so you have a clean rom to patch?", "Copy Rom?", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;
      try
      {
        File.Copy(file, file + "[CLEAN]-" + DateTime.Now.ToString("Hms-Mdyyyy") + ".z64");
      }
      catch
      {
      }
    }

    private void enableMWFull()
    {
      this.textEditorToolStripMenuItem.Enabled = true;
      this.knowAllMovesToolStripMenuItem.Enabled = true;
      this.haveNoMovesToolStripMenuItem.Enabled = true;
      this.openSetupFileToolStripMenuItem.Enabled = true;
      this.removeNumbersFromNotedoorToolStripMenuItem.Enabled = true;
      this.puzzleEditorToolStripMenuItem.Enabled = true;
      this.midiToolToolStripMenuItem.Enabled = true;
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
    }

    private void warp_btn_Click(object sender, EventArgs e)
    {
      try
      {
        WarpDestinationForm warpDestinationForm = new WarpDestinationForm();
        int num = (int) warpDestinationForm.ShowDialog();
        this.id_tb.Text = ((short) warpDestinationForm.warp.id).ToString("x");
        this.updateObject();
        this.world.RenderObjects();
        this.unlockEditSettings();
        this.Refresh();
      }
      catch
      {
      }
    }

    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        this.RotateSceneClick = false;
      else
        this.disableAllSubModes();
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e) => this.LevelViewer_KeyUp(sender, e);

    private void saveSetupFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.saveSetupFileDialog.ShowDialog() != DialogResult.OK)
        return;
      string fileName = this.saveSetupFileDialog.FileName;
      this.sfw.createBinaryFileObjects(this.tmpDir, this.outDir, this.selectedFile, new List<ObjectData>((IEnumerable<ObjectData>) this.world.objects), new List<ObjectData>((IEnumerable<ObjectData>) this.world.structs), this.world.paths, this.world.cameras, new List<LevelEntryPoint>(), this.includeTriggers, this.world.file.bounds, this.replacedModel, this.replacedModelEx, this.allObjsErased, this.saveSetupFileDialog.FileName);
      int num = (int) MessageBox.Show("Setup File Saved");
    }

    private void loadSetupFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.openSetupFileDialog.ShowDialog() != DialogResult.OK)
        return;
      this.world.resetStack();
      this.mode_cb.SelectedIndex = 0;
      this.clearSelection();
      this.world.eraseDLs();
      this.world.DeleteAllObjects();
      this.world.ReadSetupFile(this.openSetupFileDialog.FileName);
      this.world.RenderScene(this.replacedModel, this.replacedModelEx);
      this.world.renderSetup();
      this.world.renderPicking();
      this.populateEntryData();
      this.populateObjectData();
      this.world.pushSetupStack("Loaded Setup");
      this.Refresh();
    }

    public void createXMLFile()
    {
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<TextFile>));
        StreamWriter streamWriter1 = new StreamWriter(this.path + "\\text\\mwtext.xml");
        StreamWriter streamWriter2 = streamWriter1;
        List<TextFile> files = this.files;
        xmlSerializer.Serialize((TextWriter) streamWriter2, (object) files);
        streamWriter1.Close();
      }
      catch (Exception ex)
      {
      }
    }

    private void cleanOutDir()
    {
      foreach (string file in Directory.GetFiles(this.outDir, "*.bin", SearchOption.AllDirectories))
      {
        try
        {
          File.Delete(file);
        }
        catch
        {
        }
      }
      foreach (string file in Directory.GetFiles(this.outDir, "*.1172", SearchOption.AllDirectories))
      {
        try
        {
          File.Delete(file);
        }
        catch
        {
        }
      }
    }

    private void Form1_ResizeEnd(object sender, EventArgs e) => this.world.core.SetView(this.LevelViewer.Height, this.LevelViewer.Width);

    private void LevelViewer_SizeChanged(object sender, EventArgs e)
    {
      if (!this.loaded)
        return;
      this.world.core.SetView(this.LevelViewer.Height, this.LevelViewer.Width);
    }

    private void insertF9CAE0()
    {
      FileStream output1 = File.Create(this.outDir + "F9CAE0.bin");
      BinaryWriter binaryWriter1 = new BinaryWriter((Stream) output1);
      binaryWriter1.Write(this.F9CAE0.ToArray(), 0, this.F9CAE0.Count<byte>());
      binaryWriter1.Close();
      output1.Close();
      this.romBuild.rom = this.rom;
      this.romBuild.populateEORPointers();
      this.romBuild.outDir = this.outDir;
      this.romBuild.insertDecompressedFile(this.outDir, "F9CAE0.bin", this.F9CAE0_location, this.FA3FD0_location - this.F9CAE0_location, true);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      FileStream output2 = File.Create(this.inRom);
      BinaryWriter binaryWriter2 = new BinaryWriter((Stream) output2);
      binaryWriter2.Write(this.romBuild.rom);
      binaryWriter2.Close();
      output2.Close();
      string str = "rn64crc.exe";
      Process process = new Process();
      process.StartInfo.FileName = str;
      process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
      process.StartInfo.Arguments = "-u \"" + this.inRom + "\"";
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      process.WaitForExit();
      process.Close();
      int num = (int) MessageBox.Show("Rom Updated");
    }

    private void insertF37F90()
    {
      FileStream output1 = File.Create(this.outDir + "F37F90.bin");
      BinaryWriter binaryWriter1 = new BinaryWriter((Stream) output1);
      binaryWriter1.Write(this.F37F90.ToArray(), 0, this.F37F90.Count<byte>());
      binaryWriter1.Close();
      output1.Close();
      this.romBuild.rom = this.rom;
      this.romBuild.populateEORPointers();
      this.romBuild.outDir = this.outDir;
      this.romBuild.insertDecompressedFile(this.outDir, "F37F90.bin", this.F37F90_location, this.F9CAE0_location - this.F37F90_location, true);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      FileStream output2 = File.Create(this.inRom);
      BinaryWriter binaryWriter2 = new BinaryWriter((Stream) output2);
      binaryWriter2.Write(this.romBuild.rom);
      binaryWriter2.Close();
      output2.Close();
      string str = "rn64crc.exe";
      Process process = new Process();
      process.StartInfo.FileName = str;
      process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
      process.StartInfo.Arguments = "-u \"" + this.inRom + "\"";
      process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      process.StartInfo.CreateNoWindow = true;
      process.Start();
      process.WaitForExit();
      process.Close();
      int num = (int) MessageBox.Show("Rom Updated");
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Alt && e.KeyCode == Keys.M && this.obj_move_btn.Enabled && this.obj_move_btn.Visible)
      {
        if (this.selectMode)
          this.toggleMoveMode();
        if (this.cameraMode)
          this.toggleCamMoveMode();
      }
      if (e.Control && e.KeyCode == Keys.B && this.rectSelect_btn.Enabled)
        this.toggleRectSelect();
      if (e.Alt && e.KeyCode == Keys.R && this.obj_rot_btn.Enabled && this.obj_rot_btn.Visible)
        this.toggleRotateMode();
      if (e.Alt && e.KeyCode == Keys.S && this.obj_scale_btn.Enabled && this.obj_scale_btn.Visible)
        this.toggleScaleMode();
      if (e.Alt && e.KeyCode == Keys.D && this.obj_duplicate_btn.Enabled && this.obj_duplicate_btn.Visible)
        this.toggleDuplicateMode();
      if (e.Alt && e.KeyCode == Keys.Delete && this.delete_btn.Enabled && this.delete_btn.Visible)
        this.deleteSelected();
      if (e.KeyCode == Keys.Escape && this.deselect_btn.Enabled && this.deselect_btn.Visible)
        this.clearSelection();
      if (e.Alt && e.KeyCode == Keys.V)
      {
        this.world.BBCameraToBKCamera(this.BBCamera);
        this.forceRedraw = true;
      }
      if (e.Control && e.KeyCode == Keys.Z)
        this.undo();
      if (!e.Control || e.KeyCode != Keys.Y)
        return;
      this.redo();
    }

    private void reloadFromStackChange()
    {
      this.ls = this.world.getLevelStats(this.selectedFile.levelID, this.selectedFile.pointer);
      this.world.resetPick();
      if (this.cameraMode)
      {
        this.disableAllModes();
        this.cameraMode = true;
        this.unlockEditSettings();
      }
      else if (this.world.pathMode)
      {
        this.disableAllModes();
        this.world.ActivatePathMode();
        this.unlockPathSettings();
      }
      else
      {
        this.disableAllModes();
        this.selectMode = true;
        this.unlockEditSettings();
      }
      this.world.InitGl();
      this.world.RenderScene(this.replacedModel, this.replacedModelEx);
      this.world.renderSetup();
      this.world.renderPicking();
      this.world.RenderCameraPicking();
      this.populateEntryData();
      this.populateObjectData();
      this.forceRedraw = true;
    }

    private void undo()
    {
      if (!this.world.popSetupStack())
        return;
      this.reloadFromStackChange();
    }

    private void redo()
    {
      if (!this.world.forwardSetupStack(1))
        return;
      this.reloadFromStackChange();
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      if (this.WindowState == FormWindowState.Minimized)
        this.timer1.Stop();
      if (this.WindowState == FormWindowState.Normal)
      {
        this.timer1.Start();
        this.forceRedraw = true;
      }
      if (this.WindowState != FormWindowState.Maximized)
        return;
      this.timer1.Start();
      this.forceRedraw = true;
    }

    private void cam_mouseUpdate_gb_Enter(object sender, EventArgs e)
    {
    }

    private void camXToggle_btn_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void camYToggle_btn_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void camZToggle_btn_CheckedChanged(object sender, EventArgs e)
    {
    }

    private void camMove_btn_Click(object sender, EventArgs e) => this.toggleCamMoveMode();

    private void toggleCamMoveMode()
    {
    }

    private void camDel_btn_Click(object sender, EventArgs e) => this.deleteSelected();

    private void camDeselect_btn_Click(object sender, EventArgs e) => this.clearSelection();

    private void mouseUpdate_gb_Enter(object sender, EventArgs e)
    {
    }

    private void col_obj_details_btn_Click(object sender, EventArgs e)
    {
      if (this.selectMode)
      {
        if (!this.textUpdate_gb.Visible && this.unlockedEditSettings)
        {
          this.textUpdate_gb.Visible = true;
          this.col_obj_details_btn.Text = "- Object Details";
        }
        else
        {
          if (!this.textUpdate_gb.Visible || !this.unlockedEditSettings)
            return;
          this.textUpdate_gb.Visible = false;
          this.col_obj_details_btn.Text = "+ Object Details";
        }
      }
      else
      {
        int num = this.cameraMode ? 1 : 0;
      }
    }

    private void col_replacemodel_btn_Click(object sender, EventArgs e)
    {
      if (!this.replacemodel_gb.Visible)
      {
        this.replacemodel_gb.Visible = true;
        this.col_replacemodel_btn.Text = "- Replace Model";
      }
      else
      {
        if (!this.replacemodel_gb.Visible)
          return;
        this.replacemodel_gb.Visible = false;
        this.col_replacemodel_btn.Text = "+ Replace Model";
      }
    }

    private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private byte[] Int16ToByteArray(short s) => new byte[2]
    {
      (byte) ((uint) s >> 8),
      (byte) s
    };

    private void updateBounds_btn_Click(object sender, EventArgs e)
    {
      if (!(this.replacedModel != ""))
        return;
      BoundingBox bounds = this.world.file.bounds with
      {
        smallX = (int) Convert.ToInt16(this.minX_Bounds_tb.Text),
        smallY = (int) Convert.ToInt16(this.minY_Bounds_tb.Text),
        smallZ = (int) Convert.ToInt16(this.minZ_Bounds_tb.Text),
        largeX = (int) Convert.ToInt16(this.maxX_Bounds_tb.Text),
        largeY = (int) Convert.ToInt16(this.maxY_Bounds_tb.Text),
        largeZ = (int) Convert.ToInt16(this.maxZ_Bounds_tb.Text)
      };
      this.world.file.bounds = bounds;
      this.world.DrawLevelBoundary();
      this.forceRedraw = true;
      BinaryReader binaryReader = new BinaryReader((Stream) File.Open(this.replacedModel, FileMode.Open));
      int length = (int) binaryReader.BaseStream.Length;
      byte[] numArray = new byte[length];
      binaryReader.BaseStream.Read(numArray, 0, length);
      binaryReader.Close();
      int index = (int) numArray[16] * 16777216 + (int) numArray[17] * 65536 + (int) numArray[18] * 256 + (int) numArray[19];
      byte[] byteArray1 = this.Int16ToByteArray((short) bounds.smallX);
      numArray[index] = byteArray1[0];
      numArray[index + 1] = byteArray1[1];
      byte[] byteArray2 = this.Int16ToByteArray((short) bounds.smallY);
      numArray[index + 2] = byteArray2[0];
      numArray[index + 3] = byteArray2[1];
      byte[] byteArray3 = this.Int16ToByteArray((short) bounds.smallZ);
      numArray[index + 4] = byteArray3[0];
      numArray[index + 5] = byteArray3[1];
      byte[] byteArray4 = this.Int16ToByteArray((short) bounds.largeX);
      numArray[index + 6] = byteArray4[0];
      numArray[index + 7] = byteArray4[1];
      byte[] byteArray5 = this.Int16ToByteArray((short) bounds.largeY);
      numArray[index + 8] = byteArray5[0];
      numArray[index + 9] = byteArray5[1];
      byte[] byteArray6 = this.Int16ToByteArray((short) bounds.largeZ);
      numArray[index + 10] = byteArray6[0];
      numArray[index + 11] = byteArray6[1];
      short s1 = (short) ((bounds.largeX + bounds.smallX) / 2);
      short s2 = (short) ((bounds.largeY + bounds.smallY) / 2);
      short s3 = (short) ((bounds.largeZ + bounds.smallZ) / 2);
      byte[] byteArray7 = this.Int16ToByteArray(s1);
      numArray[index + 12] = byteArray7[0];
      numArray[index + 13] = byteArray7[1];
      byte[] byteArray8 = this.Int16ToByteArray(s2);
      numArray[index + 14] = byteArray8[0];
      numArray[index + 15] = byteArray8[1];
      byte[] byteArray9 = this.Int16ToByteArray(s3);
      numArray[index + 16] = byteArray9[0];
      numArray[index + 17] = byteArray9[1];
      short num1 = Math.Abs(bounds.largeX) > Math.Abs(bounds.smallX) ? (short) Math.Abs(bounds.largeX) : (short) Math.Abs(bounds.smallX);
      short num2 = Math.Abs(bounds.largeY) > Math.Abs(bounds.smallY) ? (short) Math.Abs(bounds.largeY) : (short) Math.Abs(bounds.smallY);
      short num3 = Math.Abs(bounds.largeZ) > Math.Abs(bounds.smallZ) ? (short) Math.Abs(bounds.largeZ) : (short) Math.Abs(bounds.smallZ);
      byte[] byteArray10 = this.Int16ToByteArray((short) ((double) num1 * 1.3));
      numArray[index + 18] = byteArray10[0];
      numArray[index + 19] = byteArray10[1];
      byte[] byteArray11 = this.Int16ToByteArray((short) ((double) num2 * 1.3));
      numArray[index + 20] = byteArray11[0];
      numArray[index + 21] = byteArray11[1];
      byte[] byteArray12 = this.Int16ToByteArray((short) ((double) num3 * 1.3));
      numArray[index + 22] = byteArray12[0];
      numArray[index + 23] = byteArray12[1];
      FileStream output = File.Create(this.replacedModel);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
      binaryWriter.Write(numArray, 0, ((IEnumerable<byte>) numArray).Count<byte>());
      binaryWriter.Close();
      output.Close();
    }

    private void numOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      try
      {
        if (!((IEnumerable<string>) new string[12]
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
          "0",
          "-",
          "."
        }).Contains<string>(e.KeyChar.ToString()) && e.KeyChar != '\b')
          e.Handled = true;
        if (this.minX_Bounds_tb.Text == "")
          this.minX_Bounds_tb.Text = "0";
        if (this.minY_Bounds_tb.Text == "")
          this.minY_Bounds_tb.Text = "0";
        if (this.minZ_Bounds_tb.Text == "")
          this.minZ_Bounds_tb.Text = "0";
        if (this.maxX_Bounds_tb.Text == "")
          this.maxX_Bounds_tb.Text = "0";
        if (this.maxX_Bounds_tb.Text == "")
          this.maxX_Bounds_tb.Text = "0";
        if (!(this.maxX_Bounds_tb.Text == ""))
          return;
        this.maxX_Bounds_tb.Text = "0";
      }
      catch
      {
      }
    }

    private void hexOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
      try
      {
        if (((IEnumerable<string>) new string[24]
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
          "0",
          "-",
          ".",
          "A",
          "B",
          "C",
          "D",
          "E",
          "F",
          "a",
          "b",
          "c",
          "d",
          nameof (e),
          "f"
        }).Contains<string>(e.KeyChar.ToString()) || e.KeyChar == '\b')
          return;
        e.Handled = true;
      }
      catch
      {
      }
    }

    private void col_levelbounds_btn_Click(object sender, EventArgs e)
    {
      if (!this.bounds_gb.Visible)
      {
        this.bounds_gb.Visible = true;
        this.col_levelbounds_btn.Text = "- Level Boundaries";
      }
      else
      {
        if (!this.bounds_gb.Visible)
          return;
        this.bounds_gb.Visible = false;
        this.col_levelbounds_btn.Text = "+ Level Boundaries";
      }
    }

    private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void entries_lv_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
    {
    }

    private void col_levelentries_btn_Click(object sender, EventArgs e)
    {
      if (!this.levelEntries_gb.Visible)
      {
        this.levelEntries_gb.Visible = true;
        this.col_levelentries_btn.Text = "- Level Entries";
      }
      else
      {
        if (!this.levelEntries_gb.Visible)
          return;
        this.levelEntries_gb.Visible = false;
        this.col_levelentries_btn.Text = "+ Level Entries";
      }
    }

    private void createCameraToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.world.core.ClearScreenAndLoadIdentity();
      Gl.glPushMatrix();
      Gl.glLoadMatrixf(this.BBCamera.GetWorldToViewMatrix());
      if (this.world.objectsDList.Count<uint>() > 0)
        this.world.Redraw(this.BBCamera);
      double[] world = this.world.ScreenToWorld(this.createPointX, this.createPointY, this.BBCamera);
      this.world.addCamera(new CameraObject((short) 0, (float) world[0], (float) world[1], (float) world[2], 0.0f, 0.0f, 0.0f, 2));
      this.forceRedraw = true;
      this.world.pushSetupStack("CameraMode: Added Camera");
    }

    private void objects_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        ObjectData objectData = this.world.objects[(int) this.objects_dgv.SelectedRows[0].Cells[0].Value];
        this.BBCamera.LookAt(new Vector3((float) objectData.locX, (float) objectData.locY, (float) objectData.locZ));
        this.forceRedraw = true;
      }
      catch
      {
      }
    }

    private void col_objects_btn_Click(object sender, EventArgs e)
    {
      if (!this.objects_gb.Visible)
      {
        this.objects_gb.Visible = true;
        this.col_objects_btn.Text = "- Objects";
      }
      else
      {
        if (!this.objects_gb.Visible)
          return;
        this.objects_gb.Visible = false;
        this.col_objects_btn.Text = "+ Objects";
      }
    }

    private void includeCameraTriggersWhenSavingToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.includeTriggers)
      {
        this.includeTriggers = false;
        this.includeCameraTriggersWhenSavingToolStripMenuItem.Checked = false;
      }
      else
      {
        this.includeCameraTriggersWhenSavingToolStripMenuItem.Checked = true;
        this.includeTriggers = true;
      }
    }

    private void createGameplayCameraToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.world.core.ClearScreenAndLoadIdentity();
      Gl.glPushMatrix();
      Gl.glLoadMatrixf(this.BBCamera.GetWorldToViewMatrix());
      if (this.world.objectsDList.Count<uint>() > 0)
        this.world.Redraw(this.BBCamera);
      double[] world = this.world.ScreenToWorld(this.createPointX, this.createPointY, this.BBCamera);
      this.world.addCamera(new CameraObject((short) 0, (float) world[0], (float) world[1], (float) world[2], 1.75f, 3.75f, 2.75f, 12f, 0.0f, 0.0f, 0.0f, 134459218, 1000f, 1000f, 3));
      this.forceRedraw = true;
      this.world.pushSetupStack("CameraMode: Added Gameplay Camera");
    }

    private void updateF37F90()
    {
      FileStream output1 = File.Create(this.outDir + "F37F90.bin");
      BinaryWriter binaryWriter1 = new BinaryWriter((Stream) output1);
      binaryWriter1.Write(this.F37F90.ToArray(), 0, this.F37F90.Count);
      binaryWriter1.Close();
      output1.Close();
      this.romBuild.rom = this.rom;
      this.romBuild.populateEORPointers();
      this.romBuild.outDir = this.outDir;
      this.romBuild.insertDecompressedFile(this.outDir, "F37F90.bin", this.F37F90_location, this.F9CAE0_location - this.F37F90_location, true);
      this.rom = this.romBuild.rom;
      RomHandler.Rom = this.rom;
      this.locateEORFiles();
      FileStream output2 = File.Create(this.inRom);
      BinaryWriter binaryWriter2 = new BinaryWriter((Stream) output2);
      binaryWriter2.Write(this.romBuild.rom);
      binaryWriter2.Close();
      output2.Close();
      this.reCRC();
      int num = (int) MessageBox.Show(this.inRom + " Updated");
    }

    private void cam_tb_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (!this.world.hasSelectedCamera())
          return;
        this.updateCamera();
      }
      catch
      {
      }
    }

    private void cam3X_tb_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        if (!this.world.hasSelectedCamera())
          return;
        this.updateCamera();
      }
      catch
      {
      }
    }

    private void updateRad_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        this.updateRad_tb.Text = this.updateRad_tb.Text == "" ? "0" : this.updateRad_tb.Text;
        this.updateScript_tb.Text = ((short) (((int) Convert.ToInt16(this.updateRad_tb.Text) << 7) + 18)).ToString("x");
        this.updateObject();
        this.world.RenderObjects();
        this.forceRedraw = true;
        this.Refresh();
      }
      catch
      {
      }
    }

    private void updateRad_tb_KeyUp(object sender, KeyEventArgs e)
    {
      try
      {
        this.updateRad_tb.Text = Convert.ToUInt16(this.updateRad_tb.Text) > (ushort) 511 ? "511" : this.updateRad_tb.Text;
      }
      catch
      {
      }
    }

    private void removeNumbersFromNotedoorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.injectFile("", ".\\resources\\notedoor_no_numbers.bin", 33568, 0, false);
      int num = (int) MessageBox.Show(this.inRom + " Updated");
    }

    private void injectFile(string dir, string file, int loc, int origSize, bool special)
    {
      try
      {
        this.romBuild.rom = this.rom;
        this.romBuild.populateEORPointers();
        this.romBuild.outDir = this.outDir;
        this.romBuild.insertDecompressedFile(dir, file, loc, origSize, special);
        this.rom = this.romBuild.rom;
        RomHandler.Rom = this.rom;
        this.locateEORFiles();
        FileStream output = File.Create(this.inRom);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(this.romBuild.rom);
        binaryWriter.Close();
        output.Close();
        this.reCRC();
      }
      catch
      {
      }
    }

    private void saveAsRomskillToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.injectDialog.ShowDialog() != DialogResult.OK)
        return;
      string fileName = Path.GetFileName(this.injectDialog.FileName);
      File.Copy(this.injectDialog.FileName, this.outDir + fileName, true);
      if (this.saveAsRomFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        this.romBuild.saveAsMode();
        this.romBuild.outDir = this.outDir;
        this.updateEORFiles(this.romBuild.insertDecompressedFile(this.outDir, fileName, Convert.ToInt32(fileName, 16), 0, false));
        FileStream output = File.Create(this.saveAsRomFileDialog.FileName);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(this.romBuild.rom);
        binaryWriter.Close();
        output.Close();
        this.writtenFiles.Clear();
        string str = "rn64crc.exe";
        Process process = new Process();
        process.StartInfo.FileName = str;
        process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory() + "\\out\\";
        process.StartInfo.Arguments = "-u \"" + this.saveAsRomFileDialog.FileName + "\"";
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit();
        process.Close();
        this.romBuild.rom = this.rom;
        this.romBuild.populateEORPointers();
        this.locateEORFiles();
        int num = (int) MessageBox.Show(this.saveAsRomFileDialog.FileName + " saved successfully");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("An error occured, please try again. " + Environment.NewLine + "Error: " + (object) ex);
      }
    }

    private void col_structs_btn_Click(object sender, EventArgs e)
    {
      if (!this.structs_gb.Visible)
      {
        this.structs_gb.Visible = true;
        this.col_structs_btn.Text = "- Structs";
      }
      else
      {
        if (!this.structs_gb.Visible)
          return;
        this.structs_gb.Visible = false;
        this.col_structs_btn.Text = "+ Structs";
      }
    }

    private void structs_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
      try
      {
        ObjectData objectData = this.world.structs[(int) this.structs_dgv.SelectedRows[0].Cells[0].Value];
        this.BBCamera.LookAt(new Vector3((float) objectData.locX, (float) objectData.locY, (float) objectData.locZ));
        this.forceRedraw = true;
      }
      catch
      {
      }
    }

    private void lockX_btn_Click(object sender, EventArgs e)
    {
      if (this.camXToggle)
      {
        this.camXToggle = false;
        this.xToggle = false;
        this.lockX_btn.BackColor = this.active;
      }
      else
      {
        this.camXToggle = true;
        this.xToggle = true;
        this.lockX_btn.BackColor = this.inactive;
      }
    }

    private void lockY_btn_Click(object sender, EventArgs e)
    {
      if (this.camYToggle)
      {
        this.camYToggle = false;
        this.yToggle = false;
        this.lockY_btn.BackColor = this.active;
      }
      else
      {
        this.camYToggle = true;
        this.yToggle = true;
        this.lockY_btn.BackColor = this.inactive;
      }
    }

    private void lockZ_btn_Click(object sender, EventArgs e)
    {
      if (this.camZToggle)
      {
        this.camZToggle = false;
        this.zToggle = false;
        this.lockZ_btn.BackColor = this.active;
      }
      else
      {
        this.camZToggle = true;
        this.zToggle = true;
        this.lockZ_btn.BackColor = this.inactive;
      }
    }

    private void assignObject_btn_Click(object sender, EventArgs e)
    {
      if (!this.world.pathMode)
        return;
      this.world.pmode = this.world.pmode == PathMode.Assign ? PathMode.None : PathMode.Assign;
      this.assignObject_btn.BackColor = this.world.pmode == PathMode.Assign ? this.active : this.inactive;
      this.forceRedraw = true;
    }

    private void yOffset_tb_Leave(object sender, EventArgs e)
    {
      if (!(this.yOffset_tb.Text == ""))
        return;
      this.yOffset_tb.Text = "0";
    }

    private void readAnimationsXML()
    {
      this.everyAnimation = BBXML.readAnimationsXML();
      foreach (object obj in this.everyAnimation)
        this.animation_cb.Items.Add(obj);
    }

    private int getAnimationNameForNode()
    {
      int animationNameForNode = -1;
      if (this.world.singleNodeSelected() && this.world.getSelectedNodeType() == ObjectType.SPath)
      {
        for (int index = 0; index < this.everyAnimation.Count; ++index)
        {
          if (this.everyAnimation[index].offset == this.world.paths[this.world.selectedPath].nodes[this.world.getSelectedNode()].animation)
            return index;
        }
      }
      return animationNameForNode;
    }

    private void mode_cb_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.clearSelection();
      this.flowLayoutPanel1.SuspendLayout();
      this.col_obj_details_btn.Visible = false;
      this.col_cam_btn.Visible = false;
      this.textUpdate_gb.Visible = false;
      this.cam3_gb.Visible = false;
      this.hideObjectButtons();
      this.hideCamButtons();
      this.hidePathButtons();
      this.flowLayoutPanel1.ResumeLayout();
      this.flowLayoutPanel1.PerformLayout();
      this.flowLayoutPanel1.Refresh();
      this.disableAllModes();
      this.rectSelect_btn.Enabled = true;
      if (this.mode_cb.SelectedIndex == 0)
        this.selectMode = true;
      if (this.selectedFile == null)
        return;
      if (this.mode_cb.SelectedIndex == 1)
      {
        this.rectSelect_btn.Enabled = false;
        this.createMode = true;
      }
      if (this.mode_cb.SelectedIndex == 2)
      {
        this.rectSelect_btn.Enabled = false;
        this.cameraMode = true;
      }
      if (this.mode_cb.SelectedIndex == 3)
      {
        this.rectSelect_btn.Enabled = false;
        this.unlockPathSettings();
        this.world.ActivatePathMode();
        this.selectPathMode = true;
        this.createPathMode = false;
      }
      this.forceRedraw = true;
    }

    private void bgA_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.drawA = this.bgA_cb.Checked;
      this.forceRedraw = true;
    }

    private void bgB_btn_CheckedChanged(object sender, EventArgs e)
    {
      this.world.drawB = this.bgB_btn.Checked;
      this.forceRedraw = true;
    }

    private void objs_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.drawObjs = this.objs_cb.Checked;
      this.forceRedraw = true;
    }

    private void cameras_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.drawCams = this.cameras_cb.Checked;
      this.forceRedraw = true;
    }

    private void levelStats_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.levelStats_cb.Checked)
      {
        this.showStats = true;
        this.forceRedraw = true;
      }
      else
      {
        this.showStats = false;
        this.forceRedraw = true;
      }
    }

    private void levelBound_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.drawLevelBoundary = this.levelBound_cb.Checked;
      this.forceRedraw = true;
    }

    private void camTrigger_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.core.drawCamTrigRadius = this.camTrigger_cb.Checked;
      this.world.RenderObjects();
      this.forceRedraw = true;
    }

    private void warpRadius_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.core.drawWarpRadius = this.warpRadius_cb.Checked;
      this.world.RenderObjects();
      this.forceRedraw = true;
    }

    private void enemyRadius_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.core.drawEnemyRadius = this.enemyRadius_cb.Checked;
      this.world.RenderObjects();
      this.forceRedraw = true;
    }

    private void showFlagRadius_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.core.drawFlagRadius = this.showFlagRadius_cb.Checked;
      this.world.RenderObjects();
      this.forceRedraw = true;
    }

    private void unknownRadius_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.core.drawUnknownRadius = this.unknownRadius_cb.Checked;
      this.world.RenderObjects();
      this.forceRedraw = true;
    }

    private void levelBoundAlpha_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.world.drawLevelBoundaryAlpha = this.levelBoundAlpha_cb.Checked;
      this.forceRedraw = true;
    }

    private void startNewPath_btn_Click(object sender, EventArgs e)
    {
      if (!this.world.pathMode)
        return;
      if (this.world.pmode == PathMode.CreatePath)
      {
        this.world.pmode = PathMode.None;
        this.startNewPath_btn.BackColor = this.inactive;
      }
      else
      {
        this.clearSelection();
        this.world.pmode = PathMode.CreatePath;
        this.startNewPath_btn.BackColor = this.active;
        this.forceRedraw = true;
      }
    }

    private void deselectPath_btn_Click(object sender, EventArgs e) => this.clearSelection();

    private void addNode_btn_Click_1(object sender, EventArgs e)
    {
      if (!this.world.pathMode)
        return;
      this.world.pmode = this.world.pmode == PathMode.CreateNode ? PathMode.None : PathMode.CreateNode;
      this.addNode_btn.BackColor = this.addNode_btn.BackColor == this.inactive ? this.active : this.inactive;
      this.forceRedraw = true;
      this.world.pushSetupStack("PathMode: Added Node");
    }

    private void addAnimationNode_btn_Click(object sender, EventArgs e)
    {
      if (!this.world.pathMode || this.world.selectedPath == -1)
        return;
      int num1 = this.world.addNode(new ObjectData(0.0f, 1, 0, 4096, (byte) 0, (byte) 0, (byte) 0, (byte) 0, true, 0)) ? 1 : 0;
      this.unlockPathSettings();
      if (num1 == 0)
      {
        int num2 = (int) MessageBox.Show("All paths used BB can't calculate any more");
      }
      else
        this.world.pushSetupStack("PathMode: Added Path Controller");
    }

    private void addNode_btn_Click(object sender, EventArgs e)
    {
    }

    private void moveNode_btn_Click(object sender, EventArgs e)
    {
      if (!this.world.pathMode)
        return;
      if (this.nodeMoveMode)
      {
        this.nodeMoveMode = false;
        this.moveNode_btn.BackColor = this.inactive;
      }
      else
      {
        this.nodeMoveMode = true;
        this.moveNode_btn.BackColor = this.active;
      }
    }

    private void removeNode_btn_Click(object sender, EventArgs e)
    {
      this.world.removeNode();
      this.unlockPathSettings();
      this.forceRedraw = true;
      this.world.pushSetupStack("PathMode:Removed Node");
    }

    private void deletePath_btn_Click(object sender, EventArgs e)
    {
      this.world.removePath();
      this.clearPathSelect();
      this.forceRedraw = true;
      this.world.pushSetupStack("PathMode: Deleted Path");
    }

    private void clearPathSelect()
    {
      this.hidePathButtons();
      this.path_dgv.Rows.Clear();
      this.path_gb.Visible = false;
      this.col_selPath_btn.Visible = false;
    }

    private void updateNode()
    {
      short num = 0;
      this.world.updateNode(this.node18_tb.Text == "" ? num : Convert.ToInt16(this.node18_tb.Text, 16), this.nodeX_tb.Text == "" ? num : Convert.ToInt16(this.nodeX_tb.Text), this.nodeY_tb.Text == "" ? num : Convert.ToInt16(this.nodeY_tb.Text), this.nodeZ_tb.Text == "" ? num : Convert.ToInt16(this.nodeZ_tb.Text));
      this.world.pushSetupStack("PathMode: Updated Node");
      this.forceRedraw = true;
      this.updateEditInfo();
      this.Refresh();
    }

    private void updateSNode()
    {
      short num = 0;
      this.world.updateSNode(this.node18_tb.Text == "" ? num : Convert.ToInt16(this.node18_tb.Text, 16), this.sNodeF_tb.Text == "" ? 0.0f : Convert.ToSingle(this.sNodeF_tb.Text), this.sNodeW1_tb.Text == "" ? (int) num : Convert.ToInt32(this.sNodeW1_tb.Text, 16), this.usePause_cb.Checked, this.useSpeed_cb.Checked, this.useAnimation_cb.Checked, this.pathID_tb.Text == "" ? (byte) 0 : Convert.ToByte(this.pathID_tb.Text), this.sNodeSpeed_tb.Text == "" ? (int) num : Convert.ToInt32(this.sNodeSpeed_tb.Text, 16), this.pauseTime_tb.Text == "" ? (int) num : Convert.ToInt32(this.pauseTime_tb.Text), this.sNodeUNK3_tb.Text == "" ? (int) num : Convert.ToInt32(this.sNodeUNK3_tb.Text, 16));
      this.world.pushSetupStack("PathMode:Updated Controller");
      this.forceRedraw = true;
      this.updateEditInfo();
      this.Refresh();
    }

    private void linkMode_btn_Click(object sender, EventArgs e)
    {
      if (!this.world.pathMode)
        return;
      this.world.pmode = this.world.pmode == PathMode.Link ? PathMode.None : PathMode.Link;
      this.linkMode_btn.BackColor = this.linkMode_btn.BackColor == this.inactive ? this.active : this.inactive;
      this.forceRedraw = true;
    }

    private void nodeX_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.nodeX_tb.Text, out result);
      if (e.KeyCode == Keys.Up)
        ++result;
      if (e.KeyCode == Keys.Down)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.nodeX_tb.Text = result.ToString();
        this.updateNode();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.LevelViewer.Focus();
    }

    private void nodeY_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.nodeY_tb.Text, out result);
      if (e.KeyCode == Keys.Up)
        ++result;
      if (e.KeyCode == Keys.Down)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.nodeY_tb.Text = result.ToString();
        this.updateNode();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.LevelViewer.Focus();
    }

    private void nodeZ_tb_KeyDown(object sender, KeyEventArgs e)
    {
      short result = 0;
      short.TryParse(this.nodeZ_tb.Text, out result);
      if (e.KeyCode == Keys.Up)
        ++result;
      if (e.KeyCode == Keys.Down)
        --result;
      if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
      {
        this.nodeZ_tb.Text = result.ToString();
        this.updateNode();
      }
      if (e.KeyCode != Keys.Return)
        return;
      this.LevelViewer.Focus();
    }

    private void node_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        this.updateNode();
      }
      catch (Exception ex)
      {
      }
    }

    private void sNode_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        this.updateSNode();
      }
      catch (Exception ex)
      {
      }
    }

    private void node_tb_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.LevelViewer.Focus();
    }

    private void objectNode_tb_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.LevelViewer.Focus();
    }

    private void objectNode_tb_Leave(object sender, EventArgs e)
    {
      this.world.objects[this.world.paths[this.world.selectedPath].pathObject].obj18 = Convert.ToByte(this.objectNode_tb.Text, 16);
      this.world.redrawSelectedPath();
      this.forceRedraw = true;
    }

    private void addSNode_btn_Click(object sender, EventArgs e)
    {
      this.world.addSNode();
      this.forceRedraw = true;
    }

    private void path_dgv_DoubleClick(object sender, EventArgs e)
    {
      this.disableAllPathModes();
      if (this.world.selectedPath == -1)
        return;
      try
      {
        this.world.clearSelectedNodes();
        this.world.selectNode((int) this.path_dgv.SelectedRows[0].Cells[0].Value);
        this.unlockPathSettings();
        this.updateEditInfo();
        this.forceRedraw = true;
      }
      catch
      {
      }
    }

    private void animation_cb_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!this.processControllerEvents)
        return;
      this.world.setAnimationOnNode(this.everyAnimation[this.animation_cb.SelectedIndex].offset);
      this.updateEditInfo();
      this.forceRedraw = true;
    }

    private void deselectPathToolStripMenuItem_Click(object sender, EventArgs e) => this.clearSelection();

    private void midiToolToolStripMenuItem_Click(object sender, EventArgs e)
    {
      MidiToolForm midiToolForm = new MidiToolForm(ref this.rom, this.outDir);
      int num1 = (int) midiToolForm.ShowDialog();
      if (midiToolForm.updatedMidis.Count <= 0)
        return;
      for (int index = 0; index < midiToolForm.updatedMidis.Count; ++index)
        this.injectFile(this.outDir, midiToolForm.updatedMidis[index].ToString("x"), midiToolForm.updatedMidis[index], 0, false);
      int num2 = (int) MessageBox.Show(this.inRom + " Updated");
    }

    private void modelEditorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.importPrep();
        this.timer1.Enabled = false;
        ModelViewer modelViewer = new ModelViewer(ref this.rom, this.tmpDir, this.outDir, ref this.sfl);
        int num1 = (int) modelViewer.ShowDialog();
        if (modelViewer.updatedModels.Count > 0)
        {
          for (int index = 0; index < modelViewer.updatedModels.Count; ++index)
            this.injectFile(this.outDir, modelViewer.updatedModels[index].ToString("x"), modelViewer.updatedModels[index], 0, false);
          int num2 = (int) MessageBox.Show(this.inRom + " Updated");
          foreach (string path in ((IEnumerable<string>) Directory.GetFiles(this.tmpDir, "*", SearchOption.AllDirectories)).Where<string>((Func<string, bool>) (file => Regex.IsMatch(Path.GetFileName(file), "^[\\dABCDEF]+$"))).ToArray<string>())
            File.Delete(path);
        }
        this.LevelViewer.MakeCurrent();
        this.timer1.Enabled = true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message.ToString());
        this.LevelViewer.MakeCurrent();
        this.timer1.Enabled = true;
      }
    }

    private void pauseTime_tb_Leave(object sender, EventArgs e)
    {
      try
      {
        this.updateSNode();
      }
      catch (Exception ex)
      {
      }
    }

    private void pauseTime_tb_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.LevelViewer.Focus();
    }

    private void pathControllers_dgv_DoubleClick(object sender, EventArgs e)
    {
      this.disableAllPathModes();
      if (this.world.selectedPath == -1)
        return;
      try
      {
        this.processControllerEvents = false;
        this.world.clearSelectedNodes();
        this.pathID_tb.Text = "";
        this.sNodeF_tb.Text = "";
        this.sNodeSpeed_tb.Text = "";
        this.sNodeUNK3_tb.Text = "";
        this.pauseTime_tb.Text = "";
        this.animation_cb.SelectedIndex = -1;
        this.sNodeW1_tb.Text = "";
        this.world.selectNode((int) this.pathControllers_dgv.SelectedRows[0].Cells[0].Value);
        this.unlockPathSettings();
        this.updateEditInfo();
        this.forceRedraw = true;
        this.processControllerEvents = true;
      }
      catch
      {
        this.processControllerEvents = true;
      }
    }

    private void controller_cb_Leave(object sender, EventArgs e)
    {
      if (!this.processControllerEvents)
        return;
      try
      {
        this.updateSNode();
      }
      catch (Exception ex)
      {
      }
    }

    private void cc_failsafe_cb_CheckedChanged(object sender, EventArgs e)
    {
      this.updateSize_tb.Text = this.cc_failsafe_cb.Checked ? "100" : "1";
      this.updateObject();
    }

    private void cameraMenu_Opening(object sender, CancelEventArgs e)
    {
    }

    private void undoToolStripMenuItem_Click(object sender, EventArgs e) => this.undo();

    private void historyItem_Click(object sender, EventArgs e)
    {
      if (!this.world.setStackLocation(Convert.ToInt32((sender as ToolStripMenuItem).Tag)))
        return;
      this.reloadFromStackChange();
    }

    private void cam_moveToCurrent_btn_Click(object sender, EventArgs e)
    {
      this.world.BKCameraToBBCamera(this.BBCamera);
      this.forceRedraw = true;
    }

    private void historyToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void editToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.historyToolStripMenuItem.DropDownItems.Clear();
        List<string> historyStack = this.world.getHistoryStack();
        for (int index = 0; index < historyStack.Count; ++index)
        {
          ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
          toolStripMenuItem.Name = "historyItem" + (object) index;
          toolStripMenuItem.Size = new Size(216, 22);
          toolStripMenuItem.Text = historyStack[index];
          toolStripMenuItem.Tag = (object) index.ToString();
          toolStripMenuItem.Click += new EventHandler(this.historyItem_Click);
          this.historyToolStripMenuItem.DropDownItems.Add((ToolStripItem) toolStripMenuItem);
        }
      }
      catch
      {
      }
    }

    private void spriteManagerToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SpriteEditorForm spriteEditorForm = new SpriteEditorForm();
      spriteEditorForm.outDir = this.outDir;
      int num1 = (int) spriteEditorForm.ShowDialog();
      if (!spriteEditorForm.romUpdated)
        return;
      for (int index = 0; index < spriteEditorForm.updatedSprites.Count; ++index)
      {
        string outDir = this.outDir;
        int updatedSprite1 = spriteEditorForm.updatedSprites[index];
        string file = updatedSprite1.ToString("x");
        int updatedSprite2 = spriteEditorForm.updatedSprites[index];
        this.injectFile(outDir, file, updatedSprite2, 0, false);
        try
        {
          string tmpDir = this.tmpDir;
          updatedSprite1 = spriteEditorForm.updatedSprites[index];
          string str = updatedSprite1.ToString("x");
          File.Delete(tmpDir + str);
        }
        catch
        {
        }
      }
      int num2 = (int) MessageBox.Show(this.inRom + " Updated");
    }

    private void redoToolStripMenuItem_Click(object sender, EventArgs e) => this.redo();

    private void drawDist_tb_Leave(object sender, EventArgs e) => this.world.drawDistance = Convert.ToSingle(this.drawDist_tb.Text);

    private void LevelViewer_Load(object sender, EventArgs e)
    {
      this.loaded = true;
      this.LevelViewer.MakeCurrent();
      this.timer1.Enabled = true;
      this.world.InitGl();
      BBUI.Setup();
      this.world.core.SetView(this.LevelViewer.Height, this.LevelViewer.Width);
      this.world.RenderScene(this.replacedModel, this.replacedModelEx);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      DataGridViewCellStyle gridViewCellStyle1 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle2 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle3 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle4 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle5 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle6 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle7 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle8 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle9 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle10 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle11 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle12 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle13 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle14 = new DataGridViewCellStyle();
      DataGridViewCellStyle gridViewCellStyle15 = new DataGridViewCellStyle();
      this.SetupFileOpenDialog = new OpenFileDialog();
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.openRomToolStripMenuItem = new ToolStripMenuItem();
      this.openSetupFileToolStripMenuItem = new ToolStripMenuItem();
      this.loadSetupFileToolStripMenuItem = new ToolStripMenuItem();
      this.saveSetupFileToolStripMenuItem = new ToolStripMenuItem();
      this.save_tsmi = new ToolStripMenuItem();
      this.saveAsRomToolStripMenuItem = new ToolStripMenuItem();
      this.saveAsRomskillToolStripMenuItem = new ToolStripMenuItem();
      this.editToolStripMenuItem = new ToolStripMenuItem();
      this.undoToolStripMenuItem = new ToolStripMenuItem();
      this.redoToolStripMenuItem = new ToolStripMenuItem();
      this.historyToolStripMenuItem = new ToolStripMenuItem();
      this.optionsToolStripMenuItem = new ToolStripMenuItem();
      this.knowAllMovesToolStripMenuItem = new ToolStripMenuItem();
      this.haveNoMovesToolStripMenuItem = new ToolStripMenuItem();
      this.includeCameraTriggersWhenSavingToolStripMenuItem = new ToolStripMenuItem();
      this.removeNumbersFromNotedoorToolStripMenuItem = new ToolStripMenuItem();
      this.hideUnknownBytesToolStripMenuItem = new ToolStripMenuItem();
      this.toolsToolStripMenuItem = new ToolStripMenuItem();
      this.importObjToolStripMenuItem = new ToolStripMenuItem();
      this.modelEditorToolStripMenuItem = new ToolStripMenuItem();
      this.textEditorToolStripMenuItem = new ToolStripMenuItem();
      this.midiToolToolStripMenuItem = new ToolStripMenuItem();
      this.puzzleEditorToolStripMenuItem = new ToolStripMenuItem();
      this.injectorInToolStripMenuItem = new ToolStripMenuItem();
      this.sNSEditorToolStripMenuItem = new ToolStripMenuItem();
      this.spriteManagerToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.folderBrowserDialog1 = new FolderBrowserDialog();
      this.objectImages_il = new ImageList(this.components);
      this.textUpdate_gb = new GroupBox();
      this.updateRad_tb = new TextBox();
      this.rad_lbl = new Label();
      this.flag_tb = new TextBox();
      this.flag_lbl = new Label();
      this.address_lbl = new Label();
      this.tableLayoutPanel4 = new TableLayoutPanel();
      this.updateB17_tb = new TextBox();
      this.updateB16_tb = new TextBox();
      this.b10_lbl = new Label();
      this.updateB10_tb = new TextBox();
      this.updateB18_tb = new TextBox();
      this.updateB13_tb = new TextBox();
      this.b18_lbl = new Label();
      this.b11_lbl = new Label();
      this.updateB11_tb = new TextBox();
      this.b13_lbl = new Label();
      this.b16_lbl = new Label();
      this.b17_lbl = new Label();
      this.tableLayoutPanel3 = new TableLayoutPanel();
      this.label19 = new Label();
      this.updateX_tb = new TextBox();
      this.label17 = new Label();
      this.label18 = new Label();
      this.updateY_tb = new TextBox();
      this.updateZ_tb = new TextBox();
      this.size_lbl = new Label();
      this.rotByte_lbl = new Label();
      this.updateSize_tb = new TextBox();
      this.updateRot_tb = new TextBox();
      this.cc_failsafe_cb = new CheckBox();
      this.failsafe_lbl = new Label();
      this.objID_lbl = new Label();
      this.id_tb = new TextBox();
      this.label1 = new Label();
      this.warp_btn = new Button();
      this.warpTo_tb = new TextBox();
      this.warpTo_lbl = new Label();
      this.id_lbl = new Label();
      this.updateScript_tb = new TextBox();
      this.updateName_tb = new TextBox();
      this.script_lbl = new Label();
      this.label22 = new Label();
      this.changeLM_btn = new Button();
      this.changeLM_ofd = new OpenFileDialog();
      this.objectMenu = new ContextMenuStrip(this.components);
      this.CamSpeed_tb = new TrackBar();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label2 = new Label();
      this.baseLevel_tb = new TextBox();
      this.extraModel_tb = new TextBox();
      this.label3 = new Label();
      this.replaceModelEx_btn = new Button();
      this.replaceModel_btn = new Button();
      this.label4 = new Label();
      this.replacemodel_gb = new GroupBox();
      this.clear_btn = new Button();
      this.openFileDialog1 = new OpenFileDialog();
      this.openFileDialog2 = new OpenFileDialog();
      this.saveFileDialog = new SaveFileDialog();
      this.replaceSetup_ofd = new OpenFileDialog();
      this.saveSetupFileDialog = new SaveFileDialog();
      this.openSetupFileDialog = new OpenFileDialog();
      this.saveAsRomFileDialog = new SaveFileDialog();
      this.flowLayoutPanel1 = new FlowLayoutPanel();
      this.path_gb = new GroupBox();
      this.label11 = new Label();
      this.label10 = new Label();
      this.pathControllers_dgv = new DataGridView();
      this.nodeID_gb = new Panel();
      this.tableLayoutPanel13 = new TableLayoutPanel();
      this.label69 = new Label();
      this.nodeID_tb = new TextBox();
      this.label70 = new Label();
      this.node18_tb = new TextBox();
      this.button6 = new Button();
      this.sNode_gb = new Panel();
      this.tableLayoutPanel2 = new TableLayoutPanel();
      this.label61 = new Label();
      this.sNodeF_tb = new TextBox();
      this.label9 = new Label();
      this.pathID_tb = new TextBox();
      this.sNodeUNK3_tb = new TextBox();
      this.label67 = new Label();
      this.panel1 = new Panel();
      this.useAnimation_cb = new CheckBox();
      this.animation_cb = new ComboBox();
      this.panel2 = new Panel();
      this.usePause_cb = new CheckBox();
      this.pauseTime_tb = new TextBox();
      this.panel3 = new Panel();
      this.useSpeed_cb = new CheckBox();
      this.sNodeSpeed_tb = new TextBox();
      this.label57 = new Label();
      this.animation_lbl = new Label();
      this.label62 = new Label();
      this.label63 = new Label();
      this.sNodeW1_tb = new TextBox();
      this.button5 = new Button();
      this.nodeProperties_gb = new Panel();
      this.button4 = new Button();
      this.nodeProperties_lp = new TableLayoutPanel();
      this.label53 = new Label();
      this.nodeX_tb = new TextBox();
      this.label55 = new Label();
      this.label54 = new Label();
      this.nodeY_tb = new TextBox();
      this.nodeZ_tb = new TextBox();
      this.col_selPath_btn = new Button();
      this.pathObject_gb = new GroupBox();
      this.tableLayoutPanel16 = new TableLayoutPanel();
      this.label60 = new Label();
      this.objectNode_tb = new TextBox();
      this.path_dgv = new DataGridView();
      this.col_obj_details_btn = new Button();
      this.col_cam_btn = new Button();
      this.cam3_gb = new GroupBox();
      this.tableLayoutPanel10 = new TableLayoutPanel();
      this.label33 = new Label();
      this.label34 = new Label();
      this.label35 = new Label();
      this.camFDist_tb = new TextBox();
      this.camCDist_tb = new TextBox();
      this.label49 = new Label();
      this.label48 = new Label();
      this.camZ_tb = new TextBox();
      this.camY_tb = new TextBox();
      this.camX_tb = new TextBox();
      this.label43 = new Label();
      this.camHSpeed_tb = new TextBox();
      this.label44 = new Label();
      this.camVSpeed_tb = new TextBox();
      this.label45 = new Label();
      this.camRotation_tb = new TextBox();
      this.label46 = new Label();
      this.camAccel_tb = new TextBox();
      this.label36 = new Label();
      this.camPitch_tb = new TextBox();
      this.camYaw_tb = new TextBox();
      this.camRoll_tb = new TextBox();
      this.cam3A5_tb = new TextBox();
      this.label37 = new Label();
      this.label38 = new Label();
      this.label47 = new Label();
      this.label39 = new Label();
      this.camID_tb = new TextBox();
      this.label40 = new Label();
      this.col_replacemodel_btn = new Button();
      this.col_levelbounds_btn = new Button();
      this.bounds_gb = new GroupBox();
      this.label29 = new Label();
      this.updateBounds_btn = new Button();
      this.tableLayoutPanel8 = new TableLayoutPanel();
      this.label21 = new Label();
      this.label23 = new Label();
      this.label24 = new Label();
      this.minZ_Bounds_tb = new TextBox();
      this.minY_Bounds_tb = new TextBox();
      this.minX_Bounds_tb = new TextBox();
      this.label25 = new Label();
      this.label26 = new Label();
      this.label27 = new Label();
      this.maxX_Bounds_tb = new TextBox();
      this.maxY_Bounds_tb = new TextBox();
      this.maxZ_Bounds_tb = new TextBox();
      this.label28 = new Label();
      this.col_levelentries_btn = new Button();
      this.levelEntries_gb = new GroupBox();
      this.levelEntries_dgv = new DataGridView();
      this.col_objects_btn = new Button();
      this.objects_gb = new GroupBox();
      this.objects_dgv = new DataGridView();
      this.col_structs_btn = new Button();
      this.structs_gb = new GroupBox();
      this.structs_dgv = new DataGridView();
      this.tableLayoutPanel6 = new TableLayoutPanel();
      this.label6 = new Label();
      this.label7 = new Label();
      this.groupBox1 = new GroupBox();
      this.tableLayoutPanel7 = new TableLayoutPanel();
      this.label8 = new Label();
      this.label20 = new Label();
      this.button1 = new Button();
      this.groupBox2 = new GroupBox();
      this.label30 = new Label();
      this.button2 = new Button();
      this.tableLayoutPanel9 = new TableLayoutPanel();
      this.label31 = new Label();
      this.label32 = new Label();
      this.tableLayoutPanel11 = new TableLayoutPanel();
      this.label41 = new Label();
      this.label42 = new Label();
      this.cameraMenu = new ContextMenuStrip(this.components);
      this.createCameraToolStripMenuItem = new ToolStripMenuItem();
      this.createGameplayCameraToolStripMenuItem = new ToolStripMenuItem();
      this.createGameplayTiggerToolStripMenuItem = new ToolStripMenuItem();
      this.injectDialog = new OpenFileDialog();
      this.tableLayoutPanel14 = new TableLayoutPanel();
      this.label52 = new Label();
      this.textBox1 = new TextBox();
      this.tableLayoutPanel15 = new TableLayoutPanel();
      this.textBox2 = new TextBox();
      this.label56 = new Label();
      this.textBox3 = new TextBox();
      this.groupBox3 = new GroupBox();
      this.toolTip1 = new ToolTip(this.components);
      this.toolStrip1 = new ToolStrip();
      this.mode_lbl = new ToolStripLabel();
      this.mode_cb = new ToolStripComboBox();
      this.rectSelect_btn = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.cam_moveToCurrent_btn = new ToolStripButton();
      this.obj_move_btn = new ToolStripButton();
      this.obj_rot_btn = new ToolStripButton();
      this.obj_scale_btn = new ToolStripButton();
      this.obj_duplicate_btn = new ToolStripButton();
      this.cam_yaw_btn = new ToolStripButton();
      this.cam_pitch_btn = new ToolStripButton();
      this.cam_roll_btn = new ToolStripButton();
      this.deselect_btn = new ToolStripButton();
      this.delete_btn = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.yOffset_tb = new ToolStripTextBox();
      this.toolStripLabel2 = new ToolStripLabel();
      this.lockZ_btn = new ToolStripButton();
      this.lockY_btn = new ToolStripButton();
      this.lockX_btn = new ToolStripButton();
      this.assignObject_btn = new ToolStripButton();
      this.moveNode_btn = new ToolStripButton();
      this.linkMode_btn = new ToolStripButton();
      this.removeNode_btn = new ToolStripButton();
      this.endNode_btn = new ToolStripButton();
      this.startNewPath_btn = new ToolStripButton();
      this.addNode_btn = new ToolStripButton();
      this.addControllerNode_btn = new ToolStripButton();
      this.deselectPath_btn = new ToolStripButton();
      this.deletePath_btn = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.eraseAll_btn = new ToolStripButton();
      this.button3 = new Button();
      this.bgA_cb = new CheckBox();
      this.bgB_btn = new CheckBox();
      this.objs_cb = new CheckBox();
      this.label59 = new Label();
      this.label51 = new Label();
      this.label64 = new Label();
      this.label65 = new Label();
      this.cameras_cb = new CheckBox();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      this.levelBoundAlpha_cb = new CheckBox();
      this.label5 = new Label();
      this.levelStats_cb = new CheckBox();
      this.label14 = new Label();
      this.label58 = new Label();
      this.levelBound_cb = new CheckBox();
      this.label75 = new Label();
      this.unknownRadius_cb = new CheckBox();
      this.flagRadius_cb = new Label();
      this.showFlagRadius_cb = new CheckBox();
      this.label72 = new Label();
      this.enemyRadius_cb = new CheckBox();
      this.label71 = new Label();
      this.warpRadius_cb = new CheckBox();
      this.label66 = new Label();
      this.camTrigger_cb = new CheckBox();
      this.flowLayoutPanel2 = new FlowLayoutPanel();
      this.drawDist_tb = new TextBox();
      this.label12 = new Label();
      this.LevelViewer = new GLControl();
      this.menuStrip1.SuspendLayout();
      this.textUpdate_gb.SuspendLayout();
      this.tableLayoutPanel4.SuspendLayout();
      this.tableLayoutPanel3.SuspendLayout();
      this.CamSpeed_tb.BeginInit();
      this.replacemodel_gb.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.path_gb.SuspendLayout();
      ((ISupportInitialize) this.pathControllers_dgv).BeginInit();
      this.nodeID_gb.SuspendLayout();
      this.tableLayoutPanel13.SuspendLayout();
      this.sNode_gb.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel3.SuspendLayout();
      this.nodeProperties_gb.SuspendLayout();
      this.nodeProperties_lp.SuspendLayout();
      this.pathObject_gb.SuspendLayout();
      this.tableLayoutPanel16.SuspendLayout();
      ((ISupportInitialize) this.path_dgv).BeginInit();
      this.cam3_gb.SuspendLayout();
      this.tableLayoutPanel10.SuspendLayout();
      this.bounds_gb.SuspendLayout();
      this.tableLayoutPanel8.SuspendLayout();
      this.levelEntries_gb.SuspendLayout();
      ((ISupportInitialize) this.levelEntries_dgv).BeginInit();
      this.objects_gb.SuspendLayout();
      ((ISupportInitialize) this.objects_dgv).BeginInit();
      this.structs_gb.SuspendLayout();
      ((ISupportInitialize) this.structs_dgv).BeginInit();
      this.tableLayoutPanel6.SuspendLayout();
      this.tableLayoutPanel7.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.tableLayoutPanel9.SuspendLayout();
      this.tableLayoutPanel11.SuspendLayout();
      this.cameraMenu.SuspendLayout();
      this.tableLayoutPanel14.SuspendLayout();
      this.tableLayoutPanel15.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.BackColor = SystemColors.ActiveCaption;
      this.menuStrip1.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.editToolStripMenuItem,
        (ToolStripItem) this.optionsToolStripMenuItem,
        (ToolStripItem) this.toolsToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(1190, 24);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.openRomToolStripMenuItem,
        (ToolStripItem) this.openSetupFileToolStripMenuItem,
        (ToolStripItem) this.loadSetupFileToolStripMenuItem,
        (ToolStripItem) this.saveSetupFileToolStripMenuItem,
        (ToolStripItem) this.save_tsmi,
        (ToolStripItem) this.saveAsRomToolStripMenuItem,
        (ToolStripItem) this.saveAsRomskillToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.openRomToolStripMenuItem.Name = "openRomToolStripMenuItem";
      this.openRomToolStripMenuItem.Size = new Size(259, 22);
      this.openRomToolStripMenuItem.Text = "Open Rom";
      this.openRomToolStripMenuItem.Click += new EventHandler(this.openRomToolStripMenuItem_Click);
      this.openSetupFileToolStripMenuItem.Enabled = false;
      this.openSetupFileToolStripMenuItem.Name = "openSetupFileToolStripMenuItem";
      this.openSetupFileToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Control;
      this.openSetupFileToolStripMenuItem.Size = new Size(259, 22);
      this.openSetupFileToolStripMenuItem.Text = "Open Setup File From Rom";
      this.openSetupFileToolStripMenuItem.Click += new EventHandler(this.openSetupFileToolStripMenuItem_Click);
      this.loadSetupFileToolStripMenuItem.Enabled = false;
      this.loadSetupFileToolStripMenuItem.Name = "loadSetupFileToolStripMenuItem";
      this.loadSetupFileToolStripMenuItem.ShortcutKeys = Keys.L | Keys.Control;
      this.loadSetupFileToolStripMenuItem.Size = new Size(259, 22);
      this.loadSetupFileToolStripMenuItem.Text = "Load Setup File";
      this.loadSetupFileToolStripMenuItem.Click += new EventHandler(this.loadSetupFileToolStripMenuItem_Click);
      this.saveSetupFileToolStripMenuItem.Enabled = false;
      this.saveSetupFileToolStripMenuItem.Name = "saveSetupFileToolStripMenuItem";
      this.saveSetupFileToolStripMenuItem.Size = new Size(259, 22);
      this.saveSetupFileToolStripMenuItem.Text = "Save Setup File";
      this.saveSetupFileToolStripMenuItem.Click += new EventHandler(this.saveSetupFileToolStripMenuItem_Click);
      this.save_tsmi.Enabled = false;
      this.save_tsmi.Name = "save_tsmi";
      this.save_tsmi.ShortcutKeys = Keys.S | Keys.Control;
      this.save_tsmi.Size = new Size(259, 22);
      this.save_tsmi.Text = "Save To Rom";
      this.save_tsmi.Click += new EventHandler(this.save_tsmi_Click);
      this.saveAsRomToolStripMenuItem.Enabled = false;
      this.saveAsRomToolStripMenuItem.Name = "saveAsRomToolStripMenuItem";
      this.saveAsRomToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Shift | Keys.Control;
      this.saveAsRomToolStripMenuItem.Size = new Size(259, 22);
      this.saveAsRomToolStripMenuItem.Text = "Save As Rom";
      this.saveAsRomToolStripMenuItem.Click += new EventHandler(this.saveAsRomToolStripMenuItem_Click);
      this.saveAsRomskillToolStripMenuItem.Name = "saveAsRomskillToolStripMenuItem";
      this.saveAsRomskillToolStripMenuItem.Size = new Size(259, 22);
      this.saveAsRomskillToolStripMenuItem.Text = "Save As Rom (injected)";
      this.saveAsRomskillToolStripMenuItem.Visible = false;
      this.saveAsRomskillToolStripMenuItem.Click += new EventHandler(this.saveAsRomskillToolStripMenuItem_Click);
      this.editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.undoToolStripMenuItem,
        (ToolStripItem) this.redoToolStripMenuItem,
        (ToolStripItem) this.historyToolStripMenuItem
      });
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new Size(39, 20);
      this.editToolStripMenuItem.Text = "Edit";
      this.editToolStripMenuItem.Click += new EventHandler(this.editToolStripMenuItem_Click);
      this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
      this.undoToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+Z";
      this.undoToolStripMenuItem.Size = new Size(153, 22);
      this.undoToolStripMenuItem.Text = "Undo";
      this.undoToolStripMenuItem.Click += new EventHandler(this.undoToolStripMenuItem_Click);
      this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
      this.redoToolStripMenuItem.ShortcutKeyDisplayString = "CTRL+Y";
      this.redoToolStripMenuItem.Size = new Size(153, 22);
      this.redoToolStripMenuItem.Text = "Redo";
      this.redoToolStripMenuItem.Click += new EventHandler(this.redoToolStripMenuItem_Click);
      this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
      this.historyToolStripMenuItem.Size = new Size(153, 22);
      this.historyToolStripMenuItem.Text = "History";
      this.historyToolStripMenuItem.Click += new EventHandler(this.historyToolStripMenuItem_Click);
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.knowAllMovesToolStripMenuItem,
        (ToolStripItem) this.haveNoMovesToolStripMenuItem,
        (ToolStripItem) this.includeCameraTriggersWhenSavingToolStripMenuItem,
        (ToolStripItem) this.removeNumbersFromNotedoorToolStripMenuItem,
        (ToolStripItem) this.hideUnknownBytesToolStripMenuItem
      });
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new Size(61, 20);
      this.optionsToolStripMenuItem.Text = "Options";
      this.knowAllMovesToolStripMenuItem.Enabled = false;
      this.knowAllMovesToolStripMenuItem.Name = "knowAllMovesToolStripMenuItem";
      this.knowAllMovesToolStripMenuItem.Size = new Size(267, 22);
      this.knowAllMovesToolStripMenuItem.Text = "Have all moves";
      this.knowAllMovesToolStripMenuItem.Click += new EventHandler(this.knowAllMovesToolStripMenuItem_Click);
      this.haveNoMovesToolStripMenuItem.Enabled = false;
      this.haveNoMovesToolStripMenuItem.Name = "haveNoMovesToolStripMenuItem";
      this.haveNoMovesToolStripMenuItem.Size = new Size(267, 22);
      this.haveNoMovesToolStripMenuItem.Text = "Have no moves";
      this.haveNoMovesToolStripMenuItem.Click += new EventHandler(this.haveNoMovesToolStripMenuItem_Click);
      this.includeCameraTriggersWhenSavingToolStripMenuItem.Checked = true;
      this.includeCameraTriggersWhenSavingToolStripMenuItem.CheckState = CheckState.Checked;
      this.includeCameraTriggersWhenSavingToolStripMenuItem.Name = "includeCameraTriggersWhenSavingToolStripMenuItem";
      this.includeCameraTriggersWhenSavingToolStripMenuItem.Size = new Size(267, 22);
      this.includeCameraTriggersWhenSavingToolStripMenuItem.Text = "Include camera triggers when saving";
      this.includeCameraTriggersWhenSavingToolStripMenuItem.Click += new EventHandler(this.includeCameraTriggersWhenSavingToolStripMenuItem_Click);
      this.removeNumbersFromNotedoorToolStripMenuItem.Enabled = false;
      this.removeNumbersFromNotedoorToolStripMenuItem.Name = "removeNumbersFromNotedoorToolStripMenuItem";
      this.removeNumbersFromNotedoorToolStripMenuItem.Size = new Size(267, 22);
      this.removeNumbersFromNotedoorToolStripMenuItem.Text = "Remove Numbers from Note Doors";
      this.removeNumbersFromNotedoorToolStripMenuItem.Click += new EventHandler(this.removeNumbersFromNotedoorToolStripMenuItem_Click);
      this.hideUnknownBytesToolStripMenuItem.Checked = true;
      this.hideUnknownBytesToolStripMenuItem.CheckState = CheckState.Checked;
      this.hideUnknownBytesToolStripMenuItem.Name = "hideUnknownBytesToolStripMenuItem";
      this.hideUnknownBytesToolStripMenuItem.Size = new Size(267, 22);
      this.hideUnknownBytesToolStripMenuItem.Text = "Hide Unknown Bytes";
      this.hideUnknownBytesToolStripMenuItem.Click += new EventHandler(this.hideUnknownBytesToolStripMenuItem_Click);
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.importObjToolStripMenuItem,
        (ToolStripItem) this.modelEditorToolStripMenuItem,
        (ToolStripItem) this.textEditorToolStripMenuItem,
        (ToolStripItem) this.midiToolToolStripMenuItem,
        (ToolStripItem) this.puzzleEditorToolStripMenuItem,
        (ToolStripItem) this.injectorInToolStripMenuItem,
        (ToolStripItem) this.sNSEditorToolStripMenuItem,
        (ToolStripItem) this.spriteManagerToolStripMenuItem
      });
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new Size(47, 20);
      this.toolsToolStripMenuItem.Text = "Tools";
      this.toolsToolStripMenuItem.Click += new EventHandler(this.toolsToolStripMenuItem_Click);
      this.importObjToolStripMenuItem.Name = "importObjToolStripMenuItem";
      this.importObjToolStripMenuItem.Size = new Size(193, 22);
      this.importObjToolStripMenuItem.Text = "Model Importer";
      this.importObjToolStripMenuItem.Click += new EventHandler(this.importObjToolStripMenuItem_Click);
      this.modelEditorToolStripMenuItem.Name = "modelEditorToolStripMenuItem";
      this.modelEditorToolStripMenuItem.Size = new Size(193, 22);
      this.modelEditorToolStripMenuItem.Text = "Model Viewer";
      this.modelEditorToolStripMenuItem.Click += new EventHandler(this.modelEditorToolStripMenuItem_Click);
      this.textEditorToolStripMenuItem.Enabled = false;
      this.textEditorToolStripMenuItem.Name = "textEditorToolStripMenuItem";
      this.textEditorToolStripMenuItem.Size = new Size(193, 22);
      this.textEditorToolStripMenuItem.Text = "Text Editor";
      this.textEditorToolStripMenuItem.Click += new EventHandler(this.textEditorToolStripMenuItem_Click);
      this.midiToolToolStripMenuItem.Enabled = false;
      this.midiToolToolStripMenuItem.Name = "midiToolToolStripMenuItem";
      this.midiToolToolStripMenuItem.Size = new Size(193, 22);
      this.midiToolToolStripMenuItem.Text = "Midi Tool";
      this.midiToolToolStripMenuItem.Click += new EventHandler(this.midiToolToolStripMenuItem_Click);
      this.puzzleEditorToolStripMenuItem.Enabled = false;
      this.puzzleEditorToolStripMenuItem.Name = "puzzleEditorToolStripMenuItem";
      this.puzzleEditorToolStripMenuItem.Size = new Size(193, 22);
      this.puzzleEditorToolStripMenuItem.Text = "General Game Settings";
      this.puzzleEditorToolStripMenuItem.Click += new EventHandler(this.puzzleEditorToolStripMenuItem_Click);
      this.injectorInToolStripMenuItem.Name = "injectorInToolStripMenuItem";
      this.injectorInToolStripMenuItem.Size = new Size(193, 22);
      this.injectorInToolStripMenuItem.Text = "Injector";
      this.injectorInToolStripMenuItem.Visible = false;
      this.sNSEditorToolStripMenuItem.Enabled = false;
      this.sNSEditorToolStripMenuItem.Name = "sNSEditorToolStripMenuItem";
      this.sNSEditorToolStripMenuItem.Size = new Size(193, 22);
      this.sNSEditorToolStripMenuItem.Text = "SNS Editor";
      this.sNSEditorToolStripMenuItem.Visible = false;
      this.sNSEditorToolStripMenuItem.Click += new EventHandler(this.sNSEditorToolStripMenuItem_Click);
      this.spriteManagerToolStripMenuItem.Name = "spriteManagerToolStripMenuItem";
      this.spriteManagerToolStripMenuItem.Size = new Size(193, 22);
      this.spriteManagerToolStripMenuItem.Text = "Sprite Manager";
      this.spriteManagerToolStripMenuItem.Click += new EventHandler(this.spriteManagerToolStripMenuItem_Click);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.aboutToolStripMenuItem
      });
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(44, 20);
      this.helpToolStripMenuItem.Text = "Help";
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.ShortcutKeys = Keys.H | Keys.Control;
      this.aboutToolStripMenuItem.Size = new Size(150, 22);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new EventHandler(this.aboutToolStripMenuItem_Click);
      this.objectImages_il.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("objectImages_il.ImageStream");
      this.objectImages_il.TransparentColor = Color.Transparent;
      this.objectImages_il.Images.SetKeyName(0, "AnicentOne_head.png");
      this.objectImages_il.Images.SetKeyName(1, "Ant_Head.png");
      this.objectImages_il.Images.SetKeyName(2, "Banjo_Head.png");
      this.objectImages_il.Images.SetKeyName(3, "BeeHive_Head.png");
      this.objectImages_il.Images.SetKeyName(4, "Blubber_Head.png");
      this.objectImages_il.Images.SetKeyName(5, "BlueEgg_Head.png");
      this.objectImages_il.Images.SetKeyName(6, "BluePresent_Head.png");
      this.objectImages_il.Images.SetKeyName(7, "Boggy_Head.png");
      this.objectImages_il.Images.SetKeyName(8, "Boggy_Kid1_Head.png");
      this.objectImages_il.Images.SetKeyName(9, "Bottles_Head.png");
      this.objectImages_il.Images.SetKeyName(10, "Box_Head.png");
      this.objectImages_il.Images.SetKeyName(11, "Brentilda_Head.png");
      this.objectImages_il.Images.SetKeyName(12, "Caterpiller_Head.png");
      this.objectImages_il.Images.SetKeyName(13, "Charmer_Head.png");
      this.objectImages_il.Images.SetKeyName(14, "Cheato_Head.png");
      this.objectImages_il.Images.SetKeyName(15, "Chest_Head.png");
      this.objectImages_il.Images.SetKeyName(16, "Chimpy_Head.png");
      this.objectImages_il.Images.SetKeyName(17, "Chomp_Head.png");
      this.objectImages_il.Images.SetKeyName(18, "Claim_Head.png");
      this.objectImages_il.Images.SetKeyName(19, "Clanker_Head.png");
      this.objectImages_il.Images.SetKeyName(20, "Clock_Head.png");
      this.objectImages_il.Images.SetKeyName(21, "Coldron_Head.png");
      this.objectImages_il.Images.SetKeyName(22, "Conga_Head.png");
      this.objectImages_il.Images.SetKeyName(23, "Crab_Head.png");
      this.objectImages_il.Images.SetKeyName(24, "CrocBanjo_Head.png");
      this.objectImages_il.Images.SetKeyName(25, "Croccos_Head.png");
      this.objectImages_il.Images.SetKeyName(26, "Dingpot_Head.png");
      this.objectImages_il.Images.SetKeyName(27, "Earie1_Head.png");
      this.objectImages_il.Images.SetKeyName(28, "Earie2_Head.png");
      this.objectImages_il.Images.SetKeyName(29, "EmptyCup_Head.png");
      this.objectImages_il.Images.SetKeyName(30, "EmptyHoneyComb_Head.png");
      this.objectImages_il.Images.SetKeyName(31, "ExtraHoneyComb_Head.png");
      this.objectImages_il.Images.SetKeyName(32, "ExtraLife_Head.png");
      this.objectImages_il.Images.SetKeyName(33, "Flip_Head.png");
      this.objectImages_il.Images.SetKeyName(34, "Ghoul_Head.png");
      this.objectImages_il.Images.SetKeyName(35, "Gloop_Head.png");
      this.objectImages_il.Images.SetKeyName(36, "Gnawty_Head.png");
      this.objectImages_il.Images.SetKeyName(37, "Gobi_Head.png");
      this.objectImages_il.Images.SetKeyName(38, "GoldBars_Head.png");
      this.objectImages_il.Images.SetKeyName(39, "GoldFeather_Head.png");
      this.objectImages_il.Images.SetKeyName(40, "GreenPresent_Head.png");
      this.objectImages_il.Images.SetKeyName(41, "Grunty_Head.png");
      this.objectImages_il.Images.SetKeyName(42, "HoneyComb_Head.png");
      this.objectImages_il.Images.SetKeyName(43, "Ice_Head.png");
      this.objectImages_il.Images.SetKeyName(44, "Jiggy_Head.png");
      this.objectImages_il.Images.SetKeyName(45, "JinjoBlue_Head.png");
      this.objectImages_il.Images.SetKeyName(46, "JinjoGreen_Head.png");
      this.objectImages_il.Images.SetKeyName(47, "JinjoOrange_Head.png");
      this.objectImages_il.Images.SetKeyName(48, "JinjoPurple_Head.png");
      this.objectImages_il.Images.SetKeyName(49, "JinjoYellow_Head.png");
      this.objectImages_il.Images.SetKeyName(50, "Kazooie_Head.png");
      this.objectImages_il.Images.SetKeyName(51, "Klungo_Head.png");
      this.objectImages_il.Images.SetKeyName(52, "Leaky_Head.png");
      this.objectImages_il.Images.SetKeyName(53, "Loggo_Head.png");
      this.objectImages_il.Images.SetKeyName(54, "Mozzartz_Head.png");
      this.objectImages_il.Images.SetKeyName(55, "MrVile_Head.png");
      this.objectImages_il.Images.SetKeyName(56, "Mumbo_Head.png");
      this.objectImages_il.Images.SetKeyName(57, "MumboToken_Head.png");
      this.objectImages_il.Images.SetKeyName(58, "Mummy_Head.png");
      this.objectImages_il.Images.SetKeyName(59, "Note_Head.png");
      this.objectImages_il.Images.SetKeyName(60, "Nubnut_Head.png");
      this.objectImages_il.Images.SetKeyName(61, "Orange_Head.png");
      this.objectImages_il.Images.SetKeyName(62, "Pirana_Head.png");
      this.objectImages_il.Images.SetKeyName(63, "RedCrab_Head.png");
      this.objectImages_il.Images.SetKeyName(64, "RedFeather_Head.png");
      this.objectImages_il.Images.SetKeyName(65, "RedPresent_Head.png");
      this.objectImages_il.Images.SetKeyName(66, "RunningShoes_Head.png");
      this.objectImages_il.Images.SetKeyName(67, "SexyGrunty_Head.png");
      this.objectImages_il.Images.SetKeyName(68, "Slapper.png");
      this.objectImages_il.Images.SetKeyName(69, "Snacker_Head.png");
      this.objectImages_il.Images.SetKeyName(70, "Snake_Head.png");
      this.objectImages_il.Images.SetKeyName(71, "Snipper_Head.png");
      this.objectImages_il.Images.SetKeyName(72, "Snorkles_Head.png");
      this.objectImages_il.Images.SetKeyName(73, "Sphinix_Head.png");
      this.objectImages_il.Images.SetKeyName(74, "TipTop_Head.png");
      this.objectImages_il.Images.SetKeyName(75, "TipTopJr_Head.png");
      this.objectImages_il.Images.SetKeyName(76, "Tooty_Head.png");
      this.objectImages_il.Images.SetKeyName(77, "Totem_Head.png");
      this.objectImages_il.Images.SetKeyName(78, "Tree_Head.png");
      this.objectImages_il.Images.SetKeyName(79, "Turtle_Head.png");
      this.objectImages_il.Images.SetKeyName(80, "Twinkle_Head.png");
      this.objectImages_il.Images.SetKeyName(81, "UglyTooty_Head.png");
      this.objectImages_il.Images.SetKeyName(82, "unknown.png");
      this.objectImages_il.Images.SetKeyName(83, "WaddingBoots_Head.png");
      this.objectImages_il.Images.SetKeyName(84, "Wazza_Head.png");
      this.objectImages_il.Images.SetKeyName(85, "Zumba_Head.png");
      this.textUpdate_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.textUpdate_gb.Controls.Add((Control) this.updateRad_tb);
      this.textUpdate_gb.Controls.Add((Control) this.rad_lbl);
      this.textUpdate_gb.Controls.Add((Control) this.flag_tb);
      this.textUpdate_gb.Controls.Add((Control) this.flag_lbl);
      this.textUpdate_gb.Controls.Add((Control) this.address_lbl);
      this.textUpdate_gb.Controls.Add((Control) this.tableLayoutPanel4);
      this.textUpdate_gb.Controls.Add((Control) this.tableLayoutPanel3);
      this.textUpdate_gb.Controls.Add((Control) this.objID_lbl);
      this.textUpdate_gb.Controls.Add((Control) this.id_tb);
      this.textUpdate_gb.Controls.Add((Control) this.label1);
      this.textUpdate_gb.Controls.Add((Control) this.warp_btn);
      this.textUpdate_gb.Controls.Add((Control) this.warpTo_tb);
      this.textUpdate_gb.Controls.Add((Control) this.warpTo_lbl);
      this.textUpdate_gb.Controls.Add((Control) this.id_lbl);
      this.textUpdate_gb.Controls.Add((Control) this.updateScript_tb);
      this.textUpdate_gb.Controls.Add((Control) this.updateName_tb);
      this.textUpdate_gb.Controls.Add((Control) this.script_lbl);
      this.textUpdate_gb.Controls.Add((Control) this.label22);
      this.textUpdate_gb.Location = new Point(3, 781);
      this.textUpdate_gb.Name = "textUpdate_gb";
      this.textUpdate_gb.Padding = new Padding(0);
      this.textUpdate_gb.Size = new Size(200, 317);
      this.textUpdate_gb.TabIndex = 4;
      this.textUpdate_gb.TabStop = false;
      this.updateRad_tb.Location = new Point(149, 62);
      this.updateRad_tb.Name = "updateRad_tb";
      this.updateRad_tb.Size = new Size(45, 20);
      this.updateRad_tb.TabIndex = 17;
      this.updateRad_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.updateRad_tb.KeyUp += new KeyEventHandler(this.updateRad_tb_KeyUp);
      this.updateRad_tb.Leave += new EventHandler(this.updateRad_tb_Leave);
      this.rad_lbl.AutoSize = true;
      this.rad_lbl.Location = new Point(106, 65);
      this.rad_lbl.Name = "rad_lbl";
      this.rad_lbl.Size = new Size(40, 13);
      this.rad_lbl.TabIndex = 65;
      this.rad_lbl.Text = "Radius";
      this.flag_tb.Location = new Point(58, 61);
      this.flag_tb.Name = "flag_tb";
      this.flag_tb.Size = new Size(45, 20);
      this.flag_tb.TabIndex = 16;
      this.flag_lbl.AutoSize = true;
      this.flag_lbl.Location = new Point(4, 62);
      this.flag_lbl.Name = "flag_lbl";
      this.flag_lbl.Size = new Size(27, 13);
      this.flag_lbl.TabIndex = 62;
      this.flag_lbl.Text = "Flag";
      this.address_lbl.AutoSize = true;
      this.address_lbl.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.address_lbl.Location = new Point(136, 288);
      this.address_lbl.Name = "address_lbl";
      this.address_lbl.Size = new Size(24, 13);
      this.address_lbl.TabIndex = 42;
      this.address_lbl.Text = "0x0";
      this.tableLayoutPanel4.ColumnCount = 4;
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel4.Controls.Add((Control) this.updateB17_tb, 3, 2);
      this.tableLayoutPanel4.Controls.Add((Control) this.updateB16_tb, 1, 2);
      this.tableLayoutPanel4.Controls.Add((Control) this.b10_lbl, 0, 0);
      this.tableLayoutPanel4.Controls.Add((Control) this.updateB10_tb, 1, 0);
      this.tableLayoutPanel4.Controls.Add((Control) this.updateB18_tb, 3, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.updateB13_tb, 3, 0);
      this.tableLayoutPanel4.Controls.Add((Control) this.b18_lbl, 2, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.b11_lbl, 0, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.updateB11_tb, 1, 1);
      this.tableLayoutPanel4.Controls.Add((Control) this.b13_lbl, 2, 0);
      this.tableLayoutPanel4.Controls.Add((Control) this.b16_lbl, 0, 2);
      this.tableLayoutPanel4.Controls.Add((Control) this.b17_lbl, 2, 2);
      this.tableLayoutPanel4.Location = new Point(-1, 185);
      this.tableLayoutPanel4.Name = "tableLayoutPanel4";
      this.tableLayoutPanel4.RowCount = 3;
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel4.Size = new Size(190, 71);
      this.tableLayoutPanel4.TabIndex = 61;
      this.updateB17_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateB17_tb.Location = new Point(144, 53);
      this.updateB17_tb.Name = "updateB17_tb";
      this.updateB17_tb.Size = new Size(43, 20);
      this.updateB17_tb.TabIndex = 63;
      this.updateB17_tb.Leave += new EventHandler(this.updateB11_tb_Leave);
      this.updateB16_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateB16_tb.Location = new Point(50, 53);
      this.updateB16_tb.Name = "updateB16_tb";
      this.updateB16_tb.Size = new Size(41, 20);
      this.updateB16_tb.TabIndex = 62;
      this.updateB16_tb.Leave += new EventHandler(this.updateB11_tb_Leave);
      this.b10_lbl.AutoSize = true;
      this.b10_lbl.Location = new Point(3, 0);
      this.b10_lbl.Name = "b10_lbl";
      this.b10_lbl.Size = new Size(26, 13);
      this.b10_lbl.TabIndex = 50;
      this.b10_lbl.Text = "B10";
      this.updateB10_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateB10_tb.Enabled = false;
      this.updateB10_tb.Location = new Point(50, 3);
      this.updateB10_tb.Name = "updateB10_tb";
      this.updateB10_tb.Size = new Size(41, 20);
      this.updateB10_tb.TabIndex = 23;
      this.updateB10_tb.KeyDown += new KeyEventHandler(this.updateB10_tb_KeyDown);
      this.updateB10_tb.Leave += new EventHandler(this.updateB10_tb_Leave);
      this.updateB18_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateB18_tb.Enabled = false;
      this.updateB18_tb.Location = new Point(144, 28);
      this.updateB18_tb.Name = "updateB18_tb";
      this.updateB18_tb.Size = new Size(43, 20);
      this.updateB18_tb.TabIndex = 26;
      this.updateB18_tb.KeyDown += new KeyEventHandler(this.updateB18_tb_KeyDown);
      this.updateB18_tb.Leave += new EventHandler(this.updateB18_tb_Leave);
      this.updateB13_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateB13_tb.Enabled = false;
      this.updateB13_tb.Location = new Point(144, 3);
      this.updateB13_tb.Name = "updateB13_tb";
      this.updateB13_tb.Size = new Size(43, 20);
      this.updateB13_tb.TabIndex = 24;
      this.updateB13_tb.KeyDown += new KeyEventHandler(this.updateB13_tb_KeyDown);
      this.updateB13_tb.Leave += new EventHandler(this.updateB13_tb_Leave);
      this.b18_lbl.AutoSize = true;
      this.b18_lbl.Location = new Point(97, 25);
      this.b18_lbl.Name = "b18_lbl";
      this.b18_lbl.Size = new Size(26, 13);
      this.b18_lbl.TabIndex = 59;
      this.b18_lbl.Text = "B18";
      this.b11_lbl.AutoSize = true;
      this.b11_lbl.Location = new Point(3, 25);
      this.b11_lbl.Name = "b11_lbl";
      this.b11_lbl.Size = new Size(26, 13);
      this.b11_lbl.TabIndex = 51;
      this.b11_lbl.Text = "B11";
      this.updateB11_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateB11_tb.Enabled = false;
      this.updateB11_tb.Location = new Point(50, 28);
      this.updateB11_tb.Name = "updateB11_tb";
      this.updateB11_tb.Size = new Size(41, 20);
      this.updateB11_tb.TabIndex = 25;
      this.updateB11_tb.KeyDown += new KeyEventHandler(this.updateB11_tb_KeyDown);
      this.updateB11_tb.Leave += new EventHandler(this.updateB11_tb_Leave);
      this.b13_lbl.AutoSize = true;
      this.b13_lbl.Location = new Point(97, 0);
      this.b13_lbl.Name = "b13_lbl";
      this.b13_lbl.Size = new Size(26, 13);
      this.b13_lbl.TabIndex = 52;
      this.b13_lbl.Text = "B13";
      this.b16_lbl.AutoSize = true;
      this.b16_lbl.Location = new Point(3, 50);
      this.b16_lbl.Name = "b16_lbl";
      this.b16_lbl.Size = new Size(26, 13);
      this.b16_lbl.TabIndex = 60;
      this.b16_lbl.Text = "B16";
      this.b17_lbl.AutoSize = true;
      this.b17_lbl.Location = new Point(97, 50);
      this.b17_lbl.Name = "b17_lbl";
      this.b17_lbl.Size = new Size(26, 13);
      this.b17_lbl.TabIndex = 61;
      this.b17_lbl.Text = "B17";
      this.tableLayoutPanel3.ColumnCount = 4;
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
      this.tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5f));
      this.tableLayoutPanel3.Controls.Add((Control) this.label19, 0, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.updateX_tb, 1, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.label17, 0, 2);
      this.tableLayoutPanel3.Controls.Add((Control) this.label18, 0, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.updateY_tb, 1, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.updateZ_tb, 1, 2);
      this.tableLayoutPanel3.Controls.Add((Control) this.size_lbl, 2, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.rotByte_lbl, 2, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.updateSize_tb, 3, 0);
      this.tableLayoutPanel3.Controls.Add((Control) this.updateRot_tb, 3, 1);
      this.tableLayoutPanel3.Controls.Add((Control) this.cc_failsafe_cb, 3, 2);
      this.tableLayoutPanel3.Controls.Add((Control) this.failsafe_lbl, 2, 2);
      this.tableLayoutPanel3.Location = new Point(-1, 100);
      this.tableLayoutPanel3.Margin = new Padding(0);
      this.tableLayoutPanel3.Name = "tableLayoutPanel3";
      this.tableLayoutPanel3.RowCount = 3;
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel3.Size = new Size(190, 83);
      this.tableLayoutPanel3.TabIndex = 60;
      this.label19.AutoSize = true;
      this.label19.Location = new Point(3, 0);
      this.label19.Name = "label19";
      this.label19.Size = new Size(13, 13);
      this.label19.TabIndex = 28;
      this.label19.Text = "X";
      this.updateX_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateX_tb.Enabled = false;
      this.updateX_tb.Location = new Point(22, 3);
      this.updateX_tb.Name = "updateX_tb";
      this.updateX_tb.Size = new Size(51, 20);
      this.updateX_tb.TabIndex = 18;
      this.updateX_tb.KeyDown += new KeyEventHandler(this.updateX_tb_KeyDown);
      this.updateX_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.updateX_tb.Leave += new EventHandler(this.objectPropertyLeave);
      this.label17.AutoSize = true;
      this.label17.Location = new Point(3, 54);
      this.label17.Name = "label17";
      this.label17.Size = new Size(13, 13);
      this.label17.TabIndex = 30;
      this.label17.Text = "Z";
      this.label18.AutoSize = true;
      this.label18.Location = new Point(3, 27);
      this.label18.Name = "label18";
      this.label18.Size = new Size(13, 13);
      this.label18.TabIndex = 29;
      this.label18.Text = "Y";
      this.updateY_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateY_tb.Enabled = false;
      this.updateY_tb.Location = new Point(22, 30);
      this.updateY_tb.Name = "updateY_tb";
      this.updateY_tb.Size = new Size(51, 20);
      this.updateY_tb.TabIndex = 19;
      this.updateY_tb.KeyDown += new KeyEventHandler(this.updateY_tb_KeyDown);
      this.updateY_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.updateY_tb.Leave += new EventHandler(this.objectPropertyLeave);
      this.updateZ_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateZ_tb.Enabled = false;
      this.updateZ_tb.Location = new Point(22, 57);
      this.updateZ_tb.Name = "updateZ_tb";
      this.updateZ_tb.Size = new Size(51, 20);
      this.updateZ_tb.TabIndex = 20;
      this.updateZ_tb.KeyDown += new KeyEventHandler(this.updateZ_tb_KeyDown);
      this.updateZ_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.updateZ_tb.Leave += new EventHandler(this.objectPropertyLeave);
      this.size_lbl.AutoSize = true;
      this.size_lbl.Location = new Point(79, 0);
      this.size_lbl.Name = "size_lbl";
      this.size_lbl.Size = new Size(27, 13);
      this.size_lbl.TabIndex = 25;
      this.size_lbl.Text = "Size";
      this.rotByte_lbl.AutoSize = true;
      this.rotByte_lbl.Location = new Point(79, 27);
      this.rotByte_lbl.Name = "rotByte_lbl";
      this.rotByte_lbl.Size = new Size(47, 13);
      this.rotByte_lbl.TabIndex = 31;
      this.rotByte_lbl.Text = "Rotation";
      this.updateSize_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateSize_tb.Enabled = false;
      this.updateSize_tb.Location = new Point(136, 3);
      this.updateSize_tb.Name = "updateSize_tb";
      this.updateSize_tb.Size = new Size(51, 20);
      this.updateSize_tb.TabIndex = 21;
      this.updateSize_tb.KeyDown += new KeyEventHandler(this.updateSize_tb_KeyDown);
      this.updateSize_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.updateSize_tb.Leave += new EventHandler(this.objectPropertyLeave);
      this.updateRot_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.updateRot_tb.Enabled = false;
      this.updateRot_tb.Location = new Point(136, 30);
      this.updateRot_tb.Name = "updateRot_tb";
      this.updateRot_tb.Size = new Size(51, 20);
      this.updateRot_tb.TabIndex = 22;
      this.updateRot_tb.KeyDown += new KeyEventHandler(this.updateRot_tb_KeyDown);
      this.updateRot_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.updateRot_tb.Leave += new EventHandler(this.objectPropertyLeave);
      this.cc_failsafe_cb.CheckAlign = ContentAlignment.MiddleCenter;
      this.cc_failsafe_cb.Location = new Point(136, 57);
      this.cc_failsafe_cb.Name = "cc_failsafe_cb";
      this.cc_failsafe_cb.Size = new Size(31, 20);
      this.cc_failsafe_cb.TabIndex = 66;
      this.cc_failsafe_cb.UseVisualStyleBackColor = true;
      this.cc_failsafe_cb.CheckedChanged += new EventHandler(this.cc_failsafe_cb_CheckedChanged);
      this.failsafe_lbl.Location = new Point(79, 54);
      this.failsafe_lbl.Name = "failsafe_lbl";
      this.failsafe_lbl.Size = new Size(51, 20);
      this.failsafe_lbl.TabIndex = 67;
      this.failsafe_lbl.Text = "Failsafe";
      this.objID_lbl.AutoSize = true;
      this.objID_lbl.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.objID_lbl.Location = new Point(13, 288);
      this.objID_lbl.Name = "objID_lbl";
      this.objID_lbl.Size = new Size(31, 13);
      this.objID_lbl.TabIndex = 48;
      this.objID_lbl.Text = "none";
      this.objID_lbl.Visible = false;
      this.id_tb.Location = new Point(58, 39);
      this.id_tb.Name = "id_tb";
      this.id_tb.Size = new Size(45, 20);
      this.id_tb.TabIndex = 14;
      this.id_tb.KeyUp += new KeyEventHandler(this.id_tb_KeyUp);
      this.label1.AutoSize = true;
      this.label1.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label1.Location = new Point(91, 287);
      this.label1.Name = "label1";
      this.label1.Size = new Size(43, 13);
      this.label1.TabIndex = 46;
      this.label1.Text = "File Loc";
      this.warp_btn.Location = new Point(163, 262);
      this.warp_btn.Name = "warp_btn";
      this.warp_btn.Size = new Size(26, 20);
      this.warp_btn.TabIndex = 28;
      this.warp_btn.Text = "...";
      this.warp_btn.UseVisualStyleBackColor = true;
      this.warp_btn.Click += new EventHandler(this.warp_btn_Click);
      this.warpTo_tb.Location = new Point(58, 264);
      this.warpTo_tb.Name = "warpTo_tb";
      this.warpTo_tb.Size = new Size(94, 20);
      this.warpTo_tb.TabIndex = 27;
      this.warpTo_lbl.AutoSize = true;
      this.warpTo_lbl.Location = new Point(9, 266);
      this.warpTo_lbl.Name = "warpTo_lbl";
      this.warpTo_lbl.Size = new Size(54, 13);
      this.warpTo_lbl.TabIndex = 43;
      this.warpTo_lbl.Text = "Warps To";
      this.id_lbl.AutoSize = true;
      this.id_lbl.Location = new Point(3, 39);
      this.id_lbl.Name = "id_lbl";
      this.id_lbl.Size = new Size(52, 13);
      this.id_lbl.TabIndex = 41;
      this.id_lbl.Text = "Object ID";
      this.updateScript_tb.Location = new Point(149, 39);
      this.updateScript_tb.Name = "updateScript_tb";
      this.updateScript_tb.Size = new Size(45, 20);
      this.updateScript_tb.TabIndex = 15;
      this.updateScript_tb.KeyDown += new KeyEventHandler(this.updateScript_tb_KeyDown);
      this.updateScript_tb.Leave += new EventHandler(this.updateScript_tb_Leave);
      this.updateName_tb.Enabled = false;
      this.updateName_tb.Location = new Point(47, 13);
      this.updateName_tb.Name = "updateName_tb";
      this.updateName_tb.Size = new Size(147, 20);
      this.updateName_tb.TabIndex = 13;
      this.script_lbl.AutoSize = true;
      this.script_lbl.Location = new Point(106, 39);
      this.script_lbl.Name = "script_lbl";
      this.script_lbl.Size = new Size(34, 13);
      this.script_lbl.TabIndex = 25;
      this.script_lbl.Text = "Script";
      this.label22.AutoSize = true;
      this.label22.Location = new Point(3, 13);
      this.label22.Name = "label22";
      this.label22.Size = new Size(35, 13);
      this.label22.TabIndex = 25;
      this.label22.Text = "Name";
      this.changeLM_btn.Location = new Point(94, 77);
      this.changeLM_btn.Name = "changeLM_btn";
      this.changeLM_btn.Size = new Size(75, 23);
      this.changeLM_btn.TabIndex = 63;
      this.changeLM_btn.Text = "Update";
      this.changeLM_btn.UseVisualStyleBackColor = true;
      this.changeLM_btn.Click += new EventHandler(this.ChangeLM_Click);
      this.changeLM_ofd.FileName = "replaceModel";
      this.objectMenu.Name = "contextMenuStrip1";
      this.objectMenu.Size = new Size(61, 4);
      this.objectMenu.MouseClick += new MouseEventHandler(this.contextMenuStrip1_MouseClick);
      this.CamSpeed_tb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.CamSpeed_tb.AutoSize = false;
      this.CamSpeed_tb.BackColor = SystemColors.ActiveCaption;
      this.CamSpeed_tb.Cursor = Cursors.Hand;
      this.CamSpeed_tb.Location = new Point(1039, 2);
      this.CamSpeed_tb.Maximum = 100;
      this.CamSpeed_tb.Minimum = 5;
      this.CamSpeed_tb.Name = "CamSpeed_tb";
      this.CamSpeed_tb.Size = new Size(150, 19);
      this.CamSpeed_tb.TabIndex = 0;
      this.CamSpeed_tb.TickFrequency = 5;
      this.CamSpeed_tb.Value = 30;
      this.CamSpeed_tb.Scroll += new EventHandler(this.CamSpeed_tb_Scroll);
      this.timer1.Interval = 30;
      this.timer1.Tick += new EventHandler(this.timer1_Tick_1);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(10, 23);
      this.label2.Name = "label2";
      this.label2.Size = new Size(52, 13);
      this.label2.TabIndex = 53;
      this.label2.Text = "Model (A)";
      this.baseLevel_tb.Enabled = false;
      this.baseLevel_tb.Location = new Point(68, 20);
      this.baseLevel_tb.Name = "baseLevel_tb";
      this.baseLevel_tb.Size = new Size(78, 20);
      this.baseLevel_tb.TabIndex = 64;
      this.extraModel_tb.Enabled = false;
      this.extraModel_tb.Location = new Point(68, 48);
      this.extraModel_tb.Name = "extraModel_tb";
      this.extraModel_tb.Size = new Size(78, 20);
      this.extraModel_tb.TabIndex = 65;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(10, 51);
      this.label3.Name = "label3";
      this.label3.Size = new Size(52, 13);
      this.label3.TabIndex = 55;
      this.label3.Text = "Model (B)";
      this.replaceModelEx_btn.Location = new Point(152, 49);
      this.replaceModelEx_btn.Name = "replaceModelEx_btn";
      this.replaceModelEx_btn.Size = new Size(31, 23);
      this.replaceModelEx_btn.TabIndex = 61;
      this.replaceModelEx_btn.Text = "...";
      this.replaceModelEx_btn.UseVisualStyleBackColor = true;
      this.replaceModelEx_btn.Click += new EventHandler(this.replaceModelEx_btn_Click);
      this.replaceModel_btn.Location = new Point(152, 18);
      this.replaceModel_btn.Name = "replaceModel_btn";
      this.replaceModel_btn.Size = new Size(31, 23);
      this.replaceModel_btn.TabIndex = 60;
      this.replaceModel_btn.Text = "...";
      this.replaceModel_btn.UseVisualStyleBackColor = true;
      this.replaceModel_btn.Click += new EventHandler(this.replaceModel_btn_Click);
      this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label4.AutoSize = true;
      this.label4.BackColor = SystemColors.ActiveCaption;
      this.label4.Location = new Point(954, 6);
      this.label4.Name = "label4";
      this.label4.Size = new Size(77, 13);
      this.label4.TabIndex = 59;
      this.label4.Text = "Camera Speed";
      this.replacemodel_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.replacemodel_gb.Controls.Add((Control) this.clear_btn);
      this.replacemodel_gb.Controls.Add((Control) this.baseLevel_tb);
      this.replacemodel_gb.Controls.Add((Control) this.label2);
      this.replacemodel_gb.Controls.Add((Control) this.replaceModel_btn);
      this.replacemodel_gb.Controls.Add((Control) this.label3);
      this.replacemodel_gb.Controls.Add((Control) this.replaceModelEx_btn);
      this.replacemodel_gb.Controls.Add((Control) this.extraModel_tb);
      this.replacemodel_gb.Controls.Add((Control) this.changeLM_btn);
      this.replacemodel_gb.Location = new Point(3, 1534);
      this.replacemodel_gb.Name = "replacemodel_gb";
      this.replacemodel_gb.Size = new Size(200, 106);
      this.replacemodel_gb.TabIndex = 5;
      this.replacemodel_gb.TabStop = false;
      this.clear_btn.Location = new Point(13, 78);
      this.clear_btn.Name = "clear_btn";
      this.clear_btn.Size = new Size(75, 23);
      this.clear_btn.TabIndex = 62;
      this.clear_btn.Text = "Clear";
      this.clear_btn.UseVisualStyleBackColor = true;
      this.clear_btn.Click += new EventHandler(this.clear_btn_Click);
      this.openFileDialog1.Filter = "Rom Files|*.z64;*.v64;*rom";
      this.openFileDialog2.Filter = "Rom Files|*.z64;*.v64;*rom";
      this.saveFileDialog.DefaultExt = "z64";
      this.replaceSetup_ofd.FileName = "SetupFile.bin";
      this.replaceSetup_ofd.Filter = "bin files|*.bin";
      this.saveSetupFileDialog.DefaultExt = "bin";
      this.saveSetupFileDialog.FileName = "my_setup.bin";
      this.saveSetupFileDialog.Filter = "Bin Files|*.bin";
      this.openSetupFileDialog.DefaultExt = "bin";
      this.openSetupFileDialog.Filter = "Bin Files|*.bin";
      this.saveAsRomFileDialog.DefaultExt = "z64";
      this.flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
      this.flowLayoutPanel1.AutoScroll = true;
      this.flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
      this.flowLayoutPanel1.Controls.Add((Control) this.path_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_obj_details_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.textUpdate_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_cam_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.cam3_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_replacemodel_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.replacemodel_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_levelbounds_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.bounds_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_levelentries_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.levelEntries_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_objects_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.objects_gb);
      this.flowLayoutPanel1.Controls.Add((Control) this.col_structs_btn);
      this.flowLayoutPanel1.Controls.Add((Control) this.structs_gb);
      this.flowLayoutPanel1.Location = new Point(960, 158);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new Size(233, 343);
      this.flowLayoutPanel1.TabIndex = 66;
      this.flowLayoutPanel1.Paint += new PaintEventHandler(this.flowLayoutPanel1_Paint);
      this.path_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.path_gb.Controls.Add((Control) this.label11);
      this.path_gb.Controls.Add((Control) this.label10);
      this.path_gb.Controls.Add((Control) this.pathControllers_dgv);
      this.path_gb.Controls.Add((Control) this.nodeID_gb);
      this.path_gb.Controls.Add((Control) this.sNode_gb);
      this.path_gb.Controls.Add((Control) this.nodeProperties_gb);
      this.path_gb.Controls.Add((Control) this.col_selPath_btn);
      this.path_gb.Controls.Add((Control) this.pathObject_gb);
      this.path_gb.Controls.Add((Control) this.path_dgv);
      this.path_gb.Location = new Point(3, 3);
      this.path_gb.Name = "path_gb";
      this.path_gb.Size = new Size(211, 749);
      this.path_gb.TabIndex = 80;
      this.path_gb.TabStop = false;
      this.label11.AutoSize = true;
      this.label11.Location = new Point(6, 184);
      this.label11.Name = "label11";
      this.label11.Size = new Size(56, 13);
      this.label11.TabIndex = 87;
      this.label11.Text = "Controllers";
      this.label10.AutoSize = true;
      this.label10.Location = new Point(6, 74);
      this.label10.Name = "label10";
      this.label10.Size = new Size(84, 13);
      this.label10.TabIndex = 86;
      this.label10.Text = "Standard Nodes";
      this.pathControllers_dgv.AllowUserToAddRows = false;
      this.pathControllers_dgv.AllowUserToDeleteRows = false;
      this.pathControllers_dgv.AllowUserToOrderColumns = true;
      this.pathControllers_dgv.AllowUserToResizeRows = false;
      this.pathControllers_dgv.BackgroundColor = Color.White;
      gridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle1.BackColor = SystemColors.Control;
      gridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle1.ForeColor = SystemColors.WindowText;
      gridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle1.WrapMode = DataGridViewTriState.True;
      this.pathControllers_dgv.ColumnHeadersDefaultCellStyle = gridViewCellStyle1;
      this.pathControllers_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle2.BackColor = SystemColors.Window;
      gridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle2.ForeColor = SystemColors.ControlText;
      gridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle2.WrapMode = DataGridViewTriState.False;
      this.pathControllers_dgv.DefaultCellStyle = gridViewCellStyle2;
      this.pathControllers_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.pathControllers_dgv.Location = new Point(6, 200);
      this.pathControllers_dgv.Margin = new Padding(3, 3, 3, 30);
      this.pathControllers_dgv.Name = "pathControllers_dgv";
      this.pathControllers_dgv.ReadOnly = true;
      gridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle3.BackColor = SystemColors.Control;
      gridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle3.ForeColor = SystemColors.WindowText;
      gridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle3.WrapMode = DataGridViewTriState.True;
      this.pathControllers_dgv.RowHeadersDefaultCellStyle = gridViewCellStyle3;
      this.pathControllers_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.pathControllers_dgv.Size = new Size(197, 80);
      this.pathControllers_dgv.TabIndex = 85;
      this.pathControllers_dgv.DoubleClick += new EventHandler(this.pathControllers_dgv_DoubleClick);
      this.nodeID_gb.Controls.Add((Control) this.tableLayoutPanel13);
      this.nodeID_gb.Controls.Add((Control) this.button6);
      this.nodeID_gb.Location = new Point(3, 285);
      this.nodeID_gb.Name = "nodeID_gb";
      this.nodeID_gb.Size = new Size(200, 85);
      this.nodeID_gb.TabIndex = 83;
      this.tableLayoutPanel13.BackColor = Color.White;
      this.tableLayoutPanel13.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel13.ColumnCount = 2;
      this.tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.75f));
      this.tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.25f));
      this.tableLayoutPanel13.Controls.Add((Control) this.label69, 0, 0);
      this.tableLayoutPanel13.Controls.Add((Control) this.nodeID_tb, 1, 0);
      this.tableLayoutPanel13.Controls.Add((Control) this.label70, 0, 1);
      this.tableLayoutPanel13.Controls.Add((Control) this.node18_tb, 1, 1);
      this.tableLayoutPanel13.Location = new Point(0, 25);
      this.tableLayoutPanel13.Margin = new Padding(0);
      this.tableLayoutPanel13.Name = "tableLayoutPanel13";
      this.tableLayoutPanel13.RowCount = 2;
      this.tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tableLayoutPanel13.Size = new Size(200, 55);
      this.tableLayoutPanel13.TabIndex = 61;
      this.label69.AutoSize = true;
      this.label69.Location = new Point(4, 1);
      this.label69.Name = "label69";
      this.label69.Size = new Size(18, 13);
      this.label69.TabIndex = 28;
      this.label69.Text = "ID";
      this.nodeID_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.nodeID_tb.Enabled = false;
      this.nodeID_tb.Location = new Point(78, 4);
      this.nodeID_tb.Name = "nodeID_tb";
      this.nodeID_tb.Size = new Size(118, 20);
      this.nodeID_tb.TabIndex = 18;
      this.label70.AutoSize = true;
      this.label70.Location = new Point(4, 28);
      this.label70.Name = "label70";
      this.label70.Size = new Size(22, 13);
      this.label70.TabIndex = 29;
      this.label70.Text = "TO";
      this.node18_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.node18_tb.Location = new Point(78, 31);
      this.node18_tb.Name = "node18_tb";
      this.node18_tb.Size = new Size(118, 20);
      this.node18_tb.TabIndex = 20;
      this.node18_tb.KeyDown += new KeyEventHandler(this.node_tb_KeyDown);
      this.node18_tb.KeyPress += new KeyPressEventHandler(this.hexOnly_KeyPress);
      this.node18_tb.Leave += new EventHandler(this.node_tb_Leave);
      this.button6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.button6.BackColor = Color.FromArgb(233, 236, 250);
      this.button6.FlatStyle = FlatStyle.Flat;
      this.button6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button6.ForeColor = SystemColors.ControlDarkDark;
      this.button6.Location = new Point(0, 0);
      this.button6.Margin = new Padding(0);
      this.button6.Name = "button6";
      this.button6.Size = new Size(199, 25);
      this.button6.TabIndex = 83;
      this.button6.Text = "ID/TO";
      this.button6.TextAlign = ContentAlignment.MiddleLeft;
      this.button6.UseVisualStyleBackColor = false;
      this.sNode_gb.Controls.Add((Control) this.tableLayoutPanel2);
      this.sNode_gb.Controls.Add((Control) this.button5);
      this.sNode_gb.Location = new Point(4, 480);
      this.sNode_gb.Name = "sNode_gb";
      this.sNode_gb.Size = new Size(200, 244);
      this.sNode_gb.TabIndex = 84;
      this.tableLayoutPanel2.BackColor = Color.White;
      this.tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.34343f));
      this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.65656f));
      this.tableLayoutPanel2.Controls.Add((Control) this.label61, 0, 1);
      this.tableLayoutPanel2.Controls.Add((Control) this.sNodeF_tb, 1, 1);
      this.tableLayoutPanel2.Controls.Add((Control) this.label9, 0, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.pathID_tb, 1, 0);
      this.tableLayoutPanel2.Controls.Add((Control) this.sNodeUNK3_tb, 1, 5);
      this.tableLayoutPanel2.Controls.Add((Control) this.label67, 0, 5);
      this.tableLayoutPanel2.Controls.Add((Control) this.panel1, 1, 2);
      this.tableLayoutPanel2.Controls.Add((Control) this.panel2, 1, 3);
      this.tableLayoutPanel2.Controls.Add((Control) this.panel3, 1, 4);
      this.tableLayoutPanel2.Controls.Add((Control) this.label57, 0, 3);
      this.tableLayoutPanel2.Controls.Add((Control) this.animation_lbl, 0, 2);
      this.tableLayoutPanel2.Controls.Add((Control) this.label62, 0, 4);
      this.tableLayoutPanel2.Controls.Add((Control) this.label63, 0, 6);
      this.tableLayoutPanel2.Controls.Add((Control) this.sNodeW1_tb, 1, 6);
      this.tableLayoutPanel2.Location = new Point(1, 25);
      this.tableLayoutPanel2.Margin = new Padding(0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 7;
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 26f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 33f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 33f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 31f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 28f));
      this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 8f));
      this.tableLayoutPanel2.Size = new Size(199, 212);
      this.tableLayoutPanel2.TabIndex = 84;
      this.label61.AutoSize = true;
      this.label61.Location = new Point(4, 28);
      this.label61.Name = "label61";
      this.label61.Size = new Size(60, 13);
      this.label61.TabIndex = 28;
      this.label61.Text = "Act Time %";
      this.sNodeF_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.sNodeF_tb.Location = new Point(72, 31);
      this.sNodeF_tb.Name = "sNodeF_tb";
      this.sNodeF_tb.Size = new Size(123, 20);
      this.sNodeF_tb.TabIndex = 18;
      this.sNodeF_tb.KeyDown += new KeyEventHandler(this.node_tb_KeyDown);
      this.sNodeF_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.sNodeF_tb.Leave += new EventHandler(this.sNode_tb_Leave);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(4, 1);
      this.label9.Name = "label9";
      this.label9.Size = new Size(43, 13);
      this.label9.TabIndex = 71;
      this.label9.Text = "Path ID";
      this.pathID_tb.Location = new Point(72, 4);
      this.pathID_tb.Name = "pathID_tb";
      this.pathID_tb.Size = new Size(123, 20);
      this.pathID_tb.TabIndex = 72;
      this.pathID_tb.KeyDown += new KeyEventHandler(this.node_tb_KeyDown);
      this.pathID_tb.KeyPress += new KeyPressEventHandler(this.hexOnly_KeyPress);
      this.pathID_tb.Leave += new EventHandler(this.sNode_tb_Leave);
      this.sNodeUNK3_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.sNodeUNK3_tb.Location = new Point(72, 158);
      this.sNodeUNK3_tb.Name = "sNodeUNK3_tb";
      this.sNodeUNK3_tb.Size = new Size(123, 20);
      this.sNodeUNK3_tb.TabIndex = 51;
      this.sNodeUNK3_tb.KeyDown += new KeyEventHandler(this.node_tb_KeyDown);
      this.sNodeUNK3_tb.KeyPress += new KeyPressEventHandler(this.hexOnly_KeyPress);
      this.sNodeUNK3_tb.Leave += new EventHandler(this.sNode_tb_Leave);
      this.label67.AutoSize = true;
      this.label67.Location = new Point(4, 155);
      this.label67.Name = "label67";
      this.label67.Size = new Size(36, 13);
      this.label67.TabIndex = 48;
      this.label67.Text = "UNK3";
      this.panel1.Controls.Add((Control) this.useAnimation_cb);
      this.panel1.Controls.Add((Control) this.animation_cb);
      this.panel1.Location = new Point(72, 58);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(123, 27);
      this.panel1.TabIndex = 79;
      this.useAnimation_cb.AutoSize = true;
      this.useAnimation_cb.Location = new Point(2, 4);
      this.useAnimation_cb.Name = "useAnimation_cb";
      this.useAnimation_cb.Size = new Size(15, 14);
      this.useAnimation_cb.TabIndex = 76;
      this.useAnimation_cb.UseVisualStyleBackColor = true;
      this.useAnimation_cb.Leave += new EventHandler(this.controller_cb_Leave);
      this.animation_cb.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.animation_cb.FormattingEnabled = true;
      this.animation_cb.Location = new Point(21, 1);
      this.animation_cb.Name = "animation_cb";
      this.animation_cb.Size = new Size(100, 20);
      this.animation_cb.TabIndex = 67;
      this.animation_cb.SelectedIndexChanged += new EventHandler(this.animation_cb_SelectedIndexChanged);
      this.panel2.Controls.Add((Control) this.usePause_cb);
      this.panel2.Controls.Add((Control) this.pauseTime_tb);
      this.panel2.Location = new Point(72, 92);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(123, 27);
      this.panel2.TabIndex = 80;
      this.usePause_cb.AutoSize = true;
      this.usePause_cb.Location = new Point(2, 3);
      this.usePause_cb.Name = "usePause_cb";
      this.usePause_cb.Size = new Size(15, 14);
      this.usePause_cb.TabIndex = 77;
      this.usePause_cb.UseVisualStyleBackColor = true;
      this.usePause_cb.Leave += new EventHandler(this.controller_cb_Leave);
      this.pauseTime_tb.Location = new Point(21, 2);
      this.pauseTime_tb.Name = "pauseTime_tb";
      this.pauseTime_tb.Size = new Size(99, 20);
      this.pauseTime_tb.TabIndex = 70;
      this.pauseTime_tb.KeyDown += new KeyEventHandler(this.pauseTime_tb_KeyDown);
      this.pauseTime_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.pauseTime_tb.Leave += new EventHandler(this.pauseTime_tb_Leave);
      this.panel3.Controls.Add((Control) this.useSpeed_cb);
      this.panel3.Controls.Add((Control) this.sNodeSpeed_tb);
      this.panel3.Location = new Point(72, 126);
      this.panel3.Name = "panel3";
      this.panel3.Size = new Size(122, 24);
      this.panel3.TabIndex = 81;
      this.useSpeed_cb.AutoSize = true;
      this.useSpeed_cb.Location = new Point(2, 6);
      this.useSpeed_cb.Name = "useSpeed_cb";
      this.useSpeed_cb.Size = new Size(15, 14);
      this.useSpeed_cb.TabIndex = 78;
      this.useSpeed_cb.UseVisualStyleBackColor = true;
      this.useSpeed_cb.Leave += new EventHandler(this.controller_cb_Leave);
      this.sNodeSpeed_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.sNodeSpeed_tb.Location = new Point(21, 2);
      this.sNodeSpeed_tb.Name = "sNodeSpeed_tb";
      this.sNodeSpeed_tb.Size = new Size(97, 20);
      this.sNodeSpeed_tb.TabIndex = 47;
      this.sNodeSpeed_tb.KeyDown += new KeyEventHandler(this.node_tb_KeyDown);
      this.sNodeSpeed_tb.KeyPress += new KeyPressEventHandler(this.hexOnly_KeyPress);
      this.sNodeSpeed_tb.Leave += new EventHandler(this.sNode_tb_Leave);
      this.label57.AutoSize = true;
      this.label57.Location = new Point(4, 89);
      this.label57.Name = "label57";
      this.label57.Size = new Size(40, 26);
      this.label57.TabIndex = 69;
      this.label57.Text = "Pause Time";
      this.animation_lbl.AutoSize = true;
      this.animation_lbl.Location = new Point(4, 55);
      this.animation_lbl.Name = "animation_lbl";
      this.animation_lbl.Size = new Size(53, 13);
      this.animation_lbl.TabIndex = 66;
      this.animation_lbl.Text = "Animation";
      this.label62.AutoSize = true;
      this.label62.Location = new Point(4, 123);
      this.label62.Name = "label62";
      this.label62.Size = new Size(38, 13);
      this.label62.TabIndex = 30;
      this.label62.Text = "Speed";
      this.label63.AutoSize = true;
      this.label63.Location = new Point(4, 184);
      this.label63.Name = "label63";
      this.label63.Size = new Size(30, 13);
      this.label63.TabIndex = 29;
      this.label63.Text = "UNK";
      this.sNodeW1_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.sNodeW1_tb.Location = new Point(72, 187);
      this.sNodeW1_tb.Name = "sNodeW1_tb";
      this.sNodeW1_tb.Size = new Size(123, 20);
      this.sNodeW1_tb.TabIndex = 19;
      this.sNodeW1_tb.KeyDown += new KeyEventHandler(this.node_tb_KeyDown);
      this.sNodeW1_tb.KeyPress += new KeyPressEventHandler(this.hexOnly_KeyPress);
      this.sNodeW1_tb.Leave += new EventHandler(this.sNode_tb_Leave);
      this.button5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.button5.BackColor = Color.FromArgb(233, 236, 250);
      this.button5.FlatStyle = FlatStyle.Flat;
      this.button5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button5.ForeColor = SystemColors.ControlDarkDark;
      this.button5.Location = new Point(2, 0);
      this.button5.Margin = new Padding(0);
      this.button5.Name = "button5";
      this.button5.Size = new Size(196, 25);
      this.button5.TabIndex = 83;
      this.button5.Text = "Node Properties";
      this.button5.TextAlign = ContentAlignment.MiddleLeft;
      this.button5.UseVisualStyleBackColor = false;
      this.nodeProperties_gb.Controls.Add((Control) this.button4);
      this.nodeProperties_gb.Controls.Add((Control) this.nodeProperties_lp);
      this.nodeProperties_gb.Location = new Point(4, 376);
      this.nodeProperties_gb.Name = "nodeProperties_gb";
      this.nodeProperties_gb.Size = new Size(200, 97);
      this.nodeProperties_gb.TabIndex = 83;
      this.button4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.button4.BackColor = Color.FromArgb(233, 236, 250);
      this.button4.FlatStyle = FlatStyle.Flat;
      this.button4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button4.ForeColor = SystemColors.ControlDarkDark;
      this.button4.Location = new Point(0, 0);
      this.button4.Margin = new Padding(0);
      this.button4.Name = "button4";
      this.button4.Size = new Size(200, 25);
      this.button4.TabIndex = 82;
      this.button4.Text = "Location";
      this.button4.TextAlign = ContentAlignment.MiddleLeft;
      this.button4.UseVisualStyleBackColor = false;
      this.nodeProperties_lp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.nodeProperties_lp.BackColor = Color.White;
      this.nodeProperties_lp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.nodeProperties_lp.ColumnCount = 2;
      this.nodeProperties_lp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5f));
      this.nodeProperties_lp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62.49999f));
      this.nodeProperties_lp.Controls.Add((Control) this.label53, 0, 0);
      this.nodeProperties_lp.Controls.Add((Control) this.nodeX_tb, 1, 0);
      this.nodeProperties_lp.Controls.Add((Control) this.label55, 0, 1);
      this.nodeProperties_lp.Controls.Add((Control) this.label54, 0, 2);
      this.nodeProperties_lp.Controls.Add((Control) this.nodeY_tb, 1, 1);
      this.nodeProperties_lp.Controls.Add((Control) this.nodeZ_tb, 1, 2);
      this.nodeProperties_lp.Location = new Point(0, 25);
      this.nodeProperties_lp.Margin = new Padding(0);
      this.nodeProperties_lp.Name = "nodeProperties_lp";
      this.nodeProperties_lp.RowCount = 3;
      this.nodeProperties_lp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.nodeProperties_lp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.nodeProperties_lp.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.nodeProperties_lp.Size = new Size(200, 68);
      this.nodeProperties_lp.TabIndex = 61;
      this.label53.AutoSize = true;
      this.label53.Location = new Point(4, 1);
      this.label53.Name = "label53";
      this.label53.Size = new Size(14, 13);
      this.label53.TabIndex = 28;
      this.label53.Text = "X";
      this.nodeX_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.nodeX_tb.Location = new Point(75, 1);
      this.nodeX_tb.Margin = new Padding(0);
      this.nodeX_tb.Name = "nodeX_tb";
      this.nodeX_tb.Size = new Size(124, 20);
      this.nodeX_tb.TabIndex = 18;
      this.nodeX_tb.KeyDown += new KeyEventHandler(this.nodeX_tb_KeyDown);
      this.nodeX_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.nodeX_tb.Leave += new EventHandler(this.node_tb_Leave);
      this.label55.AutoSize = true;
      this.label55.Location = new Point(4, 23);
      this.label55.Name = "label55";
      this.label55.Size = new Size(14, 13);
      this.label55.TabIndex = 29;
      this.label55.Text = "Y";
      this.label54.AutoSize = true;
      this.label54.Location = new Point(4, 45);
      this.label54.Name = "label54";
      this.label54.Size = new Size(14, 13);
      this.label54.TabIndex = 30;
      this.label54.Text = "Z";
      this.nodeY_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.nodeY_tb.Location = new Point(75, 23);
      this.nodeY_tb.Margin = new Padding(0);
      this.nodeY_tb.Name = "nodeY_tb";
      this.nodeY_tb.Size = new Size(124, 20);
      this.nodeY_tb.TabIndex = 19;
      this.nodeY_tb.KeyDown += new KeyEventHandler(this.nodeY_tb_KeyDown);
      this.nodeY_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.nodeY_tb.Leave += new EventHandler(this.node_tb_Leave);
      this.nodeZ_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.nodeZ_tb.Location = new Point(75, 45);
      this.nodeZ_tb.Margin = new Padding(0);
      this.nodeZ_tb.Name = "nodeZ_tb";
      this.nodeZ_tb.Size = new Size(124, 20);
      this.nodeZ_tb.TabIndex = 47;
      this.nodeZ_tb.KeyDown += new KeyEventHandler(this.nodeZ_tb_KeyDown);
      this.nodeZ_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.nodeZ_tb.Leave += new EventHandler(this.node_tb_Leave);
      this.col_selPath_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_selPath_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_selPath_btn.FlatStyle = FlatStyle.Flat;
      this.col_selPath_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_selPath_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_selPath_btn.Location = new Point(-1, -6);
      this.col_selPath_btn.Margin = new Padding(0);
      this.col_selPath_btn.Name = "col_selPath_btn";
      this.col_selPath_btn.Size = new Size(214, 23);
      this.col_selPath_btn.TabIndex = 79;
      this.col_selPath_btn.Text = "- Selected Path";
      this.col_selPath_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_selPath_btn.UseVisualStyleBackColor = false;
      this.pathObject_gb.Controls.Add((Control) this.tableLayoutPanel16);
      this.pathObject_gb.Location = new Point(5, 20);
      this.pathObject_gb.Name = "pathObject_gb";
      this.pathObject_gb.Size = new Size(200, 50);
      this.pathObject_gb.TabIndex = 63;
      this.pathObject_gb.TabStop = false;
      this.tableLayoutPanel16.ColumnCount = 2;
      this.tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.78947f));
      this.tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.21053f));
      this.tableLayoutPanel16.Controls.Add((Control) this.label60, 0, 0);
      this.tableLayoutPanel16.Controls.Add((Control) this.objectNode_tb, 1, 0);
      this.tableLayoutPanel16.Location = new Point(6, 14);
      this.tableLayoutPanel16.Margin = new Padding(0);
      this.tableLayoutPanel16.Name = "tableLayoutPanel16";
      this.tableLayoutPanel16.RowCount = 1;
      this.tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel16.Size = new Size(190, 27);
      this.tableLayoutPanel16.TabIndex = 61;
      this.label60.AutoSize = true;
      this.label60.Location = new Point(3, 0);
      this.label60.Name = "label60";
      this.label60.Size = new Size(49, 13);
      this.label60.TabIndex = 28;
      this.label60.Text = "To Node";
      this.objectNode_tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.objectNode_tb.Enabled = false;
      this.objectNode_tb.Location = new Point(89, 3);
      this.objectNode_tb.Name = "objectNode_tb";
      this.objectNode_tb.Size = new Size(98, 20);
      this.objectNode_tb.TabIndex = 21;
      this.objectNode_tb.KeyDown += new KeyEventHandler(this.objectNode_tb_KeyDown);
      this.objectNode_tb.KeyPress += new KeyPressEventHandler(this.hexOnly_KeyPress);
      this.path_dgv.AllowUserToAddRows = false;
      this.path_dgv.AllowUserToDeleteRows = false;
      this.path_dgv.AllowUserToOrderColumns = true;
      this.path_dgv.AllowUserToResizeRows = false;
      this.path_dgv.BackgroundColor = Color.White;
      gridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle4.BackColor = SystemColors.Control;
      gridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle4.ForeColor = SystemColors.WindowText;
      gridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle4.WrapMode = DataGridViewTriState.True;
      this.path_dgv.ColumnHeadersDefaultCellStyle = gridViewCellStyle4;
      this.path_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle5.BackColor = SystemColors.Window;
      gridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle5.ForeColor = SystemColors.ControlText;
      gridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle5.WrapMode = DataGridViewTriState.False;
      this.path_dgv.DefaultCellStyle = gridViewCellStyle5;
      this.path_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.path_dgv.Location = new Point(5, 93);
      this.path_dgv.Margin = new Padding(3, 3, 3, 30);
      this.path_dgv.Name = "path_dgv";
      this.path_dgv.ReadOnly = true;
      gridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle6.BackColor = SystemColors.Control;
      gridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle6.ForeColor = SystemColors.WindowText;
      gridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle6.WrapMode = DataGridViewTriState.True;
      this.path_dgv.RowHeadersDefaultCellStyle = gridViewCellStyle6;
      this.path_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.path_dgv.Size = new Size(197, 86);
      this.path_dgv.TabIndex = 0;
      this.path_dgv.DoubleClick += new EventHandler(this.path_dgv_DoubleClick);
      this.col_obj_details_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_obj_details_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_obj_details_btn.FlatStyle = FlatStyle.Flat;
      this.col_obj_details_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_obj_details_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_obj_details_btn.Location = new Point(0, 755);
      this.col_obj_details_btn.Margin = new Padding(0);
      this.col_obj_details_btn.Name = "col_obj_details_btn";
      this.col_obj_details_btn.Size = new Size(210, 23);
      this.col_obj_details_btn.TabIndex = 3;
      this.col_obj_details_btn.Text = "- Object Details";
      this.col_obj_details_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_obj_details_btn.UseVisualStyleBackColor = false;
      this.col_obj_details_btn.Click += new EventHandler(this.col_obj_details_btn_Click);
      this.col_cam_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_cam_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_cam_btn.FlatStyle = FlatStyle.Flat;
      this.col_cam_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_cam_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_cam_btn.Location = new Point(0, 1101);
      this.col_cam_btn.Margin = new Padding(0);
      this.col_cam_btn.Name = "col_cam_btn";
      this.col_cam_btn.Size = new Size(210, 23);
      this.col_cam_btn.TabIndex = 81;
      this.col_cam_btn.Text = "- Camera";
      this.col_cam_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_cam_btn.UseVisualStyleBackColor = false;
      this.cam3_gb.Controls.Add((Control) this.tableLayoutPanel10);
      this.cam3_gb.Controls.Add((Control) this.label39);
      this.cam3_gb.Controls.Add((Control) this.camID_tb);
      this.cam3_gb.Controls.Add((Control) this.label40);
      this.cam3_gb.Location = new Point(3, 1127);
      this.cam3_gb.Name = "cam3_gb";
      this.cam3_gb.Size = new Size(205, 378);
      this.cam3_gb.TabIndex = 70;
      this.cam3_gb.TabStop = false;
      this.tableLayoutPanel10.BackColor = Color.White;
      this.tableLayoutPanel10.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel10.ColumnCount = 2;
      this.tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.67005f));
      this.tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.32995f));
      this.tableLayoutPanel10.Controls.Add((Control) this.label33, 0, 0);
      this.tableLayoutPanel10.Controls.Add((Control) this.label34, 0, 2);
      this.tableLayoutPanel10.Controls.Add((Control) this.label35, 0, 1);
      this.tableLayoutPanel10.Controls.Add((Control) this.camFDist_tb, 1, 12);
      this.tableLayoutPanel10.Controls.Add((Control) this.camCDist_tb, 1, 11);
      this.tableLayoutPanel10.Controls.Add((Control) this.label49, 0, 12);
      this.tableLayoutPanel10.Controls.Add((Control) this.label48, 0, 11);
      this.tableLayoutPanel10.Controls.Add((Control) this.camZ_tb, 1, 2);
      this.tableLayoutPanel10.Controls.Add((Control) this.camY_tb, 1, 1);
      this.tableLayoutPanel10.Controls.Add((Control) this.camX_tb, 1, 0);
      this.tableLayoutPanel10.Controls.Add((Control) this.label43, 0, 3);
      this.tableLayoutPanel10.Controls.Add((Control) this.camHSpeed_tb, 1, 3);
      this.tableLayoutPanel10.Controls.Add((Control) this.label44, 0, 4);
      this.tableLayoutPanel10.Controls.Add((Control) this.camVSpeed_tb, 1, 4);
      this.tableLayoutPanel10.Controls.Add((Control) this.label45, 0, 5);
      this.tableLayoutPanel10.Controls.Add((Control) this.camRotation_tb, 1, 5);
      this.tableLayoutPanel10.Controls.Add((Control) this.label46, 0, 6);
      this.tableLayoutPanel10.Controls.Add((Control) this.camAccel_tb, 1, 6);
      this.tableLayoutPanel10.Controls.Add((Control) this.label36, 0, 7);
      this.tableLayoutPanel10.Controls.Add((Control) this.camPitch_tb, 1, 7);
      this.tableLayoutPanel10.Controls.Add((Control) this.camYaw_tb, 1, 8);
      this.tableLayoutPanel10.Controls.Add((Control) this.camRoll_tb, 1, 9);
      this.tableLayoutPanel10.Controls.Add((Control) this.cam3A5_tb, 1, 10);
      this.tableLayoutPanel10.Controls.Add((Control) this.label37, 0, 8);
      this.tableLayoutPanel10.Controls.Add((Control) this.label38, 0, 9);
      this.tableLayoutPanel10.Controls.Add((Control) this.label47, 0, 10);
      this.tableLayoutPanel10.Location = new Point(3, 40);
      this.tableLayoutPanel10.Margin = new Padding(0);
      this.tableLayoutPanel10.Name = "tableLayoutPanel10";
      this.tableLayoutPanel10.RowCount = 13;
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 7.692307f));
      this.tableLayoutPanel10.Size = new Size(194, 331);
      this.tableLayoutPanel10.TabIndex = 61;
      this.label33.AutoSize = true;
      this.label33.Location = new Point(4, 1);
      this.label33.Name = "label33";
      this.label33.Size = new Size(14, 13);
      this.label33.TabIndex = 28;
      this.label33.Text = "X";
      this.label34.AutoSize = true;
      this.label34.Location = new Point(4, 51);
      this.label34.Name = "label34";
      this.label34.Size = new Size(14, 13);
      this.label34.TabIndex = 30;
      this.label34.Text = "Z";
      this.label35.AutoSize = true;
      this.label35.Location = new Point(4, 26);
      this.label35.Name = "label35";
      this.label35.Size = new Size(14, 13);
      this.label35.TabIndex = 29;
      this.label35.Text = "Y";
      this.camFDist_tb.Location = new Point(90, 304);
      this.camFDist_tb.Name = "camFDist_tb";
      this.camFDist_tb.Size = new Size(100, 20);
      this.camFDist_tb.TabIndex = 53;
      this.camFDist_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camFDist_tb.Leave += new EventHandler(this.camera_properties_update);
      this.camCDist_tb.Location = new Point(90, 279);
      this.camCDist_tb.Name = "camCDist_tb";
      this.camCDist_tb.Size = new Size(100, 20);
      this.camCDist_tb.TabIndex = 52;
      this.camCDist_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camCDist_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label49.AutoSize = true;
      this.label49.Location = new Point(4, 301);
      this.label49.Name = "label49";
      this.label49.Size = new Size(67, 13);
      this.label49.TabIndex = 53;
      this.label49.Text = "Far Distance";
      this.label48.AutoSize = true;
      this.label48.Location = new Point(4, 276);
      this.label48.Name = "label48";
      this.label48.Size = new Size(78, 13);
      this.label48.TabIndex = 52;
      this.label48.Text = "Close Distance";
      this.camZ_tb.Location = new Point(90, 54);
      this.camZ_tb.Name = "camZ_tb";
      this.camZ_tb.Size = new Size(100, 20);
      this.camZ_tb.TabIndex = 43;
      this.camZ_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camZ_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.camZ_tb.KeyUp += new KeyEventHandler(this.cam_tb_KeyUp);
      this.camZ_tb.Leave += new EventHandler(this.camera_properties_update);
      this.camY_tb.Location = new Point(90, 29);
      this.camY_tb.Name = "camY_tb";
      this.camY_tb.Size = new Size(100, 20);
      this.camY_tb.TabIndex = 42;
      this.camY_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camY_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.camY_tb.KeyUp += new KeyEventHandler(this.cam_tb_KeyUp);
      this.camY_tb.Leave += new EventHandler(this.camera_properties_update);
      this.camX_tb.Location = new Point(90, 4);
      this.camX_tb.Name = "camX_tb";
      this.camX_tb.Size = new Size(100, 20);
      this.camX_tb.TabIndex = 41;
      this.camX_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camX_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.camX_tb.KeyUp += new KeyEventHandler(this.cam_tb_KeyUp);
      this.camX_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label43.AutoSize = true;
      this.label43.Location = new Point(4, 76);
      this.label43.Name = "label43";
      this.label43.Size = new Size(49, 13);
      this.label43.TabIndex = 43;
      this.label43.Text = "H Speed";
      this.camHSpeed_tb.Location = new Point(90, 79);
      this.camHSpeed_tb.Name = "camHSpeed_tb";
      this.camHSpeed_tb.Size = new Size(100, 20);
      this.camHSpeed_tb.TabIndex = 44;
      this.camHSpeed_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camHSpeed_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label44.AutoSize = true;
      this.label44.Location = new Point(4, 101);
      this.label44.Name = "label44";
      this.label44.Size = new Size(48, 13);
      this.label44.TabIndex = 44;
      this.label44.Text = "V Speed";
      this.camVSpeed_tb.Location = new Point(90, 104);
      this.camVSpeed_tb.Name = "camVSpeed_tb";
      this.camVSpeed_tb.Size = new Size(100, 20);
      this.camVSpeed_tb.TabIndex = 45;
      this.camVSpeed_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camVSpeed_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label45.AutoSize = true;
      this.label45.Location = new Point(4, 126);
      this.label45.Name = "label45";
      this.label45.Size = new Size(50, 24);
      this.label45.TabIndex = 47;
      this.label45.Text = "Rotation Speed";
      this.camRotation_tb.Location = new Point(90, 129);
      this.camRotation_tb.Name = "camRotation_tb";
      this.camRotation_tb.Size = new Size(100, 20);
      this.camRotation_tb.TabIndex = 50;
      this.camRotation_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camRotation_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label46.AutoSize = true;
      this.label46.Location = new Point(4, 151);
      this.label46.Name = "label46";
      this.label46.Size = new Size(66, 13);
      this.label46.TabIndex = 48;
      this.label46.Text = "Acceleration";
      this.camAccel_tb.Location = new Point(90, 154);
      this.camAccel_tb.Name = "camAccel_tb";
      this.camAccel_tb.Size = new Size(100, 20);
      this.camAccel_tb.TabIndex = 51;
      this.camAccel_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camAccel_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label36.AutoSize = true;
      this.label36.Location = new Point(4, 176);
      this.label36.Name = "label36";
      this.label36.Size = new Size(31, 13);
      this.label36.TabIndex = 40;
      this.label36.Text = "Pitch";
      this.camPitch_tb.Location = new Point(90, 179);
      this.camPitch_tb.Name = "camPitch_tb";
      this.camPitch_tb.Size = new Size(100, 20);
      this.camPitch_tb.TabIndex = 47;
      this.camPitch_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camPitch_tb.Leave += new EventHandler(this.camera_properties_update);
      this.camYaw_tb.Location = new Point(90, 204);
      this.camYaw_tb.Name = "camYaw_tb";
      this.camYaw_tb.Size = new Size(100, 20);
      this.camYaw_tb.TabIndex = 48;
      this.camYaw_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camYaw_tb.Leave += new EventHandler(this.camera_properties_update);
      this.camRoll_tb.Location = new Point(90, 229);
      this.camRoll_tb.Name = "camRoll_tb";
      this.camRoll_tb.Size = new Size(100, 20);
      this.camRoll_tb.TabIndex = 49;
      this.camRoll_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camRoll_tb.Leave += new EventHandler(this.camera_properties_update);
      this.cam3A5_tb.Location = new Point(90, 254);
      this.cam3A5_tb.Name = "cam3A5_tb";
      this.cam3A5_tb.Size = new Size(100, 20);
      this.cam3A5_tb.TabIndex = 46;
      this.cam3A5_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.cam3A5_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label37.AutoSize = true;
      this.label37.Location = new Point(4, 201);
      this.label37.Name = "label37";
      this.label37.Size = new Size(28, 13);
      this.label37.TabIndex = 41;
      this.label37.Text = "Yaw";
      this.label38.AutoSize = true;
      this.label38.Location = new Point(4, 226);
      this.label38.Name = "label38";
      this.label38.Size = new Size(25, 13);
      this.label38.TabIndex = 42;
      this.label38.Text = "Roll";
      this.label47.AutoSize = true;
      this.label47.Location = new Point(4, 251);
      this.label47.Name = "label47";
      this.label47.Size = new Size(20, 13);
      this.label47.TabIndex = 51;
      this.label47.Text = "A5";
      this.label39.AutoSize = true;
      this.label39.Location = new Point(122, 16);
      this.label39.Name = "label39";
      this.label39.Size = new Size(0, 13);
      this.label39.TabIndex = 43;
      this.camID_tb.Location = new Point(71, 13);
      this.camID_tb.Name = "camID_tb";
      this.camID_tb.Size = new Size(45, 20);
      this.camID_tb.TabIndex = 40;
      this.camID_tb.KeyDown += new KeyEventHandler(this.camera_properties_update);
      this.camID_tb.KeyUp += new KeyEventHandler(this.cam_tb_KeyUp);
      this.camID_tb.Leave += new EventHandler(this.camera_properties_update);
      this.label40.AutoSize = true;
      this.label40.Location = new Point(6, 16);
      this.label40.Name = "label40";
      this.label40.Size = new Size(60, 13);
      this.label40.TabIndex = 0;
      this.label40.Text = "Camera ID:";
      this.col_replacemodel_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_replacemodel_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_replacemodel_btn.FlatStyle = FlatStyle.Flat;
      this.col_replacemodel_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_replacemodel_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_replacemodel_btn.Location = new Point(0, 1508);
      this.col_replacemodel_btn.Margin = new Padding(0);
      this.col_replacemodel_btn.Name = "col_replacemodel_btn";
      this.col_replacemodel_btn.Size = new Size(210, 23);
      this.col_replacemodel_btn.TabIndex = 66;
      this.col_replacemodel_btn.Text = "- Replace Level Model";
      this.col_replacemodel_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_replacemodel_btn.UseVisualStyleBackColor = false;
      this.col_replacemodel_btn.Click += new EventHandler(this.col_replacemodel_btn_Click);
      this.col_levelbounds_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_levelbounds_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_levelbounds_btn.FlatStyle = FlatStyle.Flat;
      this.col_levelbounds_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_levelbounds_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_levelbounds_btn.Location = new Point(0, 1643);
      this.col_levelbounds_btn.Margin = new Padding(0);
      this.col_levelbounds_btn.Name = "col_levelbounds_btn";
      this.col_levelbounds_btn.Size = new Size(210, 23);
      this.col_levelbounds_btn.TabIndex = 67;
      this.col_levelbounds_btn.Text = "- Level Boundaries";
      this.col_levelbounds_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_levelbounds_btn.UseVisualStyleBackColor = false;
      this.col_levelbounds_btn.Click += new EventHandler(this.col_levelbounds_btn_Click);
      this.bounds_gb.Controls.Add((Control) this.label29);
      this.bounds_gb.Controls.Add((Control) this.updateBounds_btn);
      this.bounds_gb.Controls.Add((Control) this.tableLayoutPanel8);
      this.bounds_gb.Controls.Add((Control) this.label28);
      this.bounds_gb.Location = new Point(3, 1669);
      this.bounds_gb.Name = "bounds_gb";
      this.bounds_gb.Size = new Size(200, 152);
      this.bounds_gb.TabIndex = 67;
      this.bounds_gb.TabStop = false;
      this.label29.AutoSize = true;
      this.label29.Location = new Point(4, 107);
      this.label29.Name = "label29";
      this.label29.Size = new Size(160, 13);
      this.label29.TabIndex = 63;
      this.label29.Text = "WARNING will update model file";
      this.updateBounds_btn.Location = new Point(119, 123);
      this.updateBounds_btn.Name = "updateBounds_btn";
      this.updateBounds_btn.Size = new Size(75, 23);
      this.updateBounds_btn.TabIndex = 62;
      this.updateBounds_btn.Text = "Update";
      this.updateBounds_btn.UseVisualStyleBackColor = true;
      this.updateBounds_btn.Click += new EventHandler(this.updateBounds_btn_Click);
      this.tableLayoutPanel8.ColumnCount = 4;
      this.tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.57895f));
      this.tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.89474f));
      this.tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel8.Controls.Add((Control) this.label21, 0, 0);
      this.tableLayoutPanel8.Controls.Add((Control) this.label23, 0, 2);
      this.tableLayoutPanel8.Controls.Add((Control) this.label24, 0, 1);
      this.tableLayoutPanel8.Controls.Add((Control) this.minZ_Bounds_tb, 1, 2);
      this.tableLayoutPanel8.Controls.Add((Control) this.minY_Bounds_tb, 1, 1);
      this.tableLayoutPanel8.Controls.Add((Control) this.minX_Bounds_tb, 1, 0);
      this.tableLayoutPanel8.Controls.Add((Control) this.label25, 2, 0);
      this.tableLayoutPanel8.Controls.Add((Control) this.label26, 2, 1);
      this.tableLayoutPanel8.Controls.Add((Control) this.label27, 2, 2);
      this.tableLayoutPanel8.Controls.Add((Control) this.maxX_Bounds_tb, 3, 0);
      this.tableLayoutPanel8.Controls.Add((Control) this.maxY_Bounds_tb, 3, 1);
      this.tableLayoutPanel8.Controls.Add((Control) this.maxZ_Bounds_tb, 3, 2);
      this.tableLayoutPanel8.Location = new Point(7, 16);
      this.tableLayoutPanel8.Margin = new Padding(0);
      this.tableLayoutPanel8.Name = "tableLayoutPanel8";
      this.tableLayoutPanel8.RowCount = 3;
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
      this.tableLayoutPanel8.Size = new Size(190, 83);
      this.tableLayoutPanel8.TabIndex = 61;
      this.label21.AutoSize = true;
      this.label21.Location = new Point(3, 0);
      this.label21.Name = "label21";
      this.label21.Size = new Size(34, 13);
      this.label21.TabIndex = 28;
      this.label21.Text = "Min-X";
      this.label23.AutoSize = true;
      this.label23.Location = new Point(3, 54);
      this.label23.Name = "label23";
      this.label23.Size = new Size(34, 13);
      this.label23.TabIndex = 30;
      this.label23.Text = "Min-Z";
      this.label24.AutoSize = true;
      this.label24.Location = new Point(3, 27);
      this.label24.Name = "label24";
      this.label24.Size = new Size(34, 13);
      this.label24.TabIndex = 29;
      this.label24.Text = "Min-Y";
      this.minZ_Bounds_tb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.minZ_Bounds_tb.Location = new Point(44, 57);
      this.minZ_Bounds_tb.Name = "minZ_Bounds_tb";
      this.minZ_Bounds_tb.Size = new Size(47, 20);
      this.minZ_Bounds_tb.TabIndex = 74;
      this.minZ_Bounds_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.minY_Bounds_tb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.minY_Bounds_tb.Location = new Point(44, 30);
      this.minY_Bounds_tb.Name = "minY_Bounds_tb";
      this.minY_Bounds_tb.Size = new Size(47, 20);
      this.minY_Bounds_tb.TabIndex = 72;
      this.minY_Bounds_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.minX_Bounds_tb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.minX_Bounds_tb.Location = new Point(44, 3);
      this.minX_Bounds_tb.Name = "minX_Bounds_tb";
      this.minX_Bounds_tb.Size = new Size(47, 20);
      this.minX_Bounds_tb.TabIndex = 70;
      this.minX_Bounds_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.label25.AutoSize = true;
      this.label25.Location = new Point(97, 0);
      this.label25.Name = "label25";
      this.label25.Size = new Size(37, 13);
      this.label25.TabIndex = 34;
      this.label25.Text = "Max-X";
      this.label26.AutoSize = true;
      this.label26.Location = new Point(97, 27);
      this.label26.Name = "label26";
      this.label26.Size = new Size(37, 13);
      this.label26.TabIndex = 35;
      this.label26.Text = "Max-Y";
      this.label27.AutoSize = true;
      this.label27.Location = new Point(97, 54);
      this.label27.Name = "label27";
      this.label27.Size = new Size(37, 13);
      this.label27.TabIndex = 36;
      this.label27.Text = "Max-Z";
      this.maxX_Bounds_tb.Location = new Point(144, 3);
      this.maxX_Bounds_tb.Name = "maxX_Bounds_tb";
      this.maxX_Bounds_tb.Size = new Size(43, 20);
      this.maxX_Bounds_tb.TabIndex = 71;
      this.maxX_Bounds_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.maxY_Bounds_tb.Location = new Point(144, 30);
      this.maxY_Bounds_tb.Name = "maxY_Bounds_tb";
      this.maxY_Bounds_tb.Size = new Size(43, 20);
      this.maxY_Bounds_tb.TabIndex = 73;
      this.maxY_Bounds_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.maxZ_Bounds_tb.Location = new Point(144, 57);
      this.maxZ_Bounds_tb.Name = "maxZ_Bounds_tb";
      this.maxZ_Bounds_tb.Size = new Size(43, 20);
      this.maxZ_Bounds_tb.TabIndex = 75;
      this.maxZ_Bounds_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.label28.AutoSize = true;
      this.label28.Location = new Point(122, 16);
      this.label28.Name = "label28";
      this.label28.Size = new Size(0, 13);
      this.label28.TabIndex = 43;
      this.col_levelentries_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_levelentries_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_levelentries_btn.FlatStyle = FlatStyle.Flat;
      this.col_levelentries_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_levelentries_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_levelentries_btn.Location = new Point(0, 1824);
      this.col_levelentries_btn.Margin = new Padding(0);
      this.col_levelentries_btn.Name = "col_levelentries_btn";
      this.col_levelentries_btn.Size = new Size(210, 23);
      this.col_levelentries_btn.TabIndex = 69;
      this.col_levelentries_btn.Text = "- Level Entries";
      this.col_levelentries_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_levelentries_btn.UseVisualStyleBackColor = false;
      this.col_levelentries_btn.Click += new EventHandler(this.col_levelentries_btn_Click);
      this.levelEntries_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.levelEntries_gb.Controls.Add((Control) this.levelEntries_dgv);
      this.levelEntries_gb.Location = new Point(3, 1850);
      this.levelEntries_gb.Name = "levelEntries_gb";
      this.levelEntries_gb.Size = new Size(207, 150);
      this.levelEntries_gb.TabIndex = 68;
      this.levelEntries_gb.TabStop = false;
      this.levelEntries_dgv.AllowUserToAddRows = false;
      this.levelEntries_dgv.AllowUserToDeleteRows = false;
      this.levelEntries_dgv.AllowUserToOrderColumns = true;
      this.levelEntries_dgv.AllowUserToResizeRows = false;
      this.levelEntries_dgv.BackgroundColor = Color.White;
      gridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle7.BackColor = SystemColors.Control;
      gridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle7.ForeColor = SystemColors.WindowText;
      gridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle7.WrapMode = DataGridViewTriState.True;
      this.levelEntries_dgv.ColumnHeadersDefaultCellStyle = gridViewCellStyle7;
      this.levelEntries_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle8.BackColor = SystemColors.Window;
      gridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle8.ForeColor = SystemColors.ControlText;
      gridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle8.WrapMode = DataGridViewTriState.False;
      this.levelEntries_dgv.DefaultCellStyle = gridViewCellStyle8;
      this.levelEntries_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.levelEntries_dgv.Location = new Point(7, 11);
      this.levelEntries_dgv.Margin = new Padding(3, 3, 3, 30);
      this.levelEntries_dgv.Name = "levelEntries_dgv";
      this.levelEntries_dgv.ReadOnly = true;
      gridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle9.BackColor = SystemColors.Control;
      gridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle9.ForeColor = SystemColors.WindowText;
      gridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle9.WrapMode = DataGridViewTriState.True;
      this.levelEntries_dgv.RowHeadersDefaultCellStyle = gridViewCellStyle9;
      this.levelEntries_dgv.Size = new Size(194, 133);
      this.levelEntries_dgv.TabIndex = 0;
      this.col_objects_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_objects_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_objects_btn.FlatStyle = FlatStyle.Flat;
      this.col_objects_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_objects_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_objects_btn.Location = new Point(0, 2003);
      this.col_objects_btn.Margin = new Padding(0);
      this.col_objects_btn.Name = "col_objects_btn";
      this.col_objects_btn.Size = new Size(210, 23);
      this.col_objects_btn.TabIndex = 71;
      this.col_objects_btn.Text = "- Objects";
      this.col_objects_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_objects_btn.UseVisualStyleBackColor = false;
      this.col_objects_btn.Click += new EventHandler(this.col_objects_btn_Click);
      this.objects_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.objects_gb.Controls.Add((Control) this.objects_dgv);
      this.objects_gb.Location = new Point(3, 2029);
      this.objects_gb.Name = "objects_gb";
      this.objects_gb.Size = new Size(207, 242);
      this.objects_gb.TabIndex = 72;
      this.objects_gb.TabStop = false;
      this.objects_dgv.AllowUserToAddRows = false;
      this.objects_dgv.AllowUserToDeleteRows = false;
      this.objects_dgv.AllowUserToOrderColumns = true;
      this.objects_dgv.AllowUserToResizeRows = false;
      this.objects_dgv.BackgroundColor = Color.White;
      gridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle10.BackColor = SystemColors.Control;
      gridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle10.ForeColor = SystemColors.WindowText;
      gridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle10.WrapMode = DataGridViewTriState.True;
      this.objects_dgv.ColumnHeadersDefaultCellStyle = gridViewCellStyle10;
      this.objects_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle11.BackColor = SystemColors.Window;
      gridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle11.ForeColor = SystemColors.ControlText;
      gridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle11.WrapMode = DataGridViewTriState.False;
      this.objects_dgv.DefaultCellStyle = gridViewCellStyle11;
      this.objects_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.objects_dgv.Location = new Point(7, 11);
      this.objects_dgv.Margin = new Padding(3, 3, 3, 30);
      this.objects_dgv.Name = "objects_dgv";
      this.objects_dgv.ReadOnly = true;
      gridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle12.BackColor = SystemColors.Control;
      gridViewCellStyle12.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle12.ForeColor = SystemColors.WindowText;
      gridViewCellStyle12.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle12.WrapMode = DataGridViewTriState.True;
      this.objects_dgv.RowHeadersDefaultCellStyle = gridViewCellStyle12;
      this.objects_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.objects_dgv.Size = new Size(194, 219);
      this.objects_dgv.TabIndex = 0;
      this.objects_dgv.CellDoubleClick += new DataGridViewCellEventHandler(this.objects_dgv_CellDoubleClick);
      this.col_structs_btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.col_structs_btn.BackColor = Color.FromArgb(233, 236, 250);
      this.col_structs_btn.FlatStyle = FlatStyle.Flat;
      this.col_structs_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.col_structs_btn.ForeColor = SystemColors.ControlDarkDark;
      this.col_structs_btn.Location = new Point(0, 2274);
      this.col_structs_btn.Margin = new Padding(0);
      this.col_structs_btn.Name = "col_structs_btn";
      this.col_structs_btn.Size = new Size(210, 23);
      this.col_structs_btn.TabIndex = 73;
      this.col_structs_btn.Text = "- Structs";
      this.col_structs_btn.TextAlign = ContentAlignment.MiddleLeft;
      this.col_structs_btn.UseVisualStyleBackColor = false;
      this.col_structs_btn.Click += new EventHandler(this.col_structs_btn_Click);
      this.structs_gb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.structs_gb.Controls.Add((Control) this.structs_dgv);
      this.structs_gb.Location = new Point(3, 2300);
      this.structs_gb.Name = "structs_gb";
      this.structs_gb.Size = new Size(207, 242);
      this.structs_gb.TabIndex = 74;
      this.structs_gb.TabStop = false;
      this.structs_dgv.AllowUserToAddRows = false;
      this.structs_dgv.AllowUserToDeleteRows = false;
      this.structs_dgv.AllowUserToOrderColumns = true;
      this.structs_dgv.AllowUserToResizeRows = false;
      this.structs_dgv.BackgroundColor = Color.White;
      gridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle13.BackColor = SystemColors.Control;
      gridViewCellStyle13.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle13.ForeColor = SystemColors.WindowText;
      gridViewCellStyle13.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle13.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle13.WrapMode = DataGridViewTriState.True;
      this.structs_dgv.ColumnHeadersDefaultCellStyle = gridViewCellStyle13;
      this.structs_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      gridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle14.BackColor = SystemColors.Window;
      gridViewCellStyle14.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle14.ForeColor = SystemColors.ControlText;
      gridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle14.WrapMode = DataGridViewTriState.False;
      this.structs_dgv.DefaultCellStyle = gridViewCellStyle14;
      this.structs_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.structs_dgv.Location = new Point(7, 11);
      this.structs_dgv.Margin = new Padding(3, 3, 3, 30);
      this.structs_dgv.Name = "structs_dgv";
      this.structs_dgv.ReadOnly = true;
      gridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleLeft;
      gridViewCellStyle15.BackColor = SystemColors.Control;
      gridViewCellStyle15.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      gridViewCellStyle15.ForeColor = SystemColors.WindowText;
      gridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
      gridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
      gridViewCellStyle15.WrapMode = DataGridViewTriState.True;
      this.structs_dgv.RowHeadersDefaultCellStyle = gridViewCellStyle15;
      this.structs_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.structs_dgv.Size = new Size(194, 219);
      this.structs_dgv.TabIndex = 0;
      this.structs_dgv.CellDoubleClick += new DataGridViewCellEventHandler(this.structs_dgv_CellDoubleClick);
      this.tableLayoutPanel6.ColumnCount = 4;
      this.tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5f));
      this.tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
      this.tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5f));
      this.tableLayoutPanel6.Controls.Add((Control) this.label6, 0, 0);
      this.tableLayoutPanel6.Location = new Point(0, 0);
      this.tableLayoutPanel6.Name = "tableLayoutPanel6";
      this.tableLayoutPanel6.RowCount = 1;
      this.tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel6.Size = new Size(200, 100);
      this.tableLayoutPanel6.TabIndex = 0;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(3, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(14, 13);
      this.label6.TabIndex = 28;
      this.label6.Text = "X";
      this.label7.AutoSize = true;
      this.label7.Location = new Point(3, 12);
      this.label7.Name = "label7";
      this.label7.Size = new Size(1, 8);
      this.label7.TabIndex = 30;
      this.label7.Text = "Z";
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(200, 100);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.tableLayoutPanel7.ColumnCount = 4;
      this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5f));
      this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
      this.tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5f));
      this.tableLayoutPanel7.Controls.Add((Control) this.label8, 0, 0);
      this.tableLayoutPanel7.Location = new Point(0, 0);
      this.tableLayoutPanel7.Name = "tableLayoutPanel7";
      this.tableLayoutPanel7.RowCount = 1;
      this.tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel7.Size = new Size(200, 100);
      this.tableLayoutPanel7.TabIndex = 0;
      this.label8.AutoSize = true;
      this.label8.Location = new Point(3, 0);
      this.label8.Name = "label8";
      this.label8.Size = new Size(14, 13);
      this.label8.TabIndex = 28;
      this.label8.Text = "X";
      this.label20.AutoSize = true;
      this.label20.Location = new Point(3, 54);
      this.label20.Name = "label20";
      this.label20.Size = new Size(13, 13);
      this.label20.TabIndex = 30;
      this.label20.Text = "Z";
      this.button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.button1.BackColor = Color.FromArgb(233, 236, 250);
      this.button1.FlatStyle = FlatStyle.Flat;
      this.button1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button1.ForeColor = SystemColors.ControlDarkDark;
      this.button1.Location = new Point(0, 405);
      this.button1.Margin = new Padding(0);
      this.button1.Name = "button1";
      this.button1.Size = new Size(210, 23);
      this.button1.TabIndex = 69;
      this.button1.Text = "- Level Boundaries";
      this.button1.TextAlign = ContentAlignment.MiddleLeft;
      this.button1.UseVisualStyleBackColor = false;
      this.groupBox2.Controls.Add((Control) this.label30);
      this.groupBox2.Controls.Add((Control) this.button2);
      this.groupBox2.Location = new Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(200, 100);
      this.groupBox2.TabIndex = 0;
      this.groupBox2.TabStop = false;
      this.label30.AutoSize = true;
      this.label30.Location = new Point(4, 107);
      this.label30.Name = "label30";
      this.label30.Size = new Size(160, 13);
      this.label30.TabIndex = 63;
      this.label30.Text = "WARNING will update model file";
      this.button2.Location = new Point(119, 123);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 62;
      this.button2.Text = "Update";
      this.button2.UseVisualStyleBackColor = true;
      this.tableLayoutPanel9.ColumnCount = 4;
      this.tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.57895f));
      this.tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.89474f));
      this.tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
      this.tableLayoutPanel9.Controls.Add((Control) this.label31, 0, 0);
      this.tableLayoutPanel9.Location = new Point(0, 0);
      this.tableLayoutPanel9.Name = "tableLayoutPanel9";
      this.tableLayoutPanel9.RowCount = 1;
      this.tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel9.Size = new Size(200, 100);
      this.tableLayoutPanel9.TabIndex = 0;
      this.label31.AutoSize = true;
      this.label31.Location = new Point(3, 0);
      this.label31.Name = "label31";
      this.label31.Size = new Size(34, 13);
      this.label31.TabIndex = 28;
      this.label31.Text = "Min-X";
      this.label32.AutoSize = true;
      this.label32.Location = new Point(3, 54);
      this.label32.Name = "label32";
      this.label32.Size = new Size(34, 13);
      this.label32.TabIndex = 30;
      this.label32.Text = "Min-Z";
      this.tableLayoutPanel11.ColumnCount = 4;
      this.tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5f));
      this.tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
      this.tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5f));
      this.tableLayoutPanel11.Controls.Add((Control) this.label41, 0, 0);
      this.tableLayoutPanel11.Location = new Point(0, 0);
      this.tableLayoutPanel11.Name = "tableLayoutPanel11";
      this.tableLayoutPanel11.RowCount = 1;
      this.tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel11.Size = new Size(200, 100);
      this.tableLayoutPanel11.TabIndex = 0;
      this.label41.AutoSize = true;
      this.label41.Location = new Point(3, 0);
      this.label41.Name = "label41";
      this.label41.Size = new Size(14, 13);
      this.label41.TabIndex = 28;
      this.label41.Text = "X";
      this.label42.AutoSize = true;
      this.label42.Location = new Point(3, 12);
      this.label42.Name = "label42";
      this.label42.Size = new Size(1, 8);
      this.label42.TabIndex = 30;
      this.label42.Text = "Z";
      this.cameraMenu.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.createCameraToolStripMenuItem,
        (ToolStripItem) this.createGameplayCameraToolStripMenuItem,
        (ToolStripItem) this.createGameplayTiggerToolStripMenuItem
      });
      this.cameraMenu.Name = "contextMenuStrip2";
      this.cameraMenu.Size = new Size(209, 70);
      this.cameraMenu.Opening += new CancelEventHandler(this.cameraMenu_Opening);
      this.createCameraToolStripMenuItem.Name = "createCameraToolStripMenuItem";
      this.createCameraToolStripMenuItem.Size = new Size(208, 22);
      this.createCameraToolStripMenuItem.Text = "Create Cutscene Camera";
      this.createCameraToolStripMenuItem.Click += new EventHandler(this.createCameraToolStripMenuItem_Click);
      this.createGameplayCameraToolStripMenuItem.Name = "createGameplayCameraToolStripMenuItem";
      this.createGameplayCameraToolStripMenuItem.Size = new Size(208, 22);
      this.createGameplayCameraToolStripMenuItem.Text = "Create Gameplay Camera";
      this.createGameplayCameraToolStripMenuItem.Click += new EventHandler(this.createGameplayCameraToolStripMenuItem_Click);
      this.createGameplayTiggerToolStripMenuItem.Name = "createGameplayTiggerToolStripMenuItem";
      this.createGameplayTiggerToolStripMenuItem.Size = new Size(208, 22);
      this.createGameplayTiggerToolStripMenuItem.Tag = (object) "Cam Trigger";
      this.createGameplayTiggerToolStripMenuItem.Text = "Create Camera Trigger";
      this.createGameplayTiggerToolStripMenuItem.Click += new EventHandler(this.createItem_MouseClick);
      this.tableLayoutPanel14.ColumnCount = 4;
      this.tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5f));
      this.tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
      this.tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5f));
      this.tableLayoutPanel14.Controls.Add((Control) this.label52, 0, 0);
      this.tableLayoutPanel14.Location = new Point(0, 0);
      this.tableLayoutPanel14.Name = "tableLayoutPanel14";
      this.tableLayoutPanel14.RowCount = 1;
      this.tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel14.Size = new Size(200, 100);
      this.tableLayoutPanel14.TabIndex = 0;
      this.label52.AutoSize = true;
      this.label52.Location = new Point(3, 0);
      this.label52.Name = "label52";
      this.label52.Size = new Size(14, 13);
      this.label52.TabIndex = 28;
      this.label52.Text = "X";
      this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox1.Enabled = false;
      this.textBox1.Location = new Point(22, 3);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(51, 20);
      this.textBox1.TabIndex = 18;
      this.tableLayoutPanel15.ColumnCount = 4;
      this.tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.5f));
      this.tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
      this.tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.5f));
      this.tableLayoutPanel15.Controls.Add((Control) this.textBox2, 0, 2);
      this.tableLayoutPanel15.Controls.Add((Control) this.label56, 0, 0);
      this.tableLayoutPanel15.Location = new Point(0, 0);
      this.tableLayoutPanel15.Name = "tableLayoutPanel15";
      this.tableLayoutPanel15.RowCount = 3;
      this.tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel15.Size = new Size(200, 100);
      this.tableLayoutPanel15.TabIndex = 0;
      this.textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox2.Location = new Point(3, 43);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new Size(14, 20);
      this.textBox2.TabIndex = 47;
      this.label56.AutoSize = true;
      this.label56.Location = new Point(3, 0);
      this.label56.Name = "label56";
      this.label56.Size = new Size(14, 13);
      this.label56.TabIndex = 28;
      this.label56.Text = "X";
      this.textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBox3.Location = new Point(22, 3);
      this.textBox3.Name = "textBox3";
      this.textBox3.Size = new Size(51, 20);
      this.textBox3.TabIndex = 18;
      this.groupBox3.Location = new Point(0, 0);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(200, 100);
      this.groupBox3.TabIndex = 0;
      this.groupBox3.TabStop = false;
      this.toolStrip1.BackColor = SystemColors.ActiveBorder;
      this.toolStrip1.Dock = DockStyle.Bottom;
      this.toolStrip1.Items.AddRange(new ToolStripItem[32]
      {
        (ToolStripItem) this.mode_lbl,
        (ToolStripItem) this.mode_cb,
        (ToolStripItem) this.rectSelect_btn,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.cam_moveToCurrent_btn,
        (ToolStripItem) this.obj_move_btn,
        (ToolStripItem) this.obj_rot_btn,
        (ToolStripItem) this.obj_scale_btn,
        (ToolStripItem) this.obj_duplicate_btn,
        (ToolStripItem) this.cam_yaw_btn,
        (ToolStripItem) this.cam_pitch_btn,
        (ToolStripItem) this.cam_roll_btn,
        (ToolStripItem) this.deselect_btn,
        (ToolStripItem) this.delete_btn,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.yOffset_tb,
        (ToolStripItem) this.toolStripLabel2,
        (ToolStripItem) this.lockZ_btn,
        (ToolStripItem) this.lockY_btn,
        (ToolStripItem) this.lockX_btn,
        (ToolStripItem) this.assignObject_btn,
        (ToolStripItem) this.moveNode_btn,
        (ToolStripItem) this.linkMode_btn,
        (ToolStripItem) this.removeNode_btn,
        (ToolStripItem) this.endNode_btn,
        (ToolStripItem) this.startNewPath_btn,
        (ToolStripItem) this.addNode_btn,
        (ToolStripItem) this.addControllerNode_btn,
        (ToolStripItem) this.deselectPath_btn,
        (ToolStripItem) this.deletePath_btn,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.eraseAll_btn
      });
      this.toolStrip1.Location = new Point(0, 504);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1190, 26);
      this.toolStrip1.TabIndex = 74;
      this.mode_lbl.Name = "mode_lbl";
      this.mode_lbl.Size = new Size(38, 23);
      this.mode_lbl.Text = "Mode";
      this.mode_cb.BackColor = SystemColors.ControlDarkDark;
      this.mode_cb.DropDownStyle = ComboBoxStyle.DropDownList;
      this.mode_cb.Enabled = false;
      this.mode_cb.ForeColor = Color.White;
      this.mode_cb.Items.AddRange(new object[4]
      {
        (object) "Select Mode",
        (object) "Create Mode",
        (object) "Camera Mode",
        (object) "Path Mode"
      });
      this.mode_cb.Name = "mode_cb";
      this.mode_cb.Size = new Size(100, 26);
      this.mode_cb.SelectedIndexChanged += new EventHandler(this.mode_cb_SelectedIndexChanged);
      this.rectSelect_btn.AutoToolTip = false;
      this.rectSelect_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.rectSelect_btn.Image = (Image) componentResourceManager.GetObject("rectSelect_btn.Image");
      this.rectSelect_btn.ImageTransparentColor = Color.Magenta;
      this.rectSelect_btn.Name = "rectSelect_btn";
      this.rectSelect_btn.Size = new Size(97, 23);
      this.rectSelect_btn.Text = "Rectangle Select";
      this.rectSelect_btn.Click += new EventHandler(this.rectSelect_btn_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 26);
      this.cam_moveToCurrent_btn.AutoToolTip = false;
      this.cam_moveToCurrent_btn.BackColor = SystemColors.ActiveBorder;
      this.cam_moveToCurrent_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.cam_moveToCurrent_btn.Image = (Image) componentResourceManager.GetObject("cam_moveToCurrent_btn.Image");
      this.cam_moveToCurrent_btn.ImageTransparentColor = Color.Magenta;
      this.cam_moveToCurrent_btn.Name = "cam_moveToCurrent_btn";
      this.cam_moveToCurrent_btn.Size = new Size(102, 23);
      this.cam_moveToCurrent_btn.Text = "Set to BB Camera";
      this.cam_moveToCurrent_btn.Click += new EventHandler(this.cam_moveToCurrent_btn_Click);
      this.obj_move_btn.AutoToolTip = false;
      this.obj_move_btn.BackColor = SystemColors.ActiveBorder;
      this.obj_move_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.obj_move_btn.Image = (Image) componentResourceManager.GetObject("obj_move_btn.Image");
      this.obj_move_btn.ImageTransparentColor = Color.Magenta;
      this.obj_move_btn.Name = "obj_move_btn";
      this.obj_move_btn.Size = new Size(41, 23);
      this.obj_move_btn.Text = "Move";
      this.obj_move_btn.Click += new EventHandler(this.obj_move_btn_Click);
      this.obj_rot_btn.AutoToolTip = false;
      this.obj_rot_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.obj_rot_btn.Image = (Image) componentResourceManager.GetObject("obj_rot_btn.Image");
      this.obj_rot_btn.ImageTransparentColor = Color.Magenta;
      this.obj_rot_btn.Name = "obj_rot_btn";
      this.obj_rot_btn.Size = new Size(45, 23);
      this.obj_rot_btn.Text = "Rotate";
      this.obj_rot_btn.Click += new EventHandler(this.obj_rot_btn_Click);
      this.obj_scale_btn.AutoToolTip = false;
      this.obj_scale_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.obj_scale_btn.Image = (Image) componentResourceManager.GetObject("obj_scale_btn.Image");
      this.obj_scale_btn.ImageTransparentColor = Color.Magenta;
      this.obj_scale_btn.Name = "obj_scale_btn";
      this.obj_scale_btn.Size = new Size(38, 23);
      this.obj_scale_btn.Text = "Scale";
      this.obj_scale_btn.Click += new EventHandler(this.obj_scale_btn_Click);
      this.obj_duplicate_btn.AutoToolTip = false;
      this.obj_duplicate_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.obj_duplicate_btn.Image = (Image) componentResourceManager.GetObject("obj_duplicate_btn.Image");
      this.obj_duplicate_btn.ImageTransparentColor = Color.Magenta;
      this.obj_duplicate_btn.Name = "obj_duplicate_btn";
      this.obj_duplicate_btn.Size = new Size(61, 23);
      this.obj_duplicate_btn.Text = "Duplicate";
      this.obj_duplicate_btn.Click += new EventHandler(this.obj_duplicate_btn_Click);
      this.cam_yaw_btn.AutoToolTip = false;
      this.cam_yaw_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.cam_yaw_btn.Image = (Image) componentResourceManager.GetObject("cam_yaw_btn.Image");
      this.cam_yaw_btn.ImageTransparentColor = Color.Magenta;
      this.cam_yaw_btn.Name = "cam_yaw_btn";
      this.cam_yaw_btn.Size = new Size(32, 23);
      this.cam_yaw_btn.Text = "Yaw";
      this.cam_yaw_btn.Click += new EventHandler(this.cam_yaw_btn_Click);
      this.cam_pitch_btn.AutoToolTip = false;
      this.cam_pitch_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.cam_pitch_btn.Image = (Image) componentResourceManager.GetObject("cam_pitch_btn.Image");
      this.cam_pitch_btn.ImageTransparentColor = Color.Magenta;
      this.cam_pitch_btn.Name = "cam_pitch_btn";
      this.cam_pitch_btn.Size = new Size(38, 23);
      this.cam_pitch_btn.Text = "Pitch";
      this.cam_pitch_btn.Click += new EventHandler(this.cam_pitch_btn_Click);
      this.cam_roll_btn.AutoToolTip = false;
      this.cam_roll_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.cam_roll_btn.Image = (Image) componentResourceManager.GetObject("cam_roll_btn.Image");
      this.cam_roll_btn.ImageTransparentColor = Color.Magenta;
      this.cam_roll_btn.Name = "cam_roll_btn";
      this.cam_roll_btn.Size = new Size(31, 23);
      this.cam_roll_btn.Text = "Roll";
      this.cam_roll_btn.Click += new EventHandler(this.cam_roll_btn_Click);
      this.deselect_btn.AutoToolTip = false;
      this.deselect_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.deselect_btn.Image = (Image) componentResourceManager.GetObject("deselect_btn.Image");
      this.deselect_btn.ImageTransparentColor = Color.Magenta;
      this.deselect_btn.Name = "deselect_btn";
      this.deselect_btn.Size = new Size(55, 23);
      this.deselect_btn.Text = "Deselect";
      this.deselect_btn.Click += new EventHandler(this.deselect_btn_Click);
      this.delete_btn.AutoToolTip = false;
      this.delete_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.delete_btn.Image = (Image) componentResourceManager.GetObject("delete_btn.Image");
      this.delete_btn.ImageTransparentColor = Color.Magenta;
      this.delete_btn.Name = "delete_btn";
      this.delete_btn.Size = new Size(44, 23);
      this.delete_btn.Text = "Delete";
      this.delete_btn.Click += new EventHandler(this.delete_btn_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 26);
      this.yOffset_tb.Alignment = ToolStripItemAlignment.Right;
      this.yOffset_tb.Margin = new Padding(3, 0, 0, 3);
      this.yOffset_tb.Name = "yOffset_tb";
      this.yOffset_tb.Size = new Size(40, 23);
      this.yOffset_tb.Text = "0";
      this.yOffset_tb.Leave += new EventHandler(this.yOffset_tb_Leave);
      this.yOffset_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.toolStripLabel2.Alignment = ToolStripItemAlignment.Right;
      this.toolStripLabel2.Name = "toolStripLabel2";
      this.toolStripLabel2.Size = new Size(51, 23);
      this.toolStripLabel2.Text = "Y-Offset";
      this.lockZ_btn.Alignment = ToolStripItemAlignment.Right;
      this.lockZ_btn.AutoToolTip = false;
      this.lockZ_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.lockZ_btn.Font = new Font("Segoe UI", 6f, FontStyle.Bold);
      this.lockZ_btn.Image = (Image) componentResourceManager.GetObject("lockZ_btn.Image");
      this.lockZ_btn.ImageTransparentColor = Color.Magenta;
      this.lockZ_btn.Name = "lockZ_btn";
      this.lockZ_btn.Size = new Size(36, 23);
      this.lockZ_btn.Text = "LOCK Z";
      this.lockZ_btn.Click += new EventHandler(this.lockZ_btn_Click);
      this.lockY_btn.Alignment = ToolStripItemAlignment.Right;
      this.lockY_btn.AutoToolTip = false;
      this.lockY_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.lockY_btn.Font = new Font("Segoe UI", 6f, FontStyle.Bold);
      this.lockY_btn.Image = (Image) componentResourceManager.GetObject("lockY_btn.Image");
      this.lockY_btn.ImageTransparentColor = Color.Magenta;
      this.lockY_btn.Name = "lockY_btn";
      this.lockY_btn.Size = new Size(36, 23);
      this.lockY_btn.Text = "LOCK Y";
      this.lockY_btn.Click += new EventHandler(this.lockY_btn_Click);
      this.lockX_btn.Alignment = ToolStripItemAlignment.Right;
      this.lockX_btn.AutoToolTip = false;
      this.lockX_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.lockX_btn.Font = new Font("Segoe UI", 6f, FontStyle.Bold);
      this.lockX_btn.Image = (Image) componentResourceManager.GetObject("lockX_btn.Image");
      this.lockX_btn.ImageTransparentColor = Color.Magenta;
      this.lockX_btn.Name = "lockX_btn";
      this.lockX_btn.Size = new Size(36, 23);
      this.lockX_btn.Text = "LOCK X";
      this.lockX_btn.Click += new EventHandler(this.lockX_btn_Click);
      this.assignObject_btn.AutoToolTip = false;
      this.assignObject_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.assignObject_btn.Image = (Image) componentResourceManager.GetObject("assignObject_btn.Image");
      this.assignObject_btn.ImageTransparentColor = Color.Magenta;
      this.assignObject_btn.Name = "assignObject_btn";
      this.assignObject_btn.Size = new Size(69, 23);
      this.assignObject_btn.Text = "Assign OBJ";
      this.assignObject_btn.Click += new EventHandler(this.assignObject_btn_Click);
      this.moveNode_btn.AutoToolTip = false;
      this.moveNode_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.moveNode_btn.Image = (Image) componentResourceManager.GetObject("moveNode_btn.Image");
      this.moveNode_btn.ImageTransparentColor = Color.Magenta;
      this.moveNode_btn.Name = "moveNode_btn";
      this.moveNode_btn.Size = new Size(73, 23);
      this.moveNode_btn.Text = "Move Node";
      this.moveNode_btn.Click += new EventHandler(this.moveNode_btn_Click);
      this.linkMode_btn.AutoToolTip = false;
      this.linkMode_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.linkMode_btn.Image = (Image) componentResourceManager.GetObject("linkMode_btn.Image");
      this.linkMode_btn.ImageTransparentColor = Color.Magenta;
      this.linkMode_btn.Name = "linkMode_btn";
      this.linkMode_btn.Size = new Size(33, 23);
      this.linkMode_btn.Text = "Link";
      this.linkMode_btn.Click += new EventHandler(this.linkMode_btn_Click);
      this.removeNode_btn.AutoToolTip = false;
      this.removeNode_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.removeNode_btn.Image = (Image) componentResourceManager.GetObject("removeNode_btn.Image");
      this.removeNode_btn.ImageTransparentColor = Color.Magenta;
      this.removeNode_btn.Name = "removeNode_btn";
      this.removeNode_btn.Size = new Size(63, 19);
      this.removeNode_btn.Text = "Del. Node";
      this.removeNode_btn.Click += new EventHandler(this.removeNode_btn_Click);
      this.endNode_btn.AutoToolTip = false;
      this.endNode_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.endNode_btn.Image = (Image) componentResourceManager.GetObject("endNode_btn.Image");
      this.endNode_btn.ImageTransparentColor = Color.Magenta;
      this.endNode_btn.Name = "endNode_btn";
      this.endNode_btn.Size = new Size(63, 19);
      this.endNode_btn.Text = "End Node";
      this.endNode_btn.Click += new EventHandler(this.endNode_btn_Click);
      this.startNewPath_btn.AutoToolTip = false;
      this.startNewPath_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.startNewPath_btn.Image = (Image) componentResourceManager.GetObject("startNewPath_btn.Image");
      this.startNewPath_btn.ImageTransparentColor = Color.Magenta;
      this.startNewPath_btn.Name = "startNewPath_btn";
      this.startNewPath_btn.Size = new Size(62, 19);
      this.startNewPath_btn.Text = "New Path";
      this.startNewPath_btn.Click += new EventHandler(this.startNewPath_btn_Click);
      this.addNode_btn.AutoToolTip = false;
      this.addNode_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addNode_btn.Image = (Image) componentResourceManager.GetObject("addNode_btn.Image");
      this.addNode_btn.ImageTransparentColor = Color.Magenta;
      this.addNode_btn.Name = "addNode_btn";
      this.addNode_btn.Size = new Size(65, 19);
      this.addNode_btn.Text = "Add Node";
      this.addNode_btn.Click += new EventHandler(this.addNode_btn_Click_1);
      this.addControllerNode_btn.AutoToolTip = false;
      this.addControllerNode_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.addControllerNode_btn.Image = (Image) componentResourceManager.GetObject("addControllerNode_btn.Image");
      this.addControllerNode_btn.ImageTransparentColor = Color.Magenta;
      this.addControllerNode_btn.Name = "addControllerNode_btn";
      this.addControllerNode_btn.Size = new Size(116, 19);
      this.addControllerNode_btn.Text = "Add Path Controller";
      this.addControllerNode_btn.Click += new EventHandler(this.addAnimationNode_btn_Click);
      this.deselectPath_btn.AutoToolTip = false;
      this.deselectPath_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.deselectPath_btn.Image = (Image) componentResourceManager.GetObject("deselectPath_btn.Image");
      this.deselectPath_btn.ImageTransparentColor = Color.Magenta;
      this.deselectPath_btn.Name = "deselectPath_btn";
      this.deselectPath_btn.Size = new Size(82, 19);
      this.deselectPath_btn.Text = "Deselect Path";
      this.deselectPath_btn.Click += new EventHandler(this.deselectPath_btn_Click);
      this.deletePath_btn.AutoToolTip = false;
      this.deletePath_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.deletePath_btn.Image = (Image) componentResourceManager.GetObject("deletePath_btn.Image");
      this.deletePath_btn.ImageTransparentColor = Color.Magenta;
      this.deletePath_btn.Name = "deletePath_btn";
      this.deletePath_btn.Size = new Size(71, 19);
      this.deletePath_btn.Text = "Delete Path";
      this.deletePath_btn.Click += new EventHandler(this.deletePath_btn_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 26);
      this.eraseAll_btn.AutoToolTip = false;
      this.eraseAll_btn.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.eraseAll_btn.Image = (Image) componentResourceManager.GetObject("eraseAll_btn.Image");
      this.eraseAll_btn.ImageTransparentColor = Color.Magenta;
      this.eraseAll_btn.Name = "eraseAll_btn";
      this.eraseAll_btn.Size = new Size(55, 19);
      this.eraseAll_btn.Text = "Erase All";
      this.eraseAll_btn.Visible = false;
      this.eraseAll_btn.Click += new EventHandler(this.eraseAll_btn_Click);
      this.button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.button3.BackColor = Color.FromArgb(233, 236, 250);
      this.button3.FlatStyle = FlatStyle.Flat;
      this.button3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.button3.ForeColor = SystemColors.ControlDarkDark;
      this.button3.Location = new Point(960, 27);
      this.button3.Margin = new Padding(0);
      this.button3.Name = "button3";
      this.button3.Size = new Size(230, 23);
      this.button3.TabIndex = 80;
      this.button3.Text = "Layers";
      this.button3.TextAlign = ContentAlignment.MiddleLeft;
      this.button3.UseVisualStyleBackColor = false;
      this.bgA_cb.AutoSize = true;
      this.bgA_cb.Checked = true;
      this.bgA_cb.CheckState = CheckState.Checked;
      this.bgA_cb.Location = new Point(4, 4);
      this.bgA_cb.Name = "bgA_cb";
      this.bgA_cb.Size = new Size(14, 14);
      this.bgA_cb.TabIndex = 0;
      this.bgA_cb.UseVisualStyleBackColor = true;
      this.bgA_cb.CheckedChanged += new EventHandler(this.bgA_cb_CheckedChanged);
      this.bgB_btn.AutoSize = true;
      this.bgB_btn.Checked = true;
      this.bgB_btn.CheckState = CheckState.Checked;
      this.bgB_btn.Location = new Point(4, 29);
      this.bgB_btn.Name = "bgB_btn";
      this.bgB_btn.Size = new Size(14, 14);
      this.bgB_btn.TabIndex = 1;
      this.bgB_btn.UseVisualStyleBackColor = true;
      this.bgB_btn.CheckedChanged += new EventHandler(this.bgB_btn_CheckedChanged);
      this.objs_cb.AutoSize = true;
      this.objs_cb.Checked = true;
      this.objs_cb.CheckState = CheckState.Checked;
      this.objs_cb.Location = new Point(4, 54);
      this.objs_cb.Name = "objs_cb";
      this.objs_cb.Size = new Size(14, 14);
      this.objs_cb.TabIndex = 2;
      this.objs_cb.UseVisualStyleBackColor = true;
      this.objs_cb.CheckedChanged += new EventHandler(this.objs_cb_CheckedChanged);
      this.label59.AutoSize = true;
      this.label59.Location = new Point(25, 26);
      this.label59.Name = "label59";
      this.label59.Size = new Size(75, 13);
      this.label59.TabIndex = 6;
      this.label59.Text = "Background B";
      this.label51.AutoSize = true;
      this.label51.Location = new Point(25, 1);
      this.label51.Name = "label51";
      this.label51.Size = new Size(75, 13);
      this.label51.TabIndex = 5;
      this.label51.Text = "Background A";
      this.label64.AutoSize = true;
      this.label64.Location = new Point(25, 51);
      this.label64.Name = "label64";
      this.label64.Size = new Size(43, 13);
      this.label64.TabIndex = 7;
      this.label64.Text = "Objects";
      this.label65.AutoSize = true;
      this.label65.Location = new Point(25, 76);
      this.label65.Name = "label65";
      this.label65.Size = new Size(48, 13);
      this.label65.TabIndex = 8;
      this.label65.Text = "Cameras";
      this.cameras_cb.AutoSize = true;
      this.cameras_cb.Checked = true;
      this.cameras_cb.CheckState = CheckState.Checked;
      this.cameras_cb.Location = new Point(4, 79);
      this.cameras_cb.Name = "cameras_cb";
      this.cameras_cb.Size = new Size(14, 14);
      this.cameras_cb.TabIndex = 9;
      this.cameras_cb.UseVisualStyleBackColor = true;
      this.cameras_cb.CheckedChanged += new EventHandler(this.cameras_cb_CheckedChanged);
      this.tableLayoutPanel1.BackColor = Color.White;
      this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
      this.tableLayoutPanel1.ColumnCount = 2;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.5f));
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 89.5f));
      this.tableLayoutPanel1.Controls.Add((Control) this.levelBoundAlpha_cb, 0, 6);
      this.tableLayoutPanel1.Controls.Add((Control) this.label5, 1, 6);
      this.tableLayoutPanel1.Controls.Add((Control) this.levelStats_cb, 0, 4);
      this.tableLayoutPanel1.Controls.Add((Control) this.bgA_cb, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.bgB_btn, 0, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.objs_cb, 0, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.cameras_cb, 0, 3);
      this.tableLayoutPanel1.Controls.Add((Control) this.label51, 1, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.label59, 1, 1);
      this.tableLayoutPanel1.Controls.Add((Control) this.label64, 1, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.label65, 1, 3);
      this.tableLayoutPanel1.Controls.Add((Control) this.label14, 1, 4);
      this.tableLayoutPanel1.Controls.Add((Control) this.label58, 1, 5);
      this.tableLayoutPanel1.Controls.Add((Control) this.levelBound_cb, 0, 5);
      this.tableLayoutPanel1.Controls.Add((Control) this.label75, 1, 11);
      this.tableLayoutPanel1.Controls.Add((Control) this.unknownRadius_cb, 0, 11);
      this.tableLayoutPanel1.Controls.Add((Control) this.flagRadius_cb, 1, 10);
      this.tableLayoutPanel1.Controls.Add((Control) this.showFlagRadius_cb, 0, 10);
      this.tableLayoutPanel1.Controls.Add((Control) this.label72, 1, 9);
      this.tableLayoutPanel1.Controls.Add((Control) this.enemyRadius_cb, 0, 9);
      this.tableLayoutPanel1.Controls.Add((Control) this.label71, 1, 8);
      this.tableLayoutPanel1.Controls.Add((Control) this.warpRadius_cb, 0, 8);
      this.tableLayoutPanel1.Controls.Add((Control) this.label66, 1, 7);
      this.tableLayoutPanel1.Controls.Add((Control) this.camTrigger_cb, 0, 7);
      this.tableLayoutPanel1.Location = new Point(3, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 12;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
      this.tableLayoutPanel1.Size = new Size(201, 300);
      this.tableLayoutPanel1.TabIndex = 81;
      this.levelBoundAlpha_cb.AutoSize = true;
      this.levelBoundAlpha_cb.Location = new Point(4, 154);
      this.levelBoundAlpha_cb.Name = "levelBoundAlpha_cb";
      this.levelBoundAlpha_cb.Size = new Size(14, 14);
      this.levelBoundAlpha_cb.TabIndex = 84;
      this.levelBoundAlpha_cb.UseVisualStyleBackColor = true;
      this.levelBoundAlpha_cb.CheckedChanged += new EventHandler(this.levelBoundAlpha_cb_CheckedChanged);
      this.label5.AutoSize = true;
      this.label5.Location = new Point(25, 151);
      this.label5.Name = "label5";
      this.label5.Size = new Size(116, 13);
      this.label5.TabIndex = 84;
      this.label5.Text = "Level Boundary (alpha)";
      this.levelStats_cb.AutoSize = true;
      this.levelStats_cb.Checked = true;
      this.levelStats_cb.CheckState = CheckState.Checked;
      this.levelStats_cb.Location = new Point(4, 104);
      this.levelStats_cb.Name = "levelStats_cb";
      this.levelStats_cb.Size = new Size(14, 14);
      this.levelStats_cb.TabIndex = 11;
      this.levelStats_cb.UseVisualStyleBackColor = true;
      this.levelStats_cb.CheckedChanged += new EventHandler(this.levelStats_cb_CheckedChanged);
      this.label14.AutoSize = true;
      this.label14.Location = new Point(25, 101);
      this.label14.Name = "label14";
      this.label14.Size = new Size(60, 13);
      this.label14.TabIndex = 10;
      this.label14.Text = "Level Stats";
      this.label58.AutoSize = true;
      this.label58.Location = new Point(25, 126);
      this.label58.Name = "label58";
      this.label58.Size = new Size(81, 13);
      this.label58.TabIndex = 12;
      this.label58.Text = "Level Boundary";
      this.levelBound_cb.AutoSize = true;
      this.levelBound_cb.Location = new Point(4, 129);
      this.levelBound_cb.Name = "levelBound_cb";
      this.levelBound_cb.Size = new Size(14, 14);
      this.levelBound_cb.TabIndex = 15;
      this.levelBound_cb.UseVisualStyleBackColor = true;
      this.levelBound_cb.CheckedChanged += new EventHandler(this.levelBound_cb_CheckedChanged);
      this.label75.AutoSize = true;
      this.label75.Location = new Point(25, 276);
      this.label75.Name = "label75";
      this.label75.Size = new Size(123, 13);
      this.label75.TabIndex = 23;
      this.label75.Text = "Unknown Object Radius";
      this.unknownRadius_cb.AutoSize = true;
      this.unknownRadius_cb.Location = new Point(4, 279);
      this.unknownRadius_cb.Name = "unknownRadius_cb";
      this.unknownRadius_cb.Size = new Size(14, 14);
      this.unknownRadius_cb.TabIndex = 24;
      this.unknownRadius_cb.UseVisualStyleBackColor = true;
      this.unknownRadius_cb.CheckedChanged += new EventHandler(this.unknownRadius_cb_CheckedChanged);
      this.flagRadius_cb.AutoSize = true;
      this.flagRadius_cb.Location = new Point(25, 251);
      this.flagRadius_cb.Name = "flagRadius_cb";
      this.flagRadius_cb.Size = new Size(63, 13);
      this.flagRadius_cb.TabIndex = 20;
      this.flagRadius_cb.Text = "Flag Radius";
      this.showFlagRadius_cb.AutoSize = true;
      this.showFlagRadius_cb.Location = new Point(4, 254);
      this.showFlagRadius_cb.Name = "showFlagRadius_cb";
      this.showFlagRadius_cb.Size = new Size(14, 14);
      this.showFlagRadius_cb.TabIndex = 22;
      this.showFlagRadius_cb.UseVisualStyleBackColor = true;
      this.showFlagRadius_cb.CheckedChanged += new EventHandler(this.showFlagRadius_cb_CheckedChanged);
      this.label72.AutoSize = true;
      this.label72.Location = new Point(25, 226);
      this.label72.Name = "label72";
      this.label72.Size = new Size(75, 13);
      this.label72.TabIndex = 19;
      this.label72.Text = "Enemy Radius";
      this.enemyRadius_cb.AutoSize = true;
      this.enemyRadius_cb.Location = new Point(4, 229);
      this.enemyRadius_cb.Name = "enemyRadius_cb";
      this.enemyRadius_cb.Size = new Size(14, 14);
      this.enemyRadius_cb.TabIndex = 21;
      this.enemyRadius_cb.UseVisualStyleBackColor = true;
      this.enemyRadius_cb.CheckedChanged += new EventHandler(this.enemyRadius_cb_CheckedChanged);
      this.label71.AutoSize = true;
      this.label71.Location = new Point(25, 201);
      this.label71.Name = "label71";
      this.label71.Size = new Size(69, 13);
      this.label71.TabIndex = 17;
      this.label71.Text = "Warp Radius";
      this.warpRadius_cb.AutoSize = true;
      this.warpRadius_cb.Location = new Point(4, 204);
      this.warpRadius_cb.Name = "warpRadius_cb";
      this.warpRadius_cb.Size = new Size(14, 14);
      this.warpRadius_cb.TabIndex = 18;
      this.warpRadius_cb.UseVisualStyleBackColor = true;
      this.warpRadius_cb.CheckedChanged += new EventHandler(this.warpRadius_cb_CheckedChanged);
      this.label66.AutoSize = true;
      this.label66.Location = new Point(25, 176);
      this.label66.Name = "label66";
      this.label66.Size = new Size(115, 13);
      this.label66.TabIndex = 13;
      this.label66.Text = "Camera Trigger Radius";
      this.camTrigger_cb.AutoSize = true;
      this.camTrigger_cb.Location = new Point(4, 179);
      this.camTrigger_cb.Name = "camTrigger_cb";
      this.camTrigger_cb.Size = new Size(14, 14);
      this.camTrigger_cb.TabIndex = 16;
      this.camTrigger_cb.UseVisualStyleBackColor = true;
      this.camTrigger_cb.CheckedChanged += new EventHandler(this.camTrigger_cb_CheckedChanged);
      this.flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.flowLayoutPanel2.AutoScroll = true;
      this.flowLayoutPanel2.BorderStyle = BorderStyle.FixedSingle;
      this.flowLayoutPanel2.Controls.Add((Control) this.tableLayoutPanel1);
      this.flowLayoutPanel2.Location = new Point(960, 51);
      this.flowLayoutPanel2.Name = "flowLayoutPanel2";
      this.flowLayoutPanel2.Size = new Size(229, 102);
      this.flowLayoutPanel2.TabIndex = 83;
      this.drawDist_tb.Location = new Point(897, 3);
      this.drawDist_tb.Name = "drawDist_tb";
      this.drawDist_tb.Size = new Size(53, 20);
      this.drawDist_tb.TabIndex = 84;
      this.drawDist_tb.Text = "5000";
      this.drawDist_tb.KeyPress += new KeyPressEventHandler(this.numOnly_KeyPress);
      this.drawDist_tb.Leave += new EventHandler(this.drawDist_tb_Leave);
      this.label12.AutoSize = true;
      this.label12.BackColor = SystemColors.ActiveCaption;
      this.label12.Location = new Point(780, 6);
      this.label12.Name = "label12";
      this.label12.Size = new Size(111, 13);
      this.label12.TabIndex = 85;
      this.label12.Text = "Object Draw Distance";
      this.LevelViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.LevelViewer.BackColor = Color.Black;
      this.LevelViewer.Location = new Point(0, 27);
      this.LevelViewer.Name = "LevelViewer";
      this.LevelViewer.Size = new Size(957, 474);
      this.LevelViewer.TabIndex = 86;
      this.LevelViewer.VSync = false;
      this.LevelViewer.Load += new EventHandler(this.LevelViewer_Load);
      this.LevelViewer.SizeChanged += new EventHandler(this.LevelViewer_SizeChanged);
      this.LevelViewer.KeyDown += new KeyEventHandler(this.LevelViewer_KeyDown);
      this.LevelViewer.KeyUp += new KeyEventHandler(this.LevelViewer_KeyUp);
      this.LevelViewer.MouseDown += new MouseEventHandler(this.LevelViewer_MouseDown);
      this.LevelViewer.MouseMove += new MouseEventHandler(this.LevelViewer_MouseMove);
      this.LevelViewer.MouseUp += new MouseEventHandler(this.LevelViewer_MouseUp);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(229, 229, 229);
      this.ClientSize = new Size(1190, 530);
      this.Controls.Add((Control) this.LevelViewer);
      this.Controls.Add((Control) this.drawDist_tb);
      this.Controls.Add((Control) this.flowLayoutPanel2);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.CamSpeed_tb);
      this.Controls.Add((Control) this.menuStrip1);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.flowLayoutPanel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (Form1);
      this.Text = "Banjo's Backpack";
      this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
      this.Load += new EventHandler(this.Form1_Load);
      this.ResizeEnd += new EventHandler(this.Form1_ResizeEnd);
      this.SizeChanged += new EventHandler(this.Form1_SizeChanged);
      this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
      this.KeyUp += new KeyEventHandler(this.Form1_KeyUp);
      this.MouseUp += new MouseEventHandler(this.Form1_MouseUp);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.textUpdate_gb.ResumeLayout(false);
      this.textUpdate_gb.PerformLayout();
      this.tableLayoutPanel4.ResumeLayout(false);
      this.tableLayoutPanel4.PerformLayout();
      this.tableLayoutPanel3.ResumeLayout(false);
      this.tableLayoutPanel3.PerformLayout();
      this.CamSpeed_tb.EndInit();
      this.replacemodel_gb.ResumeLayout(false);
      this.replacemodel_gb.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout(false);
      this.path_gb.ResumeLayout(false);
      this.path_gb.PerformLayout();
      ((ISupportInitialize) this.pathControllers_dgv).EndInit();
      this.nodeID_gb.ResumeLayout(false);
      this.tableLayoutPanel13.ResumeLayout(false);
      this.tableLayoutPanel13.PerformLayout();
      this.sNode_gb.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.nodeProperties_gb.ResumeLayout(false);
      this.nodeProperties_lp.ResumeLayout(false);
      this.nodeProperties_lp.PerformLayout();
      this.pathObject_gb.ResumeLayout(false);
      this.tableLayoutPanel16.ResumeLayout(false);
      this.tableLayoutPanel16.PerformLayout();
      ((ISupportInitialize) this.path_dgv).EndInit();
      this.cam3_gb.ResumeLayout(false);
      this.cam3_gb.PerformLayout();
      this.tableLayoutPanel10.ResumeLayout(false);
      this.tableLayoutPanel10.PerformLayout();
      this.bounds_gb.ResumeLayout(false);
      this.bounds_gb.PerformLayout();
      this.tableLayoutPanel8.ResumeLayout(false);
      this.tableLayoutPanel8.PerformLayout();
      this.levelEntries_gb.ResumeLayout(false);
      ((ISupportInitialize) this.levelEntries_dgv).EndInit();
      this.objects_gb.ResumeLayout(false);
      ((ISupportInitialize) this.objects_dgv).EndInit();
      this.structs_gb.ResumeLayout(false);
      ((ISupportInitialize) this.structs_dgv).EndInit();
      this.tableLayoutPanel6.ResumeLayout(false);
      this.tableLayoutPanel6.PerformLayout();
      this.tableLayoutPanel7.ResumeLayout(false);
      this.tableLayoutPanel7.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.tableLayoutPanel9.ResumeLayout(false);
      this.tableLayoutPanel9.PerformLayout();
      this.tableLayoutPanel11.ResumeLayout(false);
      this.tableLayoutPanel11.PerformLayout();
      this.cameraMenu.ResumeLayout(false);
      this.tableLayoutPanel14.ResumeLayout(false);
      this.tableLayoutPanel14.PerformLayout();
      this.tableLayoutPanel15.ResumeLayout(false);
      this.tableLayoutPanel15.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.flowLayoutPanel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
