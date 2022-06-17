// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SceneReassignmentForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class SceneReassignmentForm : Form
  {
    public int newLevel = -1;
    private IContainer components;
    private Button close_btn;
    private Button update_btn;
    private ListBox level_lb;

    public SceneReassignmentForm()
    {
      this.InitializeComponent();
      this.populateLB();
    }

    private void populateLB()
    {
      for (byte levelID = 1; levelID < (byte) 14; ++levelID)
        this.level_lb.Items.Add((object) BKLevelMap.getLevelName(levelID));
    }

    private void close_btn_Click(object sender, EventArgs e) => this.Close();

    private void setNewLevel()
    {
      try
      {
        this.newLevel = this.level_lb.SelectedIndex + 1;
      }
      catch
      {
      }
      this.Close();
    }

    private void update_btn_Click(object sender, EventArgs e) => this.setNewLevel();

    private void level_lb_MouseDoubleClick(object sender, MouseEventArgs e) => this.setNewLevel();

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
      this.level_lb = new ListBox();
      this.SuspendLayout();
      this.close_btn.Location = new Point(62, 429);
      this.close_btn.Name = "close_btn";
      this.close_btn.Size = new Size(75, 23);
      this.close_btn.TabIndex = 5;
      this.close_btn.Text = "Close";
      this.close_btn.UseVisualStyleBackColor = true;
      this.update_btn.Location = new Point(143, 429);
      this.update_btn.Name = "update_btn";
      this.update_btn.Size = new Size(75, 23);
      this.update_btn.TabIndex = 4;
      this.update_btn.Text = "OK";
      this.update_btn.UseVisualStyleBackColor = true;
      this.update_btn.Click += new EventHandler(this.update_btn_Click_1);
      this.level_lb.FormattingEnabled = true;
      this.level_lb.Location = new Point(12, 12);
      this.level_lb.Name = "level_lb";
      this.level_lb.Size = new Size(206, 407);
      this.level_lb.TabIndex = 3;
      this.level_lb.MouseDoubleClick += new MouseEventHandler(this.level_lb_MouseDoubleClick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(230, 458);
      this.Controls.Add((Control) this.close_btn);
      this.Controls.Add((Control) this.update_btn);
      this.Controls.Add((Control) this.level_lb);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SceneReassignmentForm);
      this.ShowIcon = false;
      this.Text = "Assign to Level...";
      this.ResumeLayout(false);
    }
  }
}
