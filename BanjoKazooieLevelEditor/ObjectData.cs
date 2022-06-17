// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ObjectData
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;

namespace BanjoKazooieLevelEditor
{
  public class ObjectData : PickableObject
  {
    public ObjectType type = ObjectType.Normal;
    public int zoneID;
    public string name = "";
    public short objectID;
    public int address;
    public short locX;
    public short locY;
    public short locZ;
    public short rot;
    public short size = 100;
    public short specialScript;
    public string modelFile = "";
    public string modelFile2 = "";
    public int pointer;
    public int pointer2;
    public BoundingBox bb;
    public bool hasJiggy;
    public int jiggyID = -1;
    public int flag = -1;
    public int cameraID = -1;
    public byte obj10;
    public byte obj11;
    public byte obj13;
    public byte obj16;
    public byte obj17;
    public byte obj18;
    public byte obj19;
    public short uid;
    public short nodeOutUID;
    public byte struct2;
    public byte struct3;
    public byte structA;
    public byte structB;
    public ushort radius;
    public float activationPercent;
    public int pw1;
    public int pw2;
    public int pw3;
    public uint unk3;
    public bool useAnimation;
    public bool usePause;
    public bool useSpeed;
    public int animation;
    public int pauseTime;
    public int speed;
    public byte pathID;
    public bool node_in;
    public bool node_out;
    public byte colour = 4;

    public ObjectData(
      string name_,
      short objectID_,
      short script_,
      int pointer_,
      int pointer2_,
      string modelfile_,
      string modelfile2_,
      int cameraid_,
      int jiggyid_)
    {
      this.name = name_;
      this.objectID = objectID_;
      this.specialScript = script_;
      this.pointer = pointer_;
      this.pointer2 = pointer2_;
      this.modelFile = modelfile_;
      this.modelFile2 = modelfile2_;
      this.cameraID = cameraid_;
      this.jiggyID = jiggyid_;
    }

    public static ObjectData clone(ObjectData o) => new ObjectData(o.name, o.objectID, o.specialScript, o.pointer, o.pointer2, o.modelFile, o.modelFile2, o.cameraID, o.jiggyID)
    {
      type = o.type,
      radius = o.radius
    };

    public static ObjectData fullClone(ObjectData o) => new ObjectData(o.name, o.objectID, o.specialScript, o.pointer, o.pointer2, o.modelFile, o.modelFile2, o.cameraID, o.jiggyID)
    {
      address = o.address,
      zoneID = o.zoneID,
      type = o.type,
      radius = o.radius,
      locX = o.locX,
      locY = o.locY,
      locZ = o.locZ,
      rot = o.rot,
      size = o.size,
      uid = o.uid,
      obj10 = o.obj10,
      obj11 = o.obj11,
      obj13 = o.obj13,
      obj16 = o.obj16,
      obj17 = o.obj17,
      obj18 = o.obj18,
      obj19 = o.obj19,
      struct2 = o.struct2,
      struct3 = o.struct3,
      structA = o.structA,
      structB = o.structB,
      hasJiggy = o.hasJiggy,
      flag = o.flag,
      activationPercent = o.activationPercent,
      pw1 = o.pw1,
      pw2 = o.pw2,
      pw3 = o.pw3,
      unk3 = o.unk3,
      useAnimation = o.useAnimation,
      usePause = o.usePause,
      useSpeed = o.useSpeed,
      animation = o.animation,
      pauseTime = o.pauseTime,
      speed = o.speed,
      pathID = o.pathID,
      node_in = o.node_in,
      node_out = o.node_out,
      nodeOutUID = o.nodeOutUID,
      colour = o.colour
    };

    public ObjectData(
      short objectID_,
      int address_,
      short x_,
      short y_,
      short z_,
      short rot_,
      short size_,
      short specialScript_,
      byte obj10_,
      byte obj11_,
      byte obj13_,
      byte obj16_,
      byte obj17_,
      byte obj18_,
      byte obj19_)
    {
      this.obj10 = obj10_;
      this.obj11 = obj11_;
      this.obj13 = obj13_;
      this.obj16 = obj16_;
      this.obj17 = obj17_;
      this.obj18 = obj18_;
      this.obj19 = obj19_;
      this.uid = (short) (((int) this.obj16 << 8) + (int) this.obj17);
      this.objectID = objectID_;
      this.address = address_;
      this.locX = x_;
      this.locY = y_;
      this.locZ = z_;
      this.rot = rot_;
      this.size = size_;
      this.specialScript = specialScript_;
      this.process();
    }

    public ObjectData(
      short objectID_,
      int address_,
      short x_,
      short y_,
      short z_,
      short rot_,
      short size_,
      short specialScript_,
      byte struct2_,
      byte struct3_,
      byte structA_,
      byte structB_)
    {
      this.struct2 = struct2_;
      this.struct3 = struct3_;
      this.structA = structA_;
      this.structB = structB_;
      this.objectID = objectID_;
      this.address = address_;
      this.locX = x_;
      this.locY = y_;
      this.locZ = z_;
      this.rot = rot_;
      this.size = size_;
      this.specialScript = specialScript_;
      this.process();
    }

    public ObjectData(
      short objectID_,
      int address_,
      short x_,
      short y_,
      short z_,
      short rot_,
      short size_,
      short specialScript_)
    {
      this.objectID = objectID_;
      this.address = address_;
      this.locX = x_;
      this.locY = y_;
      this.locZ = z_;
      this.rot = rot_;
      this.size = size_;
      this.specialScript = specialScript_;
      this.process();
    }

    public ObjectData(
      float activationPercent_,
      int w1,
      int w2,
      int w3,
      byte obj16_,
      byte obj17_,
      byte obj18_,
      byte obj19_,
      bool path,
      int add)
    {
      this.activationPercent = activationPercent_;
      this.pw1 = w1;
      this.pw2 = w2;
      this.pw3 = w3;
      this.unk3 = (uint) this.pw3 >> 23;
      this.speed = this.pw3 << 9 >> 9 >> 12;
      this.animation = this.pw2 >> 22 << 1;
      this.pauseTime = (this.pw3 << 20 >> 21) / 4;
      byte num = (byte) ((this.pw2 & 65280) >> 8);
      this.usePause = ((int) num & 1) == 1;
      this.useSpeed = ((int) num & 2) == 2;
      this.useAnimation = ((int) num & 4) == 4;
      this.pathID = (byte) (this.pw2 & (int) byte.MaxValue);
      this.obj16 = obj16_;
      this.obj17 = obj17_;
      this.obj18 = obj18_;
      this.obj19 = obj19_;
      this.type = ObjectType.SPath;
      this.uid = (short) (((int) this.obj16 << 8) + (int) this.obj17);
      this.address = add;
    }

    public void setControlFlags(bool usePause_, bool useSpeed_, bool useAnimation_)
    {
      this.usePause = usePause_;
      this.useSpeed = useSpeed_;
      this.useAnimation = useAnimation_;
      byte num = 0;
      if (this.usePause)
        ++num;
      if (this.useSpeed)
        num += (byte) 2;
      if (this.useAnimation)
        num += (byte) 20;
      this.pw2 = (int) ((long) this.pw2 & 4294902015L);
      this.pw2 += (int) num << 8;
    }

    public void setPathID(byte pid)
    {
      this.pw2 = (this.pw2 >> 8 << 8) + (int) pid;
      this.pathID = pid;
    }

    public void setSpeed(int speed_)
    {
      this.speed = speed_;
      this.pw3 = (int) ((long) this.pw3 & 4286582783L);
      this.pw3 += this.speed << 12;
    }

    public void setPauseTime(int pauseTime_)
    {
      this.pauseTime = pauseTime_;
      this.pw3 = (this.pw3 >> 12 << 12) + (this.pauseTime * 4 << 1);
    }

    public void setUNK3(int unk3_)
    {
      this.unk3 = (uint) unk3_;
      this.pw3 = (this.pw3 << 9 >> 9) + ((int) this.unk3 << 23);
    }

    private void process()
    {
      byte num = (byte) ((uint) this.specialScript & (uint) sbyte.MaxValue);
      switch (num)
      {
        case 0:
          break;
        case 12:
          break;
        default:
          this.radius = (ushort) ((uint) (ushort) this.specialScript >> 7);
          if (num == (byte) 6)
          {
            this.name = "warp";
            this.type = ObjectType.Warp;
            this.modelFile = ".\\resources\\warp.mw";
            this.pointer = 1;
            this.colour = (byte) 3;
          }
          if (num == (byte) 8)
          {
            if (this.objectID == (short) 77 || this.objectID == (short) 76)
            {
              this.name = "Magic Boundary";
              this.type = ObjectType.MagicBoundaryOrCameraTrigger;
              this.modelFile = ".\\resources\\magic_marker.mw";
              this.pointer = 1;
            }
            else
            {
              switch (this.objectID)
              {
                case 22:
                  this.name = "Camera Path Trigger 1";
                  break;
                case 23:
                  this.name = "Camera Path Trigger 2";
                  break;
                case 24:
                  this.name = "Camera Path Trigger 3";
                  break;
                case 25:
                  this.name = "Camera Path Trigger 4";
                  break;
                case 26:
                  this.name = "Camera Path Trigger 5";
                  break;
                case 27:
                  this.name = "Camera Path Trigger 6";
                  break;
                case 28:
                  this.name = "Camera Path Trigger 7";
                  break;
                case 29:
                  this.name = "Camera Path Trigger 8";
                  break;
                case 30:
                  this.name = "Camera Path Trigger 9";
                  break;
                case 31:
                  this.name = "Camera Path Trigger 10";
                  break;
                case 32:
                  this.name = "Camera Path Trigger 11";
                  break;
                case 33:
                  this.name = "Camera Path Trigger 12";
                  break;
                case 34:
                  this.name = "Camera Path Trigger 13";
                  break;
                case 35:
                  this.name = "Camera Path Trigger 14";
                  break;
                case 36:
                  this.name = "Camera Path Trigger 15";
                  break;
                case 37:
                  this.name = "Camera Path Trigger 16";
                  break;
                case 38:
                  this.name = "Camera Path Trigger 17";
                  break;
                case 39:
                  this.name = "Camera Path Trigger 18";
                  break;
                case 40:
                  this.name = "Camera Path Trigger 19";
                  break;
                case 41:
                  this.name = "Camera Path Trigger 20";
                  break;
                case 42:
                  this.name = "Camera Release";
                  break;
              }
              this.type = ObjectType.MagicBoundaryOrCameraTrigger;
              if (this.objectID >= (short) 22 && this.objectID <= (short) 41)
                this.modelFile = ".\\resources\\cam_start.mw";
              else if (this.objectID == (short) 42)
                this.modelFile = ".\\resources\\cam_end.mw";
              this.pointer = 1;
            }
          }
          if (num == (byte) 18)
          {
            this.name = "Camera Trigger";
            this.colour = (byte) 2;
            this.type = ObjectType.CameraTrigger;
          }
          if (num == (byte) 14)
          {
            this.name = "Enemy Boundary";
            this.colour = (byte) 0;
            this.pointer = 1;
            this.type = ObjectType.EnemeyBoundary;
            this.modelFile = ".\\resources\\enemy_marker.mw";
          }
          if (num == (byte) 16)
          {
            this.name = "Path Node";
            this.colour = (byte) 0;
            this.type = ObjectType.Path;
          }
          if (num != (byte) 20)
            break;
          this.name = "Flag";
          this.colour = (byte) 1;
          this.type = ObjectType.Flag;
          break;
      }
    }

    public bool compareTo(ObjectData od)
    {
      bool flag = false;
      if ((int) this.objectID == (int) od.objectID && (int) this.specialScript == (int) od.specialScript && (int) this.locX == (int) od.locX && (int) this.locY == (int) od.locY && (int) this.locZ == (int) od.locZ && this.address == od.address)
        flag = true;
      return flag;
    }

    public void RemapOBJProperties(string objectID_)
    {
      int objectId = (int) this.objectID;
      this.objectID = Convert.ToInt16(objectID_, 16);
      this.modelFile = "";
      this.modelFile2 = "";
      this.CalObjName();
    }

    private void CalObjName()
    {
      if (this.specialScript == (short) 6412)
      {
        switch (this.objectID)
        {
          case 1:
            this.name = "Start Point";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 2:
            this.name = "Entry Point 2";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 4:
            this.name = "Bull";
            this.pointer = 31024;
            break;
          case 5:
            this.name = "Ticker";
            this.pointer = 31000;
            break;
          case 6:
            this.name = "Grublin";
            this.pointer = 31936;
            break;
          case 7:
            this.name = "Mumbo";
            this.pointer = 31944;
            break;
          case 8:
            this.name = "Conga";
            this.pointer = 31096;
            this.hasJiggy = true;
            this.jiggyID = 0;
            break;
          case 9:
            this.name = "MM Hut";
            this.pointer = 40272;
            break;
          case 10:
            this.name = "Piranha Fish";
            this.pointer = 31216;
            break;
          case 11:
            this.name = "Jump Pad";
            this.pointer = 30080;
            break;
          case 12:
            this.name = "BGS Hut";
            this.pointer = 40280;
            break;
          case 13:
            this.name = "Wood Demolished";
            this.modelFile = "";
            break;
          case 14:
            this.name = "Bull 2";
            this.pointer = 31024;
            break;
          case 15:
            this.name = "Chimpy";
            this.pointer = 31104;
            this.hasJiggy = true;
            this.jiggyID = 0;
            break;
          case 17:
            this.name = "Ju-Ju";
            this.pointer = 30152;
            break;
          case 18:
            this.name = "Bee Hive";
            this.pointer = 31160;
            break;
          case 20:
            this.name = "Orange Attack";
            this.pointer = 29992;
            break;
          case 21:
            this.name = "Entry Point 3";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 23:
            this.name = "Shadow";
            this.pointer = 31888;
            break;
          case 30:
            this.name = "Leaky";
            this.pointer = 34664;
            this.cameraID = 36;
            break;
          case 32:
            this.name = "Pumpkin Transformation";
            this.modelFile = ".\\resources\\pumpkin.mw";
            this.pointer = 1;
            break;
          case 33:
            this.name = "Croc Transformation";
            this.modelFile = ".\\resources\\croc.mw";
            this.pointer = 1;
            break;
          case 34:
            this.name = "Walrus Transformation";
            this.modelFile = ".\\resources\\walrus.mw";
            this.pointer = 1;
            break;
          case 35:
            this.name = "Bee Transformation";
            this.modelFile = ".\\resources\\bee.mw";
            this.pointer = 1;
            break;
          case 36:
            this.name = "Yum-Yum_";
            this.pointer = 31008;
            break;
          case 37:
            this.name = "Cemetary Pot";
            this.pointer = 31752;
            break;
          case 38:
            this.name = "Start Climb";
            this.modelFile = ".\\resources\\climb_start.mw";
            this.pointer = 1;
            break;
          case 39:
            this.name = "End Climb Can't Go Higher";
            this.modelFile = ".\\resources\\climb_start.mw";
            this.pointer = 1;
            break;
          case 40:
            this.name = "End Climb";
            this.modelFile = ".\\resources\\climb_end.mw";
            this.pointer = 1;
            break;
          case 41:
            this.name = "Orange";
            this.pointer = 29992;
            break;
          case 42:
            this.name = "Blubber's Gold";
            this.pointer = 31952;
            break;
          case 44:
            this.name = "Running Shoes";
            this.pointer = 31184;
            break;
          case 45:
            this.name = "Mumbo Token";
            this.modelFile = ".\\resources\\mumboToken.mw";
            this.pointer = 1;
            break;
          case 49:
            this.name = "School of Fish";
            this.modelFile = "";
            break;
          case 55:
            this.name = "Wooden Crate Script";
            this.modelFile = "";
            break;
          case 56:
            this.name = "Tumblar";
            this.pointer = 30240;
            break;
          case 57:
            this.name = "Napper";
            this.pointer = 35208;
            break;
          case 58:
            this.name = "Motzand";
            this.pointer = 41720;
            break;
          case 60:
            this.name = "Big Key";
            this.pointer = 32736;
            break;
          case 61:
            this.name = "Propeller";
            this.pointer = 32528;
            break;
          case 62:
            this.name = "Propeller 2";
            this.pointer = 32536;
            break;
          case 63:
            this.name = "Propeller 3";
            this.pointer = 32544;
            break;
          case 64:
            this.name = "Propeller 4";
            this.pointer = 32872;
            break;
          case 65:
            this.name = "Propeller 5";
            this.pointer = 32528;
            break;
          case 66:
            this.name = "Propeller 6";
            this.pointer = 32528;
            break;
          case 67:
            this.name = "Screw";
            this.pointer = 41752;
            break;
          case 68:
            this.name = "Rock";
            this.pointer = 41800;
            break;
          case 70:
            this.name = "Jiggy";
            this.pointer = 31120;
            break;
          case 71:
            this.name = "Empty Honeycomb";
            this.pointer = 31152;
            break;
          case 73:
            this.name = "1-up";
            this.modelFile = ".\\resources\\life.mw";
            this.pointer = 1;
            break;
          case 74:
            this.name = "Wood Explosion";
            this.modelFile = "";
            break;
          case 75:
            this.name = "Explosion 2";
            this.modelFile = "";
            break;
          case 76:
            this.name = "Steam";
            this.modelFile = "";
            break;
          case 77:
            this.name = "Steam 2";
            this.modelFile = "";
            break;
          case 78:
            this.name = "Sparkles";
            this.modelFile = "";
            break;
          case 79:
            this.name = "Sparkles";
            this.modelFile = "";
            break;
          case 80:
            this.name = "Honeycomb";
            this.pointer = 31152;
            break;
          case 81:
            this.name = "Note";
            this.modelFile = ".\\resources\\note.mw";
            this.pointer = 1;
            break;
          case 82:
            this.name = "Egg";
            this.modelFile = ".\\resources\\egg.mw";
            this.pointer = 1;
            break;
          case 83:
            this.name = "Red Arrow";
            this.pointer = 32224;
            break;
          case 84:
            this.name = "Red Question Mark";
            this.pointer = 32240;
            break;
          case 85:
            this.name = "Red Cross";
            this.pointer = 32232;
            break;
          case 86:
            this.name = "Shrapnel";
            this.pointer = 32248;
            break;
          case 87:
            this.name = "Orange pad";
            this.pointer = 30192;
            break;
          case 89:
            this.name = "Ju-Ju Totem Pole";
            this.pointer = 30152;
            break;
          case 90:
            this.name = "Jiggy Podium";
            this.pointer = 34904;
            break;
          case 91:
            this.name = "BGS Egg 1";
            this.pointer = 31384;
            break;
          case 94:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 95:
            this.name = "Orange Jinjo";
            this.pointer = 31864;
            break;
          case 96:
            this.name = "Blue Jinjo";
            this.pointer = 31896;
            break;
          case 97:
            this.name = "Purple Jinjo";
            this.pointer = 31904;
            break;
          case 98:
            this.name = "Green Jinjo";
            this.pointer = 31912;
            break;
          case 99:
            this.name = "Where Banjo throw's Chimpy's Orange";
            break;
          case 100:
            this.name = "Water Level Switch";
            this.modelFile = "3509B0.bin";
            this.pointer = 33856;
            break;
          case 101:
            this.name = "Wading Boots";
            this.pointer = 31176;
            break;
          case 102:
            this.name = "?";
            this.modelFile = "";
            break;
          case 103:
            this.name = "Snippet";
            this.pointer = 31064;
            break;
          case 104:
            this.name = "Snacker";
            this.pointer = 31768;
            break;
          case 105:
            this.name = "Yum-Yum";
            this.pointer = 31008;
            break;
          case 108:
            this.name = "?";
            this.modelFile = "";
            break;
          case 109:
            this.name = "Banjo Door";
            this.pointer = 32088;
            break;
          case 114:
            this.name = "Entry Point 17";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 115:
            this.name = "Entry Point 16";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 116:
            this.name = "Entry Point 15";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 117:
            this.name = "Entry Point 14";
            this.modelFile = "";
            break;
          case 118:
            this.name = "Entry Point 4";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 119:
            this.name = "Entry Point 5";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 120:
            this.name = "Entry Point 6";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 121:
            this.name = "Entry Point 7";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 122:
            this.name = "Entry Point 8";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 123:
            this.name = "Entry Point 9";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 124:
            this.name = "Entry Point 10";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 125:
            this.name = "Entry Point 11";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 126:
            this.name = "Entry Point 12";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case (short) sbyte.MaxValue:
            this.name = "Entry Point 13";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 142:
            this.name = "Concert Banjo and Kazooie";
            this.pointer = 31040;
            break;
          case 143:
            this.name = "Concert Mumbo";
            this.pointer = 31776;
            break;
          case 144:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 145:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 146:
            this.name = "Concert Tooty";
            this.pointer = 31080;
            break;
          case 147:
            this.name = "Nintendo Cube";
            this.pointer = 31688;
            break;
          case 148:
            this.name = "Rareware Logo";
            this.modelFile = "1F5350.bin";
            this.pointer = 31696;
            break;
          case 149:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 150:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 151:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 152:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 153:
            this.name = "?";
            this.modelFile = "";
            break;
          case 154:
            this.name = "?";
            this.modelFile = "";
            break;
          case 155:
            this.name = "Concert Bull";
            this.pointer = 31032;
            break;
          case 156:
            this.name = "Concert Frog";
            this.pointer = 31200;
            break;
          case 157:
            this.name = "Bull";
            this.pointer = 31024;
            break;
          case 158:
            this.name = "Grunty";
            this.pointer = 33056;
            break;
          case 159:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 160:
            this.name = "Banjo-Kazooie Sign";
            this.pointer = 35072;
            break;
          case 161:
            this.name = "?";
            this.modelFile = "";
            break;
          case 162:
            this.name = "Fire Sparkle";
            this.modelFile = "";
            break;
          case 163:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 164:
            this.name = "?";
            this.modelFile = "";
            break;
          case 165:
            this.name = "Dragon Fly";
            this.pointer = 32256;
            break;
          case 166:
            this.name = "Red Yumblie";
            this.pointer = 32328;
            break;
          case 167:
            this.name = "BBQ Mumbo";
            this.pointer = 33328;
            break;
          case 168:
            this.name = "BBQ";
            this.pointer = 33336;
            break;
          case 169:
            this.name = "BBQ";
            this.pointer = 33336;
            break;
          case 170:
            this.name = "Dingpot";
            this.pointer = 33048;
            break;
          case 171:
            this.name = "Grunty's Arms";
            this.pointer = 33064;
            break;
          case 172:
            this.name = "Grunty";
            this.pointer = 33056;
            break;
          case 173:
            this.name = "Bat";
            this.pointer = 31976;
            break;
          case 174:
            this.name = "Dingpot";
            this.pointer = 33048;
            break;
          case 175:
            this.name = "Green Mist";
            this.pointer = 33040;
            break;
          case 176:
            this.name = "Bottles";
            this.pointer = 31440;
            break;
          case 177:
            this.name = "Bottles Mound";
            this.pointer = 31448;
            break;
          case 178:
            this.name = "Machine Room Door";
            this.pointer = 30928;
            break;
          case 180:
            this.name = "Tooty";
            this.pointer = 31088;
            break;
          case 181:
            this.name = "Grunty's Broomstick";
            this.pointer = 33096;
            break;
          case 182:
            this.name = "Grunty on Broomstick";
            this.pointer = 33104;
            break;
          case 183:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 184:
            this.name = "Banjo Sleeping";
            this.modelFile = "";
            break;
          case 185:
            this.name = "Banjo's Bed";
            this.pointer = 34840;
            break;
          case 186:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 187:
            this.name = "Kazooie in Backpack Stand";
            this.pointer = 33136;
            break;
          case 188:
            this.name = "Banjo's Curtains";
            this.pointer = 33144;
            break;
          case 189:
            this.name = "Banjo's Door";
            this.pointer = 33160;
            break;
          case 190:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 191:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 192:
            this.name = "???";
            this.modelFile = "";
            break;
          case 193:
            this.name = "Jiggy Cutout Board";
            this.modelFile = "";
            break;
          case 194:
            this.name = "Sexy Grunty";
            this.pointer = 33240;
            break;
          case 195:
            this.name = "Ugly Tooty";
            this.pointer = 33240;
            break;
          case 197:
            this.name = "Chimpy's Tree Stump";
            this.pointer = 31960;
            break;
          case 199:
            this.name = "RIP Tombstone";
            this.pointer = 30296;
            break;
          case 200:
            this.name = "Boggy on Sled 2";
            this.pointer = 31464;
            break;
          case 202:
            this.name = "Tee-Hee";
            this.pointer = 31984;
            break;
          case 203:
            this.name = "Normal Barrel Top";
            this.pointer = 31992;
            break;
          case 204:
            this.name = "Camera Angle";
            this.modelFile = "";
            break;
          case 228:
            this.name = "Flight Pad";
            this.pointer = 30168;
            break;
          case 230:
            this.name = "Gloop";
            this.pointer = 31272;
            break;
          case 231:
            this.name = "Gloop Bubbles";
            this.modelFile = "";
            break;
          case 232:
            this.name = "Tanktup";
            this.pointer = 32264;
            break;
          case 233:
            this.name = "Tanktup Head";
            this.pointer = 32272;
            break;
          case 234:
            this.name = "Tanktup Leg 1";
            this.pointer = 32280;
            break;
          case 235:
            this.name = "Tanktup Leg 2";
            this.pointer = 32288;
            break;
          case 236:
            this.name = "Tanktup Leg 3";
            this.pointer = 32296;
            break;
          case 238:
            this.name = "Egg 2";
            this.pointer = 31392;
            break;
          case 239:
            this.name = "Egg 3";
            this.pointer = 31400;
            break;
          case 240:
            this.name = "Egg 4";
            this.pointer = 31408;
            break;
          case 241:
            this.name = "Leaf";
            this.pointer = 30464;
            break;
          case 242:
            this.name = "Black Snippet";
            this.pointer = 35272;
            break;
          case 243:
            this.name = "?";
            this.modelFile = "";
            break;
          case 244:
            this.name = "Gold Chest";
            this.pointer = 32760;
            break;
          case 245:
            this.name = "Mutant Snippet";
            this.pointer = 31064;
            break;
          case 246:
            this.name = "Big Alligator";
            this.pointer = 31568;
            break;
          case 257:
            this.name = "Gold Tooth";
            this.pointer = 41760;
            break;
          case 258:
            this.name = "Gold Tooth";
            this.pointer = 41800;
            break;
          case 259:
            this.name = "Entry Point 18";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 260:
            this.name = "Entry Point 19";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 261:
            this.name = "Entry Point 20";
            this.modelFile = ".\\resources\\entry.mw";
            this.pointer = 1;
            break;
          case 264:
            this.name = "Shadow";
            this.pointer = 34984;
            break;
          case 265:
            this.name = "MMM - Big Door";
            this.pointer = 32000;
            break;
          case 266:
            this.name = "MMM - Main Door";
            this.pointer = 32008;
            break;
          case 267:
            this.name = "Basement Door";
            this.modelFile = "";
            break;
          case 268:
            this.name = "Locked Gate";
            this.pointer = 32024;
            break;
          case 269:
            this.name = "Gate";
            this.pointer = 32032;
            break;
          case 270:
            this.name = "Hatch";
            this.pointer = 32040;
            break;
          case 276:
            this.name = "Church Door";
            this.pointer = 32048;
            break;
          case 277:
            this.name = "Blubber";
            this.pointer = 31256;
            this.hasJiggy = true;
            this.jiggyID = 0;
            break;
          case 278:
            this.name = "Bullseye";
            this.pointer = 32672;
            break;
          case 279:
            this.name = "Nipper's Shell";
            this.pointer = 32064;
            this.hasJiggy = true;
            break;
          case 280:
            this.name = "Grey Slappa";
            this.pointer = 31264;
            break;
          case 281:
            this.name = "Magic Carpet";
            this.pointer = 32120;
            break;
          case 282:
            this.name = "Sarcophagus";
            this.pointer = 30848;
            break;
          case 283:
            this.name = "Rubee";
            this.pointer = 32128;
            break;
          case 284:
            this.name = "Histup";
            this.pointer = 32136;
            break;
          case 285:
            this.name = "Pot";
            this.pointer = 32160;
            break;
          case 286:
            this.name = "Hand Shadows";
            this.pointer = 32192;
            break;
          case 287:
            this.name = "Dirt flies up";
            this.modelFile = "";
            break;
          case 288:
            this.name = "Purple Slappa";
            this.pointer = 31304;
            break;
          case 289:
            this.name = "Big Jinxy Head";
            this.pointer = 32200;
            break;
          case 290:
            this.name = "Square Shadow";
            this.pointer = 32208;
            break;
          case 291:
            this.name = "Magic Carpet";
            this.pointer = 32120;
            break;
          case 292:
            this.name = "Snowman";
            this.modelFile = "1D9CE0.bin";
            this.pointer = 31312;
            break;
          case 293:
            this.name = "Snowball";
            this.pointer = 31320;
            break;
          case 294:
            this.name = "Snowman's Hat";
            this.pointer = 31328;
            break;
          case 297:
            this.name = "Red Feather";
            this.modelFile = ".\\resources\\red_feather.mw";
            this.pointer = 1;
            break;
          case 300:
            this.name = "Bottles Mound";
            this.pointer = 31448;
            break;
          case 302:
            this.name = "Gobi";
            this.pointer = 32152;
            break;
          case 303:
            this.name = "Bamboo";
            this.pointer = 32176;
            break;
          case 304:
            this.name = "Gobi's Rock";
            this.pointer = 32184;
            break;
          case 305:
            this.name = "Gobi 2";
            this.pointer = 32152;
            break;
          case 306:
            this.name = "Trunker";
            this.pointer = 32144;
            break;
          case 307:
            this.name = "Flibbit";
            this.pointer = 31296;
            break;
          case 308:
            this.name = "Dragon Fly";
            this.pointer = 32256;
            break;
          case 309:
            this.name = "Gobi 3";
            this.pointer = 32152;
            break;
          case 311:
            this.name = "Yellow Flibblet";
            this.pointer = 31424;
            break;
          case 313:
            this.name = "Yumblie";
            this.pointer = 32336;
            break;
          case 314:
            this.name = "Mr. Vile";
            this.pointer = 31280;
            this.hasJiggy = true;
            break;
          case 315:
            this.name = "Floatsam";
            this.pointer = 32416;
            break;
          case 319:
            this.name = "Sun Switch";
            this.pointer = 32408;
            break;
          case 320:
            this.name = "Sun Door";
            this.pointer = 32400;
            break;
          case 322:
            this.name = "Star Hatch";
            this.pointer = 32112;
            break;
          case 323:
            this.name = "Kazooie Door";
            this.pointer = 32096;
            break;
          case 324:
            this.name = "Star Switch";
            this.pointer = 32080;
            break;
          case 325:
            this.name = "Gold Honeycomb Switch";
            this.pointer = 32856;
            break;
          case 326:
            this.name = "Kazooie Target";
            this.pointer = 32168;
            break;
          case 334:
            this.name = "Green Jiggy Switch";
            this.pointer = 32320;
            break;
          case 335:
            this.name = "Destroyed Jiggy";
            this.modelFile = "";
            break;
          case 337:
            this.name = "Lockup";
            this.pointer = 32056;
            break;
          case 338:
            this.name = "Lockup";
            this.pointer = 32056;
            break;
          case 339:
            this.name = "Lockup";
            this.pointer = 32056;
            break;
          case 351:
            this.name = "Christmas Tree";
            this.pointer = 33496;
            break;
          case 352:
            this.name = "Boggy on Sled";
            this.pointer = 31464;
            break;
          case 353:
            this.name = "Boggy's Gate (Right)";
            this.pointer = 30272;
            break;
          case 354:
            this.name = "Boggy's Gate (Left)";
            this.pointer = 30272;
            break;
          case 355:
            this.name = "Bat";
            this.pointer = 31976;
            break;
          case 356:
            this.name = "Cauliwobble";
            this.pointer = 34312;
            break;
          case 357:
            this.name = "Bawl";
            this.pointer = 34320;
            break;
          case 358:
            this.name = "Topper";
            this.pointer = 34304;
            break;
          case 359:
            this.name = "Coliwobble /extra honeycomb";
            this.pointer = 34312;
            break;
          case 360:
            this.name = "Winter Switch";
            this.pointer = 34392;
            break;
          case 361:
            this.name = "Door";
            this.pointer = 34152;
            break;
          case 362:
            this.name = "Autumn Switch";
            this.pointer = 34384;
            break;
          case 363:
            this.name = "Door";
            this.pointer = 34152;
            break;
          case 364:
            this.name = "Summer Switch";
            this.pointer = 34376;
            break;
          case 365:
            this.name = "Door";
            this.pointer = 34152;
            break;
          case 367:
            this.name = "SM Boulder";
            this.pointer = 32768;
            break;
          case 370:
            this.name = "Weird Green Ball?";
            this.pointer = 40056;
            break;
          case 371:
            this.name = "Weird Green Ball?";
            this.pointer = 40056;
            break;
          case 372:
            this.name = "Weird Green Ball?";
            this.pointer = 40056;
            break;
          case 373:
            this.name = "Ship Propeller";
            this.pointer = 32432;
            break;
          case 374:
            this.name = "Green propeller switch";
            this.pointer = 32440;
            break;
          case 375:
            this.name = "Shaft 1";
            this.pointer = 32456;
            break;
          case 376:
            this.name = "Spinning Platform 1";
            this.pointer = 32504;
            break;
          case 377:
            this.name = "Spinning Platform 2";
            this.pointer = 32512;
            break;
          case 378:
            this.name = "Spinning Platform 3";
            this.pointer = 32520;
            break;
          case 379:
            this.name = "Grey Cog 1";
            this.pointer = 32480;
            break;
          case 380:
            this.name = "Grey Cog 2";
            this.pointer = 32488;
            break;
          case 381:
            this.name = "Grey Cog 3";
            this.pointer = 32496;
            break;
          case 382:
            this.name = "Shaft 2";
            this.pointer = 32456;
            break;
          case 383:
            this.name = "Shaft 3";
            this.pointer = 32464;
            break;
          case 384:
            this.name = "Shaft 4";
            this.pointer = 32472;
            break;
          case 385:
            this.name = "Sled";
            this.pointer = 31016;
            break;
          case 386:
            this.name = "Sled 2";
            this.pointer = 31016;
            break;
          case 389:
            this.name = "Place near warp, makes Banjo walk in";
            this.modelFile = ".\\resources\\walkin.mw";
            this.pointer = 1;
            break;
          case 395:
            this.name = "Lava Floor";
            this.modelFile = ".\\resources\\lava.mw";
            this.pointer = 1;
            break;
          case 399:
            this.name = "Honeycomb Switch";
            this.pointer = 32784;
            break;
          case 400:
            this.name = "Witch Switch Jiggy (CC)";
            this.pointer = 31120;
            break;
          case 401:
            this.name = "Secret X Barrel Top";
            this.pointer = 34544;
            break;
          case 405:
            this.name = "Banjo Sleeping";
            this.pointer = 34840;
            break;
          case 406:
            this.name = "Banjo playing Gameboy";
            this.modelFile = "";
            break;
          case 407:
            this.name = "Banjo cooking";
            this.pointer = 31016;
            break;
          case 408:
            this.name = "Banjo's Bed";
            this.pointer = 34840;
            break;
          case 409:
            this.name = "Banjo's Chair";
            this.pointer = 30744;
            break;
          case 410:
            this.name = "Banjo's Kitchen";
            this.pointer = 30800;
            break;
          case 411:
            this.name = "Another Secret can get in desert";
            this.modelFile = "";
            break;
          case 412:
            this.name = "The End";
            this.modelFile = "";
            break;
          case 414:
            this.name = "Place near warp, makes Banjo walk in";
            this.modelFile = ".\\resources\\walkin.mw";
            this.pointer = 1;
            break;
          case 425:
            this.name = "TTC - Lighthouse Door";
            this.pointer = 34648;
            break;
          case 443:
            this.name = "Propeller";
            this.pointer = 32528;
            break;
          case 444:
            this.name = "Propeller";
            this.pointer = 32536;
            break;
          case 445:
            this.name = "Propeller";
            this.pointer = 32544;
            break;
          case 446:
            this.name = "Boat Propeller Switch";
            this.pointer = 32552;
            break;
          case 447:
            this.name = "1 Switch";
            this.pointer = 32560;
            break;
          case 448:
            this.name = "2 Switch";
            this.pointer = 32568;
            break;
          case 449:
            this.name = "3 Switch";
            this.pointer = 32576;
            break;
          case 450:
            this.name = "Gold Whistle 1";
            this.pointer = 32584;
            break;
          case 451:
            this.name = "Gold Whistle 2";
            this.pointer = 32592;
            break;
          case 452:
            this.name = "Gold Whistle 3";
            this.pointer = 32600;
            break;
          case 454:
            this.name = "Pipe";
            this.pointer = 32608;
            break;
          case 455:
            this.name = "Anchor Switch";
            this.pointer = 32624;
            break;
          case 456:
            this.name = "Snorkel";
            this.pointer = 32632;
            break;
          case 457:
            this.name = "Anchor and Chain";
            this.pointer = 32640;
            break;
          case 458:
            this.name = "Rareware Flag Pole";
            this.pointer = 32648;
            break;
          case 460:
            this.name = "Chompa";
            this.pointer = 32792;
            break;
          case 469:
            this.name = "Cheato 1";
            this.pointer = 35088;
            break;
          case 470:
            this.name = "Cheato 2";
            this.pointer = 35088;
            break;
          case 471:
            this.name = "Cheato 3";
            this.pointer = 35088;
            break;
          case 472:
            this.name = "Blue Egg Upgrade";
            this.pointer = 35024;
            break;
          case 473:
            this.name = "Red Feather Upgrade";
            this.pointer = 35032;
            break;
          case 474:
            this.name = "Gold Feather Upgrade";
            this.pointer = 35040;
            break;
          case 475:
            this.name = "Game Over";
            this.pointer = 35064;
            break;
          case 476:
            this.name = "Banjo Kazooie Sign";
            this.pointer = 35072;
            break;
          case 477:
            this.name = "Copyright";
            this.pointer = 35080;
            break;
          case 478:
            this.name = "Press Start";
            this.pointer = 35192;
            break;
          case 479:
            this.name = "No Controller";
            this.pointer = 35200;
            break;
          case 480:
            this.name = "Bottles Bonus";
            break;
          case 481:
            this.name = "Iron Gate";
            this.pointer = 34640;
            break;
          case 482:
            this.name = "Spring Switch";
            this.pointer = 34368;
            break;
          case 483:
            this.name = "CCW Door";
            this.pointer = 34824;
            break;
          case 484:
            this.name = "Toots";
            this.pointer = 32824;
            break;
          case 485:
            this.name = "Firecrackers";
            this.pointer = 31744;
            break;
          case 487:
            this.name = "Emitter: ";
            switch (this.specialScript)
            {
              case 396:
                this.name += "Green Bubbles";
                return;
              case 908:
                this.name += "Snow Explosion";
                return;
              case 1036:
                this.name += "Leaves";
                return;
              case 1292:
                this.name += "Green Smoke";
                return;
              case 1548:
                this.name += "Green Balls";
                return;
              case 2060:
                this.name += "White Smoke";
                return;
              case 2188:
                this.name += "Black Smoke";
                return;
              case 2316:
                this.name += "White Smoke (small)";
                return;
              case 2444:
                this.name += "Dust Cloud";
                return;
              default:
                return;
            }
          case 489:
            this.name = "Venus Flytrap";
            this.pointer = 32920;
            break;
          case 490:
            this.name = "Polar bear kid 1";
            this.pointer = 33016;
            break;
          case 491:
            this.name = "Polar bear kid 2";
            this.pointer = 33024;
            break;
          case 492:
            this.name = "Polar bear kid 3";
            this.pointer = 33032;
            break;
          case 493:
            this.name = "Blue Present";
            this.pointer = 30016;
            break;
          case 495:
            this.name = "Green Present";
            this.pointer = 30032;
            break;
          case 497:
            this.name = "Red Present";
            this.pointer = 33440;
            break;
          case 499:
            this.name = "Wozza";
            this.pointer = 33592;
            break;
          case 501:
            this.name = "Kazooie Door 2";
            this.pointer = 32096;
            break;
          case 503:
            this.name = "Jinxy";
            this.pointer = 32680;
            break;
          case 504:
            this.name = "?";
            this.modelFile = "";
            break;
          case 505:
            this.name = "Cactus";
            this.pointer = 32696;
            break;
          case 506:
            this.name = "Croctus";
            this.pointer = 32704;
            break;
          case 507:
            this.name = "Green Jiggy Switch";
            this.pointer = 32320;
            break;
          case 509:
            this.name = "Clock Switch";
            this.pointer = 32896;
            break;
          case 510:
            this.name = "Gate";
            this.pointer = 32904;
            break;
          case 511:
            this.name = "Red Feather";
            this.modelFile = ".\\resources\\red_feather.mw";
            this.pointer = 1;
            break;
          case 512:
            this.name = "Gold Feather_";
            this.modelFile = ".\\resources\\gold_feather.mw";
            this.pointer = 1;
            break;
          case 515:
            this.name = "Note Door";
            this.pointer = 33568;
            break;
          case 516:
            this.name = "Witch Switch (MM)";
            this.pointer = 34168;
            break;
          case 517:
            this.name = "Witch Switch Jiggy (MM)";
            this.pointer = 31120;
            break;
          case 518:
            this.name = "Witch Switch (MMM)";
            this.pointer = 34168;
            break;
          case 519:
            this.name = "Witch Switch Jiggy (MMM)";
            this.pointer = 31120;
            break;
          case 520:
            this.name = "Witch Switch (TTC)";
            this.pointer = 34168;
            break;
          case 521:
            this.name = "Witch Switch Jiggy (TTC)";
            this.pointer = 31120;
            break;
          case 523:
            this.name = "Witch Switch (RBB)";
            this.pointer = 34168;
            break;
          case 524:
            this.name = "Witch Switch Jiggy (RBB)";
            this.pointer = 31120;
            break;
          case 525:
            this.name = "Brick wall";
            this.pointer = 33696;
            break;
          case 526:
            this.name = "Entrance door to MM";
            this.pointer = 33704;
            break;
          case 527:
            this.name = "RBB Entrance Door";
            this.pointer = 33848;
            break;
          case 528:
            this.name = "BGS Entrance Door";
            this.pointer = 33800;
            break;
          case 529:
            this.name = "Chest Lid";
            this.pointer = 33712;
            break;
          case 530:
            this.name = "Big Iron Bars";
            this.pointer = 33744;
            break;
          case 531:
            this.name = "Circular Grate";
            this.pointer = 33752;
            break;
          case 532:
            this.name = "Grate Switch";
            this.pointer = 33776;
            break;
          case 533:
            this.name = "Tall Pipe";
            this.pointer = 33720;
            break;
          case 534:
            this.name = "Tall Pipe 2";
            this.pointer = 33728;
            break;
          case 535:
            this.name = "Pipe Switch";
            this.pointer = 33760;
            break;
          case 536:
            this.name = "Pipe";
            this.pointer = 33736;
            break;
          case 537:
            this.name = "Pipe Switch 2";
            this.pointer = 33768;
            break;
          case 538:
            this.name = "CC Entrance grates";
            this.modelFile = "";
            break;
          case 539:
            this.name = "Yum-Yum";
            this.pointer = 31008;
            break;
          case 540:
            this.name = "Wooden Door";
            this.pointer = 33576;
            break;
          case 541:
            this.name = "Steel Door";
            this.pointer = 33584;
            break;
          case 542:
            this.name = "Circular Green Grate";
            this.pointer = 33824;
            break;
          case 543:
            this.name = "Circular Brown Grate";
            this.pointer = 33824;
            break;
          case 544:
            this.name = "RBB Jigsaw grate";
            this.pointer = 33872;
            break;
          case 545:
            this.name = "Water Switch";
            this.pointer = 33856;
            break;
          case 546:
            this.name = "Water Switch 2";
            this.pointer = 33832;
            break;
          case 547:
            this.name = "Water Switch 3";
            this.pointer = 33816;
            break;
          case 548:
            this.name = "Ice Ball";
            this.pointer = 33808;
            break;
          case 549:
            this.name = "Rareware box";
            this.pointer = 33840;
            break;
          case 550:
            this.name = "GV Entrance";
            this.pointer = 33912;
            break;
          case 551:
            this.name = "Phantom Glow";
            this.pointer = 33920;
            break;
          case 552:
            this.name = "Invisible Wall";
            this.modelFile = "";
            break;
          case 553:
            this.name = "House";
            this.pointer = 33968;
            break;
          case 555:
            this.name = "Frozen Mumbo Hut";
            this.pointer = 33976;
            break;
          case 556:
            this.name = "Christmas Present Stack";
            this.pointer = 33984;
            break;
          case 557:
            this.name = "Snowy Bridge";
            this.pointer = 33992;
            break;
          case 558:
            this.name = "Snowy Bridge 2";
            this.pointer = 33992;
            break;
          case 559:
            this.name = "Snowy Bridge 3";
            this.pointer = 33992;
            break;
          case 560:
            this.name = "Cobweb";
            this.pointer = 30736;
            break;
          case 561:
            this.name = "Big yellow cobweb";
            this.pointer = 34112;
            break;
          case 563:
            this.name = "Mumbo's Hut";
            this.pointer = 31792;
            break;
          case 564:
            this.name = "CCW Entrance Door";
            this.pointer = 34120;
            break;
          case 565:
            this.name = "FP Entrance Door";
            this.pointer = 34128;
            break;
          case 566:
            this.name = "FP Entrance Door 2";
            this.pointer = 34136;
            break;
          case 567:
            this.name = "Witch Switch (CCW)";
            this.pointer = 34168;
            break;
          case 568:
            this.name = "Witch Switch Jiggy (CCW)";
            this.pointer = 31120;
            break;
          case 569:
            this.name = "Witch Switch (FP)";
            this.pointer = 34168;
            break;
          case 570:
            this.name = "Wooden snow drift texture";
            this.pointer = 34144;
            break;
          case 572:
            this.name = "CCW Switch";
            this.pointer = 33880;
            break;
          case 573:
            this.name = "Mumbo Pad";
            this.pointer = 34176;
            break;
          case 574:
            this.name = "Empty wooden coffin";
            this.pointer = 34208;
            break;
          case 575:
            this.name = "Skylights";
            this.pointer = 34216;
            break;
          case 578:
            this.name = "?";
            this.modelFile = "";
            break;
          case 579:
            this.name = "Wooden Panel";
            this.pointer = 34616;
            break;
          case 580:
            this.name = "Sarcophagus";
            this.pointer = 30848;
            break;
          case 581:
            this.name = "Sarcophagus switch";
            this.pointer = 34624;
            break;
          case 582:
            this.name = "Flying pad switch";
            this.modelFile = "";
            break;
          case 583:
            this.name = "Kazooie fly disk";
            this.pointer = 30168;
            break;
          case 584:
            this.name = "Shock jump switch";
            this.modelFile = "";
            break;
          case 585:
            this.name = "Kazooie Shock Spring disc";
            this.pointer = 30080;
            break;
          case 595:
            this.name = "Piece of glass panel";
            this.pointer = 34600;
            break;
          case 596:
            this.name = "Piece of glass panel 2";
            this.pointer = 34600;
            break;
          case 597:
            this.name = "Tomb";
            this.pointer = 34528;
            break;
          case 598:
            this.name = "Witch Switch (GV)";
            this.pointer = 34168;
            break;
          case 599:
            this.name = "Witch Switch (BGS)";
            this.pointer = 34168;
            break;
          case 600:
            this.name = "Tomb Top";
            this.modelFile = "";
            break;
          case 601:
            this.name = "Grunty eye switch";
            this.pointer = 34512;
            break;
          case 602:
            this.name = "Grunty eye switch 2";
            this.pointer = 34520;
            break;
          case 603:
            this.name = "Witch Switch (CC)";
            this.pointer = 34168;
            break;
          case 604:
            this.name = "Sharkfood Island";
            this.pointer = 34536;
            break;
          case 605:
            this.name = "Ice Key";
            this.pointer = 34552;
            break;
          case 606:
            this.name = "SNS Egg";
            this.pointer = 34560;
            break;
          case 607:
            this.name = "Nabnut's Window Spring";
            this.pointer = 34408;
            break;
          case 608:
            this.name = "Nabnut's Window Summer";
            this.pointer = 34400;
            break;
          case 609:
            this.name = "Nabnut's Window Fall";
            this.pointer = 34408;
            break;
          case 610:
            this.name = "Nabnut's Window Winter";
            this.pointer = 34416;
            break;
          case 611:
            this.name = "Safety Boat";
            this.pointer = 34184;
            break;
          case 612:
            this.name = "Safety Boat";
            this.pointer = 34184;
            break;
          case 613:
            this.name = "Door";
            this.pointer = 34200;
            break;
          case 614:
            this.name = "Window";
            this.pointer = 33944;
            break;
          case 615:
            this.name = "Window";
            this.pointer = 33944;
            break;
          case 617:
            this.name = "Clanker";
            this.modelFile = "";
            break;
          case 634:
            this.name = "TipTup";
            this.pointer = 32344;
            this.hasJiggy = true;
            break;
          case 635:
            this.name = "Choir Member";
            this.pointer = 32352;
            break;
          case 636:
            this.name = "Choir Member";
            this.pointer = 32352;
            break;
          case 637:
            this.name = "Choir Member";
            this.pointer = 32352;
            break;
          case 638:
            this.name = "Choir Member";
            this.pointer = 32352;
            break;
          case 639:
            this.name = "Choir Member";
            this.pointer = 32352;
            break;
          case 640:
            this.name = "Choir Member";
            this.pointer = 32352;
            break;
          case 641:
            this.name = "Kaboom Part 1";
            this.pointer = 32728;
            break;
          case 642:
            this.name = "Kaboom Part 2";
            this.pointer = 32728;
            break;
          case 643:
            this.name = "Kaboom Part 3";
            this.pointer = 32728;
            break;
          case 644:
            this.name = "Kaboom Part 4";
            this.pointer = 32728;
            break;
          case 645:
            this.name = "Big Jinxy Head";
            this.pointer = 30360;
            break;
          case 646:
            this.name = "Big Jinxy Head 2";
            this.pointer = 30360;
            break;
          case 647:
            this.name = "Big Jinxy Head 3";
            this.pointer = 30360;
            break;
          case 649:
            this.name = "Vent";
            this.pointer = 32800;
            break;
          case 650:
            this.name = "Underwater Whip Crack";
            this.pointer = 32808;
            break;
          case 652:
            this.name = "Green Drain";
            this.pointer = 32832;
            break;
          case 653:
            this.name = "Green Drain 2";
            this.pointer = 32840;
            break;
          case 654:
            this.name = "Green Drain 3";
            this.pointer = 32848;
            break;
          case 655:
            this.name = "Vent";
            this.pointer = 32800;
            break;
          case 656:
            this.name = "Propeller 7";
            this.pointer = 32872;
            break;
          case 657:
            this.name = "Propeller 8";
            this.pointer = 32528;
            break;
          case 658:
            this.name = "Propeller 9";
            this.pointer = 32536;
            break;
          case 659:
            this.name = "Propeller 10";
            this.pointer = 32544;
            break;
          case 660:
            this.name = "Propeller 11";
            this.pointer = 32544;
            break;
          case 661:
            this.name = "Propeller 12";
            this.pointer = 32544;
            break;
          case 662:
            this.name = "Bell Buoy";
            this.pointer = 32880;
            break;
          case 663:
            this.name = "Row Boat";
            this.pointer = 32888;
            break;
          case 664:
            this.name = "Flat Board";
            this.pointer = 32952;
            break;
          case 665:
            this.name = "Lump of Honey";
            this.pointer = 32944;
            break;
          case 666:
            this.name = "Flat Board";
            this.pointer = 32960;
            break;
          case 667:
            this.name = "Zubba";
            this.pointer = 32968;
            break;
          case 668:
            this.name = "Zubba (Attacker)";
            this.pointer = 32968;
            break;
          case 669:
            this.name = "Beanstalk";
            this.pointer = 32976;
            break;
          case 670:
            this.name = "Gobi";
            this.pointer = 32152;
            break;
          case 671:
            this.name = "Big Clucker";
            this.pointer = 33448;
            break;
          case 672:
            this.name = "???";
            this.modelFile = "";
            break;
          case 673:
            this.name = "Eyrie";
            this.pointer = 33464;
            break;
          case 674:
            this.name = "Caterpiller";
            this.pointer = 33472;
            break;
          case 675:
            this.name = "Big Eyrie";
            this.pointer = 33488;
            break;
          case 676:
            this.name = "TNT Box Part 1";
            this.pointer = 33528;
            break;
          case 678:
            this.name = "Nabnut";
            this.pointer = 34472;
            break;
          case 679:
            this.name = "Nabnut 2";
            this.pointer = 34480;
            break;
          case 680:
            this.name = "Nabnut 3";
            this.pointer = 34480;
            break;
          case 681:
            this.name = "Acorn";
            this.pointer = 33544;
            break;
          case 682:
            this.name = "Gnawty";
            this.pointer = 33552;
            break;
          case 683:
            this.name = "Gnawty 2";
            this.pointer = 33552;
            break;
          case 684:
            this.name = "Gnawty's Boulder";
            this.pointer = 33560;
            break;
          case 686:
            this.name = "Leaves Start";
            this.modelFile = "";
            break;
          case 687:
            this.name = "Leaves End";
            this.modelFile = "";
            break;
          case 688:
            this.name = "Rain Start";
            this.modelFile = "";
            break;
          case 689:
            this.name = "Rain End";
            this.modelFile = "";
            break;
          case 690:
            this.name = "Snow Start";
            this.modelFile = "";
            break;
          case 691:
            this.name = "Snow End";
            this.modelFile = "";
            break;
          case 693:
            this.name = "Nonsense picture";
            this.pointer = 33320;
            break;
          case 729:
            this.name = "X";
            this.modelFile = "";
            break;
          case 730:
            this.name = "X";
            this.modelFile = "";
            break;
          case 731:
            this.name = "Dingpot";
            this.pointer = 33072;
            break;
          case 732:
            this.name = "Gnawty's Shelves";
            this.pointer = 34960;
            break;
          case 733:
            this.name = "Gnawty's Bed";
            this.pointer = 34952;
            break;
          case 734:
            this.name = "Gnawty's House";
            this.pointer = 34848;
            break;
          case 735:
            this.name = "Lighthouse";
            this.pointer = 31880;
            break;
          case 736:
            this.name = "Stairs";
            this.pointer = 31816;
            break;
          case 737:
            this.name = "Stairs 2";
            this.pointer = 31824;
            break;
          case 738:
            this.name = "Lighthouse";
            this.modelFile2 = "20BFE0.bin";
            this.pointer = 31872;
            this.pointer2 = 31880;
            break;
          case 739:
            this.name = "Mumbo's Mountain sign";
            this.pointer = 35248;
            break;
          case 740:
            this.name = "Warp Disk";
            this.pointer = 35176;
            break;
          case 741:
            this.name = "Wooden Door";
            this.pointer = 35096;
            break;
          case 742:
            this.name = "Nabnut's Door";
            this.pointer = 34864;
            break;
          case 743:
            this.name = "Wooden Door";
            this.pointer = 34648;
            break;
          case 744:
            this.name = "Window";
            this.pointer = 33944;
            break;
          case 745:
            this.name = "Short Window";
            this.pointer = 33952;
            break;
          case 746:
            this.name = "Tall Window";
            this.pointer = 33960;
            break;
          case 749:
            this.name = "Machine Room Booth";
            this.pointer = 30872;
            break;
          case 750:
            this.name = "Klungo";
            this.pointer = 33256;
            break;
          case 751:
            this.name = "Tooty";
            this.pointer = 31088;
            break;
          case 752:
            this.name = "Machine Room Console";
            this.pointer = 30880;
            break;
          case 753:
            this.name = "Tooty's force field";
            this.pointer = 33264;
            break;
          case 754:
            this.name = "Machine Room booth";
            this.pointer = 30872;
            break;
          case 755:
            this.name = "Lightning";
            this.pointer = 33280;
            break;
          case 756:
            this.name = "Goldfish Bowl";
            this.pointer = 33288;
            break;
          case 757:
            this.name = "Cuckoo Clock";
            this.pointer = 33296;
            break;
          case 758:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 759:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 760:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 761:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 762:
            this.name = "Klungo";
            this.pointer = 33256;
            break;
          case 763:
            this.name = "Banjo";
            this.pointer = 30976;
            break;
          case 764:
            this.name = "Mumbo";
            this.pointer = 31944;
            break;
          case 765:
            this.name = "Snacker";
            this.pointer = 31768;
            break;
          case 766:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 767:
            this.name = "?";
            this.modelFile = "";
            break;
          case 768:
            this.name = "?";
            this.modelFile = "";
            break;
          case 769:
            this.name = "Blubber";
            this.pointer = 31256;
            break;
          case 770:
            this.name = "Rock";
            this.pointer = 30432;
            break;
          case 771:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 772:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 773:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 774:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 775:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 776:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 777:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 778:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 779:
            this.name = "Dead Beanstalk";
            this.pointer = 34224;
            break;
          case 780:
            this.name = "'Z' Logo";
            this.pointer = 34232;
            break;
          case 781:
            this.name = "TNT Box Part 2";
            this.pointer = 33528;
            break;
          case 782:
            this.name = "Eyrie Big";
            this.pointer = 33488;
            break;
          case 783:
            this.name = "Whip Crack";
            this.pointer = 34432;
            break;
          case 784:
            this.name = "Acorn mound";
            this.pointer = 34464;
            break;
          case 785:
            this.name = "Nabnut's Wife";
            this.pointer = 33192;
            break;
          case 786:
            this.name = "Nabnut's Bed Covers";
            this.pointer = 33200;
            break;
          case 787:
            this.name = "Nabnut's Duvet";
            this.pointer = 33208;
            break;
          case 788:
            this.name = "Nabnut 4";
            this.pointer = 34480;
            break;
          case 789:
            this.name = "Nabnut (Top Half)";
            this.pointer = 33536;
            break;
          case 794:
            this.name = "Gnawty 3";
            this.pointer = 33552;
            break;
          case 797:
            this.name = "Pyramid";
            this.pointer = 35312;
            break;
          case 798:
            this.name = "TTC Tree";
            this.pointer = 30056;
            break;
          case 818:
            this.name = "Blue Twinkly";
            this.pointer = 32984;
            break;
          case 819:
            this.name = "Green Twinkly";
            this.pointer = 32992;
            break;
          case 820:
            this.name = "Orange Twinkly";
            this.pointer = 33000;
            break;
          case 821:
            this.name = "Red Twinkly";
            this.pointer = 33008;
            break;
          case 822:
            this.name = "Twinkly Box";
            this.pointer = 32936;
            break;
          case 823:
            this.name = "Twinkly Muncher";
            this.pointer = 33608;
            break;
          case 824:
            this.name = "Christmas Tree Switch";
            this.pointer = 33480;
            break;
          case 825:
            this.name = "?";
            this.modelFile = "";
            break;
          case 826:
            this.name = "Blue Present";
            this.pointer = 33424;
            break;
          case 827:
            this.name = "Green Present";
            this.pointer = 33432;
            break;
          case 828:
            this.name = "Red Present";
            this.pointer = 33440;
            break;
          case 829:
            this.name = "Boggy on Sled 3";
            this.pointer = 31464;
            break;
          case 831:
            this.name = "Wozza 2";
            this.pointer = 33592;
            break;
          case 832:
            this.name = "Ice Tree";
            this.pointer = 34088;
            break;
          case 833:
            this.name = "?";
            this.modelFile = "";
            break;
          case 840:
            this.name = "Brentilda";
            this.pointer = 34912;
            break;
          case 845:
            this.name = "Bees";
            this.modelFile = "";
            break;
          case 846:
            this.name = "Skeleton";
            this.pointer = 34040;
            break;
          case 847:
            this.name = "Mummy";
            this.pointer = 34000;
            break;
          case 848:
            this.name = "Sea Grublin";
            this.pointer = 33664;
            break;
          case 850:
            this.name = "Grunty after first note door";
            this.modelFile = "";
            break;
          case 851:
            this.name = "Weird green ball";
            this.pointer = 32424;
            break;
          case 853:
            this.name = "Purple ice pole";
            this.pointer = 34240;
            break;
          case 854:
            this.name = "Green Ice Pole";
            this.pointer = 34256;
            break;
          case 855:
            this.name = "Big Ice Pole";
            this.pointer = 34264;
            break;
          case 856:
            this.name = "Ice Pole";
            this.pointer = 34272;
            break;
          case 861:
            this.name = "Ice Pole";
            this.pointer = 34272;
            break;
          case 862:
            this.name = "Race rostrum";
            this.pointer = 34296;
            break;
          case 863:
            this.name = "Finish banner";
            this.pointer = 34280;
            break;
          case 864:
            this.name = "Start banner";
            this.pointer = 34288;
            break;
          case 871:
            this.name = "Gruntling";
            this.pointer = 35048;
            break;
          case 872:
            this.name = "Mumbo Token Sign (5)";
            this.pointer = 30368;
            break;
          case 873:
            this.name = "Mumbo Token Sign (20)";
            this.pointer = 30392;
            break;
          case 874:
            this.name = "Mumbo Token Sign (15)";
            this.pointer = 30384;
            break;
          case 875:
            this.name = "Mumbo Token Sign (10)";
            this.pointer = 30376;
            break;
          case 876:
            this.name = "Mumbo Token Sign (25)";
            this.pointer = 30400;
            break;
          case 877:
            this.name = "Colliwobble";
            this.pointer = 34312;
            break;
          case 878:
            this.name = "Bawl";
            this.pointer = 34320;
            break;
          case 879:
            this.name = "Topper";
            this.pointer = 34304;
            break;
          case 880:
            this.name = "Gold Feather";
            this.modelFile = ".\\resources\\gold_feather.mw";
            this.pointer = 1;
            break;
          case 884:
            this.name = "????";
            this.modelFile = "";
            break;
          case 885:
            this.name = "Grublin Hood";
            this.pointer = 34808;
            break;
          case 890:
            this.name = "Bottles Mound (with Event)";
            this.pointer = 31448;
            break;
          case 893:
            this.name = "Ice Cube";
            this.pointer = 34488;
            break;
          case 894:
            this.name = "Dead Venus Flytrap";
            this.pointer = 34504;
            break;
          case 895:
            this.name = "Loggo";
            this.pointer = 34656;
            break;
          case 896:
            this.name = "Beetle";
            this.pointer = 34672;
            break;
          case 897:
            this.name = "Portrait Chompa";
            this.pointer = 34720;
            if (this.specialScript == (short) 6412)
            {
              this.name = "Portrait Chompa - Grunty";
              this.modelFile2 = "3BEB88.bin";
              this.pointer2 = 34728;
            }
            if (this.specialScript == (short) 6540)
            {
              this.name = "Portrait Chompa - Blackeye";
              this.modelFile2 = "3C1C98.bin";
              this.pointer2 = 34768;
            }
            if (this.specialScript == (short) 6668)
            {
              this.name = "Portrait Chompa - Tower";
              this.modelFile2 = "3C3FC8.bin";
              this.pointer2 = 34776;
            }
            if (this.specialScript == (short) 6796)
            {
              this.name = "Portrait Chompa - Tree";
              this.modelFile2 = "3C61E0.bin";
              this.pointer2 = 34776;
            }
            if (this.specialScript == (short) 6924)
            {
              this.name = "Portrait Chompa - Ghouls";
              this.modelFile2 = "3C8530.bin";
              this.pointer2 = 34792;
            }
            if (this.specialScript != (short) 7052)
              break;
            this.name = "Portrait Chompa - 3 Enemies";
            this.modelFile2 = "3CA730.bin";
            this.pointer2 = 34800;
            break;
          case 898:
            this.name = "Portrait Grunty";
            this.pointer = 34728;
            break;
          case 900:
            this.name = "Flame";
            this.pointer = 30824;
            break;
          case 901:
            this.name = "Portrait Blackeye";
            this.pointer = 34768;
            break;
          case 902:
            this.name = "Portrait Tower";
            this.pointer = 34776;
            break;
          case 903:
            this.name = "Portrait Tree";
            this.pointer = 34784;
            break;
          case 904:
            this.name = "Portrait Ghosts";
            this.pointer = 34792;
            break;
          case 905:
            this.name = "Fireball";
            this.pointer = 35152;
            break;
          case 906:
            this.name = "Green Blast";
            this.pointer = 35160;
            break;
          case 907:
            this.name = "Grunty";
            this.pointer = 34944;
            break;
          case 927:
            this.name = "Kazooie fly disk";
            this.pointer = 30168;
            break;
          case 928:
            this.name = "Ice Cube";
            this.pointer = 34488;
            break;
          case 929:
            this.name = "Jinjonator Stand";
            this.pointer = 35000;
            break;
          case 930:
            this.name = "Jinjo Stand";
            this.pointer = 34992;
            break;
          case 933:
            this.name = "Orange Jinjo";
            this.pointer = 31864;
            break;
          case 934:
            this.name = "Green Jinjo";
            this.pointer = 31912;
            break;
          case 935:
            this.name = "Purple Jinjo";
            this.pointer = 31904;
            break;
          case 936:
            this.name = "Yellow Jinjo";
            this.pointer = 31856;
            break;
          case 938:
            this.name = "Big Green Blast";
            this.pointer = 35160;
            break;
          case 940:
            this.name = "Jinjonator";
            this.pointer = 35104;
            break;
          case 941:
            this.name = "Rock Smash";
            this.pointer = 30440;
            break;
          case 942:
            this.name = "Boggy's Igloo";
            this.pointer = 35184;
            break;
          case 943:
            this.name = "Shadow";
            this.pointer = 34984;
            break;
          case 944:
            this.name = "House chimney";
            this.pointer = 35304;
            break;
          case 955:
            this.name = "Fireball";
            this.pointer = 35168;
            break;
          case 956:
            this.name = "Jiggy Podium";
            this.pointer = 34904;
            break;
          case 959:
            this.name = "Gruntling 2";
            this.pointer = 35232;
            break;
          case 960:
            this.name = "Gruntling 3";
            this.pointer = 35240;
            break;
          case 961:
            this.name = "Purple Tee-Hee";
            this.pointer = 35256;
            break;
          case 962:
            this.name = "RIP Tombstone";
            this.pointer = 30296;
            break;
          case 963:
            this.name = "Banjo Falling in Witch Statue";
            this.modelFile = "";
            break;
          case 964:
            this.name = "Washing machine Cauldron";
            this.pointer = 35216;
            break;
          case 965:
            this.name = "Grunty";
            this.pointer = 34944;
            break;
          case 966:
            this.name = "Furnace Fun Podium";
            this.pointer = 30968;
            break;
          case 967:
            this.name = "Grunty Doll";
            this.pointer = 35224;
            break;
          case 968:
            this.name = "Tooty";
            this.pointer = 31088;
            break;
        }
      }
      else
      {
        if ((byte) ((uint) this.specialScript & (uint) sbyte.MaxValue) == (byte) 12)
        {
          if (this.objectID == (short) 38)
          {
            this.name = "Start Climb";
            this.modelFile = ".\\resources\\climb_start.mw";
            this.pointer = 1;
            return;
          }
          if (this.objectID == (short) 39)
          {
            this.name = "End Climb Can't Go Higher";
            this.modelFile = ".\\resources\\climb_start.mw";
            this.pointer = 1;
          }
          if (this.objectID == (short) 40)
          {
            this.name = "End Climb";
            this.modelFile = ".\\resources\\climb_end.mw";
            this.pointer = 1;
          }
        }
        switch (this.objectID)
        {
          case 34:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Conga's Tree";
            this.pointer = 30000;
            break;
          case 144:
            this.name = "TTC Tree";
            this.pointer = 30056;
            break;
          case 146:
            this.name = "TTC Tree";
            this.pointer = 30056;
            break;
          case 147:
            this.name = "TTC Tree";
            this.pointer = 30056;
            break;
          case 151:
            this.name = "TTC Tree";
            this.pointer = 30056;
            break;
          case 197:
            this.name = "Chimpy's Tree Stump";
            this.pointer = 31960;
            break;
          case 224:
            this.name = "Red Feather";
            this.modelFile = ".\\resources\\red_feather.mw";
            this.pointer = 1;
            this.specialScript = (short) 0;
            break;
          case 230:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Light Crate";
            this.pointer = 30096;
            break;
          case 242:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Dark Crate";
            this.pointer = 30104;
            break;
          case 246:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Dark Crate";
            this.pointer = 30104;
            break;
          case 247:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Dark Crate";
            this.pointer = 30104;
            break;
          case 260:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Another Crate";
            this.pointer = 30112;
            break;
          case 263:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Another Crate";
            this.pointer = 30112;
            break;
          case 266:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Another Crate";
            this.pointer = 30112;
            break;
          case 299:
            this.name = "Bottles Mound (With Event SM)";
            this.pointer = 31448;
            if (this.specialScript == (short) 140)
            {
              this.name = "Bottles Mound (Start)";
              this.cameraID = 18;
            }
            if (this.specialScript == (short) 268)
            {
              this.name = "Bottles Mound (Camera)";
              this.cameraID = 41;
            }
            if (this.specialScript == (short) 396)
            {
              this.name = "Bottles Mound (Swim)";
              this.cameraID = 5;
            }
            if (this.specialScript == (short) 524)
            {
              this.name = "Bottles Mound (Claw Swipe)";
              this.cameraID = 6;
            }
            if (this.specialScript == (short) 652)
            {
              this.name = "Bottles Mound (Beak Barge)";
              this.cameraID = 8;
            }
            if (this.specialScript == (short) 780)
            {
              this.name = "Bottles Mound (Jump)";
              this.cameraID = 4;
            }
            if (this.specialScript == (short) 908)
            {
              this.name = "Bottles Mound (Climb)";
              this.cameraID = 7;
            }
            if (this.specialScript != (short) 1036)
              break;
            this.name = "Bottles Mound (Top)";
            this.cameraID = 17;
            break;
          case 515:
            this.name = "Note Door";
            this.pointer = 33568;
            if (this.specialScript == (short) 140)
              this.name += " - Door 1";
            if (this.specialScript == (short) 268)
              this.name += " - Door 2";
            if (this.specialScript == (short) 396)
              this.name += " - Door 3";
            if (this.specialScript == (short) 524)
              this.name += " - Door 4";
            if (this.specialScript == (short) 652)
              this.name += " - Door 5";
            if (this.specialScript == (short) 652)
              this.name += " - Door 6";
            if (this.specialScript == (short) 780)
              this.name += " - Door 7";
            if (this.specialScript == (short) 908)
              this.name += " - Door 8";
            if (this.specialScript == (short) 1036)
              this.name += " - Door 9";
            if (this.specialScript == (short) 1164)
              this.name += " - Door 10";
            if (this.specialScript == (short) 1292)
              this.name += " - Door 11";
            if (this.specialScript != (short) 1420)
              break;
            this.name += " - Door 12";
            break;
          case 553:
            if (this.specialScript != (short) 140)
              break;
            this.name = "House";
            this.pointer = 33968;
            break;
          case 571:
            this.name = "Cauldron";
            this.pointer = 34192;
            if (this.specialScript == (short) 652)
              this.name += " Pipe Room";
            if (this.specialScript == (short) 780)
              this.name += " CCW Area";
            if (this.specialScript == (short) 268)
              this.name += " GL Room 6";
            if (this.specialScript != (short) 524)
              break;
            this.name += " RBB Area";
            break;
          case 573:
            this.name = "Mumbo Pad";
            this.pointer = 34176;
            if (this.specialScript == (short) 652)
              this.name += " - Termite";
            if (this.specialScript == (short) 1292)
              this.name += " - Crocodile";
            if (this.specialScript == (short) 1932)
              this.name += " - Walrus";
            if (this.specialScript == (short) 2572)
              this.name += " - Pumpkin";
            if (this.specialScript != (short) 3212)
              break;
            this.name += " - Bee";
            break;
          case 606:
            if (this.specialScript == (short) 140)
            {
              this.name = "Yellow SNS Egg";
              this.pointer = 34560;
            }
            if (this.specialScript == (short) 268)
            {
              this.name = "Red SNS Egg";
              this.pointer = 34560;
            }
            if (this.specialScript == (short) 396)
            {
              this.name = "Green SNS Egg";
              this.pointer = 34560;
            }
            if (this.specialScript == (short) 524)
            {
              this.name = "Blue SNS Egg";
              this.pointer = 34560;
            }
            if (this.specialScript == (short) 652)
            {
              this.name = "Pink SNS Egg";
              this.pointer = 34560;
            }
            if (this.specialScript != (short) 780)
              break;
            this.name = "Cyan SNS Egg";
            this.pointer = 34560;
            break;
          case 738:
            this.name = "Lighthouse";
            this.modelFile2 = "20BFE0.bin";
            this.pointer = 31872;
            this.pointer2 = 31880;
            break;
          case 739:
            if (this.specialScript == (short) 140)
              this.name = "GL - MM Sign";
            if (this.specialScript == (short) 268)
              this.name = "GL - TTC Sign";
            if (this.specialScript == (short) 396)
              this.name = "GL - CC Sign";
            if (this.specialScript == (short) 524)
              this.name = "GL - BGS Sign";
            if (this.specialScript == (short) 652)
              this.name = "GL - FP Sign";
            if (this.specialScript == (short) 780)
              this.name = "GL - GV Sign";
            if (this.specialScript == (short) 908)
              this.name = "GL - MMM Sign";
            if (this.specialScript == (short) 1036)
              this.name = "GL - RBB Sign";
            if (this.specialScript == (short) 1164)
              this.name = "GL - CCW Sign";
            this.pointer = 35248;
            break;
          case 740:
            if (this.specialScript == (short) 0)
            {
              this.name = "SM Tree";
              this.pointer = 30336;
            }
            if (this.specialScript == (short) 140)
            {
              this.name = "MM Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript == (short) 268)
            {
              this.name = "TTC Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript == (short) 396)
            {
              this.name = "CC Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript == (short) 524)
            {
              this.name = "BGS Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript == (short) 652)
            {
              this.name = "GV Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript == (short) 780)
            {
              this.name = "FP Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript == (short) 908)
            {
              this.name = "MMM Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript == (short) 1036)
            {
              this.name = "RBB Start Pad";
              this.pointer = 35176;
            }
            if (this.specialScript != (short) 1164)
              break;
            this.name = "CCW Start Pad";
            this.pointer = 35176;
            break;
          case 741:
            if (this.specialScript != (short) 0)
              break;
            this.name = "SM Tree";
            this.pointer = 30352;
            break;
          case 743:
            this.name = "MM Tree";
            this.pointer = 30352;
            break;
          case 840:
            this.name = "Brentilda";
            this.pointer = 34912;
            if (this.specialScript == (short) 140)
              this.name = "Brentilda(GL 2)";
            if (this.specialScript == (short) 268)
              this.name = "Brentilda(GL 3)";
            if (this.specialScript == (short) 1292)
              this.name = "Brentilda(GL CC)";
            if (this.specialScript == (short) 908)
              this.name = "Brentilda(GL 4)";
            if (this.specialScript == (short) 396)
              this.name = "Brentilda(GL BGS)";
            if (this.specialScript == (short) 780)
              this.name = "Brentilda(GL 5)";
            if (this.specialScript == (short) 524)
              this.name = "Brentilda(GL 6)";
            if (this.specialScript == (short) 652)
              this.name = "Brentilda(GL Lava)";
            if (this.specialScript == (short) 1036)
              this.name = "Brentilda(GL CCW)";
            if (this.specialScript != (short) 1164)
              break;
            this.name = "Brentilda(GL MMM)";
            break;
          case 845:
            this.name = "Bees";
            this.modelFile = "";
            break;
          case 890:
            this.name = "Bottles Mound (With Event)";
            this.pointer = 31448;
            if (this.specialScript == (short) 1164)
            {
              this.name = "Bottles Mound (Beak Bomb)";
              this.cameraID = 15;
            }
            if (this.specialScript == (short) 1292)
            {
              this.name = "Bottles Mound (Eggs)";
              this.cameraID = 22;
            }
            if (this.specialScript == (short) 1420)
            {
              this.name = "Bottles Mound (Beak Buster)";
              this.cameraID = 23;
            }
            if (this.specialScript == (short) 1420)
              this.name = "Bottles Mound (Beak Bomb)";
            if (this.specialScript == (short) 1548)
            {
              this.name = "Bottles Mound (Talon)";
              this.cameraID = 24;
            }
            if (this.specialScript == (short) 1676)
            {
              this.name = "Bottles Mound (Spring Jump)";
              this.cameraID = 12;
            }
            if (this.specialScript == (short) 1804)
            {
              this.name = "Bottles Mound (Fly)";
              this.cameraID = 13;
            }
            if (this.specialScript == (short) 1932)
            {
              this.name = "Bottles Mound (Wonder Wing)";
              this.cameraID = 1;
            }
            if (this.specialScript == (short) 2060)
            {
              this.name = "Bottles Mound (Wading Boots)";
              this.cameraID = 16;
            }
            if (this.specialScript == (short) 2188)
            {
              this.name = "Bottles Mound (Running Shoes)";
              this.cameraID = 25;
            }
            if (this.specialScript != (short) 2316)
              break;
            this.name = "Bottles Mound (Note Door)";
            this.cameraID = 14;
            break;
          case 897:
            this.name = "Portrait Chompa";
            this.pointer = 34720;
            if (this.specialScript == (short) 6412)
            {
              this.name = "Portrait Chompa - Grunty";
              this.modelFile2 = "3BEB88.bin";
              this.pointer2 = 34728;
            }
            if (this.specialScript == (short) 6540)
            {
              this.name = "Portrait Chompa - Blackeye";
              this.modelFile2 = "3C1C98.bin";
              this.pointer2 = 34768;
            }
            if (this.specialScript == (short) 6668)
            {
              this.name = "Portrait Chompa - Tower";
              this.modelFile2 = "3C3FC8.bin";
              this.pointer2 = 34776;
            }
            if (this.specialScript == (short) 6796)
            {
              this.name = "Portrait Chompa - Tree";
              this.modelFile2 = "3C61E0.bin";
              this.pointer2 = 34776;
            }
            if (this.specialScript == (short) 6924)
            {
              this.name = "Portrait Chompa - Ghouls";
              this.modelFile2 = "3C8530.bin";
              this.pointer2 = 34792;
            }
            if (this.specialScript != (short) 7052)
              break;
            this.name = "Portrait Chompa - 3 Enemies";
            this.modelFile2 = "3CA730.bin";
            this.pointer2 = 34800;
            break;
          case 899:
            this.name = "Fire Pain";
            this.modelFile = "";
            break;
          case 951:
            if (this.specialScript == (short) 140)
              this.name = "GL - MM Jiggy Podium";
            if (this.specialScript == (short) 396)
              this.name = "GL - CC Jiggy Podium";
            if (this.specialScript == (short) 524)
              this.name = "GL - BGS Jiggy Podium";
            if (this.specialScript == (short) 652)
              this.name = "GL - FP Jiggy Podium";
            if (this.specialScript == (short) 780)
              this.name = "GL - GV Jiggy Podium";
            if (this.specialScript == (short) 908)
              this.name = "GL - MMM Jiggy Podium";
            if (this.specialScript == (short) 1036)
              this.name = "GL - RBB Jiggy Podium";
            if (this.specialScript == (short) 1164)
              this.name = "GL - CCW Jiggy Podium";
            this.pointer = 34904;
            break;
          case 956:
            if (this.specialScript != (short) 268)
              break;
            this.name = "GL - TTC Jiggy Podium";
            this.pointer = 34904;
            break;
          case 1125:
            this.name = "Blue Flowers";
            this.modelFile = ".\\resources\\blueFlowers.mw";
            this.pointer = 1;
            break;
          case 1127:
            this.name = "Blue Flowers";
            this.modelFile = ".\\resources\\blueFlowers.mw";
            this.pointer = 1;
            break;
          case 1136:
            this.name = "Yellow Red Flowers";
            this.modelFile = ".\\resources\\yellowRedFlowers.mw";
            this.pointer = 1;
            break;
          case 1280:
            this.name = "Red Flowers";
            this.modelFile = ".\\resources\\redFlowers.mw";
            this.pointer = 1;
            break;
          case 1552:
            if (this.specialScript != (short) 0)
              break;
            this.name = "BGS - Walkway";
            this.pointer = 30760;
            break;
          case 1556:
            if (this.specialScript != (short) 0)
              break;
            this.name = "BGS - Walkway";
            this.pointer = 30760;
            break;
          case 1584:
            if (this.specialScript != (short) 0)
              break;
            this.name = "GV Tree";
            this.pointer = 30776;
            break;
          case 1586:
            if (this.specialScript != (short) 0)
              break;
            this.name = "GV Tree";
            this.pointer = 30776;
            break;
          case 1588:
            if (this.specialScript != (short) 0)
              break;
            this.name = "GV Tree";
            this.pointer = 30776;
            break;
          case 1600:
            if (this.specialScript != (short) 0)
              break;
            this.name = "BGS - Pole";
            this.pointer = 30784;
            break;
          case 1602:
            if (this.specialScript != (short) 0)
              break;
            this.name = "BGS - Pole";
            this.pointer = 30784;
            break;
          case 1604:
            if (this.specialScript != (short) 0)
              break;
            this.name = "BGS - Pole";
            this.pointer = 30784;
            break;
          case 3424:
            this.name = "Orange 2D";
            this.modelFile = ".\\resources\\orange.mw";
            this.pointer = 1;
            break;
          case 5200:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Small Fire";
            this.modelFile = "";
            break;
          case 5616:
            this.name = "Gold Feather";
            this.modelFile = ".\\resources\\gold_feather.mw";
            this.pointer = 1;
            break;
          case 5696:
            this.name = "Note";
            this.modelFile = ".\\resources\\note.mw";
            this.pointer = 1;
            break;
          case 5712:
            this.name = "Blue Egg";
            this.modelFile = ".\\resources\\egg.mw";
            this.pointer = 1;
            break;
          case 5728:
            if (this.specialScript != (short) 0)
              break;
            this.name = "Fire 2D";
            this.modelFile = ".\\resources\\flame.mw";
            this.pointer = 1;
            break;
        }
      }
    }
  }
}
