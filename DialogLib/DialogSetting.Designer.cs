namespace BinaryClockLib
{
    partial class DialogSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDownOpacity = new System.Windows.Forms.NumericUpDown();
            this.groupBoxLocation = new System.Windows.Forms.GroupBox();
            this.checkBoxAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.label = new System.Windows.Forms.Label();
            this.labelTip = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.numericUpDownSize = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGrid = new System.Windows.Forms.NumericUpDown();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxBoxType = new System.Windows.Forms.ComboBox();
            this.groupBoxAppearance = new System.Windows.Forms.GroupBox();
            this.labelOrder = new System.Windows.Forms.Label();
            this.comboBoxOrder = new System.Windows.Forms.ComboBox();
            this.labelGridWidth = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.labelBoxType = new System.Windows.Forms.Label();
            this.labelBoxSize = new System.Windows.Forms.Label();
            this.groupBoxBox = new System.Windows.Forms.GroupBox();
            this.buttonShadow = new System.Windows.Forms.Button();
            this.labelShadow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).BeginInit();
            this.groupBoxLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrid)).BeginInit();
            this.groupBoxAppearance.SuspendLayout();
            this.groupBoxBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDownOpacity
            // 
            this.numericUpDownOpacity.Location = new System.Drawing.Point(77, 20);
            this.numericUpDownOpacity.Name = "numericUpDownOpacity";
            this.numericUpDownOpacity.Size = new System.Drawing.Size(63, 21);
            this.numericUpDownOpacity.TabIndex = 0;
            this.numericUpDownOpacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownOpacity.ValueChanged += new System.EventHandler(this.numericUpDownOpacity_ValueChanged);
            // 
            // groupBoxLocation
            // 
            this.groupBoxLocation.Controls.Add(this.checkBoxAlwaysOnTop);
            this.groupBoxLocation.Controls.Add(this.label);
            this.groupBoxLocation.Controls.Add(this.labelTip);
            this.groupBoxLocation.Controls.Add(this.pictureBox);
            this.groupBoxLocation.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLocation.Name = "groupBoxLocation";
            this.groupBoxLocation.Size = new System.Drawing.Size(353, 263);
            this.groupBoxLocation.TabIndex = 1;
            this.groupBoxLocation.TabStop = false;
            this.groupBoxLocation.Text = "Location";
            // 
            // checkBoxAlwaysOnTop
            // 
            this.checkBoxAlwaysOnTop.AutoSize = true;
            this.checkBoxAlwaysOnTop.Location = new System.Drawing.Point(245, 236);
            this.checkBoxAlwaysOnTop.Name = "checkBoxAlwaysOnTop";
            this.checkBoxAlwaysOnTop.Size = new System.Drawing.Size(102, 16);
            this.checkBoxAlwaysOnTop.TabIndex = 3;
            this.checkBoxAlwaysOnTop.Text = "Always on top";
            this.checkBoxAlwaysOnTop.UseVisualStyleBackColor = true;
            this.checkBoxAlwaysOnTop.CheckedChanged += new System.EventHandler(this.checkBoxAlwaysOnTop_CheckedChanged);
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(272, 47);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(54, 23);
            this.label.TabIndex = 2;
            this.label.Text = "label";
            // 
            // labelTip
            // 
            this.labelTip.Location = new System.Drawing.Point(6, 231);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(233, 29);
            this.labelTip.TabIndex = 2;
            this.labelTip.Text = "label1";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(6, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(341, 208);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // numericUpDownSize
            // 
            this.numericUpDownSize.Location = new System.Drawing.Point(77, 75);
            this.numericUpDownSize.Maximum = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.numericUpDownSize.Name = "numericUpDownSize";
            this.numericUpDownSize.Size = new System.Drawing.Size(63, 21);
            this.numericUpDownSize.TabIndex = 0;
            this.numericUpDownSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownSize.ValueChanged += new System.EventHandler(this.numericUpDownSize_ValueChanged);
            // 
            // numericUpDownGrid
            // 
            this.numericUpDownGrid.Location = new System.Drawing.Point(77, 47);
            this.numericUpDownGrid.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownGrid.Name = "numericUpDownGrid";
            this.numericUpDownGrid.Size = new System.Drawing.Size(63, 21);
            this.numericUpDownGrid.TabIndex = 1;
            this.numericUpDownGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownGrid.ValueChanged += new System.EventHandler(this.numericUpDownGrid_ValueChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(371, 244);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(445, 244);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // comboBoxBoxType
            // 
            this.comboBoxBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBoxType.FormattingEnabled = true;
            this.comboBoxBoxType.Items.AddRange(new object[] {
            "None",
            "Border",
            "Shadow"});
            this.comboBoxBoxType.Location = new System.Drawing.Point(77, 20);
            this.comboBoxBoxType.Name = "comboBoxBoxType";
            this.comboBoxBoxType.Size = new System.Drawing.Size(63, 20);
            this.comboBoxBoxType.TabIndex = 0;
            this.comboBoxBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxBoxType_SelectedIndexChanged);
            // 
            // groupBoxAppearance
            // 
            this.groupBoxAppearance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAppearance.Controls.Add(this.labelOrder);
            this.groupBoxAppearance.Controls.Add(this.comboBoxOrder);
            this.groupBoxAppearance.Controls.Add(this.numericUpDownGrid);
            this.groupBoxAppearance.Controls.Add(this.numericUpDownOpacity);
            this.groupBoxAppearance.Controls.Add(this.labelGridWidth);
            this.groupBoxAppearance.Controls.Add(this.labelOpacity);
            this.groupBoxAppearance.Location = new System.Drawing.Point(371, 12);
            this.groupBoxAppearance.Name = "groupBoxAppearance";
            this.groupBoxAppearance.Size = new System.Drawing.Size(149, 106);
            this.groupBoxAppearance.TabIndex = 7;
            this.groupBoxAppearance.TabStop = false;
            this.groupBoxAppearance.Text = "Appearance";
            // 
            // labelOrder
            // 
            this.labelOrder.AutoSize = true;
            this.labelOrder.Location = new System.Drawing.Point(6, 77);
            this.labelOrder.Name = "labelOrder";
            this.labelOrder.Size = new System.Drawing.Size(35, 12);
            this.labelOrder.TabIndex = 7;
            this.labelOrder.Text = "Order";
            // 
            // comboBoxOrder
            // 
            this.comboBoxOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOrder.FormattingEnabled = true;
            this.comboBoxOrder.Items.AddRange(new object[] {
            "8421",
            "1248"});
            this.comboBoxOrder.Location = new System.Drawing.Point(77, 74);
            this.comboBoxOrder.Name = "comboBoxOrder";
            this.comboBoxOrder.Size = new System.Drawing.Size(63, 20);
            this.comboBoxOrder.TabIndex = 6;
            this.comboBoxOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrder_SelectedIndexChanged);
            // 
            // labelGridWidth
            // 
            this.labelGridWidth.AutoSize = true;
            this.labelGridWidth.Location = new System.Drawing.Point(6, 49);
            this.labelGridWidth.Name = "labelGridWidth";
            this.labelGridWidth.Size = new System.Drawing.Size(65, 12);
            this.labelGridWidth.TabIndex = 3;
            this.labelGridWidth.Text = "Grid Width";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(6, 22);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(47, 12);
            this.labelOpacity.TabIndex = 0;
            this.labelOpacity.Text = "Opacity";
            // 
            // labelBoxType
            // 
            this.labelBoxType.AutoSize = true;
            this.labelBoxType.Location = new System.Drawing.Point(6, 23);
            this.labelBoxType.Name = "labelBoxType";
            this.labelBoxType.Size = new System.Drawing.Size(53, 12);
            this.labelBoxType.TabIndex = 1;
            this.labelBoxType.Text = "Box Type";
            // 
            // labelBoxSize
            // 
            this.labelBoxSize.AutoSize = true;
            this.labelBoxSize.Location = new System.Drawing.Point(6, 77);
            this.labelBoxSize.Name = "labelBoxSize";
            this.labelBoxSize.Size = new System.Drawing.Size(53, 12);
            this.labelBoxSize.TabIndex = 2;
            this.labelBoxSize.Text = "Box Size";
            // 
            // groupBoxBox
            // 
            this.groupBoxBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBox.Controls.Add(this.buttonShadow);
            this.groupBoxBox.Controls.Add(this.labelShadow);
            this.groupBoxBox.Controls.Add(this.labelBoxType);
            this.groupBoxBox.Controls.Add(this.numericUpDownSize);
            this.groupBoxBox.Controls.Add(this.comboBoxBoxType);
            this.groupBoxBox.Controls.Add(this.labelBoxSize);
            this.groupBoxBox.Location = new System.Drawing.Point(371, 124);
            this.groupBoxBox.Name = "groupBoxBox";
            this.groupBoxBox.Size = new System.Drawing.Size(149, 106);
            this.groupBoxBox.TabIndex = 8;
            this.groupBoxBox.TabStop = false;
            this.groupBoxBox.Text = "Box";
            // 
            // buttonShadow
            // 
            this.buttonShadow.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonShadow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadow.Location = new System.Drawing.Point(77, 46);
            this.buttonShadow.Name = "buttonShadow";
            this.buttonShadow.Size = new System.Drawing.Size(63, 23);
            this.buttonShadow.TabIndex = 4;
            this.buttonShadow.UseVisualStyleBackColor = true;
            this.buttonShadow.Click += new System.EventHandler(this.buttonShadow_Click);
            // 
            // labelShadow
            // 
            this.labelShadow.AutoSize = true;
            this.labelShadow.Location = new System.Drawing.Point(6, 51);
            this.labelShadow.Name = "labelShadow";
            this.labelShadow.Size = new System.Drawing.Size(41, 12);
            this.labelShadow.TabIndex = 3;
            this.labelShadow.Text = "Shadow";
            // 
            // DialogSetting
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(532, 285);
            this.Controls.Add(this.groupBoxBox);
            this.Controls.Add(this.groupBoxAppearance);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxLocation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DialogSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.DialogSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOpacity)).EndInit();
            this.groupBoxLocation.ResumeLayout(false);
            this.groupBoxLocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGrid)).EndInit();
            this.groupBoxAppearance.ResumeLayout(false);
            this.groupBoxAppearance.PerformLayout();
            this.groupBoxBox.ResumeLayout(false);
            this.groupBoxBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownOpacity;
        private System.Windows.Forms.GroupBox groupBoxLocation;
        private System.Windows.Forms.NumericUpDown numericUpDownSize;
        private System.Windows.Forms.NumericUpDown numericUpDownGrid;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.CheckBox checkBoxAlwaysOnTop;
        private System.Windows.Forms.ComboBox comboBoxBoxType;
        private System.Windows.Forms.GroupBox groupBoxAppearance;
        private System.Windows.Forms.Label labelOrder;
        private System.Windows.Forms.ComboBox comboBoxOrder;
        private System.Windows.Forms.Label labelGridWidth;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.Label labelBoxType;
        private System.Windows.Forms.Label labelBoxSize;
        private System.Windows.Forms.GroupBox groupBoxBox;
        private System.Windows.Forms.Button buttonShadow;
        private System.Windows.Forms.Label labelShadow;
    }
}