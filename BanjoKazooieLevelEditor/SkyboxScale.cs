// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SkyboxScale
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class SkyboxScale : Form
  {
    public short size = 16256;
    private IContainer components;
    private Button ok_btn;
    private Label label1;
    private TextBox scale_tb;

    public SkyboxScale(int size_)
    {
      this.InitializeComponent();
      this.scale_tb.Text = size_.ToString("x");
    }

    private void hexOnly_KeyPress(object sender, KeyPressEventArgs e)
    {
      try
      {
        if (!((IEnumerable<string>) new string[22]
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
          "0",
          "A",
          "B",
          "C",
          "D",
          "E",
          "F",
          "a",
          "b",
          "c",
          "d",
          nameof (e),
          "f"
        }).Contains<string>(e.KeyChar.ToString()) && e.KeyChar != '\b')
          e.Handled = true;
        try
        {
          int num = (int) short.Parse(this.scale_tb.Text, NumberStyles.AllowHexSpecifier);
        }
        catch
        {
        }
      }
      catch
      {
      }
    }

    private void ok_btn_Click(object sender, EventArgs e)
    {
      try
      {
        this.size = short.Parse(this.scale_tb.Text, NumberStyles.AllowHexSpecifier);
      }
      catch
      {
      }
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
      this.ok_btn = new Button();
      this.label1 = new Label();
      this.scale_tb = new TextBox();
      this.SuspendLayout();
      this.ok_btn.Location = new Point(87, 36);
      this.ok_btn.Name = "ok_btn";
      this.ok_btn.Size = new Size(52, 23);
      this.ok_btn.TabIndex = 0;
      this.ok_btn.Text = "Update";
      this.ok_btn.UseVisualStyleBackColor = true;
      this.ok_btn.Click += new EventHandler(this.ok_btn_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new Size(79, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "New Scale:  0x";
      this.scale_tb.Location = new Point(91, 10);
      this.scale_tb.Name = "scale_tb";
      this.scale_tb.Size = new Size(46, 20);
      this.scale_tb.TabIndex = 2;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(154, 66);
      this.Controls.Add((Control) this.scale_tb);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.ok_btn);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SkyboxScale);
      this.ShowIcon = false;
      this.Text = "Skybox Scale";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
