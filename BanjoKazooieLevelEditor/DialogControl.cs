// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.DialogControl
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class DialogControl : UserControl
  {
    public byte imageID;
    private IContainer components;
    private PictureBox pb_character;
    private TextBox tb_text;
    private TextBox tb_group;
    private Label lbl_id;
    private Button btn_delete;

    public event CharacterHeadClick CharacterHeadClickEvent;

    public event DeleteDialog DeleteDialogEvent;

    public DialogControl(Image image, byte imageID_, string text, int group)
    {
      this.InitializeComponent();
      this.pb_character.Image = image;
      this.imageID = imageID_;
      this.tb_text.Text = text;
      this.tb_group.Text = group.ToString();
      this.lbl_id.Text = this.imageID.ToString("x");
    }

    public DialogControl(byte imageID_, string text, int group)
    {
      this.InitializeComponent();
      this.imageID = imageID_;
      this.tb_text.Text = text;
      this.tb_group.Text = group.ToString();
      this.lbl_id.Text = this.imageID.ToString("x");
    }

    public void SetImage(Image image, byte imageID_)
    {
      this.pb_character.Image = image;
      this.imageID = imageID_;
      this.lbl_id.Text = this.imageID.ToString("x");
    }

    public string GetText() => this.tb_text.Text;

    private void pb_character_Click(object sender, EventArgs e)
    {
      if (this.CharacterHeadClickEvent == null)
        return;
      this.CharacterHeadClickEvent(this);
    }

    private void btn_delete_Click(object sender, EventArgs e)
    {
      if (this.DeleteDialogEvent == null)
        return;
      this.DeleteDialogEvent(this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.pb_character = new PictureBox();
      this.tb_text = new TextBox();
      this.tb_group = new TextBox();
      this.lbl_id = new Label();
      this.btn_delete = new Button();
      ((ISupportInitialize) this.pb_character).BeginInit();
      this.SuspendLayout();
      this.pb_character.Location = new Point(3, 3);
      this.pb_character.Name = "pb_character";
      this.pb_character.Size = new Size(30, 30);
      this.pb_character.SizeMode = PictureBoxSizeMode.StretchImage;
      this.pb_character.TabIndex = 0;
      this.pb_character.TabStop = false;
      this.pb_character.Click += new EventHandler(this.pb_character_Click);
      this.tb_text.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.tb_text.CharacterCasing = CharacterCasing.Upper;
      this.tb_text.Location = new Point(39, 3);
      this.tb_text.Multiline = true;
      this.tb_text.Name = "tb_text";
      this.tb_text.Size = new Size(572, 40);
      this.tb_text.TabIndex = 1;
      this.tb_group.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.tb_group.Enabled = false;
      this.tb_group.Location = new Point(619, 3);
      this.tb_group.Name = "tb_group";
      this.tb_group.Size = new Size(20, 20);
      this.tb_group.TabIndex = 2;
      this.lbl_id.AutoSize = true;
      this.lbl_id.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lbl_id.Location = new Point(10, 37);
      this.lbl_id.Name = "lbl_id";
      this.lbl_id.Size = new Size(21, 9);
      this.lbl_id.TabIndex = 3;
      this.lbl_id.Text = "0x00";
      this.btn_delete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.btn_delete.Font = new Font("Microsoft Sans Serif", 6f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.btn_delete.Location = new Point(614, 27);
      this.btn_delete.Name = "btn_delete";
      this.btn_delete.Size = new Size(30, 16);
      this.btn_delete.TabIndex = 4;
      this.btn_delete.Text = "DEL";
      this.btn_delete.UseVisualStyleBackColor = true;
      this.btn_delete.Click += new EventHandler(this.btn_delete_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.Controls.Add((Control) this.btn_delete);
      this.Controls.Add((Control) this.lbl_id);
      this.Controls.Add((Control) this.tb_group);
      this.Controls.Add((Control) this.tb_text);
      this.Controls.Add((Control) this.pb_character);
      this.Name = "DialogControl";
      this.Size = new Size(650, 50);
      ((ISupportInitialize) this.pb_character).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
