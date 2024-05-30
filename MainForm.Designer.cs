
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
            mainPictureBox = new PictureBox();
            picturePanel = new Panel();
            selectColorButton = new Button();
            selectedColorLabel = new Label();
            applyBlendingButton = new Button();
            colorMapComboBox = new ComboBox();
            report = new Button();
            forrier = new Button();
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
            menuStrip.Padding = new Padding(7, 3, 0, 3);
            menuStrip.Size = new Size(941, 30);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveAsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(233, 26);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItemClick;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(233, 26);
            saveAsToolStripMenuItem.Text = "&Save As";
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItemClick;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(179, 26);
            undoToolStripMenuItem.Text = "&Undo";
            undoToolStripMenuItem.Click += UndoToolStripMenuItemClick;
            // 
            // mainPictureBox
            // 
            mainPictureBox.Dock = DockStyle.Fill;
            mainPictureBox.Location = new Point(0, 0);
            mainPictureBox.Margin = new Padding(3, 4, 3, 4);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new Size(733, 676);
            mainPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            mainPictureBox.TabIndex = 1;
            mainPictureBox.TabStop = false;
            mainPictureBox.Click += mainPictureBox_Click;
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
            picturePanel.Location = new Point(14, 36);
            picturePanel.Margin = new Padding(3, 4, 3, 4);
            picturePanel.Name = "picturePanel";
            picturePanel.Size = new Size(735, 678);
            picturePanel.TabIndex = 2;
            // 
            // selectColorButton
            // 
            selectColorButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectColorButton.Location = new Point(753, 107);
            selectColorButton.Margin = new Padding(3, 4, 3, 4);
            selectColorButton.Name = "selectColorButton";
            selectColorButton.Size = new Size(174, 31);
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
            selectedColorLabel.Location = new Point(753, 72);
            selectedColorLabel.Name = "selectedColorLabel";
            selectedColorLabel.Size = new Size(173, 30);
            selectedColorLabel.TabIndex = 4;
            selectedColorLabel.Visible = false;
            // 
            // applyBlendingButton
            // 
            applyBlendingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyBlendingButton.Location = new Point(755, 683);
            applyBlendingButton.Margin = new Padding(3, 4, 3, 4);
            applyBlendingButton.Name = "applyBlendingButton";
            applyBlendingButton.Size = new Size(173, 31);
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
            colorMapComboBox.Location = new Point(754, 37);
            colorMapComboBox.Margin = new Padding(3, 4, 3, 4);
            colorMapComboBox.Name = "colorMapComboBox";
            colorMapComboBox.Size = new Size(172, 28);
            colorMapComboBox.TabIndex = 6;
            colorMapComboBox.Text = "Cool Warm";
            colorMapComboBox.SelectedIndexChanged += ColorMapComboBoxSelectedIndexChanged;
            // 
            // report
            // 
            report.Location = new Point(753, 610);
            report.Name = "report";
            report.Size = new Size(172, 29);
            report.TabIndex = 7;
            report.Text = "make a report";
            report.UseVisualStyleBackColor = true;
            report.Click += report_Click;
            // 
            // forrier
            // 
            forrier.Location = new Point(754, 566);
            forrier.Name = "forrier";
            forrier.Size = new Size(171, 29);
            forrier.TabIndex = 8;
            forrier.Text = "Forrier Tranformations";
            forrier.UseVisualStyleBackColor = true;
            forrier.Click += forrier_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 731);
            Controls.Add(forrier);
            Controls.Add(report);
            Controls.Add(colorMapComboBox);
            Controls.Add(selectedColorLabel);
            Controls.Add(applyBlendingButton);
            Controls.Add(selectColorButton);
            Controls.Add(picturePanel);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(583, 667);
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
        private Button report;
        private Button forrier;

        public EventHandler MainForm_Load { get; private set; }
    }
}
