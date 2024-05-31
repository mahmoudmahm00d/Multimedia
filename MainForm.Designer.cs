namespace Multimedia
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            cropToolStripMenuItem = new ToolStripMenuItem();
            addTesxtToolStripMenuItem = new ToolStripMenuItem();
            compressToolStripMenuItem = new ToolStripMenuItem();
            Compress_tool = new ToolStripMenuItem();
            mainPictureBox = new PictureBox();
            picturePanel = new Panel();
            selectColorButton = new Button();
            selectedColorLabel = new Label();
            applyBlendingButton = new Button();
            colorMapComboBox = new ComboBox();
            chkCoordinates = new CheckBox();
            lblDrawX1 = new Label();
            lblDrawY1 = new Label();
            lblDrawX2 = new Label();
            lblDrawY2 = new Label();
            txtDrawX1 = new TextBox();
            txtDrawY1 = new TextBox();
            txtDrawX2 = new TextBox();
            txtDrawY2 = new TextBox();
            txtCY2 = new TextBox();
            txtCX2 = new TextBox();
            txtCY1 = new TextBox();
            txtCX1 = new TextBox();
            lblCY2 = new Label();
            lblCX2 = new Label();
            lblCY1 = new Label();
            lblCX1 = new Label();
            textBox1 = new TextBox();
            addSoundToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            picturePanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(823, 24);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(186, 22);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItemClick;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(186, 22);
            saveAsToolStripMenuItem.Text = "&Save As";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItemClick;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, cropToolStripMenuItem, addTesxtToolStripMenuItem, compressToolStripMenuItem, addSoundToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(180, 22);
            undoToolStripMenuItem.Text = "&Undo";
            undoToolStripMenuItem.Click += UndoToolStripMenuItemClick;
            // 
            // cropToolStripMenuItem
            // 
            cropToolStripMenuItem.Name = "cropToolStripMenuItem";
            cropToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            cropToolStripMenuItem.Size = new Size(180, 22);
            cropToolStripMenuItem.Text = "&Crop";
            cropToolStripMenuItem.Click += cropToolStripMenuItem_Click;
            // 
            // addTesxtToolStripMenuItem
            // 
            addTesxtToolStripMenuItem.Name = "addTesxtToolStripMenuItem";
            addTesxtToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            addTesxtToolStripMenuItem.Size = new Size(180, 22);
            addTesxtToolStripMenuItem.Text = "&Add Text";
            addTesxtToolStripMenuItem.Click += addTesxtToolStripMenuItem_Click;
            // 
            // compressToolStripMenuItem
            // 
            compressToolStripMenuItem.Name = "compressToolStripMenuItem";
            compressToolStripMenuItem.Size = new Size(180, 22);
            compressToolStripMenuItem.Text = "Compress";
            compressToolStripMenuItem.Click += compressToolStripMenuItem_Click;
            // 
            // Compress_tool
            // 
            Compress_tool.Name = "Compress_tool";
            Compress_tool.Size = new Size(32, 19);
            // 
            // mainPictureBox
            // 
            mainPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            mainPictureBox.Dock = DockStyle.Fill;
            mainPictureBox.Location = new Point(0, 0);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new Size(641, 507);
            mainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            mainPictureBox.TabIndex = 1;
            mainPictureBox.TabStop = false;
            mainPictureBox.Paint += MainPictureBoxPaint;
            mainPictureBox.MouseDown += MainPictureBoxMouseDown;
            mainPictureBox.MouseMove += MainPictureBoxMouseMove;
            mainPictureBox.MouseUp += MainPictureBoxMouseUp;
            // 
            // picturePanel
            // 
            picturePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picturePanel.AutoScroll = true;
            picturePanel.BorderStyle = BorderStyle.FixedSingle;
            picturePanel.Controls.Add(mainPictureBox);
            picturePanel.Location = new Point(12, 27);
            picturePanel.Name = "picturePanel";
            picturePanel.Size = new Size(643, 509);
            picturePanel.TabIndex = 2;
            // 
            // selectColorButton
            // 
            selectColorButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectColorButton.Location = new Point(659, 80);
            selectColorButton.Name = "selectColorButton";
            selectColorButton.Size = new Size(152, 23);
            selectColorButton.TabIndex = 3;
            selectColorButton.Text = "Select Color";
            selectColorButton.UseVisualStyleBackColor = true;
            selectColorButton.Visible = false;
            selectColorButton.Click += SelectColorButtonClick;
            // 
            // selectedColorLabel
            // 
            selectedColorLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectedColorLabel.BorderStyle = BorderStyle.FixedSingle;
            selectedColorLabel.Location = new Point(659, 54);
            selectedColorLabel.Name = "selectedColorLabel";
            selectedColorLabel.Size = new Size(152, 23);
            selectedColorLabel.TabIndex = 4;
            selectedColorLabel.Visible = false;
            // 
            // applyBlendingButton
            // 
            applyBlendingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyBlendingButton.Location = new Point(661, 512);
            applyBlendingButton.Name = "applyBlendingButton";
            applyBlendingButton.Size = new Size(151, 23);
            applyBlendingButton.TabIndex = 3;
            applyBlendingButton.Text = "Apply Blending";
            applyBlendingButton.UseVisualStyleBackColor = true;
            applyBlendingButton.Click += ApplyBlendingButtonClick;
            // 
            // colorMapComboBox
            // 
            colorMapComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            colorMapComboBox.FormattingEnabled = true;
            colorMapComboBox.Items.AddRange(new object[] { "Cool Warm", "Parula", "Heat", "Purple Blue", "Rainbow", "Custom Color" });
            colorMapComboBox.Location = new Point(660, 28);
            colorMapComboBox.Name = "colorMapComboBox";
            colorMapComboBox.Size = new Size(151, 23);
            colorMapComboBox.TabIndex = 6;
            colorMapComboBox.Text = "Cool Warm";
            colorMapComboBox.SelectedIndexChanged += ColorMapComboBoxSelectedIndexChanged;
            // 
            // chkCoordinates
            // 
            chkCoordinates.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkCoordinates.AutoSize = true;
            chkCoordinates.Location = new Point(678, 249);
            chkCoordinates.Margin = new Padding(3, 2, 3, 2);
            chkCoordinates.Name = "chkCoordinates";
            chkCoordinates.Size = new Size(112, 19);
            chkCoordinates.TabIndex = 7;
            chkCoordinates.Text = "\tUse Coordinates";
            chkCoordinates.UseVisualStyleBackColor = true;
            // 
            // lblDrawX1
            // 
            lblDrawX1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDrawX1.AutoSize = true;
            lblDrawX1.Location = new Point(658, 275);
            lblDrawX1.Name = "lblDrawX1";
            lblDrawX1.Size = new Size(20, 15);
            lblDrawX1.TabIndex = 8;
            lblDrawX1.Text = "X1";
            // 
            // lblDrawY1
            // 
            lblDrawY1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDrawY1.AutoSize = true;
            lblDrawY1.Location = new Point(659, 302);
            lblDrawY1.Name = "lblDrawY1";
            lblDrawY1.Size = new Size(20, 15);
            lblDrawY1.TabIndex = 9;
            lblDrawY1.Text = "Y1";
            // 
            // lblDrawX2
            // 
            lblDrawX2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDrawX2.AutoSize = true;
            lblDrawX2.Location = new Point(658, 328);
            lblDrawX2.Name = "lblDrawX2";
            lblDrawX2.Size = new Size(20, 15);
            lblDrawX2.TabIndex = 10;
            lblDrawX2.Text = "X2";
            // 
            // lblDrawY2
            // 
            lblDrawY2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDrawY2.AutoSize = true;
            lblDrawY2.Location = new Point(658, 355);
            lblDrawY2.Name = "lblDrawY2";
            lblDrawY2.Size = new Size(20, 15);
            lblDrawY2.TabIndex = 11;
            lblDrawY2.Text = "Y2";
            // 
            // txtDrawX1
            // 
            txtDrawX1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDrawX1.Location = new Point(682, 273);
            txtDrawX1.Margin = new Padding(3, 2, 3, 2);
            txtDrawX1.Name = "txtDrawX1";
            txtDrawX1.Size = new Size(60, 23);
            txtDrawX1.TabIndex = 12;
            // 
            // txtDrawY1
            // 
            txtDrawY1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDrawY1.Location = new Point(682, 299);
            txtDrawY1.Margin = new Padding(3, 2, 3, 2);
            txtDrawY1.Name = "txtDrawY1";
            txtDrawY1.Size = new Size(61, 23);
            txtDrawY1.TabIndex = 13;
            // 
            // txtDrawX2
            // 
            txtDrawX2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDrawX2.Location = new Point(682, 326);
            txtDrawX2.Margin = new Padding(3, 2, 3, 2);
            txtDrawX2.Name = "txtDrawX2";
            txtDrawX2.Size = new Size(61, 23);
            txtDrawX2.TabIndex = 14;
            // 
            // txtDrawY2
            // 
            txtDrawY2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtDrawY2.Location = new Point(681, 352);
            txtDrawY2.Margin = new Padding(3, 2, 3, 2);
            txtDrawY2.Name = "txtDrawY2";
            txtDrawY2.Size = new Size(62, 23);
            txtDrawY2.TabIndex = 15;
            // 
            // txtCY2
            // 
            txtCY2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCY2.Location = new Point(757, 352);
            txtCY2.Margin = new Padding(3, 2, 3, 2);
            txtCY2.Name = "txtCY2";
            txtCY2.Size = new Size(62, 23);
            txtCY2.TabIndex = 23;
            // 
            // txtCX2
            // 
            txtCX2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCX2.Location = new Point(758, 325);
            txtCX2.Margin = new Padding(3, 2, 3, 2);
            txtCX2.Name = "txtCX2";
            txtCX2.Size = new Size(61, 23);
            txtCX2.TabIndex = 22;
            // 
            // txtCY1
            // 
            txtCY1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCY1.Location = new Point(758, 298);
            txtCY1.Margin = new Padding(3, 2, 3, 2);
            txtCY1.Name = "txtCY1";
            txtCY1.Size = new Size(61, 23);
            txtCY1.TabIndex = 21;
            // 
            // txtCX1
            // 
            txtCX1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCX1.Location = new Point(759, 272);
            txtCX1.Margin = new Padding(3, 2, 3, 2);
            txtCX1.Name = "txtCX1";
            txtCX1.Size = new Size(60, 23);
            txtCX1.TabIndex = 20;
            // 
            // lblCY2
            // 
            lblCY2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCY2.AutoSize = true;
            lblCY2.Location = new Point(734, 354);
            lblCY2.Name = "lblCY2";
            lblCY2.Size = new Size(20, 15);
            lblCY2.TabIndex = 19;
            lblCY2.Text = "Y2";
            // 
            // lblCX2
            // 
            lblCX2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCX2.AutoSize = true;
            lblCX2.Location = new Point(734, 327);
            lblCX2.Name = "lblCX2";
            lblCX2.Size = new Size(20, 15);
            lblCX2.TabIndex = 18;
            lblCX2.Text = "X2";
            // 
            // lblCY1
            // 
            lblCY1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCY1.AutoSize = true;
            lblCY1.Location = new Point(735, 301);
            lblCY1.Name = "lblCY1";
            lblCY1.Size = new Size(20, 15);
            lblCY1.TabIndex = 17;
            lblCY1.Text = "Y1";
            // 
            // lblCX1
            // 
            lblCX1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCX1.AutoSize = true;
            lblCX1.Location = new Point(734, 274);
            lblCX1.Name = "lblCX1";
            lblCX1.Size = new Size(20, 15);
            lblCX1.TabIndex = 16;
            lblCX1.Text = "X1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(662, 122);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 23);
            textBox1.TabIndex = 24;
            textBox1.Visible = false;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // addSoundToolStripMenuItem
            // 
            addSoundToolStripMenuItem.Name = "addSoundToolStripMenuItem";
            addSoundToolStripMenuItem.Size = new Size(180, 22);
            addSoundToolStripMenuItem.Text = "Add Sound";
            addSoundToolStripMenuItem.Click += addSoundToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 548);
            Controls.Add(textBox1);
            Controls.Add(txtCY2);
            Controls.Add(txtCX2);
            Controls.Add(txtCY1);
            Controls.Add(txtCX1);
            Controls.Add(lblCY2);
            Controls.Add(lblCX2);
            Controls.Add(lblCY1);
            Controls.Add(lblCX1);
            Controls.Add(txtDrawY2);
            Controls.Add(txtDrawX2);
            Controls.Add(txtDrawY1);
            Controls.Add(txtDrawX1);
            Controls.Add(lblDrawY2);
            Controls.Add(lblDrawX2);
            Controls.Add(lblDrawY1);
            Controls.Add(lblDrawX1);
            Controls.Add(chkCoordinates);
            Controls.Add(colorMapComboBox);
            Controls.Add(selectedColorLabel);
            Controls.Add(applyBlendingButton);
            Controls.Add(selectColorButton);
            Controls.Add(picturePanel);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(512, 510);
            Name = "MainForm";
            Text = "Multimedia";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
            picturePanel.ResumeLayout(false);
            picturePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private PictureBox mainPictureBox;
        private Panel picturePanel;
        private Button selectColorButton;
        private Label selectedColorLabel;
        private Button applyBlendingButton;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ListBox listBox1;
        private ComboBox colorMapComboBox;
        private ToolStripMenuItem cropToolStripMenuItem;
        private CheckBox chkCoordinates;
        private Label lblDrawX1;
        private Label lblDrawY1;
        private Label lblDrawX2;
        private Label lblDrawY2;
        private TextBox txtDrawX1;
        private TextBox txtDrawY1;
        private TextBox txtDrawX2;
        private TextBox txtDrawY2;
        private TextBox txtCY2;
        private TextBox txtCX2;
        private TextBox txtCY1;
        private TextBox txtCX1;
        private Label lblCY2;
        private Label lblCX2;
        private Label lblCY1;
        private Label lblCX1;
        private ToolStripMenuItem addTesxtToolStripMenuItem;
        private TextBox textBox1;
        private ToolStripMenuItem Compress_tool;
        private ToolStripMenuItem compressToolStripMenuItem;
        private ToolStripMenuItem addSoundToolStripMenuItem;
    }
}
