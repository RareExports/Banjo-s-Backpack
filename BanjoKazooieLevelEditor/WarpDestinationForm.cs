// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.WarpDestinationForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class WarpDestinationForm : Form
  {
    public WarpLocation warp;
    private List<WarpLocation> everyWarp = new List<WarpLocation>();
    private IContainer components;
    private Button button1;
    private Button button2;
    private ListBox warps_lb;

    public WarpDestinationForm()
    {
      this.InitializeComponent();
      this.populateWarpList();
    }

    public void populateWarpList()
    {
      for (short id_ = 0; id_ < (short) 288; ++id_)
      {
        WarpLocation warpLocation = new WarpLocation((int) id_);
        if (warpLocation.name != "")
        {
          this.everyWarp.Add(warpLocation);
          this.warps_lb.Items.Add((object) warpLocation.name);
        }
      }
    }

    private void Objects_lv_DoubleClick(object sender, EventArgs e)
    {
      this.warp = this.everyWarp[this.warps_lb.SelectedIndices[0]];
      this.Close();
    }

    private void button2_Click(object sender, EventArgs e) => this.Close();

    private void button1_Click(object sender, EventArgs e)
    {
      this.warp = this.everyWarp[this.warps_lb.SelectedIndices[0]];
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.button2 = new Button();
      this.warps_lb = new ListBox();
      this.SuspendLayout();
      this.button1.Location = new Point(257, 516);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 49;
      this.button1.Text = "OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Location = new Point(172, 516);
      this.button2.Name = "button2";
      this.button2.Size = new Size(75, 23);
      this.button2.TabIndex = 50;
      this.button2.Text = "Cancel";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.warps_lb.FormattingEnabled = true;
      this.warps_lb.Location = new Point(13, 12);
      this.warps_lb.Name = "warps_lb";
      this.warps_lb.Size = new Size(319, 498);
      this.warps_lb.TabIndex = 53;
      this.warps_lb.DoubleClick += new EventHandler(this.Objects_lv_DoubleClick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(344, 544);
      this.Controls.Add((Control) this.warps_lb);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (WarpDestinationForm);
      this.ShowIcon = false;
      this.Text = "Warp To";
      this.ResumeLayout(false);
    }
  }
}
