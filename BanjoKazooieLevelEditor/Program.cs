// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.Program
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      try
      {
        Application.Run((Form) new Form1());
      }
      catch
      {
      }
    }
  }
}
