// Decompiled with JetBrains decompiler
// Type: BanjoKazooieLevelEditor.ColorTrackBar
// Assembly: BanjoKazooieLevelEditor, Version=2.0.19.0, Culture=neutral, PublicKeyToken=null
// MVID: 9E4E8A9F-6E2F-4B24-B56C-5C2BF24BF813
// Assembly location: F:\BanjosBackpack\BB.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BanjoKazooieLevelEditor
{
  [Description("Color Track Bar")]
  [ToolboxBitmap(typeof (TrackBar))]
  public class ColorTrackBar : Control
  {
    private int trackSize = 25;
    private Poles maxSide = Poles.Right;
    private Rectangle trackRect = Rectangle.Empty;
    private int mousestartPos = -1;
    private bool leftbuttonDown;
    private Color barborderColor = Color.Black;
    private Color barColor = Color.White;
    private Color trackborderColor = Color.Black;
    private Color trackColor = Color.Red;
    private int borderWidth = 1;
    private int trackerValue = 25;
    private int barMinimum;
    private int barMaximum = 100;
    private Container components;
    private int infoBoxHeight = 15;

    [Description("Set Trackbar size")]
    [Category("ColorTrackBar")]
    public int TrackerSize
    {
      get => this.trackSize;
      set
      {
        this.trackSize = value > 0 ? value : throw new ArgumentException("value must be greater then zero");
        this.trackRect = Rectangle.Empty;
        this.Invalidate();
      }
    }

    [Description("Set Minimum value of the Track bar")]
    [Category("ColorTrackBar")]
    [RefreshProperties(RefreshProperties.All)]
    public int Minimum
    {
      set
      {
        this.barMinimum = value < this.barMaximum ? value : throw new ArgumentException("'" + (object) value + "' is not a valid value for 'Mimimum'.\n'Minimum' must be less than 'Maximum'.");
        if (this.trackerValue < this.barMinimum)
          this.trackerValue = value;
        this.trackRect = Rectangle.Empty;
        this.Invalidate();
      }
      get => this.barMinimum;
    }

    [Description("Set Maximum value of the Track bar")]
    [Category("ColorTrackBar")]
    [RefreshProperties(RefreshProperties.All)]
    public int Maximum
    {
      set
      {
        if (value <= this.barMinimum)
          throw new ArgumentException("'" + (object) value + "' is not a valid value for 'Maximum'.\n'Maximum' must be greater than 'Minimum'.");
        if (this.trackerValue > value)
          this.trackerValue = value;
        this.barMaximum = value;
        this.trackRect = Rectangle.Empty;
        this.Invalidate();
      }
      get => this.barMaximum;
    }

    [Description("Select the side of the control to represent the maximum range value")]
    [Category("ColorTrackBar")]
    public Poles MaximumValueSide
    {
      get => this.maxSide;
      set
      {
        this.maxSide = value != Poles.Top && value != Poles.Bottom ? value : throw new ArgumentException("Since your Orientation is set to Horizontal, you can only select Left or Right for this property");
        this.trackRect = Rectangle.Empty;
        this.Invalidate();
      }
    }

    [Description("Bar border color")]
    [Category("ColorTrackBar")]
    public Color BarBorderColor
    {
      set
      {
        this.barborderColor = value;
        this.Invalidate();
      }
      get => this.barborderColor;
    }

    [Description("Bar color")]
    [Category("ColorTrackBar")]
    public Color BarColor
    {
      set
      {
        this.barColor = value;
        this.Invalidate();
      }
      get => this.barColor;
    }

    [Description("Tracker border color")]
    [Category("ColorTrackBar")]
    public Color TrackerBorderColor
    {
      set
      {
        this.trackborderColor = value;
        this.Invalidate();
      }
      get => this.trackborderColor;
    }

    [Description("Tracker color")]
    [Category("ColorTrackBar")]
    public Color TrackerColor
    {
      set
      {
        this.trackColor = value;
        this.Invalidate();
      }
      get => this.trackColor;
    }

    [Description("Set or get the Tracker position")]
    [Category("ColorTrackBar")]
    public int Value
    {
      set
      {
        if (value <= this.barMinimum)
          value = this.barMinimum;
        if (value >= this.barMaximum)
          value = this.barMaximum;
        this.trackerValue = value;
        this.trackRect = Rectangle.Empty;
        this.Invalidate();
      }
      get => this.trackerValue;
    }

    public static ushort LowWord(uint value) => (ushort) (value & (uint) ushort.MaxValue);

    public static ushort HighWord(uint value) => (ushort) (value >> 16);

    [Description("Event fires when the Value property changes")]
    [Category("Action")]
    public event ColorTrackBar.ValueChangedEventHandler ValueChanged;

    [Description("Event fires when the Trackbar position is changed")]
    [Category("Behavior")]
    public event ColorTrackBar.ScrollEventHandler Scroll;

    protected virtual void OnScroll()
    {
      try
      {
        if (this.Scroll == null)
          return;
        this.Scroll((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
      }
    }

    protected virtual void OnValueChanged()
    {
      try
      {
        if (this.ValueChanged == null)
          return;
        this.ValueChanged((object) this, new EventArgs());
      }
      catch (Exception ex)
      {
      }
    }

    protected override void WndProc(ref Message m)
    {
      try
      {
        if (m.Msg == 513)
        {
          Point pt = new Point((int) ColorTrackBar.LowWord((uint) (int) m.LParam), (int) ColorTrackBar.HighWord((uint) (int) m.LParam));
          if (this.trackRect.Contains(pt))
          {
            if (!this.leftbuttonDown)
            {
              this.leftbuttonDown = true;
              this.mousestartPos = pt.X - this.trackRect.X;
            }
          }
          else
          {
            int x = this.trackRect.Right + (pt.X - this.trackRect.X - this.trackRect.Width / 2) < this.Width ? (this.trackRect.Left + (pt.X - this.trackRect.X - this.trackRect.Width / 2) > 0 ? pt.X - this.trackRect.X - this.trackRect.Width / 2 : (this.trackRect.Left - 1) * -1) : this.Width - this.trackRect.Right - 1;
            this.trackRect.Offset(x, 0);
            this.trackerValue = (this.trackRect.X - 1) * (this.barMaximum - this.barMinimum) / (this.Width - this.trackSize - 2);
            if (this.maxSide == Poles.Left)
              this.trackerValue = (this.trackerValue - (this.barMaximum - this.barMinimum)) * -1;
            this.trackerValue += this.barMinimum;
            this.Invalidate();
            if (x != 0)
            {
              this.OnScroll();
              this.OnValueChanged();
            }
          }
          this.Focus();
        }
        if (m.Msg == 514)
          this.leftbuttonDown = false;
        if (m.Msg == 512)
        {
          int trackerValue = this.trackerValue;
          Point pt = new Point((int) ColorTrackBar.LowWord((uint) (int) m.LParam), (int) ColorTrackBar.HighWord((uint) (int) m.LParam));
          if (this.leftbuttonDown)
          {
            if (this.ClientRectangle.Contains(pt))
            {
              int x = 0;
              try
              {
                x = this.trackRect.Right + (pt.X - this.trackRect.X - this.mousestartPos) < this.Width ? (this.trackRect.Left + (pt.X - this.trackRect.X - this.mousestartPos) > 0 ? pt.X - this.trackRect.X - this.mousestartPos : (this.trackRect.Left - 1) * -1) : this.Width - this.trackRect.Right - 1;
                this.trackRect.Offset(x, 0);
                this.trackerValue = (this.trackRect.X - 1) * (this.barMaximum - this.barMinimum) / (this.Width - this.trackSize - 2);
                if (this.maxSide == Poles.Left)
                  this.trackerValue = (this.trackerValue - (this.barMaximum - this.barMinimum)) * -1;
              }
              catch (Exception ex)
              {
              }
              finally
              {
                this.trackerValue += this.barMinimum;
                this.Invalidate();
                if (x != 0)
                {
                  this.OnScroll();
                  this.OnValueChanged();
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
      }
      base.WndProc(ref m);
    }

    public ColorTrackBar()
    {
      this.Size = new Size(150, 25);
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
      this.Cursor = Cursors.Hand;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      this.trackRect = Rectangle.Empty;
      base.OnSizeChanged(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.barColor != Color.Empty)
      {
        SolidBrush solidBrush1 = new SolidBrush(this.barColor);
      }
      else
      {
        SolidBrush solidBrush2 = new SolidBrush(Color.FromName("Control"));
      }
      this.DrawControl(e.Graphics);
      base.OnPaint(e);
    }

    protected void DrawControl(Graphics g)
    {
      bool flag = false;
      if (this.trackRect == Rectangle.Empty)
        flag = true;
      try
      {
        Color.FromName("Control");
        if (this.Parent != null)
        {
          Color backColor = this.Parent.BackColor;
        }
        if (this.trackRect == Rectangle.Empty)
        {
          int num1 = this.trackerValue - this.barMinimum;
          Rectangle clientRectangle = this.ClientRectangle;
          int num2 = clientRectangle.Width - this.trackSize;
          int num3 = num1 * num2 / (this.barMaximum - this.barMinimum);
          if (num3 == 0)
            ++num3;
          int num4 = num3 + this.trackSize;
          clientRectangle = this.ClientRectangle;
          int width1 = clientRectangle.Width;
          if (num4 == width1)
            --num3;
          if (this.maxSide != Poles.Right)
          {
            int num5 = num3;
            clientRectangle = this.ClientRectangle;
            int width2 = clientRectangle.Width;
            num3 = (num5 - width2 + this.trackSize) * -1;
          }
          int x = num3;
          int trackSize = this.trackSize;
          clientRectangle = this.ClientRectangle;
          int height = clientRectangle.Height - 2;
          this.trackRect = new Rectangle(x, 1, trackSize, height);
        }
        this.PaintRectangle(this.ClientRectangle, this.barColor, this.barborderColor, g);
        Region region1 = new Region(this.ClientRectangle);
        Region region2 = new Region(this.trackRect);
        this.PaintTracker(this.trackRect, this.trackColor, this.trackborderColor, g);
      }
      catch (Exception ex)
      {
        throw new Exception("DrawBackGround Error: " + ex.Message);
      }
      finally
      {
        if (flag)
        {
          this.OnScroll();
          this.OnValueChanged();
        }
      }
    }

    protected void PaintRectangle(
      Rectangle Rect,
      Color RectColor,
      Color RectBorderColor,
      Graphics g)
    {
      Pen pen1 = new Pen(RectBorderColor, (float) this.borderWidth);
      g.DrawRectangle(pen1, new Rectangle(Rect.X, Rect.Y, Rect.Width - 1, Rect.Height - 1));
      pen1.Dispose();
      Rectangle rect1 = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 2, Rect.Height - (this.infoBoxHeight + 1));
      SolidBrush solidBrush1 = new SolidBrush(RectColor);
      g.FillRectangle((Brush) solidBrush1, rect1);
      solidBrush1.Dispose();
      Rectangle rect2 = new Rectangle(Rect.X + 1, Rect.Height - this.infoBoxHeight, Rect.Width, 20);
      SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(140, 140, 140));
      g.FillRectangle((Brush) solidBrush2, rect2);
      solidBrush2.Dispose();
      g.DrawString(this.Minimum.ToString(), this.Font, (Brush) new SolidBrush(Color.Black), (PointF) new Point(rect2.X, rect2.Y));
      Pen pen2 = new Pen(RectBorderColor, (float) this.borderWidth);
      g.DrawLine(pen2, new Point(rect2.X, rect2.Y), new Point(rect2.Width, rect2.Y));
      int num1 = (int) ((double) this.Maximum * 0.2);
      g.DrawString(num1.ToString(), this.Font, (Brush) new SolidBrush(Color.Black), (PointF) new Point((int) ((double) rect2.Width * 0.2), rect2.Y));
      g.DrawLine(pen2, new Point((int) ((double) Rect.Width * 0.2), Rect.Y), new Point((int) ((double) Rect.Width * 0.2), Rect.Height - this.infoBoxHeight));
      int num2 = (int) ((double) this.Maximum * 0.4);
      g.DrawString(num2.ToString(), this.Font, (Brush) new SolidBrush(Color.Black), (PointF) new Point((int) ((double) rect2.Width * 0.4), rect2.Y));
      g.DrawLine(pen2, new Point((int) ((double) Rect.Width * 0.4), Rect.Y), new Point((int) ((double) Rect.Width * 0.4), Rect.Height - this.infoBoxHeight));
      int num3 = (int) ((double) this.Maximum * 0.6);
      g.DrawString(num3.ToString(), this.Font, (Brush) new SolidBrush(Color.Black), (PointF) new Point((int) ((double) rect2.Width * 0.6), rect2.Y));
      g.DrawLine(pen2, new Point((int) ((double) Rect.Width * 0.6), Rect.Y), new Point((int) ((double) Rect.Width * 0.6), Rect.Height - this.infoBoxHeight));
      int num4 = (int) ((double) this.Maximum * 0.8);
      g.DrawString(num4.ToString(), this.Font, (Brush) new SolidBrush(Color.Black), (PointF) new Point((int) ((double) rect2.Width * 0.8), rect2.Y));
      g.DrawLine(pen2, new Point((int) ((double) Rect.Width * 0.8), Rect.Y), new Point((int) ((double) Rect.Width * 0.8), Rect.Height - this.infoBoxHeight));
      g.DrawString(this.Maximum.ToString(), this.Font, (Brush) new SolidBrush(Color.Black), (PointF) new Point(rect2.Width - 20, rect2.Y));
      pen2.Dispose();
    }

    protected void PaintTracker(
      Rectangle Rect,
      Color RectColor,
      Color RectBorderColor,
      Graphics g)
    {
      Rectangle rect = new Rectangle(Rect.X + 1, Rect.Y + 1, Rect.Width - 2, Rect.Height - (this.infoBoxHeight + 1));
      SolidBrush solidBrush = new SolidBrush(RectColor);
      g.FillRectangle((Brush) solidBrush, rect);
      solidBrush.Dispose();
    }

    protected void PaintPath(GraphicsPath PaintPath, Color PathColor, Graphics g)
    {
      Region region1 = new Region(PaintPath);
      Region region2 = new Region(PaintPath);
      SolidBrush solidBrush = new SolidBrush(ControlPaint.Dark(PathColor));
      g.FillRegion((Brush) solidBrush, new Region(PaintPath));
      solidBrush.Dispose();
      Rectangle rectangle = Rectangle.Truncate(PaintPath.GetBounds());
      Rectangle rect1 = new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height / 2);
      Rectangle rect2 = new Rectangle(rectangle.X, rectangle.Height / 2, rectangle.Width, rectangle.Height / 2);
      region1.Intersect(rect1);
      region2.Intersect(rect2);
      LinearGradientBrush linearGradientBrush1 = new LinearGradientBrush(new Point(rect1.Width / 2, rect1.Top), new Point(rect1.Width / 2, rect1.Bottom), ControlPaint.Dark(PathColor), PathColor);
      g.FillRegion((Brush) linearGradientBrush1, region1);
      linearGradientBrush1.Dispose();
      LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(new Point(rect2.Width / 2, rect2.Top - 1), new Point(rect2.Width / 2, rect2.Bottom), PathColor, ControlPaint.Dark(PathColor));
      g.FillRegion((Brush) linearGradientBrush2, region2);
      linearGradientBrush2.Dispose();
    }

    public delegate void ScrollEventHandler(object sender, EventArgs e);

    public delegate void ValueChangedEventHandler(object sender, EventArgs e);
  }
}
