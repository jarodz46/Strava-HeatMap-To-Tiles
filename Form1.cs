using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Core.DevToolsProtocolExtension;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using WebView2.DevTools.Dom;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using HtmlElement = WebView2.DevTools.Dom.HtmlElement;

namespace StravaHeatMapToKMZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webView21.Source = new Uri(heatmapurl, UriKind.Absolute);
            backgroundWorker1.RunWorkerAsync();
            mapControl.CacheFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MapControl");
            mapControl.TileServer = new OpenStreetMapTileServer("stravatiledownloader");
            mapStyle.SelectedIndex = 0;
            activityType.SelectedIndex = 0;
            SetButtonsState(false);
        }

        async Task<string?> GetCookieValByName(string name)
        {
            try
            {
                var cookies = await webView21.CoreWebView2.CookieManager.GetCookiesAsync("");
                foreach (var cookie in cookies)
                {
                    if (cookie.Expires > DateTime.UtcNow && cookie.Name == name)
                    {
                        Debug.WriteLine(cookie.Name + " : " + cookie.Value);
                        return cookie.Value;
                    }
                }
            }
            catch (Exception e)
            { Debug.WriteLine(e.Message); }

            return null;
        }

        void SetButtonsState(bool enabled)
        {
            createKMZ.Enabled = enabled;
            updateKMZ.Enabled = enabled;
            createTiles.Enabled = enabled;
            createKarooTiles.Enabled = enabled;
            updateTiles.Enabled = enabled;
            mapStyle.Enabled = enabled;
            activityType.Enabled = enabled;
            tileZoom.Enabled = enabled;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        NumberFormatInfo NFI
        {
            get
            {
                NumberFormatInfo nfi = new();
                nfi.NumberDecimalSeparator = ".";
                return nfi;
            }
        }

        Uri StravaHeatMapUri
        {
            get
            {
                return new Uri("https://www.strava.com/heatmap");
            }
        }


        enum UICommand
        {
            Show,
            Hide,
            Toggle,
        }


        private async void createKMZ_Click(object sender, EventArgs e)
        {

            SetButtonsState(false);

            var viewInfos = GetTilesInfosForCurrentView((int)tileZoom.Value);

            MemoryStream mZipStream = new();
            ZipArchive archive = new(mZipStream, ZipArchiveMode.Update, true);
            ZipArchiveEntry kmlEntry = archive.CreateEntry("doc.kml");

            XmlWriterSettings xmlWriterSettings = new();
            xmlWriterSettings.NewLineOnAttributes = true;
            xmlWriterSettings.Indent = true;
            XmlWriter kmlWriter = XmlWriter.Create(kmlEntry.Open(), xmlWriterSettings);
            kmlWriter.WriteStartElement("kml");
            kmlWriter.WriteStartElement("Document");
            kmlWriter.WriteElementString("name", "strava heatmap x");
            kmlWriter.WriteStartElement("LookAt");
            var nfi = NFI;
            kmlWriter.WriteElementString("longitude", viewInfos.centerLng.ToString(nfi));
            kmlWriter.WriteElementString("latitude", viewInfos.centerLat.ToString(nfi));
            kmlWriter.WriteElementString("range", "1000");
            kmlWriter.WriteEndElement();

            var onTileCreate = delegate (MemoryStream stream, Tile tile)
            {
                var screenPath = "files/tile" + tile.x1 + "_" + tile.y1 + ".jpg";
                var screenEntry = archive.CreateEntry(screenPath);
                var streamEntry = screenEntry.Open();
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(streamEntry);
                streamEntry.Close();

                var worldCoord = Tile.TileToWorldPos(tile.x1, tile.y1, (int)tileZoom.Value);
                var worldCoordMax = Tile.TileToWorldPos(tile.x2, tile.y2, (int)tileZoom.Value);
                var west = worldCoord.X;
                var east = worldCoordMax.X;
                var north = worldCoord.Y;
                var south = worldCoordMax.Y;
                kmlWriter.WriteStartElement("GroundOverlay");
                kmlWriter.WriteStartElement("Icon");
                kmlWriter.WriteElementString("href", screenPath);
                kmlWriter.WriteEndElement();
                kmlWriter.WriteStartElement("LatLonBox");
                kmlWriter.WriteElementString("north", north.ToString(nfi));
                kmlWriter.WriteElementString("south", south.ToString(nfi));
                kmlWriter.WriteElementString("east", east.ToString(nfi));
                kmlWriter.WriteElementString("west", west.ToString(nfi));
                kmlWriter.WriteEndElement();
                kmlWriter.WriteEndElement();
            };

            var result = await CreateTiles(onTileCreate, TileFormat.jpg, (int)tileZoom.Value);

            kmlWriter.WriteEndElement();
            kmlWriter.WriteEndElement();
            kmlWriter.Flush();
            kmlWriter.Dispose();

            archive.Dispose();
            if (!result)
            {
                mZipStream.Dispose();
                goto end;
            }
            SaveFileDialog saveFileDialog = new();
            saveFileDialog.DefaultExt = "kmz";
            saveFileDialog.Filter = "kmz files (*.kmz)|*.kmz";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var kmzPath = saveFileDialog.FileName;
                FileStream fileStream = new(kmzPath, FileMode.Create);
                mZipStream.Seek(0, SeekOrigin.Begin);
                mZipStream.CopyTo(fileStream);
                mZipStream.Close();
                fileStream.Close();
            }

        end:
            SetButtonsState(true);
        }

        //class KMLTile
        //{
        //    public string screenPath = string.Empty;
        //    public double north = 0;
        //    public double south = 0;
        //    public double west = 0;
        //    public double east = 0;
        //}

        private async void updateKMZ_ClickAsync(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new();
            openFileDialog.DefaultExt = "kmz";
            openFileDialog.Filter = "kmz files (*.kmz)|*.kmz";
            int updated = 0;
            var usedFormat = TileFormat.none;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream kmzFileStream = new(openFileDialog.FileName, FileMode.Open);
                ZipArchive kmzArchive = new(kmzFileStream, ZipArchiveMode.Update);
                var kmlEntry = kmzArchive.GetEntry("doc.kml");
                if (kmlEntry != null)
                {

                    XmlReader kmlReader = XmlReader.Create(kmlEntry.Open());
                    List<Tile> tiles = new();
                    while (kmlReader.Read())
                    {
                        if (abordWork)
                        {
                            tiles.Clear();
                            break;
                        }
                        if (kmlReader.NodeType == XmlNodeType.Element && kmlReader.Name == "GroundOverlay")
                        {
                            string screenPath = string.Empty;
                            double north = 0, south = 0, east = 0, west = 0;
                            while (kmlReader.NodeType != XmlNodeType.EndElement || kmlReader.Name != "GroundOverlay")
                            {
                                kmlReader.Read();
                                //MessageBox.Show(kmlReader.Name);
                                if (kmlReader.NodeType == XmlNodeType.Element)
                                {
                                    switch (kmlReader.Name)
                                    {
                                        case "href":
                                            kmlReader.Read();
                                            screenPath = kmlReader.Value;
                                            break;
                                        case "north":
                                            kmlReader.Read();
                                            double.TryParse(kmlReader.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out north);
                                            break;
                                        case "south":
                                            kmlReader.Read();
                                            double.TryParse(kmlReader.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out south);
                                            break;
                                        case "east":
                                            kmlReader.Read();
                                            double.TryParse(kmlReader.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out east);
                                            break;
                                        case "west":
                                            kmlReader.Read();
                                            double.TryParse(kmlReader.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out west);
                                            break;
                                    }
                                }
                            }
                            if (!string.IsNullOrEmpty(screenPath) && north != 0 && south != 0 && west != 0 && east != 0)
                            {
                                var tile = new Tile(north, south, east, west, 15);
                                tile.tag = screenPath;
                                tiles.Add(tile);

                                if (usedFormat == TileFormat.none)
                                {
                                    if (tile.tag.EndsWith("jpg"))
                                        usedFormat = TileFormat.jpg;
                                    if (tile.tag.EndsWith("png"))
                                        usedFormat = TileFormat.png;
                                }
                            }
                        }

                    }

                    if (usedFormat == TileFormat.none)
                    {
                        MessageBox.Show("Unable to get tile image format");
                        goto end;
                    }

                    var onTileCreate = delegate (MemoryStream stream, Tile tile)
                    {
                        var screenEntry = kmzArchive.GetEntry(tile.tag);
                        if (screenEntry != null)
                        {
                            var screenStream = screenEntry.Open();
                            screenStream.SetLength(0);
                            stream.Seek(0, SeekOrigin.Begin);
                            stream.CopyTo(screenStream);
                            screenStream.Close();
                            updated++;
                        }
                    };

                    var result = await CreateTiles(onTileCreate, usedFormat, 15, tiles);
                }
            end:
                kmzArchive.Dispose();
                SetButtonsState(true);
                MessageBox.Show(updated + " tiles udpated !");
            }
        }


        string lastTempFolder = string.Empty;



        class ViewInfos
        {
            public List<Tile> tiles = new List<Tile>();
            public double centerLat = 0;
            public double centerLng = 0;
        }

        ViewInfos GetTilesInfosForCurrentView(int zoom)
        {
            var viewInfos = new ViewInfos();

            //await using var devToolsContext = await webView21.CoreWebView2.CreateDevToolsContextAsync();

            //var bScript = "(value) => ({east: map.getBounds().getEast(), west: map.getBounds().getWest(), north: map.getBounds().getNorth(), south: map.getBounds().getSouth()}) ";
            //var bounds = await devToolsContext.EvaluateFunctionAsync<dynamic>(bScript);


            var minPoint = Tile.WorldToTilePos(mapControl.TopLeft.Longitude, mapControl.TopLeft.Latitude, zoom);
            var maxPoint = Tile.WorldToTilePos(mapControl.BottomRight.Longitude, mapControl.BottomRight.Latitude, zoom);

            for (double x = Math.Floor(minPoint.X); x <= Math.Floor(maxPoint.X); x++)
            {
                for (double y = Math.Floor(minPoint.Y); y <= Math.Floor(maxPoint.Y); y++)
                {
                    viewInfos.tiles.Add(new Tile(new Point((int)x, (int)y), new Point((int)x + 1, (int)y + 1), zoom));
                }
            }

            viewInfos.centerLat = mapControl.Center.Latitude;
            viewInfos.centerLng = mapControl.Center.Longitude;


            return viewInfos;
        }

        enum TileFormat
        {
            png,
            jpg,
            none,
        }

        const int PicBoxSize = 200;

        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        async Task<bool> CreateTiles(Action<MemoryStream, Tile> onTileCreated, TileFormat format, int zoom, List<Tile>? customTiles = null)
        {
            //if (!CheckUri())
            //    return false;


            if (!DownloadGranted)
                return false;


            abordWork = false;

            SetButtonsState(false);

            var finalFormat = format == TileFormat.png ? System.Drawing.Imaging.ImageFormat.Png : System.Drawing.Imaging.ImageFormat.Jpeg;

            progressBar1.Value = 0;
            var tiles = new List<Tile>();
            if (customTiles == null)
            {
                var viewInfos = GetTilesInfosForCurrentView(zoom);
                tiles = viewInfos.tiles;
            }
            else
            {
                tiles = customTiles;
            }

            var tileWorks = new List<List<Tile>>();
            var tilesCount = tiles.Count;
            var workCount = (int)threadCount.Value;
            if (workCount > 1)
            {
                if (tilesCount < 5)
                    workCount = 1;
                if (tilesCount < 10)
                    workCount = 2;
            }
            var workTileCount = tilesCount / workCount;
            progressBar1.Maximum = tiles.Count;
            while (tiles.Count > 0)
            {
                var tilesToTake = workTileCount;
                if (tiles.Count < tilesToTake)
                    tilesToTake = tiles.Count;
                tileWorks.Add(tiles.GetRange(0, tilesToTake));
                tiles.RemoveRange(0, tilesToTake);
            }

            tabControl1.SelectedIndex = 2;
            foreach (var tileWork in tileWorks)
            {
                var newFlow = new FlowLayoutPanel();
                newFlow.FlowDirection = FlowDirection.LeftToRight;
                newFlow.Size = new Size(PicBoxSize, PicBoxSize + 15);

                var newProgressBar = new System.Windows.Forms.ProgressBar();
                newProgressBar.Size = new Size(PicBoxSize, 10);
                newProgressBar.Style = ProgressBarStyle.Continuous;

                var newPictureBox = new PictureBox();
                newPictureBox.Enabled = false;
                newPictureBox.Size = new Size(PicBoxSize, PicBoxSize);

                newFlow.Controls.Add(newPictureBox);
                newFlow.Controls.Add(newProgressBar);

                flowLayoutPanel1.Controls.Add(newFlow);

                newProgressBar.Maximum = tileWork.Count;
                var nextTileWork = delegate ()
                {
                    if (abordWork)
                        return;

                    if (newProgressBar.Value > tileWork.Count - 1)
                        return;

                    var tile = tileWork[newProgressBar.Value];

                    

                    string[] sub = { "a", "b", "c" };
                    var usedSub = sub[new Random().Next(sub.Length)];

                    var url_prefix = "https://heatmap-external-" + usedSub + ".strava.com/tiles-auth/";
                    var url_suffix = "/" + zoom + "/" + tile.x1 + "/" + tile.y1 + ".png";
                    var map_type = activityType.SelectedItem.ToString();
                    if (string.IsNullOrEmpty(map_type))
                        map_type = "all";
                    var map_color = mapStyle.SelectedItem.ToString();
                    if (string.IsNullOrEmpty(map_color))
                        map_color = "hot";
                    var query_string = "?Key-Pair-Id=" + pair + "&Policy=" + policy + "&Signature=" + signature;
                    var tile_url = url_prefix + map_type + '/' + map_color + url_suffix + query_string;
                    //MessageBox.Show(tile_url);

                    try
                    {
                        newPictureBox.Tag = tile;
                        newPictureBox.LoadAsync(tile_url);
                    }
                    catch
                    {
                        MessageBox.Show("Error while getting tile");
                        return;
                    }
                    
                };

                newPictureBox.LoadCompleted += (sender, e) =>
                {
                    if (e.Error != null)
                        Debug.WriteLine(e.Error);
                    else
                    {
                        var bmp = new Bitmap(newPictureBox.Image.Width, newPictureBox.Image.Height);
                        var g = Graphics.FromImage(bmp);
                        g.FillRectangle(Brushes.WhiteSmoke, 0, 0, newPictureBox.Image.Width, newPictureBox.Image.Height);
                        g.DrawImage(newPictureBox.Image, 0, 0);
                        g.Save();
                        MemoryStream memoryStream = new();
                        var tile = newPictureBox.Tag as Tile;
                        if (tile != null)
                        {
                            bmp.Save(memoryStream, finalFormat);
                            onTileCreated(memoryStream, tile);
                        }
                    }

                    progressBar1.Value++;
                    newProgressBar.Value++;

                    nextTileWork();
                };
                nextTileWork();

            }

            while (progressBar1.Value < progressBar1.Maximum)
            {
                if (abordWork)
                    goto end;
                await Task.Delay(100);
            }


        end:
            while (flowLayoutPanel1.Controls.Count > 1)
                flowLayoutPanel1.Controls.RemoveAt(1);
            SetButtonsState(true);
            return !abordWork;

        }

        async Task CreateAndSaveTile(TileFormat format, string folder, int zoom) // folder end with '\'
        {
            folder += zoom + @"\";

            var onTileCreated = delegate (MemoryStream stream, Tile tile)
            {
                Bitmap screenBitmap = new(stream);
                if (mapStyle.SelectedIndex == 0)
                    screenBitmap.MakeTransparent(Color.White);

                var relativePath = tile.x1 + @"\" + tile.y1 + ".png";
                var screenPath = folder + relativePath;

                var screenFileInfo = new FileInfo(screenPath);
                var screenFileDir = screenFileInfo.Directory;
                if (screenFileDir != null && !screenFileDir.Exists)
                    screenFileDir.Create();

                screenBitmap.Save(screenPath);
            };

            await CreateTiles(onTileCreated, format, (int)tileZoom.Value);


        }

        private void NewWebView_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        async private void createTiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select directory where to save tiles";

            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var folder = folderBrowserDialog.SelectedPath + @"\";
                await CreateAndSaveTile(TileFormat.png, folder, (int)tileZoom.Value);
            }
        }

        private void createKarooTiles_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //folderBrowserDialog.Description = "Select folder with adb.exe";

            //var result = folderBrowserDialog.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    var adbPath = folderBrowserDialog.SelectedPath + @"\adb.exe";
            //    var fileInfos = new FileInfo(adbPath);
            //    if (!fileInfos.Exists)
            //    {
            //        MessageBox.Show("Can't find adb.exe !");
            //        return;
            //    }

            //    var folder = Path.GetTempPath() + new Random().Next() + @"\";
            //    lastTempFolder = folder;
            //    await CreateAndSaveTile(TileFormat.png, folder, (int)tileSize.Value, (int)tileZoom.Value);

            //    Process process = new();
            //    ProcessStartInfo startInfo = new();
            //    //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //    startInfo.FileName = adbPath;
            //    folder += (int)tileZoom.Value + @"\";
            //    startInfo.Arguments = "push \"" + folder + ".\" /sdcard/offline/heatmap/" + (int)tileZoom.Value + "/";
            //    process.StartInfo = startInfo;
            //    process.Start();
            //    process.WaitForExit();

            //    if (Directory.Exists(lastTempFolder))
            //        Directory.Delete(lastTempFolder, true);
            //}
            new SendToAndroid().ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists(lastTempFolder))
                Directory.Delete(lastTempFolder, true);
        }

        bool abordWork = false;
        private void abord_Click(object sender, EventArgs e)
        {
            abordWork = true;
        }

        async private void updateTiles_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select tiles folder";

            var result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var tileDirInfos = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                var tiles = new List<Tile>();
                foreach (var dirInfos in tileDirInfos.GetDirectories())
                {
                    int zoomNum = 0;
                    if (int.TryParse(dirInfos.Name, out zoomNum))
                    {
                        foreach (var subDirInfos in dirInfos.GetDirectories())
                        {
                            int xTile = 0;
                            if (int.TryParse(subDirInfos.Name, out xTile))
                            {
                                foreach (var file in subDirInfos.GetFiles("*.png"))
                                {
                                    int yTile = 0;
                                    if (int.TryParse(Path.GetFileNameWithoutExtension(file.Name), out yTile))
                                    {
                                        var newTile = new Tile(new Point(xTile, yTile), new Point(xTile + 1, yTile + 1), zoomNum);
                                        newTile.tag = file.FullName;
                                        tiles.Add(newTile);
                                    }
                                }
                            }
                        }
                    }
                }

                var onTileCreated = delegate (MemoryStream stream, Tile tile)
                {
                    Bitmap screenBitmap = new(stream);
                    if (mapStyle.SelectedIndex == 0)
                        screenBitmap.MakeTransparent(Color.White);

                    screenBitmap.Save(tile.tag);
                };

                await CreateTiles(onTileCreated, TileFormat.png, (int)tileZoom.Value, tiles);

            }
        }

        private void webView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {

        }

        async private void button1_Click(object sender, EventArgs e)
        {
            //webView21.ExecuteScriptAsync("let getActive = browser.tabs.query({  active: true,  currentWindow: true,}); console.log(getActive)");
            var cookies = await webView21.CoreWebView2.CookieManager.GetCookiesAsync(string.Empty);
            foreach (var cookie in cookies)
            {
                Debug.WriteLine(cookie.Name + " : " + cookie.Value);
            }
            // webView21.ExecuteScriptAsync("alert(document.cookie)");
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        string? pair, policy, signature;

        bool DownloadGranted
        {
            get
            {
                return pair != null && policy != null && signature != null;
            }
        }

        async private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var getKeys = async delegate ()
            {
                pair = await GetCookieValByName("CloudFront-Key-Pair-Id");
                policy = await GetCookieValByName("CloudFront-Policy");
                signature = await GetCookieValByName("CloudFront-Signature");
            };

            while (true)
            {
                await Task.Delay(1000);

                if (e.Cancel)
                    return;

                Debug.WriteLine("tick");

                await Invoke(getKeys);

                if (pair != null || policy != null || signature != null)
                    break;
            }

            var completed = delegate ()
            {
                SetButtonsState(true);
                tabControl1.SelectedIndex = 1;
            };
            Invoke(completed);

            e.Result = true;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex > 0 && !DownloadGranted)
            {
                MessageBox.Show("Connect on your strava account on global heatmap before !");
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        const string heatmapurl = "https://www.strava.com/maps/global-heatmap";
        private void bBackHome_Click(object sender, EventArgs e)
        {
            webView21.Source = new Uri(heatmapurl, UriKind.Absolute);
        }
    }


}