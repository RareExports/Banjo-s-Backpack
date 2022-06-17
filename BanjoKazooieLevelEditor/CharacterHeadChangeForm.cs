// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.CharacterHeadChangeForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class CharacterHeadChangeForm : Form
  {
    public int headID;
    private List<Sprite> sprites;
    private IContainer components;
    private Button ok_btn;
    private DataGridView dgv_heads;

    public CharacterHeadChangeForm(List<Sprite> sprites_)
    {
      this.InitializeComponent();
      this.sprites = sprites_;
      this.dgv_heads.Rows.Clear();
      this.dgv_heads.Columns.Clear();
      this.dgv_heads.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.dgv_heads.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      this.dgv_heads.AutoGenerateColumns = false;
      this.dgv_heads.RowHeadersVisible = false;
      this.dgv_heads.MultiSelect = false;
      DataGridViewColumnCollection columns1 = this.dgv_heads.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn1 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn1.HeaderText = "ID";
      viewTextBoxColumn1.ReadOnly = true;
      viewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn1.FillWeight = 25f;
      columns1.Add((DataGridViewColumn) viewTextBoxColumn1);
      DataGridViewColumnCollection columns2 = this.dgv_heads.Columns;
      DataGridViewTextBoxColumn viewTextBoxColumn2 = new DataGridViewTextBoxColumn();
      viewTextBoxColumn2.HeaderText = "Name";
      viewTextBoxColumn2.ReadOnly = true;
      viewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
      viewTextBoxColumn2.FillWeight = 25f;
      columns2.Add((DataGridViewColumn) viewTextBoxColumn2);
      for (int index = 0; index < this.sprites.Count; ++index)
        this.dgv_heads.Rows.Add((object) ("0x" + this.sprites[index].id.ToString("x")), (object) this.sprites[index].name);
    }

    private void ok_btn_Click(object sender, EventArgs e) => this.Close();

    private void dgv_heads_CellClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.RowIndex == -1)
        return;
      try
      {
        this.headID = int.Parse(this.dgv_heads.Rows[e.RowIndex].Cells[0].Value.ToString().Substring(2), NumberStyles.AllowHexSpecifier);
      }
      catch
      {
      }
    }

    private void dgv_heads_CellDoubleClick(object sender, DataGridViewCellEventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.ok_btn = new Button();
      this.dgv_heads = new DataGridView();
      ((ISupportInitialize) this.dgv_heads).BeginInit();
      this.SuspendLayout();
      this.ok_btn.Location = new Point(101, 468);
      this.ok_btn.Name = "ok_btn";
      this.ok_btn.Size = new Size(75, 23);
      this.ok_btn.TabIndex = 1;
      this.ok_btn.Text = "OK";
      this.ok_btn.UseVisualStyleBackColor = true;
      this.ok_btn.Click += new EventHandler(this.ok_btn_Click);
      this.dgv_heads.AllowUserToAddRows = false;
      this.dgv_heads.AllowUserToDeleteRows = false;
      this.dgv_heads.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgv_heads.Location = new Point(12, 12);
      this.dgv_heads.Name = "dgv_heads";
      this.dgv_heads.ReadOnly = true;
      this.dgv_heads.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dgv_heads.Size = new Size(164, 450);
      this.dgv_heads.TabIndex = 2;
      this.dgv_heads.CellDoubleClick += new DataGridViewCellEventHandler(this.dgv_heads_CellDoubleClick);
      this.dgv_heads.CellClick += new DataGridViewCellEventHandler(this.dgv_heads_CellClick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(188, 502);
      this.Controls.Add((Control) this.dgv_heads);
      this.Controls.Add((Control) this.ok_btn);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (CharacterHeadChangeForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Change Head";
      ((ISupportInitialize) this.dgv_heads).EndInit();
      this.ResumeLayout(false);
    }
  }
}
