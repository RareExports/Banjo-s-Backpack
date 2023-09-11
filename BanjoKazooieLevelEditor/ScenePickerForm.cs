// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ScenePickerForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class ScenePickerForm : Form
  {
    private List<BKSceneDigit> bkscenedigits = new List<BKSceneDigit>();
    public string newMap = "undef";
    private IContainer components;
    private Button close_btn;
    private Button update_btn;
    private ListBox scene_lb;

    public ScenePickerForm(List<BKSceneDigit> bkscenedigits_)
    {
      this.InitializeComponent();
      this.bkscenedigits = bkscenedigits_;
      this.populateLB();
    }

    private void populateLB()
    {
      for (int index = 0; index < this.bkscenedigits.Count<BKSceneDigit>(); ++index)
        this.scene_lb.Items.Add((object) this.bkscenedigits[index].mapName);
    }

    private void close_btn_Click(object sender, EventArgs e) => this.Close();

    private void setNewLevel()
    {
      try
      {
        this.newMap = this.scene_lb.SelectedItem.ToString();
      }
      catch
      {
      }
      this.Close();
    }

    private void update_btn_Click(object sender, EventArgs e) => this.setNewLevel();

    private void scene_lb_MouseDoubleClick(object sender, MouseEventArgs e) => this.setNewLevel();

    private void update_btn_Click_1(object sender, EventArgs e) => this.setNewLevel();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.close_btn = new Button();
      this.update_btn = new Button();
      this.scene_lb = new ListBox();
      this.SuspendLayout();
      this.close_btn.Location = new Point(62, 429);
      this.close_btn.Name = "close_btn";
      this.close_btn.Size = new Size(75, 23);
      this.close_btn.TabIndex = 8;
      this.close_btn.Text = "Close";
      this.close_btn.UseVisualStyleBackColor = true;
      this.close_btn.Click += new EventHandler(this.close_btn_Click);
      this.update_btn.Location = new Point(143, 429);
      this.update_btn.Name = "update_btn";
      this.update_btn.Size = new Size(75, 23);
      this.update_btn.TabIndex = 7;
      this.update_btn.Text = "OK";
      this.update_btn.UseVisualStyleBackColor = true;
      this.update_btn.Click += new EventHandler(this.update_btn_Click);
      this.scene_lb.FormattingEnabled = true;
      this.scene_lb.Location = new Point(12, 12);
      this.scene_lb.Name = "scene_lb";
      this.scene_lb.Size = new Size(206, 407);
      this.scene_lb.TabIndex = 6;
      this.scene_lb.MouseDoubleClick += new MouseEventHandler(this.scene_lb_MouseDoubleClick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(229, 459);
      this.Controls.Add((Control) this.close_btn);
      this.Controls.Add((Control) this.update_btn);
      this.Controls.Add((Control) this.scene_lb);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ScenePickerForm";
      this.ShowIcon = false;
      this.Text = "Scene Select";
      this.ResumeLayout(false);
    }
  }
}
