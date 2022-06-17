// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.RomBuilder
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  internal class RomBuilder
  {
    public byte[] rom = new byte[0];
    public byte[] saveAsRom = new byte[67108864];
    public string outDir = "";
    private List<ASMPointer> eorPointers = new List<ASMPointer>();

    public void correctModelFile(string file)
    {
      BinaryReader binaryReader = new BinaryReader((Stream) File.Open(file, FileMode.Open));
      int length = (int) binaryReader.BaseStream.Length;
      byte[] buffer = new byte[length];
      binaryReader.BaseStream.Read(buffer, 0, length);
      binaryReader.Close();
      bool flag1 = false;
      bool flag2 = false;
      for (int index = buffer.Length - 9; index > 0 && !flag1; --index)
      {
        if (buffer[index] == (byte) 0 && buffer[index + 1] == (byte) 0 && buffer[index + 2] == (byte) 0 && buffer[index + 3] == (byte) 13 && buffer[index + 4] == (byte) 0 && buffer[index + 5] == (byte) 0 && buffer[index + 6] == (byte) 0 && buffer[index + 7] == (byte) 0)
          flag1 = true;
        if (buffer[index] == (byte) 0 && buffer[index + 1] == (byte) 0 && buffer[index + 2] == (byte) 0 && buffer[index + 3] == (byte) 13 && buffer[index + 4] == (byte) 0 && buffer[index + 5] == (byte) 0 && buffer[index + 6] == (byte) 0 && buffer[index + 7] == (byte) 40)
        {
          buffer[index + 7] = (byte) 0;
          flag1 = true;
          flag2 = true;
        }
      }
      if (!flag2)
        return;
      FileStream output = File.Create(file);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
      binaryWriter.Write(buffer);
      binaryWriter.Close();
      output.Close();
    }

    public void GVFix(string file)
    {
      BinaryReader binaryReader = new BinaryReader((Stream) File.Open(file, FileMode.Open));
      int length = (int) binaryReader.BaseStream.Length;
      byte[] buffer1 = new byte[length];
      binaryReader.BaseStream.Read(buffer1, 0, length);
      binaryReader.Close();
      int num1 = (int) buffer1[4] * 16777216 + (int) buffer1[5] * 65536 + (int) buffer1[6] * 256 + (int) buffer1[7];
      int num2 = (int) buffer1[36] * 16777216 + (int) buffer1[37] * 65536 + (int) buffer1[38] * 256 + (int) buffer1[39];
      if (num1 == num2 || num2 == 0)
      {
        int index1 = num1;
        byte[] buffer2 = new byte[buffer1.Length + 24];
        for (int index2 = 0; index2 < index1; ++index2)
          buffer2[index2] = buffer1[index2];
        buffer2[index1] = (byte) 0;
        buffer2[index1 + 1] = (byte) 1;
        buffer2[index1 + 2] = (byte) 1;
        buffer2[index1 + 3] = (byte) 48;
        buffer2[index1 + 4] = (byte) 0;
        buffer2[index1 + 5] = (byte) 0;
        byte[] byteArray = this.Int32ToByteArray(num1 + 24);
        buffer2[36] = buffer1[4];
        buffer2[37] = buffer1[5];
        buffer2[38] = buffer1[6];
        buffer2[39] = buffer1[7];
        buffer2[4] = byteArray[0];
        buffer2[5] = byteArray[1];
        buffer2[6] = byteArray[2];
        buffer2[7] = byteArray[3];
        for (int index3 = index1; index3 < buffer1.Length; ++index3)
          buffer2[index3 + 24] = buffer1[index3];
        FileStream output = File.Create(Application.StartupPath + "//out//gv-b.bin");
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(buffer2);
        binaryWriter.Close();
        output.Close();
      }
      else
      {
        FileStream output = File.Create(Application.StartupPath + "//out//gv-b.bin");
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        binaryWriter.Write(buffer1);
        binaryWriter.Close();
        output.Close();
      }
    }

    private int getCompressedFileSize(int l)
    {
      byte[] numArray = this.arrayCopy(l, 1048576);
      GECompression geCompression = new GECompression();
      byte[] Buffer = numArray;
      geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
      int compressedSize = 0;
      int fileSize = 0;
      geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
      return compressedSize;
    }

    public void extendRom()
    {
      int index1 = 24216;
      int num1 = 16777216;
      int num2 = num1 - 68816;
      try
      {
        for (; index1 < 68816; index1 += 8)
        {
          int num3 = (int) this.rom[index1] * 16777216 + (int) this.rom[index1 + 1] * 65536 + (int) this.rom[index1 + 2] * 256 + (int) this.rom[index1 + 3];
          int num4;
          for (num4 = (int) this.rom[index1 + 8] * 16777216 + (int) this.rom[index1 + 1 + 8] * 65536 + (int) this.rom[index1 + 2 + 8] * 256 + (int) this.rom[index1 + 3 + 8]; num4 - num3 <= 0 && index1 < 68808; num4 = (int) this.rom[index1 + 8] * 16777216 + (int) this.rom[index1 + 1 + 8] * 65536 + (int) this.rom[index1 + 2 + 8] * 256 + (int) this.rom[index1 + 3 + 8])
          {
            this.rom[index1] = (byte) (num2 >> 24);
            this.rom[index1 + 1] = (byte) (num2 >> 16);
            this.rom[index1 + 2] = (byte) (num2 >> 8);
            this.rom[index1 + 3] = (byte) num2;
            index1 += 8;
            num3 = (int) this.rom[index1] * 16777216 + (int) this.rom[index1 + 1] * 65536 + (int) this.rom[index1 + 2] * 256 + (int) this.rom[index1 + 3];
          }
          if (index1 < 68808)
          {
            int num5 = num4 + 68816;
            int num6 = num3 + 68816;
            for (int index2 = 0; index2 < num5 - num6; ++index2)
              this.rom[num1 + index2] = this.rom[num6 + index2];
            this.rom[index1] = (byte) (num2 >> 24);
            this.rom[index1 + 1] = (byte) (num2 >> 16);
            this.rom[index1 + 2] = (byte) (num2 >> 8);
            this.rom[index1 + 3] = (byte) num2;
            num2 = num1 + (num5 - num6) - 68816;
            num1 += num5 - num6;
          }
          else
          {
            this.rom[index1] = (byte) (num2 >> 24);
            this.rom[index1 + 1] = (byte) (num2 >> 16);
            this.rom[index1 + 2] = (byte) (num2 >> 8);
            this.rom[index1 + 3] = (byte) num2;
          }
        }
      }
      catch (Exception ex)
      {
      }
      int num7 = 945584;
      int num8 = 0;
      int index3 = 15831632;
      for (; num8 < num7; ++num8)
      {
        this.rom[num1 + num8] = this.rom[index3];
        ++index3;
      }
      int num9 = 15831632;
      foreach (ASMPointer eorPointer in this.eorPointers)
      {
        int pntr = this.toPNTR(eorPointer.u, eorPointer.l) - num9 + num1;
        this.pntrToRom(eorPointer.u, eorPointer.l, pntr);
      }
      for (int index4 = num1 + num7; index4 < 67108864; ++index4)
        this.rom[index4] = byte.MaxValue;
    }

    public void populateEORPointers()
    {
      this.eorPointers.Clear();
      this.eorPointers.Add(new ASMPointer(4218, 4226));
      this.eorPointers.Add(new ASMPointer(4222, 4230));
      this.eorPointers.Add(new ASMPointer(10234, 10274));
      this.eorPointers.Add(new ASMPointer(10238, 10278));
      this.eorPointers.Add(new ASMPointer(10242, 10282));
      this.eorPointers.Add(new ASMPointer(10246, 10286));
      this.eorPointers.Add(new ASMPointer(10250, 10290));
      this.eorPointers.Add(new ASMPointer(10254, 10294));
      this.eorPointers.Add(new ASMPointer(10258, 10298));
      this.eorPointers.Add(new ASMPointer(10262, 10302));
      this.eorPointers.Add(new ASMPointer(10266, 10306));
      this.eorPointers.Add(new ASMPointer(10270, 10310));
      this.eorPointers.Add(new ASMPointer(10354, 10394));
      this.eorPointers.Add(new ASMPointer(10358, 10398));
      this.eorPointers.Add(new ASMPointer(10362, 10402));
      this.eorPointers.Add(new ASMPointer(10366, 10406));
      this.eorPointers.Add(new ASMPointer(10370, 10410));
      this.eorPointers.Add(new ASMPointer(10374, 10414));
      this.eorPointers.Add(new ASMPointer(10378, 10418));
      this.eorPointers.Add(new ASMPointer(10382, 10422));
      this.eorPointers.Add(new ASMPointer(10386, 10426));
      this.eorPointers.Add(new ASMPointer(10390, 10430));
      this.eorPointers.Add(new ASMPointer(10474, 10514));
      this.eorPointers.Add(new ASMPointer(10478, 10518));
      this.eorPointers.Add(new ASMPointer(10482, 10522));
      this.eorPointers.Add(new ASMPointer(10486, 10526));
      this.eorPointers.Add(new ASMPointer(10490, 10530));
      this.eorPointers.Add(new ASMPointer(10494, 10534));
      this.eorPointers.Add(new ASMPointer(10498, 10538));
      this.eorPointers.Add(new ASMPointer(10502, 10542));
      this.eorPointers.Add(new ASMPointer(10506, 10546));
      this.eorPointers.Add(new ASMPointer(10510, 10550));
    }

    public int getNextPointer(int pntr_)
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

    public RomBuilder()
    {
    }

    public RomBuilder(byte[] rom_)
    {
      this.rom = new byte[67108864];
      for (int index = 0; index < rom_.Length; ++index)
        this.rom[index] = rom_[index];
      for (int index = 0; index < (int) rom_[index]; ++index)
        this.saveAsRom[index] = rom_[index];
      this.populateEORPointers();
    }

    public void insertAsset(byte[] file, int loc)
    {
      for (int index = 0; index < file.Length; ++index)
        this.rom[loc + index] = file[index];
    }

    public void saveAsMode()
    {
      this.createSaveAsRom();
      this.rom = this.saveAsRom;
    }

    private void createSaveAsRom()
    {
      for (int index = 0; index < this.rom.Length; ++index)
        this.saveAsRom[index] = this.rom[index];
    }

    public void updateLevelHeader(
      BoundingBox setup,
      BoundingBox level,
      List<byte> F9CAE0,
      int F9CAE0_location_,
      int compressedSize,
      int sceneID,
      bool saveAs)
    {
      level.largeX = (int) Math.Floor((double) level.largeX / 1000.0);
      level.largeY = (int) Math.Floor((double) level.largeY / 1000.0);
      level.largeZ = (int) Math.Floor((double) level.largeZ / 1000.0);
      level.smallX = (int) Math.Floor((double) level.smallX / 1000.0);
      level.smallY = (int) Math.Floor((double) level.smallY / 1000.0);
      level.smallZ = (int) Math.Floor((double) level.smallZ / 1000.0);
      int number1 = setup.smallX - level.smallX;
      int number2 = setup.smallY - level.smallY;
      int number3 = setup.smallZ - level.smallZ;
      int number4 = setup.largeX - level.largeX;
      int number5 = setup.largeY - level.largeY;
      int number6 = setup.largeZ - level.largeZ;
      byte[] byteArray1 = this.Int32ToByteArray(number1);
      byte[] byteArray2 = this.Int32ToByteArray(number2);
      byte[] byteArray3 = this.Int32ToByteArray(number3);
      byte[] byteArray4 = this.Int32ToByteArray(number4);
      byte[] byteArray5 = this.Int32ToByteArray(number5);
      byte[] byteArray6 = this.Int32ToByteArray(number6);
      int num = 0;
      for (int index = 30288; index < 33412 && num == 0; index += 24)
      {
        if ((int) F9CAE0[index] == (int) (byte) (sceneID >> 8) && (int) F9CAE0[index + 1] == (int) (byte) sceneID)
          num = index;
      }
      byte[] numArray = new byte[12]
      {
        F9CAE0[num + 6],
        F9CAE0[num + 7],
        F9CAE0[num + 8],
        F9CAE0[num + 9],
        F9CAE0[num + 10],
        F9CAE0[num + 11],
        F9CAE0[num + 12],
        F9CAE0[num + 13],
        F9CAE0[num + 14],
        F9CAE0[num + 15],
        F9CAE0[num + 16],
        F9CAE0[num + 17]
      };
      F9CAE0[num + 6] = byteArray1[2];
      F9CAE0[num + 7] = byteArray1[3];
      F9CAE0[num + 8] = byteArray2[2];
      F9CAE0[num + 9] = byteArray2[3];
      F9CAE0[num + 10] = byteArray3[2];
      F9CAE0[num + 11] = byteArray3[3];
      F9CAE0[num + 12] = byteArray4[2];
      F9CAE0[num + 13] = byteArray4[3];
      F9CAE0[num + 14] = byteArray5[2];
      F9CAE0[num + 15] = byteArray5[3];
      F9CAE0[num + 16] = byteArray6[2];
      F9CAE0[num + 17] = byteArray6[3];
      FileStream output = File.Create(this.outDir + "F9CAE0.bin");
      BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
      binaryWriter.Write(F9CAE0.ToArray(), 0, F9CAE0.Count<byte>());
      binaryWriter.Close();
      output.Close();
      this.insertDecompressedFile(this.outDir, "F9CAE0.bin", F9CAE0_location_, compressedSize, true);
      if (!saveAs)
        return;
      for (int index = 0; index < 12; ++index)
        F9CAE0[num + 6 + index] = numArray[index];
    }

    private byte[] arrayCopy(int l)
    {
      byte[] numArray = new byte[this.toPNTR(10246, 10286) - l];
      for (int index = 0; index < numArray.Length; ++index)
        numArray[index] = this.rom[l + index];
      return numArray;
    }

    private byte[] arrayCopy(int l, int length)
    {
      byte[] numArray = new byte[length];
      for (int index = 0; index < numArray.Length && index < length; ++index)
        numArray[index] = this.rom[l + index];
      return numArray;
    }

    public byte[] Int32ToByteArray(int number) => new byte[4]
    {
      (byte) (number >> 24),
      (byte) (number >> 16),
      (byte) (number >> 8),
      (byte) (number & (int) byte.MaxValue)
    };

    public int ByteArrayToInt32(byte[] b_) => (int) b_[0] * 16777216 + (int) b_[1] * 65536 + (int) b_[2] * 256 + (int) b_[3];

    public void updateAllPointers(int index, int difference, bool special)
    {
      if (special)
      {
        for (int index1 = 0; index1 < this.eorPointers.Count; ++index1)
        {
          int pntr1 = this.toPNTR(this.eorPointers[index1].u, this.eorPointers[index1].l);
          if (pntr1 > index)
          {
            int pntr2 = pntr1 + difference;
            if (pntr2 % 8 != 0)
            {
              int num1 = 0;
              while ((pntr2 + num1) % 8 != 0)
                ++num1;
              int num2 = pntr2;
              for (int index2 = (int) (66060288L - 1L - (long) num1); index2 >= num2; --index2)
                this.rom[index2 + num1] = this.rom[index2];
              for (int index3 = pntr2; index3 < pntr2 + num1; ++index3)
                this.rom[index3] = (byte) 0;
              pntr2 += num1;
              difference += num1;
            }
            this.pntrToRom(this.eorPointers[index1].u, this.eorPointers[index1].l, pntr2);
          }
        }
      }
      else
      {
        for (int index4 = index + 8; index4 < 68816; index4 += 8)
        {
          int num3 = (int) this.rom[index4] * 16777216 + (int) this.rom[index4 + 1] * 65536 + (int) this.rom[index4 + 2] * 256 + (int) this.rom[index4 + 3];
          if (index4 < 68816)
          {
            int num4 = num3 + difference;
            this.rom[index4] = (byte) (num4 >> 24);
            this.rom[index4 + 1] = (byte) (num4 >> 16);
            this.rom[index4 + 2] = (byte) (num4 >> 8);
            this.rom[index4 + 3] = (byte) num4;
          }
        }
        foreach (ASMPointer eorPointer in this.eorPointers)
        {
          int pntr = this.toPNTR(eorPointer.u, eorPointer.l) + difference;
          this.pntrToRom(eorPointer.u, eorPointer.l, pntr);
        }
      }
    }

    private int toPNTR(int u, int l) => (int) this.rom[u] * 16777216 + (int) this.rom[u + 1] * 65536 + (int) (short) ((int) this.rom[l] * 256 + (int) this.rom[l + 1]);

    private void pntrToRom(int u, int l, int pntr)
    {
      int num1 = (pntr & 268369920) >> 16;
      int num2 = pntr & (int) ushort.MaxValue;
      if (num2 >= 32768)
        ++num1;
      pntr = (num1 << 16) + num2;
      byte[] byteArray = this.Int32ToByteArray(pntr);
      this.rom[u] = byteArray[0];
      this.rom[u + 1] = byteArray[1];
      this.rom[l] = byteArray[2];
      this.rom[l + 1] = byteArray[3];
    }

    public int insertDecompressedFile(
      string outDir,
      string file,
      int location,
      int originalSize,
      bool special)
    {
      int num1 = 0;
      if (!special)
      {
        originalSize = 0;
        while (originalSize == 0)
        {
          int nextPointer = this.getNextPointer(location);
          int num2 = (int) this.rom[location] * 16777216 + (int) this.rom[location + 1] * 65536 + (int) this.rom[location + 2] * 256 + (int) this.rom[location + 3];
          int num3 = num2;
          originalSize = nextPointer - num3;
          num1 = num2 + 68816;
        }
      }
      GECompression geCompression = new GECompression();
      geCompression.SetPath(Directory.GetCurrentDirectory() + "\\out\\");
      if (special)
        geCompression.padding = false;
      if (file.Contains(".\\resources\\"))
      {
        string inputFile = file;
        file = inputFile.Replace(".\\resources\\", "");
        geCompression.CompressGZipFile(inputFile, outDir + file + ".1172", false);
      }
      else
        geCompression.CompressGZipFile(outDir + file, outDir + file + ".1172", false);
      BinaryReader binaryReader = new BinaryReader((Stream) File.Open(outDir + file + ".1172", FileMode.Open));
      int length = (int) binaryReader.BaseStream.Length;
      byte[] buffer = new byte[length];
      binaryReader.BaseStream.Read(buffer, 0, length);
      binaryReader.Close();
      long difference = (long) (length - originalSize);
      int num4 = 66060288;
      if (difference > 0L)
      {
        int num5 = location + originalSize;
        if (!special)
          num5 = num1 + originalSize;
        for (int index = (int) ((long) (num4 - 1) - difference); index >= num5; --index)
          this.rom[(long) index + difference] = this.rom[index];
        for (int index = 0; index < buffer.Length; ++index)
        {
          if (!special)
            this.rom[num1 + index] = buffer[index];
          else
            this.rom[location + index] = buffer[index];
        }
      }
      else
      {
        int num6 = location + buffer.Length;
        if (!special)
          num6 = num1 + buffer.Length;
        int index1 = location + originalSize;
        if (!special)
          index1 = num1 + originalSize;
        for (int index2 = num6; (long) index2 < (long) num4 + difference; ++index2)
        {
          this.rom[index2] = this.rom[index1];
          ++index1;
        }
        for (int index3 = num4 + (int) difference; index3 < num4; ++index3)
          this.rom[index3] = byte.MaxValue;
        for (int index4 = 0; index4 < buffer.Length; ++index4)
        {
          if (!special)
            this.rom[num1 + index4] = buffer[index4];
          else
            this.rom[location + index4] = buffer[index4];
        }
      }
      this.updateAllPointers(location, (int) difference, special);
      return (int) difference;
    }

    public int setModelFile(
      int F9CAE0_file_loc,
      int size,
      int sceneID,
      int pntr,
      bool b,
      bool clear)
    {
      GECompression geCompression = new GECompression();
      int fileSize = 0;
      int compressedSize = 0;
      byte[] Buffer = this.arrayCopy(F9CAE0_file_loc, size);
      geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
      byte[] numArray = geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
      int num1 = 0;
      for (int index = 30288; index < 33412 && num1 == 0; index += 24)
      {
        if ((int) numArray[index] == (int) (byte) (sceneID >> 8) && (int) numArray[index + 1] == (int) (byte) sceneID)
          num1 = index;
      }
      int num2 = (pntr - 24216) / 8;
      if (!b && !clear)
      {
        numArray[num1 + 2] = (byte) (num2 >> 8);
        numArray[num1 + 3] = (byte) num2;
      }
      if (!b & clear)
      {
        numArray[num1 + 2] = (byte) 0;
        numArray[num1 + 3] = (byte) 0;
      }
      if (b && !clear)
      {
        numArray[num1 + 4] = (byte) (num2 >> 8);
        numArray[num1 + 5] = (byte) num2;
      }
      if (b & clear)
      {
        numArray[num1 + 4] = (byte) 0;
        numArray[num1 + 5] = (byte) 0;
      }
      FileStream output = File.Create(this.outDir + "F9CAE0.bin");
      BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
      binaryWriter.Write(numArray, 0, ((IEnumerable<byte>) numArray).Count<byte>());
      binaryWriter.Close();
      output.Close();
      return this.insertDecompressedFile(this.outDir, "F9CAE0.bin", F9CAE0_file_loc, compressedSize, true);
    }

    public bool getModelFile(int F9CAE0_file_loc, int size, int sceneID, int pntr, bool b)
    {
      bool modelFile = true;
      GECompression geCompression = new GECompression();
      int fileSize = 0;
      int compressedSize = 0;
      byte[] Buffer = this.arrayCopy(F9CAE0_file_loc, size);
      geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
      byte[] numArray = geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
      int num = 0;
      for (int index = 30288; index < 33412 && num == 0; index += 24)
      {
        if ((int) numArray[index] == (int) (byte) (sceneID >> 8) && (int) numArray[index + 1] == (int) (byte) sceneID)
          num = index;
      }
      if (!b && numArray[num + 2] == (byte) 0 && numArray[num + 3] == (byte) 0)
        modelFile = false;
      if (b && numArray[num + 4] == (byte) 0 && numArray[num + 5] == (byte) 0)
        modelFile = false;
      return modelFile;
    }
  }
}
