// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SpriteEditorForm
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

namespace BanjoKazooieLevelEditor
{
  public class SpriteEditorForm : Form
  {
    public bool romUpdated;
    public List<int> updatedSprites = new List<int>();
    private List<Sprite> sprites = new List<Sprite>();
    private List<Bitmap> newSprite;
    private Sprite selectedSprite = new Sprite(0, "", 0, true);
    public string outDir = "";
    private IContainer components;
    private DataGridView sprites_dgv;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private FlowLayoutPanel sprite_flp;
    private FlowLayoutPanel newSprite_flp;
    private ToolStripMenuItem replaceSpriteToolStripMenuItem;
    private OpenFileDialog openFileDialog1;
    private ToolStripMenuItem saveToRomToolStripMenuItem;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label lbl_frameCount;
    private Label label4;
    private Label lbl_type;
    private Panel panel2;
    private TableLayoutPanel tableLayoutPanel1;

    public SpriteEditorForm()
    {
      this.InitializeComponent();
      this.sprites = BBXML.ReadSpriteXML();
      this.sprites_dgv.Rows.Clear();
      this.sprites_dgv.Columns.Clear();
      this.sprites_dgv.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.sprites_dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.sprites_dgv.AutoGenerateColumns = false;
      this.sprites_dgv.RowHeadersVisible = false;
      this.sprites_dgv.MultiSelect = false;
      DataGridViewColumnCollection columns1 = this.sprites_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "REF";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn1.FillWeight = 25f;
      columns1.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewColumnCollection columns2 = this.sprites_dgv.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Name";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn2.FillWeight = 25f;
      columns2.Add((DataGridViewColumn) viewTextBoxColumn2);
      for (int index = 0; index < this.sprites.Count; ++index)
        this.sprites_dgv.Rows.Add((object) index, (object) this.sprites[index].name);
      this.sprites_dgv.Columns[0].Visible = false;
      this.sprites_dgv.ClearSelection();
    }

    private void sprites_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void ShowSelectedSprite()
    {
      int index1 = 0;
      while (index1 < this.newSprite_flp.Controls.Count)
        this.newSprite_flp.Controls[index1].Dispose();
      this.newSprite = (List<Bitmap>) null;
      try
      {
        int index2 = 0;
        while (index2 < this.sprite_flp.Controls.Count)
          this.sprite_flp.Controls[index2].Dispose();
        int index3 = (int) this.sprites_dgv.SelectedRows[0].Cells[0].Value;
        this.selectedSprite = this.sprites[index3];
        if (this.selectedSprite.compressed)
        {
          RomHandler.DecompressFileToHDD(this.sprites[index3].pointer);
          if (File.Exists(RomHandler.tmpDir + this.sprites[index3].pointer.ToString("x")))
          {
            byte[] file = File.ReadAllBytes(RomHandler.tmpDir + this.sprites[index3].pointer.ToString("x"));
            if (this.sprites[index3].frames.Count == 0)
              ImageHandler.ConvertSprite(ref file, this.sprites[index3]);
          }
        }
        else
        {
          byte[] decompressedFile = RomHandler.GetDecompressedFile(this.selectedSprite.pointer, 20480);
          if (this.sprites[index3].frames.Count == 0)
            ImageHandler.ConvertSprite(ref decompressedFile, this.sprites[index3]);
        }
        foreach (Bitmap frame in this.selectedSprite.frames)
        {
          PictureBox pictureBox = new PictureBox();
          pictureBox.Width = frame.Width;
          pictureBox.Height = frame.Height;
          pictureBox.Image = (Image) frame;
          this.sprite_flp.Controls.Add((Control) pictureBox);
        }
        this.lbl_frameCount.Text = this.selectedSprite.frames.Count<Bitmap>().ToString();
        this.lbl_type.Text = Enum.GetName(typeof (SpriteTextureFormat), (object) this.selectedSprite.textureFormat) ?? "UNK";
      }
      catch
      {
      }
    }

    private void replaceSpriteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.selectedSprite == null)
        return;
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        int index = 0;
        while (index < this.newSprite_flp.Controls.Count)
          this.newSprite_flp.Controls[index].Dispose();
        this.newSprite = ((IEnumerable<Bitmap>) ImageHandler.LoadGIFFrames(this.openFileDialog1.FileName, this.selectedSprite.frames.Count<Bitmap>())).ToList<Bitmap>();
        foreach (Bitmap bitmap in this.newSprite)
        {
          PictureBox pictureBox = new PictureBox();
          pictureBox.Width = bitmap.Width;
          pictureBox.Height = bitmap.Height;
          pictureBox.Image = (Image) bitmap;
          this.newSprite_flp.Controls.Add((Control) pictureBox);
        }
      }
      catch
      {
      }
    }

    private void saveToRomToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.sprites_dgv.SelectedRows.Count > 0)
      {
        if (this.newSprite != null)
        {
          try
          {
            if (!this.updatedSprites.Contains(this.selectedSprite.pointer))
              this.updatedSprites.Add(this.selectedSprite.pointer);
            if (File.Exists(this.outDir + (object) this.selectedSprite.pointer))
              File.Delete(this.outDir + this.selectedSprite.pointer.ToString("x"));
            FileStream output = File.Create(this.outDir + this.selectedSprite.pointer.ToString("x"));
            BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
            try
            {
              binaryWriter.Write(ImageHandler.ConvertFramesToBKSprite(this.newSprite.ToArray(), this.selectedSprite.animationByte));
              binaryWriter.Close();
              output.Close();
              this.romUpdated = true;
              int num = (int) MessageBox.Show("Change commited will be applied to the rom when the Sprite Editor closes");
              return;
            }
            catch
            {
              binaryWriter.Close();
              output.Close();
              return;
            }
          }
          catch
          {
            return;
          }
        }
      }
      int num1 = (int) MessageBox.Show("You need to specify a replacement sprite");
    }

    private void SpriteEditorForm_Load(object sender, EventArgs e) => this.ShowSelectedSprite();

    private void sprites_dgv_SelectionChanged(object sender, EventArgs e) => this.ShowSelectedSprite();

    private void button1_Click(object sender, EventArgs e)
    {
      this.newSprite.Add(this.newSprite[0]);
      PictureBox pictureBox = new PictureBox();
      pictureBox.Width = this.newSprite[0].Width;
      pictureBox.Height = this.newSprite[0].Height;
      pictureBox.Image = (Image) this.newSprite[0];
      this.newSprite_flp.Controls.Add((Control) pictureBox);
    }

    private void label2_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.sprites_dgv = new DataGridView();
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.replaceSpriteToolStripMenuItem = new ToolStripMenuItem();
      this.saveToRomToolStripMenuItem = new ToolStripMenuItem();
      this.sprite_flp = new FlowLayoutPanel();
      this.newSprite_flp = new FlowLayoutPanel();
      this.openFileDialog1 = new OpenFileDialog();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.lbl_frameCount = new Label();
      this.label4 = new Label();
      this.lbl_type = new Label();
      this.panel2 = new Panel();
      this.tableLayoutPanel1 = new TableLayoutPanel();
      ((ISupportInitialize) this.sprites_dgv).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      this.sprites_dgv.AllowUserToAddRows = false;
      this.sprites_dgv.AllowUserToDeleteRows = false;
      this.sprites_dgv.AllowUserToResizeColumns = false;
      this.sprites_dgv.AllowUserToResizeRows = false;
      this.sprites_dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
      this.sprites_dgv.BackgroundColor = Color.White;
      this.sprites_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.sprites_dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
      this.sprites_dgv.Location = new Point(12, 27);
      this.sprites_dgv.Name = "sprites_dgv";
      this.sprites_dgv.ReadOnly = true;
      this.sprites_dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.sprites_dgv.Size = new Size(178, 422);
      this.sprites_dgv.TabIndex = 68;
      this.sprites_dgv.CellClick += new DataGridViewCellEventHandler(this.sprites_dgv_CellContentClick);
      this.sprites_dgv.SelectionChanged += new EventHandler(this.sprites_dgv_SelectionChanged);
      this.menuStrip1.BackColor = SystemColors.ActiveCaption;
      this.menuStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.fileToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(788, 24);
      this.menuStrip1.TabIndex = 69;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.replaceSpriteToolStripMenuItem,
        (ToolStripItem) this.saveToRomToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      this.replaceSpriteToolStripMenuItem.Name = "replaceSpriteToolStripMenuItem";
      this.replaceSpriteToolStripMenuItem.Size = new Size(152, 22);
      this.replaceSpriteToolStripMenuItem.Text = "Replace Sprite";
      this.replaceSpriteToolStripMenuItem.Click += new EventHandler(this.replaceSpriteToolStripMenuItem_Click);
      this.saveToRomToolStripMenuItem.Name = "saveToRomToolStripMenuItem";
      this.saveToRomToolStripMenuItem.Size = new Size(152, 22);
      this.saveToRomToolStripMenuItem.Text = "Save To Rom";
      this.saveToRomToolStripMenuItem.Click += new EventHandler(this.saveToRomToolStripMenuItem_Click);
      this.sprite_flp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.sprite_flp.AutoScroll = true;
      this.sprite_flp.BackColor = Color.Black;
      this.sprite_flp.Location = new Point(3, 3);
      this.sprite_flp.Name = "sprite_flp";
      this.sprite_flp.Size = new Size(571, 174);
      this.sprite_flp.TabIndex = 70;
      this.newSprite_flp.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.newSprite_flp.BackColor = Color.Black;
      this.newSprite_flp.Location = new Point(3, 223);
      this.newSprite_flp.Name = "newSprite_flp";
      this.newSprite_flp.Size = new Size(571, 174);
      this.newSprite_flp.TabIndex = 71;
      this.openFileDialog1.Filter = "GIF Files|*.gif";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(196, 33);
      this.label1.Name = "label1";
      this.label1.Size = new Size(45, 13);
      this.label1.TabIndex = 72;
      this.label1.Text = "Original:";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(0, 18);
      this.label2.Name = "label2";
      this.label2.Size = new Size(32, 13);
      this.label2.TabIndex = 73;
      this.label2.Text = "New:";
      this.label2.Click += new EventHandler(this.label2_Click);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(3, 2);
      this.label3.Name = "label3";
      this.label3.Size = new Size(70, 13);
      this.label3.TabIndex = 74;
      this.label3.Text = "Frame Count:";
      this.lbl_frameCount.AutoSize = true;
      this.lbl_frameCount.Location = new Point(80, 2);
      this.lbl_frameCount.Name = "lbl_frameCount";
      this.lbl_frameCount.Size = new Size(13, 13);
      this.lbl_frameCount.TabIndex = 75;
      this.lbl_frameCount.Text = "0";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(130, 2);
      this.label4.Name = "label4";
      this.label4.Size = new Size(34, 13);
      this.label4.TabIndex = 76;
      this.label4.Text = "Type:";
      this.lbl_type.AutoSize = true;
      this.lbl_type.Location = new Point(171, 1);
      this.lbl_type.Name = "lbl_type";
      this.lbl_type.Size = new Size(10, 13);
      this.lbl_type.TabIndex = 77;
      this.lbl_type.Text = "-";
      this.panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.panel2.Controls.Add((Control) this.label3);
      this.panel2.Controls.Add((Control) this.label2);
      this.panel2.Controls.Add((Control) this.lbl_type);
      this.panel2.Controls.Add((Control) this.lbl_frameCount);
      this.panel2.Controls.Add((Control) this.label4);
      this.panel2.Location = new Point(3, 183);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(571, 34);
      this.panel2.TabIndex = 79;
      this.tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
      this.tableLayoutPanel1.Controls.Add((Control) this.newSprite_flp, 0, 2);
      this.tableLayoutPanel1.Controls.Add((Control) this.sprite_flp, 0, 0);
      this.tableLayoutPanel1.Controls.Add((Control) this.panel2, 0, 1);
      this.tableLayoutPanel1.Location = new Point(199, 49);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
      this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));
      this.tableLayoutPanel1.Size = new Size(577, 400);
      this.tableLayoutPanel1.TabIndex = 81;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(788, 455);
      this.Controls.Add((Control) this.tableLayoutPanel1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.menuStrip1);
      this.Controls.Add((Control) this.sprites_dgv);
      this.Name = "SpriteEditorForm";
      this.ShowIcon = false;
      this.Text = "Sprite Editor";
      this.Load += new EventHandler(this.SpriteEditorForm_Load);
      ((ISupportInitialize) this.sprites_dgv).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
