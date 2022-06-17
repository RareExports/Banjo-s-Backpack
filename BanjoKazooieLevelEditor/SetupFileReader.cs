// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.SetupFileReader
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  internal class SetupFileReader
  {
    private string myNewSetup = "";
    public List<ObjectData> everyObject;
    public List<ObjectData> everyStruct;

    public void init(string file_) => this.myNewSetup = file_;

    public void FillObjectDetails(ref ObjectData o)
    {
      if (o.specialScript == (short) 0)
      {
        for (int index = 0; index < this.everyStruct.Count; ++index)
        {
          if ((int) this.everyStruct[index].objectID == (int) o.objectID)
          {
            o.pointer = this.everyStruct[index].pointer;
            o.pointer2 = this.everyStruct[index].pointer2;
            o.modelFile = this.everyStruct[index].modelFile;
            o.modelFile2 = this.everyStruct[index].modelFile2;
            o.jiggyID = this.everyStruct[index].jiggyID;
            o.cameraID = this.everyStruct[index].cameraID;
            o.name = this.everyStruct[index].name;
          }
        }
      }
      else
      {
        for (int index = 0; index < this.everyObject.Count; ++index)
        {
          if ((int) this.everyObject[index].objectID == (int) o.objectID && (int) this.everyObject[index].specialScript == (int) o.specialScript)
          {
            o.pointer = this.everyObject[index].pointer;
            o.pointer2 = this.everyObject[index].pointer2;
            o.modelFile = this.everyObject[index].modelFile;
            o.modelFile2 = this.everyObject[index].modelFile2;
            o.jiggyID = this.everyObject[index].jiggyID;
            o.cameraID = this.everyObject[index].cameraID;
            o.name = this.everyObject[index].name;
          }
        }
      }
    }

    public ArrayList ReadSetupFile(byte[] setupfile)
    {
      List<ObjectData> objectDataList1 = new List<ObjectData>();
      List<ObjectData> objectDataList2 = new List<ObjectData>();
      List<byte> camBytes = new List<byte>();
      try
      {
        int length = setupfile.Length;
        try
        {
          int num1 = (int) setupfile[2] * 16777216 + (int) setupfile[3] * 65536 + (int) setupfile[4] * 256 + (int) setupfile[5];
          int num2 = (int) setupfile[6] * 16777216 + (int) setupfile[7] * 65536 + (int) setupfile[8] * 256 + (int) setupfile[9];
          int num3 = (int) setupfile[10] * 16777216 + (int) setupfile[11] * 65536 + (int) setupfile[12] * 256 + (int) setupfile[13];
          int num4 = (int) setupfile[14] * 16777216 + (int) setupfile[15] * 65536 + (int) setupfile[16] * 256 + (int) setupfile[17];
          int num5 = (int) setupfile[18] * 16777216 + (int) setupfile[19] * 65536 + (int) setupfile[20] * 256 + (int) setupfile[21];
          int num6 = (int) setupfile[22] * 16777216 + (int) setupfile[23] * 65536 + (int) setupfile[24] * 256 + (int) setupfile[25];
          int num7 = Math.Abs(num1) + num4 + 1;
          if (num1 > 0)
            num7 = num4 - num1 + 1;
          int num8 = Math.Abs(num2) + num5 + 1;
          if (num2 > 0)
            num8 = num5 - num2 + 1;
          int num9 = Math.Abs(num3) + num6 + 1;
          if (num3 > 0)
            num9 = num6 - num3 + 1;
          int num10 = 0;
          int num11 = 0;
          int num12 = num8 * num9;
          int num13 = 0;
          int num14 = 0;
          int num15 = 0;
          int num16 = 0;
          int num17 = num9 * num8 * num7;
          int index1;
          for (index1 = 26; index1 < setupfile.Length && num10 < num17; ++num10)
          {
            if (num13 > num12)
            {
              num13 = 0;
              ++num11;
              ++num14;
              num15 = 0;
            }
            if (num13 - num16 * num9 > num9)
            {
              if (num16 < num9)
                ++num16;
              if (num16 >= num9 - 1)
              {
                num16 = 0;
                ++num15;
              }
            }
            if (setupfile[index1] == (byte) 3 && setupfile[index1 + 1] == (byte) 10 && setupfile[index1 + 3] == (byte) 11)
            {
              int num18 = (int) setupfile[index1 + 2];
              int index2 = index1 + 4;
              for (; num18 > 0; --num18)
              {
                switch ((byte) ((uint) (short) ((int) setupfile[index2 + 6] * 256 + (int) setupfile[index2 + 7]) & (uint) sbyte.MaxValue))
                {
                  case 6:
                  case 8:
                  case 12:
                  case 14:
                  case 16:
                  case 18:
                  case 20:
                    int objectID_ = (int) (short) ((int) setupfile[index2 + 8] * 256 + (int) setupfile[index2 + 9]);
                    int num19 = index2;
                    short num20 = (short) ((int) setupfile[index2] * 256 + (int) setupfile[index2 + 1]);
                    short num21 = (short) ((int) setupfile[index2 + 2] * 256 + (int) setupfile[index2 + 3]);
                    short num22 = (short) ((int) setupfile[index2 + 4] * 256 + (int) setupfile[index2 + 5]);
                    short num23 = (short) ((int) setupfile[index2 + 12] * 2);
                    short num24 = (short) ((int) setupfile[index2 + 14] * 256 + (int) setupfile[index2 + 15]);
                    short num25 = (short) ((int) setupfile[index2 + 6] * 256 + (int) setupfile[index2 + 7]);
                    int address_ = num19;
                    int x_ = (int) num20;
                    int y_ = (int) num21;
                    int z_ = (int) num22;
                    int rot_ = (int) num23;
                    int size_ = (int) num24;
                    int specialScript_ = (int) num25;
                    int num26 = (int) setupfile[index2 + 10];
                    int num27 = (int) setupfile[index2 + 11];
                    int num28 = (int) setupfile[index2 + 13];
                    int num29 = (int) setupfile[index2 + 16];
                    int num30 = (int) setupfile[index2 + 17];
                    int num31 = (int) setupfile[index2 + 18];
                    int num32 = (int) setupfile[index2 + 19];
                    ObjectData o = new ObjectData((short) objectID_, address_, (short) x_, (short) y_, (short) z_, (short) rot_, (short) size_, (short) specialScript_, (byte) num26, (byte) num27, (byte) num28, (byte) num29, (byte) num30, (byte) num31, (byte) num32);
                    o.zoneID = num10;
                    this.FillObjectDetails(ref o);
                    objectDataList1.Add(o);
                    break;
                  default:
                    double single = (double) BitConverter.ToSingle(new byte[4]
                    {
                      setupfile[index2 + 3],
                      setupfile[index2 + 2],
                      setupfile[index2 + 1],
                      setupfile[index2]
                    }, 0);
                    int num33 = ((int) setupfile[index2 + 4] << 24) + ((int) setupfile[index2 + 5] << 16) + ((int) setupfile[index2 + 6] << 8) + (int) setupfile[index2 + 7];
                    int num34 = ((int) setupfile[index2 + 8] << 24) + ((int) setupfile[index2 + 9] << 16) + ((int) setupfile[index2 + 10] << 8) + (int) setupfile[index2 + 11];
                    int num35 = ((int) setupfile[index2 + 12] << 24) + ((int) setupfile[index2 + 13] << 16) + ((int) setupfile[index2 + 14] << 8) + (int) setupfile[index2 + 15];
                    int w1 = num33;
                    int w2 = num34;
                    int w3 = num35;
                    int num36 = (int) setupfile[index2 + 16];
                    int num37 = (int) setupfile[index2 + 17];
                    int num38 = (int) setupfile[index2 + 18];
                    int num39 = (int) setupfile[index2 + 19];
                    int add = index2;
                    objectDataList1.Add(new ObjectData((float) single, w1, w2, w3, (byte) num36, (byte) num37, (byte) num38, (byte) num39, true, add)
                    {
                      zoneID = num10,
                      locX = (short) (num1 * 1000 + num14 * 1000 + 500),
                      locY = (short) (num2 * 1000 + num15 * 1000 + 500),
                      locZ = (short) (num3 * 1000 + num16 * 1000 + 500)
                    });
                    break;
                }
                index2 += 20;
              }
              index1 = index1 + 4 + (int) setupfile[index1 + 2] * 20;
            }
            if (setupfile[index1] == (byte) 3 && setupfile[index1 + 1] == (byte) 10 && setupfile[index1 + 3] != (byte) 11)
              index1 += 3;
            if (setupfile[index1] == (byte) 8 && setupfile[index1 + 2] == (byte) 9)
            {
              int num40 = (int) setupfile[index1 + 1];
              int index3 = index1 + 3;
              for (; num40 > 0; --num40)
              {
                int objectID_ = (int) (short) ((int) setupfile[index3] * 256 + (int) setupfile[index3 + 1]);
                int num41 = index3;
                short num42 = (short) ((int) setupfile[index3 + 4] * 256 + (int) setupfile[index3 + 5]);
                short num43 = (short) ((int) setupfile[index3 + 6] * 256 + (int) setupfile[index3 + 7]);
                short num44 = (short) ((int) setupfile[index3 + 8] * 256 + (int) setupfile[index3 + 9]);
                short num45 = 0;
                short num46 = (short) setupfile[index3 + 10];
                int address_ = num41;
                int x_ = (int) num42;
                int y_ = (int) num43;
                int z_ = (int) num44;
                int rot_ = (int) num45;
                int size_ = (int) num46;
                int struct2_ = (int) setupfile[index3 + 2];
                int struct3_ = (int) setupfile[index3 + 3];
                int structA_ = (int) setupfile[index3 + 10];
                int structB_ = (int) setupfile[index3 + 11];
                ObjectData o = new ObjectData((short) objectID_, address_, (short) x_, (short) y_, (short) z_, (short) rot_, (short) size_, (short) 0, (byte) struct2_, (byte) struct3_, (byte) structA_, (byte) structB_);
                o.zoneID = num10;
                this.FillObjectDetails(ref o);
                objectDataList2.Add(o);
                index3 += 12;
              }
              index1 += 3 + (int) setupfile[index1 + 1] * 12;
            }
            if (setupfile[index1] == (byte) 8 && setupfile[index1 + 2] != (byte) 9)
              index1 += 2;
            ++index1;
            ++num13;
          }
          for (; index1 < length; ++index1)
            camBytes.Add(setupfile[index1]);
        }
        catch
        {
        }
      }
      catch
      {
      }
      List<CameraObject> cameraObjectList = this.RipCameras(camBytes);
      return new ArrayList()
      {
        (object) objectDataList1,
        (object) objectDataList2,
        (object) camBytes,
        (object) cameraObjectList
      };
    }

    public ArrayList ReadSetupFile()
    {
      List<ObjectData> objectDataList1 = new List<ObjectData>();
      List<ObjectData> objectDataList2 = new List<ObjectData>();
      List<byte> byteList = new List<byte>();
      if (!File.Exists(this.myNewSetup))
        return new ArrayList();
      try
      {
        BinaryReader binaryReader = new BinaryReader((Stream) File.Open(this.myNewSetup, FileMode.Open));
        long length = binaryReader.BaseStream.Length;
        byte[] numArray = new byte[length];
        binaryReader.BaseStream.Read(numArray, 0, (int) length);
        return this.ReadSetupFile(numArray);
      }
      catch
      {
        return new ArrayList();
      }
    }

    public List<CameraObject> RipCameras(List<byte> camBytes)
    {
      List<CameraObject> cameraObjectList = new List<CameraObject>();
      try
      {
        if (camBytes[3] != (byte) 4)
        {
          int index1 = 2;
          while (index1 + 32 < camBytes.Count<byte>())
          {
            short id_ = (short) ((int) camBytes[index1 + 1] * 256 + (int) camBytes[index1 + 2]);
            int camByte = (int) camBytes[index1 + 4];
            if (camBytes[index1] == (byte) 1)
            {
              switch (camByte)
              {
                case 1:
                case 2:
                case 3:
                  int index2 = index1 + 6;
                  byte[] numArray1 = new byte[4]
                  {
                    camBytes[index2 + 3],
                    camBytes[index2 + 2],
                    camBytes[index2 + 1],
                    camBytes[index2]
                  };
                  int index3 = index2 + 4;
                  byte[] numArray2 = new byte[4]
                  {
                    camBytes[index3 + 3],
                    camBytes[index3 + 2],
                    camBytes[index3 + 1],
                    camBytes[index3]
                  };
                  int index4 = index3 + 4;
                  byte[] numArray3 = new byte[4]
                  {
                    camBytes[index4 + 3],
                    camBytes[index4 + 2],
                    camBytes[index4 + 1],
                    camBytes[index4]
                  };
                  index1 = index4 + 4;
                  float single1 = BitConverter.ToSingle(numArray1, 0);
                  float single2 = BitConverter.ToSingle(numArray2, 0);
                  float single3 = BitConverter.ToSingle(numArray3, 0);
                  CameraObject cameraObject1 = new CameraObject(id_, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, camByte);
                  if (camByte == 2)
                  {
                    int index5 = index1 + 1;
                    byte[] numArray4 = new byte[4]
                    {
                      camBytes[index5 + 3],
                      camBytes[index5 + 2],
                      camBytes[index5 + 1],
                      camBytes[index5]
                    };
                    int index6 = index5 + 4;
                    byte[] numArray5 = new byte[4]
                    {
                      camBytes[index6 + 3],
                      camBytes[index6 + 2],
                      camBytes[index6 + 1],
                      camBytes[index6]
                    };
                    int index7 = index6 + 4;
                    byte[] numArray6 = new byte[4]
                    {
                      camBytes[index7 + 3],
                      camBytes[index7 + 2],
                      camBytes[index7 + 1],
                      camBytes[index7]
                    };
                    index1 = index7 + 4 + 1;
                    float single4 = BitConverter.ToSingle(numArray4, 0);
                    float single5 = BitConverter.ToSingle(numArray5, 0);
                    float single6 = BitConverter.ToSingle(numArray6, 0);
                    CameraObject cameraObject2 = new CameraObject(id_, single1, single2, single3, single4, single5, single6, camByte);
                    if (cameraObject2.type == 2 || cameraObject2.type == 3 || cameraObject2.type == 1)
                    {
                      cameraObjectList.Add(cameraObject2);
                      continue;
                    }
                    continue;
                  }
                  if (camByte == 3 || camByte == 1)
                  {
                    int index8 = index1 + 1;
                    byte[] numArray7 = new byte[4]
                    {
                      camBytes[index8 + 3],
                      camBytes[index8 + 2],
                      camBytes[index8 + 1],
                      camBytes[index8]
                    };
                    int index9 = index8 + 4;
                    byte[] numArray8 = new byte[4]
                    {
                      camBytes[index9 + 3],
                      camBytes[index9 + 2],
                      camBytes[index9 + 1],
                      camBytes[index9]
                    };
                    int index10 = index9 + 4 + 1;
                    byte[] numArray9 = new byte[4]
                    {
                      camBytes[index10 + 3],
                      camBytes[index10 + 2],
                      camBytes[index10 + 1],
                      camBytes[index10]
                    };
                    int index11 = index10 + 4;
                    byte[] numArray10 = new byte[4]
                    {
                      camBytes[index11 + 3],
                      camBytes[index11 + 2],
                      camBytes[index11 + 1],
                      camBytes[index11]
                    };
                    int index12 = index11 + 4 + 1;
                    byte[] numArray11 = new byte[4]
                    {
                      camBytes[index12 + 3],
                      camBytes[index12 + 2],
                      camBytes[index12 + 1],
                      camBytes[index12]
                    };
                    int index13 = index12 + 4;
                    byte[] numArray12 = new byte[4]
                    {
                      camBytes[index13 + 3],
                      camBytes[index13 + 2],
                      camBytes[index13 + 1],
                      camBytes[index13]
                    };
                    int index14 = index13 + 4;
                    byte[] numArray13 = new byte[4]
                    {
                      camBytes[index14 + 3],
                      camBytes[index14 + 2],
                      camBytes[index14 + 1],
                      camBytes[index14]
                    };
                    int index15 = index14 + 4 + 1;
                    int t3a5 = (int) camBytes[index15] * 16777216 + (int) camBytes[index15 + 1] * 65536 + (int) camBytes[index15 + 2] * 256 + (int) camBytes[index15 + 3];
                    int num = index15 + 4;
                    float single7 = BitConverter.ToSingle(numArray7, 0);
                    float single8 = BitConverter.ToSingle(numArray8, 0);
                    float single9 = BitConverter.ToSingle(numArray9, 0);
                    float single10 = BitConverter.ToSingle(numArray10, 0);
                    float single11 = BitConverter.ToSingle(numArray11, 0);
                    float single12 = BitConverter.ToSingle(numArray12, 0);
                    float single13 = BitConverter.ToSingle(numArray13, 0);
                    CameraObject cameraObject3;
                    if (camByte == 3)
                    {
                      int index16 = num + 1;
                      byte[] numArray14 = new byte[4]
                      {
                        camBytes[index16 + 3],
                        camBytes[index16 + 2],
                        camBytes[index16 + 1],
                        camBytes[index16]
                      };
                      int index17 = index16 + 4;
                      byte[] numArray15 = new byte[4]
                      {
                        camBytes[index17 + 3],
                        camBytes[index17 + 2],
                        camBytes[index17 + 1],
                        camBytes[index17]
                      };
                      num = index17 + 4;
                      float single14 = BitConverter.ToSingle(numArray14, 0);
                      float single15 = BitConverter.ToSingle(numArray15, 0);
                      cameraObject3 = new CameraObject(id_, single1, single2, single3, single7, single8, single9, single10, single11, single12, single13, t3a5, single14, single15, camByte);
                    }
                    else
                      cameraObject3 = new CameraObject(id_, single1, single2, single3, single7, single8, single9, single10, single11, single12, single13, t3a5, camByte);
                    index1 = num + 1;
                    if (cameraObject3.type == 2 || cameraObject3.type == 3 || cameraObject3.type == 1)
                    {
                      cameraObjectList.Add(cameraObject3);
                      continue;
                    }
                    continue;
                  }
                  continue;
                case 4:
                  index1 += 11;
                  continue;
                default:
                  int num1 = (int) MessageBox.Show("TYPE " + (object) camByte + " CAMERA: " + index1.ToString("x"));
                  index1 += 64;
                  continue;
              }
            }
            else
            {
              int num2 = (int) MessageBox.Show("Contains lighting data not parsed by BB");
              index1 = camBytes.Count;
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      return cameraObjectList;
    }

    public int GetListDec(string file, int skipCount)
    {
      byte[] numArray = new byte[3]
      {
        (byte) 3,
        (byte) 10,
        (byte) 11
      };
      int num = 0;
      int listDec = 0;
      ArrayList arrayList = new ArrayList();
      bool flag = false;
      if (File.Exists(file))
      {
        try
        {
          BinaryReader binaryReader = new BinaryReader((Stream) File.Open(file, FileMode.Open));
          long length = binaryReader.BaseStream.Length;
          byte[] buffer = new byte[length];
          binaryReader.BaseStream.Read(buffer, 0, (int) length);
          binaryReader.Close();
          try
          {
            for (int index = 0; (long) index < length; ++index)
            {
              if (!flag)
              {
                if ((int) buffer[index] == (int) numArray[0] && (int) buffer[index + 1] == (int) numArray[1] && (int) buffer[index + 3] == (int) numArray[2])
                {
                  ++num;
                  if (skipCount < num)
                  {
                    flag = true;
                    listDec = index;
                  }
                }
              }
              else
                break;
            }
          }
          catch (Exception ex)
          {
            binaryReader.Close();
          }
        }
        catch
        {
        }
      }
      return listDec;
    }

    public int GetListDec(List<byte> bytesInFile, int skipCount)
    {
      byte[] numArray = new byte[3]
      {
        (byte) 3,
        (byte) 10,
        (byte) 11
      };
      int num = 0;
      long count = (long) bytesInFile.Count;
      int listDec = 0;
      ArrayList arrayList = new ArrayList();
      bool flag = false;
      try
      {
        for (int index = 0; (long) index < count; ++index)
        {
          if (!flag)
          {
            if ((int) bytesInFile[index] == (int) numArray[0] && (int) bytesInFile[index + 1] == (int) numArray[1] && (int) bytesInFile[index + 3] == (int) numArray[2])
            {
              ++num;
              if (skipCount < num)
              {
                flag = true;
                listDec = index;
              }
            }
          }
          else
            break;
        }
      }
      catch (Exception ex)
      {
      }
      return listDec;
    }

    public int GetStructListDec(List<byte> bytesInFile, int skipCount)
    {
      byte[] numArray = new byte[2]{ (byte) 8, (byte) 9 };
      int num = 0;
      long count = (long) bytesInFile.Count;
      int structListDec = 0;
      ArrayList arrayList = new ArrayList();
      bool flag = false;
      try
      {
        for (int index = 0; (long) index < count; ++index)
        {
          if (!flag)
          {
            if ((int) bytesInFile[index] == (int) numArray[0] && (int) bytesInFile[index + 2] == (int) numArray[1])
            {
              ++num;
              if (skipCount < num)
              {
                flag = true;
                structListDec = index;
              }
            }
          }
          else
            break;
        }
      }
      catch (Exception ex)
      {
      }
      return structListDec;
    }
  }
}
