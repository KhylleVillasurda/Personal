using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
/*
************************************************************
*                                                          *
*     KYAAAAAA!!!   PLEASE DON'T TOUCH THIS CODE!          *
*                                                          *
*  I am steve, nah,                                        *
*      Edit the code at your own risk!                     *
* Also the notes helps you understand the code well.       *
*                                                          *
*  Would you be gay enough to find the redundant code?     *
*  Let's see shall we?                                     *
*                                                          *
************************************************************

                     ______________
                  ,-'            _-`-._
                ,'          _,-'       `.
               /         _,'              `.
              |       _,'    ___            `.
             |     ,'    ,-'   `.             \
            |   ,'     ,'        `.    \       \
           /   /      /             \    .      \
          /   /      /               `-._|       \
         /   /      /      "DRAGON"      ||       \
        /   /      /                    / |        \
       /   /      /              _.----'  |         \
      /   /      /            ,-'  _      |          \
     /   /      /          ,-'    (_)     |           \
    /   /      /        ,-'                \           \
   /   /      /      ,-'                    `.          \
  /   /      /     ,'                         `.         \
 /   /      /    ,'                             `.        \
/___/______/____/_________________________________\________\
*/



namespace videoTest6
{
    public partial class Form1 : Form
    {
        private Font _minecraftFont;
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        private VideoView _videoView;
        private List<Process> _calculatedResult;
        private int _animationCounter = 0;
        private const int AnimationSteps = 10;
        private List<string> _videoResourceNames;
        private List<string> _videoPlaylist;
        private int _currentVideoIndex = 0;
        private bool _autoplayEnabled = true;
        private string _tempDirectory;
        Image img = videoTest6.Properties.Resources.exitBtn;
        private bool isPlaying = true;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        public Form1()
        {
            InitializeComponent();

            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;
        }

        private void PrepareProcesses()
        {
            List<Process> processes = new List<Process>();

            foreach (DataGridViewRow row in dgvProcesses.Rows)
            {
                if (row.Cells[0].Value != null &&
                    row.Cells[1].Value != null &&
                    row.Cells[2].Value != null)
                {
                    processes.Add(new Process
                    {
                        Name = row.Cells[0].Value.ToString(),
                        ArrivalTime = int.Parse(row.Cells[1].Value.ToString()),
                        BurstTime = int.Parse(row.Cells[2].Value.ToString())
                    });
                }
            }

            if (processes.Count > 0)
            {
                _calculatedResult = CalculateFCFS(processes);
            }
        }

        private void ShowResults()
        {
            if (_calculatedResult != null)
            {
                DrawGanttChart(_calculatedResult);
                DisplayResults(_calculatedResult);
            }
        }

        private void timerGif_Tick(object sender, EventArgs e)
        {
            // Stop the timer 
            timerGif.Stop();

            // Hide the GIF
            minecraftLoad.Visible = false;

            // Show the results
            pnlGanttChart.Visible = true;
            rtbOutput.Visible = true;

            // Re-enable the button
            btnCalculate.Enabled = true;

            // Display the actual results
            ShowResults();
            //Also Definitely dont touch this! 
        }


        public class Process
        {
            public string Name { get; set; }
            public int ArrivalTime { get; set; }
            public int BurstTime { get; set; }
            public int CompletionTime { get; set; }
            public int TurnaroundTime { get; set; }
            public int WaitingTime { get; set; }
        }

        private List<Process> CalculateFCFS(List<Process> processes)
        {
            // Sort processes by arrival time
            var sortedProcesses = processes.OrderBy(p => p.ArrivalTime).ToList();

            int currentTime = 0;

            foreach (var process in sortedProcesses)
            {
                if (currentTime < process.ArrivalTime)
                {
                    currentTime = process.ArrivalTime;
                }

                process.CompletionTime = currentTime + process.BurstTime;
                process.TurnaroundTime = process.CompletionTime - process.ArrivalTime;
                process.WaitingTime = process.TurnaroundTime - process.BurstTime;

                currentTime = process.CompletionTime;
            }

            return sortedProcesses;
        }

        private void Form1_Load(object sender, EventArgs e)///////////////////////////////////////////////////////////////////////FORM
        {
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;

            ApplyMinecraftFontToAll(this.Controls, _minecraftFont);

            Core.Initialize();
            _libVLC = new LibVLC("--avcodec-hw=dxva2");
            _mediaPlayer = new MediaPlayer(_libVLC);

            _videoView = new VideoView { Dock = DockStyle.Fill };
            panel1.Controls.Add(_videoView);
            _videoView.MediaPlayer = _mediaPlayer;

            SetupVideoPlaylist();

            minecraftLoad.Visible = false;
            minecraftLoad.SizeMode = PictureBoxSizeMode.Zoom;

            // Timer
            timerGif.Interval = 20000;
            timerGif.Tick += timerGif_Tick;

            // Load GIF from resources
            minecraftLoad.Image = Properties.Resources.minecraftLoading; //GIF Loads before the process pls dont remove this
            dgvProcesses.Columns.Add("Name", "Process Name");
            dgvProcesses.Columns.Add("ArrivalTime", "Arrival Time");
            dgvProcesses.Columns.Add("BurstTime", "Burst Time");

            // Add some sample data
            dgvProcesses.Rows.Add("P1", 0, 5);

            dgvProcesses.CellValidating += dgvProcesses_CellValidating;
            dgvProcesses.CellEndEdit += dgvProcesses_CellEndEdit;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetupVideoControlButtons();

            // Find and hook up the exit picture box
            if (Controls["pnlBorder"] is Panel borderPanel)
            {
                foreach (Control c in borderPanel.Controls)
                {
                    if (c is PictureBox pb && pb.Name == "picBoxExit")
                    {
                        pb.Click += (s, evt) => this.Close();
                        break;
                    }
                }
            }


            _minecraftFont = LoadMinecraftFont(12f);

            ApplyMinecraftFontToAll(this.Controls, _minecraftFont);

            dgvProcesses.Font = new Font(_minecraftFont.FontFamily, 10f);
            rtbOutput.Font = new Font(_minecraftFont.FontFamily, 11f);
        }

        private void PlayCurrentVideo()
        {
            if (_videoPlaylist == null || _videoPlaylist.Count == 0)
            {
                MessageBox.Show("No videos in the playlist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_currentVideoIndex >= 0 && _currentVideoIndex < _videoPlaylist.Count)
            {
                string videoPath = _videoPlaylist[_currentVideoIndex];
                if (File.Exists(videoPath))
                {
                    var media = new Media(_libVLC, videoPath);
                    _mediaPlayer.Play(media);
                    UpdatePlayPauseButton(true); // Update to "Pause" state
                }
                else
                {
                    MessageBox.Show($"Video file not found: {videoPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Skip to the next video in the sequence
                    _currentVideoIndex = (_currentVideoIndex + 1) % _videoPlaylist.Count;
                    PlayCurrentVideo();
                }
            }
            else
            {
                MessageBox.Show("Invalid video index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SetupVideoControlButtons()
        {

            playpauseHere.Text = "Pause";
            playpauseHere.Click += playpauseHere_Click;

            nextBtn.Text = "Next";
            nextBtn.Click += nextBtn_Click;

        }
        private void MediaPlayer_EndReached(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                _currentVideoIndex = (_currentVideoIndex + 1) % _videoPlaylist.Count;
                PlayCurrentVideo();
                UpdatePlayPauseButton(true);
            }));
        }

        private void SetupVideoPlaylist()
        {
            // Create a temporary directory for extracted video resources
            _tempDirectory = Path.Combine(Path.GetTempPath(), "VideoTestApp_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(_tempDirectory);

            // List of resource names
            _videoResourceNames = new List<string> { "video1", "video2", "video3", "video4" };
            List<string> extractedFilePaths = new List<string>();

            // Extract each video resource to a temporary file
            foreach (string resourceName in _videoResourceNames)
            {
                try
                {
                    // Get the resource as a byte array
                    byte[] videoData = (byte[])Properties.Resources.ResourceManager.GetObject(resourceName);
                    if (videoData != null)
                    {
                        // Create a temporary file path
                        string tempFilePath = Path.Combine(_tempDirectory, resourceName + ".mp4");

                        // Write the resource to the temporary file
                        File.WriteAllBytes(tempFilePath, videoData);

                        // Add the path to our list
                        extractedFilePaths.Add(tempFilePath);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error extracting resource {resourceName}: {ex.Message}");
                }
            }

            _videoPlaylist = extractedFilePaths;


            _mediaPlayer.EndReached += MediaPlayer_EndReached;

            // Start the first video automatically if we have any videos
            if (_videoPlaylist.Count > 0)
            {
                panel1.Visible = true;
                PlayCurrentVideo();
            }
        }

        private void UpdatePlayPauseButton(bool isPlaying)
        {
            this.isPlaying = isPlaying;
            playpauseHere.Text = isPlaying ? "Pause" : "Play";
            playpauseHere.Refresh();
        }

        private void PlayNextVideo()
        {
            _currentVideoIndex = (_currentVideoIndex + 1) % _videoPlaylist.Count;
            PlayCurrentVideo();
        }


        private void DrawGanttChart(List<Process> processes)
        {
            pnlGanttChart.Controls.Clear();
            pnlGanttChart.Refresh();

            int scale = 30;
            int height = 40;
            int y = 10;

            int currentX = 10;

            // Draw the processes
            foreach (var process in processes)
            {
                Label processLabel = new Label();
                processLabel.Text = process.Name;
                processLabel.BackColor = GetRandomColor();
                processLabel.BorderStyle = BorderStyle.FixedSingle;
                processLabel.TextAlign = ContentAlignment.MiddleCenter;
                processLabel.Width = process.BurstTime * scale;
                processLabel.Height = height;
                processLabel.Location = new Point(currentX, y);
                pnlGanttChart.Controls.Add(processLabel);

                // Add time markers
                Label startLabel = new Label();
                startLabel.Text = (currentX - 10) / scale + "";
                startLabel.Location = new Point(currentX, y + height);
                pnlGanttChart.Controls.Add(startLabel);

                currentX += process.BurstTime * scale;
            }

            // Add final time marker
            Label endLabel = new Label();
            endLabel.Text = (currentX - 10) / scale + "";
            endLabel.Location = new Point(currentX, y + height);
            pnlGanttChart.Controls.Add(endLabel);
        }

        private Color GetRandomColor()
        {
            Random rnd = new Random();
            return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private void DisplayResults(List<Process> processes)
        {
            rtbOutput.Clear();

            rtbOutput.AppendText("Process\tAT\tBT\tCT\tTAT\tWT\n");

            foreach (var process in processes)
            {
                rtbOutput.AppendText($"{process.Name}\t{process.ArrivalTime}\t" +
                                    $"{process.BurstTime}\t{process.CompletionTime}\t" +
                                    $"{process.TurnaroundTime}\t{process.WaitingTime}\n");
            }

            // Calculate averages MWEHEHEH
            double avgTAT = processes.Average(p => p.TurnaroundTime);
            double avgWT = processes.Average(p => p.WaitingTime);

            rtbOutput.AppendText($"\nAverage Turnaround Time: {avgTAT:F2}\n");
            rtbOutput.AppendText($"Average Waiting Time: {avgWT:F2}\n");
        }

        private void dgvProcesses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlGanttChart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddProcess_Click(object sender, EventArgs e)
        {
            string processName = $"P{dgvProcesses.Rows.Count + 1}";

            // Add a new process with some default values
            // You can adjust these default values as needed
            int defaultArrivalTime = dgvProcesses.Rows.Count; // Sequential arrival
            int defaultBurstTime = new Random().Next(1, 10); // Random burst time between 1-10

            // Add to DataGridView
            dgvProcesses.Rows.Add(processName, defaultArrivalTime, defaultBurstTime);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {//So this entire button is a mess, but it works
            // Disable button during animation
            btnCalculate.Enabled = false;

            // Show loading
            minecraftLoad.Visible = true;

            // Hide results panel during animation
            pnlGanttChart.Visible = false;
            rtbOutput.Visible = false;

            // Start the timer
            timerGif.Start();

            // Prepare the processes in background (but don't show yet)
            PrepareProcesses();
        }


        private void plyBtn_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _mediaPlayer?.Stop();
            _videoView?.Dispose();
            _libVLC?.Dispose();

            // Clean up temporary files optimization is from deepseek salamat jud deepseek
            try
            {
                if (Directory.Exists(_tempDirectory))
                {
                    Directory.Delete(_tempDirectory, true);
                }
            }
            catch
            {
                // Ignore cleanup errors
            }

            base.OnFormClosing(e);
            //Optimizes Resources pls dont delete this
        }

        private void ApplyMinecraftFontToAll(Control.ControlCollection controls, Font font)
        {
            if (font == null || controls == null) return;

            foreach (Control control in controls)
            {
                if (control == null || control.IsDisposed) continue;

                try
                {
                    // Skip controls
                    if (control is PictureBox || control is VideoView) continue;

                    // Apply to standard controls
                    if (control is Label || control is Button ||
                        control is TextBox || control is RichTextBox)
                    {
                        control.Font = new Font(font.FontFamily, control.Font.Size);
                    }

                    // Handle DataGridView specially
                    if (control is DataGridView dgv && !dgv.IsDisposed)
                    {
                        dgv.Font = new Font(font.FontFamily, 10f);
                        foreach (DataGridViewColumn col in dgv.Columns)
                        {
                            col.DefaultCellStyle.Font = new Font(font.FontFamily, 10f);
                        }
                    }

                    // Recurse carefully
                    if (control.HasChildren && !control.IsDisposed)
                    {
                        ApplyMinecraftFontToAll(control.Controls, font);
                    }
                }
                catch { /* Gracefully skip errors */ }
            }
        }

        private Font LoadMinecraftFont(float size)
        {
            try
            {
                // Debug: Check if resource exists
                if (Properties.Resources.Minecraftia == null || Properties.Resources.Minecraftia.Length == 0)
                {
                    MessageBox.Show("Font resource is empty or missing");
                    return new Font("Arial", size);
                }

                var pfc = new PrivateFontCollection();

                // Pin the byte array in memory
                GCHandle handle = GCHandle.Alloc(Properties.Resources.Minecraftia, GCHandleType.Pinned);
                try
                {
                    pfc.AddMemoryFont(handle.AddrOfPinnedObject(), Properties.Resources.Minecraftia.Length);
                }
                finally
                {
                    handle.Free();
                }

                // Verify font was loaded
                if (pfc.Families.Length == 0)
                {
                    MessageBox.Show("No font families loaded");
                    return new Font("Arial", size);
                }

                return new Font(pfc.Families[0], size);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Font load failed: {ex.Message}");
                return new Font("Arial", size);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, 50, 50, 100, 100);
        }

        private void picBoxExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playpauseHere_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Pause();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (_videoPlaylist == null || _videoPlaylist.Count == 0)
            {
                MessageBox.Show("No videos in the playlist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            _currentVideoIndex = (_currentVideoIndex + 1) % _videoPlaylist.Count;

            // Play the next video
            PlayCurrentVideo();

            // Update the play/pause button to show "Pause" since the video is playing
            playpauseHere.Text = "Pause";
            isPlaying = true;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));

            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void secretLabel_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            playpauseHere.Visible = true;
            nextBtn.Visible = true;
        }
//Cell Validation Below
        private void dgvProcesses_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Only validate Arrival Time (column 1) and Burst Time (column 2)
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int value) || value < 0)
                {
                    e.Cancel = true;
                    dgvProcesses.Rows[e.RowIndex].ErrorText =
                        "Only 0 or positive numbers allowed!";
                    MessageBox.Show("Please enter 0 or a positive number!",
                                  "Invalid Input",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvProcesses_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear error text when editing is done
            dgvProcesses.Rows[e.RowIndex].ErrorText = null;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void minecraftLoad_Click(object sender, EventArgs e)
        {

        }
    }
}



