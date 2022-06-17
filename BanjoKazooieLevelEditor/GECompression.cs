// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.GECompression
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public class GECompression
  {
    public bool padding = true;
    private uint maxByteSize = 8388608;
    public static int GOLDENEYE = 0;
    public static int PD = 1;
    public static int BANJOKAZOOIE = 2;
    public static int KILLERINSTINCT = 3;
    public static int DONKEYKONG64 = 4;
    public static int BLASTCORPS = 5;
    public static int BANJOTOOIE = 6;
    public static int DONKEYKONG64KIOSK = 7;
    public static int CONKER = 8;
    public static int TOPGEARRALLY = 9;
    public static int MILO = 10;
    public static int JFG = 11;
    public static int DKR = 12;
    public static int JFGKIOSK = 13;
    public static int MICKEYSPEEDWAY = 14;
    public static int MORTALKOMBAT = 15;
    public static int STUNTRACER64 = 16;
    public long compressed_filelen;
    private int game;
    private string mainFolder;
    private GECompression.tableEntry[] unpackTable;
    private int unpackTableIndex;
    private uint bitsCache;
    private int bitsRemain;
    private uint bytesIndex;
    private byte[] compressedBuffer;
    private int compressedBufferSize;
    private byte[] variableTable = new byte[19];
    private ushort tableSize;
    private byte fiveBits;
    private uint[] wordTable;
    private uint iterationCounter;
    private int TABLE1;
    private int TABLE2 = 1;
    private int VARIABLETABLE = 2;
    private int WORDTABLEBEGIN = 3;
    private int WORDTABLEEND = 4;
    private byte[] bt1Table1 = new byte[288]
    {
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 9,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 7,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8,
      (byte) 8
    };
    private byte[] bt1Table2 = new byte[30]
    {
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5,
      (byte) 5
    };
    private ushort[] bt12Table1S = new ushort[32]
    {
      (ushort) 3,
      (ushort) 4,
      (ushort) 5,
      (ushort) 6,
      (ushort) 7,
      (ushort) 8,
      (ushort) 9,
      (ushort) 10,
      (ushort) 11,
      (ushort) 13,
      (ushort) 15,
      (ushort) 17,
      (ushort) 19,
      (ushort) 23,
      (ushort) 27,
      (ushort) 31,
      (ushort) 35,
      (ushort) 43,
      (ushort) 51,
      (ushort) 59,
      (ushort) 67,
      (ushort) 83,
      (ushort) 99,
      (ushort) 115,
      (ushort) 131,
      (ushort) 163,
      (ushort) 195,
      (ushort) 227,
      (ushort) 258,
      (ushort) 0,
      (ushort) 0,
      (ushort) 0
    };
    private ushort[] bt12Table1B = new ushort[32]
    {
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 1,
      (ushort) 1,
      (ushort) 1,
      (ushort) 1,
      (ushort) 2,
      (ushort) 2,
      (ushort) 2,
      (ushort) 2,
      (ushort) 3,
      (ushort) 3,
      (ushort) 3,
      (ushort) 3,
      (ushort) 4,
      (ushort) 4,
      (ushort) 4,
      (ushort) 4,
      (ushort) 5,
      (ushort) 5,
      (ushort) 5,
      (ushort) 5,
      (ushort) 0,
      (ushort) 99,
      (ushort) 99,
      (ushort) 0
    };
    private ushort[] bt12Table2S = new ushort[32]
    {
      (ushort) 1,
      (ushort) 2,
      (ushort) 3,
      (ushort) 4,
      (ushort) 5,
      (ushort) 7,
      (ushort) 9,
      (ushort) 13,
      (ushort) 17,
      (ushort) 25,
      (ushort) 33,
      (ushort) 49,
      (ushort) 65,
      (ushort) 97,
      (ushort) 129,
      (ushort) 193,
      (ushort) 257,
      (ushort) 385,
      (ushort) 513,
      (ushort) 769,
      (ushort) 1025,
      (ushort) 1537,
      (ushort) 2049,
      (ushort) 3073,
      (ushort) 4097,
      (ushort) 6145,
      (ushort) 8193,
      (ushort) 12289,
      (ushort) 16385,
      (ushort) 24577,
      (ushort) 0,
      (ushort) 0
    };
    private ushort[] bt12Table2B = new ushort[32]
    {
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 0,
      (ushort) 1,
      (ushort) 1,
      (ushort) 2,
      (ushort) 2,
      (ushort) 3,
      (ushort) 3,
      (ushort) 4,
      (ushort) 4,
      (ushort) 5,
      (ushort) 5,
      (ushort) 6,
      (ushort) 6,
      (ushort) 7,
      (ushort) 7,
      (ushort) 8,
      (ushort) 8,
      (ushort) 9,
      (ushort) 9,
      (ushort) 10,
      (ushort) 10,
      (ushort) 11,
      (ushort) 11,
      (ushort) 12,
      (ushort) 12,
      (ushort) 13,
      (ushort) 13,
      (ushort) 0,
      (ushort) 0
    };
    private byte[] bt2Table1B = new byte[19]
    {
      (byte) 16,
      (byte) 17,
      (byte) 18,
      (byte) 0,
      (byte) 8,
      (byte) 7,
      (byte) 9,
      (byte) 6,
      (byte) 10,
      (byte) 5,
      (byte) 11,
      (byte) 4,
      (byte) 12,
      (byte) 3,
      (byte) 13,
      (byte) 2,
      (byte) 14,
      (byte) 1,
      (byte) 15
    };

    public GECompression()
    {
      this.compressedBuffer = (byte[]) null;
      this.compressedBufferSize = 0;
      this.wordTable = (uint[]) null;
      this.unpackTable = (GECompression.tableEntry[]) null;
      this.game = GECompression.BANJOKAZOOIE;
      this.unpackTable = new GECompression.tableEntry[(int) ushort.MaxValue];
    }

    public void SetPath(string directory)
    {
      string str = directory;
      if (str.Substring(str.Length - 1, 1) != "\\")
        this.mainFolder = directory + "\\";
      else
        this.mainFolder = directory;
    }

    public void SetGame(int replaceGame) => this.game = replaceGame;

    public void SetCompressedBuffer(byte[] Buffer, int bufferSize)
    {
      this.compressedBuffer = new byte[bufferSize];
      for (int index = 0; index < bufferSize; ++index)
        this.compressedBuffer[index] = Buffer[index];
      this.compressedBufferSize = bufferSize;
    }

    public void SetCompressedBuffer(byte[] Buffer)
    {
      this.compressedBuffer = Buffer;
      this.compressedBufferSize = Buffer.Length;
    }

    private uint GetNBits(int nBits)
    {
      while (this.bitsRemain < nBits)
      {
        if (this.bytesIndex >= this.maxByteSize || (long) this.bytesIndex >= (long) this.compressedBufferSize)
          return 0;
        this.bitsCache |= (uint) this.compressedBuffer[(int) this.bytesIndex] << this.bitsRemain;
        this.bitsRemain += 8;
        ++this.bytesIndex;
      }
      int nbits = (int) (uint) ((ulong) this.bitsCache & (ulong) ((1 << nBits) - 1));
      this.bitsCache >>= nBits;
      this.bitsRemain -= nBits;
      return (uint) nbits;
    }

    private uint GetNBitsAndPreserve(int nBits)
    {
      while (this.bitsRemain < nBits)
      {
        if (this.bytesIndex >= this.maxByteSize || (long) this.bytesIndex >= (long) this.compressedBufferSize)
          return 0;
        this.bitsCache |= (uint) this.compressedBuffer[(int) this.bytesIndex] << this.bitsRemain;
        this.bitsRemain += 8;
        ++this.bytesIndex;
      }
      return (uint) ((ulong) this.bitsCache & (ulong) ((1 << nBits) - 1));
    }

    private bool hiddenExec(string program, string args, string currentDirectory)
    {
      Process.Start(new ProcessStartInfo()
      {
        FileName = program,
        Arguments = args,
        WorkingDirectory = currentDirectory,
        WindowStyle = ProcessWindowStyle.Hidden,
        CreateNoWindow = true
      }).WaitForExit();
      return true;
    }

    private bool IsFileExist(string lpszFilename) => File.Exists(lpszFilename);

    public bool CompressGZipFile(string inputFile, string outputFile, bool byteFlipCompressed)
    {
      string str1 = this.mainFolder + "gzip.exe";
      if (!this.IsFileExist(this.mainFolder + "gzip.exe"))
      {
        int num = (int) MessageBox.Show("gzip.exe not found!", "Error");
        return false;
      }
      string str2 = inputFile;
      if (!this.IsFileExist(str2))
        return false;
      FileInfo fileInfo = new FileInfo(str2);
      uint count1 = 0;
      byte[] numArray;
      using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(str2, FileMode.Open, FileAccess.Read, FileShare.Read)))
      {
        count1 = Convert.ToUInt32(binaryReader.BaseStream.Length);
        if (count1 == 0U)
          return false;
        numArray = binaryReader.ReadBytes((int) count1);
      }
      byte[] buffer1 = new byte[(int) count1 + 16];
      for (int index = 0; (long) index < (long) (count1 + 16U); ++index)
        buffer1[index] = (byte) 0;
      for (int index = 0; (long) index < (long) count1; ++index)
        buffer1[index] = numArray[index];
      using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(this.mainFolder + "tempgh9.bin", FileMode.Create)))
      {
        uint count2 = count1;
        if (count2 % 16U != 0U)
        {
          int num = (int) count2;
          count2 = (uint) (num - (int) ((uint) num % 16U) + 16);
        }
        binaryWriter.Write(buffer1, 0, (int) count2);
      }
      string currentDirectory = Directory.GetCurrentDirectory();
      try
      {
        Directory.SetCurrentDirectory(this.mainFolder);
        this.hiddenExec("gzip.exe", "-f -q -9 tempgh9.bin", this.mainFolder);
        Directory.SetCurrentDirectory(currentDirectory);
      }
      catch
      {
        Directory.SetCurrentDirectory(currentDirectory);
        throw new Exception("error in gzip");
      }
      string str3 = this.mainFolder + "TEMPGH9.BIZ";
      if (!this.IsFileExist(str3))
        str3 = this.mainFolder + "tempgh9.bin.gz";
      if (this.IsFileExist(str3))
      {
        int int32;
        byte[] buffer2;
        using (BinaryReader binaryReader = new BinaryReader((Stream) File.Open(str3, FileMode.Open, FileAccess.Read, FileShare.Read)))
        {
          int32 = Convert.ToInt32(binaryReader.BaseStream.Length);
          if (int32 == 0)
            return false;
          buffer2 = binaryReader.ReadBytes(int32);
        }
        File.Delete(this.mainFolder + "TEMPGH9.BIZ");
        using (BinaryWriter binaryWriter = new BinaryWriter((Stream) File.Open(outputFile, FileMode.Create)))
        {
          uint index1 = 22;
          if (this.game == GECompression.GOLDENEYE || this.game == GECompression.KILLERINSTINCT)
          {
            index1 -= 2U;
            buffer2[(int) index1] = (byte) 17;
            buffer2[(int) index1 + 1] = (byte) 114;
          }
          else if (this.game == GECompression.PD)
          {
            index1 -= 5U;
            buffer2[(int) index1] = (byte) 17;
            buffer2[(int) index1 + 1] = (byte) 115;
            buffer2[(int) index1 + 2] = (byte) (count1 >> 16 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 3] = (byte) (count1 >> 8 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 4] = (byte) (count1 & (uint) byte.MaxValue);
          }
          else if (this.game == GECompression.BANJOKAZOOIE)
          {
            index1 -= 6U;
            buffer2[(int) index1] = (byte) 17;
            buffer2[(int) index1 + 1] = (byte) 114;
            buffer2[(int) index1 + 2] = (byte) (count1 >> 24 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 3] = (byte) (count1 >> 16 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 4] = (byte) (count1 >> 8 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 5] = (byte) (count1 & (uint) byte.MaxValue);
          }
          else if (this.game == GECompression.DONKEYKONG64 || this.game == GECompression.BLASTCORPS)
          {
            index1 -= 10U;
            buffer2[(int) index1] = (byte) 31;
            buffer2[(int) index1 + 1] = (byte) 139;
            buffer2[(int) index1 + 2] = (byte) 8;
            buffer2[(int) index1 + 3] = (byte) 0;
            buffer2[(int) index1 + 4] = (byte) 0;
            buffer2[(int) index1 + 5] = (byte) 0;
            buffer2[(int) index1 + 6] = (byte) 0;
            buffer2[(int) index1 + 7] = (byte) 0;
            buffer2[(int) index1 + 8] = (byte) 2;
            buffer2[(int) index1 + 9] = (byte) 3;
          }
          else if (this.game == GECompression.DONKEYKONG64KIOSK)
          {
            index1 -= 18U;
            buffer2[(int) index1] = (byte) 31;
            buffer2[(int) index1 + 1] = (byte) 139;
            buffer2[(int) index1 + 2] = (byte) 8;
            buffer2[(int) index1 + 3] = (byte) 8;
            buffer2[(int) index1 + 4] = (byte) 3;
            buffer2[(int) index1 + 5] = (byte) 69;
            buffer2[(int) index1 + 6] = (byte) 117;
            buffer2[(int) index1 + 7] = (byte) 55;
            buffer2[(int) index1 + 8] = (byte) 0;
            buffer2[(int) index1 + 9] = (byte) 3;
            buffer2[(int) index1 + 10] = (byte) 116;
            buffer2[(int) index1 + 11] = (byte) 109;
            buffer2[(int) index1 + 12] = (byte) 112;
            buffer2[(int) index1 + 13] = (byte) 46;
            buffer2[(int) index1 + 14] = (byte) 98;
            buffer2[(int) index1 + 15] = (byte) 105;
            buffer2[(int) index1 + 16] = (byte) 110;
            buffer2[(int) index1 + 17] = (byte) 0;
          }
          else if (this.game == GECompression.BANJOTOOIE)
          {
            index1 -= 2U;
            buffer2[(int) index1] = (byte) 0;
            buffer2[(int) index1 + 1] = (byte) 21;
          }
          else if (this.game == GECompression.CONKER)
          {
            index1 -= 4U;
            buffer2[(int) index1] = (byte) (count1 >> 24 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 1] = (byte) (count1 >> 16 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 2] = (byte) (count1 >> 8 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 3] = (byte) (count1 & (uint) byte.MaxValue);
          }
          else if (this.game == GECompression.TOPGEARRALLY)
          {
            index1 -= 14U;
            buffer2[(int) index1] = (byte) ((ulong) ((long) int32 - (long) (index1 + 8U) >> 24) & (ulong) byte.MaxValue);
            buffer2[(int) index1 + 1] = (byte) ((ulong) ((long) int32 - (long) (index1 + 8U) >> 16) & (ulong) byte.MaxValue);
            buffer2[(int) index1 + 2] = (byte) ((ulong) ((long) int32 - (long) (index1 + 8U) >> 8) & (ulong) byte.MaxValue);
            buffer2[(int) index1 + 3] = (byte) ((ulong) int32 - (ulong) (index1 + 8U) & (ulong) byte.MaxValue);
            buffer2[(int) index1 + 4] = (byte) (count1 >> 24 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 5] = (byte) (count1 >> 16 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 6] = (byte) (count1 >> 8 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 7] = (byte) (count1 & (uint) byte.MaxValue);
            buffer2[(int) index1 + 8] = (byte) 0;
            buffer2[(int) index1 + 9] = (byte) 0;
            buffer2[(int) index1 + 10] = (byte) 0;
            buffer2[(int) index1 + 11] = (byte) 0;
            buffer2[(int) index1 + 12] = (byte) 0;
            buffer2[(int) index1 + 13] = (byte) 0;
          }
          else if (this.game == GECompression.MILO)
          {
            index1 -= 2U;
            buffer2[(int) index1] = (byte) 120;
            buffer2[(int) index1 + 1] = (byte) 156;
          }
          else if (this.game == GECompression.JFG || this.game == GECompression.JFGKIOSK)
          {
            index1 -= 5U;
            buffer2[(int) index1] = (byte) 4;
            buffer2[(int) index1 + 1] = (byte) 3;
            buffer2[(int) index1 + 2] = (byte) 0;
            buffer2[(int) index1 + 3] = (byte) 0;
            buffer2[(int) index1 + 4] = (byte) 9;
          }
          else if (this.game == GECompression.DKR)
          {
            index1 -= 5U;
            buffer2[(int) index1] = (byte) 4;
            buffer2[(int) index1 + 1] = (byte) 3;
            buffer2[(int) index1 + 2] = (byte) 0;
            buffer2[(int) index1 + 3] = (byte) 0;
            buffer2[(int) index1 + 4] = (byte) 9;
          }
          else if (this.game == GECompression.MICKEYSPEEDWAY)
          {
            index1 -= 5U;
            buffer2[(int) index1] = (byte) 4;
            buffer2[(int) index1 + 1] = (byte) 3;
            buffer2[(int) index1 + 2] = (byte) 0;
            buffer2[(int) index1 + 3] = (byte) 0;
            buffer2[(int) index1 + 4] = (byte) 9;
          }
          else if (this.game == GECompression.STUNTRACER64)
          {
            index1 -= 2U;
            buffer2[(int) index1] = (byte) 120;
            buffer2[(int) index1 + 1] = (byte) 218;
          }
          if (byteFlipCompressed)
          {
            if (int32 % 2 == 1)
            {
              buffer2[int32 - 8] = (byte) 0;
              ++int32;
            }
            for (int index2 = 0; index2 < int32; index2 += 2)
            {
              byte num = buffer2[index2];
              buffer2[index2] = buffer2[index2 + 1];
              buffer2[index2 + 1] = num;
            }
          }
          binaryWriter.Write(buffer2, (int) index1, (int) ((long) int32 - (long) (index1 + 8U)));
          this.compressed_filelen = binaryWriter.BaseStream.Length;
          uint num1 = (uint) ((ulong) int32 - (ulong) (index1 + 8U));
          if (num1 % 8U != 0U)
          {
            if (this.padding)
            {
              for (int index3 = 0; (long) index3 < (long) (8U - num1 % 8U); ++index3)
              {
                if (this.game == GECompression.BANJOKAZOOIE || this.game == GECompression.BANJOTOOIE)
                {
                  byte num2 = 170;
                  binaryWriter.Write(num2);
                }
                else
                {
                  byte num3 = 0;
                  binaryWriter.Write(num3);
                }
              }
              binaryWriter.Close();
              return true;
            }
          }
        }
        return false;
      }
      int num4 = (int) MessageBox.Show("Error Compressing - GZip didn't spit out a file", "Error");
      return false;
    }

    public byte[] OutputDecompressedBuffer(ref int fileSize, ref int compressedSize)
    {
      compressedSize = 0;
      if (this.compressedBuffer == null || this.compressedBufferSize < 3)
        return (byte[]) null;
      if (((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 4466 && ((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 4467 && ((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 30876 && ((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 30938 && ((int) this.compressedBuffer[0] << 24 | (int) this.compressedBuffer[1] << 16 | (int) this.compressedBuffer[2] << 8 | (int) this.compressedBuffer[3]) != 529205248 && ((int) this.compressedBuffer[0] << 24 | (int) this.compressedBuffer[1] << 16 | (int) this.compressedBuffer[2] << 8 | (int) this.compressedBuffer[3]) != 529205256 && this.game != GECompression.BLASTCORPS && this.game != GECompression.BANJOTOOIE && this.game != GECompression.CONKER && this.game != GECompression.TOPGEARRALLY && this.game != GECompression.JFG && this.game != GECompression.DKR && this.game != GECompression.JFGKIOSK && this.game != GECompression.MICKEYSPEEDWAY)
      {
        int num = (int) MessageBox.Show("Not 1172/1173/1F8B0800/1F8B0808 Compressed", "Error");
        return (byte[]) null;
      }
      this.bitsCache = 0U;
      this.bitsRemain = 0;
      if (this.game == GECompression.GOLDENEYE || this.game == GECompression.KILLERINSTINCT || this.game == GECompression.MILO || this.game == GECompression.STUNTRACER64)
        this.bytesIndex = 2U;
      else if (this.game == GECompression.PD)
        this.bytesIndex = 5U;
      else if (this.game == GECompression.BANJOKAZOOIE)
        this.bytesIndex = 6U;
      else if (this.game == GECompression.DONKEYKONG64 || this.game == GECompression.DONKEYKONG64KIOSK || this.game == GECompression.BLASTCORPS)
        this.bytesIndex = 10U;
      else if (this.game == GECompression.BANJOTOOIE)
        this.bytesIndex = 2U;
      else if (this.game == GECompression.CONKER)
        this.bytesIndex = 4U;
      else if (this.game == GECompression.TOPGEARRALLY)
        this.bytesIndex = 14U;
      else if (this.game == GECompression.JFG || this.game == GECompression.JFGKIOSK || this.game == GECompression.DKR || this.game == GECompression.MICKEYSPEEDWAY)
        this.bytesIndex = 5U;
      if ((this.game == GECompression.DONKEYKONG64 || this.game == GECompression.DONKEYKONG64KIOSK || this.game == GECompression.BLASTCORPS) && ((int) this.compressedBuffer[0] << 24 | (int) this.compressedBuffer[1] << 16 | (int) this.compressedBuffer[2] << 8 | (int) this.compressedBuffer[3]) == 529205256)
      {
        while (this.compressedBuffer[(int) this.bytesIndex] != (byte) 0)
          ++this.bytesIndex;
        ++this.bytesIndex;
      }
      this.unpackTableIndex = 0;
      for (int index = 0; index < (int) ushort.MaxValue; ++index)
      {
        this.unpackTable[index].bits = 0U;
        this.unpackTable[index].flags = (byte) 0;
        this.unpackTable[index].nextIndex = 0;
        this.unpackTable[index].wordValue = 0U;
      }
      byte[] returnBuffer = new byte[(int) this.maxByteSize];
      fileSize = 0;
      this.iterationCounter = 0U;
      while (this.iterationCounter <= 268435455U)
      {
        ++this.iterationCounter;
        bool boolean = Convert.ToBoolean(this.GetNBits(1));
        if (this.bytesIndex >= this.maxByteSize)
        {
          fileSize = 0;
          return (byte[]) null;
        }
        switch (Convert.ToByte(this.GetNBits(2)))
        {
          case 0:
            if (!this.UncompressType0(returnBuffer, ref fileSize))
            {
              fileSize = 0;
              return (byte[]) null;
            }
            break;
          case 1:
            if (!this.UncompressType1(returnBuffer, ref fileSize))
            {
              fileSize = 0;
              return (byte[]) null;
            }
            break;
          case 2:
            if (!this.UncompressType2(returnBuffer, ref fileSize))
            {
              fileSize = 0;
              return (byte[]) null;
            }
            break;
          default:
            fileSize = 0;
            return (byte[]) null;
        }
        if (boolean)
        {
          compressedSize = (int) this.bytesIndex;
          byte[] numArray = new byte[fileSize];
          for (int index = 0; index < fileSize; ++index)
            numArray[index] = returnBuffer[index];
          return numArray;
        }
      }
      fileSize = 0;
      return (byte[]) null;
    }

    public byte[] GetUncompressedSize(ref int fileSize, ref int compressedSize)
    {
      compressedSize = 0;
      if (this.compressedBuffer == null || this.compressedBufferSize < 3)
        return (byte[]) null;
      if (((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 4466 && ((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 4467 && ((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 30876 && ((int) this.compressedBuffer[0] << 8 | (int) this.compressedBuffer[1]) != 30938 && ((int) this.compressedBuffer[0] << 24 | (int) this.compressedBuffer[1] << 16 | (int) this.compressedBuffer[2] << 8 | (int) this.compressedBuffer[3]) != 529205248 && ((int) this.compressedBuffer[0] << 24 | (int) this.compressedBuffer[1] << 16 | (int) this.compressedBuffer[2] << 8 | (int) this.compressedBuffer[3]) != 529205256 && this.game != GECompression.BLASTCORPS && this.game != GECompression.BANJOTOOIE && this.game != GECompression.CONKER && this.game != GECompression.TOPGEARRALLY && this.game != GECompression.JFG && this.game != GECompression.DKR && this.game != GECompression.JFGKIOSK && this.game != GECompression.MICKEYSPEEDWAY)
      {
        int num = (int) MessageBox.Show("Not 1172/1173/1F8B0800/1F8B0808 Compressed", "Error");
        return (byte[]) null;
      }
      this.bitsCache = 0U;
      this.bitsRemain = 0;
      if (this.game == GECompression.GOLDENEYE || this.game == GECompression.KILLERINSTINCT || this.game == GECompression.MILO || this.game == GECompression.STUNTRACER64)
        this.bytesIndex = 2U;
      else if (this.game == GECompression.PD)
        this.bytesIndex = 5U;
      else if (this.game == GECompression.BANJOKAZOOIE)
        this.bytesIndex = 6U;
      else if (this.game == GECompression.DONKEYKONG64 || this.game == GECompression.DONKEYKONG64KIOSK || this.game == GECompression.BLASTCORPS)
        this.bytesIndex = 10U;
      else if (this.game == GECompression.BANJOTOOIE)
        this.bytesIndex = 2U;
      else if (this.game == GECompression.CONKER)
        this.bytesIndex = 4U;
      else if (this.game == GECompression.TOPGEARRALLY)
        this.bytesIndex = 14U;
      else if (this.game == GECompression.JFG || this.game == GECompression.JFGKIOSK || this.game == GECompression.DKR || this.game == GECompression.MICKEYSPEEDWAY)
        this.bytesIndex = 5U;
      if ((this.game == GECompression.DONKEYKONG64 || this.game == GECompression.DONKEYKONG64KIOSK || this.game == GECompression.BLASTCORPS) && ((int) this.compressedBuffer[0] << 24 | (int) this.compressedBuffer[1] << 16 | (int) this.compressedBuffer[2] << 8 | (int) this.compressedBuffer[3]) == 529205256)
      {
        while (this.compressedBuffer[(int) this.bytesIndex] != (byte) 0)
          ++this.bytesIndex;
        ++this.bytesIndex;
      }
      this.unpackTableIndex = 0;
      for (int index = 0; index < (int) ushort.MaxValue; ++index)
      {
        this.unpackTable[index].bits = 0U;
        this.unpackTable[index].flags = (byte) 0;
        this.unpackTable[index].nextIndex = 0;
        this.unpackTable[index].wordValue = 0U;
      }
      byte[] returnBuffer = new byte[(int) this.maxByteSize];
      fileSize = 0;
      this.iterationCounter = 0U;
      while (this.iterationCounter <= 268435455U)
      {
        ++this.iterationCounter;
        bool boolean = Convert.ToBoolean(this.GetNBits(1));
        if (this.bytesIndex >= this.maxByteSize)
        {
          fileSize = 0;
          return (byte[]) null;
        }
        switch (Convert.ToByte(this.GetNBits(2)))
        {
          case 0:
            if (!this.UncompressType0(returnBuffer, ref fileSize))
            {
              fileSize = 0;
              return (byte[]) null;
            }
            break;
          case 1:
            if (!this.UncompressType1(returnBuffer, ref fileSize))
            {
              fileSize = 0;
              return (byte[]) null;
            }
            break;
          case 2:
            if (!this.UncompressType2(returnBuffer, ref fileSize))
            {
              fileSize = 0;
              return (byte[]) null;
            }
            break;
          default:
            fileSize = 0;
            return (byte[]) null;
        }
        if (boolean)
        {
          compressedSize = (int) this.bytesIndex;
          return returnBuffer;
        }
      }
      fileSize = 0;
      return (byte[]) null;
    }

    private bool UncompressType0(byte[] returnBuffer, ref int fileSize)
    {
      int nbits1 = (int) this.GetNBits(this.bitsRemain & 7);
      ushort nbits2 = (ushort) this.GetNBits(16);
      int nbits3 = (int) this.GetNBits(16);
      for (int index = 0; index < (int) nbits2; ++index)
      {
        if ((long) fileSize >= (long) this.maxByteSize)
        {
          fileSize = 0;
          return false;
        }
        returnBuffer[fileSize] = (byte) this.GetNBits(8);
        ++fileSize;
        if (this.iterationCounter > 268435455U)
        {
          fileSize = 0;
          return false;
        }
        ++this.iterationCounter;
      }
      return true;
    }

    private bool UncompressType1(byte[] returnBuffer, ref int fileSize)
    {
      bool returnValue1 = false;
      bool returnValue2 = false;
      int numReturnBits1 = 0;
      int numReturnBits2 = 0;
      int returnStartIndex1 = 0;
      int returnStartIndex2 = 0;
      this.CreateGlobalDecompressionTable(0, 257, 0, 0, 7, ref returnValue1, ref numReturnBits1, ref returnStartIndex1);
      this.CreateGlobalDecompressionTable(1, 0, 1, 1, 5, ref returnValue2, ref numReturnBits2, ref returnStartIndex2);
      return this.DecompressBasedOnTable(returnStartIndex1, returnStartIndex2, numReturnBits1, numReturnBits2, returnBuffer, ref fileSize);
    }

    private bool UncompressType2(byte[] returnBuffer, ref int fileSize)
    {
      try
      {
        for (int index = 0; index < 19; ++index)
          this.variableTable[index] = (byte) 0;
        this.tableSize = (ushort) (this.GetNBits(5) + 257U);
        this.fiveBits = (byte) (this.GetNBits(5) + 1U);
        byte num1 = (byte) (this.GetNBits(4) + 4U);
        for (int index = 0; index < (int) num1; ++index)
        {
          byte nbits = (byte) this.GetNBits(3);
          this.variableTable[(int) this.bt2Table1B[index]] = nbits;
        }
        bool returnValue1 = false;
        int numReturnBits1 = 0;
        int returnStartIndex1 = 0;
        this.CreateGlobalDecompressionTable(2, 19, 2, 2, 7, ref returnValue1, ref numReturnBits1, ref returnStartIndex1);
        this.wordTable = new uint[(int) ushort.MaxValue];
        int index1 = 0;
        uint num2 = 0;
        while (index1 < (int) this.tableSize + (int) this.fiveBits)
        {
          if (this.iterationCounter > 268435455U)
          {
            fileSize = 0;
            return false;
          }
          ++this.iterationCounter;
          uint nbitsAndPreserve = this.GetNBitsAndPreserve(numReturnBits1);
          if ((long) returnStartIndex1 + (long) nbitsAndPreserve > (long) ushort.MaxValue)
          {
            fileSize = 0;
            return false;
          }
          int bits = (int) this.unpackTable[(long) returnStartIndex1 + (long) nbitsAndPreserve].bits;
          if (this.bytesIndex >= this.maxByteSize)
          {
            fileSize = 0;
            return false;
          }
          int nbits = (int) this.GetNBits(bits);
          uint wordValue = this.unpackTable[(long) returnStartIndex1 + (long) nbitsAndPreserve].wordValue;
          if (this.unpackTable[(long) returnStartIndex1 + (long) nbitsAndPreserve].nextIndex == 0)
          {
            if (wordValue < 16U)
            {
              num2 = wordValue;
              this.wordTable[index1] = wordValue;
              ++index1;
            }
            else
            {
              switch (wordValue)
              {
                case 16:
                  int num3 = (int) this.GetNBits(2) + 3;
                  for (int index2 = 0; index2 < num3; ++index2)
                  {
                    this.wordTable[index1] = num2;
                    ++index1;
                  }
                  continue;
                case 17:
                  int num4 = (int) this.GetNBits(3) + 3;
                  for (int index3 = 0; index3 < num4; ++index3)
                  {
                    this.wordTable[index1] = 0U;
                    ++index1;
                  }
                  continue;
                default:
                  int num5 = (int) this.GetNBits(7) + 11;
                  for (int index4 = 0; index4 < num5; ++index4)
                  {
                    this.wordTable[index1] = 0U;
                    ++index1;
                  }
                  continue;
              }
            }
          }
        }
        bool returnValue2 = false;
        bool returnValue3 = false;
        int numReturnBits2 = 0;
        int numReturnBits3 = 0;
        int returnStartIndex2 = 0;
        int returnStartIndex3 = 0;
        this.CreateGlobalDecompressionTable(3, 257, 0, 0, 9, ref returnValue2, ref numReturnBits2, ref returnStartIndex2);
        this.CreateGlobalDecompressionTable(4, 0, 1, 1, 6, ref returnValue3, ref numReturnBits3, ref returnStartIndex3);
        this.DecompressBasedOnTable(returnStartIndex2, returnStartIndex3, numReturnBits2, numReturnBits3, returnBuffer, ref fileSize);
        this.wordTable = (uint[]) null;
      }
      catch (Exception ex)
      {
        ex.ToString();
        int num = (int) MessageBox.Show(ex.StackTrace);
        fileSize = 0;
        return false;
      }
      return true;
    }

    private void CreateGlobalDecompressionTable(
      int bit1TableChoice,
      int size2,
      int bit12STableSChoice,
      int bit12BTableChoice,
      int numBits,
      ref bool returnValue,
      ref int numReturnBits,
      ref int returnStartIndex)
    {
      GECompression.tableEntry tableEntry;
      tableEntry.bits = 0U;
      tableEntry.flags = (byte) 0;
      tableEntry.nextIndex = 0;
      tableEntry.wordValue = 0U;
      int length = 0;
      int num1 = -1;
      uint[] numArray1 = new uint[17];
      for (int index = 0; index < 17; ++index)
        numArray1[index] = 0U;
      if (bit1TableChoice == this.TABLE1)
      {
        length = 288;
        for (int index = 0; index < 288; ++index)
          ++numArray1[(int) this.bt1Table1[index]];
      }
      else if (bit1TableChoice == this.TABLE2)
      {
        length = 30;
        for (int index = 0; index < 30; ++index)
          ++numArray1[(int) this.bt1Table2[index]];
      }
      else if (bit1TableChoice == this.VARIABLETABLE)
      {
        length = 19;
        for (int index = 0; index < 19; ++index)
          ++numArray1[(int) this.variableTable[index]];
      }
      else if (bit1TableChoice == this.WORDTABLEBEGIN)
      {
        length = (int) this.tableSize;
        for (int index = 0; index < length; ++index)
          ++numArray1[(int) this.wordTable[index]];
      }
      else if (bit1TableChoice == this.WORDTABLEEND)
      {
        length = (int) this.tableSize + (int) this.fiveBits - (int) this.tableSize;
        for (int index = 0; index < length; ++index)
          ++numArray1[(int) this.wordTable[(int) this.tableSize + index]];
      }
      int index1 = 1;
      while (numArray1[index1] == 0U)
        ++index1;
      int index2 = 16;
      while (numArray1[index2] == 0U)
        --index2;
      if (numBits < index1)
        numBits = index1;
      if (numBits > index2)
        numBits = index2;
      uint num2 = (uint) (1 << index1);
      if (index1 != index2)
      {
        for (int index3 = index1; index3 < index2; ++index3)
          num2 = (uint) (((int) num2 - (int) numArray1[index3]) * 2);
      }
      int num3 = (int) numArray1[index2];
      numArray1[index2] = num2;
      uint num4 = (uint) ((ulong) num2 - (ulong) num3);
      uint[] numArray2 = new uint[17];
      for (int index4 = 0; index4 < 17; ++index4)
        numArray2[index4] = 0U;
      int num5 = 0;
      for (int index5 = 1; index5 < index2; ++index5)
      {
        num5 = (int) ((long) num5 + (long) numArray1[index5]);
        numArray2[index5 + 1] = (uint) num5;
      }
      uint[] numArray3 = new uint[length];
      int index6 = 0;
      int num6 = 0;
      for (int index7 = 0; index7 < length; ++index7)
        numArray3[index7] = 0U;
      for (int index8 = 0; index8 < length; ++index8)
      {
        if (bit1TableChoice == this.TABLE1)
        {
          if (this.bt1Table1[index8] != (byte) 0)
          {
            numArray3[(int) numArray2[(int) this.bt1Table1[index8]]] = (uint) num6;
            ++numArray2[(int) this.bt1Table1[index8]];
          }
        }
        else if (bit1TableChoice == this.TABLE2)
        {
          if (this.bt1Table2[index8] != (byte) 0)
          {
            numArray3[(int) numArray2[(int) this.bt1Table2[index8]]] = (uint) num6;
            ++numArray2[(int) this.bt1Table2[index8]];
          }
        }
        else if (bit1TableChoice == this.VARIABLETABLE)
        {
          if (this.variableTable[index8] != (byte) 0)
          {
            numArray3[(int) numArray2[(int) this.variableTable[index8]]] = (uint) num6;
            ++numArray2[(int) this.variableTable[index8]];
          }
        }
        else if (bit1TableChoice == this.WORDTABLEBEGIN)
        {
          if (this.wordTable[index8] != 0U)
          {
            numArray3[(int) numArray2[(int) this.wordTable[index8]]] = (uint) num6;
            ++numArray2[(int) this.wordTable[index8]];
          }
        }
        else if (bit1TableChoice == this.WORDTABLEEND && this.wordTable[(int) this.tableSize + index8] != 0U)
        {
          numArray3[(int) numArray2[(int) this.wordTable[(int) this.tableSize + index8]]] = (uint) num6;
          ++numArray2[(int) this.wordTable[(int) this.tableSize + index8]];
        }
        ++num6;
      }
      int num7 = -numBits;
      int index9 = -1;
      int num8 = 0;
      int[] numArray4 = new int[131072];
      int index10 = -1;
      uint num9 = 0;
      int num10 = 0;
      for (int index11 = index1; index11 < index2 + 1; ++index11)
      {
        int num11 = (int) numArray1[index11];
        uint num12 = (uint) (1 << index11 - 1);
        int num13 = length;
        for (; num11 > 0 && num11 >= 0; --num11)
        {
          int num14;
          for (num14 = num7 + numBits; num14 < index11; num14 += numBits)
          {
            ++index9;
            uint num15 = numBits >= index2 - num14 ? (uint) (index2 - num14) : (uint) numBits;
            num9 = (uint) (index11 - num14);
            if (num11 < 1 << (int) num9)
            {
              uint num16 = (uint) ((1 << (int) num9) - num11);
              ++num9;
              for (int index12 = index11 + 1; num9 < num15 && index12 < numArray1.Length; ++index12)
              {
                if (numArray1[index12] < num16 * 2U)
                {
                  ++num9;
                  num16 = num16 * 2U - numArray1[index12];
                }
              }
            }
            if (num1 == -1)
              num1 = this.unpackTableIndex + 1;
            ++index10;
            numArray4[index10] = this.unpackTableIndex + 1;
            num10 = this.unpackTableIndex + 1;
            if (index9 != 0)
            {
              numArray2[index9] = (uint) num8;
              tableEntry.bits = (uint) numBits;
              tableEntry.flags = (byte) (num9 + 16U);
              tableEntry.nextIndex = this.unpackTableIndex + 1;
              tableEntry.wordValue = uint.MaxValue;
              this.unpackTable[(num8 >> num14 - numBits) + numArray4[index9 - 1]].bits = tableEntry.bits;
              this.unpackTable[(num8 >> num14 - numBits) + numArray4[index9 - 1]].flags = tableEntry.flags;
              this.unpackTable[(num8 >> num14 - numBits) + numArray4[index9 - 1]].wordValue = tableEntry.wordValue;
              this.unpackTable[(num8 >> num14 - numBits) + numArray4[index9 - 1]].nextIndex = tableEntry.nextIndex;
            }
            this.unpackTableIndex += (1 << (int) num9) + 1;
          }
          num7 = num14 - numBits;
          tableEntry.bits = (uint) (index11 - num7);
          tableEntry.nextIndex = 0;
          if (index6 >= num13)
          {
            tableEntry.flags = (byte) 99;
          }
          else
          {
            uint num17 = numArray3[index6];
            if ((long) num17 < (long) size2)
            {
              tableEntry.flags = num17 < 256U ? (byte) 16 : (byte) 15;
              tableEntry.wordValue = num17;
            }
            else if (bit12STableSChoice == this.TABLE1)
            {
              tableEntry.flags = (byte) this.bt12Table1B[(long) numArray3[index6] - (long) size2];
              tableEntry.wordValue = (uint) this.bt12Table1S[(long) numArray3[index6] - (long) size2];
            }
            else if (bit12STableSChoice == this.TABLE2)
            {
              tableEntry.flags = (byte) this.bt12Table2B[(long) numArray3[index6] - (long) size2];
              tableEntry.wordValue = (uint) this.bt12Table2S[(long) numArray3[index6] - (long) size2];
            }
            else
            {
              int variabletable = this.VARIABLETABLE;
            }
            ++index6;
          }
          uint num18 = (uint) (num8 >> num7);
          uint num19 = (uint) (1 << index11 - num7);
          for (; (long) (1 << (int) num9) > (long) num18; num18 += num19)
          {
            if ((long) num10 + (long) num18 > (long) ushort.MaxValue)
              return;
            this.unpackTable[(long) num10 + (long) num18].bits = tableEntry.bits;
            this.unpackTable[(long) num10 + (long) num18].flags = tableEntry.flags;
            this.unpackTable[(long) num10 + (long) num18].wordValue = tableEntry.wordValue;
            this.unpackTable[(long) num10 + (long) num18].nextIndex = tableEntry.nextIndex;
          }
          uint num20;
          for (num20 = num12; ((long) num8 & (long) num20) > 0L; num20 >>= 1)
            num8 = (int) ((long) num8 ^ (long) num20);
          for (num8 = (int) ((long) num8 ^ (long) num20); (long) (num8 & (1 << num7) - 1) != (long) numArray2[index9]; num7 = 0)
            --index9;
        }
      }
      if (num4 > 0U)
      {
        returnValue = 0 < (index2 ^ 1);
        numReturnBits = numBits;
        returnStartIndex = num1;
      }
      else
      {
        returnValue = false;
        numReturnBits = numBits;
        returnStartIndex = num1;
      }
    }

    private bool DecompressBasedOnTable(
      int startIndex1,
      int startIndex2,
      int bitLen1,
      int bitLen2,
      byte[] returnBuffer,
      ref int fileSize)
    {
      bool flag = true;
      try
      {
        while (flag)
        {
          if (this.iterationCounter > 268435455U)
          {
            fileSize = 0;
            return false;
          }
          ++this.iterationCounter;
          if (this.bytesIndex >= this.maxByteSize)
          {
            fileSize = 0;
            return false;
          }
          uint nbitsAndPreserve1 = this.GetNBitsAndPreserve(bitLen1);
          if ((long) startIndex1 + (long) nbitsAndPreserve1 > (long) ushort.MaxValue)
          {
            fileSize = 0;
            return false;
          }
          GECompression.tableEntry tableEntry1;
          uint nbitsAndPreserve2;
          for (tableEntry1 = this.unpackTable[(long) startIndex1 + (long) nbitsAndPreserve1]; tableEntry1.flags > (byte) 16; tableEntry1 = this.unpackTable[(long) tableEntry1.nextIndex + (long) nbitsAndPreserve2])
          {
            if (this.iterationCounter > 268435455U)
            {
              fileSize = 0;
              return false;
            }
            ++this.iterationCounter;
            if (this.bytesIndex >= this.maxByteSize)
            {
              fileSize = 0;
              return false;
            }
            int nbits = (int) this.GetNBits((int) tableEntry1.bits);
            nbitsAndPreserve2 = this.GetNBitsAndPreserve((int) tableEntry1.flags - 16);
            if ((long) tableEntry1.nextIndex + (long) nbitsAndPreserve2 > (long) ushort.MaxValue)
            {
              fileSize = 0;
              return false;
            }
          }
          if (this.bytesIndex >= this.maxByteSize)
          {
            fileSize = 0;
            return false;
          }
          int nbits1 = (int) this.GetNBits((int) tableEntry1.bits);
          if (tableEntry1.flags == (byte) 16)
          {
            if ((long) fileSize >= (long) this.maxByteSize)
            {
              fileSize = 0;
              return false;
            }
            returnBuffer[fileSize] = (byte) tableEntry1.wordValue;
            ++fileSize;
          }
          else if (tableEntry1.flags < (byte) 15)
          {
            uint num1 = tableEntry1.wordValue + this.GetNBits((int) tableEntry1.flags);
            uint nbitsAndPreserve3 = this.GetNBitsAndPreserve(bitLen2);
            if ((long) startIndex2 + (long) nbitsAndPreserve3 > (long) ushort.MaxValue)
            {
              fileSize = 0;
              return false;
            }
            GECompression.tableEntry tableEntry2;
            uint nbitsAndPreserve4;
            for (tableEntry2 = this.unpackTable[(long) startIndex2 + (long) nbitsAndPreserve3]; tableEntry2.flags > (byte) 16; tableEntry2 = this.unpackTable[(long) tableEntry2.nextIndex + (long) nbitsAndPreserve4])
            {
              if (this.iterationCounter > 268435455U)
              {
                fileSize = 0;
                return false;
              }
              ++this.iterationCounter;
              if (this.bytesIndex >= this.maxByteSize)
              {
                fileSize = 0;
                return false;
              }
              int nbits2 = (int) this.GetNBits((int) tableEntry2.bits);
              nbitsAndPreserve4 = this.GetNBitsAndPreserve((int) tableEntry2.flags - 16);
              if ((long) tableEntry2.nextIndex + (long) nbitsAndPreserve4 > (long) ushort.MaxValue)
              {
                fileSize = 0;
                return false;
              }
            }
            if (this.bytesIndex >= this.maxByteSize)
            {
              fileSize = 0;
              return false;
            }
            int nbits3 = (int) this.GetNBits((int) tableEntry2.bits);
            uint wordValue = tableEntry2.wordValue;
            uint nbits4 = this.GetNBits((int) tableEntry2.flags);
            uint num2 = (uint) ((ulong) fileSize - (ulong) wordValue - (ulong) nbits4);
            uint num3 = num2 + num1;
            for (int index = (int) num2; (long) index < (long) num3; ++index)
            {
              if ((int) num2 < 0 || (int) num3 < 0 || num2 > this.maxByteSize || num3 > this.maxByteSize)
              {
                fileSize = 0;
                return false;
              }
              returnBuffer[fileSize] = returnBuffer[index];
              ++fileSize;
            }
          }
          else
            flag = false;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    public struct tableEntry
    {
      public uint bits;
      public byte flags;
      public int nextIndex;
      public uint wordValue;
    }
  }
}
