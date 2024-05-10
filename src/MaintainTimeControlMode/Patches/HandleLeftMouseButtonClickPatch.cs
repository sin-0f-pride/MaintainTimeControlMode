using HarmonyLib;
using SandBox.View.Map;
using TaleWorlds.CampaignSystem;

namespace MaintainTimeControlMode.Patches
{
    [HarmonyPatch(typeof(MapScreen), "HandleLeftMouseButtonClick")]
    public static class HandleLeftMouseButtonClickPatch
    {
        public static void Postfix()
        {
            if (SubModule.LeftEncounter && SubModule.LastTimeControlMode != CampaignTimeControlMode.Stop)
            {
                Campaign.Current.TimeControlMode = SubModule.LastTimeControlMode;
            }
            SubModule.LeftEncounter = false;
        }
    }
}
