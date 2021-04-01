
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
            resources.ApplyResources(this.minimizeButton, "minimizeButton");
            this.minimizeButton.BackColor = System.Drawing.Color.Black;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.ForeColor = System.Drawing.Color.Transparent;
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            resources.ApplyResources(this.closeButton, "closeButton");
            this.closeButton.BackColor = System.Drawing.Color.Black;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.ForeColor = System.Drawing.Color.Transparent;
            this.closeButton.Name = "closeButton";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // dirLabel
            // 
            resources.ApplyResources(this.dirLabel, "dirLabel");
            this.dirLabel.ForeColor = System.Drawing.Color.White;
            this.dirLabel.Name = "dirLabel";
            // 
            // pathLabel
            // 
            resources.ApplyResources(this.pathLabel, "pathLabel");
            this.pathLabel.ForeColor = System.Drawing.Color.White;
            this.pathLabel.Name = "pathLabel";
            // 
            // logoAkhmat
            // 
            resources.ApplyResources(this.logoAkhmat, "logoAkhmat");
            this.logoAkhmat.Name = "logoAkhmat";
            this.logoAkhmat.TabStop = false;
            // 
            // changeDirButton
            // 
            resources.ApplyResources(this.changeDirButton, "changeDirButton");
            this.changeDirButton.BackColor = System.Drawing.Color.Black;
            this.changeDirButton.ForeColor = System.Drawing.Color.White;
            this.changeDirButton.Name = "changeDirButton";
            this.changeDirButton.UseVisualStyleBackColor = false;
            this.changeDirButton.Click += new System.EventHandler(this.changeDirButton_Click);
            // 
            // localizationComboBox
            // 
            resources.ApplyResources(this.localizationComboBox, "localizationComboBox");
            this.localizationComboBox.FormattingEnabled = true;
            this.localizationComboBox.Name = "localizationComboBox";
            this.localizationComboBox.SelectedIndexChanged += new System.EventHandler(this.localizationComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tweetPointsCheckBox
            // 
            resources.ApplyResources(this.tweetPointsCheckBox, "tweetPointsCheckBox");
            this.tweetPointsCheckBox.ForeColor = System.Drawing.Color.White;
            this.tweetPointsCheckBox.Name = "tweetPointsCheckBox";
            this.tweetPointsCheckBox.UseVisualStyleBackColor = true;
            this.tweetPointsCheckBox.CheckedChanged += new System.EventHandler(this.tweetPointsCheckBox_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.BackColor = System.Drawing.Color.Black;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // folderBrowserDialog1
            // 
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            // 
            // dragPanel
            // 
            resources.ApplyResources(this.dragPanel, "dragPanel");
            this.dragPanel.Controls.Add(this.label1);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseDown);
            // 
            // EmotionScaleCheckBox
            // 
            resources.ApplyResources(this.EmotionScaleCheckBox, "EmotionScaleCheckBox");
            this.EmotionScaleCheckBox.ForeColor = System.Drawing.Color.White;
            this.EmotionScaleCheckBox.Name = "EmotionScaleCheckBox";
            this.EmotionScaleCheckBox.UseVisualStyleBackColor = true;
            this.EmotionScaleCheckBox.CheckedChanged += new System.EventHandler(this.EmotionScaleCheckBox_CheckedChanged);
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
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
            this.Name = "SettingsForm";
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