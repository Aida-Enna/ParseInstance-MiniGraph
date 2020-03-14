using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Timers;

using System.Runtime.InteropServices;


namespace MiniGraph
{
    namespace Extensions.Colors
    {
        public static class ChartColorPallets
        {

            public static List<Color> Bright
                => new List<Color>() {
                "#008000".FromHex(),
                "#0000FF".FromHex(),
                "#800080".FromHex(),
                "#00FF00".FromHex(),
                "#FF00FF".FromHex(),
                "#008080".FromHex(),
                "#FFFF00".FromHex(),
                "#808080".FromHex(),
                "#00FFFF".FromHex(),
                "#000080".FromHex(),
                "#800000".FromHex(),
                "#FF0000".FromHex(),
                "#808000".FromHex(),
                "#C0C0C0".FromHex(),
                "#FF6347".FromHex(),
                "#FFE4B5".FromHex()
            };
            public static List<Color> GreyScale
                => new List<Color>() {
                "#C8C8C8".FromHex(),
                "#BDBDBD".FromHex(),
                "#B2B2B2".FromHex(),
                "#A7A7A7".FromHex(),
                "#9C9C9C".FromHex(),
                "#919191".FromHex(),
                "#868686".FromHex(),
                "#7B7B7B".FromHex(),
                "#707070".FromHex(),
                "#656565".FromHex(),
                "#5A5A5A".FromHex(),
                "#4F4F4F".FromHex(),
                "#444444".FromHex(),
                "#393939".FromHex(),
                "#2E2E2E".FromHex(),
                "#232323".FromHex()
            };
            public static List<Color> Excel
                => new List<Color>() {
                "#9999FF".FromHex(),
                "#993366".FromHex(),
                "#FFFFCC".FromHex(),
                "#CCFFFF".FromHex(),
                "#660066".FromHex(),
                "#FF8080".FromHex(),
                "#0066CC".FromHex(),
                "#CCCCFF".FromHex(),
                "#000080".FromHex(),
                "#FF00FF".FromHex(),
                "#FFFF00".FromHex(),
                "#00FFFF".FromHex(),
                "#800080".FromHex(),
                "#800000".FromHex(),
                "#008080".FromHex(),
                "#0000FF".FromHex()
            };
            public static List<Color> Light
                => new List<Color>() {
                "#E6E6FA".FromHex(),
                "#FFF0F5".FromHex(),
                "#FFDAB9".FromHex(),
                "#FFFACD".FromHex(),
                "#FFE4E1".FromHex(),
                "#F0FFF0".FromHex(),
                "#F0F8FF".FromHex(),
                "#F5F5F5".FromHex(),
                "#FAEBD7".FromHex(),
                "#E0FFFF".FromHex()
            };
            public static List<Color> Pastel
                => new List<Color>() {
                "#87CEEB".FromHex(),
                "#32CD32".FromHex(),
                "#BA55D3".FromHex(),
                "#F08080".FromHex(),
                "#4682B4".FromHex(),
                "#9ACD32".FromHex(),
                "#40E0D0".FromHex(),
                "#FF69B4".FromHex(),
                "#F0E68C".FromHex(),
                "#D2B48C".FromHex(),
                "#8FBC8B".FromHex(),
                "#6495ED".FromHex(),
                "#DDA0DD".FromHex(),
                "#5F9EA0".FromHex(),
                "#FFDAB9".FromHex(),
                "#FFA07A".FromHex()
            };
            public static List<Color> EarthTones
                => new List<Color>() {
                "#FF8000".FromHex(),
                "#B8860B".FromHex(),
                "#C04000".FromHex(),
                "#6B8E23".FromHex(),
                "#CD853F".FromHex(),
                "#C0C000".FromHex(),
                "#228B22".FromHex(),
                "#D2691E".FromHex(),
                "#808000".FromHex(),
                "#20B2AA".FromHex(),
                "#F4A460".FromHex(),
                "#00C000".FromHex(),
                "#8FBC8B".FromHex(),
                "#B22222".FromHex(),
                "#8B4513".FromHex(),
                "#C00000".FromHex()
            };
            public static List<Color> SemiTransparent
                => new List<Color>() {
                "#FF0000".FromHex(),
                "#00FF00".FromHex(),
                "#0000FF".FromHex(),
                "#FFFF00".FromHex(),
                "#00FFFF".FromHex(),
                "#FF00FF".FromHex(),
                "#AA7814".FromHex(),
                "#FF0000".FromHex(),
                "#00FF00".FromHex(),
                "#0000FF".FromHex(),
                "#FFFF00".FromHex(),
                "#00FFFF".FromHex(),
                "#FF00FF".FromHex(),
                "#AA7814".FromHex(),
                "#647832".FromHex(),
                "#285A96".FromHex()
            };
            public static List<Color> Berry
                => new List<Color>() {
                "#8A2BE2".FromHex(),
                "#BA55D3".FromHex(),
                "#4169E1".FromHex(),
                "#C71585".FromHex(),
                "#0000FF".FromHex(),
                "#8A2BE2".FromHex(),
                "#DA70D6".FromHex(),
                "#7B68EE".FromHex(),
                "#C000C0".FromHex(),
                "#0000CD".FromHex(),
                "#800080".FromHex()
            };
            public static List<Color> Chocolate
                => new List<Color>() {
                "#A0522D".FromHex(),
                "#D2691E".FromHex(),
                "#8B0000".FromHex(),
                "#CD853F".FromHex(),
                "#A52A2A".FromHex(),
                "#F4A460".FromHex(),
                "#8B4513".FromHex(),
                "#C04000".FromHex(),
                "#B22222".FromHex(),
                "#B65C3A".FromHex()
            };
            public static List<Color> Fire
                => new List<Color>() {
                "#FFD700".FromHex(),
                "#FF0000".FromHex(),
                "#FF1493".FromHex(),
                "#DC143C".FromHex(),
                "#FF8C00".FromHex(),
                "#FF00FF".FromHex(),
                "#FFFF00".FromHex(),
                "#FF4500".FromHex(),
                "#C71585".FromHex(),
                "#DDE221".FromHex()
            };
            public static List<Color> SeaGreen
                => new List<Color>() {
                "#2E8B57".FromHex(),
                "#66CDAA".FromHex(),
                "#4682B4".FromHex(),
                "#008B8B".FromHex(),
                "#5F9EA0".FromHex(),
                "#3CB371".FromHex(),
                "#48D1CC".FromHex(),
                "#B0C4DE".FromHex(),
                "#8FBC8B".FromHex(),
                "#87CEEB".FromHex()
            };
            public static List<Color> BrightPastel
                => new List<Color>() {
                "#418CF0".FromHex(),
                "#FCB441".FromHex(),
                "#E0400A".FromHex(),
                "#056492".FromHex(),
                "#BFBFBF".FromHex(),
                "#1A3B69".FromHex(),
                "#FFE382".FromHex(),
                "#129CDD".FromHex(),
                "#CA6B4B".FromHex(),
                "#005CDB".FromHex(),
                "#F3D288".FromHex(),
                "#506381".FromHex(),
                "#F1B9A8".FromHex(),
                "#E0830A".FromHex(),
                "#7893BE".FromHex()
            };
            private static Color FromHex(this string hex) => ColorTranslator.FromHtml(hex);
        }
    }
    public partial class MiniGraph : Form
    {
        public string sDir = "";

        public int nColorOffset = 0;
        public int nInstanceID = 0;

        int nIconWidth = 0;
        int nIconHeight = 0;

        uint uPlayerID = 0;

        int nTitlebarHeight = 0;
        int nBorderWidth = 0;
        int nNameImageWidth = 0;

        Image oIcon_Disc = null;
        Image oIcon_MusicDisc = null;

        Image oIcon_Class_HU = null;
        Image oIcon_Class_RA = null;
        Image oIcon_Class_FO = null;
        Image oIcon_Class_FI = null;
        Image oIcon_Class_GU = null;
        Image oIcon_Class_TE = null;
        Image oIcon_Class_BR = null;
        Image oIcon_Class_BO = null;
        Image oIcon_Class_SU = null;
        Image oIcon_Class_HR = null;
        Image oIcon_Class_PH = null;
        Image oIcon_Class_ET = null;

        Image oIcon_Weapon_Gunslash = null;
        Image oIcon_Weapon_Sword = null;
        Image oIcon_Weapon_Partisan = null;
        Image oIcon_Weapon_WireLance = null;
        Image oIcon_Weapon_Rifle = null;
        Image oIcon_Weapon_Launcher = null;
        Image oIcon_Weapon_Rod = null;
        Image oIcon_Weapon_Talis = null;
        Image oIcon_Weapon_Knuckle = null;
        Image oIcon_Weapon_TwinDagger = null;
        Image oIcon_Weapon_DoubleSaber = null;
        Image oIcon_Weapon_TwinMachinegun = null;
        Image oIcon_Weapon_Wand = null;
        Image oIcon_Weapon_Katana = null;
        Image oIcon_Weapon_BulletBow = null;
        Image oIcon_Weapon_DualBlades = null;
        Image oIcon_Weapon_JetBoots = null;
        Image oIcon_Weapon_Tact = null;
        Image oIcon_Pets = null;

        Image oIcon_Technique_Foie = null;
        Image oIcon_Technique_Barta = null;
        Image oIcon_Technique_Zonde = null;
        Image oIcon_Technique_Zan = null;
        Image oIcon_Technique_Grants = null;
        Image oIcon_Technique_Megid = null;
        Image oIcon_Technique_Compound = null;

        Image oIcon_DarkBlast = null;
        Image oIcon_SClassAffix = null;

        int nPosX = 0;
        int nPosY = 0;
        int nMainWidth = 0;
        //int nMainHeight = 0;
        int nMainOpacity = 0;
        int nBorderYesNo = 1;
        int nMode = 1; // Full = 1, Basic = 0;

        int nInitX = 0;
        int nInitY = 0;
        
        int nPlayers = 0;

        bool bHotkeyRegistered = false;
        bool bMoving = false;

        DateTime tLastUpdate = new DateTime();
        System.Timers.Timer oTimer = null;

        List<SkillGraph> oSkillsShown = new List<SkillGraph>();

        Dictionary<uint, Color> ColorRemember = new Dictionary<uint, Color>();

        public string sLoadFile = "";
        public string sLoadSkillFile = "";

        bool bFull = true;
        int nBarWidth = 28;

        List<Color> oColorList = new List<Color>();

        ToolTip ShowPlayerName = new ToolTip();

        AboutBox about = new AboutBox();

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        FileSystemWatcher oWatcher = null;
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public MiniGraph()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            sDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            //sDir = "\\\\REHOME01\\pso2_bin\\ACT\\Plugins";
            //sDir = "\\\\REHOME01\\pso2_bin\\BOOM";
            //sDir = "C:\\Users\\ryuue\\source\\repos\\ParseInstance\\ParseInstance\\bin\\Debug";

            sLoadFile = sDir + "\\InstanceData.csv";
            sLoadSkillFile = sDir + "\\InstanceData.skilldb";
            
            Assembly myAssembly = Assembly.GetExecutingAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.Disc.png");
            oIcon_Disc = Image.FromStream(myStream);

            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.MusicDisc.png");
            oIcon_MusicDisc = Image.FromStream(myStream);

            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-HU.png");
            oIcon_Class_HU = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-RA.png");
            oIcon_Class_RA = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-FO.png");
            oIcon_Class_FO = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-FI.png");
            oIcon_Class_FI = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-GU.png");
            oIcon_Class_GU = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-TE.png");
            oIcon_Class_TE = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-BR.png");
            oIcon_Class_BR = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-BO.png");
            oIcon_Class_BO = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-SU.png");
            oIcon_Class_SU = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-HR.png");
            oIcon_Class_HR = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-PH.png");
            oIcon_Class_PH = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.ClassIcon-ET.png");
            oIcon_Class_ET = Image.FromStream(myStream);

            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Gunslash.png");
            oIcon_Weapon_Gunslash = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Sword.png");
            oIcon_Weapon_Sword = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Partisan.png");
            oIcon_Weapon_Partisan = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-WireLance.png");
            oIcon_Weapon_WireLance = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Rifle.png");
            oIcon_Weapon_Rifle = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Launcher.png");
            oIcon_Weapon_Launcher = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Rod.png");
            oIcon_Weapon_Rod = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Talis.png");
            oIcon_Weapon_Talis = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Knuckle.png");
            oIcon_Weapon_Knuckle = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-TwinDagger.png");
            oIcon_Weapon_TwinDagger = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-DoubleSaber.png");
            oIcon_Weapon_DoubleSaber = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-TwinMachinegun.png");
            oIcon_Weapon_TwinMachinegun = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Wand.png");
            oIcon_Weapon_Wand = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Katana.png");
            oIcon_Weapon_Katana = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-BulletBow.png");
            oIcon_Weapon_BulletBow = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-DualBlades.png");
            oIcon_Weapon_DualBlades = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-JetBoots.png");
            oIcon_Weapon_JetBoots = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.WeaponIcon-Tact.png");
            oIcon_Weapon_Tact = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.Pets.png");
            oIcon_Pets = Image.FromStream(myStream);

            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.TechniqueIcon-Foie.png");
            oIcon_Technique_Foie = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.TechniqueIcon-Barta.png");
            oIcon_Technique_Barta = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.TechniqueIcon-Zonde.png");
            oIcon_Technique_Zonde = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.TechniqueIcon-Zan.png");
            oIcon_Technique_Zan = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.TechniqueIcon-Grants.png");
            oIcon_Technique_Grants = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.TechniqueIcon-Megid.png");
            oIcon_Technique_Megid = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.TechniqueIcon-Compound.png");
            oIcon_Technique_Compound = Image.FromStream(myStream);

            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.DarkBlast.png");
            oIcon_DarkBlast = Image.FromStream(myStream);
            myStream = myAssembly.GetManifestResourceStream("MiniGraph.Icons.OtherIcon-S-ClassAffix.png");
            oIcon_SClassAffix = Image.FromStream(myStream);

            nIconWidth = oIcon_MusicDisc.Width;
            nIconHeight = oIcon_MusicDisc.Height;

            bHotkeyRegistered = RegisterHotKey(this.Handle, 1, 0x0002, (int)Keys.Tab);

            oWatcher = new FileSystemWatcher
            {
                Path = sDir,
                Filter = "InstanceData.csv",
                NotifyFilter = NotifyFilters.LastWrite
            };

            oWatcher.Changed += InstanceDataChanged;

            oWatcher.EnableRaisingEvents = true;

            this.Move += new System.EventHandler(this.WindowMoved);
            this.ResizeEnd += new System.EventHandler(this.WindowResized);

            this.FormClosing += Form_Closing;

            oColorList = Extensions.Colors.ChartColorPallets.Pastel;

            Rectangle rScreen = this.RectangleToScreen(this.ClientRectangle);
            nTitlebarHeight = rScreen.Top - this.Top;
            nBorderWidth = rScreen.Left - this.Left;

            ReadSettingsFile();
            nInitX = nPosX;
            nInitY = nPosY;
        }

        /*
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }
        */

        private void Form_Closing(Object sender, FormClosingEventArgs e)
        {
            if (bHotkeyRegistered)
                UnregisterHotKey(this.Handle, 1);

            UpdateSettingsFile();
        }
        protected override void WndProc(ref Message m)
        {
            // 5. Catch when a HotKey is pressed !
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                // MessageBox.Show(string.Format("Hotkey #{0} pressed", id));

                if (id == 1)
                {
                    if (this.Visible)
                    {
                        this.Hide();
                        oTimer.Enabled = false;
                    }
                    else
                    {
                        this.Show();
                        oTimer.Enabled = true;
                        tLastUpdate = DateTime.Now;
                    }
                    UpdateSkillWindows();
                }
            }

            base.WndProc(ref m);
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
        

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void InstanceDataChanged(object source, FileSystemEventArgs e)
        {
            sLoadFile = sDir + "\\InstanceData.csv";
            sLoadSkillFile = sDir + "\\InstanceData.skilldb";

            if (this.InvokeRequired)
            {
                BeginInvoke((Action)(() =>
                {
                    ReadInstanceData();
                }));
            }
            else
                ReadInstanceData();
        }

        private void WindowMoved(object sender, System.EventArgs e)
        {
            nPosX = this.Location.X;
            nPosY = this.Location.Y;
        }
        private void WindowResized(object sender, System.EventArgs e)
        {
            if (bFull)
                nMainWidth = this.Size.Width;
            else
                nMainWidth = Convert.ToInt32(this.Size.Width / 0.7);
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

        public string ShortenSkillName(string input)
        {
            string sReturn = input;

            if (input != "" && input != null)
            {
                sReturn = sReturn.Replace("(Focus)", "(F)");
                sReturn = sReturn.Replace("Hunter", "HU");
                sReturn = sReturn.Replace("Ranger", "RA");
                sReturn = sReturn.Replace("Force", "FO");
                sReturn = sReturn.Replace("Fighter", "FI");
                sReturn = sReturn.Replace("Gunner", "GU");
                sReturn = sReturn.Replace("Techer", "TE");
                sReturn = sReturn.Replace("Braver", "BR");
                sReturn = sReturn.Replace("Bouncer", "BO");
                sReturn = sReturn.Replace("Summoner", "SU");
                sReturn = sReturn.Replace("Hero", "HR");
                sReturn = sReturn.Replace("Phantom", "PH");
                sReturn = sReturn.Replace("Etoile", "ET");
                sReturn = sReturn.Replace("Dark Blast", "D.Blast");
                sReturn = sReturn.Replace("Twin Machine Gun", "TMG");
                sReturn = sReturn.Replace("Double Saber", "DS");
                sReturn = sReturn.Replace("Dual Blades", "DB");
                sReturn = sReturn.Replace("Assault Rifle", "AR");
                sReturn = sReturn.Replace("Jet Boots", "JB");
                sReturn = sReturn.Replace("Wired Lances", "WL");
                sReturn = sReturn.Replace("(Shift Action)", "(S)");
                sReturn = sReturn.Replace("Weapon Action", "W.Action");
                sReturn = sReturn.Replace("Dodge Counter Shot", "DCS");
            }

            return sReturn;
        }

        void ReadInstanceData()
        {
            string sPath = sLoadFile;
            Graphics G = CreateGraphics();
            nPlayers = 0;

            if (File.Exists(sPath))
            {
                string[] sLines;
                try
                {
                    sLines = WriteSafeReadAllLines(sPath);
                }
                catch
                {
                    return;
                }

                if (sLines.Length < 3)
                    return;

                this.SuspendLayout();
                if (this.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        if (!this.Visible)
                        {
                            this.Show();
                            tLastUpdate = DateTime.Now;
                            oTimer.Enabled = true;
                        }
                    }));

                }
                else
                {
                    if (!this.Visible)
                    {
                        this.Show();
                        tLastUpdate = DateTime.Now;
                        oTimer.Enabled = true;
                    }
                }

                Font oFont = new Font("MS UI Gothic", 11f, FontStyle.Bold);
                Font oMonoFont = new Font("Consolas", 10f, FontStyle.Bold);

                Chart oEncounterGraph = Graph;
                if (Graph.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        Graph.Series.Clear();
                        Graph.ChartAreas.Clear();
                        oEncounterGraph.Palette = ChartColorPalette.SemiTransparent;
                        oEncounterGraph.BackColor = Color.FromArgb(222, 222, 222);
                    }));
                }
                else
                { 
                    Graph.Series.Clear();
                    Graph.ChartAreas.Clear();
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
                chA.AxisX2.LabelStyle.Enabled = true;
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
                long lZanverse = 0;
                long lMaxDamage = 0;
                long lYMax = 0;

                for (int n = 0; n < nColorOffset; n++)
                {
                    if (oColorList.Count > 0)
                        oColorList.Remove(oColorList.First());
                    else
                        break;
                }

                nPlayers = 0;
                foreach (string sLine in sLines)
                {
                    if (sLine == "PID,Name,Type,Class,Damage,Data1,Data2,Data3") continue;

                    string[] tmp = sLine.Split(',');

                    uint uPID = Convert.ToUInt32(tmp[0]);
                    string sPName = tmp[1];
                    string sType = tmp[2];
                    string sClass = tmp[3];

                    string sName = sPName;

                    // Skip first header line
                    if (sName == "Name" && sType == "Type" && sClass == "Class")
                        continue;

                    long lDamage = Convert.ToInt64(tmp[4]);
                    string sLabel = tmp[5];
                    string sMaxSkill = tmp[6];
                    long lMaxSkill = Convert.ToInt64(tmp[7]);

                    SizeF oStringSize;
                    Image oLabelImage = null;
                    NamedImage oImageAdd = null;

                    if (sName == "Init" && sType == "Init" && sClass == "Init")
                    {
                        uPlayerID = uPID;
                        lMaxDamage = Convert.ToInt64(sMaxSkill);
                        lZanverse = lMaxSkill;

                        int nInstID = Convert.ToInt32(sLabel.Substring(11, sLabel.IndexOf(" - ") - 11));
                        if (nInstanceID == 0)
                            nInstanceID = nInstID;

                        if (nInstID != nInstanceID)
                        {
                            ColorRemember.Clear();
                            nColorOffset++;
                            nInstanceID = nInstID;
                        }

                        // Prep InstanceInfo Text
                        oStringSize = G.MeasureString(sLabel, oFont);
                        oStringSize.Width += 4;
                        oStringSize.Height += 4;

                        oLabelImage = new Bitmap((int)oStringSize.Width, (int)oStringSize.Height);

                        using (Graphics oG = Graphics.FromImage(oLabelImage))
                        {
                            oG.Clear(Color.Transparent);
                            //oG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.Black), 2, 2);

                            InstanceInfo.Image = oLabelImage;
                        }

                        // Prep BottomInfo Text
                        string sBottomText = "";
                        if (lZanverse > 0)
                            sBottomText = "Zanverse : " + lZanverse.ToString("N0") + " - Total Damage : " + lMaxDamage.ToString("N0");
                        else
                            sBottomText = "Total Damage : " + lMaxDamage.ToString("N0");

                        sLabel = sBottomText;
                        oStringSize = G.MeasureString(sLabel, oFont);
                        oStringSize.Width += 4;
                        oStringSize.Height += 4;

                        oLabelImage = new Bitmap((int)oStringSize.Width, (int)oStringSize.Height);
                        using (Graphics oG = Graphics.FromImage(oLabelImage))
                        {
                            oG.Clear(Color.Transparent);
                            //oG.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 0);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 1);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 3);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 4);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 2);
                            oG.DrawString(sLabel, oFont, new SolidBrush(Color.Black), 2, 2);

                            BottomInfo.Image = oLabelImage;
                        }
                    }
                    else
                    {
                        DataPoint oPoint = new DataPoint(nPos, lDamage);
                        DataPoint oPBottom = new DataPoint(nPos, 0);

                        if (lDamage > lYMax)
                            lYMax = lDamage;

                        CustomLabel cl1 = new CustomLabel
                        {
                            FromPosition = nPos - 0.5,
                            ToPosition = nPos + 0.5
                        };

                        CustomLabel cl2 = new CustomLabel
                        {
                            FromPosition = nPos - 0.5,
                            ToPosition = nPos + 0.5
                        };

                        if (uPID == uPlayerID)
                        {
                            oPoint.BackSecondaryColor = Color.White;
                            oPoint.BackGradientStyle = GradientStyle.HorizontalCenter;
                        }

                        oPoint.IsValueShownAsLabel = false;
                        Color oPointColor = new Color();
                        if (oColorList.Count == 0)
                            oColorList = Extensions.Colors.ChartColorPallets.Pastel;
                        oPointColor = oColorList.First();
                        oColorList.Remove(oColorList.First());
                        if (ColorRemember.ContainsKey(uPID))
                            oPoint.Color = ColorRemember[uPID];
                        else
                        {
                            ColorRemember.Add(uPID, oPointColor);
                            oPoint.Color = oPointColor;
                        }

                        // Setting Player Icons
                        if (uPID == uPlayerID)
                            sName = "★";
                        else
                            sName = "";

                        int nImageHeight = 0;

                        oStringSize = G.MeasureString(sName, oFont);
                        oStringSize.Width += 4;
                        oStringSize.Height += 4;

                        if (oStringSize.Height > nIconHeight)
                            nImageHeight = Convert.ToInt32(oStringSize.Height);
                        else
                            nImageHeight = nIconHeight;
                        oLabelImage = new Bitmap(Convert.ToInt32(oStringSize.Width + (nIconWidth * 2.375)), nImageHeight);
                        using (Graphics oG = Graphics.FromImage(oLabelImage))
                        {
                            if (sName == "★")
                            {
                                oG.Clear(Color.DarkSlateGray);
                                nNameImageWidth = oLabelImage.Width;
                            }
                            else
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
                            if (sName == "★")
                                oG.DrawString(sName, oFont, new SolidBrush(Color.Gold), 2, 2);
                            else
                                oG.DrawString(sName, oFont, new SolidBrush(Color.Black), 2, 2);

                            int nOffset = 0;
                            nOffset += Convert.ToInt32(oStringSize.Width + 2 + (nIconWidth / 8));

                            int nYOffset = 0;
                            if (oStringSize.Height > nIconHeight)
                                nYOffset = Convert.ToInt32((oStringSize.Height - nIconHeight) / 2);

                            switch (sType)
                            {
                                case "Foie":
                                    oG.DrawImage(oIcon_Technique_Foie, nOffset, nYOffset);
                                    break;
                                case "Barta":
                                    oG.DrawImage(oIcon_Technique_Barta, nOffset, nYOffset);
                                    break;
                                case "Zonde":
                                    oG.DrawImage(oIcon_Technique_Zonde, nOffset, nYOffset);
                                    break;
                                case "Zan":
                                    oG.DrawImage(oIcon_Technique_Zan, nOffset, nYOffset);
                                    break;
                                case "Grants":
                                    oG.DrawImage(oIcon_Technique_Grants, nOffset, nYOffset);
                                    break;
                                case "Megid":
                                    oG.DrawImage(oIcon_Technique_Megid, nOffset, nYOffset);
                                    break;
                                case "Compound":
                                    oG.DrawImage(oIcon_Technique_Compound, nOffset, nYOffset);
                                    break;

                                case "Sword":
                                    oG.DrawImage(oIcon_Weapon_Sword, nOffset, nYOffset);
                                    break;
                                case "Partisan":
                                    oG.DrawImage(oIcon_Weapon_Partisan, nOffset, nYOffset);
                                    break;
                                case "WireLance":
                                    oG.DrawImage(oIcon_Weapon_WireLance, nOffset, nYOffset);
                                    break;
                                case "Rifle":
                                    oG.DrawImage(oIcon_Weapon_Rifle, nOffset, nYOffset);
                                    break;
                                case "Launcher":
                                    oG.DrawImage(oIcon_Weapon_Launcher, nOffset, nYOffset);
                                    break;
                                case "Rod":
                                    oG.DrawImage(oIcon_Weapon_Rod, nOffset, nYOffset);
                                    break;
                                case "Talis":
                                    oG.DrawImage(oIcon_Weapon_Talis, nOffset, nYOffset);
                                    break;
                                case "Gunslash":
                                    oG.DrawImage(oIcon_Weapon_Gunslash, nOffset, nYOffset);
                                    break;
                                case "Knuckle":
                                    oG.DrawImage(oIcon_Weapon_Knuckle, nOffset, nYOffset);
                                    break;
                                case "TwinDagger":
                                    oG.DrawImage(oIcon_Weapon_TwinDagger, nOffset, nYOffset);
                                    break;
                                case "DoubleSaber":
                                    oG.DrawImage(oIcon_Weapon_DoubleSaber, nOffset, nYOffset);
                                    break;
                                case "TwinMachinegun":
                                    oG.DrawImage(oIcon_Weapon_TwinMachinegun, nOffset, nYOffset);
                                    break;
                                case "Wand":
                                    oG.DrawImage(oIcon_Weapon_Wand, nOffset, nYOffset);
                                    break;
                                case "Katana":
                                    oG.DrawImage(oIcon_Weapon_Katana, nOffset, nYOffset);
                                    break;
                                case "BulletBow":
                                    oG.DrawImage(oIcon_Weapon_BulletBow, nOffset, nYOffset);
                                    break;
                                case "DualBlades":
                                    oG.DrawImage(oIcon_Weapon_DualBlades, nOffset, nYOffset);
                                    break;
                                case "JetBoots":
                                    oG.DrawImage(oIcon_Weapon_JetBoots, nOffset, nYOffset);
                                    break;
                                case "Tact":
                                    oG.DrawImage(oIcon_Weapon_Tact, nOffset, nYOffset);
                                    break;
                                case "Pets":
                                    oG.DrawImage(oIcon_Pets, nOffset, nYOffset);
                                    break;

                                default:
                                    oG.DrawImage(oIcon_Disc, nOffset, nYOffset);
                                    break;
                            }

                            nOffset = nOffset + nIconWidth + 2;
                            switch (sClass)
                            {
                                case "HU":
                                    oG.DrawImage(oIcon_Class_HU, nOffset, nYOffset);
                                    break;
                                case "RA":
                                    oG.DrawImage(oIcon_Class_RA, nOffset, nYOffset);
                                    break;
                                case "FO":
                                    oG.DrawImage(oIcon_Class_FO, nOffset, nYOffset);
                                    break;
                                case "FI":
                                    oG.DrawImage(oIcon_Class_FI, nOffset, nYOffset);
                                    break;
                                case "GU":
                                    oG.DrawImage(oIcon_Class_GU, nOffset, nYOffset);
                                    break;
                                case "TE":
                                    oG.DrawImage(oIcon_Class_TE, nOffset, nYOffset);
                                    break;
                                case "BR":
                                    oG.DrawImage(oIcon_Class_BR, nOffset, nYOffset);
                                    break;
                                case "BO":
                                    oG.DrawImage(oIcon_Class_BO, nOffset, nYOffset);
                                    break;
                                case "SU":
                                    oG.DrawImage(oIcon_Class_SU, nOffset, nYOffset);
                                    break;
                                case "HR":
                                    oG.DrawImage(oIcon_Class_HR, nOffset, nYOffset);
                                    break;
                                case "PH":
                                    oG.DrawImage(oIcon_Class_PH, nOffset, nYOffset);
                                    break;
                                case "ET":
                                    oG.DrawImage(oIcon_Class_ET, nOffset, nYOffset);
                                    break;
                                default:
                                    oG.DrawImage(oIcon_MusicDisc, nOffset, nYOffset);
                                    break;
                            }

                            oImageAdd = new NamedImage("PlayerName" + nPos.ToString(), oLabelImage);
                            bool bImageFound = false;
                            foreach (NamedImage oCheck in Graph.Images)
                            {
                                if (oCheck.Name == "PlayerName" + nPos.ToString())
                                {
                                    bImageFound = true;
                                    oCheck.Image = oLabelImage;
                                    break;
                                }
                            }
                            if (!bImageFound)
                                Graph.Images.Add(oImageAdd);
                            cl1.Image = "PlayerName" + nPos.ToString();
                        }

                        if (!bFull)
                        {
                            string[] labelsep = sLabel.Split('・');
                            sLabel = labelsep[1] + " ・" + labelsep[2] + '・' + labelsep[3];
                        }
                        oPBottom.Label = sLabel;

                        if (bFull)
                        {
                            // Setting MaxHit Text
                            sLabel = ShortenSkillName(sMaxSkill) + " : " + lMaxSkill.ToString("N0");
                            oStringSize = G.MeasureString(sLabel, oFont);
                            oStringSize.Width += 4;
                            oStringSize.Height += 4;

                            oLabelImage = new Bitmap(Convert.ToInt32(oStringSize.Width), Convert.ToInt32(oStringSize.Height));
                            using (Graphics oG = Graphics.FromImage(oLabelImage))
                            {
                                oG.Clear(Color.Transparent);

                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 0);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 0);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 0);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 0);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 0);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 1);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 1);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 1);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 1);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 1);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 3);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 3);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 3);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 3);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 3);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 4);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 4);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 2, 4);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 4);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 4);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 0, 2);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 1, 2);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 3, 2);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.White), 4, 2);
                                oG.DrawString(sLabel, oFont, new SolidBrush(Color.Black), 2, 2);

                                oImageAdd = new NamedImage("PlayerMax" + nPos.ToString(), oLabelImage);
                                bool bImageFound = false;
                                foreach (NamedImage oCheck in Graph.Images)
                                {
                                    if (oCheck.Name == "PlayerMax" + nPos.ToString())
                                    {
                                        bImageFound = true;
                                        oCheck.Image = oLabelImage;
                                        break;
                                    }
                                }
                                if (!bImageFound)
                                    Graph.Images.Add(oImageAdd);
                                cl2.Image = "PlayerMax" + nPos.ToString();
                            }
                        }

                        if (Graph.InvokeRequired)
                        {
                            BeginInvoke((Action)(() =>
                            {
                                Graph.ChartAreas[0].AxisX.CustomLabels.Add(cl1);
                                Graph.ChartAreas[0].AxisX2.CustomLabels.Add(cl2);
                            }));
                        }
                        else
                        {
                            Graph.ChartAreas[0].AxisX.CustomLabels.Add(cl1);
                            Graph.ChartAreas[0].AxisX2.CustomLabels.Add(cl2);
                        }

                        Dictionary<string, object> TagData = new Dictionary<string, object>();
                        TagData.Add("ID", uPID);
                        TagData.Add("Name", sPName);
                        oPoint.Tag = TagData;
                        
                        oBottom.Points.Add(oPBottom);
                        oSeries.Points.Add(oPoint);
                        nPlayers++;
                    }

                    nPos++;
                }

                if (Graph.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        Graph.ChartAreas[0].AxisX.Minimum = 0.5;
                        Graph.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(nPos - 0.5);
                        Graph.ChartAreas[0].AxisX2.Minimum = 0.5;
                        Graph.ChartAreas[0].AxisX2.Maximum = Convert.ToDouble(nPos - 0.5);

                        Graph.ChartAreas[0].AxisY.Maximum = lYMax;

                        Graph.Series.Add(oBottom);
                        Graph.Series.Add(oSeries);
                    }));
                }
                else
                {
                    Graph.ChartAreas[0].AxisX.Minimum = 0.5;
                    Graph.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(nPos - 0.5);
                    Graph.ChartAreas[0].AxisX2.Minimum = 0.5;
                    Graph.ChartAreas[0].AxisX2.Maximum = Convert.ToDouble(nPos - 0.5);

                    Graph.ChartAreas[0].AxisY.Maximum = lYMax;

                    Graph.Series.Add(oBottom);
                    Graph.Series.Add(oSeries);
                }
            }

            this.ResumeLayout();
            int nNewWidth = nMainWidth;
            if (!bFull)
                nNewWidth = Convert.ToInt32(nMainWidth * 0.7);
            int nNewHeight = 0;
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
                nNewHeight = 83;
            else
                nNewHeight = 58;
            nNewHeight += (nBarWidth * nPlayers);
            if (this.InvokeRequired)
            {
                BeginInvoke((Action)(() =>
                {
                    this.Size = new System.Drawing.Size(nNewWidth, nNewHeight);
                }));
            }
            else
            {
                this.Size = new System.Drawing.Size(nNewWidth, nNewHeight);
            }
            tLastUpdate = DateTime.Now;
        }
        private void Opacity_Scroll(object sender, EventArgs e)
        {
            double dValue = OpacitySlider.Value;
            if (dValue < 1)
                dValue = 1;
            this.Opacity = (dValue / 10.0);
            nMainOpacity = Convert.ToInt32(dValue);

            UpdateSkillWindows();
        }

        private void MiniGraph_Load(object sender, EventArgs e)
        {
            if (nInitX > 0 && nInitY > 0)
            {
                this.Location = new Point(nInitX, nInitY);
                nInitX = 0;
                nInitY = 0;
            }
            ReadInstanceData();

            oTimer = new System.Timers.Timer(1000);
            oTimer.Elapsed += OnTimerEvent;
            oTimer.Enabled = true;
            oTimer.AutoReset = true;

            Button1_Click(this, e);
            Button1_Click(this, e);
        }

        private void OnTimerEvent(Object source, ElapsedEventArgs e)
        {
            if (!bMoving)
            {
                if ((DateTime.Now - tLastUpdate).TotalSeconds > 60)
                {
                    if (this.InvokeRequired)
                    {
                        BeginInvoke((Action)(() =>
                        {
                            this.Hide();
                            oTimer.Enabled = false;
                        }));
                    }
                    else
                    {
                        this.Hide();
                        oTimer.Enabled = false;
                    }
                }
            }
            else
                tLastUpdate = DateTime.Now;

            UpdateSkillWindows();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReadSettingsFile()
        {
            if (File.Exists(sDir + "\\MiniGraph.ini"))
            {
                string[] sOptions = WriteSafeReadAllLines(sDir + "\\MiniGraph.ini");
                foreach (string sLine in sOptions)
                {
                    string[] tmp = sLine.Split('=');
                    switch (tmp[0])
                    {
                        case "X":
                            nPosX = Convert.ToInt32(tmp[1]);
                            break;
                        case "Y":
                            nPosY = Convert.ToInt32(tmp[1]);
                            break;
                        case "Width":
                            nMainWidth = Convert.ToInt32(tmp[1]);
                            break;
                        //case "Height":
                        //    nMainHeight = Convert.ToInt32(tmp[1]);
                        //    break;
                        case "Opacity":
                            nMainOpacity = Convert.ToInt32(tmp[1]);
                            break;
                        case "Border":
                            nBorderYesNo = Convert.ToInt32(tmp[1]);
                            break;
                        case "Mode":
                            nMode = Convert.ToInt32(tmp[1]);
                            break;

                        default:
                            break;
                    }
                }

                int nNewPosX = 0;
                int nNewPosY = 0;
                int nNewWidth = 0;
                int nNewHeight = 0;
                int nNewOpacity = 0;
                int nNewBorder = 1;

                if (nPosX > 0)
                    nNewPosX = nPosX;
                else
                    nNewPosX = this.Location.X;

                if (nPosY > 0)
                    nNewPosY = nPosY;
                else
                    nNewPosY = this.Location.Y;

                if (nMainWidth > 0)
                    nNewWidth = nMainWidth;
                else
                {
                    nNewWidth = 746;
                    nMainWidth = nNewWidth;
                }

                /*
                 * if (nMainHeight > 0)
                    nNewHeight = nMainHeight;
                else
                    nNewHeight = this.Size.Height;
                */

                if (nMainOpacity > 0)
                    nNewOpacity = nMainOpacity;
                else
                    nNewOpacity = 10;

                nNewBorder = nBorderYesNo;
                if (nBorderYesNo == 1)
                    nNewHeight = 83;
                else
                    nNewHeight = 58;

                nNewHeight += (nBarWidth * (nPlayers < 1 ? 1 : nPlayers));

                this.Location = new Point(nNewPosX, nNewPosY);
                this.Size = new System.Drawing.Size(nNewWidth, nNewHeight);
                OpacitySlider.Value = nNewOpacity;
                this.Opacity = (nNewOpacity) / 10.0;
                if (Convert.ToBoolean(nNewBorder))
                {
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.TransparencyKey = Color.GhostWhite;
                    this.button1.Text = "Border On";
                }
                else
                {
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.TransparencyKey = Color.FromArgb(222, 222, 222);
                    this.button1.Text = "Border Off";
                }

                if (((bFull) && (nMode == 0)) || ((!bFull) && (nMode == 1)))
                    ChangeMode();
            }
            else
            {
                nMainWidth = 746;
                nMode = 1;
                nBorderYesNo = 1;
                nMainOpacity = 10;
            }
        }
        private void UpdateSettingsFile()
        {
            if (nPosX < 0) nPosX = 0;
            if (nPosY < 0) nPosY = 0;
            if (nMainWidth < 0) nMainWidth = 0;
            //if (nMainHeight < 0) nMainHeight = 0;
            if (nMainOpacity < 1) nMainOpacity = 10;
            if (nBorderYesNo > 2) nBorderYesNo = 1;

            //string sSettingsText = $"X={nPosX}\nY={nPosY}\nWidth={nMainWidth}\nHeight={nMainHeight}\nOpacity={nMainOpacity}\nBorder={nBorderYesNo}";
            string sSettingsText = $"X={nPosX}\nY={nPosY}\nWidth={nMainWidth}\nOpacity={nMainOpacity}\nBorder={nBorderYesNo}\nMode={nMode}";

            if (File.Exists(sDir + "\\MiniGraph.ini"))
                File.Delete(sDir + "\\MiniGraph.ini");

            File.WriteAllLines(sDir + "\\MiniGraph.ini", sSettingsText.Split('\n'));
        }
        
        private void MenuShowHide_Click(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
                this.Text = "MiniGraph (Hidden)";
                oTimer.Enabled = false;
            }
            else
            {
                this.Text = "MiniGraph";
                this.Show();
                oTimer.Enabled = true;
            }

            UpdateSkillWindows();
            tLastUpdate = DateTime.Now;
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MenuShowHide_Click(sender, e);
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bMoving = true;
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Label1_MouseUp(object sender, MouseEventArgs e)
        {
            bMoving = false;
        }

        private void BorderYesNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.TransparencyKey = Color.GhostWhite;
                nBorderYesNo = 1;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.TransparencyKey = Color.FromArgb(222, 222, 222);
                nBorderYesNo = 0;
            }
            UpdateSkillWindows();
        }

        private void MiniGraph_Paint(object sender, PaintEventArgs e)
        {
            //    if (this.FormBorderStyle != FormBorderStyle.None)
            //        e.Graphics.DrawRectangle(new Pen(Color.Blue, 7), this.DisplayRectangle);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.TransparencyKey = Color.GhostWhite;
                this.button1.Text = "Border On";
                nBorderYesNo = 1;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.TransparencyKey = Color.FromArgb(222, 222, 222);
                this.button1.Text = "Border Off";
                nBorderYesNo = 0;
            }
            UpdateSkillWindows();
        }
        
        private void Graph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Chart oChart = (Chart)sender;
            var r = oChart.HitTest((int)oChart.ChartAreas[0].AxisY.ValueToPixelPosition(0), e.Y, ChartElementType.DataPoint);
            if (r.Object != null)
            {
                int index = r.PointIndex;
                DataPoint oPoint = r.Series.Points[index];

                if (oPoint is DataPoint)
                {
                    if (oPoint.Tag != null)
                    {
                        Dictionary<string, object> oTag = (Dictionary<string, object>)oPoint.Tag;
                        if (index > -1)
                        {
                            try
                            {
                                SkillGraph oSkillWindow = null;
                                foreach (SkillGraph oWindow in oSkillsShown)
                                {
                                    if (oWindow.uPlayerID == (uint)oTag["ID"])
                                    {
                                        oSkillWindow = oWindow;
                                        oSkillWindow.Activate();
                                    }
                                }
                                if (oSkillWindow == null)
                                {
                                    oSkillWindow = new SkillGraph(this, (uint)oTag["ID"]);
                                    oSkillWindow.FormClosed += new FormClosedEventHandler(SkillWindow_FormClosed);
                                    oSkillWindow.Show();
                                    oSkillsShown.Add(oSkillWindow);
                                }
                                tLastUpdate = DateTime.Now;
                            }
                            catch (Exception ex)
                            {
                                LogError(ex, "Error - Something happened when doubleclicking on main graph");
                            }
                        }
                    }
                }
            }
        }

        void SkillWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (oSkillsShown.Contains((SkillGraph)sender))
                oSkillsShown.Remove((SkillGraph)sender);
            else
                MessageBox.Show("ERROR! couldn't remove skillwindow instance!");
        }

        void UpdateSkillWindows()
        {
            List<SkillGraph> bkList = new List<SkillGraph>();
            foreach (SkillGraph window in oSkillsShown)
            {
                if (!window.IsDisposed)
                    bkList.Add(window);
            }
            oSkillsShown = bkList;
            foreach (SkillGraph oWindow in oSkillsShown)
            {
                if (oWindow.IsDisposed) continue;
                if (oWindow.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        if (!oWindow.IsDisposed)
                        {
                            oWindow.SuspendLayout();
                            oWindow.Visible = this.Visible;
                            oWindow.FormBorderStyle = this.FormBorderStyle;
                            oWindow.TransparencyKey = this.TransparencyKey;
                            oWindow.Opacity = this.Opacity;
                            oWindow.ResumeLayout();
                        }
                    }));
                }
                else
                {
                    oWindow.SuspendLayout();
                    oWindow.Visible = this.Visible;
                    oWindow.FormBorderStyle = this.FormBorderStyle;
                    oWindow.TransparencyKey = this.TransparencyKey;
                    oWindow.Opacity = this.Opacity;
                    oWindow.ResumeLayout();
                }
            }
        }
        public void LogError(Exception e, string sErrorMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\MiniGraph.log";
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
            string filePath = sLogDir + "\\MiniGraph.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + " - Error Message : " + sErrorMsg);
            }
        }
        public void LogMessage(string sMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\MiniGraph.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + " - Message : " + sMsg);
            }
        }
        private void PauseResume_Click(object sender, EventArgs e)
        {
            if (oWatcher.EnableRaisingEvents)
            {
                oWatcher.EnableRaisingEvents = false;
                PauseResume.Text = "Resume";
            }
            else
            {
                PauseResume.Text = "Pause";
                sLoadFile = sDir + "\\InstanceData.csv";
                sLoadSkillFile = sDir + "\\InstanceData.skilldb";
                oWatcher.EnableRaisingEvents = true;
            }
        }

        private void ChangeBasicFull_Click(object sender, EventArgs e)
        {
            ChangeMode();
        }

        private void ChangeMode()
        {
            if (bFull)
            {
                bFull = false;
                nMode = 0;
                nBarWidth = 23;
                ChangeBasicFull.Text = "Full";
                this.PauseResume.Visible = false;
                this.LoadAnother.Visible = false;
            }
            else
            {
                bFull = true;
                nMode = 1;
                nBarWidth = 28;
                ChangeBasicFull.Text = "Basic";
                this.PauseResume.Visible = true;
                this.LoadAnother.Visible = true;
            }
            try
            {
                if (this.InvokeRequired)
                {
                    BeginInvoke((Action)(() =>
                    {
                        ReadInstanceData();
                    }));
                }
                else
                    ReadInstanceData();

            }
            catch (Exception ex)
            {
                LogError(ex, "Error while re-reading InstanceData when switching modes!");
            }
        }

        private void LoadAnother_Click(object sender, EventArgs e)
        {
            OpenFileDialog oOpen = new OpenFileDialog();
            oOpen.InitialDirectory = sDir + "\\PreviousInstances";
            oOpen.Title = "Choose previous InstanceData.csv to load";
            oOpen.DefaultExt = "csv";
            oOpen.Filter = "Instance Data Files|*.csv";

            DialogResult result = oOpen.ShowDialog();
            if (result == DialogResult.OK)
            {
                string sChosen = oOpen.FileName;
                string sChosenSkill = sChosen.Replace(".csv", ".skilldb");

                sLoadFile = sChosen;
                sLoadSkillFile = sChosenSkill;

                ReadInstanceData();
            }
        }

        private void Graph_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Chart oChart = (Chart)sender;
                if (oChart is Chart)
                {
                    var r = oChart.HitTest((int)oChart.ChartAreas[0].AxisY.ValueToPixelPosition(0) + 0, e.Y, ChartElementType.DataPoint);
                    if (r.Object != null)
                    {
                        int index = r.PointIndex;
                        DataPoint oPoint = r.Series.Points[index];

                        if (oPoint is DataPoint)
                        {
                            if (index > -1)
                            {
                                int nHeight = oChart.Height / r.Series.Points.Count;
                                int nStartY = Convert.ToInt32(r.ChartArea.AxisX.ValueToPixelPosition(index)) - nHeight;
                                int nStartX = Convert.ToInt32(r.ChartArea.AxisY.ValueToPixelPosition(0)) + (nBorderWidth * 2) - nNameImageWidth - 1;
                                if (nBorderYesNo == 0)
                                {
                                    nStartX -= nBorderWidth;
                                    nStartY -= nTitlebarHeight;
                                }

                                ShowPlayerName.ShowAlways = true;
                                ShowPlayerName.ToolTipTitle = "Character Name :";


                                if (oPoint.Tag != null)
                                {
                                    Dictionary<string, object> oTag = (Dictionary<string, object>)oPoint.Tag;
                                    ShowPlayerName.Show((string)oTag["Name"], this, nStartX, nStartY);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Error while moving mouse within the graph!");
            }
        }

        private void Graph_MouseLeave(object sender, EventArgs e)
        {
            ShowPlayerName.ShowAlways = false;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about.Show();
        }
    }
}
