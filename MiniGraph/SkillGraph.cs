using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MiniGraph
{
    public partial class SkillGraph : Form
    {
        private MiniGraph oParentWindow;

        Dictionary<string, Color> ColorRemember = new Dictionary<string, Color>();
        List<Color> oColorList = new List<Color>();

        int nCurrentInstanceID = 0;
        public uint uPlayerID = 0;
        private string sDir = "";
        private FileSystemWatcher oWatcher = null;
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public SkillGraph(MiniGraph obj, uint uID)
        {
            InitializeComponent();

            oParentWindow = obj;

            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            sDir = oParentWindow.sDir;

            uPlayerID = uID;

            oWatcher = new FileSystemWatcher
            {
                Path = sDir,
                Filter = "InstanceData.skilldb",
                NotifyFilter = NotifyFilters.LastWrite
            };

            oWatcher.Changed += InstanceDataChanged;

            oWatcher.EnableRaisingEvents = true;

            oColorList = Extensions.Colors.ChartColorPallets.Pastel;

            SGraph.MouseWheel += new MouseEventHandler(SGraph_MouseWheel);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")] 
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                this.TransparencyKey = Color.GhostWhite;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.TransparencyKey = Color.FromArgb(222, 222, 222);
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams baseParams = base.CreateParams;

                const int WS_EX_NOACTIVATE = 0x08000000;
                baseParams.ExStyle |= (int)(WS_EX_NOACTIVATE);
                //baseParams.Style &= ~0xC00000; //WS_CAPTION;

                return baseParams;
            }
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Label1_MouseUp(object sender, MouseEventArgs e)
        {
        }

        public string[] WriteSafeReadAllLines(String path)
        {
            using (var csv = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(csv))
            {
                List<string> file = new List<string>();
                while (!sr.EndOfStream)
                {
                    file.Add(sr.ReadLine());
                }

                return file.ToArray();
            }
        }

        private void InstanceDataChanged(object source, FileSystemEventArgs e)
        {
            ReadSkillDB();
        }
        private void SkillGraph_Load(object sender, EventArgs e)
        {
            ReadSkillDB();
        }

        private void ReadSkillDB()
        {
            string sPath = oParentWindow.sLoadSkillFile;
            string sCSVPath = oParentWindow.sLoadFile;

            if (this.IsDisposed)
                return;

            Graphics G = CreateGraphics();
            int nSkills = 0;

            if (File.Exists(sPath))
            {
                string[] sLines;
                string[] sCSVLines;
                try
                {
                    sLines = WriteSafeReadAllLines(sPath);
                    sCSVLines = WriteSafeReadAllLines(sCSVPath);
                }
                catch
                {
                    return;
                }

                this.SuspendLayout();

                Font oFont = new Font("MS UI Gothic", 11f, FontStyle.Bold);
                Font oMonoFont = new Font("Consolas", 10f, FontStyle.Bold);

                if (nCurrentInstanceID == 0)
                    nCurrentInstanceID = oParentWindow.nInstanceID;

                if (nCurrentInstanceID != oParentWindow.nInstanceID)
                {
                    ColorRemember.Clear();
                    nCurrentInstanceID = oParentWindow.nInstanceID;
                }
                // Read InstanceData.csv to gather data of this player ID
                int nLine = 0;
                string sTopHeader = "";
                foreach (string line in sCSVLines)
                {
                    nLine++;
                    if (nLine < 3) continue;

                    string[] tmp = line.Split(',');
                    uint uID = 0;
                    try
                    {
                        uID = Convert.ToUInt32(tmp[0]);
                    }
                    catch (Exception e)
                    {
                        uID = 0;
                        LogError(e, "SkillDB Error! Can't convert uID while parsing InstanceData.csv - " + line);
                    }

                    if (uID == uPlayerID)
                    {
                        sTopHeader = "Class: " + tmp[3] + " ・ " + tmp[5];
                        break;
                    }
                }
                if (sTopHeader != "")
                {
                    SizeF oStringSize = G.MeasureString(sTopHeader, oFont);
                    oStringSize.Width += 4;
                    oStringSize.Height += 4;

                    Image oLabelImage = new Bitmap((int)oStringSize.Width, (int)oStringSize.Height);

                    using (Graphics oG = Graphics.FromImage(oLabelImage))
                    {
                        oG.Clear(Color.Transparent);

                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 0, 0);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 1, 0);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 2, 0);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 3, 0);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 4, 0);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 0, 1);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 1, 1);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 2, 1);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 3, 1);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 4, 1);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 0, 3);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 1, 3);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 2, 3);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 3, 3);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 4, 3);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 0, 4);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 1, 4);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 2, 4);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 3, 4);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 4, 4);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 0, 2);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 1, 2);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 3, 2);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.White), 4, 2);
                        oG.DrawString(sTopHeader, oFont, new SolidBrush(Color.Black), 2, 2);

                        TopHeader.Image = oLabelImage;
                        TopHeader.ImageAlign = ContentAlignment.MiddleLeft;
                    }
                }

                if (this.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        if (!this.Visible)
                        {
                            this.Show();
                        }
                    }));

                }
                else
                {
                    if (!this.Visible)
                    {
                        this.Show();
                    }
                }

                Chart oEncounterGraph = SGraph;
                if (SGraph.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        SGraph.Series.Clear();
                        SGraph.ChartAreas.Clear();
                        oEncounterGraph.Palette = ChartColorPalette.SemiTransparent;
                        oEncounterGraph.BackColor = Color.FromArgb(222, 222, 222);
                    }));
                }
                else
                {
                    SGraph.Series.Clear();
                    SGraph.ChartAreas.Clear();
                    oEncounterGraph.Palette = ChartColorPalette.SemiTransparent;
                    oEncounterGraph.BackColor = Color.FromArgb(222, 222, 222);
                }

                ChartArea chA = new ChartArea();
                chA.BackColor = Color.FromArgb(180, 180, 180);
                chA.Name = "EncounterGraph";
                chA.AxisX.MaximumAutoSize = 100;
                chA.AxisX.IsMarginVisible = false;
                chA.AxisX.LabelStyle.Enabled = true;
                chA.AxisX.MajorTickMark.Enabled = false;
                chA.AxisX.MajorGrid.Enabled = true;
                chA.AxisY.MajorTickMark.Enabled = false;
                chA.AxisY.MajorGrid.Enabled = false;
                chA.AxisY.MajorGrid.LineColor = Color.LightGray;
                chA.AxisY.LabelStyle.Enabled = false;
                chA.AxisX2.Enabled = AxisEnabled.True;
                chA.AxisX2.IsMarginVisible = false;
                chA.AxisX2.LabelStyle.Enabled = false;
                chA.AxisX2.MajorTickMark.Enabled = false;
                chA.AxisX2.MajorGrid.Enabled = false;
                chA.Position.X = 0;
                chA.Position.Y = 0;
                chA.Position.Width = 100;
                chA.Position.Height = 100;
                chA.BorderWidth = 0;
                chA.BorderColor = Color.Transparent;

                chA.AxisX.LabelStyle.Font = new System.Drawing.Font("MS UI Gothic", 11f, FontStyle.Bold);

                if (oEncounterGraph.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        oEncounterGraph.ChartAreas.Add(chA);
                    }));
                }
                else
                {
                    oEncounterGraph.ChartAreas.Add(chA);
                }

                Series oBottom = new Series("Bottom")
                {
                    ChartType = SeriesChartType.StackedBar
                };
                oBottom.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.No;

                Series oSeries = new Series("Players")
                {
                    ChartType = SeriesChartType.StackedBar,
                    BorderColor = Color.Black,
                    BorderWidth = 1
                };
                oSeries["PointWidth"] = "1";
                oSeries.SmartLabelStyle.Enabled = false;

                int nPos = 0;
                long lYMax = 0;

                for (int n = 0; n < oParentWindow.nColorOffset; n++)
                {
                    if (oColorList.Count > 0)
                        oColorList.RemoveAt(0);
                    else
                        break;
                }
                foreach (string sLine in sLines)
                {
                    if (sLine == "PID,AID,Damage,Min,Max,JA,Crit") continue;

                    string[] tmp = sLine.Split(',');

                    uint uPID = 0;
                    string sName = "";
                    long lDamage = 0;
                    long lMinDamage = 0;
                    long lMaxDamage = 0;
                    int nJA = 0;
                    int nCrit = 0;

                    try
                    {
                        uPID = Convert.ToUInt32(tmp[0]);
                    }
                    catch (Exception e)
                    {
                        uPID = 0;
                        LogError(e, "Error parsing skilldb line - " + sLine);
                    }

                    sName = oParentWindow.ShortenSkillName(tmp[1]);

                    try
                    {
                        lDamage = Convert.ToInt64(tmp[2]);
                    }
                    catch (Exception e)
                    {
                        lDamage = 0;
                        LogError(e, "Error parsing skilldb line - " + sLine);
                    }
                    try
                    {
                        lMinDamage = Convert.ToInt64(tmp[3]);
                    }
                    catch (Exception e)
                    {
                        lMinDamage = 0;
                        LogError(e, "Error parsing skilldb line - " + sLine);
                    }
                    try
                    {
                        lMaxDamage = Convert.ToInt64(tmp[4]);
                    }
                    catch (Exception e)
                    {
                        lMaxDamage = 0;
                        LogError(e, "Error parsing skilldb line - " + sLine);
                    }
                    try
                    {
                        nJA = Convert.ToInt32(tmp[5]);
                    }
                    catch (Exception e)
                    {
                        nJA = 0;
                        LogError(e, "Error parsing skilldb line - " + sLine);
                    }
                    try
                    {
                        nCrit = Convert.ToInt32(tmp[6]);
                    }
                    catch (Exception e)
                    {
                        nCrit = 0;
                        LogError(e, "Error parsing skilldb line - " + sLine);
                    }

                    if (uPID == uPlayerID)
                    {
                        if (lDamage > lYMax)
                            lYMax = lDamage;

                        SizeF oStringSize;
                        Image oLabelImage = null;
                        NamedImage oImageAdd = null;

                        DataPoint oPoint = new DataPoint(nPos, lDamage);
                        DataPoint oPBottom = new DataPoint(nPos, 0);

                        CustomLabel cl1 = new CustomLabel
                        {
                            FromPosition = nPos - 0.5,
                            ToPosition = nPos + 0.5
                        };

                        Color oPointColor = new Color();
                        oPoint.IsValueShownAsLabel = false;
                        if (oColorList.Count == 0)
                            oColorList = Extensions.Colors.ChartColorPallets.Pastel;
                        oPointColor = oColorList.First();
                        oColorList.RemoveAt(0);
                        if (ColorRemember.ContainsKey(uPID.ToString() + "_" + sName))
                            oPoint.Color = ColorRemember[uPID.ToString() + "_" + sName];
                        else
                        {
                            ColorRemember.Add(uPID.ToString() + "_" + sName, oPointColor);
                            oPoint.Color = oPointColor;
                        }

                        oStringSize = G.MeasureString(sName, oFont);
                        oStringSize.Width += 4;
                        oStringSize.Height += 4;

                        oLabelImage = new Bitmap((int)oStringSize.Width, (int)oStringSize.Height);

                        using (Graphics oG = Graphics.FromImage(oLabelImage))
                        {
                            oG.Clear(Color.Transparent);

                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 0, 0);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 1, 0);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 2, 0);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 3, 0);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 4, 0);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 0, 1);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 1, 1);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 2, 1);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 3, 1);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 4, 1);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 0, 3);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 1, 3);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 2, 3);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 3, 3);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 4, 3);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 0, 4);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 1, 4);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 2, 4);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 3, 4);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 4, 4);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 0, 2);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 1, 2);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 3, 2);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.White), 4, 2);
                            oG.DrawString(sName, oFont, new SolidBrush(Color.Black), 2, 2);

                            oImageAdd = new NamedImage("SkillName" + nPos.ToString(), oLabelImage);
                            bool bImageFound = false;
                            foreach (NamedImage oCheck in SGraph.Images)
                            {
                                if (oCheck.Name == "SkillName" + nPos.ToString())
                                {
                                    bImageFound = true;
                                    oCheck.Image = oLabelImage;
                                    break;
                                }
                            }
                            if (!bImageFound)
                                SGraph.Images.Add(oImageAdd);
                            cl1.Image = "SkillName" + nPos.ToString();
                        }

                        // Setting DPS Text
                        string sLabel = "";
                        string sDamage = lDamage.ToString("N0");
                        if (lDamage > 1000)
                            sDamage = (lDamage / 1000.0).ToString("N1") + "K";
                        if (lDamage > 1000000)
                            sDamage = (lDamage / 1000000.0).ToString("N2") + "M";
                        string sMinDamage = lMinDamage.ToString("N0");
                        if (lMinDamage > 1000)
                            sMinDamage = (lMinDamage / 1000.0).ToString("N1") + "K";
                        if (lMinDamage > 1000000)
                            sMinDamage = (lMinDamage / 1000000.0).ToString("N2") + "M";
                        string sMaxDamage = lMaxDamage.ToString("N0");
                        if (lMaxDamage > 1000)
                            sMaxDamage = (lMaxDamage / 1000.0).ToString("N1") + "K";
                        if (lMaxDamage > 1000000)
                            sMaxDamage = (lMaxDamage / 1000000.0).ToString("N2") + "M";

                        sLabel = $"Damage: {sDamage.PadLeft(7)} ・ Min: {sMinDamage.PadLeft(7)} ・ Max: {sMaxDamage.PadLeft(7)} ・ JA: {nJA.ToString("N0").PadLeft(3)}% ・ Crit: {nCrit.ToString("N0").PadLeft(3)}%";
                        oPBottom.Label = sLabel;


                        if (SGraph.InvokeRequired)
                        {
                            BeginInvoke((Action)(() =>
                            {
                                SGraph.ChartAreas[0].AxisX.CustomLabels.Add(cl1);
                            }));
                        }
                        else
                        {
                            SGraph.ChartAreas[0].AxisX.CustomLabels.Add(cl1);
                        }
                        oBottom.Points.Add(oPBottom);
                        oSeries.Points.Add(oPoint);

                        nSkills++;
                        nPos++;
                    }
                }

                if (SGraph.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        SGraph.ChartAreas[0].AxisX.Minimum = -0.5;
                        SGraph.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(nPos - 0.5);
                        SGraph.ChartAreas[0].AxisX2.Minimum = -0.5;
                        SGraph.ChartAreas[0].AxisX2.Maximum = Convert.ToDouble(nPos - 0.5);

                        SGraph.ChartAreas[0].AxisY.Maximum = lYMax;

                        if (nSkills > 10)
                        {
                            SGraph.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                            SGraph.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                            SGraph.ChartAreas[0].AxisX.ScaleView.Size = 10;
                            SGraph.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                            SGraph.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
                            SGraph.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.First);
                            SGraph.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
                        }

                        SGraph.Series.Add(oBottom);
                        SGraph.Series.Add(oSeries);
                    }));
                }
                else
                {
                    SGraph.ChartAreas[0].AxisX.Minimum = -0.5;
                    SGraph.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(nPos - 0.5);
                    SGraph.ChartAreas[0].AxisX2.Minimum = -0.5;
                    SGraph.ChartAreas[0].AxisX2.Maximum = Convert.ToDouble(nPos - 0.5);

                    SGraph.ChartAreas[0].AxisY.Maximum = lYMax;

                    if (nSkills > 10)
                    {
                        SGraph.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                        SGraph.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                        SGraph.ChartAreas[0].AxisX.ScaleView.Size = 10;
                        SGraph.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
                        SGraph.ChartAreas[0].AxisX.ScrollBar.ButtonColor = Color.LightGray;
                        SGraph.ChartAreas[0].AxisX.ScrollBar.BackColor = Color.Gray;
                        SGraph.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;
                        SGraph.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
                        SGraph.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.First);
                        SGraph.ChartAreas[0].AxisX.ScaleView.Scroll(ScrollType.Last);
                    }

                    SGraph.Series.Add(oBottom);
                    SGraph.Series.Add(oSeries);
                }
            }

            this.ResumeLayout();

            int nNewHeight = 0;
            if (this.FormBorderStyle == FormBorderStyle.SizableToolWindow)
                nNewHeight = 83;
            else
                nNewHeight = 58;
            if (nSkills < 11)
                nNewHeight += (28 * (nSkills));
            else
                nNewHeight += (28 * 10);

            if (this.InvokeRequired)
            {
                BeginInvoke((Action)(() =>
                {
                    this.Size = new System.Drawing.Size(this.Width, nNewHeight);
                }));
            }
            else
            {
                this.Size = new System.Drawing.Size(this.Width, nNewHeight);
            }
        }

        private void SGraph_MouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                Axis xAxis = SGraph.ChartAreas[0].AxisX;

                if (e.Delta < 0)
                {
                    // Scrolled down
                    xAxis.ScaleView.Scroll(ScrollType.SmallDecrement);
                }
                else if (e.Delta > 0)
                {
                    // Scrolled up
                    xAxis.ScaleView.Scroll(ScrollType.SmallIncrement);
                }
            }
            catch { }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LogError(Exception e, string sErrorMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\MiniGraph-Skill.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + Environment.NewLine + "Error Message : " + sErrorMsg);
                logWriter.WriteLine("Message :" + e.Message + "<br/>" + Environment.NewLine + "StackTrace :" + e.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                logWriter.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
        public void LogError(string sErrorMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\MiniGraph-Skill.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + " - Error Message : " + sErrorMsg);
            }
        }
        public void LogMessage(string sErrorMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\MiniGraph-Skill.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + Environment.NewLine + sErrorMsg);
            }
        }

    }
}
