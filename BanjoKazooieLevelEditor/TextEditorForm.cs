// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.TextEditorForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml.Serialization;

namespace BanjoKazooieLevelEditor
{
  public class TextEditorForm : Form
  {
    public bool updateROM;
    private CharacterHeadChangeForm chcf;
    private SearchForm searchForm = new SearchForm();
    private SearchCriteria searchCriteria = new SearchCriteria();
    private int selectedIndex;
    private int partIndex;
    private List<Sprite> sprites = new List<Sprite>();
    private List<Button> ups = new List<Button>();
    private List<Button> dwns = new List<Button>();
    private string path = Application.StartupPath;
    private string outpath = Application.StartupPath + "\\text\\out\\";
    private List<TextFile> files = new List<TextFile>();
    private List<TextFile> results = new List<TextFile>();
    private TextFile openFile;
    private string tmpDir = "";
    private BackgroundWorker worker;
    private Progress tpf = new Progress();
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem allToolStripMenuItem;
    private ToolStripMenuItem spiralMountainToolStripMenuItem;
    private ToolStripMenuItem gruntysLairToolStripMenuItem;
    private ToolStripMenuItem mumbosMountainToolStripMenuItem;
    private ToolStripMenuItem treasureTroveCoveToolStripMenuItem;
    private ToolStripMenuItem clankersCavernToolStripMenuItem;
    private ToolStripMenuItem bubblegloopSwampToolStripMenuItem;
    private ToolStripMenuItem freezeezyPeakToolStripMenuItem;
    private ToolStripMenuItem gobisValleyToolStripMenuItem;
    private ToolStripMenuItem madMonsterMansionToolStripMenuItem;
    private ToolStripMenuItem rustyBucketBayToolStripMenuItem;
    private ToolStripMenuItem clickClockWoodToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem quizToolStripMenuItem;
    private ToolStripMenuItem introToolStripMenuItem;
    private ToolStripMenuItem preEndingToolStripMenuItem;
    private ToolStripMenuItem endingToolStripMenuItem;
    private ToolStripMenuItem creditsToolStripMenuItem;
    private ToolStripMenuItem gameOverToolStripMenuItem;
    private ToolStripMenuItem mumbosMessagesToolStripMenuItem;
    private ToolStripMenuItem stopNSwopToolStripMenuItem;
    private ToolStripMenuItem unknownToolStripMenuItem;
    private FolderBrowserDialog folderPicker;
    private Label label2;
    private ListView fileFound_lv;
    private ToolStripMenuItem searchToolStripMenuItem;
    private Button save_btn;
    private Button addPartTop_btn;
    private Label label1;
    private ComboBox topbottom_cb;
    private Panel pnl_top;
    private Label file_lbl;
    private Panel pnl_bottom;
    private Label label3;
    private Label label4;
    private TableLayoutPanel tlp_top;
    private TableLayoutPanel tlp_bottom;
    private Button addPartBottom_btn;

    private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => this.tpf.Close();

    private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e) => this.tpf.ProgressValue = e.ProgressPercentage;

    private void worker_DoWork(object sender, DoWorkEventArgs e) => this.ripAllTextFiles();

    private Sprite GetSprite(int headID)
    {
      foreach (Sprite sprite in this.sprites)
      {
        if (sprite.id == headID)
          return sprite;
      }
      return new Sprite(headID, "", 0, true);
    }

    private Bitmap GetFrameOneFromSpriteID(int id)
    {
      foreach (Sprite sprite in this.sprites)
      {
        if (sprite.id == id)
        {
          int count = sprite.frames.Count;
          return sprite.frames[0];
        }
      }
      return new Bitmap(1, 1);
    }

    private void ripAllTextFiles()
    {
      byte[] rom = RomHandler.Rom;
      int num1 = 0;
      GECompression geCompression1 = new GECompression();
      for (int index1 = 44784; index1 < 65464; index1 += 8)
      {
        try
        {
          int num2 = (int) rom[index1] * 16777216 + (int) rom[index1 + 1] * 65536 + (int) rom[index1 + 2] * 256 + (int) rom[index1 + 3];
          int compressedSize = (int) rom[index1 + 8] * 16777216 + (int) rom[index1 + 1 + 8] * 65536 + (int) rom[index1 + 2 + 8] * 256 + (int) rom[index1 + 3 + 8] - num2;
          byte[] numArray1 = new byte[compressedSize];
          int num3 = num2 + 68816;
          string path = this.path + "\\text\\" + index1.ToString("x") + ".bin";
          if (compressedSize > 0)
          {
            for (int index2 = 0; index2 < compressedSize; ++index2)
              numArray1[index2] = rom[num3 + index2];
            GECompression geCompression2 = geCompression1;
            byte[] Buffer = numArray1;
            int length = Buffer.Length;
            geCompression2.SetCompressedBuffer(Buffer, length);
            int fileSize = 0;
            byte[] numArray2 = geCompression1.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
            FileStream output = File.Create(path);
            BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
            binaryWriter.Write(numArray2, 0, fileSize);
            binaryWriter.Close();
            output.Close();
            string level_ = "";
            int pointer_ = 44784 + num1 * 8;
            if (pointer_ >= 44784 && pointer_ <= 45032)
              level_ = "Treasure Trove Cove";
            else if (pointer_ >= 45584 && pointer_ <= 45784)
              level_ = "Gobi's Valley";
            else if (pointer_ >= 46384 && pointer_ <= 46504)
              level_ = "Mad Monster Mansion";
            else if (pointer_ >= 47184 && pointer_ <= 47392)
              level_ = "Mumbo's Mountain";
            else if (pointer_ >= 51184 && pointer_ <= 51296)
              level_ = "Clankers Cavern";
            else if (pointer_ >= 55632 && pointer_ <= 56472)
              level_ = "Grunty's Lair";
            else if (pointer_ >= 47984 && pointer_ <= 48048)
              level_ = "Rusty Bucket Bay";
            else if (pointer_ >= 48784 && pointer_ <= 49136)
              level_ = "Freezeezy Peak";
            else if (pointer_ >= 49584 && pointer_ <= 50008)
              level_ = "Bubblegloop Swamp";
            else if (pointer_ >= 50384 && pointer_ <= 51296)
              level_ = "Click Clock Wood";
            else if (pointer_ >= 51984 && pointer_ <= 52296)
              level_ = "General";
            else if (pointer_ >= 52784 && pointer_ <= 53392)
              level_ = "Spiral Mountain";
            else if (pointer_ >= 53592 && pointer_ <= 56472)
              level_ = "Cutscenes";
            else if (pointer_ >= 57232 && pointer_ <= 57496)
              level_ = "Furnace Fun";
            else if (pointer_ >= 58032 && pointer_ <= 59816)
              level_ = "Final Battle / Grunty Squares";
            else if (pointer_ >= 60432 && pointer_ <= 60648)
              level_ = "Credits";
            else if (pointer_ >= 61240 && pointer_ <= 65464)
              level_ = "Furnace Fun";
            bool topFirst = false;
            this.files.Add(new TextFile(this.ReadTextFile(numArray2, ref topFirst), level_, pointer_, topFirst));
          }
          ++num1;
        }
        catch (Exception ex)
        {
        }
        float num4 = 20680f;
        this.worker.ReportProgress((int) ((double) ((float) (index1 - 44784) / num4) * 100.0));
      }
    }

    public TextEditorForm(string tmpDir_)
    {
      try
      {
        this.InitializeComponent();
        this.tmpDir = tmpDir_;
        this.worker = new BackgroundWorker();
        if (Directory.GetFiles(this.path + "\\text\\").Length < 100 || !File.Exists(this.path + "\\text\\mwtext.xml"))
        {
          this.files = new List<TextFile>();
          this.worker.WorkerReportsProgress = true;
          this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
          this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
          this.worker.ProgressChanged += new ProgressChangedEventHandler(this.worker_ProgressChanged);
          this.worker.RunWorkerAsync();
          this.tpf.StartPosition = FormStartPosition.CenterParent;
          int num = (int) this.tpf.ShowDialog();
          this.createXMLFile();
          this.files.Clear();
        }
        this.sprites = BBXML.ReadSpriteXML();
        this.fileFound_lv.View = View.Details;
        this.readXMLFile();
        this.fileFound_lv.Columns.Add("Files", -2, HorizontalAlignment.Left);
        for (int index = 0; index < this.files.Count; ++index)
        {
          TextFile file = this.files[index];
          if (file.parts.Count > 0)
            this.fileFound_lv.Items.Add(new ListViewItem(this.convertHexString(file.parts[0].hex)));
          else
            this.fileFound_lv.Items.Add(new ListViewItem("BLANK"));
        }
        this.results = new List<TextFile>((IEnumerable<TextFile>) this.files);
        this.chcf = new CharacterHeadChangeForm(this.sprites);
      }
      catch
      {
        int num = (int) MessageBox.Show("Can't load files");
        this.Close();
      }
    }

    public void readXMLFile()
    {
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<TextFile>));
        TextReader textReader = (TextReader) new StreamReader(this.path + "\\text\\mwtext.xml");
        this.files = (List<TextFile>) xmlSerializer.Deserialize(textReader);
        textReader.Close();
        this.results = this.files;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Can't load files - for help visit banjosbackpack.com");
        this.Close();
      }
    }

    public string convertHexStringQuiz(byte[] hex)
    {
      string str = "";
      for (int index = 2; index < hex.Length; ++index)
      {
        if (hex[index] >= (byte) 32 && hex[index] <= (byte) 126)
        {
          char ch = (char) hex[index];
          str += ch.ToString();
        }
      }
      return str;
    }

    public string convertHexString(byte[] hex)
    {
      string str = "";
      for (int index = 0; index < hex.Length; ++index)
      {
        if (hex[index] >= (byte) 32 && hex[index] <= (byte) 126)
        {
          char ch = (char) hex[index];
          str += ch.ToString();
        }
      }
      return str;
    }

    public List<byte> convertStringHex(string text)
    {
      List<byte> byteList = new List<byte>();
      for (int index = 0; index < text.Length; ++index)
        byteList.Add((byte) text[index]);
      return byteList;
    }

    public List<byte> convertStringHexQuiz(string text)
    {
      List<byte> byteList = new List<byte>();
      byteList.Add((byte) 253);
      byteList.Add((byte) 108);
      for (int index = 0; index < text.Length; ++index)
        byteList.Add((byte) text[index]);
      return byteList;
    }

    private void fileFound_lv_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.fileFound_lv.SelectedIndices.Count <= 0)
        return;
      this.selectedIndex = this.fileFound_lv.SelectedIndices[0];
      this.openFile = this.results[this.selectedIndex];
      bool topFirst = false;
      this.openFile.parts = this.ReadTextFile(File.ReadAllBytes(this.path + "\\text\\" + this.openFile.pointer.ToString("x") + ".bin"), ref topFirst);
      this.file_lbl.Text = "File: 0x" + this.openFile.pointer.ToString("x");
      if (topFirst)
        this.topbottom_cb.Text = "Top";
      else
        this.topbottom_cb.Text = "Bottom";
      this.loadFile();
    }

    private void DecompressSprite(Sprite s)
    {
      if (s.name != "" && s.pointer != 0 && !File.Exists(this.tmpDir + (object) s.pointer))
        RomHandler.DecompressFileToHDD(s.pointer);
      if (s.frames.Count == 0)
      {
        if (s.id != 0)
        {
          try
          {
            byte[] file = File.ReadAllBytes(this.tmpDir + s.pointer.ToString("x"));
            s.frames.Add(ImageHandler.ConvertSpriteToImage(ref file));
          }
          catch (Exception ex)
          {
          }
        }
      }
      if (s.id != 0 || s.frames.Count != 0)
        return;
      s.frames.Add(new Bitmap(1, 1));
    }

    private void loadFile()
    {
      this.tlp_top.Controls.Clear();
      this.tlp_bottom.Controls.Clear();
      try
      {
        foreach (TextFilePart part in this.openFile.parts)
        {
          Sprite sprite = this.GetSprite(part.headID);
          this.DecompressSprite(sprite);
          DialogControl dialogControl = sprite.frames.Count <= 0 ? new DialogControl((byte) sprite.id, this.convertHexString(part.hex), part.group) : new DialogControl((Image) sprite.frames[0], (byte) sprite.id, this.convertHexString(part.hex), part.group);
          dialogControl.CharacterHeadClickEvent += new CharacterHeadClick(this.CharacterHeadUpdate);
          dialogControl.DeleteDialogEvent += new BanjoKazooieLevelEditor.DeleteDialog(this.DeleteDialog);
          dialogControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
          if (part.top)
            this.tlp_top.Controls.Add((Control) dialogControl);
          else
            this.tlp_bottom.Controls.Add((Control) dialogControl);
        }
        this.Refresh();
      }
      catch (Exception ex)
      {
      }
    }

    private void CharacterHeadUpdate(DialogControl dc)
    {
      int num = (int) this.chcf.ShowDialog();
      Sprite sprite = this.GetSprite(this.chcf.headID);
      if (sprite.frames.Count == 0)
        this.DecompressSprite(sprite);
      dc.SetImage((Image) sprite.frames[0], (byte) sprite.id);
    }

    private void DeleteDialog(DialogControl dc)
    {
      if (this.tlp_bottom.Controls.Contains((Control) dc))
        this.tlp_bottom.Controls.Remove((Control) dc);
      if (!this.tlp_top.Controls.Contains((Control) dc))
        return;
      this.tlp_top.Controls.Remove((Control) dc);
    }

    private void clearGUI(int selected)
    {
      this.tlp_top.Controls.Clear();
      this.tlp_bottom.Controls.Clear();
    }

    private void group_KeyPress(object sender, KeyPressEventArgs e)
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

    private void searchToolStripMenuItem_Click(object sender, EventArgs e)
    {
      int num = (int) this.searchForm.ShowDialog();
      this.searchCriteria = this.searchForm.searchCriteria;
      this.results.Clear();
      foreach (TextFile file in this.files)
      {
        bool flag1 = false;
        bool flag2 = false;
        if (file.level == "Credits" && this.searchCriteria.cut)
          flag2 = true;
        if (file.level == "Cutscenes" && this.searchCriteria.cut)
          flag2 = true;
        if (file.level == "Spiral Mountain" && this.searchCriteria.sm)
          flag2 = true;
        if (file.level == "Grunty's Lair" && this.searchCriteria.gl)
          flag2 = true;
        if (file.level == "Mumbo's Mountain" && this.searchCriteria.mm)
          flag2 = true;
        if (file.level == "Treasure Trove Cove" && this.searchCriteria.ttc)
          flag2 = true;
        if (file.level == "Clankers Cavern" && this.searchCriteria.cc)
          flag2 = true;
        if (file.level == "Gobi's Valley" && this.searchCriteria.gv)
          flag2 = true;
        if (file.level == "Furnace Fun" && this.searchCriteria.ff)
          flag2 = true;
        if (file.level == "Freezeezy Peak" && this.searchCriteria.fp)
          flag2 = true;
        if (file.level == "Mad Monster Mansion" && this.searchCriteria.mmm)
          flag2 = true;
        if (file.level == "Bubblegloop Swamp" && this.searchCriteria.bgs)
          flag2 = true;
        if (file.level == "Click Clock Wood" && this.searchCriteria.ccw)
          flag2 = true;
        if (file.level == "Rusty Bucket Bay" && this.searchCriteria.rbb)
          flag2 = true;
        if (file.level == "General" && this.searchCriteria.gen)
          flag2 = true;
        if (file.level == "Final Battle / Grunty Squares" && this.searchCriteria.fb)
          flag2 = true;
        if (flag2)
        {
          foreach (TextFilePart part in file.parts)
          {
            if (this.convertHexString(part.hex).Contains(this.searchCriteria.text.ToUpper()))
              flag1 = true;
          }
          if (flag1)
            this.results.Add(file);
        }
      }
      this.fileFound_lv.Clear();
      this.fileFound_lv.Columns.Add("Files", -2, HorizontalAlignment.Left);
      for (int index = 0; index < this.results.Count; ++index)
        this.fileFound_lv.Items.Add(new ListViewItem(this.convertHexString(this.results[index].parts[0].hex)));
      this.selectedIndex = 0;
      this.clearForm();
    }

    private void clearForm()
    {
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void saveToRomToolStripMenuItem_Click(object sender, EventArgs e) => this.save();

    private void save_btn_Click(object sender, EventArgs e) => this.save();

    private void save()
    {
      byte num1 = 0;
      try
      {
        TextFile result = this.results[this.selectedIndex];
        string str = this.outpath + result.pointer.ToString("x");
        FileStream output = File.Create(str);
        List<byte> byteList = new List<byte>();
        byteList.Add((byte) 1);
        byteList.Add((byte) 3);
        byteList.Add((byte) 0);
        bool flag1 = true;
        int num2;
        if (this.topbottom_cb.Text == "Top")
        {
          num2 = this.tlp_bottom.Controls.Count * 16 + 8 >> 3;
          flag1 = false;
        }
        else
          num2 = this.tlp_bottom.Controls.Count * 16 >> 3;
        byteList.Add((byte) num2);
        int count = this.openFile.parts.Count;
        foreach (DialogControl control in (ArrangedElementCollection) this.tlp_bottom.Controls)
        {
          if (!flag1)
          {
            byteList.Add((byte) 6);
            byteList.Add((byte) 1);
            byteList.Add((byte) 0);
            ++num1;
          }
          flag1 = false;
          byteList.Add(control.imageID);
          byteList.Add((byte) (control.GetText().Length + 1));
          byteList.AddRange((IEnumerable<byte>) this.convertStringHex(control.GetText()));
          byteList.Add((byte) 0);
        }
        byteList.Add((byte) 4);
        byteList.Add((byte) 1);
        byteList.Add((byte) 0);
        byte num3 = (byte) ((uint) num1 + 1U);
        bool flag2 = true;
        int num4;
        if (this.topbottom_cb.Text == "Bottom")
        {
          num4 = this.tlp_top.Controls.Count * 16 + 8 >> 3;
          flag2 = false;
        }
        else
          num4 = this.tlp_top.Controls.Count * 16 >> 3;
        byteList.Add((byte) num4);
        foreach (DialogControl control in (ArrangedElementCollection) this.tlp_top.Controls)
        {
          if (!flag2)
          {
            byteList.Add((byte) 6);
            byteList.Add((byte) 1);
            byteList.Add((byte) 0);
          }
          flag2 = false;
          byteList.Add(control.imageID);
          byteList.Add((byte) (control.GetText().Length + 1));
          byteList.AddRange((IEnumerable<byte>) this.convertStringHex(control.GetText()));
          byteList.Add((byte) 0);
          ++num3;
        }
        byteList.Add((byte) 4);
        byteList.Add((byte) 1);
        byteList.Add((byte) 0);
        byte num5 = (byte) ((uint) num3 + 1U);
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(byteList.ToArray());
        binaryWriter.Close();
        output.Close();
        File.Copy(str, this.path + "\\text\\" + result.pointer.ToString("x") + ".bin", true);
        this.createXMLFile();
        this.updateROM = true;
      }
      catch
      {
        int num6 = (int) MessageBox.Show("Could not save file");
      }
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

    private void addPartBottom_btn_Click(object sender, EventArgs e)
    {
      TextFilePart textFilePart = new TextFilePart(new byte[0], 0, false, false, true, this.tlp_bottom.Controls.Count);
      this.openFile.parts.Add(textFilePart);
      DialogControl dialogControl = new DialogControl((byte) 0, "", textFilePart.group);
      dialogControl.CharacterHeadClickEvent += new CharacterHeadClick(this.CharacterHeadUpdate);
      dialogControl.DeleteDialogEvent += new BanjoKazooieLevelEditor.DeleteDialog(this.DeleteDialog);
      dialogControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      if (textFilePart.top)
        this.tlp_top.Controls.Add((Control) dialogControl);
      else
        this.tlp_bottom.Controls.Add((Control) dialogControl);
    }

    private void addPart_btn_Click(object sender, EventArgs e)
    {
      TextFilePart textFilePart = new TextFilePart(new byte[0], 0, true, false, true, this.tlp_top.Controls.Count);
      this.openFile.parts.Add(textFilePart);
      DialogControl dialogControl = new DialogControl((byte) 0, "", textFilePart.group);
      dialogControl.CharacterHeadClickEvent += new CharacterHeadClick(this.CharacterHeadUpdate);
      dialogControl.DeleteDialogEvent += new BanjoKazooieLevelEditor.DeleteDialog(this.DeleteDialog);
      dialogControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      if (textFilePart.top)
        this.tlp_top.Controls.Add((Control) dialogControl);
      else
        this.tlp_bottom.Controls.Add((Control) dialogControl);
    }

    public List<TextFilePart> ReadTextFile(byte[] file, ref bool topFirst)
    {
      List<TextFilePart> textFilePartList = new List<TextFilePart>();
      if (file[0] == (byte) 1 && file[1] == (byte) 1 && file[2] == (byte) 2)
      {
        int num1 = (int) file[3];
      }
      if (file[0] == (byte) 1 && file[1] == (byte) 3 && file[2] == (byte) 0)
      {
        int num2 = (int) file[3];
        topFirst = false;
        int group_ = 0;
        if (file[4] == (byte) 6)
        {
          topFirst = true;
        }
        else
        {
          topFirst = false;
          group_ = 1;
        }
        bool top_ = false;
        int index1 = 4;
        while (index1 < file.Length)
        {
          if (file[index1] == (byte) 6 && file[index1 + 1] == (byte) 1 && file[index1 + 2] == (byte) 0)
          {
            ++group_;
            int index2 = index1 + 3;
            byte headID_ = file[index2];
            int index3 = index2 + 1;
            byte length = file[index3];
            index1 = index3 + 1;
            byte[] hex_ = new byte[(int) length];
            int num3 = index1 + (int) length;
            int index4 = 0;
            for (; index1 < num3; ++index1)
            {
              hex_[index4] = file[index1];
              ++index4;
            }
            TextFilePart textFilePart = new TextFilePart(hex_, (int) headID_, top_, false, true, group_);
            textFilePartList.Add(textFilePart);
          }
          else if (file[index1] == (byte) 4 && file[index1 + 1] == (byte) 1 && file[index1 + 2] == (byte) 0)
          {
            top_ = true;
            group_ = 0;
            index1 += 3;
          }
          else if (file[index1] > (byte) 127)
          {
            byte headID_ = file[index1];
            int index5 = index1 + 1;
            byte length = file[index5];
            index1 = index5 + 1;
            byte[] hex_ = new byte[(int) length];
            int num4 = index1 + (int) length;
            int index6 = 0;
            for (; index1 < num4; ++index1)
            {
              hex_[index6] = file[index1];
              ++index6;
            }
            TextFilePart textFilePart = new TextFilePart(hex_, (int) headID_, top_, false, false, group_);
            textFilePartList.Add(textFilePart);
          }
          else
            ++index1;
        }
      }
      return textFilePartList;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.menuStrip1 = new MenuStrip();
      this.searchToolStripMenuItem = new ToolStripMenuItem();
      this.viewToolStripMenuItem = new ToolStripMenuItem();
      this.allToolStripMenuItem = new ToolStripMenuItem();
      this.spiralMountainToolStripMenuItem = new ToolStripMenuItem();
      this.gruntysLairToolStripMenuItem = new ToolStripMenuItem();
      this.mumbosMountainToolStripMenuItem = new ToolStripMenuItem();
      this.treasureTroveCoveToolStripMenuItem = new ToolStripMenuItem();
      this.clankersCavernToolStripMenuItem = new ToolStripMenuItem();
      this.bubblegloopSwampToolStripMenuItem = new ToolStripMenuItem();
      this.freezeezyPeakToolStripMenuItem = new ToolStripMenuItem();
      this.gobisValleyToolStripMenuItem = new ToolStripMenuItem();
      this.madMonsterMansionToolStripMenuItem = new ToolStripMenuItem();
      this.rustyBucketBayToolStripMenuItem = new ToolStripMenuItem();
      this.clickClockWoodToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.quizToolStripMenuItem = new ToolStripMenuItem();
      this.introToolStripMenuItem = new ToolStripMenuItem();
      this.preEndingToolStripMenuItem = new ToolStripMenuItem();
      this.endingToolStripMenuItem = new ToolStripMenuItem();
      this.creditsToolStripMenuItem = new ToolStripMenuItem();
      this.gameOverToolStripMenuItem = new ToolStripMenuItem();
      this.mumbosMessagesToolStripMenuItem = new ToolStripMenuItem();
      this.stopNSwopToolStripMenuItem = new ToolStripMenuItem();
      this.unknownToolStripMenuItem = new ToolStripMenuItem();
      this.folderPicker = new FolderBrowserDialog();
      this.label2 = new Label();
      this.fileFound_lv = new ListView();
      this.save_btn = new Button();
      this.addPartTop_btn = new Button();
      this.label1 = new Label();
      this.topbottom_cb = new ComboBox();
      this.pnl_top = new Panel();
      this.tlp_top = new TableLayoutPanel();
      this.file_lbl = new Label();
      this.pnl_bottom = new Panel();
      this.tlp_bottom = new TableLayoutPanel();
      this.label3 = new Label();
      this.label4 = new Label();
      this.addPartBottom_btn = new Button();
      this.menuStrip1.SuspendLayout();
      this.pnl_top.SuspendLayout();
      this.pnl_bottom.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.searchToolStripMenuItem,
        (ToolStripItem) this.viewToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(1084, 24);
      this.menuStrip1.TabIndex = 1;
      this.menuStrip1.Text = "menuStrip1";
      this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
      this.searchToolStripMenuItem.Size = new Size(54, 20);
      this.searchToolStripMenuItem.Text = "Search";
      this.searchToolStripMenuItem.Click += new EventHandler(this.searchToolStripMenuItem_Click);
      this.viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[22]
      {
        (ToolStripItem) this.allToolStripMenuItem,
        (ToolStripItem) this.spiralMountainToolStripMenuItem,
        (ToolStripItem) this.gruntysLairToolStripMenuItem,
        (ToolStripItem) this.mumbosMountainToolStripMenuItem,
        (ToolStripItem) this.treasureTroveCoveToolStripMenuItem,
        (ToolStripItem) this.clankersCavernToolStripMenuItem,
        (ToolStripItem) this.bubblegloopSwampToolStripMenuItem,
        (ToolStripItem) this.freezeezyPeakToolStripMenuItem,
        (ToolStripItem) this.gobisValleyToolStripMenuItem,
        (ToolStripItem) this.madMonsterMansionToolStripMenuItem,
        (ToolStripItem) this.rustyBucketBayToolStripMenuItem,
        (ToolStripItem) this.clickClockWoodToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.quizToolStripMenuItem,
        (ToolStripItem) this.introToolStripMenuItem,
        (ToolStripItem) this.preEndingToolStripMenuItem,
        (ToolStripItem) this.endingToolStripMenuItem,
        (ToolStripItem) this.creditsToolStripMenuItem,
        (ToolStripItem) this.gameOverToolStripMenuItem,
        (ToolStripItem) this.mumbosMessagesToolStripMenuItem,
        (ToolStripItem) this.stopNSwopToolStripMenuItem,
        (ToolStripItem) this.unknownToolStripMenuItem
      });
      this.viewToolStripMenuItem.Enabled = false;
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new Size(44, 20);
      this.viewToolStripMenuItem.Text = "View";
      this.viewToolStripMenuItem.Visible = false;
      this.allToolStripMenuItem.Checked = true;
      this.allToolStripMenuItem.CheckState = CheckState.Checked;
      this.allToolStripMenuItem.Name = "allToolStripMenuItem";
      this.allToolStripMenuItem.Size = new Size(194, 22);
      this.allToolStripMenuItem.Text = "All";
      this.spiralMountainToolStripMenuItem.Name = "spiralMountainToolStripMenuItem";
      this.spiralMountainToolStripMenuItem.Size = new Size(194, 22);
      this.spiralMountainToolStripMenuItem.Text = "Spiral Mountain";
      this.gruntysLairToolStripMenuItem.Name = "gruntysLairToolStripMenuItem";
      this.gruntysLairToolStripMenuItem.Size = new Size(194, 22);
      this.gruntysLairToolStripMenuItem.Text = "Grunty's Lair";
      this.mumbosMountainToolStripMenuItem.Name = "mumbosMountainToolStripMenuItem";
      this.mumbosMountainToolStripMenuItem.Size = new Size(194, 22);
      this.mumbosMountainToolStripMenuItem.Text = "Mumbo's Mountain";
      this.treasureTroveCoveToolStripMenuItem.Name = "treasureTroveCoveToolStripMenuItem";
      this.treasureTroveCoveToolStripMenuItem.Size = new Size(194, 22);
      this.treasureTroveCoveToolStripMenuItem.Text = "Treasure Trove Cove";
      this.clankersCavernToolStripMenuItem.Name = "clankersCavernToolStripMenuItem";
      this.clankersCavernToolStripMenuItem.Size = new Size(194, 22);
      this.clankersCavernToolStripMenuItem.Text = "Clanker's Cavern";
      this.bubblegloopSwampToolStripMenuItem.Name = "bubblegloopSwampToolStripMenuItem";
      this.bubblegloopSwampToolStripMenuItem.Size = new Size(194, 22);
      this.bubblegloopSwampToolStripMenuItem.Text = "Bubblegloop Swamp";
      this.freezeezyPeakToolStripMenuItem.Name = "freezeezyPeakToolStripMenuItem";
      this.freezeezyPeakToolStripMenuItem.Size = new Size(194, 22);
      this.freezeezyPeakToolStripMenuItem.Text = "Freezeezy Peak";
      this.gobisValleyToolStripMenuItem.Name = "gobisValleyToolStripMenuItem";
      this.gobisValleyToolStripMenuItem.Size = new Size(194, 22);
      this.gobisValleyToolStripMenuItem.Text = "Gobi's Valley ";
      this.madMonsterMansionToolStripMenuItem.Name = "madMonsterMansionToolStripMenuItem";
      this.madMonsterMansionToolStripMenuItem.Size = new Size(194, 22);
      this.madMonsterMansionToolStripMenuItem.Text = "Mad Monster Mansion";
      this.rustyBucketBayToolStripMenuItem.Name = "rustyBucketBayToolStripMenuItem";
      this.rustyBucketBayToolStripMenuItem.Size = new Size(194, 22);
      this.rustyBucketBayToolStripMenuItem.Text = "Rusty Bucket Bay";
      this.clickClockWoodToolStripMenuItem.Name = "clickClockWoodToolStripMenuItem";
      this.clickClockWoodToolStripMenuItem.Size = new Size(194, 22);
      this.clickClockWoodToolStripMenuItem.Text = "Click Clock Wood ";
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(191, 6);
      this.quizToolStripMenuItem.Name = "quizToolStripMenuItem";
      this.quizToolStripMenuItem.Size = new Size(194, 22);
      this.quizToolStripMenuItem.Text = "Quiz";
      this.introToolStripMenuItem.Name = "introToolStripMenuItem";
      this.introToolStripMenuItem.Size = new Size(194, 22);
      this.introToolStripMenuItem.Text = "Intro";
      this.preEndingToolStripMenuItem.Name = "preEndingToolStripMenuItem";
      this.preEndingToolStripMenuItem.Size = new Size(194, 22);
      this.preEndingToolStripMenuItem.Text = "Pre-Ending";
      this.endingToolStripMenuItem.Name = "endingToolStripMenuItem";
      this.endingToolStripMenuItem.Size = new Size(194, 22);
      this.endingToolStripMenuItem.Text = "Ending";
      this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
      this.creditsToolStripMenuItem.Size = new Size(194, 22);
      this.creditsToolStripMenuItem.Text = "Credits";
      this.gameOverToolStripMenuItem.Name = "gameOverToolStripMenuItem";
      this.gameOverToolStripMenuItem.Size = new Size(194, 22);
      this.gameOverToolStripMenuItem.Text = "Game Over";
      this.mumbosMessagesToolStripMenuItem.Name = "mumbosMessagesToolStripMenuItem";
      this.mumbosMessagesToolStripMenuItem.Size = new Size(194, 22);
      this.mumbosMessagesToolStripMenuItem.Text = "Mumbo's Messages";
      this.stopNSwopToolStripMenuItem.Name = "stopNSwopToolStripMenuItem";
      this.stopNSwopToolStripMenuItem.Size = new Size(194, 22);
      this.stopNSwopToolStripMenuItem.Text = "Stop N Swop";
      this.unknownToolStripMenuItem.Name = "unknownToolStripMenuItem";
      this.unknownToolStripMenuItem.Size = new Size(194, 22);
      this.unknownToolStripMenuItem.Text = "Unknown";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(18, -22);
      this.label2.Name = "label2";
      this.label2.Size = new Size(109, 13);
      this.label2.TabIndex = 31;
      this.label2.Text = "Type Your Edit Below";
      this.fileFound_lv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.fileFound_lv.Font = new Font("Microsoft Sans Serif", 6.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.fileFound_lv.Location = new Point(12, 27);
      this.fileFound_lv.Name = "fileFound_lv";
      this.fileFound_lv.Size = new Size(382, 385);
      this.fileFound_lv.TabIndex = 33;
      this.fileFound_lv.UseCompatibleStateImageBehavior = false;
      this.fileFound_lv.SelectedIndexChanged += new EventHandler(this.fileFound_lv_SelectedIndexChanged);
      this.save_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.save_btn.Location = new Point(966, 421);
      this.save_btn.Name = "save_btn";
      this.save_btn.Size = new Size(106, 23);
      this.save_btn.TabIndex = 35;
      this.save_btn.Text = "Save";
      this.save_btn.UseVisualStyleBackColor = true;
      this.save_btn.Click += new EventHandler(this.save_btn_Click);
      this.addPartTop_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.addPartTop_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.addPartTop_btn.Location = new Point(990, 194);
      this.addPartTop_btn.Name = "addPartTop_btn";
      this.addPartTop_btn.Size = new Size(82, 19);
      this.addPartTop_btn.TabIndex = 36;
      this.addPartTop_btn.Text = "+ Add Part";
      this.addPartTop_btn.UseVisualStyleBackColor = true;
      this.addPartTop_btn.Click += new EventHandler(this.addPart_btn_Click);
      this.label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(764, 428);
      this.label1.Name = "label1";
      this.label1.Size = new Size(114, 13);
      this.label1.TabIndex = 37;
      this.label1.Text = "Play This Section First:";
      this.topbottom_cb.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.topbottom_cb.FormattingEnabled = true;
      this.topbottom_cb.Items.AddRange(new object[2]
      {
        (object) "Top",
        (object) "Bottom"
      });
      this.topbottom_cb.Location = new Point(884, 425);
      this.topbottom_cb.Name = "topbottom_cb";
      this.topbottom_cb.Size = new Size(76, 21);
      this.topbottom_cb.TabIndex = 38;
      this.topbottom_cb.Text = "Top";
      this.pnl_top.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnl_top.AutoScroll = true;
      this.pnl_top.Controls.Add((Control) this.tlp_top);
      this.pnl_top.Location = new Point(400, 52);
      this.pnl_top.Name = "pnl_top";
      this.pnl_top.Size = new Size(672, 135);
      this.pnl_top.TabIndex = 40;
      this.tlp_top.AutoSize = true;
      this.tlp_top.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.tlp_top.ColumnCount = 1;
      this.tlp_top.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tlp_top.Dock = DockStyle.Top;
      this.tlp_top.Location = new Point(0, 0);
      this.tlp_top.Name = "tlp_top";
      this.tlp_top.RowCount = 1;
      this.tlp_top.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
      this.tlp_top.Size = new Size(672, 0);
      this.tlp_top.TabIndex = 0;
      this.file_lbl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.file_lbl.AutoSize = true;
      this.file_lbl.Location = new Point(13, 419);
      this.file_lbl.Name = "file_lbl";
      this.file_lbl.Size = new Size(26, 13);
      this.file_lbl.TabIndex = 42;
      this.file_lbl.Text = "File:";
      this.pnl_bottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.pnl_bottom.AutoScroll = true;
      this.pnl_bottom.Controls.Add((Control) this.tlp_bottom);
      this.pnl_bottom.Location = new Point(400, 242);
      this.pnl_bottom.Name = "pnl_bottom";
      this.pnl_bottom.Size = new Size(672, 135);
      this.pnl_bottom.TabIndex = 41;
      this.tlp_bottom.AutoSize = true;
      this.tlp_bottom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.tlp_bottom.ColumnCount = 1;
      this.tlp_bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
      this.tlp_bottom.Dock = DockStyle.Top;
      this.tlp_bottom.Location = new Point(0, 0);
      this.tlp_bottom.Name = "tlp_bottom";
      this.tlp_bottom.RowCount = 1;
      this.tlp_bottom.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
      this.tlp_bottom.Size = new Size(672, 0);
      this.tlp_bottom.TabIndex = 0;
      this.label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(401, 223);
      this.label3.Name = "label3";
      this.label3.Size = new Size(84, 13);
      this.label3.TabIndex = 43;
      this.label3.Text = "Bottom Sections";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(400, 27);
      this.label4.Name = "label4";
      this.label4.Size = new Size(70, 13);
      this.label4.TabIndex = 44;
      this.label4.Text = "Top Sections";
      this.addPartBottom_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.addPartBottom_btn.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.addPartBottom_btn.Location = new Point(990, 383);
      this.addPartBottom_btn.Name = "addPartBottom_btn";
      this.addPartBottom_btn.Size = new Size(82, 19);
      this.addPartBottom_btn.TabIndex = 45;
      this.addPartBottom_btn.Text = "+ Add Part";
      this.addPartBottom_btn.UseVisualStyleBackColor = true;
      this.addPartBottom_btn.Click += new EventHandler(this.addPartBottom_btn_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1084, 458);
      this.Controls.Add((Control) this.addPartBottom_btn);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.pnl_bottom);
      this.Controls.Add((Control) this.file_lbl);
      this.Controls.Add((Control) this.pnl_top);
      this.Controls.Add((Control) this.topbottom_cb);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.addPartTop_btn);
      this.Controls.Add((Control) this.save_btn);
      this.Controls.Add((Control) this.fileFound_lv);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.menuStrip1);
      this.MinimizeBox = false;
      this.Name = "TextEditorForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Text Editor";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.pnl_top.ResumeLayout(false);
      this.pnl_top.PerformLayout();
      this.pnl_bottom.ResumeLayout(false);
      this.pnl_bottom.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
