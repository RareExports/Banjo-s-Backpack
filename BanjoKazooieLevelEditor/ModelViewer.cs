// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ModelViewer
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using BanjoKazooieLevelEditor.Properties;
using Collada141;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace BanjoKazooieLevelEditor
{
  public class ModelViewer : Form
  {
    private bool loaded;
    private bool isDLAnimation;
    private byte[] bytesInFile;
    private float translationFactor;
    private List<ObjectData> models = new List<ObjectData>();
    private List<SetupFile> levels = new List<SetupFile>();
    private Color active = SystemColors.ControlDarkDark;
    private Color inactive = SystemColors.ActiveBorder;
    private Core core = new Core();
    private GLCamera BBCamera = new GLCamera();
    private bool zoomIn;
    private bool zoomOut;
    private bool left;
    private bool right;
    private uint vboVertexHandle;
    private uint vboColorHandle;
    private uint vboTexCoordHandle;
    private List<uint> iboHandles = new List<uint>();
    private List<ushort[]> iboData = new List<ushort[]>();
    private List<int> textures = new List<int>();
    private float[] vertexData = new float[1];
    private int newx;
    private int newy;
    private int oldx;
    private int oldy;
    private bool sceneClick;
    private bool RotateSceneClick;
    private string tmpDir = "";
    private string outDir = "";
    private bool forceRedraw;
    private List<int> dlOffsets = new List<int>();
    private uint CurrentModelDL = 200001;
    private List<float[]> vertexFrames = new List<float[]>();
    private List<Bone> skeleton = new List<Bone>();
    private List<uint> SkeletonDL = new List<uint>();
    private ObjectData o;
    private BKAnimation animation;
    private bool drawSkeleton;
    private List<AnimationFile> animations = new List<AnimationFile>();
    private string replacementModel = "";
    public List<int> updatedModels = new List<int>();
    private int levelPointer;
    private bool usingARB;
    private byte[] rom;
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem loadReplacementModelToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.Timer timer1;
    private OpenFileDialog openFileDialog1;
    private Label label4;
    internal TrackBar CamSpeed_tb;
    private ToolStripMenuItem exportToGeObjToolStripMenuItem;
    private FolderBrowserDialog folderBrowserDialog;
    private DataGridView objects_dgv;
    private DataGridView levels_dgv;
    private DataGridView animation_dgv;
    private Button play_btn;
    private System.Windows.Forms.Timer animationPlayer_timer;
    private Button stop_btn;
    private Label frameNo_lbl;
    private Panel panel1;
    private ColorTrackBar frame_trackBar;
    private NumericUpDown frame_spin;
    private Panel panel2;
    private Label label1;
    private TextBox fps_tb;
    private ToolStripMenuItem exportToColladadaeToolStripMenuItem;
    private Label fileInfo_lbl;
    private Label lbl_glVersion;
    private GLControl BKOpenGLC;
    private ToolStripMenuItem importColladadaeToolStripMenuItem;
    private OpenFileDialog openFileDialog2;

    public ModelViewer(
      ref byte[] rom_,
      string tmpDir_,
      string outDir_,
      ref List<SetupFile> levels_)
    {
      this.rom = rom_;
      this.levels = levels_;
      this.InitializeComponent();
      this.readObjectsXML();
      this.readAnimationsXML();
      this.DisplayFiles();
      this.tmpDir = tmpDir_;
      this.outDir = outDir_;
    }

    private void ModelViewer_Load(object sender, EventArgs e)
    {
      this.forceRedraw = true;
      this.BKOpenGLC.SwapBuffers();
      this.BKOpenGLC.Invalidate();
    }

    private void DisplayFiles()
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
      List<string> stringList = new List<string>();
      for (int index = 0; index < this.models.Count; ++index)
      {
        if (!stringList.Contains(this.models[index].name))
        {
          this.objects_dgv.Rows.Add((object) index, (object) this.models[index].name);
          stringList.Add(this.models[index].name);
        }
      }
      this.objects_dgv.Columns[0].Visible = false;
      this.objects_dgv.Sort(this.objects_dgv.Columns[1], ListSortDirection.Ascending);
      this.levels_dgv.Rows.Clear();
      this.levels_dgv.Columns.Clear();
      this.levels_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.levels_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.levels_dgv.AutoGenerateColumns = false;
      this.levels_dgv.RowHeadersVisible = false;
      this.levels_dgv.MultiSelect = false;
      DataGridViewColumnCollection columns3 = this.levels_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn3 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn3.HeaderText = "REF";
      viewTextBoxColumn3.ReadOnly = true;
      viewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn3.FillWeight = 25f;
      columns3.Add((DataGridViewColumn) viewTextBoxColumn3);
      DataGridViewColumnCollection columns4 = this.levels_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn4 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn4.HeaderText = "Level Name";
      viewTextBoxColumn4.ReadOnly = true;
      viewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn4.FillWeight = 25f;
      columns4.Add((DataGridViewColumn) viewTextBoxColumn4);
      for (int index = 0; index < this.levels.Count; ++index)
      {
        this.levels_dgv.Rows.Add((object) index, (object) this.levels[index].name);
        if (this.levels[index].modelBPointer != 0)
          this.levels_dgv.Rows.Add((object) index, (object) (this.levels[index].name + " B"));
      }
      this.levels_dgv.Columns[0].Visible = false;
      this.objects_dgv.ClearSelection();
      this.levels_dgv.ClearSelection();
    }

    private void DisplayAnimationFiles(int modelPointer)
    {
      this.animation_dgv.Rows.Clear();
      this.animation_dgv.Columns.Clear();
      this.animation_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.animation_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.animation_dgv.AutoGenerateColumns = false;
      this.animation_dgv.RowHeadersVisible = false;
      this.animation_dgv.MultiSelect = false;
      DataGridViewColumnCollection columns1 = this.animation_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "REF";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn1.FillWeight = 25f;
      columns1.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewColumnCollection columns2 = this.animation_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Name";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn2.FillWeight = 25f;
      columns2.Add((DataGridViewColumn) viewTextBoxColumn2);
      for (int index = 0; index < this.animations.Count; ++index)
      {
        if (this.animations[index].modelPointers.Contains(modelPointer))
          this.animation_dgv.Rows.Add((object) index, (object) this.animations[index].name);
      }
      this.animation_dgv.Columns[0].Visible = false;
      this.animation_dgv.ClearSelection();
    }

    private void readObjectsXML()
    {
      try
      {
        XmlTextReader xmlTextReader = new XmlTextReader(".\\resources\\objects.xml");
        while (xmlTextReader.Read())
        {
          string name = xmlTextReader.Name;
          ObjectData objectData = new ObjectData((short) 0, 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0);
          if (name == "object" || name == "struct")
          {
            int pointer_ = xmlTextReader.GetAttribute("pointer") == null ? 0 : Convert.ToInt32(xmlTextReader.GetAttribute("pointer"), 16);
            switch (pointer_)
            {
              case 0:
              case 1:
                continue;
              default:
                string name_ = xmlTextReader.GetAttribute("name") == null ? "" : xmlTextReader.GetAttribute("name");
                if (name_ != "Banjo" && name_ != "Banjo cooking")
                {
                  short objectID_ = xmlTextReader.GetAttribute("id") == null ? (short) 0 : Convert.ToInt16(xmlTextReader.GetAttribute("id"), 16);
                  short script_ = xmlTextReader.GetAttribute("script") == null ? (short) 0 : Convert.ToInt16(xmlTextReader.GetAttribute("script"), 16);
                  int pointer2_ = xmlTextReader.GetAttribute("pointer2") == null ? 0 : Convert.ToInt32(xmlTextReader.GetAttribute("pointer2"), 16);
                  string modelfile_ = xmlTextReader.GetAttribute("modelfile") == null ? "" : xmlTextReader.GetAttribute("modelfile");
                  string modelfile2_ = xmlTextReader.GetAttribute("modelfile2") == null ? "" : xmlTextReader.GetAttribute("modelfile2");
                  short cameraid_ = xmlTextReader.GetAttribute("cameraID") == null ? (short) -1 : Convert.ToInt16(xmlTextReader.GetAttribute("cameraID"), 16);
                  short jiggyid_ = xmlTextReader.GetAttribute("jiggyID") == null ? (short) -1 : Convert.ToInt16(xmlTextReader.GetAttribute("jiggyID"), 16);
                  this.models.Add(new ObjectData(name_, objectID_, script_, pointer_, pointer2_, modelfile_, modelfile2_, (int) cameraid_, (int) jiggyid_));
                  continue;
                }
                continue;
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      this.models.Add(new ObjectData("Banjo-Kazooie", (short) 0, (short) 0, 30976, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Banjo Crocodile", (short) 0, (short) 0, 31288, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Banjo Walrus", (short) 0, (short) 0, 31072, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Banjo Bee", (short) 0, (short) 0, 31144, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Banjo Pumpkin", (short) 0, (short) 0, 31248, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Banjo Termite", (short) 0, (short) 0, 30992, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Mumbo's Mountain", (short) 0, (short) 0, 40064, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Mumbo's Mountain Clouds", (short) 0, (short) 0, 40072, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Treasure Trove Cove", (short) 0, (short) 0, 40080, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Treasure Trove Cove Clouds", (short) 0, (short) 0, 40088, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Gobi's Valley", (short) 0, (short) 0, 40096, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Mad Monster Mansion", (short) 0, (short) 0, 40104, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Mad Monster Mansion Fog", (short) 0, (short) 0, 40112, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Spiral Mountain", (short) 0, (short) 0, 40120, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Rusty Bucket Bay", (short) 0, (short) 0, 40128, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Freezeezy Peak", (short) 0, (short) 0, 40136, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Freezeezy Peak Clouds", (short) 0, (short) 0, 40144, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Freezeezy Peak More Clouds", (short) 0, (short) 0, 40152, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Intro", (short) 0, (short) 0, 40160, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Grunty's Lair MMM Entrance", (short) 0, (short) 0, 40168, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Grunty's Lair MMM Entrance Clouds", (short) 0, (short) 0, 40176, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Witch Falling Towards Ground", (short) 0, (short) 0, 40184, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Skybox Beach Ending", (short) 0, (short) 0, 40192, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Scene Transition - Jiggy", (short) 0, (short) 0, 40216, 0, "", "", 0, 0));
      this.models.Add(new ObjectData("Scene Transition - Witch", (short) 0, (short) 0, 40248, 0, "", "", 0, 0));
    }

    private void readAnimationsXML() => this.animations = BBXML.readAnimationsXML(true);

    private void camera()
    {
      bool flag = false;
      if (this.zoomIn | this.zoomOut | this.left | this.right)
      {
        this.BBCamera.PanUpdate(this.zoomIn, this.zoomOut, this.left, this.right);
        flag = true;
      }
      Point mousePosition1 = Control.MousePosition;
      this.newx = mousePosition1.X;
      mousePosition1 = Control.MousePosition;
      this.newy = mousePosition1.Y;
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
        this.BBCamera.MouseUpdate(this.newx - this.oldx, this.newy - this.oldy);
      }
      Point mousePosition2 = Control.MousePosition;
      this.oldx = mousePosition2.X;
      mousePosition2 = Control.MousePosition;
      this.oldy = mousePosition2.Y;
      if (!flag)
        return;
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      GL.LoadMatrix(this.BBCamera.GetWorldToViewMatrix());
      GL.EnableClientState(EnableCap.VertexArray);
      GL.EnableClientState(EnableCap.ColorArray);
      GL.EnableClientState(EnableCap.TextureCoordArray);
      if (this.animation != null)
      {
        int index = this.frame_trackBar.Value - this.frame_trackBar.Minimum;
        if (this.usingARB)
        {
          GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, this.vboVertexHandle);
          GL.Arb.BufferData<float>(BufferTargetArb.ArrayBuffer, (IntPtr) (this.vertexFrames[index].Length * 4), this.vertexFrames[index], BufferUsageArb.StaticDraw);
          GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, 0);
        }
        else
        {
          GL.BindBuffer(BufferTarget.ArrayBuffer, this.vboVertexHandle);
          GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr) (this.vertexFrames[index].Length * 4), this.vertexFrames[index], BufferUsageHint.StaticDraw);
          GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
      }
      else if (this.usingARB)
      {
        GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, this.vboVertexHandle);
        GL.Arb.BufferData<float>(BufferTargetArb.ArrayBuffer, (IntPtr) (this.vertexData.Length * 4), this.vertexData, BufferUsageArb.StaticDraw);
        GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, 0);
      }
      else
      {
        GL.BindBuffer(BufferTarget.ArrayBuffer, this.vboVertexHandle);
        GL.BufferData<float>(BufferTarget.ArrayBuffer, (IntPtr) (this.vertexData.Length * 4), this.vertexData, BufferUsageHint.StaticDraw);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
      }
      if (this.usingARB)
      {
        GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, this.vboVertexHandle);
        GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero);
        GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, this.vboColorHandle);
        GL.ColorPointer(4, ColorPointerType.Float, 0, IntPtr.Zero);
        GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, this.vboTexCoordHandle);
        GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, IntPtr.Zero);
      }
      else
      {
        GL.BindBuffer(BufferTarget.ArrayBuffer, this.vboVertexHandle);
        GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero);
        GL.BindBuffer(BufferTarget.ArrayBuffer, this.vboColorHandle);
        GL.ColorPointer(4, ColorPointerType.Float, 0, IntPtr.Zero);
        GL.BindBuffer(BufferTarget.ArrayBuffer, this.vboTexCoordHandle);
        GL.TexCoordPointer(2, TexCoordPointerType.Float, 0, IntPtr.Zero);
      }
      for (int index = 0; index < this.iboHandles.Count; ++index)
      {
        if (this.textures[index] == -1)
        {
          GL.Disable(EnableCap.Texture2D);
        }
        else
        {
          GL.Enable(EnableCap.Texture2D);
          GL.BindTexture(TextureTarget.Texture2D, this.textures[index]);
        }
        if (this.usingARB)
          GL.Arb.BindBuffer(BufferTargetArb.ElementArrayBuffer, this.iboHandles[index]);
        else
          GL.BindBuffer(BufferTarget.ElementArrayBuffer, this.iboHandles[index]);
        GL.DrawElements(PrimitiveType.Triangles, ((IEnumerable<ushort>) this.iboData[index]).Count<ushort>(), DrawElementsType.UnsignedShort, IntPtr.Zero);
      }
      if (this.usingARB)
      {
        GL.Arb.BindBuffer(BufferTargetArb.ArrayBuffer, 0);
        GL.Arb.BindBuffer(BufferTargetArb.ElementArrayBuffer, 0);
      }
      else
      {
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
      }
      GL.DisableClientState(EnableCap.VertexArray);
      GL.DisableClientState(EnableCap.ColorArray);
      GL.DisableClientState(EnableCap.TextureCoordArray);
      GL.PopMatrix();
      this.core.SetView(this.BKOpenGLC.Height, this.BKOpenGLC.Width);
      this.BKOpenGLC.SwapBuffers();
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

    private void decompressFile(int pntr)
    {
      if (File.Exists(this.tmpDir + pntr.ToString("x")))
        return;
      try
      {
        int num1 = (int) this.rom[pntr] * 16777216 + (int) this.rom[pntr + 1] * 65536 + (int) this.rom[pntr + 2] * 256 + (int) this.rom[pntr + 3];
        int compressedSize = this.getNextPointer(pntr) - num1;
        int num2 = num1 + 68816;
        byte[] numArray = new byte[compressedSize];
        for (int index = 0; index < compressedSize; ++index)
          numArray[index] = this.rom[num2 + index];
        GECompression geCompression = new GECompression();
        byte[] Buffer = numArray;
        geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
        int fileSize = 0;
        byte[] buffer = geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
        FileStream output = File.Create(this.tmpDir + pntr.ToString("x"));
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        try
        {
          binaryWriter.Write(buffer, 0, fileSize);
          binaryWriter.Close();
          output.Close();
        }
        catch
        {
          binaryWriter.Close();
          output.Close();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      this.camera();
      this.BKOpenGLC.Invalidate();
    }

    private void ModelViewer_SizeChanged(object sender, EventArgs e)
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

    private void ModelViewer_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
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

    private void BKOpenGLC_MouseDown(object sender, MouseEventArgs e)
    {
      this.Focus();
      this.forceRedraw = true;
      this.sceneClick = true;
      if (e.Button == MouseButtons.Left)
        this.RotateSceneClick = true;
      int button = (int) e.Button;
    }

    private void BKOpenGLC_MouseMove(object sender, MouseEventArgs e)
    {
    }

    private void BKOpenGLC_MouseUp(object sender, MouseEventArgs e)
    {
      this.sceneClick = false;
      if (e.Button != MouseButtons.Left)
        return;
      this.RotateSceneClick = false;
    }

    private void BKOpenGLC_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
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

    private void showBones_btn_Click(object sender, EventArgs e)
    {
      this.drawSkeleton = !this.drawSkeleton;
      this.forceRedraw = true;
    }

    private void BKOpenGLC_Paint(object sender, PaintEventArgs e)
    {
    }

    private void PrepareModel(int pntr_)
    {
      try
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(this.tmpDir + pntr_.ToString("x"), FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        this.bytesInFile = new byte[length];
        binaryReader.BaseStream.Read(this.bytesInFile, 0, (int) length);
        binaryReader.Close();
        this.RipSkeleton(ref this.bytesInFile);
        if (this.skeleton.Count <= 0)
          return;
        if (((int) this.bytesInFile[40] << 24) + ((int) this.bytesInFile[41] << 16) + ((int) this.bytesInFile[42] << 8) + (int) this.bytesInFile[43] == 0)
        {
          this.isDLAnimation = true;
        }
        else
        {
          this.ripVertBoneAssignments(ref this.bytesInFile);
          this.isDLAnimation = false;
        }
      }
      catch
      {
      }
    }

    private void RipSkeleton(ref byte[] bytesInFile)
    {
      this.skeleton = new List<Bone>();
      try
      {
        int index1 = ((int) bytesInFile[24] << 24) + ((int) bytesInFile[25] << 16) + ((int) bytesInFile[26] << 8) + (int) bytesInFile[27];
        if (index1 == 0)
          return;
        this.translationFactor = BitConverter.ToSingle(new byte[4]
        {
          bytesInFile[index1 + 3],
          bytesInFile[index1 + 2],
          bytesInFile[index1 + 1],
          bytesInFile[index1]
        }, 0);
        int num1 = ((int) bytesInFile[index1 + 4] << 16) + (int) bytesInFile[index1 + 5];
        int num2 = index1 + 8;
        short id_ = 0;
        while (num2 < bytesInFile.Length && this.skeleton.Count < num1)
        {
          int index2 = num2;
          float single1 = BitConverter.ToSingle(new byte[4]
          {
            bytesInFile[index2 + 3],
            bytesInFile[index2 + 2],
            bytesInFile[index2 + 1],
            bytesInFile[index2]
          }, 0);
          int index3 = index2 + 4;
          float single2 = BitConverter.ToSingle(new byte[4]
          {
            bytesInFile[index3 + 3],
            bytesInFile[index3 + 2],
            bytesInFile[index3 + 1],
            bytesInFile[index3]
          }, 0);
          int index4 = index3 + 4;
          float single3 = BitConverter.ToSingle(new byte[4]
          {
            bytesInFile[index4 + 3],
            bytesInFile[index4 + 2],
            bytesInFile[index4 + 1],
            bytesInFile[index4]
          }, 0);
          int index5 = index4 + 4;
          short animationID_ = (short) (((int) bytesInFile[index5] << 8) + (int) bytesInFile[index5 + 1]);
          short parent_ = (short) (((int) bytesInFile[index5 + 2] << 8) + (int) bytesInFile[index5 + 3]);
          Bone bone = new Bone(id_, animationID_, parent_, single1, single2, single3);
          num2 += 16;
          this.skeleton.Add(bone);
          ++id_;
        }
      }
      catch
      {
      }
    }

    private void ripVertBoneAssignments(ref byte[] modelfile)
    {
      int num1 = ((int) modelfile[40] << 24) + ((int) modelfile[41] << 16) + ((int) modelfile[42] << 8) + (int) modelfile[43];
      int num2 = ((int) modelfile[24] << 24) + ((int) modelfile[25] << 16) + ((int) modelfile[26] << 8) + (int) modelfile[27];
      if (num1 != 0)
      {
        int index1 = num1 + 4;
        while (index1 < num2)
        {
          int index2 = index1 + 6;
          int index3 = (int) modelfile[index2];
          int index4 = index2 + 1;
          int length = (int) modelfile[index4];
          index1 = index4 + 1;
          int[] collection = new int[length];
          for (int index5 = 0; index5 < length; ++index5)
          {
            collection[index5] = ((int) modelfile[index1] << 8) + (int) modelfile[index1 + 1];
            index1 += 2;
          }
          this.skeleton[index3].verts.AddRange((IEnumerable<int>) collection);
        }
      }
      foreach (Bone bone in this.skeleton)
        bone.verts = bone.verts.Distinct<int>().ToList<int>();
    }

    private void RipDLAssignments(ref byte[] modelfile)
    {
      int num1 = ((int) modelfile[4] << 24) + ((int) modelfile[5] << 16) + ((int) modelfile[6] << 8) + (int) modelfile[7];
      int length = modelfile.Length;
      if (num1 == 0)
        return;
      int num2 = num1;
      while (num2 < length)
      {
        if (modelfile[num2 + 3] == (byte) 2)
        {
          int index1 = (int) modelfile[num2 + 9];
          num2 += 16;
          while (modelfile[num2 + 3] != (byte) 3 && num2 < length && modelfile[num2 + 3] == (byte) 2)
            num2 += 8;
          if (modelfile[num2 + 3] == (byte) 3)
          {
            int num3 = ((int) modelfile[num2 + 8] << 8) + (int) modelfile[num2 + 9];
            for (uint index2 = 0; (long) index2 < (long) this.dlOffsets.Count; ++index2)
            {
              if (this.dlOffsets[(int) index2] == num3)
              {
                this.skeleton[index1].dl = index2;
                break;
              }
            }
          }
        }
        else
          num2 += 8;
      }
    }

    private void loadReplacementModelToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.DisableAnimationView();
      if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        this.replacementModel = this.openFileDialog1.FileName;
        this.core.DeleteDL(this.CurrentModelDL);
        this.CurrentModelDL = this.core.GenerateDL();
        GL.PushMatrix();
        this.core.DrawModelFile(this.replacementModel, 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false);
        GL.PopMatrix();
        this.core.EndDL();
      }
      this.forceRedraw = true;
    }

    private void DisableAnimationView()
    {
      this.frame_trackBar.Enabled = false;
      this.animationPlayer_timer.Stop();
      this.play_btn.Enabled = false;
      this.stop_btn.Enabled = false;
      this.animation_dgv.Rows.Clear();
      this.animation = (BKAnimation) null;
    }

    private void EnableAnimationView()
    {
      this.frame_trackBar.Enabled = true;
      this.animationPlayer_timer.Stop();
      this.play_btn.Enabled = true;
      this.stop_btn.Enabled = true;
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.objects_dgv.SelectedRows.Count <= 0)
        return;
      if (!(this.replacementModel != ""))
        return;
      try
      {
        ObjectData model = this.models[(int) this.objects_dgv.SelectedRows[0].Cells[0].Value];
        if (!this.updatedModels.Contains(model.pointer))
          this.updatedModels.Add(model.pointer);
        if (File.Exists(this.replacementModel))
          File.Delete(this.outDir + model.pointer.ToString("x"));
        File.Copy(this.replacementModel, this.outDir + model.pointer.ToString("x"));
      }
      catch
      {
      }
    }

    private void CamSpeed_tb_Scroll(object sender, EventArgs e) => this.BBCamera.MovementSpeed = (float) (this.CamSpeed_tb.Value * 2);

    private void boneWidth_slider_Scroll(object sender, EventArgs e)
    {
      if (this.o == null || this.objects_dgv.SelectedRows.Count <= 0 || !File.Exists(this.tmpDir + this.o.pointer.ToString("x")))
        return;
      this.forceRedraw = true;
    }

    private void objects_dgv_SelectionChanged(object sender, EventArgs e)
    {
      this.core.DeleteBuffer(this.vboVertexHandle);
      this.core.DeleteBuffer(this.vboColorHandle);
      this.core.DeleteBuffer(this.vboTexCoordHandle);
      this.core.DeleteBuffers(this.iboHandles);
      this.core.DeleteTextures(this.textures);
      this.iboData.Clear();
      this.iboHandles.Clear();
      this.textures.Clear();
      this.fileInfo_lbl.Text = "";
      this.animationPlayer_timer.Stop();
      if (this.objects_dgv.SelectedRows.Count <= 0)
        return;
      this.levels_dgv.ClearSelection();
      this.levelPointer = 0;
      this.loadReplacementModelToolStripMenuItem.Enabled = true;
      this.saveToolStripMenuItem.Enabled = true;
      this.replacementModel = "";
      this.o = this.models[(int) this.objects_dgv.SelectedRows[0].Cells[0].Value];
      try
      {
        this.decompressFile(this.o.pointer);
      }
      catch (Exception ex)
      {
      }
      if (!File.Exists(this.tmpDir + this.o.pointer.ToString("x")))
        return;
      this.fileInfo_lbl.Text = "File Info: " + this.o.pointer.ToString("x");
      this.DisableAnimationView();
      this.EnableAnimationView();
      this.PrepareModel(this.o.pointer);
      this.core.GetBuffersFromBKModelFile(ref this.bytesInFile, ref this.vboVertexHandle, ref this.vertexData, ref this.vboColorHandle, ref this.vboTexCoordHandle, ref this.iboHandles, ref this.iboData, ref this.textures);
      this.DisplayAnimationFiles(this.o.pointer);
      this.forceRedraw = true;
    }

    private void levels_dgv_SelectionChanged(object sender, EventArgs e)
    {
      this.core.DeleteBuffer(this.vboVertexHandle);
      this.core.DeleteBuffer(this.vboColorHandle);
      this.core.DeleteBuffer(this.vboTexCoordHandle);
      this.core.DeleteBuffers(this.iboHandles);
      this.core.DeleteTextures(this.textures);
      this.iboData.Clear();
      this.iboHandles.Clear();
      this.textures.Clear();
      this.fileInfo_lbl.Text = "";
      this.animationPlayer_timer.Stop();
      this.DisableAnimationView();
      if (this.levels_dgv.SelectedRows.Count <= 0)
        return;
      this.objects_dgv.ClearSelection();
      this.o = (ObjectData) null;
      this.loadReplacementModelToolStripMenuItem.Enabled = false;
      this.saveToolStripMenuItem.Enabled = false;
      this.replacementModel = "";
      SetupFile level = this.levels[(int) this.levels_dgv.SelectedRows[0].Cells[0].Value];
      this.levelPointer = ((string) this.levels_dgv.SelectedRows[0].Cells[1].Value).EndsWith(" B") ? level.modelBPointer : level.modelAPointer;
      try
      {
        this.decompressFile(this.levelPointer);
      }
      catch (Exception ex)
      {
      }
      if (!File.Exists(this.tmpDir + this.levelPointer.ToString("x")))
        return;
      this.fileInfo_lbl.Text = "File Info: " + this.levelPointer.ToString("x");
      this.PrepareModel(this.levelPointer);
      this.core.GetBuffersFromBKModelFile(ref this.bytesInFile, ref this.vboVertexHandle, ref this.vertexData, ref this.vboColorHandle, ref this.vboTexCoordHandle, ref this.iboHandles, ref this.iboData, ref this.textures);
      this.forceRedraw = true;
    }

    private void animation_dgv_SelectionChanged(object sender, EventArgs e)
    {
    }

    private void ShowAnimationProgressBar(Progress progressBar)
    {
      progressBar.ProgressValue = 0;
      progressBar.StartPosition = FormStartPosition.CenterParent;
      int num = (int) progressBar.ShowDialog();
    }

    private void RenderFrame(int frameNumber)
    {
      if (this.animation_dgv.SelectedRows.Count <= 0)
        return;
      foreach (Bone bone in this.skeleton)
        bone.ClearTranformations();
      if (this.animation == null || frameNumber == -1)
        return;
      for (int index = 0; index < this.skeleton.Count; ++index)
      {
        int num1 = 0;
        foreach (BKAnimationSection section in this.animation.sections)
        {
          ++num1;
          if ((int) section.boneDL == (int) this.skeleton[index].animationID)
          {
            int boneDl1 = (int) section.boneDL;
            int boneDl2 = (int) section.boneDL;
            int num2 = -1;
            int num3 = int.MaxValue;
            float num4 = 0.0f;
            int num5 = -1;
            int num6 = int.MaxValue;
            float num7 = 0.0f;
            int num8 = -1;
            int num9 = int.MaxValue;
            float num10 = 0.0f;
            int num11 = -1;
            int num12 = int.MaxValue;
            float num13 = 0.0f;
            int num14 = -1;
            int num15 = int.MaxValue;
            float num16 = 0.0f;
            int num17 = -1;
            int num18 = int.MaxValue;
            float num19 = 0.0f;
            int num20 = -1;
            int num21 = int.MaxValue;
            float num22 = 0.0f;
            int num23 = -1;
            int num24 = int.MaxValue;
            float num25 = 0.0f;
            int num26 = -1;
            int num27 = int.MaxValue;
            float num28 = 0.0f;
            foreach (BKAnimationCommand command in section.commands)
            {
              switch (section.tranformationType)
              {
                case TransformationType.XRotation:
                  if ((int) command.frameNumber > num11 && (int) command.frameNumber <= frameNumber)
                  {
                    num11 = (int) command.frameNumber;
                    this.skeleton[index].frame_xRotation = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.XRot);
                    this.skeleton[index].transformOrder.Add(MTransform.XRot);
                  }
                  if ((int) command.frameNumber < num12 && (int) command.frameNumber > frameNumber)
                  {
                    num12 = (int) command.frameNumber;
                    num13 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.YRotation:
                  if ((int) command.frameNumber > num14 && (int) command.frameNumber <= frameNumber)
                  {
                    num14 = (int) command.frameNumber;
                    this.skeleton[index].frame_yRotation = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.YRot);
                    this.skeleton[index].transformOrder.Add(MTransform.YRot);
                  }
                  if ((int) command.frameNumber < num15 && (int) command.frameNumber > frameNumber)
                  {
                    num15 = (int) command.frameNumber;
                    num16 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.ZRotation:
                  if ((int) command.frameNumber > num17 && (int) command.frameNumber <= frameNumber)
                  {
                    num17 = (int) command.frameNumber;
                    this.skeleton[index].frame_zRotation = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.ZRot);
                    this.skeleton[index].transformOrder.Add(MTransform.ZRot);
                  }
                  if ((int) command.frameNumber < num18 && (int) command.frameNumber > frameNumber)
                  {
                    num18 = (int) command.frameNumber;
                    num19 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.XScale:
                  if ((int) command.frameNumber > num20 && (int) command.frameNumber <= frameNumber)
                  {
                    num20 = (int) command.frameNumber;
                    this.skeleton[index].frame_xScale = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.XScale);
                    this.skeleton[index].transformOrder.Add(MTransform.XScale);
                  }
                  if ((int) command.frameNumber < num21 && (int) command.frameNumber > frameNumber)
                  {
                    num21 = (int) command.frameNumber;
                    num22 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.YScale:
                  if ((int) command.frameNumber > num23 && (int) command.frameNumber <= frameNumber)
                  {
                    num23 = (int) command.frameNumber;
                    this.skeleton[index].frame_yScale = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.YScale);
                    this.skeleton[index].transformOrder.Add(MTransform.YScale);
                  }
                  if ((int) command.frameNumber < num24 && (int) command.frameNumber > frameNumber)
                  {
                    num24 = (int) command.frameNumber;
                    num25 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.ZScale:
                  if ((int) command.frameNumber > num26 && (int) command.frameNumber <= frameNumber)
                  {
                    num26 = (int) command.frameNumber;
                    this.skeleton[index].frame_zScale = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.ZScale);
                    this.skeleton[index].transformOrder.Add(MTransform.ZScale);
                  }
                  if ((int) command.frameNumber < num27 && (int) command.frameNumber > frameNumber)
                  {
                    num27 = (int) command.frameNumber;
                    num28 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.XTranslation:
                  if ((int) command.frameNumber > num2 && (int) command.frameNumber <= frameNumber)
                  {
                    num2 = (int) command.frameNumber;
                    this.skeleton[index].frame_xTranslation = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.XTrans);
                    this.skeleton[index].transformOrder.Add(MTransform.XTrans);
                  }
                  if ((int) command.frameNumber < num3 && (int) command.frameNumber > frameNumber)
                  {
                    num3 = (int) command.frameNumber;
                    num4 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.YTranslation:
                  if ((int) command.frameNumber > num5 && (int) command.frameNumber <= frameNumber)
                  {
                    num5 = (int) command.frameNumber;
                    this.skeleton[index].frame_yTranslation = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.YTrans);
                    this.skeleton[index].transformOrder.Add(MTransform.YTrans);
                  }
                  if ((int) command.frameNumber < num6 && (int) command.frameNumber > frameNumber)
                  {
                    num6 = (int) command.frameNumber;
                    num7 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                case TransformationType.ZTranslation:
                  if ((int) command.frameNumber > num8 && (int) command.frameNumber <= frameNumber)
                  {
                    num8 = (int) command.frameNumber;
                    this.skeleton[index].frame_zTranslation = (float) command.transformFactor / 64f;
                    this.skeleton[index].ClearTransformOrder(MTransform.ZTrans);
                    this.skeleton[index].transformOrder.Add(MTransform.ZTrans);
                  }
                  if ((int) command.frameNumber < num9 && (int) command.frameNumber > frameNumber)
                  {
                    num9 = (int) command.frameNumber;
                    num10 = (float) command.transformFactor / 64f;
                    continue;
                  }
                  continue;
                default:
                  continue;
              }
            }
            if (num3 != int.MaxValue && num2 != -1)
            {
              float num29 = (float) (num3 - num2);
              float num30 = (float) (frameNumber - num2) / num29;
              this.skeleton[index].frame_xTranslation += (num4 - this.skeleton[index].frame_xTranslation) * num30;
            }
            if (num6 != int.MaxValue && num5 != -1)
            {
              float num31 = (float) (num6 - num5);
              float num32 = (float) (frameNumber - num5) / num31;
              this.skeleton[index].frame_yTranslation += (num7 - this.skeleton[index].frame_yTranslation) * num32;
            }
            if (num9 != int.MaxValue && num8 != -1)
            {
              float num33 = (float) (num9 - num8);
              float num34 = (float) (frameNumber - num8) / num33;
              this.skeleton[index].frame_zTranslation += (num10 - this.skeleton[index].frame_zTranslation) * num34;
            }
            if (num12 != int.MaxValue && num11 != -1)
            {
              float num35 = (float) (num12 - num11);
              float num36 = (float) (frameNumber - num11) / num35;
              this.skeleton[index].frame_xRotation += (num13 - this.skeleton[index].frame_xRotation) * num36;
            }
            if (num15 != int.MaxValue && num14 != -1)
            {
              float num37 = (float) (num15 - num14);
              float num38 = (float) (frameNumber - num14) / num37;
              this.skeleton[index].frame_yRotation += (num16 - this.skeleton[index].frame_yRotation) * num38;
            }
            if (num18 != int.MaxValue && num17 != -1)
            {
              float num39 = (float) (num18 - num17);
              float num40 = (float) (frameNumber - num17) / num39;
              this.skeleton[index].frame_zRotation += (num19 - this.skeleton[index].frame_zRotation) * num40;
            }
            if (num21 != int.MaxValue && num20 != -1)
            {
              float num41 = (float) (num21 - num20);
              float num42 = (float) (frameNumber - num20) / num41;
              this.skeleton[index].frame_xScale += (num22 - this.skeleton[index].frame_xScale) * num42;
            }
            if (num24 != int.MaxValue && num23 != -1)
            {
              float num43 = (float) (num24 - num23);
              float num44 = (float) (frameNumber - num23) / num43;
              this.skeleton[index].frame_yScale += (num25 - this.skeleton[index].frame_yScale) * num44;
            }
            if (num27 != int.MaxValue && num26 != -1)
            {
              float num45 = (float) (num27 - num26);
              float num46 = (float) (frameNumber - num26) / num45;
              this.skeleton[index].frame_zScale += (num28 - this.skeleton[index].frame_zScale) * num46;
            }
          }
        }
      }
    }

    private void frame_cb_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void ModelViewer_Shown(object sender, EventArgs e)
    {
      this.objects_dgv.ClearSelection();
      this.levels_dgv.ClearSelection();
      this.core.DeleteDL(this.CurrentModelDL);
      this.o = (ObjectData) null;
      this.levelPointer = 0;
    }

    private void frameSlider_Scroll(object sender, EventArgs e)
    {
    }

    private void play_btn_Click(object sender, EventArgs e)
    {
      if (this.animation_dgv.SelectedRows.Count <= 0)
        return;
      this.animationPlayer_timer.Start();
    }

    private void animationPlayer_timer_Tick(object sender, EventArgs e)
    {
      if (this.frame_trackBar.Value != this.frame_trackBar.Maximum)
        ++this.frame_trackBar.Value;
      else
        this.frame_trackBar.Value = this.frame_trackBar.Minimum;
    }

    private void stop_btn_Click(object sender, EventArgs e) => this.animationPlayer_timer.Stop();

    private void frameSlider_ValueChanged(object sender, EventArgs e) => this.forceRedraw = true;

    private void bgw_animationParser_DoWork(object sender, DoWorkEventArgs e)
    {
    }

    private void animation_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      this.vertexFrames.Clear();
      if (this.animation_dgv.SelectedRows.Count <= 0)
        return;
      AnimationFile animation = this.animations[(int) this.animation_dgv.SelectedRows[0].Cells[0].Value];
      try
      {
        this.decompressFile(animation.pointer);
      }
      catch (Exception ex)
      {
      }
      if (!File.Exists(this.tmpDir + animation.pointer.ToString("x")))
        return;
      this.animation = new BKAnimation(File.ReadAllBytes(this.tmpDir + animation.pointer.ToString("x")));
      if ((int) this.animation.endFrame - (int) this.animation.startFrame <= 2000 && (int) this.animation.endFrame - (int) this.animation.startFrame > 0)
      {
        this.frame_spin.Maximum = (Decimal) this.animation.endFrame;
        this.frame_spin.Minimum = (Decimal) this.animation.startFrame;
        this.frame_spin.Value = (Decimal) this.animation.startFrame;
        this.frame_trackBar.Minimum = 0;
        this.frame_trackBar.Value = 0;
        this.frame_trackBar.Maximum = (int) this.animation.endFrame;
        this.frame_trackBar.Minimum = (int) this.animation.startFrame;
        this.frame_trackBar.Value = (int) this.animation.startFrame;
        try
        {
          this.forceRedraw = true;
          Progress progressBar = new Progress("Processing Animation Data");
          new Thread((ThreadStart) (() => this.ShowAnimationProgressBar(progressBar))).Start();
          for (int startFrame = (int) this.animation.startFrame; startFrame <= (int) this.animation.endFrame; ++startFrame)
          {
            this.RenderFrame(startFrame);
            Stopwatch stopwatch = Stopwatch.StartNew();
            if (this.o != null)
            {
              if (this.isDLAnimation)
                this.vertexFrames.Add(this.core.DrawDLAnimationFrameVBO(ref this.bytesInFile, this.skeleton, this.translationFactor, this.vertexData));
              else
                this.vertexFrames.Add(this.core.DrawVertAnimationFrameVBO(ref this.bytesInFile, this.skeleton, this.translationFactor, (float[]) this.vertexData.Clone()));
            }
            stopwatch.Stop();
            long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
            int newProgress = (int) ((double) startFrame / (double) ((int) this.animation.endFrame - (int) this.animation.startFrame + 1) * 100.0);
            if (!progressBar.Disposing && !progressBar.IsDisposed)
              progressBar.UpdateProgress(newProgress);
          }
          progressBar.CloseFrm();
        }
        catch (Exception ex)
        {
        }
      }
      else
      {
        int num = (int) MessageBox.Show("Could not load animation");
        this.animation = (BKAnimation) null;
      }
    }

    private void frame_trackBar_ValueChanged(object sender, EventArgs e)
    {
      this.forceRedraw = true;
      if (!((Decimal) this.frame_trackBar.Value >= this.frame_spin.Minimum) || !((Decimal) this.frame_trackBar.Value <= this.frame_spin.Maximum))
        return;
      this.frame_spin.Value = (Decimal) this.frame_trackBar.Value;
    }

    private void frameNo_lbl_Click(object sender, EventArgs e)
    {
    }

    private void frame_spin_ValueChanged(object sender, EventArgs e)
    {
      this.forceRedraw = true;
      if (!(this.frame_spin.Value >= (Decimal) this.frame_trackBar.Minimum) || !(this.frame_spin.Value <= (Decimal) this.frame_trackBar.Maximum))
        return;
      this.frame_trackBar.Value = (int) this.frame_spin.Value;
    }

    private void fps_tb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
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

    private void fps_tb_TextChanged(object sender, EventArgs e)
    {
      try
      {
        this.animationPlayer_timer.Interval = 1000 / Convert.ToInt32(this.fps_tb.Text);
      }
      catch
      {
      }
    }

    private void objects_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void exportToGeObjToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog.ShowDialog() != DialogResult.OK || this.levelPointer == 0 && this.o == null)
        return;
      string str = "";
      string mtl = "";
      string outDir = this.folderBrowserDialog.SelectedPath + "\\";
      int pntr_ = this.levelPointer == 0 ? this.o.pointer : this.levelPointer;
      this.core.TranslateToGEOBJ(this.tmpDir, outDir, pntr_, ref str, ref mtl);
      if (this.skeleton != null)
        str += GEOBJ.convertSkeleton(this.skeleton);
      StreamWriter streamWriter1 = new StreamWriter(outDir + pntr_.ToString("x") + ".obj");
      streamWriter1.WriteLine(str);
      streamWriter1.Close();
      StreamWriter streamWriter2 = new StreamWriter(outDir + pntr_.ToString("x") + ".mtl");
      streamWriter2.WriteLine(mtl);
      streamWriter2.Close();
      int num = (int) MessageBox.Show("Export Complete");
    }

    private void exportToColladadaeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog.ShowDialog() != DialogResult.OK || this.levelPointer == 0 && this.o == null)
        return;
      string outDir = this.folderBrowserDialog.SelectedPath + "\\";
      int pntr_ = this.levelPointer == 0 ? this.o.pointer : this.levelPointer;
      string filename = outDir + pntr_.ToString("x") + ".dae";
      this.core.TranslateToCollada(this.tmpDir, outDir, pntr_, this.skeleton, filename);
      int num = (int) MessageBox.Show("Export Complete");
    }

    private void BKOpenGLC_Load(object sender, EventArgs e)
    {
      this.loaded = true;
      this.BKOpenGLC.MakeCurrent();
      Core.InitGl();
      this.core.SetView(this.BKOpenGLC.Height, this.BKOpenGLC.Width);
      this.forceRedraw = true;
      this.lbl_glVersion.Text = "OpenGL Version: " + GL.GetString(StringName.Version) + "  using ARB: " + this.usingARB.ToString();
      this.camera();
      this.forceRedraw = true;
      this.BBCamera.MovementSpeed = (float) (this.CamSpeed_tb.Value * 2);
      this.timer1.Enabled = true;
    }

    private void ModelViewer_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.timer1.Enabled = false;
      this.core.DeleteBuffer(this.vboVertexHandle);
      this.core.DeleteBuffer(this.vboColorHandle);
      this.core.DeleteBuffer(this.vboTexCoordHandle);
      this.core.DeleteBuffers(this.iboHandles);
      this.core.DeleteTextures(this.textures);
      this.iboData.Clear();
      this.iboHandles.Clear();
      this.textures.Clear();
      this.fileInfo_lbl.Text = "";
      this.animationPlayer_timer.Stop();
      this.DisableAnimationView();
    }

    private void importColladadaeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.openFileDialog2.ShowDialog() != DialogResult.OK)
        return;
      int count = COLLADA.Load(this.openFileDialog2.FileName).Items.OfType<library_visual_scenes>().ToList<library_visual_scenes>().Count;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ModelViewer));
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.loadReplacementModelToolStripMenuItem = new ToolStripMenuItem();
      this.saveToolStripMenuItem = new ToolStripMenuItem();
      this.exportToGeObjToolStripMenuItem = new ToolStripMenuItem();
      this.exportToColladadaeToolStripMenuItem = new ToolStripMenuItem();
      this.importColladadaeToolStripMenuItem = new ToolStripMenuItem();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.openFileDialog1 = new OpenFileDialog();
      this.label4 = new Label();
      this.CamSpeed_tb = new TrackBar();
      this.folderBrowserDialog = new FolderBrowserDialog();
      this.objects_dgv = new DataGridView();
      this.levels_dgv = new DataGridView();
      this.animation_dgv = new DataGridView();
      this.animationPlayer_timer = new System.Windows.Forms.Timer(this.components);
      this.frameNo_lbl = new Label();
      this.panel1 = new Panel();
      this.panel2 = new Panel();
      this.fileInfo_lbl = new Label();
      this.label1 = new Label();
      this.fps_tb = new TextBox();
      this.frame_spin = new NumericUpDown();
      this.play_btn = new Button();
      this.stop_btn = new Button();
      this.frame_trackBar = new ColorTrackBar();
      this.lbl_glVersion = new Label();
      this.BKOpenGLC = new GLControl();
      this.openFileDialog2 = new OpenFileDialog();
      this.menuStrip1.SuspendLayout();
      this.CamSpeed_tb.BeginInit();
      ((ISupportInitialize) this.objects_dgv).BeginInit();
      ((ISupportInitialize) this.levels_dgv).BeginInit();
      ((ISupportInitialize) this.animation_dgv).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.frame_spin.BeginInit();
      this.SuspendLayout();
      this.menuStrip1.BackColor = SystemColors.ActiveCaption;
      this.menuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.fileToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(1180, 24);
      this.menuStrip1.TabIndex = 11;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.loadReplacementModelToolStripMenuItem,
        (ToolStripItem) this.saveToolStripMenuItem,
        (ToolStripItem) this.exportToGeObjToolStripMenuItem,
        (ToolStripItem) this.exportToColladadaeToolStripMenuItem,
        (ToolStripItem) this.importColladadaeToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.loadReplacementModelToolStripMenuItem.Name = "loadReplacementModelToolStripMenuItem";
      this.loadReplacementModelToolStripMenuItem.Size = new Size(209, 22);
      this.loadReplacementModelToolStripMenuItem.Text = "Load Replacement Model";
      this.loadReplacementModelToolStripMenuItem.Click += new EventHandler(this.loadReplacementModelToolStripMenuItem_Click);
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new Size(209, 22);
      this.saveToolStripMenuItem.Text = "Save to Rom";
      this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
      this.exportToGeObjToolStripMenuItem.Name = "exportToGeObjToolStripMenuItem";
      this.exportToGeObjToolStripMenuItem.Size = new Size(209, 22);
      this.exportToGeObjToolStripMenuItem.Text = "Export to geObj";
      this.exportToGeObjToolStripMenuItem.Click += new EventHandler(this.exportToGeObjToolStripMenuItem_Click);
      this.exportToColladadaeToolStripMenuItem.Name = "exportToColladadaeToolStripMenuItem";
      this.exportToColladadaeToolStripMenuItem.Size = new Size(209, 22);
      this.exportToColladadaeToolStripMenuItem.Text = "Export to Collada (.dae)";
      this.exportToColladadaeToolStripMenuItem.Visible = false;
      this.exportToColladadaeToolStripMenuItem.Click += new EventHandler(this.exportToColladadaeToolStripMenuItem_Click);
      this.importColladadaeToolStripMenuItem.Name = "importColladadaeToolStripMenuItem";
      this.importColladadaeToolStripMenuItem.Size = new Size(209, 22);
      this.importColladadaeToolStripMenuItem.Text = "Import Collada (.dae)";
      this.importColladadaeToolStripMenuItem.Visible = false;
      this.importColladadaeToolStripMenuItem.Click += new EventHandler(this.importColladadaeToolStripMenuItem_Click);
      this.timer1.Interval = 25;
      this.timer1.Tick += new EventHandler(this.timer1_Tick);
      this.openFileDialog1.Filter = "BK Model File|*.bin";
      this.label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label4.AutoSize = true;
      this.label4.BackColor = SystemColors.ActiveCaption;
      this.label4.Location = new Point(945, 6);
      this.label4.Name = "label4";
      this.label4.Size = new Size(77, 13);
      this.label4.TabIndex = 61;
      this.label4.Text = "Camera Speed";
      this.CamSpeed_tb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.CamSpeed_tb.AutoSize = false;
      this.CamSpeed_tb.BackColor = SystemColors.ActiveCaption;
      this.CamSpeed_tb.Cursor = Cursors.Hand;
      this.CamSpeed_tb.Location = new Point(1030, 2);
      this.CamSpeed_tb.Maximum = 100;
      this.CamSpeed_tb.Minimum = 5;
      this.CamSpeed_tb.Name = "CamSpeed_tb";
      this.CamSpeed_tb.Size = new Size(150, 19);
      this.CamSpeed_tb.TabIndex = 60;
      this.CamSpeed_tb.TickFrequency = 5;
      this.CamSpeed_tb.Value = 30;
      this.CamSpeed_tb.Scroll += new EventHandler(this.CamSpeed_tb_Scroll);
      this.objects_dgv.AllowUserToAddRows = false;
      this.objects_dgv.AllowUserToDeleteRows = false;
      this.objects_dgv.AllowUserToResizeColumns = false;
      this.objects_dgv.AllowUserToResizeRows = false;
      this.objects_dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.objects_dgv.BackgroundColor = Color.White;
      this.objects_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.objects_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.objects_dgv.Location = new Point(12, 27);
      this.objects_dgv.Name = "objects_dgv";
      this.objects_dgv.ReadOnly = true;
      this.objects_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.objects_dgv.Size = new Size(178, 308);
      this.objects_dgv.TabIndex = 67;
      this.objects_dgv.CellContentClick += new DataGridViewCellEventHandler(this.objects_dgv_CellContentClick);
      this.objects_dgv.SelectionChanged += new EventHandler(this.objects_dgv_SelectionChanged);
      this.levels_dgv.AllowUserToAddRows = false;
      this.levels_dgv.AllowUserToDeleteRows = false;
      this.levels_dgv.AllowUserToResizeColumns = false;
      this.levels_dgv.AllowUserToResizeRows = false;
      this.levels_dgv.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.levels_dgv.BackgroundColor = Color.White;
      this.levels_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.levels_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.levels_dgv.Location = new Point(12, 341);
      this.levels_dgv.Name = "levels_dgv";
      this.levels_dgv.ReadOnly = true;
      this.levels_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.levels_dgv.Size = new Size(178, 180);
      this.levels_dgv.TabIndex = 68;
      this.levels_dgv.SelectionChanged += new EventHandler(this.levels_dgv_SelectionChanged);
      this.animation_dgv.AllowUserToAddRows = false;
      this.animation_dgv.AllowUserToDeleteRows = false;
      this.animation_dgv.AllowUserToResizeColumns = false;
      this.animation_dgv.AllowUserToResizeRows = false;
      this.animation_dgv.BackgroundColor = Color.FromArgb(114, 114, 114);
      this.animation_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.animation_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.animation_dgv.Location = new Point(3, 7);
      this.animation_dgv.Name = "animation_dgv";
      this.animation_dgv.ReadOnly = true;
      this.animation_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.animation_dgv.Size = new Size(178, 107);
      this.animation_dgv.TabIndex = 69;
      this.animation_dgv.CellClick += new DataGridViewCellEventHandler(this.animation_dgv_CellClick);
      this.animation_dgv.SelectionChanged += new EventHandler(this.animation_dgv_SelectionChanged);
      this.animationPlayer_timer.Interval = 16;
      this.animationPlayer_timer.Tick += new EventHandler(this.animationPlayer_timer_Tick);
      this.frameNo_lbl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.frameNo_lbl.AutoSize = true;
      this.frameNo_lbl.Location = new Point(3, 11);
      this.frameNo_lbl.Name = "frameNo_lbl";
      this.frameNo_lbl.Size = new Size(39, 13);
      this.frameNo_lbl.TabIndex = 76;
      this.frameNo_lbl.Text = "frame: ";
      this.frameNo_lbl.Click += new EventHandler(this.frameNo_lbl_Click);
      this.panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel1.BackColor = Color.FromArgb(68, 68, 68);
      this.panel1.Controls.Add((Control) this.panel2);
      this.panel1.Controls.Add((Control) this.frame_trackBar);
      this.panel1.Controls.Add((Control) this.animation_dgv);
      this.panel1.Location = new Point(196, 401);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(972, 120);
      this.panel1.TabIndex = 77;
      this.panel2.BackColor = Color.FromArgb(142, 142, 142);
      this.panel2.Controls.Add((Control) this.fileInfo_lbl);
      this.panel2.Controls.Add((Control) this.label1);
      this.panel2.Controls.Add((Control) this.fps_tb);
      this.panel2.Controls.Add((Control) this.frameNo_lbl);
      this.panel2.Controls.Add((Control) this.frame_spin);
      this.panel2.Controls.Add((Control) this.play_btn);
      this.panel2.Controls.Add((Control) this.stop_btn);
      this.panel2.Location = new Point(187, 85);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(781, 29);
      this.panel2.TabIndex = 79;
      this.fileInfo_lbl.AutoSize = true;
      this.fileInfo_lbl.Location = new Point(190, 8);
      this.fileInfo_lbl.Name = "fileInfo_lbl";
      this.fileInfo_lbl.Size = new Size(0, 13);
      this.fileInfo_lbl.TabIndex = 81;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(121, 11);
      this.label1.Name = "label1";
      this.label1.Size = new Size(27, 13);
      this.label1.TabIndex = 80;
      this.label1.Text = "FPS";
      this.fps_tb.BackColor = Color.FromArgb(114, 114, 114);
      this.fps_tb.ForeColor = SystemColors.Info;
      this.fps_tb.Location = new Point(154, 6);
      this.fps_tb.Name = "fps_tb";
      this.fps_tb.Size = new Size(30, 20);
      this.fps_tb.TabIndex = 79;
      this.fps_tb.Text = "60";
      this.fps_tb.TextChanged += new EventHandler(this.fps_tb_TextChanged);
      this.fps_tb.KeyPress += new KeyPressEventHandler(this.fps_tb_KeyPress);
      this.frame_spin.BackColor = Color.FromArgb(114, 114, 114);
      this.frame_spin.BorderStyle = BorderStyle.FixedSingle;
      this.frame_spin.ForeColor = SystemColors.Info;
      this.frame_spin.Location = new Point(48, 6);
      this.frame_spin.Name = "frame_spin";
      this.frame_spin.Size = new Size(51, 20);
      this.frame_spin.TabIndex = 78;
      this.frame_spin.ValueChanged += new EventHandler(this.frame_spin_ValueChanged);
      this.play_btn.Anchor = AnchorStyles.None;
      this.play_btn.BackColor = Color.Transparent;
      this.play_btn.BackgroundImageLayout = ImageLayout.None;
      this.play_btn.FlatAppearance.BorderColor = Color.Black;
      this.play_btn.FlatAppearance.BorderSize = 0;
      this.play_btn.FlatStyle = FlatStyle.Flat;
      this.play_btn.Image = (Image) Resources.play2;
      this.play_btn.Location = new Point(720, 2);
      this.play_btn.Name = "play_btn";
      this.play_btn.Size = new Size(22, 22);
      this.play_btn.TabIndex = 74;
      this.play_btn.UseVisualStyleBackColor = false;
      this.play_btn.Click += new EventHandler(this.play_btn_Click);
      this.stop_btn.Anchor = AnchorStyles.None;
      this.stop_btn.BackColor = Color.Transparent;
      this.stop_btn.FlatAppearance.BorderSize = 0;
      this.stop_btn.FlatStyle = FlatStyle.Flat;
      this.stop_btn.Image = (Image) componentResourceManager.GetObject("stop_btn.Image");
      this.stop_btn.Location = new Point(745, 2);
      this.stop_btn.Margin = new Padding(0);
      this.stop_btn.Name = "stop_btn";
      this.stop_btn.Size = new Size(22, 22);
      this.stop_btn.TabIndex = 75;
      this.stop_btn.UseVisualStyleBackColor = false;
      this.stop_btn.Click += new EventHandler(this.stop_btn_Click);
      this.frame_trackBar.BarBorderColor = Color.Black;
      this.frame_trackBar.BarColor = Color.FromArgb(114, 114, 114);
      this.frame_trackBar.Cursor = Cursors.Arrow;
      this.frame_trackBar.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.frame_trackBar.Location = new Point(187, 7);
      this.frame_trackBar.Maximum = 100;
      this.frame_trackBar.MaximumValueSide = Poles.Right;
      this.frame_trackBar.Minimum = 0;
      this.frame_trackBar.Name = "frame_trackBar";
      this.frame_trackBar.Size = new Size(781, 72);
      this.frame_trackBar.TabIndex = 77;
      this.frame_trackBar.TrackerBorderColor = Color.Black;
      this.frame_trackBar.TrackerColor = Color.Turquoise;
      this.frame_trackBar.TrackerSize = 4;
      this.frame_trackBar.Value = 0;
      this.frame_trackBar.ValueChanged += new ColorTrackBar.ValueChangedEventHandler(this.frame_trackBar_ValueChanged);
      this.lbl_glVersion.AutoSize = true;
      this.lbl_glVersion.BackColor = SystemColors.ActiveCaption;
      this.lbl_glVersion.ForeColor = Color.White;
      this.lbl_glVersion.Location = new Point(193, 6);
      this.lbl_glVersion.Name = "lbl_glVersion";
      this.lbl_glVersion.Size = new Size(91, 13);
      this.lbl_glVersion.TabIndex = 78;
      this.lbl_glVersion.Text = "OpenGL Version: ";
      this.BKOpenGLC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.BKOpenGLC.BackColor = Color.Black;
      this.BKOpenGLC.Location = new Point(199, 27);
      this.BKOpenGLC.Name = "BKOpenGLC";
      this.BKOpenGLC.Size = new Size(969, 368);
      this.BKOpenGLC.TabIndex = 79;
      this.BKOpenGLC.VSync = false;
      this.BKOpenGLC.Load += new EventHandler(this.BKOpenGLC_Load);
      this.BKOpenGLC.KeyDown += new KeyEventHandler(this.BKOpenGLC_KeyDown);
      this.BKOpenGLC.KeyUp += new KeyEventHandler(this.ModelViewer_KeyUp);
      this.BKOpenGLC.MouseDown += new MouseEventHandler(this.BKOpenGLC_MouseDown);
      this.BKOpenGLC.MouseMove += new MouseEventHandler(this.BKOpenGLC_MouseMove);
      this.BKOpenGLC.MouseUp += new MouseEventHandler(this.BKOpenGLC_MouseUp);
      this.openFileDialog2.FileName = "Model.dae";
      this.openFileDialog2.Filter = "Model File|*.dae";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1180, 522);
      this.Controls.Add((Control) this.BKOpenGLC);
      this.Controls.Add((Control) this.lbl_glVersion);
      this.Controls.Add((Control) this.panel1);
      this.Controls.Add((Control) this.levels_dgv);
      this.Controls.Add((Control) this.objects_dgv);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.CamSpeed_tb);
      this.Controls.Add((Control) this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (ModelViewer);
      this.ShowIcon = false;
      this.Text = "Model Viewer";
      this.FormClosing += new FormClosingEventHandler(this.ModelViewer_FormClosing);
      this.Load += new EventHandler(this.ModelViewer_Load);
      this.Shown += new EventHandler(this.ModelViewer_Shown);
      this.SizeChanged += new EventHandler(this.ModelViewer_SizeChanged);
      this.KeyUp += new KeyEventHandler(this.ModelViewer_KeyUp);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.CamSpeed_tb.EndInit();
      ((ISupportInitialize) this.objects_dgv).EndInit();
      ((ISupportInitialize) this.levels_dgv).EndInit();
      ((ISupportInitialize) this.animation_dgv).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.frame_spin.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
