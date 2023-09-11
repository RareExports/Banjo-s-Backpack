// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SkyBoxReassignment
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
  public class SkyBoxReassignment : Form
  {
    private List<BkSkyBoxDigit> bkSkyBoxDigits = new List<BkSkyBoxDigit>();
    public string newBox = "undef";
    private IContainer components;
    private Button close_btn;
    private Button update_btn;
    private ListBox skybox_lb;

    public SkyBoxReassignment(List<BkSkyBoxDigit> bkSkyBoxDigits_)
    {
      this.InitializeComponent();
      this.bkSkyBoxDigits = bkSkyBoxDigits_;
      this.populateLB();
    }

    private void populateLB()
    {
      for (int index = 0; index < this.bkSkyBoxDigits.Count<BkSkyBoxDigit>(); ++index)
        this.skybox_lb.Items.Add((object) this.bkSkyBoxDigits[index].name);
    }

    private void setNewBox()
    {
      try
      {
        this.newBox = this.skybox_lb.SelectedItem.ToString();
      }
      catch
      {
      }
      this.Close();
    }

    private void update_btn_Click(object sender, EventArgs e) => this.setNewBox();

    private void close_btn_Click(object sender, EventArgs e) => this.Close();

    private void skybox_lb_DoubleClick(object sender, EventArgs e) => this.setNewBox();

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
      this.skybox_lb = new ListBox();
      this.SuspendLayout();
      this.close_btn.Location = new Point(62, 429);
      this.close_btn.Name = "close_btn";
      this.close_btn.Size = new Size(75, 23);
      this.close_btn.TabIndex = 5;
      this.close_btn.Text = "Close";
      this.close_btn.UseVisualStyleBackColor = true;
      this.close_btn.Click += new EventHandler(this.close_btn_Click);
      this.update_btn.Location = new Point(143, 429);
      this.update_btn.Name = "update_btn";
      this.update_btn.Size = new Size(75, 23);
      this.update_btn.TabIndex = 4;
      this.update_btn.Text = "OK";
      this.update_btn.UseVisualStyleBackColor = true;
      this.update_btn.Click += new EventHandler(this.update_btn_Click);
      this.skybox_lb.FormattingEnabled = true;
      this.skybox_lb.Location = new Point(12, 12);
      this.skybox_lb.Name = "skybox_lb";
      this.skybox_lb.Size = new Size(206, 407);
      this.skybox_lb.TabIndex = 3;
      this.skybox_lb.DoubleClick += new EventHandler(this.skybox_lb_DoubleClick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(230, 461);
      this.Controls.Add((Control) this.close_btn);
      this.Controls.Add((Control) this.update_btn);
      this.Controls.Add((Control) this.skybox_lb);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SkyBoxReassignment";
      this.ShowIcon = false;
      this.Text = "Sky Box Reassignment";
      this.ResumeLayout(false);
    }
  }
}
