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
            createTiles = new Button();
            createKarooTiles = new Button();
            abord = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            mapStyle = new ComboBox();
            label2 = new Label();
            activityType = new ComboBox();
            threadCount = new NumericUpDown();
            label4 = new Label();
            tileZoom = new NumericUpDown();
            label5 = new Label();
            updateTiles = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            bBackHome = new Button();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
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
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(3, 40);
            webView21.Margin = new Padding(3, 4, 3, 4);
            webView21.Name = "webView21";
            webView21.Size = new Size(800, 932);
            webView21.TabIndex = 0;
            webView21.ZoomFactor = 1D;
            webView21.NavigationCompleted += webView21_NavigationCompleted;
            // 
            // mapControl
            // 
            mapControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mapControl.ErrorColor = Color.Red;
            mapControl.FitToBounds = true;
            mapControl.Location = new Point(3, 45);
            mapControl.Margin = new Padding(3, 4, 3, 4);
            mapControl.Name = "mapControl";
            mapControl.ShowThumbnails = true;
            mapControl.Size = new Size(800, 800);
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
            createKMZ.Location = new Point(10, 9);
            createKMZ.Margin = new Padding(3, 4, 3, 4);
            createKMZ.Name = "createKMZ";
            createKMZ.Size = new Size(114, 31);
            createKMZ.TabIndex = 1;
            createKMZ.Text = "Create KMZ";
            createKMZ.UseVisualStyleBackColor = true;
            createKMZ.Click += createKMZ_Click;
            // 
            // updateKMZ
            // 
            updateKMZ.Enabled = false;
            updateKMZ.Location = new Point(17, 15);
            updateKMZ.Margin = new Padding(3, 4, 3, 4);
            updateKMZ.Name = "updateKMZ";
            updateKMZ.Size = new Size(114, 31);
            updateKMZ.TabIndex = 2;
            updateKMZ.Text = "Update KMZ";
            updateKMZ.UseVisualStyleBackColor = true;
            updateKMZ.Click += updateKMZ_ClickAsync;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(449, 15);
            progressBar1.Margin = new Padding(3, 4, 3, 4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(280, 31);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 3;
            // 
            // createTiles
            // 
            createTiles.Enabled = false;
            createTiles.Location = new Point(131, 9);
            createTiles.Margin = new Padding(3, 4, 3, 4);
            createTiles.Name = "createTiles";
            createTiles.Size = new Size(114, 31);
            createTiles.TabIndex = 5;
            createTiles.Text = "Create tiles";
            createTiles.UseVisualStyleBackColor = true;
            createTiles.Click += createTiles_Click;
            // 
            // createKarooTiles
            // 
            createKarooTiles.Enabled = false;
            createKarooTiles.Location = new Point(238, 15);
            createKarooTiles.Margin = new Padding(3, 4, 3, 4);
            createKarooTiles.Name = "createKarooTiles";
            createKarooTiles.Size = new Size(205, 31);
            createKarooTiles.TabIndex = 6;
            createKarooTiles.Text = "Send tiles to Android device";
            createKarooTiles.UseVisualStyleBackColor = true;
            createKarooTiles.Click += createKarooTiles_Click;
            // 
            // abord
            // 
            abord.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            abord.Location = new Point(734, 16);
            abord.Margin = new Padding(3, 4, 3, 4);
            abord.Name = "abord";
            abord.Size = new Size(70, 31);
            abord.TabIndex = 7;
            abord.Text = "Abord";
            abord.UseVisualStyleBackColor = true;
            abord.Click += abord_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 4);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(802, 972);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 60);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 9;
            label1.Text = "Map Color";
            // 
            // mapStyle
            // 
            mapStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            mapStyle.FormattingEnabled = true;
            mapStyle.Items.AddRange(new object[] { "hot", "blue", "purple", "gray", "bluered", "mobileblue" });
            mapStyle.Location = new Point(91, 56);
            mapStyle.Margin = new Padding(3, 4, 3, 4);
            mapStyle.Name = "mapStyle";
            mapStyle.Size = new Size(138, 28);
            mapStyle.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 60);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 11;
            label2.Text = "Activity type";
            // 
            // activityType
            // 
            activityType.DropDownStyle = ComboBoxStyle.DropDownList;
            activityType.FormattingEnabled = true;
            activityType.Items.AddRange(new object[] { "all", "ride", "run", "water", "winter" });
            activityType.Location = new Point(327, 53);
            activityType.Margin = new Padding(3, 4, 3, 4);
            activityType.Name = "activityType";
            activityType.Size = new Size(138, 28);
            activityType.TabIndex = 12;
            // 
            // threadCount
            // 
            threadCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            threadCount.Location = new Point(766, 55);
            threadCount.Margin = new Padding(3, 4, 3, 4);
            threadCount.Maximum = new decimal(new int[] { 8, 0, 0, 0 });
            threadCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            threadCount.Name = "threadCount";
            threadCount.Size = new Size(39, 27);
            threadCount.TabIndex = 15;
            threadCount.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(665, 60);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 16;
            label4.Text = "Threads count";
            // 
            // tileZoom
            // 
            tileZoom.Location = new Point(563, 55);
            tileZoom.Margin = new Padding(3, 4, 3, 4);
            tileZoom.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            tileZoom.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            tileZoom.Name = "tileZoom";
            tileZoom.Size = new Size(58, 27);
            tileZoom.TabIndex = 18;
            tileZoom.Value = new decimal(new int[] { 14, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(493, 60);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 17;
            label5.Text = "Tile zoom";
            // 
            // updateTiles
            // 
            updateTiles.Enabled = false;
            updateTiles.Location = new Point(138, 15);
            updateTiles.Margin = new Padding(3, 4, 3, 4);
            updateTiles.Name = "updateTiles";
            updateTiles.Size = new Size(93, 31);
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
            tabControl1.Location = new Point(2, 96);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(816, 880);
            tabControl1.TabIndex = 20;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            tabControl1.Selecting += tabControl1_Selecting;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(bBackHome);
            tabPage1.Controls.Add(webView21);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(808, 980);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "1. Strava access";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // bBackHome
            // 
            bBackHome.Location = new Point(5, 5);
            bBackHome.Margin = new Padding(3, 4, 3, 4);
            bBackHome.Name = "bBackHome";
            bBackHome.Size = new Size(197, 31);
            bBackHome.TabIndex = 1;
            bBackHome.Text = "Go back to strava heatmap page";
            bBackHome.UseVisualStyleBackColor = true;
            bBackHome.Click += bBackHome_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(mapControl);
            tabPage2.Controls.Add(createKMZ);
            tabPage2.Controls.Add(createTiles);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Margin = new Padding(3, 4, 3, 4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3, 4, 3, 4);
            tabPage2.Size = new Size(808, 847);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "2. Zone selection";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(flowLayoutPanel1);
            tabPage3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Margin = new Padding(3, 4, 3, 4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3, 4, 3, 4);
            tabPage3.Size = new Size(808, 980);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Download progress";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 980);
            Controls.Add(tabControl1);
            Controls.Add(updateTiles);
            Controls.Add(tileZoom);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(threadCount);
            Controls.Add(activityType);
            Controls.Add(label2);
            Controls.Add(mapStyle);
            Controls.Add(label1);
            Controls.Add(abord);
            Controls.Add(createKarooTiles);
            Controls.Add(progressBar1);
            Controls.Add(updateKMZ);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Strava Heatmap to KMZ";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
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
        private Button createTiles;
        private Button createKarooTiles;
        private Button abord;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ComboBox mapStyle;
        private Label label2;
        private ComboBox activityType;
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
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button bBackHome;
        private ColorDialog colorDialog1;
    }
}