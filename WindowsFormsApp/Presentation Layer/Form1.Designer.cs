namespace WindowsFormsApp
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.EmotionPanel = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.PictureBox();
            this.logoAkhmat = new System.Windows.Forms.PictureBox();
            this.chooseFile = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.fullScreenButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.tweetInfoPanel = new System.Windows.Forms.Panel();
            this.screenshotButton = new System.Windows.Forms.Button();
            this.getInfoButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.gmapToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chooseFileListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.loadScreen = new System.Windows.Forms.PictureBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoAkhmat)).BeginInit();
            this.tweetInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loadScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            resources.ApplyResources(this.gMapControl, "gMapControl");
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl_OnMarkerClick);
            this.gMapControl.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gMapControl_OnPolygonClick);
            this.gMapControl.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gMapControl_OnMarkerEnter);
            this.gMapControl.OnMarkerLeave += new GMap.NET.WindowsForms.MarkerLeave(this.gMapControl_OnMarkerLeave);
            this.gMapControl.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // EmotionPanel
            // 
            resources.ApplyResources(this.EmotionPanel, "EmotionPanel");
            this.EmotionPanel.BackColor = System.Drawing.Color.Black;
            this.EmotionPanel.Name = "EmotionPanel";
            this.EmotionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.header, "header");
            this.header.Name = "header";
            this.header.TabStop = false;
            this.header.Click += new System.EventHandler(this.header_Click);
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // logoAkhmat
            // 
            resources.ApplyResources(this.logoAkhmat, "logoAkhmat");
            this.logoAkhmat.Name = "logoAkhmat";
            this.logoAkhmat.TabStop = false;
            this.logoAkhmat.Click += new System.EventHandler(this.logoAkhmat_Click_1);
            // 
            // chooseFile
            // 
            this.chooseFile.BackColor = System.Drawing.Color.Black;
            this.chooseFile.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.chooseFile, "chooseFile");
            this.chooseFile.ForeColor = System.Drawing.Color.White;
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.UseVisualStyleBackColor = false;
            this.chooseFile.Click += new System.EventHandler(this.chooseFile_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.menuButton, "menuButton");
            this.menuButton.FlatAppearance.BorderSize = 0;
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Name = "menuButton";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
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
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseHover += new System.EventHandler(this.closeButton_MouseHover);
            // 
            // fullScreenButton
            // 
            resources.ApplyResources(this.fullScreenButton, "fullScreenButton");
            this.fullScreenButton.BackColor = System.Drawing.Color.Black;
            this.fullScreenButton.FlatAppearance.BorderSize = 0;
            this.fullScreenButton.ForeColor = System.Drawing.Color.Transparent;
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.UseVisualStyleBackColor = false;
            this.fullScreenButton.Click += new System.EventHandler(this.fullScreenButton_Click);
            this.fullScreenButton.MouseLeave += new System.EventHandler(this.fullScreenButton_MouseLeave);
            this.fullScreenButton.MouseHover += new System.EventHandler(this.fullScreenButton_MouseHover);
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
            this.minimizeButton.MouseLeave += new System.EventHandler(this.minimizeButton_MouseLeave);
            this.minimizeButton.MouseHover += new System.EventHandler(this.minimizeButton_MouseHover);
            // 
            // tweetInfoPanel
            // 
            resources.ApplyResources(this.tweetInfoPanel, "tweetInfoPanel");
            this.tweetInfoPanel.BackColor = System.Drawing.Color.Black;
            this.tweetInfoPanel.Controls.Add(this.EmotionPanel);
            this.tweetInfoPanel.Name = "tweetInfoPanel";
            this.tweetInfoPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tweetInfoPanel_Paint);
            // 
            // screenshotButton
            // 
            this.screenshotButton.BackColor = System.Drawing.Color.Black;
            this.screenshotButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.screenshotButton, "screenshotButton");
            this.screenshotButton.ForeColor = System.Drawing.Color.White;
            this.screenshotButton.Name = "screenshotButton";
            this.screenshotButton.UseVisualStyleBackColor = false;
            this.screenshotButton.Click += new System.EventHandler(this.screenshotButton_Click);
            // 
            // getInfoButton
            // 
            this.getInfoButton.BackColor = System.Drawing.Color.Black;
            this.getInfoButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.getInfoButton, "getInfoButton");
            this.getInfoButton.ForeColor = System.Drawing.Color.White;
            this.getInfoButton.Name = "getInfoButton";
            this.getInfoButton.UseVisualStyleBackColor = false;
            this.getInfoButton.Click += new System.EventHandler(this.getInfoButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Black;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.settingsButton, "settingsButton");
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.UseVisualStyleBackColor = false;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // gmapToolTip
            // 
            this.gmapToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.gmapToolTip_Popup);
            // 
            // chooseFileListView
            // 
            this.chooseFileListView.BackColor = System.Drawing.Color.Black;
            this.chooseFileListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chooseFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            resources.ApplyResources(this.chooseFileListView, "chooseFileListView");
            this.chooseFileListView.ForeColor = System.Drawing.Color.White;
            this.chooseFileListView.HideSelection = false;
            this.chooseFileListView.MultiSelect = false;
            this.chooseFileListView.Name = "chooseFileListView";
            this.chooseFileListView.Scrollable = false;
            this.chooseFileListView.UseCompatibleStateImageBehavior = false;
            this.chooseFileListView.View = System.Windows.Forms.View.List;
            this.chooseFileListView.ItemActivate += new System.EventHandler(this.chooseFileListView_ItemActivate);
            this.chooseFileListView.SelectedIndexChanged += new System.EventHandler(this.chooseFileListView_SelectedIndexChanged);
            this.chooseFileListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chooseFileListView_MouseClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // loadScreen
            // 
            resources.ApplyResources(this.loadScreen, "loadScreen");
            this.loadScreen.BackColor = System.Drawing.Color.Black;
            this.loadScreen.Name = "loadScreen";
            this.loadScreen.TabStop = false;
            this.loadScreen.Click += new System.EventHandler(this.loadScreen_Click);
            // 
            // logoPictureBox
            // 
            resources.ApplyResources(this.logoPictureBox, "logoPictureBox");
            this.logoPictureBox.BackColor = System.Drawing.Color.Black;
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.Click += new System.EventHandler(this.logoPictureBox_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.fullScreenButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.loadScreen);
            this.Controls.Add(this.chooseFileListView);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.getInfoButton);
            this.Controls.Add(this.screenshotButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.chooseFile);
            this.Controls.Add(this.logoAkhmat);
            this.Controls.Add(this.header);
            this.Controls.Add(this.tweetInfoPanel);
            this.Controls.Add(this.gMapControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoAkhmat)).EndInit();
            this.tweetInfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loadScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Panel EmotionPanel;
        private System.Windows.Forms.PictureBox header;
        private System.Windows.Forms.PictureBox logoAkhmat;
        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button fullScreenButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Panel tweetInfoPanel;
        private System.Windows.Forms.Button screenshotButton;
        private System.Windows.Forms.Button getInfoButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.ToolTip gmapToolTip;
        private System.Windows.Forms.ListView chooseFileListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.PictureBox loadScreen;
        private System.Windows.Forms.PictureBox logoPictureBox;
    }
}

