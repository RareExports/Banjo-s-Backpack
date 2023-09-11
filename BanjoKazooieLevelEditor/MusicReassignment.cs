// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.MusicReassignment
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
  public class MusicReassignment : Form
  {
    private List<BKTrack> bkTracks;
    public int selectedTrack = -1;
    private IContainer components;
    private ListBox music_lb;
    private Button update_btn;
    private Button close_btn;

    public MusicReassignment(ref List<BKTrack> bkTracks_)
    {
      this.InitializeComponent();
      this.bkTracks = bkTracks_;
      this.populateLB();
    }

    private void populateLB()
    {
      for (int index = 0; index < this.bkTracks.Count<BKTrack>(); ++index)
        this.music_lb.Items.Add((object) this.bkTracks[index].trackName);
    }

    private void setNewMusic()
    {
      try
      {
        this.selectedTrack = this.music_lb.SelectedIndex;
      }
      catch
      {
      }
      this.Close();
    }

    private void music_lb_MouseDoubleClick(object sender, MouseEventArgs e) => this.setNewMusic();

    private void close_btn_Click(object sender, EventArgs e) => this.Close();

    private void update_btn_Click(object sender, EventArgs e) => this.setNewMusic();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.music_lb = new ListBox();
      this.update_btn = new Button();
      this.close_btn = new Button();
      this.SuspendLayout();
      this.music_lb.FormattingEnabled = true;
      this.music_lb.Location = new Point(12, 12);
      this.music_lb.Name = "music_lb";
      this.music_lb.Size = new Size(206, 407);
      this.music_lb.TabIndex = 0;
      this.music_lb.MouseDoubleClick += new MouseEventHandler(this.music_lb_MouseDoubleClick);
      this.update_btn.Location = new Point(143, 429);
      this.update_btn.Name = "update_btn";
      this.update_btn.Size = new Size(75, 23);
      this.update_btn.TabIndex = 1;
      this.update_btn.Text = "OK";
      this.update_btn.UseVisualStyleBackColor = true;
      this.update_btn.Click += new EventHandler(this.update_btn_Click);
      this.close_btn.Location = new Point(62, 429);
      this.close_btn.Name = "close_btn";
      this.close_btn.Size = new Size(75, 23);
      this.close_btn.TabIndex = 2;
      this.close_btn.Text = "Close";
      this.close_btn.UseVisualStyleBackColor = true;
      this.close_btn.Click += new EventHandler(this.close_btn_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(232, 464);
      this.Controls.Add((Control) this.close_btn);
      this.Controls.Add((Control) this.update_btn);
      this.Controls.Add((Control) this.music_lb);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Name = "MusicReassignment";
      this.ResumeLayout(false);
    }
  }
}
