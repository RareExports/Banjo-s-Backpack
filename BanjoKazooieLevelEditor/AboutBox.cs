// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.AboutBox
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using BanjoKazooieLevelEditor.Properties;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class AboutBox : Form
  {
    private IContainer components;
    private Label label1;
    private Label label3;
    private Label label5;
    private Label label7;
    private LinkLabel linkLabel1;
    private Label label8;
    private Label label9;
    private Label label10;
    private Label label11;
    private Label label12;
    private LinkLabel linkLabel2;

    public AboutBox()
    {
      this.InitializeComponent();
      this.linkLabel1.Links.Add(0, 40, (object) "http://www.banjosbackpack.com/");
      this.linkLabel2.Links.Add(0, 100, (object) "https://www.youtube.com/user/runehero124");
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(e.Link.LinkData.ToString());

    private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start(e.Link.LinkData.ToString());

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.label1 = new Label();
      this.label3 = new Label();
      this.label5 = new Label();
      this.label7 = new Label();
      this.linkLabel1 = new LinkLabel();
      this.label8 = new Label();
      this.label9 = new Label();
      this.label10 = new Label();
      this.label11 = new Label();
      this.label12 = new Label();
      this.linkLabel2 = new LinkLabel();
      this.SuspendLayout();
      this.label1.AutoSize = true;
      this.label1.BackColor = Color.Transparent;
      this.label1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.label1.ForeColor = Color.White;
      this.label1.Location = new Point(13, 13);
      this.label1.Name = "label1";
      this.label1.Size = new Size(279, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Banjo's Backpack Development Team";
      this.label3.AutoSize = true;
      this.label3.BackColor = Color.Transparent;
      this.label3.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label3.ForeColor = Color.White;
      this.label3.Location = new Point(13, 36);
      this.label3.Name = "label3";
      this.label3.Size = new Size(223, 15);
      this.label3.TabIndex = 2;
      this.label3.Text = "Skill - Software Developer / File Analysis";
      this.label5.AutoSize = true;
      this.label5.BackColor = Color.Transparent;
      this.label5.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label5.ForeColor = Color.White;
      this.label5.Location = new Point(12, 61);
      this.label5.Name = "label5";
      this.label5.Size = new Size(231, 15);
      this.label5.TabIndex = 4;
      this.label5.Text = "koolboyman - Rom Research / Rom Map";
      this.label7.AutoSize = true;
      this.label7.BackColor = Color.Transparent;
      this.label7.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label7.ForeColor = Color.White;
      this.label7.Location = new Point(12, 86);
      this.label7.Name = "label7";
      this.label7.Size = new Size(293, 15);
      this.label7.TabIndex = 6;
      this.label7.Text = "Subdrag - Compression/Descompression / Midi Tool";
      this.linkLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.BackColor = Color.Transparent;
      this.linkLabel1.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel1.LinkColor = Color.White;
      this.linkLabel1.Location = new Point(355, 235);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new Size(176, 17);
      this.linkLabel1.TabIndex = 7;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "http://banjosbackpack.com";
      this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
      this.label8.AutoSize = true;
      this.label8.BackColor = Color.Transparent;
      this.label8.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label8.ForeColor = Color.White;
      this.label8.Location = new Point(12, 179);
      this.label8.Name = "label8";
      this.label8.Size = new Size(56, 17);
      this.label8.TabIndex = 8;
      this.label8.Text = "Testers";
      this.label9.AutoSize = true;
      this.label9.BackColor = Color.Transparent;
      this.label9.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label9.ForeColor = Color.White;
      this.label9.Location = new Point(12, 205);
      this.label9.Name = "label9";
      this.label9.Size = new Size(265, 15);
      this.label9.TabIndex = 9;
      this.label9.Text = "Comet (wwwarea), Tee-Hee, Pokekid, jombo23";
      this.label10.AutoSize = true;
      this.label10.BackColor = Color.Transparent;
      this.label10.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label10.ForeColor = Color.White;
      this.label10.Location = new Point(12, 235);
      this.label10.Name = "label10";
      this.label10.Size = new Size(243, 15);
      this.label10.TabIndex = 10;
      this.label10.Text = "Special Thanks to Tee-Hee for the 3D icons";
      this.label11.AutoSize = true;
      this.label11.BackColor = Color.Transparent;
      this.label11.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label11.ForeColor = Color.White;
      this.label11.Location = new Point(12, 111);
      this.label11.Name = "label11";
      this.label11.Size = new Size(117, 17);
      this.label11.TabIndex = 11;
      this.label11.Text = "Object Globalizer";
      this.label12.AutoSize = true;
      this.label12.BackColor = Color.Transparent;
      this.label12.Font = new Font("Microsoft Sans Serif", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.label12.ForeColor = Color.White;
      this.label12.Location = new Point(12, 143);
      this.label12.Name = "label12";
      this.label12.Size = new Size(62, 15);
      this.label12.TabIndex = 12;
      this.label12.Text = "Runehero";
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.BackColor = Color.Transparent;
      this.linkLabel2.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.linkLabel2.LinkColor = Color.White;
      this.linkLabel2.Location = new Point(76, 142);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new Size(90, 17);
      this.linkLabel2.TabIndex = 13;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "runehero124";
      this.linkLabel2.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) Resources.banjos_backpack;
      this.BackgroundImageLayout = ImageLayout.Stretch;
      this.ClientSize = new Size(543, 256);
      this.Controls.Add((Control) this.linkLabel2);
      this.Controls.Add((Control) this.label12);
      this.Controls.Add((Control) this.label11);
      this.Controls.Add((Control) this.label10);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.linkLabel1);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AboutBox);
      this.ShowIcon = false;
      this.Text = "About";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
