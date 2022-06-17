// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SetupFileWritter
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BanjoKazooieLevelEditor
{
  internal class SetupFileWritter
  {
    private WrittenFile writtenFile;

    public void stripDown(string file, int byteToRemove)
    {
      List<byte> byteList = new List<byte>();
      if (File.Exists(file))
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(file, FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] numArray = new byte[length];
        binaryReader.BaseStream.Read(numArray, 0, (int) length);
        binaryReader.Close();
        byteList = new List<byte>((IEnumerable<byte>) numArray);
      }
      bool flag = false;
      for (int index1 = 0; index1 + 3 < byteList.Count && !flag; ++index1)
      {
        if (byteList[index1] == (byte) 3 && byteList[index1 + 1] == (byte) 10 && byteList[index1 + 3] == (byte) 11)
        {
          int num1 = (int) byteList[index1 + 2];
          int num2 = num1;
          int index2 = index1 + 4;
          for (int index3 = 0; index3 < num2 && !flag && num1 > 1; ++index3)
          {
            if (byteList[index2 + 6] == (byte) 250 && byteList[index2 + 7] == (byte) 18 || byteList[index2 + 6] == (byte) 250 && byteList[index2 + 7] == (byte) 14 || byteList[index2 + 8] == (byte) 0 && byteList[index2 + 9] == (byte) 0 || byteList[index2 + 6] == (byte) 100 && byteList[index2 + 7] == (byte) 8 || byteList[index2 + 6] == (byte) 150 && byteList[index2 + 7] == (byte) 18)
            {
              byteList.RemoveRange(index2, 20);
              --num1;
              byteList[index1 + 2] = (byte) num1;
              byteToRemove -= 20;
              if (byteToRemove < 0)
                flag = true;
            }
            else
              index2 += 20;
          }
          index1 += 2;
        }
      }
      FileStream output = File.Create(file);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
      binaryWriter.Write(byteList.ToArray());
      binaryWriter.Close();
      output.Close();
    }

    public void stripDown(List<byte> bytesInFileList, int byteToRemove)
    {
      bool flag = false;
      for (int index1 = 0; index1 + 3 < bytesInFileList.Count && !flag; ++index1)
      {
        if (bytesInFileList[index1] == (byte) 3 && bytesInFileList[index1 + 1] == (byte) 10 && bytesInFileList[index1 + 3] == (byte) 11)
        {
          int bytesInFile = (int) bytesInFileList[index1 + 2];
          int num1 = bytesInFile;
          int index2 = index1 + 4;
          for (int index3 = 0; index3 < num1 && !flag && bytesInFile > 1; ++index3)
          {
            short num2 = (short) ((int) bytesInFileList[index2 + 8] * 100 + (int) bytesInFileList[index2 + 9]);
            short num3 = (short) ((int) bytesInFileList[index2 + 6] * 100 + (int) bytesInFileList[index2 + 7]);
            if (bytesInFileList[index2 + 6] == (byte) 250 && bytesInFileList[index2 + 7] == (byte) 18 || bytesInFileList[index2 + 6] == (byte) 250 && bytesInFileList[index2 + 7] == (byte) 14 || bytesInFileList[index2 + 8] == (byte) 0 && bytesInFileList[index2 + 9] == (byte) 0 || bytesInFileList[index2 + 6] == (byte) 100 && bytesInFileList[index2 + 7] == (byte) 8 || bytesInFileList[index2 + 6] == (byte) 150 && bytesInFileList[index2 + 7] == (byte) 18 || num2 == short.MinValue && (num3 <= short.MinValue || num3 >= (short) -32512))
            {
              bytesInFileList.RemoveRange(index2, 20);
              --bytesInFile;
              bytesInFileList[index1 + 2] = (byte) bytesInFile;
              byteToRemove -= 20;
              if (byteToRemove <= 0)
                flag = true;
            }
            else
              index2 += 20;
          }
          index1 += 2;
        }
      }
    }

    private bool objectInBounds(ObjectData obj, BoundingBox bounds)
    {
      bool flag = false;
      if ((int) obj.locX < bounds.largeX + 1000 && (int) obj.locX > bounds.smallX - 1000 && (int) obj.locY < bounds.largeY + 1000 && (int) obj.locY > bounds.smallY - 1000 && (int) obj.locZ < bounds.largeZ + 1000 && (int) obj.locZ > bounds.smallZ - 1000)
        flag = true;
      return flag;
    }

    public WrittenFile createBinaryFileObjects(
      string inDir_,
      string outDir_,
      SetupFile file_,
      List<ObjectData> objects_,
      List<ObjectData> structs_,
      List<BKPath> paths_,
      List<CameraObject> cams_,
      List<LevelEntryPoint> entries_,
      bool includeTriggers,
      BoundingBox maxBounds,
      string replacementModel_,
      string replacementModelB_,
      bool allObjsErased_,
      string filename_)
    {
      ObjectData objectData1 = new ObjectData((short) 0, 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0);
      for (int index = 0; index < objects_.Count<ObjectData>(); ++index)
      {
        if (objects_[index].name == "Start Point")
          objectData1 = objects_[index];
      }
      for (int index = 0; index < entries_.Count<LevelEntryPoint>(); ++index)
      {
        short specialScript_ = 6412;
        ObjectData objectData2 = new ObjectData((short) entries_[index].objectId, 0, objectData1.locX, objectData1.locY, objectData1.locZ, objectData1.rot, objectData1.size, specialScript_);
        objects_.Add(objectData2);
      }
      List<int> intList = new List<int>();
      for (int index = 0; index < cams_.Count; ++index)
        intList.Add((int) cams_[index].id);
      short num1 = 4352;
      List<short> shortList = new List<short>();
      for (int index = 0; index < paths_.Count<BKPath>(); ++index)
        objects_.AddRange((IEnumerable<ObjectData>) paths_[index].nodes);
      for (int index = 0; index < objects_.Count<ObjectData>(); ++index)
        shortList.Add((short) ((int) objects_[index].obj16 * 256 + (int) objects_[index].obj17));
      shortList.Add((short) 1200);
      shortList.Add((short) 1232);
      shortList.Add((short) 1744);
      shortList.Add((short) 1184);
      shortList.Add((short) 6032);
      for (int index = 0; index < objects_.Count; ++index)
      {
        if (objects_[index].obj16 == (byte) 0 && objects_[index].obj17 == (byte) 0)
        {
          while (shortList.Contains(num1))
            num1 += (short) 32;
          objects_[index].obj16 = (byte) ((uint) num1 >> 8);
          objects_[index].obj17 = (byte) num1;
          num1 += (short) 32;
        }
      }
      List<byte> source = new List<byte>();
      source.Add((byte) 1);
      source.Add((byte) 1);
      int num2 = 999999999;
      int num3 = 999999999;
      int num4 = 999999999;
      int num5 = -999999999;
      int num6 = -999999999;
      int num7 = -999999999;
      for (int index = 0; index < objects_.Count; ++index)
      {
        ObjectData objectData3 = objects_[index];
        if (objectData3.objectID != short.MinValue && this.objectInBounds(objectData3, maxBounds))
        {
          if (num2 > (int) objectData3.locX)
            num2 = (int) objectData3.locX;
          if (num3 > (int) objectData3.locY)
            num3 = (int) objectData3.locY;
          if (num4 > (int) objectData3.locZ)
            num4 = (int) objectData3.locZ;
          if (num5 < (int) objectData3.locX)
            num5 = (int) objectData3.locX;
          if (num6 < (int) objectData3.locY)
            num6 = (int) objectData3.locY;
          if (num7 < (int) objectData3.locZ)
            num7 = (int) objectData3.locZ;
        }
      }
      for (int index = 0; index < structs_.Count; ++index)
      {
        ObjectData objectData4 = structs_[index];
        if (this.objectInBounds(objectData4, maxBounds))
        {
          if (num2 > (int) objectData4.locX)
            num2 = (int) objectData4.locX;
          if (num3 > (int) objectData4.locY)
            num3 = (int) objectData4.locY;
          if (num4 > (int) objectData4.locZ)
            num4 = (int) objectData4.locZ;
          if (num5 < (int) objectData4.locX)
            num5 = (int) objectData4.locX;
          if (num6 < (int) objectData4.locY)
            num6 = (int) objectData4.locY;
          if (num7 < (int) objectData4.locZ)
            num7 = (int) objectData4.locZ;
        }
      }
      int number1 = num2 / 1000;
      if (num2 % 1000 != 0)
        --number1;
      int number2 = num3 / 1000;
      if (num3 % 1000 != 0)
        --number2;
      int number3 = num4 / 1000;
      if (num4 % 1000 != 0)
        --number3;
      int number4 = num5 / 1000;
      int num8 = num5 % 1000;
      int number5 = num6 / 1000;
      int num9 = num6 % 1000;
      int number6 = num7 / 1000;
      int num10 = num7 % 1000;
      byte[] byteArray1 = this.Int32ToByteArray(number1);
      byte[] byteArray2 = this.Int32ToByteArray(number2);
      byte[] byteArray3 = this.Int32ToByteArray(number3);
      byte[] byteArray4 = this.Int32ToByteArray(number4);
      byte[] byteArray5 = this.Int32ToByteArray(number5);
      byte[] byteArray6 = this.Int32ToByteArray(number6);
      BoundingBox bb_ = new BoundingBox();
      bb_.smallX = number1;
      bb_.smallY = number2;
      bb_.smallZ = number3;
      bb_.largeX = number4;
      bb_.largeY = number5;
      bb_.largeZ = number6;
      source.Add(byteArray1[0]);
      source.Add(byteArray1[1]);
      source.Add(byteArray1[2]);
      source.Add(byteArray1[3]);
      source.Add(byteArray2[0]);
      source.Add(byteArray2[1]);
      source.Add(byteArray2[2]);
      source.Add(byteArray2[3]);
      source.Add(byteArray3[0]);
      source.Add(byteArray3[1]);
      source.Add(byteArray3[2]);
      source.Add(byteArray3[3]);
      source.Add(byteArray4[0]);
      source.Add(byteArray4[1]);
      source.Add(byteArray4[2]);
      source.Add(byteArray4[3]);
      source.Add(byteArray5[0]);
      source.Add(byteArray5[1]);
      source.Add(byteArray5[2]);
      source.Add(byteArray5[3]);
      source.Add(byteArray6[0]);
      source.Add(byteArray6[1]);
      source.Add(byteArray6[2]);
      source.Add(byteArray6[3]);
      int num11 = Math.Abs(number1) + number4 + 1;
      if (number1 > 0)
        num11 = number4 - number1 + 1;
      int num12 = Math.Abs(number2) + number5 + 1;
      if (number2 > 0)
        num12 = number5 - number2 + 1;
      int num13 = Math.Abs(number3) + number6 + 1;
      if (number3 > 0)
        num13 = number6 - number3 + 1;
      for (int index1 = 0; index1 < num11; ++index1)
      {
        for (int index2 = 0; index2 < num12; ++index2)
        {
          for (int index3 = 0; index3 < num13; ++index3)
          {
            List<byte> collection1 = new List<byte>();
            collection1.Add((byte) 3);
            collection1.Add((byte) 10);
            collection1.Add((byte) 0);
            int num14 = (number1 + index1) * 1000;
            int num15 = num14 + 1000;
            int num16 = (number2 + index2) * 1000;
            int num17 = num16 + 1000;
            int num18 = (number3 + index3) * 1000;
            int num19 = num18 + 1000;
            bool flag1 = false;
            bool flag2 = false;
            byte num20 = 0;
            byte num21 = 0;
            int index4 = 2;
            try
            {
              for (int index5 = 0; index5 < objects_.Count<ObjectData>(); ++index5)
              {
                ObjectData objectData5 = objects_[index5];
                bool flag3 = true;
                if (objectData5.specialScript == (short) -1518 && !intList.Contains((int) objectData5.objectID))
                  flag3 = false;
                if (objectData5.specialScript == (short) -1518 && !includeTriggers)
                  flag3 = false;
                if ((((int) objectData5.locX < num14 || (int) objectData5.locX >= num15 || (int) objectData5.locY < num16 || (int) objectData5.locY >= num17 || (int) objectData5.locZ < num18 ? 0 : ((int) objectData5.locZ < num19 ? 1 : 0)) & (flag3 ? 1 : 0)) != 0)
                {
                  if (!flag1)
                  {
                    flag1 = true;
                    collection1.Add((byte) 11);
                  }
                  ++num20;
                  objects_.RemoveAt(index5);
                  --index5;
                  byte[] collection2 = new byte[20];
                  if (objectData5.type != ObjectType.SPath)
                  {
                    byte[] byteArray7 = this.Int16ToByteArray(objectData5.locX);
                    byte[] byteArray8 = this.Int16ToByteArray(objectData5.locY);
                    byte[] byteArray9 = this.Int16ToByteArray(objectData5.locZ);
                    byte[] byteArray10 = this.Int16ToByteArray(objectData5.specialScript);
                    byte num22 = (byte) ((uint) objectData5.rot / 2U);
                    byte[] byteArray11 = this.Int16ToByteArray(objectData5.size);
                    byte[] byteArray12 = this.Int16ToByteArray(objectData5.objectID);
                    collection2[0] = byteArray7[0];
                    collection2[1] = byteArray7[1];
                    collection2[2] = byteArray8[0];
                    collection2[3] = byteArray8[1];
                    collection2[4] = byteArray9[0];
                    collection2[5] = byteArray9[1];
                    collection2[6] = byteArray10[0];
                    collection2[7] = byteArray10[1];
                    collection2[8] = byteArray12[0];
                    collection2[9] = byteArray12[1];
                    collection2[10] = objectData5.obj10;
                    collection2[11] = objectData5.obj11;
                    collection2[12] = num22;
                    collection2[13] = objectData5.obj13;
                    collection2[14] = byteArray11[0];
                    collection2[15] = byteArray11[1];
                    collection2[16] = objectData5.obj16;
                    collection2[17] = objectData5.obj17;
                    collection2[18] = objectData5.obj18;
                    collection2[19] = objectData5.obj19;
                    if (objectData5.name == "Start Point")
                      collection2[17] = (byte) 32;
                    else if (objectData5.name == "Jiggy Flag")
                    {
                      collection2[14] = (byte) 0;
                      collection2[15] = (byte) 0;
                    }
                    if (collection2[16] == (byte) 0 && collection2[17] == (byte) 0 && collection2[19] == (byte) 0 && !(objectData5.name == "Blue Jinjo"))
                    {
                      if (objectData5.name == "Yellow Jinjo")
                        collection2[19] = (byte) 208;
                      else if (objectData5.name == "Green Jinjo")
                        collection2[19] = (byte) 64;
                      else if (objectData5.name == "Purple Jinjo")
                        collection2[19] = (byte) 192;
                      else if (objectData5.name == "Orange Jinjo")
                        collection2[19] = (byte) 80;
                      else if (objectData5.name.Contains("SNS Egg"))
                        collection2[19] = (byte) 70;
                    }
                    if (objectData5.name == "Warp" && collection2[16] == (byte) 0)
                    {
                      int num23 = (int) collection2[17];
                    }
                    int objectId = (int) objectData5.objectID;
                    if (collection2[19] == (byte) 0 && objectData5.type != ObjectType.SPath)
                      collection2[19] = (byte) 64;
                  }
                  else
                  {
                    byte[] bytes = BitConverter.GetBytes(objectData5.activationPercent);
                    collection2[0] = bytes[3];
                    collection2[1] = bytes[2];
                    collection2[2] = bytes[1];
                    collection2[3] = bytes[0];
                    collection2[4] = (byte) (objectData5.pw1 >> 24);
                    collection2[5] = (byte) (objectData5.pw1 >> 16);
                    collection2[6] = (byte) (objectData5.pw1 >> 8);
                    collection2[7] = (byte) objectData5.pw1;
                    collection2[8] = (byte) (objectData5.pw2 >> 24);
                    collection2[9] = (byte) (objectData5.pw2 >> 16);
                    collection2[10] = (byte) (objectData5.pw2 >> 8);
                    collection2[11] = (byte) objectData5.pw2;
                    collection2[12] = (byte) (objectData5.pw3 >> 24);
                    collection2[13] = (byte) (objectData5.pw3 >> 16);
                    collection2[14] = (byte) (objectData5.pw3 >> 8);
                    collection2[15] = (byte) objectData5.pw3;
                    collection2[16] = objectData5.obj16;
                    collection2[17] = objectData5.obj17;
                    collection2[18] = objectData5.obj18;
                    collection2[19] = objectData5.obj19;
                  }
                  collection1.AddRange((IEnumerable<byte>) collection2);
                }
              }
              collection1[index4] = num20;
              collection1.Add((byte) 8);
              int num24 = collection1.Count - 1;
              collection1.Add((byte) 0);
              for (int index6 = 0; index6 < structs_.Count; ++index6)
              {
                ObjectData objectData6 = structs_[index6];
                if ((int) objectData6.locX >= num14 && (int) objectData6.locX < num15 && (int) objectData6.locY >= num16 && (int) objectData6.locY < num17 && (int) objectData6.locZ >= num18 && (int) objectData6.locZ < num19)
                {
                  if (!flag2)
                  {
                    flag2 = true;
                    collection1.Add((byte) 9);
                  }
                  ++num21;
                  structs_.RemoveAt(index6);
                  --index6;
                  byte[] byteArray13 = this.Int16ToByteArray(objectData6.locX);
                  byte[] byteArray14 = this.Int16ToByteArray(objectData6.locY);
                  byte[] byteArray15 = this.Int16ToByteArray(objectData6.locZ);
                  this.Int16ToByteArray(objectData6.specialScript);
                  byte[] byteArray16 = this.Int16ToByteArray(objectData6.size);
                  byte[] byteArray17 = this.Int16ToByteArray(objectData6.objectID);
                  byte[] collection3 = new byte[12];
                  collection3[0] = byteArray17[0];
                  collection3[1] = byteArray17[1];
                  collection3[2] = objectData6.struct2;
                  collection3[3] = objectData6.struct3;
                  if (objectData6.struct3 == (byte) 0)
                  {
                    if (objectData6.name == "Red Feather")
                      collection3[3] = (byte) 220;
                    if (objectData6.name == "Gold Feather")
                      collection3[3] = (byte) 222;
                    if (objectData6.name == "Note")
                      collection3[3] = (byte) 180;
                    if (objectData6.name == "Blue Egg")
                      collection3[3] = (byte) 162;
                    if (objectData6.name == "Fire 2D")
                    {
                      collection3[2] = (byte) 1;
                      collection3[3] = (byte) 144;
                    }
                    if (objectData6.name == "Blue Flowers")
                    {
                      collection3[2] = (byte) 1;
                      collection3[3] = (byte) 78;
                    }
                    if (objectData6.name == "Red Flowers")
                    {
                      collection3[2] = (byte) 0;
                      collection3[3] = (byte) 230;
                    }
                    if (objectData6.name == "Yellow Red Flowers")
                    {
                      collection3[2] = (byte) 1;
                      collection3[3] = (byte) 74;
                    }
                    if (objectData6.name == "MM Tree" || objectData6.name == "TTC Tree")
                    {
                      collection3[2] = (byte) 179;
                      collection3[3] = (byte) 0;
                    }
                    if (objectData6.name == "Conga's Tree")
                    {
                      collection3[2] = (byte) 11;
                      collection3[3] = (byte) 0;
                    }
                    if (objectData6.name == "Orange 2D")
                    {
                      collection3[2] = (byte) 0;
                      collection3[3] = (byte) 108;
                    }
                    if (objectData6.name == "Another Crate")
                    {
                      collection3[2] = (byte) 0;
                      collection3[3] = (byte) 0;
                    }
                    if (objectData6.name == "Dark Crate")
                    {
                      collection3[2] = (byte) 59;
                      collection3[3] = (byte) 177;
                    }
                    if (objectData6.name == "Light Crate")
                    {
                      collection3[2] = (byte) 21;
                      collection3[3] = (byte) 2;
                    }
                  }
                  collection3[4] = byteArray13[0];
                  collection3[5] = byteArray13[1];
                  collection3[6] = byteArray14[0];
                  collection3[7] = byteArray14[1];
                  collection3[8] = byteArray15[0];
                  collection3[9] = byteArray15[1];
                  collection3[10] = byteArray16[1];
                  collection3[11] = objectData6.structB;
                  if (objectData6.structB == (byte) 0)
                  {
                    if (objectData6.name == "SM Tree")
                      collection3[11] = (byte) 18;
                    if (objectData6.name == "MM Tree")
                      collection3[11] = (byte) 210;
                    if (objectData6.name == "TTC Tree")
                      collection3[11] = (byte) 18;
                    if (objectData6.name == "GV Tree")
                      collection3[11] = (byte) 146;
                    if (objectData6.name == "Conga's Tree")
                      collection3[11] = (byte) 82;
                    if (objectData6.name == "Another Crate")
                      collection3[11] = (byte) 210;
                    if (objectData6.name == "Dark Crate")
                      collection3[11] = (byte) 146;
                    if (objectData6.name == "Light Crate")
                      collection3[11] = (byte) 210;
                    if (objectData6.name.Contains("Toxic"))
                      collection3[11] = (byte) 210;
                  }
                  if (objectData6.structB == (byte) 0 && objectData6.structA == (byte) 0)
                  {
                    if (objectData6.name == "Blue Flowers")
                    {
                      collection3[10] = (byte) 6;
                      collection3[11] = (byte) 80;
                    }
                    if (objectData6.name == "Red Flowers")
                    {
                      collection3[10] = (byte) 6;
                      collection3[11] = (byte) 48;
                    }
                    if (objectData6.name == "Yellow Red Flowers")
                    {
                      collection3[10] = (byte) 1;
                      collection3[11] = (byte) 16;
                    }
                    if (objectData6.name == "Orange 2D")
                    {
                      collection3[10] = (byte) 2;
                      collection3[11] = (byte) 80;
                    }
                  }
                  collection1.AddRange((IEnumerable<byte>) collection3);
                }
              }
              collection1.Add((byte) 1);
              collection1[num24 + 1] = num21;
              if (!flag1 && !flag2)
                source.Add((byte) 1);
              else
                source.AddRange((IEnumerable<byte>) collection1);
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
      source.Add((byte) 0);
      source.Add((byte) 3);
      for (int index = 0; index < cams_.Count; ++index)
      {
        if (cams_[index].type == 3 || cams_[index].type == 2 || cams_[index].type == 1)
        {
          source.Add((byte) 1);
          source.Add((byte) 0);
          source.Add((byte) cams_[index].id);
          source.Add((byte) 2);
          source.Add((byte) cams_[index].type);
          source.Add((byte) 1);
          byte[] bytes1 = BitConverter.GetBytes(cams_[index].x);
          byte[] bytes2 = BitConverter.GetBytes(cams_[index].y);
          byte[] bytes3 = BitConverter.GetBytes(cams_[index].z);
          source.Add(bytes1[3]);
          source.Add(bytes1[2]);
          source.Add(bytes1[1]);
          source.Add(bytes1[0]);
          source.Add(bytes2[3]);
          source.Add(bytes2[2]);
          source.Add(bytes2[1]);
          source.Add(bytes2[0]);
          source.Add(bytes3[3]);
          source.Add(bytes3[2]);
          source.Add(bytes3[1]);
          source.Add(bytes3[0]);
          source.Add((byte) 2);
          if (cams_[index].type == 2)
          {
            byte[] bytes4 = BitConverter.GetBytes(cams_[index].pitch);
            byte[] bytes5 = BitConverter.GetBytes(cams_[index].yaw);
            byte[] bytes6 = BitConverter.GetBytes(cams_[index].roll);
            source.Add(bytes4[3]);
            source.Add(bytes4[2]);
            source.Add(bytes4[1]);
            source.Add(bytes4[0]);
            source.Add(bytes5[3]);
            source.Add(bytes5[2]);
            source.Add(bytes5[1]);
            source.Add(bytes5[0]);
            source.Add(bytes6[3]);
            source.Add(bytes6[2]);
            source.Add(bytes6[1]);
            source.Add(bytes6[0]);
          }
          if (cams_[index].type == 3 || cams_[index].type == 1)
          {
            byte[] bytes7 = BitConverter.GetBytes(cams_[index].camHSpeed);
            byte[] bytes8 = BitConverter.GetBytes(cams_[index].camVSpeed);
            source.Add(bytes7[3]);
            source.Add(bytes7[2]);
            source.Add(bytes7[1]);
            source.Add(bytes7[0]);
            source.Add(bytes8[3]);
            source.Add(bytes8[2]);
            source.Add(bytes8[1]);
            source.Add(bytes8[0]);
            source.Add((byte) 3);
            byte[] bytes9 = BitConverter.GetBytes(cams_[index].camRotation);
            byte[] bytes10 = BitConverter.GetBytes(cams_[index].camAccel);
            source.Add(bytes9[3]);
            source.Add(bytes9[2]);
            source.Add(bytes9[1]);
            source.Add(bytes9[0]);
            source.Add(bytes10[3]);
            source.Add(bytes10[2]);
            source.Add(bytes10[1]);
            source.Add(bytes10[0]);
            source.Add((byte) 4);
            byte[] bytes11 = BitConverter.GetBytes(cams_[index].pitch3);
            byte[] bytes12 = BitConverter.GetBytes(cams_[index].yaw3);
            byte[] bytes13 = BitConverter.GetBytes(cams_[index].roll3);
            source.Add(bytes11[3]);
            source.Add(bytes11[2]);
            source.Add(bytes11[1]);
            source.Add(bytes11[0]);
            source.Add(bytes12[3]);
            source.Add(bytes12[2]);
            source.Add(bytes12[1]);
            source.Add(bytes12[0]);
            source.Add(bytes13[3]);
            source.Add(bytes13[2]);
            source.Add(bytes13[1]);
            source.Add(bytes13[0]);
            source.Add((byte) 5);
            byte[] byteArray18 = this.Int32ToByteArray(cams_[index].Type3Arg5);
            source.Add(byteArray18[0]);
            source.Add(byteArray18[1]);
            source.Add(byteArray18[2]);
            source.Add(byteArray18[3]);
            if (cams_[index].type == 3)
            {
              source.Add((byte) 6);
              byte[] bytes14 = BitConverter.GetBytes(cams_[index].camCDist);
              byte[] bytes15 = BitConverter.GetBytes(cams_[index].camFDist);
              source.Add(bytes14[3]);
              source.Add(bytes14[2]);
              source.Add(bytes14[1]);
              source.Add(bytes14[0]);
              source.Add(bytes15[3]);
              source.Add(bytes15[2]);
              source.Add(bytes15[1]);
              source.Add(bytes15[0]);
            }
          }
        }
        source.Add((byte) 0);
      }
      source.Add((byte) 0);
      source.Add((byte) 4);
      source.Add((byte) 0);
      source.Add((byte) 0);
      int num25 = 0;
      if (File.Exists(inDir_ + file_.pointer.ToString("x")))
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(inDir_ + file_.pointer.ToString("x"), FileMode.Open));
        num25 = (int) binaryReader.BaseStream.Length;
        binaryReader.Close();
      }
      source.Count<byte>();
      FileStream output = !(filename_ == "") ? File.Create(filename_) : File.Create(outDir_ + file_.pointer.ToString("x"));
      BinaryWriter binaryWriter = new BinaryWriter((Stream) output);
      binaryWriter.Write(source.ToArray());
      binaryWriter.Close();
      output.Close();
      this.writtenFile = new WrittenFile(file_.pointer.ToString("x"), bb_, file_.pointer, file_.modelAPointer, file_.modelBPointer, replacementModel_, replacementModelB_);
      return this.writtenFile;
    }

    public byte[] Int16ToByteArray(short number) => new byte[2]
    {
      (byte) ((uint) number >> 8),
      (byte) ((uint) number & (uint) byte.MaxValue)
    };

    public byte[] Int32ToByteArray(int number) => new byte[4]
    {
      (byte) (number >> 24),
      (byte) (number >> 16),
      (byte) (number >> 8),
      (byte) (number & (int) byte.MaxValue)
    };
  }
}
