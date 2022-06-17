// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.MidiParse
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.IO;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  public static class MidiParse
  {
    private static uint CharArrayToLong(byte[] currentSpot, int offset) => Convert.ToUInt32((uint) ((((int) currentSpot[offset] << 8 | (int) currentSpot[offset + 1]) << 8 | (int) currentSpot[offset + 2]) << 8) | (uint) currentSpot[offset + 3]);

    private static ushort CharArrayToShort(byte[] currentSpot, int offset) => Convert.ToUInt16((int) currentSpot[offset] << 8 | (int) currentSpot[offset + 1]);

    private static uint Flip32Bit(uint inLong) => Convert.ToUInt32((uint) ((int) ((inLong & 4278190080U) >> 24) | (int) ((inLong & 16711680U) >> 8) | ((int) inLong & 65280) << 8 | ((int) inLong & (int) byte.MaxValue) << 24));

    private static ushort Flip16Bit(ushort tempShort) => Convert.ToUInt16(((int) tempShort & 65280) >> 8 | ((int) tempShort & (int) byte.MaxValue) << 8);

    private static uint GetVLBytes(
      byte[] vlByteArray,
      ref int offset,
      ref uint original,
      ref byte[] altPattern,
      ref byte altOffset,
      ref byte altLength,
      bool includeFERepeats)
    {
      uint num1 = 0;
      byte vlByte1;
      while (true)
      {
        if (altPattern != null)
        {
          vlByte1 = altPattern[(int) altOffset];
          ++altOffset;
          if ((int) altOffset == (int) altLength && altPattern != null)
          {
            altPattern = (byte[]) null;
            altOffset = (byte) 0;
            altLength = (byte) 0;
          }
        }
        else
        {
          vlByte1 = vlByteArray[offset];
          ++offset;
          if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] != (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
          {
            int vlByte2 = (int) vlByteArray[offset];
            ++offset;
            ushort uint16 = Convert.ToUInt16(vlByte2 << 8 | (int) vlByteArray[offset]);
            ++offset;
            byte vlByte3 = vlByteArray[offset];
            ++offset;
            altPattern = new byte[(int) vlByte3];
            for (int index = offset - 4 - (int) uint16; index < offset - 4 - (int) uint16 + (int) vlByte3; ++index)
              altPattern[index - (offset - 4 - (int) uint16)] = vlByteArray[index];
            altOffset = (byte) 0;
            altLength = vlByte3;
            vlByte1 = altPattern[(int) altOffset];
            ++altOffset;
          }
          else if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] == (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
            ++offset;
          if ((int) altOffset == (int) altLength && altPattern != null)
          {
            altPattern = (byte[]) null;
            altOffset = (byte) 0;
            altLength = (byte) 0;
          }
        }
        if ((int) vlByte1 >> 7 == 1)
          num1 = num1 + (uint) vlByte1 << 8;
        else
          break;
      }
      uint num2 = num1 + (uint) vlByte1;
      original = num2;
      uint vlBytes = 0;
      int num3 = 0;
      int num4 = 0;
      while (true)
      {
        vlBytes += (uint) (((int) (num2 >> num3) & (int) sbyte.MaxValue) << num4);
        if (num3 != 24)
        {
          num3 += 8;
          num4 += 7;
        }
        else
          break;
      }
      return vlBytes;
    }

    private static void WriteVLBytes(
      FileStream outFile,
      uint value,
      uint length,
      bool includeFERepeats)
    {
      switch (length)
      {
        case 1:
          byte num1 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num1);
          break;
        case 2:
          byte num2 = (byte) (value >> 8 & (uint) byte.MaxValue);
          outFile.WriteByte(num2);
          byte num3 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num3);
          break;
        case 3:
          byte num4 = (byte) (value >> 16 & (uint) byte.MaxValue);
          outFile.WriteByte(num4);
          byte num5 = (byte) (value >> 8 & (uint) byte.MaxValue);
          outFile.WriteByte(num5);
          byte num6 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num6);
          break;
        default:
          byte num7 = (byte) (value >> 24 & (uint) byte.MaxValue);
          outFile.WriteByte(num7);
          byte num8 = (byte) (value >> 8 & (uint) byte.MaxValue);
          outFile.WriteByte(num8);
          byte num9 = (byte) (value & (uint) byte.MaxValue);
          outFile.WriteByte(num9);
          break;
      }
    }

    private static byte ReadMidiByte(
      byte[] vlByteArray,
      ref int offset,
      ref byte[] altPattern,
      ref byte altOffset,
      ref byte altLength,
      bool includeFERepeats)
    {
      byte vlByte1;
      if (altPattern != null)
      {
        vlByte1 = altPattern[(int) altOffset];
        ++altOffset;
      }
      else
      {
        vlByte1 = vlByteArray[offset];
        ++offset;
        if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] != (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
        {
          int vlByte2 = (int) vlByteArray[offset];
          ++offset;
          uint num = (uint) (vlByte2 << 8) | (uint) vlByteArray[offset];
          ++offset;
          byte vlByte3 = vlByteArray[offset];
          ++offset;
          altPattern = new byte[(int) vlByte3];
          for (int int32 = Convert.ToInt32((long) (offset - 4) - (long) num); (long) int32 < (long) (offset - 4) - (long) num + (long) vlByte3; ++int32)
            altPattern[(long) int32 - ((long) (offset - 4) - (long) num)] = vlByteArray[int32];
          altOffset = (byte) 0;
          altLength = vlByte3;
          vlByte1 = altPattern[(int) altOffset];
          ++altOffset;
        }
        else if (((vlByte1 != (byte) 254 ? 0 : (vlByteArray[offset] == (byte) 254 ? 1 : 0)) & (includeFERepeats ? 1 : 0)) != 0)
          ++offset;
      }
      if ((int) altOffset == (int) altLength && altPattern != null)
      {
        altPattern = (byte[]) null;
        altOffset = (byte) 0;
        altLength = (byte) 0;
      }
      return vlByte1;
    }

    private static uint ReturnVLBytes(uint value, ref uint length)
    {
      byte num1 = Convert.ToByte(value >> 21 & (uint) sbyte.MaxValue);
      byte num2 = Convert.ToByte(value >> 14 & (uint) sbyte.MaxValue);
      byte num3 = Convert.ToByte(value >> 7 & (uint) sbyte.MaxValue);
      byte num4 = Convert.ToByte(value & (uint) sbyte.MaxValue);
      if (num1 > (byte) 0)
      {
        int num5 = -2139062272 | (int) num1 << 24 | (int) num2 << 16 | (int) num3 << 8 | (int) num4;
        length = 4U;
        return (uint) num5;
      }
      if (num2 > (byte) 0)
      {
        int num6 = 8421376 | (int) num2 << 16 | (int) num3 << 8 | (int) num4;
        length = 3U;
        return (uint) num6;
      }
      if (num3 > (byte) 0)
      {
        int num7 = 32768 | (int) num3 << 8 | (int) num4;
        length = 2U;
        return (uint) num7;
      }
      length = 1U;
      return value;
    }

    private static void WriteLongToBuffer(byte[] Buffer, uint address, uint data)
    {
      Buffer[(int) address] = Convert.ToByte(data >> 24 & (uint) byte.MaxValue);
      Buffer[(int) address + 1] = Convert.ToByte(data >> 16 & (uint) byte.MaxValue);
      Buffer[(int) address + 2] = Convert.ToByte(data >> 8 & (uint) byte.MaxValue);
      Buffer[(int) address + 3] = Convert.ToByte(data & (uint) byte.MaxValue);
    }

    public static void GEMidiToMidi(
      byte[] inputMID,
      int inputSize,
      string outFileName,
      ref int numberInstruments)
    {
      numberInstruments = 0;
      try
      {
        FileStream outFile = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num1 = (int) MessageBox.Show("Error outputting file", "Error");
        }
        else
        {
          uint num2 = 68;
          int num3 = 0;
          for (int offset = 0; (long) offset < (long) (num2 - 4U); offset += 4)
          {
            if (MidiParse.CharArrayToLong(inputMID, offset) != 0U)
              ++num3;
          }
          uint num4 = MidiParse.Flip32Bit(1297377380U);
          outFile.Write(BitConverter.GetBytes(num4), 0, 4);
          uint num5 = MidiParse.Flip32Bit(6U);
          outFile.Write(BitConverter.GetBytes(num5), 0, 4);
          uint num6 = MidiParse.Flip32Bit(Convert.ToUInt32(65536 | num3));
          outFile.Write(BitConverter.GetBytes(num6), 0, 4);
          ushort num7 = MidiParse.Flip16Bit(Convert.ToUInt16(MidiParse.CharArrayToLong(inputMID, 64)));
          outFile.Write(BitConverter.GetBytes(num7), 0, 2);
          int num8 = 0;
          for (int offset = 0; (long) offset < (long) (num2 - 4U); offset += 4)
          {
            uint num9 = 0;
            int index1 = 0;
            TrackEvent[] trackEventArray = new TrackEvent[1048576];
            for (int index2 = 0; index2 < 1048576; ++index2)
            {
              trackEventArray[index2] = new TrackEvent();
              trackEventArray[index2].contents = (byte[]) null;
              trackEventArray[index2].contentSize = 0;
              trackEventArray[index2].obsoleteEvent = false;
              trackEventArray[index2].deltaTime = 0U;
              trackEventArray[index2].absoluteTime = 0U;
            }
            int int32 = Convert.ToInt32(MidiParse.CharArrayToLong(inputMID, offset));
            if (int32 != 0)
            {
              uint num10 = MidiParse.Flip32Bit(1297379947U);
              outFile.Write(BitConverter.GetBytes(num10), 0, 4);
              int num11 = 0;
              byte[] altPattern = (byte[]) null;
              byte altOffset = 0;
              byte altLength = 0;
              bool flag1 = false;
              while (int32 < inputSize && !flag1)
              {
                if (index1 > 589824)
                  return;
                uint original = 0;
                uint vlBytes1 = MidiParse.GetVLBytes(inputMID, ref int32, ref original, ref altPattern, ref altOffset, ref altLength, true);
                trackEventArray[index1].deltaTime += vlBytes1;
                num9 += vlBytes1;
                trackEventArray[index1].absoluteTime = num9;
                byte num12 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                bool flag2 = num12 < (byte) 128;
                if (num12 == byte.MaxValue || flag2 && num11 == (int) byte.MaxValue)
                {
                  switch (!flag2 ? MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true) : num12)
                  {
                    case 45:
                      int num13 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      int num14 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      int num15 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      int num16 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      int num17 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      int num18 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, false);
                      break;
                    case 46:
                      int num19 = (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      if (MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true) == byte.MaxValue)
                        break;
                      break;
                    case 47:
                      trackEventArray[index1].type = byte.MaxValue;
                      trackEventArray[index1].contentSize = 2;
                      trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                      trackEventArray[index1].contents[0] = (byte) 47;
                      trackEventArray[index1].contents[1] = (byte) 0;
                      ++index1;
                      flag1 = true;
                      break;
                    case 81:
                      int num20 = ((int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true)) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                      trackEventArray[index1].type = byte.MaxValue;
                      trackEventArray[index1].contentSize = 5;
                      trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                      trackEventArray[index1].contents[0] = (byte) 81;
                      trackEventArray[index1].contents[1] = (byte) 3;
                      trackEventArray[index1].contents[2] = Convert.ToByte(num20 >> 16 & (int) byte.MaxValue);
                      trackEventArray[index1].contents[3] = Convert.ToByte(num20 >> 8 & (int) byte.MaxValue);
                      trackEventArray[index1].contents[4] = Convert.ToByte(num20 & (int) byte.MaxValue);
                      ++index1;
                      double num21 = 60000000.0 / (double) num20;
                      break;
                  }
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 144 && num12 < (byte) 160 || flag2 && num11 >= 144 && num11 < 160)
                {
                  byte num22;
                  if (flag2)
                  {
                    trackEventArray[index1].type = Convert.ToByte(num11);
                    num22 = num12;
                    int num23 = (int) Convert.ToByte(num11);
                  }
                  else
                  {
                    trackEventArray[index1].type = num12;
                    num22 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  }
                  byte num24 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  uint vlBytes2 = MidiParse.GetVLBytes(inputMID, ref int32, ref original, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index1].durationTime = vlBytes2;
                  trackEventArray[index1].contentSize = 2;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num22;
                  trackEventArray[index1].contents[1] = num24;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 176 && num12 < (byte) 192 || flag2 && num11 >= 176 && num11 < 192)
                {
                  byte num25;
                  if (flag2)
                  {
                    num25 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num25 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  byte num26 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index1].contentSize = 2;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num25;
                  trackEventArray[index1].contents[1] = num26;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 192 && num12 < (byte) 208 || flag2 && num11 >= 192 && num11 < 208)
                {
                  byte num27;
                  if (flag2)
                  {
                    num27 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num27 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  trackEventArray[index1].contentSize = 1;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num27;
                  if ((int) num27 >= numberInstruments)
                    numberInstruments = (int) num27 + 1;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 208 && num12 < (byte) 224 || flag2 && num11 >= 208 && num11 < 224)
                {
                  byte num28;
                  if (flag2)
                  {
                    num28 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num28 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  trackEventArray[index1].contentSize = 1;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num28;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
                else if (num12 >= (byte) 224 && num12 < (byte) 240 || flag2 && num11 >= 224 && num11 < 240)
                {
                  byte num29;
                  if (flag2)
                  {
                    num29 = num12;
                    trackEventArray[index1].type = Convert.ToByte(num11);
                  }
                  else
                  {
                    num29 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index1].type = num12;
                  }
                  byte num30 = MidiParse.ReadMidiByte(inputMID, ref int32, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index1].contentSize = 2;
                  trackEventArray[index1].contents = new byte[trackEventArray[index1].contentSize];
                  trackEventArray[index1].contents[0] = num29;
                  trackEventArray[index1].contents[1] = num30;
                  ++index1;
                  if (!flag2)
                    num11 = (int) num12;
                }
              }
              for (int index3 = 0; index3 < index1; ++index3)
              {
                if (index1 > 589824)
                  return;
                TrackEvent trackEvent = trackEventArray[index3];
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160 && trackEvent.durationTime > 0U)
                {
                  uint num31 = trackEvent.absoluteTime + trackEvent.durationTime;
                  if (index3 != index1 - 1)
                  {
                    for (int index4 = index3 + 1; index4 < index1; ++index4)
                    {
                      if (trackEventArray[index4].absoluteTime > num31 && index4 != index1 - 1)
                      {
                        for (int index5 = index1 - 1; index5 >= index4; --index5)
                        {
                          trackEventArray[index5 + 1].absoluteTime = trackEventArray[index5].absoluteTime;
                          trackEventArray[index5 + 1].contentSize = trackEventArray[index5].contentSize;
                          if (trackEventArray[index5 + 1].contents != null)
                            trackEventArray[index5 + 1].contents = (byte[]) null;
                          trackEventArray[index5 + 1].contents = new byte[trackEventArray[index5].contentSize];
                          for (int index6 = 0; index6 < trackEventArray[index5].contentSize; ++index6)
                            trackEventArray[index5 + 1].contents[index6] = trackEventArray[index5].contents[index6];
                          trackEventArray[index5 + 1].deltaTime = trackEventArray[index5].deltaTime;
                          trackEventArray[index5 + 1].durationTime = trackEventArray[index5].durationTime;
                          trackEventArray[index5 + 1].obsoleteEvent = trackEventArray[index5].obsoleteEvent;
                          trackEventArray[index5 + 1].type = trackEventArray[index5].type;
                        }
                        trackEventArray[index4].type = trackEventArray[index3].type;
                        trackEventArray[index4].absoluteTime = num31;
                        trackEventArray[index4].deltaTime = trackEventArray[index4].absoluteTime - trackEventArray[index4 - 1].absoluteTime;
                        trackEventArray[index4].contentSize = trackEventArray[index3].contentSize;
                        trackEventArray[index4].durationTime = 0U;
                        trackEventArray[index4].contents = new byte[trackEventArray[index4].contentSize];
                        trackEventArray[index4].contents[0] = trackEventArray[index3].contents[0];
                        trackEventArray[index4].contents[1] = (byte) 0;
                        trackEventArray[index4 + 1].deltaTime = trackEventArray[index4 + 1].absoluteTime - trackEventArray[index4].absoluteTime;
                        int deltaTime = (int) trackEventArray[index4].deltaTime;
                        ++index1;
                        break;
                      }
                      if (index4 == index1 - 1)
                      {
                        trackEventArray[index4 + 1].absoluteTime = num31;
                        trackEventArray[index4 + 1].contentSize = trackEventArray[index4].contentSize;
                        if (trackEventArray[index4 + 1].contents != null)
                          trackEventArray[index4 + 1].contents = (byte[]) null;
                        trackEventArray[index4 + 1].contents = new byte[trackEventArray[index4].contentSize];
                        for (int index7 = 0; index7 < trackEventArray[index4].contentSize; ++index7)
                          trackEventArray[index4 + 1].contents[index7] = trackEventArray[index4].contents[index7];
                        trackEventArray[index4 + 1].deltaTime = trackEventArray[index4].deltaTime;
                        trackEventArray[index4 + 1].durationTime = trackEventArray[index4].durationTime;
                        trackEventArray[index4 + 1].obsoleteEvent = trackEventArray[index4].obsoleteEvent;
                        trackEventArray[index4 + 1].type = trackEventArray[index4].type;
                        trackEventArray[index4].type = trackEventArray[index3].type;
                        trackEventArray[index4].absoluteTime = num31;
                        trackEventArray[index4].deltaTime = trackEventArray[index4].absoluteTime - trackEventArray[index4 - 1].absoluteTime;
                        trackEventArray[index4].contentSize = trackEventArray[index3].contentSize;
                        trackEventArray[index4].durationTime = 0U;
                        trackEventArray[index4].contents = new byte[trackEventArray[index4].contentSize];
                        trackEventArray[index4].contents[0] = trackEventArray[index3].contents[0];
                        trackEventArray[index4].contents[1] = (byte) 0;
                        trackEventArray[index4 + 1].deltaTime = trackEventArray[index4 + 1].absoluteTime - trackEventArray[index4].absoluteTime;
                        ++index1;
                        break;
                      }
                    }
                  }
                  else
                  {
                    trackEventArray[index3 + 1].absoluteTime = num31;
                    trackEventArray[index3 + 1].contentSize = trackEventArray[index3].contentSize;
                    if (trackEventArray[index3 + 1].contents != null)
                      trackEventArray[index3 + 1].contents = (byte[]) null;
                    trackEventArray[index3 + 1].contents = new byte[trackEventArray[index3].contentSize];
                    for (int index8 = 0; index8 < trackEventArray[index3].contentSize; ++index8)
                      trackEventArray[index3 + 1].contents[index8] = trackEventArray[index3].contents[index8];
                    trackEventArray[index3 + 1].deltaTime = trackEventArray[index3].deltaTime;
                    trackEventArray[index3 + 1].durationTime = trackEventArray[index3].durationTime;
                    trackEventArray[index3 + 1].obsoleteEvent = trackEventArray[index3].obsoleteEvent;
                    trackEventArray[index3 + 1].type = trackEventArray[index3].type;
                    trackEventArray[index3].type = trackEventArray[index3].type;
                    trackEventArray[index3].absoluteTime = num31;
                    int num32 = (int) trackEventArray[index3].absoluteTime - (int) trackEventArray[index3 - 1].absoluteTime;
                    trackEventArray[index3].deltaTime = trackEventArray[index3].absoluteTime - trackEventArray[index3 - 1].absoluteTime;
                    trackEventArray[index3].contentSize = trackEventArray[index3].contentSize;
                    trackEventArray[index3].durationTime = 0U;
                    trackEventArray[index3].contents = new byte[trackEventArray[index3].contentSize];
                    trackEventArray[index3].contents[0] = trackEventArray[index3].contents[0];
                    trackEventArray[index3].contents[1] = (byte) 0;
                    trackEventArray[index3 + 1].deltaTime = trackEventArray[index3 + 1].absoluteTime - trackEventArray[index3].absoluteTime;
                    int deltaTime = (int) trackEventArray[index3].deltaTime;
                    ++index1;
                  }
                }
              }
              uint num33 = 0;
              uint inLong = 0;
              byte num34 = 0;
              for (int index9 = 0; index9 < index1; ++index9)
              {
                TrackEvent trackEvent = trackEventArray[index9];
                if (trackEvent.obsoleteEvent)
                {
                  num33 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  int num35 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num33, ref length);
                  num33 = 0U;
                  uint num36 = inLong + length;
                  if ((int) trackEvent.type != (int) num34 || trackEvent.type == byte.MaxValue)
                    ++num36;
                  inLong = num36 + Convert.ToUInt32(trackEvent.contentSize);
                  num34 = trackEvent.type;
                }
              }
              uint num37 = MidiParse.Flip32Bit(inLong);
              outFile.Write(BitConverter.GetBytes(num37), 0, 4);
              uint num38 = 0;
              byte num39 = 0;
              for (int index10 = 0; index10 < index1; ++index10)
              {
                TrackEvent trackEvent = trackEventArray[index10];
                if (trackEvent.obsoleteEvent)
                {
                  num38 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  uint num40 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num38, ref length);
                  num38 = 0U;
                  MidiParse.WriteVLBytes(outFile, num40, length, true);
                  if ((int) trackEvent.type != (int) num39 || trackEvent.type == byte.MaxValue)
                    outFile.WriteByte(trackEvent.type);
                  outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                  num39 = trackEvent.type;
                }
              }
              for (int index11 = 0; index11 < index1; ++index11)
              {
                if (trackEventArray[index11].contents != null)
                  trackEventArray[index11].contents = (byte[]) null;
              }
            }
            ++num8;
          }
          outFile.Close();
          outFile.Dispose();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error exporting " + ex.ToString(), "Error");
      }
    }

    public static void BTMidiToMidi(
      byte[] inputMID,
      int inputSize,
      string outFileName,
      ref int numberInstruments)
    {
      numberInstruments = 0;
      try
      {
        FileStream outFile = new FileStream(outFileName, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num1 = (int) MessageBox.Show("Error outputting file", "Error");
        }
        else
        {
          int int32_1 = Convert.ToInt32(MidiParse.CharArrayToLong(inputMID, 4));
          uint num2 = MidiParse.Flip32Bit(1297377380U);
          outFile.Write(BitConverter.GetBytes(num2), 0, 4);
          uint num3 = MidiParse.Flip32Bit(6U);
          outFile.Write(BitConverter.GetBytes(num3), 0, 4);
          uint num4 = MidiParse.Flip32Bit(Convert.ToUInt32(65536 | int32_1));
          outFile.Write(BitConverter.GetBytes(num4), 0, 4);
          ushort num5 = MidiParse.Flip16Bit(Convert.ToUInt16(MidiParse.CharArrayToLong(inputMID, 0)));
          outFile.Write(BitConverter.GetBytes(num5), 0, 2);
          int num6 = 0;
          for (int index1 = 0; index1 < int32_1; ++index1)
          {
            uint num7 = 0;
            int index2 = 0;
            TrackEvent[] trackEventArray = new TrackEvent[1048576];
            for (int index3 = 0; index3 < 1048576; ++index3)
            {
              trackEventArray[index3] = new TrackEvent();
              trackEventArray[index3].contents = (byte[]) null;
              trackEventArray[index3].contentSize = 0;
              trackEventArray[index3].obsoleteEvent = false;
              trackEventArray[index3].deltaTime = 0U;
              trackEventArray[index3].absoluteTime = 0U;
            }
            int int32_2 = Convert.ToInt32(MidiParse.CharArrayToLong(inputMID, index1 * 4 + 8));
            if (int32_2 != 0)
            {
              uint num8 = MidiParse.Flip32Bit(1297379947U);
              outFile.Write(BitConverter.GetBytes(num8), 0, 4);
              int num9 = 0;
              byte[] altPattern = (byte[]) null;
              byte altOffset = 0;
              byte altLength = 0;
              bool flag1 = false;
              while (int32_2 < inputSize && !flag1)
              {
                if (index2 > 589824)
                  return;
                uint original = 0;
                uint vlBytes1 = MidiParse.GetVLBytes(inputMID, ref int32_2, ref original, ref altPattern, ref altOffset, ref altLength, true);
                trackEventArray[index2].deltaTime += vlBytes1;
                num7 += vlBytes1;
                trackEventArray[index2].absoluteTime = num7;
                byte num10 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                bool flag2 = num10 < (byte) 128;
                if (num10 == byte.MaxValue || flag2 && num9 == (int) byte.MaxValue)
                {
                  switch (!flag2 ? MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true) : num10)
                  {
                    case 45:
                      int num11 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      int num12 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      int num13 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      int num14 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      int num15 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      int num16 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, false);
                      break;
                    case 46:
                      int num17 = (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      if (MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true) == byte.MaxValue)
                        break;
                      break;
                    case 47:
                      trackEventArray[index2].type = byte.MaxValue;
                      trackEventArray[index2].contentSize = 2;
                      trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                      trackEventArray[index2].contents[0] = (byte) 47;
                      trackEventArray[index2].contents[1] = (byte) 0;
                      ++index2;
                      flag1 = true;
                      break;
                    case 81:
                      int num18 = ((int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true)) << 8 | (int) MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                      trackEventArray[index2].type = byte.MaxValue;
                      trackEventArray[index2].contentSize = 5;
                      trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                      trackEventArray[index2].contents[0] = (byte) 81;
                      trackEventArray[index2].contents[1] = (byte) 3;
                      trackEventArray[index2].contents[2] = Convert.ToByte(num18 >> 16 & (int) byte.MaxValue);
                      trackEventArray[index2].contents[3] = Convert.ToByte(num18 >> 8 & (int) byte.MaxValue);
                      trackEventArray[index2].contents[4] = Convert.ToByte(num18 & (int) byte.MaxValue);
                      ++index2;
                      double num19 = 60000000.0 / (double) num18;
                      break;
                  }
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 144 && num10 < (byte) 160 || flag2 && num9 >= 144 && num9 < 160)
                {
                  byte num20;
                  if (flag2)
                  {
                    trackEventArray[index2].type = Convert.ToByte(num9);
                    num20 = num10;
                    int num21 = (int) Convert.ToByte(num9);
                  }
                  else
                  {
                    trackEventArray[index2].type = num10;
                    num20 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  }
                  byte num22 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  uint vlBytes2 = MidiParse.GetVLBytes(inputMID, ref int32_2, ref original, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index2].durationTime = vlBytes2;
                  trackEventArray[index2].contentSize = 2;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num20;
                  trackEventArray[index2].contents[1] = num22;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 176 && num10 < (byte) 192 || flag2 && num9 >= 176 && num9 < 192)
                {
                  byte num23;
                  if (flag2)
                  {
                    num23 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num23 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  byte num24 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index2].contentSize = 2;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num23;
                  trackEventArray[index2].contents[1] = num24;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 192 && num10 < (byte) 208 || flag2 && num9 >= 192 && num9 < 208)
                {
                  byte num25;
                  if (flag2)
                  {
                    num25 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num25 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  trackEventArray[index2].contentSize = 1;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num25;
                  if ((int) num25 >= numberInstruments)
                    numberInstruments = (int) num25 + 1;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 208 && num10 < (byte) 224 || flag2 && num9 >= 208 && num9 < 224)
                {
                  byte num26;
                  if (flag2)
                  {
                    num26 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num26 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  trackEventArray[index2].contentSize = 1;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num26;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
                else if (num10 >= (byte) 224 && num10 < (byte) 240 || flag2 && num9 >= 224 && num9 < 240)
                {
                  byte num27;
                  if (flag2)
                  {
                    num27 = num10;
                    trackEventArray[index2].type = Convert.ToByte(num9);
                  }
                  else
                  {
                    num27 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                    trackEventArray[index2].type = num10;
                  }
                  byte num28 = MidiParse.ReadMidiByte(inputMID, ref int32_2, ref altPattern, ref altOffset, ref altLength, true);
                  trackEventArray[index2].contentSize = 2;
                  trackEventArray[index2].contents = new byte[trackEventArray[index2].contentSize];
                  trackEventArray[index2].contents[0] = num27;
                  trackEventArray[index2].contents[1] = num28;
                  ++index2;
                  if (!flag2)
                    num9 = (int) num10;
                }
              }
              for (int index4 = 0; index4 < index2; ++index4)
              {
                if (index2 > 589824)
                  return;
                TrackEvent trackEvent = trackEventArray[index4];
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160 && trackEvent.durationTime > 0U)
                {
                  uint num29 = trackEvent.absoluteTime + trackEvent.durationTime;
                  if (index4 != index2 - 1)
                  {
                    for (int index5 = index4 + 1; index5 < index2; ++index5)
                    {
                      if (trackEventArray[index5].absoluteTime > num29 && index5 != index2 - 1)
                      {
                        for (int index6 = index2 - 1; index6 >= index5; --index6)
                        {
                          trackEventArray[index6 + 1].absoluteTime = trackEventArray[index6].absoluteTime;
                          trackEventArray[index6 + 1].contentSize = trackEventArray[index6].contentSize;
                          if (trackEventArray[index6 + 1].contents != null)
                            trackEventArray[index6 + 1].contents = (byte[]) null;
                          trackEventArray[index6 + 1].contents = new byte[trackEventArray[index6].contentSize];
                          for (int index7 = 0; index7 < trackEventArray[index6].contentSize; ++index7)
                            trackEventArray[index6 + 1].contents[index7] = trackEventArray[index6].contents[index7];
                          trackEventArray[index6 + 1].deltaTime = trackEventArray[index6].deltaTime;
                          trackEventArray[index6 + 1].durationTime = trackEventArray[index6].durationTime;
                          trackEventArray[index6 + 1].obsoleteEvent = trackEventArray[index6].obsoleteEvent;
                          trackEventArray[index6 + 1].type = trackEventArray[index6].type;
                        }
                        trackEventArray[index5].type = trackEventArray[index4].type;
                        trackEventArray[index5].absoluteTime = num29;
                        trackEventArray[index5].deltaTime = trackEventArray[index5].absoluteTime - trackEventArray[index5 - 1].absoluteTime;
                        trackEventArray[index5].contentSize = trackEventArray[index4].contentSize;
                        trackEventArray[index5].durationTime = 0U;
                        trackEventArray[index5].contents = new byte[trackEventArray[index5].contentSize];
                        trackEventArray[index5].contents[0] = trackEventArray[index4].contents[0];
                        trackEventArray[index5].contents[1] = (byte) 0;
                        trackEventArray[index5 + 1].deltaTime = trackEventArray[index5 + 1].absoluteTime - trackEventArray[index5].absoluteTime;
                        int deltaTime = (int) trackEventArray[index5].deltaTime;
                        ++index2;
                        break;
                      }
                      if (index5 == index2 - 1)
                      {
                        trackEventArray[index5 + 1].absoluteTime = num29;
                        trackEventArray[index5 + 1].contentSize = trackEventArray[index5].contentSize;
                        if (trackEventArray[index5 + 1].contents != null)
                          trackEventArray[index5 + 1].contents = (byte[]) null;
                        trackEventArray[index5 + 1].contents = new byte[trackEventArray[index5].contentSize];
                        for (int index8 = 0; index8 < trackEventArray[index5].contentSize; ++index8)
                          trackEventArray[index5 + 1].contents[index8] = trackEventArray[index5].contents[index8];
                        trackEventArray[index5 + 1].deltaTime = trackEventArray[index5].deltaTime;
                        trackEventArray[index5 + 1].durationTime = trackEventArray[index5].durationTime;
                        trackEventArray[index5 + 1].obsoleteEvent = trackEventArray[index5].obsoleteEvent;
                        trackEventArray[index5 + 1].type = trackEventArray[index5].type;
                        trackEventArray[index5].type = trackEventArray[index4].type;
                        trackEventArray[index5].absoluteTime = num29;
                        trackEventArray[index5].deltaTime = trackEventArray[index5].absoluteTime - trackEventArray[index5 - 1].absoluteTime;
                        trackEventArray[index5].contentSize = trackEventArray[index4].contentSize;
                        trackEventArray[index5].durationTime = 0U;
                        trackEventArray[index5].contents = new byte[trackEventArray[index5].contentSize];
                        trackEventArray[index5].contents[0] = trackEventArray[index4].contents[0];
                        trackEventArray[index5].contents[1] = (byte) 0;
                        trackEventArray[index5 + 1].deltaTime = trackEventArray[index5 + 1].absoluteTime - trackEventArray[index5].absoluteTime;
                        ++index2;
                        break;
                      }
                    }
                  }
                  else
                  {
                    trackEventArray[index4 + 1].absoluteTime = num29;
                    trackEventArray[index4 + 1].contentSize = trackEventArray[index4].contentSize;
                    if (trackEventArray[index4 + 1].contents != null)
                      trackEventArray[index4 + 1].contents = (byte[]) null;
                    trackEventArray[index4 + 1].contents = new byte[trackEventArray[index4].contentSize];
                    for (int index9 = 0; index9 < trackEventArray[index4].contentSize; ++index9)
                      trackEventArray[index4 + 1].contents[index9] = trackEventArray[index4].contents[index9];
                    trackEventArray[index4 + 1].deltaTime = trackEventArray[index4].deltaTime;
                    trackEventArray[index4 + 1].durationTime = trackEventArray[index4].durationTime;
                    trackEventArray[index4 + 1].obsoleteEvent = trackEventArray[index4].obsoleteEvent;
                    trackEventArray[index4 + 1].type = trackEventArray[index4].type;
                    trackEventArray[index4].type = trackEventArray[index4].type;
                    trackEventArray[index4].absoluteTime = num29;
                    int num30 = (int) trackEventArray[index4].absoluteTime - (int) trackEventArray[index4 - 1].absoluteTime;
                    trackEventArray[index4].deltaTime = trackEventArray[index4].absoluteTime - trackEventArray[index4 - 1].absoluteTime;
                    trackEventArray[index4].contentSize = trackEventArray[index4].contentSize;
                    trackEventArray[index4].durationTime = 0U;
                    trackEventArray[index4].contents = new byte[trackEventArray[index4].contentSize];
                    trackEventArray[index4].contents[0] = trackEventArray[index4].contents[0];
                    trackEventArray[index4].contents[1] = (byte) 0;
                    trackEventArray[index4 + 1].deltaTime = trackEventArray[index4 + 1].absoluteTime - trackEventArray[index4].absoluteTime;
                    int deltaTime = (int) trackEventArray[index4].deltaTime;
                    ++index2;
                  }
                }
              }
              uint num31 = 0;
              uint inLong = 0;
              byte num32 = 0;
              for (int index10 = 0; index10 < index2; ++index10)
              {
                TrackEvent trackEvent = trackEventArray[index10];
                if (trackEvent.obsoleteEvent)
                {
                  num31 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  int num33 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num31, ref length);
                  num31 = 0U;
                  uint num34 = inLong + length;
                  if ((int) trackEvent.type != (int) num32 || trackEvent.type == byte.MaxValue)
                    ++num34;
                  inLong = num34 + Convert.ToUInt32(trackEvent.contentSize);
                  num32 = trackEvent.type;
                }
              }
              uint num35 = MidiParse.Flip32Bit(inLong);
              outFile.Write(BitConverter.GetBytes(num35), 0, 4);
              uint num36 = 0;
              byte num37 = 0;
              for (int index11 = 0; index11 < index2; ++index11)
              {
                TrackEvent trackEvent = trackEventArray[index11];
                if (trackEvent.obsoleteEvent)
                {
                  num36 += trackEvent.deltaTime;
                }
                else
                {
                  uint length = 0;
                  uint num38 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num36, ref length);
                  num36 = 0U;
                  MidiParse.WriteVLBytes(outFile, num38, length, true);
                  if ((int) trackEvent.type != (int) num37 || trackEvent.type == byte.MaxValue)
                    outFile.WriteByte(trackEvent.type);
                  outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                  num37 = trackEvent.type;
                }
              }
              for (int index12 = 0; index12 < index2; ++index12)
              {
                if (trackEventArray[index12].contents != null)
                  trackEventArray[index12].contents = (byte[]) null;
              }
            }
            ++num6;
          }
          outFile.Close();
          outFile.Dispose();
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error exporting " + ex.ToString(), "Error");
      }
    }

    public static bool MidiToGEFormat(
      string input,
      string output,
      bool loop,
      uint loopPoint,
      bool useRepeaters)
    {
      try
      {
        TrackEvent[,] trackEventArray = new TrackEvent[32, 65536];
        for (int index1 = 0; index1 < 32; ++index1)
        {
          for (int index2 = 0; index2 < 65536; ++index2)
            trackEventArray[index1, index2] = new TrackEvent();
        }
        int[] numArray1 = new int[32];
        for (int index = 0; index < 32; ++index)
          numArray1[index] = 0;
        string str = input;
        int int32_1 = Convert.ToInt32(new FileInfo(str).Length);
        byte[] numArray2 = File.ReadAllBytes(str);
        if (MidiParse.CharArrayToLong(numArray2, 0) != 1297377380U)
        {
          int num = (int) MessageBox.Show("Invalid midi hdr", "Error");
          return false;
        }
        int num1 = (int) MidiParse.CharArrayToLong(numArray2, 4);
        ushort num2 = MidiParse.CharArrayToShort(numArray2, 8);
        ushort num3 = MidiParse.CharArrayToShort(numArray2, 10);
        ushort inLong1 = MidiParse.CharArrayToShort(numArray2, 12);
        if (num3 > (ushort) 16)
        {
          int num4 = (int) MessageBox.Show("Too many tracks, truncated to 16", "Warning");
          num3 = (ushort) 16;
        }
        FileStream outFile = new FileStream(output, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num5 = (int) MessageBox.Show("Error outputting file", "Error");
          return false;
        }
        int num6 = (int) num3;
        if (num2 != (ushort) 0 && num2 != (ushort) 1)
        {
          int num7 = (int) MessageBox.Show("Invalid midi type", "Error");
          return false;
        }
        int offset = 14;
        byte[] altPattern = (byte[]) null;
        byte altOffset = 0;
        byte altLength = 0;
        bool flag1 = false;
        uint num8 = 0;
        uint[] numArray3 = new uint[16];
        for (int index = 0; index < 16; ++index)
          numArray3[index] = 0U;
        for (int index3 = 0; index3 < num6; ++index3)
        {
          uint num9 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num10 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num11 = (int) numArray2[offset + 4];
          int num12 = (int) numArray2[offset + 5];
          int num13 = (int) numArray2[offset + 6];
          int num14 = (int) numArray2[offset + 7];
          offset += 8;
          byte num15 = byte.MaxValue;
          bool flag2 = false;
          while (!flag2 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num9 += vlBytes;
            byte num16 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag3 = num16 <= (byte) 127;
            if (num16 == byte.MaxValue)
            {
              byte num17 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num17)
              {
                case 47:
                  num9 -= vlBytes;
                  flag2 = true;
                  int num18 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  int num19 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num20 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num21 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num22 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num17 < (byte) 127 && num17 != (byte) 81 && num17 != (byte) 47)
                  {
                    uint num23 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index4 = 0; (long) index4 < (long) num23; ++index4)
                    {
                      int num24 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  if (num17 == (byte) 127)
                  {
                    int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index5 = 0; index5 < int32_2; ++index5)
                    {
                      int num25 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  break;
              }
              num15 = num16;
            }
            else if (num16 >= (byte) 128 && num16 < (byte) 144 || flag3 && num15 >= (byte) 128 && num15 < (byte) 144)
            {
              if (!flag3)
              {
                int num26 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num27 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num15 = num16;
            }
            else if (num16 >= (byte) 144 && num16 < (byte) 160 || flag3 && num15 >= (byte) 144 && num15 < (byte) 160)
            {
              if (!flag3)
              {
                int num28 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num29 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num15 = num16;
            }
            else if (num16 >= (byte) 176 && num16 < (byte) 192 || flag3 && num15 >= (byte) 176 && num15 < (byte) 192)
            {
              if (!flag3)
              {
                int num30 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num31 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num15 = num16;
            }
            else if (num16 >= (byte) 192 && num16 < (byte) 208 || flag3 && num15 >= (byte) 192 && num15 < (byte) 208)
            {
              if (!flag3)
              {
                int num32 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num15 = num16;
            }
            else if (num16 >= (byte) 208 && num16 < (byte) 224 || flag3 && num15 >= (byte) 208 && num15 < (byte) 224)
            {
              if (!flag3)
              {
                int num33 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num15 = num16;
            }
            else if (num16 >= (byte) 224 && num16 < (byte) 240 || flag3 && num15 >= (byte) 224 && num15 < (byte) 240)
            {
              if (!flag3)
              {
                int num34 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num35 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num15 = num16;
            }
            else if (num16 == (byte) 240 || num16 == (byte) 247)
            {
              int int32_3 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index6 = 0; index6 < int32_3; ++index6)
              {
                int num36 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
            }
            else if (!flag1)
            {
              int num37 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
          }
          if (num9 > num8)
            num8 = num9;
          if (num9 > numArray3[index3])
            numArray3[index3] = num9;
        }
        offset = 14;
        altPattern = (byte[]) null;
        altOffset = (byte) 0;
        altLength = (byte) 0;
        for (int index7 = 0; index7 < num6; ++index7)
        {
          uint num38 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num39 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num40 = (int) numArray2[offset + 4];
          int num41 = (int) numArray2[offset + 5];
          int num42 = (int) numArray2[offset + 6];
          int num43 = (int) numArray2[offset + 7];
          offset += 8;
          byte num44 = byte.MaxValue;
          bool flag4 = false;
          bool flag5 = false;
          if (loop && loopPoint == 0U && numArray3[index7] > 0U)
          {
            TrackEvent trackEvent = trackEventArray[index7, numArray1[index7]];
            trackEvent.type = byte.MaxValue;
            trackEvent.absoluteTime = 0U;
            trackEvent.contentSize = 3;
            trackEvent.contents = new byte[trackEvent.contentSize];
            trackEvent.contents[0] = (byte) 46;
            trackEvent.contents[1] = (byte) 0;
            trackEvent.contents[2] = byte.MaxValue;
            trackEvent.deltaTime = 0U;
            trackEvent.obsoleteEvent = false;
            ++numArray1[index7];
            flag5 = true;
          }
          while (!flag4 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num38 += vlBytes;
            TrackEvent trackEvent1 = trackEventArray[index7, numArray1[index7]];
            trackEvent1.deltaTime = vlBytes;
            trackEvent1.obsoleteEvent = false;
            trackEvent1.contents = (byte[]) null;
            trackEvent1.absoluteTime = num38;
            if (loop && !flag5 && numArray3[index7] > loopPoint)
            {
              if ((int) num38 == (int) loopPoint)
              {
                TrackEvent trackEvent2 = trackEventArray[index7, numArray1[index7]];
                trackEvent2.type = byte.MaxValue;
                trackEvent2.absoluteTime = num38;
                trackEvent2.contentSize = 3;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent2.contents[0] = (byte) 46;
                trackEvent2.contents[1] = (byte) 0;
                trackEvent2.contents[2] = byte.MaxValue;
                trackEvent2.deltaTime = vlBytes;
                trackEvent2.obsoleteEvent = false;
                ++numArray1[index7];
                trackEvent1 = trackEventArray[index7, numArray1[index7]];
                trackEvent1.deltaTime = 0U;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num38;
                flag5 = true;
              }
              else if (num38 > loopPoint)
              {
                TrackEvent trackEvent3 = trackEventArray[index7, numArray1[index7]];
                trackEvent3.type = byte.MaxValue;
                trackEvent3.absoluteTime = loopPoint;
                trackEvent3.contentSize = 3;
                TrackEvent trackEvent4 = trackEvent3;
                trackEvent4.contents = new byte[trackEvent4.contentSize];
                trackEvent3.contents[0] = (byte) 46;
                trackEvent3.contents[1] = (byte) 0;
                trackEvent3.contents[2] = byte.MaxValue;
                trackEvent3.deltaTime = numArray1[index7] <= 0 ? loopPoint : loopPoint - trackEventArray[index7, numArray1[index7] - 1].absoluteTime;
                trackEvent3.obsoleteEvent = false;
                ++numArray1[index7];
                trackEvent1 = trackEventArray[index7, numArray1[index7]];
                trackEvent1.deltaTime = num38 - loopPoint;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num38;
                flag5 = true;
              }
            }
            byte num45 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag6 = num45 <= (byte) 127;
            if (num45 == byte.MaxValue)
            {
              byte num46 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num46)
              {
                case 47:
                  flag4 = true;
                  if (loop && numArray3[index7] > loopPoint)
                  {
                    TrackEvent trackEvent5 = trackEventArray[index7, numArray1[index7] - 1];
                    if (trackEvent5.type == byte.MaxValue && trackEvent5.contentSize > 0 && trackEvent5.contents[0] == (byte) 46)
                    {
                      TrackEvent trackEvent6 = trackEvent5;
                      trackEvent6.type = byte.MaxValue;
                      trackEvent6.contentSize = 1;
                      TrackEvent trackEvent7 = trackEvent6;
                      trackEvent7.contents = new byte[trackEvent7.contentSize];
                      trackEvent6.contents[0] = (byte) 47;
                    }
                    else
                    {
                      TrackEvent trackEvent8 = trackEventArray[index7, numArray1[index7] + 1];
                      trackEvent8.absoluteTime = num8;
                      trackEvent8.deltaTime = 0U;
                      trackEvent8.durationTime = trackEvent1.durationTime;
                      trackEvent8.obsoleteEvent = trackEvent1.obsoleteEvent;
                      trackEvent8.type = byte.MaxValue;
                      trackEvent8.contentSize = 1;
                      trackEvent8.contents = new byte[trackEvent8.contentSize];
                      trackEvent8.contents[0] = (byte) 47;
                      trackEvent1.type = byte.MaxValue;
                      if (num8 > trackEvent5.absoluteTime + trackEvent5.durationTime)
                      {
                        trackEvent1.deltaTime = num8 - (trackEvent5.absoluteTime + trackEvent5.durationTime);
                        trackEvent1.absoluteTime = num8;
                      }
                      else
                      {
                        trackEvent1.deltaTime = 0U;
                        trackEvent1.absoluteTime = trackEvent5.absoluteTime;
                      }
                      trackEvent1.contentSize = 7;
                      TrackEvent trackEvent9 = trackEvent1;
                      trackEvent9.contents = new byte[trackEvent9.contentSize];
                      trackEvent1.contents[0] = (byte) 45;
                      trackEvent1.contents[1] = byte.MaxValue;
                      trackEvent1.contents[2] = byte.MaxValue;
                      trackEvent1.contents[3] = (byte) 0;
                      trackEvent1.contents[4] = (byte) 0;
                      trackEvent1.contents[5] = (byte) 0;
                      trackEvent1.contents[6] = (byte) 0;
                      trackEvent1.obsoleteEvent = false;
                      ++numArray1[index7];
                    }
                  }
                  else
                  {
                    trackEvent1.type = byte.MaxValue;
                    trackEvent1.contentSize = 1;
                    TrackEvent trackEvent10 = trackEvent1;
                    trackEvent10.contents = new byte[trackEvent10.contentSize];
                    trackEvent1.contents[0] = (byte) 47;
                  }
                  int num47 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  trackEvent1.type = byte.MaxValue;
                  trackEvent1.contentSize = 4;
                  TrackEvent trackEvent11 = trackEvent1;
                  trackEvent11.contents = new byte[trackEvent11.contentSize];
                  trackEvent1.contents[0] = (byte) 81;
                  int num48 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[1] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[2] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[3] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num46 < (byte) 127 && num46 != (byte) 81 && num46 != (byte) 47)
                  {
                    trackEvent1.type = byte.MaxValue;
                    uint num49 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index8 = 0; (long) index8 < (long) num49; ++index8)
                    {
                      int num50 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  if (num46 == (byte) 127)
                  {
                    trackEvent1.type = byte.MaxValue;
                    int int32_4 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index9 = 0; index9 < int32_4; ++index9)
                    {
                      int num51 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  break;
              }
              num44 = num45;
            }
            else if (num45 >= (byte) 128 && num45 < (byte) 144 || flag6 && num44 >= (byte) 128 && num44 < (byte) 144)
            {
              byte num52;
              byte num53;
              if (flag6)
              {
                trackEvent1.type = num44;
                num52 = num45;
                num53 = num44;
              }
              else
              {
                trackEvent1.type = num45;
                num52 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num53 = num45;
              }
              byte num54 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              for (int index10 = numArray1[index7] - 1; index10 >= 0; --index10)
              {
                if ((int) trackEventArray[index7, index10].type == (144 | (int) num53 & 15) && !trackEventArray[index7, index10].obsoleteEvent && (int) trackEventArray[index7, index10].contents[0] == (int) num52)
                {
                  trackEventArray[index7, index10].durationTime = num38 - trackEventArray[index7, index10].absoluteTime;
                  break;
                }
              }
              trackEvent1.durationTime = 0U;
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent12 = trackEvent1;
              trackEvent12.contents = new byte[trackEvent12.contentSize];
              trackEvent1.contents[0] = num52;
              trackEvent1.contents[1] = num54;
              trackEvent1.obsoleteEvent = true;
              if (!flag6)
                num44 = num45;
            }
            else if (num45 >= (byte) 144 && num45 < (byte) 160 || flag6 && num44 >= (byte) 144 && num44 < (byte) 160)
            {
              byte num55;
              byte num56;
              if (flag6)
              {
                trackEvent1.type = num44;
                num55 = num45;
                num56 = num44;
              }
              else
              {
                trackEvent1.type = num45;
                num55 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num56 = num45;
              }
              byte num57 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (num57 == (byte) 0)
              {
                for (int index11 = numArray1[index7] - 1; index11 >= 0; --index11)
                {
                  if ((int) trackEventArray[index7, index11].type == (int) num56 && !trackEventArray[index7, index11].obsoleteEvent && (int) trackEventArray[index7, index11].contents[0] == (int) num55)
                  {
                    trackEventArray[index7, index11].durationTime = num38 - trackEventArray[index7, index11].absoluteTime;
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent13 = trackEvent1;
                trackEvent13.contents = new byte[trackEvent13.contentSize];
                trackEvent1.contents[0] = num55;
                trackEvent1.contents[1] = num57;
                trackEvent1.obsoleteEvent = true;
              }
              else
              {
                for (int index12 = numArray1[index7] - 1; index12 >= 0; --index12)
                {
                  if ((int) trackEventArray[index7, index12].type == (int) num56 && !trackEventArray[index7, index12].obsoleteEvent && (int) trackEventArray[index7, index12].contents[0] == (int) num55)
                  {
                    if (trackEventArray[index7, index12].durationTime == 0U)
                    {
                      trackEventArray[index7, index12].durationTime = num38 - trackEventArray[index7, index12].absoluteTime;
                      break;
                    }
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent14 = trackEvent1;
                trackEvent14.contents = new byte[trackEvent14.contentSize];
                trackEvent1.contents[0] = num55;
                trackEvent1.contents[1] = num57;
              }
              if (!flag6)
                num44 = num45;
            }
            else if (num45 >= (byte) 176 && num45 < (byte) 192 || flag6 && num44 >= (byte) 176 && num44 < (byte) 192)
            {
              byte num58;
              if (flag6)
              {
                num58 = num45;
                trackEvent1.type = num44;
              }
              else
              {
                num58 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num45;
              }
              byte num59 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent15 = trackEvent1;
              trackEvent15.contents = new byte[trackEvent15.contentSize];
              trackEvent1.contents[0] = num58;
              trackEvent1.contents[1] = num59;
              if (!flag6)
                num44 = num45;
            }
            else if (num45 >= (byte) 192 && num45 < (byte) 208 || flag6 && num44 >= (byte) 192 && num44 < (byte) 208)
            {
              byte num60;
              if (flag6)
              {
                num60 = num45;
                trackEvent1.type = num44;
              }
              else
              {
                num60 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num45;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent16 = trackEvent1;
              trackEvent16.contents = new byte[trackEvent16.contentSize];
              trackEvent1.contents[0] = num60;
              if (!flag6)
                num44 = num45;
            }
            else if (num45 >= (byte) 208 && num45 < (byte) 224 || flag6 && num44 >= (byte) 208 && num44 < (byte) 224)
            {
              trackEvent1.type = num45;
              byte num61;
              if (flag6)
              {
                num61 = num45;
                trackEvent1.type = num44;
              }
              else
              {
                num61 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num45;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent17 = trackEvent1;
              trackEvent17.contents = new byte[trackEvent17.contentSize];
              trackEvent1.contents[0] = num61;
              if (!flag6)
                num44 = num45;
            }
            else if (num45 >= (byte) 224 && num45 < (byte) 240 || flag6 && num44 >= (byte) 224 && num44 < (byte) 240)
            {
              trackEvent1.type = num45;
              byte num62;
              if (flag6)
              {
                num62 = num45;
                trackEvent1.type = num44;
              }
              else
              {
                num62 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num45;
              }
              byte num63 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent18 = trackEvent1;
              trackEvent18.contents = new byte[trackEvent18.contentSize];
              trackEvent1.contents[0] = num62;
              trackEvent1.contents[1] = num63;
              if (!flag6)
                num44 = num45;
            }
            else if (num45 == (byte) 240 || num45 == (byte) 247)
            {
              trackEvent1.type = num45;
              int int32_5 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index13 = 0; index13 < int32_5; ++index13)
              {
                int num64 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              trackEvent1.obsoleteEvent = true;
            }
            else if (!flag1)
            {
              int num65 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
            ++numArray1[index7];
          }
        }
        uint num66 = 0;
        uint inLong2 = 68;
        for (int index14 = 0; index14 < num6; ++index14)
        {
          uint num67 = 0;
          int num68 = 0;
          byte num69 = 0;
          if (numArray1[index14] > 0)
          {
            uint num70 = MidiParse.Flip32Bit(inLong2);
            outFile.Write(BitConverter.GetBytes(num70), 0, 4);
            for (int index15 = 0; index15 < numArray1[index14]; ++index15)
            {
              TrackEvent trackEvent = trackEventArray[index14, index15];
              uint length1 = 0;
              int num71 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num66, ref length1);
              if (trackEvent.obsoleteEvent)
              {
                num66 += trackEvent.deltaTime;
              }
              else
              {
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 46)
                  num68 = Convert.ToInt32((long) (uint) ((int) inLong2 + (int) num67 + 1) + (long) trackEvent.contentSize + (long) length1);
                num66 = 0U;
                uint num72 = num67 + length1;
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 45)
                {
                  uint uint32 = Convert.ToUInt32((long) (inLong2 + num72) - (long) num68 + 8L);
                  trackEvent.contents[3] = Convert.ToByte(uint32 >> 24 & (uint) byte.MaxValue);
                  trackEvent.contents[4] = Convert.ToByte(uint32 >> 16 & (uint) byte.MaxValue);
                  trackEvent.contents[5] = Convert.ToByte(uint32 >> 8 & (uint) byte.MaxValue);
                  trackEvent.contents[6] = Convert.ToByte(uint32 & (uint) byte.MaxValue);
                }
                if ((int) trackEvent.type != (int) num69 || trackEvent.type == byte.MaxValue)
                  ++num72;
                num67 = num72 + Convert.ToUInt32(trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length2 = 0;
                  int num73 = (int) MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length2);
                  num67 += length2;
                }
                num69 = trackEvent.type;
              }
            }
            inLong2 += num67;
          }
          else
          {
            uint num74 = 0;
            outFile.Write(BitConverter.GetBytes(num74), 0, 4);
          }
        }
        for (int index = num6; index < 16; ++index)
        {
          uint num75 = 0;
          outFile.Write(BitConverter.GetBytes(num75), 0, 4);
        }
        uint num76 = MidiParse.Flip32Bit((uint) inLong1);
        outFile.Write(BitConverter.GetBytes(num76), 0, 4);
        for (int index16 = 0; index16 < num6; ++index16)
        {
          if (numArray1[index16] > 0)
          {
            byte num77 = 0;
            for (int index17 = 0; index17 < numArray1[index16]; ++index17)
            {
              TrackEvent trackEvent = trackEventArray[index16, index17];
              if (trackEvent.obsoleteEvent)
              {
                num66 += trackEvent.deltaTime;
              }
              else
              {
                uint length3 = 0;
                uint num78 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num66, ref length3);
                num66 = 0U;
                MidiParse.WriteVLBytes(outFile, num78, length3, false);
                if ((int) trackEvent.type != (int) num77 || trackEvent.type == byte.MaxValue)
                  outFile.WriteByte(trackEvent.type);
                outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length4 = 0;
                  uint num79 = MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length4);
                  MidiParse.WriteVLBytes(outFile, num79, length4, false);
                }
                num77 = trackEvent.type;
              }
            }
          }
          for (int index18 = 0; index18 < numArray1[index16]; ++index18)
          {
            if (trackEventArray[index16, index18].contents != null)
              trackEventArray[index16, index18].contents = (byte[]) null;
          }
        }
        outFile.Close();
        outFile.Dispose();
        int int32_6 = Convert.ToInt32(new FileInfo(output).Length);
        byte[] Buffer1 = File.ReadAllBytes(output);
        uint[] numArray4 = new uint[16];
        int[] numArray5 = new int[16];
        for (int index = 0; index < 64; index += 4)
        {
          numArray4[index / 4] = (uint) ((((int) Buffer1[index] << 8 | (int) Buffer1[index + 1]) << 8 | (int) Buffer1[index + 2]) << 8) | (uint) Buffer1[index + 3];
          numArray5[index / 4] = 0;
        }
        for (int index19 = 0; index19 < int32_6; ++index19)
        {
          if (index19 > 68 && Buffer1[index19] == (byte) 254)
          {
            for (int index20 = 0; index20 < num6; ++index20)
            {
              if ((long) numArray4[index20] > (long) index19)
                ++numArray5[index20];
            }
          }
        }
        FileStream fileStream1 = new FileStream(output, FileMode.Create, FileAccess.Write);
        for (int index = 0; index < 16; ++index)
          MidiParse.WriteLongToBuffer(Buffer1, Convert.ToUInt32(index * 4), numArray4[index] + Convert.ToUInt32(numArray5[index]));
        for (int index = 0; index < int32_6; ++index)
        {
          fileStream1.WriteByte(Buffer1[index]);
          if (index > 68 && Buffer1[index] == (byte) 254)
            fileStream1.WriteByte(Buffer1[index]);
        }
        fileStream1.Close();
        fileStream1.Dispose();
        byte[] numArray6 = (byte[]) null;
        if (useRepeaters)
        {
          int int32_7 = Convert.ToInt32(new FileInfo(output).Length);
          byte[] numArray7 = File.ReadAllBytes(output);
          uint[] numArray8 = new uint[16];
          for (int index = 0; index < 64; index += 4)
            numArray8[index / 4] = (uint) ((((int) numArray7[index] << 8 | (int) numArray7[index + 1]) << 8 | (int) numArray7[index + 2]) << 8) | (uint) numArray7[index + 3];
          uint data = (uint) ((((int) numArray7[64] << 8 | (int) numArray7[65]) << 8 | (int) numArray7[66]) << 8) | (uint) numArray7[67];
          byte[] Buffer2 = new byte[int32_7 * 4];
          for (int index = 0; index < int32_7 * 4; ++index)
            Buffer2[index] = (byte) 0;
          uint[] numArray9 = new uint[16];
          for (int index = 0; index < 16; ++index)
            numArray9[index] = 0U;
          int num80 = 68;
          for (int index21 = 0; index21 < 16 && numArray8[index21] != 0U; ++index21)
          {
            numArray9[index21] = Convert.ToUInt32(num80);
            int num81 = num80;
            int num82 = int32_7;
            if (index21 < 15 && numArray8[index21 + 1] != 0U)
              num82 = Convert.ToInt32(numArray8[index21 + 1]);
            int int32_8 = Convert.ToInt32(numArray8[index21]);
            while (int32_8 < num82)
            {
              int num83 = -1;
              int num84 = -1;
              for (int index22 = num81; index22 < num80; ++index22)
              {
                int num85;
                for (num85 = 0; (int) Buffer2[index22 + num85] == (int) numArray7[int32_8 + num85] && int32_8 + num85 < num82 && Buffer2[index22 + num85] != (byte) 254 && Buffer2[index22 + num85] != byte.MaxValue && index22 + num85 < num80; ++num85)
                {
                  bool flag7 = false;
                  for (int index23 = int32_8 + num85; index23 < num82 && index23 < int32_8 + num85 + 5; ++index23)
                  {
                    if (numArray7[index23] == byte.MaxValue)
                      flag7 = true;
                  }
                  if (flag7)
                    break;
                }
                if (num85 > num84 && num85 > 6)
                {
                  num84 = num85;
                  num83 = index22;
                }
              }
              Convert.ToInt32(((long) int32_8 - (long) numArray8[index21]) / 2L);
              if (num84 > 6)
              {
                if (num84 > 253)
                  num84 = 253;
                byte[] numArray10 = Buffer2;
                int index24 = num80;
                int num86 = index24 + 1;
                numArray10[index24] = (byte) 254;
                int num87 = num86 - num83 - 1;
                byte[] numArray11 = Buffer2;
                int index25 = num86;
                int num88 = index25 + 1;
                int num89 = (int) Convert.ToByte(num87 >> 8 & (int) byte.MaxValue);
                numArray11[index25] = (byte) num89;
                byte[] numArray12 = Buffer2;
                int index26 = num88;
                int num90 = index26 + 1;
                int num91 = (int) Convert.ToByte(num87 & (int) byte.MaxValue);
                numArray12[index26] = (byte) num91;
                byte[] numArray13 = Buffer2;
                int index27 = num90;
                num80 = index27 + 1;
                int num92 = (int) Convert.ToByte(num84);
                numArray13[index27] = (byte) num92;
                int32_8 += num84;
              }
              else
              {
                Buffer2[num80++] = numArray7[int32_8];
                ++int32_8;
              }
            }
            if (num80 % 4 != 0)
              num80 += 4 - num80 % 4;
          }
          for (int index = 0; index < 16; ++index)
          {
            if (numArray9[index] != 0U)
            {
              Convert.ToInt32(numArray9[index]);
              int num93 = num80;
              if (index < 15 && numArray9[index + 1] != 0U)
                num93 = Convert.ToInt32(numArray9[index + 1]);
              int int32_9 = Convert.ToInt32(numArray9[index]);
              bool flag8 = false;
              int num94 = 0;
              while (int32_9 < num93)
              {
                if (Buffer2[int32_9] == byte.MaxValue && Buffer2[int32_9 + 1] == (byte) 46 && Buffer2[int32_9 + 2] == (byte) 0 && Buffer2[int32_9 + 3] == byte.MaxValue)
                {
                  flag8 = true;
                  num94 = int32_9 + 4;
                  int32_9 += 4;
                }
                else if (Buffer2[int32_9] == byte.MaxValue && Buffer2[int32_9 + 1] == (byte) 45 && Buffer2[int32_9 + 2] == byte.MaxValue && Buffer2[int32_9 + 3] == byte.MaxValue)
                {
                  if (flag8)
                  {
                    int num95 = int32_9 + 8 - num94;
                    MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(int32_9 + 4), Convert.ToUInt32(num95));
                    flag8 = false;
                  }
                  int32_9 += 8;
                }
                else
                  ++int32_9;
              }
            }
          }
          for (int index = 0; index < 16; ++index)
            MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(index * 4), Convert.ToUInt32(numArray9[index]));
          MidiParse.WriteLongToBuffer(Buffer2, 64U, data);
          FileStream fileStream2 = new FileStream(output, FileMode.Create, FileAccess.Write);
          for (int index = 0; index < num80; ++index)
            fileStream2.WriteByte(Buffer2[index]);
          fileStream2.Close();
          fileStream2.Dispose();
          numArray6 = (byte[]) null;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error converting " + ex.ToString(), "Error");
        return false;
      }
      return true;
    }

    public static bool MidiToBTFormat(
      string input,
      string output,
      bool loop,
      uint loopPoint,
      bool useRepeaters)
    {
      string str = output + "temp.bin";
      ushort numTracks = 32;
      if (!MidiParse.MidiToBTFormatStageOne(input, str, loop, loopPoint, useRepeaters, ref numTracks))
        return false;
      int int32 = Convert.ToInt32(new FileInfo(str).Length);
      byte[] currentSpot = File.ReadAllBytes(str);
      File.Delete(str);
      FileStream fileStream = new FileStream(output, FileMode.Create, FileAccess.Write);
      uint inLong = MidiParse.CharArrayToLong(currentSpot, 128);
      uint[] numArray = new uint[32];
      for (int index = 0; index < 128; index += 4)
      {
        numArray[index / 4] = (uint) ((((int) currentSpot[index] << 8 | (int) currentSpot[index + 1]) << 8 | (int) currentSpot[index + 2]) << 8) | (uint) currentSpot[index + 3];
        if (numArray[index / 4] == 0U)
          break;
      }
      uint uint32 = Convert.ToUInt32(132 - ((int) numTracks * 4 + 8));
      uint num1 = MidiParse.Flip32Bit(inLong);
      fileStream.Write(BitConverter.GetBytes(num1), 0, 4);
      uint num2 = MidiParse.Flip32Bit((uint) numTracks);
      fileStream.Write(BitConverter.GetBytes(num2), 0, 4);
      for (int index = 0; index < (int) numTracks; ++index)
      {
        uint num3 = MidiParse.Flip32Bit(numArray[index] - uint32);
        fileStream.Write(BitConverter.GetBytes(num3), 0, 4);
      }
      for (int index = 132; index < int32; ++index)
        fileStream.WriteByte(currentSpot[index]);
      fileStream.Close();
      fileStream.Dispose();
      return true;
    }

    private static bool MidiToBTFormatStageOne(
      string input,
      string output,
      bool loop,
      uint loopPoint,
      bool useRepeaters,
      ref ushort numTracks)
    {
      try
      {
        TrackEvent[,] trackEventArray = new TrackEvent[32, 65536];
        for (int index1 = 0; index1 < 32; ++index1)
        {
          for (int index2 = 0; index2 < 65536; ++index2)
            trackEventArray[index1, index2] = new TrackEvent();
        }
        int[] numArray1 = new int[32];
        for (int index = 0; index < 32; ++index)
          numArray1[index] = 0;
        string str = input;
        int int32_1 = Convert.ToInt32(new FileInfo(str).Length);
        byte[] numArray2 = File.ReadAllBytes(str);
        if (MidiParse.CharArrayToLong(numArray2, 0) != 1297377380U)
        {
          int num = (int) MessageBox.Show("Invalid midi hdr", "Error");
          return false;
        }
        int num1 = (int) MidiParse.CharArrayToLong(numArray2, 4);
        ushort num2 = MidiParse.CharArrayToShort(numArray2, 8);
        numTracks = MidiParse.CharArrayToShort(numArray2, 10);
        ushort inLong1 = MidiParse.CharArrayToShort(numArray2, 12);
        if (numTracks > (ushort) 32)
        {
          int num3 = (int) MessageBox.Show("Too many tracks, truncated to 32", "Warning");
          numTracks = (ushort) 32;
        }
        int uint32_1 = (int) Convert.ToUInt32(132 - ((int) numTracks * 4 + 8));
        FileStream outFile = new FileStream(output, FileMode.Create, FileAccess.Write);
        if (outFile == null)
        {
          int num4 = (int) MessageBox.Show("Error outputting file", "Error");
          return false;
        }
        if (num2 != (ushort) 0 && num2 != (ushort) 1)
        {
          int num5 = (int) MessageBox.Show("Invalid midi type", "Error");
          return false;
        }
        int offset = 14;
        byte[] altPattern = (byte[]) null;
        byte altOffset = 0;
        byte altLength = 0;
        bool flag1 = false;
        uint num6 = 0;
        uint[] numArray3 = new uint[32];
        for (int index = 0; index < 32; ++index)
          numArray3[index] = 0U;
        for (int index3 = 0; index3 < (int) numTracks; ++index3)
        {
          uint num7 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num8 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num9 = (int) numArray2[offset + 4];
          int num10 = (int) numArray2[offset + 5];
          int num11 = (int) numArray2[offset + 6];
          int num12 = (int) numArray2[offset + 7];
          offset += 8;
          byte num13 = byte.MaxValue;
          bool flag2 = false;
          while (!flag2 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num7 += vlBytes;
            byte num14 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag3 = num14 <= (byte) 127;
            if (num14 == byte.MaxValue)
            {
              byte num15 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num15)
              {
                case 47:
                  num7 -= vlBytes;
                  flag2 = true;
                  int num16 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  int num17 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num18 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num19 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  int num20 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num15 < (byte) 127 && num15 != (byte) 81 && num15 != (byte) 47)
                  {
                    uint num21 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index4 = 0; (long) index4 < (long) num21; ++index4)
                    {
                      int num22 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  if (num15 == (byte) 127)
                  {
                    int int32_2 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index5 = 0; index5 < int32_2; ++index5)
                    {
                      int num23 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    break;
                  }
                  break;
              }
              num13 = num14;
            }
            else if (num14 >= (byte) 128 && num14 < (byte) 144 || flag3 && num13 >= (byte) 128 && num13 < (byte) 144)
            {
              if (!flag3)
              {
                int num24 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num25 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num14;
            }
            else if (num14 >= (byte) 144 && num14 < (byte) 160 || flag3 && num13 >= (byte) 144 && num13 < (byte) 160)
            {
              if (!flag3)
              {
                int num26 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num27 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num14;
            }
            else if (num14 >= (byte) 176 && num14 < (byte) 192 || flag3 && num13 >= (byte) 176 && num13 < (byte) 192)
            {
              if (!flag3)
              {
                int num28 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num29 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num14;
            }
            else if (num14 >= (byte) 192 && num14 < (byte) 208 || flag3 && num13 >= (byte) 192 && num13 < (byte) 208)
            {
              if (!flag3)
              {
                int num30 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num13 = num14;
            }
            else if (num14 >= (byte) 208 && num14 < (byte) 224 || flag3 && num13 >= (byte) 208 && num13 < (byte) 224)
            {
              if (!flag3)
              {
                int num31 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              if (!flag3)
                num13 = num14;
            }
            else if (num14 >= (byte) 224 && num14 < (byte) 240 || flag3 && num13 >= (byte) 224 && num13 < (byte) 240)
            {
              if (!flag3)
              {
                int num32 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              int num33 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (!flag3)
                num13 = num14;
            }
            else if (num14 == (byte) 240 || num14 == (byte) 247)
            {
              int int32_3 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index6 = 0; index6 < int32_3; ++index6)
              {
                int num34 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
            }
            else if (!flag1)
            {
              int num35 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
          }
          if (num7 > num6)
            num6 = num7;
          if (num7 > numArray3[index3])
            numArray3[index3] = num7;
        }
        offset = 14;
        altPattern = (byte[]) null;
        altOffset = (byte) 0;
        altLength = (byte) 0;
        for (int index7 = 0; index7 < (int) numTracks; ++index7)
        {
          uint num36 = 0;
          if (((((int) numArray2[offset] << 8 | (int) numArray2[offset + 1]) << 8 | (int) numArray2[offset + 2]) << 8 | (int) numArray2[offset + 3]) != 1297379947)
          {
            int num37 = (int) MessageBox.Show("Invalid track midi hdr", "Error");
            return false;
          }
          int num38 = (int) numArray2[offset + 4];
          int num39 = (int) numArray2[offset + 5];
          int num40 = (int) numArray2[offset + 6];
          int num41 = (int) numArray2[offset + 7];
          offset += 8;
          byte num42 = byte.MaxValue;
          bool flag4 = false;
          bool flag5 = false;
          if (loop && loopPoint == 0U && numArray3[index7] > 0U)
          {
            TrackEvent trackEvent = trackEventArray[index7, numArray1[index7]];
            trackEvent.type = byte.MaxValue;
            trackEvent.absoluteTime = 0U;
            trackEvent.contentSize = 3;
            trackEvent.contents = new byte[trackEvent.contentSize];
            trackEvent.contents[0] = (byte) 46;
            trackEvent.contents[1] = (byte) 0;
            trackEvent.contents[2] = byte.MaxValue;
            trackEvent.deltaTime = 0U;
            trackEvent.obsoleteEvent = false;
            ++numArray1[index7];
            flag5 = true;
          }
          while (!flag4 && offset < int32_1)
          {
            uint original = 0;
            uint vlBytes = MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false);
            num36 += vlBytes;
            TrackEvent trackEvent1 = trackEventArray[index7, numArray1[index7]];
            trackEvent1.deltaTime = vlBytes;
            trackEvent1.obsoleteEvent = false;
            trackEvent1.contents = (byte[]) null;
            trackEvent1.absoluteTime = num36;
            if (loop && !flag5 && numArray3[index7] > loopPoint)
            {
              if ((int) num36 == (int) loopPoint)
              {
                TrackEvent trackEvent2 = trackEventArray[index7, numArray1[index7]];
                trackEvent2.type = byte.MaxValue;
                trackEvent2.absoluteTime = num36;
                trackEvent2.contentSize = 3;
                trackEvent2.contents = new byte[trackEvent2.contentSize];
                trackEvent2.contents[0] = (byte) 46;
                trackEvent2.contents[1] = (byte) 0;
                trackEvent2.contents[2] = byte.MaxValue;
                trackEvent2.deltaTime = vlBytes;
                trackEvent2.obsoleteEvent = false;
                ++numArray1[index7];
                trackEvent1 = trackEventArray[index7, numArray1[index7]];
                trackEvent1.deltaTime = 0U;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num36;
                flag5 = true;
              }
              else if (num36 > loopPoint)
              {
                TrackEvent trackEvent3 = trackEventArray[index7, numArray1[index7]];
                trackEvent3.type = byte.MaxValue;
                trackEvent3.absoluteTime = loopPoint;
                trackEvent3.contentSize = 3;
                TrackEvent trackEvent4 = trackEvent3;
                trackEvent4.contents = new byte[trackEvent4.contentSize];
                trackEvent3.contents[0] = (byte) 46;
                trackEvent3.contents[1] = (byte) 0;
                trackEvent3.contents[2] = byte.MaxValue;
                trackEvent3.deltaTime = numArray1[index7] <= 0 ? loopPoint : loopPoint - trackEventArray[index7, numArray1[index7] - 1].absoluteTime;
                trackEvent3.obsoleteEvent = false;
                ++numArray1[index7];
                trackEvent1 = trackEventArray[index7, numArray1[index7]];
                trackEvent1.deltaTime = num36 - loopPoint;
                trackEvent1.obsoleteEvent = false;
                trackEvent1.contents = (byte[]) null;
                trackEvent1.absoluteTime = num36;
                flag5 = true;
              }
            }
            byte num43 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
            bool flag6 = num43 <= (byte) 127;
            if (num43 == byte.MaxValue)
            {
              byte num44 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              switch (num44)
              {
                case 47:
                  flag4 = true;
                  if (loop && numArray3[index7] > loopPoint)
                  {
                    TrackEvent trackEvent5 = trackEventArray[index7, numArray1[index7] - 1];
                    if (trackEvent5.type == byte.MaxValue && trackEvent5.contentSize > 0 && trackEvent5.contents[0] == (byte) 46)
                    {
                      TrackEvent trackEvent6 = trackEvent5;
                      trackEvent6.type = byte.MaxValue;
                      trackEvent6.contentSize = 1;
                      TrackEvent trackEvent7 = trackEvent6;
                      trackEvent7.contents = new byte[trackEvent7.contentSize];
                      trackEvent6.contents[0] = (byte) 47;
                    }
                    else
                    {
                      TrackEvent trackEvent8 = trackEventArray[index7, numArray1[index7] + 1];
                      trackEvent8.absoluteTime = num6;
                      trackEvent8.deltaTime = 0U;
                      trackEvent8.durationTime = trackEvent1.durationTime;
                      trackEvent8.obsoleteEvent = trackEvent1.obsoleteEvent;
                      trackEvent8.type = byte.MaxValue;
                      trackEvent8.contentSize = 1;
                      trackEvent8.contents = new byte[trackEvent8.contentSize];
                      trackEvent8.contents[0] = (byte) 47;
                      trackEvent1.type = byte.MaxValue;
                      if (num6 > trackEvent5.absoluteTime + trackEvent5.durationTime)
                      {
                        trackEvent1.deltaTime = num6 - (trackEvent5.absoluteTime + trackEvent5.durationTime);
                        trackEvent1.absoluteTime = num6;
                      }
                      else
                      {
                        trackEvent1.deltaTime = 0U;
                        trackEvent1.absoluteTime = trackEvent5.absoluteTime;
                      }
                      trackEvent1.contentSize = 7;
                      TrackEvent trackEvent9 = trackEvent1;
                      trackEvent9.contents = new byte[trackEvent9.contentSize];
                      trackEvent1.contents[0] = (byte) 45;
                      trackEvent1.contents[1] = byte.MaxValue;
                      trackEvent1.contents[2] = byte.MaxValue;
                      trackEvent1.contents[3] = (byte) 0;
                      trackEvent1.contents[4] = (byte) 0;
                      trackEvent1.contents[5] = (byte) 0;
                      trackEvent1.contents[6] = (byte) 0;
                      trackEvent1.obsoleteEvent = false;
                      ++numArray1[index7];
                    }
                  }
                  else
                  {
                    trackEvent1.type = byte.MaxValue;
                    trackEvent1.contentSize = 1;
                    TrackEvent trackEvent10 = trackEvent1;
                    trackEvent10.contents = new byte[trackEvent10.contentSize];
                    trackEvent1.contents[0] = (byte) 47;
                  }
                  int num45 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                case 81:
                  trackEvent1.type = byte.MaxValue;
                  trackEvent1.contentSize = 4;
                  TrackEvent trackEvent11 = trackEvent1;
                  trackEvent11.contents = new byte[trackEvent11.contentSize];
                  trackEvent1.contents[0] = (byte) 81;
                  int num46 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[1] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[2] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  trackEvent1.contents[3] = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                  break;
                default:
                  if (num44 < (byte) 127 && num44 != (byte) 81 && num44 != (byte) 47)
                  {
                    trackEvent1.type = byte.MaxValue;
                    uint num47 = (uint) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    for (int index8 = 0; (long) index8 < (long) num47; ++index8)
                    {
                      int num48 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  if (num44 == (byte) 127)
                  {
                    trackEvent1.type = byte.MaxValue;
                    int int32_4 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
                    for (int index9 = 0; index9 < int32_4; ++index9)
                    {
                      int num49 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                    }
                    trackEvent1.obsoleteEvent = true;
                    break;
                  }
                  break;
              }
              num42 = num43;
            }
            else if (num43 >= (byte) 128 && num43 < (byte) 144 || flag6 && num42 >= (byte) 128 && num42 < (byte) 144)
            {
              byte num50;
              byte num51;
              if (flag6)
              {
                trackEvent1.type = num42;
                num50 = num43;
                num51 = num42;
              }
              else
              {
                trackEvent1.type = num43;
                num50 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num51 = num43;
              }
              byte num52 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              for (int index10 = numArray1[index7] - 1; index10 >= 0; --index10)
              {
                if ((int) trackEventArray[index7, index10].type == (144 | (int) num51 & 15) && !trackEventArray[index7, index10].obsoleteEvent && (int) trackEventArray[index7, index10].contents[0] == (int) num50)
                {
                  trackEventArray[index7, index10].durationTime = num36 - trackEventArray[index7, index10].absoluteTime;
                  break;
                }
              }
              trackEvent1.durationTime = 0U;
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent12 = trackEvent1;
              trackEvent12.contents = new byte[trackEvent12.contentSize];
              trackEvent1.contents[0] = num50;
              trackEvent1.contents[1] = num52;
              trackEvent1.obsoleteEvent = true;
              if (!flag6)
                num42 = num43;
            }
            else if (num43 >= (byte) 144 && num43 < (byte) 160 || flag6 && num42 >= (byte) 144 && num42 < (byte) 160)
            {
              byte num53;
              byte num54;
              if (flag6)
              {
                trackEvent1.type = num42;
                num53 = num43;
                num54 = num42;
              }
              else
              {
                trackEvent1.type = num43;
                num53 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                num54 = num43;
              }
              byte num55 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              if (num55 == (byte) 0)
              {
                for (int index11 = numArray1[index7] - 1; index11 >= 0; --index11)
                {
                  if ((int) trackEventArray[index7, index11].type == (int) num54 && !trackEventArray[index7, index11].obsoleteEvent && (int) trackEventArray[index7, index11].contents[0] == (int) num53)
                  {
                    trackEventArray[index7, index11].durationTime = num36 - trackEventArray[index7, index11].absoluteTime;
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent13 = trackEvent1;
                trackEvent13.contents = new byte[trackEvent13.contentSize];
                trackEvent1.contents[0] = num53;
                trackEvent1.contents[1] = num55;
                trackEvent1.obsoleteEvent = true;
              }
              else
              {
                for (int index12 = numArray1[index7] - 1; index12 >= 0; --index12)
                {
                  if ((int) trackEventArray[index7, index12].type == (int) num54 && !trackEventArray[index7, index12].obsoleteEvent && (int) trackEventArray[index7, index12].contents[0] == (int) num53)
                  {
                    if (trackEventArray[index7, index12].durationTime == 0U)
                    {
                      trackEventArray[index7, index12].durationTime = num36 - trackEventArray[index7, index12].absoluteTime;
                      break;
                    }
                    break;
                  }
                }
                trackEvent1.durationTime = 0U;
                trackEvent1.contentSize = 2;
                TrackEvent trackEvent14 = trackEvent1;
                trackEvent14.contents = new byte[trackEvent14.contentSize];
                trackEvent1.contents[0] = num53;
                trackEvent1.contents[1] = num55;
              }
              if (!flag6)
                num42 = num43;
            }
            else if (num43 >= (byte) 176 && num43 < (byte) 192 || flag6 && num42 >= (byte) 176 && num42 < (byte) 192)
            {
              byte num56;
              if (flag6)
              {
                num56 = num43;
                trackEvent1.type = num42;
              }
              else
              {
                num56 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num43;
              }
              byte num57 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent15 = trackEvent1;
              trackEvent15.contents = new byte[trackEvent15.contentSize];
              trackEvent1.contents[0] = num56;
              trackEvent1.contents[1] = num57;
              if (!flag6)
                num42 = num43;
            }
            else if (num43 >= (byte) 192 && num43 < (byte) 208 || flag6 && num42 >= (byte) 192 && num42 < (byte) 208)
            {
              byte num58;
              if (flag6)
              {
                num58 = num43;
                trackEvent1.type = num42;
              }
              else
              {
                num58 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num43;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent16 = trackEvent1;
              trackEvent16.contents = new byte[trackEvent16.contentSize];
              trackEvent1.contents[0] = num58;
              if (!flag6)
                num42 = num43;
            }
            else if (num43 >= (byte) 208 && num43 < (byte) 224 || flag6 && num42 >= (byte) 208 && num42 < (byte) 224)
            {
              trackEvent1.type = num43;
              byte num59;
              if (flag6)
              {
                num59 = num43;
                trackEvent1.type = num42;
              }
              else
              {
                num59 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num43;
              }
              trackEvent1.contentSize = 1;
              TrackEvent trackEvent17 = trackEvent1;
              trackEvent17.contents = new byte[trackEvent17.contentSize];
              trackEvent1.contents[0] = num59;
              if (!flag6)
                num42 = num43;
            }
            else if (num43 >= (byte) 224 && num43 < (byte) 240 || flag6 && num42 >= (byte) 224 && num42 < (byte) 240)
            {
              trackEvent1.type = num43;
              byte num60;
              if (flag6)
              {
                num60 = num43;
                trackEvent1.type = num42;
              }
              else
              {
                num60 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
                trackEvent1.type = num43;
              }
              byte num61 = MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              trackEvent1.contentSize = 2;
              TrackEvent trackEvent18 = trackEvent1;
              trackEvent18.contents = new byte[trackEvent18.contentSize];
              trackEvent1.contents[0] = num60;
              trackEvent1.contents[1] = num61;
              if (!flag6)
                num42 = num43;
            }
            else if (num43 == (byte) 240 || num43 == (byte) 247)
            {
              trackEvent1.type = num43;
              int int32_5 = Convert.ToInt32(MidiParse.GetVLBytes(numArray2, ref offset, ref original, ref altPattern, ref altOffset, ref altLength, false));
              for (int index13 = 0; index13 < int32_5; ++index13)
              {
                int num62 = (int) MidiParse.ReadMidiByte(numArray2, ref offset, ref altPattern, ref altOffset, ref altLength, false);
              }
              trackEvent1.obsoleteEvent = true;
            }
            else if (!flag1)
            {
              int num63 = (int) MessageBox.Show("Invalid midi character found", "Error");
              flag1 = true;
            }
            ++numArray1[index7];
          }
        }
        uint num64 = 0;
        uint inLong2 = 132;
        for (int index14 = 0; index14 < (int) numTracks; ++index14)
        {
          uint num65 = 0;
          int num66 = 0;
          byte num67 = 0;
          if (numArray1[index14] > 0)
          {
            uint num68 = MidiParse.Flip32Bit(inLong2);
            outFile.Write(BitConverter.GetBytes(num68), 0, 4);
            for (int index15 = 0; index15 < numArray1[index14]; ++index15)
            {
              TrackEvent trackEvent = trackEventArray[index14, index15];
              uint length1 = 0;
              int num69 = (int) MidiParse.ReturnVLBytes(trackEvent.deltaTime + num64, ref length1);
              if (trackEvent.obsoleteEvent)
              {
                num64 += trackEvent.deltaTime;
              }
              else
              {
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 46)
                  num66 = Convert.ToInt32((long) (uint) ((int) inLong2 + (int) num65 + 1) + (long) trackEvent.contentSize + (long) length1);
                num64 = 0U;
                uint num70 = num65 + length1;
                if (trackEvent.type == byte.MaxValue && trackEvent.contents[0] == (byte) 45)
                {
                  uint uint32_2 = Convert.ToUInt32((long) (inLong2 + num70) - (long) num66 + 8L);
                  trackEvent.contents[3] = Convert.ToByte(uint32_2 >> 24 & (uint) byte.MaxValue);
                  trackEvent.contents[4] = Convert.ToByte(uint32_2 >> 16 & (uint) byte.MaxValue);
                  trackEvent.contents[5] = Convert.ToByte(uint32_2 >> 8 & (uint) byte.MaxValue);
                  trackEvent.contents[6] = Convert.ToByte(uint32_2 & (uint) byte.MaxValue);
                }
                if ((int) trackEvent.type != (int) num67 || trackEvent.type == byte.MaxValue)
                  ++num70;
                num65 = num70 + Convert.ToUInt32(trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length2 = 0;
                  int num71 = (int) MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length2);
                  num65 += length2;
                }
                num67 = trackEvent.type;
              }
            }
            inLong2 += num65;
          }
          else
          {
            uint num72 = 0;
            outFile.Write(BitConverter.GetBytes(num72), 0, 4);
          }
        }
        for (int index = (int) numTracks; index < 32; ++index)
        {
          uint num73 = 0;
          outFile.Write(BitConverter.GetBytes(num73), 0, 4);
        }
        uint num74 = MidiParse.Flip32Bit((uint) inLong1);
        outFile.Write(BitConverter.GetBytes(num74), 0, 4);
        for (int index16 = 0; index16 < (int) numTracks; ++index16)
        {
          if (numArray1[index16] > 0)
          {
            byte num75 = 0;
            for (int index17 = 0; index17 < numArray1[index16]; ++index17)
            {
              TrackEvent trackEvent = trackEventArray[index16, index17];
              if (trackEvent.obsoleteEvent)
              {
                num64 += trackEvent.deltaTime;
              }
              else
              {
                uint length3 = 0;
                uint num76 = MidiParse.ReturnVLBytes(trackEvent.deltaTime + num64, ref length3);
                num64 = 0U;
                MidiParse.WriteVLBytes(outFile, num76, length3, false);
                if ((int) trackEvent.type != (int) num75 || trackEvent.type == byte.MaxValue)
                  outFile.WriteByte(trackEvent.type);
                outFile.Write(trackEvent.contents, 0, trackEvent.contentSize);
                if (trackEvent.type >= (byte) 144 && trackEvent.type < (byte) 160)
                {
                  uint length4 = 0;
                  uint num77 = MidiParse.ReturnVLBytes(trackEvent.durationTime, ref length4);
                  MidiParse.WriteVLBytes(outFile, num77, length4, false);
                }
                num75 = trackEvent.type;
              }
            }
          }
          for (int index18 = 0; index18 < numArray1[index16]; ++index18)
          {
            if (trackEventArray[index16, index18].contents != null)
              trackEventArray[index16, index18].contents = (byte[]) null;
          }
        }
        outFile.Close();
        outFile.Dispose();
        int int32_6 = Convert.ToInt32(new FileInfo(output).Length);
        byte[] Buffer1 = File.ReadAllBytes(output);
        uint[] numArray4 = new uint[32];
        int[] numArray5 = new int[32];
        for (int index = 0; index < 128; index += 4)
        {
          numArray4[index / 4] = (uint) ((((int) Buffer1[index] << 8 | (int) Buffer1[index + 1]) << 8 | (int) Buffer1[index + 2]) << 8) | (uint) Buffer1[index + 3];
          numArray5[index / 4] = 0;
        }
        for (int index19 = 0; index19 < int32_6; ++index19)
        {
          if (index19 > 132 && Buffer1[index19] == (byte) 254)
          {
            for (int index20 = 0; index20 < (int) numTracks; ++index20)
            {
              if ((long) numArray4[index20] > (long) index19)
                ++numArray5[index20];
            }
          }
        }
        FileStream fileStream1 = new FileStream(output, FileMode.Create, FileAccess.Write);
        for (int index = 0; index < 32; ++index)
          MidiParse.WriteLongToBuffer(Buffer1, Convert.ToUInt32(index * 4), numArray4[index] + Convert.ToUInt32(numArray5[index]));
        for (int index = 0; index < int32_6; ++index)
        {
          fileStream1.WriteByte(Buffer1[index]);
          if (index > 132 && Buffer1[index] == (byte) 254)
            fileStream1.WriteByte(Buffer1[index]);
        }
        fileStream1.Close();
        fileStream1.Dispose();
        byte[] numArray6 = (byte[]) null;
        if (useRepeaters)
        {
          int int32_7 = Convert.ToInt32(new FileInfo(output).Length);
          byte[] numArray7 = File.ReadAllBytes(output);
          uint[] numArray8 = new uint[32];
          for (int index = 0; index < 128; index += 4)
            numArray8[index / 4] = (uint) ((((int) numArray7[index] << 8 | (int) numArray7[index + 1]) << 8 | (int) numArray7[index + 2]) << 8) | (uint) numArray7[index + 3];
          uint data = (uint) ((((int) numArray7[128] << 8 | (int) numArray7[129]) << 8 | (int) numArray7[130]) << 8) | (uint) numArray7[131];
          byte[] Buffer2 = new byte[int32_7 * 4];
          for (int index = 0; index < int32_7 * 4; ++index)
            Buffer2[index] = (byte) 0;
          uint[] numArray9 = new uint[32];
          for (int index = 0; index < 32; ++index)
            numArray9[index] = 0U;
          int num78 = 132;
          for (int index21 = 0; index21 < 32 && numArray8[index21] != 0U; ++index21)
          {
            numArray9[index21] = Convert.ToUInt32(num78);
            int num79 = num78;
            int num80 = int32_7;
            if (index21 < 15 && numArray8[index21 + 1] != 0U)
              num80 = Convert.ToInt32(numArray8[index21 + 1]);
            int int32_8 = Convert.ToInt32(numArray8[index21]);
            while (int32_8 < num80)
            {
              int num81 = -1;
              int num82 = -1;
              for (int index22 = num79; index22 < num78; ++index22)
              {
                int num83;
                for (num83 = 0; (int) Buffer2[index22 + num83] == (int) numArray7[int32_8 + num83] && int32_8 + num83 < num80 && Buffer2[index22 + num83] != (byte) 254 && Buffer2[index22 + num83] != byte.MaxValue && index22 + num83 < num78; ++num83)
                {
                  bool flag7 = false;
                  for (int index23 = int32_8 + num83; index23 < num80 && index23 < int32_8 + num83 + 5; ++index23)
                  {
                    if (numArray7[index23] == byte.MaxValue)
                      flag7 = true;
                  }
                  if (flag7)
                    break;
                }
                if (num83 > num82 && num83 > 6)
                {
                  num82 = num83;
                  num81 = index22;
                }
              }
              Convert.ToInt32(((long) int32_8 - (long) numArray8[index21]) / 2L);
              if (num82 > 6)
              {
                if (num82 > 253)
                  num82 = 253;
                byte[] numArray10 = Buffer2;
                int index24 = num78;
                int num84 = index24 + 1;
                numArray10[index24] = (byte) 254;
                int num85 = num84 - num81 - 1;
                byte[] numArray11 = Buffer2;
                int index25 = num84;
                int num86 = index25 + 1;
                int num87 = (int) Convert.ToByte(num85 >> 8 & (int) byte.MaxValue);
                numArray11[index25] = (byte) num87;
                byte[] numArray12 = Buffer2;
                int index26 = num86;
                int num88 = index26 + 1;
                int num89 = (int) Convert.ToByte(num85 & (int) byte.MaxValue);
                numArray12[index26] = (byte) num89;
                byte[] numArray13 = Buffer2;
                int index27 = num88;
                num78 = index27 + 1;
                int num90 = (int) Convert.ToByte(num82);
                numArray13[index27] = (byte) num90;
                int32_8 += num82;
              }
              else
              {
                Buffer2[num78++] = numArray7[int32_8];
                ++int32_8;
              }
            }
            if (num78 % 4 != 0)
              num78 += 4 - num78 % 4;
          }
          for (int index = 0; index < 32; ++index)
          {
            if (numArray9[index] != 0U)
            {
              Convert.ToInt32(numArray9[index]);
              int num91 = num78;
              if (index < 15 && numArray9[index + 1] != 0U)
                num91 = Convert.ToInt32(numArray9[index + 1]);
              int int32_9 = Convert.ToInt32(numArray9[index]);
              bool flag8 = false;
              int num92 = 0;
              while (int32_9 < num91)
              {
                if (Buffer2[int32_9] == byte.MaxValue && Buffer2[int32_9 + 1] == (byte) 46 && Buffer2[int32_9 + 2] == (byte) 0 && Buffer2[int32_9 + 3] == byte.MaxValue)
                {
                  flag8 = true;
                  num92 = int32_9 + 4;
                  int32_9 += 4;
                }
                else if (Buffer2[int32_9] == byte.MaxValue && Buffer2[int32_9 + 1] == (byte) 45 && Buffer2[int32_9 + 2] == byte.MaxValue && Buffer2[int32_9 + 3] == byte.MaxValue)
                {
                  if (flag8)
                  {
                    int num93 = int32_9 + 8 - num92;
                    MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(int32_9 + 4), Convert.ToUInt32(num93));
                    flag8 = false;
                  }
                  int32_9 += 8;
                }
                else
                  ++int32_9;
              }
            }
          }
          for (int index = 0; index < 32; ++index)
            MidiParse.WriteLongToBuffer(Buffer2, Convert.ToUInt32(index * 4), Convert.ToUInt32(numArray9[index]));
          MidiParse.WriteLongToBuffer(Buffer2, 128U, data);
          FileStream fileStream2 = new FileStream(output, FileMode.Create, FileAccess.Write);
          for (int index = 0; index < num78; ++index)
            fileStream2.WriteByte(Buffer2[index]);
          fileStream2.Close();
          fileStream2.Dispose();
          numArray6 = (byte[]) null;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error converting " + ex.ToString(), "Error");
        return false;
      }
      return true;
    }
  }
}
