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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            undoToolStripMenuItem = new ToolStripMenuItem();
            compareToolStripMenuItem = new ToolStripMenuItem();
            selectionModeToolStripMenuItem = new ToolStripMenuItem();
            rectangleToolStripMenuItem = new ToolStripMenuItem();
            eclipseToolStripMenuItem = new ToolStripMenuItem();
            polyganToolStripMenuItem = new ToolStripMenuItem();
            addTextToolStripMenuItem = new ToolStripMenuItem();
            mainPictureBox = new PictureBox();
            picturePanel = new Panel();
            selectColorButton = new Button();
            selectedColorLabel = new Label();
            applyBlendingButton = new Button();
            colorMapComboBox = new ComboBox();
            statusStrip = new StatusStrip();
            progressToolStripStatusLabel = new ToolStripStatusLabel();
            progressValueToolStripStatusLabel = new ToolStripStatusLabel();
            classificationToolStripStatusLabel = new ToolStripStatusLabel();
            classificationToolStripDropDownButton = new ToolStripDropDownButton();
            highToolStripMenuItem = new ToolStripMenuItem();
            midiumToolStripMenuItem = new ToolStripMenuItem();
            lowToolStripMenuItem = new ToolStripMenuItem();
            noneToolStripMenuItem = new ToolStripMenuItem();
            sidePanel = new Panel();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).BeginInit();
            picturePanel.SuspendLayout();
            statusStrip.SuspendLayout();
            sidePanel.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
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
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, compareToolStripMenuItem, selectionModeToolStripMenuItem, addTextToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            undoToolStripMenuItem.Size = new Size(156, 22);
            undoToolStripMenuItem.Text = "&Undo";
            undoToolStripMenuItem.Click += UndoToolStripMenuItemClick;
            // 
            // compareToolStripMenuItem
            // 
            compareToolStripMenuItem.Name = "compareToolStripMenuItem";
            compareToolStripMenuItem.Size = new Size(156, 22);
            compareToolStripMenuItem.Text = "&Compare";
            compareToolStripMenuItem.Click += CompareToolStripMenuItemClick;
            // 
            // selectionModeToolStripMenuItem
            // 
            selectionModeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rectangleToolStripMenuItem, eclipseToolStripMenuItem, polyganToolStripMenuItem });
            selectionModeToolStripMenuItem.Name = "selectionModeToolStripMenuItem";
            selectionModeToolStripMenuItem.Size = new Size(156, 22);
            selectionModeToolStripMenuItem.Text = "&Selection Mode";
            // 
            // rectangleToolStripMenuItem
            // 
            rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            rectangleToolStripMenuItem.Size = new Size(126, 22);
            rectangleToolStripMenuItem.Text = "&Rectangle";
            rectangleToolStripMenuItem.Click += OnSetSelectionModeToolStripMenuItemsClick;
            // 
            // eclipseToolStripMenuItem
            // 
            eclipseToolStripMenuItem.Name = "eclipseToolStripMenuItem";
            eclipseToolStripMenuItem.Size = new Size(126, 22);
            eclipseToolStripMenuItem.Text = "&Ellipse";
            eclipseToolStripMenuItem.Click += OnSetSelectionModeToolStripMenuItemsClick;
            // 
            // polyganToolStripMenuItem
            // 
            polyganToolStripMenuItem.Name = "polyganToolStripMenuItem";
            polyganToolStripMenuItem.Size = new Size(126, 22);
            polyganToolStripMenuItem.Text = "&Polygon";
            polyganToolStripMenuItem.Click += OnSetSelectionModeToolStripMenuItemsClick;
            // 
            // addTextToolStripMenuItem
            // 
            addTextToolStripMenuItem.Name = "addTextToolStripMenuItem";
            addTextToolStripMenuItem.Size = new Size(156, 22);
            addTextToolStripMenuItem.Text = "Add &Text";
            // 
            // mainPictureBox
            // 
            mainPictureBox.Dock = DockStyle.Fill;
            mainPictureBox.Location = new Point(0, 0);
            mainPictureBox.Name = "mainPictureBox";
            mainPictureBox.Size = new Size(537, 494);
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
            picturePanel.Size = new Size(539, 496);
            picturePanel.TabIndex = 2;
            // 
            // selectColorButton
            // 
            selectColorButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectColorButton.Location = new Point(3, 58);
            selectColorButton.Name = "selectColorButton";
            selectColorButton.Size = new Size(252, 23);
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
            selectedColorLabel.Location = new Point(3, 32);
            selectedColorLabel.Name = "selectedColorLabel";
            selectedColorLabel.Size = new Size(252, 23);
            selectedColorLabel.TabIndex = 4;
            selectedColorLabel.Visible = false;
            // 
            // applyBlendingButton
            // 
            applyBlendingButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            applyBlendingButton.Location = new Point(3, 468);
            applyBlendingButton.Name = "applyBlendingButton";
            applyBlendingButton.Size = new Size(252, 23);
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
            colorMapComboBox.Location = new Point(3, 6);
            colorMapComboBox.Name = "colorMapComboBox";
            colorMapComboBox.Size = new Size(252, 23);
            colorMapComboBox.TabIndex = 6;
            colorMapComboBox.Text = "Cool Warm";
            colorMapComboBox.SelectedIndexChanged += ColorMapComboBoxSelectedIndexChanged;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { progressToolStripStatusLabel, progressValueToolStripStatusLabel, classificationToolStripStatusLabel, classificationToolStripDropDownButton });
            statusStrip.Location = new Point(0, 526);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(823, 22);
            statusStrip.TabIndex = 7;
            statusStrip.Text = "statusStrip1";
            // 
            // progressToolStripStatusLabel
            // 
            progressToolStripStatusLabel.Name = "progressToolStripStatusLabel";
            progressToolStripStatusLabel.Size = new Size(55, 17);
            progressToolStripStatusLabel.Text = "Progress:";
            // 
            // progressValueToolStripStatusLabel
            // 
            progressValueToolStripStatusLabel.AutoSize = false;
            progressValueToolStripStatusLabel.Name = "progressValueToolStripStatusLabel";
            progressValueToolStripStatusLabel.Size = new Size(120, 17);
            progressValueToolStripStatusLabel.Text = "None";
            progressValueToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // classificationToolStripStatusLabel
            // 
            classificationToolStripStatusLabel.Name = "classificationToolStripStatusLabel";
            classificationToolStripStatusLabel.Size = new Size(80, 17);
            classificationToolStripStatusLabel.Text = "Classification:";
            // 
            // classificationToolStripDropDownButton
            // 
            classificationToolStripDropDownButton.AutoSize = false;
            classificationToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            classificationToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { highToolStripMenuItem, midiumToolStripMenuItem, lowToolStripMenuItem, noneToolStripMenuItem });
            classificationToolStripDropDownButton.Image = (Image)resources.GetObject("classificationToolStripDropDownButton.Image");
            classificationToolStripDropDownButton.ImageTransparentColor = Color.Magenta;
            classificationToolStripDropDownButton.Name = "classificationToolStripDropDownButton";
            classificationToolStripDropDownButton.Size = new Size(120, 20);
            classificationToolStripDropDownButton.Text = "Select Classification";
            // 
            // highToolStripMenuItem
            // 
            highToolStripMenuItem.Name = "highToolStripMenuItem";
            highToolStripMenuItem.Size = new Size(119, 22);
            highToolStripMenuItem.Text = "High";
            highToolStripMenuItem.Click += OnClassificationToolStripMenuItemClick;
            // 
            // midiumToolStripMenuItem
            // 
            midiumToolStripMenuItem.Name = "midiumToolStripMenuItem";
            midiumToolStripMenuItem.Size = new Size(119, 22);
            midiumToolStripMenuItem.Text = "Medium";
            midiumToolStripMenuItem.Click += OnClassificationToolStripMenuItemClick;
            // 
            // lowToolStripMenuItem
            // 
            lowToolStripMenuItem.Name = "lowToolStripMenuItem";
            lowToolStripMenuItem.Size = new Size(119, 22);
            lowToolStripMenuItem.Text = "Low";
            lowToolStripMenuItem.Click += OnClassificationToolStripMenuItemClick;
            // 
            // noneToolStripMenuItem
            // 
            noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            noneToolStripMenuItem.Size = new Size(119, 22);
            noneToolStripMenuItem.Text = "None";
            noneToolStripMenuItem.Click += OnClassificationToolStripMenuItemClick;
            // 
            // sidePanel
            // 
            sidePanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            sidePanel.Controls.Add(selectColorButton);
            sidePanel.Controls.Add(selectedColorLabel);
            sidePanel.Controls.Add(applyBlendingButton);
            sidePanel.Controls.Add(colorMapComboBox);
            sidePanel.Location = new Point(556, 28);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(260, 494);
            sidePanel.TabIndex = 8;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 548);
            Controls.Add(sidePanel);
            Controls.Add(statusStrip);
            Controls.Add(picturePanel);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(512, 512);
            Name = "MainForm";
            Text = "Multimedia";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mainPictureBox).EndInit();
            picturePanel.ResumeLayout(false);
            picturePanel.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            sidePanel.ResumeLayout(false);
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
        private ToolStripMenuItem compareToolStripMenuItem;
        private ToolStripMenuItem selectionModeToolStripMenuItem;
        private ToolStripMenuItem rectangleToolStripMenuItem;
        private ToolStripMenuItem eclipseToolStripMenuItem;
        private ToolStripMenuItem polyganToolStripMenuItem;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel progressToolStripStatusLabel;
        private ToolStripStatusLabel progressValueToolStripStatusLabel;
        private ToolStripStatusLabel classificationToolStripStatusLabel;
        private ToolStripDropDownButton classificationToolStripDropDownButton;
        private ToolStripMenuItem highToolStripMenuItem;
        private ToolStripMenuItem midiumToolStripMenuItem;
        private ToolStripMenuItem lowToolStripMenuItem;
        private ToolStripMenuItem noneToolStripMenuItem;
        private ToolStripMenuItem addTextToolStripMenuItem;
        private Panel sidePanel;
    }
}
