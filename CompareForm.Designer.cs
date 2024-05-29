namespace Multimedia
{
    partial class CompareForm
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
            selectImageButton = new Button();
            panel1 = new Panel();
            secondPictureBox = new PictureBox();
            originalPictureBox = new PictureBox();
            panel3 = new Panel();
            progressLabel = new Label();
            progressComboBox = new ComboBox();
            mergeImagesButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            saveProgressButton = new Button();
            ((System.ComponentModel.ISupportInitialize)secondPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).BeginInit();
            panel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // selectImageButton
            // 
            selectImageButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectImageButton.Location = new Point(5, 3);
            selectImageButton.Name = "selectImageButton";
            selectImageButton.Size = new Size(150, 23);
            selectImageButton.TabIndex = 0;
            selectImageButton.Text = "Select Image to compare";
            selectImageButton.UseVisualStyleBackColor = true;
            selectImageButton.Click += SelectImageButtonClick;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(25, 520);
            panel1.TabIndex = 3;
            // 
            // secondPictureBox
            // 
            secondPictureBox.BorderStyle = BorderStyle.FixedSingle;
            secondPictureBox.Dock = DockStyle.Fill;
            secondPictureBox.Location = new Point(446, 3);
            secondPictureBox.Name = "secondPictureBox";
            secondPictureBox.Size = new Size(437, 514);
            secondPictureBox.TabIndex = 0;
            secondPictureBox.TabStop = false;
            // 
            // originalPictureBox
            // 
            originalPictureBox.BorderStyle = BorderStyle.FixedSingle;
            originalPictureBox.Dock = DockStyle.Fill;
            originalPictureBox.Location = new Point(3, 3);
            originalPictureBox.Name = "originalPictureBox";
            originalPictureBox.Size = new Size(437, 514);
            originalPictureBox.TabIndex = 0;
            originalPictureBox.TabStop = false;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(saveProgressButton);
            panel3.Controls.Add(progressLabel);
            panel3.Controls.Add(progressComboBox);
            panel3.Controls.Add(mergeImagesButton);
            panel3.Controls.Add(selectImageButton);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(911, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(160, 520);
            panel3.TabIndex = 3;
            // 
            // progressLabel
            // 
            progressLabel.AutoSize = true;
            progressLabel.Location = new Point(3, 49);
            progressLabel.Name = "progressLabel";
            progressLabel.Size = new Size(52, 15);
            progressLabel.TabIndex = 2;
            progressLabel.Text = "Progress";
            progressLabel.Visible = false;
            // 
            // progressComboBox
            // 
            progressComboBox.FormattingEnabled = true;
            progressComboBox.Items.AddRange(new object[] { "None", "Low", "Medium", "High" });
            progressComboBox.Location = new Point(3, 67);
            progressComboBox.Name = "progressComboBox";
            progressComboBox.Size = new Size(150, 23);
            progressComboBox.TabIndex = 1;
            progressComboBox.Text = "None";
            progressComboBox.Visible = false;
            // 
            // mergeImagesButton
            // 
            mergeImagesButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            mergeImagesButton.Location = new Point(5, 484);
            mergeImagesButton.Name = "mergeImagesButton";
            mergeImagesButton.Size = new Size(150, 23);
            mergeImagesButton.TabIndex = 0;
            mergeImagesButton.Text = "Merge Images";
            mergeImagesButton.UseVisualStyleBackColor = true;
            mergeImagesButton.Visible = false;
            mergeImagesButton.Click += MergeImagesButtonClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(originalPictureBox, 0, 0);
            tableLayoutPanel1.Controls.Add(secondPictureBox, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(25, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(886, 520);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // saveProgressButton
            // 
            saveProgressButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            saveProgressButton.Location = new Point(5, 455);
            saveProgressButton.Name = "saveProgressButton";
            saveProgressButton.Size = new Size(148, 23);
            saveProgressButton.TabIndex = 3;
            saveProgressButton.Text = "Save Progress";
            saveProgressButton.UseVisualStyleBackColor = true;
            // 
            // CompareForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 520);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "CompareForm";
            Text = "CompareForm";
            ((System.ComponentModel.ISupportInitialize)secondPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button selectImageButton;
        private Panel panel1;
        private Panel panel3;
        private Button mergeImagesButton;
        private PictureBox secondPictureBox;
        private PictureBox originalPictureBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label progressLabel;
        private ComboBox progressComboBox;
        private Button saveProgressButton;
    }
}