// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.OpenSetFileForm
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
  public class OpenSetFileForm : Form
  {
    public int selected = -1;
    private IContainer components;
    private Button ok_btn;
    private Button close_btn;
    private FolderBrowserDialog directoryPicker_fbd;
    private ListView fileFound_lv;

    public OpenSetFileForm() => this.InitializeComponent();

    public void DisplayFiles(List<SetupFile> SetupFiles_)
    {
      this.fileFound_lv.View = View.Details;
      this.fileFound_lv.Columns.Add("Title", -2, HorizontalAlignment.Center);
      this.fileFound_lv.Columns.Add("Address", -2, HorizontalAlignment.Left);
      for (int index = 0; index < SetupFiles_.Count; ++index)
      {
        SetupFile setupFile = SetupFiles_[index];
        this.fileFound_lv.Items.Add(new ListViewItem(setupFile.name)
        {
          SubItems = {
            "0x" + setupFile.pointer.ToString("x")
          }
        });
      }
    }

    private void ok_btn_Click(object sender, EventArgs e)
    {
      if (this.fileFound_lv.SelectedIndices.Count == 0)
        return;
      this.selected = this.fileFound_lv.SelectedIndices[0];
      this.Close();
    }

    private void close_btn_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.ok_btn = new Button();
      this.close_btn = new Button();
      this.directoryPicker_fbd = new FolderBrowserDialog();
      this.fileFound_lv = new ListView();
      this.SuspendLayout();
      this.ok_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.ok_btn.Location = new Point(433, 477);
      this.ok_btn.Name = "ok_btn";
      this.ok_btn.Size = new Size(75, 23);
      this.ok_btn.TabIndex = 3;
      this.ok_btn.Text = "OK";
      this.ok_btn.UseVisualStyleBackColor = true;
      this.ok_btn.Click += new EventHandler(this.ok_btn_Click);
      this.close_btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.close_btn.Location = new Point(355, 477);
      this.close_btn.Name = "close_btn";
      this.close_btn.Size = new Size(75, 23);
      this.close_btn.TabIndex = 4;
      this.close_btn.Text = "Close";
      this.close_btn.UseVisualStyleBackColor = true;
      this.close_btn.Click += new EventHandler(this.close_btn_Click);
      this.fileFound_lv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.fileFound_lv.FullRowSelect = true;
      this.fileFound_lv.GridLines = true;
      this.fileFound_lv.Location = new Point(12, 12);
      this.fileFound_lv.MultiSelect = false;
      this.fileFound_lv.Name = "fileFound_lv";
      this.fileFound_lv.Size = new Size(500, 459);
      this.fileFound_lv.TabIndex = 8;
      this.fileFound_lv.UseCompatibleStateImageBehavior = false;
      this.fileFound_lv.DoubleClick += new EventHandler(this.ok_btn_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(524, 512);
      this.Controls.Add((Control) this.fileFound_lv);
      this.Controls.Add((Control) this.close_btn);
      this.Controls.Add((Control) this.ok_btn);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (OpenSetFileForm);
      this.ShowIcon = false;
      this.Text = "Setup File";
      this.ResumeLayout(false);
    }
  }
}
