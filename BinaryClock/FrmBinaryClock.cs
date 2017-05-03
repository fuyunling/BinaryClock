using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using BinaryClockLib;
using GlobalLib;
using ConfigLib;

namespace BinaryClock
{
    public partial class FrmBinaryClock : Form
    {
        public FrmBinaryClock()
        {
            InitializeComponent();

            this.SuspendLayout();
            ContextMenuStrip cms = new ContextMenuStrip();
            cms.Items.Add(Global.MenuSnapshot);
            cms.Items.Add("-");
            cms.Items.Add(Global.MenuSetting);
            cms.Items.Add(Global.MenuColor);
            cms.Items.Add(Global.MenuReverse);
            cms.Items.Add("-");
            cms.Items.Add(Global.MenuAbout);
            cms.Items.Add(Global.MenuExit);

            notifyIcon.Icon = SystemIcons.Application;
            notifyIcon.ContextMenuStrip = cms;
            notifyIcon.Text = "Binary Clock";
            notifyIcon.Icon = this.Icon;
            notifyIcon.MouseClick += notifyIcon_MouseClick;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            ShortTime = DateTime.Now.ToShortTimeString();

            Global.Matrix = GetMatrix();
            //Global.Icon = new Bitmap(24, 24);
            //IconGraphics = Graphics.FromImage(Global.Icon);
            //IconGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            this.TopMost = true;
            this.TransparencyKey = this.BackColor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            // to set up automatic double buffering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.DoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.ResizeRedraw, true);

            this.Paint += FrmBinaryClock_Paint;
            this.ResumeLayout();
        }

        #region contextmenu
        private void ContextMenuItem_Click(object sender, EventArgs e)
        {
            isTop = false;

            ToolStripItem tsi = sender as ToolStripItem;
            if (tsi.Text.Equals(Global.MenuSnapshot))
            {
                Snapshot();
            }
            else if (tsi.Text.Equals(Global.MenuSetting))
            {
                ShowSettingDialog();
            }
            else if (tsi.Text.Equals(Global.MenuColor))
            {
                ShowColorDialog();
            }
            else if (tsi.Text.Equals(Global.MenuReverse))
            {
                ChangeColor(Global.ShadowColor, Global.ClockColor);
            }
            else if (tsi.Text.Equals(Global.MenuAbout))
            {
                ShowAboutDialog();
            }
            else if (tsi.Text.Equals(Global.MenuExit))
            {
                SaveConfiguration();
                notifyIcon.Dispose();
                this.Close();
            }

            isTop = true;
        }

        private void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            isTop = false;
        }

        private void ContextMenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            isTop = true;
        }
        #endregion contextmenu

        void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                (sender as NotifyIcon).ShowBalloonTip(500, 
                    DateTime.Now.ToLongTimeString(), 
                    DateTime.Now.ToLongDateString(), 
                    ToolTipIcon.Info);
            }
            this.TopMost = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Refresh(); // do paint
            if (onTop && isTop)
            {
                this.TopMost = true;
            }

            // update the tray icon
            if (!ShortTime.Equals(DateTime.Now.ToShortTimeString()))
            {
                ShortTime = DateTime.Now.ToShortTimeString();
                //DrawIcon();
            }
        }

        #region transparent
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // to hide from Alt-Tab program switcher, need to set ShowIcon to false
                cp.ExStyle |= 0x80; // Turn on WS_EX_TOOLWINDOW style bit
                //to transparent control
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }

        //// transparent control step 2: to invalidate the parent of the control
        //protected void InvalidateEx()
        //{
        //    if (Parent == null)
        //        return;
        //    Rectangle rc = new Rectangle(this.Location, this.Size);
        //    Parent.Invalidate(rc, true);
        //}

        //// transparent control step 3
        //// to ensure that the background draw routine does not mess up the 
        //// recently repainted parent-form content by 
        //// stubbing out the OnPaintBackground method.
        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    //do not allow the background to be painted 
        //}
        #endregion transparent

        #region form
        private void FrmBinaryClock_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            #region draw the matrix
            if (drawType.Equals(BoxType.Border))
            {
                g.DrawRectangles(Global.ClockPen, Global.Matrix);
            }
            else if (drawType.Equals(BoxType.Shadow))
            {
                g.FillRectangles(Global.ShadowBrush, Global.Matrix);
            }
            #endregion draw the matrix

            #region draw the current time
            LongTime = DateTime.Now.ToLongTimeString(); // 16:37:59
            LongTime = LongTime.Replace(":", "").PadLeft(6, '0');  // 163759
            Global.ListBits = new List<Rectangle>();
            for (int i = 0; i < LongTime.Length; i++)
            {
                int d = int.Parse(LongTime[i].ToString());
                Bit = 0;
                // dec -> bin
                while (d != 0)
                {
                    if (d % 2 != 0)
                    {
                        // bin -> rectangle[]
                        Global.ListBits.Add(GetRect(Bit + i * 4));  // bit is 1, i * 4 is the offset of the array
                    }
                    d = d >> 1;  // next bit
                    Bit++;  // index of the bit
                }
            }
            Global.Bits = Global.ListBits.ToArray();
            // 0 0 0 0 0 1
            // 0 1 0 1 1 0
            // 0 1 1 1 0 0 
            // 1 0 1 1 1 1

            if (Global.Bits.Length > 0)
            {
                g.FillRectangles(Global.ClockBrush, Global.Bits);
            }
            #endregion draw the current time

            //g.FillEllipse(Brushes.Aqua, 0, 0, 100, 100);
            //string t = DateTime.Now.ToLongTimeString() + "\r\n" + DateTime.Now.ToLongDateString();
            //g.DrawString(DateTime.Now.ToLongTimeString(),
            //    SystemFonts.DefaultFont, 
            //    Brushes.White,
            //    new PointF(10, 10));
        }

        private void FrmBinaryClock_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            if (!ConfigTool.ConfigExits(Global.ConfigFile))
            {
                ChangeSize();
                ChangeColor(Global.DefaultColor, Global.DefaultShadow);

                this.Opacity = 0.45;
                int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width - 50;
                int y = Screen.PrimaryScreen.WorkingArea.Top + 50;
                this.Location = new Point(x, y);
            }
            else
            {
                GetConfiguration();
                ChangeSize();
                ChangeColor(Global.ClockColor, Global.ShadowColor);
            }

            timer.Start();

            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            notifyIcon.ContextMenuStrip.Closing += ContextMenuStrip_Closing;
            AddItemClickEvent(notifyIcon.ContextMenuStrip.Items);

            //DrawIcon();
            this.ResumeLayout();
        }
        #endregion form

        #region utility
        private void Snapshot()
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = Global.SaveSnapshot;
            sfd.Filter = "*.png|*.png";
            sfd.DefaultExt = ".png";
            sfd.FileName = DateTime.Now.ToString().Replace(":", "-").Replace("/", "-");
            if (DialogResult.OK == sfd.ShowDialog())
            {
                bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            bmp.Dispose();
        }

        private void ShowColorDialog()
        {
            ColorDialog cd = new ColorDialog();
            if (DialogResult.OK == cd.ShowDialog())
            {
                Global.ClockColor = cd.Color;
            }
            ChangeColor(Global.ClockColor, Global.ShadowColor);
        }

        private void ShowAboutDialog()
        {
            string about = "Shows time in binary matrix.";
            MessageBox.Show(about + "\n\n" + "-- flynn@20140204".PadLeft(about.Length * 3 / 2),
                "Binary Clock", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowSettingDialog()
        {
            DialogSetting ds = new DialogSetting();
            ds.ClockOpacity = (int)(this.Opacity * 100);
            ds.BoxSize = this.w;
            ds.GridWidth = this.s;
            ds.AlwaysOnTop = this.onTop;
            ds.DrawType = this.drawType;
            ds.IsReverse = this.is1248;
            ds.ClockLocation = this.Location;
            ds.ClockColor = Global.ClockColor;
            ds.ShadowColor = Global.ShadowColor;
            ds.Icon = this.Icon;

            if (DialogResult.OK == ds.ShowDialog())
            {
                double o = ds.ClockOpacity * 1.0 / 100;
                if (this.Opacity != o)
                {
                    this.Opacity = o;
                }
                if (ds.BoxSize != w || 
                    ds.GridWidth != s)
                {
                    this.w = ds.BoxSize;
                    this.s = ds.GridWidth;
                    ChangeSize();
                }
                Point p = ds.ClockLocation;
                if (Math.Abs(p.X - this.Left) > 5 ||
                    Math.Abs(p.Y - this.Top) > 5)
                {
                    this.Location = p;
                }
                this.is1248 = ds.IsReverse;
                this.onTop = ds.AlwaysOnTop;
                this.drawType = ds.DrawType;
                ChangeColor(ds.ClockColor, ds.ShadowColor);
                
                //DrawIcon();
                SaveConfiguration();
            }
        }

        private Rectangle[] GetMatrix()
        {
            Rectangle[] rects = new Rectangle[24];
            for (int i = 0; i < rects.Length; i++)
            {
                rects[i] = new Rectangle((i / 4) * (w + s), (i % 4) * (w + s), w, w);
            }
            return rects;
        }

        private Rectangle GetRect(int i)
        {
            return is1248 ?
                new Rectangle((i / 4) * (w + s), (i % 4) * (w + s), w, w) :
                new Rectangle((i / 4) * (w + s), (3 - (i % 4)) * (w + s), w, w);

            #region hide
            // return new Rectangle((i / 4) * (w + 1), 4 * (w + 1) - (i % 4) * (w + 1), w, w); // original

            //Rectangle[] rects = new Rectangle[24];
            //for (int i = 0; i < rects.Length; i++)
            //{
            //    rects[i] = new Rectangle((i / 4) * (w + 1) + w, (i % 4) * (w + 1) + w, w, w);
            //}
            #endregion hide
        }

        private void AddItemClickEvent(ToolStripItemCollection items)
        {
            foreach (ToolStripItem item in items)
            {
                item.Click += ContextMenuItem_Click;
            }
        }

        private void ChangeColor(Color color, Color shadow)
        {
            Global.ClockColor = color;
            Global.ShadowColor = shadow;
            Global.ShadowBrush = GetBrush(shadow);
            Global.ClockBrush = GetBrush(color);
            Global.ClockPen = GetPen(color);

            //DrawIcon();
        }
            
        private void ChangeSize()
        {
            //this.Size = new Size(6 * (w + s), 4 * (w + s));
            this.Size = new Size(6 * (w + s) - s + 1, 4 * (w + s) - s + 1);
            
            Global.Matrix = GetMatrix();
        }

        //private void DrawIcon()
        //{
        //    //Global.Icon = new Bitmap(this.Height, this.Height);
        //    using (Bitmap ico = new Bitmap(this.Height, this.Height))
        //    {
        //        this.DrawToBitmap(ico, new Rectangle(0, 0, ico.Width, ico.Height));
        //        //Bitmap icon = new Bitmap(24, 24);
        //        //Graphics g = Graphics.FromImage(Global.Icon);
        //        //g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //        IconGraphics.DrawImage(ico, new Rectangle(0, 0, Global.Icon.Width, Global.Icon.Height));
        //        notifyIcon.Icon = Icon.FromHandle(Global.Icon.GetHicon());
        //        ico.Dispose();
        //    }
        //    //Global.Icon.Dispose();
        //}

        private void GetConfiguration()
        {
            SortedList<string, object> 
            conf = ConfigTool.ImportConfig(Global.ConfigFile, Global.CatagoryAppearance);
            this.Opacity = double.Parse(conf[Global.FieldOpacity].ToString().Trim());
            this.s = int.Parse(conf[Global.FieldGridWidth].ToString().Trim());
            this.is1248 = conf[Global.FieldOrder].Equals(Global.Order1248);
            
            conf = ConfigTool.ImportConfig(Global.ConfigFile, Global.CatagoryLocation);
            this.onTop = conf[Global.FieldAlwaysOnTop].Equals(bool.TrueString);
            string[] p = conf[Global.FieldLocation].ToString().Split(',');
            this.Location = new Point(int.Parse(p[0].Trim()), int.Parse(p[1].Trim()));

            conf = ConfigTool.ImportConfig(Global.ConfigFile, Global.CatagoryBox);
            this.drawType = (BoxType)Enum.Parse(typeof(BoxType), conf[Global.FieldBoxType].ToString().Trim(), true);
            this.w = int.Parse(conf[Global.FieldBoxSize].ToString().Trim());
            Global.ClockColor = Color.FromArgb(255 << 24 | int.Parse(conf[Global.FieldBoxColor].ToString().Trim()));
            Global.ShadowColor = Color.FromArgb(255 << 24 | int.Parse(conf[Global.FieldShadowColor].ToString().Trim()));
        }

        private void SaveConfiguration()
        {
            ConfigTool.CreateConfig(Global.ConfigFile);

            SortedList<string, object> conf = new SortedList<string, object>();
            conf.Add(Global.FieldOpacity, this.Opacity);
            conf.Add(Global.FieldGridWidth, this.s);
            conf.Add(Global.FieldOrder, this.is1248 ? Global.Order1248 : Global.Order8421);
            ConfigTool.ExportConfig(Global.ConfigFile, conf, Global.CatagoryAppearance);

            conf.Clear();
            conf.Add(Global.FieldLocation, this.Left + "," + this.Top);
            conf.Add(Global.FieldAlwaysOnTop, this.onTop);
            ConfigTool.ExportConfig(Global.ConfigFile, conf, Global.CatagoryLocation);

            conf.Clear();
            conf.Add(Global.FieldBoxType, this.drawType);
            conf.Add(Global.FieldBoxSize, this.w);
            conf.Add(Global.FieldBoxColor, ToRGB(Global.ClockColor));
            conf.Add(Global.FieldShadowColor, ToRGB(Global.ShadowColor));
            ConfigTool.ExportConfig(Global.ConfigFile, conf, Global.CatagoryBox); 
        }

        private int ToRGB(Color color)
        {
            return color.R << 16 | color.G << 8 | color.B;
        }

        private Brush GetBrush(Color color)
        {
            return new SolidBrush(color);
        }

        private Pen GetPen(Color color)
        {
            return new Pen(color);
        }
        #endregion utility

        #region global
        public Timer timer { get; set; }
        //public Graphics IconGraphics { get; set; }

        private int Bit { get; set; }
        private string LongTime { get; set; }
        private string ShortTime { get; set; }

        private bool isTop = true;
        private bool is1248 = false;
        private bool onTop = false;
        private BoxType drawType = BoxType.Border;
        private int w = 6;
        private int s = 2;
        #endregion global

    }
}
