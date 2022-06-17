// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.RomHandler
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.IO;

namespace BanjoKazooieLevelEditor
{
  public static class RomHandler
  {
    public const int TABLE_SETUPS_START = 38776;
    private static byte[] rom;
    public static string tmpDir = "";

    public static byte[] Rom
    {
      set => RomHandler.rom = value;
      get => RomHandler.rom;
    }

    public static int getNextPointer(int pntr_)
    {
      int num = (int) RomHandler.rom[pntr_] * 16777216 + (int) RomHandler.rom[pntr_ + 1] * 65536 + (int) RomHandler.rom[pntr_ + 2] * 256 + (int) RomHandler.rom[pntr_ + 3];
      int nextPointer = (int) RomHandler.rom[pntr_ + 8] * 16777216 + (int) RomHandler.rom[pntr_ + 1 + 8] * 65536 + (int) RomHandler.rom[pntr_ + 2 + 8] * 256 + (int) RomHandler.rom[pntr_ + 3 + 8];
      while (num - nextPointer == 0)
      {
        nextPointer = (int) RomHandler.rom[pntr_ + 8] * 16777216 + (int) RomHandler.rom[pntr_ + 1 + 8] * 65536 + (int) RomHandler.rom[pntr_ + 2 + 8] * 256 + (int) RomHandler.rom[pntr_ + 3 + 8];
        pntr_ += 8;
      }
      return nextPointer;
    }

    public static byte[] DecompressFileToByteArray(int pntr)
    {
      int num1 = (int) RomHandler.rom[pntr] * 16777216 + (int) RomHandler.rom[pntr + 1] * 65536 + (int) RomHandler.rom[pntr + 2] * 256 + (int) RomHandler.rom[pntr + 3];
      int compressedSize = RomHandler.getNextPointer(pntr) - num1;
      int num2 = num1 + 68816;
      byte[] numArray = new byte[compressedSize];
      for (int index = 0; index < compressedSize; ++index)
        numArray[index] = RomHandler.rom[num2 + index];
      GECompression geCompression = new GECompression();
      byte[] Buffer = numArray;
      geCompression.SetCompressedBuffer(Buffer, Buffer.Length);
      int fileSize = 0;
      return geCompression.OutputDecompressedBuffer(ref fileSize, ref compressedSize);
    }

    public static byte[] GetDecompressedFile(int pntr, int length)
    {
      byte[] decompressedFile = new byte[length];
      for (int index = 0; index < length; ++index)
        decompressedFile[index] = RomHandler.rom[pntr + index];
      return decompressedFile;
    }

    public static void DecompressFileToHDD(int pntr)
    {
      if (File.Exists(RomHandler.tmpDir + pntr.ToString("x")))
        return;
      try
      {
        byte[] byteArray = RomHandler.DecompressFileToByteArray(pntr);
        FileStream output = File.Create(RomHandler.tmpDir + pntr.ToString("x"));
        BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
        try
        {
          binaryWriter.Write(byteArray);
          binaryWriter.Close();
          output.Close();
        }
        catch
        {
          binaryWriter.Close();
          output.Close();
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
