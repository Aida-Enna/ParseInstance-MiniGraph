using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace ParseInstance
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.Run(new MyCustomApplicationContext());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\ParseInstance.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Message :" + e.Exception.Message + "<br/>" + Environment.NewLine + "StackTrace :" + e.Exception.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                logWriter.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
    }


    public class MyCustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        string sLogDir = "";
        string sDir = "";

        uint uYOUID = 0;
        uint uCurrentInstance = 0;

        long lZanverse = 0;
        long lTotalDamage = 0;

        DateTime tInstanceStart = new DateTime();
        DateTime tLastUpdate = new DateTime();
        DateTime tLastDirUpdate = new DateTime();
        DateTime tLastFileUpdate = new DateTime();
        uint uLastAction = 0;

        System.Timers.Timer oTimer = null;

        Process oGraphStart = new Process();

        List<string> sPrevLines = new List<string>();

        struct PlayerInstance
        {
            public long TimeStamp;
            public uint ID;
            public string Name;
            public string Type;
            public string Class;
            public long Damage;
            public Dictionary<string, SkillData> Skills;
            public int Hits;
            public int JAs;
            public int JAHits;
            public int Crits;
            public int DamageTaken;
            public string MaxSkill;
            public long MaxDamage;
        }

        struct SkillData
        {
            public string Name;
            public long Damage;
            public int Hits;
            public int JAs;
            public int JAHits;
            public int Crits;
            public long MinDamage;
            public long MaxDamage;
        }

        struct Action
        {
            public uint timestamp;
            public ushort instanceID;
            public uint sourceID;
            public string sourceName;
            public uint targetID;
            public string targetName;
            public uint attackID;
            public int damage;
            public bool isJA;
            public bool isCrit;
            public bool isMultiHit;
            public bool isMisc;
            public bool isMisc2;
        }

        Dictionary<uint, PlayerInstance> InstanceData = new Dictionary<uint, PlayerInstance>();
        
        struct Skill
        {
            public string Name;
            public string Type;
            public string Comment;
        }

        Dictionary<uint, Skill> skillDict = new Dictionary<uint, Skill>();
        Dictionary<string, uint> revSkillDict = new Dictionary<string, uint>();
        Dictionary<uint, Skill> noJADict = new Dictionary<uint, Skill>();

        Dictionary<uint, string> MainClassLookup = new Dictionary<uint, string>();
        Dictionary<uint, string> ClassLookup = new Dictionary<uint, string>();
        Dictionary<uint, string> WeaponLookup = new Dictionary<uint, string>();

        FileStream LastStream;
        StreamReader LastLogFile = null;
        string LogFileName = "";

        string sPartialLine = "";

        AboutBox about = new AboutBox();

        public MyCustomApplicationContext()
        {            
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.FO,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem("Choose damagelog folder location", FolderLocation),
                    new MenuItem("About...", About),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true
            };

            trayIcon.Text = "ParseInstance";

            sDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            try
            {
                ReadSettingsFile();
            }
            catch (Exception e)
            {
                LogError(e, "Error while Reading Settings File");
            }
            try
            {
                InitializeSkillDict();
            }
            catch (Exception e)
            {
                LogError(e, "Error while Initializing Skill Dictionaries");
            }

            if (sLogDir == "")
            {
                MessageBox.Show("Please select pso2_bin\\damagelog folder location");
                ChooseLocation();
            }

            try
            {
                SecondInit();
            }
            catch (Exception e)
            {
                LogError(e, "Error while reading latest damagelog data");
            }

            StartMiniGraph();
        }

        private void SecondInit()
        {
            DirectoryInfo oLogDir;
            IOrderedEnumerable<FileInfo> oFileList;
            FileInfo oLastLog = null;

            try
            {
                oLogDir = new DirectoryInfo(sLogDir);
                tLastDirUpdate = oLogDir.LastWriteTime;
                oFileList = oLogDir.GetFiles().OrderByDescending(f => f.LastWriteTime);
                foreach (var file in oFileList)
                {
                    if (file.Extension == ".csv")
                    {
                        oLastLog = file;
                        break;
                    }
                }
                if (oLastLog == null)
                {
                    LogError("No damagelog files found!");
                    return;
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Error while reading damagelog file");
            }

            if (oLastLog != null)
            {
                try
                {
                    tLastFileUpdate = oLastLog.LastWriteTime;
                    LogFileName = oLastLog.FullName;

                    LastStream = new FileStream(oLastLog.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    LastLogFile = new StreamReader(LastStream);
                    string sLine = "";
                    while (!LastLogFile.EndOfStream)
                    {
                        sLine = LastLogFile.ReadLine();
                        if (sLine.Contains(",YOU,"))
                        {
                            string[] tmp = sLine.Split(',');
                            uYOUID = Convert.ToUInt32(tmp[2]);
                            LastStream.Seek(0, SeekOrigin.End);
                        }
                    }
                    LastStream.Seek(0, SeekOrigin.End);
                }
                catch (Exception e)
                {
                    LogError(e, "Error while reading " + LogFileName);
                }
            }
            else
            {
                LogError("No damagelog files found!");
            }

            if (oTimer == null)
            {
                oTimer = new System.Timers.Timer(1000);
                oTimer.Elapsed += DamageLogUpdated;
                oTimer.AutoReset = true;
                oTimer.Enabled = true;
            }
        }

        private void DamageLogUpdated(object source, ElapsedEventArgs e)
        {
            DirectoryInfo oLogDir;
            IOrderedEnumerable<FileInfo> oFileList;
            FileInfo oLastLog = null;

            try
            {
                oLogDir = new DirectoryInfo(sLogDir);

                if (oLogDir.LastWriteTime > tLastDirUpdate)
                {
                    tLastDirUpdate = oLogDir.LastWriteTime;

                    oFileList = oLogDir.GetFiles().OrderByDescending(f => f.LastWriteTime);
                    foreach (var file in oFileList)
                    {
                        if (file.Extension == ".csv")
                        {
                            oLastLog = file;
                            break;
                        }
                    }
                    if (oLastLog == null)
                    {
                        LogError("No damagelog files found!");
                        return;
                    }

                    LastStream.Close();
                    LastLogFile.Close();

                    LastStream = new FileStream(oLastLog.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    LastLogFile = new StreamReader(LastStream);
                    LogFileName = oLastLog.FullName;
                }
                else
                    oLastLog = new FileInfo(LogFileName);
            }
            catch (Exception ex)
            {
                LogError(ex, "Error while reading damagelog file");
            }

            if (oLastLog.LastWriteTime <= tLastFileUpdate) return;
            tLastFileUpdate = oLastLog.LastWriteTime;

            if (LastLogFile.EndOfStream) return;

            string sRead;
            List<string> SecondData = new List<string>();

            try
            {
                sRead = LastLogFile.ReadToEnd();
                LastStream.Seek(0, SeekOrigin.End);
                if (sRead == "") return;

                SecondData = sRead.Split('\n').ToList();
                if (sPartialLine != "")
                {
                    SecondData[0] = sPartialLine + SecondData[0];
                    sPartialLine = "";
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Error while reading latest damage data lines");
            }

            if (sPrevLines.Count > 0)
                SecondData = sPrevLines.Concat(SecondData).ToList();

            // Now parse the damagelog lines of this last second from the log.
            string sPrevLine = "";
            string sPrevTarget = "";
            int nLinePos = 0;
            int nLineTotal = SecondData.Count;
            foreach (string sLine in SecondData)
            {
                if (sLine == "") continue;
                if (sPrevLine == sLine && sLine.Contains(",33,Unknown,33,Unknown,0,-1,"))
                    continue;
                if (sPrevLine == sLine && sLine.Contains(",38,Unknown,38,Unknown,0,-1,"))
                    continue;
                if (sPrevLine == sLine && sLine.Contains(",504,Unknown,504,Unknown,0,-1,"))
                    continue;
                if (sPrevLine == sLine && sLine.Contains(",458,Unknown,458,Unknown,0,-1,"))
                    continue;

                int nCount = 0;
                foreach (char c in sLine)
                    if (c == ',') nCount++;

                if (nCount != 12) continue;

                string[] tmp = sLine.Split(',');
                sPrevLine = sLine;

                if (tmp[0] == "timestamp")
                    continue;

                if (tmp[3] == "YOU")
                {
                    uYOUID = Convert.ToUInt32(tmp[2]);
                    continue;
                }

                Action aAction = new Action();
                try
                {
                    aAction.timestamp = Convert.ToUInt32(tmp[0]);
                    aAction.instanceID = Convert.ToUInt16(tmp[1]);
                    aAction.sourceID = Convert.ToUInt32(tmp[2]);
                    aAction.sourceName = tmp[3];
                    aAction.targetID = Convert.ToUInt32(tmp[4]);
                    aAction.targetName = tmp[5];
                    aAction.attackID = Convert.ToUInt32(tmp[6]);
                    aAction.damage = Convert.ToInt32(tmp[7]);
                    aAction.isJA = (Convert.ToInt32(tmp[8]) == 1);
                    aAction.isCrit = (Convert.ToInt32(tmp[9]) == 1);
                    aAction.isMultiHit = (Convert.ToInt32(tmp[10]) == 1);
                    aAction.isMisc = (Convert.ToInt32(tmp[11]) == 1);
                    aAction.isMisc2 = (Convert.ToInt32(tmp[12]) == 1);
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error while parsing damage line : " + sLine);
                    continue;
                }

                if (uCurrentInstance == 0 && aAction.instanceID != 0)
                {
                    try
                    {
                        InstanceData.Clear();
                        uCurrentInstance = aAction.instanceID;
                        tInstanceStart = new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(aAction.timestamp);
                        lZanverse = 0;
                        lTotalDamage = 0;
                    }
                    catch (Exception ex)
                    {
                        LogError(ex, "Error while trying to clear data for very first instance");
                    }
                }

                if (aAction.instanceID < 1000 && uCurrentInstance != 0)
                    aAction.instanceID = Convert.ToUInt16(uCurrentInstance);

                try
                {
                    if ((aAction.sourceID == aAction.targetID) && (aAction.attackID == 0))
                    {
                        switch (aAction.sourceID)
                        {
                            case 27: // Separating Double from PD - Another instance of it? Found it by running UH
                            case 33: // Separating Mother from Deus
                            case 38: // Separating Double from PD
                            case 278: // Separating Deus from Esca???
                            case 504: // Separating normal run from Space Magatsu
                            case 458: // Separating normal run from Yamato AIS Run
                                uCurrentInstance = 0;
                                break;

                            default:
                                break;
                        }
                    }

                    if (aAction.sourceID > 10000000 && aAction.targetID < 10000000)
                    {
                        // Break Mother Rideroid -> Normal fight
                        if (sPrevTarget == "DPP1" && aAction.targetName == "DPP2")
                            uCurrentInstance = 0;

                        // Break Deus from Esca
                        if (sPrevTarget == "DEHm2" && aAction.targetName == "DE")
                            uCurrentInstance = 0;
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error while trying to separate able runs");
                }

                bool bBreakInstance = false;
                if (uCurrentInstance == 0)
                    bBreakInstance = true;
                else
                {
                    if (aAction.instanceID != uCurrentInstance)
                    {
                        if ((nLinePos + 5) < nLineTotal)
                        {
                            // Look ahead through the lines to see if it really instance change or stray instance line
                            bool bBreak = true;
                            int nLoopTotal = 6;
                            for (int n = 1; n < nLoopTotal; n++)
                            {
                                try
                                {
                                    string sLineAhead = SecondData[nLinePos + n];
                                    string[] linesplit = sLineAhead.Split(',');

                                    uint uAheadInstance = Convert.ToUInt32(linesplit[1]);

                                    if (uAheadInstance == 0)
                                    {
                                        nLoopTotal++;
                                        continue;
                                    }

                                    if (uAheadInstance == uCurrentInstance)
                                    {
                                        bBreak = false;
                                        aAction.instanceID = Convert.ToUInt16(uCurrentInstance);
                                        break;
                                    }
                                }
                                catch
                                { }
                            }
                            bBreakInstance = bBreak;
                        }
                        else
                        {
                            sPrevLines.Add(sLine);
                        }
                    }
                }

                if (bBreakInstance)
                {
                    if (InstanceData.Count > 0)
                    {
                        // RESET DATA FOR NEW INSTANCE!
                        sPrevLines.Clear();
                        InstanceData.Clear();
                        uCurrentInstance = aAction.instanceID;
                        tInstanceStart = new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(aAction.timestamp);
                        lZanverse = 0;
                        lTotalDamage = 0;

                        try
                        {
                            if (File.Exists(sDir + "\\InstanceData.csv"))
                            {
                                if (!Directory.Exists(sDir + "\\PreviousInstances"))
                                    Directory.CreateDirectory(sDir + "\\PreviousInstances");

                                int nDuplicate = 0;
                                if (File.Exists(sDir + "\\PreviousInstances\\InstanceData-" + uCurrentInstance.ToString() + ".csv"))
                                {
                                    nDuplicate++;
                                    if (File.Exists(sDir + "\\PreviousInstances\\InstanceData-" + uCurrentInstance.ToString() + "(" + nDuplicate + ").csv"))
                                    {
                                        while (File.Exists(sDir + "\\PreviousInstances\\InstanceData-" + uCurrentInstance.ToString() + "(" + nDuplicate + ").csv"))
                                        {
                                            nDuplicate++;
                                        }
                                    }
                                }

                                if (nDuplicate == 0)
                                {
                                    File.Move(sDir + "\\InstanceData.csv", sDir + "\\PreviousInstances\\InstanceData-" + uCurrentInstance.ToString() + ".csv");
                                    File.Move(sDir + "\\InstanceData.skilldb", sDir + "\\PreviousInstances\\InstanceData-" + uCurrentInstance.ToString() + ".skilldb");
                                }
                                else
                                {
                                    File.Move(sDir + "\\InstanceData.csv", sDir + "\\PreviousInstances\\InstanceData-" + uCurrentInstance.ToString() + "(" + nDuplicate + ").csv");
                                    File.Move(sDir + "\\InstanceData.skilldb", sDir + "\\PreviousInstances\\InstanceData-" + uCurrentInstance.ToString() + "(" + nDuplicate + ").skilldb");
                                }
                            }
                        }
                        catch (Exception e1)
                        {
                            LogError(e1, "Error while moving previous instance data!");
                        }
                    }
                }

                if (aAction.sourceID < 10000000 && aAction.targetID < 10000000)
                    continue;

                PlayerInstance oNewPlayer = new PlayerInstance();

                uint uPlayerID = 0;
                string sPlayerName = "";
                if (aAction.sourceID > 10000000)
                {
                    uPlayerID = aAction.sourceID;
                    sPlayerName = aAction.sourceName;
                }
                else
                {
                    if (aAction.targetID > 10000000)
                    {
                        uPlayerID = aAction.targetID;
                        sPlayerName = aAction.targetName;
                    }
                }

                try
                {
                    if (InstanceData.ContainsKey(uPlayerID))
                    {
                        PlayerInstance oOldPlayer = InstanceData[uPlayerID];
                        oNewPlayer = oOldPlayer;
                    }
                    else
                    {
                        oNewPlayer.TimeStamp = aAction.timestamp;
                        oNewPlayer.ID = uPlayerID;
                        oNewPlayer.Name = sPlayerName;
                        oNewPlayer.Type = "";
                        oNewPlayer.Class = "";
                        oNewPlayer.Damage = 0;
                        oNewPlayer.Skills = new Dictionary<string, SkillData>();
                        oNewPlayer.Hits = 0;
                        oNewPlayer.JAs = 0;
                        oNewPlayer.JAHits = 0;
                        oNewPlayer.Crits = 0;
                        oNewPlayer.DamageTaken = 0;
                        oNewPlayer.MaxSkill = "";
                        oNewPlayer.MaxDamage = 0;
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error while trying to set up PlayerInstance data");
                }

                if (oNewPlayer.TimeStamp > aAction.timestamp) continue;

                oNewPlayer.TimeStamp = aAction.timestamp;
                if (aAction.damage > 10)
                {
                    if (aAction.sourceID > 10000000)
                    {
                        if (aAction.attackID != 2106601422)
                        {
                            sPrevTarget = aAction.targetName;

                            try
                            {
                                // Player dealing damage
                                oNewPlayer.Hits++;
                                if (!noJADict.ContainsKey(aAction.attackID))
                                    oNewPlayer.JAHits++;
                                if (aAction.isJA) oNewPlayer.JAs++;
                                if (aAction.isCrit) oNewPlayer.Crits++;
                                oNewPlayer.Damage += aAction.damage;
                                lTotalDamage += aAction.damage;
                                if (aAction.damage > oNewPlayer.MaxDamage)
                                {
                                    oNewPlayer.MaxSkill = skillDict[aAction.attackID].Name;
                                    oNewPlayer.MaxDamage = aAction.damage;
                                }
                            }
                            catch (Exception ex)
                            {
                                LogError(ex, "Error while trying to update Player Instance data");
                            }

                            string skname = "";
                            try
                            {
                                if (skillDict.ContainsKey(aAction.attackID))
                                    skname = skillDict[aAction.attackID].Name;
                                else
                                    skname = aAction.attackID.ToString();
                            }
                            catch (Exception ex)
                            {
                                LogError(ex, "Error while trying to set skillname");
                            }

                            SkillData skillData;

                            try
                            {
                                if (oNewPlayer.Skills.ContainsKey(skname))
                                {
                                    skillData = oNewPlayer.Skills[skname];
                                }
                                else
                                {
                                    skillData = new SkillData
                                    {
                                        Name = (skillDict.ContainsKey(aAction.attackID) ? skillDict[aAction.attackID].Name : aAction.attackID.ToString()),
                                        Damage = 0,
                                        Hits = 0,
                                        JAHits = 0,
                                        JAs = 0,
                                        Crits = 0,
                                        MinDamage = 0,
                                        MaxDamage = 0
                                    };
                                }
                            }
                            catch (Exception ex)
                            {
                                skillData = new SkillData();
                                LogError(ex, "Error while trying to retrieve SkillData info");
                            }

                            try
                            {
                                skillData.Damage += aAction.damage;
                                skillData.Hits++;
                                if (!noJADict.ContainsKey(aAction.attackID))
                                    skillData.JAHits++;
                                if (aAction.isJA)
                                    skillData.JAs++;
                                if (aAction.isCrit)
                                    skillData.Crits++;
                                if (aAction.damage > skillData.MaxDamage)
                                    skillData.MaxDamage = aAction.damage;
                                if (skillData.MinDamage == 0)
                                    skillData.MinDamage = aAction.damage;
                                if (aAction.damage < skillData.MinDamage)
                                    skillData.MinDamage = aAction.damage;
                                if (oNewPlayer.Skills.ContainsKey(skname))
                                    oNewPlayer.Skills[skname] = skillData;
                                else
                                    oNewPlayer.Skills.Add(skname, skillData);

                                if (MainClassLookup.ContainsKey(aAction.attackID))
                                    oNewPlayer.Class = MainClassLookup[aAction.attackID];
                                if (oNewPlayer.Class == "")
                                    if (ClassLookup.ContainsKey(aAction.attackID))
                                        oNewPlayer.Class = ClassLookup[aAction.attackID];
                            }
                            catch (Exception ex)
                            {
                                LogError(ex, "Error while updating SkillData info");
                            }

                            try
                            {
                                uint uSkillID = 0;
                                long lHighestSkillDamage = 0;
                                foreach (KeyValuePair<string, SkillData> oPair in oNewPlayer.Skills)
                                {
                                    if (oPair.Value.Damage > lHighestSkillDamage)
                                    {
                                        lHighestSkillDamage = oPair.Value.Damage;
                                        if (revSkillDict.ContainsKey(oPair.Key))
                                            uSkillID = revSkillDict[oPair.Key];
                                    }
                                }
                                if (WeaponLookup.ContainsKey(uSkillID))
                                    oNewPlayer.Type = WeaponLookup[uSkillID];
                            }
                            catch (Exception ex)
                            {
                                LogError(ex, "Error while trying to get Highest Total Skill Damage data");
                            }
                        }
                        else
                            lZanverse += aAction.damage;
                    }
                    if (aAction.targetID > 10000000)
                    {
                        // Player receiving damage
                        oNewPlayer.DamageTaken += aAction.damage;
                    }

                    try
                    {
                        if (InstanceData.ContainsKey(uPlayerID))
                            InstanceData[uPlayerID] = oNewPlayer;
                        else
                            InstanceData.Add(uPlayerID, oNewPlayer);
                    }
                    catch (Exception ex)
                    {
                        LogError(ex, "Error while trying to update InstanceData back to DB");
                    }

                    tLastUpdate = new DateTime(1970, 1, 1).ToLocalTime().AddSeconds(aAction.timestamp);
                    if (aAction.sourceID > 10000000 && aAction.targetID < 10000000)
                        uLastAction = aAction.timestamp;
                }
                nLinePos++;
            }

            // Generate InstanceData.csv
            List<string> sInstanceLines = new List<string>();
            List<string> sInstanceSkillDBLines = new List<string>();
            sInstanceLines.Add("PID,Name,Type,Class,Damage,Data1,Data2,Data3");
            sInstanceSkillDBLines.Add("PID,AID,Damage,Min,Max,JA,Crit");
            List<long> lDamageSort = new List<long>();
            Dictionary<long, uint> dSearch = new Dictionary<long, uint>();

            try
            {
                foreach (KeyValuePair<uint, PlayerInstance> oPair in InstanceData)
                {
                    if (!lDamageSort.Contains(oPair.Value.Damage))
                    {
                        lDamageSort.Add(oPair.Value.Damage);
                        dSearch.Add(oPair.Value.Damage, oPair.Key);
                    }
                    else
                    {
                       LogError("This should never happen... - Found another player with the SAME damage total");
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex, "Error while setting up to sort the players for writing");
            }

            lDamageSort.Sort();

            foreach (long lDmg in lDamageSort)
            {
                PlayerInstance oPlayer;
                try
                {
                    oPlayer = InstanceData[dSearch[lDmg]];
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error trying to retrieve Player's Instance Data for setting up data to write");
                    continue;
                }

                try
                {
                    string sname = oPlayer.Name;
                    string stype = oPlayer.Type;
                    string sclass = oPlayer.Class;
                    if (lDmg < 10) continue;
                    string sDmgNumber = lDmg.ToString();
                    if (lDmg > 1000)
                        sDmgNumber = (lDmg / 1000.0).ToString("N1") + "K";
                    if (lDmg > 1000000)
                        sDmgNumber = (lDmg / 1000000.0).ToString("N2") + "M";
                    string slabel = "Damage: " + sDmgNumber.PadLeft(6) + " ・ DPS: " + ((lDmg / (tLastUpdate - tInstanceStart).TotalSeconds) / 1000).ToString("0K").PadLeft(4) + " ・ JA: " + ((Convert.ToDouble(oPlayer.JAs) / Convert.ToDouble(oPlayer.JAHits)) * 100).ToString("N0").PadLeft(3) + "% ・ Crit: " + (((double)oPlayer.Crits / (double)oPlayer.Hits) * 100).ToString("N0").PadLeft(3) + "%  ・  Taken : " + (oPlayer.DamageTaken > 1000 ? (oPlayer.DamageTaken / 1000.0).ToString("0.0K") : oPlayer.DamageTaken.ToString());
                    slabel = slabel.Replace(",∞,", ",0,");
                    slabel = slabel.Replace(",-∞,", ",0,");
                    slabel = slabel.Replace(",NaN,", ",0,");
                    string smaxhit = oPlayer.MaxSkill;
                    long lmaxhit = oPlayer.MaxDamage;
                    sInstanceLines.Add(oPlayer.ID.ToString() + "," + sname + "," + stype + "," + sclass + "," + lDmg.ToString() + "," + slabel + "," + smaxhit + "," + lmaxhit.ToString());
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error while setting up InstanceData line to write");
                }

                try
                {
                    List<long> lSkillDSort = new List<long>();
                    Dictionary<long, string> dSkillDSearch = new Dictionary<long, string>();
                    foreach (KeyValuePair<string, SkillData> oPair in oPlayer.Skills)
                    {
                        string sSkillName = oPair.Key;
                        SkillData skill = oPair.Value;

                        long ldamage = oPair.Value.Damage;
                        if (dSkillDSearch.ContainsKey(ldamage))
                            ldamage++;

                        if (!lSkillDSort.Contains(ldamage))
                            lSkillDSort.Add(ldamage);
                        if (!dSkillDSearch.ContainsKey(ldamage))
                            dSkillDSearch.Add(ldamage, sSkillName);
                    }
                    lSkillDSort.Sort();
                    lSkillDSort.Reverse();

                    List<string> skillSort = new List<string>();
                    int nPos = 0;
                    SkillData others = new SkillData
                    {
                        Name = "",
                        Damage = 0,
                        MinDamage = 0,
                        MaxDamage = 0,
                        JAs = 0,
                        JAHits = 0,
                        Crits = 0,
                        Hits = 0
                    };
                    string sLine = "";
                    foreach (long lSkillDamage in lSkillDSort)
                    {
                        string sSearchName = dSkillDSearch[lSkillDamage];
                        SkillData skill = oPlayer.Skills[sSearchName];

                        if (skill.Name != "")
                        {
                            sLine = $"{oPlayer.ID.ToString()},{skill.Name},{skill.Damage.ToString()},{skill.MinDamage.ToString()},{skill.MaxDamage.ToString()},{(((double)skill.JAs / (double)skill.JAHits) * 100).ToString("N0")},{(((double)skill.Crits / (double)skill.Hits) * 100).ToString("N0")}";
                            sLine = sLine.Replace(",∞,", ",0,");
                            sLine = sLine.Replace(",-∞,", ",0,");
                            sLine = sLine.Replace(",NaN,", ",0,");
                            skillSort.Add(sLine);

                            nPos++;
                        }
                    }
                    skillSort.Reverse();
                    foreach (string line in skillSort)
                        sInstanceSkillDBLines.Add(line);
                }
                catch (Exception ex)
                {
                    LogError(ex, "Error while setting up skilldb line to add");
                }
            }

            string sDuration = (tLastUpdate - tInstanceStart).ToString("mm':'ss");
            sInstanceLines.Insert(1, uYOUID.ToString() + ",Init,Init,Init,0,Instance : " + uCurrentInstance.ToString() + " - Duration : " + sDuration + " - " + tInstanceStart.ToString() + "," + lTotalDamage.ToString() + "," + lZanverse.ToString());

            try
            {
                File.WriteAllLines(sDir + "\\InstanceData.csv", sInstanceLines.ToArray());
                File.WriteAllLines(sDir + "\\InstanceData.skilldb", sInstanceSkillDBLines.ToArray());
            }
            catch (Exception e1)
            {
                LogError(e1, "Error while writing InstanceData files!");
            }
        }

        void About(object sender, EventArgs e)
        {
            if (about is AboutBox)
                about.Show();
        }

        void FolderLocation(object sender, EventArgs e)
        {
            ChooseLocation();
        }

        void ChooseLocation()
        {
            FolderBrowserDialog oBrowse = new FolderBrowserDialog
            {
                Description = "Please select location of pso2_bin\\damagelog"
            };
            DialogResult oResult = oBrowse.ShowDialog();
            if (oResult == DialogResult.OK)
            {
                string sPath = oBrowse.SelectedPath;
                sLogDir = sPath;
                UpdateSettingsFile();
                SecondInit();
            }
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            if (LogFileName != "")
            {
                LastStream.Close();
                LastLogFile.Close();
            }

            if (!oGraphStart.CloseMainWindow())
            {
                oGraphStart.Kill();
            }
            oGraphStart.Close();

            Application.Exit();
        }

        private void InitializeSkillDict()
        {
            try
            {
                using (StreamReader sr = new StreamReader(sDir + "\\skills.csv"))
                {
                    string line;
                    if (sr.ReadLine() != null)
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] tmp = line.Split(',');
                            Skill s;
                            s.Name = tmp[0];
                            s.Type = tmp[2];
                            s.Comment = tmp[3];
                            if (!skillDict.ContainsKey(Convert.ToUInt32(tmp[1])))
                                skillDict.Add(Convert.ToUInt32(tmp[1]), s);
                            if (!revSkillDict.ContainsKey(s.Name))
                                revSkillDict.Add(s.Name, Convert.ToUInt32(tmp[1]));
                        }
                }

                using (StreamReader sr = new StreamReader(sDir + "\\skills-noJA.csv"))
                {
                    string line;
                    if (sr.ReadLine() != null)
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] tmp = line.Split(',');
                            Skill s;
                            s.Name = tmp[0];
                            s.Type = tmp[2];
                            s.Comment = tmp[3];
                            if (!noJADict.ContainsKey(Convert.ToUInt32(tmp[1])))
                                noJADict.Add(Convert.ToUInt32(tmp[1]), s);
                        }
                }

                using (StreamReader sr = new StreamReader(sDir + "\\skills-Main.csv"))
                {
                    string line;
                    if (sr.ReadLine() != null)
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] tmp = line.Split(',');
                            uint nSkillID = Convert.ToUInt32(tmp[0]);
                            string sClass = tmp[1];

                            if (!MainClassLookup.ContainsKey(Convert.ToUInt32(tmp[0])))
                                MainClassLookup.Add(Convert.ToUInt32(tmp[0]), sClass);
                        }
                }

                using (StreamReader sr = new StreamReader(sDir + "\\skills-Weapon.csv"))
                {
                    string line;
                    if (sr.ReadLine() != null)
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] tmp = line.Split(',');
                            uint nSkillID = Convert.ToUInt32(tmp[0]);
                            string sClass = tmp[1];
                            string sWeapon = tmp[2];

                            if (!ClassLookup.ContainsKey(Convert.ToUInt32(tmp[0])))
                                ClassLookup.Add(Convert.ToUInt32(tmp[0]), sClass);
                            if (!WeaponLookup.ContainsKey(Convert.ToUInt32(tmp[0])))
                                WeaponLookup.Add(Convert.ToUInt32(tmp[0]), sWeapon);
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadSettingsFile()
        {
            if (File.Exists(sDir + "\\ParseInstance.ini"))
            {
                string[] sOptions = WriteSafeReadAllLines(sDir + "\\ParseInstance.ini");
                foreach (string sLine in sOptions)
                {
                    string[] tmp = sLine.Split('=');
                    switch (tmp[0])
                    {
                        case "damagelog":
                            sLogDir = tmp[1];
                            break;

                        default:
                            break;
                    }
                }
            }
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
        private void UpdateSettingsFile()
        {            
            string sSettingsText = $"damagelog={sLogDir}";

            if (File.Exists(sDir + "\\ParseInstance.ini"))
                File.Delete(sDir + "\\ParseInstance.ini");

            File.WriteAllLines(sDir + "\\ParseInstance.ini", sSettingsText.Split('\n'));
        }
        private void LogError(Exception e, string sErrorMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\ParseInstance.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + Environment.NewLine + "Error Message : " + sErrorMsg);
                logWriter.WriteLine("Message :" + e.Message + "<br/>" + Environment.NewLine + "StackTrace :" + e.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                logWriter.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
        private void LogError(string sErrorMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\ParseInstance.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + " - Error Message : " + sErrorMsg);
            }
        }
        private void LogMessage(string sMsg)
        {
            string sLogDir = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            string filePath = sLogDir + "\\ParseInstance.log";
            using (StreamWriter logWriter = new StreamWriter(filePath, true))
            {
                logWriter.WriteLine("Date :" + DateTime.Now.ToString() + " - Message : " + sMsg);
            }
        }

        private void StartMiniGraph()
        {
            string sMiniGraphExe = "MiniGraph.exe";
            if (File.Exists(sDir + "\\Starter.ini"))
            {
                string[] sOptions = WriteSafeReadAllLines(sDir + "\\Starter.ini");
                foreach (string sLine in sOptions)
                {
                    string[] tmp = sLine.Split('=');
                    if (tmp[0] == "MiniGraph.exe")
                    {
                        sMiniGraphExe = tmp[1];
                        break;
                    }
                }
            }

            oGraphStart.StartInfo.FileName = sMiniGraphExe;
            oGraphStart.StartInfo.UseShellExecute = false;
            oGraphStart.StartInfo.RedirectStandardOutput = true;
            oGraphStart.StartInfo.RedirectStandardError = true;
            oGraphStart.EnableRaisingEvents = true;
            oGraphStart.Exited += new EventHandler(MiniGraph_Exited);

            oGraphStart.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    LogMessage(e.Data);
                }
            });

            oGraphStart.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    LogError(e.Data);
                }
            });

            oGraphStart.Start();
            oGraphStart.BeginOutputReadLine();
            oGraphStart.BeginErrorReadLine();
        }

        private void MiniGraph_Exited(object sender, EventArgs e)
        {
            // Probably MiniGraph crashed?
            LogMessage("MiniGraph Exited : - Exit Code : " + oGraphStart.ExitCode.ToString());
            StartMiniGraph();
        }
    }
}
