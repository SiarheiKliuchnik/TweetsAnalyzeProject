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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.PictureBox();
            this.logoAkhmat = new System.Windows.Forms.PictureBox();
            this.chooseFile = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.fullScreenButton = new System.Windows.Forms.Button();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.tweetInfoPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.header)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoAkhmat)).BeginInit();
            this.tweetInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl
            // 
            this.gMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(-4, 59);
            this.gMapControl.Margin = new System.Windows.Forms.Padding(2);
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
            this.gMapControl.Size = new System.Drawing.Size(1304, 569);
            this.gMapControl.TabIndex = 1;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl_OnMarkerClick);
            this.gMapControl.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.gMapControl_OnPolygonClick);
            this.gMapControl.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 51);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1296, 62);
            this.header.TabIndex = 6;
            this.header.TabStop = false;
            this.header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // logoAkhmat
            // 
            this.logoAkhmat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logoAkhmat.BackgroundImage")));
            this.logoAkhmat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoAkhmat.Location = new System.Drawing.Point(12, 2);
            this.logoAkhmat.Name = "logoAkhmat";
            this.logoAkhmat.Size = new System.Drawing.Size(57, 57);
            this.logoAkhmat.TabIndex = 7;
            this.logoAkhmat.TabStop = false;
            // 
            // chooseFile
            // 
            this.chooseFile.BackColor = System.Drawing.Color.Black;
            this.chooseFile.FlatAppearance.BorderSize = 0;
            this.chooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseFile.Font = new System.Drawing.Font("HelvLight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFile.ForeColor = System.Drawing.Color.White;
            this.chooseFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chooseFile.Location = new System.Drawing.Point(78, 62);
            this.chooseFile.Name = "chooseFile";
            this.chooseFile.Size = new System.Drawing.Size(150, 40);
            this.chooseFile.TabIndex = 9;
            this.chooseFile.Text = "another file";
            this.chooseFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chooseFile.UseVisualStyleBackColor = false;
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Black;
            this.menuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuButton.FlatAppearance.BorderSize = 0;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("HelvLight", 20.3F);
            this.menuButton.ForeColor = System.Drawing.Color.White;
            this.menuButton.Image = ((System.Drawing.Image)(resources.GetObject("menuButton.Image")));
            this.menuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menuButton.Location = new System.Drawing.Point(78, 10);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(111, 46);
            this.menuButton.TabIndex = 10;
            this.menuButton.Text = "Menu";
            this.menuButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.BackColor = System.Drawing.Color.Black;
            this.closeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("closeButton.BackgroundImage")));
            this.closeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Location = new System.Drawing.Point(1274, 2);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 11;
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseLeave += new System.EventHandler(this.closeButton_MouseLeave);
            this.closeButton.MouseHover += new System.EventHandler(this.closeButton_MouseHover);
            // 
            // fullScreenButton
            // 
            this.fullScreenButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fullScreenButton.BackColor = System.Drawing.Color.Black;
            this.fullScreenButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fullScreenButton.BackgroundImage")));
            this.fullScreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fullScreenButton.FlatAppearance.BorderSize = 0;
            this.fullScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullScreenButton.Location = new System.Drawing.Point(1248, 2);
            this.fullScreenButton.Name = "fullScreenButton";
            this.fullScreenButton.Size = new System.Drawing.Size(20, 20);
            this.fullScreenButton.TabIndex = 12;
            this.fullScreenButton.UseVisualStyleBackColor = false;
            this.fullScreenButton.Click += new System.EventHandler(this.fullScreenButton_Click);
            this.fullScreenButton.MouseLeave += new System.EventHandler(this.fullScreenButton_MouseLeave);
            this.fullScreenButton.MouseHover += new System.EventHandler(this.fullScreenButton_MouseHover);
            // 
            // minimizeButton
            // 
            this.minimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimizeButton.BackColor = System.Drawing.Color.Black;
            this.minimizeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("minimizeButton.BackgroundImage")));
            this.minimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Location = new System.Drawing.Point(1222, 2);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(20, 20);
            this.minimizeButton.TabIndex = 13;
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            this.minimizeButton.MouseLeave += new System.EventHandler(this.minimizeButton_MouseLeave);
            this.minimizeButton.MouseHover += new System.EventHandler(this.minimizeButton_MouseHover);
            // 
            // tweetInfoPanel
            // 
            this.tweetInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tweetInfoPanel.BackColor = System.Drawing.Color.Black;
            this.tweetInfoPanel.Controls.Add(this.panel1);
            this.tweetInfoPanel.Location = new System.Drawing.Point(0, 563);
            this.tweetInfoPanel.Name = "tweetInfoPanel";
            this.tweetInfoPanel.Size = new System.Drawing.Size(1300, 65);
            this.tweetInfoPanel.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 621);
            this.Controls.Add(this.minimizeButton);
            this.Controls.Add(this.fullScreenButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.chooseFile);
            this.Controls.Add(this.logoAkhmat);
            this.Controls.Add(this.header);
            this.Controls.Add(this.tweetInfoPanel);
            this.Controls.Add(this.gMapControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(400, 320);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.header)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoAkhmat)).EndInit();
            this.tweetInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox header;
        private System.Windows.Forms.PictureBox logoAkhmat;
        private System.Windows.Forms.Button chooseFile;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button fullScreenButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Panel tweetInfoPanel;
    }
}

