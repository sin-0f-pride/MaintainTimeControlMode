using HarmonyLib;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;

namespace MaintainTimeControlMode.Patches
{
    [HarmonyPatch(typeof(PlayerEncounter), "Finish")]
    public static class PlayerEncounterFinishPatch
    {
        public static void Postfix()
        {
            if (MobileParty.MainParty.Army == null || MobileParty.MainParty.Army.LeaderParty == PlayerEncounter.EncounteredMobileParty)
            {
                SubModule.LeftEncounter = true;
            }
        }
    }
}
