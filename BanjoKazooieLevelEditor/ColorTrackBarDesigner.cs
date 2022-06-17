// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ColorTrackBarDesigner
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System.Collections;
using System.Windows.Forms.Design;

namespace BanjoKazooieLevelEditor
{
  internal class ColorTrackBarDesigner : ControlDesigner
  {
    protected override void PostFilterProperties(IDictionary Properties)
    {
      Properties.Remove((object) "AllowDrop");
      Properties.Remove((object) "BackgroundImage");
      Properties.Remove((object) "ContextMenu");
      Properties.Remove((object) "FlatStyle");
      Properties.Remove((object) "Image");
      Properties.Remove((object) "ImageAlign");
      Properties.Remove((object) "ImageIndex");
      Properties.Remove((object) "ImageList");
      Properties.Remove((object) "Text");
      Properties.Remove((object) "TextAlign");
      Properties.Remove((object) "BackColor");
      Properties.Remove((object) "Font");
      Properties.Remove((object) "ForeColor");
      Properties.Remove((object) "Cursor");
    }

    protected override void PostFilterEvents(IDictionary events)
    {
      events.Remove((object) "Click");
      events.Remove((object) "DoubleClick");
      events.Remove((object) "Paint");
      events.Remove((object) "ChangeUICues");
      events.Remove((object) "ImeModeChanged");
      events.Remove((object) "QueryAccessibilityHelp");
      events.Remove((object) "StyleChanged");
      events.Remove((object) "SystemColorsChanged");
      events.Remove((object) "DragDrop");
      events.Remove((object) "DragEnter");
      events.Remove((object) "DragLeave");
      events.Remove((object) "DragOver");
      events.Remove((object) "GiveFeedback");
      events.Remove((object) "QueryContinueDrag");
      events.Remove((object) "DragDrop");
      events.Remove((object) "Layout");
      events.Remove((object) "Move");
      events.Remove((object) "Resize");
      events.Remove((object) "BackColorChanged");
      events.Remove((object) "BackgroundImageChanged");
      events.Remove((object) "BindingContextChanged");
      events.Remove((object) "CausesValidationChanged");
      events.Remove((object) "CursorChanged");
      events.Remove((object) "FontChanged");
      events.Remove((object) "ForeColorChanged");
      events.Remove((object) "RightToLeftChanged");
      events.Remove((object) "SizeChanged");
      events.Remove((object) "TextChanged");
      base.PostFilterEvents(events);
    }
  }
}
