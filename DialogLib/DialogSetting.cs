using System;
using System.Drawing;
using System.Windows.Forms;
using GlobalLib;
using System.Runtime.InteropServices;

namespace BinaryClockLib
{
    public partial class DialogSetting : Form
    {
        public DialogSetting()
        {
            InitializeComponent();

            this.SuspendLayout();
            Size s = Screen.PrimaryScreen.WorkingArea.Size;
            numericUpDownGrid.Minimum = 0;
            numericUpDownOpacity.Minimum = 0;
            numericUpDownOpacity.Maximum = 100;
            numericUpDownSize.Minimum = 1;
            numericUpDownGrid.Maximum = 
            numericUpDownSize.Maximum = Math.Min(s.Width / 6, s.Height / 4);
            
            label.Size = new Size(24, 16);
            label.Parent = pictureBox;
            label.MouseDoubleClick += label_MouseDoubleClick;
            label.MouseDown += label_MouseDown;
            label.MouseUp += label_MouseUp;
            label.MouseMove += label_MouseMove;

            comboBoxBoxType.Items.Clear();
            comboBoxBoxType.Items.Add(BoxType.None);
            comboBoxBoxType.Items.Add(BoxType.Border);
            comboBoxBoxType.Items.Add(BoxType.Shadow);
            comboBoxOrder.Items.Clear();
            comboBoxOrder.Items.Add("8421");
            comboBoxOrder.Items.Add("1248");

            //int w = pictureBox.Width;
            //int h = pictureBox.Height;
            //pictureBox.Size = new Size(s.Width * h / s.Height, h);
            //pictureBox.Left = (groupBoxLocation.Width - pictureBox.Width) / 2;
            pictureBox.MouseClick += pictureBox_MouseClick;
            this.ResumeLayout();
        }

        #region label
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isMouseDown = true;
                mouseOffset = e.Location;
            }
        }

        private void label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SetBackColor(sender as Control);
            /**
            ColorDialog cd = new ColorDialog();
            if (DialogResult.OK == cd.ShowDialog())
            {
                label.BackColor = cd.Color;
            }
            **/
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                label.Left += e.X - mouseOffset.X;
                label.Top += e.Y - mouseOffset.Y;
            }
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        #endregion label

        #region property
        private void numericUpDownOpacity_ValueChanged(object sender, EventArgs e)
        {
            this.ClockOpacity = (int)(numericUpDownOpacity.Value);
        }

        private void numericUpDownGrid_ValueChanged(object sender, EventArgs e)
        {
            this.GridWidth = (int)(numericUpDownGrid.Value);
            ChangeLabelSize();
        }

        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            this.BoxSize = (int)(numericUpDownSize.Value);
            ChangeLabelSize();
        }

        private void buttonShadow_Click(object sender, EventArgs e)
        {
            SetBackColor(sender as Control);
            /**
            ColorDialog cd = new ColorDialog();
            if (DialogResult.OK == cd.ShowDialog())
            {
                buttonShadow.BackColor = cd.Color;
            }
            **/
        }

        private void comboBoxBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DrawType = (BoxType)(comboBoxBoxType.SelectedItem);
            this.buttonShadow.Visible = this.labelShadow.Enabled = this.DrawType.Equals(BoxType.Shadow);
        }

        private void comboBoxOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IsReverse = comboBoxOrder.SelectedIndex == 1;
        }

        private void checkBoxAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.AlwaysOnTop = checkBoxAlwaysOnTop.Checked;
        }
        #endregion property

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X - label.Width / 2;
            int y = e.Y - label.Height / 2;
            label.Location = new Point(x, y);
        }

        #region hide
        //private void panel_MouseMove(object sender, MouseEventArgs e)
        //{
            //if (isMouseDown)
            //{
                //Graphics g = panel.CreateGraphics();
                //g.FillRectangle(SystemBrushes.Control, panel.ClientRectangle);
                //g.FillRectangle(Brushes.GhostWhite, new Rectangle(e.Location, new Size(12, 8)));
            //}
        //}
        #endregion hide

        #region load
        #region Get desktop wallpaper
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SystemParametersInfo(uint uAction, uint uParam, System.Text.StringBuilder lpvParam, uint init);

        /*
         * Retrieves the full path of the bitmap file for the desktop wallpaper. 
         * The pvParam parameter must point to a buffer to receive the NULL-terminated path string. 
         * Set the uiParam parameter to the size, in characters, of the pvParam buffer. 
         * The returned string will not exceed MAX_PATH characters. 
         * If there is no desktop wallpaper, the returned string is empty. 
         */
        const uint SPI_GETDESKWALLPAPER = 0x0073;
        #endregion Get desktop wallpaper

        private void DialogSetting_Load(object sender, EventArgs e)
        {
            #region Get current desktop paper
            System.Text.StringBuilder wallPaperPath = new System.Text.StringBuilder(200);

            if (SystemParametersInfo(SPI_GETDESKWALLPAPER, 200, wallPaperPath, 0))
            {
                pictureBox.Image = Image.FromFile(wallPaperPath.ToString());
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            #endregion Get current desktop paper

            labelTip.Text = "Drag to place. \nDouble click to change color.";
            labelTip.TextAlign = ContentAlignment.MiddleLeft;   
            
            ChangeLabelSize();
            label.Location = GetLabelLocation();
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Text = string.Empty;

            numericUpDownOpacity.Value = Decimal.Parse(this.ClockOpacity.ToString());
            numericUpDownSize.Value = Decimal.Parse(this.BoxSize.ToString());
            numericUpDownGrid.Value = Decimal.Parse(this.GridWidth.ToString());
            checkBoxAlwaysOnTop.Checked = this.AlwaysOnTop;
            comboBoxBoxType.SelectedItem = this.DrawType;
            comboBoxOrder.SelectedIndex = this.IsReverse ? 1 : 0;
            buttonShadow.Visible = this.DrawType.Equals(BoxType.Shadow);

            label.Select();

            this.TopMost = true;
        }
        #endregion load

        #region utility
        private void SetBackColor(Control control)
        {
            ColorDialog cd = new ColorDialog();
            if (DialogResult.OK == cd.ShowDialog())
            {
                control.BackColor = cd.Color;
            }
        }

        private void ChangeLabelSize()
        {
            Size s = Screen.PrimaryScreen.WorkingArea.Size;
            int w = ClockSize.Width * pictureBox.Width / s.Width;
            int h = ClockSize.Height * pictureBox.Height / s.Height;
            label.Size = new Size(w, h);
        }

        private Point GetLabelLocation()
        {
            Point p = clockLocation;//value;
            Size s = Screen.PrimaryScreen.WorkingArea.Size;
            int x = (p.X > s.Width / 2) ? (s.Width - p.X - ClockSize.Width) : p.X;
            int y = (p.Y > s.Height / 2) ? (s.Height - p.Y - ClockSize.Height) : p.Y;

            x = x * pictureBox.Width / s.Width;
            y = y * pictureBox.Height / s.Height;

            x = (p.X > s.Width / 2) ? (pictureBox.Width - x - label.Width) : x;
            y = (p.Y > s.Height / 2) ? (pictureBox.Height - y - label.Height) : y;

            return new Point(x, y);
        }
        #endregion utility

        #region globe
        private Point clockLocation;
        public Point ClockLocation 
        { 
            get
            {
                Point p = label.Location;
                Size s = Screen.PrimaryScreen.WorkingArea.Size;
                
                int x = (p.X > pictureBox.Width / 2) ? (pictureBox.Width - p.X - label.Width) : p.X;
                int y = (p.Y > pictureBox.Height / 2) ? (pictureBox.Height - p.Y - label.Height) : p.Y;

                x = x * s.Width / pictureBox.Width;
                y = y * s.Height / pictureBox.Height;

                x = (p.X > pictureBox.Width / 2) ? (s.Width - x - ClockSize.Width) : x;
                y = (p.Y > pictureBox.Height / 2) ? (s.Height - y - ClockSize.Height) : y;

                return new Point(x, y);
            }
            set
            {
                //Point p = value;
                //Size s = Screen.PrimaryScreen.WorkingArea.Size;
                //int x = (p.X > s.Width / 2) ? (s.Width - p.X - ClockSize.Width) : p.X;
                //int y = (p.Y > s.Height / 2) ? (s.Height - p.Y - ClockSize.Height) : p.Y;

                //x = x * pictureBox.Width / s.Width;
                //y = y * pictureBox.Height / s.Height;

                //x = (p.X > s.Width / 2) ? (pictureBox.Width - x - label.Width) : x;
                //y = (p.Y > s.Height / 2) ? (pictureBox.Height - y - label.Height) : y;

                clockLocation = value;// new Point(x, y);
            }
        }

        public Color ClockColor 
        {
            get
            {
                return label.BackColor;
            }
            set
            {
                label.BackColor = value;
            }
        }
        public Color ShadowColor
        {
            get
            {
                return buttonShadow.BackColor;
            }
            set
            {
                buttonShadow.BackColor = value;
            }
        }
        public bool IsReverse { get; set; }
        public bool AlwaysOnTop { get; set; }
        public BoxType DrawType { get; set; }
        public int ClockOpacity { get; set; }
        public int BoxSize { get; set; }
        public int GridWidth { get; set; }
        private Size ClockSize
        {
            get
            {
                return new Size(6 * (BoxSize + GridWidth) - GridWidth + 1, 
                    4 * (BoxSize + GridWidth) - GridWidth + 1);
            }
        }

        private bool isMouseDown { get; set; }
        private Point mouseOffset { get; set; }

        private void buttonShadow_EnabledChanged(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = SystemColors.ControlLightLight;//(sender as Button).Enabled ? Color.Blue : (sender as Button).BackColor;
        }
        #endregion globe

        /*
         *            w1                       w2
         *  +--------------------+-     +-------------+-   
         *  |               +--+ |-y1   |         +-+ |-y2
         *  |h1           n1+--+ |  =>  |h2     n2+-+ |
         *  |                m1  |      |         m2  |
         *  |-------x1------|    |      |---x2----|   |
         *  |                    |      +-------------+
         *  +--------------------+
         * 
         *  w1/w2 == m1/m2 == x1/x2
         *  h1/h2 == n1/n2 == y1/y2 
         *  w1/w2 == h1/h2 or w1/w2 != h1 /h2 
         * 
         */

    } 
}
