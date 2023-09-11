// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.MidiToolForm
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace BanjoKazooieLevelEditor
{
  public class MidiToolForm : Form
  {
    private List<BKMidi> midis = new List<BKMidi>();
    private byte[] rom;
    private string outDir = "";
    private string inFile = "";
    public List<int> updatedMidis = new List<int>();
    private IContainer components;
    private ListView midis_lv;
    private Button export_btn;
    private CheckBox checkBoxUseRepeaters;
    private TextBox LoopPoint_tb;
    private CheckBox checkBoxLoop;
    private Label label1;
    private GroupBox groupBox1;
    private Button import_btn;
    private OpenFileDialog openFileDialog1;

    public MidiToolForm(ref byte[] rom_, string outDir_)
    {
      this.InitializeComponent();
      this.readMidisXML();
      this.DisplayFiles();
      this.rom = rom_;
      this.outDir = outDir_;
    }

    private void DisplayFiles()
    {
      this.midis_lv.View = View.Details;
      this.midis_lv.Columns.Add("Title", -2, HorizontalAlignment.Center);
      for (int index = 0; index < this.midis.Count; ++index)
        this.midis_lv.Items.Add(new ListViewItem(this.midis[index].Name));
      this.midis_lv.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.None);
      this.midis_lv.Columns[0].Width = 225;
    }

    private void readMidisXML()
    {
      try
      {
        XmlTextReader xmlTextReader = new XmlTextReader(".\\resources\\midi.xml");
        while (xmlTextReader.Read())
        {
          string name1 = xmlTextReader.Name;
          BKMidi bkMidi = new BKMidi(0, "", 0);
          if (name1 == "midi")
          {
            string str = xmlTextReader.GetAttribute("name") == null ? "" : xmlTextReader.GetAttribute("name");
            int id = xmlTextReader.GetAttribute("id") == null ? 0 : (int) Convert.ToInt16(xmlTextReader.GetAttribute("id"), 16);
            int num = xmlTextReader.GetAttribute("pointer") == null ? 0 : Convert.ToInt32(xmlTextReader.GetAttribute("pointer"), 16);
            string name2 = str;
            int pntr = num;
            this.midis.Add(new BKMidi(id, name2, pntr));
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void export_btn_Click(object sender, EventArgs e)
    {
      if (this.midis_lv.SelectedIndices.Count == 0)
        return;
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "Midi Files (.mid;.midi)|*.mid;*.midi";
      if (saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        byte[] inputMID = this.decompressFile(this.midis[this.midis_lv.SelectedIndices[0]].Pointer);
        int numberInstruments = 0;
        MidiParse.GEMidiToMidi(inputMID, inputMID.Length, saveFileDialog.FileName, ref numberInstruments);
        int num = (int) MessageBox.Show("Export Successful");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Export Failed: " + ex.ToString());
      }
    }

    private byte[] decompressFile(int pntr)
    {
      if (File.Exists(this.outDir + pntr.ToString("x")))
        return new byte[0];
      try
      {
        if (pntr == 0)
          return new byte[0];
        int num1 = (int) this.rom[pntr] * 16777216 + (int) this.rom[pntr + 1] * 65536 + (int) this.rom[pntr + 2] * 256 + (int) this.rom[pntr + 3];
        int compressedSize = this.getNextPointer(pntr) - num1;
        int num2 = num1 + 68816;
        byte[] numArray = new byte[compressedSize];
        for (int index = 0; index < compressedSize; ++index)
          numArray[index] = this.rom[num2 + index];
        GECompression geCompression = new GECompression();
        byte[] Buffer = numArray;
        geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
        int fileSize = 0;
        return geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
      }
      catch (Exception ex)
      {
        return new byte[0];
      }
    }

    private int getNextPointer(int pntr_)
    {
      int num = (int) this.rom[pntr_] * 16777216 + (int) this.rom[pntr_ + 1] * 65536 + (int) this.rom[pntr_ + 2] * 256 + (int) this.rom[pntr_ + 3];
      int nextPointer = (int) this.rom[pntr_ + 8] * 16777216 + (int) this.rom[pntr_ + 1 + 8] * 65536 + (int) this.rom[pntr_ + 2 + 8] * 256 + (int) this.rom[pntr_ + 3 + 8];
      while (num - nextPointer == 0)
      {
        nextPointer = (int) this.rom[pntr_ + 8] * 16777216 + (int) this.rom[pntr_ + 1 + 8] * 65536 + (int) this.rom[pntr_ + 2 + 8] * 256 + (int) this.rom[pntr_ + 3 + 8];
        pntr_ += 8;
      }
      return nextPointer;
    }

    private void import_btn_Click(object sender, EventArgs e)
    {
      if (this.midis_lv.SelectedIndices.Count == 0)
        return;
      this.openFileDialog1.Filter = "Midi Files (.mid;.midi)|*.mid;*.midi";
      if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
        return;
      try
      {
        if (!MidiParse.MidiToGEFormat(this.openFileDialog1.FileName, this.outDir + this.midis[this.midis_lv.SelectedIndices[0]].Pointer.ToString("x"), this.checkBoxLoop.Checked, Convert.ToUInt32(this.LoopPoint_tb.Text), this.checkBoxUseRepeaters.Checked))
        {
          int num1 = (int) MessageBox.Show("Failure");
        }
        else
        {
          this.updatedMidis.Add(this.midis[this.midis_lv.SelectedIndices[0]].Pointer);
          int num2 = (int) MessageBox.Show("Midi Converted, Rom will be updated when the form is closed");
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Could not import Midi " + ex.ToString());
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.midis_lv = new ListView();
      this.export_btn = new Button();
      this.checkBoxUseRepeaters = new CheckBox();
      this.LoopPoint_tb = new TextBox();
      this.checkBoxLoop = new CheckBox();
      this.label1 = new Label();
      this.groupBox1 = new GroupBox();
      this.import_btn = new Button();
      this.openFileDialog1 = new OpenFileDialog();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      this.midis_lv.FullRowSelect = true;
      this.midis_lv.GridLines = true;
      this.midis_lv.HideSelection = false;
      this.midis_lv.Location = new Point(12, 12);
      this.midis_lv.MultiSelect = false;
      this.midis_lv.Name = "midis_lv";
      this.midis_lv.Size = new Size(247, 358);
      this.midis_lv.TabIndex = 0;
      this.midis_lv.UseCompatibleStateImageBehavior = false;
      this.export_btn.Location = new Point(275, 133);
      this.export_btn.Name = "export_btn";
      this.export_btn.Size = new Size(195, 51);
      this.export_btn.TabIndex = 2;
      this.export_btn.Text = "Export Midi";
      this.export_btn.UseVisualStyleBackColor = true;
      this.export_btn.Click += new EventHandler(this.export_btn_Click);
      this.checkBoxUseRepeaters.AutoSize = true;
      this.checkBoxUseRepeaters.Location = new Point(10, 39);
      this.checkBoxUseRepeaters.Margin = new Padding(2);
      this.checkBoxUseRepeaters.Name = "checkBoxUseRepeaters";
      this.checkBoxUseRepeaters.Size = new Size(97, 17);
      this.checkBoxUseRepeaters.TabIndex = 8;
      this.checkBoxUseRepeaters.Text = "Use Repeaters";
      this.checkBoxUseRepeaters.UseVisualStyleBackColor = true;
      this.LoopPoint_tb.Location = new Point(129, 15);
      this.LoopPoint_tb.Margin = new Padding(2);
      this.LoopPoint_tb.Name = "LoopPoint_tb";
      this.LoopPoint_tb.Size = new Size(76, 20);
      this.LoopPoint_tb.TabIndex = 7;
      this.LoopPoint_tb.Text = "0";
      this.checkBoxLoop.AutoSize = true;
      this.checkBoxLoop.Location = new Point(10, 18);
      this.checkBoxLoop.Margin = new Padding(2);
      this.checkBoxLoop.Name = "checkBoxLoop";
      this.checkBoxLoop.Size = new Size(50, 17);
      this.checkBoxLoop.TabIndex = 6;
      this.checkBoxLoop.Text = "Loop";
      this.checkBoxLoop.UseVisualStyleBackColor = true;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(66, 19);
      this.label1.Name = "label1";
      this.label1.Size = new Size(58, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Loop Point";
      this.groupBox1.Controls.Add((Control) this.import_btn);
      this.groupBox1.Controls.Add((Control) this.checkBoxLoop);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.LoopPoint_tb);
      this.groupBox1.Controls.Add((Control) this.checkBoxUseRepeaters);
      this.groupBox1.Location = new Point(265, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(219, 115);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Import";
      this.import_btn.Location = new Point(10, 61);
      this.import_btn.Name = "import_btn";
      this.import_btn.Size = new Size(195, 44);
      this.import_btn.TabIndex = 12;
      this.import_btn.Text = "Import";
      this.import_btn.UseVisualStyleBackColor = true;
      this.import_btn.Click += new EventHandler(this.import_btn_Click);
      this.openFileDialog1.FileName = "openFileDialog1";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(496, 382);
      this.Controls.Add((Control) this.groupBox1);
      this.Controls.Add((Control) this.export_btn);
      this.Controls.Add((Control) this.midis_lv);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MidiToolForm";
      this.ShowIcon = false;
      this.Text = "Midi Tool";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
    }
  }
}
