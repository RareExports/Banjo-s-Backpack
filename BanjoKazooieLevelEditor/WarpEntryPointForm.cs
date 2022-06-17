// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.WarpEntryPointForm
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
  public class WarpEntryPointForm : Form
  {
    private List<EntryPoint> entryPoints = new List<EntryPoint>();
    public EntryPoint entry = new EntryPoint("", 0);
    private IContainer components;
    private ListBox entrypoints_lb;
    private Button ok_btn;

    public WarpEntryPointForm()
    {
      this.InitializeComponent();
      this.setup();
    }

    public void setup()
    {
      this.entryPoints.Add(new EntryPoint("SM - Banjo's House", 431));
      this.entryPoints.Add(new EntryPoint("SM - Grunty's Lair", 431));
      this.entryPoints.Add(new EntryPoint("MM - Mumbo's Hut", 1));
      this.entryPoints.Add(new EntryPoint("MM -  Ticker's Tower Bottom", 2));
      this.entryPoints.Add(new EntryPoint("MM -  Ticker's Tower Top", 21));
      this.entryPoints.Add(new EntryPoint("TTC - Blubber's Ship Top", 120));
      this.entryPoints.Add(new EntryPoint("TTC - Blubber's Ship Bottom", 121));
      this.entryPoints.Add(new EntryPoint("TTC - Sandcastle", 21));
      this.entryPoints.Add(new EntryPoint("TTC - Upper Level", 116));
      this.entryPoints.Add(new EntryPoint("TTC - Lower Level", 117));
      this.entryPoints.Add(new EntryPoint("TTC - Lighthouse Bottom", 122));
      this.entryPoints.Add(new EntryPoint("TTC - Nipper's Shell", 126));
      this.entryPoints.Add(new EntryPoint("CC - Left Gill", 21));
      this.entryPoints.Add(new EntryPoint("CC - Right", 118));
      this.entryPoints.Add(new EntryPoint("BGS - Mumbo's Hut", 419));
      this.entryPoints.Add(new EntryPoint("BGS - Tanktup", 416));
      this.entryPoints.Add(new EntryPoint("BGS - Mr Vile (Right)", 417));
      this.entryPoints.Add(new EntryPoint("BGS - Mr Vile (Left)", 418));
      this.entryPoints.Add(new EntryPoint("GV - Jinxy", 415));
      this.entryPoints.Add(new EntryPoint("GV - Sun Pyramid", 416));
      this.entryPoints.Add(new EntryPoint("GV - Main Pyramid", 417));
      this.entryPoints.Add(new EntryPoint("GV - Star Pyramid", 418));
      this.entryPoints.Add(new EntryPoint("GV - SNS Egg Room", 423));
      this.entryPoints.Add(new EntryPoint("GV - Kazooie Pyramid", 419));
      this.entryPoints.Add(new EntryPoint("MMM - Outside Clock", 114));
      this.entryPoints.Add(new EntryPoint("MMM - Top of Clock Tower", 115));
      this.entryPoints.Add(new EntryPoint("MMM - Note Room", 116));
      this.entryPoints.Add(new EntryPoint("MMM - Bedroom", 117));
      this.entryPoints.Add(new EntryPoint("MMM - Shed", 118));
      this.entryPoints.Add(new EntryPoint("MMM - Secret Room", 120));
      this.entryPoints.Add(new EntryPoint("MMM - Drainpipe", 122));
      this.entryPoints.Add(new EntryPoint("MMM - Basement", 123));
      this.entryPoints.Add(new EntryPoint("MMM - Feather Room", 124));
      this.entryPoints.Add(new EntryPoint("MMM - Egg Room", 125));
      this.entryPoints.Add(new EntryPoint("MMM - Bathroom", 126));
      this.entryPoints.Add(new EntryPoint("MMM - Attic", (int) sbyte.MaxValue));
      this.entryPoints.Add(new EntryPoint("MMM - Church", 418));
      this.entryPoints.Add(new EntryPoint("MMM - Mumbo's Hut", 431));
      this.entryPoints.Add(new EntryPoint("MMM - Well Bottom", 432));
      this.entryPoints.Add(new EntryPoint("FP - Boggy's Igloo", 122));
      this.entryPoints.Add(new EntryPoint("FP - Xmas Tree", 123));
      this.entryPoints.Add(new EntryPoint("FP - Wazza's Cave", 120));
      this.entryPoints.Add(new EntryPoint("FP - Mumbo's Hut", 122));
      this.entryPoints.Add(new EntryPoint("RBB - Boss Ka-Boom Room", 126));
      this.entryPoints.Add(new EntryPoint("RBB - Propeller Room", 121));
      this.entryPoints.Add(new EntryPoint("RBB - Container Room 1", 123));
      this.entryPoints.Add(new EntryPoint("RBB - Container Room 2", 124));
      this.entryPoints.Add(new EntryPoint("RBB - Container Room 3", 125));
      this.entryPoints.Add(new EntryPoint("RBB - Navigation Room", 119));
      this.entryPoints.Add(new EntryPoint("CCW - Winter", 1));
      this.entryPoints.Add(new EntryPoint("CCW - Spring", 2));
      this.entryPoints.Add(new EntryPoint("CCW - Summer", 21));
      this.entryPoints.Add(new EntryPoint("CCW - Autumn", 118));
      for (int index = 0; index < this.entryPoints.Count; ++index)
        this.entrypoints_lb.Items.Add((object) this.entryPoints[index].name);
    }

    private void ok_btn_Click(object sender, EventArgs e)
    {
      this.entry = this.entryPoints[this.entrypoints_lb.SelectedIndices[0]];
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
      this.entrypoints_lb = new ListBox();
      this.ok_btn = new Button();
      this.SuspendLayout();
      this.entrypoints_lb.FormattingEnabled = true;
      this.entrypoints_lb.Location = new Point(13, 13);
      this.entrypoints_lb.Name = "entrypoints_lb";
      this.entrypoints_lb.Size = new Size(283, 368);
      this.entrypoints_lb.TabIndex = 0;
      this.ok_btn.Location = new Point(221, 387);
      this.ok_btn.Name = "ok_btn";
      this.ok_btn.Size = new Size(75, 23);
      this.ok_btn.TabIndex = 51;
      this.ok_btn.Text = "OK";
      this.ok_btn.UseVisualStyleBackColor = true;
      this.ok_btn.Click += new EventHandler(this.ok_btn_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(308, 420);
      this.Controls.Add((Control) this.ok_btn);
      this.Controls.Add((Control) this.entrypoints_lb);
      this.Name = nameof (WarpEntryPointForm);
      this.ShowIcon = false;
      this.Text = "Select Entry Point";
      this.ResumeLayout(false);
    }
  }
}
