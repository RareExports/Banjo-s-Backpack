// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Progress
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class Progress : Form
  {
    private IContainer components;
    private ProgressBar progress_pb;
    private Label info_lbl;

    public Progress() => this.InitializeComponent();

    public Progress(string message)
    {
      this.InitializeComponent();
      this.info_lbl.Text = message;
    }

    public int ProgressValue
    {
      get => this.progress_pb.Value;
      set => this.progress_pb.Value = value;
    }

    public void UpdateProgress(int newProgress)
    {
      if (this.InvokeRequired)
      {
        this.Invoke((Delegate) new Progress.updateProgress(this.UpdateProgress), (object) newProgress);
      }
      else
      {
        if (newProgress > 100)
          newProgress = 100;
        this.progress_pb.Value = newProgress;
        int num = this.progress_pb.Value;
      }
    }

    public void CloseFrm()
    {
      if (this.InvokeRequired)
        this.Invoke((Delegate) new Progress.closeFrm(this.CloseFrm), new object[0]);
      else
        this.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.progress_pb = new ProgressBar();
      this.info_lbl = new Label();
      this.SuspendLayout();
      this.progress_pb.Location = new Point(12, 25);
      this.progress_pb.Name = "progress_pb";
      this.progress_pb.Size = new Size(235, 23);
      this.progress_pb.TabIndex = 0;
      this.info_lbl.AutoSize = true;
      this.info_lbl.Location = new Point(12, 9);
      this.info_lbl.Name = "info_lbl";
      this.info_lbl.Size = new Size(166, 13);
      this.info_lbl.TabIndex = 1;
      this.info_lbl.Text = "Decompressing files please wait...";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(262, 62);
      this.ControlBox = false;
      this.Controls.Add((Control) this.info_lbl);
      this.Controls.Add((Control) this.progress_pb);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = "Progress";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private delegate void updateProgress(int newProgress);

    private delegate void closeFrm();
  }
}
