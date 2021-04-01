
namespace WindowsFormsApp.Presentation_Layer
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.dirLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.logoAkhmat = new System.Windows.Forms.PictureBox();
            this.changeDirButton = new System.Windows.Forms.Button();
            this.localizationComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tweetPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dragPanel = new System.Windows.Forms.Panel();
            this.EmotionScaleCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoAkhmat)).BeginInit();
            this.dragPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.Black;
            this.minimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("minimizeButton.BackgroundImage")));
            this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.Transparent;
            this.minimizeButton.Location = new System.Drawing.Point(392, -1);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(20, 25);
            this.minimizeButton.TabIndex = 16;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Black;
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.ForeColor = System.Drawing.Color.Transparent;
            this.closeButton.Location = new System.Drawing.Point(412, -1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 25);
            this.closeButton.TabIndex = 14;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dirLabel
            // 
            this.dirLabel.AutoSize = true;
            this.dirLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dirLabel.ForeColor = System.Drawing.Color.White;
            this.dirLabel.Location = new System.Drawing.Point(23, 141);
            this.dirLabel.Name = "dirLabel";
            this.dirLabel.Size = new System.Drawing.Size(203, 22);
            this.dirLabel.TabIndex = 17;
            this.dirLabel.Text = "Directory to saved files:";
            // 
            // pathLabel
            // 
            this.pathLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathLabel.ForeColor = System.Drawing.Color.White;
            this.pathLabel.Location = new System.Drawing.Point(24, 169);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(308, 51);
            this.pathLabel.TabIndex = 18;
            // 
            // logoAkhmat
            // 
            this.logoAkhmat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoAkhmat.BackgroundImage")));
            this.logoAkhmat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoAkhmat.Location = new System.Drawing.Point(2, -1);
            this.logoAkhmat.Name = "logoAkhmat";
            this.logoAkhmat.Size = new System.Drawing.Size(57, 57);
            this.logoAkhmat.TabIndex = 19;
            this.logoAkhmat.TabStop = false;
            // 
            // changeDirButton
            // 
            this.changeDirButton.BackColor = System.Drawing.Color.Black;
            this.changeDirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeDirButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeDirButton.ForeColor = System.Drawing.Color.White;
            this.changeDirButton.Location = new System.Drawing.Point(338, 165);
            this.changeDirButton.Name = "changeDirButton";
            this.changeDirButton.Size = new System.Drawing.Size(75, 31);
            this.changeDirButton.TabIndex = 20;
            this.changeDirButton.Text = "Change";
            this.changeDirButton.UseVisualStyleBackColor = false;
            this.changeDirButton.Click += new System.EventHandler(this.changeDirButton_Click);
            // 
            // localizationComboBox
            // 
            this.localizationComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.localizationComboBox.FormattingEnabled = true;
            this.localizationComboBox.Location = new System.Drawing.Point(143, 235);
            this.localizationComboBox.Name = "localizationComboBox";
            this.localizationComboBox.Size = new System.Drawing.Size(121, 21);
            this.localizationComboBox.TabIndex = 21;
            this.localizationComboBox.SelectedIndexChanged += new System.EventHandler(this.localizationComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Localization:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tweetPointsCheckBox
            // 
            this.tweetPointsCheckBox.AutoSize = true;
            this.tweetPointsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tweetPointsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tweetPointsCheckBox.ForeColor = System.Drawing.Color.White;
            this.tweetPointsCheckBox.Location = new System.Drawing.Point(29, 71);
            this.tweetPointsCheckBox.Name = "tweetPointsCheckBox";
            this.tweetPointsCheckBox.Size = new System.Drawing.Size(200, 22);
            this.tweetPointsCheckBox.TabIndex = 23;
            this.tweetPointsCheckBox.Text = "Show tweet points on map";
            this.tweetPointsCheckBox.UseVisualStyleBackColor = true;
            this.tweetPointsCheckBox.CheckedChanged += new System.EventHandler(this.tweetPointsCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(63, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 33);
            this.label1.TabIndex = 24;
            this.label1.Text = "Settings";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Black;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(29, 263);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 31);
            this.saveButton.TabIndex = 25;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dragPanel
            // 
            this.dragPanel.Controls.Add(this.label1);
            this.dragPanel.Location = new System.Drawing.Point(2, -1);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(430, 57);
            this.dragPanel.TabIndex = 26;
            this.dragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseDown);
            // 
            // EmotionScaleCheckBox
            // 
            this.EmotionScaleCheckBox.AutoSize = true;
            this.EmotionScaleCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EmotionScaleCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmotionScaleCheckBox.ForeColor = System.Drawing.Color.White;
            this.EmotionScaleCheckBox.Location = new System.Drawing.Point(29, 99);
            this.EmotionScaleCheckBox.Name = "EmotionScaleCheckBox";
            this.EmotionScaleCheckBox.Size = new System.Drawing.Size(217, 22);
            this.EmotionScaleCheckBox.TabIndex = 27;
            this.EmotionScaleCheckBox.Text = "Show emotional weight scale";
            this.EmotionScaleCheckBox.UseVisualStyleBackColor = true;
            this.EmotionScaleCheckBox.CheckedChanged += new System.EventHandler(this.EmotionScaleCheckBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(431, 308);
            this.Controls.Add(this.EmotionScaleCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tweetPointsCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.localizationComboBox);
            this.Controls.Add(this.changeDirButton);
            this.Controls.Add(this.logoAkhmat);
            this.Controls.Add(this.pathLabel);
            this.Controls.Add(this.dirLabel);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.dragPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoAkhmat)).EndInit();
            this.dragPanel.ResumeLayout(false);
            this.dragPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label dirLabel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.PictureBox logoAkhmat;
        private System.Windows.Forms.Button changeDirButton;
        private System.Windows.Forms.ComboBox localizationComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox tweetPointsCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel dragPanel;
        private System.Windows.Forms.CheckBox EmotionScaleCheckBox;
    }
}