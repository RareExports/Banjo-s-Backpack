// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SNSEditor
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class SNSEditor : Form
  {
    private List<SetupFile> SetupFiles;
    private List<SNSItem> SNSItems = new List<SNSItem>();
    private SNSItem selectedItem;
    private bool isSelecting;
    public List<byte> F37F90;
    public List<byte> F9CAE0;
    public bool updatedRom;
    private IContainer components;
    private ListBox level_lb;
    private Label label3;
    private Button update_btn;
    private Label label1;
    private ListBox items_lb;
    private Panel particle_pnl;
    private Label label2;
    private PictureBox colorPick_pbx;
    private Label lbl4;
    private TextBox unknown_tb;

    public SNSEditor(List<byte> F37F90_, List<byte> F9CAE0_, List<SetupFile> SetupFiles_)
    {
      this.InitializeComponent();
      this.F37F90 = F37F90_;
      this.F9CAE0 = F9CAE0_;
      this.SetupFiles = SetupFiles_;
      this.createSNSItems();
      this.populateLevelList();
      this.disableEditing();
    }

    private void createSNSItems()
    {
      this.SNSItems.Add(new SNSItem(22912, (int) this.F37F90[22914] * 256 + (int) this.F37F90[22915], this.F37F90[22919], (byte) 0));
      for (int loc_ = 22920; loc_ < 22976; loc_ += 12)
        this.SNSItems.Add(new SNSItem(loc_, (int) this.F37F90[loc_ + 2] * 256 + (int) this.F37F90[loc_ + 3], this.F37F90[loc_ + 7], this.F37F90[loc_ + 11]));
      for (int index1 = 220; index1 < 237; index1 += 3)
      {
        for (int index2 = 0; index2 < this.SNSItems.Count; ++index2)
        {
          if ((int) this.SNSItems[index2].colorOffset == index1)
            this.SNSItems[index2].SetColour(this.F9CAE0[index1], this.F9CAE0[index1 + 1], this.F9CAE0[index1 + 2]);
        }
      }
      foreach (SNSItem snsItem in this.SNSItems)
        this.items_lb.Items.Add((object) snsItem.name);
    }

    private void populateLevelList()
    {
      for (int index = 0; index < this.SetupFiles.Count; ++index)
        this.level_lb.Items.Add((object) this.SetupFiles[index].name);
    }

    private void items_lb_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        this.selectedItem = this.SNSItems[this.items_lb.SelectedIndex];
        this.particle_pnl.BackColor = this.selectedItem.particle;
        this.unknown_tb.Text = this.selectedItem.unknown.ToString("x");
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
      this.update_btn.Enabled = false;
    }

    private void enableEditing()
    {
      this.level_lb.Enabled = true;
      this.update_btn.Enabled = true;
      this.level_lb.SelectedIndex = 0;
      for (int index = 0; index < this.SetupFiles.Count<SetupFile>(); ++index)
      {
        if (this.selectedItem.level == this.SetupFiles[index].sceneID)
          this.level_lb.SelectedIndex = index;
      }
    }

    private void update_btn_Click(object sender, EventArgs e)
    {
      this.F37F90[this.selectedItem.loc + 3] = (byte) this.SetupFiles[this.level_lb.SelectedIndex].sceneID;
      this.F37F90[this.selectedItem.loc + 7] = Convert.ToByte(this.unknown_tb.Text, 16);
      this.F9CAE0[(int) this.selectedItem.colorOffset] = this.particle_pnl.BackColor.R;
      this.F9CAE0[(int) this.selectedItem.colorOffset + 1] = this.particle_pnl.BackColor.G;
      this.F9CAE0[(int) this.selectedItem.colorOffset + 2] = this.particle_pnl.BackColor.B;
      this.updatedRom = true;
    }

    private void colorPick_pbx_MouseDown(object sender, MouseEventArgs e)
    {
      this.isSelecting = true;
      this.colorPick_pbx_MouseMove(sender, e);
    }

    private void colorPick_pbx_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if (!this.isSelecting)
          return;
        Bitmap bitmap = new Bitmap(this.colorPick_pbx.Width, this.colorPick_pbx.Height);
        using (Graphics graphics = Graphics.FromImage((Image) bitmap))
        {
          graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
          graphics.DrawImage(this.colorPick_pbx.Image, 0, 0, bitmap.Width, bitmap.Height);
        }
        this.particle_pnl.BackColor = bitmap.GetPixel(e.X, e.Y);
      }
      catch
      {
      }
    }

    private void colorPick_pbx_MouseUp(object sender, MouseEventArgs e) => this.isSelecting = false;

    private void colorPick_pbx_MouseLeave(object sender, EventArgs e) => this.isSelecting = false;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SNSEditor));
      this.level_lb = new ListBox();
      this.label3 = new Label();
      this.update_btn = new Button();
      this.label1 = new Label();
      this.items_lb = new ListBox();
      this.particle_pnl = new Panel();
      this.label2 = new Label();
      this.colorPick_pbx = new PictureBox();
      this.lbl4 = new Label();
      this.unknown_tb = new TextBox();
      ((ISupportInitialize) this.colorPick_pbx).BeginInit();
      this.SuspendLayout();
      this.level_lb.FormattingEnabled = true;
      this.level_lb.Location = new Point(261, 36);
      this.level_lb.Name = "level_lb";
      this.level_lb.Size = new Size(205, 316);
      this.level_lb.TabIndex = 12;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(16, 20);
      this.label3.Name = "label3";
      this.label3.Size = new Size(27, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "Item";
      this.update_btn.Location = new Point(475, 36);
      this.update_btn.Name = "update_btn";
      this.update_btn.Size = new Size(75, 23);
      this.update_btn.TabIndex = 10;
      this.update_btn.Text = "Update";
      this.update_btn.UseVisualStyleBackColor = true;
      this.update_btn.Click += new EventHandler(this.update_btn_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(258, 20);
      this.label1.Name = "label1";
      this.label1.Size = new Size(33, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Level";
      this.items_lb.FormattingEnabled = true;
      this.items_lb.Location = new Point(17, 36);
      this.items_lb.Name = "items_lb";
      this.items_lb.Size = new Size(205, 199);
      this.items_lb.TabIndex = 8;
      this.items_lb.SelectedIndexChanged += new EventHandler(this.items_lb_SelectedIndexChanged);
      this.particle_pnl.BackColor = Color.White;
      this.particle_pnl.BorderStyle = BorderStyle.FixedSingle;
      this.particle_pnl.Location = new Point(19, 254);
      this.particle_pnl.Name = "particle_pnl";
      this.particle_pnl.Size = new Size(203, 32);
      this.particle_pnl.TabIndex = 39;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(16, 238);
      this.label2.Name = "label2";
      this.label2.Size = new Size(75, 13);
      this.label2.TabIndex = 40;
      this.label2.Text = "Particle Colour";
      this.colorPick_pbx.Image = (Image) componentResourceManager.GetObject("colorPick_pbx.Image");
      this.colorPick_pbx.Location = new Point(19, 292);
      this.colorPick_pbx.Name = "colorPick_pbx";
      this.colorPick_pbx.Size = new Size(205, 84);
      this.colorPick_pbx.SizeMode = PictureBoxSizeMode.StretchImage;
      this.colorPick_pbx.TabIndex = 41;
      this.colorPick_pbx.TabStop = false;
      this.colorPick_pbx.MouseMove += new MouseEventHandler(this.colorPick_pbx_MouseMove);
      this.colorPick_pbx.MouseDown += new MouseEventHandler(this.colorPick_pbx_MouseDown);
      this.colorPick_pbx.MouseUp += new MouseEventHandler(this.colorPick_pbx_MouseUp);
      this.lbl4.AutoSize = true;
      this.lbl4.Location = new Point(258, 365);
      this.lbl4.Name = "lbl4";
      this.lbl4.Size = new Size(56, 13);
      this.lbl4.TabIndex = 42;
      this.lbl4.Text = "Unknown:";
      this.unknown_tb.Location = new Point(366, 362);
      this.unknown_tb.Name = "unknown_tb";
      this.unknown_tb.Size = new Size(100, 20);
      this.unknown_tb.TabIndex = 43;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(562, 394);
      this.Controls.Add((Control) this.unknown_tb);
      this.Controls.Add((Control) this.lbl4);
      this.Controls.Add((Control) this.colorPick_pbx);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.particle_pnl);
      this.Controls.Add((Control) this.level_lb);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.update_btn);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.items_lb);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SNSEditor);
      this.ShowIcon = false;
      this.Text = "SNS Editor";
      ((ISupportInitialize) this.colorPick_pbx).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
