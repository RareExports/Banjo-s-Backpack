// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SearchForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class SearchForm : Form
  {
    public SearchCriteria searchCriteria = new SearchCriteria();
    private IContainer components;
    private Label label1;
    private TextBox text_tb;
    private Label label2;
    private CheckBox all_cb;
    private CheckBox mm_cb;
    private CheckBox ttc_cb;
    private CheckBox gv_cb;
    private CheckBox mmm_cb;
    private CheckBox gen_cb;
    private CheckBox sm_cb;
    private CheckBox cut_cb;
    private CheckBox gl_cb;
    private CheckBox fb_cb;
    private CheckBox ff_cb;
    private CheckBox ccw_cb;
    private CheckBox cc_cb;
    private CheckBox bgs_cb;
    private CheckBox fp_cb;
    private CheckBox rbb_cb;
    private Button search_btn;

    public SearchForm() => this.InitializeComponent();

    private void search_btn_Click(object sender, EventArgs e)
    {
      this.searchCriteria = new SearchCriteria(this.text_tb.Text, this.gl_cb.Checked, this.sm_cb.Checked, this.mm_cb.Checked, this.ttc_cb.Checked, this.cc_cb.Checked, this.bgs_cb.Checked, this.fp_cb.Checked, this.gv_cb.Checked, this.mmm_cb.Checked, this.rbb_cb.Checked, this.ccw_cb.Checked, this.fb_cb.Checked, this.ff_cb.Checked, this.gen_cb.Checked, this.cut_cb.Checked);
      this.Close();
    }

    private void all_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.all_cb.Checked)
        return;
      this.gl_cb.Checked = true;
      this.sm_cb.Checked = true;
      this.mm_cb.Checked = true;
      this.ttc_cb.Checked = true;
      this.cc_cb.Checked = true;
      this.bgs_cb.Checked = true;
      this.fp_cb.Checked = true;
      this.gv_cb.Checked = true;
      this.mmm_cb.Checked = true;
      this.ccw_cb.Checked = true;
      this.fb_cb.Checked = true;
      this.ff_cb.Checked = true;
      this.gen_cb.Checked = true;
      this.cut_cb.Checked = true;
      this.rbb_cb.Checked = true;
    }

    private void gl_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.gl_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void sm_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.sm_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void mm_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.mm_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void ttc_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.ttc_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void cc_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cc_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void bgs_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.bgs_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void fp_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.fp_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void gv_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.gv_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void mmm_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.mmm_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void rbb_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.rbb_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void ccw_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.ccw_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void fb_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.fb_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void ff_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.ff_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void gen_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.gen_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    private void cut_cb_CheckedChanged(object sender, EventArgs e)
    {
      if (this.cut_cb.Checked)
        return;
      this.all_cb.Checked = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.text_tb = new TextBox();
      this.label2 = new Label();
      this.all_cb = new CheckBox();
      this.mm_cb = new CheckBox();
      this.ttc_cb = new CheckBox();
      this.gv_cb = new CheckBox();
      this.mmm_cb = new CheckBox();
      this.gen_cb = new CheckBox();
      this.sm_cb = new CheckBox();
      this.cut_cb = new CheckBox();
      this.gl_cb = new CheckBox();
      this.fb_cb = new CheckBox();
      this.ff_cb = new CheckBox();
      this.ccw_cb = new CheckBox();
      this.cc_cb = new CheckBox();
      this.bgs_cb = new CheckBox();
      this.fp_cb = new CheckBox();
      this.rbb_cb = new CheckBox();
      this.search_btn = new Button();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.Location = new Point(14, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(28, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Text";
      this.text_tb.Location = new Point(48, 13);
      this.text_tb.Name = "text_tb";
      this.text_tb.Size = new Size(411, 20);
      this.text_tb.TabIndex = 1;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(13, 49);
      this.label2.Name = "label2";
      this.label2.Size = new Size(38, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Levels";
      this.all_cb.AutoSize = true;
      this.all_cb.Checked = true;
      this.all_cb.CheckState = CheckState.Checked;
      this.all_cb.Location = new Point(13, 66);
      this.all_cb.Name = "all_cb";
      this.all_cb.Size = new Size(37, 17);
      this.all_cb.TabIndex = 3;
      this.all_cb.Text = "All";
      this.all_cb.UseVisualStyleBackColor = true;
      this.all_cb.CheckedChanged += new EventHandler(this.all_cb_CheckedChanged);
      this.mm_cb.AutoSize = true;
      this.mm_cb.Checked = true;
      this.mm_cb.CheckState = CheckState.Checked;
      this.mm_cb.Location = new Point(13, 135);
      this.mm_cb.Name = "mm_cb";
      this.mm_cb.Size = new Size(115, 17);
      this.mm_cb.TabIndex = 4;
      this.mm_cb.Text = "Mumbo's Mountain";
      this.mm_cb.UseVisualStyleBackColor = true;
      this.mm_cb.CheckedChanged += new EventHandler(this.mm_cb_CheckedChanged);
      this.ttc_cb.AutoSize = true;
      this.ttc_cb.Checked = true;
      this.ttc_cb.CheckState = CheckState.Checked;
      this.ttc_cb.Location = new Point(13, 158);
      this.ttc_cb.Name = "ttc_cb";
      this.ttc_cb.Size = new Size((int) sbyte.MaxValue, 17);
      this.ttc_cb.TabIndex = 5;
      this.ttc_cb.Text = "Treasure Trove Cove";
      this.ttc_cb.UseVisualStyleBackColor = true;
      this.ttc_cb.CheckedChanged += new EventHandler(this.ttc_cb_CheckedChanged);
      this.gv_cb.AutoSize = true;
      this.gv_cb.Checked = true;
      this.gv_cb.CheckState = CheckState.Checked;
      this.gv_cb.Location = new Point(157, 135);
      this.gv_cb.Name = "gv_cb";
      this.gv_cb.Size = new Size(86, 17);
      this.gv_cb.TabIndex = 6;
      this.gv_cb.Text = "Gobi's Valley";
      this.gv_cb.UseVisualStyleBackColor = true;
      this.gv_cb.CheckedChanged += new EventHandler(this.gv_cb_CheckedChanged);
      this.mmm_cb.AutoSize = true;
      this.mmm_cb.Checked = true;
      this.mmm_cb.CheckState = CheckState.Checked;
      this.mmm_cb.Location = new Point(157, 158);
      this.mmm_cb.Name = "mmm_cb";
      this.mmm_cb.Size = new Size(131, 17);
      this.mmm_cb.TabIndex = 7;
      this.mmm_cb.Text = "Mad Monster Mansion";
      this.mmm_cb.UseVisualStyleBackColor = true;
      this.mmm_cb.CheckedChanged += new EventHandler(this.mmm_cb_CheckedChanged);
      this.gen_cb.AutoSize = true;
      this.gen_cb.Checked = true;
      this.gen_cb.CheckState = CheckState.Checked;
      this.gen_cb.Location = new Point(305, 158);
      this.gen_cb.Name = "gen_cb";
      this.gen_cb.Size = new Size(63, 17);
      this.gen_cb.TabIndex = 8;
      this.gen_cb.Text = "General";
      this.gen_cb.UseVisualStyleBackColor = true;
      this.gen_cb.CheckedChanged += new EventHandler(this.gen_cb_CheckedChanged);
      this.sm_cb.AutoSize = true;
      this.sm_cb.Checked = true;
      this.sm_cb.CheckState = CheckState.Checked;
      this.sm_cb.Location = new Point(12, 112);
      this.sm_cb.Name = "sm_cb";
      this.sm_cb.Size = new Size(99, 17);
      this.sm_cb.TabIndex = 9;
      this.sm_cb.Text = "Spiral Mountain";
      this.sm_cb.UseVisualStyleBackColor = true;
      this.sm_cb.CheckedChanged += new EventHandler(this.sm_cb_CheckedChanged);
      this.cut_cb.AutoSize = true;
      this.cut_cb.Checked = true;
      this.cut_cb.CheckState = CheckState.Checked;
      this.cut_cb.Location = new Point(305, 181);
      this.cut_cb.Name = "cut_cb";
      this.cut_cb.Size = new Size(76, 17);
      this.cut_cb.TabIndex = 10;
      this.cut_cb.Text = "Cutscenes";
      this.cut_cb.UseVisualStyleBackColor = true;
      this.cut_cb.CheckedChanged += new EventHandler(this.cut_cb_CheckedChanged);
      this.gl_cb.AutoSize = true;
      this.gl_cb.Checked = true;
      this.gl_cb.CheckState = CheckState.Checked;
      this.gl_cb.Location = new Point(12, 89);
      this.gl_cb.Name = "gl_cb";
      this.gl_cb.Size = new Size(84, 17);
      this.gl_cb.TabIndex = 11;
      this.gl_cb.Text = "Grunty's Lair";
      this.gl_cb.UseVisualStyleBackColor = true;
      this.gl_cb.CheckedChanged += new EventHandler(this.gl_cb_CheckedChanged);
      this.fb_cb.AutoSize = true;
      this.fb_cb.Checked = true;
      this.fb_cb.CheckState = CheckState.Checked;
      this.fb_cb.Location = new Point(305, 112);
      this.fb_cb.Name = "fb_cb";
      this.fb_cb.Size = new Size(162, 17);
      this.fb_cb.TabIndex = 12;
      this.fb_cb.Text = "Final Battle / Grunty Squares";
      this.fb_cb.UseVisualStyleBackColor = true;
      this.fb_cb.CheckedChanged += new EventHandler(this.fb_cb_CheckedChanged);
      this.ff_cb.AutoSize = true;
      this.ff_cb.Checked = true;
      this.ff_cb.CheckState = CheckState.Checked;
      this.ff_cb.Location = new Point(305, 135);
      this.ff_cb.Name = "ff_cb";
      this.ff_cb.Size = new Size(86, 17);
      this.ff_cb.TabIndex = 13;
      this.ff_cb.Text = "Furnace Fun";
      this.ff_cb.UseVisualStyleBackColor = true;
      this.ff_cb.CheckedChanged += new EventHandler(this.ff_cb_CheckedChanged);
      this.ccw_cb.AutoSize = true;
      this.ccw_cb.Checked = true;
      this.ccw_cb.CheckState = CheckState.Checked;
      this.ccw_cb.Location = new Point(305, 89);
      this.ccw_cb.Name = "ccw_cb";
      this.ccw_cb.Size = new Size(111, 17);
      this.ccw_cb.TabIndex = 14;
      this.ccw_cb.Text = "Click Clock Wood";
      this.ccw_cb.UseVisualStyleBackColor = true;
      this.ccw_cb.CheckedChanged += new EventHandler(this.ccw_cb_CheckedChanged);
      this.cc_cb.AutoSize = true;
      this.cc_cb.Checked = true;
      this.cc_cb.CheckState = CheckState.Checked;
      this.cc_cb.Location = new Point(13, 181);
      this.cc_cb.Name = "cc_cb";
      this.cc_cb.Size = new Size(106, 17);
      this.cc_cb.TabIndex = 15;
      this.cc_cb.Text = "Clanker's Cavern";
      this.cc_cb.UseVisualStyleBackColor = true;
      this.cc_cb.CheckedChanged += new EventHandler(this.cc_cb_CheckedChanged);
      this.bgs_cb.AutoSize = true;
      this.bgs_cb.Checked = true;
      this.bgs_cb.CheckState = CheckState.Checked;
      this.bgs_cb.Location = new Point(157, 89);
      this.bgs_cb.Name = "bgs_cb";
      this.bgs_cb.Size = new Size(123, 17);
      this.bgs_cb.TabIndex = 16;
      this.bgs_cb.Text = "Bubblegloop Swamp";
      this.bgs_cb.UseVisualStyleBackColor = true;
      this.bgs_cb.CheckedChanged += new EventHandler(this.bgs_cb_CheckedChanged);
      this.fp_cb.AutoSize = true;
      this.fp_cb.Checked = true;
      this.fp_cb.CheckState = CheckState.Checked;
      this.fp_cb.Location = new Point(157, 112);
      this.fp_cb.Name = "fp_cb";
      this.fp_cb.Size = new Size(102, 17);
      this.fp_cb.TabIndex = 17;
      this.fp_cb.Text = "Freezeezy Peak";
      this.fp_cb.UseVisualStyleBackColor = true;
      this.fp_cb.CheckedChanged += new EventHandler(this.fp_cb_CheckedChanged);
      this.rbb_cb.AutoSize = true;
      this.rbb_cb.Checked = true;
      this.rbb_cb.CheckState = CheckState.Checked;
      this.rbb_cb.Location = new Point(157, 182);
      this.rbb_cb.Name = "rbb_cb";
      this.rbb_cb.Size = new Size(111, 17);
      this.rbb_cb.TabIndex = 18;
      this.rbb_cb.Text = "Rusty Bucket Bay";
      this.rbb_cb.UseVisualStyleBackColor = true;
      this.rbb_cb.CheckedChanged += new EventHandler(this.rbb_cb_CheckedChanged);
      this.search_btn.Location = new Point(383, 214);
      this.search_btn.Name = "search_btn";
      this.search_btn.Size = new Size(75, 23);
      this.search_btn.TabIndex = 19;
      this.search_btn.Text = "Search";
      this.search_btn.UseVisualStyleBackColor = true;
      this.search_btn.Click += new EventHandler(this.search_btn_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(471, 249);
      this.Controls.Add((Control) this.search_btn);
      this.Controls.Add((Control) this.rbb_cb);
      this.Controls.Add((Control) this.fp_cb);
      this.Controls.Add((Control) this.bgs_cb);
      this.Controls.Add((Control) this.cc_cb);
      this.Controls.Add((Control) this.ccw_cb);
      this.Controls.Add((Control) this.ff_cb);
      this.Controls.Add((Control) this.fb_cb);
      this.Controls.Add((Control) this.gl_cb);
      this.Controls.Add((Control) this.cut_cb);
      this.Controls.Add((Control) this.sm_cb);
      this.Controls.Add((Control) this.gen_cb);
      this.Controls.Add((Control) this.mmm_cb);
      this.Controls.Add((Control) this.gv_cb);
      this.Controls.Add((Control) this.ttc_cb);
      this.Controls.Add((Control) this.mm_cb);
      this.Controls.Add((Control) this.all_cb);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.text_tb);
      this.Controls.Add((Control) this.label1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchForm";
      this.ShowIcon = false;
      this.Text = "Search";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
