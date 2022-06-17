// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.World
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tao.OpenGl;

namespace BanjoKazooieLevelEditor
{
  internal class World
  {
    private List<ObjectData[]> objectsStack = new List<ObjectData[]>();
    private List<ObjectData[]> structsStack = new List<ObjectData[]>();
    private List<CameraObject[]> camerasStack = new List<CameraObject[]>();
    private List<BKPath[]> pathsStack = new List<BKPath[]>();
    private List<string> modeStack = new List<string>();
    private List<int[]> selectedObjectsStack = new List<int[]>();
    private List<int[]> selectedStructsStack = new List<int[]>();
    private List<int[]> selectedNodesStack = new List<int[]>();
    private List<int[]> selectedSNodesStack = new List<int[]>();
    private List<int> selectedCamStack = new List<int>();
    private List<int> selectedPathStack = new List<int>();
    private int setupStackPointer;
    public int setupStackSize = 10;
    private Glu.GLUquadric wire;
    public Core core = new Core();
    public float drawDistance = 5000f;
    public bool drawCams = true;
    public bool drawObjs = true;
    public bool drawA = true;
    public bool drawB = true;
    public bool pathMode;
    public PathMode pmode = PathMode.None;
    private List<int> selectedNodes = new List<int>();
    private List<int> selectedSNodes = new List<int>();
    private int currentPath = 32;
    public bool drawLevelBoundary;
    public bool drawLevelBoundaryAlpha;
    private float[][] frustum = new float[6][];
    private short oldX;
    private short oldY;
    private short oldZ;
    private short oldS;
    private short oldR;
    private ushort oldRad;
    private string path = Application.StartupPath;
    public List<byte> camBytes = new List<byte>();
    private SetupFileReader setupFileReader = new SetupFileReader();
    public List<ObjectData> objects = new List<ObjectData>();
    public List<ObjectData> structs = new List<ObjectData>();
    public List<CameraObject> cameras = new List<CameraObject>();
    public List<BKPath> paths = new List<BKPath>();
    private List<ObjectData> everyObject = new List<ObjectData>();
    private List<ObjectData> everyStruct = new List<ObjectData>();
    private int texture = 1;
    public uint levelBoundary;
    public uint levelBoundaryAlpha;
    public uint levelDList;
    public uint levelBDList;
    public uint bkDList;
    public uint pickDList = 300000;
    public uint pickPathDList = 110000;
    public uint pickPathNodeDList = 110000;
    public uint jiggyDList = 200000;
    public uint clankerDL = 100000;
    public uint soundMapDList;
    public uint selectedDList = 200000;
    private List<short> UIDs = new List<short>();
    private List<byte> PathIDs = new List<byte>();
    public List<uint> objectsDList = new List<uint>();
    public List<uint> structsDList = new List<uint>();
    public List<uint> pathsDList = new List<uint>();
    public List<uint> cameraDList = new List<uint>();
    public List<uint> cameraPickDList = new List<uint>();
    public uint movementDL = 100001;
    private bool selList;
    public SetupFile file;
    public string dir = "";
    public float nRange = 1000f;
    public List<int> selectedObjects = new List<int>();
    public List<int> selectedStructs = new List<int>();
    public int selectedCam = -1;
    public int selectedPath = -1;
    private Hashtable GLLevelObjects = new Hashtable();
    private Hashtable MMLevelObjects = new Hashtable();
    private Hashtable TTCLevelObjects = new Hashtable();
    private Hashtable CCLevelObjects = new Hashtable();
    private Hashtable BGSLevelObjects = new Hashtable();
    private Hashtable FPLevelObjects = new Hashtable();
    private Hashtable MMMLevelObjects = new Hashtable();
    private Hashtable GVLevelObjects = new Hashtable();
    private Hashtable CCWLevelObjects = new Hashtable();
    private Hashtable RBBLevelObjects = new Hashtable();
    private Hashtable SMLevelObjects = new Hashtable();
    private Hashtable FBLevelObjects = new Hashtable();
    private Hashtable CSLevelObjects = new Hashtable();
    public List<int> usedJiggyFlags = new List<int>();
    public List<int> usedHCFlags = new List<int>();
    public List<int> usedMTFlags = new List<int>();
    public bool[] jinjos = new bool[5];

    private void reloadStack()
    {
      this.DeleteAllStructs();
      this.DeleteAllObjects();
      this.DeleteAllCameras();
      this.eraseDLs();
      this.resetPick();
      this.objects = ((IEnumerable<ObjectData>) this.objectsStack[this.setupStackPointer]).ToList<ObjectData>();
      this.structs = ((IEnumerable<ObjectData>) this.structsStack[this.setupStackPointer]).ToList<ObjectData>();
      this.cameras = ((IEnumerable<CameraObject>) this.camerasStack[this.setupStackPointer]).ToList<CameraObject>();
      this.paths = ((IEnumerable<BKPath>) this.pathsStack[this.setupStackPointer]).ToList<BKPath>();
      this.recalculateUIDs();
    }

    public void pushSetupStack(string mode)
    {
      if (this.setupStackPointer != 0)
      {
        this.objectsStack.RemoveRange(0, this.setupStackPointer);
        this.structsStack.RemoveRange(0, this.setupStackPointer);
        this.camerasStack.RemoveRange(0, this.setupStackPointer);
        this.modeStack.RemoveRange(0, this.setupStackPointer);
        this.selectedObjectsStack.RemoveRange(0, this.setupStackPointer);
        this.selectedStructsStack.RemoveRange(0, this.setupStackPointer);
        this.selectedNodesStack.RemoveRange(0, this.setupStackPointer);
        this.selectedSNodesStack.RemoveRange(0, this.setupStackPointer);
        this.selectedCamStack.RemoveRange(0, this.setupStackPointer);
        this.selectedPathStack.RemoveRange(0, this.setupStackPointer);
        this.setupStackPointer = 0;
      }
      ObjectData[] objectDataArray1 = new ObjectData[this.objects.Count<ObjectData>()];
      for (int index = 0; index < objectDataArray1.Length; ++index)
        objectDataArray1[index] = ObjectData.fullClone(this.objects[index]);
      ObjectData[] objectDataArray2 = new ObjectData[this.structs.Count<ObjectData>()];
      for (int index = 0; index < objectDataArray2.Length; ++index)
        objectDataArray2[index] = ObjectData.fullClone(this.structs[index]);
      CameraObject[] cameraObjectArray = new CameraObject[this.cameras.Count<CameraObject>()];
      for (int index = 0; index < cameraObjectArray.Length; ++index)
        cameraObjectArray[index] = CameraObject.clone(this.cameras[index]);
      BKPath[] bkPathArray = new BKPath[this.paths.Count<BKPath>()];
      for (int index = 0; index < bkPathArray.Length; ++index)
        bkPathArray[index] = BKPath.clone(this.paths[index]);
      this.objectsStack.Insert(0, objectDataArray1);
      this.structsStack.Insert(0, objectDataArray2);
      this.camerasStack.Insert(0, cameraObjectArray);
      this.pathsStack.Insert(0, bkPathArray);
      this.modeStack.Insert(0, mode);
      this.selectedObjectsStack.Insert(0, this.selectedObjects.ToArray());
      this.selectedStructsStack.Insert(0, this.selectedStructs.ToArray());
      this.selectedNodesStack.Insert(0, this.selectedNodes.ToArray());
      this.selectedSNodesStack.Insert(0, this.selectedSNodes.ToArray());
      this.selectedCamStack.Insert(0, this.selectedCam);
      this.selectedPathStack.Insert(0, this.selectedPath);
      if (this.objectsStack.Count <= this.setupStackSize)
        return;
      this.objectsStack.RemoveAt(this.objectsStack.Count - 1);
      this.structsStack.RemoveAt(this.structsStack.Count - 1);
      this.camerasStack.RemoveAt(this.camerasStack.Count - 1);
      this.modeStack.RemoveAt(this.modeStack.Count - 1);
      this.selectedObjectsStack.RemoveAt(this.selectedObjectsStack.Count - 1);
      this.selectedStructsStack.RemoveAt(this.selectedStructsStack.Count - 1);
      this.selectedNodesStack.RemoveAt(this.selectedNodesStack.Count - 1);
      this.selectedSNodesStack.RemoveAt(this.selectedSNodesStack.Count - 1);
      this.selectedCamStack.RemoveAt(this.selectedCamStack.Count - 1);
      this.selectedPathStack.RemoveAt(this.selectedPathStack.Count - 1);
    }

    public bool popSetupStack()
    {
      if (this.modeStack.Count<string>() > this.setupStackPointer + 1)
      {
        ++this.setupStackPointer;
        this.reloadStack();
        return true;
      }
      int num = (int) MessageBox.Show("No more moves to undo on stack");
      return false;
    }

    public bool forwardSetupStack(int sp)
    {
      if (this.setupStackPointer - sp >= 0)
      {
        this.setupStackPointer -= sp;
        this.reloadStack();
        return true;
      }
      int num = (int) MessageBox.Show("No more moves to redo on stack");
      return false;
    }

    public bool setStackLocation(int loc)
    {
      if (loc > this.objectsStack.Count - 1 || loc < 0)
        return false;
      this.setupStackPointer = loc;
      this.reloadStack();
      return true;
    }

    public void resetStack()
    {
      this.objectsStack.Clear();
      this.structsStack.Clear();
      this.camerasStack.Clear();
      this.pathsStack.Clear();
      this.modeStack.Clear();
      this.selectedObjectsStack.Clear();
      this.selectedStructsStack.Clear();
      this.selectedNodesStack.Clear();
      this.selectedSNodesStack.Clear();
      this.selectedCamStack.Clear();
      this.selectedPathStack.Clear();
      this.setupStackPointer = 0;
    }

    public List<string> getHistoryStack() => this.modeStack;

    public void FillObjectDetails(ref ObjectData o)
    {
      o.pointer = 0;
      o.pointer2 = 0;
      o.modelFile = "";
      o.modelFile2 = "";
      o.jiggyID = -1;
      o.cameraID = -1;
      o.name = "";
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
      else if (o.specialScript == (short) 20358)
      {
        o.name = "warp";
        o.modelFile = ".\\resources\\warp.mw";
        o.pointer = 1;
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

    private void readObjectsXML()
    {
      BBXML.readObjectsXML(ref this.everyObject, ref this.everyStruct);
      this.setupFileReader.everyObject = this.everyObject;
      this.setupFileReader.everyStruct = this.everyStruct;
    }

    public void DrawLevelBoundary()
    {
      if (this.file == null)
        return;
      this.levelBoundary = (uint) GL.GenLists(1);
      GL.NewList(this.levelBoundary, ListMode.Compile);
      if (this.file.modelAPointer != 0)
      {
        GL.Color3(0.0f, 0.0f, 0.0f);
        this.core.DrawModelBoundary(this.file.bounds, true);
      }
      GL.EndList();
      this.levelBoundaryAlpha = (uint) GL.GenLists(1);
      GL.NewList(this.levelBoundaryAlpha, ListMode.Compile);
      if (this.file.modelBPointer != 0)
      {
        GL.Color3(1f, 1f, 1f);
        this.core.DrawModelBoundary(this.file.boundsA, true);
      }
      GL.EndList();
    }

    public ObjectData getObject(string name)
    {
      ObjectData objectData = new ObjectData((short) 0, 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0);
      for (int index = 0; index < this.everyObject.Count; ++index)
      {
        if (this.everyObject[index].name == name)
          return ObjectData.clone(this.everyObject[index]);
      }
      return objectData;
    }

    public ObjectData getStruct(string name)
    {
      ObjectData objectData = new ObjectData((short) 0, 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0);
      for (int index = 0; index < this.everyStruct.Count; ++index)
      {
        if (this.everyStruct[index].name == name)
          objectData = ObjectData.clone(this.everyStruct[index]);
      }
      return objectData;
    }

    public void ActivatePathMode()
    {
      this.pathMode = true;
      this.pmode = PathMode.None;
      this.RenderPaths();
    }

    public void DeactivatePathMode()
    {
      this.pathMode = false;
      this.pmode = PathMode.None;
    }

    public bool createNewPath(ObjectData node)
    {
      short newUid = this.getNewUID();
      if (newUid == (short) 0)
        return false;
      node.obj16 = (byte) ((uint) newUid >> 8);
      node.obj17 = (byte) newUid;
      node.obj18 = (byte) 0;
      node.uid = newUid;
      this.paths.Add(new BKPath() { nodes = { node } });
      this.RenderPaths();
      this.renderPathPicking();
      this.selectedPath = this.paths.Count - 1;
      return true;
    }

    public short getNewUID()
    {
      this.UIDs.Sort();
      short newUid1 = 768;
      if (this.UIDs.Count == 0)
      {
        short newUid2 = 768;
        this.UIDs.Add(newUid2);
        return newUid2;
      }
      int num;
      for (int index = 0; index < this.UIDs.Count; index = num + 1)
      {
        if (newUid1 > (short) 4080)
          return 0;
        if (this.UIDs.Contains(newUid1))
        {
          num = this.UIDs.IndexOf(newUid1);
          newUid1 += (short) 16;
        }
        else
          break;
      }
      this.UIDs.Add(newUid1);
      return newUid1;
    }

    public byte getNewPathID()
    {
      for (int index = 0; index < this.paths[this.selectedPath].nodes.Count; ++index)
      {
        if (this.paths[this.selectedPath].nodes[index].type == ObjectType.SPath)
          return this.paths[this.selectedPath].nodes[index].pathID;
      }
      this.PathIDs.Sort();
      byte newPathId1 = 1;
      if (this.PathIDs.Count == 0)
      {
        this.PathIDs.Add(newPathId1);
        return newPathId1;
      }
      byte newPathId2;
      for (newPathId2 = (byte) 1; (int) newPathId2 < this.PathIDs.Count; ++newPathId2)
      {
        if (newPathId2 > (byte) 254)
          return 0;
        if (!this.PathIDs.Contains(newPathId2))
          break;
      }
      this.PathIDs.Add(newPathId2);
      return newPathId2;
    }

    public bool addNode(ObjectData node)
    {
      short newUid = this.getNewUID();
      if (newUid == (short) 0)
        return false;
      node.obj16 = (byte) ((uint) newUid >> 8);
      node.obj17 = (byte) newUid;
      try
      {
        if (node.type == ObjectType.SPath)
        {
          byte newPathId = this.getNewPathID();
          node.setPathID(newPathId);
          node.locX = this.paths[this.selectedPath].nodes[0].locX;
          node.locY = this.paths[this.selectedPath].nodes[0].locY;
          node.locZ = this.paths[this.selectedPath].nodes[0].locZ;
          node.nodeOutUID = this.paths[this.selectedPath].nodes[0].nodeOutUID;
          node.obj18 = this.paths[this.selectedPath].nodes[0].obj18;
          this.paths[this.selectedPath].nodes[0].obj18 = (byte) ((uint) newUid / 16U);
          this.paths[this.selectedPath].nodes[0].nodeOutUID = newUid;
          this.paths[this.selectedPath].nodes[0].node_out = true;
          node.node_in = true;
          node.node_out = true;
        }
        else
        {
          for (int index = this.paths[this.selectedPath].nodes.Count - 1; index > -1; ++index)
          {
            if (this.paths[this.selectedPath].nodes[index].type == ObjectType.Path)
            {
              this.paths[this.selectedPath].nodes[index].obj18 = (byte) ((uint) newUid / 16U);
              this.paths[this.selectedPath].nodes[index].nodeOutUID = newUid;
              this.paths[this.selectedPath].nodes[index].node_out = true;
              node.node_in = true;
              break;
            }
          }
        }
      }
      catch
      {
      }
      node.uid = newUid;
      this.paths[this.selectedPath].nodes.Add(node);
      this.redrawSelectedPath();
      return true;
    }

    public void addSNode()
    {
      ObjectData objectData = new ObjectData(0.0f, 0, 0, 0, (byte) 0, (byte) 0, (byte) 0, (byte) 0, true, 0);
      short newUid = this.getNewUID();
      objectData.obj16 = (byte) ((uint) newUid >> 8);
      objectData.obj17 = (byte) newUid;
      objectData.uid = newUid;
      this.paths[this.selectedPath].nodes.Add(objectData);
      this.redrawSelectedPath();
    }

    public void updateSNode(
      short to,
      float actPercent,
      int w1,
      bool usePause,
      bool useSpeed,
      bool useAnimation,
      byte pathID,
      int speed,
      int pauseTime,
      int unk3)
    {
      for (int index = 0; index < this.selectedSNodes.Count; ++index)
      {
        foreach (ObjectData node in this.paths[this.selectedPath].nodes)
        {
          if ((int) node.nodeOutUID == (int) to)
          {
            node.nodeOutUID = (short) 0;
            node.obj18 = (byte) 0;
            node.node_out = false;
          }
        }
        int selectedSnode = this.selectedSNodes[index];
        if (to != (short) 0)
          this.paths[this.selectedPath].nodes[selectedSnode].node_out = true;
        this.paths[this.selectedPath].nodes[selectedSnode].nodeOutUID = to;
        this.paths[this.selectedPath].nodes[selectedSnode].obj18 = (byte) ((uint) to / 16U);
        this.paths[this.selectedPath].nodes[selectedSnode].activationPercent = actPercent;
        this.paths[this.selectedPath].nodes[selectedSnode].pw1 = w1;
        this.paths[this.selectedPath].nodes[selectedSnode].setPathID(pathID);
        this.paths[this.selectedPath].nodes[selectedSnode].setControlFlags(usePause, useSpeed, useAnimation);
        this.paths[this.selectedPath].nodes[selectedSnode].setSpeed(speed);
        this.paths[this.selectedPath].nodes[selectedSnode].setPauseTime(pauseTime);
        this.paths[this.selectedPath].nodes[selectedSnode].setUNK3(unk3);
      }
      this.redrawSelectedPath();
    }

    public void updateNodeLocation(
      short x,
      short y,
      short z,
      bool ux,
      bool uy,
      bool uz,
      short yOffset)
    {
      try
      {
        short[] forSelectedObjects = this.getCenterPointForSelectedObjects(x, y, z, Mode.Path);
        for (int index = 0; index < this.selectedSNodes.Count; ++index)
        {
          int selectedSnode = this.selectedSNodes[index];
          if (ux)
            this.paths[this.selectedPath].nodes[selectedSnode].locX += forSelectedObjects[0];
          if (uy)
            this.paths[this.selectedPath].nodes[selectedSnode].locY += (short) ((int) forSelectedObjects[1] + (int) yOffset);
          if (uz)
            this.paths[this.selectedPath].nodes[selectedSnode].locZ += forSelectedObjects[2];
        }
        for (int index = 0; index < this.selectedNodes.Count; ++index)
        {
          int selectedNode = this.selectedNodes[index];
          if (ux)
            this.paths[this.selectedPath].nodes[selectedNode].locX += forSelectedObjects[0];
          if (uy)
            this.paths[this.selectedPath].nodes[selectedNode].locY += (short) ((int) forSelectedObjects[1] + (int) yOffset);
          if (uz)
            this.paths[this.selectedPath].nodes[selectedNode].locZ += forSelectedObjects[2];
        }
      }
      catch
      {
      }
    }

    public void updateNode(short to, short x, short y, short z)
    {
      try
      {
        int selectedNode = this.getSelectedNode();
        if (selectedNode == -1)
          return;
        foreach (ObjectData node in this.paths[this.selectedPath].nodes)
        {
          if ((int) node.nodeOutUID == (int) to)
          {
            node.nodeOutUID = (short) 0;
            node.obj18 = (byte) 0;
            node.node_out = false;
          }
        }
        this.paths[this.selectedPath].nodes[selectedNode].nodeOutUID = to;
        this.paths[this.selectedPath].nodes[selectedNode].obj18 = (byte) ((uint) to / 16U);
        if (to != (short) 0)
          this.paths[this.selectedPath].nodes[selectedNode].node_out = true;
        this.paths[this.selectedPath].nodes[selectedNode].locX = x;
        this.paths[this.selectedPath].nodes[selectedNode].locY = y;
        this.paths[this.selectedPath].nodes[selectedNode].locZ = z;
      }
      catch
      {
      }
    }

    public ObjectType getSelectedNodeType()
    {
      if (this.selectedPath == -1)
        return ObjectType.Path;
      if (this.selectedSNodes.Count<int>() == 1)
        return ObjectType.SPath;
      this.selectedNodes.Count<int>();
      return ObjectType.Path;
    }

    public int getSelectedNode()
    {
      int selectedNode = -1;
      if (this.selectedNodes.Count<int>() == 1)
        selectedNode = this.selectedNodes[0];
      if (this.selectedSNodes.Count<int>() == 1)
        selectedNode = this.selectedSNodes[0];
      return selectedNode;
    }

    public bool hasSelectedCamera() => this.selectedCam != -1;

    public CameraObject getSelectedCamera() => this.selectedCam != -1 ? this.cameras[this.selectedCam] : throw new Exception("No camera selected");

    public bool hasSelectedNodes() => this.selectedNodes.Count > 0 || this.selectedSNodes.Count > 0;

    public bool singleNodeSelected()
    {
      if (this.selectedNodes.Count == 1 && this.selectedSNodes.Count == 0)
        return true;
      return this.selectedNodes.Count == 0 && this.selectedSNodes.Count == 1;
    }

    public void selectNode(int id)
    {
      this.selectedSNodes.Clear();
      this.selectedNodes.Clear();
      if (this.selectedPath == -1 || this.paths[this.selectedPath].nodes.Count <= id)
        return;
      if (this.paths[this.selectedPath].nodes[id].type == ObjectType.SPath)
        this.selectedSNodes.Add(id);
      else
        this.selectedNodes.Add(id);
    }

    private void recalculateUIDs()
    {
      this.UIDs.Clear();
      this.PathIDs.Clear();
      for (int index = 0; index < this.objects.Count; ++index)
        this.UIDs.Add(this.objects[index].uid);
      for (int index1 = 0; index1 < this.paths.Count; ++index1)
      {
        for (int index2 = 0; index2 < this.paths[index1].nodes.Count; ++index2)
        {
          this.UIDs.Add(this.paths[index1].nodes[index2].uid);
          if (!this.PathIDs.Contains(this.paths[index1].nodes[index2].pathID))
            this.PathIDs.Add(this.paths[index1].nodes[index2].pathID);
        }
      }
    }

    private void ClearNodeIn(ObjectData node)
    {
      if (this.selectedPath == -1)
        return;
      foreach (ObjectData node1 in this.paths[this.selectedPath].nodes)
      {
        if ((int) node.nodeOutUID == (int) node1.uid)
          node1.node_in = false;
        else if ((int) node.uid == (int) node1.nodeOutUID)
        {
          node1.nodeOutUID = (short) 0;
          node1.node_out = false;
        }
      }
    }

    public void removeNode()
    {
      if (this.selectedPath == -1)
        return;
      if (this.selectedNodes.Count > 0)
      {
        this.selectedNodes.Sort();
        this.selectedNodes.Reverse();
        for (int index = 0; index < this.selectedNodes.Count; ++index)
        {
          this.ClearNodeIn(this.paths[this.selectedPath].nodes[this.selectedNodes[index]]);
          this.paths[this.selectedPath].nodes.RemoveAt(this.selectedNodes[index]);
        }
      }
      if (this.selectedSNodes.Count > 0)
      {
        for (int index = 0; index < this.selectedSNodes.Count; ++index)
        {
          this.ClearNodeIn(this.paths[this.selectedPath].nodes[this.selectedSNodes[index]]);
          this.paths[this.selectedPath].nodes.RemoveAt(this.selectedSNodes[index]);
        }
      }
      GL.DeleteLists(this.pathsDList[this.selectedPath], 1);
      uint list = (uint) GL.GenLists(1);
      GL.NewList(list, ListMode.Compile);
      this.DrawPath(this.paths[this.selectedPath], false);
      GL.EndList();
      this.pathsDList[this.selectedPath] = list;
      this.recalculateUIDs();
      this.clearSelectedNodes();
      this.renderPathPicking();
    }

    public void removePath()
    {
      if (this.selectedPath == -1)
        return;
      this.paths.RemoveAt(this.selectedPath);
      GL.DeleteLists(this.pathsDList[this.selectedPath], 1);
      this.recalculateUIDs();
      this.resetPick();
      this.renderPathPicking();
      this.RenderPaths();
    }

    public void setAnimationOnNode(int offset)
    {
      if (this.selectedSNodes.Count != 1)
        return;
      this.paths[this.selectedPath].nodes[this.selectedSNodes[0]].pw2 = (offset << 5 << 16) + 5895;
      this.paths[this.selectedPath].nodes[this.selectedSNodes[0]].animation = offset;
    }

    private void CreateJiggyDL()
    {
      ObjectData objectData = new ObjectData((short) 70, 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 0, (short) 6412);
      objectData.pointer = 31120;
      this.jiggyDList = (uint) GL.GenLists(1);
      GL.NewList(this.jiggyDList, ListMode.Compile);
      this.DrawObject(objectData, 100f, true, false);
      GL.EndList();
    }

    private void checkSize(ref float s, ObjectData obj)
    {
      if (obj.pointer == 0)
        s = 1f;
      if (obj.objectID == (short) 1 || obj.objectID == (short) 45 || obj.objectID == (short) 81 || obj.objectID == (short) 82 || obj.objectID == (short) 5696 || obj.objectID == (short) 5712 || obj.objectID == (short) 5728 || obj.name == "Magic Boundary" || obj.name == "Note" || obj.name.Contains("Entry Point") || obj.name == "warp" || obj.name == "Warp To - Start of Level" || obj.objectID == (short) 204 || obj.objectID == (short) 389 || obj.objectID == (short) 395 || obj.objectID == (short) 405 || obj.objectID == (short) 414 || obj.objectID == (short) 297 || obj.objectID == (short) 224 || obj.objectID == (short) 511 || obj.objectID == (short) 512 || obj.objectID == (short) 880 || obj.objectID == (short) 73)
        s = 1f;
      if (obj.specialScript != (short) 0 || obj.objectID != (short) 3424 && obj.objectID != (short) 1125 && obj.objectID != (short) 1127 && obj.objectID != (short) 1136 && obj.objectID != (short) 1280 && obj.objectID != (short) 5696 && obj.objectID != (short) 5616 && obj.objectID != (short) 224 && obj.objectID != (short) 5712 && obj.objectID != (short) 5728)
        return;
      s = 1f;
    }

    public void clearSelectedNodes()
    {
      this.selectedNodes.Clear();
      this.selectedSNodes.Clear();
    }

    public void resetPick()
    {
      this.selectedObjects.Clear();
      this.selectedStructs.Clear();
      this.selectedPath = -1;
      this.selectedNodes.Clear();
      this.selectedSNodes.Clear();
      this.selectedCam = -1;
      this.selList = false;
    }

    public int getCamType() => this.selectedCam == -1 ? -1 : this.cameras[this.selectedCam].type;

    public void BKCameraToBBCamera(GLCamera BBCam)
    {
      if (this.selectedCam == -1)
        return;
      CameraObject camera = this.cameras[this.selectedCam];
      camera.x = -BBCam.X;
      camera.y = -BBCam.Y;
      camera.z = -BBCam.Z;
      camera.yaw = -(double) BBCam.GetYRotation() < 0.0 ? (float) (360.0 + -(double) BBCam.GetYRotation()) : -BBCam.GetYRotation();
      camera.pitch = -(double) BBCam.GetXRotation() < 0.0 ? (float) (360.0 + -(double) BBCam.GetXRotation()) : -BBCam.GetXRotation();
      camera.roll = 0.0f;
    }

    public void BBCameraToBKCamera(GLCamera BBCam)
    {
      if (this.selectedCam == -1)
        return;
      CameraObject camera = this.cameras[this.selectedCam];
      BBCam.X = -camera.x;
      BBCam.Y = -camera.y;
      BBCam.Z = -camera.z;
      BBCam.Yaw = -camera.yaw;
      BBCam.Pitch = -camera.pitch;
      BBCam.Roll = 0.0f;
    }

    public void updateCameraLocation(float x, float y, float z, bool ux, bool uy, bool uz)
    {
      if (this.selectedCam == -1)
        return;
      if (ux)
        this.cameras[this.selectedCam].x = x;
      if (uy)
        this.cameras[this.selectedCam].y = y;
      if (!uz)
        return;
      this.cameras[this.selectedCam].z = z;
    }

    public void updateCameraYaw(float yaw)
    {
      if (this.selectedCam == -1)
        return;
      this.cameras[this.selectedCam].yaw += (float) (short) yaw;
      if ((double) this.cameras[this.selectedCam].yaw < 0.0)
        this.cameras[this.selectedCam].yaw = 360f;
      if ((double) this.cameras[this.selectedCam].yaw <= 360.0)
        return;
      this.cameras[this.selectedCam].yaw = 0.0f;
    }

    public void updateCameraPitch(float pitch)
    {
      if (this.selectedCam == -1)
        return;
      this.cameras[this.selectedCam].pitch += (float) (short) pitch;
      if ((double) this.cameras[this.selectedCam].pitch < 0.0)
        this.cameras[this.selectedCam].pitch = 360f;
      if ((double) this.cameras[this.selectedCam].pitch <= 360.0)
        return;
      this.cameras[this.selectedCam].pitch = 0.0f;
    }

    public void updateCameraRoll(float roll)
    {
      if (this.selectedCam == -1)
        return;
      this.cameras[this.selectedCam].roll += (float) (short) roll;
      if ((double) this.cameras[this.selectedCam].roll < 0.0)
        this.cameras[this.selectedCam].roll = 360f;
      if ((double) this.cameras[this.selectedCam].roll <= 360.0)
        return;
      this.cameras[this.selectedCam].roll = 0.0f;
    }

    public void updateObject(
      short id,
      short ss,
      short flag,
      ushort radius,
      short x,
      short y,
      short z,
      short size,
      short rot,
      byte b10,
      byte b11,
      byte b13,
      byte b18,
      byte b16,
      byte b17)
    {
      ObjectData objectData = this.selectedObjects.Count > 0 ? this.objects[this.selectedObjects[0]] : this.structs[this.selectedStructs[0]];
      objectData.objectID = id;
      objectData.specialScript = ss;
      objectData.flag = (int) flag;
      objectData.radius = radius;
      objectData.locX = x;
      objectData.locY = y;
      objectData.locZ = z;
      objectData.size = size;
      objectData.rot = rot;
      objectData.obj10 = b10;
      objectData.obj11 = b11;
      objectData.obj13 = b13;
      objectData.obj18 = b18;
      objectData.obj16 = b16;
      objectData.obj17 = b17;
    }

    public void updateObjectID(short id)
    {
      if (!this.hasSelectedObjects())
        return;
      ObjectData o = this.selectedObjects.Count > 0 ? this.objects[this.selectedObjects[0]] : this.structs[this.selectedStructs[0]];
      if (o.type == ObjectType.Flag)
      {
        short num = 0;
        if (o.name.Contains("Jiggy"))
          num = (short) 70;
        if (o.name.Contains("Empty Honeycomb"))
          num = (short) 71;
        if (o.name.Contains("Mumbo Token"))
          num = (short) 45;
        if (num != (short) 0)
        {
          foreach (ObjectData objectData in this.objects)
          {
            if ((int) objectData.objectID == (int) num && objectData.flag == (int) o.objectID)
            {
              objectData.flag = (int) id;
              break;
            }
          }
        }
      }
      o.objectID = id;
      if (o.type != ObjectType.Normal)
        return;
      this.FillObjectDetails(ref o);
    }

    public void updateObjectScript(short s)
    {
      if (!this.hasSelectedObjects())
        return;
      ObjectData o = this.selectedObjects.Count > 0 ? this.objects[this.selectedObjects[0]] : this.structs[this.selectedStructs[0]];
      o.specialScript = s;
      this.FillObjectDetails(ref o);
    }

    public void updateCamera(
      short id,
      float x,
      float y,
      float z,
      float yaw,
      float pitch,
      float roll)
    {
      CameraObject camera = this.cameras[this.selectedCam];
      camera.id = id;
      camera.x = x;
      camera.y = y;
      camera.z = z;
      camera.yaw = yaw;
      camera.pitch = pitch;
      camera.roll = roll;
    }

    public void updateCamera3(
      short id,
      float x,
      float y,
      float z,
      float yaw,
      float pitch,
      float roll,
      float hs,
      float vs,
      float r,
      float accel,
      int a5,
      float cd,
      float fd)
    {
      CameraObject camera = this.cameras[this.selectedCam];
      camera.id = id;
      camera.x = x;
      camera.y = y;
      camera.z = z;
      camera.yaw3 = yaw;
      camera.pitch3 = pitch;
      camera.roll3 = roll;
      camera.Type3Arg5 = a5;
      camera.camCDist = cd;
      camera.camFDist = fd;
      camera.camHSpeed = hs;
      camera.camVSpeed = vs;
      camera.camRotation = r;
      camera.camAccel = accel;
    }

    public void updateCamera1(
      short id,
      float x,
      float y,
      float z,
      float yaw,
      float pitch,
      float roll,
      float hs,
      float vs,
      float r,
      float accel,
      int a5)
    {
      CameraObject camera = this.cameras[this.selectedCam];
      camera.id = id;
      camera.x = x;
      camera.y = y;
      camera.z = z;
      camera.yaw3 = yaw;
      camera.pitch3 = pitch;
      camera.roll3 = roll;
      camera.Type3Arg5 = a5;
      camera.camHSpeed = hs;
      camera.camVSpeed = vs;
      camera.camRotation = r;
      camera.camAccel = accel;
    }

    public bool isObject() => this.selectedObjects.Count > 0;

    public void setSelectedObj(int sid, int objType_)
    {
      if (objType_ == 0)
        this.selectedObjects.Add(sid);
      else
        this.selectedStructs.Add(sid);
    }

    public void setNodeAsEndNode()
    {
      if (this.selectedPath == -1)
        return;
      int index = -1;
      if (this.selectedSNodes.Count == 1)
        index = this.selectedSNodes[0];
      if (this.selectedNodes.Count == 1)
        index = this.selectedNodes[0];
      if (index == -1)
        return;
      this.paths[this.selectedPath].nodes[index].nodeOutUID = (short) 0;
      this.paths[this.selectedPath].nodes[index].obj18 = (byte) 0;
    }

    public bool hasSelectedObjects() => this.selectedObjects.Count > 0 || this.selectedStructs.Count > 0;

    public bool singleObjectSelected()
    {
      if (!this.hasSelectedObjects())
        return false;
      if (this.selectedObjects.Count == 1 && this.selectedStructs.Count == 0)
        return true;
      return this.selectedObjects.Count == 0 && this.selectedStructs.Count == 1;
    }

    public ObjectData getSelectedObject() => this.selectedObjects.Count <= 0 ? this.structs[this.selectedStructs[0]] : this.objects[this.selectedObjects[0]];

    public World()
    {
      this.readObjectsXML();
      for (int index = 0; index < this.frustum.Length; ++index)
        this.frustum[index] = new float[4];
    }

    public void getRomStats(List<byte> F9CAE0)
    {
      try
      {
        GECompression geCompression = new GECompression();
        for (int index = 33412; index < 34451; index += 8)
        {
          int num1 = (int) F9CAE0[index + 4] * 256 + (int) F9CAE0[index + 5];
          int num2 = (int) F9CAE0[index + 6] * 256 + (int) F9CAE0[index + 7];
          int num3 = 38776 + num1 * 8;
          ArrayList arrayList = this.setupFileReader.ReadSetupFile(RomHandler.DecompressFileToByteArray(num3));
          if (num2 == 1)
          {
            this.MMLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.MMLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 2)
          {
            this.TTCLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.TTCLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 3)
          {
            this.CCLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.CCLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 4)
          {
            this.BGSLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.BGSLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 5)
          {
            this.FPLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.FPLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 6)
          {
            this.GLLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.GLLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 7)
          {
            this.GVLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.GVLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 8)
          {
            this.CCWLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.CCWLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 9)
          {
            this.RBBLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.RBBLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 10)
          {
            this.MMMLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.MMMLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 11)
          {
            this.SMLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.SMLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 12)
          {
            this.FBLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.FBLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
          if (num2 == 13)
          {
            this.CSLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[0]);
            this.CSLevelObjects.Add((object) num3, (object) (List<ObjectData>) arrayList[1]);
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    public LevelStat getLevelStats(int levelID, int setup)
    {
      this.usedHCFlags.Clear();
      this.usedJiggyFlags.Clear();
      this.usedMTFlags.Clear();
      List<ObjectData> objectDataList = new List<ObjectData>();
      objectDataList.AddRange((IEnumerable<ObjectData>) this.objects);
      objectDataList.AddRange((IEnumerable<ObjectData>) this.structs);
      this.jinjos[0] = false;
      this.jinjos[1] = false;
      this.jinjos[2] = false;
      this.jinjos[3] = false;
      this.jinjos[4] = false;
      if (levelID == 1)
      {
        foreach (DictionaryEntry mmLevelObject in this.MMLevelObjects)
        {
          if ((int) mmLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) mmLevelObject.Value);
        }
      }
      if (levelID == 2)
      {
        foreach (DictionaryEntry ttcLevelObject in this.TTCLevelObjects)
        {
          if ((int) ttcLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) ttcLevelObject.Value);
        }
      }
      if (levelID == 3)
      {
        foreach (DictionaryEntry ccLevelObject in this.CCLevelObjects)
        {
          if ((int) ccLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) ccLevelObject.Value);
        }
      }
      if (levelID == 4)
      {
        foreach (DictionaryEntry bgsLevelObject in this.BGSLevelObjects)
        {
          if ((int) bgsLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) bgsLevelObject.Value);
        }
      }
      if (levelID == 5)
      {
        foreach (DictionaryEntry fpLevelObject in this.FPLevelObjects)
        {
          if ((int) fpLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) fpLevelObject.Value);
        }
      }
      if (levelID == 6)
      {
        foreach (DictionaryEntry glLevelObject in this.GLLevelObjects)
        {
          if ((int) glLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) glLevelObject.Value);
        }
      }
      if (levelID == 7)
      {
        foreach (DictionaryEntry gvLevelObject in this.GVLevelObjects)
        {
          if ((int) gvLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) gvLevelObject.Value);
        }
      }
      if (levelID == 8)
      {
        foreach (DictionaryEntry ccwLevelObject in this.CCWLevelObjects)
        {
          if ((int) ccwLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) ccwLevelObject.Value);
        }
      }
      if (levelID == 9)
      {
        foreach (DictionaryEntry rbbLevelObject in this.RBBLevelObjects)
        {
          if ((int) rbbLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) rbbLevelObject.Value);
        }
      }
      if (levelID == 10)
      {
        foreach (DictionaryEntry mmmLevelObject in this.MMMLevelObjects)
        {
          if ((int) mmmLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) mmmLevelObject.Value);
        }
      }
      if (levelID == 11)
      {
        foreach (DictionaryEntry smLevelObject in this.SMLevelObjects)
        {
          if ((int) smLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) smLevelObject.Value);
        }
      }
      if (levelID == 12)
      {
        foreach (DictionaryEntry fbLevelObject in this.FBLevelObjects)
        {
          if ((int) fbLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) fbLevelObject.Value);
        }
      }
      if (levelID == 13)
      {
        foreach (DictionaryEntry csLevelObject in this.CSLevelObjects)
        {
          if ((int) csLevelObject.Key != setup)
            objectDataList.AddRange((IEnumerable<ObjectData>) csLevelObject.Value);
        }
      }
      int note_ = 0;
      int egg_ = 0;
      int red_ = 0;
      int gold_ = 0;
      int mumbo_ = 0;
      int jiggy_ = 0;
      int eh_ = 0;
      for (int index = 0; index < objectDataList.Count; ++index)
      {
        if (objectDataList[index].name == "Jiggy" || objectDataList[index].hasJiggy)
          ++jiggy_;
        if (objectDataList[index].name == "Mumbo Token")
          ++mumbo_;
        if (objectDataList[index].name == "Empty Honeycomb")
          ++eh_;
        if (objectDataList[index].name == "Note")
          ++note_;
        if (objectDataList[index].name == "Blue Egg")
          ++egg_;
        if (objectDataList[index].name == "Red Feather")
          ++red_;
        if (objectDataList[index].name == "Gold Feather")
          ++gold_;
        if (objectDataList[index].name == "Blue Jinjo")
          this.jinjos[0] = true;
        if (objectDataList[index].name == "Green Jinjo")
          this.jinjos[1] = true;
        if (objectDataList[index].name == "Orange Jinjo")
          this.jinjos[2] = true;
        if (objectDataList[index].name == "Purple Jinjo")
          this.jinjos[3] = true;
        if (objectDataList[index].name == "Yellow Jinjo")
          this.jinjos[4] = true;
      }
      if (this.jinjos[0] && this.jinjos[1] && this.jinjos[2] && this.jinjos[3] && this.jinjos[4])
        ++jiggy_;
      this.PairObjectsWithFlags();
      return new LevelStat(note_, egg_, red_, gold_, mumbo_, jiggy_, eh_);
    }

    private void PairObjectsWithFlags()
    {
      this.usedHCFlags.Clear();
      this.usedJiggyFlags.Clear();
      this.usedMTFlags.Clear();
      List<int> intList = new List<int>();
      foreach (ObjectData objectData in this.objects)
        objectData.flag = -1;
      using (List<ObjectData>.Enumerator enumerator = this.objects.GetEnumerator())
      {
label_17:
        while (enumerator.MoveNext())
        {
          ObjectData current = enumerator.Current;
          if (current.type == ObjectType.Flag)
          {
            bool flag = false;
            int index = 0;
            while (true)
            {
              if (index < this.objects.Count && !flag)
              {
                if ((this.objects[index].objectID == (short) 70 || this.objects[index].objectID == (short) 45 || this.objects[index].objectID == (short) 71) && !intList.Contains(index))
                {
                  ushort radius = current.radius;
                  if ((int) this.objects[index].locX < (int) current.locX + (int) radius && (int) this.objects[index].locX > (int) current.locX - (int) radius && (int) this.objects[index].locY < (int) current.locY + (int) radius && (int) this.objects[index].locY > (int) current.locY - (int) radius && (int) this.objects[index].locZ < (int) current.locZ + (int) radius && (int) this.objects[index].locZ > (int) current.locZ - (int) radius)
                  {
                    intList.Add(index);
                    this.objects[index].flag = (int) current.objectID;
                    flag = true;
                    switch (this.objects[index].objectID)
                    {
                      case 45:
                        this.usedMTFlags.Add((int) current.objectID);
                        current.name = "Mumbo Token Flag";
                        break;
                      case 70:
                        this.usedJiggyFlags.Add((int) current.objectID);
                        current.name = "Jiggy Flag";
                        break;
                      case 71:
                        this.usedHCFlags.Add((int) current.objectID);
                        current.name = "Empty Honeycomb Flag";
                        break;
                    }
                  }
                }
                ++index;
              }
              else
                goto label_17;
            }
          }
        }
      }
    }

    private void getDistance(float[] a, float[] b) => Math.Sqrt(Math.Pow((double) a[0] - (double) b[0], 2.0) + Math.Pow((double) a[1] - (double) b[1], 2.0) + Math.Pow((double) a[2] - (double) b[2], 2.0));

    public string getCameraDesc(int cid)
    {
      string cameraDesc = "";
      foreach (ObjectData objectData in this.objects)
      {
        if (objectData.cameraID == cid)
          cameraDesc = objectData.name;
      }
      return cameraDesc;
    }

    public void eraseDLs()
    {
      try
      {
        GL.DeleteLists(this.levelDList, 1);
      }
      catch (Exception ex)
      {
      }
      try
      {
        GL.DeleteLists(this.levelBDList, 1);
      }
      catch
      {
      }
      try
      {
        GL.DeleteLists(this.objectsDList[0], this.objectsDList.Count);
      }
      catch
      {
      }
      try
      {
        GL.DeleteLists(this.structsDList[0], this.structsDList.Count);
      }
      catch
      {
      }
      try
      {
        GL.DeleteLists(this.cameraDList[0], this.cameraDList.Count);
      }
      catch
      {
      }
      try
      {
        GL.DeleteLists(this.clankerDL, 1);
      }
      catch
      {
      }
      try
      {
        GL.DeleteLists(this.cameraPickDList[0], this.cameraPickDList.Count);
      }
      catch
      {
      }
      try
      {
        GL.DeleteLists(this.pathsDList[0], this.pathsDList.Count);
      }
      catch
      {
      }
      this.objectsDList.Clear();
      this.structsDList.Clear();
      this.cameraDList.Clear();
      this.cameraPickDList.Clear();
      this.pathsDList.Clear();
      this.currentPath = 32;
    }

    public void addCamera(CameraObject cam)
    {
      this.cameras.Add(cam);
      this.RenderCameras();
      this.renderPicking();
    }

    public void Redraw(GLCamera BBCam)
    {
      GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
      if (this.pathMode)
      {
        if (this.pmode == PathMode.Assign)
        {
          GL.CallList(this.levelDList);
          this.ExtractFrustum();
          for (int index = 0; index < this.objects.Count<ObjectData>(); ++index)
          {
            try
            {
              ObjectData objectData = this.objects[index];
              float s = (float) objectData.size / 100f;
              this.checkSize(ref s, objectData);
              if (objectData.name != "")
              {
                if (objectData.type == ObjectType.Normal)
                {
                  if (this.CubeInFrustum((float) this.objects[index].locX, (float) this.objects[index].locY, (float) this.objects[index].locZ, (float) this.objects[index].bb.getSize() * s))
                    GL.CallList(this.objectsDList[index]);
                }
              }
            }
            catch (Exception ex)
            {
            }
          }
          GL.CallList(this.levelBDList);
        }
        else if (this.pmode == PathMode.Link)
        {
          GL.CallList(this.levelDList);
          if (this.selectedPath != -1)
          {
            GL.DeleteLists(this.pathsDList[this.selectedPath], 1);
            uint list = (uint) GL.GenLists(1);
            GL.NewList(list, ListMode.Compile);
            this.DrawPath(this.paths[this.selectedPath], false);
            GL.EndList();
            this.pathsDList[this.selectedPath] = list;
            GL.CallList(this.pathsDList[this.selectedPath]);
          }
          GL.CallList(this.levelBDList);
        }
        else
        {
          if (this.drawLevelBoundary)
            GL.CallList(this.levelBoundary);
          if (this.drawLevelBoundaryAlpha)
            GL.CallList(this.levelBoundaryAlpha);
          GL.CallList(this.levelDList);
          if (this.selectedPath != -1)
          {
            GL.DeleteLists(this.pathsDList[this.selectedPath], 1);
            uint list = (uint) GL.GenLists(1);
            GL.NewList(list, ListMode.Compile);
            this.DrawPath(this.paths[this.selectedPath], false);
            GL.EndList();
            this.pathsDList[this.selectedPath] = list;
            GL.CallList(this.pathsDList[this.selectedPath]);
          }
          else
          {
            for (int index = 0; index < this.pathsDList.Count<uint>(); ++index)
              GL.CallList(this.pathsDList[index]);
          }
          if (this.selectedPath != -1)
          {
            GL.DeleteLists(this.selectedDList, 1);
            this.selectedDList = (uint) GL.GenLists(1);
            GL.NewList(this.selectedDList, ListMode.Compile);
            for (int index = 0; index < this.selectedNodes.Count; ++index)
              this.core.drawObjectBoundingBox(this.paths[this.selectedPath].nodes[this.selectedNodes[index]]);
            GL.EndList();
            GL.CallList(this.selectedDList);
            if (this.selectedSNodes.Count == 1)
              this.drawSelectedPathController();
          }
          GL.CallList(this.levelBDList);
        }
      }
      else
      {
        for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
        {
          GL.DeleteLists(this.objectsDList[this.selectedObjects[index]], 1);
          this.objectsDList[this.selectedObjects[index]] = (uint) GL.GenLists(1);
          GL.NewList(this.objectsDList[this.selectedObjects[index]], ListMode.Compile);
          this.drawHelper(this.objects[this.selectedObjects[index]], true, false);
          GL.Disable(EnableCap.Texture2D);
          GL.EndList();
          GL.Flush();
        }
        for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
        {
          GL.DeleteLists(this.structsDList[this.selectedStructs[index]], 1);
          this.structsDList[this.selectedStructs[index]] = (uint) GL.GenLists(1);
          GL.NewList(this.structsDList[this.selectedStructs[index]], ListMode.Compile);
          this.drawHelper(this.structs[this.selectedStructs[index]], true, true);
          GL.Disable(EnableCap.Texture2D);
          GL.EndList();
          GL.Flush();
        }
        GL.DeleteLists(this.selectedDList, 1);
        this.selectedDList = (uint) GL.GenLists(1);
        GL.NewList(this.selectedDList, ListMode.Compile);
        for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
          this.core.drawObjectBoundingBox(this.objects[this.selectedObjects[index]]);
        for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
          this.core.drawObjectBoundingBox(this.structs[this.selectedStructs[index]]);
        if (this.selectedCam != -1)
        {
          GL.PushMatrix();
          GL.Translate(this.cameras[this.selectedCam].x, this.cameras[this.selectedCam].y, this.cameras[this.selectedCam].z);
          GL.Rotate(this.cameras[this.selectedCam].roll, 0.0f, 0.0f, 1f);
          GL.Rotate(this.cameras[this.selectedCam].yaw, 0.0f, 1f, 0.0f);
          GL.Rotate(this.cameras[this.selectedCam].pitch, 1f, 0.0f, 0.0f);
          this.core.DrawModelBoundary(this.cameras[this.selectedCam].bb, false);
          GL.PopMatrix();
        }
        GL.EndList();
        GL.PushMatrix();
        GL.Translate(0.0f, 0.0f, 0.0f);
        GL.Rotate(0.0f, 1f, 0.0f, 0.0f);
        GL.Rotate(0.0f, 0.0f, 1f, 0.0f);
        GL.Rotate(0.0f, 0.0f, 0.0f, 1f);
        if (this.drawLevelBoundary)
          GL.CallList(this.levelBoundary);
        if (this.drawLevelBoundaryAlpha)
          GL.CallList(this.levelBoundaryAlpha);
        if (this.drawA)
          GL.CallList(this.levelDList);
        GL.CallList(this.selectedDList);
        for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
          GL.CallList(this.objectsDList[this.selectedObjects[index]]);
        for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
          GL.CallList(this.structsDList[this.selectedStructs[index]]);
        if (this.drawObjs)
        {
          this.ExtractFrustum();
          for (int index = 0; index < this.objects.Count<ObjectData>(); ++index)
          {
            if (!this.selectedObjects.Contains(index))
            {
              try
              {
                ObjectData objectData = this.objects[index];
                float s = (float) objectData.size / 100f;
                this.checkSize(ref s, objectData);
                if (this.ObjectInDrawDistance((float) this.objects[index].locX, (float) this.objects[index].locY, (float) this.objects[index].locZ, BBCam))
                {
                  if (this.CubeInFrustum((float) this.objects[index].locX, (float) this.objects[index].locY, (float) this.objects[index].locZ, (float) this.objects[index].bb.getSize() * s))
                    GL.CallList(this.objectsDList[index]);
                }
              }
              catch (Exception ex)
              {
              }
            }
          }
          for (int index = 0; index < this.structs.Count<ObjectData>(); ++index)
          {
            if (!this.selectedStructs.Contains(index))
            {
              ObjectData objectData = this.structs[index];
              float s = (float) objectData.size / 100f;
              this.checkSize(ref s, objectData);
              if (this.ObjectInDrawDistance((float) this.structs[index].locX, (float) this.structs[index].locY, (float) this.structs[index].locZ, BBCam) && this.CubeInFrustum((float) this.structs[index].locX, (float) this.structs[index].locY, (float) this.structs[index].locZ, (float) this.structs[index].bb.getSize() * s))
                GL.CallList(this.structsDList[index]);
            }
          }
        }
        if (this.file != null && this.file.pointer == 38864)
          GL.CallList(this.clankerDL);
        if (this.drawB)
          GL.CallList(this.levelBDList);
        if (this.drawCams)
        {
          for (int index = 0; index < this.cameraDList.Count<uint>(); ++index)
          {
            if (index == this.selectedCam)
            {
              this.cameraDList[this.selectedCam] = (uint) GL.GenLists(1);
              GL.NewList(this.cameraDList[this.selectedCam], ListMode.Compile);
              this.core.drawCamera(this.cameras[index]);
              GL.EndList();
            }
            GL.CallList(this.cameraDList[index]);
          }
        }
        GL.PopMatrix();
      }
    }

    private bool ObjectInDrawDistance(float x, float y, float z, GLCamera camera) => Math.Sqrt(Math.Pow((double) x + (double) camera.X, 2.0) + Math.Pow((double) y + (double) camera.Y, 2.0) + Math.Pow((double) z + (double) camera.Z, 2.0)) <= (double) this.drawDistance;

    private bool CubeInFrustum(float x, float y, float z, float size)
    {
      for (int index = 0; index < 6; ++index)
      {
        if ((double) this.frustum[index][0] * ((double) x - (double) size) + (double) this.frustum[index][1] * ((double) y - (double) size) + (double) this.frustum[index][2] * ((double) z - (double) size) + (double) this.frustum[index][3] <= 0.0 && (double) this.frustum[index][0] * ((double) x + (double) size) + (double) this.frustum[index][1] * ((double) y - (double) size) + (double) this.frustum[index][2] * ((double) z - (double) size) + (double) this.frustum[index][3] <= 0.0 && (double) this.frustum[index][0] * ((double) x - (double) size) + (double) this.frustum[index][1] * ((double) y + (double) size) + (double) this.frustum[index][2] * ((double) z - (double) size) + (double) this.frustum[index][3] <= 0.0 && (double) this.frustum[index][0] * ((double) x + (double) size) + (double) this.frustum[index][1] * ((double) y + (double) size) + (double) this.frustum[index][2] * ((double) z - (double) size) + (double) this.frustum[index][3] <= 0.0 && (double) this.frustum[index][0] * ((double) x - (double) size) + (double) this.frustum[index][1] * ((double) y - (double) size) + (double) this.frustum[index][2] * ((double) z + (double) size) + (double) this.frustum[index][3] <= 0.0 && (double) this.frustum[index][0] * ((double) x + (double) size) + (double) this.frustum[index][1] * ((double) y - (double) size) + (double) this.frustum[index][2] * ((double) z + (double) size) + (double) this.frustum[index][3] <= 0.0 && (double) this.frustum[index][0] * ((double) x - (double) size) + (double) this.frustum[index][1] * ((double) y + (double) size) + (double) this.frustum[index][2] * ((double) z + (double) size) + (double) this.frustum[index][3] <= 0.0 && (double) this.frustum[index][0] * ((double) x + (double) size) + (double) this.frustum[index][1] * ((double) y + (double) size) + (double) this.frustum[index][2] * ((double) z + (double) size) + (double) this.frustum[index][3] <= 0.0)
          return false;
      }
      return true;
    }

    private bool PointInFrustum(float x, float y, float z)
    {
      for (int index = 0; index < 6; ++index)
      {
        if ((double) this.frustum[index][0] * (double) x + (double) this.frustum[index][1] * (double) y + (double) this.frustum[index][2] * (double) z + (double) this.frustum[index][3] <= 0.0)
          return false;
      }
      return true;
    }

    private void ExtractFrustum()
    {
      try
      {
        float[] data1 = new float[16];
        float[] data2 = new float[16];
        float[] numArray = new float[16];
        GL.GetFloat(GetPName.ProjectionMatrix, data1);
        GL.GetFloat(GetPName.Modelview0MatrixExt, data2);
        numArray[0] = (float) ((double) data2[0] * (double) data1[0] + (double) data2[1] * (double) data1[4] + (double) data2[2] * (double) data1[8] + (double) data2[3] * (double) data1[12]);
        numArray[1] = (float) ((double) data2[0] * (double) data1[1] + (double) data2[1] * (double) data1[5] + (double) data2[2] * (double) data1[9] + (double) data2[3] * (double) data1[13]);
        numArray[2] = (float) ((double) data2[0] * (double) data1[2] + (double) data2[1] * (double) data1[6] + (double) data2[2] * (double) data1[10] + (double) data2[3] * (double) data1[14]);
        numArray[3] = (float) ((double) data2[0] * (double) data1[3] + (double) data2[1] * (double) data1[7] + (double) data2[2] * (double) data1[11] + (double) data2[3] * (double) data1[15]);
        numArray[4] = (float) ((double) data2[4] * (double) data1[0] + (double) data2[5] * (double) data1[4] + (double) data2[6] * (double) data1[8] + (double) data2[7] * (double) data1[12]);
        numArray[5] = (float) ((double) data2[4] * (double) data1[1] + (double) data2[5] * (double) data1[5] + (double) data2[6] * (double) data1[9] + (double) data2[7] * (double) data1[13]);
        numArray[6] = (float) ((double) data2[4] * (double) data1[2] + (double) data2[5] * (double) data1[6] + (double) data2[6] * (double) data1[10] + (double) data2[7] * (double) data1[14]);
        numArray[7] = (float) ((double) data2[4] * (double) data1[3] + (double) data2[5] * (double) data1[7] + (double) data2[6] * (double) data1[11] + (double) data2[7] * (double) data1[15]);
        numArray[8] = (float) ((double) data2[8] * (double) data1[0] + (double) data2[9] * (double) data1[4] + (double) data2[10] * (double) data1[8] + (double) data2[11] * (double) data1[12]);
        numArray[9] = (float) ((double) data2[8] * (double) data1[1] + (double) data2[9] * (double) data1[5] + (double) data2[10] * (double) data1[9] + (double) data2[11] * (double) data1[13]);
        numArray[10] = (float) ((double) data2[8] * (double) data1[2] + (double) data2[9] * (double) data1[6] + (double) data2[10] * (double) data1[10] + (double) data2[11] * (double) data1[14]);
        numArray[11] = (float) ((double) data2[8] * (double) data1[3] + (double) data2[9] * (double) data1[7] + (double) data2[10] * (double) data1[11] + (double) data2[11] * (double) data1[15]);
        numArray[12] = (float) ((double) data2[12] * (double) data1[0] + (double) data2[13] * (double) data1[4] + (double) data2[14] * (double) data1[8] + (double) data2[15] * (double) data1[12]);
        numArray[13] = (float) ((double) data2[12] * (double) data1[1] + (double) data2[13] * (double) data1[5] + (double) data2[14] * (double) data1[9] + (double) data2[15] * (double) data1[13]);
        numArray[14] = (float) ((double) data2[12] * (double) data1[2] + (double) data2[13] * (double) data1[6] + (double) data2[14] * (double) data1[10] + (double) data2[15] * (double) data1[14]);
        numArray[15] = (float) ((double) data2[12] * (double) data1[3] + (double) data2[13] * (double) data1[7] + (double) data2[14] * (double) data1[11] + (double) data2[15] * (double) data1[15]);
        this.frustum[0][0] = numArray[3] - numArray[0];
        this.frustum[0][1] = numArray[7] - numArray[4];
        this.frustum[0][2] = numArray[11] - numArray[8];
        this.frustum[0][3] = numArray[15] - numArray[12];
        float num1 = (float) Math.Sqrt((double) this.frustum[0][0] * (double) this.frustum[0][0] + (double) this.frustum[0][1] * (double) this.frustum[0][1] + (double) this.frustum[0][2] * (double) this.frustum[0][2]);
        this.frustum[0][0] /= num1;
        this.frustum[0][1] /= num1;
        this.frustum[0][2] /= num1;
        this.frustum[0][3] /= num1;
        this.frustum[1][0] = numArray[3] + numArray[0];
        this.frustum[1][1] = numArray[7] + numArray[4];
        this.frustum[1][2] = numArray[11] + numArray[8];
        this.frustum[1][3] = numArray[15] + numArray[12];
        float num2 = (float) Math.Sqrt((double) this.frustum[1][0] * (double) this.frustum[1][0] + (double) this.frustum[1][1] * (double) this.frustum[1][1] + (double) this.frustum[1][2] * (double) this.frustum[1][2]);
        this.frustum[1][0] /= num2;
        this.frustum[1][1] /= num2;
        this.frustum[1][2] /= num2;
        this.frustum[1][3] /= num2;
        this.frustum[2][0] = numArray[3] + numArray[1];
        this.frustum[2][1] = numArray[7] + numArray[5];
        this.frustum[2][2] = numArray[11] + numArray[9];
        this.frustum[2][3] = numArray[15] + numArray[13];
        float num3 = (float) Math.Sqrt((double) this.frustum[2][0] * (double) this.frustum[2][0] + (double) this.frustum[2][1] * (double) this.frustum[2][1] + (double) this.frustum[2][2] * (double) this.frustum[2][2]);
        this.frustum[2][0] /= num3;
        this.frustum[2][1] /= num3;
        this.frustum[2][2] /= num3;
        this.frustum[2][3] /= num3;
        this.frustum[3][0] = numArray[3] - numArray[1];
        this.frustum[3][1] = numArray[7] - numArray[5];
        this.frustum[3][2] = numArray[11] - numArray[9];
        this.frustum[3][3] = numArray[15] - numArray[13];
        float num4 = (float) Math.Sqrt((double) this.frustum[3][0] * (double) this.frustum[3][0] + (double) this.frustum[3][1] * (double) this.frustum[3][1] + (double) this.frustum[3][2] * (double) this.frustum[3][2]);
        this.frustum[3][0] /= num4;
        this.frustum[3][1] /= num4;
        this.frustum[3][2] /= num4;
        this.frustum[3][3] /= num4;
        this.frustum[4][0] = numArray[3] - numArray[2];
        this.frustum[4][1] = numArray[7] - numArray[6];
        this.frustum[4][2] = numArray[11] - numArray[10];
        this.frustum[4][3] = numArray[15] - numArray[14];
        float num5 = (float) Math.Sqrt((double) this.frustum[4][0] * (double) this.frustum[4][0] + (double) this.frustum[4][1] * (double) this.frustum[4][1] + (double) this.frustum[4][2] * (double) this.frustum[4][2]);
        this.frustum[4][0] /= num5;
        this.frustum[4][1] /= num5;
        this.frustum[4][2] /= num5;
        this.frustum[4][3] /= num5;
        this.frustum[5][0] = numArray[3] + numArray[2];
        this.frustum[5][1] = numArray[7] + numArray[6];
        this.frustum[5][2] = numArray[11] + numArray[10];
        this.frustum[5][3] = numArray[15] + numArray[14];
        float num6 = (float) Math.Sqrt((double) this.frustum[5][0] * (double) this.frustum[5][0] + (double) this.frustum[5][1] * (double) this.frustum[5][1] + (double) this.frustum[5][2] * (double) this.frustum[5][2]);
        this.frustum[5][0] /= num6;
        this.frustum[5][1] /= num6;
        this.frustum[5][2] /= num6;
        this.frustum[5][3] /= num6;
      }
      catch (Exception ex)
      {
      }
    }

    private void DrawMusicZones(List<byte> F19250)
    {
    }

    public void RenderScene(string replacedModel, string replacedModelB)
    {
      this.CreateJiggyDL();
      this.levelDList = (uint) GL.GenLists(1);
      this.levelBDList = (uint) GL.GenLists(1);
      if (this.file != null)
      {
        GL.NewList(this.levelDList, ListMode.Compile);
        if (replacedModel == "")
        {
          if (this.file.modelAPointer != 0)
            this.file.bounds = this.DrawModelFile(this.file.modelAPointer, 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false, false);
        }
        else
          this.file.bounds = this.core.DrawModelFile(replacedModel, 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false);
        GL.Disable(EnableCap.Texture2D);
        GL.EndList();
        GL.NewList(this.levelBDList, ListMode.Compile);
        if (replacedModel == "")
        {
          if (this.file.modelBPointer != 0)
          {
            this.DrawModelFile(this.file.modelBPointer, 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false, false);
            this.file.boundsA = this.DrawModelFile(this.file.modelBPointer, 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false, false);
          }
        }
        else if (replacedModelB != "")
        {
          this.core.DrawModelFile(replacedModelB, 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false);
          this.file.boundsA = this.core.DrawModelFile(replacedModelB, 0.0f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false);
        }
        GL.Disable(EnableCap.Texture2D);
        GL.EndList();
        if (this.file.modelAPointer == 67072)
        {
          this.clankerDL = (uint) GL.GenLists(1);
          GL.NewList(this.clankerDL, ListMode.Compile);
          this.DrawModelFile(41736, 5390f, 0.0f, 0.0f, 0, 100f, (ushort) 0, false, false);
          GL.Disable(EnableCap.Texture2D);
          GL.EndList();
        }
        this.movementDL = (uint) GL.GenLists(1);
        GL.NewList(this.movementDL, ListMode.Compile);
        GL.Disable(EnableCap.Texture2D);
        GL.EndList();
      }
      this.DrawLevelBoundary();
    }

    public void RenderObjects()
    {
      try
      {
        for (int index = 0; index < this.objectsDList.Count; ++index)
          GL.DeleteLists(this.objectsDList[index], 1);
      }
      catch
      {
      }
      this.objectsDList.Clear();
      for (int index = 0; index < this.objects.Count; ++index)
        this.drawHelper(this.objects[index], false, false);
    }

    public void RenderPaths()
    {
      try
      {
        for (int index = 0; index < this.pathsDList.Count; ++index)
          GL.DeleteLists(this.pathsDList[index], 1);
      }
      catch
      {
      }
      this.pathsDList.Clear();
      for (int index = 0; index < this.paths.Count; ++index)
      {
        uint list = (uint) GL.GenLists(1);
        GL.NewList(list, ListMode.Compile);
        this.DrawPath(this.paths[index], false);
        GL.EndList();
        this.pathsDList.Add(list);
      }
    }

    public void redrawSelectedPath()
    {
      GL.DeleteLists(this.pathsDList[this.selectedPath], 1);
      GL.NewList((uint) GL.GenLists(1), ListMode.Compile);
      this.DrawPath(this.paths[this.selectedPath], false);
      GL.EndList();
    }

    private void DrawPath(BKPath p, bool s)
    {
      if (p.pathObject != -1)
      {
        this.drawHelper(this.objects[p.pathObject], true, false);
        GL.Disable(EnableCap.Texture2D);
      }
      for (int index1 = 0; index1 < p.nodes.Count; ++index1)
      {
        p.nodes[index1].bb = new BoundingBox();
        p.nodes[index1].bb.smallX = -25;
        p.nodes[index1].bb.smallY = -25;
        p.nodes[index1].bb.smallZ = -25;
        p.nodes[index1].bb.largeX = 25;
        p.nodes[index1].bb.largeY = 25;
        p.nodes[index1].bb.largeZ = 25;
        if (p.nodes[index1].type == ObjectType.Path)
        {
          GL.Color3(1f, 1f, 1f);
          this.core.DrawPri((float) p.nodes[index1].locX, (float) p.nodes[index1].locY, (float) p.nodes[index1].locZ, p.nodes[index1].radius, p.nodes[index1].colour);
        }
        GL.PushMatrix();
        if (s)
          GL.Color3(0.3f, 0.3f, 1f);
        else
          GL.Color3(1, 1, 1);
        GL.Begin(BeginMode.Lines);
        for (int index2 = 0; index2 < p.nodes.Count; ++index2)
        {
          if ((int) p.nodes[index1].nodeOutUID == (int) p.nodes[index2].uid && p.nodes[index2].type != ObjectType.SPath)
          {
            GL.Color3(0.95f, 0.51f, 0.14f);
            GL.Vertex3(p.nodes[index2].locX, p.nodes[index2].locY, p.nodes[index2].locZ);
            GL.Vertex3(p.nodes[index1].locX, p.nodes[index1].locY, p.nodes[index1].locZ);
          }
          if (p.pathObject != -1 && (int) this.objects[p.pathObject].nodeOutUID == (int) p.nodes[index2].uid)
          {
            GL.Color3(1f, 1f, 1f);
            if (p.nodes[index2].type == ObjectType.SPath)
              GL.Color3(1, 0, 0);
            GL.Vertex3(p.nodes[index2].locX, p.nodes[index2].locY, p.nodes[index2].locZ);
            GL.Vertex3(this.objects[p.pathObject].locX, this.objects[p.pathObject].locY, this.objects[p.pathObject].locZ);
          }
        }
        GL.End();
        GL.PopMatrix();
      }
    }

    public void renderSetup()
    {
      this.RenderObjects();
      this.RenderStructs();
      this.RenderCameras();
    }

    public void RenderStructs()
    {
      try
      {
        for (int index = 0; index < this.structsDList.Count; ++index)
          GL.DeleteLists(this.structsDList[index], 1);
      }
      catch
      {
      }
      this.structsDList.Clear();
      for (int index = 0; index < this.structs.Count; ++index)
        this.drawHelper(this.structs[index], false, true);
    }

    public void RenderCameras()
    {
      try
      {
        for (int index = 0; index < this.cameraDList.Count; ++index)
          GL.DeleteLists(this.cameraDList[index], 1);
      }
      catch
      {
      }
      this.cameraDList.Clear();
      for (int index = 0; index < this.cameras.Count; ++index)
      {
        CameraObject camera = this.cameras[index];
        uint list = (uint) GL.GenLists(1);
        GL.NewList(list, ListMode.Compile);
        this.core.drawCamera(camera);
        GL.EndList();
        GL.Flush();
        this.cameraDList.Add(list);
      }
    }

    public void RenderCameraPicking()
    {
      try
      {
        for (int index = 0; index < this.cameraPickDList.Count; ++index)
          GL.DeleteLists(this.cameraPickDList[index], 1);
      }
      catch
      {
      }
      this.cameraPickDList.Clear();
      for (int index = 0; index < this.cameras.Count; ++index)
        this.drawCameraPicking(this.cameras[index]);
    }

    private bool check2D(ref ObjectData obj) => obj.objectID == (short) 32 || obj.objectID == (short) 33 || obj.objectID == (short) 34 && obj.specialScript == (short) 6412 || obj.objectID == (short) 35 || obj.objectID == (short) 39 || obj.objectID == (short) 45 || obj.objectID == (short) 81 || obj.objectID == (short) 82 || obj.objectID == (short) 5696 || obj.objectID == (short) 5712 || obj.objectID == (short) 5728 || obj.name == "Enemy Boundary" || obj.name.Contains("End Climb") || obj.name == "Start Climb" || obj.name == "Note" || obj.name.Contains("Start Point") || obj.name.Contains("Entry Point") || obj.name == "warp" || obj.name == "Warp To - Start of Level" || obj.objectID == (short) 389 || obj.objectID == (short) 395 || obj.objectID == (short) 414 || obj.objectID == (short) 297 || obj.objectID == (short) 224 || obj.objectID == (short) 511 || obj.objectID == (short) 512 || obj.objectID == (short) 880 || obj.objectID == (short) 73 || obj.specialScript == (short) 0 && (obj.objectID == (short) 3424 || obj.objectID == (short) 1125 || obj.objectID == (short) 1127 || obj.objectID == (short) 1136 || obj.objectID == (short) 1280 || obj.objectID == (short) 5696 || obj.objectID == (short) 5616 || obj.objectID == (short) 224 || obj.objectID == (short) 5712 || obj.objectID == (short) 5728);

    public void drawHelper(ObjectData obj, bool skipDL, bool isStruct)
    {
      uint list = 0;
      if (obj.pointer != 0)
      {
        if (!skipDL)
        {
          list = (uint) GL.GenLists(1);
          GL.NewList(list, ListMode.Compile);
        }
        if (this.check2D(ref obj) || obj.pointer == 1)
        {
          obj.bb = this.core.DrawModelFile(obj.modelFile, (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, 100f, obj.radius, skipDL);
          if (obj.modelFile2 != "")
            this.core.DrawModelFile(obj.modelFile2, (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, (float) obj.size, obj.radius, skipDL);
        }
        else
        {
          ObjectData objectData1 = obj;
          ObjectData objectData2 = obj;
          BoundingBox boundingBox = this.DrawObject(objectData2, (float) objectData2.size, true, skipDL);
          objectData1.bb = boundingBox;
          if (obj.modelFile2 != "" || obj.pointer2 != 0)
          {
            if (obj.pointer2 != 0)
            {
              ObjectData objectData3 = obj;
              this.DrawObject(objectData3, (float) objectData3.size, false, skipDL);
            }
            else
              this.core.DrawModelFile(this.dir + obj.modelFile2, (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, (float) obj.size, obj.radius, skipDL);
          }
        }
        if (skipDL)
          return;
        GL.Disable(EnableCap.Texture2D);
        GL.EndList();
        GL.Flush();
        if (isStruct)
          this.structsDList.Add(list);
        else
          this.objectsDList.Add(list);
      }
      else
      {
        if (!skipDL)
        {
          list = (uint) GL.GenLists(1);
          GL.NewList(list, ListMode.Compile);
          obj.bb = new BoundingBox();
          obj.bb.smallX = -25;
          obj.bb.smallY = -25;
          obj.bb.smallZ = -25;
          obj.bb.largeX = 25;
          obj.bb.largeY = 25;
          obj.bb.largeZ = 25;
        }
        if (obj.name == "Camera Trigger")
          this.core.DrawCamTrigger((float) obj.locX, (float) obj.locY, (float) obj.locZ, obj.radius, (byte) 0, (byte) 0, byte.MaxValue);
        else
          this.core.DrawPri((float) obj.locX, (float) obj.locY, (float) obj.locZ, obj.radius, obj.colour);
        if (skipDL)
          return;
        GL.EndList();
        GL.Flush();
        if (isStruct)
          this.structsDList.Add(list);
        else
          this.objectsDList.Add(list);
      }
    }

    public BoundingBox DrawModelFile(
      int pntr_,
      float x_,
      float y_,
      float z_,
      int rot_,
      float size,
      ushort radius,
      bool selected,
      bool hasJiggy)
    {
      BoundingBox boundingBox = new BoundingBox();
      try
      {
        RomHandler.DecompressFileToHDD(pntr_);
      }
      catch (Exception ex)
      {
      }
      return File.Exists(this.dir + pntr_.ToString("x")) ? this.core.DrawModelFile(this.dir, pntr_, x_, y_, z_, rot_, size, radius, selected, hasJiggy, this.jiggyDList) : boundingBox;
    }

    public BoundingBox DrawObject(
      ObjectData obj,
      float size,
      bool model1,
      bool selected)
    {
      return !model1 ? this.DrawModelFile(obj.pointer2, (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, (float) obj.size, obj.radius, selected, obj.hasJiggy) : this.DrawModelFile(obj.pointer, (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, (float) obj.size, obj.radius, selected, obj.hasJiggy);
    }

    public void drawPickHelper(ObjectData obj)
    {
      if (obj.pointer != 0)
      {
        if (this.check2D(ref obj) || obj.pointer == 1)
        {
          GL.Color3((float) obj.m_colorID[0] / (float) byte.MaxValue, (float) obj.m_colorID[1] / (float) byte.MaxValue, (float) obj.m_colorID[2] / (float) byte.MaxValue);
          this.core.DrawModelFilePicking(obj.modelFile, (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, 100f);
          GL.Disable(EnableCap.Texture2D);
        }
        else
        {
          GL.Color3((float) obj.m_colorID[0] / (float) byte.MaxValue, (float) obj.m_colorID[1] / (float) byte.MaxValue, (float) obj.m_colorID[2] / (float) byte.MaxValue);
          this.DrawObjectPicking(obj);
          if (!(obj.modelFile2 != "") || obj.pointer2 != 0)
            return;
          GL.Color3((float) obj.m_colorID[0] / (float) byte.MaxValue, (float) obj.m_colorID[1] / (float) byte.MaxValue, (float) obj.m_colorID[2] / (float) byte.MaxValue);
          this.core.DrawModelFilePicking(this.dir + obj.modelFile2, (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, (float) obj.size);
        }
      }
      else if (obj.name == "Camera Trigger")
      {
        this.core.DrawCamTrigger((float) obj.locX, (float) obj.locY, (float) obj.locZ, (ushort) 0, obj.m_colorID[0], obj.m_colorID[1], obj.m_colorID[2]);
      }
      else
      {
        GL.Color3((float) obj.m_colorID[0] / (float) byte.MaxValue, (float) obj.m_colorID[1] / (float) byte.MaxValue, (float) obj.m_colorID[2] / (float) byte.MaxValue);
        this.core.DrawPriPick((float) obj.locX, (float) obj.locY, (float) obj.locZ);
      }
    }

    public void renderPathPicking()
    {
      try
      {
        GL.DeleteLists(this.pickPathDList, 1);
      }
      catch
      {
      }
      this.pickPathDList = (uint) GL.GenLists(1);
      GL.NewList(this.pickPathDList, ListMode.Compile);
      GL.Disable(EnableCap.CullFace);
      try
      {
        for (int index1 = 0; index1 < this.paths.Count; ++index1)
        {
          GL.Color3((float) this.paths[index1].m_colorID[0] / (float) byte.MaxValue, (float) this.paths[index1].m_colorID[1] / (float) byte.MaxValue, (float) this.paths[index1].m_colorID[2] / (float) byte.MaxValue);
          GL.PushMatrix();
          if (this.paths[index1].pathObject != -1)
          {
            ObjectData objectData = this.objects[this.paths[index1].pathObject];
            if (objectData.pointer != 0)
              this.DrawObjectPicking(objectData);
            else if (objectData.name == "Camera Trigger")
              this.core.DrawCamTrigger((float) objectData.locX, (float) objectData.locY, (float) objectData.locZ, (ushort) 0, objectData.m_colorID[0], objectData.m_colorID[1], objectData.m_colorID[2]);
            else
              this.core.DrawPriPick((float) objectData.locX, (float) objectData.locY, (float) objectData.locZ);
          }
          GL.PopMatrix();
          for (int index2 = 0; index2 < this.paths[index1].nodes.Count; ++index2)
          {
            if (this.paths[index1].nodes[index2].type == ObjectType.Path)
            {
              GL.Color3((float) this.paths[index1].m_colorID[0] / (float) byte.MaxValue, (float) this.paths[index1].m_colorID[1] / (float) byte.MaxValue, (float) this.paths[index1].m_colorID[2] / (float) byte.MaxValue);
              this.core.DrawPriPick((float) this.paths[index1].nodes[index2].locX, (float) this.paths[index1].nodes[index2].locY, (float) this.paths[index1].nodes[index2].locZ);
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      GL.EndList();
      try
      {
        GL.DeleteLists(this.pickPathNodeDList, 1);
      }
      catch
      {
      }
      this.pickPathNodeDList = (uint) GL.GenLists(1);
      GL.NewList(this.pickPathNodeDList, ListMode.Compile);
      GL.Disable(EnableCap.CullFace);
      for (int index3 = 0; index3 < this.paths.Count; ++index3)
      {
        for (int index4 = 0; index4 < this.paths[index3].nodes.Count; ++index4)
        {
          if (this.paths[index3].nodes[index4].type == ObjectType.Path)
          {
            GL.Color3((float) this.paths[index3].nodes[index4].m_colorID[0] / (float) byte.MaxValue, (float) this.paths[index3].nodes[index4].m_colorID[1] / (float) byte.MaxValue, (float) this.paths[index3].nodes[index4].m_colorID[2] / (float) byte.MaxValue);
            this.core.DrawPriPick((float) this.paths[index3].nodes[index4].locX, (float) this.paths[index3].nodes[index4].locY, (float) this.paths[index3].nodes[index4].locZ);
          }
        }
      }
      GL.EndList();
      GL.Flush();
    }

    public void renderPicking()
    {
      this.renderPathPicking();
      this.RenderCameraPicking();
      try
      {
        GL.DeleteLists(this.pickDList, 1);
      }
      catch
      {
      }
      this.pickDList = (uint) GL.GenLists(1);
      GL.NewList(this.pickDList, ListMode.Compile);
      GL.Disable(EnableCap.CullFace);
      GL.Disable(EnableCap.Texture2D);
      GL.Disable(EnableCap.Fog);
      GL.Disable(EnableCap.Lighting);
      GL.ShadeModel(ShadingModel.Flat);
      for (int index = 0; index < this.structs.Count; ++index)
      {
        if (!this.selectedStructs.Contains(index))
        {
          ObjectData objectData = this.structs[index];
          if (objectData.pointer != 0)
          {
            this.drawPickHelper(objectData);
          }
          else
          {
            GL.Color3((float) objectData.m_colorID[0] / (float) byte.MaxValue, (float) objectData.m_colorID[1] / (float) byte.MaxValue, (float) objectData.m_colorID[2] / (float) byte.MaxValue);
            this.core.DrawPriPick((float) objectData.locX, (float) objectData.locY, (float) objectData.locZ);
          }
        }
      }
      if (this.objects != null && this.objects.Count != 0)
      {
        for (int index = 0; index < this.objects.Count; ++index)
        {
          ObjectData objectData = this.objects[index];
          bool flag = true;
          if (this.selectedObjects.Contains(index))
            flag = false;
          if (flag)
            this.drawPickHelper(objectData);
        }
      }
      GL.EndList();
      GL.Flush();
    }

    public int pickPath(int x, int y, bool multiselect, GLCamera cam)
    {
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      GL.LoadMatrix(cam.GetWorldToViewMatrix());
      this.resetPick();
      this.renderPathPicking();
      byte[] numArray = this.core.BackBufferSelect(x, y, this.pickPathDList);
      int num = -1;
      for (int index = 0; index < this.paths.Count; ++index)
      {
        if ((int) this.paths[index].m_colorID[0] == (int) numArray[0] && (int) this.paths[index].m_colorID[1] == (int) numArray[1] && (int) this.paths[index].m_colorID[2] == (int) numArray[2])
          num = index;
      }
      this.selectedPath = num;
      this.selectedNodes.Clear();
      this.selectedSNodes.Clear();
      GL.PopMatrix();
      this.pickPathNode(x, y, multiselect, cam);
      return num;
    }

    public void pickPathNode(int x, int y, bool multiselect, GLCamera cam)
    {
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      GL.LoadMatrix(cam.GetWorldToViewMatrix());
      if (this.selectedPath != -1)
      {
        GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
        GL.Disable(EnableCap.Texture2D);
        GL.Disable(EnableCap.Fog);
        GL.Disable(EnableCap.Lighting);
        GL.ShadeModel(ShadingModel.Flat);
        GL.Disable(EnableCap.CullFace);
        GL.PushMatrix();
        GL.Translate(0.0f, 0.0f, 0.0f);
        GL.Rotate(0.0f, 1f, 0.0f, 0.0f);
        GL.Rotate(0.0f, 0.0f, 1f, 0.0f);
        GL.Rotate(0.0f, 0.0f, 0.0f, 1f);
        try
        {
          foreach (ObjectData node in this.paths[this.selectedPath].nodes)
          {
            if (node.type == ObjectType.Path)
            {
              GL.Color3((float) node.m_colorID[0] / (float) byte.MaxValue, (float) node.m_colorID[1] / (float) byte.MaxValue, (float) node.m_colorID[2] / (float) byte.MaxValue);
              this.core.DrawPriPick((float) node.locX, (float) node.locY, (float) node.locZ);
            }
          }
        }
        catch (Exception ex)
        {
        }
        byte[] pixels = new byte[3];
        int[] data = new int[4];
        GL.GetInteger(GetPName.Viewport, data);
        GL.ReadPixels<byte>(x, data[3] - y, 1, 1, PixelFormat.Rgb, PixelType.UnsignedByte, pixels);
        GL.PopMatrix();
        if (!multiselect)
          this.selectedNodes.Clear();
        this.selectedSNodes.Clear();
        for (int index = 0; index < this.paths[this.selectedPath].nodes.Count; ++index)
        {
          if ((int) this.paths[this.selectedPath].nodes[index].m_colorID[0] == (int) pixels[0] && (int) this.paths[this.selectedPath].nodes[index].m_colorID[1] == (int) pixels[1] && (int) this.paths[this.selectedPath].nodes[index].m_colorID[2] == (int) pixels[2] && this.paths[this.selectedPath].nodes[index].type != ObjectType.SPath)
            this.selectedNodes.Add(index);
        }
      }
      GL.PopMatrix();
    }

    public bool linkNode(int x, int y, GLCamera cam)
    {
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      GL.LoadMatrix(cam.GetWorldToViewMatrix());
      bool flag1 = false;
      if (this.selectedPath != -1)
      {
        int index1 = -1;
        bool flag2 = false;
        if (this.selectedNodes.Count == 1)
          index1 = this.selectedNodes[0];
        else if (this.selectedSNodes.Count == 1)
        {
          index1 = this.selectedSNodes[0];
          flag2 = true;
        }
        if (index1 != -1)
        {
          this.pickPathNode(x, y, false, cam);
          int index2 = -1;
          if (this.selectedNodes.Count > 0)
          {
            if (this.selectedNodes.Count<int>() == 1)
              index2 = this.selectedNodes[0];
            if (this.selectedSNodes.Count<int>() == 1)
              index2 = this.selectedSNodes[0];
            if (this.paths[this.selectedPath].nodes[index1].nodeOutUID != (short) 0)
            {
              foreach (ObjectData node in this.paths[this.selectedPath].nodes)
              {
                if ((int) this.paths[this.selectedPath].nodes[index1].nodeOutUID == (int) node.uid)
                  node.node_in = false;
              }
            }
            this.paths[this.selectedPath].nodes[index1].nodeOutUID = this.paths[this.selectedPath].nodes[index2].uid;
            this.paths[this.selectedPath].nodes[index1].obj18 = (byte) ((int) this.paths[this.selectedPath].nodes[index1].nodeOutUID / 16 & (int) byte.MaxValue);
            this.paths[this.selectedPath].nodes[index1].node_out = true;
            this.paths[this.selectedPath].nodes[index2].node_in = true;
            flag1 = true;
            this.selectedNodes.Clear();
            this.selectedSNodes.Clear();
            if (flag2)
              this.selectedSNodes.Add(index1);
            else
              this.selectedNodes.Add(index1);
          }
          this.selectedNodes.Clear();
          this.selectedSNodes.Clear();
          if (flag2)
            this.selectedSNodes.Add(index1);
          else
            this.selectedNodes.Add(index1);
        }
      }
      GL.PopMatrix();
      return flag1;
    }

    public void pickObjectForPath(int x, int y, GLCamera cam)
    {
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      GL.LoadMatrix(cam.GetWorldToViewMatrix());
      if (this.selectedPath != -1 && this.objects.Count > 0 && this.paths[this.selectedPath].nodes.Count > 0)
      {
        int index1 = 0;
        byte[] numArray = this.core.BackBufferSelect(x, y, this.pickDList);
        for (int index2 = 0; index2 < this.objects.Count; ++index2)
        {
          if (this.objects[index2].name != "" && this.objects[index2].type == ObjectType.Normal && (int) this.objects[index2].m_colorID[0] == (int) numArray[0] && (int) this.objects[index2].m_colorID[1] == (int) numArray[1] && (int) this.objects[index2].m_colorID[2] == (int) numArray[2])
          {
            index1 = index2;
            break;
          }
        }
        if (this.paths[this.selectedPath].pathObject != -1)
        {
          this.objects[index1].obj16 = this.objects[this.paths[this.selectedPath].pathObject].obj16;
          this.objects[index1].obj17 = this.objects[this.paths[this.selectedPath].pathObject].obj17;
          this.objects[index1].uid = this.objects[this.paths[this.selectedPath].pathObject].uid;
          this.objects[this.paths[this.selectedPath].pathObject].obj16 = (byte) 0;
          this.objects[this.paths[this.selectedPath].pathObject].obj17 = (byte) 0;
          this.objects[this.paths[this.selectedPath].pathObject].obj18 = (byte) 0;
          this.objects[this.paths[this.selectedPath].pathObject].nodeOutUID = (short) 0;
          this.objects[this.paths[this.selectedPath].pathObject].uid = (short) 0;
        }
        if (!this.paths[this.selectedPath].IsPathLooped())
        {
          int firstNode = this.paths[this.selectedPath].GetFirstNode();
          if (firstNode != -1)
            this.LinkObjectToNode(this.objects[index1], firstNode);
        }
        else if (this.selectedNodes.Count > 0)
          this.LinkObjectToNode(this.objects[index1], this.selectedNodes[0]);
        else
          this.LinkObjectToNode(this.objects[index1], this.selectedSNodes[0]);
        this.paths[this.selectedPath].pathObject = index1;
        this.redrawSelectedPath();
        this.renderPicking();
      }
      this.pmode = PathMode.None;
      GL.PopMatrix();
      this.pushSetupStack("PathMode: Assigned Object");
    }

    private void LinkObjectToNode(ObjectData o, int node)
    {
      o.nodeOutUID = this.paths[this.selectedPath].nodes[node].uid;
      ObjectData objectData = o;
      objectData.obj18 = (byte) ((int) objectData.nodeOutUID / 16 & (int) byte.MaxValue);
      this.paths[this.selectedPath].nodes[node].node_in = true;
    }

    public void pickColorOBJ(int x, int y, bool multiselect)
    {
      List<int> first1 = new List<int>((IEnumerable<int>) this.selectedObjects);
      List<int> first2 = new List<int>((IEnumerable<int>) this.selectedStructs);
      if (!multiselect)
        this.resetPick();
      this.selectBackBufferObject(this.core.BackBufferSelect(x, y, this.pickDList));
      List<int> selectedObjects = this.selectedObjects;
      if (!first1.SequenceEqual<int>((IEnumerable<int>) selectedObjects))
        return;
      first2.SequenceEqual<int>((IEnumerable<int>) this.selectedStructs);
    }

    public void pickRectSelect(Point p1, Point p2, Mode mode)
    {
      if (mode == Mode.Path && this.selectedPath == -1)
        return;
      BKPath p = new BKPath();
      if (mode == Mode.Path && this.selectedPath != -1)
        p = this.paths[this.selectedPath];
      byte[] numArray = this.core.pickRectSelect(p1, p2, mode, this.pickDList, p);
      List<int> first1 = new List<int>((IEnumerable<int>) this.selectedObjects);
      List<int> first2 = new List<int>((IEnumerable<int>) this.selectedStructs);
      List<int> first3 = new List<int>((IEnumerable<int>) this.selectedNodes);
      List<int> first4 = new List<int>((IEnumerable<int>) this.selectedSNodes);
      List<int> intList = new List<int>();
      int num1 = (p2.X - p1.X + 1) * (p2.Y - p1.Y + 1) * 3 + 3;
      for (int index = 0; index < num1; index += 3)
      {
        int num2 = (int) numArray[index] + ((int) numArray[index + 1] << 8) + ((int) numArray[index + 2] << 16);
        if (num2 > 0 && !intList.Contains(num2))
        {
          if (mode == Mode.Object)
            this.selectBackBufferObject(new byte[3]
            {
              numArray[index],
              numArray[index + 1],
              numArray[index + 2]
            });
          if (mode == Mode.Path)
            this.selectBackBufferNode(new byte[3]
            {
              numArray[index],
              numArray[index + 1],
              numArray[index + 2]
            });
          intList.Add(num2);
        }
      }
      if (mode == Mode.Object && first1.SequenceEqual<int>((IEnumerable<int>) this.selectedObjects))
        first2.SequenceEqual<int>((IEnumerable<int>) this.selectedStructs);
      if (mode != Mode.Path || !first3.SequenceEqual<int>((IEnumerable<int>) this.selectedNodes))
        return;
      first4.SequenceEqual<int>((IEnumerable<int>) this.selectedSNodes);
    }

    public void selectBackBufferObject(byte[] pixel)
    {
      int index1 = -1;
      int num = -1;
      for (int index2 = 0; index2 < this.objects.Count; ++index2)
      {
        ObjectData objectData = this.objects[index2];
        if ((int) objectData.m_colorID[0] == (int) pixel[0] && (int) objectData.m_colorID[1] == (int) pixel[1] && (int) objectData.m_colorID[2] == (int) pixel[2])
        {
          index1 = index2;
          num = 0;
          this.setInitValues(this.objects[index1]);
        }
      }
      if (index1 == -1)
      {
        for (int index3 = 0; index3 < this.structs.Count; ++index3)
        {
          ObjectData objectData = this.structs[index3];
          if ((int) objectData.m_colorID[0] == (int) pixel[0] && (int) objectData.m_colorID[1] == (int) pixel[1] && (int) objectData.m_colorID[2] == (int) pixel[2])
          {
            index1 = index3;
            break;
          }
        }
        if (index1 != -1)
        {
          num = 1;
          this.setInitValues(this.structs[index1]);
        }
      }
      if (index1 == -1)
        return;
      if (num == 0)
      {
        if (this.selectedObjects.Contains(index1))
          return;
        this.selectedObjects.Add(index1);
      }
      else
      {
        if (this.selectedStructs.Contains(index1))
          return;
        this.selectedStructs.Add(index1);
      }
    }

    public void selectBackBufferNode(byte[] pixel)
    {
      if (this.selectedPath == -1)
        return;
      for (int index = 0; index < this.paths[this.selectedPath].nodes.Count; ++index)
      {
        if (!this.selectedNodes.Contains(index) && !this.selectedSNodes.Contains(index) && (int) this.paths[this.selectedPath].nodes[index].m_colorID[0] == (int) pixel[0] && (int) this.paths[this.selectedPath].nodes[index].m_colorID[1] == (int) pixel[1] && (int) this.paths[this.selectedPath].nodes[index].m_colorID[2] == (int) pixel[2] && this.paths[this.selectedPath].nodes[index].type != ObjectType.SPath)
          this.selectedNodes.Add(index);
      }
    }

    public void pickCamera(int x, int y, GLCamera cam)
    {
      this.resetPick();
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      GL.LoadMatrix(cam.GetWorldToViewMatrix());
      byte[] numArray = this.core.BackBufferSelect(x, y, this.cameraPickDList);
      for (int index = 0; index < this.cameras.Count; ++index)
      {
        CameraObject camera = this.cameras[index];
        if ((int) camera.m_colorID[0] == (int) numArray[0] && (int) camera.m_colorID[1] == (int) numArray[1] && (int) camera.m_colorID[2] == (int) numArray[2])
          this.selectedCam = index;
      }
      GL.PopMatrix();
      this.InitGl();
      this.renderPicking();
    }

    public void setInitValues(ObjectData obj)
    {
      this.oldR = obj.rot;
      this.oldS = obj.size;
      this.oldX = obj.locX;
      this.oldY = obj.locY;
      this.oldZ = obj.locZ;
      this.oldRad = obj.radius;
    }

    public double[] ScreenToWorld(int x, int y, GLCamera cam)
    {
      this.core.ClearScreenAndLoadIdentity();
      GL.PushMatrix();
      GL.LoadMatrix(cam.GetWorldToViewMatrix());
      GL.CallList(this.levelDList);
      GL.CallList(this.levelBDList);
      int[] numArray1 = new int[4];
      double[] numArray2 = new double[16];
      double[] numArray3 = new double[16];
      GL.GetInteger(GetPName.Viewport, numArray1);
      GL.GetDouble(GetPName.Modelview0MatrixExt, numArray2);
      GL.GetDouble(GetPName.ProjectionMatrix, numArray3);
      int num1 = numArray1[3];
      int num2 = x;
      int num3 = y;
      int num4 = num1 - num3;
      float[] pixels = new float[1];
      GL.ReadPixels<float>(num2, num4, 1, 1, PixelFormat.DepthComponent, PixelType.Float, pixels);
      double objX = 0.0;
      double objY = 0.0;
      double objZ = 0.0;
      Glu.gluUnProject((double) num2, (double) num4, (double) pixels[0], numArray2, numArray3, numArray1, out objX, out objY, out objZ);
      GL.PopMatrix();
      if ((double) pixels[0] == 1.0)
      {
        GL.PushMatrix();
        GL.Translate(0.0f, 0.0f, -2000f);
        this.core.DrawInvisibleWall();
        GL.PopMatrix();
        GL.ReadPixels<float>(num2, num4, 1, 1, PixelFormat.DepthComponent, PixelType.Float, pixels);
        objX = 0.0;
        objY = 0.0;
        objZ = 0.0;
        Glu.gluUnProject((double) num2, (double) num4, (double) pixels[0], numArray2, numArray3, numArray1, out objX, out objY, out objZ);
      }
      return new double[3]{ objX, objY, objZ };
    }

    public void drawCameraPicking(CameraObject cam) => this.cameraPickDList.Add(this.core.drawCameraPicking(cam));

    public void DrawObjectPicking(ObjectData obj)
    {
      double num = (double) obj.size / 100.0;
      if (!File.Exists(this.dir + obj.pointer.ToString("x")))
      {
        try
        {
          RomHandler.DecompressFileToHDD(obj.pointer);
        }
        catch (Exception ex)
        {
        }
      }
      if (obj.pointer2 != 0)
      {
        if (!File.Exists(this.dir + obj.pointer2.ToString("x")))
        {
          try
          {
            RomHandler.DecompressFileToHDD(obj.pointer2);
          }
          catch (Exception ex)
          {
          }
        }
      }
      if (File.Exists(this.dir + obj.pointer.ToString("x")))
        this.core.DrawModelFilePicking(this.dir + obj.pointer.ToString("x"), (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, (float) obj.size);
      if (!File.Exists(this.dir + obj.pointer2.ToString("x")))
        return;
      this.core.DrawModelFilePicking(this.dir + obj.pointer2.ToString("x"), (float) obj.locX, (float) obj.locY, (float) obj.locZ, (int) obj.rot, (float) obj.size);
    }

    public void ReadSetupFile(string file_)
    {
      this.setupFileReader.init(file_);
      ArrayList arrayList = this.setupFileReader.ReadSetupFile();
      this.objects = (List<ObjectData>) arrayList[0];
      this.structs = (List<ObjectData>) arrayList[1];
      this.camBytes = (List<byte>) arrayList[2];
      this.cameras = (List<CameraObject>) arrayList[3];
      this.currentPath = 32;
      for (int index1 = 0; index1 < this.objects.Count; ++index1)
      {
        if (this.objects[index1].type == ObjectType.SPath)
        {
          for (int index2 = 0; index2 < this.objects.Count; ++index2)
          {
            if (this.objects[index2].type == ObjectType.Path && (((int) this.objects[index2].obj16 * 256 + (int) this.objects[index2].obj17) / 16 & (int) byte.MaxValue) == (int) this.objects[index1].obj18)
            {
              this.objects[index1].locX = this.objects[index2].locX;
              this.objects[index1].locY = this.objects[index2].locY;
              this.objects[index1].locZ = this.objects[index2].locZ;
            }
          }
        }
      }
      this.paths.Clear();
      this.extractPaths();
      this.setSPathLocations();
    }

    private void setSPathLocations()
    {
      for (int index1 = 0; index1 < this.paths.Count; ++index1)
      {
        for (int index2 = 0; index2 < this.paths[index1].nodes.Count; ++index2)
        {
          if (this.paths[index1].nodes[index2].type == ObjectType.SPath)
          {
            if (index2 == 0)
            {
              for (int index3 = 0; index3 < this.paths[index1].nodes.Count; ++index3)
              {
                if (this.paths[index1].nodes[index3].type == ObjectType.Path)
                {
                  this.paths[index1].nodes[index2].locX = this.paths[index1].nodes[index3].locX;
                  this.paths[index1].nodes[index2].locY = this.paths[index1].nodes[index3].locY;
                  this.paths[index1].nodes[index2].locZ = this.paths[index1].nodes[index3].locZ;
                  break;
                }
              }
            }
            else
            {
              this.paths[index1].nodes[index2].locX = this.paths[index1].nodes[index2 - 1].locX;
              this.paths[index1].nodes[index2].locY = this.paths[index1].nodes[index2 - 1].locY;
              this.paths[index1].nodes[index2].locZ = this.paths[index1].nodes[index2 - 1].locZ;
            }
          }
        }
      }
    }

    private void drawSelectedPathController()
    {
      try
      {
        List<int> intList1 = new List<int>();
        List<int> intList2 = new List<int>();
        short nodeOutUid = this.objects[this.paths[this.selectedPath].pathObject].nodeOutUID;
        bool flag = false;
        for (int index = 0; index < this.paths[this.selectedPath].nodes.Count; ++index)
        {
          ObjectData node = this.paths[this.selectedPath].nodes[index];
          if ((int) node.uid == (int) nodeOutUid)
          {
            if (node.type == ObjectType.Path)
              intList1.Add(index);
            intList2.Add((int) node.uid);
            nodeOutUid = node.nodeOutUID;
            if (intList2.Contains((int) nodeOutUid))
            {
              flag = true;
              break;
            }
            index = -1;
          }
        }
        int num1 = flag ? 1 : 0;
        double num2;
        int index1 = (int) Math.Floor(num2 = (double) this.paths[this.selectedPath].nodes[this.selectedSNodes[0]].activationPercent * (double) (intList1.Count - 1));
        float num3 = (float) (num2 % 1.0);
        ObjectData node1 = this.paths[this.selectedPath].nodes[intList1[index1]];
        ObjectData node2 = this.paths[this.selectedPath].nodes[intList1[index1]];
        ObjectData objectData = index1 != intList1.Count - 1 ? this.paths[this.selectedPath].nodes[intList1[index1 + 1]] : this.paths[this.selectedPath].nodes[intList1[0]];
        float num4 = (float) ((int) objectData.locX - (int) node1.locX);
        float num5 = (float) ((int) objectData.locY - (int) node1.locY);
        float num6 = (float) ((int) objectData.locZ - (int) node1.locZ);
        float num7 = num4 * num3;
        float num8 = num5 * num3;
        float num9 = num6 * num3;
        this.core.DrawPathController((float) node1.locX + num7, (float) node1.locY + num8, (float) node1.locZ + num9);
      }
      catch
      {
      }
    }

    private void extractPaths()
    {
      try
      {
        List<ObjectData> nodes1 = new List<ObjectData>();
        for (int index = 0; index < this.objects.Count; ++index)
        {
          this.UIDs.Add(this.objects[index].uid);
          if (this.objects[index].type == ObjectType.Path || this.objects[index].type == ObjectType.SPath)
          {
            nodes1.Add(this.objects[index]);
            this.objects.RemoveAt(index);
            --index;
          }
        }
        for (int index = 0; index < this.objects.Count; ++index)
        {
          byte id = byte.MaxValue;
          if (this.objects[index].obj18 > (byte) 0)
          {
            BKPath bkPath = new BKPath();
            bkPath.pathObject = index;
            ObjectData nodesPartner1 = this.findNodesPartner(nodes1, this.objects[index], this.objects[index].obj18);
            if (nodesPartner1 != null)
            {
              if (nodesPartner1.type == ObjectType.SPath)
                id = nodesPartner1.pathID;
              nodesPartner1.node_in = true;
              bkPath.nodes.Add(nodesPartner1);
              this.objects[index].nodeOutUID = nodesPartner1.uid;
              bool flag = false;
              while (!flag)
              {
                ObjectData nodesPartner2 = this.findNodesPartner(nodes1, bkPath.nodes[bkPath.nodes.Count - 1], bkPath.nodes[bkPath.nodes.Count - 1].obj18);
                if (nodesPartner2 != null)
                {
                  bkPath.nodes[bkPath.nodes.Count - 1].nodeOutUID = nodesPartner2.uid;
                  bkPath.nodes.Add(nodesPartner2);
                  if (nodesPartner2.type == ObjectType.SPath)
                    id = nodesPartner2.pathID;
                }
                else
                  flag = true;
              }
              if (id != byte.MaxValue && id != (byte) 0)
                bkPath.nodes.AddRange((IEnumerable<ObjectData>) this.findSNodes(nodes1, id));
              if (bkPath.nodes.Count > 0)
                this.paths.Add(bkPath);
            }
          }
        }
        for (int index1 = 0; index1 < nodes1.Count; ++index1)
        {
          List<int> matches = new List<int>();
          for (int index2 = 0; index2 < nodes1.Count; ++index2)
          {
            if ((int) nodes1[index1].obj18 == (((int) nodes1[index2].obj16 * 256 + (int) nodes1[index2].obj17) / 16 & (int) byte.MaxValue) && !nodes1[index2].node_in)
              matches.Add(index2);
          }
          if (matches.Count > 0)
          {
            List<ObjectData> nodes2 = nodes1;
            int bestNodeMatch = this.findBestNodeMatch(nodes2, nodes2[index1], matches);
            nodes1[matches[bestNodeMatch]].node_in = true;
            nodes1[index1].nodeOutUID = nodes1[matches[bestNodeMatch]].uid;
          }
          matches.Clear();
        }
        while (nodes1.Count > 0)
        {
          BKPath bkPath = new BKPath();
          bkPath.nodes.Add(nodes1[0]);
          nodes1.RemoveAt(0);
          for (int index3 = 0; index3 < nodes1.Count; ++index3)
          {
            bool flag = false;
            for (int index4 = 0; index4 < bkPath.nodes.Count && !flag; ++index4)
            {
              if ((int) bkPath.nodes[index4].nodeOutUID == (int) nodes1[index3].uid)
              {
                bkPath.nodes.Add(nodes1[index3]);
                nodes1.RemoveAt(index3);
                index3 = -1;
                flag = true;
              }
              if (!flag && (int) nodes1[index3].nodeOutUID == (int) bkPath.nodes[index4].uid)
              {
                bkPath.nodes.Add(nodes1[index3]);
                nodes1.RemoveAt(index3);
                index3 = -1;
                flag = true;
              }
            }
          }
          this.paths.Add(bkPath);
        }
        for (int index = 0; index < this.paths.Count; ++index)
        {
          if (this.paths[index].nodes[this.paths[index].nodes.Count - 1].obj18 != (byte) 0)
          {
            ObjectData node = this.paths[index].nodes[this.paths[index].nodes.Count - 1];
            node.node_out = true;
            node.nodeOutUID = (short) ((int) node.obj18 << 4);
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    private List<ObjectData> findSNodes(List<ObjectData> nodes, byte id)
    {
      List<ObjectData> snodes = new List<ObjectData>();
      for (int index = 0; index < nodes.Count; ++index)
      {
        if (nodes[index].type == ObjectType.SPath && (int) id == (int) nodes[index].pathID)
        {
          snodes.Add(nodes[index]);
          nodes.RemoveAt(index);
          --index;
        }
      }
      return snodes;
    }

    private ObjectData findNodesPartner(List<ObjectData> nodes, ObjectData node, byte to)
    {
      List<int> matches = new List<int>();
      for (int index = 0; index < nodes.Count; ++index)
      {
        if ((int) to == ((int) nodes[index].uid / 16 & (int) byte.MaxValue))
          matches.Add(index);
      }
      if (matches.Count <= 0)
        return (ObjectData) null;
      int bestNodeMatch = this.findBestNodeMatch(nodes, node, matches);
      ObjectData node1 = nodes[matches[bestNodeMatch]];
      nodes.RemoveAt(matches[bestNodeMatch]);
      return node1;
    }

    private int findBestNodeMatch(List<ObjectData> nodes, ObjectData node, List<int> matches)
    {
      int bestNodeMatch = 0;
      if (matches.Count > 0)
      {
        ObjectData node1 = nodes[matches[0]];
        float num1 = float.MaxValue;
        for (int index = 0; index < matches.Count; ++index)
        {
          float num2 = (float) Math.Sqrt(Math.Pow((double) ((int) nodes[matches[index]].locX - (int) node.locX), 2.0) + Math.Pow((double) ((int) nodes[matches[index]].locY - (int) node.locY), 2.0) + Math.Pow((double) ((int) nodes[matches[index]].locZ - (int) node.locZ), 2.0));
          if ((double) num1 > (double) num2)
          {
            num1 = num2;
            ObjectData node2 = nodes[matches[index]];
            bestNodeMatch = index;
          }
        }
      }
      return bestNodeMatch;
    }

    public int GetListDec(string file_) => this.setupFileReader.GetListDec(file_, 0);

    public void AddObj(ObjectData data_) => this.objects.Add(data_);

    public void AddStruct(ObjectData data_) => this.structs.Add(data_);

    public void AddCamera(CameraObject data_) => this.cameras.Add(data_);

    public void DeleteAllStructs() => this.structs.Clear();

    public void DeleteAllCameras() => this.cameras.Clear();

    public void DeleteAllObjects()
    {
      this.usedJiggyFlags.Clear();
      this.usedMTFlags.Clear();
      this.usedHCFlags.Clear();
      this.objects.Clear();
      this.selectedCam = -1;
      this.selectedObjects.Clear();
      this.selectedStructs.Clear();
      this.paths.Clear();
      this.UIDs.Clear();
      this.PathIDs.Clear();
      this.selectedPath = -1;
    }

    private void reIndexList(int y)
    {
      for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
      {
        if (this.selectedObjects[index] > y)
          this.selectedObjects[index]--;
      }
      for (int index = 0; index < this.paths.Count<BKPath>(); ++index)
      {
        if (this.paths[index].pathObject > y)
          --this.paths[index].pathObject;
      }
    }

    public void DeleteSelectedObjects()
    {
      this.selectedObjects.Sort();
      this.selectedObjects.Reverse();
      this.selectedStructs.Sort();
      this.selectedStructs.Reverse();
      for (int index1 = 0; index1 < this.selectedObjects.Count<int>(); ++index1)
      {
        string[] strArray = new string[3]
        {
          "Jiggy",
          "Mumbo Token",
          "Empty Honeycomb"
        };
        foreach (string str in strArray)
        {
          if (this.objects[this.selectedObjects[index1]].name == str && this.objects[this.selectedObjects[index1]].flag != -1)
          {
            for (int index2 = 0; index2 < this.objects.Count; ++index2)
            {
              if (this.objects[index2].name.Contains(str + " Flag") && (int) this.objects[index2].objectID == this.objects[this.selectedObjects[index1]].flag && !this.selectedObjects.Contains(index2))
              {
                this.objects.RemoveAt(index2);
                this.objectsDList.RemoveAt(index2);
                if (str == "Jiggy")
                  this.usedJiggyFlags.Remove((int) this.objects[index2].objectID);
                if (str == "Mumbo Token")
                  this.usedMTFlags.Remove((int) this.objects[index2].objectID);
                if (str == "Empty Honeycomb")
                  this.usedHCFlags.Remove((int) this.objects[index2].objectID);
                this.reIndexList(index2);
              }
            }
          }
        }
        if (this.objects[this.selectedObjects[index1]].type == ObjectType.Flag)
        {
          string name = this.objects[this.selectedObjects[index1]].name;
          if (name == "Jiggy Flag")
            this.usedJiggyFlags.Remove((int) this.objects[this.selectedObjects[index1]].objectID);
          if (name == "Mumbo Token Flag")
            this.usedMTFlags.Remove((int) this.objects[this.selectedObjects[index1]].objectID);
          if (name == "Empty Honeycomb Flag")
            this.usedHCFlags.Remove((int) this.objects[this.selectedObjects[index1]].objectID);
        }
        this.objects.RemoveAt(this.selectedObjects[index1]);
        this.objectsDList.RemoveAt(this.selectedObjects[index1]);
      }
      for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
      {
        this.structs.RemoveAt(this.selectedStructs[index]);
        this.structsDList.RemoveAt(this.selectedStructs[index]);
      }
      if (this.selectedCam != -1)
      {
        this.cameras.RemoveAt(this.selectedCam);
        this.cameraDList.RemoveAt(this.selectedCam);
      }
      for (int index = 0; index < this.paths.Count<BKPath>(); ++index)
      {
        if (this.selectedObjects.Contains(this.paths[index].pathObject))
          this.paths[index].pathObject = -1;
        foreach (int selectedObject in this.selectedObjects)
        {
          if (this.paths[index].pathObject > selectedObject)
            --this.paths[index].pathObject;
        }
      }
      this.selectedObjects.Clear();
      this.selectedStructs.Clear();
      this.selectedCam = -1;
      this.PairObjectsWithFlags();
    }

    public void updateScaleForSelectedObjects(short s)
    {
      for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
      {
        int selectedObject = this.selectedObjects[index];
        if (this.objects[selectedObject].radius == (ushort) 0)
        {
          this.objects[selectedObject].size += s;
          if (this.objects[selectedObject].size < (short) 10)
            this.objects[selectedObject].size = (short) 10;
          if (this.objects[selectedObject].size > (short) 800)
            this.objects[selectedObject].size = (short) 800;
        }
        else
        {
          this.objects[selectedObject].radius += (ushort) s;
          if (this.objects[selectedObject].radius < (ushort) 10)
            this.objects[selectedObject].radius = (ushort) 10;
          if (this.objects[selectedObject].radius > (ushort) 511)
            this.objects[selectedObject].radius = (ushort) 511;
        }
      }
      for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
      {
        int selectedStruct = this.selectedStructs[index];
        if (this.structs[selectedStruct].radius == (ushort) 0)
        {
          this.structs[selectedStruct].size += s;
          if (this.structs[selectedStruct].size < (short) 10)
            this.structs[selectedStruct].size = (short) 10;
          if (this.structs[selectedStruct].size > (short) 800)
            this.structs[selectedStruct].size = (short) 800;
        }
        else
        {
          this.structs[selectedStruct].radius += (ushort) s;
          if (this.structs[selectedStruct].radius < (ushort) 10)
            this.structs[selectedStruct].radius = (ushort) 10;
          if (this.structs[selectedStruct].radius > (ushort) 511)
            this.structs[selectedStruct].radius = (ushort) 511;
        }
      }
    }

    public void updateRotateForSelectedObjects(short r)
    {
      for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
      {
        int selectedObject = this.selectedObjects[index];
        this.objects[selectedObject].rot += r;
        if (this.objects[selectedObject].rot < (short) 0)
          this.objects[selectedObject].rot = (short) 360;
        if (this.objects[selectedObject].rot > (short) 360)
          this.objects[selectedObject].rot = (short) 0;
      }
      for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
      {
        int selectedStruct = this.selectedStructs[index];
        this.structs[selectedStruct].rot += r;
        if (this.structs[selectedStruct].rot < (short) 0)
          this.structs[selectedStruct].rot = (short) 360;
        if (this.structs[selectedStruct].rot > (short) 360)
          this.structs[selectedStruct].rot = (short) 0;
      }
    }

    public void duplicateSelectedObjects(short x, short y, short z)
    {
      short[] forSelectedObjects = this.getCenterPointForSelectedObjects(x, y, z, Mode.Object);
      for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
      {
        int selectedObject = this.selectedObjects[index];
        ObjectData o = new ObjectData(this.objects[selectedObject].objectID, 0, (short) ((int) this.objects[selectedObject].locX + (int) forSelectedObjects[0]), (short) ((int) this.objects[selectedObject].locY + (int) forSelectedObjects[1]), (short) ((int) this.objects[selectedObject].locZ + (int) forSelectedObjects[2]), this.objects[selectedObject].rot, this.objects[selectedObject].size, this.objects[selectedObject].specialScript);
        if (o.type == ObjectType.Normal)
          this.FillObjectDetails(ref o);
        this.objects.Add(o);
      }
      for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
      {
        int selectedStruct = this.selectedStructs[index];
        ObjectData o = new ObjectData(this.structs[selectedStruct].objectID, 0, (short) ((int) this.structs[selectedStruct].locX + (int) forSelectedObjects[0]), (short) ((int) this.structs[selectedStruct].locY + (int) forSelectedObjects[1]), (short) ((int) this.structs[selectedStruct].locZ + (int) forSelectedObjects[2]), this.structs[selectedStruct].rot, this.structs[selectedStruct].size, this.structs[selectedStruct].specialScript);
        this.FillObjectDetails(ref o);
        this.structs.Add(o);
      }
      this.RenderStructs();
      this.RenderObjects();
    }

    private short[] getCenterPointForSelectedObjects(short x, short y, short z, Mode mode)
    {
      int[] numArray1 = new int[3]
      {
        int.MaxValue,
        int.MaxValue,
        int.MaxValue
      };
      int[] numArray2 = new int[3]
      {
        int.MinValue,
        int.MinValue,
        int.MinValue
      };
      int[] numArray3 = new int[3];
      if (mode == Mode.Object)
      {
        for (int index = 0; index < this.selectedObjects.Count<int>(); ++index)
        {
          numArray2[0] = (int) this.objects[this.selectedObjects[index]].locX > numArray2[0] ? (int) this.objects[this.selectedObjects[index]].locX : numArray2[0];
          numArray2[1] = (int) this.objects[this.selectedObjects[index]].locY > numArray2[1] ? (int) this.objects[this.selectedObjects[index]].locY : numArray2[1];
          numArray2[2] = (int) this.objects[this.selectedObjects[index]].locZ > numArray2[2] ? (int) this.objects[this.selectedObjects[index]].locZ : numArray2[2];
          numArray1[0] = (int) this.objects[this.selectedObjects[index]].locX < numArray1[0] ? (int) this.objects[this.selectedObjects[index]].locX : numArray1[0];
          numArray1[1] = (int) this.objects[this.selectedObjects[index]].locY < numArray1[1] ? (int) this.objects[this.selectedObjects[index]].locY : numArray1[1];
          numArray1[2] = (int) this.objects[this.selectedObjects[index]].locZ < numArray1[2] ? (int) this.objects[this.selectedObjects[index]].locZ : numArray1[2];
        }
        for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
        {
          numArray2[0] = (int) this.structs[this.selectedStructs[index]].locX > numArray2[0] ? (int) this.structs[this.selectedStructs[index]].locX : numArray2[0];
          numArray2[1] = (int) this.structs[this.selectedStructs[index]].locY > numArray2[1] ? (int) this.structs[this.selectedStructs[index]].locY : numArray2[1];
          numArray2[2] = (int) this.structs[this.selectedStructs[index]].locZ > numArray2[2] ? (int) this.structs[this.selectedStructs[index]].locZ : numArray2[2];
          numArray1[0] = (int) this.structs[this.selectedStructs[index]].locX < numArray1[0] ? (int) this.structs[this.selectedStructs[index]].locX : numArray1[0];
          numArray1[1] = (int) this.structs[this.selectedStructs[index]].locY < numArray1[1] ? (int) this.structs[this.selectedStructs[index]].locY : numArray1[1];
          numArray1[2] = (int) this.structs[this.selectedStructs[index]].locZ < numArray1[2] ? (int) this.structs[this.selectedStructs[index]].locZ : numArray1[2];
        }
      }
      if (mode == Mode.Path)
      {
        for (int index = 0; index < this.selectedNodes.Count<int>(); ++index)
        {
          ObjectData node = this.paths[this.selectedPath].nodes[this.selectedNodes[index]];
          numArray2[0] = (int) node.locX > numArray2[0] ? (int) node.locX : numArray2[0];
          numArray2[1] = (int) node.locY > numArray2[1] ? (int) node.locY : numArray2[1];
          numArray2[2] = (int) node.locZ > numArray2[2] ? (int) node.locZ : numArray2[2];
          numArray1[0] = (int) node.locX < numArray1[0] ? (int) node.locX : numArray1[0];
          numArray1[1] = (int) node.locY < numArray1[1] ? (int) node.locY : numArray1[1];
          numArray1[2] = (int) node.locZ < numArray1[2] ? (int) node.locZ : numArray1[2];
        }
        for (int index = 0; index < this.selectedSNodes.Count<int>(); ++index)
        {
          ObjectData node = this.paths[this.selectedPath].nodes[this.selectedSNodes[index]];
          numArray2[0] = (int) node.locX > numArray2[0] ? (int) node.locX : numArray2[0];
          numArray2[1] = (int) node.locY > numArray2[1] ? (int) node.locY : numArray2[1];
          numArray2[2] = (int) node.locZ > numArray2[2] ? (int) node.locZ : numArray2[2];
          numArray1[0] = (int) node.locX < numArray1[0] ? (int) node.locX : numArray1[0];
          numArray1[1] = (int) node.locY < numArray1[1] ? (int) node.locY : numArray1[1];
          numArray1[2] = (int) node.locZ < numArray1[2] ? (int) node.locZ : numArray1[2];
        }
      }
      for (int index = 0; index < 3; ++index)
        numArray3[index] = (numArray2[index] + numArray1[index]) / 2;
      return new short[3]
      {
        (short) ((int) x - numArray3[0]),
        (short) ((int) y - numArray3[1]),
        (short) ((int) z - numArray3[2])
      };
    }

    public void updateLocationForSelectedObjects(
      short x,
      short y,
      short z,
      bool ux,
      bool uy,
      bool uz,
      short yOffset)
    {
      short[] forSelectedObjects = this.getCenterPointForSelectedObjects(x, y, z, Mode.Object);
      this.selectedObjects.Sort();
      this.selectedObjects.Reverse();
      this.selectedStructs.Sort();
      this.selectedStructs.Reverse();
      for (int index1 = 0; index1 < this.selectedObjects.Count<int>(); ++index1)
      {
        string[] strArray = new string[3]
        {
          "Jiggy",
          "Mumbo Token",
          "Empty Honeycomb"
        };
        foreach (string str in strArray)
        {
          if (this.objects[this.selectedObjects[index1]].name == str && this.objects[this.selectedObjects[index1]].flag != -1)
          {
            for (int index2 = 0; index2 < this.objects.Count; ++index2)
            {
              if (this.objects[index2].name.Contains(str + " Flag") && (int) this.objects[index2].objectID == this.objects[this.selectedObjects[index1]].flag && !this.selectedObjects.Contains(index2))
              {
                if (ux)
                  this.objects[index2].locX += forSelectedObjects[0];
                if (uy)
                  this.objects[index2].locY += (short) ((int) forSelectedObjects[1] + (int) yOffset);
                if (uz)
                  this.objects[index2].locZ += forSelectedObjects[2];
                GL.DeleteLists(this.objectsDList[index2], 1);
                this.objectsDList[index2] = (uint) GL.GenLists(1);
                GL.NewList(this.objectsDList[index2], ListMode.Compile);
                this.drawHelper(this.objects[index2], true, false);
                GL.Disable(EnableCap.Texture2D);
                GL.EndList();
                GL.Flush();
              }
            }
          }
        }
        int selectedObject = this.selectedObjects[index1];
        if (ux)
          this.objects[selectedObject].locX += forSelectedObjects[0];
        if (uy)
          this.objects[selectedObject].locY += (short) ((int) forSelectedObjects[1] + (int) yOffset);
        if (uz)
          this.objects[selectedObject].locZ += forSelectedObjects[2];
      }
      for (int index = 0; index < this.selectedStructs.Count<int>(); ++index)
      {
        int selectedStruct = this.selectedStructs[index];
        if (ux)
          this.structs[selectedStruct].locX += forSelectedObjects[0];
        if (uy)
          this.structs[selectedStruct].locY += (short) ((int) forSelectedObjects[1] + (int) yOffset);
        if (uz)
          this.structs[selectedStruct].locZ += forSelectedObjects[2];
      }
      if (this.selectedCam == -1)
        return;
      if (ux)
        this.cameras[this.selectedCam].x = (float) x;
      if (uy)
        this.cameras[this.selectedCam].y = (float) ((int) y + (int) yOffset);
      if (!uz)
        return;
      this.cameras[this.selectedCam].z = (float) z;
    }

    public void InitGl() => Core.InitGl();
  }
}
