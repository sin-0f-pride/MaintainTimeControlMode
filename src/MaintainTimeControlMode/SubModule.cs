using System.IO;
using System;

using HarmonyLib;
using TaleWorlds.MountAndBlade;
using TaleWorlds.CampaignSystem;

namespace MaintainTimeControlMode
{
    public class SubModule : MBSubModuleBase
    {
        private static bool _leftEncounter;
        private static CampaignTimeControlMode _lastTimeControlMode;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            new Harmony("mod.bannerlord.maintaintimecontrolmode").PatchAll();
        }

        public static void Log(string message)
        {
            string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Mount and Blade II Bannerlord", "Logs");
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            string path = Path.Combine(text, "MaintainTimeControlMode.txt");
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine("[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + message);
            }
        }

        public static bool LeftEncounter
        {
            get => _leftEncounter;

            set
            {
                if (value != _leftEncounter)
                {
                    _leftEncounter = value;
                }
            }
        }
        public static CampaignTimeControlMode LastTimeControlMode
        {
            get => _lastTimeControlMode;

            set
            {
                if (value != _lastTimeControlMode)
                {
                    _lastTimeControlMode = value;
                }
            }
        }
    }
}