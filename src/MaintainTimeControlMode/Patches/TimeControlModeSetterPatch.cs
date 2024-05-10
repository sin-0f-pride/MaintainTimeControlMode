using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace MaintainTimeControlMode.Patches
{
    [HarmonyPatch(typeof(Campaign), "TimeControlMode", MethodType.Setter)]
    public static class TimeControlModeSetterPatch
    {
        public static void Postfix(Campaign __instance)
        {
            CampaignTimeControlMode mode = __instance.TimeControlMode;
            if (mode != CampaignTimeControlMode.Stop)
            {
                SubModule.LastTimeControlMode = mode;
            }
        }
    }
}
