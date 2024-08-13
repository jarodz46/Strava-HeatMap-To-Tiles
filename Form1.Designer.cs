namespace StravaHeatMapToKMZ
{
    partial class Form1
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
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            mapControl = new MapControl();
            createKMZ = new Button();
            updateKMZ = new Button();
            progressBar1 = new ProgressBar();
            toggleElements = new Button();
            createTiles = new Button();
            createKarooTiles = new Button();
            abord = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            mapStyle = new ComboBox();
            label2 = new Label();
            activityType = new ComboBox();
            label3 = new Label();
            tileSize = new NumericUpDown();
            threadCount = new NumericUpDown();
            label4 = new Label();
            tileZoom = new NumericUpDown();
            label5 = new Label();
            updateTiles = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tileSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)threadCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tileZoom).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Dock = DockStyle.Fill;
            webView21.Enabled = false;
            webView21.Location = new Point(3, 3);
            webView21.Name = "webView21";
            webView21.Size = new Size(967, 606);
            webView21.Source = new Uri("https://www.strava.com/maps/global-heatmap", UriKind.Absolute);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.NavigationCompleted += webView21_NavigationCompleted;
            // 
            // mapControl
            // 
            mapControl.Dock = DockStyle.Fill;
            mapControl.ErrorColor = Color.Red;
            mapControl.FitToBounds = true;
            mapControl.Location = new Point(3, 3);
            mapControl.Name = "mapControl";
            mapControl.ShowThumbnails = true;
            mapControl.Size = new Size(967, 606);
            mapControl.TabIndex = 0;
            mapControl.ThumbnailBackColor = Color.FromArgb(224, 224, 224);
            mapControl.ThumbnailForeColor = Color.FromArgb(176, 176, 176);
            mapControl.ThumbnailText = "Downloading...";
            mapControl.TileImageAttributes = null;
            mapControl.ZoomLevel = 5;
            // 
            // createKMZ
            // 
            createKMZ.Enabled = false;
            createKMZ.Location = new Point(12, 11);
            createKMZ.Name = "createKMZ";
            createKMZ.Size = new Size(100, 23);
            createKMZ.TabIndex = 1;
            createKMZ.Text = "Create KMZ";
            createKMZ.UseVisualStyleBackColor = true;
            createKMZ.Click += createKMZ_Click;
            // 
            // updateKMZ
            // 
            updateKMZ.Enabled = false;
            updateKMZ.Location = new Point(118, 11);
            updateKMZ.Name = "updateKMZ";
            updateKMZ.Size = new Size(100, 23);
            updateKMZ.TabIndex = 2;
            updateKMZ.Text = "Update KMZ";
            updateKMZ.UseVisualStyleBackColor = true;
            updateKMZ.Click += updateKMZ_ClickAsync;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(616, 11);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(289, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 3;
            // 
            // toggleElements
            // 
            toggleElements.Enabled = false;
            toggleElements.Location = new Point(1285, 40);
            toggleElements.Name = "toggleElements";
            toggleElements.Size = new Size(75, 23);
            toggleElements.TabIndex = 4;
            toggleElements.Text = "Toggle UI";
            toggleElements.UseVisualStyleBackColor = true;
            toggleElements.Visible = false;
            toggleElements.Click += toggleElements_Click;
            // 
            // createTiles
            // 
            createTiles.Enabled = false;
            createTiles.Location = new Point(234, 11);
            createTiles.Name = "createTiles";
            createTiles.Size = new Size(75, 23);
            createTiles.TabIndex = 5;
            createTiles.Text = "Create tiles";
            createTiles.UseVisualStyleBackColor = true;
            createTiles.Click += createTiles_Click;
            // 
            // createKarooTiles
            // 
            createKarooTiles.Enabled = false;
            createKarooTiles.Location = new Point(431, 11);
            createKarooTiles.Name = "createKarooTiles";
            createKarooTiles.Size = new Size(179, 23);
            createKarooTiles.TabIndex = 6;
            createKarooTiles.Text = "Send tiles to Android device";
            createKarooTiles.UseVisualStyleBackColor = true;
            createKarooTiles.Click += createKarooTiles_Click;
            // 
            // abord
            // 
            abord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            abord.Location = new Point(909, 12);
            abord.Name = "abord";
            abord.Size = new Size(61, 23);
            abord.TabIndex = 7;
            abord.Text = "Abord";
            abord.UseVisualStyleBackColor = true;
            abord.Click += abord_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(967, 606);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 45);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 9;
            label1.Text = "Map Style";
            // 
            // mapStyle
            // 
            mapStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            mapStyle.FormattingEnabled = true;
            mapStyle.Items.AddRange(new object[] { "None", "Dark", "Winter", "Satellite" });
            mapStyle.Location = new Point(80, 42);
            mapStyle.Name = "mapStyle";
            mapStyle.Size = new Size(121, 23);
            mapStyle.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(207, 45);
            label2.Name = "label2";
            label2.Size = new Size(73, 15);
            label2.TabIndex = 11;
            label2.Text = "Activity type";
            // 
            // activityType
            // 
            activityType.DropDownStyle = ComboBoxStyle.DropDownList;
            activityType.FormattingEnabled = true;
            activityType.Items.AddRange(new object[] { "All", "Bikes", "Runs" });
            activityType.Location = new Point(286, 40);
            activityType.Name = "activityType";
            activityType.Size = new Size(121, 23);
            activityType.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(413, 45);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 13;
            label3.Text = "Tile size (px)";
            // 
            // tileSize
            // 
            tileSize.Location = new Point(490, 40);
            tileSize.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            tileSize.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            tileSize.Name = "tileSize";
            tileSize.Size = new Size(51, 23);
            tileSize.TabIndex = 14;
            tileSize.Value = new decimal(new int[] { 512, 0, 0, 0 });
            // 
            // threadCount
            // 
            threadCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            threadCount.Location = new Point(937, 41);
            threadCount.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            threadCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            threadCount.Name = "threadCount";
            threadCount.Size = new Size(34, 23);
            threadCount.TabIndex = 15;
            threadCount.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(849, 45);
            label4.Name = "label4";
            label4.Size = new Size(82, 15);
            label4.TabIndex = 16;
            label4.Text = "Threads count";
            // 
            // tileZoom
            // 
            tileZoom.Location = new Point(609, 40);
            tileZoom.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            tileZoom.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            tileZoom.Name = "tileZoom";
            tileZoom.Size = new Size(51, 23);
            tileZoom.TabIndex = 18;
            tileZoom.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(547, 44);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 17;
            label5.Text = "Tile zoom";
            // 
            // updateTiles
            // 
            updateTiles.Enabled = false;
            updateTiles.Location = new Point(315, 11);
            updateTiles.Name = "updateTiles";
            updateTiles.Size = new Size(81, 23);
            updateTiles.TabIndex = 19;
            updateTiles.Text = "Update tiles";
            updateTiles.UseVisualStyleBackColor = true;
            updateTiles.Click += updateTiles_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(2, 71);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(981, 640);
            tabControl1.TabIndex = 20;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(webView21);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(973, 612);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Strava access";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(mapControl);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(973, 612);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Zone selection";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(flowLayoutPanel1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(973, 612);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Download";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 709);
            Controls.Add(tabControl1);
            Controls.Add(updateTiles);
            Controls.Add(tileZoom);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(threadCount);
            Controls.Add(tileSize);
            Controls.Add(label3);
            Controls.Add(activityType);
            Controls.Add(label2);
            Controls.Add(mapStyle);
            Controls.Add(label1);
            Controls.Add(abord);
            Controls.Add(createKarooTiles);
            Controls.Add(createTiles);
            Controls.Add(toggleElements);
            Controls.Add(progressBar1);
            Controls.Add(updateKMZ);
            Controls.Add(createKMZ);
            Name = "Form1";
            Text = "Strava Heatmap to KMZ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ((System.ComponentModel.ISupportInitialize)tileSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)threadCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)tileZoom).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button createKMZ;
        private Button updateKMZ;
        private ProgressBar progressBar1;
        private Button toggleElements;
        private Button createTiles;
        private Button createKarooTiles;
        private Button abord;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ComboBox mapStyle;
        private Label label2;
        private ComboBox activityType;
        private Label label3;
        private NumericUpDown tileSize;
        private NumericUpDown threadCount;
        private Label label4;
        private NumericUpDown tileZoom;
        private Label label5;
        private Button updateTiles;
        private MapControl mapControl;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
    }
}